using System;
using System.Collections.Generic;
using System.Text;
using CSharpAsn1CRT;
using semantix.util;
using System.Reflection;
using TAP3Common;
using System.Xml;

namespace Tap2Xml_DNA
{
    class Program
    {

        static void usage(string errMessage)
        {
            Console.WriteLine("Tap2Xml.net [version 1.0]");
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

            Console.WriteLine("{0} [-toXml|-toBer] -i inputFile -o OutputFile", appShortName);
            Console.WriteLine("\t-toXml converts the input file (which must be a TAP3 file) into Xml");
            Console.WriteLine("\t-toBer converts the input file (which must be an XML file) into TAP3");

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
            if (!CmdLineArgs.HasArg(args, "-toBer") && !CmdLineArgs.HasArg(args, "-toXml"))
            {
                usage("You must specify one of -toBer or -toXml");
            }

            bool toBer = CmdLineArgs.HasArg(args, "-toBer");


            string inputFile = string.Empty;
            string outFile = string.Empty;
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
            if (toBer)
                ToBer(inputFile, outFile);
            else
                ToXml(inputFile, outFile);
            return 0;
        }

        static void ToXml(string inputFile, string outFile)
        {
            using (System.IO.MemoryStream f = new System.IO.MemoryStream(System.IO.File.ReadAllBytes(inputFile), false))
            {
                Asn1Object root = new TAP_0311_DNA.RootNode();
                root.Decode(f, CSharpAsn1CRT.EncodingRules.CER);

                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.OmitXmlDeclaration = true;
                settings.CheckCharacters = false;

//                using (StreamWriterLevel of = new StreamWriterLevel(outFile))
                using (XmlWriter xw = XmlTextWriter.Create(outFile, settings))
                {
                    string attrs = string.Format("Version=\"{0}\" Release=\"{1}\"", 3, 11);
                    root.ToXml(xw, "TAP3-DNA", new KeyValuePair<string, string>("Version", "3"), new KeyValuePair<string, string>("Release", "11"));
                }
            }

        }

        static void ToBer(string inputFile, string outFile)
        {

            Asn1Object root = new TAP_0311_DNA.RootNode();

            using (System.IO.MemoryStream f = new System.IO.MemoryStream(System.IO.File.ReadAllBytes(inputFile), false))
            {
                root.FromXml(f, "TAP3-DNA", null);
            }

            using (System.IO.FileStream w = new System.IO.FileStream(outFile, System.IO.FileMode.Create))
            {
                root.Encode(w, CSharpAsn1CRT.EncodingRules.CER);
            }


        }
    }
}

