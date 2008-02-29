using System;
using System.Collections.Generic;
using System.Text;


using Antlr.Runtime;
using Antlr.StringTemplate;
using Antlr.StringTemplate.Language;
using Antlr.Utility.Tree;
using Antlr.Runtime.Tree;
using System.IO;
using tinyAsn1;

namespace asn1cc
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
            Asn1CompilerInvokation compInv = Asn1CompilerInvokation.Instance;

            bool debug = false;

            for (int i = 0; i < args.Length; i++)
            {
                if (args[i].StartsWith("-"))
                {
                    if (args[i] == "-debug")
                        debug = true;
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
            try
            {
                compInv.printC();
            }
            catch (SemanticErrorException ex)
            {
                Console.Error.WriteLine(ex.Message);
                return 2;
            }

            return 0;
        }

        static int Usage()
        {
            Console.Error.WriteLine("ASN.1 Certified compiler");
            Console.Error.WriteLine("Current Version is: 0.92");
            Console.Error.WriteLine("Usage:");
            Console.Error.WriteLine("asn1cc -debug file1, file2, ..., fileN ");
            Console.Error.WriteLine("\t -debug\tre-prints the AST using ASN.1. Usefull only for debug purposes.");
            Console.Error.WriteLine("Example:");
            Console.Error.WriteLine("\tasn1cc MyFile.asn1");
            return 4;
        }
    }
}
