using System;
using System.Collections.Generic;
using System.Text;
using Antlr.Runtime.Tree;

namespace tinyAsn1
{
    /* ************ CONSTRAINTS ***********************/

    public partial class ExceptionSpec
    {
        static public ExceptionSpec CreateFromAntlrAst(ITree tree)
        {
            Console.Error.WriteLine("Unimplemented feature ASN.1 Exception are parsed but ignored");
            return new ExceptionSpec();
        }

    }

    public partial class Constraint
    {
        public UnionSet m_set1;
        public bool m_extMarkPresent = false;
        public UnionSet m_set2;
        public ExceptionSpec m_exception;
    }

    public partial class UnionSet : ConstraintExpression
    {
        public List<UnionElement> m_set = new List<UnionElement>();
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
        
        static public ValueRangeExpression CreateFromAntlrAst(ITree tree)
        {
            ValueRangeExpression ret = new ValueRangeExpression();
            ret.m_minValue = Asn1Value.CreateFromAntlrAst(tree.GetChild(0));
            int lineNo = tree.GetChild(0).Line;
            for (int i = 1; i < tree.ChildCount; i++)
            {
                ITree child = tree.GetChild(i);
                switch (child.Type)
                {
                    case asn1Parser.MAX_VAL_PRESENT:
                        ret.m_maxValue = Asn1Value.CreateFromAntlrAst(child.GetChild(0));
                        break;
                    case asn1Parser.MIN_VAL_INCLUDED:
                        ret.m_minValIsIncluded = true;
                        break;
                    case asn1Parser.MAX_VAL_INCLUDED:
                        ret.m_maxValIsIncluded = true;
                        break;
                    default:
                        throw new Exception("Unkown child: " + child.Text + " for node: " + tree.Text);
                }
            }

            //if (ret.m_maxValue != null && ret.m_minValue.m_valType != ret.m_maxValue.m_valType)
            //    throw new SemanticErrorException("Semantic Error: Both values in a range must be of the same type. Line:" +lineNo.ToString());

            return ret;
        }
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




/// <summary>
/// 
/// 
/// 
///  Create static classes from ANTLR tree
/// 
/// 
/// 
/// </summary>

#if defined
    public partial class ExceptionSpec
    {
        static public ExceptionSpec CreateFromAntlrAst(ITree tree)
        {
            Console.Error.WriteLine("Unimplemented feature ASN.1 Exception are parsed but ignored");
            return new ExceptionSpec();
        }
    }

    public partial class Constraint
    {
        static public Constraint CreateFromAntlrAst(ITree tree)
        {
            if (tree.Type != asn1Parser.CONSTRAINT)
                throw new Exception(tree.Text + " is not a constraint");
            Constraint ret = new Constraint();
            UnionElement element = null;
            for (int i = 0; i < tree.ChildCount; i++)
            {
                ITree child = tree.GetChild(i);
                switch (child.Type)
                {
                    case asn1Parser.UNION_ELEMENT:
                        element = UnionElementOfIntersectionItems.CreateFromAntlrAst(child);
                        if (!ret.m_extMarkPresent)
                            ret.m_set1.Add(element);
                        else
                            ret.m_set2.Add(element);
                        break;
                    case asn1Parser.UNION_ELEMENT_ALL_EXCEPT:
                        element = UnionElementExceptOf.CreateFromAntlrAst(child);
                        if (ret.m_extMarkPresent)
                            ret.m_set2.Add(element);
                        else
                            ret.m_set1.Add(element);
                        break;
                    case asn1Parser.EXT_MARK:
                        ret.m_extMarkPresent = true;
                        break;
                    case asn1Parser.EXCEPTION_SPEC:
                        ret.m_exception = ExceptionSpec.CreateFromAntlrAst(child);
                        break;
                    default:
                        throw new Exception("Unkown child: " + child.Text + " for node: " + tree.Text);
                }
            }

            return ret;
        }

        static public void HandleBody(Constraint ret, ITree tree)
        {
        }

        static public Constraint CreateConstraintFromSizeConstraint(ITree tree)
        {


            Constraint ret = new Constraint();
            UnionElementOfIntersectionItems un = new UnionElementOfIntersectionItems();
            ret.m_set1.Add(un);
            IntersectionElement ir = new IntersectionElement();
            un.m_intersectionElements.Add(ir);
            SizeExpression sz = new SizeExpression();
            ir.m_exp = sz;
            sz.m_sizeConstraint = Constraint.CreateFromAntlrAst(tree.GetChild(0));

            return ret;
        }
    }

