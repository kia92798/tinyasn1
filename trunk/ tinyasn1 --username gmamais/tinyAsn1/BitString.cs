using System;
using System.Collections.Generic;
using System.Text;
using Antlr.Runtime.Tree;
using Antlr.Runtime;

namespace tinyAsn1
{
    public partial class BitStringType : SizeableType, IInternalContentsInHtml
    {
        internal List<NumberedItem> m_namedBitsPriv = new List<NumberedItem>();
        public OrderedDictionary<string, Int64> m_namedBits = new OrderedDictionary<string, Int64>();
        public override string Name
        {
            get { return "BIT STRING"; }
        }

        public override Asn1Type.Tag UniversalTag
        {
            get
            {
                return Asn1CompilerInvokation.Instance.Factory.CreateAsn1TypeTag(Tag.TagClass.UNIVERSAL, 3, TaggingMode.EXPLICIT, this);
            }
        }

        static public new BitStringType CreateFromAntlrAst(ITree tree)
        {
            BitStringType ret = Asn1CompilerInvokation.Instance.Factory.CreateBitStringType();
            for (int i = 0; i < tree.ChildCount; i++)
            {
                ITree child = tree.GetChild(i);
                NumberedItem item = NumberedItem.CreateFromAntlrAst(child);
                //                if (ret.m_namedBitsPriv.ContainsKey(item.m_id))
                //                    throw new SemanticErrorException(item.m_id + " has alrady been defined. Line: " + child.Line);

                ret.m_namedBitsPriv.Add(item);
            }


            return ret;
        }

        internal override bool SemanticAnalysisFinished()
        {
            if (m_namedBitsPriv.Count > 0)
                return false;

            return base.SemanticAnalysisFinished();
        }
        public override void DoSemanticAnalysis()
        {
            base.DoSemanticAnalysis();
            List<NumberedItem> toBeRemoved = new List<NumberedItem>();
            foreach (NumberedItem ni in m_namedBitsPriv)
            {
                if (m_namedBits.ContainsKey(ni.m_id))
                    throw new SemanticErrorException("The BIT STRING type defined in line " + antlrNode.Line +
                        " containts more than once the identifier " + ni.m_id);

                if (ni.m_valueAsInt != null)
                {
                    if (ni.m_valueAsInt.Value < 0)
                        throw new SemanticErrorException("Error in line : " + antlrNode.Line + ". Bit string ids must be no negative numbers");
                    m_namedBits.Add(ni.m_id, ni.m_valueAsInt.Value);
                    toBeRemoved.Add(ni);
                }
                else
                {
                    //We have to look up in the variables definitions
                    string refName = ni.m_valueAsReference;
                    if (m_module.isValueDeclared(refName))
                    {
                        Asn1Value tmpVal = m_module.GetValue(refName);
                        if (tmpVal.m_TypeID == Asn1Value.TypeID.UNRESOLVED)
                            continue;
                        if (tmpVal.m_TypeID == Asn1Value.TypeID.INT)
                        {
                            Int64 val = ((IntegerValue)tmpVal).Value;
                            if (val < 0)
                                throw new SemanticErrorException("Error in line : " + antlrNode.Line + ". Identifier '" + refName + "' is a negative integer");
                            m_namedBits.Add(ni.m_id, val);
                            toBeRemoved.Add(ni);
                        }
                        else
                        {
                            throw new SemanticErrorException("Error in line : " + antlrNode.Line + ". Identifier '" + refName + "' is not an integer");
                        }
                        //else let it be resolved in a next parse round
                    }
                    else
                        throw new SemanticErrorException("Error in line : " + antlrNode.Line + ". Identifier '" + refName + "' is unknown");
                }

            }
            foreach (NumberedItem ni in toBeRemoved)
                m_namedBitsPriv.Remove(ni);
        }

