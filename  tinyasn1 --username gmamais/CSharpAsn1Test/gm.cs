using System;
using System.Collections.Generic;
using System.Text;
using CSharpAsn1CRT;

namespace TYPES
{

    public class FLOAT32 : Asn1RealObject
    {
        public FLOAT32()
        {
            //Write constraints
        }
    }

    public class OBIT : Asn1IntegerObject
    {
        public OBIT()
        {
            //Write constraints
            m_constraints.Add(new Func<long, bool>(delegate(long val) { return ((val>=0) && (val<=4294967296)); }));
        }
    }

    public class A_FL : FLOAT32
    {
        public A_FL()
        {
            //Write constraints
            m_constraints.Add(new Func<double, bool>(delegate(double val) { return ((val>=23) && (val<=100)); }));
        }
    }

    public class MyStr : Asn1IA5StringObject
    {
        public MyStr()
        {
            //Write constraints
            m_constraints.Add(new Func<string, bool>(delegate(string val) { return ((val.Length>=1) && (val.Length<=10)); }));
        }
    }

    public class MyStr2 : Asn1IA5StringObject
    {
        public MyStr2()
        {
            //Write constraints
            m_constraints.Add(new Func<string, bool>(delegate(string val) { return new List<char>(val).TrueForAll(delegate(char c) { return ((c>='A') && (c<='Z')); }); }));
        }
    }

    public class MyStr3 : Asn1IA5StringObject
    {
        public MyStr3()
        {
            //Write constraints
            m_constraints.Add(new Func<string, bool>(delegate(string val) { return ((val.Length>=1) && (val.Length<=10)); }));
            m_constraints.Add(new Func<string, bool>(delegate(string val) { return new List<char>(val).TrueForAll(delegate(char c) { return (((c>='A') && (c<='Z')) || string.Format("abcd").Contains(c.ToString())); }); }));
        }
    }

    public class MyStr4 : Asn1IA5StringObject
    {
        public MyStr4()
        {
            //Write constraints
            m_constraints.Add(new Func<string, bool>(delegate(string val) { return (new List<char>(val).TrueForAll(delegate(char c) { return string.Format("ABCDE").Contains(c.ToString()); }) || ((val.Length>=1) && (val.Length<=20))); }));
        }
    }

    public class MyStrStr : MyStr4
    {
        public MyStrStr()
        {
            //Write constraints
            m_constraints.Add(new Func<string, bool>(delegate(string val) { return new List<char>(val).TrueForAll(delegate(char c) { return string.Format("ABC").Contains(c.ToString()); }); }));
        }
    }

    public class MyOctStr : Asn1OctetStringObject
    {
        public MyOctStr()
        {
            //Write constraints
            m_constraints.Add(new Func<List<byte>, bool>(delegate(List<byte> val) { return ((val.Count>=1) && (val.Count<=5)); }));
        }
    }

    public class MySeqOF : Asn1SequenceOfObject<Asn1IntegerObject>
    {
        public MySeqOF()
        {
            m_child.createObj = new Func<Asn1IntegerObject>(delegate()
            {
                Asn1IntegerObject ch1 = new Asn1IntegerObject();
                //Write constraints
                ch1.m_constraints.Add(new Func<long, bool>(delegate(long val) { return ((val>=1) && (val<=10)); }));
                return ch1;
            });
            //Write constraints
            m_constraints.Add(new Func<Asn1ArrayObject<Asn1IntegerObject>, bool>(delegate(Asn1ArrayObject<Asn1IntegerObject> val) { return ((val.m_children.Count>=1) && (val.m_children.Count<=20)); }));
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
        public MyEnum()
        {
            //Write constraints
            m_constraints.Add(new Func<MyEnum.Enumerated, bool>(delegate(MyEnum.Enumerated val) { return ((val == MyEnum.Enumerated.red) || (val == MyEnum.Enumerated.blue)); }));
        }
    }

    public class MySeq : Asn1SequenceObject
    {

        public Asn1IntegerObject a
        {
            get { return m_children["a"].m_asn1Object as Asn1IntegerObject; }
        }
        public Asn1IntegerObject Create_a()
        {
            Asn1IntegerObject ret = new Asn1IntegerObject();
            //Write constraints
            m_children["a"].m_asn1Object = ret;
            return ret;
        }

