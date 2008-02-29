using System;
using System.Collections.Generic;
using System.Text;
using Antlr.Runtime.Tree;
using Antlr.Runtime;

namespace tinyAsn1
{
    public interface IStringType
    {
        Char[] AllowedCharSet { get;}
    }

    public partial class IA5StringType : SizeableType, IStringType
    {
        public override string Name
        {
            get { return "IA5String"; }
        }

        public override Asn1Type.Tag UniversalTag
        {
            get
            {
                return new Tag(Tag.TagClass.UNIVERSAL, 22, TaggingMode.EXPLICIT, this);
            }
        }

        internal override Asn1Value ResolveVariable(Asn1Value val)
        {
            string referenceId = "";
            switch (val.antlrNode.Type)
            {
                case asn1Parser.StringLiteral:
                    return new IA5StringValue(val.antlrNode, m_module, this);
                case asn1Parser.VALUE_REFERENCE:
                    referenceId = val.antlrNode.GetChild(0).Text;
                    if (m_module.isValueDeclared(referenceId))
                    {
                        Asn1Value tmp = m_module.GetValue(referenceId);
                        switch (tmp.m_TypeID)
                        {
                            case Asn1Value.TypeID.IA5String:
                                return new IA5StringValue(tmp as IA5StringValue, val.antlrNode.GetChild(0));
                            case Asn1Value.TypeID.UNRESOLVED:
                                // not yet resolved, wait for next round
                                return val;
                            default:
                                throw new SemanticErrorException("Error in line : " + val.antlrNode.Line + ". Incompatible variable assigment");
                        }
                    }
                    else
                        throw new SemanticErrorException("Error in line : " + val.antlrNode.Line + ". Identifier '" + referenceId + "' is unknown");

                default:
                    throw new SemanticErrorException("Error in line : " + val.antlrNode.Line + ". Expecting string constant or string variable reference");
            }
        }

        internal override bool SemanticAnalysisFinished()
        {
            return base.SemanticAnalysisFinished();
        }
        public override void DoSemanticAnalysis()
        {
            base.DoSemanticAnalysis();
        }

        static List<int> m_allowedTokens = new List<int>(new int[]{ asn1Parser.CONSTRAINT, asn1Parser.EXCEPTION_SPEC, asn1Parser.EXT_MARK, 
                asn1Parser.UNION_SET, asn1Parser.UNION_SET_ALL_EXCEPT, asn1Parser.INTERSECTION_SET,
                asn1Parser.INTERSECTION_ELEMENT, asn1Parser.VALUE_RANGE_EXPR, asn1Parser.SUBTYPE_EXPR, asn1Parser.SIZE_EXPR, asn1Parser.PERMITTED_ALPHABET_EXPR});
        static List<int> m_stopList = new List<int>(new int[] { asn1Parser.VALUE_RANGE_EXPR, asn1Parser.SUBTYPE_EXPR, asn1Parser.SIZE_EXPR, asn1Parser.PERMITTED_ALPHABET_EXPR, asn1Parser.EXCEPTION_SPEC });

        protected override IEnumerable<int> AllowedTokensInConstraints
        {
            get
            {
                if (m_IamUsedInPermittedAlphabet)
                    return m_allowedTokensPA;
                return m_allowedTokens;
            }
        }
        protected override IEnumerable<int> StopTokensInConstraints
        {
            get
            {
                if (m_IamUsedInPermittedAlphabet)
                    return m_stopListPA;
                return m_stopList;
            }
        }


        private bool m_IamUsedInPermittedAlphabet = false;

        public bool IamUsedInPermittedAlphabet
        {
            get { return m_IamUsedInPermittedAlphabet; }
            set { m_IamUsedInPermittedAlphabet = value; }
        }
        static List<int> m_allowedTokensPA = new List<int>(new int[]{ asn1Parser.CONSTRAINT, asn1Parser.EXCEPTION_SPEC, asn1Parser.EXT_MARK, 
                asn1Parser.UNION_SET, asn1Parser.UNION_SET_ALL_EXCEPT, asn1Parser.INTERSECTION_SET,
                asn1Parser.INTERSECTION_ELEMENT, asn1Parser.VALUE_RANGE_EXPR});
        static List<int> m_stopListPA = new List<int>(new int[] { asn1Parser.VALUE_RANGE_EXPR });

