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
            string inputFileName = args[0];
            ICharStream input = new ANTLRFileStream(inputFileName);
            asn1Lexer lexer = new asn1Lexer(input);
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            asn1Parser parser = new asn1Parser(tokens);
             
            try
            {
                asn1Parser.moduleDefinitions_return result = parser.moduleDefinitions();

                CommonTree tree = (CommonTree)result.Tree;
                CommonTreeNodeStream nodes = new CommonTreeNodeStream(tree);
                nodes.TokenStream = tokens;

                int debug = 0;
                if (debug == 1)
                {
                    DOTTreeGenerator gen = new DOTTreeGenerator();
                    StringTemplate st = gen.ToDOT(tree);
                    Console.WriteLine(st);
                } else if (debug==2)
                    Console.Write(tree.ToStringTree());


                asn1Tree ast = new asn1Tree(nodes);

                ast.moduleDefinitions();

                return 0;
            } catch(RecognitionException ) {

                return 1;
            }

            
            //parser.element();
            
            
        }
    }
}
