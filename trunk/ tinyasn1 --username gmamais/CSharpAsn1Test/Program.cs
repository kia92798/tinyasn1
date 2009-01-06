using System;
using System.Collections.Generic;
using System.Text;
using CSharpAsn1CRT;
using semantix.util;


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
                BERDump.dump(inFileName, outFileName);
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
                                root.ToXml(oo, "Call", 0);
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



    public class FileVersion
    {
        public enum ProtocolClass
        {
            TAP,
            RAP,
            NRTRDE
        };

        ProtocolClass m_protocolClass = ProtocolClass.TAP;

        int majorVersion = 0;
        int minorVersion = 0;
        int secMajorVersion = 0;
        int secMinorVersion = 0;

        public FileVersion(ProtocolClass protocolClass, int mjVer, int mnVer)
        {
            m_protocolClass = protocolClass;
            majorVersion = mjVer;
            minorVersion = mnVer;

        }

        public FileVersion(ProtocolClass protocolClass, int mjVer, int mnVer, int secMjVer, int secMnVer)
        {
            m_protocolClass = protocolClass;
            majorVersion = mjVer;
            minorVersion = mnVer;
            secMajorVersion = secMjVer;
            secMinorVersion = secMnVer;

        }

        public Asn1Object CreateRootNode()
        {
            if (m_protocolClass == ProtocolClass.TAP)
            {
                if (majorVersion == 3 && minorVersion == 1)
                    return new TAP_0301.DataInterChange();
                if (majorVersion == 3 && minorVersion == 2)
                    return new TAP_0302.DataInterChange();
                if (majorVersion == 3 && minorVersion == 3)
                    return new TAP_0303.DataInterChange();
                if (majorVersion == 3 && minorVersion == 4)
                    return new TAP_0304.DataInterChange();
                if (majorVersion == 3 && minorVersion == 9)
                    return new TAP_0309.DataInterChange();
                if (majorVersion == 3 && minorVersion == 10)
                    return new TAP_0310.DataInterChange();
                if (majorVersion == 3 && minorVersion == 11)
                    return new TAP_0311.DataInterChange();
            }

            throw new Exception();
        }

        public static FileVersion Detect(string fileName)
        {

            List<BERNode> lst = new List<BERNode>();
            using (System.IO.MemoryStream ffff = new System.IO.MemoryStream(System.IO.File.ReadAllBytes(fileName), false))
            {

                foreach (BERNode n in BERNode.GetNodes(ffff))
                {
                    lst.Add(n);
                    if (lst.Count > 50)
                        break;
                }
            }



            if (lst.Count >= 3 && lst[0].m_tag.m_tagNo == 1 && lst[1].m_tag.m_tagNo == 41 && lst[2].m_tag.m_tagNo == 37)
            {
                int mj = ((BERNodePrimitive)(lst[1])).m_data[0];
                int mn = ((BERNodePrimitive)(lst[1])).m_data[1];
                return new FileVersion(ProtocolClass.NRTRDE, mj, mn);
            }

            Func<int, Predicate<BERNode>> cl = delegate(int AppID)
            {
                return delegate(BERNode n)
                {
                    return n.m_tag.m_tagNo == AppID;
                };
            };

            bool TB_exists = lst.Exists(cl(1));
            bool NF = lst.Exists(cl(2));
            bool BC = lst.Exists(cl(4));
            bool SV = lst.Exists(cl(201));
            bool RV = lst.Exists(cl(189));
            bool RapRB = lst.Exists(cl(534));
            bool RapBC = lst.Exists(cl(537));
            bool RapSV = lst.Exists(cl(544));
            bool RapRV = lst.Exists(cl(543));
            bool RapAck = lst.Exists(cl(535));

            if (RapAck)
            {
                return new FileVersion(ProtocolClass.RAP, 1, 4, 3, 11);
            }
            if (RapRB && RapBC && RapSV && RapRV && SV && RV)
            {
                BERNodePrimitive rsv = lst.Find(cl(544)) as BERNodePrimitive;
                BERNodePrimitive rrv = lst.Find(cl(543)) as BERNodePrimitive;

                BERNodePrimitive tsv = lst.Find(cl(201)) as BERNodePrimitive;
                BERNodePrimitive trv = lst.Find(cl(189)) as BERNodePrimitive;


                return new FileVersion(ProtocolClass.RAP, rsv.m_data[0], rrv.m_data[0],
                    tsv.m_data[0], trv.m_data[0]);
            }

            if ((BC || NF) && SV && RV)
            {
                BERNodePrimitive tsv = lst.Find(cl(201)) as BERNodePrimitive;
                BERNodePrimitive trv = lst.Find(cl(189)) as BERNodePrimitive;

                return new FileVersion(ProtocolClass.TAP, tsv.m_data[0], trv.m_data[0]);
            }

            throw new Exception("Unknown Version");

       }


    }

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


}
