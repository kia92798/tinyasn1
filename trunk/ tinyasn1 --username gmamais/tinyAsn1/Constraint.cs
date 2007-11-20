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

    public interface IConstraint
    {
        bool isValueAllowed(Asn1Value val);
        bool isPERVisible();
        IConstraint Simplify();
        //Asn1Value MIN {get;} //applicable only for Integers & Reals & ?Strings
        //Asn1Value MAX {get;} //applicable only for Integers & Reals & ?Strings
        bool IsResolved();
        void DoSemanticAnalysis();
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
        ////applicable only for Integers & Reals & Strings
        //public virtual Asn1Value MIN { get { throw new Exception("Abstract method called"); }}
        //public virtual Asn1Value MAX { get { throw new Exception("Abstract method called"); }}

        protected Asn1Type m_type;
        
        
        public BaseConstraint(Asn1Type type)
        {
            m_type = type;
        }

        public virtual bool IsResolved()
        {
            throw new Exception("Abstract method called");
        }
        
        public virtual void DoSemanticAnalysis()
        {
            throw new Exception("Abstract method called");
        }

        public static IConstraint CreateConstraintExpression(ITree tree, Asn1Type type)
        {
            if (tree == null || type == null)
                throw new ArgumentNullException();
            switch (tree.Type)
            {
                case asn1Parser.VALUE_RANGE_EXPR:
                    if (tree.ChildCount == 1)
                        return SingleValueConstraint.Create(tree.GetChild(0), type);
                    return RangeConstraint.Create(tree, type);
                case asn1Parser.UNION_SET:
                case asn1Parser.UNION_SET_ALL_EXCEPT:
                    return CreateUnionSet(tree, type);
                case asn1Parser.SIZE_EXPR:
                    return SizeConstraint.Create(tree, type);
                case asn1Parser.PERMITTED_ALPHABET_EXPR:
                    return PermittedAlphabetConstraint.Create(tree, type);
                case asn1Parser.SUBTYPE_EXPR:
                    return TypeInclusionConstraint.Create(tree, type);
                case asn1Parser.WITH_COMPONENT_CONSTR:
                    return WithComponentConstraint.Create(tree, type);
                case asn1Parser.WITH_COMPONENTS_CONSTR:
                    return WithComponentsConstraint.Create(tree, type);
                default:
                    throw new Exception("Internal Error: unexpectected token: " + tree.Text);
            }
        }

        public static IConstraint CreateUnionSet(ITree tree, Asn1Type type)
        {
            if (tree == null || type == null )
                throw new ArgumentNullException();
            if (tree.Type == asn1Parser.UNION_SET)
                return UnionConstraint.Create(tree, type);
            if (tree.Type == asn1Parser.UNION_SET_ALL_EXCEPT)
                return AllExceptConstraint.Create(tree, type);
            throw new Exception("Internal Error");
        }

        protected static IConstraint CreateIntersectionItem(ITree iTree, Asn1Type type)
        {
            if (iTree == null || type == null )
                throw new ArgumentNullException();
            if (iTree.Type!=asn1Parser.INTERSECTION_ELEMENT)
                throw new Exception("Internal Error");
            if (iTree.ChildCount == 2)
                return ExceptConstraint.Create(iTree, type);
            return BaseConstraint.CreateConstraintExpression(iTree.GetChild(0), type);
        }
    }

