using System;
using System.Collections.Generic;
using System.Text;
using Antlr.Runtime.Tree;
using Antlr.Runtime;

namespace tinyAsn1
{

    public class SizeableType : Asn1Type
    {
        public override long maxBitsInPER(PEREffectiveConstraint cns)
        {
            PERSizeEffectiveConstraint cn = (PERSizeEffectiveConstraint)cns;

            if (cn == null)
                return -1;
            if (cn.Extensible)
                return -1;
            if (cn.m_size.m_rootRange.m_maxIsInfinite)
                return -1;

            if (cn.m_size.m_rootRange.m_max < 0x10000 &&
                cn.m_size.m_rootRange.m_max == cn.m_size.m_rootRange.m_min)
                return cn.m_size.m_rootRange.m_max * maxItemBitsInPER(cns);

            if (cn.m_size.m_rootRange.m_max < 0x10000)
                return cn.m_size.m_rootRange.m_max * maxItemBitsInPER(cns) + PER.GetNumberOfBitsForNonNegativeInteger((ulong)(cn.m_size.m_rootRange.m_max - cn.m_size.m_rootRange.m_min));

            return cn.m_size.m_rootRange.m_max * maxItemBitsInPER(cns) + (cn.m_size.m_rootRange.m_max / 0x10000 + 3) * 8;
        }
        public override long minBitsInPER(PEREffectiveConstraint cns)
        {
            PERSizeEffectiveConstraint cn = (PERSizeEffectiveConstraint)cns;
            int extBit = 0;
            if (cn.Extensible)
                extBit++;

            if (cn == null)
                return extBit + 8;

            if (!cn.m_size.m_rootRange.m_maxIsInfinite)
            {
                if (cn.m_size.m_rootRange.m_max < 0x10000 &&
                    cn.m_size.m_rootRange.m_max == cn.m_size.m_rootRange.m_min)
                    return extBit + cn.m_size.m_rootRange.m_min * minItemBitsInPER(cns);

                if (cn.m_size.m_rootRange.m_max < 0x10000)
                    return extBit + cn.m_size.m_rootRange.m_min * minItemBitsInPER(cns) + PER.GetNumberOfBitsForNonNegativeInteger((ulong)(cn.m_size.m_rootRange.m_max - cn.m_size.m_rootRange.m_min));
            }


            if (cn.m_size.m_rootRange.m_min <= 0x7F)
                return extBit + cn.m_size.m_rootRange.m_min * minItemBitsInPER(cns) + 8;
            if (cn.m_size.m_rootRange.m_min <= 0x3FFF)
                return extBit + cn.m_size.m_rootRange.m_min * minItemBitsInPER(cns) + 16;


            return extBit + cn.m_size.m_rootRange.m_min * minItemBitsInPER(cns) + (cn.m_size.m_rootRange.m_min / 0x10000 + 3) * 8;
        }

        public virtual long minItemBitsInPER(PEREffectiveConstraint cns)
        {
            throw new Exception("Abstract method called");
        }
        public virtual long maxItemBitsInPER(PEREffectiveConstraint cns)
        {
            throw new Exception("Abstract method called");
        }

        public virtual string ItemConstraint(PEREffectiveConstraint cns)
        {
            throw new Exception("Abstract method called");
        }


        public long minItems(PEREffectiveConstraint cns)
        {
            if (cns == null)
                return 0;
            PERSizeEffectiveConstraint cn = (PERSizeEffectiveConstraint)cns;
            return cn.m_size.m_rootRange.m_min;
        }
        public long maxItems(PEREffectiveConstraint cns)
        {
            if (cns == null)
                return -1;
            PERSizeEffectiveConstraint cn = (PERSizeEffectiveConstraint)cns;
            if (cn.m_size.m_rootRange.m_maxIsInfinite)
                return -1;
            return cn.m_size.m_rootRange.m_max;
        }


        public long minSizeBitsInPER(PEREffectiveConstraint cns)
        {
            PERSizeEffectiveConstraint cn = (PERSizeEffectiveConstraint)cns;
            int extBit = 0;
            if (cn.Extensible)
                extBit++;

            if (cn == null)
                return extBit + 8;

            if (!cn.m_size.m_rootRange.m_maxIsInfinite)
            {
                if (cn.m_size.m_rootRange.m_max < 0x10000 &&
                    cn.m_size.m_rootRange.m_max == cn.m_size.m_rootRange.m_min)
                    return extBit;

                if (cn.m_size.m_rootRange.m_max < 0x10000)
                    return extBit + PER.GetNumberOfBitsForNonNegativeInteger((ulong)(cn.m_size.m_rootRange.m_max - cn.m_size.m_rootRange.m_min));
            }


            if (cn.m_size.m_rootRange.m_min <= 0x7F)
                return extBit + 8;
            if (cn.m_size.m_rootRange.m_min <= 0x3FFF)
                return extBit + 16;

            return -1;
        }

