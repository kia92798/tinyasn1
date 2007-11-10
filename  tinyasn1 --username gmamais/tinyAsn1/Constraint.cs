using System;
using System.Collections.Generic;
using System.Text;
using Antlr.Runtime.Tree;

namespace tinyAsn1
{
    /* ************ CONSTRAINTS ********************** */

    public partial class ExceptionSpec
    {
        static public ExceptionSpec CreateFromAntlrAst(ITree tree)
        {
            Console.Error.WriteLine("Unimplemented feature ASN.1 Exception are parsed but ignored");
            return new ExceptionSpec();
        }

    }

    public partial class ValueRangeExpression
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


    public interface IConstraint
    {
        bool isValueAllowed(Asn1Value val);
        bool isPERVisible();
        IConstraint Simplify();
        Asn1Value MIN {get;} //applicable only for Integers & Reals & ?Strings
        Asn1Value MAX {get;} //applicable only for Integers & Reals & ?Strings
        bool IsResolved();
        void DoSemanticAnalysis();
        bool AllowsEverything();
    }

    public class BaseConstraint : IConstraint
    {
        public virtual bool isValueAllowed(Asn1Value val)
        {
            throw new Exception("Abstract method called");
        }
        public virtual bool isPERVisible()
        {
            throw new Exception("Abstract method called");
        }



        public virtual IConstraint Simplify()
        {
            throw new Exception("Abstract method called");
        }
        //applicable only for Integers & Reals & Strings
        public virtual Asn1Value MIN { get { throw new Exception("Abstract method called"); }}
        public virtual Asn1Value MAX { get { throw new Exception("Abstract method called"); }}

        protected IConstraint m_parentTypeConstraint;
        protected Asn1Type m_type;
        

        public BaseConstraint(Asn1Type type, IConstraint parentTypeConstraint)
        {
            m_type = type;
            m_parentTypeConstraint = parentTypeConstraint;
        }

        public virtual bool IsResolved()
        {
            throw new Exception("Abstract method called");
        }
        
        public virtual void DoSemanticAnalysis()
        {
            throw new Exception("Abstract method called");
        }

        public static IConstraint CreateConstraintExpression(ITree tree, Asn1Type type, IConstraint parentTypeConstraint)
        {
            if (tree == null || type == null || parentTypeConstraint == null)
                throw new ArgumentNullException();
            switch (tree.Type)
            {
                case asn1Parser.VALUE_RANGE_EXPR:
                    if (tree.ChildCount == 1)
                        return SingleValueConstraint.Create(tree.GetChild(0), type, parentTypeConstraint);
                    return RangeConstraint.Create(tree, type, parentTypeConstraint);
                case asn1Parser.UNION_SET:
                case asn1Parser.UNION_SET_ALL_EXCEPT:
                    return CreateUnionSet(tree, type, parentTypeConstraint);
                default:
                    throw new Exception("Internal Error: unexpectected token: " + tree.Text);
            }
        }

        public static IConstraint CreateUnionSet(ITree tree, Asn1Type type, IConstraint parentTypeConstraint)
        {
            if (tree == null || type == null || parentTypeConstraint == null)
                throw new ArgumentNullException();
            if (tree.Type == asn1Parser.UNION_SET)
                return UnionConstraint.Create(tree, type, parentTypeConstraint);
            if (tree.Type == asn1Parser.UNION_SET_ALL_EXCEPT)
                return AllExceptConstraint.Create(tree, type, parentTypeConstraint);
            throw new Exception("Internal Error");
        }

        protected static IConstraint CreateIntersectionItem(ITree iTree, Asn1Type type, IConstraint parentTypeConstraint)
        {
            if (iTree == null || type == null || parentTypeConstraint == null)
                throw new ArgumentNullException();
            if (iTree.Type!=asn1Parser.INTERSECTION_ELEMENT)
                throw new Exception("Internal Error");
            if (iTree.ChildCount == 2)
                return ExceptConstraint.Create(iTree, type, parentTypeConstraint);
            return BaseConstraint.CreateConstraintExpression(iTree.GetChild(0), type, parentTypeConstraint);
        }
        public virtual bool AllowsEverything() 
        {
            return false;
        }
    }

