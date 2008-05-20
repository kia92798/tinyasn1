using System;
using System.Collections.Generic;
using System.Text;
using tinyAsn1;

namespace asn1scc
{
    public static class CSSSequenceOrSetType
    {
        public static void PrintHTypeDeclaration(SequenceOrSetType pThis, PEREffectiveConstraint cns, StreamWriterLevel h, string typeName, string varName, int lev)
        {
            h.WriteLine("struct {");
            //            h.WriteLine("struct {0} {{", typeName);
            foreach (SequenceOrSetType.Child ch in pThis.m_children.Values)
            {
                h.WriteComment(ch.m_comments, lev + 1);
                h.P(lev + 1);
                ((ISCCType)ch.m_type).PrintHTypeDeclaration(ch.m_type.PEREffectiveConstraint, h,
                    typeName + "_" + C.ID(ch.m_childVarName), C.ID(ch.m_childVarName), lev + 1);
                if (!(ch.m_type is IA5StringType))
                    h.WriteLine(" {0};", C.ID(ch.m_childVarName));
            }
            if (pThis.GetNumberOfOptionalOrDefaultFields() != 0)
            {
                h.P(lev + 1);
                h.WriteLine("struct {");
                foreach (SequenceOrSetType.Child ch in pThis.m_children.Values)
                {
                    if (ch.m_optional || ch.m_defaultValue != null)
                    {
                        h.P(lev + 2);
                        h.WriteLine("unsigned int {0}:1;", C.ID(ch.m_childVarName));
                    }
                }
                h.P(lev + 1);
                h.WriteLine("} exist;");

            }
            h.P(lev);
            h.Write("}");
        }

        public static void PrintHConstraintConstant(SequenceOrSetType pThis, StreamWriterLevel h, string name)
        {
            CSSType.PrintHConstraintConstant(pThis, h, C.ID(name));
            foreach (SequenceOrSetType.Child ch in pThis.m_children.Values)
            {
                ((ISCCType)ch.m_type).PrintHConstraintConstant(h, C.ID(name) + "_" + C.ID(ch.m_childVarName));
            }
        }

        public static void VarsNeededForPrintCInitialize(SequenceOrSetType pThis, int lev, OrderedDictionary<string, CLocalVariable> existingVars)
        {
            foreach (SequenceOrSetType.Child ch in pThis.m_children.Values)
            {
                ((ISCCType)ch.m_type).VarsNeededForPrintCInitialize(lev, existingVars);
            }
        }

        public static void PrintCInitialize(SequenceOrSetType pThis, PEREffectiveConstraint cns, Asn1Value defauleVal, StreamWriterLevel c, string typeName, string varName, int lev, int arrayDepth)
        {
            bool topLevel = !varName.Contains("->");
            string prefix = "";
            if (topLevel)
                prefix = varName + "->";
            else
                prefix = varName + ".";

            foreach (SequenceOrSetType.Child ch in pThis.m_children.Values)
            {
                ((ISCCType)ch.m_type).PrintCInitialize(ch.m_type.PEREffectiveConstraint, ch.m_defaultValue, c,
                    typeName + "_" + C.ID(ch.m_childVarName), prefix + C.ID(ch.m_childVarName), lev, arrayDepth);
            }
        }

        public static void VarsNeededForIsConstraintValid(SequenceOrSetType pThis, int lev, OrderedDictionary<string, CLocalVariable> existingVars)
        {
            foreach (SequenceOrSetType.Child ch in pThis.m_children.Values)
            {
                ((ISCCType)ch.m_type).VarsNeededForIsConstraintValid(lev, existingVars);
            }
        }