/*   
    public class DefaultIntegerConstraint : BaseConstraint
    {
        static DefaultIntegerConstraint m_instance;
        private DefaultIntegerConstraint() : base (null)
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
    */
    public class RootConstraint : BaseConstraint
    {
        IConstraint m_constr;
        IConstraint m_extConstr;

        public RootConstraint(Asn1Type type, IConstraint constr, IConstraint extConstr)
            : base(type)
        {
            m_constr = constr;
            m_extConstr = extConstr;
        }
        
        public static IConstraint Create(ITree tree, Asn1Type type)
        {
            if (tree == null || type == null )
                throw new ArgumentNullException();
            if (tree.Type == asn1Parser.SIMPLIFIED_SIZE_CONSTRAINT)
                return SizeConstraint.Create(tree, type);
            if (tree.Type != asn1Parser.CONSTRAINT)
                throw new Exception("Internal Error");
            
            IConstraint constr = BaseConstraint.CreateUnionSet(tree.GetChild(0), type);
            IConstraint extConstr=null;

            for (int i = 1; i < tree.ChildCount; i++)
            {
                switch (tree.Type)
                {
                    case asn1Parser.UNION_SET:
                    case asn1Parser.UNION_SET_ALL_EXCEPT:
                        extConstr = BaseConstraint.CreateUnionSet(tree, type);
                        break;
                    case asn1Parser.EXT_MARK:
                    case asn1Parser.EXCEPTION_SPEC:
                        break;
                    default:
                        throw new Exception("Internal Error");
                }
            }

            return new RootConstraint(type, constr, extConstr);

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

        public UnionConstraint(Asn1Type type, List<IConstraint> items)
            : base(type)
        {
            m_items = items;
        }

        public static UnionConstraint Create(ITree tree, Asn1Type type)
        {
            if (tree == null || type == null)
                throw new ArgumentNullException();
            if (tree.Type != asn1Parser.UNION_SET)
                throw new Exception("Internal Error");
            
            List<IConstraint> items = new List<IConstraint>();
            for (int i = 0; i < tree.ChildCount; i++)
            {
                items.Add(AndConstraint.Create(tree.GetChild(i), type));
            }

            return new UnionConstraint(type, items);
        }

        public override bool isValueAllowed(Asn1Value val)
        {
            foreach (IConstraint cn in m_items)
                if (cn.isValueAllowed(val))
                    return true;
            return false;
        }
        public override bool IsResolved()
        {
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

/*        public override Asn1Value MIN
        {
            get
            {
                // return the smallest MIN
                Asn1Value curMin = m_items[0].MIN;
                foreach (IConstraint con in m_items)
                {
                    if (con.MIN.CompareTo(curMin) < 0)
                        curMin = con.MIN;
                }
                return curMin;
            }
        }
        public override Asn1Value MAX
        {
            get
            {
                // return maximum MAX
                Asn1Value curMax = m_items[0].MAX;
                foreach (IConstraint con in m_items)
                {
                    if (con.MAX.CompareTo(curMax) > 0)
                        curMax = con.MAX;
                }
                return curMax;
            }
        }
        */
    }

    // Intersection, ^
    public class AndConstraint : BaseConstraint
    {
        List<IConstraint> m_items;

        public AndConstraint(Asn1Type type, List<IConstraint> items)
            : base(type)
        {
            m_items = items;
        }
        public static AndConstraint Create(ITree tree, Asn1Type type)
        {
            if (tree == null || type == null )
                throw new ArgumentNullException();
            if (tree.Type != asn1Parser.INTERSECTION_SET)
                throw new Exception("Internal Error");
            List<IConstraint> items = new List<IConstraint>();
            for (int i = 0; i < tree.ChildCount; i++)
            {
                items.Add(BaseConstraint.CreateIntersectionItem(tree.GetChild(i), type));
            }

            return new AndConstraint(type, items);
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

/*        public override Asn1Value MIN
        {
            get
            {
                //return greatest min
                Asn1Value curMin = m_items[0].MIN;
                foreach (IConstraint con in m_items)
                {
                    if (con.MIN.CompareTo(curMin) > 0)
                        curMin = con.MIN;
                }
                return curMin;
            }
        }

        public override Asn1Value MAX
        {
            get
            {
                //return the smallest MAX
                Asn1Value curMax = m_items[0].MAX;
                foreach (IConstraint con in m_items)
                {
                    if (con.MAX.CompareTo(curMax) < 0)
                        curMax = con.MAX;
                }
                return curMax;
            }
        }*/
    }

    public class ExceptConstraint : BaseConstraint
    {
        IConstraint m_c1;
        IConstraint m_c2;

        public ExceptConstraint(Asn1Type type, IConstraint constr1, IConstraint constr2)
            : base(type)
        {
            m_c1 = constr1;
            m_c2 = constr2;
        }
        public static ExceptConstraint Create(ITree tree, Asn1Type type)
        {
            if (tree == null || type == null )
                throw new ArgumentNullException();
            if (tree.Type != asn1Parser.INTERSECTION_ELEMENT && tree.ChildCount==2)
                throw new Exception("Internal Error");
            IConstraint c1 = BaseConstraint.CreateConstraintExpression(tree.GetChild(0), type);
            IConstraint c2 = BaseConstraint.CreateConstraintExpression(tree.GetChild(1), type);

            return new ExceptConstraint(type, c1, c2);
        }

        public override bool isValueAllowed(Asn1Value val)
        {
            if (m_c1.isValueAllowed(val) && !m_c2.isValueAllowed(val))
                return true;
            return false;
        }
        public override bool IsResolved()
        {
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

/*        public override Asn1Value MIN
        {
            get
            {
                //To calculate min and max we have to eliminate Exclude constraints. To achieve
                // we will use set's algebra

                return base.MIN;
            }
        }*/
        
    }

    // m_c1 is the Parent constraint
    public class AllExceptConstraint : BaseConstraint
    {
        IConstraint m_c;

        public AllExceptConstraint(Asn1Type type, IConstraint constraint)
            : base(type)
        {
            m_c = constraint;
        }
        public static AllExceptConstraint Create(ITree tree, Asn1Type type)
        {
            if (tree == null || type == null)
                throw new ArgumentNullException();
            if (tree.Type != asn1Parser.UNION_SET_ALL_EXCEPT)
                throw new Exception("Internal Error");
            IConstraint c = BaseConstraint.CreateConstraintExpression(tree.GetChild(0), type);

            return new AllExceptConstraint(type, c);
        }

        public override bool isValueAllowed(Asn1Value val)
        {
            if (!m_c.isValueAllowed(val))
                return true;
            return false;
        }

        public override bool IsResolved()
        {
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
        protected Asn1Value m_val;

        public SingleValueConstraint(Asn1Type type, Asn1Value value)
            : base(type)
        {
            m_val = value;
        }
        public override bool isValueAllowed(Asn1Value val)
        {
            return m_val.Equals(val);
        }

        public static SingleValueConstraint Create(ITree tree, Asn1Type type) 
        {
            if (tree == null || type == null)
                throw new ArgumentNullException();
            
            Asn1Value val = Asn1Value.CreateFromAntlrAst(tree);
//            val = type.ResolveVariable(val);
            if ((type is IA5StringType) && ( ((IA5StringType)type).IamUsedInPermittedAlphabet))
                return new SinglePAValueConstraint(type, val);
            return new SingleValueConstraint(type, val);
        }

        public override bool IsResolved()
        {
            return m_val.IsResolved();
        }
        
        public override void DoSemanticAnalysis()
        {
            if (IsResolved())
                return;

            m_val = m_type.ResolveVariable(m_val);
            if (m_val.IsResolved() && m_type.ParentType!=null && m_type.ParentType.AreConstraintsResolved())
            {
                if (!m_type.ParentType.isValueAllowed(m_val))
                {
                    Console.Error.WriteLine("Warning line:" + m_val.antlrNode.Line + ",col: " + m_val.antlrNode.CharPositionInLine +
                        ". Value: "+m_val.ToString()+" does not belong to parent type");
                }
            }
        }

        public override IConstraint Simplify()
        {
            return this;
        }

/*        public override Asn1Value MIN
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
        }*/
        public override string ToString()
        {
            return m_val.ToString();
        }
    }

    public class SinglePAValueConstraint : SingleValueConstraint
    {
        public SinglePAValueConstraint(Asn1Type type, Asn1Value value)
            : base(type, value)
        {
        }
        public override bool isValueAllowed(Asn1Value val)
        {
            ICharacterString str = val as ICharacterString;
            ICharacterString set = m_val as ICharacterString;
            if (str == null || set == null)
                throw new Exception("Internal Error");
            if (str.Value.Length != 1)
                throw new Exception("Internal Error");
            Char ch = str.Value[0];

            if (!set.Value.Contains(ch.ToString()))
                return false;
            return true;
        }
    }

    public class RangeConstraint : BaseConstraint
    {
        /// <summary>
        /// if m_min is null then m_min is MIN
        /// </summary>
        protected Asn1Value m_min;
        /// <summary>
        /// if m_max is null then m_max is MAX
        /// </summary>
        protected Asn1Value m_max;
        protected bool m_minValIsInluded = true;
        protected bool m_maxValIsInluded = true;

        public RangeConstraint(Asn1Type type, Asn1Value minVal, Asn1Value maxVal,
            bool minValIsInluded, bool maxValIsInluded)
            : base(type)
        {
            m_min = minVal;
            m_max = maxVal;
            m_minValIsInluded = minValIsInluded;
            m_maxValIsInluded = maxValIsInluded;
        }
        public override bool isValueAllowed(Asn1Value val)
        {
            if (m_min == null && m_max == null)  //(MIN..MAX)
                return true;
            if (m_min == null && (val.CompareTo(m_max) < 0)) // (MIN..value)
                return true;
            if ((m_min.CompareTo(val) < 0) && m_max==null)
                return true;
            if ((m_min.CompareTo(val) < 0) && (val.CompareTo(m_max) < 0))
                return true;
            if (m_minValIsInluded && m_min!=null && m_min.Equals(val))
                return true;
            if (m_maxValIsInluded && m_max!=null && m_max.Equals(val))
                return true;
            return false;
        }

        
        public static RangeConstraint Create(ITree tree, Asn1Type type )
        {
            if (tree == null || type == null )
                throw new ArgumentNullException();
            if (tree.Type != asn1Parser.VALUE_RANGE_EXPR)
                throw new Exception("Internal Error");
            if (tree.ChildCount <2)
                throw new Exception("Internal Error");

            Asn1Value minVal=null;
            if (tree.GetChild(0).Type != asn1Parser.MIN)
            {
                minVal = Asn1Value.CreateFromAntlrAst(tree.GetChild(0));
//                minVal = type.ResolveVariable(minVal);
            }

            Asn1Value maxVal = null;
            if (tree.GetChild(1).GetChild(0).Type != asn1Parser.MAX)
            {
                maxVal = Asn1Value.CreateFromAntlrAst(tree.GetChild(1).GetChild(0));
//                maxVal = type.ResolveVariable(maxVal);
            }

            bool minValIsInclude = true;
            bool maxValIsInclude = true;

            for (int i = 2; i < tree.ChildCount; i++)
            {
                if (tree.GetChild(i).Type == asn1Parser.MIN_VAL_INCLUDED)
                    minValIsInclude = false;
                if (tree.GetChild(i).Type == asn1Parser.MAX_VAL_INCLUDED)
                    maxValIsInclude = false;
            }

            if ((type is IA5StringType) && (((IA5StringType)type).IamUsedInPermittedAlphabet))
                return new RangePAConstraint(type, minVal, maxVal, minValIsInclude, maxValIsInclude);
            return new RangeConstraint(type, minVal, maxVal, minValIsInclude, maxValIsInclude);
        }
        public override bool IsResolved()
        {
            if (m_min == null && m_max == null)  //(MIN..MAX)
                return true;
            if (m_min == null && m_max != null)
                return m_max.IsResolved();
            if (m_min != null && m_max == null)
                return m_min.IsResolved();
            return m_min.IsResolved() && m_max.IsResolved();
        }

        public override void DoSemanticAnalysis()
        {
            if (IsResolved())
                return;

            if (m_min != null)
                m_min = m_type.ResolveVariable(m_min);

            if (m_min != null && m_min.IsResolved() && m_type.ParentType != null && m_type.ParentType.AreConstraintsResolved())
            {
                if (!m_type.ParentType.isValueAllowed(m_min))
                {
                    if (m_type is SizeConstraint.DummyReferenceType)
                        throw new SemanticErrorException("Error line:" + m_max.antlrNode.Line + ",col: " + m_max.antlrNode.CharPositionInLine +
                            ". A Size constraint must not include non negative integer numbers");
                    else
                        Console.Error.WriteLine("Warning line:" + m_min.antlrNode.Line + ",col: " + m_min.antlrNode.CharPositionInLine +
                         ". Value: " + m_min.ToString() + " does not belong to parent type");
                }
            } 

            if (m_max != null)
                m_max = m_type.ResolveVariable(m_max);

            if (m_max != null && m_max.IsResolved() && m_type.ParentType != null && m_type.ParentType.AreConstraintsResolved())
            {
                if (!m_type.ParentType.isValueAllowed(m_max))
                {
                    if (m_type is SizeConstraint.DummyReferenceType)
                        throw new SemanticErrorException("Error line:" + m_max.antlrNode.Line + ",col: " + m_max.antlrNode.CharPositionInLine +
                            ". A Size constraint must not include non negative integer numbers");
                    else
                        Console.Error.WriteLine("Warning line:" + m_max.antlrNode.Line + ",col: " + m_max.antlrNode.CharPositionInLine +
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

/*        public override Asn1Value MIN
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
        }*/

        public override string ToString()
        {
            string ret = "";
            if (m_min==null)
                ret="MIN";
            else
                ret = m_min.ToString();

            if (!m_minValIsInluded)
                ret += "<";
            ret += "..";
            if (!m_maxValIsInluded)
                ret += "<";
            if (m_max == null)
                ret += "MAX";
            else
                ret += m_max.ToString();
            return ret;
        }
    }

    public class RangePAConstraint : RangeConstraint
    {
        public RangePAConstraint(Asn1Type type, Asn1Value minVal, Asn1Value maxVal,
            bool minValIsInluded, bool maxValIsInluded)
            : base(type, minVal, maxVal, minValIsInluded, maxValIsInluded)
        {
        }

        public override void DoSemanticAnalysis()
        {
            if (IsResolved())
                return;
            base.DoSemanticAnalysis();
            if (m_min != null && m_min.IsResolved() && Lo.Value.Length!=1)
            {
                Console.Error.WriteLine("Warning line: "+m_min.antlrNode.Line+": Permitted alphabet ranges must constain single character string. The constraint will be ignored");
            }

            if (m_max != null && m_max.IsResolved() && Hi.Value.Length != 1)
            {
                Console.Error.WriteLine("Warning line: " + m_max.antlrNode.Line + ": Permitted alphabet ranges must constain single character string. The constraint will be ignored");
            }
            
        }
        ICharacterString Lo
        {
            get { return (ICharacterString)m_min; }
        }
        ICharacterString Hi
        {
            get { return (ICharacterString)m_max; }
        }
        public override bool isValueAllowed(Asn1Value val)
        {
            if (m_min != null && Lo.Value.Length != 1)
                return true; // ignore constraint
            if (m_max != null && Hi.Value.Length != 1)
                return true; // ignore constraint
            ICharacterString str = val as ICharacterString;
            if (str.Value.Length != 1)
                throw new Exception("Internal Error");

            if (m_min == null && m_max == null)  //(MIN..MAX)
                return true;

            Char min;
            Char max;
            Char ch = str.Value[0];
            if (m_min != null && m_max == null) // (value..MAX)
            {
                min = Lo.Value[0];
                if (ch < min)
                    return false;
                else if (min == ch && !m_minValIsInluded)
                    return false;
            }
            else if (m_min == null && m_max != null) // (MIN..value)
            {
                max = Hi.Value[0];
                if (ch > max)
                    return false;
                else if (ch == max && !m_maxValIsInluded)
                    return false;
            }
            else
            {
                min = Lo.Value[0];
                max = Hi.Value[0];
                if ((ch < min) || (ch > max))
                    return false;
                else if (min == ch && !m_minValIsInluded)
                    return false;
                else if (ch == max && !m_maxValIsInluded)
                    return false;
            }

            return true;
        }
    }

    public class SizeConstraint : BaseConstraint
    {
        public class DummyReferenceType : ReferenceType
        {
            IntegerType dummyInterger;
            public DummyReferenceType(Module mod, ITree antlr)
            {
                m_module = mod;
                antlrNode = antlr;
                dummyInterger = new IntegerType();
                dummyInterger.antlrNode = antlr;
                dummyInterger.m_module = mod;
                dummyInterger.m_constraints.Add(new RangeConstraint(dummyInterger, new IntegerValue(0, mod, antlr, dummyInterger), null, true, true));
                m_referencedTypeName = "SIZE";
            }
            public override Asn1Type ParentType { get { return dummyInterger; } }
            public override Asn1Type Type { get { return dummyInterger; } }
            public override string ToString()
            {
                string ret = "SIZE (";
                foreach (IConstraint con in m_constraints)
                    ret+=con.ToString();
                ret += ")";
                return ret;
            }
        }

        DummyReferenceType sizeCon;

        public SizeConstraint(Asn1Type type, DummyReferenceType sc)
            : base(type)
        {
            sizeCon = sc;
        }

        public static IConstraint Create(ITree tree, Asn1Type type)
        {
            if (tree == null || type == null)
                throw new ArgumentNullException();
            if (!(tree.Type == asn1Parser.SIZE_EXPR || tree.Type==asn1Parser.SIMPLIFIED_SIZE_CONSTRAINT))
                throw new Exception("Internal Error");

            DummyReferenceType sc = new DummyReferenceType(type.m_module, tree);
            sc.m_AntlrConstraints.Add(tree.GetChild(0));
            return new SizeConstraint(type, sc);
        }

        public override bool IsResolved()
        {
            return sizeCon.AreConstraintsResolved();
        }
        public override void DoSemanticAnalysis()
        {
            sizeCon.ResolveConstraints();
        }
        public override IConstraint Simplify()
        {
            return this;
        }
        public override bool isValueAllowed(Asn1Value val)
        {
            ISize size = val as ISize;
            if (size == null)
                throw new ArgumentException("Internal Error, val does not implement Size interface");

            return sizeCon.isValueAllowed(new IntegerValue(size.Size, m_type.m_module, null, sizeCon));
        }

        public override string ToString()
        {
            return sizeCon.ToString();
        }

    }

    public class PermittedAlphabetConstraint : BaseConstraint
    {
        IA5StringType allowed_char_set;

        public PermittedAlphabetConstraint(Asn1Type type, IA5StringType allowed_char)
            : base(type)
        {
            allowed_char_set = allowed_char;
        }

        internal static IConstraint Create(ITree tree, Asn1Type type)
        {
            if (tree == null || type == null)
                throw new ArgumentNullException();
            if (tree.Type != asn1Parser.PERMITTED_ALPHABET_EXPR)
                throw new Exception("Internal Error");

            IA5StringType ia = type as IA5StringType;
            IA5StringType set = ia.CreateForPA(type.m_module, tree);
            set.m_AntlrConstraints.Add(tree.GetChild(0));

            return new PermittedAlphabetConstraint(type, set);
        }

        public override bool IsResolved()
        {
            return allowed_char_set.AreConstraintsResolved();
        }
        public override void DoSemanticAnalysis()
        {
            allowed_char_set.ResolveConstraints();
        }
        
        public override bool isValueAllowed(Asn1Value val)
        {
            ICharacterString str = val as ICharacterString;
            if (str == null)
                throw new Exception("Internal error");
            foreach (Char ch in str.Value)
            {
                IA5StringValue v = new IA5StringValue(ch);
                if (!allowed_char_set.isValueAllowed(v))
                    return false;
            }

            return true;
        }
        public override string ToString()
        {
            string ret = "FROM (";
            foreach (IConstraint con in allowed_char_set.m_constraints)
                ret += con.ToString();
            ret += ")";
            return ret;
        }
        public override IConstraint Simplify()
        {
            return this;
        }
    }



    public class TypeInclusionConstraint : BaseConstraint
    {
        Asn1Type m_otherType;

        public TypeInclusionConstraint(Asn1Type type, Asn1Type otherType)
            : base(type)
        {
            m_otherType = otherType;
        }

        internal static IConstraint Create(ITree tree, Asn1Type type)
        {
            if (tree == null || type == null)
                throw new ArgumentNullException();
            if (tree.Type != asn1Parser.SUBTYPE_EXPR)
                throw new Exception("Internal Error");

            Asn1Type oth = Asn1Type.CreateFromAntlrAst(tree.GetChild(0));
            if (oth.SemanticAnalysisFinished())
            {
                if (oth.GetFinalType() != type.GetFinalType())
                    throw new SemanticErrorException("Error, line:" + oth.antlrNode.Line + " .Types '"+oth.Name+"' and '"+type.Name+"' are not compatible");
            }

            return new TypeInclusionConstraint(type, oth);
        }

        public override bool IsResolved()
        {
            return m_otherType.SemanticAnalysisFinished() && m_otherType.AreConstraintsResolved();
        }
        public override void DoSemanticAnalysis()
        {
            //if (IsResolved())
            //    return;
            if (!m_otherType.SemanticAnalysisFinished())
                m_otherType.DoSemanticAnalysis();

            if (m_otherType.SemanticAnalysisFinished() && !m_otherType.AreConstraintsResolved())
                m_otherType.ResolveConstraints();

            if (m_otherType.AreConstraintsResolved())
            {
                if (m_otherType.GetFinalType() != m_type.GetFinalType())
                    throw new SemanticErrorException("Error, line:" + m_otherType.antlrNode.Line + " .Types are not compatible");
            }
        }

        public override bool isValueAllowed(Asn1Value val)
        {
            return m_otherType.isValueAllowed(val);
        }
        public override string ToString()
        {
            return m_otherType.Name;
        }
        public override IConstraint Simplify()
        {
            return this;
        }
    }

    public class WithComponentConstraint : BaseConstraint
    {
        IConstraint m_innerTypeConstraint;
        Asn1Type m_innerType;

        public WithComponentConstraint(Asn1Type type, Asn1Type innerType, IConstraint innerTypeConstraint)
            : base(type)
        {
            m_innerTypeConstraint = innerTypeConstraint;
            m_innerType = innerType;
        }

        internal static IConstraint Create(ITree tree, Asn1Type type)
        {
            if (tree == null || type == null)
                throw new ArgumentNullException();
            if (tree.Type != asn1Parser.WITH_COMPONENT_CONSTR)
                throw new Exception("Internal Error");
            ArrayType arrayType = type.GetFinalType() as ArrayType;
            if (arrayType==null)
                throw new SemanticErrorException("Error line:"+tree.Line+" WITH COMPONENT constraint can appear only in reference types which reference a SEQUENCE OF or SET OF");
            Asn1Type innerType = arrayType.m_type;
            IConstraint innerConstraint=null;
            innerType.ResolveExternalConstraints(tree.GetChild(0), ref innerConstraint);
            if (innerConstraint.IsResolved())
                innerConstraint = innerConstraint.Simplify();
            return new WithComponentConstraint(type, innerType, innerConstraint);
        }

        public override bool IsResolved()
        {
            return m_innerTypeConstraint.IsResolved();
        }
        public override void DoSemanticAnalysis()
        {
            if (IsResolved())
                return;

            m_innerType.ResolveExternalConstraints(null, ref m_innerTypeConstraint);
            if (m_innerTypeConstraint.IsResolved())
                m_innerTypeConstraint = m_innerTypeConstraint.Simplify();
            
        }

        public override bool isValueAllowed(Asn1Value val)
        {
            ArrayValue arval = val as ArrayValue;
            if (arval == null)
                throw new Exception("Internal Error");
            foreach (Asn1Value v in arval.m_children)
                if (!m_innerTypeConstraint.isValueAllowed(v))
                    return false;
            
            return true;
        }

        public override string ToString()
        {
            return "WITH COMPONENT (" + m_innerTypeConstraint.ToString() + ")";
        }
        public override IConstraint Simplify()
        {
            return this;
        }
    }

    public class WithComponentsConstraint : BaseConstraint
    {
        public class Component
        {
            public enum Optionality {
                Present,
                Absent,
                Optional,
                None
            }
            public string m_name;
            public Optionality m_optionality = Optionality.None;
            public IConstraint m_constraint = null;
            public Component(string name, Optionality opt, IConstraint con)
            {
                m_name = name;
                m_optionality = opt;
                m_constraint = con;
            }
        }

        protected bool m_partialSpecification = false; //i.e. ... are not present
        protected List<Component> m_components = new List<Component>();

        internal static IConstraint Create(ITree tree, Asn1Type type)
        {
            if (tree == null || type == null)
                throw new ArgumentNullException();
            if (tree.Type != asn1Parser.WITH_COMPONENTS_CONSTR)
                throw new Exception("Internal Error");
            if (type.GetFinalType() is SequenceOrSetType)
                return WithComponentsSeqConstraint.Create2(tree, (SequenceOrSetType)type.GetFinalType());
            if (type.GetFinalType() is ChoiceType)
                return WithComponentsChConstraint.Create2(tree, (ChoiceType)type.GetFinalType());

            throw new Exception("Internal Error");
        }

        public WithComponentsConstraint(Asn1Type type, bool partialSpecification, List<Component> components)
            : base(type)
        {
            m_partialSpecification = partialSpecification;
            m_components = components;
        }
    }

    public class WithComponentsSeqConstraint : WithComponentsConstraint
    {
        public WithComponentsSeqConstraint(Asn1Type type, bool partialSpecification, List<Component> components)
            : base(type, partialSpecification, components)
        {
        }
        internal static IConstraint Create2(ITree tree, SequenceOrSetType type)
        {
            List<Component> components = new List<Component>();
            bool partialSpecification = false;

            for (int i = 0; i < tree.ChildCount; i++)
            {
                ITree chTree = tree.GetChild(i);
                if (chTree.Type == asn1Parser.EXT_MARK)
                    partialSpecification = true;
                else if (chTree.Type == asn1Parser.NAME_CONSTRAINT_EXPR)
                {
                    string id = null;
                    Component.Optionality opt = Component.Optionality.None;
                    if (!partialSpecification)
                        opt = Component.Optionality.Present;    //default setting if no optionality modifier is present
                    ITree constraint = null;
                    for (int j = 0; j < chTree.ChildCount; j++)
                    {
                        ITree grChTree = chTree.GetChild(j);
                        switch (grChTree.Type)
                        {
                            case asn1Parser.LID:
                                id = grChTree.Text;
                                break;
                            case asn1Parser.PRESENT:
                                opt = Component.Optionality.Present;
                                break;
                            case asn1Parser.ABSENT:
                                opt = Component.Optionality.Absent;
                                break;
                            case asn1Parser.OPTIONAL:
                                opt = Component.Optionality.Optional;
                                break;
                            case asn1Parser.CONSTRAINT:
                                constraint = grChTree;
                                break;
                            default:
                                throw new Exception("Internal Error");
                        }
                    }

                    if (!type.m_children.ContainsKey(id))
                        throw new SemanticErrorException("Error: Line:"+chTree.GetChild(0).Line+" ."+id+" is not a child");
                    
                    SequenceOrSetType.Child childComp = type.m_children[id];

                    if  (opt != Component.Optionality.None && !childComp.m_optional) 
                    {
                        throw new SemanticErrorException("Error");
                    }

                    IConstraint con = null;
                    if (constraint!=null)
                        childComp.m_type.ResolveExternalConstraints(constraint, ref con);
                    components.Add(new Component(id, opt, con));
                }
             
            }
            return new WithComponentsSeqConstraint(type, partialSpecification, components);
        }
    }

    public class WithComponentsChConstraint : WithComponentsConstraint
    {
        public WithComponentsChConstraint(Asn1Type type, bool partialSpecification, List<Component> components)
            : base(type, partialSpecification, components)
        {
        }
        internal static IConstraint Create2(ITree tree, ChoiceType type)
        {
            throw new Exception();
        }
    }

}
