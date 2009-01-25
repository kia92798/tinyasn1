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

        public static string BCDToString_noTrailingF(List<byte> data)
        {
            string ret = BCDToString(data);

            while (ret.EndsWith("F"))
                ret = ret.Substring(0, ret.Length - 1);
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

    public class ConversionErrorException : Exception
    {
        public ConversionErrorException(string errMsg, params object[] args)
            :base (string.Format(errMsg, args))
        {
        }
    }

    public partial class RootNode
    {
        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            uint decodedData = 0;
            while (strm.Position<strm.Length)
            {
                DataInterChange ch = AppendNewChild();
                decodedData += ch.Decode(strm, encRule);
            }

            return decodedData;

        }

        
        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            uint ret = 0;
            foreach (DataInterChange ch in m_children)
                ret += ch.Encode(strm, encRule);
            return ret;
        }
    
    }


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
        DNACall cll = null;

        //public override void ToXml(StreamWriterLevel o, string tag, int l, string attrs)
        //{

        //    cll = DNACall.CreateCall(Value);

        //    o.P(l); o.WriteLine("<{0} callType=\"{1}\">", tag, cll.CallType);

        //    foreach (DNACall.FieldValue fld in cll.Fields)
        //    {
        //        o.P(l+1);
        //        o.WriteLine("<{0}>{1}</{0}>", fld.m_fldDesc.m_FieldName, XML.esc(fld.m_value));
        //    }


        //    o.P(l); o.WriteLine("</{0}>", tag);
        //}

        public override void ToXml(XmlWriter o, string tag, params KeyValuePair<string, string>[] attrs)
        {
            cll = DNACall.CreateCall(Value);
            o.WriteStartElement(tag);
            foreach (KeyValuePair<string, string> at in attrs)
                o.WriteAttributeString(at.Key, at.Value);

            o.WriteAttributeString("callType", cll.CallType);

            foreach (DNACall.FieldValue fld in cll.Fields)
            {
                o.WriteStartElement(fld.m_fldDesc.m_FieldName);
                o.WriteString(fld.m_value);
                o.WriteEndElement();
            }
            o.WriteEndElement();
        }



        string curChild = string.Empty;
        protected override Asn1Object OnXmlOpenTag(string tag, XmlReader tr)
        {
            curChild = tag;
            return this;
        }

        public override void OnXmlAttribute(XmlReader tr)
        {
            cll = DNACall.CreateCall(tr.GetAttribute("callType"));
        }

        protected override void OnXmlData(string data)
        {
            if (curChild == string.Empty)
                return;
            cll.AddFieldValue(curChild, data);
        }

        public override uint Encode(Stream strm, EncodingRules encRule, bool primitive, uint tag)
        {
            Value = cll.CreateOSRawData();
            long sPos = strm.Position;
            BER.EncodeTagAsInt(strm, tag, primitive);
            BER.EncodeLengthDF(strm, (uint)Value.Count);
            EncodeContent(strm, encRule);

            return (uint)(strm.Position - sPos);
        }
        
    }


    public class DNACall
    {
        public class StaticFldDesc
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
            public string m_DefValue = string.Empty;

            public int SizeInBytes { get { return m_sizeInHalfBytes / 2; } }
            
            public StaticFldDesc(string flName, int flSize, FieldType flType, string defValue)
            {
                m_FieldName = flName;
                m_FieldType = flType;
                m_sizeInHalfBytes = flSize;
                m_DefValue = defValue;
                if (m_DefValue == string.Empty && m_FieldType == FieldType.CHAR)
                    m_DefValue = new string(' ', m_sizeInHalfBytes/2);
            }
        }

        public virtual string CallType
        {
            get { return GetType().Name; }
        }

        public class FieldValue
        {
            public FieldValue(StaticFldDesc stFld)
            {
                m_fldDesc = stFld;
            }
            public StaticFldDesc m_fldDesc;
            public FieldValue(StaticFldDesc stFld, string val)
            {
                m_fldDesc = stFld;
                m_value = val;
            }
            public string m_value = string.Empty;
        }

        public virtual void AddFieldValue(string fieldName, string value)
        {
            StaticFldDesc  f = GetFldDecs().Find(delegate(StaticFldDesc p) { if (p.m_FieldName == fieldName) return true; return false; });
            if (f == null)
                throw new Exception(string.Format("Call of type {0} does not contain field with name {1}", CallType, fieldName));
            Fields.Add(new FieldValue(f, value));
        }
        





        protected List<FieldValue> m_felds = new List<FieldValue>();
        public bool ContainsField(string fldName)
        {
            foreach (FieldValue fv in Fields)
                if (fv.m_fldDesc.m_FieldName == fldName)
                    return true;
            return false;
        }

        public FieldValue GetField(string fieldName)
        {
            foreach (FieldValue fv in Fields)
                if (fv.m_fldDesc.m_FieldName == fieldName)
                    return fv;
            throw new KeyNotFoundException(fieldName);
        }

        public List<FieldValue> Fields
        {
            get
            {
                return m_felds;
            }
        }


        public static DNACall CreateCall(List<Byte> osData) 
        {
            if (recCreators == null)
            {
                recCreators = new Dictionary<int, Func<List<byte>,DNACall>>();
                recCreators.Add(sizeInHalfBytes(City_GSM_call.City_GSM), delegate(List<byte> osInfo) { return new City_GSM_call(osInfo); });
                recCreators.Add(sizeInHalfBytes(City_SCU_MMS_call.City_SCU_MMS), delegate(List<byte> osInfo) { return new City_SCU_MMS_call(osInfo); });
                recCreators.Add(sizeInHalfBytes(SGw_SMS_call.SGw_SMS), delegate(List<byte> osInfo) { return new SGw_SMS_call(osInfo); });
                recCreators.Add(sizeInHalfBytes(SGw_MMS_call.SGw_MMS), delegate(List<byte> osInfo) { return new SGw_MMS_call(osInfo); });
                recCreators.Add(sizeInHalfBytes(SGw_WAP_call.SGw_WAP), delegate(List<byte> osInfo) { return new SGw_WAP_call(osInfo); });
            }

            return recCreators[osData.Count * 2](osData);


        }

        static Dictionary<int, Func<List<byte>, DNACall>> recCreators = null;


        public static DNACall CreateCall(string protocolClass)
        {
            if (recCreators2 == null)
            {
                recCreators2 = new Dictionary<string, Func<DNACall>>();
                recCreators2.Add(typeof(City_GSM_call).Name, delegate() { return new City_GSM_call(); });
                recCreators2.Add(typeof(City_SCU_MMS_call).Name, delegate() { return new City_SCU_MMS_call(); });
                recCreators2.Add(typeof(SGw_SMS_call).Name, delegate() { return new SGw_SMS_call(); });
                recCreators2.Add(typeof(SGw_MMS_call).Name, delegate() { return new SGw_MMS_call(); });
                recCreators2.Add(typeof(SGw_WAP_call).Name, delegate() { return new SGw_WAP_call(); });
            }

            

            return recCreators2[protocolClass]();
        }

        static Dictionary<string, Func<DNACall>> recCreators2 = null;

        static int sizeInHalfBytes(StaticFldDesc[] arr)
        {
            int ret = 0;
            foreach (StaticFldDesc f in arr)
                ret += f.m_sizeInHalfBytes;
            return ret;
        }

        public virtual List<StaticFldDesc> GetFldDecs()
        {
            throw new AbstractMethodCalledException();
        }

        public List<byte> CreateOSRawData()
        {
            List<byte> ret = new List<byte>();
            byte TypeofNumberAndNumberingPlanIndicator = 0;

            foreach (StaticFldDesc stField in GetFldDecs())
            {
                string val = string.Empty;
                if (ContainsField(stField.m_FieldName))
                {
                    val = GetField(stField.m_FieldName).m_value;
                }
                else
                {
                    val = stField.m_DefValue;
                }

                if (stField.m_FieldName == "TypeofNumber")
                {
                    TypeofNumberAndNumberingPlanIndicator = (byte)(byte.Parse(val, System.Globalization.NumberStyles.HexNumber) << 4);
                }
                else if (stField.m_FieldName == "NumberingPlanIndicator")
                {
                    TypeofNumberAndNumberingPlanIndicator |= byte.Parse(val, System.Globalization.NumberStyles.HexNumber);
                    ret.Add(TypeofNumberAndNumberingPlanIndicator);
                }
                else
                {
                    if (stField.m_FieldType == StaticFldDesc.FieldType.BCD)
                    {
                        if (val.Length > stField.m_sizeInHalfBytes)
                            throw new ConversionErrorException("Field {0} can contain values up to {1} nibbles. Cuttent value '{2}' has {3}. ", stField.m_FieldName, stField.m_sizeInHalfBytes, val, val.Length);
                        if (val.Length < stField.m_sizeInHalfBytes)
                            val += new string('F', stField.m_sizeInHalfBytes - val.Length);
                        //                        val = new string('0', stField.m_sizeInHalfBytes - val.Length) + val;
                        ret.AddRange(TAP3Common.BCDUtils.StringToBCD(val));
                    }
                    else if (stField.m_FieldType == StaticFldDesc.FieldType.CHAR)
                    {
                        if (val.Length > stField.m_sizeInHalfBytes / 2)
                            throw new ConversionErrorException("Field {0} can contain values up to {1} characters. Cuttent value '{2}' has {3}. ", stField.m_FieldName, stField.m_sizeInHalfBytes / 2, val, val.Length);

                        if (val.Length < stField.m_sizeInHalfBytes / 2)
                            val += new string(' ', stField.m_sizeInHalfBytes / 2 - val.Length);


                        //ret.AddRange(ASCIIEncoding.ASCII.GetBytes(val));
                        ret.AddRange(Encoding.GetEncoding(0).GetBytes(val));
                    }
                    else if (stField.m_FieldType == StaticFldDesc.FieldType.NUM)
                    {
                        int n = int.Parse(val);
                        List<byte> tmp = new List<byte>(BitConverter.GetBytes(n));
                        tmp = tmp.GetRange(0, stField.m_sizeInHalfBytes / 2);
                        tmp.Reverse();
                        ret.AddRange(tmp);
                    }
                }
            }
            return ret;
        }

        public DNACall(List<Byte> osData)
        {
            
            int cur = 0;
            foreach (StaticFldDesc fld in GetFldDecs())
            {
                FieldValue fv = new FieldValue(fld);
                if (fld.m_FieldName == "TypeofNumber")
                {
                    fv.m_value = GetFldValueAsString(fld.m_FieldType, (byte)(osData[cur] >> 4));
                }
                else if (fld.m_FieldName == "NumberingPlanIndicator")
                {
                    fv.m_value = GetFldValueAsString(fld.m_FieldType, (byte)(osData[cur] & 0xF));
                    cur += 1;
                }
                else
                {
                    fv.m_value = GetFldValueAsString(fld.m_FieldType, osData.GetRange(cur, fld.m_sizeInHalfBytes / 2));
                    cur += fld.m_sizeInHalfBytes / 2;
                }
                m_felds.Add(fv);
            }

        }

        public DNACall() { }


        private string GetFldValueAsString(StaticFldDesc.FieldType fieldType, List<byte> osiBytes)
        {
            //Encoding enc = ASCIIEncoding;

            Encoding enc = Encoding.GetEncoding(0);

            if (fieldType == StaticFldDesc.FieldType.BCD)
                return TAP3Common.BCDUtils.BCDToString(osiBytes);

            if (fieldType == StaticFldDesc.FieldType.CHAR)
                return enc.GetString(osiBytes.ToArray());

            if (fieldType == StaticFldDesc.FieldType.NUM)
            {
                ulong v = 0;
                foreach (byte b in osiBytes)
                {
                    v <<= 8;
                    v |= b;
                }
                return v.ToString();
            }

            throw new Exception("BUG");
        }

        private string GetFldValueAsString(StaticFldDesc.FieldType fieldType, byte b)
        {
            byte[] w = new byte[1];
            if (b < 10)
                w[0] = (byte)('0' + b);
            else
                w[0] = (byte)('A' + b - 10);

            return ASCIIEncoding.ASCII.GetString(w);
        }

        
    }


    public class City_GSM_call : DNACall
    {

        public City_GSM_call(List<Byte> osData)
            : base(osData)
        {
        }
        public City_GSM_call()
        {
        }


        static List<StaticFldDesc> _GetFldDecs_res = null;
        public override List<StaticFldDesc> GetFldDecs()
        {
            if (_GetFldDecs_res == null)
                _GetFldDecs_res = new List<StaticFldDesc>(City_GSM);
            return _GetFldDecs_res;
        }





        
        public static StaticFldDesc[] City_GSM = {
                                new StaticFldDesc("CallIdentificationNumber",6,StaticFldDesc.FieldType.BCD ,"FFFFFF"),
                                new StaticFldDesc("ChargedParty",2,StaticFldDesc.FieldType.BCD,"FF"),
                                new StaticFldDesc("ChargingCase",4,StaticFldDesc.FieldType.BCD,"FFFF"),
                                new StaticFldDesc("TariffClass",4,StaticFldDesc.FieldType.BCD,"FFFF"),
                                new StaticFldDesc("OutgoingRoute",14,StaticFldDesc.FieldType.CHAR,"       "),
                                new StaticFldDesc("IncomingRoute",14,StaticFldDesc.FieldType.CHAR,"       "),
                                new StaticFldDesc("EOSInfo",2,StaticFldDesc.FieldType.BCD,"FF"),
                                new StaticFldDesc("LastPartialOutput",2,StaticFldDesc.FieldType.NUM,"0"),
                                new StaticFldDesc("PartialOutputRecNum",2,StaticFldDesc.FieldType.BCD,"0"),     
                                new StaticFldDesc("FaultCode",4,StaticFldDesc.FieldType.NUM,"0"),
                                new StaticFldDesc("INMarkingofMS",2,StaticFldDesc.FieldType.NUM,"0"),
                                new StaticFldDesc("AccountCode",10,StaticFldDesc.FieldType.BCD,"FFFFFFFFFF"),
                                new StaticFldDesc("TypeofNumber",1,StaticFldDesc.FieldType.BCD,"F"),
                                new StaticFldDesc("NumberingPlanIndicator",1,StaticFldDesc.FieldType.BCD,"F"),
                                new StaticFldDesc("TranslatedNumber",38,StaticFldDesc.FieldType.BCD,"FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF"),
                                new StaticFldDesc("ServiceCode",2,StaticFldDesc.FieldType.BCD,"00"),
                                new StaticFldDesc("TypeofAccess",2,StaticFldDesc.FieldType.BCD,"00"),
                                new StaticFldDesc("FunctionTrace",28,StaticFldDesc.FieldType.BCD,"FFFFFFFFFFFFFFFFFFFFFFFFFFFF"),
                                new StaticFldDesc("CallType",2,StaticFldDesc.FieldType.BCD,"FF"),
                                new StaticFldDesc("ServiceSubscriberId",28,StaticFldDesc.FieldType.BCD,"FFFFFFFFFFFFFFFFFFFFFFFFFFFF"),
                                new StaticFldDesc("CostDistributionCode",28,StaticFldDesc.FieldType.BCD,"FFFFFFFFFFFFFFFFFFFFFFFFFFFF"),
                                new StaticFldDesc("ExtraCostDistributionCode",28,StaticFldDesc.FieldType.BCD,"FFFFFFFFFFFFFFFFFFFFFFFFFFFF"),
                                new StaticFldDesc("PublicNumberCalledNumber",16,StaticFldDesc.FieldType.BCD,"FFFFFFFFFFFFFFFF"),
                                new StaticFldDesc("ExtraDestinationNumber",16,StaticFldDesc.FieldType.BCD,"FFFFFFFFFFFFFFFF"),
                                new StaticFldDesc("LocationIndicatorCallingParty",2,StaticFldDesc.FieldType.BCD,"FF"),
                                new StaticFldDesc("LocationIndicatorCalledParty",2,StaticFldDesc.FieldType.BCD,"FF"),
                                new StaticFldDesc("TypeofTermination",2,StaticFldDesc.FieldType.BCD,"FF"),
                                new StaticFldDesc("LocationNumber",28,StaticFldDesc.FieldType.BCD,"FFFFFFFFFFFFFFFFFFFFFFFFFFFF"),
                                new StaticFldDesc("PublicNumberCallingNumber",16,StaticFldDesc.FieldType.BCD,"FFFFFFFFFFFFFFFF"),
                                new StaticFldDesc("TransitCDRIndicator",2,StaticFldDesc.FieldType.BCD,"0")
                            };
     

    }


    public class City_SCU_MMS_call : DNACall
    {

        public City_SCU_MMS_call(List<Byte> osData)
            : base(osData)
        {
        }
        public City_SCU_MMS_call()
        {
        }


        static List<StaticFldDesc> _GetFldDecs_res = null;
        public override List<StaticFldDesc> GetFldDecs()
        {
            if (_GetFldDecs_res == null)
                _GetFldDecs_res = new List<StaticFldDesc>(City_SCU_MMS);
            return _GetFldDecs_res;
        }


        public static StaticFldDesc[] City_SCU_MMS = {
                                new StaticFldDesc("CdrType",	2*2, StaticFldDesc.FieldType.BCD, new string('F',4)),
                                new StaticFldDesc("MsgId",	2*21, StaticFldDesc.FieldType.CHAR,	new string(' ',21)),
                                new StaticFldDesc("MsgFrom",	2*32, StaticFldDesc.FieldType.CHAR,	new string(' ',32)),
                                new StaticFldDesc("MsgTo",	2*32, StaticFldDesc.FieldType.CHAR,	new string(' ',32)),
                                new StaticFldDesc("MsgSize",	2*3, StaticFldDesc.FieldType.BCD,	new string('F',6)),
                                new StaticFldDesc("MsgOriginIndicator", 	2*2, StaticFldDesc.FieldType.BCD,	new string('F',4)),
                                new StaticFldDesc("ExternalApplicationAddress", 2*40, StaticFldDesc.FieldType.CHAR,	new string(' ',40)),
                                new StaticFldDesc("XTecnomenMMsCharging", 	2*3, StaticFldDesc.FieldType.BCD,	new string('F',6)),
                                new StaticFldDesc("ServiceProviderId",	2*2, StaticFldDesc.FieldType.BCD,	new string('F',4)),
                                new StaticFldDesc("ParentMsgId", 	2*32, StaticFldDesc.FieldType.CHAR,	new string(' ',32)),
                                new StaticFldDesc("MsgNumRecipients",	2*3, StaticFldDesc.FieldType.BCD,	new string('F',6)),
                                new StaticFldDesc("BIMSI",	2*15, StaticFldDesc.FieldType.CHAR,	new string('F',15))
                                                     };
    }


    public class SGw_SMS_call : DNACall
    {

        public SGw_SMS_call(List<Byte> osData)
            : base(osData)
        {
        }
        public SGw_SMS_call()
        {
        }


        static List<StaticFldDesc> _GetFldDecs_res = null;
        public override List<StaticFldDesc> GetFldDecs()
        {
            if (_GetFldDecs_res == null)
                _GetFldDecs_res = new List<StaticFldDesc>(SGw_SMS);
            return _GetFldDecs_res;
        }


        public static StaticFldDesc[] SGw_SMS = {
                new StaticFldDesc("CallIdenficationNumber", 2*6,StaticFldDesc.FieldType.CHAR,""),
                new StaticFldDesc("ChargedParty", 2*1,StaticFldDesc.FieldType.CHAR,""),
                new StaticFldDesc("ChargingCase", 2*2,StaticFldDesc.FieldType.CHAR,""),
                new StaticFldDesc("TariffClass", 2*4,StaticFldDesc.FieldType.CHAR,""),
                new StaticFldDesc("OutgoingRoute", 2*7,StaticFldDesc.FieldType.CHAR,""),
                new StaticFldDesc("IncomingRoute", 2*7,StaticFldDesc.FieldType.CHAR,""),
                new StaticFldDesc("EOSInfo", 2*1,StaticFldDesc.FieldType.CHAR,""),
                new StaticFldDesc("LastPartialOutput", 2*1,StaticFldDesc.FieldType.CHAR,""),
                new StaticFldDesc("PartialOutputRecNum", 2*1,StaticFldDesc.FieldType.CHAR,""),
                new StaticFldDesc("FaultCode", 2*2,StaticFldDesc.FieldType.CHAR,""),
                new StaticFldDesc("INMarkingOfMS", 2*1,StaticFldDesc.FieldType.CHAR,""),
                new StaticFldDesc("AccountCode", 2*6,StaticFldDesc.FieldType.CHAR,""),
                new StaticFldDesc("TypeOfNumber", 2*1,StaticFldDesc.FieldType.CHAR,""),
                new StaticFldDesc("NumperingPlanIndicator", 2*1,StaticFldDesc.FieldType.CHAR,""),
                new StaticFldDesc("TranslatedIndicator", 2*19,StaticFldDesc.FieldType.CHAR,""),
                new StaticFldDesc("ServiceCode", 2*1,StaticFldDesc.FieldType.CHAR,""),
                new StaticFldDesc("TypeOfAccess", 2*1,StaticFldDesc.FieldType.CHAR,""),
                new StaticFldDesc("FunctionTrace", 2*14,StaticFldDesc.FieldType.CHAR,""),
                new StaticFldDesc("CallType", 2*1,StaticFldDesc.FieldType.CHAR,""),
                new StaticFldDesc("ServiceSubscriberId", 2*14,StaticFldDesc.FieldType.CHAR,""),
                new StaticFldDesc("CostDistributionCode", 2*14,StaticFldDesc.FieldType.CHAR,""),
                new StaticFldDesc("ExtraCostDistributionCode", 2*14,StaticFldDesc.FieldType.CHAR,""),
                new StaticFldDesc("PublicNumberCalledNumber", 2*8,StaticFldDesc.FieldType.CHAR,""),
                new StaticFldDesc("ExtraDestinationNumber", 2*8,StaticFldDesc.FieldType.CHAR,""),
                new StaticFldDesc("LocationIndicatorCallingParty", 2*1,StaticFldDesc.FieldType.CHAR,""),
                new StaticFldDesc("LocationIndicatorCalledParty", 2*1,StaticFldDesc.FieldType.CHAR,""),
                new StaticFldDesc("TypeOfTermination", 2*1,StaticFldDesc.FieldType.CHAR,""),
                new StaticFldDesc("LocationNumber", 2*14,StaticFldDesc.FieldType.CHAR,""),
                new StaticFldDesc("PublicNumberCallingNumber", 2*8,StaticFldDesc.FieldType.CHAR,""),
                new StaticFldDesc("TransitCDRIndicator", 2*1,StaticFldDesc.FieldType.CHAR,""),
                new StaticFldDesc("ServiceProviderName", 2*24,StaticFldDesc.FieldType.CHAR,""),
                new StaticFldDesc("ServiceDescription", 2*24,StaticFldDesc.FieldType.CHAR,""),
                new StaticFldDesc("ServiceCategoryID", 2*3,StaticFldDesc.FieldType.CHAR,""),
                new StaticFldDesc("ServiceDescriptionID", 2*3,StaticFldDesc.FieldType.CHAR,""),
                            };
    }


    public class SGw_MMS_call : DNACall
    {

        public SGw_MMS_call(List<Byte> osData)
            : base(osData)
        {
        }
        public SGw_MMS_call()
        {
        }


        static List<StaticFldDesc> _GetFldDecs_res = null;
        public override List<StaticFldDesc> GetFldDecs()
        {
            if (_GetFldDecs_res == null)
                _GetFldDecs_res = new List<StaticFldDesc>(SGw_MMS);
            return _GetFldDecs_res;
        }


        public static StaticFldDesc[] SGw_MMS = {
                new StaticFldDesc("CdrType", 2*4,StaticFldDesc.FieldType.CHAR,""),
                new StaticFldDesc("MsgId", 2*21,StaticFldDesc.FieldType.CHAR,""),
                new StaticFldDesc("MsgFrom", 2*32,StaticFldDesc.FieldType.CHAR,""),
                new StaticFldDesc("MsgTo", 2*32,StaticFldDesc.FieldType.CHAR,""),
                new StaticFldDesc("MsgSize", 2*6,StaticFldDesc.FieldType.CHAR,""),
                new StaticFldDesc("MsgOriginIndicator", 2*2,StaticFldDesc.FieldType.CHAR,""),
                new StaticFldDesc("ExternalApplicationAddress", 2*40,StaticFldDesc.FieldType.CHAR,""),
                new StaticFldDesc("MMsCharging", 2*3,StaticFldDesc.FieldType.CHAR,""),
                new StaticFldDesc("ServiceProviderId", 2*4,StaticFldDesc.FieldType.CHAR,""),
                new StaticFldDesc("ParentMsgId", 2*32,StaticFldDesc.FieldType.CHAR,""),
                new StaticFldDesc("MsgNumRecipients", 2*5,StaticFldDesc.FieldType.CHAR,""),
                new StaticFldDesc("BIMSI", 2*15,StaticFldDesc.FieldType.CHAR,""),
                new StaticFldDesc("ServiceProviderName", 2*24,StaticFldDesc.FieldType.CHAR,""),
                new StaticFldDesc("ServiceDescription", 2*24,StaticFldDesc.FieldType.CHAR,""),
                new StaticFldDesc("ServiceCategoryID", 2*3,StaticFldDesc.FieldType.CHAR,""),
                new StaticFldDesc("ServiceDescriptionID", 2*3,StaticFldDesc.FieldType.CHAR,"")
                            };
    }

    public class SGw_WAP_call : DNACall
    {

        public SGw_WAP_call(List<Byte> osData)
            : base(osData)
        {
        }
        public SGw_WAP_call()
        {
        }


        static List<StaticFldDesc> _GetFldDecs_res = null;
        public override List<StaticFldDesc> GetFldDecs()
        {
            if (_GetFldDecs_res == null)
                _GetFldDecs_res = new List<StaticFldDesc>(SGw_WAP);
            return _GetFldDecs_res;
        }


        public static StaticFldDesc[] SGw_WAP = {
                new StaticFldDesc("CDRType", 2*2,StaticFldDesc.FieldType.CHAR,""),
                new StaticFldDesc("SubscriberType", 2*2,StaticFldDesc.FieldType.CHAR,""),
                new StaticFldDesc("ErrorCode", 2*4,StaticFldDesc.FieldType.CHAR,""),
                new StaticFldDesc("AccessType", 2*2,StaticFldDesc.FieldType.CHAR,""),
                new StaticFldDesc("TariffClass", 2*4,StaticFldDesc.FieldType.CHAR,""),
                new StaticFldDesc("ServiceCategoryID", 2*3,StaticFldDesc.FieldType.CHAR,"")
                            };
    }


}




