using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using CSharpAsn1CRT;
using semantix.util;
using System.Xml;


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
            throw new Exception("Unsupported protocol class ("+s+")");
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
            using(StreamReader txt = new StreamReader(inputFile))
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


    public static class BCDUtils
    {

        public static void Test()
        {
           
        }

        public static string BCDToString(List<byte> data)
        {

            Func<byte, byte> fix = delegate(byte orig) 
            {
                if (orig < 10)
                    return (byte)('0' + orig);
                else
                    return (byte)('A' + orig - 10);
            };

            string ret = string.Empty;
            byte[] w = new byte[2];
            foreach (byte b in data)
            {
                w[0] = fix((byte)(b >> 4));
                w[1] = fix((byte)(b & (byte)0x0F));

                ret += ASCIIEncoding.ASCII.GetString(w);
            }

            return ret;
        }

        public static List<byte> StringToBCD(string data)
        {
            List<byte> ret = new List<byte>();
            bool firstNibble = true;
            byte currentByte = 0;
            foreach (char ch in data)
            {
                byte curNibble=0;
                if (ch >= '0' && ch <= '9')
                    curNibble = (byte)(ch - '0');
                else if (ch >= 'A' && ch <= 'F')
                    curNibble = (byte)(ch - 'A' + 10);
                else
                    throw new Exception("Invalid BCD string");
                if (firstNibble)
                    currentByte = (byte)(curNibble << 4);
                else
                {
                    currentByte |= curNibble;
                    ret.Add(currentByte);
                }
                firstNibble = !firstNibble;
            }
            if (!firstNibble)
            {
                currentByte |= 0xF;
                ret.Add(currentByte);
            }

            return ret;
        }

    }
}






namespace NRTRDE_0201
{
    public partial class BCDString
    {
        public override string ValueAsString
        {
            get { return TAP3Common.BCDUtils.BCDToString(Value); }
            set { Value = TAP3Common.BCDUtils.StringToBCD(value); }
        }
        protected override void OnXmlData(string data)
        {
            Value = TAP3Common.BCDUtils.StringToBCD(data);
        }
    }




}


namespace TAP_0301
{
    public partial class BCDString
    {
        public override string ValueAsString
        {
            get { return TAP3Common.BCDUtils.BCDToString(Value);  }
            set { Value = TAP3Common.BCDUtils.StringToBCD(value); }
        }
        protected override void OnXmlData(string data)
        {
            Value = TAP3Common.BCDUtils.StringToBCD(data);
        }
    }
}


namespace TAP_0302
{
    public partial class BCDString
    {
        public override string ValueAsString
        {
            get { return TAP3Common.BCDUtils.BCDToString(Value); }
            set { Value = TAP3Common.BCDUtils.StringToBCD(value); }
        }
        protected override void OnXmlData(string data)
        {
            Value = TAP3Common.BCDUtils.StringToBCD(data);
        }
    }
}

namespace TAP_0303
{
    public partial class BCDString
    {
        public override string ValueAsString
        {
            get { return TAP3Common.BCDUtils.BCDToString(Value); }
            set { Value = TAP3Common.BCDUtils.StringToBCD(value); }
        }
        protected override void OnXmlData(string data)
        {
            Value = TAP3Common.BCDUtils.StringToBCD(data);
        }
    }
}


namespace TAP_0304
{
    public partial class BCDString
    {
        public override string ValueAsString
        {
            get { return TAP3Common.BCDUtils.BCDToString(Value); }
            set { Value = TAP3Common.BCDUtils.StringToBCD(value); }
        }
        protected override void OnXmlData(string data)
        {
            Value = TAP3Common.BCDUtils.StringToBCD(data);
        }
    }
}

namespace TAP_0309
{
    public partial class BCDString
    {
        public override string ValueAsString
        {
            get { return TAP3Common.BCDUtils.BCDToString(Value); }
            set { Value = TAP3Common.BCDUtils.StringToBCD(value); }
        }
        protected override void OnXmlData(string data)
        {
            Value = TAP3Common.BCDUtils.StringToBCD(data);
        }
    }
}



namespace TAP_0310
{
    public partial class BCDString
    {
        public override string ValueAsString
        {
            get { return TAP3Common.BCDUtils.BCDToString(Value); }
            set { Value = TAP3Common.BCDUtils.StringToBCD(value); }
        }
        protected override void OnXmlData(string data)
        {
            Value = TAP3Common.BCDUtils.StringToBCD(data);
        }
    }
}


namespace TAP_0311
{
    public partial class BCDString
    {
        public override string ValueAsString
        {
            get { return TAP3Common.BCDUtils.BCDToString(Value); }
            set { Value = TAP3Common.BCDUtils.StringToBCD(value); }
        }

        protected override void OnXmlData(string data)
        {
            Value = TAP3Common.BCDUtils.StringToBCD(data);
        }
    }

}
namespace TAP_0311_DNA
{

    public partial class BCDString
    {
        public override string ValueAsString
        {
            get { return TAP3Common.BCDUtils.BCDToString(Value); }
            set { Value = TAP3Common.BCDUtils.StringToBCD(value); }
        }
        protected override void OnXmlData(string data)
        {
            Value = TAP3Common.BCDUtils.StringToBCD(data);
        }
    }


    public partial class OperatorSpecInformation
    {

