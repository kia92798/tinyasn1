using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using CSharpAsn1CRT;
using semantix.util;
using System.Xml;
using Tap3Utils;

namespace TAP3Common
{
    public class FileVersion
    {
        public enum ProtocolClass
        {
            TAP,
            RAP,
            NRTRDE
        };

        public static ProtocolClass string2ProtocolClass(string s)
        {
            if (s == "TAP")
                return ProtocolClass.TAP;
            if (s == "RAP")
                return ProtocolClass.RAP;
            if (s == "NRTRDE")
                return ProtocolClass.NRTRDE;
            throw new Exception("Unsupported protocol class (" + s + ")");
        }

        public ProtocolClass m_protocolClass = ProtocolClass.TAP;

        public int majorVersion = 0;
        public int minorVersion = 0;
        public int secMajorVersion = 0;
        public int secMinorVersion = 0;



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
            else if (m_protocolClass == ProtocolClass.NRTRDE)
            {
                if (majorVersion == 2 && minorVersion == 1)
                    return new NRTRDE_0201.Nrtrde();
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
                int mn = ((BERNodePrimitive)(lst[2])).m_data[0];
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

            throw new Exception("Unknown TAP3 Version ...");

        }



        public static FileVersion DetectFromXml(string inputFile)
        {
            using (StreamReader txt = new StreamReader(inputFile))
            using (XmlTextReader xml = new XmlTextReader(txt))
            {


                while (xml.Read())
                {
                    if (xml.NodeType == XmlNodeType.Element)
                    {
                        try
                        {

                            ProtocolClass cls = string2ProtocolClass(xml.Name);
                            int ver = int.Parse(xml.GetAttribute("Version"));
                            int rel = int.Parse(xml.GetAttribute("Release"));
                            if (cls == ProtocolClass.RAP)
                            {
                                int scver = int.Parse(xml.GetAttribute("SecVersion"));
                                int screl = int.Parse(xml.GetAttribute("SecRelease"));
                                return new FileVersion(cls, ver, rel, scver, screl);
                            }
                            else
                            {
                                return new FileVersion(cls, ver, rel);
                            }

                        }
                        catch (Exception)
                        {
                            throw new Exception("Input file '" + inputFile + "' is not a valid XML file");
                        }

                    }
                }
                throw new Exception("Input file '" + inputFile + "' is not a valid XML file");
            }
        }
    }

}






namespace NRTRDE_0201
{
    public partial class BCDString
    {
        public override string ValueAsString
        {
            get { return BCDUtils.BCDToString(Value); }
            set { Value = BCDUtils.StringToBCD(value); }
        }
    }




}


namespace TAP_0301
{
    public partial class BCDString
    {
        public override string ValueAsString
        {
            get { return BCDUtils.BCDToString(Value);  }
            set { Value = BCDUtils.StringToBCD(value); }
        }
    }

    public partial class MyVisibleString
    {
        public override string ValueAsString
        {
            get { return Encoding.GetEncoding(0).GetString(Value.ToArray()); }
            set { Value = new List<byte>(Encoding.GetEncoding(0).GetBytes(value)); }
        }
    }

}


namespace TAP_0302
{
    public partial class BCDString
    {
        public override string ValueAsString
        {
            get { return BCDUtils.BCDToString(Value); }
            set { Value = BCDUtils.StringToBCD(value); }
        }
    }
    public partial class MyVisibleString
    {
        public override string ValueAsString
        {
            get { return Encoding.GetEncoding(0).GetString(Value.ToArray()); }
            set { Value = new List<byte>(Encoding.GetEncoding(0).GetBytes(value)); }
        }
    }
}

namespace TAP_0303
{
    public partial class BCDString
    {
        public override string ValueAsString
        {
            get { return BCDUtils.BCDToString(Value); }
            set { Value = BCDUtils.StringToBCD(value); }
        }
    }
    public partial class MyVisibleString
    {
        public override string ValueAsString
        {
            get { return Encoding.GetEncoding(0).GetString(Value.ToArray()); }
            set { Value = new List<byte>(Encoding.GetEncoding(0).GetBytes(value)); }
        }
    }
}


namespace TAP_0304
{
    public partial class BCDString
    {
        public override string ValueAsString
        {
            get { return BCDUtils.BCDToString(Value); }
            set { Value = BCDUtils.StringToBCD(value); }
        }
    }
    public partial class MyVisibleString
    {
        public override string ValueAsString
        {
            get { return Encoding.GetEncoding(0).GetString(Value.ToArray()); }
            set { Value = new List<byte>(Encoding.GetEncoding(0).GetBytes(value)); }
        }
    }
}

namespace TAP_0309
{
    public partial class BCDString
    {
        public override string ValueAsString
        {
            get { return BCDUtils.BCDToString(Value); }
            set { Value = BCDUtils.StringToBCD(value); }
        }
    }
    public partial class MyVisibleString
    {
        public override string ValueAsString
        {
            get { return Encoding.GetEncoding(0).GetString(Value.ToArray()); }
            set { Value = new List<byte>(Encoding.GetEncoding(0).GetBytes(value)); }
        }
    }
}



namespace TAP_0310
{
    public partial class BCDString
    {
        public override string ValueAsString
        {
            get { return BCDUtils.BCDToString(Value); }
            set { Value = BCDUtils.StringToBCD(value); }
        }
    }
    public partial class MyVisibleString
    {
        public override string ValueAsString
        {
            get { return Encoding.GetEncoding(0).GetString(Value.ToArray()); }
            set { Value = new List<byte>(Encoding.GetEncoding(0).GetBytes(value)); }
        }
    }
}


namespace TAP_0311
{
    public partial class BCDString
    {
        public override string ValueAsString
        {
            get { return BCDUtils.BCDToString(Value); }
            set { Value = BCDUtils.StringToBCD(value); }
        }
    }
    public partial class MyVisibleString
    {
        public override string ValueAsString
        {
            get { return Encoding.GetEncoding(0).GetString(Value.ToArray()); }
            set { Value = new List<byte>(Encoding.GetEncoding(0).GetBytes(value)); }
        }
    }
}




