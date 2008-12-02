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
using semantix.util;

namespace asn1csharp
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
            CSharpBackend compInv = new CSharpBackend();

            bool debug = false;
            string astXml = string.Empty;

            for (int i = 0; i < args.Length; i++)
            {
                if (args[i].StartsWith("-"))
                {
                    if (args[i] == "-debug")
                        debug = true;
                    else if (args[i] == "-typePrefix")
                    {
                        try
                        {
                            i++;
                            compInv.TypePrefix = args[i];
                        }
                        catch (Exception ex)
                        {
                            Console.Error.WriteLine("-typePrefix argument specified, but not prefix was given.");
                            Console.Error.WriteLine(ex.Message);
                            return Usage();
                        }

                    }
                    else if (args[i] == "-useSpecialComments")
                        DefaultBackend.UseSpecialComments = true;
                    else if (args[i] == "-o")
                    {
                        try
                        {
                            i++;
                            string outFileDir = args[i];
                            if (!System.IO.Directory.Exists(outFileDir))
                            {
                                Console.Error.WriteLine("{0} is not a valid directory.", outFileDir);
                                return Usage();
                            }
                            DefaultBackend.m_outDirectory = outFileDir;
                        }
                        catch (Exception)
                        {
                            Console.Error.WriteLine("-o argument specified, but no directory was given.");
                            return Usage();
                        }
                    }
                    else if (args[i] == "-ast")
                    {
                        try
                        {
                            i++;
                            astXml = args[i];
                            FileStream dummy = System.IO.File.Create(astXml);
                            dummy.Close();
                            System.IO.File.Delete(astXml);
                        }
                        catch (Exception)
                        {
                            Console.Error.WriteLine("Can not create file {0}",astXml);
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
                Console.Error.WriteLine("No input files.");
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

            if (astXml != string.Empty)
            {
                using (StreamWriterLevel xmlstream = new StreamWriterLevel(astXml))
                {
                    compInv.ToXml(xmlstream, 0);
                }

                return 0;
                
            }

            if (debug)
            {
                compInv.debug();
            }
            try
            {
                compInv.printCode();
            }
            catch (SemanticErrorException ex)
            {
                Console.Error.WriteLine(ex.Message);
                return 2;
            }

            DefaultBackend.CheckRecursiveFuncSetIsEmpty();
            return 0;
        }

        static int Usage()
        {
            Console.Error.WriteLine();
            Console.Error.WriteLine("ASN.1 CSharp Compiler");
            Console.Error.WriteLine("Current Version is: 0.93");
            Console.Error.WriteLine("Usage:");
            Console.Error.WriteLine();
            Console.Error.WriteLine("asn1csharp [-debug] [-ast ast.xml] [-typePrefix prefix] [-useSpecialComments] [-o outdir] file1, file2, ..., fileN ");
            Console.Error.WriteLine();
            Console.Error.WriteLine("\t -debug\t\t\tre-prints the AST using ASN.1.");
            Console.Error.WriteLine("\t\t\t\tUseful only for debug purposes.");
            Console.Error.WriteLine();
            Console.Error.WriteLine("\t -ast\t\tProduces an XML file of the parsed input ASN.1 grammar.");
            Console.Error.WriteLine();
            Console.Error.WriteLine("\t -typePrefix\t\tadds 'prefix' to all generated C data types.");
            Console.Error.WriteLine();
            Console.Error.WriteLine("\t -useSpecialComments\tOnly comments starting with --@ will be copied");
            Console.Error.WriteLine("\t\t\t\tto the generated files");
            Console.Error.WriteLine();
            Console.Error.WriteLine("\t -o outdir\t\tdirectory where all files are produced.");
            Console.Error.WriteLine("\t\t\t\tDefault is current directory");
            Console.Error.WriteLine();
            Console.Error.WriteLine("Example:");
            Console.Error.WriteLine();
            Console.Error.WriteLine("\tasn1csharp MyFile.asn1");
            return 4;
        }
    }
}
