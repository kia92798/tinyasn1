using System;
using System.Collections.Generic;
using System.Text;
using Antlr.Runtime.Tree;
using Antlr.Runtime;

namespace tinyAsn1
{

    /// <summary>
    /// Common base class for SEQUENCE OF and SET OF
    /// </summary>
    public partial class ArrayType : Asn1Type
    {
        public string m_xmlVarName;
        public Asn1Type m_type;

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
                m_perEffectiveConstraint = new PERSizeEffectiveConstraint();
                m_perEffectiveConstraint = (PERSizeEffectiveConstraint)m_perEffectiveConstraint.Compute(m_constraints,this);
                return m_perEffectiveConstraint;
            }
        }
        public override long minBitsInPER(PEREffectiveConstraint cns)
        {
            PERSizeEffectiveConstraint cn = (PERSizeEffectiveConstraint)cns;

            if (cn == null)
                return 8;

            if (!cn.m_size.m_rootRange.m_maxIsInfinite &&
                cn.m_size.m_rootRange.m_max < 0xFFFF &&
                cn.m_size.m_rootRange.m_max == cn.m_size.m_rootRange.m_min)
                return cn.m_size.m_rootRange.m_min * m_type.MaxBitsInPER;


            if (cn.m_size.m_rootRange.m_min <= 127)
                return cn.m_size.m_rootRange.m_min * m_type.MaxBitsInPER + 8;
            if (cn.m_size.m_rootRange.m_min <= 0x3FFF)
                return cn.m_size.m_rootRange.m_min * m_type.MaxBitsInPER + 16;


            return cn.m_size.m_rootRange.m_min * m_type.MaxBitsInPER + (cn.m_size.m_rootRange.m_min / 0x10000 + 3) * 8;
        }

        public override long maxBitsInPER(PEREffectiveConstraint cns)
        {
            PERSizeEffectiveConstraint cn = (PERSizeEffectiveConstraint)cns;

            if (cn != null)
            {
                if (cn.Extensible)
                    return -1;

                if (!cn.m_size.m_rootRange.m_maxIsInfinite)
                {
                    if (cn.m_size.m_rootRange.m_max < 0xFFFF && 
                        cn.m_size.m_rootRange.m_max == cn.m_size.m_rootRange.m_min)
                        return cn.m_size.m_rootRange.m_max * m_type.MaxBitsInPER;

                    if (cn.m_size.m_rootRange.m_max <= 127)
                        return cn.m_size.m_rootRange.m_max * m_type.MaxBitsInPER + 8;
                    
                    if (cn.m_size.m_rootRange.m_max <= 0x3FFF)
                        return cn.m_size.m_rootRange.m_max * m_type.MaxBitsInPER + 16;

                    return cn.m_size.m_rootRange.m_max * m_type.MaxBitsInPER + (cn.m_size.m_rootRange.m_max / 0x10000 + 3) * 8;
                }
                else
                    return -1;
            }

            return -1;
        }

    
   }


    public partial class ArrayValue : Asn1Value, ISize
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

                if (!cn.m_size.m_rootRange.m_maxIsInfinite && cn.m_size.m_rootRange.m_max < 0xFFFF)
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
