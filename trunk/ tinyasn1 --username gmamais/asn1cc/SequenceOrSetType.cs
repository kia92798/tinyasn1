/**=============================================================================
Definition sequence and set ASN.1 types used in asn1scc project  
================================================================================
Copyright(c) Semantix Information Technologies S.A www.semantix.gr
All rights reserved.

This source code is only intended as a supplement to the
Semantix Technical Reference and related electronic documentation 
provided with the autoICD application.
See these sources for detailed information regarding the
autoICD application.
==============================================================================*/
using System;
using System.Collections.Generic;
using System.Text;
using tinyAsn1;
using semantix.util;

namespace asn1scc
{
    public static class CSSSequenceOrSetType
    {


        public static string CompareTo(SequenceOrSetType pThis, string varName, Asn1Value constValue)
        {
            string ret = string.Empty;

            string varName2 = varName;
            if (varName.Contains("->"))
                varName2 += ".";
            else
                varName2 += "->";

            ret += "(";

            SequenceOrSetValue val = constValue as SequenceOrSetValue;

            foreach (string id in val.m_children.Keys)
            {
                Asn1Value chVal = val.m_children[id];
                chVal.CName = val.CName + "." + id;
                INonPrimitiveCType chType = chVal.Type as INonPrimitiveCType;
                if (chType != null)
                    ret += chType.CompareTo(varName2 + id, chVal);
                else
                {
                    if (ret.EndsWith(")"))
                        ret += " && ";
                    ret += "(" + varName2+id + " == " + chVal.ToStringC() + ")";
                }
            }

            ret += ")";
            return ret;
        }


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

