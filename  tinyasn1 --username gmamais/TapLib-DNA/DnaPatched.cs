using System;
using System.Collections.Generic; 
using System.Linq;
using System.Text;
using CSharpAsn1CRT;
using System.IO;
using System.Xml;
using Tap3Utils;
using semantix.util;

namespace TAP_0311_DNA
{
    public class ConversionErrorException : Exception
    {
        public ConversionErrorException(string errMsg, params object[] args)
            : base(string.Format(errMsg, args))
        {
        }
    }

    public partial class RootNode
    {
        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            uint decodedData = 0;
            while (strm.Position < strm.Length)
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


        public static void ToXml(string inputFile, string outFile)
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

        public static void ToBer(string inputFile, string outFile)
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


    public partial class BCDString
    {
        public override string ValueAsString
        {
            get { return BCDUtils.BCDToString(Value); }
            set { Value = BCDUtils.StringToBCD(value); }
        }
        public override void OnXmlData(string data)
        {
            Value = BCDUtils.StringToBCD(data);
        }
    }

    public static class DNA_Extensios
    {
        static Dictionary<string, uint> _customSizes = new Dictionary<string, uint>();

        public static uint CustomSizeInBytes(this Asn1SequenceOrSetObject obj)
        {
            string typeName = obj.GetType().Name;
            if (!_customSizes.ContainsKey(typeName))
            {
                _customSizes.Add(typeName, 0);

                foreach (var a in obj.ClassDef.m_children.Values)
                {
                    var dummy = a.createObj();
                    _customSizes[typeName] += uint.Parse(dummy.CustomAttrs["Size"]);
                }

                if (typeName == typeof(City).Name)
                    _customSizes[typeName]--;

            }
            return _customSizes[typeName];
        }


        public static uint EncodeContent_and_only_content(this Asn1SequenceOrSetObject obj, Stream strm, EncodingRules encRule)
        {
            uint total = 0;
            for (int i = 0; i < obj.m_children.Length; i++)
            {
                if (obj.m_children[i] == null)
                {
                    obj.m_children[i] = obj.ClassDef[i].createObj();
                    ((IOperSpecField)(obj.m_children[i])).SetValueToDefault();
                }
                total += obj.m_children[i].EncodeContent(strm, encRule);
            }

            return total;
        }

        public static uint DecodeContent_and_only_content(this Asn1SequenceOrSetObject obj, Stream strm, EncodingRules encRule)
        {
            uint total = 0;
            for (int i = 0; i < obj.m_children.Length; i++)
            {
                obj.m_children[i] = obj.ClassDef[i].createObj();
                obj.m_children[i].Parent = obj;
                total = obj.m_children[i].DecodeContent(strm, encRule, 0xFFFFFFFF, false);
            }
            return total;
        }

    }


    public partial class OperatorSpecInformation
    {
        public override bool IsPrimitive
        {
            get
            {
                return true;
            }
        }

        public override uint EncodeContent(Stream strm, EncodingRules encRule)
        {
            return   ((Asn1SequenceOrSetObject)m_Alternative).EncodeContent_and_only_content(strm, encRule);
        }

        public override uint DecodeContent(Stream strm, EncodingRules encRule, uint dataLen, bool indefiniteForm)
        {
            NamedChild childClass = _creators[dataLen];
            m_children[childClass.m_index] = childClass.createObj();
            m_children[childClass.m_index].Parent = this;
            return ((Asn1SequenceOrSetObject)m_children[childClass.m_index]).DecodeContent_and_only_content(strm, encRule);
        }

        static Dictionary<uint, NamedChild> _creators = new Dictionary<uint, NamedChild>();
        static OperatorSpecInformation()
        {
            foreach (var a in _clsDef.m_children.Values)
            {
                Asn1SequenceOrSetObject dummy = (Asn1SequenceOrSetObject)a.createObj();
                _creators.Add(dummy.CustomSizeInBytes(), a);
            }

        }

    }





    interface IOperSpecField
    {
        void SetValueToDefault();
    }

    public partial class OSFBCDString : IOperSpecField
    {
        public override uint EncodeContent(Stream strm, EncodingRules encRule)
        {
            int len = int.Parse(CustomAttrs["Size"]);
            if (Value.Count < len)
                Value.AddRange(Enumerable.Repeat<byte>(0xFF, len - Value.Count));
            else if (Value.Count > len)
                Value.RemoveRange(len, Value.Count - len);

            return base.EncodeContent(strm, encRule);
        }

        public override uint DecodeContent(Stream strm, EncodingRules encRule, uint dataLen, bool indefiniteForm)
        {
            uint len = uint.Parse(CustomAttrs["Size"]);
            return base.DecodeContent(strm, encRule, len, false);
        }


        public virtual void SetValueToDefault()
        {
            Value = BCDUtils.StringToBCD(CustomAttrs["DV"]);
        }

