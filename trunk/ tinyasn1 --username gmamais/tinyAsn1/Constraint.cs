using System;
using System.Collections.Generic;
using System.Text;

namespace tinyAsn1
{
    /* ************ CONSTRAINTS ***********************/

    public partial class ExceptionSpec
    {

    }

    public partial class Constraint
    {
        public SetOfValues m_values;
        public ExceptionSpec m_exception;
    }

    public partial class UnionElement
    {
    }

    public partial class UnionElementOfIntersectionItems : UnionElement
    {
        public List<IntersectionElement> m_intersectionElements = new List<IntersectionElement>();
    }

    public partial class UnionElementExceptOf : UnionElement
    {
        public ConstraintExpression m_exceptOfThis;
    }

    public partial class IntersectionElement
    {
        public ConstraintExpression m_exp;
        public ConstraintExpression m_except_exp;
    }

    public partial class ConstraintExpression
    {
    }

    public partial class ValueRangeExpression : ConstraintExpression
    {
        public Asn1Value m_minValue;
        public Asn1Value m_maxValue;
        public bool m_minValIsIncluded = false;
        public bool m_maxValIsIncluded = false;
    }

    public partial class SizeExpression : ConstraintExpression
    {
        public Constraint m_sizeConstraint;
    }

    public partial class WithComponentsExpression : ConstraintExpression
    {
    }

    public partial class SubtypeExpression : ConstraintExpression
    {
        public Asn1Type m_type;
        public bool m_includes = false;
    }

    public partial class PermittedAlphabetExpression : ConstraintExpression
    {
        public Constraint m_permittedAlphabetConstraint;
    }
    public partial class PatternExpression : ConstraintExpression
    {
        public Asn1Value m_pattern;
    }

    public partial class SetOfValues : ConstraintExpression
    {
        public List<UnionElement> m_set1 = new List<UnionElement>();
        public bool m_extMarkPresent = false;
        public List<UnionElement> m_set2 = new List<UnionElement>();
    }

}
