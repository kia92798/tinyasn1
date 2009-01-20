using System;
using System.Collections.Generic;
using System.Text;
using semantix.util;

namespace BERDump
{
    class Program
    {
        static void usage(string errMessage)
        {
            Console.WriteLine("BERDump [version 1.0]");
            Console.WriteLine("(C) Copyright Semantix Information Technologies");
            Console.WriteLine();
            Console.WriteLine();
            if (errMessage != null && errMessage.Length > 0)
            {
                Console.WriteLine(errMessage);
                Console.WriteLine();
                Console.WriteLine();
            }
            Console.WriteLine("Usage:");

            string appShortName = System.IO.Path.GetFileName(Environment.GetCommandLineArgs()[0]);

            Console.WriteLine("{0} [-ign|-DNA] -i inputFile -o OutputFile", appShortName);
            Console.WriteLine("\t-ign ignores extra bytes that may appear at the end of the file");
            Console.WriteLine("\t-DNA handle extra bytes as DNA");

            Environment.Exit(1);
        }

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
                return 2;
            }
        }


        static int Main2(string[] args)
        {
            string inputFile = string.Empty;
            string outFile = string.Empty;

            bool ignoreExtraBytes = CmdLineArgs.HasArg(args, "-ign");
            bool handleExtraBytesAsDNA = CmdLineArgs.HasArg(args, "-DNA");

            try
            {
                inputFile = CmdLineArgs.GetArgValue(args, "-i", "Input File not specified. Use argument -i to specify it.");
                outFile = CmdLineArgs.GetArgValue(args, "-o", "Output File not specified. Use argument -o to specify it.");
            }
            catch (CmdLineArgs.ArgException ex)
            {
                usage(string.Format("Error: {0}", ex.Message));
            }
            if (!System.IO.File.Exists(inputFile))
            {
                usage(string.Format("Input file {0} does not exist", inputFile));
            }


            CSharpAsn1CRT.BERDump.dump(inputFile, outFile, ignoreExtraBytes, handleExtraBytesAsDNA);

            return 0;
        }
    }
}
