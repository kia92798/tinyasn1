using System;
using System.Collections.Generic;
using System.Text;
using tinyAsn1;

namespace asn1scc
{

    public interface ISCCSizeable
    {
        void PrintCEncodeItem(PEREffectiveConstraint cns, StreamWriterLevel c, string errorCode, string varName, int lev);
        void PrintCDecodeItem(PEREffectiveConstraint cns, StreamWriterLevel c, string varName, int lev);
    }

    public static class SCCSizeable
    {
        public static void VarsNeededForEncode(SizeableType pThis, PEREffectiveConstraint cns, int arrayDepth, OrderedDictionary<string, CLocalVariable> existingVars)
        {
            string var = "i" + arrayDepth.ToString();
            if (!existingVars.ContainsKey(var))
            {
                existingVars.Add(var, new CLocalVariable(var, "int", 0, "0"));
            }
            if (pThis.maxItems(cns) > 0x10000)
            {
                var = "nCount" + arrayDepth.ToString();
                if (!existingVars.ContainsKey(var))
                    existingVars.Add(var, new CLocalVariable(var, "asn1SccSint", 0, "0"));
                var = "curBlockSize" + arrayDepth.ToString();
                if (!existingVars.ContainsKey(var))
                    existingVars.Add(var, new CLocalVariable(var, "asn1SccSint", 0, "0"));
                var = "curItem" + arrayDepth.ToString();
                if (!existingVars.ContainsKey(var))
                    existingVars.Add(var, new CLocalVariable(var, "asn1SccSint", 0, "0"));
            }
        }

        public static void PrintCEncode(SizeableType pThis, PEREffectiveConstraint cns, StreamWriterLevel c, string errorCode, string varName, int lev)
        {
            long min = pThis.minItems(cns);
            long max = pThis.maxItems(cns);
            string i = "i" + (CLocalVariable.GetArrayIndex(varName) + 1);
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

                c.P(lev); c.WriteLine("for({0}=0;{0}<{1}nCount;{0}++)", i, prefix);
                c.P(lev); c.WriteLine("{");
                ((ISCCSizeable)pThis).PrintCEncodeItem(cns, c, errorCode + "_elem", prefix + "arr[" + i + "]", lev + 1);
                c.P(lev); c.WriteLine("}");
            }
            else
            {
                PrintCEncodeFragmentation(pThis, cns, c, errorCode, varName, lev,
                    string.Format(nCount + " = {0}nCount;", prefix), "arr", max, i, prefix,
                    nCount, curBlockSize, curItem);
            }
        }

        public static void PrintCEncodeFragmentation(SizeableType pThis, PEREffectiveConstraint cns, StreamWriterLevel c, string errorCode, string varName, int lev,
            string nCountInit, string arrName, long max, string i, string prefix, string nCount, string curBlockSize, string curItem)
        {

            c.P(lev); c.WriteLine("/* Fragmentation required since {0} is grater than 64K*/", max);

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

            c.P(lev); c.WriteLine("for({0}={1}; {0} < {2} + {1}; {0}++)", i, curItem, curBlockSize);
            c.P(lev); c.WriteLine("{");
            ((ISCCSizeable)pThis).PrintCEncodeItem(cns, c, errorCode + "_elem", prefix + arrName + "[" + i + "]", lev + 1);
            c.P(lev); c.WriteLine("}");
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
            c.P(lev); c.WriteLine("for({0}={1}; {0} < {1} + {2}; {0}++)", i, curItem, nCount);
            c.P(lev); c.WriteLine("{");
            ((ISCCSizeable)pThis).PrintCEncodeItem(cns, c, errorCode + "_elem", prefix + arrName + "[" + i + "]", lev + 1);
            c.P(lev); c.WriteLine("}");
        }

