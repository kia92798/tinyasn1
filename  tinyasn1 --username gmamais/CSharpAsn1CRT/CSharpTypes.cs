using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using semantix.util;
using System.Xml;

namespace CSharpAsn1CRT
{

    public class UnexpectedTagException : Exception
    {
    }

    public class LengthMismatchException : Exception
    {
    }

    public class UnexpectedEndOfStreamException : Exception
    {
    }

    public class ConstraintViolationException : Exception
    {
    }

    public class EmptyChoiceException : Exception
    {
    }

    public class Xml2Asn1DecodeException : Exception
    {
        public Xml2Asn1DecodeException(string errMessage, params object[] args):base(string.Format(errMessage,args)) 
        {
        }
    }

    public enum EncodingRules
    {
        DER,
        CER,
        uPER,
        aPER
    }

    public enum TagClass
    {
        UNIVERSAL = 0,
        APPLICATION = 1,
        CONTEXT_SPECIFIC = 2,
        PRIVATE = 3,
    }


    public class Tag
    {

        public uint m_tagNo;
        public TagClass m_tgClass;
        public bool isPrimitive;

        public Tag() { }
        public Tag(uint tagNo, TagClass tgClass)
        {
            m_tagNo = tagNo;
            m_tgClass = tgClass;
        }

        public Tag(uint tagNo, TagClass tgClass, bool primitive)
        {
            m_tagNo = tagNo;
            m_tgClass = tgClass;
            isPrimitive = primitive;
        }

        public override bool Equals(object obj)
        {
            Tag o = obj as Tag;
            if (o == null)
                return false;
            return o.m_tagNo == m_tagNo && o.m_tgClass == m_tgClass;
        }
        public override int GetHashCode()
        {
            return m_tagNo.GetHashCode();
        }

    }






    public interface IOnXmlVisitNode
    {
        IOnXmlVisitNode OnChildElement(string tag, XmlReader tr);
        void OnXmlAttribute(XmlReader tr);
        void OnXmlData(string data);
        void NodeHasNoData();
    }

    public abstract class Asn1Object : IOnXmlVisitNode
    {
        
        public abstract uint Decode(Stream strm, EncodingRules encRule);
        public abstract uint Encode(Stream strm, EncodingRules encRule);
        //Encodes only the content, not tag and length
        //return the length of bytes encoded
        public abstract uint EncodeContent(Stream strm, EncodingRules encRule);
        //Decodes only the content, not tag and length
        //returns the length of bytes decoded
        public abstract uint DecodeContent(Stream strm, EncodingRules encRule, uint dataLen, bool indefiniteForm);
        public abstract bool IsConstraintValid();

        public abstract IEnumerable<Asn1Object> GetChildren(bool includeMyself);

        private static Dictionary<string, string> m_defaultCustomeAttrs = new Dictionary<string, string>();
        public virtual Dictionary<string, string> CustomAttrs { get { return m_defaultCustomeAttrs; } }


        Asn1Object _parent = null;
        public Asn1Object Parent
        {
            get
            {
                return _parent;
            }
            set
            {
                _parent = value;
            }
        }

        public virtual IEnumerable<T> GetChildren<T>() where T : Asn1Object
        {
            foreach (Asn1Object cu in GetChildren(false))
            {
                if (cu is T)
                    yield return cu as T;
            }
        }

        public virtual List<Asn1Object> PossibleChildren { get { return new List<Asn1Object>(); } }

        public class Path
        {
            List<Asn1Object> nodes = new List<Asn1Object>();
        }

        //public virtual IEnumerable<T> GetChildren<T>(Func<bool,Path> selector) where T : Asn1Object
        //{
            
        //    throw new Exception();
            
        //}

        public virtual bool IsPrimitive { get { return true; } }


        public virtual uint Encode(Stream strm, EncodingRules encRule, bool primitive, UInt32 tag)
        {
            long sPos = strm.Position;
            if (!primitive)
            {
                BER.EncodeTagAsInt(strm, tag, primitive);
                strm.WriteByte(0x80);
                EncodeContent(strm, encRule);
                strm.WriteByte(0);
                strm.WriteByte(0);
            }
            else
            {
                using (MemoryStream tmp = new MemoryStream())
                {
                    BER.EncodeTagAsInt(strm, tag, primitive);
                    uint len = EncodeContent(tmp, encRule);
                    BER.EncodeLengthDF(strm, len);
                    strm.Write(tmp.GetBuffer(), 0, (int)tmp.Length);
                }
            }
            return (uint)(strm.Position - sPos);
        }
        


