using System;
using System.Collections.Generic;
using System.Text;
using Antlr.Runtime.Tree;
using Antlr.Runtime;
using System.IO;
using System.Text.RegularExpressions;

namespace tinyAsn1
{
    public abstract class Asn1CompilerInvokation
    {

        public abstract IAsn1AbstractFactory Factory { get;}


        public string TypePrefix = string.Empty;

        public static bool m_HtmlIntegerSizeMustBeExplained = false;
        public static bool m_HtmlRealSizeMustBeExplained = false;
        public static bool m_HtmlLengthSizeMustBeExplained = false;
        public static bool m_FirstTopLevel = true;

        public static string _m_outDirectory = Environment.CurrentDirectory;
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

        public List<Asn1File> m_files = new List<Asn1File>();

        public IEnumerable<T> GetTypes<T>() where T : Asn1Type
        {
            foreach (Asn1File f in m_files)
                foreach (T t in f.GetTypes<T>())
                    yield return t;
        }

        public IEnumerable<KeyValuePair<string, T>> GetTypesWithPath<T>() where T : Asn1Type
        {
            foreach (Asn1File f in m_files)
                foreach (KeyValuePair<string, T> t in f.GetTypesWithPath<T>())
                    yield return t;
        }

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



        public Asn1CompilerInvokation() 
        {
            if (m_instance != null)
                throw new Exception("Internal Error. Only one instance of Asn1CompilerInvokation can exist");
            m_instance = this; 
        }
        private static Asn1CompilerInvokation m_instance = null;
        public static Asn1CompilerInvokation Instance
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

//            CheckDependencies();

            //foreach (Asn1File f in m_files)
            //    f.GetTypesWithNoDepends();

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
                    if (Asn1CompilerInvokation.UseSpecialComments)
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
                        if (Asn1CompilerInvokation.UseSpecialComments)
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




        /// <summary>
        /// It checks that
        /// * All strings, SEQUENCE OFs, SETs etc have SIZE constraint and that MAX is bounded
        /// 
        /// </summary>
        private void CheckStrictConstraintsNeededForAsn1cc()
        {
            foreach(Asn1File f in m_files)
                foreach (Module m in f.m_modules)
                {
                    foreach (SizeableType st in m.GetTypes<SizeableType>())
                    {
                        PERSizeEffectiveConstraint sz = st.PEREffectiveConstraint as PERSizeEffectiveConstraint;
                        if (sz == null)
                            ErrorReporter.SemanticError(f.m_fileName, st.antlrNode.Line, "This type({0}) must have a non extensible size constraint", st.Name);
                        if (sz.Extensible || sz.m_size.m_isExtended)
                            ErrorReporter.SemanticError(f.m_fileName, st.antlrNode.Line, "This type({0}) must have a non extensible size constraint", st.Name);
                        if (sz.m_size.m_rootRange.m_maxIsInfinite)
                            ErrorReporter.SemanticError(f.m_fileName, st.antlrNode.Line, "This type({0}) must have a non extensible size constraint with finite upper value", st.Name);
                    }
                    foreach (SequenceOrSetType sq in m.GetTypes<SequenceOrSetType>())
                    {
                        if (sq.IsPERExtensible())
                            ErrorReporter.SemanticError(f.m_fileName, sq.antlrNode.Line, "This type({0}) cannot be extensible", sq.Name);
                    }
                    foreach (ChoiceType ch in m.GetTypes<ChoiceType>())
                    {
                        if (ch.IsPERExtensible())
                            ErrorReporter.SemanticError(f.m_fileName, ch.antlrNode.Line, "This type({0}) cannot be extensible", ch.Name);
                    }
                    foreach (EnumeratedType en in GetTypes<EnumeratedType>())
                    {
                        if (en.IsPERExtensible())
                            ErrorReporter.SemanticError(f.m_fileName, en.antlrNode.Line, "This type({0}) cannot be extensible", en.Name);
                    }
                }
        }