        public long maxSizeBitsInPER(PEREffectiveConstraint cns)
        {
            PERSizeEffectiveConstraint cn = (PERSizeEffectiveConstraint)cns;

            if (cn == null)
                return -1;
            if (cn.Extensible)
                return -1;
            if (cn.m_size.m_rootRange.m_maxIsInfinite)
                return -1;

            if (cn.m_size.m_rootRange.m_max < 0x10000 &&
                cn.m_size.m_rootRange.m_max == cn.m_size.m_rootRange.m_min)
                return 0;

            if (cn.m_size.m_rootRange.m_max < 0x10000)
                return PER.GetNumberOfBitsForNonNegativeInteger((ulong)(cn.m_size.m_rootRange.m_max - cn.m_size.m_rootRange.m_min));

            return -1;
        }




        internal override void VarsNeededForDecode(PEREffectiveConstraint cns, int arrayDepth, OrderedDictionary<string, CLocalVariable> existingVars)
        {
            string var;
            if (maxItems(cns) <= 0x10000)
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
            if (maxItems(cns) > 0x10000)
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

        internal override void PrintCDecode(PEREffectiveConstraint cns, StreamWriterLevel c, string varName, int lev)
        {
            long min = minItems(cns);
            long max = maxItems(cns);
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
                PrintCDecodeItem(cns, c, prefix + "arr[" + i + "]", lev + 1);
                c.P(lev); c.WriteLine("}");
            } 
            else
            {
                c.P(lev); c.WriteLine("/* Fragmentation required since {0} is grater than 64K*/", max);
                PrintCDecodeFragmentation(cns, c, varName, lev,
                        "arr", max, i, prefix, length, curBlockSize, nCount);

            }
        }

        protected virtual void PrintCDecodeFragmentation(PEREffectiveConstraint cns, StreamWriterLevel c, string varName, int lev,
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

            PrintCDecodeItem(cns, c, prefix + arrName+ "[" + i + "]", lev + 2);
            
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
", i, length,curBlockSize,nCount);
            PrintCDecodeItem(cns, c, prefix + arrName + "[" + i + "]", lev + 1);

            c.WriteCodeBlock(lev,
@"}}
{0}+=(long){1};", nCount, length);
            if (arrName != "")
            {
                c.P(lev);
                c.WriteLine("{0}nCount = (long){1};", prefix, nCount);
            }

        }

        protected virtual void PrintCDecodeItem(PEREffectiveConstraint cns, StreamWriterLevel c, string varName, int lev)
        {
            throw new AbstractMethodCalledException();
        }
    }


    /// <summary>
    /// Common base class for SEQUENCE OF and SET OF
    /// </summary>
    public partial class ArrayType : SizeableType
    {
        public string m_xmlVarName;
        public Asn1Type m_type;

        public override IEnumerable<T> GetMySelfAndAnyChildren<T>()
        {
            if (this is T)
                yield return this as T;
            foreach (T grCh in m_type.GetMySelfAndAnyChildren<T>())
                yield return grCh;
        }

        public override IEnumerable<KeyValuePair<string, T>> GetMySelfAndAnyChildrenWithPath<T>(string pathUpToHere)
        {
            if (this is T)
                yield return new KeyValuePair<string, T>(pathUpToHere, this as T);

            foreach (KeyValuePair<string, T> grCh in m_type.GetMySelfAndAnyChildrenWithPath<T>(pathUpToHere + "/arr"))
                yield return grCh;
        }


        static List<int> m_allowedTokens = new List<int>(new int[]{ asn1Parser.CONSTRAINT, asn1Parser.EXCEPTION_SPEC, asn1Parser.EXT_MARK, 
                asn1Parser.UNION_SET, asn1Parser.UNION_SET_ALL_EXCEPT, asn1Parser.INTERSECTION_SET,
                asn1Parser.INTERSECTION_ELEMENT, asn1Parser.VALUE_RANGE_EXPR, asn1Parser.SUBTYPE_EXPR, 
                asn1Parser.SIZE_EXPR, asn1Parser.SIMPLIFIED_SIZE_CONSTRAINT, asn1Parser.WITH_COMPONENT_CONSTR});
        static List<int> m_stopList = new List<int>(new int[] { asn1Parser.VALUE_RANGE_EXPR, asn1Parser.SUBTYPE_EXPR, asn1Parser.EXCEPTION_SPEC,
            asn1Parser.SIZE_EXPR, asn1Parser.SIMPLIFIED_SIZE_CONSTRAINT, asn1Parser.WITH_COMPONENT_CONSTR });

