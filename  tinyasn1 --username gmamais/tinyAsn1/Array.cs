/**=============================================================================
SizeableType, ArrayType and ArrayValue class definitions
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
using MB = System.Reflection.MethodBase;
using System.Diagnostics;
using semantix.util;

namespace tinyAsn1
{

    /// <summary>
    /// This is an abstract class serving common functionality to all types that
    /// can have a SIZE constraint.
    /// These types are: SEQUENCE OF, SET OF, OCTET STRING, BIT STRING and character
    /// types
    /// </summary>
    public class SizeableType : Asn1Type
    {
        //see base class for more information
        public override long maxBitsInPER(PEREffectiveConstraint cns)
        {
            if (!DefaultBackend.EnterRecursiveFunc(MB.GetCurrentMethod().Name, this))
                return -1;

            long ret = 0;

            PERSizeEffectiveConstraint cn = (PERSizeEffectiveConstraint)cns;

            if (cn == null)
            {
                DefaultBackend.LeaveRecursiveFunc(MB.GetCurrentMethod().Name, this);
                return -1;
            }
            if (cn.Extensible)
            {
                DefaultBackend.LeaveRecursiveFunc(MB.GetCurrentMethod().Name, this);
                return -1;
            }
            if (cn.m_size.m_rootRange.m_maxIsInfinite)
            {
                DefaultBackend.LeaveRecursiveFunc(MB.GetCurrentMethod().Name, this);
                return -1;
            }
            if (maxItemBitsInPER(cns) == -1)
            {
                DefaultBackend.LeaveRecursiveFunc(MB.GetCurrentMethod().Name, this);
                return -1;
            }

            if (cn.m_size.m_rootRange.m_max < 0x10000 &&
                cn.m_size.m_rootRange.m_max == cn.m_size.m_rootRange.m_min)
            {
                ret =  cn.m_size.m_rootRange.m_max * maxItemBitsInPER(cns);
            } 
            else if (cn.m_size.m_rootRange.m_max < 0x10000)
            {
                ret = cn.m_size.m_rootRange.m_max * maxItemBitsInPER(cns) + PER.GetNumberOfBitsForNonNegativeInteger((ulong)(cn.m_size.m_rootRange.m_max - cn.m_size.m_rootRange.m_min));
            } else 
                ret = cn.m_size.m_rootRange.m_max * maxItemBitsInPER(cns) + (cn.m_size.m_rootRange.m_max / 0x10000 + 3) * 8;

            DefaultBackend.LeaveRecursiveFunc(MB.GetCurrentMethod().Name, this);
            return ret;
        }
        
        //see base class for more information
        public override long minBitsInPER(PEREffectiveConstraint cns)
        {

            if (!DefaultBackend.EnterRecursiveFunc(MB.GetCurrentMethod().Name, this))
                return 0;
            

            PERSizeEffectiveConstraint cn = (PERSizeEffectiveConstraint)cns;
            int extBit = 0;
            if (cn.Extensible)
                extBit++;

            if (cn == null)
            {
                DefaultBackend.LeaveRecursiveFunc(MB.GetCurrentMethod().Name, this);
                return extBit + 8;
            }

            if (!cn.m_size.m_rootRange.m_maxIsInfinite)
            {
                if (cn.m_size.m_rootRange.m_max < 0x10000 &&
                    cn.m_size.m_rootRange.m_max == cn.m_size.m_rootRange.m_min)
                {
                    long ret = extBit + cn.m_size.m_rootRange.m_min * minItemBitsInPER(cns);
                    DefaultBackend.LeaveRecursiveFunc(MB.GetCurrentMethod().Name, this);
                    return ret;
                }

                if (cn.m_size.m_rootRange.m_max < 0x10000)
                {
                    long ret = extBit + cn.m_size.m_rootRange.m_min * minItemBitsInPER(cns) + PER.GetNumberOfBitsForNonNegativeInteger((ulong)(cn.m_size.m_rootRange.m_max - cn.m_size.m_rootRange.m_min));
                    DefaultBackend.LeaveRecursiveFunc(MB.GetCurrentMethod().Name, this);
                    return ret;
                }
            }


            if (cn.m_size.m_rootRange.m_min <= 0x7F)
            {
                long ret = extBit + cn.m_size.m_rootRange.m_min * minItemBitsInPER(cns) + 8;
                DefaultBackend.LeaveRecursiveFunc(MB.GetCurrentMethod().Name, this);
                return ret;
            }
            if (cn.m_size.m_rootRange.m_min <= 0x3FFF)
            {
                long ret = extBit + cn.m_size.m_rootRange.m_min * minItemBitsInPER(cns) + 16;
                DefaultBackend.LeaveRecursiveFunc(MB.GetCurrentMethod().Name, this);
                return ret;
            }

            long ret2 = extBit + cn.m_size.m_rootRange.m_min * minItemBitsInPER(cns) + (cn.m_size.m_rootRange.m_min / 0x10000 + 3) * 8;
            DefaultBackend.LeaveRecursiveFunc(MB.GetCurrentMethod().Name, this);
            return ret2;
        }

        /// <summary>
        /// Return the minimum number of bits for encoding in uPER the internal item
        /// </summary>
        public virtual long minItemBitsInPER(PEREffectiveConstraint cns)
        {
            throw new Exception("Abstract method called");
        }
        /// <summary>
        /// Return the maximum number of bits for encoding in uPER the internal item
        /// </summary>
        public virtual long maxItemBitsInPER(PEREffectiveConstraint cns)
        {
            throw new Exception("Abstract method called");
        }

        // Get internal item constraint as printable string
        public virtual string ItemConstraint(PEREffectiveConstraint cns)
        {
            throw new Exception("Abstract method called");
        }

        // Get the minimum number of items that are allowed (based on the SIZE constraint)
        public long minItems(PEREffectiveConstraint cns)
        {
            if (cns == null)
                return 0;
            PERSizeEffectiveConstraint cn = (PERSizeEffectiveConstraint)cns;
            return cn.m_size.m_rootRange.m_min;
        }
        // Get the maximum number of items that are allowed (based on the SIZE constraint)
        public long maxItems(PEREffectiveConstraint cns)
        {
            if (cns == null)
                return -1;
            PERSizeEffectiveConstraint cn = (PERSizeEffectiveConstraint)cns;
            if (cn.m_size.m_rootRange.m_maxIsInfinite)
                return -1;
            return cn.m_size.m_rootRange.m_max;
        }

        // Get the minimum number of bits required for encode the size in uPER
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

        // Get the maximum number of bits required for encode the size in uPER
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


        public override void ToXml2(StreamWriterLevel o, int p)
        {

            string nodeName = GetType().BaseType.Name;
            long mn = minItems(PEREffectiveConstraint);
            long mx = maxItems(PEREffectiveConstraint);

            string min = "MIN";
            string max = "MAX";
            if (mn != -1)
                min = mn.ToString();
            if (mx != -1)
                max = mx.ToString();

            o.P(p); o.WriteLine("<{0} Min=\"{1}\" Max=\"{2}\">", nodeName, min, max);
            ToXml3(o, p + 1);
            o.P(p); o.WriteLine("</{0}>", nodeName);

        }

        protected virtual void ToXml3(StreamWriterLevel o, int p)
        {
            
        }


    }


    /// <summary>
    /// This is an abstract class serving common functionality to 
    /// SEQUENCE OF and  SET OF types
    /// </summary>
    public partial class ArrayType : SizeableType
    {
        // The internal type of Sequence Of or Set Of
        public Asn1Type m_type;
        public string m_xmlVarName;

        /// <summary>
        /// Auxiliary methods for implementing the visitor pattern
        /// </summary>
        public override IEnumerable<T> GetMySelfAndAnyChildren<T>()
        {
            if (this is T)
                yield return this as T;
            foreach (T grCh in m_type.GetMySelfAndAnyChildren<T>())
                yield return grCh;
        }

        /// <summary>
        /// Auxiliary methods for implementing the visitor pattern
        /// </summary>
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
            if (!DefaultBackend.EnterRecursiveFunc(MB.GetCurrentMethod().Name, this))
                return;
            m_type.CheckChildrensTags();

            DefaultBackend.LeaveRecursiveFunc(MB.GetCurrentMethod().Name, this);

        }

        public override void PerformAutomaticTagging()
        {
            if (!DefaultBackend.EnterRecursiveFunc(MB.GetCurrentMethod().Name, this))
                return;
            m_type.PerformAutomaticTagging();
            DefaultBackend.LeaveRecursiveFunc(MB.GetCurrentMethod().Name, this);
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
                m_perEffectiveConstraint = DefaultBackend.Instance.Factory.CreatePERSizeEffectiveConstraint();
                m_perEffectiveConstraint = (PERSizeEffectiveConstraint)m_perEffectiveConstraint.Compute(m_constraints,this);
                return m_perEffectiveConstraint;
            }
        }
        
        public override long maxItemBitsInPER(PEREffectiveConstraint cns)
        {
            if (!DefaultBackend.EnterRecursiveFunc(MB.GetCurrentMethod().Name, this))
                return -1;
            long ret =  m_type.MaxBitsInPER;
            DefaultBackend.LeaveRecursiveFunc(MB.GetCurrentMethod().Name, this);

            return ret;
        }

        public override long minItemBitsInPER(PEREffectiveConstraint cns)
        {
            if (!DefaultBackend.EnterRecursiveFunc(MB.GetCurrentMethod().Name, this))
                return -1;
            long ret = m_type.MinBitsInPER;
            DefaultBackend.LeaveRecursiveFunc(MB.GetCurrentMethod().Name, this);

            return ret;
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

        protected override void ToXml3(StreamWriterLevel o, int p)
        {
            m_type.ToXml(o, p);
        }

    }


    /// <summary>
    /// Abstract class providing common functionality
    /// to SEQUENCE OF and SET OF values
    /// </summary>
    public abstract partial class ArrayValue : Asn1Value, ISize
    {
        public List<Asn1Value> m_children = new List<Asn1Value>();

        public override IEnumerable<T> GetMySelfAndAnyChildren<T>()
        {

            if (this is T)
                yield return this as T;

            foreach (Asn1Value v in m_children)
                if (v is T)
                    yield return v as T;

            yield break;
        }


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


    }

}