        private void EnsureUniqueEnumerated()
        {
            List<string> enumKeys = new List<string>();
            List<string> doubleKeys = new List<string>();
            while (true)
            {
                enumKeys.Clear();
                foreach (EnumeratedType en in GetTypes<EnumeratedType>())
                {
                    List<string> path = new List<string>(en.UniquePath.Split('/'));
                    foreach (EnumeratedType.Item item in en.m_enumValues.Values)
                    {
                        if (doubleKeys.Contains(item.CID))
                        {
                            for (int i = path.Count - 1; i >= 0; i--)
                                if (!item.CID.Contains(path[i].Replace('-','_')))
                                {
                                    item.CID = path[i] + "_" + item.CID;
                                    break;
                                }
                        }
                        enumKeys.Add(item.CID);
                    } 
                }

                foreach (ChoiceType ch in GetTypes<ChoiceType>())
                {
                    List<string> path = new List<string>(ch.UniquePath.Split('/'));
                    if (doubleKeys.Contains(ch.CID_NONE))
                    {
                        for (int i = path.Count - 1; i >= 0; i--)
                            if (!ch.CID_NONE.Contains(path[i].Replace('-', '_')))
                            {
                                ch.CID_NONE = path[i] + "_" + ch.CID_NONE;
                                break;
                            }
                    }
                    enumKeys.Add(ch.CID_NONE);
                    foreach (ChoiceChild item in ch.m_children.Values)
                    {
                        if (doubleKeys.Contains(item.CID))
                        {
                            for (int i = path.Count - 1; i >= 0; i--)
                                if (!item.CID.Contains(path[i].Replace('-', '_')))
                                {
                                    item.CID = path[i] + "_" + item.CID;
                                    break;
                                }
                        }
                        enumKeys.Add(item.CID);
                    }
                }


                doubleKeys.Clear();
                for (int i = 0; i < enumKeys.Count; i++)
                {
                    for (int j = i + 1; j < enumKeys.Count; j++)
                    {
                        if (enumKeys[i] == enumKeys[j] && !doubleKeys.Contains(enumKeys[i]))
                            doubleKeys.Add(enumKeys[i]);
                    }
                }
                if (doubleKeys.Count == 0)
                    break;
            }
        }




        
        void CheckDependencies()
        {
            List<string> ret = new List<string>();
            List<TypeAssigment> tmp = new List<TypeAssigment>();

            foreach(Asn1File f in m_files)
                foreach (Module m in f.m_modules)
                    foreach (TypeAssigment t in m.m_typeAssigments.Values)
                        tmp.Add(t);

            while (tmp.Count > 0)
            {
                int lenBefore = tmp.Count;
                foreach (Asn1File f in m_files)
                {
                    foreach (Module m in f.m_modules)
                    {
                        foreach (TypeAssigment t in m.m_typeAssigments.Values)
                        {
                            if (t.DependsOnlyOn(ret) && !ret.Contains(t.m_name))
                            {
                                ret.Add(t.m_name);
                                tmp.Remove(t);
                            }
                        }
                    }
                }
                if (lenBefore == tmp.Count)
                {
                    Console.Error.WriteLine("Cyclic dependencies detected");
                    List<string> tmpstr = new List<string>();
                    foreach (TypeAssigment t in tmp)
                        tmpstr.Add(t.m_name);
                    foreach (TypeAssigment t in tmp)
                    {
                        Console.Error.WriteLine("Type {0} depends on: ",t.m_name);
                        List<string> dps = t.TypesIDepend();
                        foreach (string l in dps)
                            Console.Error.WriteLine("\t{0}", l);
                    }
                    throw new SemanticErrorException("Error: Asn1 grammar has cyclic dependencies");
                }
            }

        }

        public void printC()
        {
            CheckStrictConstraintsNeededForAsn1cc();
            EnsureUniqueEnumerated();
            foreach (Asn1File file in m_files)
                file.printC();
        }

        public void EncodeVars()
        {
            foreach (Asn1File file in m_files)
                file.EncodeVars();
        }


        internal string GetUniqueID(string p)
        {
            return p;
        }

        int _constraintErrorID = 1000;
        public int ConstraintErrorID { get { return _constraintErrorID; } set { _constraintErrorID = value; } }


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

    }


    public partial class Asn1File
    {
        public List<IToken> m_tokes = new List<IToken>();
        public string m_fileName = "";
        public List<Module> m_modules = new List<Module>();

        public IEnumerable<T> GetTypes<T>() where T : Asn1Type
        {
            foreach (Module m in m_modules)
                foreach (T t in m.GetTypes<T>())
                    yield return t;
        }
        public IEnumerable<KeyValuePair<string, T>> GetTypesWithPath<T>() where T : Asn1Type
        {
            foreach (Module m in m_modules)
                foreach (KeyValuePair<string, T> t in m.GetTypesWithPath<T>())
                    yield return t;
        }

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