        public static void VarsNeededForDecode(SizeableType pThis, PEREffectiveConstraint cns, int arrayDepth, OrderedDictionary<string, CLocalVariable> existingVars)
        {
            string var;
            if (pThis.maxItems(cns) <= 0x10000)
            {
                if (!existingVars.ContainsKey("nCount"))
                {
                    existingVars.Add("nCount", new CLocalVariable("nCount", "asn1SccSint", 0, "0"));
                }
            }
            else
            {
                var = "nCount" + arrayDepth.ToString();
                if (!existingVars.ContainsKey(var))
                    existingVars.Add(var, new CLocalVariable(var, "asn1SccSint", 0, "0"));
            }
            var = "i" + arrayDepth.ToString();
            if (!existingVars.ContainsKey(var))
            {
                existingVars.Add(var, new CLocalVariable(var, "int", 0, "0"));
            }
            if (pThis.maxItems(cns) > 0x10000)
            {
                var = "length" + arrayDepth.ToString();
                if (!existingVars.ContainsKey(var))
                    existingVars.Add(var, new CLocalVariable(var, "asn1SccSint", 0, "0"));
                var = "curBlockSize" + arrayDepth.ToString();
                if (!existingVars.ContainsKey(var))
                    existingVars.Add(var, new CLocalVariable(var, "asn1SccSint", 0, "0"));
                var = "curItem" + arrayDepth.ToString();
                if (!existingVars.ContainsKey(var))
                    existingVars.Add(var, new CLocalVariable(var, "asn1SccSint", 0, "0"));
            }
        }