        public virtual IA5StringType CreateForPA(Module mod, ITree antrl)
        {
            IA5StringType ret = new IA5StringType();
            ret.m_IamUsedInPermittedAlphabet = true;
            ret.m_module = mod;
            ret.antlrNode = antrl;
            return ret;
        }
        public override void checkConstraintsSemantically(ITree antrlConstraint)
        {
            if (!IamUsedInPermittedAlphabet)
                base.checkConstraintsSemantically(antrlConstraint);
            else
            {
                AntlrTreeVisitor visit = new AntlrTreeVisitor();


                visit.visitIfNot(antrlConstraint, AllowedTokensInConstraints, delegate(ITree root)
                {
                    throw new SemanticErrorException("Error1 in Line:" + root.Line + ", col:" + root.CharPositionInLine +
                        " . This type of constraint '" + root.Text + "' cannot appear under " + Name);
                },
                    StopTokensInConstraints);
            }
        }

        public override bool Compatible(Asn1Type other)
        {
            return other.GetFinalType() is IA5StringType;
        }

        List<Char> m_allowedCharSet = null;
        public virtual char[] AllowedCharSet
        {
            get {
                if (m_allowedCharSet == null)
                {
                    m_allowedCharSet = new List<char>();

                    Char ch = Char.MinValue;
                    for(int i=0;i<128;i++)
                    {
                        m_allowedCharSet.Add(ch);
                        ch++;
                    }
                }
                return m_allowedCharSet.ToArray();
            }
        }

        private PERAlphabetAndSizeEffectiveConstraint m_perEffectiveConstraint = null;
        public override PEREffectiveConstraint PEREffectiveConstraint
        {
            get
            {
                if (m_perEffectiveConstraint != null)
                    return m_perEffectiveConstraint;
                m_perEffectiveConstraint = new PERAlphabetAndSizeEffectiveConstraint();
                m_perEffectiveConstraint = (PERAlphabetAndSizeEffectiveConstraint)m_perEffectiveConstraint.Compute(m_constraints, this);
                return m_perEffectiveConstraint;
            }
        }

        protected int BitsPerSingleChar(CharSet perAlphaCon)
        {
            int min;
            int max;
            min = 0;
            max = AllowedCharSet.Length - 1;

            if (perAlphaCon != null)
                max = perAlphaCon.m_set.Count - 1;

            if (min == max)
                return 0;
            return PER.GetNumberOfBitsForNonNegativeInteger((UInt64)(max - min));
        }


        protected override long minItemBitsInPER(PEREffectiveConstraint cns)
        {
            PERAlphabetAndSizeEffectiveConstraint cn = (PERAlphabetAndSizeEffectiveConstraint)cns;
            return BitsPerSingleChar(cn.m_from);
        }
        protected override long maxItemBitsInPER(PEREffectiveConstraint cns)
        {
            return minItemBitsInPER(cns);
        }
        protected override string TypeName
        {
            get { return "ASCII CHARACTER"; }
        }
        protected override string ItemConstraint(PEREffectiveConstraint cns)
        {
            PERAlphabetAndSizeEffectiveConstraint cn = (PERAlphabetAndSizeEffectiveConstraint)cns;
            return cn.m_from.ToString();
        }
        internal override void PrintHTypeDeclaration(PEREffectiveConstraint cns, StreamWriterLevel h, string typeName, string varName, int lev)
        {
            if (varName=="")
                h.WriteLine("char {0}[{1}];", typeName, maxItems(cns) + 1);
            else
                h.WriteLine("char {0}[{1}];", varName, maxItems(cns) + 1);
        }
        internal override void PrintCInitialize(PEREffectiveConstraint cns, Asn1Value defaultVal, StreamWriterLevel h, string typeName, string varName, int lev, int arrayDepth)
        {
            h.P(lev);
            if (defaultVal!=null)
                h.WriteLine("strcpy({0}, {1});", varName, defaultVal.ToString());
            else
                h.WriteLine("memset({0}, 0x0, {1});", varName, maxItems(cns) + 1);
        }

