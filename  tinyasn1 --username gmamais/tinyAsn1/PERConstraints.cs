using System;
using System.Collections.Generic;
using System.Text;
using Antlr.Runtime.Tree;

namespace tinyAsn1
{
    public class IntRange
    {
        public Int64 min;
        public Int64 max;
        public bool ignored = false;
        static public IntRange NULL
        {
            get
            {
                IntRange ret = new IntRange();
                ret.min = Int64.MaxValue;
                ret.max = Int64.MinValue;
                return ret;
            }
        }
        static public IntRange INF
        {
            get
            {
                IntRange ret = new IntRange();
                ret.min = Int64.MinValue;
                ret.max = Int64.MaxValue;
                return ret;
            }
        }

        static public IntRange IGNORED
        {
            get
            {
                IntRange ret = new IntRange();
                ret.ignored = true;
                return ret;
            }
        }
        public static IntRange GetIntersection(IntRange X, IntRange Y)
        {
            IntRange ret = new IntRange();
            if (X.min < Y.min && Y.min < X.max && X.max < Y.max)
            {
                ret.min = Y.min;
                ret.max = X.max;
            }
            else if (Y.min < X.min && X.min < Y.max && Y.max < X.max)
            {
                ret.min = X.min;
                ret.max = Y.max;
            }
            else if (X.Contains(Y))
                ret = Y;
            else if (Y.Contains(X))
                ret = X;
            else
                ret = IntRange.NULL;

            return ret;
        }

        public static IntRange GetUnion(IntRange X, IntRange Y)
        {
            IntRange ret = new IntRange();
            ret.min = Math.Min(X.min, Y.min);
            ret.max = Math.Max(X.max, Y.max);
            return ret;
        }

        public bool Contains(IntRange subset)
        {
            if (min <= subset.min && max >= subset.max)
                return true;
            return false;
        }
        
        public int getNumberOfEncodedBits()
        {
            UInt64 size = (UInt64)(max - min);
            int ret = 0;
            while (size > 0)
            {
                size = size >> 1;
                ret++;
            }

            return ret;
        }

        static public int getNumberOfEncodedBits(UInt64 size)
        {
            int ret = 0;
            while (size > 0)
            {
                size = size >> 1;
                ret++;
            }

            return ret;
        }
    }

    public partial class Asn1Type
    {
        public virtual IntRange IntRangeConstraint
        {
            get
            {
                throw new Exception("Abstract method called ...");
            }
        }

        public virtual IntRange SizeConstraint
        {
            get
            {

                IntRange ret = IntRange.INF;
                foreach (Constraint c in m_constraints)
                {
                    if (c.IsSizeConstraint())
                        ret = c.SizeConstraint;
                }
                return ret;
            }
        }
    }



    public partial class IntegerType : Asn1Type
    {
        public override IntRange IntRangeConstraint
        {
            get
            {
                if (m_constraints.Count == 0)
                    return IntRange.INF;

                IntRange ret = IntRange.NULL;
                foreach (Constraint c in m_constraints)
                {
                    IntRange cur = c.IntRange;
                    ret = IntRange.GetUnion(ret, cur);
                }
                return ret;
            }
        }
    }


    public partial class Constraint
    {
        public IntRange IntRange
        {
            get
            {
                return m_values.IntRange;
            }
        }

        public bool IsSizeConstraint()
        {
            if (m_values == null)
                return false;
            if (m_values.m_set1 == null)
                return false;
            if (m_values.m_set1.Count == 0)
                return false;
            UnionElementOfIntersectionItems el1 = m_values.m_set1[0] as UnionElementOfIntersectionItems;
            if (el1 == null)
                return false;
            if (el1.m_intersectionElements == null || el1.m_intersectionElements.Count == 0)
                return false;
            IntersectionElement in1 = el1.m_intersectionElements[0];
            SizeExpression sz = in1.m_exp as SizeExpression;
            if (sz == null)
                return false;

            return true;
        }
        
