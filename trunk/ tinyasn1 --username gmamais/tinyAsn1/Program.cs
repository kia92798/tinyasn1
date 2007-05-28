using System;
using System.Collections.Generic;
using System.Text;


using Antlr.Runtime;
using Antlr.StringTemplate;
using Antlr.StringTemplate.Language;

namespace tinyAsn1
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFileName = args[0];
            ICharStream input = new ANTLRFileStream(inputFileName);
            asn1Lexer lexer = new asn1Lexer(input);
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            asn1Parser parser = new asn1Parser(tokens);
            
            parser.moduleDefinitions();
            //parser.element();
            
            
        }
    }
}