        public Asn1IntegerObject b
        {
            get { return m_children["b"].m_asn1Object as Asn1IntegerObject; }
        }
        public Asn1IntegerObject Create_b()
        {
            Asn1IntegerObject ret = new Asn1IntegerObject();
            //Write constraints
            ret.m_constraints.Add(new Func<long, bool>(delegate(long val) { return ((val>=1) && (val<=10)); }));
            m_children["b"].m_asn1Object = ret;
            return ret;
        }

        public OBIT c
        {
            get { return m_children["c"].m_asn1Object as OBIT; }
        }
        public OBIT Create_c()
        {
            OBIT ret = new OBIT();
            //Write constraints
            ret.m_constraints.Add(new Func<long, bool>(delegate(long val) { return ((val>=4) && (val<=20)); }));
            m_children["c"].m_asn1Object = ret;
            return ret;
        }

        public MyStrStr strst
        {
            get { return m_children["strst"].m_asn1Object as MyStrStr; }
        }
        public MyStrStr Create_strst()
        {
            MyStrStr ret = new MyStrStr();
            //Write constraints
            ret.m_constraints.Add(new Func<string, bool>(delegate(string val) { return (val.Length == 4); }));
            m_children["strst"].m_asn1Object = ret;
            return ret;
        }

        public Asn1SequenceOfObject<Asn1IntegerObject> arr
        {
            get { return m_children["arr"].m_asn1Object as Asn1SequenceOfObject<Asn1IntegerObject>; }
        }
        public Asn1SequenceOfObject<Asn1IntegerObject> Create_arr()
        {
            Asn1SequenceOfObject<Asn1IntegerObject> ret = new Asn1SequenceOfObject<Asn1IntegerObject>();
            ret.m_child.createObj = new Func<Asn1IntegerObject>(delegate()
            {
                Asn1IntegerObject ch1 = new Asn1IntegerObject();
                //Write constraints
                ch1.m_constraints.Add(new Func<long, bool>(delegate(long val) { return ((val>=1) && (val<=10)); }));
                return ch1;
            });
            //Write constraints
            ret.m_constraints.Add(new Func<Asn1ArrayObject<Asn1IntegerObject>, bool>(delegate(Asn1ArrayObject<Asn1IntegerObject> val) { return ((val.m_children.Count>=1) && (val.m_children.Count<=20)); }));
            m_children["arr"].m_asn1Object = ret;
            return ret;
        }

        public Asn1SequenceOfObject<Asn1SequenceOfObject<Asn1IntegerObject>> arr2
        {
            get { return m_children["arr2"].m_asn1Object as Asn1SequenceOfObject<Asn1SequenceOfObject<Asn1IntegerObject>>; }
        }
        public Asn1SequenceOfObject<Asn1SequenceOfObject<Asn1IntegerObject>> Create_arr2()
        {
            Asn1SequenceOfObject<Asn1SequenceOfObject<Asn1IntegerObject>> ret = new Asn1SequenceOfObject<Asn1SequenceOfObject<Asn1IntegerObject>>();
            ret.m_child.createObj = new Func<Asn1SequenceOfObject<Asn1IntegerObject>>(delegate()
            {
                Asn1SequenceOfObject<Asn1IntegerObject> ch1 = new Asn1SequenceOfObject<Asn1IntegerObject>();
                ch1.m_child.createObj = new Func<Asn1IntegerObject>(delegate()
                {
                    Asn1IntegerObject ch2 = new Asn1IntegerObject();
                    //Write constraints
                    ch2.m_constraints.Add(new Func<long, bool>(delegate(long val) { return ((val>=1) && (val<=10)); }));
                    return ch2;
                });
                //Write constraints
                ch1.m_constraints.Add(new Func<Asn1ArrayObject<Asn1IntegerObject>, bool>(delegate(Asn1ArrayObject<Asn1IntegerObject> val) { return ((val.m_children.Count>=100) && (val.m_children.Count<=200)); }));
                return ch1;
            });
            //Write constraints
            ret.m_constraints.Add(new Func<Asn1ArrayObject<Asn1SequenceOfObject<Asn1IntegerObject>>, bool>(delegate(Asn1ArrayObject<Asn1SequenceOfObject<Asn1IntegerObject>> val) { return ((val.m_children.Count>=1) && (val.m_children.Count<=20)); }));
            m_children["arr2"].m_asn1Object = ret;
            return ret;
        }