        protected override IEnumerable<int> AllowedTokensInConstraints { get { return m_allowedTokens; } }
        protected override IEnumerable<int> StopTokensInConstraints { get { return m_stopList; } }

        public override void CheckChildrensTags()
        {
            m_type.CheckChildrensTags();
        }

        public override void PerformAutomaticTagging()
        {
            m_type.PerformAutomaticTagging();
        }
        public override bool Compatible(Asn1Type other)
        {
            ArrayType o = other.GetFinalType() as ArrayType;
            if (o == null)
                return false;

            return m_type.Compatible(o.m_type);
        }
        public override void ComputePEREffectiveConstraints()
        {
            base.ComputePEREffectiveConstraints();
            m_type.ComputePEREffectiveConstraints();
        }

        private PERSizeEffectiveConstraint m_perEffectiveConstraint = null;
        public override PEREffectiveConstraint PEREffectiveConstraint
        {
            get
            {
                if (m_perEffectiveConstraint != null)
                    return m_perEffectiveConstraint;
                m_perEffectiveConstraint = Asn1CompilerInvokation.Instance.Factory.CreatePERSizeEffectiveConstraint();
                m_perEffectiveConstraint = (PERSizeEffectiveConstraint)m_perEffectiveConstraint.Compute(m_constraints,this);
                return m_perEffectiveConstraint;
            }
        }
/*        public override long minBitsInPER(PEREffectiveConstraint cns)
        {
            PERSizeEffectiveConstraint cn = (PERSizeEffectiveConstraint)cns;
            int extBit = 0;
            if (cn.Extensible)
                extBit++;

            if (cn == null)
                return extBit+8;

            if (!cn.m_size.m_rootRange.m_maxIsInfinite)
            {
                if (cn.m_size.m_rootRange.m_max < 0x10000 &&
                    cn.m_size.m_rootRange.m_max == cn.m_size.m_rootRange.m_min)
                    return extBit + cn.m_size.m_rootRange.m_min * m_type.MaxBitsInPER;

                if (cn.m_size.m_rootRange.m_max < 0x10000)
                    return extBit + cn.m_size.m_rootRange.m_min * m_type.MaxBitsInPER + PER.GetNumberOfBitsForNonNegativeInteger((ulong)(cn.m_size.m_rootRange.m_max - cn.m_size.m_rootRange.m_min));
            }


            if (cn.m_size.m_rootRange.m_min <= 0x7F)
                return extBit + cn.m_size.m_rootRange.m_min * m_type.MaxBitsInPER + 8;
            if (cn.m_size.m_rootRange.m_min <= 0x3FFF)
                return extBit + cn.m_size.m_rootRange.m_min * m_type.MaxBitsInPER + 16;


            return extBit + cn.m_size.m_rootRange.m_min * m_type.MaxBitsInPER + (cn.m_size.m_rootRange.m_min / 0x10000 + 3) * 8;
        }

        public override long maxBitsInPER(PEREffectiveConstraint cns)
        {
            PERSizeEffectiveConstraint cn = (PERSizeEffectiveConstraint)cns;

            if (cn == null)
                return -1;
            if (cn.Extensible)
                return -1;
            if (cn.m_size.m_rootRange.m_maxIsInfinite)
                return -1;

            if (cn.m_size.m_rootRange.m_max < 0x10000 && 
                cn.m_size.m_rootRange.m_max == cn.m_size.m_rootRange.m_min)
                return cn.m_size.m_rootRange.m_max * m_type.MaxBitsInPER;

            if (cn.m_size.m_rootRange.m_max < 0x10000)
                return cn.m_size.m_rootRange.m_max * m_type.MaxBitsInPER + PER.GetNumberOfBitsForNonNegativeInteger((ulong)(cn.m_size.m_rootRange.m_max - cn.m_size.m_rootRange.m_min));

            return cn.m_size.m_rootRange.m_max * m_type.MaxBitsInPER + (cn.m_size.m_rootRange.m_max / 0x10000 + 3) * 8;
        }*/
        
        public override long maxItemBitsInPER(PEREffectiveConstraint cns)
        {
            return m_type.MaxBitsInPER;
        }

        public override long minItemBitsInPER(PEREffectiveConstraint cns)
        {
            return m_type.MinBitsInPER;
        }


        public override bool Constructed
        {
            get { return true; }
        }

