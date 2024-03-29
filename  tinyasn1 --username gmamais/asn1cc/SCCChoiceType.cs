﻿/**=============================================================================
Definition SCCChoiceType class used in asn1scc project  
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
    class SCCChoiceType : ChoiceType, ISCCType, INonPrimitiveCType
    {
        public void PrintHTypeDeclaration(PEREffectiveConstraint cns, StreamWriterLevel h, string typeName, string varName, int lev)
        {
            //            h.WriteLine("struct {0} {{", typeName);
            h.WriteLine("struct {");
            h.P(lev + 1);
            h.WriteLine("enum {");
            //            h.WriteLine("enum {0}_PR {{", typeName);
            h.P(lev + 2);
            h.WriteLine("{0},	/* No components present */", CID_NONE);
            //            h.WriteLine("{0}_NONE,	/* No components present */", typeName);
            int i = 0;
            foreach (ChoiceChild ch in m_children.Values)
            {
                h.P(lev + 2);
                //                h.Write("{0}_{1}", typeName, ch.m_childVarName);
                h.Write("{0}", ch.CID);
                if (i < m_children.Values.Count - 1)
                    h.WriteLine(",");
                else
                    h.WriteLine();
                i++;
            }
            h.P(lev + 1);
            h.WriteLine("} kind;");


            h.P(lev + 1);
            h.WriteLine("union {");
            //            h.WriteLine("union {0}_data {{", typeName);
            foreach (ChoiceChild ch in m_children.Values)
            {
                h.WriteComment(ch.m_comments, lev + 2);

                h.P(lev + 2);
                ((ISCCType)ch.m_type).PrintHTypeDeclaration(ch.m_type.PEREffectiveConstraint, h,
                    typeName + "_" + C.ID(ch.m_childVarName),
                    C.ID(ch.m_childVarName), lev + 1);
                if (!(ch.m_type is IA5StringType))
                    h.WriteLine(" {0};", C.ID(ch.m_childVarName));
            }
            h.P(lev + 1);
            h.WriteLine("} u;");


            h.P(lev);
            h.Write("}");
        }

        public void PrintHConstraintConstant(StreamWriterLevel h, string name)
        {
            h.WriteLine("#define ERR_{0}\t\t{1} /* {2} */", C.ID(name), DefaultBackend.Instance.ConstraintErrorID++, Constraints);
            foreach (ChoiceChild ch in m_children.Values)
            {
                ((ISCCType)ch.m_type).PrintHConstraintConstant(h, C.ID(name) + "_" + C.ID(ch.m_childVarName));
            }
        }
        public void VarsNeededForPrintCInitialize(int arrayDepth, OrderedDictionary<string, CLocalVariable> existingVars)
        {
        }
        public void PrintCInitialize(PEREffectiveConstraint cns, Asn1Value defaultValue, StreamWriterLevel c, string typeName, string varName, int lev, int arrayDepth)
        {
            bool topLevel = !varName.Contains("->");
            string prefix = "";
            if (topLevel)
                prefix = varName + "->";
            else
                prefix = varName + ".";

            ChoiceValue chVal = defaultValue as ChoiceValue;
            if (chVal == null)
            {
                c.P(lev); c.WriteLine("{0}kind = {1};", prefix, CID_NONE);
            }
            else
            {
                Asn1Type altType = ((ChoiceType)chVal.Type).m_children[chVal.AlternativeName].m_type;
                c.P(lev); c.WriteLine("{0}kind = {1};", prefix, ((ChoiceType)chVal.Type).m_children[chVal.AlternativeName].CID);
                c.P(lev); c.WriteLine("{");
                ((ISCCType)altType).PrintCInitialize(altType.PEREffectiveConstraint, chVal.Value, c,
                    typeName + "_" + C.ID(chVal.AlternativeName), prefix + "u." + C.ID(chVal.AlternativeName), lev + 1, arrayDepth + 1);
                c.P(lev); c.WriteLine("}");
            }
            //            c.P(lev); c.WriteLine("{0}kind = {1}_NONE;", prefix, typeName);
        }
        public void VarsNeededForIsConstraintValid(int lev, OrderedDictionary<string, CLocalVariable> existingVars)
        {
            foreach (ChoiceChild ch in m_children.Values)
            {
                ((ISCCType)ch.m_type).VarsNeededForIsConstraintValid(lev, existingVars);
            }
        }

        public string CompareTo(string varName, Asn1Value constValue)
        {
            string ret = string.Empty;

            string varName2 = varName;
            if (varName.Contains("->"))
                varName2 += ".";
            else
                varName2 += "->";

            ret += "(";

            ChoiceValue val = constValue as ChoiceValue;

            Asn1Value chVal = val.Value;
            chVal.CName = val.CName + "." + val.AlternativeName;
            INonPrimitiveCType chType = chVal.Type as INonPrimitiveCType;

            ret += "(" +  varName2+"kind == " + m_children[val.AlternativeName].CID + ") && ";

            
            if (chType != null)
                ret += chType.CompareTo(varName2 + "u." + C.ID(val.AlternativeName), chVal);
            else
            {
                ret += "(" + varName2 + "u." + C.ID(val.AlternativeName) + " == " + chVal.ToStringC() + ")";
            }

            ret += ")";
            return ret;
        }

        public void PrintCIsConstraintValid(PEREffectiveConstraint cns, StreamWriterLevel c, string errorCode, string typeName, string varName, int lev, int arrayDepth)
        {
            string varName2 = varName;
            if (!varName.Contains("->"))
                varName2 += "->";
            else
                varName2 += ".";

            CSSType.PrintCIsConstraintValid(this, cns, c, errorCode, typeName, varName, lev, arrayDepth);


            c.P(lev);
            c.WriteLine("switch({0}kind)", varName2);
            c.P(lev); c.WriteLine("{");
            foreach (ChoiceChild ch in m_children.Values)
            {
                //                c.P(lev); c.WriteLine("case {0}_{1}:", typeName, ch.m_childVarName);
                c.P(lev); c.WriteLine("case {0}:", ch.CID);
                ((ISCCType)ch.m_type).PrintCIsConstraintValid(ch.m_type.PEREffectiveConstraint, c, errorCode + "_" + ch.m_childVarName,
                    typeName + "_" + C.ID(ch.m_childVarName), varName2 + "u." + C.ID(ch.m_childVarName), lev + 1, arrayDepth);
                c.P(lev + 1);
                c.WriteLine("break;");
            }
            c.P(lev);
            c.WriteLine("default:");
            c.P(lev + 1);
            c.WriteLine("*pErrCode = ERR_{0};", C.ID(errorCode));
            c.P(lev + 1);
            c.WriteLine("return FALSE;");
            c.P(lev); c.WriteLine("}");

        }
        public void VarsNeededForEncode(PEREffectiveConstraint cns, int arrayDepth, OrderedDictionary<string, CLocalVariable> existingVars)
        {
            foreach (ChoiceChild ch in m_children.Values)
            {
                ((ISCCType)ch.m_type).VarsNeededForEncode(ch.m_type.PEREffectiveConstraint, arrayDepth, existingVars);
            }
        }
        public void PrintCEncode(PEREffectiveConstraint cns, StreamWriterLevel c, string errorCode, string varName, int lev)
        {
            int largestIndex = -1;
            foreach (string v in m_children.Keys)
            {
                if (m_children[v].m_extended)
                    continue;
                largestIndex++;
            }

            string varName2 = varName;
            if (!varName.Contains("->"))
                varName2 += "->";
            else
                varName2 += ".";

            c.P(lev);
            c.WriteLine("switch({0}kind)", varName2);
            c.P(lev); c.WriteLine("{");
            int choiceIndex = 0;
            foreach (ChoiceChild ch in m_children.Values)
            {
                c.P(lev); c.WriteLine("case {0}:", ch.CID);
                c.P(lev + 1);
                c.WriteLine("BitStream_EncodeConstraintWholeNumber(pBitStrm, {0}, {1}, {2});", choiceIndex, 0, largestIndex);
                ((ISCCType)ch.m_type).PrintCEncode(ch.m_type.PEREffectiveConstraint, c, errorCode + "_" + ch.m_childVarName,
                    varName2 + "u." + C.ID(ch.m_childVarName), lev + 1);

                c.P(lev + 1);
                c.WriteLine("break;");
                choiceIndex++;
            }
            c.P(lev);
            c.WriteLine("default:");
            c.P(lev + 1);
            c.WriteLine("*pErrCode = ERR_INVALID_CHOICE_ALTERNATIVE;");
            c.P(lev + 1);
            c.WriteLine("return FALSE;");

            c.P(lev); c.WriteLine("}");
        }
        public void VarsNeededForDecode(PEREffectiveConstraint cns, int arrayDepth, OrderedDictionary<string, CLocalVariable> existingVars)
        {
            if (!existingVars.ContainsKey("nChoiceIndex"))
                existingVars.Add("nChoiceIndex", new CLocalVariable("nChoiceIndex", "asn1SccSint", 0, "0"));
            foreach (ChoiceChild ch in m_children.Values)
            {
                ((ISCCType)ch.m_type).VarsNeededForDecode(ch.m_type.PEREffectiveConstraint, arrayDepth, existingVars);
            }
        }
        public void PrintCDecode(PEREffectiveConstraint cns, StreamWriterLevel c, string varName, int lev)
        {
            string varName2 = varName;
            if (!varName.Contains("->"))
                varName2 += "->";
            else
                varName2 += ".";

            int largestIndex = -1;
            foreach (string v in m_children.Keys)
            {
                if (m_children[v].m_extended)
                    continue;
                largestIndex++;
            }


            c.P(lev);
            c.WriteLine("if (!BitStream_DecodeConstraintWholeNumber(pBitStrm, &nChoiceIndex, {0}, {1})) {{", 0, largestIndex);
            c.P(lev + 1);
            c.WriteLine("*pErrCode = ERR_INSUFFICIENT_DATA;");
            c.P(lev + 1);
            c.WriteLine("return FALSE;");
            c.P(lev);
            c.WriteLine("}");
            c.P(lev);
            c.WriteLine("switch(nChoiceIndex)");
            c.P(lev); c.WriteLine("{");
            int choiceIndex = 0;
            foreach (ChoiceChild ch in m_children.Values)
            {
                c.P(lev); c.WriteLine("case {0}:", choiceIndex);
                ((ISCCType)ch.m_type).PrintCDecode(ch.m_type.PEREffectiveConstraint, c,
                    varName2 + "u." + C.ID(ch.m_childVarName), lev + 1);


                c.P(lev + 1);
                c.WriteLine("{0}kind = {1};", varName2, ch.CID);
                c.P(lev + 1);
                c.WriteLine("break;");
                choiceIndex++;
            }
            c.P(lev); c.WriteLine("}");

        }

    
    }

    public class SCCChoiceChild : ChoiceChild
    {
    }
}