    public partial class UnionElementOfIntersectionItems : UnionElement
    {
        static new public UnionElementOfIntersectionItems CreateFromAntlrAst(ITree tree)
        {
            UnionElementOfIntersectionItems ret = new UnionElementOfIntersectionItems();
            for (int i = 0; i < tree.ChildCount; i++)
            {
                ITree child = tree.GetChild(i);
                switch (child.Type)
                {
                    case asn1Parser.INTERSECTION_ELEMENT:
                        ret.m_intersectionElements.Add(IntersectionElement.CreateFromAntlrAst(child));
                        break;
                    default:
                        throw new Exception("Unkown child: " + child.Text + " for node: " + tree.Text);
                }
            }
            return ret;
        }
    }

    public partial class UnionElementExceptOf : UnionElement
    {
        static new public UnionElementExceptOf CreateFromAntlrAst(ITree tree)
        {
            UnionElementExceptOf ret = new UnionElementExceptOf();
            ret.m_exceptOfThis = ConstraintExpression.CreateFromAntlrAst(tree.GetChild(0));
            return ret;
        }
    }

    public partial class IntersectionElement
    {
        static public IntersectionElement CreateFromAntlrAst(ITree tree)
        {
            IntersectionElement ret = new IntersectionElement();

            ret.m_exp = ConstraintExpression.CreateFromAntlrAst(tree.GetChild(0));
            if (tree.ChildCount > 1)
                ret.m_except_exp = ConstraintExpression.CreateFromAntlrAst(tree.GetChild(1));

            return ret;
        }
    }

    public partial class ConstraintExpression
    {
        static public ConstraintExpression CreateFromAntlrAst(ITree tree)
        {
            ConstraintExpression ret = null;

            switch (tree.Type)
            {
                case asn1Parser.VALUE_RANGE_EXPR:
                    ret = ValueRangeExpression.CreateFromAntlrAst(tree);
                    break;
                case asn1Parser.SIZE_EXPR:
                    ret = SizeExpression.CreateFromAntlrAst(tree);
                    break;
                case asn1Parser.PERMITTED_ALPHABET_EXPR:
                    ret = PermittedAlphabetExpression.CreateFromAntlrAst(tree);
                    break;
                case asn1Parser.SUBTYPE_EXPR:
                    ret = SubtypeExpression.CreateFromAntlrAst(tree);
                    break;
                case asn1Parser.UNION_ELEMENT:
                    ret = UnionElementOfIntersectionItems.CreateFromAntlrAst(tree);
                    break;
                case asn1Parser.UNION_ELEMENT_ALL_EXCEPT:
                    ret = UnionElementExceptOf.CreateFromAntlrAst(tree);
                    break;
                case asn1Parser.PATTERN_EXPR:
                    ret = PatternExpression.CreateFromAntlrAst(tree);
                    break;
                case asn1Parser.INNER_TYPE_EXPR:
                    Console.Error.WriteLine("Unimplemented feature, 'WITH COMPONENTS' is ignored");
                    ret = new WithComponentsExpression();
                    break;
                default:
                    throw new Exception("Unkown constraint expression: " + tree.Text);
            }

            return ret;
        }
    }

    public partial class ValueRangeExpression : ConstraintExpression
    {
    }

    public partial class SizeExpression : ConstraintExpression
    {
        static public new SizeExpression CreateFromAntlrAst(ITree tree)
        {
            SizeExpression ret = new SizeExpression();
            ret.m_sizeConstraint = Constraint.CreateFromAntlrAst(tree.GetChild(0));
            return ret;
        }
    }

    public partial class SubtypeExpression : ConstraintExpression
    {
        static public new SubtypeExpression CreateFromAntlrAst(ITree tree)
        {
            SubtypeExpression ret = new SubtypeExpression();
            ret.m_type = Asn1Type.CreateFromAntlrAst(tree.GetChild(0));
            if (tree.ChildCount > 1)
                ret.m_includes = true;
            return ret;
        }
    }

    public partial class PermittedAlphabetExpression : ConstraintExpression
    {
        static public new PermittedAlphabetExpression CreateFromAntlrAst(ITree tree)
        {
            PermittedAlphabetExpression ret = new PermittedAlphabetExpression();
            ret.m_permittedAlphabetConstraint = Constraint.CreateFromAntlrAst(tree.GetChild(0));
            return ret;
        }
    }

    public partial class PatternExpression : ConstraintExpression
    {
        static public new PatternExpression CreateFromAntlrAst(ITree tree)
        {
            PatternExpression ret = new PatternExpression();
            ret.m_pattern = Asn1Value.CreateFromAntlrAst(tree.GetChild(0));
            return ret;
        }
    }

#endif
}