        public IntRange SizeConstraint
        {
            get
            {
                if (m_values == null)
                    throw new Exception();
                if (m_values.m_set1 == null)
                    throw new Exception();
                if (m_values.m_set1.Count == 0)
                    throw new Exception();
                UnionElementOfIntersectionItems el1 = m_values.m_set1[0] as UnionElementOfIntersectionItems;
                if (el1 == null)
                    throw new Exception();
                if (el1.m_intersectionElements == null || el1.m_intersectionElements.Count == 0)
                    throw new Exception();
                IntersectionElement in1 = el1.m_intersectionElements[0];
                SizeExpression sz = in1.m_exp as SizeExpression;
                if (sz == null)
                    throw new Exception();

                return sz.m_sizeConstraint.IntRange;

            }
        }
    }

    public partial class SetOfValues : ConstraintExpression
    {
        public override IntRange IntRange
        {
            get
            {
                IntRange ret = IntRange.NULL;
                foreach (UnionElement el in m_set1)
                {
                    IntRange cur = el.IntRange;
                    if (cur.ignored)
                        continue;
                    ret = IntRange.GetUnion(ret, cur);
                }

                if (m_set2.Count != 0)
                    throw new Exception("Unimplemented feature ...");
                return ret;
            }
        }
    }


    public partial class UnionElement
    {
        public virtual IntRange IntRange
        {
            get
            {
                throw new Exception("Abstract method called ...");
            }
        }
    }

    public partial class UnionElementOfIntersectionItems : UnionElement
    {
        public override IntRange IntRange
        {
            get
            {
                IntRange ret = IntRange.INF;
                foreach (IntersectionElement el in m_intersectionElements)
                {
                    IntRange Y = el.IntRange;
                    if (Y.ignored)
                        continue;
                    ret = IntRange.GetIntersection(ret, Y);
                }
                return ret;
            }
        }
    }

    public partial class UnionElementExceptOf : UnionElement
    {
        public override IntRange IntRange
        {
            get
            {
                throw new Exception("Unimplemented feature ...");
            }
        }
    }

    public partial class IntersectionElement
    {
        public IntRange IntRange
        {
            get
            {
                if (m_except_exp!=null)
                    throw new Exception("Unimplemented feature ...");
                return m_exp.IntRange;

            }
        }
    }

    public partial class ConstraintExpression
    {
        public virtual IntRange IntRange
        {
            get
            {
                throw new Exception("Abstract method called ...");
            }
        }
    }

    public partial class ValueRangeExpression : ConstraintExpression
    {
        public override IntRange IntRange
        {
            get
            {
                IntRange ret = IntRange.INF;
                if (m_minValue != null)
                {
                    ret.min = m_minValue.getValueAsInt();
                }

                if (m_maxValue != null)
                {
//                    if (m_maxValue.m_valType == Asn1Value.ValType.INT)
                        ret.max = m_maxValue.getValueAsInt();
//                    else
//                        throw new SemanticErrorException(m_minValue.m_valType.ToString() + " cannot appear on an integer range value");

                }
                else
                {
                    ret.max = ret.min;
                }
                
                return ret;

            }
        }
    }

    public partial class SizeExpression : ConstraintExpression
    {
        public override IntRange IntRange
        {
            get
            {
                return IntRange.IGNORED;
            }
        }
    }

    public partial class WithComponentsExpression : ConstraintExpression
    {
        public override IntRange IntRange
        {
            get
            {
                return IntRange.IGNORED;
            }
        }
    }

    public partial class SubtypeExpression : ConstraintExpression
    {
        public override IntRange IntRange
        {
            get
            {
                return m_type.IntRangeConstraint;
            }
        }
    }

    public partial class PermittedAlphabetExpression : ConstraintExpression
    {
        public override IntRange IntRange
        {
            get
            {
                return IntRange.IGNORED;
            }
        }
    }
    public partial class PatternExpression : ConstraintExpression
    {
        public override IntRange IntRange
        {
            get
            {
                return IntRange.IGNORED;
            }
        }
    }



}