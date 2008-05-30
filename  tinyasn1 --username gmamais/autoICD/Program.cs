/**=============================================================================
Definition of class Program, entry point of autoICD application
================================================================================
Copyright(c) Semantix Information Technologies S.A www.semantix.gr
All rights reserved.

This source code is only intended as a supplement to the
Semantix Technical Reference and related electronic documentation 
provided with the autoICD application.
See these sources for detailed information regarding the
autoICD application.
==============================================================================*/

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
            //if running under debugger, do not catch unhandled exceptions
            //so that Visual Studio IDE can locate the point where the exception
            //was thrown
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
            bool debug = false;
            bool encodeVars = false;
            bool genOutput = false;
            string outFileName = null;
            List<string> inputFiles = new List<string>();

            //construct the backend
            ICDBackend compInv = new ICDBackend();


            for (int i = 0; i < args.Length; i++)
            {
                if (args[i].StartsWith("-"))
                {
                    if (args[i] == "-debug")
                        debug = true;
                    else if (args[i] == "-encodeVariables")
                        encodeVars = true;
                    else if (args[i] == "-icd")
                        genOutput = true;
                    else if (args[i] == "-useSpecialComments")
                        DefaultBackend.UseSpecialComments = true;
                    else if (args[i] == "-displayTypesAsAppearInAsn1Grammar")
                        DefaultBackend.displayTypesAsAppearInAsn1Grammar = true;
                    else if (args[i] == "-wordSize")
                    {
                        try
                        {
                            i++;
                            Config.IntegerSize = int.Parse(args[i]);
                        }
                        catch (FormatException)
                        {
                            Console.Error.WriteLine("Error in argument -wordSize: {0} is not a number", args[i]);
                            return Usage();
                        }
                        catch (Exception )
                        {
                            Console.Error.WriteLine("Error in argument -wordSize: No value specified");
                            return Usage();
                        }
                        
                    }
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

            DefaultBackend.CheckRecursiveFuncSetIsEmpty();
            return 0;
        }

        static int Usage()
        {
            Console.Error.WriteLine();
            Console.Error.WriteLine("Automatic ICD Generator");
            Console.Error.WriteLine("Current Version is: 1.00");
            Console.Error.WriteLine("Usage:");
            Console.Error.WriteLine();
            Console.Error.WriteLine("autoICD [-o fileName.html] [-wordSize N] [-debug] [-encodeVariables] [-icd] [-useSpecialComments] file1.asn1, file2.asn1, ..., fileN.asn1 ");
            Console.Error.WriteLine();
            Console.Error.WriteLine("\t -o fileName.html\tthe generated ICD file name.");
            Console.Error.WriteLine("\t\t\t\tIf omitted, the name of the generated ICD will");
            Console.Error.WriteLine("\t\t\t\tbe file1.html.");
            Console.Error.WriteLine();
            Console.Error.WriteLine("\t -wordSize N\t\tthe word size of the target machine in bytes.");
            Console.Error.WriteLine("\t\t\t\tPossible values are 2,4 and 8");
            Console.Error.WriteLine("\t\t\t\tIf omitted, N is equal to 8");
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
            Console.Error.WriteLine("\t -displayTypesAsAppearInAsn1Grammar");
            Console.Error.WriteLine("\t\t\t\tDisplay types with the order that appear in the");
            Console.Error.WriteLine("\t\t\t\tASN.1 grammar. If not set (default), top level");
            Console.Error.WriteLine("\t\t\t\ttypes (i.e. PDUs) appear first");
            Console.Error.WriteLine("Example:");
            Console.Error.WriteLine("\tautoICD -icd MyFile.asn1");
            return 4;
        }
    }
}
