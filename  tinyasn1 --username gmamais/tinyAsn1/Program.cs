using System;
using System.Collections.Generic;
using System.Text;


using Antlr.Runtime;
using Antlr.StringTemplate;
using Antlr.StringTemplate.Language;
using Antlr.Utility.Tree;
using Antlr.Runtime.Tree;
using System.IO;

namespace tinyAsn1
{
    class Program
    {
        static int Main(string[] args)
        {
            if (System.Diagnostics.Debugger.IsAttached)
                return Main2(args);
            try
            {
                return Main2(args);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Unkown exception ...");
                Console.Error.WriteLine(ex.Message);
                Console.Error.WriteLine(ex.StackTrace);
                return 3;
            }
        }
        
        static int Main2(string[] args)
        {
            List<string> inputFiles = new List<string>();
//            List<Asn1File> ASTs = new List<Asn1File>();
            Asn1CompilerInvokation compInv = Asn1CompilerInvokation.Instance;

            bool debug=false;
            bool genOutput = false;

            for (int i=0;i<args.Length;i++)
            {
                if (args[i].StartsWith("-"))
                {
                    if (args[i] == "-debug")
                        debug = true;
                    else if (args[i] == "-icd")
                        genOutput = true;
                    else
                    {
                        Console.Error.WriteLine("Unrecognized option: " + args[i]);
                        return Usage();
                    }
                }
                else
                {
                    inputFiles.Add(args[i]);
                }
            }

            if (inputFiles.Count == 0)
            {
                Console.Error.WriteLine("No input files");
                return Usage();
            }

            foreach (string inFileName in inputFiles)
            {
                if (!System.IO.File.Exists(inFileName))
                {
                    Console.Error.WriteLine("File: " + inFileName + " doesn't exist");
                    return Usage();
                }
            }

//Create Syntax Tree
            try
            {
                compInv.CreateASTs(inputFiles);
            }
            catch (RecognitionException)
            {
                return 1;
            }
            catch (SemanticErrorException ex)
            {
                Console.Error.WriteLine(ex.Message);
                return 2;
            }

// Modify Syntax Tree and make Semantic checks

            try
            {
                compInv.SemanticParse();
            }
            catch (SemanticErrorException ex)
            {
                Console.Error.WriteLine(ex.Message);
                return 2;
            }
            

            if (debug)
            {
                compInv.debug();
            }

            if (genOutput)
            {
                for (int i = 0; i < inputFiles.Count; i++)
                {

                        System.IO.StreamWriter wr = new System.IO.StreamWriter(inputFiles[i] + ".html");
//                        ASTs[i].GenerateICD(wr);
                        wr.Flush();
                        wr.Close();
                }
            }
            return 0;            
        }

        static int Usage()
        {
            Console.Error.WriteLine("tinyAsn1 -debug -icd file1, file2, ..., fileN ");
            Console.Error.WriteLine("\t -debug \t\tcreates an XML with AST representation");
            Console.Error.WriteLine("\t -icd \t\tGenerate ICD Documents");
            return 4;
        }
    }
}
