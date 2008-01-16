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
            Asn1CompilerInvokation compInv = Asn1CompilerInvokation.Instance;

            bool debug=false;
            bool encodeVars = false;
            bool genOutput = false;

            for (int i=0;i<args.Length;i++)
            {
                if (args[i].StartsWith("-"))
                {
                    if (args[i] == "-debug")
                        debug = true;
                    else if (args[i] == "-enc")
                        encodeVars = true;
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

            if (encodeVars)
            {
                compInv.EncodeVars();
            }

            if (genOutput)
            {
                compInv.PrintHtml();
            }
            return 0;            
        }

        static int Usage()
        {
            Console.Error.WriteLine("Automatic ICD Generator");
            Console.Error.WriteLine("Current Version is: 0.90");
            Console.Error.WriteLine("Usage:");
            Console.Error.WriteLine("autoICD -debug -encodeVariables -icd file1, file2, ..., fileN ");
            Console.Error.WriteLine("\t -debug\tre-prints the AST using ASN.1. Usefull only for debug purposes.");
            Console.Error.WriteLine("\t -enc\tcreates one .dat file with PER encoding for each variable");
            Console.Error.WriteLine("\t -icd\tgenerates ICD Documents");
            Console.Error.WriteLine("Example:");
            Console.Error.WriteLine("\tautoICD -icd MyFile.asn1");
            return 4;
        }
    }
}
