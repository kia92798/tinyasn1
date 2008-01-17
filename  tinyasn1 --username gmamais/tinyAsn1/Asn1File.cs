using System;
using System.Collections.Generic;
using System.Text;
using Antlr.Runtime.Tree;
using Antlr.Runtime;
using System.IO;
using System.Text.RegularExpressions;

namespace tinyAsn1
{
    public partial class Asn1CompilerInvokation
    {
        public List<Asn1File> m_files = new List<Asn1File>();

        public void CreateASTs(List<string> inputFiles)
        {
            foreach (string inFileName in inputFiles)
            {
                ICharStream input = new ANTLRFileStream(inFileName);
                asn1Lexer lexer = new asn1Lexer(input);
                CommonTokenStream tokens = new CommonTokenStream(lexer);

                List<IToken> tokenslst = new List<IToken>();
                foreach (IToken token in tokens.GetTokens())
                {
                    tokenslst.Add(token);
                   //if (token.Type!= asn1Lexer.WS)
                   //     Console.WriteLine("{0}\t{1}", token.Type, token.Text);
//                    Console.WriteLine("{0}\t{1}\t{2}", token.Type, token.Text, token.Line,token.CharPositionInLine);
                }




                asn1Parser parser = new asn1Parser(tokens);
                asn1Parser.moduleDefinitions_return result = parser.moduleDefinitions();

                CommonTree tree = (CommonTree)result.Tree;
                CommonTreeNodeStream nodes = new CommonTreeNodeStream(tree);
                nodes.TokenStream = tokens;

                Asn1File asnFile = Asn1File.CreateFromAntlrAst(tree);
                asnFile.m_fileName = inFileName;
                asnFile.m_tokes.AddRange(tokenslst);
                m_files.Add(asnFile);
            }
            EarlySemanticCheck();
        }

        void EarlySemanticCheck()
        {
            List<string> m_modNames = new List<string>();

            foreach (Asn1File f in m_files)
                foreach (Module mod in f.m_modules)
                {
                    if (m_modNames.Contains(mod.m_moduleID))
                        throw new SemanticErrorException("Error: Module with name '" + mod.m_moduleID + "' defined twice"); //12.5
                    m_modNames.Add(mod.m_moduleID);
                }

        }



        private Asn1CompilerInvokation() { }
        private static Asn1CompilerInvokation m_instance;
        public static Asn1CompilerInvokation Instance
        {
            get
            {
                if (m_instance == null)
                    m_instance = new Asn1CompilerInvokation();
                return m_instance;
            }
        }

        public bool isModuleDefined(string modName)
        {
            foreach (Asn1File f in m_files)
                foreach (Module m in f.m_modules)
                    if (m.m_moduleID == modName)
                        return true;
            return false;
        }

        public Module GetModuleByName(string modName)
        {
            foreach (Asn1File f in m_files)
                foreach (Module m in f.m_modules)
                    if (m.m_moduleID == modName)
                        return m;
            throw new SemanticErrorException("Error no module is defined with name: '" + modName + "'");
        }