        public uint Decode(Stream strm, EncodingRules encRule, bool primitive, UInt32 tag)
        {

            long initPos = strm.Position;

            UInt32 t = BER.DecodeTagAsInt(strm);

            if (t == UInt32.MaxValue)
                throw new UnexpectedTagException();
            if (t != tag)
                throw new UnexpectedTagException();

            uint length = 0;
            bool indefiniteForm;
            BER.DecodeLength(strm, out length, out indefiniteForm);
            long sPos = strm.Position;

            DecodeContent(strm, encRule, length, indefiniteForm);

            long decodedData = strm.Position - sPos;

            if (indefiniteForm)
                BER.DecodeTwoZeros(strm); // throws LengthMismatchException if no two zeros found
            else if (decodedData != length)
                throw new LengthMismatchException();



            return (uint)(strm.Position - initPos);

        }

        public virtual void ToXml(XmlWriter o, string tag, params KeyValuePair<string,string>[] attrs)
        {
            o.WriteStartElement(tag);
            foreach (KeyValuePair<string, string> at in attrs)
                o.WriteAttributeString(at.Key, at.Value);
            WriteXmlContent(o);
            o.WriteEndElement();
        }

        public virtual void WriteXmlContent(XmlWriter o)
        {
        }


        public void FromXml(System.IO.Stream inputData, string rootTag, 
            Dictionary<string, Action<Asn1Object>> notifyEvents)
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.CheckCharacters = false;
            

