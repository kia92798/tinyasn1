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

namespace autoICD
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
            bool encodeVars = false;
            bool genOutput = false;
            string outFileName = null;

            for (int i = 0; i < args.Length; i++)
            {
                if (args[i].StartsWith("-"))
                {
                    if (args[i] == "-debug")
                        debug = true;
                    else if (args[i] == "-enc")
                        encodeVars = true;
                    else if (args[i] == "-icd")
                        genOutput = true;
                    else if (args[i] == "-useSpecialComments")
                        Asn1CompilerInvokation.UseSpecialComments = true;
                    else if (args[i] == "-o")
                    {
                        try
                        {
                            i++;
                            outFileName = args[i];
                            System.IO.StreamWriter d = System.IO.File.CreateText(outFileName);
                            d.Close();
                            System.IO.File.Delete(outFileName);
                        }
                        catch (Exception ex)
                        {
                            Console.Error.WriteLine("-o argument specified, but filename specified is not valid. Error is");
                            Console.Error.WriteLine(ex.Message);
                            return Usage();
                        }
                    }
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
                compInv.PrintHtml(outFileName);
            }

            Asn1CompilerInvokation.CheckRecursiveFuncSetIsEmpty();
            return 0;
        }

        static int Usage()
        {
            Console.Error.WriteLine();
            Console.Error.WriteLine("Automatic ICD Generator");
            Console.Error.WriteLine("Current Version is: 0.94");
            Console.Error.WriteLine("Usage:");
            Console.Error.WriteLine();
            Console.Error.WriteLine("autoICD [-o fileName.html] [-debug] [-encodeVariables] [-icd] [-useSpecialComments] file1.asn1, file2.asn1, ..., fileN.asn1 ");
            Console.Error.WriteLine();
            Console.Error.WriteLine("\t -o fileName.html\tthe generated ICD file name.");
            Console.Error.WriteLine("\t\t\t\tIf omitted, the name of the generated ICD will");
            Console.Error.WriteLine("\t\t\t\tbe file1.html.");
            Console.Error.WriteLine();
            Console.Error.WriteLine("\t -debug\t\t\tre-prints the AST using ASN.1.");
            Console.Error.WriteLine("\t\t\t\tUseful only for debug purposes.");
            Console.Error.WriteLine();
            Console.Error.WriteLine("\t -encodeVariables\tcreates one .dat file with uPER encoding");
            Console.Error.WriteLine("\t\t\t\tfor each variable that exists in the asn1 input");
            Console.Error.WriteLine("\t\t\t\tfiles.");
            Console.Error.WriteLine();
            Console.Error.WriteLine("\t -icd\t\t\tgenerates ICD Documents");
            Console.Error.WriteLine();
            Console.Error.WriteLine("\t -useSpecialComments\tOnly comments starting with --@ will be");
            Console.Error.WriteLine("\t\t\t\tcopied to the ICD tables.");
            Console.Error.WriteLine();
            Console.Error.WriteLine("Example:");
            Console.Error.WriteLine("\tautoICD -icd MyFile.asn1");
            return 4;
        }
    }
}