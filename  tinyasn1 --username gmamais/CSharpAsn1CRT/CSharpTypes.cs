using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

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


    public delegate TResult Func<TResult>();
    public delegate TResult Func<TResult, T>();
    
    public abstract class Asn1Object
    {

        

        public abstract uint Decode(Stream strm, EncodingRules encRule);
        public abstract uint Encode(Stream strm, EncodingRules encRule);
        //Encodes only the content, not tag and length
        //return the length of bytes encoded
        public abstract uint EncodeContent(Stream strm, EncodingRules encRule);
        //Decodes only the content, not tag and length
        //returns the length of bytes decoded
        public abstract uint DecodeContent(Stream strm, EncodingRules encRule, uint dataLen);
        public abstract bool IsConstraintValid();

        public abstract IEnumerable<Asn1Object> GetChildren(bool includeMyself);
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
            BER.DecodeLength(strm, out length);
            long sPos = strm.Position;

            DecodeContent(strm, encRule, length);

            long decodedData = strm.Position - sPos;

            if (length != 0 && decodedData != length)
                throw new LengthMismatchException();
            else if (length == 0 && decodedData > 0)
                BER.DecodeTwoZeros(strm); // throws LengthMismatchException if no two zeros found



            return (uint)(strm.Position - initPos);

        }


    }


    public class Asn1NullObject : Asn1Object
    {

        public override uint DecodeContent(Stream strm, EncodingRules encRule, uint dataLen)
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
    }

    public abstract class Asn1PrimitiveObject<T> : Asn1Object
    {
        public T Value;



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



    public class Asn1IntegerObject : Asn1PrimitiveObject<Int64>
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, true, 2);
//            return Encode(strm, encRule, TagClass.UNIVERSAL, true, 2);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, true, 2);
//            return Decode(strm, encRule, TagClass.UNIVERSAL, true, 2);
        }

        public override uint EncodeContent(Stream strm, EncodingRules encRule)
        {
//            if (encRule == EncodingRules.CER || encRule == EncodingRules.DER)
                return BER.EncodeInteger(strm, Value);

            throw new Exception("Unsupported encoding");
        }


        public override uint DecodeContent(Stream strm, EncodingRules encRule, uint dataLen)
        {

            if (encRule == EncodingRules.CER || encRule == EncodingRules.DER)
                Value = BER.DecodeInteger(strm, dataLen);
            else
                throw new Exception("Unsupported encoding");

            return dataLen;
        }

    }

    public class Asn1RealObject : Asn1PrimitiveObject<double>
    {
        public override uint EncodeContent(Stream strm, EncodingRules encRule)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        public override uint DecodeContent(Stream strm, EncodingRules encRule, uint dataLen)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, true, 9);
//            return Decode(strm, encRule, TagClass.UNIVERSAL, true, 9);
        }
        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, true, 9);