            Asn1File ret = Asn1CompilerInvokation.Instance.Factory.CreateAsn1File();
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




        internal List<TypeAssigment> GetTypesWithNoDepends()
        {
            
            List<TypeAssigment> ret = new List<TypeAssigment>();
            List<TypeAssigment> tmp = new List<TypeAssigment>();
            List<string> retStr = new List<string>();

            foreach (Module m in m_modules)
            {
                foreach (ImportedModule imp in m.m_imports)
                    retStr.AddRange(imp.m_importedTypes);
                foreach (TypeAssigment t in m.m_typeAssigments.Values)
                    tmp.Add(t);
            }

            while (tmp.Count > 0)
            {
                int lenBefore = tmp.Count;
                foreach (Module m in m_modules)
                {
                    foreach (TypeAssigment t in m.m_typeAssigments.Values)
                    {
                        if (t.DependsOnlyOn(retStr) && !ret.Contains(t))
                        {
                            ret.Add(t);
                            tmp.Remove(t);
                            retStr.Add(t.m_name);
                        }
                    }
                }
                if (lenBefore == tmp.Count)
                {
                    string err = string.Empty;
                    foreach (TypeAssigment t in tmp)
                        err += t.m_name + " ";

                    throw new SemanticErrorException("Error: Asn1 grammar has cyclic dependencies: " + err);
                }
            }

            return ret;
        }


        internal void printC()
        {
            string path = Asn1CompilerInvokation.m_outDirectory;
            string fileName = Path.GetFileNameWithoutExtension(m_fileName);
            if (path != "" && !path.EndsWith(Path.DirectorySeparatorChar.ToString()))
                path += Path.DirectorySeparatorChar;

            using (StreamWriterLevel c = new StreamWriterLevel(path + fileName + ".c"))
            using (StreamWriterLevel h = new StreamWriterLevel(path + fileName + ".h"))
            {
                h.WriteLine("#ifndef _INC_{0}_H", C.ID(fileName).ToUpper());
                h.WriteLine("#define _INC_{0}_H", C.ID(fileName).ToUpper());
                h.WriteLine("/*");
                h.WriteLine("Code automatically generated by asn1cc tool");
                h.WriteLine("*/");
                h.WriteLine();


                foreach (Module m in m_modules)
                {
                    foreach (ImportedModule imp in m.m_imports)
                    {
                        Asn1File incf = null;
                        foreach (Asn1File f in Asn1CompilerInvokation.Instance.m_files)
                            foreach (Module exp in f.m_modules)
                                if (exp.m_moduleID == imp.m_moduleID)
                                    incf = f;
                        h.WriteLine("#include \"{0}.h\"", Path.GetFileNameWithoutExtension(incf.m_fileName));
                    }
                }


                h.WriteLine("#include \"asn1crt.h\"");
                h.WriteLine();
                h.WriteLine("#ifdef  __cplusplus");
                h.WriteLine("extern \"C\" {");
                h.WriteLine("#endif");
                h.WriteLine();
                List<TypeAssigment> tmp = GetTypesWithNoDepends();

                foreach (TypeAssigment t in tmp)
                {
                    string uniqueID = Asn1CompilerInvokation.Instance.TypePrefix+ Asn1CompilerInvokation.Instance.GetUniqueID(C.ID(t.m_name));
                    t.PrintH(h, uniqueID);
                }

                c.WriteLine();
                foreach (Module m in m_modules)
                    foreach (ValueAssigment v in m.m_valuesAssigments.Values)
                        v.PrintExternDeclaration(h);


                h.WriteLine("#ifdef  __cplusplus");
                h.WriteLine("}");
                h.WriteLine("#endif");
                h.WriteLine();

                h.WriteLine("#endif");


                c.WriteLine("/*");
                c.WriteLine("Code automatically generated by asn1cc tool");
                c.WriteLine("*/");

                c.WriteLine("#include <string.h>");
//                c.WriteLine("#include <assert.h>");


                c.WriteLine("#include \"{0}\"", fileName + ".h");
                foreach (TypeAssigment t in tmp)
                {
                    string uniqueID = Asn1CompilerInvokation.Instance.TypePrefix + Asn1CompilerInvokation.Instance.GetUniqueID(C.ID(t.m_name));
                    t.PrintC(c, uniqueID);
                }

                c.WriteLine();
                foreach (Module m in m_modules)
                    foreach (ValueAssigment v in m.m_valuesAssigments.Values)
                        v.PrintC(c);

            }
        }
    }


}
