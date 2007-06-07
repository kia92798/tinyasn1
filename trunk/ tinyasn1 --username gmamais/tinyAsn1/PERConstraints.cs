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

                if (m_set2 != null)
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
                    if (m_minValue.m_valType == Asn1Value.ValType.INT)
                        ret.min = (Int64)m_minValue.m_value;
                    else
                        throw new SemanticErrorException(m_minValue.m_valType.ToString() + " cannot appear on an integer range value");
                }

                if (m_maxValue != null)
                {
                    if (m_maxValue.m_valType == Asn1Value.ValType.INT)
                        ret.max = (Int64)m_maxValue.m_value;
                    else
                        throw new SemanticErrorException(m_minValue.m_valType.ToString() + " cannot appear on an integer range value");

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