        public override List<byte> Value
        {
            get  { return base.Value; }
            set  
            {
                int len = int.Parse(CustomAttrs["Size"]);
                if (len < value.Count)
                    throw new Exception(string.Format("Value is bigger than the maximum allowed (max allowed is {0} bytes)", len));
                base.Value = value;
            }
        }

    }


    public partial class TypeofNumber
    {
        public override uint EncodeContent(Stream strm, EncodingRules encRule)
        {
            //encoded in NumberingPlan !!
            return 0;
        }

        public override uint DecodeContent(Stream strm, EncodingRules encRule, uint dataLen, bool indefiniteForm)
        {
            return 0;
        }

        public override void SetValueToDefault()
        {
            Value.Clear();
            Value.Add(0xF);
        }
        public override List<byte> Value
        {
            get { return base.Value; }
            set
            {
                if (value.Count>1 && value[0]>0xF)
                    throw new Exception(string.Format("Value is bigger than the maximum allowed (max allowed is 1 nibble)"));
               base.Value = value;
            }
        }
    }

    public partial class NumberingPlanIndicator
    {
        public override uint EncodeContent(Stream strm, EncodingRules encRule)
        {
            City city = Parent as City;

            byte TypeofNumberAndNumberingPlanIndicator = 0;

            TypeofNumberAndNumberingPlanIndicator = (byte)(city.typeofNumber.Value[0] << 4);

            TypeofNumberAndNumberingPlanIndicator |= (byte)(Value[0] & 0xF);

            strm.WriteByte(TypeofNumberAndNumberingPlanIndicator);
            return 1;
        }

        public override uint DecodeContent(Stream strm, EncodingRules encRule, uint dataLen, bool indefiniteForm)
        {
            City city = Parent as City;

            byte TypeofNumberAndNumberingPlanIndicator = (byte)strm.ReadByte();

            Value.Clear();
            Value.Add((byte)(TypeofNumberAndNumberingPlanIndicator & 0xF));

            city.typeofNumber.Value.Clear();
            city.typeofNumber.Value.Add((byte)(TypeofNumberAndNumberingPlanIndicator >> 4));

            return 1;
        }


        public override void SetValueToDefault()
        {
            Value.Clear();
            Value.Add(0xF);
        }
        public override List<byte> Value
        {
            get { return base.Value; }
            set
            {
                if (value.Count > 1 && value[0] > 0xF)
                    throw new Exception(string.Format("Value is bigger than the maximum allowed (max allowed is 1 nibble)"));
                base.Value = value;
            }
        }
    }

    public partial class OSFAsciiString : IOperSpecField
    {
        public override uint EncodeContent(Stream strm, EncodingRules encRule)
        {

            int len = int.Parse(CustomAttrs["Size"]);

            if (Value.Length > len)
                Value = Value.Substring(0, len);
            if (Value.Length < len)
                Value += new string(' ', len - Value.Length);


            return base.EncodeContent(strm, encRule);
        }


        public override uint DecodeContent(Stream strm, EncodingRules encRule, uint dataLen, bool indefiniteForm)
        {
            uint len = uint.Parse(CustomAttrs["Size"]);
            return base.DecodeContent(strm, encRule, len, false);
        }
        public void SetValueToDefault()
        {
            Value = CustomAttrs["DV"];
        }

        public override string Value
        {
            get { return base.Value; }
            set
            {
                int len = int.Parse(CustomAttrs["Size"]);
                if (len < value.Length)
                    throw new Exception(string.Format("Value is bigger than the maximum allowed (max allowed is {0} characters)", len));

                base.Value = value;
            }
        }
    }

    public partial class OSFInteger : IOperSpecField
    {
        public override long Value
        {
            get
            {
                return base.Value;
            }
            set
            {
                int len = int.Parse(CustomAttrs["Size"]);
                long maxVal = 1;
                for (int i = 0; i < len; i++)
                    maxVal *= 256;
                if (value > maxVal)
                    throw new Exception(string.Format("Value of field {0} can not be larger than {1}", GetType().Name, maxVal));

                base.Value = value;
            }
        }

        public override uint EncodeContent(Stream strm, EncodingRules encRule)
        {
            int len = int.Parse(CustomAttrs["Size"]);

            List<byte> tmp = new List<byte>(BitConverter.GetBytes(Value));
            tmp = tmp.GetRange(0, len);
            tmp.Reverse();
            foreach(var b in tmp)
                strm.WriteByte(b);
            return (uint)tmp.Count;
        }

        public override uint DecodeContent(Stream strm, EncodingRules encRule, uint dataLen, bool indefiniteForm)
        {
            uint len = uint.Parse(CustomAttrs["Size"]);
            return base.DecodeContent(strm, encRule, len, false);
        }