            using (XmlReader tr = XmlReader.Create(inputData, settings))
            {
                
                try
                {
                    List<IOnXmlVisitNode> stackOfVisitedNodes = new List<IOnXmlVisitNode>();
                    IOnXmlVisitNode curNode = this;

                    stackOfVisitedNodes.Add(curNode);
                    bool hasText = false;
                    while (tr.Read())
                    {
                        if (tr.NodeType == XmlNodeType.Element)
                        {
                            if (tr.Name == rootTag)
                                continue;
                            hasText = false;
                            if (!tr.IsEmptyElement)
                            {
                                curNode = curNode.OnChildElement(tr.Name, tr);
                                stackOfVisitedNodes.Add(curNode);
                            }
                            else
                            {
                                IOnXmlVisitNode emptyElem = curNode.OnChildElement(tr.Name, tr);
                                emptyElem.NodeHasNoData();
                                continue;
                            }
                        }
                        else if (tr.NodeType == XmlNodeType.Text || tr.NodeType == XmlNodeType.Whitespace)
                        {
                            hasText = true;
                            curNode.OnXmlData(tr.Value);
                        }
                        else if (tr.NodeType == XmlNodeType.EndElement)
                        {
                            if (tr.Name == rootTag)
                                continue;
                            if (notifyEvents != null && notifyEvents.ContainsKey(tr.Name))
                                notifyEvents[tr.Name]((Asn1Object)curNode);
                            if (!hasText)
                                curNode.NodeHasNoData();

                            hasText = false;

                            if (stackOfVisitedNodes.Count > 0)
                            {
                                stackOfVisitedNodes.RemoveAt(stackOfVisitedNodes.Count - 1);
                                if (stackOfVisitedNodes.Count > 0)
                                    curNode = stackOfVisitedNodes[stackOfVisitedNodes.Count - 1];
                                else
                                    throw new Xml2Asn1DecodeException("Unexpected error. Possibly end elements are missing from the XML file");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    IXmlLineInfo li = (IXmlLineInfo)tr;
                    throw new Exception(ex.Message + "\nLine: " + li.LineNumber + ", Col: " + li.LinePosition);
                }
            }
        }

        public virtual IOnXmlVisitNode OnChildElement(string tag, XmlReader tr)
        {
            throw new Exception("Node cannot have child elements");
        }
        public virtual void OnXmlAttribute(XmlReader tr)
        {
        }

        public virtual void OnXmlData(string data)
        {
        }
        public virtual void NodeHasNoData()
        {
        }


        bool HasFather(Type father)
        {
            Asn1Object par = Parent;
            while (par != null)
            {
                if (par.GetType() == father)
                    return true;
                par = par.Parent;
            }

            return false;
        }

    }





    public class Asn1NullObject : Asn1Object
    {

        public override uint DecodeContent(Stream strm, EncodingRules encRule, uint dataLen, bool indefiniteForm)
        {
            return 0;
        }
        public override uint EncodeContent(Stream strm, EncodingRules encRule)
        {
            return 0;
        }
        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, true, 5);
//            return Decode(strm, encRule, TagClass.UNIVERSAL, true, 5);

        }
        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, true, 5);
//            return Encode(strm, encRule, TagClass.UNIVERSAL, true, 5);
        }

        public override bool IsConstraintValid()
        {
            return true;
        }
        public override IEnumerable<Asn1Object> GetChildren(bool includeMyself)
        {
            if (includeMyself)
                yield return this;
        }


        public override void WriteXmlContent(XmlWriter o)
        {
            o.WriteString("NULL");
        }
    }

    public abstract class Asn1PrimitiveObject<T> : Asn1Object
    {
        public virtual T Value { get; set; }

        public virtual string ValueAsString
        {
            get
            {
                return Value.ToString();
            }
            set
            {
                throw new AbstractMethodCalledException();
            }
        }


        public override bool IsConstraintValid()
        {
            return true;
        }

        public override IEnumerable<Asn1Object> GetChildren(bool includeMyself)
        {
            if (includeMyself)
                yield return this;
        }

        public override void WriteXmlContent(XmlWriter o)
        {
            o.WriteString(ValueAsString);
        }

    }

    public class Asn1IntegerObject : Asn1PrimitiveObject<Int64>
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, true, 2);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, true, 2);
        }

        public override uint EncodeContent(Stream strm, EncodingRules encRule)
        {
            return BER.EncodeInteger(strm, Value);
        }


        public override uint DecodeContent(Stream strm, EncodingRules encRule, uint dataLen, bool indefiniteForm)
        {

            if (encRule == EncodingRules.CER || encRule == EncodingRules.DER)
                Value = BER.DecodeInteger(strm, dataLen);
            else
                throw new Exception("Unsupported encoding");

            return dataLen;
        }

        public override void OnXmlData(string data)
        {
            Value = long.Parse(data);
        }
        public override void NodeHasNoData()
        {
            throw new Xml2Asn1DecodeException("Missing value for integer field");
        }

    }

    public class Asn1RealObject : Asn1PrimitiveObject<double>
    {
        public override uint EncodeContent(Stream strm, EncodingRules encRule)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        public override uint DecodeContent(Stream strm, EncodingRules encRule, uint dataLen, bool indefiniteForm)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, true, 9);
        }
        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, true, 9);
        }
        public override void OnXmlData(string data)
        {
            Value = double.Parse(data);
        }
        public override void NodeHasNoData()
        {
            throw new Xml2Asn1DecodeException("Missing value for real field");
        }
    }

    public class Asn1BoolObject : Asn1PrimitiveObject<bool>
    {
        public override uint EncodeContent(Stream strm, EncodingRules encRule)
        {
            if (Value)
                strm.WriteByte(0xFF);
            else
                strm.WriteByte(0);
            
            return 1;
        }
        public override uint DecodeContent(Stream strm, EncodingRules encRule, uint dataLen, bool indefiniteForm)
        {
            int n = strm.ReadByte();
            if (n == -1)
                throw new UnexpectedEndOfStreamException();
            if (n == 0)
                Value = false;
            else
                Value = true;
            return 1;
        }
        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, true, 1);
//            return Decode(strm, encRule, TagClass.UNIVERSAL, true, 1);
        }
        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, true, 1);