        public void SemanticParse()
        {
            
//Phase 1: Resolve type & variables, but not constraints
//The AST may be traversed multiple times during phase 1
            int loops = 0;
            while (!Phase1Finished())
            {
                foreach (Asn1File f in m_files)
                    foreach (Module m in f.m_modules)
                        m.DoPhase1SemanticAnalysis();
                loops++;
                if (loops > 100)
                {
                    StringWriter er = new StringWriter();
                    er.WriteLine("Error: grammar contains cyclic references. Unresolved types or variables are:");
                    foreach (Asn1File f in m_files)
                        foreach (Module m in f.m_modules)
                        {

                            string fname = f.m_fileName;
                            try {
                                fname = fname.Substring(fname.LastIndexOf('\\')+1);
                            } catch(Exception) {}
                            
                            foreach (TypeAssigment tas in m.m_typeAssigments.Values)
                                if (!tas.m_type.SemanticAnalysisFinished())
                                    er.WriteLine("File {0}, line {1}, type {2}", fname, tas.m_type.antlrNode.Line, tas.m_type.Name);

                            foreach (ValueAssigment vas in m.m_valuesAssigments.Values)
                                if (!vas.m_value.IsResolved())
                                    er.WriteLine("File {0}, line {1}", fname, vas.m_type.antlrNode.Line);
                        }
                    throw new SemanticErrorException(er.ToString());
                    
                }

            }


//Phase 2: Resolve constraints
//The AST may be traversed multiple times during phase 2
            while (!Phase2Finished())
            {
                foreach (Asn1File f in m_files)
                    foreach (Module m in f.m_modules)
                    {
                        foreach (TypeAssigment tas in m.m_typeAssigments.Values)
                            tas.m_type.ResolveConstraints();
                        foreach (ValueAssigment vas in m.m_valuesAssigments.Values)
                            vas.m_type.ResolveConstraints();
                    }
            }

//Phase 3: Check default vaules
            foreach (Asn1File f in m_files)
                foreach (Module m in f.m_modules)
                {
                    foreach (TypeAssigment tas in m.m_typeAssigments.Values)
                        tas.m_type.CheckDefaultValues();
                    foreach (ValueAssigment vas in m.m_valuesAssigments.Values)
                        vas.m_type.CheckDefaultValues();
                }

//Phase 4: Apply AUTOMATIC TAGGING if necessary
            foreach (Asn1File f in m_files)
                foreach (Module m in f.m_modules)
                {
                    if (m.m_taggingMode == TaggingMode.AUTOMATIC)
                    {
                        foreach (TypeAssigment tas in m.m_typeAssigments.Values)
                            tas.m_type.PerformAutomaticTagging();
                        foreach (ValueAssigment vas in m.m_valuesAssigments.Values)
                            vas.m_type.PerformAutomaticTagging();
                    }
                }

//Phase 5: Check Tags
            foreach (Asn1File f in m_files)
                foreach (Module m in f.m_modules) 
                    foreach (TypeAssigment tas in m.m_typeAssigments.Values)
                        tas.m_type.CheckChildrensTags();

//Phase 6: Check if there are defined variables that violate their type's constraints
            foreach (Asn1File f in m_files)
                foreach (Module m in f.m_modules)
                    foreach (ValueAssigment vs in m.m_valuesAssigments.Values)
                        if (!vs.m_type.isValueAllowed(vs.m_value))
                            Console.Error.WriteLine("Warning: value '" + vs.m_name + "'defined in line " + vs.m_value.antlrNode.Line +
                                " does not conform to its type constraints");

//Phase 7: Compute PER effective constraints
            foreach (Asn1File f in m_files)
                foreach (Module m in f.m_modules)
                {
                    foreach (TypeAssigment tas in m.m_typeAssigments.Values)
                        tas.m_type.ComputePEREffectiveConstraints();
                    foreach (ValueAssigment vas in m.m_valuesAssigments.Values)
                        vas.m_type.ComputePEREffectiveConstraints();
                }
        }

        private bool Phase1Finished()
        {
            foreach (Asn1File f in m_files)
                if (!f.SemanticCheckFinished())
                    return false;
            return true;
        }

        private bool Phase2Finished()
        {
            foreach (Asn1File f in m_files)
                foreach (Module m in f.m_modules)
                {
                    foreach (TypeAssigment t in m.m_typeAssigments.Values)
                        if (!t.m_type.AreConstraintsResolved())
                            return false;
                    foreach (ValueAssigment v in m.m_valuesAssigments.Values)
                        if (!v.m_type.AreConstraintsResolved())
                            return false;
                }
            return true;
        }


        public void debug()
        {
            PrintAsn1();
        }
        
        public virtual void PrintAsn1()
        {
            foreach (Asn1File file in m_files)
                file.PrintAsn1();

        }


        public void Tabularize()
        {
            foreach (Asn1File file in m_files)
                file.Tabularize();
        }

