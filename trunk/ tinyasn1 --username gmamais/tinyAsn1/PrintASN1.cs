using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace tinyAsn1
{
    public class PrintASN1 : IASTVisitor
    {
        TextWriter o;
        public PrintASN1(TextWriter outStream)
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
        }

        public void OnAfterTypeAssigment(Asn1File asn1File, Module mod, TypeAssigment tas)
        {
        }

        public void OnNullType(Asn1File asn1File, Module mod, NullType nullType, TypeAssigment tas)
        {
            
        }

        public void OnBitStringType(Asn1File asn1File, Module mod, BitStringType bsType, TypeAssigment tas)
        {
            if (bsType.m_namedBits.Count > 0)
            {
                o.WriteLine("\t" + tas.m_name + " ::=BIT STRING {");
                int cnt = bsType.m_namedBits.Count;
                for (int i = 0; i < bsType.m_namedBits.Count - 1; i++)
                {
                    o.WriteLine("\t\t" + bsType.m_namedBits.Keys[i] + "(" + bsType.m_namedBits.Values[i] + "),");
                }
                o.WriteLine("\t\t" + bsType.m_namedBits.Keys[cnt - 1] + "(" + bsType.m_namedBits.Values[cnt - 1] + ")");
                o.WriteLine("\t}");
            }
            else
                o.WriteLine("\t" + tas.m_name + " ::=BIT STRING");
            
        }

        public void OnBooleanType(Asn1File asn1File, Module mod, BooleanType boolType, TypeAssigment tas)
        {
            o.WriteLine("\t" + tas.m_name + " ::=BOOLEAN");
        }

        public void OnRealType(Asn1File asn1File, Module mod, RealType realType, TypeAssigment tas)
        {
            o.WriteLine("\t" + tas.m_name + " ::=REAL");
        }

        public void OnEnumeratedType(Asn1File asn1File, Module mod, EnumeratedType enumType, TypeAssigment tas)
        {
            if (enumType.m_enumValues.Count > 0)
            {
                o.WriteLine("\t" + tas.m_name + " ::=ENUMERATED {");
                int cnt = enumType.m_enumValues.Count;
                for (int i = 0; i < enumType.m_enumValues.Count - 1; i++)
                {
                    o.WriteLine("\t\t" + enumType.m_enumValues.Keys[i] + "(" + enumType.m_enumValues.Values[i].m_value + "),");
                }
                o.WriteLine("\t\t" + enumType.m_enumValues.Keys[cnt - 1] + "(" + enumType.m_enumValues.Values[cnt - 1].m_value + ")");
                o.WriteLine("\t}");
            }
            
        }

        public void OnIntegerType(Asn1File asn1File, Module mod, IntegerType intType, TypeAssigment tas)
        {
            if (intType.m_namedValues.Count > 0)
            {
                o.WriteLine("\t" + tas.m_name + " ::=INTEGER {");
                int cnt = intType.m_namedValues.Count;
                for (int i = 0; i < intType.m_namedValues.Count - 1; i++)
                {
                    o.WriteLine("\t\t" + intType.m_namedValues.Keys[i] + "(" + intType.m_namedValues.Values[i] + "),");
                }
                o.WriteLine("\t\t" + intType.m_namedValues.Keys[cnt - 1] + "(" + intType.m_namedValues.Values[cnt-1] + ")");
                o.WriteLine("\t}");
            } else
                o.WriteLine("\t" + tas.m_name + " ::=INTEGER");

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
            o.WriteLine("\t" + tas.m_name + " ::=OCTET STRING");
        }

        public void OnReferenceType(Asn1File asn1File, Module mod, ReferenceType refType, TypeAssigment tas)
        {
            o.WriteLine("\t" + tas.m_name + " ::= " + refType.Name);
        }



        public void OnValueAssigment(Asn1File asn1File, Module mod, ValueAssigment vas)
        {
            if (vas.m_value.m_TypeID == Asn1Value.TypeID.UNDEFINED)
            {
                Console.Error.WriteLine("Variable assigment '"+vas.m_name+"' is still in UNDEFINED state. It will be ignored");
                return;
            }
            o.WriteLine("\t" + vas.m_name + " " + vas.m_type.Name + " ::= " + vas.m_value.ToString());
        }

    }
}