        public class Inn : Asn1SequenceObject
        {

            public Asn1IntegerObject a
            {
                get { return m_children["a"].m_asn1Object as Asn1IntegerObject; }
            }
            public Asn1IntegerObject Create_a()
            {
                Asn1IntegerObject ret = new Asn1IntegerObject();
                //Write constraints
                m_children["a"].m_asn1Object = ret;
                return ret;
            }

            public Asn1IntegerObject b
            {
                get { return m_children["b"].m_asn1Object as Asn1IntegerObject; }
            }
            public Asn1IntegerObject Create_b()
            {
                Asn1IntegerObject ret = new Asn1IntegerObject();
                //Write constraints
                ret.m_constraints.Add(new Func<long, bool>(delegate(long val) { return ((val>=1) && (val<=10)); }));
                m_children["b"].m_asn1Object = ret;
                return ret;
            }

            public OBIT c
            {
                get { return m_children["c"].m_asn1Object as OBIT; }
            }
            public OBIT Create_c()
            {
                OBIT ret = new OBIT();
                //Write constraints
                ret.m_constraints.Add(new Func<long, bool>(delegate(long val) { return ((val>=4) && (val<=20)); }));
                m_children["c"].m_asn1Object = ret;
                return ret;
            }

            public MyStrStr strst
            {
                get { return m_children["strst"].m_asn1Object as MyStrStr; }
            }
            public MyStrStr Create_strst()
            {
                MyStrStr ret = new MyStrStr();
                //Write constraints
                ret.m_constraints.Add(new Func<string, bool>(delegate(string val) { return (val.Length == 4); }));
                m_children["strst"].m_asn1Object = ret;
                return ret;
            }

            public Asn1SequenceOfObject<Asn1IntegerObject> arr
            {
                get { return m_children["arr"].m_asn1Object as Asn1SequenceOfObject<Asn1IntegerObject>; }
            }
            public Asn1SequenceOfObject<Asn1IntegerObject> Create_arr()
            {
                Asn1SequenceOfObject<Asn1IntegerObject> ret = new Asn1SequenceOfObject<Asn1IntegerObject>();
                ret.m_child.createObj = new Func<Asn1IntegerObject>(delegate()
                {
                    Asn1IntegerObject ch1 = new Asn1IntegerObject();
                    //Write constraints
                    ch1.m_constraints.Add(new Func<long, bool>(delegate(long val) { return ((val>=1) && (val<=10)); }));
                    return ch1;
                });
                //Write constraints
                ret.m_constraints.Add(new Func<Asn1ArrayObject<Asn1IntegerObject>, bool>(delegate(Asn1ArrayObject<Asn1IntegerObject> val) { return ((val.m_children.Count>=1) && (val.m_children.Count<=20)); }));
                m_children["arr"].m_asn1Object = ret;
                return ret;
            }

