using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using CSharpAsn1CRT;

namespace TYPES
{

    public class FLOAT32 : Asn1RealObject
    {
    }

    public class OBIT : Asn1IntegerObject
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, TagClass.APPLICATION, IsPrimitive, 120);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, TagClass.APPLICATION, IsPrimitive, 120);
        }
        public override bool IsConstraintValid()
        {
            return ((Value>=0) && (Value<=4294967296)) && base.IsConstraintValid();
        }
    }

    public class A_FL : FLOAT32
    {
        public override bool IsConstraintValid()
        {
            return ((Value>=23) && (Value<=100)) && base.IsConstraintValid();
        }
    }

    public class MyStr : Asn1IA5StringObject
    {
        public override bool IsConstraintValid()
        {
            return ((Value.Length>=1) && (Value.Length<=10)) && base.IsConstraintValid();
        }
    }

    public class MyStr2 : Asn1IA5StringObject
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, TagClass.CONTEXT_SPECIFIC, IsPrimitive, 100);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, TagClass.CONTEXT_SPECIFIC, IsPrimitive, 100);
        }
        public override bool IsConstraintValid()
        {
            return new List<char>(Value).TrueForAll(delegate(char c) { return ((c>='A') && (c<='Z')); }) && base.IsConstraintValid();
        }
    }

    public class MyStr3 : Asn1IA5StringObject
    {
        public override bool IsConstraintValid()
        {
            return ((Value.Length>=1) && (Value.Length<=10)) && new List<char>(Value).TrueForAll(delegate(char c) { return (((c>='A') && (c<='Z')) || string.Format("abcd").Contains(c.ToString())); }) && base.IsConstraintValid();
        }
    }

    public class MyStr4 : Asn1IA5StringObject
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, TagClass.CONTEXT_SPECIFIC, IsPrimitive, 107);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, TagClass.CONTEXT_SPECIFIC, IsPrimitive, 107);
        }
        public override bool IsConstraintValid()
        {
            return (new List<char>(Value).TrueForAll(delegate(char c) { return string.Format("ABCDE").Contains(c.ToString()); }) || ((Value.Length>=1) && (Value.Length<=20))) && base.IsConstraintValid();
        }
    }

    public class MyStrStr : MyStr4
    {

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, TagClass.CONTEXT_SPECIFIC, IsPrimitive, 108);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, TagClass.CONTEXT_SPECIFIC, IsPrimitive, 108);
        }
        public override bool IsConstraintValid()
        {
            return new List<char>(Value).TrueForAll(delegate(char c) { return string.Format("ABC").Contains(c.ToString()); }) && base.IsConstraintValid();
        }
    }

    public class MyOctStr : Asn1OctetStringObject
    {
        public override bool IsConstraintValid()
        {
            return ((m_Data.Count>=1) && (m_Data.Count<=5)) && base.IsConstraintValid();
        }
    }

    public class MySeqOF : Asn1SequenceOfObject<MySeqOF.InternalType>
    {
        public class InternalType : Asn1IntegerObject
        {
            public override bool IsConstraintValid()
            {
                return ((Value>=1) && (Value<=10)) && base.IsConstraintValid();
            }
        }

        public override bool IsConstraintValid()
        {
            return ((m_children.Count>=1) && (m_children.Count<=20)) && base.IsConstraintValid();
        }
    }

    public class MyEnum : Asn1EnumeratedObject<MyEnum.Enumerated>
    {
        public enum Enumerated
        {
            red = 0,
            green = 1,
            blue = 2,
        }
        protected override long ValueAsLong { get {return (long)Value;}}
        public override bool IsConstraintValid()
        {
            bool ret=true;
            ret = ret && ((Value == MyEnum.Enumerated.red) || (Value == MyEnum.Enumerated.blue));
            return base.IsConstraintValid() && ret;
        }
    }

    public class MySeq : Asn1SequenceObject
    {

        public class A : Asn1IntegerObject
        {

            public override uint Encode(Stream strm, EncodingRules encRule)
            {
                return Encode(strm, encRule, TagClass.CONTEXT_SPECIFIC, IsPrimitive, 0);
            }

            public override uint Decode(Stream strm, EncodingRules encRule)
            {
                return Decode(strm, encRule, TagClass.CONTEXT_SPECIFIC, IsPrimitive, 0);
            }
        }

        public A a
        {
            get { return m_children[ClassDef.m_children["a"].m_idx] as A; }
        }
        public A Create_a()
        {
            return CreateChild("a");
        }

        public class B : Asn1IntegerObject
        {

            public override uint Encode(Stream strm, EncodingRules encRule)
            {
                return Encode(strm, encRule, TagClass.CONTEXT_SPECIFIC, IsPrimitive, 1);
            }

            public override uint Decode(Stream strm, EncodingRules encRule)
            {
                return Decode(strm, encRule, TagClass.CONTEXT_SPECIFIC, IsPrimitive, 1);
            }
            public override bool IsConstraintValid()
            {
                return ((Value>=1) && (Value<=10)) && base.IsConstraintValid();
            }
        }

        public B b
        {
            get { return m_children[ClassDef.m_children["b"].m_idx] as B; }
        }
        public B Create_b()
        {
            return CreateChild("b");
        }

        public class C : OBIT
        {

            public override uint Encode(Stream strm, EncodingRules encRule)
            {
                return Encode(strm, encRule, TagClass.CONTEXT_SPECIFIC, IsPrimitive, 2);
            }

            public override uint Decode(Stream strm, EncodingRules encRule)
            {
                return Decode(strm, encRule, TagClass.CONTEXT_SPECIFIC, IsPrimitive, 2);
            }
            public override bool IsConstraintValid()
            {
                return ((Value>=4) && (Value<=20)) && base.IsConstraintValid();
            }
        }

        public C c
        {
            get { return m_children[ClassDef.m_children["c"].m_idx] as C; }
        }
        public C Create_c()
        {
            return CreateChild("c");
        }

        public class Strst : MyStrStr
        {

            public override uint Encode(Stream strm, EncodingRules encRule)
            {
                return Encode(strm, encRule, TagClass.CONTEXT_SPECIFIC, IsPrimitive, 3);
            }

            public override uint Decode(Stream strm, EncodingRules encRule)
            {
                return Decode(strm, encRule, TagClass.CONTEXT_SPECIFIC, IsPrimitive, 3);
            }
            public override bool IsConstraintValid()
            {
                return (Value.Length == 4) && base.IsConstraintValid();
            }
        }

        public Strst strst
        {
            get { return m_children[ClassDef.m_children["strst"].m_idx] as Strst; }
        }
        public Strst Create_strst()
        {
            return CreateChild("strst");
        }

        public class Arr : Asn1SequenceOfObject<Arr.InternalType>
        {
            public class InternalType : Asn1IntegerObject
            {
                public override bool IsConstraintValid()
                {
                    return ((Value>=1) && (Value<=10)) && base.IsConstraintValid();
                }
            }


            public override uint Encode(Stream strm, EncodingRules encRule)
            {
                return Encode(strm, encRule, TagClass.CONTEXT_SPECIFIC, IsPrimitive, 4);
            }

            public override uint Decode(Stream strm, EncodingRules encRule)
            {
                return Decode(strm, encRule, TagClass.CONTEXT_SPECIFIC, IsPrimitive, 4);
            }
            public override bool IsConstraintValid()
            {
                return ((m_children.Count>=1) && (m_children.Count<=20)) && base.IsConstraintValid();
            }
        }

        public Arr arr
        {
            get { return m_children[ClassDef.m_children["arr"].m_idx] as Arr; }
        }
        public Arr Create_arr()
        {
            return CreateChild("arr");
        }

        public class Arr2 : Asn1SequenceOfObject<Arr2.InternalType>
        {
            public class InternalType : Asn1SequenceOfObject<InternalType.InternalType1>
            {
                public class InternalType1 : Asn1IntegerObject
                {
                    public override bool IsConstraintValid()
                    {
                        return ((Value>=1) && (Value<=10)) && base.IsConstraintValid();
                    }
                }

                public override bool IsConstraintValid()
                {
                    return ((m_children.Count>=100) && (m_children.Count<=200)) && base.IsConstraintValid();
                }
            }


            public override uint Encode(Stream strm, EncodingRules encRule)
            {
                return Encode(strm, encRule, TagClass.CONTEXT_SPECIFIC, IsPrimitive, 5);
            }

            public override uint Decode(Stream strm, EncodingRules encRule)
            {
                return Decode(strm, encRule, TagClass.CONTEXT_SPECIFIC, IsPrimitive, 5);
            }
            public override bool IsConstraintValid()
            {
                return ((m_children.Count>=1) && (m_children.Count<=20)) && base.IsConstraintValid();
            }
        }

        public Arr2 arr2
        {
            get { return m_children[ClassDef.m_children["arr2"].m_idx] as Arr2; }
        }
        public Arr2 Create_arr2()
        {
            return CreateChild("arr2");
        }

        public class Inn : Asn1SequenceObject
        {

            public class A : Asn1IntegerObject
            {

                public override uint Encode(Stream strm, EncodingRules encRule)
                {
                    return Encode(strm, encRule, TagClass.CONTEXT_SPECIFIC, IsPrimitive, 0);
                }

                public override uint Decode(Stream strm, EncodingRules encRule)
                {
                    return Decode(strm, encRule, TagClass.CONTEXT_SPECIFIC, IsPrimitive, 0);
                }
            }

            public A a
            {
                get { return m_children[ClassDef.m_children["a"].m_idx] as A; }
            }
            public A Create_a()
            {
                return CreateChild("a");
            }

            public class B : Asn1IntegerObject
            {

                public override uint Encode(Stream strm, EncodingRules encRule)
                {
                    return Encode(strm, encRule, TagClass.CONTEXT_SPECIFIC, IsPrimitive, 1);
                }

                public override uint Decode(Stream strm, EncodingRules encRule)
                {
                    return Decode(strm, encRule, TagClass.CONTEXT_SPECIFIC, IsPrimitive, 1);
                }
                public override bool IsConstraintValid()
                {
                    return ((Value>=1) && (Value<=10)) && base.IsConstraintValid();
                }
            }

            public B b
            {
                get { return m_children[ClassDef.m_children["b"].m_idx] as B; }
            }
            public B Create_b()
            {
                return CreateChild("b");
            }

            public class C : OBIT
            {

                public override uint Encode(Stream strm, EncodingRules encRule)
                {
                    return Encode(strm, encRule, TagClass.CONTEXT_SPECIFIC, IsPrimitive, 2);
                }

                public override uint Decode(Stream strm, EncodingRules encRule)
                {
                    return Decode(strm, encRule, TagClass.CONTEXT_SPECIFIC, IsPrimitive, 2);
                }
                public override bool IsConstraintValid()
                {
                    return ((Value>=4) && (Value<=20)) && base.IsConstraintValid();
                }
            }

            public C c
            {
                get { return m_children[ClassDef.m_children["c"].m_idx] as C; }
            }
            public C Create_c()
            {
                return CreateChild("c");
            }

            public class Strst : MyStrStr
            {

                public override uint Encode(Stream strm, EncodingRules encRule)
                {
                    return Encode(strm, encRule, TagClass.CONTEXT_SPECIFIC, IsPrimitive, 3);
                }

                public override uint Decode(Stream strm, EncodingRules encRule)
                {
                    return Decode(strm, encRule, TagClass.CONTEXT_SPECIFIC, IsPrimitive, 3);
                }
                public override bool IsConstraintValid()
                {
                    return (Value.Length == 4) && base.IsConstraintValid();
                }
            }

            public Strst strst
            {
                get { return m_children[ClassDef.m_children["strst"].m_idx] as Strst; }
            }
            public Strst Create_strst()
            {
                return CreateChild("strst");
            }

            public class Arr : Asn1SequenceOfObject<Arr.InternalType>
            {
                public class InternalType : Asn1IntegerObject
                {
                    public override bool IsConstraintValid()
                    {
                        return ((Value>=1) && (Value<=10)) && base.IsConstraintValid();
                    }
                }


                public override uint Encode(Stream strm, EncodingRules encRule)
                {
                    return Encode(strm, encRule, TagClass.CONTEXT_SPECIFIC, IsPrimitive, 4);
                }

                public override uint Decode(Stream strm, EncodingRules encRule)
                {
                    return Decode(strm, encRule, TagClass.CONTEXT_SPECIFIC, IsPrimitive, 4);
                }
                public override bool IsConstraintValid()
                {
                    return ((m_children.Count>=1) && (m_children.Count<=20)) && base.IsConstraintValid();
                }
            }

            public Arr arr
            {
                get { return m_children[ClassDef.m_children["arr"].m_idx] as Arr; }
            }
            public Arr Create_arr()
            {
                return CreateChild("arr");
            }

            public class Arr2 : Asn1SequenceOfObject<Arr2.InternalType>
            {
                public class InternalType : Asn1SequenceOfObject<InternalType.InternalType1>
                {
                    public class InternalType1 : Asn1IntegerObject
                    {
                        public override bool IsConstraintValid()
                        {
                            return ((Value>=1) && (Value<=10)) && base.IsConstraintValid();
                        }
                    }

                    public override bool IsConstraintValid()
                    {
                        return ((m_children.Count>=100) && (m_children.Count<=200)) && base.IsConstraintValid();
                    }
                }


                public override uint Encode(Stream strm, EncodingRules encRule)
                {
                    return Encode(strm, encRule, TagClass.CONTEXT_SPECIFIC, IsPrimitive, 5);
                }

                public override uint Decode(Stream strm, EncodingRules encRule)
                {
                    return Decode(strm, encRule, TagClass.CONTEXT_SPECIFIC, IsPrimitive, 5);
                }
                public override bool IsConstraintValid()
                {
                    return ((m_children.Count>=1) && (m_children.Count<=20)) && base.IsConstraintValid();
                }
            }

            public Arr2 arr2
            {
                get { return m_children[ClassDef.m_children["arr2"].m_idx] as Arr2; }
            }
            public Arr2 Create_arr2()
            {
                return CreateChild("arr2");
            }

            public override uint Encode(Stream strm, EncodingRules encRule)
            {
                return Encode(strm, encRule, TagClass.CONTEXT_SPECIFIC, IsPrimitive, 6);
            }

            public override uint Decode(Stream strm, EncodingRules encRule)
            {
                return Decode(strm, encRule, TagClass.CONTEXT_SPECIFIC, IsPrimitive, 6);
            }
            Asn1CompositeClass<OptionalNamedChild> _clsDef = null;
            public override Asn1CompositeClass<OptionalNamedChild> ClassDef
            {
                get
                {
                    if (_clsDef==null)
                        _clsDef = new InnClassDefinition();
                    return _clsDef;
                }
            }
            public class InnClassDefinition
            {
                public InnClassDefinition()
                {
                    OptionalNamedChild ch;
                    ch = new OptionalNamedChild("a", 0, delegate() {return new A();}, false, null);
                    ch.m_Tag = new Tag(0, TagClass.CONTEXT_SPECIFIC);
                    m_children.Add("a", ch);

                    ch = new OptionalNamedChild("b", 1, delegate() {return new B();}, false, null);
                    ch.m_Tag = new Tag(1, TagClass.CONTEXT_SPECIFIC);
                    m_children.Add("b", ch);

                    ch = new OptionalNamedChild("c", 2, delegate() {return new C();}, false, null);
                    ch.m_Tag = new Tag(2, TagClass.CONTEXT_SPECIFIC);
                    m_children.Add("c", ch);

                    ch = new OptionalNamedChild("strst", 3, delegate() {return new Strst();}, false, null);
                    ch.m_Tag = new Tag(3, TagClass.CONTEXT_SPECIFIC);
                    m_children.Add("strst", ch);

                    ch = new OptionalNamedChild("arr", 4, delegate() {return new Arr();}, false, null);
                    ch.m_Tag = new Tag(4, TagClass.CONTEXT_SPECIFIC);
                    m_children.Add("arr", ch);

                    ch = new OptionalNamedChild("arr2", 5, delegate() {return new Arr2();}, false, null);
                    ch.m_Tag = new Tag(5, TagClass.CONTEXT_SPECIFIC);
                    m_children.Add("arr2", ch);

                }
            }
        }

        public Inn inn
        {
            get { return m_children[ClassDef.m_children["inn"].m_idx] as Inn; }
        }
        public Inn Create_inn()
        {
            return CreateChild("inn");
        }

        public class En1 : MyEnum
        {

            public override uint Encode(Stream strm, EncodingRules encRule)
            {
                return Encode(strm, encRule, TagClass.CONTEXT_SPECIFIC, IsPrimitive, 7);
            }

            public override uint Decode(Stream strm, EncodingRules encRule)
            {
                return Decode(strm, encRule, TagClass.CONTEXT_SPECIFIC, IsPrimitive, 7);
            }
            public override bool IsConstraintValid()
            {
                return ((Value == MyEnum.Enumerated.red) || (Value == MyEnum.Enumerated.green)) && base.IsConstraintValid();
            }
        }

        public En1 en1
        {
            get { return m_children[ClassDef.m_children["en1"].m_idx] as En1; }
        }
        public En1 Create_en1()
        {
            return CreateChild("en1");
        }

        public class En2 : Asn1EnumeratedObject<En2.Enumerated>
        {
            public enum Enumerated
            {
                red = 0,
                green = 1,
                blue = 2,
            }
            protected override long ValueAsLong { get {return (long)Value;}}

            public override uint Encode(Stream strm, EncodingRules encRule)
            {
                return Encode(strm, encRule, TagClass.CONTEXT_SPECIFIC, IsPrimitive, 8);
            }

            public override uint Decode(Stream strm, EncodingRules encRule)
            {
                return Decode(strm, encRule, TagClass.CONTEXT_SPECIFIC, IsPrimitive, 8);
            }
            public override bool IsConstraintValid()
            {
                bool ret=true;
                ret = ret && ((Value == En2.Enumerated.red) || (Value == En2.Enumerated.blue));
                return base.IsConstraintValid() && ret;
            }
        }

        public En2 en2
        {
            get { return m_children[ClassDef.m_children["en2"].m_idx] as En2; }
        }
        public En2 Create_en2()
        {
            return CreateChild("en2");
        }

        public class MyChoice : MyCh
        {

            public override uint Encode(Stream strm, EncodingRules encRule)
            {
                return Encode(strm, encRule, TagClass.CONTEXT_SPECIFIC, false, 9);
            }

            public override uint Decode(Stream strm, EncodingRules encRule)
            {
                return Decode(strm, encRule, TagClass.CONTEXT_SPECIFIC, false, 9);
            }

            public override uint EncodeContent(Stream strm, EncodingRules encRule)
            {
                return base.Encode(strm, encRule);
            }

            public override uint DecodeContent(Stream strm, EncodingRules encRule, uint dataLen)
            {
                return base.Decode(strm, encRule);
            }
        }

        public MyChoice myChoice
        {
            get { return m_children[ClassDef.m_children["myChoice"].m_idx] as MyChoice; }
        }
        public MyChoice Create_myChoice()
        {
            return CreateChild("myChoice");
        }

        public override uint Encode(Stream strm, EncodingRules encRule)
        {
            return Encode(strm, encRule, TagClass.APPLICATION, IsPrimitive, 102);
        }

        public override uint Decode(Stream strm, EncodingRules encRule)
        {
            return Decode(strm, encRule, TagClass.APPLICATION, IsPrimitive, 102);
        }
        Asn1CompositeClass<OptionalNamedChild> _clsDef = null;
        public override Asn1CompositeClass<OptionalNamedChild> ClassDef
        {
            get
            {
                if (_clsDef==null)
                    _clsDef = new MySeqClassDefinition();
                return _clsDef;
            }
        }
        public class MySeqClassDefinition
        {
            public MySeqClassDefinition()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("a", 0, delegate() {return new A();}, true, null);
                ch.m_Tag = new Tag(0, TagClass.CONTEXT_SPECIFIC);
                m_children.Add("a", ch);

                ch = new OptionalNamedChild("b", 1, delegate() {return new B();}, true, null);
                ch.m_Tag = new Tag(1, TagClass.CONTEXT_SPECIFIC);
                m_children.Add("b", ch);

                ch = new OptionalNamedChild("c", 2, delegate() {return new C();}, false, null);
                ch.m_Tag = new Tag(2, TagClass.CONTEXT_SPECIFIC);
                m_children.Add("c", ch);

                ch = new OptionalNamedChild("strst", 3, delegate() {return new Strst();}, false, null);
                ch.m_Tag = new Tag(3, TagClass.CONTEXT_SPECIFIC);
                m_children.Add("strst", ch);

                ch = new OptionalNamedChild("arr", 4, delegate() {return new Arr();}, false, null);
                ch.m_Tag = new Tag(4, TagClass.CONTEXT_SPECIFIC);
                m_children.Add("arr", ch);

                ch = new OptionalNamedChild("arr2", 5, delegate() {return new Arr2();}, false, null);
                ch.m_Tag = new Tag(5, TagClass.CONTEXT_SPECIFIC);
                m_children.Add("arr2", ch);

                ch = new OptionalNamedChild("inn", 6, delegate() {return new Inn();}, false, null);
                ch.m_Tag = new Tag(6, TagClass.CONTEXT_SPECIFIC);
                m_children.Add("inn", ch);

                ch = new OptionalNamedChild("en1", 7, delegate() {return new En1();}, false, null);
                ch.m_Tag = new Tag(7, TagClass.CONTEXT_SPECIFIC);
                m_children.Add("en1", ch);

                ch = new OptionalNamedChild("en2", 8, delegate() {return new En2();}, false, null);
                ch.m_Tag = new Tag(8, TagClass.CONTEXT_SPECIFIC);
                m_children.Add("en2", ch);

                ch = new OptionalNamedChild("myChoice", 9, delegate() {return new MyChoice();}, false, null);
                ch.m_Tag = new Tag(9, TagClass.CONTEXT_SPECIFIC);
                m_children.Add("myChoice", ch);

            }
        }
    }

    public class MyCh : Asn1ChoiceObject
    {

        public class A : Asn1IntegerObject
        {

            public override uint Encode(Stream strm, EncodingRules encRule)
            {
                return Encode(strm, encRule, TagClass.CONTEXT_SPECIFIC, IsPrimitive, 0);
            }

            public override uint Decode(Stream strm, EncodingRules encRule)
            {
                return Decode(strm, encRule, TagClass.CONTEXT_SPECIFIC, IsPrimitive, 0);
            }
        }

        public A a
        {
            get { return m_children[ClassDef.m_children["a"].m_idx] as A; }
        }
        public A Create_a()
        {
            A ret = new A();
            if (m_AlternativeName != string.Empty)
                m_children[m_AlternativeName].m_asn1Object = null;
            m_children["a"].m_asn1Object = ret;
            m_AlternativeName = "a";
            return ret;
        }

        public class B : Asn1IntegerObject
        {

            public override uint Encode(Stream strm, EncodingRules encRule)
            {
                return Encode(strm, encRule, TagClass.CONTEXT_SPECIFIC, IsPrimitive, 1);
            }

            public override uint Decode(Stream strm, EncodingRules encRule)
            {
                return Decode(strm, encRule, TagClass.CONTEXT_SPECIFIC, IsPrimitive, 1);
            }
            public override bool IsConstraintValid()
            {
                return ((Value>=1) && (Value<=10)) && base.IsConstraintValid();
            }
        }

        public B b
        {
            get { return m_children[ClassDef.m_children["b"].m_idx] as B; }
        }
        public B Create_b()
        {
            B ret = new B();
            if (m_AlternativeName != string.Empty)
                m_children[m_AlternativeName].m_asn1Object = null;
            m_children["b"].m_asn1Object = ret;
            m_AlternativeName = "b";
            return ret;
        }

        public class C : OBIT
        {

            public override uint Encode(Stream strm, EncodingRules encRule)
            {
                return Encode(strm, encRule, TagClass.CONTEXT_SPECIFIC, IsPrimitive, 2);
            }

            public override uint Decode(Stream strm, EncodingRules encRule)
            {
                return Decode(strm, encRule, TagClass.CONTEXT_SPECIFIC, IsPrimitive, 2);
            }
            public override bool IsConstraintValid()
            {
                return ((Value>=4) && (Value<=20)) && base.IsConstraintValid();
            }
        }

        public C c
        {
            get { return m_children[ClassDef.m_children["c"].m_idx] as C; }
        }
        public C Create_c()
        {
            C ret = new C();
            if (m_AlternativeName != string.Empty)
                m_children[m_AlternativeName].m_asn1Object = null;
            m_children["c"].m_asn1Object = ret;
            m_AlternativeName = "c";
            return ret;
        }

        public class Strst : MyStrStr
        {

            public override uint Encode(Stream strm, EncodingRules encRule)
            {
                return Encode(strm, encRule, TagClass.CONTEXT_SPECIFIC, IsPrimitive, 3);
            }

            public override uint Decode(Stream strm, EncodingRules encRule)
            {
                return Decode(strm, encRule, TagClass.CONTEXT_SPECIFIC, IsPrimitive, 3);
            }
            public override bool IsConstraintValid()
            {
                return (Value.Length == 4) && base.IsConstraintValid();
            }
        }

        public Strst strst
        {
            get { return m_children[ClassDef.m_children["strst"].m_idx] as Strst; }
        }
        public Strst Create_strst()
        {
            Strst ret = new Strst();
            if (m_AlternativeName != string.Empty)
                m_children[m_AlternativeName].m_asn1Object = null;
            m_children["strst"].m_asn1Object = ret;
            m_AlternativeName = "strst";
            return ret;
        }

        public class Arr : Asn1SequenceOfObject<Arr.InternalType>
        {
            public class InternalType : Asn1IntegerObject
            {
                public override bool IsConstraintValid()
                {
                    return ((Value>=1) && (Value<=10)) && base.IsConstraintValid();
                }
            }


            public override uint Encode(Stream strm, EncodingRules encRule)
            {
                return Encode(strm, encRule, TagClass.CONTEXT_SPECIFIC, IsPrimitive, 4);
            }

            public override uint Decode(Stream strm, EncodingRules encRule)
            {
                return Decode(strm, encRule, TagClass.CONTEXT_SPECIFIC, IsPrimitive, 4);
            }
            public override bool IsConstraintValid()
            {
                return ((m_children.Count>=1) && (m_children.Count<=20)) && base.IsConstraintValid();
            }
        }

        public Arr arr
        {
            get { return m_children[ClassDef.m_children["arr"].m_idx] as Arr; }
        }
        public Arr Create_arr()
        {
            Arr ret = new Arr();
            if (m_AlternativeName != string.Empty)
                m_children[m_AlternativeName].m_asn1Object = null;
            m_children["arr"].m_asn1Object = ret;
            m_AlternativeName = "arr";
            return ret;
        }

        public class Arr2 : Asn1SequenceOfObject<Arr2.InternalType>
        {
            public class InternalType : Asn1SequenceOfObject<InternalType.InternalType1>
            {
                public class InternalType1 : Asn1IntegerObject
                {
                    public override bool IsConstraintValid()
                    {
                        return ((Value>=1) && (Value<=10)) && base.IsConstraintValid();
                    }
                }

                public override bool IsConstraintValid()
                {
                    return ((m_children.Count>=100) && (m_children.Count<=200)) && base.IsConstraintValid();
                }
            }


            public override uint Encode(Stream strm, EncodingRules encRule)
            {
                return Encode(strm, encRule, TagClass.CONTEXT_SPECIFIC, IsPrimitive, 5);
            }

            public override uint Decode(Stream strm, EncodingRules encRule)
            {
                return Decode(strm, encRule, TagClass.CONTEXT_SPECIFIC, IsPrimitive, 5);
            }
            public override bool IsConstraintValid()
            {
                return ((m_children.Count>=1) && (m_children.Count<=20)) && base.IsConstraintValid();
            }
        }

        public Arr2 arr2
        {
            get { return m_children[ClassDef.m_children["arr2"].m_idx] as Arr2; }
        }
        public Arr2 Create_arr2()
        {
            Arr2 ret = new Arr2();
            if (m_AlternativeName != string.Empty)
                m_children[m_AlternativeName].m_asn1Object = null;
            m_children["arr2"].m_asn1Object = ret;
            m_AlternativeName = "arr2";
            return ret;
        }

        public class Inn : Asn1SequenceObject
        {

            public class A : Asn1IntegerObject
            {

                public override uint Encode(Stream strm, EncodingRules encRule)
                {
                    return Encode(strm, encRule, TagClass.CONTEXT_SPECIFIC, IsPrimitive, 0);
                }

                public override uint Decode(Stream strm, EncodingRules encRule)
                {
                    return Decode(strm, encRule, TagClass.CONTEXT_SPECIFIC, IsPrimitive, 0);
                }
            }

            public A a
            {
                get { return m_children[ClassDef.m_children["a"].m_idx] as A; }
            }
            public A Create_a()
            {
                return CreateChild("a");
            }

            public class B : Asn1IntegerObject
            {

                public override uint Encode(Stream strm, EncodingRules encRule)
                {
                    return Encode(strm, encRule, TagClass.CONTEXT_SPECIFIC, IsPrimitive, 1);
                }

                public override uint Decode(Stream strm, EncodingRules encRule)
                {
                    return Decode(strm, encRule, TagClass.CONTEXT_SPECIFIC, IsPrimitive, 1);
                }
                public override bool IsConstraintValid()
                {
                    return ((Value>=1) && (Value<=10)) && base.IsConstraintValid();
                }
            }

            public B b
            {
                get { return m_children[ClassDef.m_children["b"].m_idx] as B; }
            }
            public B Create_b()
            {
                return CreateChild("b");
            }

            public class C : OBIT
            {

                public override uint Encode(Stream strm, EncodingRules encRule)
                {
                    return Encode(strm, encRule, TagClass.CONTEXT_SPECIFIC, IsPrimitive, 2);
                }

                public override uint Decode(Stream strm, EncodingRules encRule)
                {
                    return Decode(strm, encRule, TagClass.CONTEXT_SPECIFIC, IsPrimitive, 2);
                }
                public override bool IsConstraintValid()
                {
                    return ((Value>=4) && (Value<=20)) && base.IsConstraintValid();
                }
            }

            public C c
            {
                get { return m_children[ClassDef.m_children["c"].m_idx] as C; }
            }
            public C Create_c()
            {
                return CreateChild("c");
            }

            public class Strst : MyStrStr
            {

                public override uint Encode(Stream strm, EncodingRules encRule)
                {
                    return Encode(strm, encRule, TagClass.CONTEXT_SPECIFIC, IsPrimitive, 3);
                }

                public override uint Decode(Stream strm, EncodingRules encRule)
                {
                    return Decode(strm, encRule, TagClass.CONTEXT_SPECIFIC, IsPrimitive, 3);
                }
                public override bool IsConstraintValid()
                {
                    return (Value.Length == 4) && base.IsConstraintValid();
                }
            }

            public Strst strst
            {
                get { return m_children[ClassDef.m_children["strst"].m_idx] as Strst; }
            }
            public Strst Create_strst()
            {
                return CreateChild("strst");
            }

            public class Arr : Asn1SequenceOfObject<Arr.InternalType>
            {
                public class InternalType : Asn1IntegerObject
                {
                    public override bool IsConstraintValid()
                    {
                        return ((Value>=1) && (Value<=10)) && base.IsConstraintValid();
                    }
                }


                public override uint Encode(Stream strm, EncodingRules encRule)
                {
                    return Encode(strm, encRule, TagClass.CONTEXT_SPECIFIC, IsPrimitive, 4);
                }

                public override uint Decode(Stream strm, EncodingRules encRule)
                {
                    return Decode(strm, encRule, TagClass.CONTEXT_SPECIFIC, IsPrimitive, 4);
                }
                public override bool IsConstraintValid()
                {
                    return ((m_children.Count>=1) && (m_children.Count<=20)) && base.IsConstraintValid();
                }
            }

            public Arr arr
            {
                get { return m_children[ClassDef.m_children["arr"].m_idx] as Arr; }
            }
            public Arr Create_arr()
            {
                return CreateChild("arr");
            }

            public class Arr2 : Asn1SequenceOfObject<Arr2.InternalType>
            {
                public class InternalType : Asn1SequenceOfObject<InternalType.InternalType1>
                {
                    public class InternalType1 : Asn1IntegerObject
                    {
                        public override bool IsConstraintValid()
                        {
                            return ((Value>=1) && (Value<=10)) && base.IsConstraintValid();
                        }
                    }

                    public override bool IsConstraintValid()
                    {
                        return ((m_children.Count>=100) && (m_children.Count<=200)) && base.IsConstraintValid();
                    }
                }


                public override uint Encode(Stream strm, EncodingRules encRule)
                {
                    return Encode(strm, encRule, TagClass.CONTEXT_SPECIFIC, IsPrimitive, 5);
                }

                public override uint Decode(Stream strm, EncodingRules encRule)
                {
                    return Decode(strm, encRule, TagClass.CONTEXT_SPECIFIC, IsPrimitive, 5);
                }
                public override bool IsConstraintValid()
                {
                    return ((m_children.Count>=1) && (m_children.Count<=20)) && base.IsConstraintValid();
                }
            }

            public Arr2 arr2
            {
                get { return m_children[ClassDef.m_children["arr2"].m_idx] as Arr2; }
            }
            public Arr2 Create_arr2()
            {
                return CreateChild("arr2");
            }

            public override uint Encode(Stream strm, EncodingRules encRule)
            {
                return Encode(strm, encRule, TagClass.CONTEXT_SPECIFIC, IsPrimitive, 6);
            }

            public override uint Decode(Stream strm, EncodingRules encRule)
            {
                return Decode(strm, encRule, TagClass.CONTEXT_SPECIFIC, IsPrimitive, 6);
            }
            Asn1CompositeClass<OptionalNamedChild> _clsDef = null;
            public override Asn1CompositeClass<OptionalNamedChild> ClassDef
            {
                get
                {
                    if (_clsDef==null)
                        _clsDef = new InnClassDefinition();
                    return _clsDef;
                }
            }
            public class InnClassDefinition
            {
                public InnClassDefinition()
                {
                    OptionalNamedChild ch;
                    ch = new OptionalNamedChild("a", 0, delegate() {return new A();}, false, null);
                    ch.m_Tag = new Tag(0, TagClass.CONTEXT_SPECIFIC);
                    m_children.Add("a", ch);

                    ch = new OptionalNamedChild("b", 1, delegate() {return new B();}, false, null);
                    ch.m_Tag = new Tag(1, TagClass.CONTEXT_SPECIFIC);
                    m_children.Add("b", ch);

                    ch = new OptionalNamedChild("c", 2, delegate() {return new C();}, false, null);
                    ch.m_Tag = new Tag(2, TagClass.CONTEXT_SPECIFIC);
                    m_children.Add("c", ch);

                    ch = new OptionalNamedChild("strst", 3, delegate() {return new Strst();}, false, null);
                    ch.m_Tag = new Tag(3, TagClass.CONTEXT_SPECIFIC);
                    m_children.Add("strst", ch);

                    ch = new OptionalNamedChild("arr", 4, delegate() {return new Arr();}, false, null);
                    ch.m_Tag = new Tag(4, TagClass.CONTEXT_SPECIFIC);
                    m_children.Add("arr", ch);

                    ch = new OptionalNamedChild("arr2", 5, delegate() {return new Arr2();}, false, null);
                    ch.m_Tag = new Tag(5, TagClass.CONTEXT_SPECIFIC);
                    m_children.Add("arr2", ch);

                }
            }
        }

        public Inn inn
        {
            get { return m_children[ClassDef.m_children["inn"].m_idx] as Inn; }
        }
        public Inn Create_inn()
        {
            Inn ret = new Inn();
            if (m_AlternativeName != string.Empty)
                m_children[m_AlternativeName].m_asn1Object = null;
            m_children["inn"].m_asn1Object = ret;
            m_AlternativeName = "inn";
            return ret;
        }
        Asn1CompositeClass<NamedChild> _clsDef = null;
        public override Asn1CompositeClass<NamedChild> ClassDef
        {
            get
            {
                if (_clsDef==null)
                    _clsDef = new MyChClassDefinition();
                return _clsDef;
            }
        }
        public class MyChClassDefinition
        {
            public MyChClassDefinition()
            {
                NamedChild ch;
                ch = new NamedChild("a", 0, delegate() {return new A();});
                ch.m_Tag = new Tag(0, TagClass.CONTEXT_SPECIFIC);
                m_children.Add("a", ch);
                ch = new NamedChild("b", 1, delegate() {return new B();});
                ch.m_Tag = new Tag(1, TagClass.CONTEXT_SPECIFIC);
                m_children.Add("b", ch);
                ch = new NamedChild("c", 2, delegate() {return new C();});
                ch.m_Tag = new Tag(2, TagClass.CONTEXT_SPECIFIC);
                m_children.Add("c", ch);
                ch = new NamedChild("strst", 3, delegate() {return new Strst();});
                ch.m_Tag = new Tag(3, TagClass.CONTEXT_SPECIFIC);
                m_children.Add("strst", ch);
                ch = new NamedChild("arr", 4, delegate() {return new Arr();});
                ch.m_Tag = new Tag(4, TagClass.CONTEXT_SPECIFIC);
                m_children.Add("arr", ch);
                ch = new NamedChild("arr2", 5, delegate() {return new Arr2();});
                ch.m_Tag = new Tag(5, TagClass.CONTEXT_SPECIFIC);
                m_children.Add("arr2", ch);
                ch = new NamedChild("inn", 6, delegate() {return new Inn();});
                ch.m_Tag = new Tag(6, TagClass.CONTEXT_SPECIFIC);
                m_children.Add("inn", ch);
            }
        }
    }

    public class MySeqOF2 : Asn1SequenceOfObject<MySeq>
    {
        public override bool IsConstraintValid()
        {
            return ((m_children.Count>=1) && (m_children.Count<=20)) && base.IsConstraintValid();
        }
    }

}
