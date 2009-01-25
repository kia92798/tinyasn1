using System;
using System.Collections.Generic;
using System.Text;
using CSharpAsn1CRT;
using semantix.util;
using TAP3Common;


namespace CSharpAsn1Test
{
    class Program
    {


        static void usage()
        {
            Console.WriteLine("TAP3.11 decoder");
            Console.WriteLine("\tusage:");

            string appShortName = System.IO.Path.GetFileName(Environment.GetCommandLineArgs()[0]);
            
            Console.WriteLine("{0} -i tap311file -o outFile -f BER|xml|enc", appShortName);

            Environment.Exit(1);
        }


        static void ProcessArgs(string[] args, out string inFileName, out string outFileName,
            out bool dumpBER, out bool convertToXml, out bool encode)
        {
            inFileName = string.Empty;
            outFileName = string.Empty;
            dumpBER = false;
            convertToXml = false;
            encode = false;

            for (int i = 0; i < args.Length; i++)
            {
                if (args[i].StartsWith("-"))
                {
                    if (args[i] == "-i")
                    {
                        i++;
                        inFileName = args[i];
                    }
                    else if (args[i] == "-o")
                    {
                        i++;
                        outFileName = args[i];
                    }
                    else if (args[i] == "-f")
                    {
                        i++;
                        if (args[i] == "BER")
                            dumpBER = true;
                        else if (args[i] == "xml")
                            convertToXml = true;
                        else if (args[i] == "xml")
                            encode = true;
                        else
                            usage();
                    }
                    else
                        usage();
                }
                else
                    usage();
            }

            if (inFileName == string.Empty || outFileName == string.Empty || 
                (convertToXml == false && dumpBER == false && encode==false))
                usage();
        }

        static int Main2(string[] args)
        {
            string inFileName;
            string outFileName;
            bool dumpBER;
            bool convertToXml;
            bool encode;




            ProcessArgs(args, out inFileName, out outFileName, out dumpBER, out convertToXml, out encode);
            if (dumpBER)
            {
                BERDump.dump(inFileName, outFileName, true, false);
            }
            else if (convertToXml || encode)
            {

//                FileVersion fv = FileVersion.Detect(inFileName);
                FileVersion fv = new FileVersion(FileVersion.ProtocolClass.TAP, 3, 11);

                using (System.IO.MemoryStream f = new System.IO.MemoryStream(System.IO.File.ReadAllBytes(inFileName), false))
                {
                    int i = 0;
                    while (f.Position < f.Length)
                    {
                        i++;
                        Asn1Object root = fv.CreateRootNode();
                        root.Decode(f, CSharpAsn1CRT.EncodingRules.CER);

                        if (convertToXml)
                        {
                            using (StreamWriterLevel oo = new StreamWriterLevel(outFileName.Replace(".dat",i.ToString())))
                            {
                               // root.ToXml(oo, "Call", 0,"");
                            }
                        }
                        else
                        {
                            using (System.IO.FileStream w = new System.IO.FileStream(outFileName, System.IO.FileMode.Create))
                            {
                                root.Encode(w, CSharpAsn1CRT.EncodingRules.CER);
                            }
                        }
                    }
                }

            }
            return 0;

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
                return 3;
            }
        }
    
    
    }




/*
    public class Parents : Stack<Asn1Object>
    {

        public TRes GetParentOfType<TRes>() where TRes : Asn1Object
        {


            foreach (Asn1Object obj in this) 
                if (obj is TRes)
                    return obj as TRes;
            return null;
        }
    }
*/

}