    public class DefaultIntegerConstraint : BaseConstraint
    {
        static DefaultIntegerConstraint m_instance;
        private DefaultIntegerConstraint() : base (null,null)
        {
        }
     
        public static DefaultIntegerConstraint Instance
        {
            get
            {
                if (m_instance == null)
                    m_instance = new DefaultIntegerConstraint();
                return m_instance;
            }
        }
        public override void DoSemanticAnalysis()
        {
        }
        
        public override bool isPERVisible()
        {
            return true;
        }
        public override bool IsResolved()
        {
            return true;
        }
        public override Asn1Value MIN
        {
            get
            {
                return new IntegerValue(Config.MININT, null, null, null);
            }
        }
        public override Asn1Value MAX
        {
            get
            {
                return new IntegerValue(Config.MAXINT, null, null, null);
            }
        }
        public override bool isValueAllowed(Asn1Value val)
        {
            return true;
        }
        public override IConstraint Simplify()
        {
            return this;
        }
        public override bool AllowsEverything()
        {
            return true;
        }

        public override string ToString()
        {
            return "";
        }
    }

    public class RootConstraint : BaseConstraint
    {
        IConstraint m_constr;
        IConstraint m_extConstr;

        public RootConstraint(Asn1Type type, IConstraint parentTypeConstraint, IConstraint constr, IConstraint extConstr)
            : base(type, parentTypeConstraint)
        {
            m_constr = constr;
            m_extConstr = extConstr;
        }
        
        public static RootConstraint Create(ITree tree, Asn1Type type, IConstraint parentTypeConstraint)
        {
            if (tree == null || type == null || parentTypeConstraint == null)
                throw new ArgumentNullException();
            if (tree.Type != asn1Parser.CONSTRAINT)
                throw new Exception("Internal Error");
            IConstraint constr = BaseConstraint.CreateUnionSet(tree.GetChild(0), type, parentTypeConstraint);
            IConstraint extConstr=null;

            for (int i = 1; i < tree.ChildCount; i++)
            {
                switch (tree.Type)
                {
                    case asn1Parser.UNION_SET:
                    case asn1Parser.UNION_SET_ALL_EXCEPT:
                        extConstr = BaseConstraint.CreateUnionSet(tree, type, parentTypeConstraint);
                        break;
                    case asn1Parser.EXT_MARK:
                    case asn1Parser.EXCEPTION_SPEC:
                        break;
                    default:
                        throw new Exception("Internal Error");
                }
            }

            return new RootConstraint(type, parentTypeConstraint, constr, extConstr);

        }
        
        public override bool isValueAllowed(Asn1Value val)
        {
            if (m_constr.isValueAllowed(val))
                return true;
            if (m_extConstr != null && m_extConstr.isValueAllowed(val))
                return true;

            return false;
        }

        public override bool IsResolved()
        {
            if (!m_parentTypeConstraint.IsResolved())
                return false;

            if (m_extConstr != null)
                return m_constr.IsResolved() && m_extConstr.IsResolved();
            return m_constr.IsResolved();
        }

        public override void DoSemanticAnalysis()
        {
            if (IsResolved())
                return;
            m_constr.DoSemanticAnalysis();
            if (m_extConstr != null)
                m_extConstr.DoSemanticAnalysis();
        }
        public override IConstraint Simplify()
        {
            if (m_extConstr == null)
                return m_constr.Simplify();
            m_constr.Simplify();
            m_extConstr.Simplify();
            return this;
        }
        public override string ToString()
        {
            string ret = "";
            ret = "(" + m_constr.ToString();
            if (m_extConstr != null)
                ret += ",...," + m_extConstr.ToString();
            ret += ")";
            return ret;
        }
    }
    
    // Union, I
    public class UnionConstraint : BaseConstraint
    {
        List<IConstraint> m_items;

        public UnionConstraint(Asn1Type type, IConstraint parentTypeConstraint, List<IConstraint> items)
            : base(type, parentTypeConstraint)
        {
            m_items = items;
        }

