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
            List<string> inputFiles = new List<string>();
            List<Asn1File> ASTs = new List<Asn1File>();

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

//Create Syntax Tree
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

//                    Console.WriteLine(tree.ToStringTree());


                    Asn1File asnFile = Asn1File.CreateFromAntlrAst(tree);
                    asnFile.m_fileName = inFileName;
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
// Modify Syntax Tree and make Semantic checks

            try
            {

                SemanticParser sp = new SemanticParser();

                do
                {
                    for (int i = 0; i < inputFiles.Count; i++)
                        ASTs[i].Visit(sp);
                } while (!sp.Finished() && sp.PassNo<50);
                Console.Error.WriteLine("Semantic parsing passes : " + sp.PassNo.ToString());
            }
            catch (SemanticErrorException ex)
            {
                Console.Error.WriteLine(ex.Message);
                return 2;
            }




            if (debug)
            {
                Console.WriteLine("Debugging ...");
                for (int i = 0; i < inputFiles.Count; i++)
                {
                    StreamWriterLevel wr = new StreamWriterLevel(inputFiles[i] + ".txt");
                    try
                    {
                        PrintASN1 pr = new PrintASN1(wr);
                        ASTs[i].Visit(pr);
                        //                        ASTs[i].printAstAsXml(wr);
                    }
                    finally
                    {
                        wr.Flush();
                        wr.Close();
                    }
                    //catch (Exception ex)
                    //{
                    //    Console.Error.WriteLine("Unkown exception ...");
                    //    Console.Error.WriteLine(ex.Message);
                    //    Console.Error.WriteLine(ex.StackTrace);
                    //    return 3;
                    //}
                }
            }

            if (genOutput)
            {
                for (int i = 0; i < inputFiles.Count; i++)
                {
                    try
                    {
                        System.IO.StreamWriter wr = new System.IO.StreamWriter(inputFiles[i] + ".html");
//                        ASTs[i].GenerateICD(wr);
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
            Console.Error.WriteLine("tinyAsn1 -debug -icd file1, file2, ..., fileN ");
            Console.Error.WriteLine("\t -debug \t\tcreates an XML with AST representation");
            Console.Error.WriteLine("\t -icd \t\tGenerate ICD Documents");
            return 4;
        }
    }
}