        public static void PrintCDecode(SizeableType pThis, PEREffectiveConstraint cns, StreamWriterLevel c, string varName, int lev)
        {
            long min = pThis.minItems(cns);
            long max = pThis.maxItems(cns);
            string i = "i" + (CLocalVariable.GetArrayIndex(varName) + 1);
            string length = "length" + (CLocalVariable.GetArrayIndex(varName) + 1);
            string curBlockSize = "curBlockSize" + (CLocalVariable.GetArrayIndex(varName) + 1);
            //            string curItem = "curItem" + (CLocalVariable.GetArrayIndex(varName) + 1);
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

                c.P(lev); c.WriteLine("for({0}=0;{0}<{1}nCount;{0}++)", i, prefix);
                c.P(lev); c.WriteLine("{");
                ((ISCCSizeable)pThis).PrintCDecodeItem(cns, c, prefix + "arr[" + i + "]", lev + 1);
                c.P(lev); c.WriteLine("}");
            }
            else
            {
                c.P(lev); c.WriteLine("/* Fragmentation required since {0} is grater than 64K*/", max);
                PrintCDecodeFragmentation(pThis, cns, c, varName, lev,
                        "arr", max, i, prefix, length, curBlockSize, nCount);

            }
        }

        public static void PrintCDecodeFragmentation(SizeableType pThis, PEREffectiveConstraint cns, StreamWriterLevel c, string varName, int lev,
            string arrName, long max, string i, string prefix,
            string length, string curBlockSize, string nCount)
        {
            c.P(lev); c.WriteLine("/* Fragmentation required since {0} is grater than 64K*/", max);
            c.WriteCodeBlock(lev,
@"if (!BitStream_DecodeConstraintWholeNumber(pBitStrm, &{1}, 0, 0xFF))
{{
    *pErrCode = ERR_INSUFFICIENT_DATA;
    return FALSE;
}}
while(({1} & 0xC0)>0) 
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
	if ({3}+{2}>100000)
	{{
		*pErrCode = ERR_INSUFFICIENT_DATA;
		return FALSE;
	}}

	for({0}=0;{0}<{2};{0}++)
	{{", i, length, curBlockSize, nCount);

            ((ISCCSizeable)pThis).PrintCDecodeItem(cns, c, prefix + arrName + "[" + i + "]", lev + 2);

            c.WriteCodeBlock(lev,
@"    }}
	{3}+={2};

	if (!BitStream_DecodeConstraintWholeNumber(pBitStrm, &{1}, 0, 0xFF)) {{
		*pErrCode = ERR_INSUFFICIENT_DATA;
		return FALSE;
	}}
}}
if ( ({1} & 0x80)>0) 
{{
	asn1SccSint len2;
	len2<<=8;
	if (!BitStream_DecodeConstraintWholeNumber(pBitStrm, &len2, 0, 0xFF)) {{
		*pErrCode = ERR_INSUFFICIENT_DATA;
		return FALSE;
	}}
	{1} |= len2;
	{1} |= 0x7FFF;
}}

if ({3}+{1}>100000)
{{
	*pErrCode = ERR_INSUFFICIENT_DATA;
	return FALSE;
}}
for({0}=0;{0}<{1};{0}++)
{{
", i, length, curBlockSize, nCount);
            ((ISCCSizeable)pThis).PrintCDecodeItem(cns, c, prefix + arrName + "[" + i + "]", lev + 1);

            c.WriteCodeBlock(lev,
@"}}
{0}+=(long){1};", nCount, length);
            if (arrName != "")
            {
                c.P(lev);
                c.WriteLine("{0}nCount = (long){1};", prefix, nCount);
            }

        }

    }
    
    
    public static class SCCArray
    {
        public static void PrintHTypeDeclaration(ArrayType pThis, PEREffectiveConstraint cns, StreamWriterLevel h, string typeName, string varName, int lev)
        {
            long min = pThis.minItems(cns);
            long max = pThis.maxItems(cns);
            h.WriteLine("struct {");
            //            h.WriteLine("struct {0} {{", typeName);
            //            if (min != max)
            {
                h.P(lev + 1);
                h.WriteLine("long nCount;");
            }
            h.P(lev + 1); ((ISCCType)pThis.m_type).PrintHTypeDeclaration(pThis.m_type.PEREffectiveConstraint, h, typeName + "_arr"/*+varName*/, "arr", lev + 1);
            h.WriteLine(" arr[{0}];", max);
            h.P(lev);
            h.Write("}");
        }
     
        public static void PrintHConstraintConstant(ArrayType pThis, StreamWriterLevel h, string name)
        {
            CSSType.PrintHConstraintConstant(pThis, h, C.ID(name));
            ((ISCCType)pThis.m_type).PrintHConstraintConstant(h, C.ID(name) + "_elem");
        }

        public static void VarsNeededForPrintCInitialize(ArrayType pThis, int arrayDepth, OrderedDictionary<string, CLocalVariable> existingVars)
        {
            string var = "i" + arrayDepth.ToString();
            if (!existingVars.ContainsKey(var))
            {
                existingVars.Add(var, new CLocalVariable(var, "int", 0, "0"));
            }
            ((ISCCType)pThis.m_type).VarsNeededForPrintCInitialize(arrayDepth + 1, existingVars);
        }

        public static void PrintCInitialize(ArrayType pThis, PEREffectiveConstraint cns,
            Asn1Value defauleVal, StreamWriterLevel c, string typeName, string varName, int lev, int arrayDepth)
        {
            long min = pThis.minItems(cns);
            long max = pThis.maxItems(cns);
            string i = "i" + arrayDepth.ToString();
            string prefix = "";
            bool topLevel = !varName.Contains("->");
            if (topLevel)
                prefix = varName + "->";
            else
            {
                prefix = varName + ".";
            }

            c.P(lev);
            c.WriteLine("{0}nCount = 0;", prefix);

            c.P(lev); c.WriteLine("for({0}=0;{0}<{1};{0}++)", i, pThis.maxItems(cns));
            c.P(lev); c.WriteLine("{");
            ((ISCCType)pThis.m_type).PrintCInitialize(pThis.m_type.PEREffectiveConstraint, null, c,
                typeName + "_arr", prefix + "arr[" + i + "]", lev + 1, arrayDepth + 1);
            c.P(lev); c.WriteLine("}");
        }

        public static void VarsNeededForIsConstraintValid(ArrayType pThis, int arrayDepth, OrderedDictionary<string, CLocalVariable> existingVars)
        {
            string var = "i" + arrayDepth.ToString();
            if (!existingVars.ContainsKey(var))
            {
                existingVars.Add(var, new CLocalVariable(var, "int", 0, "0"));
            }
            ((ISCCType)pThis.m_type).VarsNeededForIsConstraintValid(arrayDepth + 1, existingVars);
        }

        public static void PrintCIsConstraintValid(ArrayType pThis, PEREffectiveConstraint cns, StreamWriterLevel c, string errorCode, string typeName, string varName, int lev, int arrayDepth)
        {
            long min = pThis.minItems(cns);
            long max = pThis.maxItems(cns);
            string i = "i" + arrayDepth.ToString();
            string prefix = "";
            bool topLevel = !varName.Contains("->");

            CSSType.PrintCIsConstraintValid(pThis, cns, c, errorCode, typeName, varName, lev, arrayDepth);

            c.WriteLine();
            if (topLevel)
                prefix = varName + "->";
            else
            {
                prefix = varName + ".";
            }

            c.P(lev); c.WriteLine("for({0}=0;{0}<{1}nCount;{0}++)", i, prefix);
            c.P(lev); c.WriteLine("{");
            ((ISCCType)pThis.m_type).PrintCIsConstraintValid(pThis.m_type.PEREffectiveConstraint, c, errorCode + "_elem",
                typeName + "_arr", prefix + "arr[" + i + "]", lev + 1, arrayDepth + 1);
            c.P(lev); c.WriteLine("}");
        }

        public static void VarsNeededForEncode(ArrayType pThis, PEREffectiveConstraint cns, int arrayDepth, OrderedDictionary<string, CLocalVariable> existingVars)
        {
            SCCSizeable.VarsNeededForEncode(pThis, cns, arrayDepth, existingVars);
            ((ISCCType)pThis.m_type).VarsNeededForEncode(pThis.m_type.PEREffectiveConstraint, arrayDepth + 1, existingVars);
        }
        public static void PrintCEncodeItem(ArrayType pThis, PEREffectiveConstraint cns, StreamWriterLevel c, string errorCode, string varName, int lev)
        {
            c.P(lev); c.WriteLine("/*Encode childlen : ({0})*/", pThis.m_type.Name);
            ((ISCCType)pThis.m_type).PrintCEncode(pThis.m_type.PEREffectiveConstraint, c, errorCode, varName, lev);
        }

        public static void VarsNeededForDecode(ArrayType pThis, PEREffectiveConstraint cns, int arrayDepth, OrderedDictionary<string, CLocalVariable> existingVars)
        {
            SCCSizeable.VarsNeededForDecode(pThis, cns, arrayDepth, existingVars);
            ((ISCCType)pThis.m_type).VarsNeededForDecode(pThis.m_type.PEREffectiveConstraint, arrayDepth + 1, existingVars);
        }
        public static void PrintCDecodeItem(ArrayType pThis, PEREffectiveConstraint cns, StreamWriterLevel c, string varName, int lev)
        {
            c.P(lev); c.WriteLine("/*Decode childlen : ({0})*/", pThis.m_type.Name);
            ((ISCCType)pThis.m_type).PrintCDecode(pThis.m_type.PEREffectiveConstraint, c, varName, lev);
        }

    }


    public class SCCSequenceOfType : SequenceOfType, ISCCType, ISCCSizeable
    {
        public void PrintHTypeDeclaration(PEREffectiveConstraint cns, StreamWriterLevel h, string typeName, string varName, int lev)
        {
            SCCArray.PrintHTypeDeclaration(this, cns, h, typeName, varName, lev);
        }
        public void PrintHConstraintConstant(StreamWriterLevel h, string name)
        {
            SCCArray.PrintHConstraintConstant(this, h, name);
        }
        public void VarsNeededForPrintCInitialize(int arrayDepth, OrderedDictionary<string, CLocalVariable> existingVars)
        {
            SCCArray.VarsNeededForPrintCInitialize(this, arrayDepth, existingVars);
        }
        public void PrintCInitialize( PEREffectiveConstraint cns,
            Asn1Value defauleVal, StreamWriterLevel c, string typeName, string varName, int lev, int arrayDepth)
        {
            SCCArray.PrintCInitialize(this, cns, defauleVal, c, typeName, varName, lev, arrayDepth);
        }
        public void VarsNeededForIsConstraintValid(int arrayDepth, OrderedDictionary<string, CLocalVariable> existingVars)
        {
            SCCArray.VarsNeededForIsConstraintValid(this, arrayDepth, existingVars);
        }
        public void PrintCIsConstraintValid(PEREffectiveConstraint cns, StreamWriterLevel c, string errorCode, string typeName, string varName, int lev, int arrayDepth)
        {
            SCCArray.PrintCIsConstraintValid(this, cns, c, errorCode, typeName, varName, lev, arrayDepth);
        }
        public void VarsNeededForEncode(PEREffectiveConstraint cns, int arrayDepth, OrderedDictionary<string, CLocalVariable> existingVars)
        {
            SCCArray.VarsNeededForEncode(this, cns, arrayDepth, existingVars);
        }

        public void PrintCEncode(PEREffectiveConstraint cns, StreamWriterLevel c, string errorCode, string varName, int lev)
        {
            SCCSizeable.PrintCEncode(this, cns, c, errorCode, varName, lev);
        }

        public void PrintCEncodeItem(PEREffectiveConstraint cns, StreamWriterLevel c, string errorCode, string varName, int lev)
        {
            SCCArray.PrintCEncodeItem(this, cns, c, errorCode, varName, lev);
        }
        public void VarsNeededForDecode(PEREffectiveConstraint cns, int arrayDepth, OrderedDictionary<string, CLocalVariable> existingVars)
        {
            SCCArray.VarsNeededForDecode(this, cns, arrayDepth, existingVars);
        }
        public void PrintCDecodeItem(PEREffectiveConstraint cns, StreamWriterLevel c, string varName, int lev)
        {
            SCCArray.PrintCDecodeItem(this, cns, c, varName, lev);
        }
        public void PrintCDecode(PEREffectiveConstraint cns, StreamWriterLevel c, string varName, int lev)
        {
            SCCSizeable.PrintCDecode(this, cns, c, varName, lev);
        }
    }

    public class SCCSetOfType : SetOfType, ISCCType, ISCCSizeable
    {
        public void PrintHTypeDeclaration(PEREffectiveConstraint cns, StreamWriterLevel h, string typeName, string varName, int lev)
        {
            SCCArray.PrintHTypeDeclaration(this, cns, h, typeName, varName, lev);
        }
        public void PrintHConstraintConstant(StreamWriterLevel h, string name)
        {
            SCCArray.PrintHConstraintConstant(this, h, name);
        }
        public void VarsNeededForPrintCInitialize(int arrayDepth, OrderedDictionary<string, CLocalVariable> existingVars)
        {
            SCCArray.VarsNeededForPrintCInitialize(this, arrayDepth, existingVars);
        }
        public void PrintCInitialize(PEREffectiveConstraint cns,
            Asn1Value defauleVal, StreamWriterLevel c, string typeName, string varName, int lev, int arrayDepth)
        {
            SCCArray.PrintCInitialize(this, cns, defauleVal, c, typeName, varName, lev, arrayDepth);
        }
        public void VarsNeededForIsConstraintValid(int arrayDepth, OrderedDictionary<string, CLocalVariable> existingVars)
        {
            SCCArray.VarsNeededForIsConstraintValid(this, arrayDepth, existingVars);
        }
        public void PrintCIsConstraintValid(PEREffectiveConstraint cns, StreamWriterLevel c, string errorCode, string typeName, string varName, int lev, int arrayDepth)
        {
            SCCArray.PrintCIsConstraintValid(this, cns, c, errorCode, typeName, varName, lev, arrayDepth);
        }
        public void VarsNeededForEncode(PEREffectiveConstraint cns, int arrayDepth, OrderedDictionary<string, CLocalVariable> existingVars)
        {
            SCCArray.VarsNeededForEncode(this, cns, arrayDepth, existingVars);
        }
        public void PrintCEncode(PEREffectiveConstraint cns, StreamWriterLevel c, string errorCode, string varName, int lev)
        {
            SCCSizeable.PrintCEncode(this, cns, c, errorCode, varName, lev);
        }
        public void PrintCEncodeItem(PEREffectiveConstraint cns, StreamWriterLevel c, string errorCode, string varName, int lev)
        {
            SCCArray.PrintCEncodeItem(this, cns, c, errorCode, varName, lev);
        }
        public void VarsNeededForDecode(PEREffectiveConstraint cns, int arrayDepth, OrderedDictionary<string, CLocalVariable> existingVars)
        {
            SCCArray.VarsNeededForDecode(this, cns, arrayDepth, existingVars);
        }
        public void PrintCDecodeItem(PEREffectiveConstraint cns, StreamWriterLevel c, string varName, int lev)
        {
            SCCArray.PrintCDecodeItem(this, cns, c, varName, lev);
        }
        public void PrintCDecode(PEREffectiveConstraint cns, StreamWriterLevel c, string varName, int lev)
        {
            SCCSizeable.PrintCDecode(this, cns, c, varName, lev);
        }
    }
}