        public virtual void PrintHtml(string f)
        {
            if (m_files.Count > 0)
            {
                string fileName = null;
                if (f == null)
                {
                    fileName = m_files[0].m_fileName;

                    if (fileName.ToUpper().EndsWith(".ASN1"))
                        fileName = fileName.Substring(0, fileName.Length - 5) + ".html";
                    else if (fileName.ToUpper().EndsWith(".ASN"))
                        fileName = fileName.Substring(0, fileName.Length - 4) + ".html";
                    else
                        fileName += ".html";
                }
                else
                    fileName = f;

                StreamWriterLevel wr=null;
                try
                {
                    wr = new StreamWriterLevel(fileName);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex.Message);
                    return;
                }
                wr.WriteLine("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Strict//EN\"");
                wr.WriteLine("        \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd\">");

                wr.WriteLine("<html xmlns=\"http://www.w3.org/1999/xhtml\" >");
                wr.WriteLine("<head>");
                wr.WriteLine("    <title>ASN.1 Test Cases</title>");
//                wr.WriteLine("    <link href=\"asn1Matrix.css\" rel=\"stylesheet\" type=\"text/css\" />");
                wr.WriteLine("    <style type=\"text/css\"> {0} </style>", Asn1File.css); 
                wr.WriteLine("</head>");
                wr.WriteLine("<body>");
                
                
                foreach (Asn1File file in m_files)
                    file.PrintHtml(wr, 0);

                foreach (Asn1File file in m_files)
                    file.PrintAsn1InHtml(wr, 0);

                wr.WriteLine("</body>");
                wr.WriteLine("</html>");

                wr.Flush();
                wr.Close();

            }
        }