        public override string ItemConstraint(PEREffectiveConstraint cns)
        {
            return m_type.Constraints;
        }

                               
        internal override bool DependsOnlyOn(List<string> values)
        {
            return m_type.DependsOnlyOn(values);
        }

        public override bool ContainsTypeAssigment(string typeAssigment)
        {
            return m_type.ContainsTypeAssigment(typeAssigment);
        }

        internal override List<string> TypesIDepend()
        {
            return m_type.TypesIDepend();
        }


/*
        internal override void PrintCIsConstraintValidAux(StreamWriterLevel c)
        {
            base.PrintCIsConstraintValidAux(c);
            m_type.PrintCIsConstraintValidAux(c);
        }
 */



        
        //internal override void PrintCEncode(PEREffectiveConstraint cns, StreamWriterLevel c, string errorCode, string varName, int lev)
        //{
        //    long min = minItems(cns);
        //    long max = maxItems(cns);
        //    string i = "i" + (CLocalVariable.GetArrayIndex(varName) + 1);
        //    string prefix = "";
        //    bool topLevel = !varName.Contains("->");
            
        //    if (topLevel)
        //        prefix = varName + "->";
        //    else
        //        prefix = varName + ".";

        //    if (min != max)
        //    {
        //        c.P(lev);
        //        c.WriteLine("BitStream_EncodeConstraintWholeNumber(pBitStrm, {0}nCount, {1}, {2});", prefix, min, max);
        //    }
        //    else
        //    {
        //        c.P(lev); c.WriteLine("/* No need to encode length (it is fixed size ({0})*/",min);
        //    }

        //    c.P(lev); c.WriteLine("for({0}=0;{0}<{1}nCount;{0}++)", i, prefix);
        //    c.P(lev); c.WriteLine("{");
        //    PrintCEncodeItem(cns, c, errorCode + "_elem", prefix + "arr[" + i + "]", lev + 1);
        //    c.P(lev); c.WriteLine("}");
        //}


        internal override void VarsNeededForDecode(PEREffectiveConstraint cns, int arrayDepth, OrderedDictionary<string, CLocalVariable> existingVars)
        {
            /*            if (!existingVars.ContainsKey("nCount"))
                        {
                            existingVars.Add("nCount", new CLocalVariable("nCount", "asn1SccSint", 0, "0"));
                        }
                        string var = "i" + arrayDepth.ToString();
                        if (!existingVars.ContainsKey(var))
                        {
                            existingVars.Add(var, new CLocalVariable(var, "int", 0, "0"));
                        }
             */
            base.VarsNeededForDecode(cns, arrayDepth, existingVars);
            m_type.VarsNeededForDecode(m_type.PEREffectiveConstraint, arrayDepth + 1, existingVars);
        }
        //internal override void PrintCDecode(PEREffectiveConstraint cns, StreamWriterLevel c, string varName, int lev)
        //{
        //    long min = minItems(cns);
        //    long max = maxItems(cns);
        //    string i = "i" + (CLocalVariable.GetArrayIndex(varName) + 1);
        //    string prefix = "";
        //    bool topLevel = !varName.Contains("->");
        //    if (topLevel)
        //        prefix = varName + "->";
        //    else
        //        prefix = varName + ".";

        //    if (min != max)
        //    {
        //        c.P(lev);
        //        c.WriteLine("if (!BitStream_DecodeConstraintWholeNumber(pBitStrm, &nCount, {0}, {1})) {{", min, max);
        //        c.P(lev + 1);
        //        c.WriteLine("*pErrCode = ERR_INSUFFICIENT_DATA;");
        //        c.P(lev + 1);
        //        c.WriteLine("return FALSE;");
        //        c.P(lev);
        //        c.WriteLine("}");
        //        c.P(lev);
        //        c.WriteLine("{0}nCount = (long)nCount;", prefix);

        //    }
        //    else
        //    {
        //        c.P(lev);
        //        c.WriteLine("{0}nCount = {1};", prefix,max);
        //    }


        //    c.P(lev); c.WriteLine("for({0}=0;{0}<{1}nCount;{0}++)", i, prefix);
        //    c.P(lev); c.WriteLine("{");
        //    PrintCDecodeItem(cns, c, prefix + "arr[" + i + "]", lev + 1);
        //    c.P(lev); c.WriteLine("}");

        //}
        protected override void PrintCDecodeItem(PEREffectiveConstraint cns, StreamWriterLevel c, string varName, int lev)
        {
            c.P(lev); c.WriteLine("/*Decode childlen : ({0})*/", m_type.Name);
            m_type.PrintCDecode(m_type.PEREffectiveConstraint, c, varName, lev);
        }
    }