        public static void PrintCIsConstraintValid(SequenceOrSetType pThis, PEREffectiveConstraint cns, StreamWriterLevel c, string errorCode, string typeName, string varName, int lev, int arrayDepth)
        {
            string varName2 = varName;
            if (!varName.Contains("->"))
                varName2 += "->";
            else
                varName2 += ".";

            foreach (SequenceOrSetType.Child ch in pThis.m_children.Values)
            {
                if (ch.m_optional || ch.m_default)
                {
                    c.P(lev);
                    c.WriteLine("if ( {0}exist.{1} ) {{", varName2, C.ID(ch.m_childVarName));

                    ((ISCCType)ch.m_type).PrintCIsConstraintValid(ch.m_type.PEREffectiveConstraint, c, errorCode + "_" + C.ID(ch.m_childVarName),
                        typeName + "_" + C.ID(ch.m_childVarName), varName2 + C.ID(ch.m_childVarName), lev + 1, arrayDepth);

                    c.P(lev); c.WriteLine("}");

                }
                else
                {
                    ((ISCCType)ch.m_type).PrintCIsConstraintValid(ch.m_type.PEREffectiveConstraint, c, errorCode + "_" + C.ID(ch.m_childVarName),
                        typeName + "_" + C.ID(ch.m_childVarName), varName2 + C.ID(ch.m_childVarName), lev, arrayDepth);
                }
                c.WriteLine();
            }
        }

        public static void VarsNeededForEncode(SequenceOrSetType pThis, PEREffectiveConstraint cns, int arrayDepth, OrderedDictionary<string, CLocalVariable> existingVars)
        {
            foreach (SequenceOrSetType.Child ch in pThis.m_children.Values)
            {
                ((ISCCType)ch.m_type).VarsNeededForEncode(ch.m_type.PEREffectiveConstraint, arrayDepth, existingVars);
            }
        }

        public static void PrintCEncode(SequenceOrSetType pThis, PEREffectiveConstraint cns, StreamWriterLevel c, string errorCode, string varName, int lev)
        {
            string varName2 = varName;
            if (!varName.Contains("->"))
                varName2 += "->";
            else
                varName2 += ".";
            if (pThis.GetNumberOfOptionalOrDefaultFields() > 0)
            {
                c.P(lev);
                c.WriteLine("/* Encode Bit Mask for optional and default fields*/");
            }

            foreach (SequenceOrSetType.Child ch in pThis.m_children.Values)
            {
                if (ch.m_optional || ch.m_default)
                {
                    c.P(lev);
                    c.WriteLine("BitStream_AppendBit(pBitStrm, {0});", varName2 + "exist." + C.ID(ch.m_childVarName));
                }
            }
            c.WriteLine();
            foreach (SequenceOrSetType.Child ch in pThis.m_children.Values)
            {
                c.P(lev); c.WriteLine("/*Encode {0} ({1})*/", ch.m_childVarName, ch.m_type.Name);
                if (ch.m_optional || ch.m_default)
                {
                    c.P(lev);
                    c.WriteLine("if ( {0}exist.{1} ) {{", varName2, C.ID(ch.m_childVarName));
                    ((ISCCType)ch.m_type).PrintCEncode(ch.m_type.PEREffectiveConstraint, c, errorCode + "_" + C.ID(ch.m_childVarName), varName2 + C.ID(ch.m_childVarName), lev + 1);
                    c.P(lev); c.WriteLine("}");

                }
                else
                    ((ISCCType)ch.m_type).PrintCEncode(ch.m_type.PEREffectiveConstraint, c, errorCode + "_" + C.ID(ch.m_childVarName), varName2 + C.ID(ch.m_childVarName), lev);
                c.WriteLine();
            }
        }

    }


    public class SCCSequenceOrSetTypeChild : SequenceOrSetType.Child
    {
        public SCCSequenceOrSetTypeChild() : base() { }

        public SCCSequenceOrSetTypeChild(SequenceOrSetType.Child o) : base(o) { }
    }

