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

        public Tag() { }
        public Tag(uint tagNo, TagClass tgClass)
        {
            m_tagNo = tagNo;
            m_tgClass = tgClass;
        }
        
        public bool Equals(Tag o)
        {
            //Tag o = obj as Tag;
            //if (o == null)
            //    return false;
            return o.m_tagNo == m_tagNo && o.m_tgClass == m_tgClass;
        }

    }

    public delegate Asn1Object CreateAsn1Object();

    public delegate TResult Func<TResult>();
    public delegate TResult Func<T, TResult>(T arg);
    
    public abstract class Asn1Object
    {
        public List<Tag> m_Tags = new List<Tag>();

        public abstract void Encode(Stream strm, EncodingRules encRule);
        public abstract void Decode(Stream strm, EncodingRules encRule);
        public abstract bool IsConstraintValid();
        public abstract IEnumerable<Asn1Object> GetChildren(bool includeMyself);

        public static bool MatchTags(Stream strm, Tag[] Tags)
        {
            long strPos = strm.Position;

            foreach (Tag t in Tags)
                if (!t.Equals(BER.DecodeTag(strm)))
                {
                    strm.Position = strPos;
                    return false;
                }

            strm.Position = strPos;
            return true;
        }

        public void DecodeTags(Stream strm)
        {
            long strPos = strm.Position;

            foreach (Tag t in m_Tags)
            {
                if (!t.Equals(BER.DecodeTag(strm)))
                {
                    strm.Position = strPos;
                    throw new UnexpectedTagException();
                }
            }

        }
       
    }


    public class Asn1NullObject : Asn1Object
    {
        public Asn1NullObject() { m_Tags.Add(new Tag(5, TagClass.UNIVERSAL)); }


        public override void Decode(Stream strm, EncodingRules encRule)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        public override void Encode(Stream strm, EncodingRules encRule)
        {
            throw new Exception("The method or operation is not implemented.");
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

        public List<Func<T, bool>> m_constraints = new List<Func<T, bool>>();


        public override bool IsConstraintValid()
        {
            foreach (Func<T, bool> f in m_constraints)
                if (!f(Value))
                    return false;

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

        public Asn1IntegerObject() { m_Tags.Add(new Tag(2, TagClass.UNIVERSAL)); }

        public override void Encode(Stream strm, EncodingRules encRule)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        public override void Decode(Stream strm, EncodingRules encRule)
        {
            throw new Exception("The method or operation is not implemented.");
        }

    }

    public class Asn1RealObject : Asn1PrimitiveObject<double>
    {
        public Asn1RealObject() { m_Tags.Add(new Tag(9, TagClass.UNIVERSAL)); }

        public override void Encode(Stream strm, EncodingRules encRule)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        public override void Decode(Stream strm, EncodingRules encRule)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }

    public class Asn1BoolObject : Asn1PrimitiveObject<bool>
    {
        public Asn1BoolObject() { m_Tags.Add(new Tag(1, TagClass.UNIVERSAL)); }

        public override void Encode(Stream strm, EncodingRules encRule)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        public override void Decode(Stream strm, EncodingRules encRule)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }

    public class Asn1IA5StringObject : Asn1PrimitiveObject<string>
    {
        public Asn1IA5StringObject()  
        {
            m_Tags.Add(new Tag(22, TagClass.UNIVERSAL));
            Value = string.Empty;
        }

        public override void Decode(Stream strm, EncodingRules encRule)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        public override void Encode(Stream strm, EncodingRules encRule)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }

    public class Asn1NumericStringObject : Asn1IA5StringObject
    {

        public Asn1NumericStringObject() { m_Tags.Add(new Tag(18, TagClass.UNIVERSAL)); }

        private string CharSet = " 0123456789";
        public override bool IsConstraintValid()
        {

            foreach (Char ch in Value.ToCharArray())
                if (!CharSet.Contains(ch.ToString()))
                    return false;
            return true;
        }
    }

    public abstract class Asn1EnumeratedObject<T> : Asn1PrimitiveObject<T>
    {
        public Asn1EnumeratedObject()  { m_Tags.Add(new Tag(10, TagClass.UNIVERSAL));}

        //public enum dd
        //{
        //    a = 4,
        //    f =5,
        //}

        public override void Encode(Stream strm, EncodingRules encRule)
        {
//            Int32 val = (Int32)Value;
            throw new Exception("The method or operation is not implemented.");
        }

        public override void Decode(Stream strm, EncodingRules encRule)
        {
            //int decodedVal = 45;
            //Value = (T)Enum.ToObject(Value.GetType(), decodedVal);
            throw new Exception("The method or operation is not implemented.");
        }
    }



    public class Asn1OctetStringObject : Asn1Object
    {
        public List<byte> m_Data = new List<byte>();

        public List<Func<List<byte>, bool>> m_constraints = new List<Func<List<byte>, bool>>();

        public Asn1OctetStringObject() { m_Tags.Add(new Tag(4, TagClass.UNIVERSAL)); }

        public override void Decode(Stream strm, EncodingRules encRule)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        public override void Encode(Stream strm, EncodingRules encRule)
        {
            throw new Exception("The method or operation is not implemented.");
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
        public Asn1BitStringObject() { m_Tags.Add(new Tag(3, TagClass.UNIVERSAL)); }
        public List<Func<List<byte>, bool>> m_constraints = new List<Func<List<byte>, bool>>();

        public System.Collections.BitArray m_Data = new System.Collections.BitArray(0);
        public override void Decode(Stream strm, EncodingRules encRule)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        public override void Encode(Stream strm, EncodingRules encRule)
        {
            throw new Exception("The method or operation is not implemented.");
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
        public List<Func<Asn1ArrayObject<T>, bool>> m_constraints = new List<Func<Asn1ArrayObject<T>, bool>>();

        public Child<T> m_child = new Child<T>();

        public List<T> m_children = new List<T>();

        public T AppendNewChild()
        {
            T ret = m_child.createObj();
            m_children.Add(ret);
            return ret;
        }

        public override void Decode(Stream strm, EncodingRules encRule)
        {
            if (encRule == EncodingRules.CER || encRule == EncodingRules.DER)
            {
                DecodeTags(strm);

                //Decode Length
                uint length = 0;
                BER.DecodeLength(strm, out length);
                long curStrPos = strm.Position;
                long decodedData = 0;
                //Decode content (i.e. children)

                while (true)
                {
                    decodedData = strm.Position - curStrPos;
                    if (length == 0 && BER.AreNextTwoBytesZeros(strm))
                        break;
                    else if (length > 0 && decodedData >= length)
                        break;
                    T ch = m_child.createObj();
                    ch.Decode(strm, encRule);
                    // in SET OF we must check for unique values
                    m_children.Add(ch);
                }


                if (length == 0)
                    BER.DecodeTwoZeros(strm);
                else
                {
                    if (decodedData != length)
                        throw new LengthMismatchException();
                }
            }
            else
                throw new ArgumentException("Unimplemented encoding rule");
        }
        public override void Encode(Stream strm, EncodingRules encRule)
        {
            if (encRule == EncodingRules.CER || encRule == EncodingRules.DER)
            {
                //encode Tag
                foreach (Tag t in m_Tags)
                    BER.EncodeTag(strm, t.m_tgClass, false, t.m_tagNo);

                //encode Length
                strm.WriteByte(0x80);

                //encode children
                foreach (T ch in m_children)
                    ch.Encode(strm, encRule);

                //encode end-of-contents
                strm.WriteByte(0x0);
                strm.WriteByte(0x0);

            }
            else
                throw new ArgumentException("Unimplemented encoding rule");
        }
        
        public override bool IsConstraintValid()
        {
            foreach (Func<Asn1ArrayObject<T>, bool> f in m_constraints)
                if (!f(this))
                    return false;

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

    public class Asn1SequenceOfObject<T> : Asn1ArrayObject<T> where T : Asn1Object
    {
        public Asn1SequenceOfObject() { m_Tags.Add(new Tag(16, TagClass.UNIVERSAL)); }
    }

    public class Asn1SetOfObject<T> : Asn1ArrayObject<T> where T : Asn1Object
    {
        public Asn1SetOfObject() { m_Tags.Add(new Tag(17, TagClass.UNIVERSAL)); }
    }


    public class Child<T>
    {
        public List<List<Tag>> m_TagLists = null;
        public Func<T> createObj = null;

        public void AddTagList(params Tag[] tagList)
        {
            m_TagLists.Add(new List<Tag>(tagList));
        }
        
        public Child()
        {
        }

        public Child(Func<T> CreateObj)
        {
            createObj = CreateObj;
        }
    }


    public class NamedChild : Child<Asn1Object>
    {
        public string m_name = string.Empty;
        public Asn1Object m_asn1Object = null;


        public NamedChild(string name, Asn1Object asn1Obj, Func<Asn1Object> CreateObj)
            : base(CreateObj)
        {
            m_name = name;
            m_asn1Object = asn1Obj;
        }
    }

    public class OptionalNamedChild : NamedChild
    {
        public bool m_isOptional = false;
        public string m_defaultValue = null;
        public OptionalNamedChild(string name, Asn1Object asn1Obj, Func<Asn1Object> CreateObj)
            : base(name, asn1Obj, CreateObj) { }

        public OptionalNamedChild(string name, Asn1Object asn1Obj, Func<Asn1Object> CreateObj, bool optional, string defValue)
            : base(name, asn1Obj, CreateObj) 
        {
            m_isOptional = optional;
            m_defaultValue = defValue;
        }
    }


    public abstract class Asn1CompositeObject<T> : Asn1Object where T : NamedChild
    {

        public List<Func<Asn1CompositeObject<T>, bool>> m_constraints = new List<Func<Asn1CompositeObject<T>, bool>>();


        public OrderedDictionary<string, T> m_children = new OrderedDictionary<string, T>();

        public override IEnumerable<Asn1Object> GetChildren(bool includeMyself)
        {
            if (includeMyself)
                yield return this;
            foreach (T ch in m_children.Values)
                foreach (Asn1Object grCh in ch.m_asn1Object.GetChildren(true))
                    yield return grCh;
        }

        public override bool IsConstraintValid()
        {
            foreach (Func<Asn1CompositeObject<T>, bool> f in m_constraints)
                if (!f(this))
                    return false;
            foreach (NamedChild ch in m_children.Values)
                if (ch.m_asn1Object != null && !ch.m_asn1Object.IsConstraintValid())
                    return false;

            return true;
        }

        public virtual Asn1Object CreateChild(string childName)
        {
            return m_children[childName].createObj();
        }

    }


    public abstract class Asn1SequenceOrSetObject : Asn1CompositeObject<OptionalNamedChild>
    {

        public override bool IsConstraintValid()
        {
            foreach (OptionalNamedChild ch in m_children.Values)
                if (!ch.m_asn1Object.IsConstraintValid())
                    return false;
            return true;
        }

    }




    public abstract class Asn1SequenceObject : Asn1SequenceOrSetObject
    {
        public Asn1SequenceObject()  
        {
            m_Tags.Add(new Tag(16, TagClass.UNIVERSAL));
        }

        public override void Decode(Stream strm, EncodingRules encRule)
        {
            if (encRule == EncodingRules.CER || encRule == EncodingRules.DER)
            {
                DecodeTags(strm);

                //Decode Length
                uint length = 0;
                BER.DecodeLength(strm, out length);
                long curStrPos = strm.Position;

                //Decode content (i.e. children)
                foreach (OptionalNamedChild ch in m_children.Values)
                {
                    foreach (List<Tag> tagList in ch.m_TagLists)
                    {
                        if (Asn1Object.MatchTags(strm, tagList.ToArray()))
                        {
                            ch.m_asn1Object = ch.createObj();
                            ch.m_asn1Object.Decode(strm, encRule);
                        }
                    }

                }
                if (length == 0)
                    BER.DecodeTwoZeros(strm);
                else
                {
                    long decodedData = strm.Position - curStrPos;
                    if (decodedData != length)
                        throw new LengthMismatchException();
                }
            }
            else
                throw new ArgumentException("Unimplemented encoding rule");
        }
        
        public override void Encode(Stream strm, EncodingRules encRule)
        {
            if (encRule == EncodingRules.CER || encRule == EncodingRules.DER)
            {
                //encode Tag
                foreach (Tag t in m_Tags)
                    BER.EncodeTag(strm, t.m_tgClass, false, t.m_tagNo);

                //encode Length
                strm.WriteByte(0x80);

                //encode children
                foreach (OptionalNamedChild ch in m_children.Values)
                    if (ch.m_asn1Object != null)
                        ch.m_asn1Object.Encode(strm, encRule);

                //encode end-of-contents
                strm.WriteByte(0x0);
                strm.WriteByte(0x0);

            } 
            else 
                throw new ArgumentException("Unimplemented encoding rule");
        }

    }


    public abstract class Asn1SetObject : Asn1SequenceOrSetObject
    {
        public Asn1SetObject() { m_Tags.Add(new Tag(17, TagClass.UNIVERSAL)); }

        public override void Decode(Stream strm, EncodingRules encRule)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        public override void Encode(Stream strm, EncodingRules encRule)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }

    public abstract class Asn1ChoiceObject : Asn1CompositeObject<NamedChild>
    {
        public Asn1ChoiceObject() : base() { }

        public override void Decode(Stream strm, EncodingRules encRule)
        {
            if (encRule == EncodingRules.CER || encRule == EncodingRules.DER)
            {
                DecodeTags(strm); // normally no Tag is associated with choice

                //Decode content (i.e. children)
                foreach (NamedChild ch in m_children.Values)
                {
                    foreach (List<Tag> tagList in ch.m_TagLists)
                    {
                        if (Asn1Object.MatchTags(strm, tagList.ToArray()))
                        {
                            ch.m_asn1Object = ch.createObj();
                            ch.m_asn1Object.Decode(strm, encRule);
                            m_AlternativeName = ch.m_name;
                            break;
                        }
                    }

                }
            }
            else
                throw new ArgumentException("Unimplemented encoding rule");
        }
        public override void Encode(Stream strm, EncodingRules encRule)
        {
            if (encRule == EncodingRules.CER || encRule == EncodingRules.DER)
            {
                //encode Tag
                foreach (Tag t in m_Tags)
                    BER.EncodeTag(strm, t.m_tgClass, false, t.m_tagNo);

                if (m_AlternativeName == string.Empty || m_Alternative == null)
                    throw new EmptyChoiceException();
                m_Alternative.Encode(strm, encRule);
            }
            else
                throw new ArgumentException("Unimplemented encoding rule");
        }

        private string choiceAlternative = string.Empty;

        public string m_AlternativeName
        {
            get { return choiceAlternative; }
            set
            {
                if (m_children.ContainsKey(value))
                    choiceAlternative = value;
                throw new ArgumentNullException();
            }
        }

        public Asn1Object m_Alternative
        {
            get
            {
                return m_children[choiceAlternative].m_asn1Object;
            }
        }

        public override bool IsConstraintValid()
        {
            return base.IsConstraintValid() && m_AlternativeName != string.Empty;
        }
    }



    

    // The difference with the normal dictionary is that
    // the Values property retains order (as inserted)
    public class OrderedDictionary<TKey, TValue>    /* util class, no need to be abstract*/
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