//            return Encode(strm, encRule, TagClass.UNIVERSAL, true, 1);
        }
        public override void OnXmlData(string data)
        {
            Value = bool.Parse(data);
        }
        public override void NodeHasNoData()
        {
            throw new Xml2Asn1DecodeException("Missing value for boolean field");
        }
    }

    public class Asn1IA5StringObject : Asn1PrimitiveObject<string>
    {
        public Asn1IA5StringObject()  
        {
            Value = string.Empty;
        }

        public override uint DecodeContent(Stream strm, EncodingRules encRule, uint dataLen, bool indefiniteForm)
        {
            if (strm.Length - strm.Position < dataLen)
                throw new UnexpectedEndOfStreamException();

            byte[] _Data = new byte[dataLen];
            strm.Read(_Data, 0, (int)dataLen);


            //Value = ASCIIEncoding.ASCII.GetString(_Data);
            Value = Encoding.GetEncoding(0).GetString(_Data);

            return dataLen;
        }
        public override uint EncodeContent(Stream strm, EncodingRules encRule)
        {
            //Byte[] _Data = ASCIIEncoding.ASCII.GetBytes(Value);
            Byte[] _Data = Encoding.GetEncoding(0).GetBytes(Value);
            strm.Write(_Data, 0, _Data.Length);
            return (uint)_Data.Length;
        }
        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, true, 22);
//            return Decode(strm, encRule, TagClass.UNIVERSAL, true, 22);
        }
        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, true, 22);
//            return Encode(strm, encRule, TagClass.UNIVERSAL, true, 22);
        }
        public override void OnXmlData(string data)
        {
            Value = data;
        }
    }

    public class Asn1NumericStringObject : Asn1IA5StringObject
    {


        private string CharSet = " 0123456789";
        public override bool IsConstraintValid()
        {

            foreach (Char ch in Value.ToCharArray())
                if (!CharSet.Contains(ch.ToString()))
                    return false;
            return true;
        }
        public override uint Decode(Stream strm, EncodingRules encRule)
        {
//            return Decode(strm, encRule, TagClass.UNIVERSAL, true, 18);
            return Decode(strm, encRule, true, 18);
        }
        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, true, 18);