    public abstract partial class ArrayValue : Asn1Value, ISize
    {
        protected List<Asn1Value> m_children = new List<Asn1Value>();
        public virtual List<Asn1Value> Value
        {
            get { return m_children; }
        }

        public long Size
        {
            get { return m_children.Count; }
        }

        public List<bool> ContentData
        {
            get
            {
                List<bool> ret = new List<bool>();
                foreach (Asn1Value v in Value)
                    ret.AddRange(v.Encode());
                return ret;
            }
        }
        public List<bool> EncodeAsUnCostraint()
        {
            List<bool> ret = new List<bool>();
            if (Size <= 0x7F)
            {
                ret.AddRange(PER.EncodeConstraintWholeNumber(Size, 0, 0xFF));
                ret.AddRange(ContentData);
                return ret;
            }

            if (Size <= 0x3FFF)
            {
                ret.Add(true);
                ret.AddRange(PER.EncodeConstraintWholeNumber(Size, 0, 0x7FFF));
                ret.AddRange(ContentData);
                return ret;
            }
            long nCount = Size;
            int curBlockSize = 0;
            List<Asn1Value> items = Value;
            int curItem = 0;
            while (nCount >= 0x4000)
            {
                if (nCount >= 0x10000)
                {
                    curBlockSize = 0x10000;
                    ret.AddRange(PER.EncodeConstraintWholeNumber(0xC4, 0, 0xFF));
                }
                else if (nCount >= 0xC000)
                {
                    curBlockSize = 0xC000;
                    ret.AddRange(PER.EncodeConstraintWholeNumber(0xC3, 0, 0xFF));
                }
                else if (nCount >= 0x8000)
                {
                    curBlockSize = 0x8000;
                    ret.AddRange(PER.EncodeConstraintWholeNumber(0xC2, 0, 0xFF));
                }
                else
                {
                    curBlockSize = 0x4000;
                    ret.AddRange(PER.EncodeConstraintWholeNumber(0xC1, 0, 0xFF));
                }
                for (int i = curItem; i < curBlockSize + curItem; i++)
                {
                    ret.AddRange(items[i].Encode());
                }
                curItem += curBlockSize;
                nCount -= curBlockSize;
            }

            if (nCount <= 0x7F)
            {
                ret.AddRange(PER.EncodeConstraintWholeNumber(nCount, 0, 0xFF));
                for (int i = curItem; i < curItem + nCount; i++)
                    ret.AddRange(items[i].Encode());
                return ret;
            }

            ret.Add(true);
            ret.AddRange(PER.EncodeConstraintWholeNumber(nCount, 0, 0x7FFF));
            for (int i = curItem; i < curItem + nCount; i++)
                ret.AddRange(items[i].Encode());
            return ret;
        }

        public override List<bool> Encode()
        {
            List<bool> ret = new List<bool>();
            PERSizeEffectiveConstraint cn = (PERSizeEffectiveConstraint)Type.PEREffectiveConstraint;

            if (cn != null)
            {
                if (cn.Extensible)
                {
                    if (cn.m_size.m_rootRange.isValueWithinRange(Size))
                    {
                        ret.Add(false);
                    }
                    else
                    {
                        ret.Add(true);
                        ret.AddRange(EncodeAsUnCostraint());
                        return ret;
                    }
                }

                if (!cn.m_size.m_rootRange.m_maxIsInfinite && cn.m_size.m_rootRange.m_max < 0x10000)
                {
                    if (cn.m_size.m_rootRange.m_max == cn.m_size.m_rootRange.m_min)
                    {
                        ret.AddRange(ContentData);       //15.9 & 15.10
                    }
                    else
                    {
                        ret.AddRange(PER.EncodeConstraintWholeNumber(Size, cn.m_size.m_rootRange.m_min, cn.m_size.m_rootRange.m_max));
                        ret.AddRange(ContentData);
                    }
                }
                else
                {
                    ret.AddRange(EncodeAsUnCostraint());
                }

            }
            else
            {
                ret.AddRange(EncodeAsUnCostraint());
            }


            return ret;
        }


        internal override void PrintC(StreamWriterLevel c, int lev)
        {
            c.WriteLine("{");
            lev++;

            int cnt = m_children.Count;

            c.P(lev); c.WriteLine("{0},",cnt);

            c.P(lev); c.WriteLine("{");
            for (int i = 0; i < cnt; i++)
            {
                c.P(lev + 1);
                m_children[i].PrintC(c, lev + 1);
                if (i != cnt - 1)
                    c.WriteLine(",");
                else
                    c.WriteLine();
            }
            c.P(lev); c.WriteLine("}");

            lev--;
            c.P(lev);
            c.Write("}");
        }
    }

}