        public static void PrintCInitialize(SequenceOrSetType pThis, PEREffectiveConstraint cns, Asn1Value defaultValue, StreamWriterLevel c, string typeName, string varName, int lev, int arrayDepth)
        {
            bool topLevel = !varName.Contains("->");
            string prefix = "";
            if (topLevel)
                prefix = varName + "->";
            else
                prefix = varName + ".";

            SCCSequenceOrSetValue defVal = defaultValue as SCCSequenceOrSetValue;
            if (defVal == null)
            {
                foreach (SequenceOrSetType.Child ch in pThis.m_children.Values)
                {
                    ((ISCCType)ch.m_type).PrintCInitialize(ch.m_type.PEREffectiveConstraint, 
                        (ch.m_defaultValue!=null?ch.m_defaultValue:ch.m_type.GetOneValidValue()), 
                        c, typeName + "_" + C.ID(ch.m_childVarName), prefix + C.ID(ch.m_childVarName), lev, arrayDepth);
                }
            }
            else
            {
                foreach (string chName in defVal.m_children.Keys)
                {
                    Asn1Value chVal = defVal.m_children[chName];
                    chVal.CName = defVal.CName + "." + C.ID(chName);
                    Asn1Type chType = pThis.m_children[chName].m_type;
                    ((ISCCType)chType).PrintCInitialize(chType.PEREffectiveConstraint, chVal, c,
                        typeName + "_" + C.ID(chName), prefix + C.ID(chName), lev, arrayDepth);
                    
                }
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

            CSSType.PrintCIsConstraintValid(pThis, cns, c, errorCode, typeName, varName, lev, arrayDepth);

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

        public static void VarsNeededForDecode(SequenceOrSetType pThis, PEREffectiveConstraint cns, int arrayDepth, OrderedDictionary<string, CLocalVariable> existingVars)
        {

            int nBitMaskLength = (int)Math.Ceiling(pThis.GetNumberOfOptionalOrDefaultFields() / 8.0);
            if (nBitMaskLength > 0)
            {
                if (!existingVars.ContainsKey("bitMask"))
                    existingVars.Add("bitMask", new CLocalVariable("bitMask", "byte", nBitMaskLength, ""));
                else
                {
                    CLocalVariable lv = existingVars["bitMask"];
                    if (lv.arrayLen < nBitMaskLength)
                        lv.arrayLen = nBitMaskLength;
                }
            }

            foreach (SequenceOrSetType.Child ch in pThis.m_children.Values)
            {
                ((ISCCType)ch.m_type).VarsNeededForDecode(ch.m_type.PEREffectiveConstraint, arrayDepth, existingVars);
            }
        }

        public static void PrintCDecode(SequenceOrSetType pThis, PEREffectiveConstraint cns, StreamWriterLevel c, string varName, int lev)
        {
            string varName2 = varName;
            if (!varName.Contains("->"))
                varName2 += "->";
            else
                varName2 += ".";

            int nBitMaskLength = (int)Math.Ceiling(pThis.GetNumberOfOptionalOrDefaultFields() / 8.0);
            //c.P(lev); c.WriteLine("{"); lev++;
            c.P(lev);
            if (nBitMaskLength > 0)
            {
                //c.WriteLine("byte bitMask[{0}];", nBitMaskLength);
                //c.P(lev);
                c.WriteLine("if (!BitStream_ReadBits(pBitStrm, bitMask, {0})) {{", pThis.GetNumberOfOptionalOrDefaultFields());
                c.P(lev + 1);
                c.WriteLine("*pErrCode = ERR_INSUFFICIENT_DATA;");
                c.P(lev + 1);
                c.WriteLine("return FALSE;");
                c.P(lev);
                c.WriteLine("}");
            }

            int currentByte = 0;
            int currentBit = 0;
            foreach (SequenceOrSetType.Child ch in pThis.m_children.Values)
            {
                c.P(lev); c.WriteLine("/*Decode {0} ({1})*/", ch.m_childVarName, ch.m_type.Name);
                if (ch.m_optional || ch.m_default)
                {
                    byte cb = 0x80;
                    c.P(lev);
                    c.WriteLine("{0}exist.{1} = 0;", varName2, C.ID(ch.m_childVarName));

                    c.P(lev);
                    c.WriteLine("if ((bitMask[{0}] & 0x{1:X2}) != 0 ) {{", currentByte, (cb >> currentBit));

                    c.P(lev + 1);
                    c.WriteLine("{0}exist.{1} = 1;", varName2, C.ID(ch.m_childVarName));


                    ((ISCCType)ch.m_type).PrintCDecode(ch.m_type.PEREffectiveConstraint, c, varName2 + C.ID(ch.m_childVarName), lev + 1);
                    c.P(lev); c.WriteLine("}");
                    if (ch.m_defaultValue != null)
                    {
                        c.P(lev); c.WriteLine("else");
                        c.P(lev); c.WriteLine("{");

                        c.P(lev + 1);
                        c.WriteLine("{0}exist.{1} = 1;", varName2, C.ID(ch.m_childVarName));

                        ((ISCCType)ch.m_type).PrintCInitialize(ch.m_type.PEREffectiveConstraint, ch.m_defaultValue, c, "", varName2 + C.ID(ch.m_childVarName), lev + 1, CLocalVariable.GetArrayIndex(varName) + 1);
                        c.P(lev); c.WriteLine("}");
                    }


                    currentBit++;
                    if (currentBit == 8)
                    {
                        currentBit = 0;
                        currentByte++;
                    }
                }
                else
                {
                    ((ISCCType)ch.m_type).PrintCDecode(ch.m_type.PEREffectiveConstraint, c, varName2 + C.ID(ch.m_childVarName), lev);
                }
            }
            //lev--; c.P(lev); c.WriteLine("}"); 
        }

    }


    public class SCCSequenceOrSetTypeChild : SequenceOrSetType.Child
    {
        public SCCSequenceOrSetTypeChild() : base() { }

        public SCCSequenceOrSetTypeChild(SequenceOrSetType.Child o) : base(o) { }
    }

    public class SCCSequenceType : SequenceType, ISCCType, INonPrimitiveCType
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
        public void VarsNeededForDecode(PEREffectiveConstraint cns, int arrayDepth, OrderedDictionary<string, CLocalVariable> existingVars)
        {
            CSSSequenceOrSetType.VarsNeededForDecode(this, cns, arrayDepth, existingVars);
        }
        public void PrintCDecode(PEREffectiveConstraint cns, StreamWriterLevel c, string varName, int lev)
        {
            CSSSequenceOrSetType.PrintCDecode(this, cns, c, varName, lev);
        }



        public string CompareTo(string varName, Asn1Value constValue)
        {
            return CSSSequenceOrSetType.CompareTo(this, varName, constValue);
        }


    }

    public class SCCSetType : SetType, ISCCType, INonPrimitiveCType
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
        public void VarsNeededForDecode(PEREffectiveConstraint cns, int arrayDepth, OrderedDictionary<string, CLocalVariable> existingVars)
        {
            CSSSequenceOrSetType.VarsNeededForDecode(this, cns, arrayDepth, existingVars);
        }
        public void PrintCDecode(PEREffectiveConstraint cns, StreamWriterLevel c, string varName, int lev)
        {
            CSSSequenceOrSetType.PrintCDecode(this, cns, c, varName, lev);
        }

        public string CompareTo(string varName, Asn1Value constValue)
        {
            return CSSSequenceOrSetType.CompareTo(this, varName, constValue);
        }
    }


}