//            return Encode(strm, encRule, TagClass.UNIVERSAL, true, 18);
        }
    }

    public abstract class Asn1EnumeratedObject<T> : Asn1PrimitiveObject<T> 
    {
        protected abstract long ValueAsLong { get;}

        public override uint EncodeContent(Stream strm, EncodingRules encRule)
        {
            return BER.EncodeInteger(strm, ValueAsLong);
        }

        public override uint DecodeContent(Stream strm, EncodingRules encRule, uint dataLen, bool indefiniteForm)
        {
            long decodedVal = BER.DecodeInteger(strm, dataLen);
            Value = (T)Enum.ToObject(Value.GetType(), decodedVal);
            return dataLen;
        }
        public override uint Decode(Stream strm, EncodingRules encRule)
        {
//            return Decode(strm, encRule, TagClass.UNIVERSAL, true, 10);
            return Decode(strm, encRule, true, 10);
        }
        public override uint Encode(Stream strm, EncodingRules encRule)
        {
//            return Encode(strm, encRule, TagClass.UNIVERSAL, true, 10);
            return Encode(strm, encRule, true, 10);
        }
        public override void OnXmlData(string data)
        {
            Value = (T)Enum.ToObject(Value.GetType(), long.Parse(data));
        }
    }

    public class Asn1OctetStringObject : Asn1PrimitiveObject<List<byte>>/*Asn1Object*/
    {


        public Asn1OctetStringObject()
        {
            Value = new List<byte>();
        }

        public override string ValueAsString
        {
            get
            {
                string tmp = string.Empty;

                foreach (byte b in Value)
                    tmp += b.ToString("X2");
                return tmp;
            }
            set
            {
                base.ValueAsString = value;
            }
        }

        //public override void ToXml(StreamWriterLevel o, string tag, int l)
        //{
        //    o.P(l);
        //    o.WriteLine("<{0}>{1}</{0}>", tag,ValueAsString);

        //}


        public override uint Encode(Stream strm, EncodingRules encRule, bool primitive, uint tag)
        {
            long sPos = strm.Position;
            BER.EncodeTagAsInt(strm, tag, primitive);
            BER.EncodeLengthDF(strm, (uint)Value.Count);
            EncodeContent(strm, encRule);

            return (uint)(strm.Position - sPos);
        }
        public override uint DecodeContent(Stream strm, EncodingRules encRule, uint dataLen, bool indefiniteForm)
        {
            if (strm.Length - strm.Position < dataLen)
                throw new UnexpectedEndOfStreamException();


            byte[] _Data = new byte[dataLen];
            strm.Read(_Data, 0, (int)dataLen);

            Value.Clear();
            Value.AddRange(_Data);

            return dataLen;
        }
        public override uint EncodeContent(Stream strm, EncodingRules encRule)
        {
            byte[] _Data = Value.ToArray();
            strm.Write(_Data, 0, _Data.Length);
            return (uint)_Data.Length;
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, true, 4);
        }
        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, true, 4);
        }
     
        public override bool IsConstraintValid()
        {
            return true;
        }
        public override IEnumerable<Asn1Object> GetChildren(bool includeMyself)
        {
            if (includeMyself)
                yield return this;
        }
        public override void OnXmlData(string data)
        {

            string dat = data;
            if (data.Length % 2 == 1)
                dat = "0" + data;

            for (int i = 0; i < dat.Length ; i += 2)
                Value.Add(byte.Parse(dat.Substring(i, 2), System.Globalization.NumberStyles.HexNumber));



        }
    }

    public class Asn1BitStringObject : Asn1PrimitiveObject<System.Collections.BitArray>
    {
        public Asn1BitStringObject()
        {
            Value = new System.Collections.BitArray(0);
        }

        public override uint DecodeContent(Stream strm, EncodingRules encRule, uint dataLen, bool indefiniteForm)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        
        public override uint EncodeContent(Stream strm, EncodingRules encRule)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        
        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, true, 8);
        }
        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, true, 8);
        }

        public override bool IsConstraintValid()
        {
            return true;
        }
        public override IEnumerable<Asn1Object> GetChildren(bool includeMyself)
        {
            if (includeMyself)
                yield return this;
        }
    }



    public abstract class Asn1ArrayObject<T> : Asn1Object where T : Asn1Object
    {
        public List<T> m_children = new List<T>(5);

        protected abstract List<UInt32> ChildTags { get;}

        protected abstract Func<T> CreateEmptyChild { get;}

        public event Action<T> childAdded = null;

        public T AppendNewChild()
        {
            T ret = CreateEmptyChild();
            m_children.Add(ret);
            ret.Parent = this;
            if (childAdded != null)
                childAdded(ret);
            return ret;
        }


        public T this[int indx] { get { return m_children[indx]; } set { m_children[indx] = value; } }


        public override bool IsPrimitive { get { return false; } }


        public override uint DecodeContent(Stream strm, EncodingRules encRule, uint dataLen, bool indefiniteForm)
        {
            uint decodedData = 0;

            if (encRule == EncodingRules.CER || encRule == EncodingRules.DER)
            {

                Func<bool> cont = delegate()
                {
                    if (!indefiniteForm)
                        return decodedData < dataLen;
                    else
                        return !BER.AreNextTwoBytesZeros(strm);
                };

                while (cont())
                {
                    T ch = AppendNewChild();
                    decodedData += ch.Decode(strm, encRule);
                }

            }
            else
                throw new ArgumentException("Unimplemented encoding rule");

            return decodedData;

        }
        public override uint EncodeContent(Stream strm, EncodingRules encRule)
        {
            uint ret = 0;
            if (encRule == EncodingRules.CER || encRule == EncodingRules.DER)
            {

                //encode children
                foreach (T ch in m_children)
                    ret += ch.Encode(strm, encRule);

            }
            else
                throw new ArgumentException("Unimplemented encoding rule");

            return ret;
        }
        
        public override bool IsConstraintValid()
        {
            foreach (T ch in m_children)
                if (!ch.IsConstraintValid())
                    return false;
            return true;
        }
        public override IEnumerable<Asn1Object> GetChildren(bool includeMyself)
        {
            if (includeMyself)
                yield return this;

            foreach (Asn1Object ch in m_children)
                foreach (Asn1Object gch in ch.GetChildren(true))
                    yield return gch;
        }


        string _internalTypeName = null;
        protected string InternalTypeName
        {
            get
            {
                if (_internalTypeName == null)
                    _internalTypeName = typeof(T).Name;
                return _internalTypeName;
            }
        }

        //public override void ToXml(XmlWriter o, string tag, int l, string attrs)
        //{
        //    o.P(l);
        //    if (attrs != "")
        //        attrs = ' ' + attrs;
        //    o.WriteLine("<{0}{1}>", tag, attrs);


        //    foreach (Asn1Object ch in m_children)
        //    {
        //        ch.ToXml(o, InternalTypeName,l+1,"");
        //    }
        //    o.P(l);
        //    o.WriteLine("</{0}>", tag);
        //}

        public override void WriteXmlContent(XmlWriter o)
        {
            foreach (Asn1Object ch in m_children)
            {
                ch.ToXml(o, InternalTypeName);
            }
        }


        public override IOnXmlVisitNode OnChildElement(string tag, XmlReader tr)
        {
            if (InternalTypeName != tag)
                throw new Xml2Asn1DecodeException("Node {0} cannot contain elements of type {1}.", GetType().Name, tag);

            Asn1Object ret = AppendNewChild();
            ret.OnXmlAttribute(tr);
            return ret;
        }

    }

    public abstract class Asn1SequenceOfObject<T> : Asn1ArrayObject<T> where T : Asn1Object
    {
        public override uint Decode(Stream strm, EncodingRules encRule)
        {
//            return Decode(strm, encRule, TagClass.UNIVERSAL, false, 16);
            return Decode(strm, encRule, false, 16);
        }
        public override uint Encode(Stream strm, EncodingRules encRule)
        {
//            return Encode(strm, encRule, TagClass.UNIVERSAL, false, 16);
            return Encode(strm, encRule, false, 16);
        }
    }

    public abstract class Asn1SetOfObject<T> : Asn1ArrayObject<T> where T : Asn1Object
    {
        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, false, 17);
