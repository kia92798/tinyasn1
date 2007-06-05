using System;
using System.Collections.Generic;
using System.Text;


using Antlr.Runtime;
using Antlr.StringTemplate;
using Antlr.StringTemplate.Language;
using Antlr.Utility.Tree;
using Antlr.Runtime.Tree;

namespace tinyAsn1
{
    class Program
    {
        static int Main(string[] args)
        {
            List<string> inputFiles = new List<string>();
            List<Asn1File> ASTs = new List<Asn1File>();

            bool debug=false;

            for (int i=0;i<args.Length;i++)
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

                try
                {
                    ICharStream input = new ANTLRFileStream(inFileName);
                    asn1Lexer lexer = new asn1Lexer(input);
                    CommonTokenStream tokens = new CommonTokenStream(lexer);
                    asn1Parser parser = new asn1Parser(tokens);

                    asn1Parser.moduleDefinitions_return result = parser.moduleDefinitions();

                    CommonTree tree = (CommonTree)result.Tree;
                    CommonTreeNodeStream nodes = new CommonTreeNodeStream(tree);
                    nodes.TokenStream = tokens;

                    Asn1File asnFile = Asn1File.CreateFromAntlrAst(tree);
                    ASTs.Add(asnFile);
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
                catch (Exception ex)
                {
                    Console.Error.WriteLine("Unkown exception ...");
                    Console.Error.WriteLine(ex.Message);
                    Console.Error.WriteLine(ex.StackTrace);
                    return 3;
                }
            }


            if (debug)
            {
                Console.WriteLine("Debugging ...");
                for (int i = 0; i < inputFiles.Count; i++)
                {
                    try
                    {
                        System.IO.StreamWriter wr = new System.IO.StreamWriter(inputFiles[i] + ".xml");
                        ASTs[i].printAstAsXml(wr);
                        wr.Flush();
                        wr.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.Error.WriteLine("Unkown exception ...");
                        Console.Error.WriteLine(ex.Message);
                        Console.Error.WriteLine(ex.StackTrace);
                        return 3;
                    }
                }
            }
            
            return 0;            
        }

        static int Usage()
        {
            Console.Error.WriteLine("tinyAsn1 -debug file1, file2, ..., fileN ");
            Console.Error.WriteLine("\t -debug \t\tcreates an XML with AST representation");
            return 4;
        }
    }
}