        internal void EncodeVars()
        {
            foreach (Asn1File file in m_files)
                file.EncodeVars();
        }

    }


    public partial class Asn1File
    {
        public List<IToken> m_tokes = new List<IToken>();
        public string m_fileName = "";
        public List<Module> m_modules = new List<Module>();

        public virtual void PrintAsn1()
        {
            StreamWriterLevel wr = new StreamWriterLevel(m_fileName + ".txt");
            foreach (Module m in m_modules)
                m.PrintAsn1(wr, 0);

            wr.Flush();
            wr.Close();

        }

        public void EncodeVars()
        {
            foreach (Module m in m_modules)
                m.EncodeVars(m_fileName);
        }

        ITree tree;

        //^(ASN1_FILE moduleDefinition*)
        static public Asn1File CreateFromAntlrAst(ITree tree)
        {
            if (tree.Type != asn1Parser.ASN1_FILE)
                throw new Exception("ASN1_FILE");

            Asn1File ret = new Asn1File();
            ret.tree = tree;

            for (int i = 0; i < tree.ChildCount; i++)
                ret.m_modules.Add(Module.CreateFromAntlrAst(tree.GetChild(i)));

            return ret;
        }
        internal bool SemanticCheckFinished()
        {
            foreach (Module m in m_modules)
                if (!m.SemanticCheckFinished())
                    return false;
            return true;
        }



        public void PrintHtml(StreamWriterLevel wr, int lev)
        {
            Tabularize();

            wr.WriteLine("    <div style=\"width: 100%\">");
            wr.WriteLine(string.Format("    <h1 >File : {0}</h1>", System.IO.Path.GetFileName(m_fileName)));

            foreach (Module m in m_modules)
                m.PrintHtml(wr, lev);

            wr.WriteLine("    </div>");

            wr.Flush();

        }

        public void PrintAsn1InHtml(StreamWriterLevel wr, int lev)
        {
            //string fname = m_fileName.Substring(m_fileName.LastIndexOf( 
            
            wr.WriteLine("    <div style=\"width: 100%\">");
            wr.WriteLine("    <h1 >File : {0}</h1>", System.IO.Path.GetFileName(m_fileName));
            wr.WriteLine("<div style=\"width: 100%; white-space:pre; font-family:Courier New; font-size:small\">");
            wr.Write(getAsn1InHtml());
            wr.WriteLine("</div>");
            wr.WriteLine("    </div>");
        }
        /*
         
         */

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        string getAsn1InHtml()
        {
            List<string> tas = new List<string>();
            Dictionary<int, string> tabulTyps = new Dictionary<int, string>();
            foreach (Module m in m_modules)
            foreach (TypeAssigment ta in m.m_typeAssigments.Values)
            {
                if (!ta.m_createdThroughTabulization)
                    tas.Add(ta.m_name);
                else
                    tabulTyps.Add(ta.m_type.antlrNode.TokenStartIndex, ta.m_name);
            }
            List<string> asn1Words = new List<string>(m_asn1Tokens);
            string ret = "";
            for (int i = 0; i < m_tokes.Count; i++)
            {
                IToken t = m_tokes[i];
                if (tabulTyps.ContainsKey(i))
                    ret += "<a name=\"ASN1_" + tabulTyps[i].Replace("-", "_") + "\">" + t.Text + "</a>";
                else if (asn1Words.Contains(t.Text))
                    ret += "<b><font  color=\"#5F9EA0\" >" + t.Text + "</font></b>";
                else if (t.Type == asn1Lexer.StringLiteral || t.Type == asn1Lexer.OctectStringLiteral || t.Type == asn1Lexer.BitStringLiteral)
                    ret += "<font  color=\"#A31515\" >" + t.Text + "</font>";
                else if (t.Type == asn1Lexer.UID && tas.Contains(t.Text))
                {
                    int j = i + 1;
                    while (j < m_tokes.Count)
                        if (m_tokes[j].Type == asn1Lexer.WS || m_tokes[j].Type == asn1Lexer.COMMENT || m_tokes[j].Type == asn1Lexer.COMMENT2)
                            j++;
                        else
                            break;
                    //<a href="#ASN1_MYSQOF">ASN.1</a>
                    if (m_tokes[j].Type == asn1Lexer.ASSIG_OP)
//                        ret += "<a name=\"ASN1_" + t.Text.Replace("-", "_") + "\"><a href=\"#ICD_" + t.Text.Replace("-", "_") + "\"><font  color=\"#2B91AF\" >" + t.Text + "</font></a></a>";
                        ret += "<a name=\"ASN1_" + t.Text.Replace("-", "_") + "\"></a><a href=\"#ICD_" + t.Text.Replace("-", "_") + "\"><font  color=\"#B8860B\" ><b>" + t.Text + "</b></font></a>";
                    else
                        ret += "<a href=\"#ASN1_" + t.Text.Replace("-", "_") + "\"><font  color=\"#000000\" >" + t.Text + "</font></a>";
                }
                else if (t.Type == asn1Lexer.COMMENT || t.Type == asn1Lexer.COMMENT2)
                    ret += "<font  color=\"#008000\" ><i>" + t.Text + "</i></font>";
                else if (t.Type == asn1Lexer.SPECIAL_COMMENT)
                    ret += "<font  color=\"#808080\" >" + t.Text + "</font>";
                else
                    ret += t.Text;
            }

            return ret;
        }


        public void Tabularize()
        {
            foreach (Module m in m_modules)
                m.Tabularize();
        }

        static string[] m_asn1Tokens = {
            "PLUS-INFINITY", "MINUS-INFINITY", "GeneralizedTime", "UTCTime", "mantissa", "base", "exponent", "UNION", "INTERSECTION",
            "DEFINITIONS", "EXPLICIT", "TAGS", "IMPLICIT", "AUTOMATIC", "EXTENSIBILITY", "IMPLIED", "BEGIN", "END", "EXPORTS", "ALL",
            "IMPORTS", "FROM", "UNIVERSAL", "APPLICATION", "PRIVATE", "BIT", "STRING", "BOOLEAN", "ENUMERATED", "INTEGER", "REAL",
            "OPTIONAL", "SIZE", "OCTET", "MIN", "MAX", "TRUE", "FALSE", "ABSENT", "PRESENT", "WITH",
            "COMPONENT", "DEFAULT", "NULL", "PATTERN", "OBJECT", "IDENTIFIER", "RELATIVE-OID", "NumericString",
            "PrintableString", "VisibleString", "IA5String", "TeletexString", "VideotexString", "GraphicString", "GeneralString",
            "UniversalString", "BMPString", "UTF8String", "INCLUDES", "EXCEPT", "SET", "SEQUENCE","CHOICE","OF","COMPONENTS"
            };
        

        public static string css = @"
.headerRow
{
	background-color: #BBBBBB;
}

.hrNo
{
	text-align: center;
	font-family: Verdana;
	color: white;
	font-size: 10pt;
	width: 3%;
}
.hrField
{
	text-align: center;
	font-family: Verdana;
	color: white;
	font-size: 10pt;
	width:15%;
}

.hrComment
{
	text-align: center;
	font-family: Verdana;
	color: white;
	font-size: 10pt;
}

.hrType
{
	text-align: center;
	font-family: Verdana;
	color: white;
	font-size: 10pt;
	width:10%;
}

.hrconstraint
{
	text-align: center;
	font-family: Verdana;
	color: white;
	font-size: 10pt;
	width:10%;
}

.hrconstraint2
{
	text-align: center;
	font-family: Verdana;
	color: white;
	font-size: 10pt;
}

.hrOptional
{
	text-align: center;
	font-family: Verdana;
	color: white;
	font-size: 10pt;
	width:10%;
}
.hrMin
{
	text-align: center;
	font-family: Verdana;
	color: white;
	font-size: 10pt;
	width:10%;
}
.hrMax
{
	text-align: center;
	font-family: Verdana;
	color: white;
	font-size: 10pt;
	width:10%;
}

.hrMin2
{
	text-align: center;
	font-family: Verdana;
	color: white;
	font-size: 10pt;
	width:20%;
}
.hrMax2
{
	text-align: center;
	font-family: Verdana;
	color: white;
	font-size: 10pt;
	width:20%;
}

.CommentRow
{
	background-color: #e9e9e9;
	height:25px;
}

.OddRow
{
	background-color: #e9e9e9;
	height:25px;
}

.EvenRow
{
	background-color: #DBDBDB;
	height:25px;
}


.no
{
	text-align:  center;
	font-family: Verdana;
	color: black;
	font-size: 9pt;
/*	width:30pt;*/
}

.field
{
	text-align: center;
	font-family: Verdana;
	color: black;
	font-size: 9pt;
/*	width:15%;*/
}

.field2
{
	text-align: center;
	font-family: Verdana;
	color: black;
	font-size: 9pt;
}

.comment
{
	color: black;
/*	width:25%;*/
	font-family: Verdana;
	font-size: 9pt;
	text-align:left;
}

.comment2
{
	color: black;
	font-family: Verdana;
	font-size: 9pt;
	text-align:left;
}

.threeDots
{
	color: black;
	font-family: Verdana;
	font-size: 9pt;
	text-align:center;
}

.type
{
	text-align: center;
	font-family: Verdana;
	color: black;
	font-size: 9pt;
/*	width:10%;*/
}

.type2
{
	text-align: center;
	font-family: Verdana;
	color: black;
	font-size: 9pt;
}

.constraint
{
	text-align: center;
	font-family: Verdana;
	color: black;
	font-size: 9pt;
}

.optional
{
	text-align: center;
	font-family: Verdana;
	color: black;
	font-size: 9pt;
/*	width:10%;*/
}
.min
{
	text-align: center;
	font-family: Verdana;
	color: black;
	font-size: 9pt;
/*	width:70pt;*/
}
.max
{
	text-align: center;
	font-family: Verdana;
	color: black;
	font-size: 9pt;
/*	width:70pt;*/
}

.min2
{
	text-align: center;
	font-family: Verdana;
	color: black;
	font-size: 9pt;
}
.max2
{
	text-align: center;
	font-family: Verdana;
	color: black;
	font-size: 9pt;
}


h1
{
	font-family: Verdana, Tahoma;
	color: #033a7a;
	font-size: 14pt;
}

h2
{
	font-family: Verdana, Tahoma;
	color: #033a7a;
	font-size: 12pt;
}
";
    }


}