//            return Decode(strm, encRule, TagClass.UNIVERSAL, false, 17);
        }
        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, false, 17);
//            return Encode(strm, encRule, TagClass.UNIVERSAL, false, 17);
        }
    }


    public class Child<T>
    {
//        public Tag m_Tag = null;

//        public List<Tag> m_childrenTags = null; // This is used only in case where child is an untagged choice
        public Func<T> createObj = null;

        //public void SetChildrenTagList(params Tag[] tagList)
        //{
        //    m_childrenTags = new List<Tag>(tagList);
        //}
        
        public Child()
        {
        }

        public Child(Func<T> CreateObj)
        {
            createObj = CreateObj;
        }

        //bool _untaggedChoice=false;
        //public bool UnTaggedChoice
        //{
        //    get { return _untaggedChoice; }
        //    set { _untaggedChoice = value; }
        //}

    }


    public class NamedChild : Child<Asn1Object>
    {
        public string m_name = string.Empty;
//        public Asn1Object m_asn1Object = null;
        public int m_index;


        public NamedChild(string name, int idx, Func<Asn1Object> CreateObj)
            : base(CreateObj)
        {
            m_name = name;
            m_index = idx;
        }
    }

    public class OptionalNamedChild : NamedChild
    {
        public bool m_isOptional = false;
        public string m_defaultValue = null;
        public OptionalNamedChild(string name, int idx, Func<Asn1Object> CreateObj)
            : base(name, idx, CreateObj) { }

        public OptionalNamedChild(string name, int idx, Func<Asn1Object> CreateObj, bool optional, string defValue)
            : base(name, idx, CreateObj) 
        {
            m_isOptional = optional;
            m_defaultValue = defValue;
        }


    }


    public abstract class Asn1CompositeObject<T> : Asn1Object where T : NamedChild
    {

        public override bool IsPrimitive { get { return false; } }

        


        public abstract Asn1CompositeClass<T> ClassDef { get;}


//        public OrderedDictionary<string, T> m_children = new OrderedDictionary<string, T>();
//        public List<Asn1Object> m_children = new List<Asn1Object>();
        public Asn1Object[] m_children = null;




        public override IEnumerable<Asn1Object> GetChildren(bool includeMyself)
        {
            if (includeMyself)
                yield return this;
            //foreach (T ch in m_children.Values)
            //    foreach (Asn1Object grCh in ch.m_asn1Object.GetChildren(true))
            //        yield return grCh;
        }

        public override bool IsConstraintValid()
        {
            foreach (Asn1Object ch in m_children)
                if (ch != null && !ch.IsConstraintValid())
                    return false;

            return true;
        }

        public virtual Asn1Object CreateChild(string childName)
        {
            if (!ClassDef.m_children.ContainsKey(childName))
            {
                throw new Xml2Asn1DecodeException("Node {0} cannot contain elements of type {1}.", GetType().Name, childName);
            }

            NamedChild ch = ClassDef.m_children[childName];
            m_children[ch.m_index] = ch.createObj();
            m_children[ch.m_index].Parent = this;
            return m_children[ch.m_index];
        }

        //public override void ToXml(XmlWriter o, string tag, int l, string attrs)
        //{
        //    o.P(l);
        //    if (attrs != "")
        //        attrs = ' ' + attrs;
        //    o.WriteLine("<{0}{1}>", tag, attrs);
        //    foreach (NamedChild ch in ClassDef.m_children.Values)
        //    {
        //        if (m_children[ch.m_index]!=null)
        //            m_children[ch.m_index].ToXml(o, ch.m_name,l+1,"");
        //    }
        //    o.P(l);
        //    o.WriteLine("</{0}>", tag);
        //}

        public override void WriteXmlContent(XmlWriter o)
        {
            foreach (NamedChild ch in ClassDef.m_children.Values)
            {
                if (m_children[ch.m_index] != null)
                    m_children[ch.m_index].ToXml(o, ch.m_name);
            }
        }

        public override IOnXmlVisitNode OnChildElement(string tag, XmlReader tr)
        {
            Asn1Object ret = CreateChild(tag);
            ret.OnXmlAttribute(tr);
            return ret;
        }

    }


    public abstract class Asn1SequenceOrSetObject : Asn1CompositeObject<OptionalNamedChild>
    {

        public override bool IsConstraintValid()
        {
            //foreach (OptionalNamedChild ch in m_children.Values)
            //    if (ch.m_asn1Object==null && (!ch.m_isOptional || ch.m_defaultValue!=null))
            //        return false;
            return base.IsConstraintValid();
        }
        public override uint EncodeContent(Stream strm, EncodingRules encRule)
        {
            long sPos = strm.Position;
            if (encRule == EncodingRules.CER || encRule == EncodingRules.DER)
            {

                //encode children
                foreach (Asn1Object ch in m_children)
                    if (ch != null)
                    {
                        ch.Encode(strm, encRule);
                    }


                return (uint)(strm.Position - sPos);
            }
            throw new Exception();
        }

        
        public override uint DecodeContent(Stream strm, EncodingRules encRule, uint dataLen, bool indefiniteForm)
        {
            if (encRule == EncodingRules.CER || encRule == EncodingRules.DER)
            {
                uint decodedData = 0;
                UInt32 nextTag = UInt32.MaxValue;

                Func<bool, bool> terminateCond = delegate(bool indFrm)
                {
                    if (!indFrm)    //i.e. definite form
                        return (decodedData < dataLen);
                    else
                        return !BER.AreNextTwoBytesZeros(strm);
                };

                while (terminateCond(indefiniteForm))
                {
                    BER.GetNextTag(strm, out nextTag);
                    OptionalNamedChild childClass = ClassDef.getChildByTag2(nextTag);

                    m_children[childClass.m_index] = childClass.createObj();
                    m_children[childClass.m_index].Parent = this;
                    decodedData += m_children[childClass.m_index].Decode(strm, encRule);
                }

                return decodedData;

            }
            throw new Exception();
        }


    }




    public abstract class Asn1SequenceObject : Asn1SequenceOrSetObject
    {
        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, false, 16);