    public class SCCSequenceType : SequenceType, ISCCType
    {
        public void PrintHTypeDeclaration(PEREffectiveConstraint cns, StreamWriterLevel h, string typeName, string varName, int lev)
        {
            CSSSequenceOrSetType.PrintHTypeDeclaration(this, cns, h, typeName, varName, lev);
        }
        public void PrintHConstraintConstant(StreamWriterLevel h, string name)
        {
            CSSSequenceOrSetType.PrintHConstraintConstant(this, h, name);
        }
        public void VarsNeededForPrintCInitialize(int lev, OrderedDictionary<string, CLocalVariable> existingVars)
        {
            CSSSequenceOrSetType.VarsNeededForPrintCInitialize(this, lev, existingVars);
        }
        public void PrintCInitialize(PEREffectiveConstraint cns, Asn1Value defauleVal, StreamWriterLevel c, string typeName, string varName, int lev, int arrayDepth)
        {
            CSSSequenceOrSetType.PrintCInitialize(this, cns, defauleVal, c, typeName, varName, lev, arrayDepth);
        }
        public void VarsNeededForIsConstraintValid(int lev, OrderedDictionary<string, CLocalVariable> existingVars)
        {
            CSSSequenceOrSetType.VarsNeededForIsConstraintValid(this, lev, existingVars);
        }
        public void PrintCIsConstraintValid(PEREffectiveConstraint cns, StreamWriterLevel c, string errorCode, string typeName, string varName, int lev, int arrayDepth)
        {
            CSSSequenceOrSetType.PrintCIsConstraintValid(this, cns, c, errorCode, typeName, varName, lev, arrayDepth);
        }
        public void VarsNeededForEncode(PEREffectiveConstraint cns, int arrayDepth, OrderedDictionary<string, CLocalVariable> existingVars)
        {
            CSSSequenceOrSetType.VarsNeededForEncode(this, cns, arrayDepth, existingVars);
        }
        public void PrintCEncode(PEREffectiveConstraint cns, StreamWriterLevel c, string errorCode, string varName, int lev)
        {
            CSSSequenceOrSetType.PrintCEncode(this, cns, c, errorCode, varName, lev);
        }
    }

    public class SCCSetType : SetType, ISCCType
    {
        public void PrintHTypeDeclaration(PEREffectiveConstraint cns, StreamWriterLevel h, string typeName, string varName, int lev)
        {
            CSSSequenceOrSetType.PrintHTypeDeclaration(this, cns, h, typeName, varName, lev);
        }
        public void PrintHConstraintConstant(StreamWriterLevel h, string name)
        {
            CSSSequenceOrSetType.PrintHConstraintConstant(this, h, name);
        }
        public void VarsNeededForPrintCInitialize(int lev, OrderedDictionary<string, CLocalVariable> existingVars)
        {
            CSSSequenceOrSetType.VarsNeededForPrintCInitialize(this, lev, existingVars);
        }
        public void PrintCInitialize(PEREffectiveConstraint cns, Asn1Value defauleVal, StreamWriterLevel c, string typeName, string varName, int lev, int arrayDepth)
        {
            CSSSequenceOrSetType.PrintCInitialize(this, cns, defauleVal, c, typeName, varName, lev, arrayDepth);
        }
        public void VarsNeededForIsConstraintValid(int lev, OrderedDictionary<string, CLocalVariable> existingVars)
        {
            CSSSequenceOrSetType.VarsNeededForIsConstraintValid(this, lev, existingVars);
        }
        public void PrintCIsConstraintValid(PEREffectiveConstraint cns, StreamWriterLevel c, string errorCode, string typeName, string varName, int lev, int arrayDepth)
        {
            CSSSequenceOrSetType.PrintCIsConstraintValid(this, cns, c, errorCode, typeName, varName, lev, arrayDepth);
        }
        public void VarsNeededForEncode(PEREffectiveConstraint cns, int arrayDepth, OrderedDictionary<string, CLocalVariable> existingVars)
        {
            CSSSequenceOrSetType.VarsNeededForEncode(this, cns, arrayDepth, existingVars);
        }
        public void PrintCEncode(PEREffectiveConstraint cns, StreamWriterLevel c, string errorCode, string varName, int lev)
        {
            CSSSequenceOrSetType.PrintCEncode(this, cns, c, errorCode, varName, lev);
        }
    }


}