        public static UnionConstraint Create(ITree tree, Asn1Type type, IConstraint parentTypeConstraint)
        {
            if (tree == null || type == null || parentTypeConstraint == null)
                throw new ArgumentNullException();
            if (tree.Type != asn1Parser.UNION_SET)
                throw new Exception("Internal Error");
            
            List<IConstraint> items = new List<IConstraint>();
            for (int i = 0; i < tree.ChildCount; i++)
            {
                items.Add(AndConstraint.Create(tree.GetChild(i), type, parentTypeConstraint));
            }

            return new UnionConstraint(type, parentTypeConstraint, items);
        }

        public override bool isValueAllowed(Asn1Value val)
        {
            foreach (IConstraint cn in m_items)
                if (isValueAllowed(val))
                    return true;
            return false;
        }
        public override bool IsResolved()
        {
            if (!m_parentTypeConstraint.IsResolved())
                return false;
            foreach (IConstraint cn in m_items)
                if (!cn.IsResolved())
                    return false;
            return true;
        }

        public override void DoSemanticAnalysis()
        {
            if (IsResolved())
                return;
            foreach (IConstraint cn in m_items)
                cn.DoSemanticAnalysis();
        }
        
        public override IConstraint Simplify()
        {
            if (m_items.Count == 1)
                return m_items[0].Simplify();
            for (int i = 0; i < m_items.Count; i++)
                m_items[i] = m_items[i].Simplify();

            //Simplify should also attempt to merge child constraints
            // e.g. 1..5 | 4..10 --> 1..10  quite excotic!
            return this;
        }
        public override string ToString()
        {
            string ret = "(";
            int cnt = m_items.Count;
            for (int i = 0; i < cnt - 1; i++)
            {
                ret += m_items[i].ToString() + "|";
            }

            ret += m_items[cnt-1].ToString()+")";
            return ret;
        }
    }

    // Intersection, ^
    public class AndConstraint : BaseConstraint
    {
        List<IConstraint> m_items;

        public AndConstraint(Asn1Type type, IConstraint parentTypeConstraint, List<IConstraint> items)
            : base(type, parentTypeConstraint)
        {
            m_items = items;
        }
        public static AndConstraint Create(ITree tree, Asn1Type type, IConstraint parentTypeConstraint)
        {
            if (tree == null || type == null || parentTypeConstraint == null)
                throw new ArgumentNullException();
            if (tree.Type != asn1Parser.INTERSECTION_SET)
                throw new Exception("Internal Error");
            List<IConstraint> items = new List<IConstraint>();
            for (int i = 0; i < tree.ChildCount; i++)
            {
                items.Add(BaseConstraint.CreateIntersectionItem(tree.GetChild(i), type, parentTypeConstraint));
            }

            return new AndConstraint(type, parentTypeConstraint, items);
        }

        public override bool isValueAllowed(Asn1Value val)
        {
            foreach (IConstraint cn in m_items)
                if (!cn.isValueAllowed(val))
                    return false;

            return true;
        }
        public override bool IsResolved()
        {
            if (!m_parentTypeConstraint.IsResolved())
                return false;

            foreach (IConstraint cn in m_items)
                if (!cn.IsResolved())
                    return false;
            return true;
        }

        public override void DoSemanticAnalysis()
        {
            if (IsResolved())
                return;
            foreach (IConstraint cn in m_items)
                cn.DoSemanticAnalysis();
        }
        public override IConstraint Simplify()
        {
            if (m_items.Count == 1)
                return m_items[0].Simplify();
            for (int i = 0; i < m_items.Count; i++)
                m_items[i] = m_items[i].Simplify();

            return this;
        }
        public override string ToString()
        {
            string ret = "(";
            int cnt = m_items.Count;
            for (int i = 0; i < cnt - 1; i++)
            {
                ret += m_items[i].ToString() + "^";
            }

            ret += m_items[cnt - 1].ToString() + ")";
            return ret;
        }
    }

    public class ExceptConstraint : BaseConstraint
    {
        IConstraint m_c1;
        IConstraint m_c2;