//            return Encode(strm, encRule, TagClass.UNIVERSAL, true, 9);
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
        public override uint DecodeContent(Stream strm, EncodingRules encRule, uint dataLen)
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
    }

    public class Asn1IA5StringObject : Asn1PrimitiveObject<string>
    {
        public Asn1IA5StringObject()  
        {
            Value = string.Empty;
        }

        public override uint DecodeContent(Stream strm, EncodingRules encRule, uint dataLen)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        public override uint EncodeContent(Stream strm, EncodingRules encRule)
        {
            throw new Exception("The method or operation is not implemented.");
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

        public override uint DecodeContent(Stream strm, EncodingRules encRule, uint dataLen)
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
    }

    public class Asn1OctetStringObject : Asn1Object
    {
//        public List<byte> m_Data = new List<byte>(10);

        byte[] _Data = null;

        //public List<byte> m_Data
        //{
        //    get
        //    {

        //    }
        //}


        public override uint Encode(Stream strm, EncodingRules encRule, bool primitive, uint tag)
        {
            long sPos = strm.Position;
            BER.EncodeTagAsInt(strm, tag, primitive);
            BER.EncodeLengthDF(strm, (uint)_Data.Length);
            EncodeContent(strm, encRule);

            return (uint)(strm.Position - sPos);
        }
        public override uint DecodeContent(Stream strm, EncodingRules encRule, uint dataLen)
        {
            if (strm.Length - strm.Position < dataLen)
                throw new UnexpectedEndOfStreamException();

            //byte[] tmp = new byte[dataLen];
            //strm.Read(tmp, 0, (int)dataLen);
            //m_Data = new List<byte>(tmp);

            _Data = new byte[dataLen];
            strm.Read(_Data, 0, (int)dataLen);

            //if (m_Data.Capacity < dataLen)
            //    m_Data.Capacity = (int)dataLen;


            



            //for (int i = 0; i < dataLen; i++)
            //{
            //    int nval = strm.ReadByte();
            //    //if (nval < 0)
            //    //    throw new UnexpectedEndOfStreamException();
            //    m_Data.Add((byte)nval);
            //}
            return dataLen;
        }
        public override uint EncodeContent(Stream strm, EncodingRules encRule)
        {
            strm.Write(_Data, 0, _Data.Length);
            return (uint)_Data.Length;
            //strm.Write(m_Data.ToArray(), 0, m_Data.Count);
            //return (uint)m_Data.Count;
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, true, 4);
//            return Decode(strm, encRule, TagClass.UNIVERSAL, true, 4);
        }
        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, true, 4);