        internal override void PrintCEncode(PEREffectiveConstraint cns, StreamWriterLevel c, string errorCode, string varName, int lev)
        {
            long min = minItems(cns);
            long max = maxItems(cns);
            string i = "i" + (CLocalVariable.GetArrayIndex(varName) + 1);
            string prefix = varName;

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
            PrintCEncodeItem(cns, c, errorCode + "_elem", prefix + "[" + i + "]", lev + 1);
            c.P(lev); c.WriteLine("}");
        }

        protected override void PrintCEncodeItem(PEREffectiveConstraint cns, StreamWriterLevel c, string errorCode, string varName, int lev)
        {
            PERAlphabetAndSizeEffectiveConstraint cn = (PERAlphabetAndSizeEffectiveConstraint)cns;
            CharSet perAlphaCon = cn.m_from;
            int min = 0;
            int max;
            List<char> tmp = null;
            if (perAlphaCon != null)
                tmp = perAlphaCon.m_set;
            else
                tmp = new List<char>(AllowedCharSet);
            max = tmp.Count - 1;
            if (min == max)
                return ;
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
            c.WriteLine("BitStream_EncodeConstraintWholeNumber(pBitStrm, charIndex, {0}, {1});", 0, tmp.Count-1);
        }

        internal override void PrintCDecode(PEREffectiveConstraint cns, StreamWriterLevel c, string varName, int lev)
        {
            long min = minItems(cns);
            long max = maxItems(cns);
            string i = "i" + (CLocalVariable.GetArrayIndex(varName) + 1);
            string prefix = varName;

            c.P(lev);
            c.WriteLine("memset({0}, 0x0, {1});", varName, maxItems(cns) + 1);
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
            PrintCDecodeItem(cns, c, prefix + "[" + i + "]", lev + 1);
            c.P(lev); c.WriteLine("}");

        }

        protected override void PrintCDecodeItem(PEREffectiveConstraint cns, StreamWriterLevel c, string varName, int lev)
        {
            PERAlphabetAndSizeEffectiveConstraint cn = (PERAlphabetAndSizeEffectiveConstraint)cns;
            CharSet perAlphaCon = cn.m_from;
            int min = 0;
            int max;
            List<char> tmp = null;
            if (perAlphaCon != null)
                tmp = perAlphaCon.m_set;
            else
                tmp = new List<char>(AllowedCharSet);
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
            c.WriteLine("sint charIndex = 0;");
            c.P(lev);
            c.WriteLine("if (!BitStream_DecodeConstraintWholeNumber(pBitStrm, &charIndex, {0}, {1})) {{", 0, tmp.Count-1);
            c.P(lev + 1);
            c.WriteLine("*pErrCode = ERR_INSUFFICIENT_DATA;");
            c.P(lev + 1);
            c.WriteLine("return FALSE;");
            c.P(lev);
            c.WriteLine("}");

            c.P(lev);
            c.WriteLine("{0} = allowedCharSet[charIndex];",varName);
        }

    }

    public partial class NumericStringType : IA5StringType
    {
        public override string Name
        {
            get { return "NumericString"; }
        }

        public override Asn1Type.Tag UniversalTag
        {
            get
            {
                return new Tag(Tag.TagClass.UNIVERSAL, 18, TaggingMode.EXPLICIT, this);
            }
        }