        public ExceptConstraint(Asn1Type type, IConstraint parentTypeConstraint, IConstraint constr1, IConstraint constr2)
            : base(type, parentTypeConstraint)
        {
            m_c1 = constr1;
            m_c2 = constr2;
        }
        public static ExceptConstraint Create(ITree tree, Asn1Type type, IConstraint parentTypeConstraint)
        {
            if (tree == null || type == null || parentTypeConstraint == null)
                throw new ArgumentNullException();
            if (tree.Type != asn1Parser.INTERSECTION_ELEMENT && tree.ChildCount==2)
                throw new Exception("Internal Error");
            IConstraint c1 = BaseConstraint.CreateConstraintExpression(tree.GetChild(0), type, parentTypeConstraint);
            IConstraint c2 = BaseConstraint.CreateConstraintExpression(tree.GetChild(1), type, parentTypeConstraint);

            return new ExceptConstraint(type, parentTypeConstraint, c1, c2);
        }

        public override bool isValueAllowed(Asn1Value val)
        {
            if (m_c1.isValueAllowed(val) && !m_c2.isValueAllowed(val))
                return true;
            return false;
        }
        public override bool IsResolved()
        {
            if (!m_parentTypeConstraint.IsResolved())
                return false;
            return m_c1.IsResolved() && m_c2.IsResolved();
        }

        public override void DoSemanticAnalysis()
        {
            if (IsResolved())
                return;
            m_c1.DoSemanticAnalysis();
            m_c2.DoSemanticAnalysis();
        }
        public override IConstraint Simplify()
        {
            m_c1.Simplify();
            m_c2.Simplify();
            return this;
        }

        public override string ToString()
        {
            return m_c1.ToString() + " EXCEPT " + m_c2.ToString();
        }
    }

    // m_c1 is the Parent constraint
    public class AllExceptConstraint : BaseConstraint
    {
        IConstraint m_c;

        public AllExceptConstraint(Asn1Type type, IConstraint parentTypeConstraint, IConstraint constraint)
            : base(type, parentTypeConstraint)
        {
            m_c = constraint;
        }
        public static AllExceptConstraint Create(ITree tree, Asn1Type type, IConstraint parentTypeConstraint)
        {
            if (tree == null || type == null || parentTypeConstraint == null)
                throw new ArgumentNullException();
            if (tree.Type != asn1Parser.UNION_SET_ALL_EXCEPT)
                throw new Exception("Internal Error");
            IConstraint c = BaseConstraint.CreateConstraintExpression(tree.GetChild(0), type, parentTypeConstraint);

            return new AllExceptConstraint(type, parentTypeConstraint, c);
        }

        public override bool isValueAllowed(Asn1Value val)
        {
            if (m_parentTypeConstraint.isValueAllowed(val) && !m_c.isValueAllowed(val))
                return true;
            return false;
        }

        public override bool IsResolved()
        {
            if (!m_parentTypeConstraint.IsResolved())
                return false;
            return m_c.IsResolved();
        }

        public override void DoSemanticAnalysis()
        {
            if (IsResolved())
                return;
            m_c.DoSemanticAnalysis();
        }

        public override IConstraint Simplify()
        {
            m_c.Simplify();
            return this;
        }
        public override string ToString()
        {
            return "ALL EXCEPT " + m_c.ToString();
        }
    }

    public class SingleValueConstraint : BaseConstraint
    {
        Asn1Value m_val;

        public SingleValueConstraint(Asn1Type type, IConstraint parentTypeConstraint, Asn1Value value)
            : base(type, parentTypeConstraint)
        {
            m_val = value;
        }
        public override bool isValueAllowed(Asn1Value val)
        {
            return m_val.Equals(val);
        }

        public static SingleValueConstraint Create(ITree tree, Asn1Type type, IConstraint parentTypeConstraint) 
        {
            if (tree == null || type == null || parentTypeConstraint == null)
                throw new ArgumentNullException();

            Asn1Value val = Asn1Value.CreateFromAntlrAst(tree);
            val = type.ResolveVariable(val);
            return new SingleValueConstraint(type, parentTypeConstraint, val);
        }

        public override bool IsResolved()
        {
            return m_val.IsResolved() && m_parentTypeConstraint.IsResolved();
        }
        
        public override void DoSemanticAnalysis()
        {
            if (IsResolved())
                return;

            m_val = m_type.ResolveVariable(m_val);
            if (m_val.IsResolved() && m_parentTypeConstraint.IsResolved())
            {
                if (!m_parentTypeConstraint.isValueAllowed(m_val))
                {
                    throw new SemanticErrorException("Error in line:" + m_val.antlrNode.Line + ",col: " + m_val.antlrNode.CharPositionInLine +
                        ". Value: "+m_val.ToString()+" does not belong to parent type");
                }
            }
        }