        internal override Asn1Value ResolveVariable(Asn1Value val)
        {
            string referenceId = "";
            switch (val.antlrNode.Type)
            {
                case asn1Parser.BitStringLiteral:
                case asn1Parser.OctectStringLiteral:
                    return Asn1CompilerInvokation.Instance.Factory.CreateBitStringValue(val.antlrNode, m_module, this);

                case asn1Parser.OBJECT_ID_VALUE: // There is case { id } that the parser thinks that this a OBJECT ID value
                    // although it should handled as VALUE_LIST
                    if (!SemanticAnalysisFinished())
                        return val;
                    if (val.antlrNode.ChildCount != 1)
                        throw new SemanticErrorException("Error in line : " + val.antlrNode.Line + ". Expecting BIT STRING constant or BIT STRING variable");
                    ITree objLstItem = val.antlrNode.GetChild(0);
                    if (objLstItem.ChildCount != 1)
                        throw new SemanticErrorException("Error in line : " + val.antlrNode.Line + ". Expecting BIT STRING constant or BIT STRING variable");
                    ITree identifier = objLstItem.GetChild(0);

                    if (identifier.Type != asn1Parser.LID)
                        throw new SemanticErrorException("Error in line: " + identifier.Line + ", col: " + identifier.CharPositionInLine + ". Expecting identifier");
                    else
                    {
                        string id = identifier.Text;
                        if (!m_namedBits.ContainsKey(id))
                            throw new SemanticErrorException("Error in line: " + identifier.Line + ", col: " + identifier.CharPositionInLine + ". Unknown identifier '" + id + ",");

                        List<Int64> ids = new List<Int64>();
                        ids.Add(m_namedBits[id]);
                        return Asn1CompilerInvokation.Instance.Factory.CreateBitStringValue(ids, val.antlrNode, m_module, this);
                    }


                //To resolve another grammar Ambiguouity, we no more declare bitStringValue. 
                //The parser will only return valueList. 
                //Therefore, we must make sure that all values are identifiers
                //case asn1Parser.BIT_STRING_VALUE: // { id, id2, id3}
                case asn1Parser.VALUE_LIST: // { val1, val2, val3}
                    {
                        if (!SemanticAnalysisFinished())
                            return val;
                        List<Int64> ids = new List<Int64>();
                        for (int i = 0; i < val.antlrNode.ChildCount; i++)
                        {
                            ITree child = val.antlrNode.GetChild(i);
                            string id;
                            if (child.Type == asn1Parser.LID)
                                id = child.Text;
                            else if (child.Type == asn1Parser.VALUE_REFERENCE)
                                id = child.GetChild(0).Text;
                            else
                                throw new SemanticErrorException("Error in line: " + child.Line + ", col: " + child.CharPositionInLine + ". Expecting identifier");
                            if (!m_namedBits.ContainsKey(id))
                                throw new SemanticErrorException("Error in line: " + child.Line + ", col: " + child.CharPositionInLine + ". Unknown identifier '" + id + ",");

                            ids.Add(m_namedBits[id]);
                        }
                        return Asn1CompilerInvokation.Instance.Factory.CreateBitStringValue(ids, val.antlrNode, m_module, this);
                    }
                case asn1Parser.VALUE_REFERENCE:
                    referenceId = val.antlrNode.GetChild(0).Text;
                    if (m_module.isValueDeclared(referenceId))
                    {
                        Asn1Value tmp = m_module.GetValue(referenceId);
                        switch (tmp.m_TypeID)
                        {
                            case Asn1Value.TypeID.BIT_STRING:
                                return Asn1CompilerInvokation.Instance.Factory.CreateBitStringValue(tmp as BitStringValue, val.antlrNode.GetChild(0));
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
                    throw new SemanticErrorException("Error in line : " + val.antlrNode.Line + ". Expecting BIT STRING constant or BIT STRING variable");
            }
        }

        static List<int> m_allowedTokens = new List<int>(new int[]{ asn1Parser.CONSTRAINT, asn1Parser.EXCEPTION_SPEC, asn1Parser.EXT_MARK, 
                asn1Parser.UNION_SET, asn1Parser.UNION_SET_ALL_EXCEPT, asn1Parser.INTERSECTION_SET,
                asn1Parser.INTERSECTION_ELEMENT, asn1Parser.VALUE_RANGE_EXPR, asn1Parser.SUBTYPE_EXPR, asn1Parser.SIZE_EXPR});
        static List<int> m_stopList = new List<int>(new int[] { asn1Parser.VALUE_RANGE_EXPR, asn1Parser.SUBTYPE_EXPR, asn1Parser.SIZE_EXPR, asn1Parser.EXCEPTION_SPEC });

        protected override IEnumerable<int> AllowedTokensInConstraints { get { return m_allowedTokens; } }
        protected override IEnumerable<int> StopTokensInConstraints { get { return m_stopList; } }


        public override void PrintAsn1(StreamWriterLevel o, int lev)
        {
            if (m_tag != null)
                m_tag.PrintAsn1(o, lev);
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
            PrintAsn1Constraints(o);
        }

        public override bool Compatible(Asn1Type other)
        {
            BitStringType o = other.GetFinalType() as BitStringType;
            if (o == null)
                return false;
            if (m_namedBits.Count != o.m_namedBits.Count)
                return false;
            
            foreach (string id in m_namedBits.Keys)
            {
                if (!o.m_namedBits.ContainsKey(id))
                    return false;

                if (m_namedBits[id] != o.m_namedBits[id])
                    return false;
            }

            return true;
        }

        private PERSizeEffectiveConstraint m_perEffectiveConstraint = null;
        public override PEREffectiveConstraint PEREffectiveConstraint
        {
            get
            {
                if (m_perEffectiveConstraint != null)
                    return m_perEffectiveConstraint;
                m_perEffectiveConstraint = Asn1CompilerInvokation.Instance.Factory.CreatePERSizeEffectiveConstraint();
                m_perEffectiveConstraint = (PERSizeEffectiveConstraint)m_perEffectiveConstraint.Compute(m_constraints, this);
                return m_perEffectiveConstraint;
            }
        }

        /*public override long minBitsInPER(PEREffectiveConstraint cns)
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
                    return extBit + cn.m_size.m_rootRange.m_min;

                if (cn.m_size.m_rootRange.m_max < 0x10000)
                    return extBit + cn.m_size.m_rootRange.m_min + PER.GetNumberOfBitsForNonNegativeInteger((ulong)(cn.m_size.m_rootRange.m_max - cn.m_size.m_rootRange.m_min));
            }


            if (cn.m_size.m_rootRange.m_min <= 0x7F)
                return extBit + cn.m_size.m_rootRange.m_min + 8;
            if (cn.m_size.m_rootRange.m_min <= 0x3FFF)
                return extBit + cn.m_size.m_rootRange.m_min + 16;


            return extBit + cn.m_size.m_rootRange.m_min + (cn.m_size.m_rootRange.m_min / 0x10000 + 3) * 8;
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
                return cn.m_size.m_rootRange.m_max;

            if (cn.m_size.m_rootRange.m_max < 0x10000)
                return cn.m_size.m_rootRange.m_max + PER.GetNumberOfBitsForNonNegativeInteger((ulong)(cn.m_size.m_rootRange.m_max - cn.m_size.m_rootRange.m_min));

            return cn.m_size.m_rootRange.m_max + (cn.m_size.m_rootRange.m_max / 0x10000 + 3) * 8;
        }*/

        public override long minItemBitsInPER(PEREffectiveConstraint cns)
        {
            return 1;
        }
        public override long maxItemBitsInPER(PEREffectiveConstraint cns)
        {
            return 1;
        }
        public override string ItemConstraint(PEREffectiveConstraint cns)
        {
            return "";
        }


        public string InternalContentsInHtml(List<IConstraint> additionalConstraints)
        {
            string ret = string.Empty;
            int cnt = m_namedBits.Count;
            if (cnt > 0)
            {
                ret = "Bit strings's special values:<br/>";
                ret += "<ul type=\"square\">";
                for (int i = 0; i < cnt; i++)
                {
                    string namedBit = m_namedBits.Keys[i];
                    long val = m_namedBits.Values[i];
                    ret += string.Format("<li><font  color=\"#5F9EA0\" >{0}</font>({1})</li>", namedBit, val);
                    //if (i < cnt - 1)
                    //    ret += ", ";
                    //if (i % 3 == 2)
                    //    ret += "<br/>";
                }
                ret += "</ul>";
            }
            return ret;
        }


        /* Print C backend */




        

    
    }


    public partial class BitStringValue : Asn1Value, ISize
    {
        static Dictionary<char, string> lookup = new Dictionary<char, string>();
        static BitStringValue()
        {
            lookup.Add('0', "0000");
            lookup.Add('1', "0001");
            lookup.Add('2', "0010");
            lookup.Add('3', "0011");
            lookup.Add('4', "0100");
            lookup.Add('5', "0101");
            lookup.Add('6', "0110");
            lookup.Add('7', "0111");
            lookup.Add('8', "1000");
            lookup.Add('9', "1001");
            lookup.Add('A', "1010");
            lookup.Add('B', "1011");
            lookup.Add('C', "1100");
            lookup.Add('D', "1101");
            lookup.Add('E', "1110");
            lookup.Add('F', "1111");
        }
        string m_value = "";
        public virtual string Value
        {
            get { return m_value; }
        }
        public List<bool> ContentData
        {
            get
            {
                List<bool> ret = new List<bool>();
                foreach (Char bit in Value)
                    ret.Add(bit == '1');
                return ret;
            }
        }

        public BitStringValue(ITree tree, Module mod, Asn1Type type)
        {
            m_TypeID = TypeID.BIT_STRING;
            m_type = type;
            antlrNode = tree;
            if (tree.Type == asn1Parser.BitStringLiteral)
            {
                m_value = tree.Text.Substring(1);
                m_value = m_value.Remove(m_value.Length - 2);
                m_value = m_value.Replace("\r", "").Replace("\n", "").Replace("\t", "").Replace(" ", "");

                while (m_value.Length > 0 && m_value[m_value.Length - 1] == '0')
                    m_value = m_value.Remove(m_value.Length - 1);
            }
            else if (tree.Type == asn1Parser.OctectStringLiteral)
            {
                string tmp = tree.Text.Substring(1);
                tmp = tmp.Remove(tmp.Length - 2);
                tmp = tmp.Replace("\r", "").Replace("\n", "").Replace("\t", "").Replace(" ", "");

                foreach (Char ch in tmp.ToUpper())
                    m_value += lookup[ch];

                while (m_value.Length > 0 && m_value[m_value.Length - 1] == '0')
                    m_value = m_value.Remove(m_value.Length - 1);
            }
            else
                throw new Exception("Internal Error");
        }
        public BitStringValue(List<Int64> ids, ITree tree, Module mod, Asn1Type type)
        {
            m_TypeID = TypeID.BIT_STRING;
            m_type = type;
            antlrNode = tree;

            Int64 max = Int64.MinValue;
            foreach (Int64 i in ids)
                if (i > max)
                    max = i;
            for (int i = 0; i <= max; i++)
            {
                if (ids.Contains(i))
                    m_value += "1";
                else
                    m_value += "0";
            }
        }

        public BitStringValue(BitStringValue o, ITree antlr)
        {
            m_TypeID = Asn1Value.TypeID.BIT_STRING;
            m_value = o.m_value;
            m_module = o.m_module;
            antlrNode = antlr;
            m_type = o.m_type;
        }

        public override string ToString()
        {
            return "'"+Value.ToString()+"'B";
        }
        public override bool Equals(object obj)
        {
            BitStringValue oth = obj as BitStringValue;
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
            get { return m_value.Length; }
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
            int curBlockSize=0;
            List<bool> items = ContentData;
            int curItem = 0;
            while (nCount >= 0x4000)
            {
                if (nCount >= 0x10000)
                {
                    curBlockSize = 0x10000;
                    ret.AddRange(PER.EncodeConstraintWholeNumber(0xC4,0,0xFF));
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
                    ret.Add(items[i]);
                }
                curItem += curBlockSize;
                nCount -= curBlockSize;
            }
            
            if (nCount <= 0x7F)
            {
                ret.AddRange(PER.EncodeConstraintWholeNumber(nCount, 0, 0xFF));
                for (int i = curItem; i < curItem + nCount; i++)
                    ret.Add(items[i]);
                return ret;
            }

            ret.Add(true);
            ret.AddRange(PER.EncodeConstraintWholeNumber(nCount, 0, 0x7FFF));
            for (int i = curItem; i < curItem + nCount; i++)
                ret.Add(items[i]);
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


    }

}
