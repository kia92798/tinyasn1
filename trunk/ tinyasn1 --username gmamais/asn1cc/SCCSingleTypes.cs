/**=============================================================================
Definition primitive ASN.1 types used in asn1scc project  
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
using Antlr.Runtime.Tree;
using Antlr.Runtime;
using tinyAsn1;
using System.IO;

namespace asn1scc
{

    //public interface WriteSingleConstraintCode
    //{
    //    string WriteCode(string varName, int lev, Asn1Value constValue);
    //}

    public interface INonPrimitiveCType
    {
        string CompareTo(string varName, Asn1Value constValue);
        string AssignTo(string varName, Asn1Value constValue, int lev);
    }

    public class SCCBitStringType : BitStringType, ISCCType, INonPrimitiveCType
    {
        public void PrintHTypeDeclaration(PEREffectiveConstraint cns, StreamWriterLevel h, string typeName, string varName, int lev)
        {
            lev++;
            long max = (long)Math.Ceiling((double)maxItems(cns) / 8.0);
            h.WriteLine("struct {");
            h.P(lev + 1);
            h.WriteLine("long nCount; /*Number of bits in the array. Max value is : {0} */", maxItems(cns));
            h.P(lev + 1); h.WriteLine("byte arr[{0}];", max);
            h.P(lev);
            h.Write("}");
        }
        public void PrintHConstraintConstant(StreamWriterLevel h, string name)
        {
            CSSType.PrintHConstraintConstant(this, h, name);
        }
        public void VarsNeededForPrintCInitialize(int arrayDepth, OrderedDictionary<string, CLocalVariable> existingVars)
        {

        }
        public void PrintCInitialize(PEREffectiveConstraint cns, Asn1Value defaultValue, StreamWriterLevel c, string typeName, string varName, int lev, int arrayDepth)
        {
            long max = (long)Math.Ceiling((double)maxItems(cns) / 8.0);
            string i = "i" + lev.ToString();
            string prefix = "";
            bool topLevel = !varName.Contains("->");
            if (topLevel)
                prefix = varName + "->";
            else
                prefix = varName + ".";

            
            BitStringValue defVal = defaultValue as BitStringValue;
            if (defVal != null)
            {
                c.P(lev); c.WriteLine("{0}nCount = {1};", prefix, defVal.Value.Length);
                c.P(lev); c.WriteLine("memcpy({0}arr,{1}.arr,{2});", prefix, defVal.CName, (long)Math.Ceiling((double)defVal.Value.Length / 8.0));
            }
            else
            {
                c.P(lev); c.WriteLine("{0}nCount = 0;", prefix);
                c.P(lev); c.WriteLine("memset({0}arr,0x0,{1});", prefix, max);
            }
        }
        public void VarsNeededForIsConstraintValid(int lev, OrderedDictionary<string, CLocalVariable> existingVars)
        {
        }

        public string CompareTo(string varName, Asn1Value constValue)
        {
            SCCBitStringValue btVal = constValue as SCCBitStringValue;
            return string.Format("( ({0}.nCount == {1}.nCount) && !memcmp({0}.arr, {1}.arr, {2}) )", varName, constValue.CName, 
                (long)Math.Ceiling((double)btVal.Value.Length / 8.0));
        }
        
        public string AssignTo(string varName, Asn1Value constValue, int lev)
        {
            return "";
        }


        //public string WriteCode(string varName, int lev, Asn1Value constValue)
        //{
        //    SCCBitStringValue btVal = constValue as SCCBitStringValue;
        //    string bitStr_nCount = "bsc_" + btVal.Value;
        //    string bitStr_arr = "bsa_" + btVal.Value;

        //    return string.Format("( ({0}.nCount == {1}) && !memcmp({0}.arr, {2}, {3}) )", varName, bitStr_nCount, bitStr_arr, (long)Math.Ceiling((double)btVal.Value.Length / 8.0));

        //}



        public void PrintCIsConstraintValid(PEREffectiveConstraint cns, StreamWriterLevel c, string errorCode, string typeName, string varName, int lev, int arrayDepth)
        {
            CSSType.PrintCIsConstraintValid(this, cns, c, errorCode, typeName, varName, lev, arrayDepth);
        }
        public void VarsNeededForEncode(PEREffectiveConstraint cns, int arrayDepth, OrderedDictionary<string, CLocalVariable> existingVars) 
        {
            SCCSizeable.VarsNeededForEncode(this, cns, arrayDepth, existingVars);
        }
        public void PrintCEncode(PEREffectiveConstraint cns, StreamWriterLevel c, string errorCode, string varName, int lev)
        {
            long min = minItems(cns);
            long max = maxItems(cns);
            string nCount = "nCount" + (CLocalVariable.GetArrayIndex(varName) + 1);
            string curBlockSize = "curBlockSize" + (CLocalVariable.GetArrayIndex(varName) + 1);
            string curItem = "curItem" + (CLocalVariable.GetArrayIndex(varName) + 1);
            string prefix = "";
            bool topLevel = !varName.Contains("->");

            if (topLevel)
                prefix = varName + "->";
            else
                prefix = varName + ".";
            if (max < 0x10000)
            {

                if (min != max)
                {
                    c.P(lev);
                    c.WriteLine("BitStream_EncodeConstraintWholeNumber(pBitStrm, {0}nCount, {1}, {2});", prefix, min, max);
                }
                else
                {
                    c.P(lev); c.WriteLine("/* No need to encode length (it is fixed size ({0})*/", min);
                }

                c.P(lev);
                c.WriteLine("BitStream_AppendBits(pBitStrm, {0}arr, {0}nCount);", prefix);
            }
            else
            {
                c.P(lev); c.WriteLine("/* Fragmentation required since {0} is grater than 64K*/", max);
//                c.WriteLine("BitStream_AppendBitsWithFragmentation(pBitStrm, {0}arr, {0}nCount);", prefix);

                PrintCEncodeFragmentation(cns, c, errorCode, varName, lev,
                    string.Format(nCount + " = {0}nCount;", prefix), "arr", max, prefix,
                    nCount, curBlockSize, curItem);

            }
        }


        public void PrintCEncodeFragmentation(PEREffectiveConstraint cns, StreamWriterLevel c, string errorCode, string varName, int lev,
            string nCountInit, string arrName, long max, string prefix, string nCount, string curBlockSize, string curItem)
        {

            //            c.P(lev); c.WriteLine("/* Fragmentation required since {0} is grater than 64K*/", max);

            c.P(lev); c.WriteLine(nCountInit);
            c.P(lev); c.WriteLine("{0} = 0;", curBlockSize);
            c.P(lev); c.WriteLine("{0} = 0;", curItem);
            c.P(lev); c.WriteLine("while ({0} >= 0x4000)", nCount);
            c.P(lev++); c.WriteLine("{");
            c.P(lev); c.WriteLine("if ({0} >= 0x10000)", nCount);
            c.P(lev++); c.WriteLine("{");
            c.P(lev); c.WriteLine("{0} = 0x10000;", curBlockSize);
            c.P(lev); c.WriteLine("BitStream_EncodeConstraintWholeNumber(pBitStrm, 0xC4, 0, 0xFF);");
            c.P(--lev); c.WriteLine("}");
            c.P(lev); c.WriteLine("else if ({0} >= 0xC000)", nCount);
            c.P(lev++); c.WriteLine("{");
            c.P(lev); c.WriteLine("{0} = 0xC000;", curBlockSize);
            c.P(lev); c.WriteLine("BitStream_EncodeConstraintWholeNumber(pBitStrm, 0xC3, 0, 0xFF);");
            c.P(--lev); c.WriteLine("}");
            c.P(lev); c.WriteLine("else if ({0} >= 0x8000)", nCount);
            c.P(lev++); c.WriteLine("{");
            c.P(lev); c.WriteLine("{0} = 0x8000;", curBlockSize);
            c.P(lev); c.WriteLine("BitStream_EncodeConstraintWholeNumber(pBitStrm, 0xC2, 0, 0xFF);");
            c.P(--lev); c.WriteLine("}");
            c.P(lev); c.WriteLine("else");
            c.P(lev++); c.WriteLine("{");
            c.P(lev); c.WriteLine("{0} = 0x4000;", curBlockSize);
            c.P(lev); c.WriteLine("BitStream_EncodeConstraintWholeNumber(pBitStrm, 0xC1, 0, 0xFF);");
            c.P(--lev); c.WriteLine("}");
            c.P(lev); c.WriteLine("BitStream_AppendBits(pBitStrm, &{0}{1}[{2}/8], {3});", prefix, arrName, curItem, curBlockSize);
            c.P(lev); c.WriteLine("{0} += {1};", curItem, curBlockSize);
            c.P(lev); c.WriteLine("{0} -= {1};", nCount, curBlockSize);
            c.P(--lev); c.WriteLine("}");

            c.P(lev); c.WriteLine("if ({0} <= 0x7F)", nCount);
            c.P(lev + 1); c.WriteLine("BitStream_EncodeConstraintWholeNumber(pBitStrm, {0}, 0, 0xFF);", nCount);
            c.P(lev); c.WriteLine("else");
            c.P(lev++); c.WriteLine("{");
            c.P(lev); c.WriteLine("BitStream_AppendBit(pBitStrm, 1);");
            c.P(lev); c.WriteLine("BitStream_EncodeConstraintWholeNumber(pBitStrm, {0}, 0, 0x7FFF);", nCount);
            c.P(--lev); c.WriteLine("}");
            c.P(lev); c.WriteLine("BitStream_AppendBits(pBitStrm, &{0}{1}[{2}/8], {3});", prefix, arrName, curItem, nCount);
        }



        public void VarsNeededForDecode(PEREffectiveConstraint cns, int arrayDepth, OrderedDictionary<string, CLocalVariable> existingVars)
        {
            SCCSizeable.VarsNeededForDecode(this, cns, arrayDepth, existingVars);
        }
        public void PrintCDecode(PEREffectiveConstraint cns, StreamWriterLevel c, string varName, int lev)
        {
            long min = minItems(cns);
            long max = maxItems(cns);
            string i = "i" + (CLocalVariable.GetArrayIndex(varName) + 1);
            string length = "length" + (CLocalVariable.GetArrayIndex(varName) + 1);
            string curBlockSize = "curBlockSize" + (CLocalVariable.GetArrayIndex(varName) + 1);
            string nCount = "nCount" + (CLocalVariable.GetArrayIndex(varName) + 1);
            string prefix = "";
            bool topLevel = !varName.Contains("->");
            if (topLevel)
                prefix = varName + "->";
            else
                prefix = varName + ".";

            if (max < 0x10000)
            {
                if (min != max)
                {
                    c.P(lev);
                    c.WriteLine("if (!BitStream_DecodeConstraintWholeNumber(pBitStrm, &nCount, {0}, {1})) {{", min, max);
                    c.P(lev + 1);
                    c.WriteLine("*pErrCode = ERR_INSUFFICIENT_DATA;");
                    c.P(lev + 1);
                    c.WriteLine("return FALSE;");
                    c.P(lev);
                    c.WriteLine("}");
                    c.P(lev);
                    c.WriteLine("{0}nCount = (long)nCount;", prefix);

                }
                else
                {
                    c.P(lev);
                    c.WriteLine("{0}nCount = {1};", prefix, max);
                }

                c.P(lev);
                c.WriteLine("if (!BitStream_ReadBits(pBitStrm, {0}arr, {0}nCount)) {{", prefix);
                c.P(lev + 1);
                c.WriteLine("*pErrCode = ERR_INSUFFICIENT_DATA;");
                c.P(lev + 1);
                c.WriteLine("return FALSE;");
                c.P(lev);
                c.WriteLine("}");
            }
            else
            {
                PrintCDecodeFragmentation(cns, c, varName, lev,
                        "arr", max, prefix, length, curBlockSize, nCount);
            }
        }



        public void PrintCDecodeFragmentation(PEREffectiveConstraint cns, StreamWriterLevel c, string varName, int lev,
            string arrName, long max, string prefix,
            string length, string curBlockSize, string nCount)
        {
            string i = "i1";
            c.P(lev); c.WriteLine("/* Fragmentation required since {0} is grater than 64K*/", max);
            c.WriteCodeBlock(lev,
@"if (!BitStream_DecodeConstraintWholeNumber(pBitStrm, &{1}, 0, 0xFF))
{{
    *pErrCode = ERR_INSUFFICIENT_DATA;
    return FALSE;
}}
while(({1} & 0xC0)==0xC0) 
{{
	if ({1} == 0xC4)
		{2} = 0x10000;
	else if ({1} == 0xC3)
		{2} = 0xC000;
	else if ({1} == 0xC2)
		{2} = 0x8000;
	else if ({1} == 0xC1)
		{2} = 0x4000;
	else {{
		*pErrCode = ERR_INCORRECT_PER_STREAM;
		return FALSE;
	}}
	if ({3}+{2}>{4})
	{{
		*pErrCode = ERR_INSUFFICIENT_DATA;
		return FALSE;
	}}

	", i, length, curBlockSize, nCount,max);

//            ((ISCCSizeable)pThis).PrintCDecodeItem(cns, c, prefix + arrName + "[" + i + "]", lev + 2);

        c.P(lev+1);
        c.WriteLine("if (!BitStream_ReadBits(pBitStrm, &{0}arr[{1}/8], {2})) {{", prefix, nCount, curBlockSize);
        c.P(lev + 2);
        c.WriteLine("*pErrCode = ERR_INSUFFICIENT_DATA;");
        c.P(lev + 2);
        c.WriteLine("return FALSE;");
        c.P(lev+1);
        c.WriteLine("}");




            c.WriteCodeBlock(lev,
@"    
	{3}+={2};

	if (!BitStream_DecodeConstraintWholeNumber(pBitStrm, &{1}, 0, 0xFF)) {{
		*pErrCode = ERR_INSUFFICIENT_DATA;
		return FALSE;
	}}
}}
if ( ({1} & 0x80)>0) 
{{
	asn1SccSint len2=0;
	{1}<<=8;
	if (!BitStream_DecodeConstraintWholeNumber(pBitStrm, &len2, 0, 0xFF)) {{
		*pErrCode = ERR_INSUFFICIENT_DATA;
		return FALSE;
	}}
	{1} |= len2;
	{1} &= 0x7FFF;
}}

if ({3}+{1}>{4})
{{
	*pErrCode = ERR_INSUFFICIENT_DATA;
	return FALSE;
}}
", i, length, curBlockSize, nCount,max);
//            ((ISCCSizeable)pThis).PrintCDecodeItem(cns, c, prefix + arrName + "[" + i + "]", lev + 1);

            c.P(lev);
            c.WriteLine("if (!BitStream_ReadBits(pBitStrm, &{0}arr[{1}/8], {2})) {{", prefix, nCount, length);
            c.P(lev + 1);
            c.WriteLine("*pErrCode = ERR_INSUFFICIENT_DATA;");
            c.P(lev + 1);
            c.WriteLine("return FALSE;");
            c.P(lev);
            c.WriteLine("}");


            c.WriteCodeBlock(lev,
@"
{0}+=(long){1};", nCount, length);
            c.P(lev); c.WriteLine("{0}nCount = (long){1};", prefix, nCount);

        }





    }

    public class SCCBooleanType : BooleanType, ISCCType
    {
        public void PrintHTypeDeclaration(PEREffectiveConstraint cns, StreamWriterLevel h, string typeName, string varName, int lev)
        {
            h.Write("flag ");
        }
        public void PrintHConstraintConstant(StreamWriterLevel h, string name)
        {
            CSSType.PrintHConstraintConstant(this, h, name);
        }
        public void VarsNeededForPrintCInitialize(int arrayDepth, OrderedDictionary<string, CLocalVariable> existingVars)
        {
        }
        public void PrintCInitialize(PEREffectiveConstraint cns, Asn1Value defaultVal, StreamWriterLevel h, string typeName, string varName, int lev, int arrayDepth)
        {
            bool topLevel = !varName.Contains("->");
            BooleanValue b = defaultVal as BooleanValue;
            string defVal = "FALSE";
            if (b != null && b.Value)
                defVal = "TRUE";
            h.P(lev);
            if (topLevel)
                h.WriteLine("*{0} = {1};", varName, defVal);
            else
                h.WriteLine("{0} = {1};", varName, defVal);

        }
        public void VarsNeededForIsConstraintValid(int lev, OrderedDictionary<string, CLocalVariable> existingVars)
        {
        }
        public void PrintCIsConstraintValid(PEREffectiveConstraint cns, StreamWriterLevel c, string errorCode, string typeName, string varName, int lev, int arrayDepth)
        {
            CSSType.PrintCIsConstraintValid(this, cns, c, errorCode, typeName, varName, lev, arrayDepth);
        }
        public void VarsNeededForEncode(PEREffectiveConstraint cns, int arrayDepth, OrderedDictionary<string, CLocalVariable> existingVars) { }
        public void PrintCEncode(PEREffectiveConstraint cns, StreamWriterLevel c, string errorCode, string varName, int lev)
        {
            bool topLevel = !varName.Contains("->");
            c.P(lev);
            if (topLevel)
                c.WriteLine("BitStream_AppendBit(pBitStrm, *{0});", varName);
            else
                c.WriteLine("BitStream_AppendBit(pBitStrm, {0});", varName);
        }
        public void VarsNeededForDecode(PEREffectiveConstraint cns, int arrayDepth, OrderedDictionary<string, CLocalVariable> existingVars) { }
        public void PrintCDecode(PEREffectiveConstraint cns, StreamWriterLevel c, string varName, int lev)
        {
            string var2 = varName;
            if (varName.Contains("->"))
                var2 = "&" + varName;

            c.P(lev);
            c.WriteLine("if (!BitStream_ReadBit(pBitStrm, {0})) {{ ", var2);
            c.P(lev + 1);
            c.WriteLine("*pErrCode = ERR_INSUFFICIENT_DATA;");
            c.P(lev + 1);
            c.WriteLine("return FALSE;");
            c.P(lev);
            c.WriteLine("}");

        }
    }

    public class SCCEnumeratedType : EnumeratedType, ISCCType
    {
        public void PrintHTypeDeclaration(PEREffectiveConstraint cns, StreamWriterLevel h, string typeName, string varName, int lev)
        {
            h.WriteLine("enum {");
            //            h.WriteLine("enum {0} {{", typeName);
            int i = 0;
            foreach (Item it in m_enumValues.Values)
            {
                h.P(lev + 1);
                h.Write("{0} = {1}", it.CID, it.m_value);
                if (i < m_enumValues.Values.Count - 1)
                    h.WriteLine(",");
                else
                    h.WriteLine();
                i++;
            }

            h.P(lev);
            h.Write("}");
        }
        public void PrintHConstraintConstant(StreamWriterLevel h, string name)
        {
            CSSType.PrintHConstraintConstant(this, h, name);
        }
        public void VarsNeededForPrintCInitialize(int arrayDepth, OrderedDictionary<string, CLocalVariable> existingVars)
        {
        }
        public void PrintCInitialize(PEREffectiveConstraint cns, Asn1Value defauleVal, StreamWriterLevel h, string typeName, string varName, int lev, int arrayDepth)
        {
            bool topLevel = !varName.Contains("->");
            EnumeratedValue v = defauleVal as EnumeratedValue;
            string defVal = m_enumValues.Values[0].CID;
            if (v != null)
                defVal = m_enumValues[v.ID].CID;
            h.P(lev);
            if (topLevel)
                h.WriteLine("*{0} = {1};", varName, defVal);
            else
                h.WriteLine("{0} = {1};", varName, defVal);

        }
        public void VarsNeededForIsConstraintValid(int lev, OrderedDictionary<string, CLocalVariable> existingVars)
        {
        }
        public void PrintCIsConstraintValid(PEREffectiveConstraint cns, StreamWriterLevel c, string errorCode, string typeName, string varName, int lev, int arrayDepth)
        {
            CSSType.PrintCIsConstraintValid(this, cns, c, errorCode, typeName, varName, lev, arrayDepth);
        }
        public void VarsNeededForEncode(PEREffectiveConstraint cns, int arrayDepth, OrderedDictionary<string, CLocalVariable> existingVars) { }
        public void PrintCEncode(PEREffectiveConstraint cns, StreamWriterLevel c, string errorCode, string varName, int lev)
        {
            string varName2 = varName;
            if (!varName.Contains("->"))
                varName2 = "*" + varName;

            c.P(lev);
            c.WriteLine("switch({0})", varName2);
            c.P(lev); c.WriteLine("{");
            int index = 0;
            foreach (Item it in m_enumValues.Values)
            {
                c.P(lev); c.WriteLine("case {0}:", it.CID);
                c.P(lev + 1);
                c.WriteLine("BitStream_EncodeConstraintWholeNumber(pBitStrm, {0}, {1}, {2});", index, 0, RootItemsCount - 1);
                c.P(lev + 1);
                c.WriteLine("break;");
                index++;
            }
            c.P(lev); c.WriteLine("}");

        }
        public void VarsNeededForDecode(PEREffectiveConstraint cns, int arrayDepth, OrderedDictionary<string, CLocalVariable> existingVars)
        {
            if (!existingVars.ContainsKey("enumIndex"))
            {
                existingVars.Add("enumIndex", new CLocalVariable("enumIndex", "asn1SccSint", 0, "0"));
            }
        }
        public void PrintCDecode(PEREffectiveConstraint cns, StreamWriterLevel c, string varName, int lev)
        {
            string varName2 = varName;
            if (!varName.Contains("->"))
                varName2 = "*" + varName;

            c.P(lev);
            c.WriteLine("if (!BitStream_DecodeConstraintWholeNumber(pBitStrm, &enumIndex, {0}, {1})) {{", 0, RootItemsCount - 1);
            c.P(lev + 1);
            c.WriteLine("*pErrCode = ERR_INSUFFICIENT_DATA;");
            c.P(lev + 1);
            c.WriteLine("return FALSE;");
            c.P(lev);
            c.WriteLine("}");
            c.P(lev);
            c.WriteLine("switch(enumIndex)");
            c.P(lev); c.WriteLine("{");
            int index = 0;
            foreach (Item it in m_enumValues.Values)
            {
                c.P(lev); c.WriteLine("case {0}:", index);
                c.P(lev + 1);
                c.WriteLine("{0} = {1};", varName2, it.CID);
                c.P(lev + 1);
                c.WriteLine("break;");
                index++;
            }


            c.P(lev); c.WriteLine("}");
        }

    }

    public class SCCIntegerType : IntegerType, ISCCType
    {
        public void PrintHTypeDeclaration(PEREffectiveConstraint cns, StreamWriterLevel h, string typeName, string varName, int lev)
        {
            h.Write("asn1SccSint ");
        }
        public void PrintHConstraintConstant(StreamWriterLevel h, string name)
        {
            CSSType.PrintHConstraintConstant(this, h, name);
        }
        public void VarsNeededForPrintCInitialize(int arrayDepth, OrderedDictionary<string, CLocalVariable> existingVars)
        {
        }
        public void PrintCInitialize(PEREffectiveConstraint cns, Asn1Value defaultVal, StreamWriterLevel h, string typeName, string varName, int lev, int arrayDepth)
        {
            bool topLevel = !varName.Contains("->");
            long defValue = 0;

            PERIntegerEffectiveConstraint intCns = cns as PERIntegerEffectiveConstraint;
            if (defaultVal != null)
                defValue = ((IntegerValue)defaultVal).Value;

            h.P(lev);
            if (topLevel)
                h.WriteLine("*{0} = {1};", varName, C.L(defValue));
            else
                h.WriteLine("{0} = {1};", varName, C.L(defValue));
        }
        public void VarsNeededForIsConstraintValid(int lev, OrderedDictionary<string, CLocalVariable> existingVars)
        {
        }
        public void PrintCIsConstraintValid(PEREffectiveConstraint cns, StreamWriterLevel c, string errorCode, string typeName, string varName, int lev, int arrayDepth)
        {
            CSSType.PrintCIsConstraintValid(this, cns, c, errorCode, typeName, varName, lev, arrayDepth);
        }
        public void VarsNeededForEncode(PEREffectiveConstraint cns, int arrayDepth, OrderedDictionary<string, CLocalVariable> existingVars) { }
        public void PrintCEncode(PEREffectiveConstraint cns, StreamWriterLevel c, string errorCode, string varName, int lev)
        {
            string var = varName;
            if (!varName.Contains("->"))
                var = "*" + var;

            PERIntegerEffectiveConstraint cn = cns as PERIntegerEffectiveConstraint;
            if (cn == null) //unconstraint integer
            {
                c.P(lev);
                c.WriteLine("BitStream_EncodeUnConstraintWholeNumber(pBitStrm, {0});", var);
            }
            else
            {
                if (cn.Extensible)
                {
                    if ((cn.m_extRange == null))
                    {
                        c.P(lev);
                        c.WriteLine("BitStream_AppendBitZero(pBitStrm); /* write extension bit*/");
                        EncodeNormal(cn, c, var, lev);
                    }
                    else
                    {
                        c.P(lev);
                        c.Write("if ");
                        for (int i = 0; i < m_constraints.Count; i++)
                        {
                            string ret = ((ISCConstraint)m_constraints[i]).PrintCIsRootConstraintValid(var, lev);
                            c.Write(ret);
                            if (i != m_constraints.Count - 1)
                                c.Write(" && ");
                        }
                        c.WriteLine(" {");
                        c.P(lev + 1);
                        c.WriteLine("BitStream_AppendBitZero(pBitStrm); /* value within root range, so ext bit is zero*/");
                        EncodeNormal(cn, c, var, lev + 1);
                        c.P(lev);
                        c.WriteLine("} else {");
                        lev++;
                        c.P(lev);
                        c.WriteLine("/* value is not within root range, so ext bit is one and value is encoded as uncostraint*/");
                        c.P(lev);
                        c.WriteLine("BitStream_AppendBitOne(pBitStrm);");
                        c.P(lev);
                        c.WriteLine("BitStream_EncodeUnConstraintWholeNumber(pBitStrm, {0});", var);
                        lev--;
                        c.P(lev);
                        c.WriteLine("}");
                    }

                }
                else
                    EncodeNormal(cn, c, var, lev);



            }

        }

        private void EncodeNormal(PERIntegerEffectiveConstraint cn, StreamWriterLevel c, string var, int lev)
        {
            if (!cn.m_rootRange.m_minIsInfinite && !cn.m_rootRange.m_maxIsInfinite)
            {
                c.P(lev);
                if (cn.m_rootRange.m_min == cn.m_rootRange.m_max)
                    c.WriteLine("/* No need to encode value since it will always be {0}*/", cn.m_rootRange.m_min);
                else
                    c.WriteLine("BitStream_EncodeConstraintWholeNumber(pBitStrm, {0}, {1}, {2});", var, C.L(cn.m_rootRange.m_min), C.L(cn.m_rootRange.m_max));
            }
            else if (!cn.m_rootRange.m_minIsInfinite && cn.m_rootRange.m_maxIsInfinite)
            {
                c.P(lev);
                c.WriteLine("BitStream_EncodeSemiConstraintWholeNumber(pBitStrm, {0}, {1});", var, C.L(cn.m_rootRange.m_min));
            }
            else
            {
                c.P(lev);
                c.WriteLine("BitStream_EncodeUnConstraintWholeNumber(pBitStrm, {0});", var);
            }
        }
        public void VarsNeededForDecode(PEREffectiveConstraint cns, int arrayDepth, OrderedDictionary<string, CLocalVariable> existingVars)
        {
            PERIntegerEffectiveConstraint cn = cns as PERIntegerEffectiveConstraint;
            if (cns != null && cn.Extensible)
            {
                if (!existingVars.ContainsKey("extBit"))
                {
                    existingVars.Add("extBit", new CLocalVariable("extBit", "flag", 0, "FALSE"));
                }
            }
        }
        public void PrintCDecode(PEREffectiveConstraint cns, StreamWriterLevel c, string varName, int lev)
        {
            string var = varName;
            if (varName.Contains("->"))
                var = "&" + var;
            PERIntegerEffectiveConstraint cn = cns as PERIntegerEffectiveConstraint;
            if (cn == null) //unconstraint integer
            {
                c.P(lev);
                c.WriteLine("if (!BitStream_DecodeUnConstraintWholeNumber(pBitStrm, {0})) {{", var);
                c.P(lev + 1);
                c.WriteLine("*pErrCode = ERR_INSUFFICIENT_DATA;");
                c.P(lev + 1);
                c.WriteLine("return FALSE;");
                c.P(lev);
                c.WriteLine("}");
            }
            else
            {
                if (cn.Extensible)
                {
                    c.P(lev);
                    c.WriteLine("if (!BitStream_ReadBit(pBitStrm, &extBit)) { /* read extension bit*/ ");
                    c.P(lev + 1);
                    c.WriteLine("*pErrCode = ERR_INSUFFICIENT_DATA;");
                    c.P(lev + 1);
                    c.WriteLine("return FALSE;");
                    c.P(lev);
                    c.WriteLine("}");

                    c.P(lev);
                    c.WriteLine("if (extBit==0) { /* ext bit is zero ==> value is expecteted with root range*/");
                    DecodeNormal(cn, c, var, lev + 1);
                    c.P(lev); c.WriteLine("} else {");
                    c.P(lev + 1);
                    c.WriteLine("if (!BitStream_DecodeUnConstraintWholeNumber(pBitStrm, {0})) {{", var);
                    c.P(lev + 2);
                    c.WriteLine("*pErrCode = ERR_INSUFFICIENT_DATA;");
                    c.P(lev + 2);
                    c.WriteLine("return FALSE;");
                    c.P(lev + 1);
                    c.WriteLine("}");
                    c.P(lev);
                    c.WriteLine("}");
                }
                else
                    DecodeNormal(cn, c, var, lev);


            }
        }

        private void DecodeNormal(PERIntegerEffectiveConstraint cn, StreamWriterLevel c, string var, int lev)
        {
            if (!cn.m_rootRange.m_minIsInfinite && !cn.m_rootRange.m_maxIsInfinite && (cn.m_rootRange.m_max == cn.m_rootRange.m_min))
            {

                c.P(lev);
                c.WriteLine("{0} = {1};", var.Replace("&", ""), C.L(cn.m_rootRange.m_min));
            }
            else
            {
                if (!cn.m_rootRange.m_minIsInfinite && !cn.m_rootRange.m_maxIsInfinite)
                {
                    c.P(lev);
                    c.WriteLine("if (!BitStream_DecodeConstraintWholeNumber(pBitStrm, {0}, {1}, {2})) {{", var, C.L(cn.m_rootRange.m_min), C.L(cn.m_rootRange.m_max));
                }
                else if (!cn.m_rootRange.m_minIsInfinite && cn.m_rootRange.m_maxIsInfinite)
                {
                    c.P(lev);
                    c.WriteLine("if (!BitStream_DecodeSemiConstraintWholeNumber(pBitStrm, {0}, {1})) {{", var, C.L(cn.m_rootRange.m_min));
                }
                else
                {
                    c.P(lev);
                    c.WriteLine("if (!BitStream_DecodeUnConstraintWholeNumber(pBitStrm, {0})) {{", var);
                }
                c.P(lev + 1);
                c.WriteLine("*pErrCode = ERR_INSUFFICIENT_DATA;");
                c.P(lev + 1);
                c.WriteLine("return FALSE;");
                c.P(lev);
                c.WriteLine("}");
            }
        }
    
    }

    public class SCCNullType : NullType, ISCCType
    {
        public void PrintHTypeDeclaration(PEREffectiveConstraint cns, StreamWriterLevel h, string typeName, string varName, int lev)
        {
            h.Write("NullType ");
        }
        public void PrintHConstraintConstant(StreamWriterLevel h, string name)
        {
            CSSType.PrintHConstraintConstant(this, h, name);
        }
        public void VarsNeededForPrintCInitialize(int arrayDepth, OrderedDictionary<string, CLocalVariable> existingVars)
        {
        }
        public void PrintCInitialize(PEREffectiveConstraint cns, Asn1Value defaultVal, StreamWriterLevel h, string typeName, string varName, int lev, int arrayDepth)
        {
            bool topLevel = !varName.Contains("->");
            h.P(lev);
            if (topLevel)
                h.WriteLine("*{0} = 0;", varName);
            else
                h.WriteLine("{0} = 0;", varName);

        }
        public void VarsNeededForIsConstraintValid(int lev, OrderedDictionary<string, CLocalVariable> existingVars)
        {
        }
        public void PrintCIsConstraintValid(PEREffectiveConstraint cns, StreamWriterLevel c, string errorCode, string typeName, string varName, int lev, int arrayDepth)
        {
            CSSType.PrintCIsConstraintValid(this, cns, c, errorCode, typeName, varName, lev, arrayDepth);
        }
        public void VarsNeededForEncode(PEREffectiveConstraint cns, int arrayDepth, OrderedDictionary<string, CLocalVariable> existingVars) { }
        public void PrintCEncode(PEREffectiveConstraint cns, StreamWriterLevel c, string errorCode, string varName, int lev)
        {
            c.P(lev); c.WriteLine("/* NULL type */");
        }
        public void VarsNeededForDecode(PEREffectiveConstraint cns, int arrayDepth, OrderedDictionary<string, CLocalVariable> existingVars) { }
        public void PrintCDecode(PEREffectiveConstraint cns, StreamWriterLevel c, string varName, int lev)
        {
            c.P(lev); c.WriteLine("/* NULL type */");
        }
    }

    public class SCCObjectIdentifier : ObjectIdentifier, ISCCType
    {
        public void PrintHTypeDeclaration(PEREffectiveConstraint cns, StreamWriterLevel h, string typeName, string varName, int lev)
        {
            throw new Exception("Unimplemented !!!");
        }
        public void PrintHConstraintConstant(StreamWriterLevel h, string name)
        {
            CSSType.PrintHConstraintConstant(this, h, name);
        }
        public void VarsNeededForPrintCInitialize(int arrayDepth, OrderedDictionary<string, CLocalVariable> existingVars)
        {
        }
        public void PrintCInitialize(PEREffectiveConstraint cns, Asn1Value defauleVal, StreamWriterLevel h, string typeName, string varName, int lev, int arrayDepth)
        {
            throw new Exception("Unimplemented !!!");
        }
        public void VarsNeededForIsConstraintValid(int lev, OrderedDictionary<string, CLocalVariable> existingVars)
        {
        }
        public void PrintCIsConstraintValid(PEREffectiveConstraint cns, StreamWriterLevel c, string errorCode, string typeName, string varName, int lev, int arrayDepth)
        {
            CSSType.PrintCIsConstraintValid(this, cns, c, errorCode, typeName, varName, lev, arrayDepth);
        }
        public void VarsNeededForEncode(PEREffectiveConstraint cns, int arrayDepth, OrderedDictionary<string, CLocalVariable> existingVars) { }
        public void PrintCEncode(PEREffectiveConstraint cns, StreamWriterLevel c, string errorCode, string varName, int lev)
        {
            throw new Exception("Unimplemented !!!");
        }
        public void VarsNeededForDecode(PEREffectiveConstraint cns, int arrayDepth, OrderedDictionary<string, CLocalVariable> existingVars) { }
        public void PrintCDecode(PEREffectiveConstraint cns, StreamWriterLevel c, string varName, int lev)
        {
            throw new Exception("Unimplemented !!!");
        }
    }

    public class SCCOctetStringType : OctetStringType, ISCCType, ISCCSizeable, INonPrimitiveCType
    {
        public void PrintHTypeDeclaration(PEREffectiveConstraint cns, StreamWriterLevel h, string typeName, string varName, int lev)
        {
            lev++;
            long max = maxItems(cns);
            h.WriteLine("struct {");
            h.P(lev + 1);
            h.WriteLine("long nCount;");
            h.P(lev + 1); h.WriteLine("byte arr[{0}];", max);
            h.P(lev);
            h.Write("}");
        }
        public void PrintHConstraintConstant(StreamWriterLevel h, string name)
        {
            CSSType.PrintHConstraintConstant(this, h, name);
        }
        public void VarsNeededForPrintCInitialize(int arrayDepth, OrderedDictionary<string, CLocalVariable> existingVars)
        {
        }
        public void PrintCInitialize(PEREffectiveConstraint cns, Asn1Value defaultValue, StreamWriterLevel c, string typeName, string varName, int lev, int arrayDepth)
        {
            long max = maxItems(cns);
            string i = "i" + lev.ToString();
            string prefix = "";
            bool topLevel = !varName.Contains("->");
            if (topLevel)
                prefix = varName + "->";
            else
                prefix = varName + ".";

            OctetStringValue defVal = defaultValue as OctetStringValue;
            if (defVal != null)
            {
                c.P(lev); c.WriteLine("{0}nCount = {1};", prefix, defVal.Value.Count);
                c.P(lev); c.WriteLine("memcpy({0}arr,{1}.arr,{2});", prefix, defVal.CName, defVal.Value.Count);
            }
            else
            {
                c.P(lev); c.WriteLine("{0}nCount = 0;", prefix);
                c.P(lev); c.WriteLine("memset({0}arr,0x0,{1});", prefix, max);
            }
        }
        public void VarsNeededForIsConstraintValid(int lev, OrderedDictionary<string, CLocalVariable> existingVars)
        {

        }


        public string CompareTo(string varName, Asn1Value constValue)
        {
            SCCBitStringValue btVal = constValue as SCCBitStringValue;
            return string.Format("( ({0}.nCount == {1}.nCount) && !memcmp({0}.arr, {1}.arr, {1}.nCount) )", varName, constValue.CName);
        }

        public string AssignTo(string varName, Asn1Value constValue, int lev)
        {
            return "";
        }

        

        public void PrintCIsConstraintValid(PEREffectiveConstraint cns, StreamWriterLevel c, string errorCode, string typeName, string varName, int lev, int arrayDepth)
        {
            CSSType.PrintCIsConstraintValid(this, cns, c, errorCode, typeName, varName, lev, arrayDepth);
        }
        public void VarsNeededForEncode(PEREffectiveConstraint cns, int arrayDepth, OrderedDictionary<string, CLocalVariable> existingVars) 
        {
            SCCSizeable.VarsNeededForEncode(this, cns, arrayDepth, existingVars);
        }
        public void PrintCEncodeItem(PEREffectiveConstraint cns, StreamWriterLevel c, string errorCode, string varName, int lev)
        {
            c.P(lev);
            c.WriteLine("BitStream_AppendByte0(pBitStrm, {0});", varName);
        }
        public void PrintCEncode(PEREffectiveConstraint cns, StreamWriterLevel c, string errorCode, string varName, int lev)
        {
            SCCSizeable.PrintCEncode(this, cns, c, errorCode, varName, lev);
        }
        public void VarsNeededForDecode(PEREffectiveConstraint cns, int arrayDepth, OrderedDictionary<string, CLocalVariable> existingVars) 
        {
            SCCSizeable.VarsNeededForDecode(this, cns, arrayDepth, existingVars);
        }
        public void PrintCDecodeItem(PEREffectiveConstraint cns, StreamWriterLevel c, string varName, int lev)
        {
            c.P(lev);
            c.WriteLine("if ( !BitStream_ReadByte(pBitStrm, &{0}) ) {{", varName);
            c.P(lev + 1);
            c.WriteLine("*pErrCode = ERR_INSUFFICIENT_DATA;");
            c.P(lev + 1);
            c.WriteLine("return FALSE;");
            c.P(lev);
            c.WriteLine("}");
        }
        public void PrintCDecode(PEREffectiveConstraint cns, StreamWriterLevel c, string varName, int lev)
        {
            SCCSizeable.PrintCDecode(this, cns, c, varName, lev);
        }
    }

    public class SCCRealType : RealType, ISCCType
    {
        public void PrintHTypeDeclaration(PEREffectiveConstraint cns, StreamWriterLevel h, string typeName, string varName, int lev)
        {
            h.Write("double");
        }
        public void PrintHConstraintConstant(StreamWriterLevel h, string name)
        {
            CSSType.PrintHConstraintConstant(this, h, name);
        }
        public void VarsNeededForPrintCInitialize(int arrayDepth, OrderedDictionary<string, CLocalVariable> existingVars)
        {
        }
        public void PrintCInitialize(PEREffectiveConstraint cns, Asn1Value defaultVal, StreamWriterLevel h, string typeName, string varName, int lev, int arrayDepth)
        {
            bool topLevel = !varName.Contains("->");
            double defValue = 0;

            if (defaultVal != null)
                defValue = ((RealValue)defaultVal).Value;

            h.P(lev);
            if (topLevel)
                h.WriteLine("*{0} = {1};", varName, defValue);
            else
                h.WriteLine("{0} = {1};", varName, defValue);

        }
        public void VarsNeededForIsConstraintValid(int lev, OrderedDictionary<string, CLocalVariable> existingVars)
        {
        }
        public void PrintCIsConstraintValid(PEREffectiveConstraint cns, StreamWriterLevel c, string errorCode, string typeName, string varName, int lev, int arrayDepth)
        {
            CSSType.PrintCIsConstraintValid(this, cns, c, errorCode, typeName, varName, lev, arrayDepth);
        }
        public void VarsNeededForEncode(PEREffectiveConstraint cns, int arrayDepth, OrderedDictionary<string, CLocalVariable> existingVars) { }
        public void PrintCEncode(PEREffectiveConstraint cns, StreamWriterLevel c, string errorCode, string varName, int lev)
        {
            string var = varName;
            if (!varName.Contains("->"))
                var = "*" + var;

            c.P(lev);
            c.WriteLine("BitStream_EncodeReal(pBitStrm, {0});", var);
        }
        public void VarsNeededForDecode(PEREffectiveConstraint cns, int arrayDepth, OrderedDictionary<string, CLocalVariable> existingVars) {}
        public void PrintCDecode(PEREffectiveConstraint cns, StreamWriterLevel c, string varName, int lev)
        {
            string var = varName;
            if (varName.Contains("->"))
                var = "&" + var;
            c.P(lev);
            c.WriteLine("if (!BitStream_DecodeReal(pBitStrm, {0})) {{", var);
            c.P(lev + 1);
            c.WriteLine("*pErrCode = ERR_INSUFFICIENT_DATA;");
            c.P(lev + 1);
            c.WriteLine("return FALSE;");
            c.P(lev);
            c.WriteLine("}");
        }
    }

    public class SCCReferenceType : ReferenceType, ISCCType
    {

        public void PrintHTypeDeclaration(PEREffectiveConstraint cns, StreamWriterLevel h, string typeName, string varName, int lev)
        {
            h.Write(DefaultBackend.Instance.TypePrefix + C.ID(m_referencedTypeName));
        }
        public void PrintHConstraintConstant(StreamWriterLevel h, string name)
        {
            Asn1Type cur = this;
            int nCount = 0;
            string conConstraints = "";
            while (cur != null)
            {
                nCount += cur.m_constraints.Count;
                conConstraints += cur.Constraints;
                cur = cur.ParentType;
            }
            if (nCount > 0)
                h.WriteLine("#define ERR_{0}\t\t{1} /* {2} */", C.ID(name), DefaultBackend.Instance.ConstraintErrorID++, conConstraints);
        }
        
        public void VarsNeededForPrintCInitialize(int arrayDepth, OrderedDictionary<string, CLocalVariable> existingVars)
        {
            ((ISCCType)Type).VarsNeededForPrintCInitialize(arrayDepth, existingVars);
        }
        public void PrintCInitialize(PEREffectiveConstraint cns, Asn1Value defauleVal, StreamWriterLevel h, string typeName, string varName, int lev, int arrayDepth)
        {
            if (m_constraints.Count == 0)
            {
                h.P(lev);
                if ((Type is IA5StringType) || !varName.Contains("->"))
                    h.WriteLine("{0}_Initialize({1});", DefaultBackend.Instance.TypePrefix + C.ID(m_referencedTypeName), varName);
                else
                    h.WriteLine("{0}_Initialize(&{1});", DefaultBackend.Instance.TypePrefix + C.ID(m_referencedTypeName), varName);
            }
            else
            {
                ((ISCCType)Type).PrintCInitialize(cns, defauleVal, h, typeName, varName, lev, arrayDepth);
            }

        }
        public void VarsNeededForIsConstraintValid(int lev, OrderedDictionary<string, CLocalVariable> existingVars)
        {
            ((ISCCType)Type).VarsNeededForIsConstraintValid(lev, existingVars);
        }
        public void PrintCIsConstraintValid(PEREffectiveConstraint cns, StreamWriterLevel c, string errorCode, string typeName, string varName, int lev, int arrayDepth)
        {
            c.P(lev); c.Write("if ( !");
            if ((Type is IA5StringType) || !varName.Contains("->"))
                c.WriteLine("{0}_IsConstraintValid({1}, pErrCode) )", DefaultBackend.Instance.TypePrefix + C.ID(m_referencedTypeName), varName);
            else
                c.WriteLine("{0}_IsConstraintValid(&{1}, pErrCode) )", DefaultBackend.Instance.TypePrefix + C.ID(m_referencedTypeName), varName);

            c.P(lev);
            c.WriteLine("{");
            //c.P(lev + 1);
            //c.WriteLine("*pErrCode = ERR_{0};", C.ID(errorCode));
            c.P(lev + 1);
            c.WriteLine("return FALSE;");
            c.P(lev);
            c.WriteLine("}");

            CSSType.PrintCIsConstraintValid(this, cns, c, errorCode, typeName, varName, lev, arrayDepth);

        }
        public void VarsNeededForEncode(PEREffectiveConstraint cns, int arrayDepth, OrderedDictionary<string, CLocalVariable> existingVars)
        {
            ((ISCCType)Type).VarsNeededForEncode(cns, arrayDepth, existingVars);
        }
        public void PrintCEncode(PEREffectiveConstraint cns, StreamWriterLevel c, string errorCode, string varName, int lev)
        {
            if (m_constraints.Count == 0)
            {
                c.P(lev);
                if ((Type is IA5StringType) || !varName.Contains("->"))
                    c.WriteLine("{0}_Encode({1}, pBitStrm, pErrCode, FALSE);", DefaultBackend.Instance.TypePrefix + C.ID(m_referencedTypeName), varName);
                else
                    c.WriteLine("{0}_Encode(&{1}, pBitStrm, pErrCode, FALSE);", DefaultBackend.Instance.TypePrefix + C.ID(m_referencedTypeName), varName);
            }
            else
            {
                ((ISCCType)Type).PrintCEncode(cns, c, errorCode, varName, lev);
            }

        }
        public void VarsNeededForDecode(PEREffectiveConstraint cns, int arrayDepth, OrderedDictionary<string, CLocalVariable> existingVars)
        {
            ((ISCCType)Type).VarsNeededForDecode(cns, arrayDepth, existingVars);
        }
        public void PrintCDecode(PEREffectiveConstraint cns, StreamWriterLevel c, string varName, int lev)
        {
            if (m_constraints.Count == 0)
            {
                c.P(lev);
                if ((Type is IA5StringType) || !varName.Contains("->"))
                    c.WriteLine("if ( !{0}_Decode({1}, pBitStrm, pErrCode) ) {{", DefaultBackend.Instance.TypePrefix + C.ID(m_referencedTypeName), varName);
                else
                    c.WriteLine("if ( !{0}_Decode(&{1}, pBitStrm, pErrCode) ) {{", DefaultBackend.Instance.TypePrefix + C.ID(m_referencedTypeName), varName);
                c.P(lev + 1);
                c.WriteLine("*pErrCode = ERR_INSUFFICIENT_DATA;");
                c.P(lev + 1);
                c.WriteLine("return FALSE;");
                c.P(lev);
                c.WriteLine("}");
            }
            else
            {
                ((ISCCType)Type).PrintCDecode(cns, c, varName, lev);
            }
        }

    }

    public static class SCCStringBase
    {
        public static void PrintHTypeDeclaration(IA5StringType pThis, PEREffectiveConstraint cns, StreamWriterLevel h, string typeName, string varName, int lev)
        {
            if (varName == "")
                h.WriteLine("char {0}[{1}];", typeName, pThis.maxItems(cns) + 1);
            else
                h.WriteLine("char {0}[{1}];", varName, pThis.maxItems(cns) + 1);
        }

        public static void PrintCInitialize(IA5StringType pThis, PEREffectiveConstraint cns, Asn1Value defaultVal, StreamWriterLevel h, string typeName, string varName, int lev, int arrayDepth)
        {
            h.P(lev);
            if (defaultVal != null)
                h.WriteLine("strcpy({0}, {1});", varName, defaultVal.ToString());
            else
                h.WriteLine("memset({0}, 0x0, {1});", varName, pThis.maxItems(cns) + 1);
        }
        public static void PrintCEncode(IA5StringType pThis, PEREffectiveConstraint cns, StreamWriterLevel c, string errorCode, string varName, int lev)
        {
            long min = pThis.minItems(cns);
            long max = pThis.maxItems(cns);
            string i = "i" + (CLocalVariable.GetArrayIndex(varName) + 1);
            string prefix = varName;
            string nCount = "nCount" + (CLocalVariable.GetArrayIndex(varName) + 1);
            string curBlockSize = "curBlockSize" + (CLocalVariable.GetArrayIndex(varName) + 1);
            string curItem = "curItem" + (CLocalVariable.GetArrayIndex(varName) + 1);

            if (max < 0x10000)
            {
                if (min != max)
                {
                    c.P(lev);
                    c.WriteLine("BitStream_EncodeConstraintWholeNumber(pBitStrm, strlen({0}), {1}, {2});", prefix, min, max);
                }
                else
                {
                    c.P(lev); c.WriteLine("/* No need to encode length (it is fixed size ({0})*/", min);
                }
                c.P(lev); c.WriteLine("for({0}=0;{0}<strlen({1});{0}++)", i, prefix);
                c.P(lev); c.WriteLine("{");
                ((ISCCSizeable)pThis).PrintCEncodeItem(cns, c, errorCode + "_elem", prefix + "[" + i + "]", lev + 1);
                c.P(lev); c.WriteLine("}");
            }
            else
            {
                SCCSizeable.PrintCEncodeFragmentation(pThis, cns, c, errorCode, varName, lev,
                    string.Format(nCount + " = strlen({0});", prefix), "", max, i, prefix, nCount, curBlockSize, curItem);
            }
        }

        public static void PrintCEncodeItem(IA5StringType pThis, PEREffectiveConstraint cns, StreamWriterLevel c, string errorCode, string varName, int lev)
        {
            PERAlphabetAndSizeEffectiveConstraint cn = (PERAlphabetAndSizeEffectiveConstraint)cns;
            CharSet perAlphaCon = cn.m_from;
            int min = 0;
            int max;
            List<char> tmp = null;
            if (perAlphaCon != null)
                tmp = perAlphaCon.m_set;
            else
                tmp = new List<char>(pThis.AllowedCharSet);
            max = tmp.Count - 1;
            if (min == max)
                return;
            c.P(lev);
            c.Write("static byte allowedCharSet[] = {");
            for (int i = 0; i < tmp.Count; i++)
            {
                c.Write("0x{0:X2}", Convert.ToByte(tmp[i]));
                if (i == tmp.Count - 1)
                    c.WriteLine("};");
                else
                    c.Write(",");
                if ((i + 1) % 15 == 0)
                {
                    c.WriteLine();
                    c.P(lev + 7);
                }
            }
            c.P(lev);
            c.WriteLine("int charIndex = GetCharIndex({0}, allowedCharSet,{1});", varName, tmp.Count);
            c.P(lev);
            c.WriteLine("BitStream_EncodeConstraintWholeNumber(pBitStrm, charIndex, {0}, {1});", 0, tmp.Count - 1);
        }
        public static void PrintCDecode(IA5StringType pThis, PEREffectiveConstraint cns, StreamWriterLevel c, string varName, int lev)
        {
            long min = pThis.minItems(cns);
            long max = pThis.maxItems(cns);
            string i = "i" + (CLocalVariable.GetArrayIndex(varName) + 1);
            string length = "length" + (CLocalVariable.GetArrayIndex(varName) + 1);
            string curBlockSize = "curBlockSize" + (CLocalVariable.GetArrayIndex(varName) + 1);
            //            string curItem = "curItem" + (CLocalVariable.GetArrayIndex(varName) + 1);
            string nCount = "nCount" + (CLocalVariable.GetArrayIndex(varName) + 1);
            string prefix = varName;

            c.P(lev);
            c.WriteLine("memset({0}, 0x0, {1});", varName, pThis.maxItems(cns) + 1);
            if (max < 0x10000)
            {
                if (min != max)
                {
                    c.P(lev);
                    c.WriteLine("if (!BitStream_DecodeConstraintWholeNumber(pBitStrm, &nCount, {0}, {1})) {{", min, max);
                    c.P(lev + 1);
                    c.WriteLine("*pErrCode = ERR_INSUFFICIENT_DATA;");
                    c.P(lev + 1);
                    c.WriteLine("return FALSE;");
                    c.P(lev);
                    c.WriteLine("}");

                }
                else
                {
                    c.P(lev);
                    c.WriteLine("nCount = {0};", max);
                }
                c.P(lev); c.WriteLine("for({0}=0;{0}<nCount;{0}++)", i);
                c.P(lev); c.WriteLine("{");
                ((ISCCSizeable)pThis).PrintCDecodeItem(cns, c, prefix + "[" + i + "]", lev + 1);
                c.P(lev); c.WriteLine("}");
            }
            else
            {
                SCCSizeable.PrintCDecodeFragmentation(pThis, cns, c, varName, lev,
                        "", max, i, prefix, length, curBlockSize, nCount);
            }

        }
        public static void PrintCDecodeItem(IA5StringType pThis, PEREffectiveConstraint cns, StreamWriterLevel c, string varName, int lev)
        {
            PERAlphabetAndSizeEffectiveConstraint cn = (PERAlphabetAndSizeEffectiveConstraint)cns;
            CharSet perAlphaCon = cn.m_from;
            int min = 0;
            int max;
            List<char> tmp = null;
            if (perAlphaCon != null)
                tmp = perAlphaCon.m_set;
            else
                tmp = new List<char>(pThis.AllowedCharSet);
            max = tmp.Count - 1;
            if (min == max)
                return;
            c.P(lev);
            c.Write("static byte allowedCharSet[] = {");
            for (int i = 0; i < tmp.Count; i++)
            {
                c.Write("0x{0:X2}", Convert.ToByte(tmp[i]));
                if (i == tmp.Count - 1)
                    c.WriteLine("};");
                else
                    c.Write(",");
                if ((i + 1) % 15 == 0)
                {
                    c.WriteLine();
                    c.P(lev + 7);
                }
            }
            c.P(lev);
            c.WriteLine("asn1SccSint charIndex = 0;");
            c.P(lev);
            c.WriteLine("if (!BitStream_DecodeConstraintWholeNumber(pBitStrm, &charIndex, {0}, {1})) {{", 0, tmp.Count - 1);
            c.P(lev + 1);
            c.WriteLine("*pErrCode = ERR_INSUFFICIENT_DATA;");
            c.P(lev + 1);
            c.WriteLine("return FALSE;");
            c.P(lev);
            c.WriteLine("}");

            c.P(lev);
            c.WriteLine("{0} = allowedCharSet[charIndex];", varName);
        }

    }


    public class SCCIA5StringType : IA5StringType, ISCCType, ISCCSizeable
    {
        public void PrintHTypeDeclaration(PEREffectiveConstraint cns, StreamWriterLevel h, string typeName, string varName, int lev)
        {
            SCCStringBase.PrintHTypeDeclaration(this, cns, h, typeName, varName, lev);
        }
        public void PrintHConstraintConstant(StreamWriterLevel h, string name)
        {
            CSSType.PrintHConstraintConstant(this, h, name);
        }
        public void VarsNeededForPrintCInitialize(int arrayDepth, OrderedDictionary<string, CLocalVariable> existingVars)
        {
        }
        public void PrintCInitialize(PEREffectiveConstraint cns, Asn1Value defaultVal, StreamWriterLevel h, string typeName, string varName, int lev, int arrayDepth)
        {
            SCCStringBase.PrintCInitialize(this, cns, defaultVal, h, typeName, varName, lev, arrayDepth);
        }
        public void VarsNeededForIsConstraintValid(int lev, OrderedDictionary<string, CLocalVariable> existingVars)
        {
        }

        public void PrintCIsConstraintValid(PEREffectiveConstraint cns, StreamWriterLevel c, string errorCode, string typeName, string varName, int lev, int arrayDepth)
        {
            CSSType.PrintCIsConstraintValid(this, cns, c, errorCode, typeName, varName, lev, arrayDepth);
        }
        public void VarsNeededForEncode(PEREffectiveConstraint cns, int arrayDepth, OrderedDictionary<string, CLocalVariable> existingVars) 
        {
            SCCSizeable.VarsNeededForEncode(this, cns, arrayDepth, existingVars);
        }
        public void PrintCEncode(PEREffectiveConstraint cns, StreamWriterLevel c, string errorCode, string varName, int lev)
        {
            SCCStringBase.PrintCEncode(this, cns, c, errorCode, varName, lev);
        }
        public void PrintCEncodeItem(PEREffectiveConstraint cns, StreamWriterLevel c, string errorCode, string varName, int lev)
        {
            SCCStringBase.PrintCEncodeItem(this, cns, c, errorCode, varName, lev);
        }
        public void VarsNeededForDecode(PEREffectiveConstraint cns, int arrayDepth, OrderedDictionary<string, CLocalVariable> existingVars)
        {
            SCCSizeable.VarsNeededForDecode(this, cns, arrayDepth, existingVars);
        }
        public void PrintCDecode(PEREffectiveConstraint cns, StreamWriterLevel c, string varName, int lev)
        {
            SCCStringBase.PrintCDecode(this, cns, c, varName, lev);
        }
        public void PrintCDecodeItem(PEREffectiveConstraint cns, StreamWriterLevel c, string varName, int lev)
        {
            SCCStringBase.PrintCDecodeItem(this, cns, c, varName, lev);
        }
    }

    public class SCCNumericStringType : NumericStringType, ISCCType, ISCCSizeable
    {
        public void PrintHTypeDeclaration(PEREffectiveConstraint cns, StreamWriterLevel h, string typeName, string varName, int lev)
        {
            SCCStringBase.PrintHTypeDeclaration(this, cns, h, typeName, varName, lev);
        }
        public void PrintHConstraintConstant(StreamWriterLevel h, string name)
        {
            CSSType.PrintHConstraintConstant(this, h, name);
        }
        public void VarsNeededForPrintCInitialize(int arrayDepth, OrderedDictionary<string, CLocalVariable> existingVars)
        {
        }
        public void PrintCInitialize(PEREffectiveConstraint cns, Asn1Value defaultVal, StreamWriterLevel h, string typeName, string varName, int lev, int arrayDepth)
        {
            SCCStringBase.PrintCInitialize(this, cns, defaultVal, h, typeName, varName, lev, arrayDepth);
        }
        public void VarsNeededForIsConstraintValid(int lev, OrderedDictionary<string, CLocalVariable> existingVars)
        {
        }
        public void PrintCIsConstraintValid(PEREffectiveConstraint cns, StreamWriterLevel c, string errorCode, string typeName, string varName, int lev, int arrayDepth)
        {
            CSSType.PrintCIsConstraintValid(this, cns, c, errorCode, typeName, varName, lev, arrayDepth);
        }
        public void VarsNeededForEncode(PEREffectiveConstraint cns, int arrayDepth, OrderedDictionary<string, CLocalVariable> existingVars) 
        {
            SCCSizeable.VarsNeededForEncode(this, cns, arrayDepth, existingVars);
        }
        public void PrintCEncode(PEREffectiveConstraint cns, StreamWriterLevel c, string errorCode, string varName, int lev)
        {
            SCCStringBase.PrintCEncode(this, cns, c, errorCode, varName, lev);
        }
        public void PrintCEncodeItem(PEREffectiveConstraint cns, StreamWriterLevel c, string errorCode, string varName, int lev)
        {
            SCCStringBase.PrintCEncodeItem(this, cns, c, errorCode, varName, lev);
        }
        public void VarsNeededForDecode(PEREffectiveConstraint cns, int arrayDepth, OrderedDictionary<string, CLocalVariable> existingVars)
        {
            SCCSizeable.VarsNeededForDecode(this, cns, arrayDepth, existingVars);
        }
        public void PrintCDecode(PEREffectiveConstraint cns, StreamWriterLevel c, string varName, int lev)
        {
            SCCStringBase.PrintCDecode(this, cns, c, varName, lev);
        }
        public void PrintCDecodeItem(PEREffectiveConstraint cns, StreamWriterLevel c, string varName, int lev)
        {
            SCCStringBase.PrintCDecodeItem(this, cns, c, varName, lev);
        }
    }

    public class SCCGeneralizedTimeType : GeneralizedTimeType, ISCCType, ISCCSizeable
    {
        public void PrintHTypeDeclaration(PEREffectiveConstraint cns, StreamWriterLevel h, string typeName, string varName, int lev)
        {
            SCCStringBase.PrintHTypeDeclaration(this, cns, h, typeName, varName, lev);
        }
        public void PrintHConstraintConstant(StreamWriterLevel h, string name)
        {
            CSSType.PrintHConstraintConstant(this, h, name);
        }
        public void VarsNeededForPrintCInitialize(int arrayDepth, OrderedDictionary<string, CLocalVariable> existingVars)
        {
        }
        public void PrintCInitialize(PEREffectiveConstraint cns, Asn1Value defaultVal, StreamWriterLevel h, string typeName, string varName, int lev, int arrayDepth)
        {
            SCCStringBase.PrintCInitialize(this, cns, defaultVal, h, typeName, varName, lev, arrayDepth);
        }
        public void VarsNeededForIsConstraintValid(int lev, OrderedDictionary<string, CLocalVariable> existingVars)
        {
        }
        public void PrintCIsConstraintValid(PEREffectiveConstraint cns, StreamWriterLevel c, string errorCode, string typeName, string varName, int lev, int arrayDepth)
        {
            CSSType.PrintCIsConstraintValid(this, cns, c, errorCode, typeName, varName, lev, arrayDepth);
        }
        public void VarsNeededForEncode(PEREffectiveConstraint cns, int arrayDepth, OrderedDictionary<string, CLocalVariable> existingVars) 
        {
            SCCSizeable.VarsNeededForEncode(this, cns, arrayDepth, existingVars);
        }
        public void PrintCEncode(PEREffectiveConstraint cns, StreamWriterLevel c, string errorCode, string varName, int lev)
        {
            SCCStringBase.PrintCEncode(this, cns, c, errorCode, varName, lev);
        }
        public void PrintCEncodeItem(PEREffectiveConstraint cns, StreamWriterLevel c, string errorCode, string varName, int lev)
        {
            SCCStringBase.PrintCEncodeItem(this, cns, c, errorCode, varName, lev);
        }
        public void VarsNeededForDecode(PEREffectiveConstraint cns, int arrayDepth, OrderedDictionary<string, CLocalVariable> existingVars)
        {
            SCCSizeable.VarsNeededForDecode(this, cns, arrayDepth, existingVars);
        }
        public void PrintCDecode(PEREffectiveConstraint cns, StreamWriterLevel c, string varName, int lev)
        {
            SCCStringBase.PrintCDecode(this, cns, c, varName, lev);
        }
        public void PrintCDecodeItem(PEREffectiveConstraint cns, StreamWriterLevel c, string varName, int lev)
        {
            SCCStringBase.PrintCDecodeItem(this, cns, c, varName, lev);
        }
    }

    public class SCCUTCTimeType : UTCTimeType, ISCCType, ISCCSizeable
    {
        public void PrintHTypeDeclaration(PEREffectiveConstraint cns, StreamWriterLevel h, string typeName, string varName, int lev)
        {
            SCCStringBase.PrintHTypeDeclaration(this, cns, h, typeName, varName, lev);
        }
        public void PrintHConstraintConstant(StreamWriterLevel h, string name)
        {
            CSSType.PrintHConstraintConstant(this, h, name);
        }
        public void VarsNeededForPrintCInitialize(int arrayDepth, OrderedDictionary<string, CLocalVariable> existingVars)
        {
        }
        public void PrintCInitialize(PEREffectiveConstraint cns, Asn1Value defaultVal, StreamWriterLevel h, string typeName, string varName, int lev, int arrayDepth)
        {
            SCCStringBase.PrintCInitialize(this, cns, defaultVal, h, typeName, varName, lev, arrayDepth);
        }
        public void VarsNeededForIsConstraintValid(int lev, OrderedDictionary<string, CLocalVariable> existingVars)
        {
        }
        public void PrintCIsConstraintValid(PEREffectiveConstraint cns, StreamWriterLevel c, string errorCode, string typeName, string varName, int lev, int arrayDepth)
        {
            CSSType.PrintCIsConstraintValid(this, cns, c, errorCode, typeName, varName, lev, arrayDepth);
        }
        public void VarsNeededForEncode(PEREffectiveConstraint cns, int arrayDepth, OrderedDictionary<string, CLocalVariable> existingVars) 
        {
            SCCSizeable.VarsNeededForEncode(this, cns, arrayDepth, existingVars);
        }
        public void PrintCEncode(PEREffectiveConstraint cns, StreamWriterLevel c, string errorCode, string varName, int lev)
        {
            SCCStringBase.PrintCEncode(this, cns, c, errorCode, varName, lev);
        }
        public void PrintCEncodeItem(PEREffectiveConstraint cns, StreamWriterLevel c, string errorCode, string varName, int lev)
        {
            SCCStringBase.PrintCEncodeItem(this, cns, c, errorCode, varName, lev);
        }
        public void VarsNeededForDecode(PEREffectiveConstraint cns, int arrayDepth, OrderedDictionary<string, CLocalVariable> existingVars)
        {
            SCCSizeable.VarsNeededForDecode(this, cns, arrayDepth, existingVars);
        }
        public void PrintCDecode(PEREffectiveConstraint cns, StreamWriterLevel c, string varName, int lev)
        {
            SCCStringBase.PrintCDecode(this, cns, c, varName, lev);
        }
        public void PrintCDecodeItem(PEREffectiveConstraint cns, StreamWriterLevel c, string varName, int lev)
        {
            SCCStringBase.PrintCDecodeItem(this, cns, c, varName, lev);
        }
    }
}