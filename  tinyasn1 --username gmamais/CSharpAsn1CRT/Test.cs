using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CSharpAsn1CRT
{


    /*
     *   MyInt ::= [APPLICATION 100] INTEGER(1..10 | 100)
     */

    /*
     * Integer constructor has two things: (a) calls to m_constraints and calls to m_Tags
     */

    public class MyInt : Asn1IntegerObject
    {
        public MyInt()
        {
            m_constraints.Add(new Func<long, bool>(delegate(long n) { return (n >= 1 && n <= 10) || n==100; }));

//Explicit            
            m_Tags.Add(new Tag(100, TagClass.APPLICATION));
//implicit
//            m_Tags.Clear();
//            m_Tags.Add(new Tag(100, TagClass.APPLICATION);

        }
    }


    /*
     *  MyInt2 ::= [APPLICATION 101] MyInt(1..5)
     
     A reference type constructor (for an Int) has also calls to m_constraints and to m_Tags 
     
     
     */

    public class MyInt2 : MyInt
    {
        public MyInt2()
        {
            m_constraints.Add(new Func<long, bool>(delegate(long n) { return (n >= 1 && n <= 5); }));

            //Explicit            
            m_Tags.Add(new Tag(101, TagClass.APPLICATION));
            //implicit
            //            m_Tags.Clear();
            //            m_Tags.Add(new Tag(101, TagClass.APPLICATION);

        }
    }


    /*
     * MyStr ::= IA5String (SIZE(1..10))(FROM("A".."Z"|"a".."z"))
     */

    public class MyStr : Asn1IA5StringObject
    {
        public MyStr()
        {
            m_constraints.Add(new Func<string, bool>(delegate(string v)
            {
                return v.Length >= 1 && v.Length <= 10;
            }));

            m_constraints.Add(new Func<string, bool>(delegate(string v)
            {
                foreach (Char ch in v.ToCharArray())
                    if (!((ch >= 'A' && ch <= 'Z') || (ch >= 'a' && ch <= 'z')))
                        return false;
                return true;
            }));
        }
    }


    /*
         * 
         *  TEST
         * 
         MySeq ::= SEQUENCE {
            a [APPLICATION 100] INTEGER (1..10) OPTIONAL,
            b [APPLICATION 100] REAL
         }
     
         */

    public class MySeq : Asn1SequenceObject
    {


        public Asn1IntegerObject a
        {
            get { return m_children["a"].m_asn1Object as Asn1IntegerObject; }
        }
        
        public Asn1IntegerObject Create_a()
        {
            Asn1IntegerObject a = new Asn1IntegerObject();
            //The code that follows is the same that would be produced if that child was a reference type to a type INTEGER(1..10)

            //set constraints
            a.m_constraints.Add(new Func<long, bool>(delegate(long n) { return n >= 1 && n <= 10; }));

            //set Tags
            //for explicit
            a.m_Tags.Add(new Tag(100, TagClass.APPLICATION));

            //for implicit
            a.m_Tags.Clear();
            a.m_Tags.Add(new Tag(100, TagClass.APPLICATION));
            return a;
        }


        Asn1RealObject b
        {
            get { return m_children["b"].m_asn1Object as Asn1RealObject; }
        }

        public static Asn1RealObject Create_b()
        {
            return new Asn1RealObject();
        }


        public MySeq()
        {
            OptionalNamedChild ch =  new OptionalNamedChild("a", null, Create_a, true, null);
            //for explicit
            ch.AddTagList(new Tag(100, TagClass.APPLICATION), new Tag(7, TagClass.UNIVERSAL));
            //for implicit
            //ch.AddTagList(new Tag(100, TagClass.APPLICATION));
            m_children.Add("a", ch);



            
            //m_children.Add("b", new OptionalNamedChild("b", null, Create_b));
        }


        public override bool IsConstraintValid()
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }


    public class Test
    {

        void foo()
        {
            System.Collections.BitArray a = new System.Collections.BitArray(10);


        }
    }


    /*
     *  Example
     * Enum2 ::= ENUMERATED { ffd(4), ddd(5) } (ffd)
        Code Template for enums
    
    */
    public class Enum2 : Asn1EnumeratedObject<Enum2.EnumValues>
    {
        public enum EnumValues
        {
            ffd = 4,
            ddd = 5,
        }
        
        public Enum2() 
        {
            Value = EnumValues.ffd;
            m_constraints.Add(new Func<EnumValues, bool>(delegate(EnumValues val) { return val == EnumValues.ffd; }));
        }

    }


    /*
      Example
        AAA::= SEQUENCE (SIZE(1..20)) OF INTEGER(2..8)

    */
    public class AAA : Asn1SequenceOfObject<Asn1IntegerObject>
    {

        public AAA()
        {
            m_child.createObj = new Func<Asn1IntegerObject>(delegate()
            {
                Asn1IntegerObject a = new Asn1IntegerObject();
                //The code that follows is the same that would be produced if that child was a reference type to a type INTEGER(1..10)

                //set constraints
                a.m_constraints.Add(new Func<long, bool>(delegate(long n) { return n >= 2 && n <= 8; }));

                //set Tags
                return a;
            });
            
            //Implicit
            m_child.AddTagList(new Tag(100, TagClass.APPLICATION), new Tag(7, TagClass.UNIVERSAL));

            m_constraints.Add(new Func<Asn1ArrayObject<Asn1IntegerObject>, bool>(delegate(Asn1ArrayObject<Asn1IntegerObject> val) { return val.m_children.Count >= 1 && val.m_children.Count >= 20; }));
        }
    }


    /*
     * MySeq2 ::= SEQUENCE {
     *      a1 SEQUENCE (SIZE(1..20)) OF INTEGER(2..8),
     *      b1 REAL
     *      c1 SEQUENCE (SIZE(1..20)) OF SEQUENCE (SIZE(50..60)) OF INTEGER(2..8),
     * }
     */

    public class MySeq2 : Asn1SequenceObject
    {
        Asn1SequenceOfObject<Asn1IntegerObject> Create_a1()
        {
            Asn1SequenceOfObject<Asn1IntegerObject> a = new Asn1SequenceOfObject<Asn1IntegerObject>();
            
            a.m_child.createObj = new Func<Asn1IntegerObject>(delegate()
            {
                Asn1IntegerObject a1 = new Asn1IntegerObject();
                //The code that follows is the same that would be produced if that child was a reference type to a type INTEGER(1..10)

                //set constraints
                a1.m_constraints.Add(new Func<long, bool>(delegate(long n) { return n >= 2 && n <= 8; }));

                //set Tags
                return a1;
            });


            a.m_constraints.Add(new Func<Asn1ArrayObject<Asn1IntegerObject>, bool>(delegate(Asn1ArrayObject<Asn1IntegerObject> val)
            {
                return val.m_children.Count >= 1 && val.m_children.Count <= 20;
            }));

            return a;
        }

        Asn1SequenceOfObject<Asn1SequenceOfObject<Asn1IntegerObject>> Create_c1()
        {
            Asn1SequenceOfObject<Asn1SequenceOfObject<Asn1IntegerObject>> a1 = new Asn1SequenceOfObject<Asn1SequenceOfObject<Asn1IntegerObject>>();

            a1.m_child.createObj = new Func<Asn1SequenceOfObject<Asn1IntegerObject>>(delegate()
            {
                Asn1SequenceOfObject<Asn1IntegerObject> a2 = new Asn1SequenceOfObject<Asn1IntegerObject>();

                a2.m_child.createObj = new Func<Asn1IntegerObject>(delegate()
                {
                    Asn1IntegerObject a3 = new Asn1IntegerObject();
                    a3.m_constraints.Add(new Func<long, bool>(delegate(long val)
                    {
                        return val >= 2 && val <= 8;
                    }));
                    return a3;
                });
                a2.m_constraints.Add(new Func<Asn1ArrayObject<Asn1IntegerObject>, bool>(delegate(Asn1ArrayObject<Asn1IntegerObject> val)
                {
                    return val.m_children.Count>=50 && val.m_children.Count<=60;
                }));
                return a2;
            });

            a1.m_constraints.Add(new Func<Asn1ArrayObject<Asn1SequenceOfObject<Asn1IntegerObject>>,bool>(delegate(Asn1ArrayObject<Asn1SequenceOfObject<Asn1IntegerObject>> val)
            {
                return val.m_children.Count >= 1 && val.m_children.Count >= 20;
            }));

            return a1;
        }
    }



    /* Cmplx1 ::= SEQUENCE {
     *      a SEQUENCE (SIZE(1..20)) OF SEQUENCE {
     *          a1      INTEGER,
     *          b1      INTEGER
     *      }
     * }
     */
    
    public class Cmplx1 : Asn1SequenceObject
    {
        public class A : Asn1SequenceOfObject<A.InternalType>
        {
            public class InternalType : Asn1SequenceObject
            {
            }
        }

    }

    /* Cmplx2 ::= SEQUENCE {
     *      a SEQUENCE (SIZE(1..100) OF SEQUENCE (SIZE(1..20)) OF SEQUENCE {
     *          a1      INTEGER,
     *          b1      INTEGER
     *      }
     * }
     * 
     */


    public class Cmplx2 : Asn1SequenceObject
    {
        public class A : Asn1SequenceOfObject<A.InternalType>
        {
            public class InternalType : Asn1SequenceOfObject<InternalType.InternalType2>
            {
                public class InternalType2 : Asn1SequenceObject
                {
                }
            }
        }

    }
    







}