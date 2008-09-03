/**=============================================================================
Definition of DefaultBackend and Asn1File classes used
in autoICD and asn1scc projects  
================================================================================
Copyright(c) Semantix Information Technologies S.A www.semantix.gr
All rights reserved.

This source code is only intended as a supplement to the
Semantix Technical Reference and related electronic documentation 
provided with the autoICD and asn1scc applications.
See these sources for detailed information regarding the
asn1scc and autoICD applications.
==============================================================================*/

using System;
using System.Collections.Generic;
using System.Text;
using Antlr.Runtime.Tree;
using Antlr.Runtime;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace tinyAsn1
{


    public class AsnTypeVisitor<T> where T : Asn1Type 
    {
        private DefaultBackend m_backend = null;
        public AsnTypeVisitor(DefaultBackend backend)
        {
            m_backend = backend;
        }


        public List<T> GetTypes() 
        {

            List<T> ret = new List<T>();

            ret.AddRange(m_backend.GetTypes<T>());

            return ret;
        }

    }



    /// <summary>
    /// This is a singleton class (i.e. only one instance can exist)
    /// It is the root element in the generated AST (i.e. the class that
    /// contains all others)
    /// Most important attribute is m_files which is the list of all files
    /// passed in the command line argument
    /// </summary>
    public class DefaultBackend
    {

        // The following attributes correspond to the equivalent command 
        // line arguments which are passed to the application during
        // the invocation

        public string TypePrefix = string.Empty;
        public static bool m_HtmlIntegerSizeMustBeExplained = false;
        public static bool m_HtmlRealSizeMustBeExplained = false;
        public static bool m_HtmlLengthSizeMustBeExplained = false;
        public static bool displayTypesAsAppearInAsn1Grammar = false;
        public static string _m_outDirectory = Environment.CurrentDirectory;

        
        /// <summary>
        /// Return the Asn1AbstractFactory
        /// Must be overriden in the subclass
        /// </summary>
        public virtual IAsn1AbstractFactory Factory { get { return new DefaultAsn1Factory(); } }

        /// <summary>
        /// the list of all files
        /// passed in the command line argument
        /// </summary>
        public List<Asn1File> m_files = new List<Asn1File>();

        /// <summary>
        /// The directory where all output files must be generated
        /// </summary>
        public static string m_outDirectory
        {
            get
            {
                if (_m_outDirectory != "" && !_m_outDirectory.EndsWith(Path.DirectorySeparatorChar.ToString()))
                    _m_outDirectory += Path.DirectorySeparatorChar;
                return _m_outDirectory;
            }
            set { _m_outDirectory = value; }
        }

        /// <summary>
        /// Auxiliary methods for implementing the visitor pattern
        /// </summary>
        public IEnumerable<T> GetTypes<T>() where T : Asn1Type
        {
            foreach (Asn1File f in m_files)
                foreach (T t in f.GetTypes<T>())
                    yield return t;
        }

        /// <summary>
        /// Auxiliary methods for implementing the visitor pattern
        /// </summary>
        public IEnumerable<KeyValuePair<string, T>> GetTypesWithPath<T>() where T : Asn1Type
        {
            foreach (Asn1File f in m_files)
                foreach (KeyValuePair<string, T> t in f.GetTypesWithPath<T>())
                    yield return t;
        }

        /// <summary>
        /// Create ASN.1 ASTs
        /// </summary>
        /// <param name="inputFiles">The list with input asn1 files</param>
        public void CreateASTs(List<string> inputFiles)
        {
            foreach (string inFileName in inputFiles)
            {
                ICharStream input = new ANTLRFileStream(inFileName);
                asn1Lexer lexer = new asn1Lexer(input);
                CommonTokenStream tokens = new CommonTokenStream(lexer);

                List<IToken> tokenslst = new List<IToken>();
                foreach (IToken token in tokens.GetTokens())
                    tokenslst.Add(token);




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



        public DefaultBackend() 
        {
            if (m_instance != null)
                throw new Exception("Internal Error. Only one instance of Asn1CompilerInvokation can exist");
            m_instance = this; 
        }
        private static DefaultBackend m_instance = null;
        public static DefaultBackend Instance
        {
            get
            {
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


        /// <summary>
        /// Main method that Initializes the Semantic parse checking (and AST reconstruction)
        /// </summary>
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

            foreach (KeyValuePair<string, Asn1Type> v in GetTypesWithPath<Asn1Type>())
                v.Value.UniquePath = v.Key;


//Phase 8: Check Sets i.e. check that no type has contraints that allow no values

            foreach (Asn1Type t in GetTypes<Asn1Type>())
            {
                ISet s = t.GetSet();
                //Console.WriteLine("== Set for type defined in line {0}", t.antlrNode.Line);
                //Console.WriteLine(s.ToString());
                if (s.isNull())
                {
                    throw new SemanticErrorException(String.Format("Error in line {0}. The contraints applied in this type do not allow any values.", t.antlrNode.Line));
                }

                OrderedDictionary<string, ISet> compSet = t.GetSetWithComponent();
                foreach (string comp in compSet.Keys)
                {
                    ISet cs = compSet[comp];
                    //Console.WriteLine("== \t With Component(s) set {0}", comp);
                    //Console.WriteLine(cs.ToString());
                    if (cs.isNull())
                    {
                        throw new SemanticErrorException(String.Format("Error in line {0}. The contraints applied in the inner type {1} do not allow any values.", t.antlrNode.Line, comp));
                    }
                }

            }




            FixComments();

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

        private void FixComment(List<IToken> FileTokens, List<IToken> alreadyTakenComments, int lastTokenLineNo,
            int prevTokenIndex, int nextTokenIndex, List<string> comments)
        {

            //first see if there comments on the same line

            while (nextTokenIndex >= 0 && nextTokenIndex < FileTokens.Count)
            {
                IToken t = FileTokens[nextTokenIndex++];
                if (alreadyTakenComments.Contains(t))
                    break;
                if (t.Line != lastTokenLineNo)
                    break;
                if (t.Type == asn1Lexer.WS)
                    continue;
                else if (t.Type == asn1Lexer.COMMENT || t.Type == asn1Lexer.COMMENT2)
                {
                    if (DefaultBackend.UseSpecialComments)
                    {
                        if (t.Text.StartsWith("--@"))
                        {
                            comments.Insert(0, t.Text);
                            alreadyTakenComments.Add(t);
                        }
                    }
                    else
                    {
                        comments.Insert(0, t.Text);
                        alreadyTakenComments.Add(t);
                    }
                }
                else
                    break;

            }

            //if no comments were found at the same line, then look back (above)
            if (comments.Count == 0)
            {

                while (prevTokenIndex >= 0 && prevTokenIndex < FileTokens.Count)
                {
                    IToken t = FileTokens[prevTokenIndex--];
                    if (alreadyTakenComments.Contains(t))
                        break;
                    if (t.Type == asn1Lexer.WS)
                        continue;
                    else if (t.Type == asn1Lexer.COMMENT || t.Type == asn1Lexer.COMMENT2)
                    {
                        if (DefaultBackend.UseSpecialComments)
                        {
                            if (t.Text.StartsWith("--@"))
                            {
                                comments.Insert(0, t.Text);
                                alreadyTakenComments.Add(t);
                            }
                        }
                        else
                        {
                            comments.Insert(0, t.Text);
                            alreadyTakenComments.Add(t);
                        }
                    }
                    else
                        break;
                }
            }
        }

        private void FixComments()
        {
            List<IToken> alreadyTakenComments = new List<IToken>();




            foreach (Asn1File f in m_files)
                foreach (Module m in f.m_modules)
                    FixComment(f.m_tokes, alreadyTakenComments, -1,
                        m.tree.TokenStartIndex - 1, -1, m.m_comments);


            foreach (Asn1File f in m_files)
                foreach (Module m in f.m_modules)
                    foreach (TypeAssigment ta in m.m_typeAssigments.Values)
                        FixComment(f.m_tokes, alreadyTakenComments, f.m_tokes[ta.antlrNode.TokenStopIndex].Line,
                            ta.antlrNode.TokenStartIndex - 1, ta.antlrNode.TokenStopIndex + 1, ta.m_comments);


            foreach (Asn1File f in m_files)
                foreach (Module m in f.m_modules)
                    foreach (SequenceOrSetType sq in m.GetTypes<SequenceOrSetType>())
                        foreach (SequenceOrSetType.Child ch in sq.m_children.Values)
                            FixComment(f.m_tokes, alreadyTakenComments, f.m_tokes[ch.antlrNode.TokenStopIndex].Line,
                                ch.antlrNode.TokenStartIndex - 1, ch.antlrNode.TokenStopIndex + 2, ch.m_comments);





            foreach (Asn1File f in m_files)
                foreach (Module m in f.m_modules)
                    foreach (ChoiceType sq in m.GetTypes<ChoiceType>())
                        foreach (ChoiceChild ch in sq.m_children.Values)
                            FixComment(f.m_tokes, alreadyTakenComments, f.m_tokes[ch.antlrNode.TokenStopIndex].Line,
                                ch.antlrNode.TokenStartIndex - 1, ch.antlrNode.TokenStopIndex + 2, ch.m_comments);

            
            foreach (Asn1File f in m_files)
                foreach (Module m in f.m_modules)
                    foreach(EnumeratedType en in m.GetTypes<EnumeratedType>())
                        foreach(EnumeratedType.Item item in en.m_enumValues.Values)
                            FixComment(f.m_tokes, alreadyTakenComments, f.m_tokes[item.antlrNode.TokenStopIndex].Line,
                                item.antlrNode.TokenStartIndex - 1, item.antlrNode.TokenStopIndex + 2, item.m_comments);



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

        public void EncodeVars()
        {
            foreach (Asn1File file in m_files)
                file.EncodeVars();
        }

        private static Dictionary<string, int> functionPasses = new Dictionary<string, int>();

        public static bool EnterRecursiveFunc(string methodName, object obj)
        {
            string curInstance = methodName + obj.GetHashCode().ToString();
            if (functionPasses.ContainsKey(curInstance))
                return false;

            functionPasses.Add(curInstance, 0);
            return true;
        }

        public static void LeaveRecursiveFunc(string methodName, object obj)
        {
            string curInstance = methodName + obj.GetHashCode().ToString();
            functionPasses.Remove(curInstance);
        }

        public static void CheckRecursiveFuncSetIsEmpty()
        {
            if (functionPasses.Count != 0)
                throw new Exception("Internal Error : Recursive Functions Set is NOT empty !");
        }


        /// <summary>
        /// When set to true (i.e. via an argument in the command line) only those comments starting
        /// with the special symbol @ are copied into the ICD 
        /// </summary>
        public static bool UseSpecialComments = false;




        public string GetUniqueID(string p)
        {
            return p;
        }

        int _constraintErrorID = 1000;
        public int ConstraintErrorID { get { return _constraintErrorID; } set { _constraintErrorID = value; } }

    }




    /// <summary>
    /// This class represent an ASN.1 file
    /// </summary>
    public partial class Asn1File
    {
        /// <summary>
        /// The name of ASN.1 file
        /// </summary>
        public string m_fileName = "";
        /// <summary>
        /// The list with all modules in this file
        /// </summary>
        public List<Module> m_modules = new List<Module>();

        /// <summary>
        /// The lexer token for this file
        /// </summary>
        public List<IToken> m_tokes = new List<IToken>();

        /// <summary>
        /// Auxiliary methods for implementing the visitor pattern
        /// </summary>
        public IEnumerable<T> GetTypes<T>() where T : Asn1Type
        {
            foreach (Module m in m_modules)
                foreach (T t in m.GetTypes<T>())
                    yield return t;
        }
        /// <summary>
        /// Auxiliary methods for implementing the visitor pattern
        /// </summary>
        public IEnumerable<KeyValuePair<string, T>> GetTypesWithPath<T>() where T : Asn1Type
        {
            foreach (Module m in m_modules)
                foreach (KeyValuePair<string, T> t in m.GetTypesWithPath<T>())
                    yield return t;
        }


        /// <summary>
        /// Prints the parsed AST in asn1 (used for debuggin)
        /// </summary>
        public virtual void PrintAsn1()
        {
            StreamWriterLevel wr = new StreamWriterLevel(m_fileName + ".txt");
            foreach (Module m in m_modules)
                m.PrintAsn1(wr, 0);

            wr.Flush();
            wr.Close();

        }

        /// <summary>
        /// encode all variables in the file
        /// </summary>
        public void EncodeVars()
        {
            foreach (Module m in m_modules)
                m.EncodeVars(m_fileName);
        }

        ITree tree;

        //^(ASN1_FILE moduleDefinition*)
        // Create File for antlr tree
        static public Asn1File CreateFromAntlrAst(ITree tree)
        {
            if (tree.Type != asn1Parser.ASN1_FILE)
                throw new Exception("ASN1_FILE");

            Asn1File ret = DefaultBackend.Instance.Factory.CreateAsn1File();
            ret.tree = tree;

            for (int i = 0; i < tree.ChildCount; i++)
                ret.m_modules.Add(Module.CreateFromAntlrAst(tree.GetChild(i),ret));

            return ret;
        }
        internal bool SemanticCheckFinished()
        {
            foreach (Module m in m_modules)
                if (!m.SemanticCheckFinished())
                    return false;
            return true;
        }

    }


}