//            return Encode(strm, encRule, TagClass.UNIVERSAL, true, 4);
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

    public class Asn1BitStringObject : Asn1Object
    {
        public System.Collections.BitArray m_Data = new System.Collections.BitArray(0);

        public override uint DecodeContent(Stream strm, EncodingRules encRule, uint dataLen)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        
        public override uint EncodeContent(Stream strm, EncodingRules encRule)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        
        public override uint Decode(Stream strm, EncodingRules encRule)
        {
//            return Decode(strm, encRule, TagClass.UNIVERSAL, true, 8);
            return Decode(strm, encRule, true, 8);
        }
        public override uint Encode(Stream strm, EncodingRules encRule)
        {
//            return Encode(strm, encRule, TagClass.UNIVERSAL, true, 8);
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
        public T AppendNewChild()
        {
//            T ret = new T();
            T ret = CreateEmptyChild();
            m_children.Add(ret);
            return ret;
        }


        public override bool IsPrimitive { get { return false; } }


        public override uint DecodeContent(Stream strm, EncodingRules encRule, uint dataLen)
        {
            long decodedData = 0;
            if (encRule == EncodingRules.CER || encRule == EncodingRules.DER)
            {

                //Decode Length
                uint length = dataLen;
                long curStrPos = strm.Position;
                //Decode content (i.e. children)

                UInt32 nextTag = UInt32.MaxValue;
                while (BER.GetNextTag(strm, out nextTag))   //on end of file or ZERO tag return 0
//                    while (true)
                {
                    
                    decodedData = strm.Position - curStrPos;
                    if (length == 0)
                    {
                        if (!ChildTags.Contains(nextTag) || BER.AreNextTwoBytesZeros(strm))
                            break;
                        
                    } 
                    else if (length > 0 && decodedData >= length)
                    {
                        if (decodedData == length)
                            break;
                        throw new LengthMismatchException();
                    }

                    T ch = AppendNewChild();
                    ch.Decode(strm, encRule);

                    //if (m_children.Count > 1000)
                    //    if (m_children.Count % 1000 == 0)
                    //        Console.WriteLine(m_children.Count);



                    // in SET OF we must check for unique values
                }
            }
            else
                throw new ArgumentException("Unimplemented encoding rule");

            return (uint)decodedData;

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
            NamedChild ch = ClassDef.m_children[childName];
            m_children[ch.m_index] = ch.createObj();

            return m_children[ch.m_index];
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

        
        //public override uint DecodeContent(Stream strm, EncodingRules encRule, uint dataLen)
        //{
        //    if (encRule == EncodingRules.CER || encRule == EncodingRules.DER)
        //    {
        //        uint ret = 0;
        //        Tag nextTag = null;
        //        while (BER.GetNextTag(strm, out nextTag))
        //        {
        //            OptionalNamedChild childClass = ClassDef.getChildByTag(nextTag);
        //            if (childClass == null)
        //                break;
        //            m_children[childClass.m_index] = childClass.createObj();
        //            ret += m_children[childClass.m_index].Decode(strm, encRule);
        //            if (dataLen == ret)
        //                return ret;
        //            if (ret > dataLen)
        //                throw new LengthMismatchException();
        //        }


        //        return ret;
        //    }
        //    throw new Exception();
        //}
        public override uint DecodeContent(Stream strm, EncodingRules encRule, uint dataLen)
        {
            if (encRule == EncodingRules.CER || encRule == EncodingRules.DER)
            {
                uint ret = 0;
                UInt32 nextTag = UInt32.MaxValue;

                long pos1 = strm.Position;
                if (dataLen > 0)
                {
                    while ( BER.GetNextTag(strm, out nextTag) )   //on end of file or ZERO tag return 0
                    {
                        OptionalNamedChild childClass = ClassDef.getChildByTag2(nextTag);

                        m_children[childClass.m_index] = childClass.createObj();
                        ret += m_children[childClass.m_index].Decode(strm, encRule);
                        
                        if (dataLen == ret)
                            return ret;
                        if (ret > dataLen)
                            throw new LengthMismatchException();
                    }
                }
                else
                {
                    while ( BER.GetNextTag(strm, out nextTag))   //return false on end of file or on ZERO tag
                    {
                        OptionalNamedChild childClass = ClassDef.getChildByTag2(nextTag);
                        m_children[childClass.m_index] = childClass.createObj();
                        ret += m_children[childClass.m_index].Decode(strm, encRule);

                    }
                }


                //while (BER.GetNextTag(strm, out nextTag))   //return false on end of file or on ZERO tag
                //{
                //    OptionalNamedChild childClass = ClassDef.getChildByTag2(nextTag);

                //    m_children[childClass.m_index] = childClass.createObj();
                //    ret += m_children[childClass.m_index].Decode(strm, encRule);
                //    if (dataLen == ret && dataLen!=0)
                //        return ret;
                //    if (ret > dataLen && dataLen!=0)
                //        throw new LengthMismatchException();
                //}


                return ret;
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

        //public override uint DecodeContent(Stream strm, EncodingRules encRule, uint dataLen)
        //{
        //    if (encRule == EncodingRules.CER || encRule == EncodingRules.DER)
        //    {

        //        uint ret = 0;
        //        Tag nextTag = null;
        //        if (BER.GetNextTag(strm, out nextTag))
        //        {
        //            NamedChild childClass = ClassDef.getChildByTag(nextTag);
        //            m_children[childClass.m_index] = childClass.createObj();
        //            m_AlternativeName = childClass.m_name;
        //            ret += m_children[childClass.m_index].Decode(strm, encRule);
        //        }
                
        //        return ret;
        //    }
        //    else
        //        throw new ArgumentException("Unimplemented encoding rule");
        //}

        public override uint DecodeContent(Stream strm, EncodingRules encRule, uint dataLen)
        {
            if (encRule == EncodingRules.CER || encRule == EncodingRules.DER)
            {

                uint ret = 0;
                UInt32 nextTag = UInt32.MaxValue;
                if ( BER.GetNextTag(strm, out nextTag))
                {
                    NamedChild childClass = ClassDef.getChildByTag2(nextTag);
                    m_children[childClass.m_index] = childClass.createObj();
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
                    throw new EmptyChoiceException();
                return m_Alternative.Encode(strm, encRule);
            }
            else
                throw new ArgumentException("Unimplemented encoding rule");
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return DecodeContent(strm, encRule, uint.MaxValue);
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
                    throw new ArgumentNullException();
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


}

