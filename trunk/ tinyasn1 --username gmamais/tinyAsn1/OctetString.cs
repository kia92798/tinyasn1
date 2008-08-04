/**=============================================================================
Definition of OctetStringType and OctetStringTypeValue classes
in autoICD and asn1scc projects  
================================================================================
Copyright(c) Semantix Information Technologies S.A www.semantix.gr
All rights reserved.

This source code is only intended as a supplement to the
Semantix Technical Reference and related electronic documentation 
provided with the autoICD and asn1scc applications.
See these sources for detailed information regarding the
asn1scc and autoICD applications.
==============================================================================*/
using System;
using System.Collections.Generic;
using System.Text;
using Antlr.Runtime.Tree;
using Antlr.Runtime;

namespace tinyAsn1
{
    /// <summary>
    /// Class representing ASN.1 OCTET STRING
    /// </summary>
    public partial class OctetStringType : SizeableType
    {
        public override string Name
        {
            get { return "OCTET STRING"; }
        }

        public override Asn1Type.Tag UniversalTag
        {
            get
            {
                return DefaultBackend.Instance.Factory.CreateAsn1TypeTag(Tag.TagClass.UNIVERSAL, 4, TaggingMode.EXPLICIT, this);
            }
        }

        internal override Asn1Value ResolveVariable(Asn1Value val)
        {
            string referenceId = "";
            switch (val.antlrNode.Type)
            {
                case asn1Parser.BitStringLiteral:
                case asn1Parser.OctectStringLiteral:
                    return DefaultBackend.Instance.Factory.CreateOctetStringValue(val.antlrNode, m_module, this);
                case asn1Parser.VALUE_REFERENCE:
                    referenceId = val.antlrNode.GetChild(0).Text;
                    if (m_module.isValueDeclared(referenceId))
                    {
                        Asn1Value tmp = m_module.GetValue(referenceId);
                        switch (tmp.m_TypeID)
                        {
                            case Asn1Value.TypeID.OCTECT_STRING:
                                return DefaultBackend.Instance.Factory.CreateOctetStringValue(tmp as OctetStringValue, val.antlrNode.GetChild(0));
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
                    throw new SemanticErrorException("Error in line : " + val.antlrNode.Line + ". Expecting OCTECT STRING constant or OCTECT STRING variable");
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
                asn1Parser.INTERSECTION_ELEMENT, asn1Parser.VALUE_RANGE_EXPR, asn1Parser.SUBTYPE_EXPR, asn1Parser.SIZE_EXPR});
        static List<int> m_stopList = new List<int>(new int[] { asn1Parser.VALUE_RANGE_EXPR, asn1Parser.SUBTYPE_EXPR, asn1Parser.SIZE_EXPR, asn1Parser.EXCEPTION_SPEC });

        protected override IEnumerable<int> AllowedTokensInConstraints { get { return m_allowedTokens; } }
        protected override IEnumerable<int> StopTokensInConstraints { get { return m_stopList; } }

        public override bool Compatible(Asn1Type other)
        {
            OctetStringType o = other.GetFinalType() as OctetStringType;
            if (o == null)
                return false;

            return true;
        }
        private PERSizeEffectiveConstraint m_perEffectiveConstraint = null;
        public override PEREffectiveConstraint PEREffectiveConstraint
        {
            get
            {
                if (m_perEffectiveConstraint != null)
                    return m_perEffectiveConstraint;
                m_perEffectiveConstraint = DefaultBackend.Instance.Factory.CreatePERSizeEffectiveConstraint();
                m_perEffectiveConstraint = (PERSizeEffectiveConstraint)m_perEffectiveConstraint.Compute(m_constraints, this);
                return m_perEffectiveConstraint;
            }
        }

        public override long minItemBitsInPER(PEREffectiveConstraint cns)
        {
            return 8;
        }
        public override long maxItemBitsInPER(PEREffectiveConstraint cns)
        {
            return 8;
        }
        public override string ItemConstraint(PEREffectiveConstraint cns)
        {
            return "";
        }


    }

    /// <summary>
    /// Class representing an OCTET STRING value e.g. 'AF'H
    /// </summary>
    public partial class OctetStringValue : Asn1Value, ISize
    {
        static Dictionary<string, byte> lookup = new Dictionary<string, byte>();
        static OctetStringValue()
        {
            lookup.Add("0000", 0x0);
            lookup.Add("0001", 0x1);
            lookup.Add("0010", 0x2);
            lookup.Add("0011", 0x3);
            lookup.Add("0100", 0x4);
            lookup.Add("0101", 0x5);
            lookup.Add("0110", 0x6);
            lookup.Add("0111", 0x7);
            lookup.Add("1000", 0x8);
            lookup.Add("1001", 0x9);
            lookup.Add("1010", 0xA);
            lookup.Add("1011", 0xB);
            lookup.Add("1100", 0xC);
            lookup.Add("1101", 0xD);
            lookup.Add("1110", 0xE);
            lookup.Add("1111", 0xF);
        }
        List<byte> m_value = new List<byte>();
        public List<byte> Value
        {
            get { return m_value; }
        }


        public List<bool> ContentData
        {
            get
            {
                List<bool> ret = new List<bool>();
                foreach (byte b in Value)
                    ret.AddRange(PER.EncodeConstraintWholeNumber(b, 0, 0xFF));
                return ret;
            }
        }

        public override string ToString()
        {
            string ret = "'";
            foreach (byte b in Value)
                ret += b.ToString("X2");
            ret += "'H";
            return ret;
        }

        public string ToStringNaked()
        {
            return ToString().Replace("'", "").Replace("H", "");
        }
        static public List<byte> ConvertToOctetArray(BitStringValue tmp, bool forOctStrUse)
        {
            List<byte> ret = new List<byte>();
            string bitString = tmp.Value;
            int nBitsToInsert = 0;
            if (bitString.Length % 4 > 0)
                nBitsToInsert = 4 - bitString.Length % 4;
            else
                nBitsToInsert = 0;

            for (int i = 0; i < nBitsToInsert; i++)
                bitString += "0";

            List<byte> nibles = new List<byte>();
            while (bitString.Length > 0)
            {
                string nible = bitString.Substring(0, 4);
                nibles.Add(lookup[nible]);
                bitString = bitString.Substring(4);
            }
            if (nibles.Count % 2 != 0)
            {
                if (forOctStrUse)
                    nibles.Insert(0, 0);
                else
                    nibles.Add(0);
            }

            while (nibles.Count > 0)
            {
                byte curByte = (byte)(nibles[0] << 4);
                curByte |= nibles[1];
                ret.Add(curByte);
                nibles.RemoveAt(0);
                nibles.RemoveAt(0);
            }
            return ret;
        }

        public OctetStringValue(ITree tree, Module mod, Asn1Type type)
        {
            m_TypeID = Asn1Value.TypeID.OCTECT_STRING;
            m_module = mod;
            antlrNode = tree;
            m_type = type;


            BitStringValue tmp = DefaultBackend.Instance.Factory.CreateBitStringValue(tree, mod, type);

            while (tmp.Value.EndsWith("0"))
                tmp.Value = tmp.Value.Substring(0, tmp.Value.Length - 1);

            m_value = ConvertToOctetArray(tmp, true);

        }


        public OctetStringValue(OctetStringValue o, ITree antlr)
        {
            m_TypeID = Asn1Value.TypeID.OCTECT_STRING;
            m_module = o.m_module;
            antlrNode = antlr;
            m_value.Clear();
            m_value.AddRange(o.m_value);
            m_type = o.m_type;
        }
        public override bool Equals(object obj)
        {
            OctetStringValue oth = obj as OctetStringValue;
            if (oth == null)
                return false;
            if (oth.m_value.Count != m_value.Count)
                return false;
            for (int i = 0; i < m_value.Count; i++)
                if (oth.m_value[i] != m_value[i])
                    return false;
            return true;
        }

        public override int GetHashCode()
        {
            return m_value.GetHashCode();
        }


        public long Size
        {
            get { return Value.Count; }
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
            List<byte> items = Value;
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
                    ret.AddRange(PER.EncodeConstraintWholeNumber(items[i],0,0xFF));
                }
                curItem += curBlockSize;
                nCount -= curBlockSize;
            }

            if (nCount <= 0x7F)
            {
                ret.AddRange(PER.EncodeConstraintWholeNumber(nCount, 0, 0xFF));
                for (int i = curItem; i < curItem + nCount; i++)
                    ret.AddRange(PER.EncodeConstraintWholeNumber(items[i], 0, 0xFF));
                return ret;
            }

            ret.Add(true);
            ret.AddRange(PER.EncodeConstraintWholeNumber(nCount, 0, 0x7FFF));
            for (int i = curItem; i < curItem + nCount; i++)
                ret.AddRange(PER.EncodeConstraintWholeNumber(items[i], 0, 0xFF));
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