        public override void ToXml(StreamWriterLevel o, string tag, int l, string attrs)
        {
            o.P(l); o.WriteLine("<{0}>", tag);

            string ret = string.Empty;
            OSField[] flds = OSField.GetFieldsByOSSInfo(Value);

            foreach (OSField fld in flds)
            {
                o.P(l+1);
                o.WriteLine("<{0}>{1}</{0}>", fld.m_FieldName, XML.esc(fld.m_Value));
            }


            o.P(l); o.WriteLine("</{0}>", tag);
        }
    }

    public class OSField
    {
        public enum FieldType
        {
            BCD,
            CHAR,
            NUM
        }
        public string m_FieldName = string.Empty;
        public FieldType m_FieldType = FieldType.BCD;
        public int m_sizeInHalfBytes = 0;
        public string m_Value = string.Empty;

        public OSField(string flName, int flSize, FieldType flType, string defValue)
        {
            m_FieldName = flName;
            m_FieldType = flType;
            m_sizeInHalfBytes = flSize;
        }

        public void SetValue(List<byte> osiBytes)
        {
            if (m_FieldType == FieldType.BCD)
                m_Value = TAP3Common.BCDUtils.BCDToString(osiBytes);
            else if (m_FieldType == FieldType.CHAR)
                m_Value = ASCIIEncoding.ASCII.GetString(osiBytes.ToArray());
            else if (m_FieldType == FieldType.NUM)
            {
                ulong v = 0;
                foreach(byte b in osiBytes) 
                {
                    v <<= 8;
                    v |= b;
                }
                m_Value = v.ToString();
            }

        }

        public void SetValue(byte b)
        {
            byte[] w = new byte[1];
            if (b < 10)
                w[0] = (byte)('0' + b);
            else
                w[0] = (byte)('A' + b- 10);

            m_Value = ASCIIEncoding.ASCII.GetString(w);
        }

        public static OSField[] GetFieldsByOSSInfo(List<byte> osiBytes)
        {
            OSField[] flds = GetTable1Flds();
            int cur=0;
            foreach (OSField fld in flds)
            {
                if (fld.m_FieldName == "TypeofNumber")
                {
                    fld.SetValue((byte)(osiBytes[cur] >> 4));
                }
                else if (fld.m_FieldName == "NumberingPlanIndicator")
                {
                    fld.SetValue((byte)(osiBytes[cur] & 0xF));
                    cur += 1;
                }
                else
                {
                    fld.SetValue(osiBytes.GetRange(cur, fld.m_sizeInHalfBytes / 2));
                    cur += fld.m_sizeInHalfBytes / 2;
                }
            }
            return flds;
        }

        public static OSField[] GetTable1Flds()
        {
            OSField[] ret = {
                                new OSField("CallIdentificationNumber",6,FieldType.BCD ,"FFFFFF"),
                                new OSField("ChargedParty",2,FieldType.BCD,"FF"),
                                new OSField("ChargingCase",4,FieldType.BCD,"FFFF"),
                                new OSField("TariffClass",4,FieldType.BCD,"FFFF"),
                                new OSField("OutgoingRoute",14,FieldType.CHAR,"20202020202020"),
                                new OSField("IncomingRoute",14,FieldType.CHAR,"20202020202020"),
                                new OSField("EOSInfo",2,FieldType.BCD,"FF"),
                                new OSField("LastPartialOutput",2,FieldType.NUM,"0"),
                                new OSField("PartialOutputRecNum",2,FieldType.BCD,"0"),
                                new OSField("FaultCode",4,FieldType.NUM,"0"),
                                new OSField("INMarkingofMS",2,FieldType.NUM,"0"),
                                new OSField("AccountCode",10,FieldType.BCD,"FFFFFFFFFF"),
                                new OSField("TypeofNumber",1,FieldType.BCD,"F"),
                                new OSField("NumberingPlanIndicator",1,FieldType.BCD,"F"),
                                new OSField("TranslatedNumber",38,FieldType.BCD,"38*F"),
                                new OSField("ServiceCode",2,FieldType.BCD,"0"),
                                new OSField("TypeofAccess",2,FieldType.BCD,"0"),
                                new OSField("FunctionTrace",28,FieldType.BCD,"28*F"),
                                new OSField("CallType",2,FieldType.BCD,"FF"),
                                new OSField("ServiceSubscriberId",28,FieldType.BCD,"28*F"),
                                new OSField("CostDistributionCode",28,FieldType.BCD,"28*F"),
                                new OSField("ExtraCostDistributionCode",28,FieldType.BCD,"28*F"),
                                new OSField("PublicNumberCalledNumber",16,FieldType.BCD,"16*F"),
                                new OSField("ExtraDestinationNumber",16,FieldType.BCD,"16*F"),
                                new OSField("LocationIndicatorCallingParty",2,FieldType.BCD,"FF"),
                                new OSField("LocationIndicatorCalledParty",2,FieldType.BCD,"FF"),
                                new OSField("TypeofTermination",2,FieldType.BCD,"FF"),
                                new OSField("LocationNumber",28,FieldType.BCD,"28*F"),
                                new OSField("PublicNumberCallingNumber",16,FieldType.BCD,"16*F"),
                                new OSField("TransitCDRIndicator",2,FieldType.BCD,"0")
                            };
            return ret;
        }

    }

}