            public Asn1SequenceOfObject<Asn1SequenceOfObject<Asn1IntegerObject>> arr2
            {
                get { return m_children["arr2"].m_asn1Object as Asn1SequenceOfObject<Asn1SequenceOfObject<Asn1IntegerObject>>; }
            }
            public Asn1SequenceOfObject<Asn1SequenceOfObject<Asn1IntegerObject>> Create_arr2()
            {
                Asn1SequenceOfObject<Asn1SequenceOfObject<Asn1IntegerObject>> ret = new Asn1SequenceOfObject<Asn1SequenceOfObject<Asn1IntegerObject>>();
                ret.m_child.createObj = new Func<Asn1SequenceOfObject<Asn1IntegerObject>>(delegate()
                {
                    Asn1SequenceOfObject<Asn1IntegerObject> ch1 = new Asn1SequenceOfObject<Asn1IntegerObject>();
                    ch1.m_child.createObj = new Func<Asn1IntegerObject>(delegate()
                    {
                        Asn1IntegerObject ch2 = new Asn1IntegerObject();
                        //Write constraints
                        ch2.m_constraints.Add(new Func<long, bool>(delegate(long val) { return ((val>=1) && (val<=10)); }));
                        return ch2;
                    });
                    //Write constraints
                    ch1.m_constraints.Add(new Func<Asn1ArrayObject<Asn1IntegerObject>, bool>(delegate(Asn1ArrayObject<Asn1IntegerObject> val) { return ((val.m_children.Count>=100) && (val.m_children.Count<=200)); }));
                    return ch1;
                });
                //Write constraints
                ret.m_constraints.Add(new Func<Asn1ArrayObject<Asn1SequenceOfObject<Asn1IntegerObject>>, bool>(delegate(Asn1ArrayObject<Asn1SequenceOfObject<Asn1IntegerObject>> val) { return ((val.m_children.Count>=1) && (val.m_children.Count<=20)); }));
                m_children["arr2"].m_asn1Object = ret;
                return ret;
            }
            public Inn()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("a", null, Create_a, false, null);
                m_children.Add("a", ch);
                ch = new OptionalNamedChild("b", null, Create_b, false, null);
                m_children.Add("b", ch);
                ch = new OptionalNamedChild("c", null, Create_c, false, null);
                m_children.Add("c", ch);
                ch = new OptionalNamedChild("strst", null, Create_strst, false, null);
                m_children.Add("strst", ch);
                ch = new OptionalNamedChild("arr", null, Create_arr, false, null);
                m_children.Add("arr", ch);
                ch = new OptionalNamedChild("arr2", null, Create_arr2, false, null);
                m_children.Add("arr2", ch);
            }
        }

        public Inn inn
        {
            get { return m_children["inn"].m_asn1Object as Inn; }
        }
        public Inn Create_inn()
        {
            Inn ret = new Inn();
            m_children["inn"].m_asn1Object = ret;
            return ret;
        }

        public MyEnum en1
        {
            get { return m_children["en1"].m_asn1Object as MyEnum; }
        }
        public MyEnum Create_en1()
        {
            MyEnum ret = new MyEnum();
            //Write constraints
            ret.m_constraints.Add(new Func<MyEnum.Enumerated, bool>(delegate(MyEnum.Enumerated val) { return ((val == MyEnum.Enumerated.red) || (val == MyEnum.Enumerated.green)); }));
            m_children["en1"].m_asn1Object = ret;
            return ret;
        }

        public class En2 : Asn1EnumeratedObject<En2.Enumerated>
        {
            public enum Enumerated
            {
                red = 0,
                green = 1,
                blue = 2,
            }
            public En2()
            {
                //Write constraints
                m_constraints.Add(new Func<En2.Enumerated, bool>(delegate(En2.Enumerated val) { return ((val == En2.Enumerated.red) || (val == En2.Enumerated.blue)); }));
            }
        }

        public En2 en2
        {
            get { return m_children["en2"].m_asn1Object as En2; }
        }
        public En2 Create_en2()
        {
            En2 ret = new En2();
            m_children["en2"].m_asn1Object = ret;
            return ret;
        }
        public MySeq()
        {
            OptionalNamedChild ch;
            ch = new OptionalNamedChild("a", null, Create_a, false, null);
            m_children.Add("a", ch);
            ch = new OptionalNamedChild("b", null, Create_b, false, null);
            m_children.Add("b", ch);
            ch = new OptionalNamedChild("c", null, Create_c, false, null);
            m_children.Add("c", ch);
            ch = new OptionalNamedChild("strst", null, Create_strst, false, null);
            m_children.Add("strst", ch);
            ch = new OptionalNamedChild("arr", null, Create_arr, false, null);
            m_children.Add("arr", ch);
            ch = new OptionalNamedChild("arr2", null, Create_arr2, false, null);
            m_children.Add("arr2", ch);
            ch = new OptionalNamedChild("inn", null, Create_inn, false, null);
            m_children.Add("inn", ch);
            ch = new OptionalNamedChild("en1", null, Create_en1, false, null);
            m_children.Add("en1", ch);
            ch = new OptionalNamedChild("en2", null, Create_en2, false, null);
            m_children.Add("en2", ch);
        }
    }

    public class MyCh : Asn1ChoiceObject
    {

