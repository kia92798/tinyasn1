using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using CSharpAsn1CRT;
using semantix.util;


namespace Common
{
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







namespace TAP_0301
{
    public partial class BCDString
    {
        public override string ValueAsString
        {
            get { return Common.BCDUtils.BCDToString(Value);  }
            set { Value = Common.BCDUtils.StringToBCD(value); }
        }
    }
}


namespace TAP_0302
{
    public partial class BCDString
    {
        public override string ValueAsString
        {
            get { return Common.BCDUtils.BCDToString(Value); }
            set { Value = Common.BCDUtils.StringToBCD(value); }
        }
    }
}

namespace TAP_0303
{
    public partial class BCDString
    {
        public override string ValueAsString
        {
            get { return Common.BCDUtils.BCDToString(Value); }
            set { Value = Common.BCDUtils.StringToBCD(value); }
        }
    }
}


namespace TAP_0304
{
    public partial class BCDString
    {
        public override string ValueAsString
        {
            get { return Common.BCDUtils.BCDToString(Value); }
            set { Value = Common.BCDUtils.StringToBCD(value); }
        }
    }
}

namespace TAP_0309
{
    public partial class BCDString
    {
        public override string ValueAsString
        {
            get { return Common.BCDUtils.BCDToString(Value); }
            set { Value = Common.BCDUtils.StringToBCD(value); }
        }
    }
}



namespace TAP_0310
{
    public partial class BCDString
    {
        public override string ValueAsString
        {
            get { return Common.BCDUtils.BCDToString(Value); }
            set { Value = Common.BCDUtils.StringToBCD(value); }
        }
    }
}


namespace TAP_0311
{
    public partial class BCDString
    {
        public override string ValueAsString
        {
            get { return Common.BCDUtils.BCDToString(Value); }
            set { Value = Common.BCDUtils.StringToBCD(value); }
        }
    }

}
namespace TAP_0311_DNA
{

    public partial class BCDString
    {
        public override string ValueAsString
        {
            get { return Common.BCDUtils.BCDToString(Value); }
            set { Value = Common.BCDUtils.StringToBCD(value); }
        }
    }


    public partial class OperatorSpecInformation
    {

        public override void ToXml(StreamWriterLevel o, string tag, int l)
        {
            o.P(l); o.WriteLine("<{0}>", tag);

            string ret = string.Empty;
            OSField[] flds = OSField.GetFieldsByOSSInfo(Value);

            foreach (OSField fld in flds)
            {
                o.P(l+1);
                o.WriteLine("<{0}>{1}</{0}>", fld.m_FieldName, fld.m_Value);
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
                m_Value = Common.BCDUtils.BCDToString(osiBytes);
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