        internal override Asn1Value ResolveVariable(Asn1Value val)
        {
            string referenceId = "";
            switch (val.antlrNode.Type)
            {
                case asn1Parser.StringLiteral:
                    return new NumericStringValue(val.antlrNode, m_module, this);
                case asn1Parser.VALUE_REFERENCE:
                    referenceId = val.antlrNode.GetChild(0).Text;
                    if (m_module.isValueDeclared(referenceId))
                    {
                        Asn1Value tmp = m_module.GetValue(referenceId);
                        switch (tmp.m_TypeID)
                        {
                            case Asn1Value.TypeID.NumericString:
                                return new NumericStringValue(tmp as NumericStringValue, val.antlrNode.GetChild(0));
                            case Asn1Value.TypeID.UNRESOLVED:
                                // not yet resolved, wait for next round
                                return val;
                            default:
                                throw new SemanticErrorException("Error in line : " + val.antlrNode.Line + ". Incompatible variable assigment");
                        }
                    }
                    else
                        throw new SemanticErrorException("Error in line : " + val.antlrNode.Line + ". Identifier '" + referenceId + "' is unknown");

                default:
                    throw new SemanticErrorException("Error in line : " + val.antlrNode.Line + ". Expecting NumericString constant or NumericString variable reference");
            }
        }
        public override IA5StringType CreateForPA(Module mod, ITree antrl)
        {
            NumericStringType ret = new NumericStringType();
            ret.IamUsedInPermittedAlphabet = true;
            ret.m_module = mod;
            ret.antlrNode = antrl;
            return ret;
        }
        public override bool Compatible(Asn1Type other)
        {
            return other.GetFinalType() is NumericStringType;
        }

        static Char[] m_allowedCharSet = { ' ', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};
        public override char[] AllowedCharSet
        {
            get { return m_allowedCharSet; }
        }
        protected override string TypeName
        {
            get { return "NUMERIC CHARACTER"; }
        }
//        protected override string EncodingCFunctionName { get { return "BitStream_EncodeNumericString"; } }
    }


    public partial class IA5StringValue : Asn1Value, ISize, ICharacterString
    {
        protected string m_value;
        public string Value
        {
            get { return m_value; }
        }

        public override string ToString()
        {
            return "\"" + Value + "\"";
        }

        public IA5StringValue(ITree tree, Module mod, Asn1Type type)
        {
            m_TypeID = Asn1Value.TypeID.IA5String;
            m_module = mod;
            antlrNode = tree;
            m_type = type;

            if (antlrNode.Type != asn1Parser.StringLiteral)
                throw new Exception("INTERNAL ERROR");

            m_value = antlrNode.Text;
            if (m_value == null)
                m_value = "";

            m_value = m_value.Replace("\"\"", "\"");
            if (m_value.StartsWith("\""))
                m_value = m_value.Substring(1);
            if (m_value.EndsWith("\""))
                m_value = m_value.Substring(0, m_value.Length - 1);

        }


        public IA5StringValue(IA5StringValue o, ITree antlr)
        {
            m_TypeID = Asn1Value.TypeID.IA5String;
            m_module = o.m_module;
            antlrNode = antlr;
            m_value = o.m_value;
            m_type = o.m_type;
        }
        public override bool Equals(object obj)
        {
            IA5StringValue oth = obj as IA5StringValue;
            if (oth == null)
                return false;
            return oth.m_value == m_value;
        }

        public override int GetHashCode()
        {
            return m_value.GetHashCode();
        }


        public long Size
        {
            get { return Value.Length; }
        }


        public override int CompareTo(object obj)
        {
            IA5StringValue oth = obj as IA5StringValue;
            if (oth == null)
                throw new ArgumentException("obj is not an IA5StringValue");
            return Value.CompareTo(oth.Value);
        }
        public IA5StringValue(Char str)
        {
            m_TypeID = Asn1Value.TypeID.IA5String;
            m_value = str.ToString();
        }


        List<bool> ContentData(CharSet perAlphaCon)
        {
            List<bool> ret = new List<bool>();
            foreach(char ch in Value.ToCharArray())
                ret.AddRange(EncodeSingleChar(ch, perAlphaCon));
            return ret;
        }

        
        protected virtual List<bool> EncodeSingleChar(char p, CharSet perAlphaCon)
        {
            List<bool> ret = new List<bool>();
            IStringType myType = m_type.GetFinalType() as IStringType;
            if (myType == null)
                throw new Exception("Internal Error");

            int min;
            int max;
            List<char> tmp = new List<char>(myType.AllowedCharSet);
            int charIndex = tmp.IndexOf(p);
            min = 0;
            max = tmp.Count - 1;

            if (perAlphaCon != null)
            {
                max = perAlphaCon.m_set.Count - 1;
                charIndex = perAlphaCon.m_set.IndexOf(p);
            }

            if (min == max)
                return ret;
            ret.AddRange(PER.EncodeConstraintWholeNumber(charIndex, min, max));

            return ret;
        }