        public Asn1IntegerObject a
        {
            get { return m_children["a"].m_asn1Object as Asn1IntegerObject; }
        }
        public Asn1IntegerObject Create_a()
        {
            Asn1IntegerObject ret = new Asn1IntegerObject();
            //Write constraints
            if (m_AlternativeName != string.Empty)
                m_children[m_AlternativeName].m_asn1Object = null;
            m_children["a"].m_asn1Object = ret;
            m_AlternativeName = "a";
            return ret;
        }

        public Asn1IntegerObject b
        {
            get { return m_children["b"].m_asn1Object as Asn1IntegerObject; }
        }
        public Asn1IntegerObject Create_b()
        {
            Asn1IntegerObject ret = new Asn1IntegerObject();
            //Write constraints
            ret.m_constraints.Add(new Func<long, bool>(delegate(long val) { return ((val>=1) && (val<=10)); }));
            if (m_AlternativeName != string.Empty)
                m_children[m_AlternativeName].m_asn1Object = null;
            m_children["b"].m_asn1Object = ret;
            m_AlternativeName = "b";
            return ret;
        }

        public OBIT c
        {
            get { return m_children["c"].m_asn1Object as OBIT; }
        }
        public OBIT Create_c()
        {
            OBIT ret = new OBIT();
            //Write constraints
            ret.m_constraints.Add(new Func<long, bool>(delegate(long val) { return ((val>=4) && (val<=20)); }));
            if (m_AlternativeName != string.Empty)
                m_children[m_AlternativeName].m_asn1Object = null;
            m_children["c"].m_asn1Object = ret;
            m_AlternativeName = "c";
            return ret;
        }

        public MyStrStr strst
        {
            get { return m_children["strst"].m_asn1Object as MyStrStr; }
        }
        public MyStrStr Create_strst()
        {
            MyStrStr ret = new MyStrStr();
            //Write constraints
            ret.m_constraints.Add(new Func<string, bool>(delegate(string val) { return (val.Length == 4); }));
            if (m_AlternativeName != string.Empty)
                m_children[m_AlternativeName].m_asn1Object = null;
            m_children["strst"].m_asn1Object = ret;
            m_AlternativeName = "strst";
            return ret;
        }

        public Asn1SequenceOfObject<Asn1IntegerObject> arr
        {
            get { return m_children["arr"].m_asn1Object as Asn1SequenceOfObject<Asn1IntegerObject>; }
        }
        public Asn1SequenceOfObject<Asn1IntegerObject> Create_arr()
        {
            Asn1SequenceOfObject<Asn1IntegerObject> ret = new Asn1SequenceOfObject<Asn1IntegerObject>();
            ret.m_child.createObj = new Func<Asn1IntegerObject>(delegate()
            {
                Asn1IntegerObject ch1 = new Asn1IntegerObject();
                //Write constraints
                ch1.m_constraints.Add(new Func<long, bool>(delegate(long val) { return ((val>=1) && (val<=10)); }));
                return ch1;
            });
            //Write constraints
            ret.m_constraints.Add(new Func<Asn1ArrayObject<Asn1IntegerObject>, bool>(delegate(Asn1ArrayObject<Asn1IntegerObject> val) { return ((val.m_children.Count>=1) && (val.m_children.Count<=20)); }));
            if (m_AlternativeName != string.Empty)
                m_children[m_AlternativeName].m_asn1Object = null;
            m_children["arr"].m_asn1Object = ret;
            m_AlternativeName = "arr";
            return ret;
        }