        public void SetValueToDefault()
        {
            Value = long.Parse(CustomAttrs["DV"]);
        }
    }

}


#if fgg

namespace TAP_0311_DNA
{



    public partial class OperatorSpecInformation
    {
        DNACall cll = null;

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
                o.WriteString(fld.Value);
                o.WriteEndElement();
            }
            o.WriteEndElement();
        }


        //1 call creation
        public override void OnXmlAttribute(XmlReader tr)
        {
            string callType = tr.GetAttribute("callType");
            if (callType == null || !DNACall.CallTypes.Contains(callType))
            {
                string callTypes = string.Empty;
                foreach (string ct in DNACall.CallTypes)
                    callTypes += "callType=\"" + ct + "\" or ";
                callTypes = callTypes.Substring(0, callTypes.Length - 4);
                throw new Exception("Mandatory attribute 'callType' is missing. Valid values are: " + callTypes);
            }

            cll = DNACall.CreateCall(callType);
        }

        // 2 fields creation
        string curChild = string.Empty;
        public override IOnXmlVisitNode OnChildElement(string tag, XmlReader tr)
        {
            //curChild = tag;
            //string callType = tr.GetAttribute("callType");
            //return this;

            return cll.AddFieldValue(tag);
        }


        public override void OnXmlData(string data)
        {
            // must be overriden to disable base (octet string) functionality
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
                    m_DefValue = new string(' ', m_sizeInHalfBytes / 2);
            }
        }

        public virtual string CallType
        {
            get { return GetType().Name; }
        }

        public class FieldValue : IOnXmlVisitNode
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
            string m_value = string.Empty;

            public string Value
            {
                get { return m_value; }
                set { SetValue(value); }
            }

            private void SetValue(string value)
            {
                if (m_fldDesc.m_FieldType == StaticFldDesc.FieldType.BCD)
                {
                    if (value.Length > m_fldDesc.m_sizeInHalfBytes)
                        throw new ConversionErrorException("Field {0} can contain values up to {1} nibbles. Current value '{2}' has {3}. ",
                            m_fldDesc.m_FieldName, m_fldDesc.m_sizeInHalfBytes, value, value.Length);
                    if (!BCDUtils.IsValidBCDString(value))
                        throw new ConversionErrorException("Field {0} is not a valid BCD string!", m_fldDesc.m_FieldName);
                }
                else if (m_fldDesc.m_FieldType == StaticFldDesc.FieldType.CHAR)
                {
                    if (value.Length > m_fldDesc.m_sizeInHalfBytes / 2)
                        throw new ConversionErrorException("Field {0} can contain values up to {1} characters. Current value '{2}' has {3}. ",
                            m_fldDesc.m_FieldName, m_fldDesc.m_sizeInHalfBytes / 2, value, value.Length);
                }
                else if (m_fldDesc.m_FieldType == StaticFldDesc.FieldType.NUM)
                {
                    UInt64 intval;
                    if (!UInt64.TryParse(value, out intval))
                    {
                        throw new ConversionErrorException("Field {0} is not a valid integer!", m_fldDesc.m_FieldName);
                    }

                    UInt64 maxVal = 0x0;
                    for (int i = 0; i < m_fldDesc.m_sizeInHalfBytes; i++)
                    {
                        maxVal <<= 4;
                        maxVal |= 0x0F;
                    }
                    if (intval > maxVal)
                        throw new ConversionErrorException("Field {0} contains a larger value {1} than the maximum allowed ({2})!",
                            m_fldDesc.m_FieldName, intval, maxVal);

                }

                m_value = value;
            }

            #region IOnXmlVisitNode Members

            public IOnXmlVisitNode OnChildElement(string tag, XmlReader tr)
            {
                throw new Exception("Node cannot have child elements");
            }

            public void OnXmlAttribute(XmlReader tr)
            {
            }

            public void OnXmlData(string data)
            {
                Value = data;
            }

            public void NodeHasNoData()
            {
                Value = m_fldDesc.m_DefValue;
            }

            #endregion
        }

        public virtual FieldValue AddFieldValue(string fieldName)
        {
            if (Fields.Exists(delegate(FieldValue fv) { if (fv.m_fldDesc.m_FieldName == fieldName) return true; return false; }))
                throw new ConversionErrorException("Field {0} can not be contained twice", fieldName);

            StaticFldDesc fs = GetFieldDescription(fieldName);  // throws exception if fieldName is not found
            FieldValue ret = new FieldValue(fs);
            Fields.Add(ret);
            return ret;
        }

        public virtual FieldValue AddFieldValue(string fieldName, string value)
        {
            StaticFldDesc stField = GetFieldDescription(fieldName);
            //StaticFldDesc stField = GetFldDecs().Find(delegate(StaticFldDesc p) { if (p.m_FieldName == fieldName) return true; return false; });
            //if (stField == null)
            //    throw new Exception(string.Format("Call of type {0} does not contain field with name {1}", CallType, fieldName));




            FieldValue ret = new FieldValue(stField, value);
            Fields.Add(ret);
            return ret;
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

            return recCreators[osData.Count * 2](osData);


        }

        static Dictionary<int, Func<List<byte>, DNACall>> recCreators = null;
        static DNACall()
        {
            recCreators = new Dictionary<int, Func<List<byte>, DNACall>>();
            recCreators.Add(sizeInHalfBytes(City_GSM_call.City_GSM), delegate(List<byte> osInfo) { return new City_GSM_call(osInfo); });
            recCreators.Add(sizeInHalfBytes(City_SCU_MMS_call.City_SCU_MMS), delegate(List<byte> osInfo) { return new City_SCU_MMS_call(osInfo); });
            recCreators.Add(sizeInHalfBytes(SGw_SMS_call.SGw_SMS), delegate(List<byte> osInfo) { return new SGw_SMS_call(osInfo); });
            recCreators.Add(sizeInHalfBytes(SGw_MMS_call.SGw_MMS), delegate(List<byte> osInfo) { return new SGw_MMS_call(osInfo); });
            recCreators.Add(sizeInHalfBytes(SGw_WAP_call.SGw_WAP), delegate(List<byte> osInfo) { return new SGw_WAP_call(osInfo); });

            recCreators2 = new Dictionary<string, Func<DNACall>>();
            recCreators2.Add(typeof(City_GSM_call).Name, delegate() { return new City_GSM_call(); });
            recCreators2.Add(typeof(City_SCU_MMS_call).Name, delegate() { return new City_SCU_MMS_call(); });
            recCreators2.Add(typeof(SGw_SMS_call).Name, delegate() { return new SGw_SMS_call(); });
            recCreators2.Add(typeof(SGw_MMS_call).Name, delegate() { return new SGw_MMS_call(); });
            recCreators2.Add(typeof(SGw_WAP_call).Name, delegate() { return new SGw_WAP_call(); });
        }

        public static DNACall CreateCall(string protocolClass)
        {

            return recCreators2[protocolClass]();
        }

        static Dictionary<string, Func<DNACall>> recCreators2 = null;

        public static List<string> CallTypes
        {
            get { return new List<string>(recCreators2.Keys); }
        }

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

        public StaticFldDesc GetFieldDescription(string fieldName)
        {
            foreach (StaticFldDesc fs in GetFldDecs())
                if (fs.m_FieldName == fieldName)
                    return fs;
            throw new Xml2Asn1DecodeException("Call of type {0} does not contain fields of type {1}.", CallType, fieldName);
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
                    val = GetField(stField.m_FieldName).Value;
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
                        //if (val.Length > stField.m_sizeInHalfBytes)
                        //    throw new ConversionErrorException("Field {0} can contain values up to {1} nibbles. Current value '{2}' has {3}. ", 
                        //        stField.m_FieldName, stField.m_sizeInHalfBytes, val, val.Length);
                        if (val.Length < stField.m_sizeInHalfBytes)
                            val += new string('F', stField.m_sizeInHalfBytes - val.Length);
                        //                        val = new string('0', stField.m_sizeInHalfBytes - val.Length) + val;
                        ret.AddRange(BCDUtils.StringToBCD(val));
                    }
                    else if (stField.m_FieldType == StaticFldDesc.FieldType.CHAR)
                    {
                        //if (val.Length > stField.m_sizeInHalfBytes / 2)
                        //    throw new ConversionErrorException("Field {0} can contain values up to {1} characters. Current value '{2}' has {3}. ", 
                        //        stField.m_FieldName, stField.m_sizeInHalfBytes / 2, val, val.Length);

                        if (val.Length < stField.m_sizeInHalfBytes / 2)
                            val += new string(' ', stField.m_sizeInHalfBytes / 2 - val.Length);


                        //ret.AddRange(ASCIIEncoding.ASCII.GetBytes(val));
                        ret.AddRange(Encoding.GetEncoding(0).GetBytes(val));
                    }
                    else if (stField.m_FieldType == StaticFldDesc.FieldType.NUM)
                    {
                        int n = int.Parse(val); // it should never fail!
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
                    fv.Value = GetFldValueAsString(fld.m_FieldType, (byte)(osData[cur] >> 4));
                }
                else if (fld.m_FieldName == "NumberingPlanIndicator")
                {
                    fv.Value = GetFldValueAsString(fld.m_FieldType, (byte)(osData[cur] & 0xF));
                    cur += 1;
                }
                else
                {
                    fv.Value = GetFldValueAsString(fld.m_FieldType, osData.GetRange(cur, fld.m_sizeInHalfBytes / 2));
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
                return BCDUtils.BCDToString(osiBytes);

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

#endif