        public List<bool> EncodeAsUnCostraint(CharSet perAlphaCon)
        {
            List<bool> ret = new List<bool>();
            if (Size <= 0x7F)
            {
                ret.AddRange(PER.EncodeConstraintWholeNumber(Size, 0, 0xFF));
                ret.AddRange(ContentData(perAlphaCon));
                return ret;
            }

            if (Size <= 0x3FFF)
            {
                ret.Add(true);
                ret.AddRange(PER.EncodeConstraintWholeNumber(Size, 0, 0x7FFF));
                ret.AddRange(ContentData(perAlphaCon));
                return ret;
            }
            long nCount = Size;
            int curBlockSize = 0;
            List<char> items = new List<char>(Value.ToCharArray());
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
                    ret.AddRange(EncodeSingleChar(items[i],perAlphaCon));
                }
                curItem += curBlockSize;
                nCount -= curBlockSize;
            }

            if (nCount <= 0x7F)
            {
                ret.AddRange(PER.EncodeConstraintWholeNumber(nCount, 0, 0xFF));
                for (int i = curItem; i < curItem + nCount; i++)
                    ret.AddRange(EncodeSingleChar(items[i], perAlphaCon));
                return ret;
            }

            ret.Add(true);
            ret.AddRange(PER.EncodeConstraintWholeNumber(nCount, 0, 0x7FFF));
            for (int i = curItem; i < curItem + nCount; i++)
                ret.AddRange(EncodeSingleChar(items[i], perAlphaCon));
            return ret;
        }


        public override List<bool> Encode()
        {
            List<bool> ret = new List<bool>();
            PERAlphabetAndSizeEffectiveConstraint cn = (PERAlphabetAndSizeEffectiveConstraint)Type.PEREffectiveConstraint;
            CharSet perAlphaCon = null;
            if (cn != null)
            {
                perAlphaCon = cn.m_from;
                if (cn.Extensible)
                {
                    if (cn.m_size.m_rootRange.isValueWithinRange(Size))
                    {
                        ret.Add(false);
                    }
                    else
                    {
                        ret.Add(true);
                        ret.AddRange(EncodeAsUnCostraint((perAlphaCon)));
                        return ret;
                    }
                }

                if (!cn.m_size.m_rootRange.m_maxIsInfinite && cn.m_size.m_rootRange.m_max < 0x10000)
                {
                    if (cn.m_size.m_rootRange.m_max == cn.m_size.m_rootRange.m_min)
                    {
                        ret.AddRange(ContentData(perAlphaCon));       //15.9 & 15.10
                    }
                    else
                    {
                        ret.AddRange(PER.EncodeConstraintWholeNumber(Size, cn.m_size.m_rootRange.m_min, cn.m_size.m_rootRange.m_max));
                        ret.AddRange(ContentData(perAlphaCon));
                    }
                }
                else
                {
                    ret.AddRange(EncodeAsUnCostraint(perAlphaCon));
                }

            }
            else
            {
                ret.AddRange(EncodeAsUnCostraint(perAlphaCon));
            }


            return ret;
        }

    }

    public partial class NumericStringValue : IA5StringValue
    {
        static Char[] AllowedCharSet = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ' ' };

        public NumericStringValue(ITree tree, Module mod, Asn1Type type)
            : base(tree, mod, type)
        {
            m_TypeID = Asn1Value.TypeID.NumericString;
            List<Char> acs = new List<char>(AllowedCharSet);
            m_value = m_value.Replace("\r", "").Replace("\n", "").Replace("\t", "").Replace(" ", "");
            foreach (Char ch in Value.ToCharArray())
                if (!acs.Contains(ch))
                    throw new SemanticErrorException("Error in line: " + antlrNode.Line + ", col: " + antlrNode.CharPositionInLine + ". Character: '" + ch + "' can not be contained in a Numeric string");
        }
        public NumericStringValue(NumericStringValue o, ITree antlr)
            : base(o, antlr)
        {
            m_TypeID = Asn1Value.TypeID.NumericString;
        }

    }


}