        public Asn1SequenceOfObject<Asn1SequenceOfObject<Asn1IntegerObject>> arr2
        {
            get { return m_children["arr2"].m_asn1Object as Asn1SequenceOfObject<Asn1SequenceOfObject<Asn1IntegerObject>>; }
        }
        public Asn1SequenceOfObject<Asn1SequenceOfObject<Asn1IntegerObject>> Create_arr2()
        {
            Asn1SequenceOfObject<Asn1SequenceOfObject<Asn1IntegerObject>> ret = new Asn1SequenceOfObject<Asn1SequenceOfObject<Asn1IntegerObject>>();
            ret.m_child.createObj = new Func<Asn1SequenceOfObject<Asn1IntegerObject>>(delegate()
            {
                Asn1SequenceOfObject<Asn1IntegerObject> ch1 = new Asn1SequenceOfObject<Asn1IntegerObject>();
                ch1.m_child.createObj = new Func<Asn1IntegerObject>(delegate()
                {
                    Asn1IntegerObject ch2 = new Asn1IntegerObject();
                    //Write constraints
                    ch2.m_constraints.Add(new Func<long, bool>(delegate(long val) { return ((val>=1) && (val<=10)); }));
                    return ch2;
                });
                //Write constraints
                ch1.m_constraints.Add(new Func<Asn1ArrayObject<Asn1IntegerObject>, bool>(delegate(Asn1ArrayObject<Asn1IntegerObject> val) { return ((val.m_children.Count>=100) && (val.m_children.Count<=200)); }));
                return ch1;
            });
            //Write constraints
            ret.m_constraints.Add(new Func<Asn1ArrayObject<Asn1SequenceOfObject<Asn1IntegerObject>>, bool>(delegate(Asn1ArrayObject<Asn1SequenceOfObject<Asn1IntegerObject>> val) { return ((val.m_children.Count>=1) && (val.m_children.Count<=20)); }));
            if (m_AlternativeName != string.Empty)
                m_children[m_AlternativeName].m_asn1Object = null;
            m_children["arr2"].m_asn1Object = ret;
            m_AlternativeName = "arr2";
            return ret;
        }

        public class Inn : Asn1SequenceObject
        {

            public Asn1IntegerObject a
            {
                get { return m_children["a"].m_asn1Object as Asn1IntegerObject; }
            }
            public Asn1IntegerObject Create_a()
            {
                Asn1IntegerObject ret = new Asn1IntegerObject();
                //Write constraints
                m_children["a"].m_asn1Object = ret;
                return ret;
            }

            public Asn1IntegerObject b
            {
                get { return m_children["b"].m_asn1Object as Asn1IntegerObject; }
            }
            public Asn1IntegerObject Create_b()
            {
                Asn1IntegerObject ret = new Asn1IntegerObject();
                //Write constraints
                ret.m_constraints.Add(new Func<long, bool>(delegate(long val) { return ((val>=1) && (val<=10)); }));
                m_children["b"].m_asn1Object = ret;
                return ret;
            }

            public OBIT c
            {
                get { return m_children["c"].m_asn1Object as OBIT; }
            }
            public OBIT Create_c()
            {
                OBIT ret = new OBIT();
                //Write constraints
                ret.m_constraints.Add(new Func<long, bool>(delegate(long val) { return ((val>=4) && (val<=20)); }));
                m_children["c"].m_asn1Object = ret;
                return ret;
            }

            public MyStrStr strst
            {
                get { return m_children["strst"].m_asn1Object as MyStrStr; }
            }
            public MyStrStr Create_strst()
            {
                MyStrStr ret = new MyStrStr();
                //Write constraints
                ret.m_constraints.Add(new Func<string, bool>(delegate(string val) { return (val.Length == 4); }));
                m_children["strst"].m_asn1Object = ret;
                return ret;
            }

            public Asn1SequenceOfObject<Asn1IntegerObject> arr
            {
                get { return m_children["arr"].m_asn1Object as Asn1SequenceOfObject<Asn1IntegerObject>; }
            }
            public Asn1SequenceOfObject<Asn1IntegerObject> Create_arr()
            {
                Asn1SequenceOfObject<Asn1IntegerObject> ret = new Asn1SequenceOfObject<Asn1IntegerObject>();
                ret.m_child.createObj = new Func<Asn1IntegerObject>(delegate()
                {
                    Asn1IntegerObject ch1 = new Asn1IntegerObject();
                    //Write constraints
                    ch1.m_constraints.Add(new Func<long, bool>(delegate(long val) { return ((val>=1) && (val<=10)); }));
                    return ch1;
                });
                //Write constraints
                ret.m_constraints.Add(new Func<Asn1ArrayObject<Asn1IntegerObject>, bool>(delegate(Asn1ArrayObject<Asn1IntegerObject> val) { return ((val.m_children.Count>=1) && (val.m_children.Count<=20)); }));
                m_children["arr"].m_asn1Object = ret;
                return ret;
            }