        public override IConstraint Simplify()
        {
            return this;
        }

        public override Asn1Value MIN
        {
            get
            {
                return m_val;
            }
        }
        public override Asn1Value MAX
        {
            get
            {
                return m_val;
            }
        }
        public override string ToString()
        {
            return m_val.ToString();
        }
    }

    public class RangeConstraint : BaseConstraint
    {
        Asn1Value m_min;
        Asn1Value m_max;
        bool m_minValIsInluded = true;
        bool m_maxValIsInluded = true;

        public RangeConstraint(Asn1Type type, IConstraint parentTypeConstraint, Asn1Value minVal, Asn1Value maxVal,
            bool minValIsInluded, bool maxValIsInluded)
            : base(type, parentTypeConstraint)
        {
            m_min = minVal;
            m_max = maxVal;
            m_minValIsInluded = minValIsInluded;
            m_maxValIsInluded = maxValIsInluded;
        }
        public override bool isValueAllowed(Asn1Value val)
        {
            if ((m_min.CompareTo(val) < 0) && (val.CompareTo(m_max) < 0))
                return true;
            if (m_minValIsInluded && m_min.Equals(val))
                return true;
            if (m_maxValIsInluded && m_max.Equals(val))
                return true;
            return false;
        }

        
        public static RangeConstraint Create(ITree tree, Asn1Type type, IConstraint parentTypeConstraint)
        {
            if (tree == null || type == null || parentTypeConstraint == null)
                throw new ArgumentNullException();
            if (tree.Type != asn1Parser.VALUE_RANGE_EXPR)
                throw new Exception("Internal Error");
            if (tree.ChildCount <2)
                throw new Exception("Internal Error");

            Asn1Value minVal=null;
            if (tree.GetChild(0).Type != asn1Parser.MIN)
            {
                minVal = Asn1Value.CreateFromAntlrAst(tree.GetChild(0));
                minVal = type.ResolveVariable(minVal);
            }
            else if (parentTypeConstraint.IsResolved())
                minVal = parentTypeConstraint.MIN;

            Asn1Value maxVal = null;
            if (tree.GetChild(1).GetChild(0).Type != asn1Parser.MAX)
            {
                maxVal = Asn1Value.CreateFromAntlrAst(tree.GetChild(1).GetChild(0));
                maxVal = type.ResolveVariable(maxVal);
            }
            else if (parentTypeConstraint.IsResolved())
                maxVal = parentTypeConstraint.MAX;

            bool minValIsInclude = true;
            bool maxValIsInclude = true;

            for (int i = 2; i < tree.ChildCount; i++)
            {
                if (tree.GetChild(i).Type == asn1Parser.MIN_VAL_INCLUDED)
                    minValIsInclude = false;
                if (tree.GetChild(i).Type == asn1Parser.MAX_VAL_INCLUDED)
                    maxValIsInclude = false;
            }
            return new RangeConstraint(type, parentTypeConstraint, minVal, maxVal, minValIsInclude, maxValIsInclude);
        }
        public override bool IsResolved()
        {
            if (m_min == null)
                return false;
            if (m_max == null)
                return false;
            return m_min.IsResolved() && m_max.IsResolved() && m_parentTypeConstraint.IsResolved();
        }