//            return Decode(strm, encRule, TagClass.UNIVERSAL, false, 16);
        }
        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, false, 16);
//            return Encode(strm, encRule, TagClass.UNIVERSAL, false, 16);
        }
    }


    public abstract class Asn1SetObject : Asn1SequenceOrSetObject
    {
        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, false, 17);
//            return Decode(strm, encRule, TagClass.UNIVERSAL, false, 17);
        }
        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, false, 17);
//            return Encode(strm, encRule, TagClass.UNIVERSAL, false, 17);
        }

    }

    public abstract class Asn1ChoiceObject : Asn1CompositeObject<NamedChild>
    {
        public Asn1ChoiceObject() : base() { }


        public override uint DecodeContent(Stream strm, EncodingRules encRule, uint dataLen, bool indefiniteForm)
        {
            if (encRule == EncodingRules.CER || encRule == EncodingRules.DER)
            {

                uint ret = 0;
                UInt32 nextTag = UInt32.MaxValue;

                Func<bool> ifCond = delegate()
                {
                    if (!indefiniteForm)    //i.e. definite form
                        return dataLen>0;
                    else
                        return !BER.AreNextTwoBytesZeros(strm);
                };

                

                if (ifCond())
                {
                    BER.GetNextTag(strm, out nextTag);
                    NamedChild childClass = ClassDef.getChildByTag2(nextTag);
                    m_children[childClass.m_index] = childClass.createObj();
                    m_children[childClass.m_index].Parent = this;
                    m_AlternativeName = childClass.m_name;
                    ret += m_children[childClass.m_index].Decode(strm, encRule);
                }

                return ret;
            }
            else
                throw new ArgumentException("Unimplemented encoding rule");
        }

        public override uint EncodeContent(Stream strm, EncodingRules encRule)
        {
            if (encRule == EncodingRules.CER || encRule == EncodingRules.DER)
            {
                if (m_AlternativeName == string.Empty || m_Alternative == null)
                    return 0;
//                    throw new EmptyChoiceException();
                return m_Alternative.Encode(strm, encRule);
            }
            else
                throw new ArgumentException("Unimplemented encoding rule");
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return DecodeContent(strm, encRule, uint.MaxValue, false);
        }
        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return EncodeContent(strm, encRule);
        }


        private string choiceAlternative = string.Empty;

        public string m_AlternativeName
        {
            get { return choiceAlternative; }
            set
            {
                if (ClassDef.m_children.ContainsKey(value))
                    choiceAlternative = value;
                else
                    throw new Xml2Asn1DecodeException("Node {0} cannot contain elements of type {1}.", GetType().Name, value);
            }
        }

        public Asn1Object m_Alternative
        {
            get
            {
                foreach (Asn1Object ch in m_children)
                    if (ch != null)
                        return ch;
                return null;
            }
        }

        public override bool IsConstraintValid()
        {
            return base.IsConstraintValid() && m_AlternativeName != string.Empty;
        }

        public override Asn1Object CreateChild(string childName)
        {
            for (int i = 0; i < m_children.Length; i++)
                m_children[i] = null;
            m_AlternativeName = childName;
            return base.CreateChild(childName);
        }
    }


#if fff  

    // The difference with the normal dictionary is that
    // the Values property retains order (as inserted)
    public class OrderedDictionary<TKey, TValue>    
    {
        Dictionary<TKey, TValue> m_keyval = new Dictionary<TKey, TValue>();
        List<TValue> m_values = new List<TValue>();
        List<TKey> m_keys = new List<TKey>();

        public void Add(TKey key, TValue value)
        {
            m_keyval.Add(key, value);
            m_values.Add(value);
            m_keys.Add(key);
        }
        public void Clear()
        {
            m_keys.Clear();
            m_keyval.Clear();
            m_values.Clear();
        }
        public TValue this[TKey key]
        {
            get
            {
                return m_keyval[key];
            }
            set
            {

                m_keyval[key] = value;
                m_values[m_keys.IndexOf(key)] = value;
            }
        }

        public bool ContainsKey(TKey key)
        {
            return m_keyval.ContainsKey(key);
        }



        public List<TValue> Values
        {
            get { return m_values; }
        }
        public List<TKey> Keys
        {
            get { return m_keys; }
        }
        public int Count { get { return m_values.Count; } }

        public override int GetHashCode()
        {
            return m_keyval.GetHashCode();
        }

        

    }

#endif
}