            public Asn1SequenceOfObject<Asn1SequenceOfObject<Asn1IntegerObject>> arr2
            {
                get { return m_children["arr2"].m_asn1Object as Asn1SequenceOfObject<Asn1SequenceOfObject<Asn1IntegerObject>>; }
            }
            public Asn1SequenceOfObject<Asn1SequenceOfObject<Asn1IntegerObject>> Create_arr2()
            {
                Asn1SequenceOfObject<Asn1SequenceOfObject<Asn1IntegerObject>> ret = new Asn1SequenceOfObject<Asn1SequenceOfObject<Asn1IntegerObject>>();
                ret.m_child.createObj = new Func<Asn1SequenceOfObject<Asn1IntegerObject>>(delegate()
                {
                    Asn1SequenceOfObject<Asn1IntegerObject> ch1 = new Asn1SequenceOfObject<Asn1IntegerObject>();
                    ch1.m_child.createObj = new Func<Asn1IntegerObject>(delegate()
                    {
                        Asn1IntegerObject ch2 = new Asn1IntegerObject();
                        //Write constraints
                        ch2.m_constraints.Add(new Func<long, bool>(delegate(long val) { return ((val>=1) && (val<=10)); }));
                        return ch2;
                    });
                    //Write constraints
                    ch1.m_constraints.Add(new Func<Asn1ArrayObject<Asn1IntegerObject>, bool>(delegate(Asn1ArrayObject<Asn1IntegerObject> val) { return ((val.m_children.Count>=100) && (val.m_children.Count<=200)); }));
                    return ch1;
                });
                //Write constraints
                ret.m_constraints.Add(new Func<Asn1ArrayObject<Asn1SequenceOfObject<Asn1IntegerObject>>, bool>(delegate(Asn1ArrayObject<Asn1SequenceOfObject<Asn1IntegerObject>> val) { return ((val.m_children.Count>=1) && (val.m_children.Count<=20)); }));
                m_children["arr2"].m_asn1Object = ret;
                return ret;
            }
            public Inn()
            {
                OptionalNamedChild ch;
                ch = new OptionalNamedChild("a", null, Create_a, false, null);
                m_children.Add("a", ch);
                ch = new OptionalNamedChild("b", null, Create_b, false, null);
                m_children.Add("b", ch);
                ch = new OptionalNamedChild("c", null, Create_c, false, null);
                m_children.Add("c", ch);
                ch = new OptionalNamedChild("strst", null, Create_strst, false, null);
                m_children.Add("strst", ch);
                ch = new OptionalNamedChild("arr", null, Create_arr, false, null);
                m_children.Add("arr", ch);
                ch = new OptionalNamedChild("arr2", null, Create_arr2, false, null);
                m_children.Add("arr2", ch);
            }
        }

        public Inn inn
        {
            get { return m_children["inn"].m_asn1Object as Inn; }
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
        public MyCh()
        {
            NamedChild ch;
            ch = new NamedChild("a", null, Create_a);
            m_children.Add("a", ch);
            ch = new NamedChild("b", null, Create_b);
            m_children.Add("b", ch);
            ch = new NamedChild("c", null, Create_c);
            m_children.Add("c", ch);
            ch = new NamedChild("strst", null, Create_strst);
            m_children.Add("strst", ch);
            ch = new NamedChild("arr", null, Create_arr);
            m_children.Add("arr", ch);
            ch = new NamedChild("arr2", null, Create_arr2);
            m_children.Add("arr2", ch);
            ch = new NamedChild("inn", null, Create_inn);
            m_children.Add("inn", ch);
        }
    }

    public class MySeqOF2 : Asn1SequenceOfObject<MySeq>
    {
        public MySeqOF2()
        {
            m_child.createObj = new Func<MySeq>(delegate()
            {
                MySeq ch1 = new MySeq();
                return ch1;
            });
            //Write constraints
            m_constraints.Add(new Func<Asn1ArrayObject<MySeq>, bool>(delegate(Asn1ArrayObject<MySeq> val) { return ((val.m_children.Count>=1) && (val.m_children.Count<=20)); }));
        }
    }

}
