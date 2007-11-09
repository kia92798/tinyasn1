using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace tinyAsn1
{

    public partial class Asn1Type
    {
        public virtual void PrintAsn1(StreamWriterLevel o, int lev)
        {
            o.Write(Name);
        }
    }


    public partial class BitStringType
    {
        public override void PrintAsn1(StreamWriterLevel o, int lev)
        {
            if (m_namedBits.Count > 0)
            {
                o.WriteLine("BIT STRING {");
                int cnt = m_namedBits.Count;
                for (int i = 0; i < m_namedBits.Count - 1; i++)
                {
                    o.P(lev + 1);
                    o.WriteLine(m_namedBits.Keys[i] + "(" + m_namedBits.Values[i] + "),");
                }
                o.P(lev + 1);
                o.WriteLine(m_namedBits.Keys[cnt - 1] + "(" + m_namedBits.Values[cnt - 1] + ")");
                
                o.P(lev); o.Write("}");
            }
            else
                o.Write(" BIT STRING");
        }
    }

    public partial class EnumeratedType
    {
        public override void PrintAsn1(StreamWriterLevel o, int lev)
        {
            if (m_enumValues.Count > 0)
            {
                o.WriteLine("ENUMERATED {");
                int cnt = m_enumValues.Count;
                for (int i = 0; i < m_enumValues.Count - 1; i++)
                {
                    o.P(lev + 1);
                    o.WriteLine(m_enumValues.Keys[i] + "(" + m_enumValues.Values[i].m_value + "),");
                }
                o.P(lev + 1);
                o.WriteLine(m_enumValues.Keys[cnt - 1] + "(" + m_enumValues.Values[cnt - 1].m_value + ")");
                o.P(lev);
                o.Write("}");
            }
        }
    }

    public partial class IntegerType
    {
        public override void PrintAsn1(StreamWriterLevel o, int lev)
        {
            if (m_namedValues.Count > 0)
            {
                o.WriteLine("INTEGER {");
                int cnt = m_namedValues.Count;
                for (int i = 0; i < m_namedValues.Count - 1; i++)
                {
                    o.P(lev + 1);
                    o.WriteLine(m_namedValues.Keys[i] + "(" + m_namedValues.Values[i] + "),");
                }
                o.P(lev + 1);
                o.WriteLine(m_namedValues.Keys[cnt - 1] + "(" + m_namedValues.Values[cnt - 1] + ")");
                o.P(lev);
                o.Write("}");
            }
            else
                o.Write("INTEGER");
            if (m_AllowedValueSet != null)
            {
                o.Write(" ");
                o.Write(m_AllowedValueSet.ToString());
            }
        }
    }

    public partial class SequenceOrSetType : Asn1Type
    {
        public partial class Child
        {
            public void PrintAsn1(StreamWriterLevel o, int lev)
            {
                o.P(lev);
                o.Write(m_childVarName); o.Write(" ");
                m_type.PrintAsn1(o, lev);
                if (m_defaultValue!=null)
                {
                    o.Write(" DEFAULT "+m_defaultValue.ToString());
                }
                else if (m_optional)
                    o.Write(" OPTIONAL");

            }
        }

        public override void PrintAsn1(StreamWriterLevel o, int lev)
        {
            Child ch;
            o.WriteLine(Name + " {");
            for (int i = 0; i < m_children.Values.Count-1;i++ )
            {
                ch = m_children.Values[i];
                ch.PrintAsn1(o, lev + 1);
                o.WriteLine(",");
            }
            if (m_children.Values.Count > 0)
            {
                ch = m_children.Values[m_children.Values.Count-1];
                ch.PrintAsn1(o, lev + 1);
                o.WriteLine();
            }

            o.P(lev);
            o.Write("}");
        }
    }

    public partial class ChoiceType : Asn1Type
    {
        public partial class Child
        {
            public void PrintAsn1(StreamWriterLevel o, int lev)
            {
                o.P(lev);
                o.Write(m_childVarName); o.Write(" ");
                m_type.PrintAsn1(o, lev);
            }
        }

        public override void PrintAsn1(StreamWriterLevel o, int lev)
        {
            Child ch;
            o.WriteLine(Name + " {");
            for (int i = 0; i < m_children.Values.Count - 1; i++)
            {
                ch = m_children.Values[i];
                ch.PrintAsn1(o, lev + 1);
                o.WriteLine(",");
            }
            if (m_children.Values.Count > 0)
            {
                ch = m_children.Values[m_children.Values.Count - 1];
                ch.PrintAsn1(o, lev + 1);
                o.WriteLine();
            }

            o.P(lev);
            o.Write("}");
        }
    }


    public partial class SequenceOfType : Asn1Type
    {

        public override void PrintAsn1(StreamWriterLevel o, int lev)
        {
            o.Write("SEQUENCE OF ");
            m_type.PrintAsn1(o, lev);
        }
    }

    public partial class SetOfType : Asn1Type
    {

        public override void PrintAsn1(StreamWriterLevel o, int lev)
        {
            o.Write("SET OF ");
            m_type.PrintAsn1(o, lev);
        }
    }

    public class PrintASN1 : IASTVisitor
    {
        

        StreamWriterLevel o;
        public PrintASN1(StreamWriterLevel outStream)
        {
            o = outStream;
        }

        public void OnBeforeAsn1File(Asn1File asn1File)
        {
        }

        public void OnAfterAsn1File(Asn1File asn1File)
        {
        }

        public void OnBeforeModule(Asn1File asn1File, Module mod)
        {
            o.Write(mod.m_moduleID + " DEFINITIONS ");
            switch (mod.m_tags) {
                case Module.Tags.AUTOMATIC:
                    o.Write("AUTOMATIC TAGS ");
                    break;
                case Module.Tags.EXPLICIT:
                    o.Write(" EXPLICIT TAGS ");
                    break;
                case Module.Tags.IMPLICIT:
                    o.Write(" IMPLICIT TAGS ");
                    break;
            }
            if (mod.m_extensibilityImplied)
                o.Write(" EXTENSIBILITY IMPLIED ");

            o.WriteLine(" ::=");
            o.WriteLine("BEGIN");

            if ( mod.m_exportedTypes.Count > 0 || mod.m_exportedVariables.Count>0)
            {
                o.WriteLine("EXPORTS");
                List<string> export = new List<string>(mod.m_exportedTypes);
                export.AddRange(mod.m_exportedVariables);
                for (int i = 0; i < export.Count - 1;i++ )
                {
                    o.WriteLine("\t"+export[i] + ",");
                }
                o.WriteLine("\t" + export[export.Count-1] + ";");
            }


            
        }

        public void OnAfterModule(Asn1File asn1File, Module mod)
        {
            o.WriteLine("END");
        }

        public void OnBeforeTypeAssigment(Asn1File asn1File, Module mod, TypeAssigment tas)
        {
            o.P(1); o.Write(tas.m_name + " ::= "); tas.m_type.PrintAsn1(o, 1); o.WriteLine();
            o.WriteLine();

        }

        public void OnAfterTypeAssigment(Asn1File asn1File, Module mod, TypeAssigment tas)
        {
        }

        public void OnNullType(Asn1File asn1File, Module mod, NullType nullType, TypeAssigment tas)
        {
            
        }

        public void OnBitStringType(Asn1File asn1File, Module mod, BitStringType bsType, TypeAssigment tas)
        {
//            o.P(1); o.Write(tas.m_name + " ::= "); bsType.PrintAsn1(o, 1); o.WriteLine();
        }

        public void OnBooleanType(Asn1File asn1File, Module mod, BooleanType boolType, TypeAssigment tas)
        {
//            o.WriteLine("\t" + tas.m_name + " ::=BOOLEAN");
        }

        public void OnRealType(Asn1File asn1File, Module mod, RealType realType, TypeAssigment tas)
        {
//            o.WriteLine("\t" + tas.m_name + " ::=REAL");
        }

        public void OnEnumeratedType(Asn1File asn1File, Module mod, EnumeratedType enumType, TypeAssigment tas)
        {
            
        }

        public void OnIntegerType(Asn1File asn1File, Module mod, IntegerType intType, TypeAssigment tas)
        {

        }

        public void OnChoiceType(Asn1File asn1File, Module mod, ChoiceType choiceType, TypeAssigment tas)
        {
            
        }

        public void OnSequenceType(Asn1File asn1File, Module mod, SequenceType seqType, TypeAssigment tas)
        {
            
        }

        public void OnSetType(Asn1File asn1File, Module mod, SetType setType, TypeAssigment tas)
        {
            
        }

        public void OnSequenceOfType(Asn1File asn1File, Module mod, SequenceOfType sqOfType, TypeAssigment tas)
        {
            
        }

        public void OnSetOfType(Asn1File asn1File, Module mod, SetOfType setOfType, TypeAssigment tas)
        {
            
        }

        public void OnOctectStringType(Asn1File asn1File, Module mod, OctetStringType osType, TypeAssigment tas)
        {
//            o.WriteLine("\t" + tas.m_name + " ::=OCTET STRING");
        }

        public void OnReferenceType(Asn1File asn1File, Module mod, ReferenceType refType, TypeAssigment tas)
        {
//            o.WriteLine("\t" + tas.m_name + " ::= " + refType.Name);
        }



        public void OnValueAssigment(Asn1File asn1File, Module mod, ValueAssigment vas)
        {
            if (vas.m_value.m_TypeID == Asn1Value.TypeID.UNRESOLVED)
            {
                Console.Error.WriteLine("Variable assigment '"+vas.m_name+"' is still in UNDEFINED state. It will be ignored");
                return;
            }
            o.WriteLine("\t" + vas.m_name + " " + vas.m_type.Name + " ::= " + vas.m_value.ToString());
        }



        public bool Finished()
        {
            return true;
        }
        public int PassNo { get { return 1; }  }

    }
}