        public override void DoSemanticAnalysis()
        {
            if (IsResolved())
                return;

            if (m_min != null)
                m_min = m_type.ResolveVariable(m_min);
            else if (m_parentTypeConstraint.IsResolved())
                m_min = m_parentTypeConstraint.MIN;

            if (m_min!=null && m_min.IsResolved() && m_parentTypeConstraint.IsResolved())
            {
                if (!m_parentTypeConstraint.isValueAllowed(m_min))
                {
                    throw new SemanticErrorException("Error in line:" + m_min.antlrNode.Line + ",col: " + m_min.antlrNode.CharPositionInLine +
                        ". Value: " + m_min.ToString() + " does not belong to parent type");
                }
            }

            if (m_max != null)
                m_max = m_type.ResolveVariable(m_max);
            else if (m_parentTypeConstraint.IsResolved())
                m_max = m_parentTypeConstraint.MAX;

            if (m_max!=null && m_max.IsResolved() && m_parentTypeConstraint.IsResolved())
            {
                if (!m_parentTypeConstraint.isValueAllowed(m_max))
                {
                    throw new SemanticErrorException("Error in line:" + m_max.antlrNode.Line + ",col: " + m_max.antlrNode.CharPositionInLine +
                        ". Value: " + m_max.ToString() + " does not belong to parent type");
                }
            }

            if (m_min!=null && m_max!=null && m_min.IsResolved() && m_max.IsResolved())
            {
                if (m_min.CompareTo(m_max) > 0)
                    throw new SemanticErrorException("Error in line:" + m_min.antlrNode.Line + ",col: " + m_min.antlrNode.CharPositionInLine +
                        ". Lower range value: (" + m_min.ToString() + ") is greater than upper range value: ("+ m_max.ToString()+")");
            }

        }
        public override IConstraint Simplify()
        {
            return this;
        }

        public override Asn1Value MIN
        {
            get
            {
                IntegerValue v = m_min as IntegerValue;
                if (!m_minValIsInluded && v!=null) {
                    IntegerValue vp1 = new IntegerValue(v);
                    vp1.Value++;
                    return vp1;
                }
                return m_min;
            }
        }
        public override Asn1Value MAX
        {
            get
            {
                IntegerValue v = m_max as IntegerValue;
                if (!m_maxValIsInluded && v != null)
                {
                    IntegerValue vp1 = new IntegerValue(v);
                    vp1.Value--;
                    return vp1;
                }
                return m_max;
            }
        }

        public override string ToString()
        {
            string ret = m_min.ToString();
            if (!m_minValIsInluded)
                ret += "<";
            ret += "..";
            if (!m_maxValIsInluded)
                ret += "<";
            ret += m_max.ToString();
            return ret;
        }
    }

    public class SizeConstraint : BaseConstraint
    {
        ConstraintsSet<Int64> m_allowedSizes;
        IConstraint m_constraint;       //parent type is INTEGER(0..MAX) where MAX is platform's MAXINT
        public SizeConstraint(Asn1Type type, IConstraint parentTypeConstraint, IConstraint constraint)
            : base(type, parentTypeConstraint)
        {
            m_constraint = constraint;
            m_allowedSizes = CreateFromConstraint(constraint);
     
        }

        public override bool isValueAllowed(Asn1Value val)
        {
            ISize size = val as ISize;
            if (size == null)
                throw new ArgumentException("Internal Error, val does not implement Size interface");
            if (m_allowedSizes.HasValue(size.Size))
                return true;
            
            return false;
        }

        ConstraintsSet<Int64> CreateFromConstraint(IConstraint constraint)
        {
            throw new Exception();
        }
        public override string ToString()
        {
            return "SIZE "+ m_constraint.ToString();
        }

    }

    public class PermittedAlphabetConstraint : BaseConstraint
    {

        IConstraint m_constraint;       //parent type is ??
        ConstraintsSet<Char> m_allowedChars;

        public PermittedAlphabetConstraint(Asn1Type type, IConstraint parentTypeConstraint, IConstraint constraint)
            : base(type, parentTypeConstraint)
        {
            m_constraint = constraint;
            m_allowedChars = CreateFromConstraint(constraint);
        }

        ConstraintsSet<Char> CreateFromConstraint(IConstraint constraint)
        {
            throw new Exception();
        }
        
        public override bool isValueAllowed(Asn1Value val)
        {
            ICharacterString charStr = val as ICharacterString;
            if (charStr == null)
                throw new ArgumentException("Internal Error, val does not implement ICharacterString interface");
            
            if (m_allowedChars.IsNull())
                return false;

            foreach (Char ch in charStr.Value)
                if (!m_allowedChars.HasValue(ch))
                    return false;

            return true;
        }
        public override string ToString()
        {
            return "FROM " + m_constraint.ToString();
        }
    }





/*
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
*/
//    public partial class ValueRangeExpression : ConstraintExpression
/*
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

*/


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
