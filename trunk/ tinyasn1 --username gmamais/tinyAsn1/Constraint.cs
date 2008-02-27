using System;
using System.Collections.Generic;
using System.Text;
using Antlr.Runtime.Tree;

namespace tinyAsn1
{
    /* ************ CONSTRAINTS ********************** */

    public partial class ExceptionSpec
    {
        public Asn1Type m_type = null;
        public Asn1Value m_value = null;
        public Module m_module = null;
        static public ExceptionSpec CreateFromAntlrAst(ITree tree)
        {
            if (tree.Type != asn1Parser.EXCEPTION_SPEC)
                throw new Exception("Internal Error");
            ExceptionSpec ret = new ExceptionSpec();
            IntegerType dummyInt;
            switch (tree.GetChild(0).Type)
            {
                case asn1Parser.EXCEPTION_SPEC_CONST_INT:
                case asn1Parser.EXCEPTION_SPEC_VAL_REF:
                    dummyInt = new IntegerType();
                    dummyInt.m_module = Module.CurrentlyConstructModule;
                    dummyInt.antlrNode = tree.GetChild(0);
                    ret.m_type = dummyInt;
                    ret.m_value = Asn1Value.CreateFromAntlrAst(tree.GetChild(0).GetChild(0));
                    
                    break;
                case asn1Parser.EXCEPTION_SPEC_TYPE_VALUE:
                    ret.m_type = Asn1Type.CreateFromAntlrAst(tree.GetChild(0).GetChild(0));
                    ret.m_value = Asn1Value.CreateFromAntlrAst(tree.GetChild(0).GetChild(1));
                    break;
            }
            ret.m_module = Module.CurrentlyConstructModule;
            return ret;
        }

        public bool isResolved()
        {
            return m_type.SemanticAnalysisFinished() && m_value.IsResolved();
        }

        public void DoSemanticAnalysis()
        {
            m_type.DoSemanticAnalysis();
            m_value = m_type.ResolveVariable(m_value);
        }

        public override string ToString()
        {
            string ret ="!";
            if (m_type is IntegerType)
                ret += m_value.ToString();
            else
                ret += m_type.Name + ":" + m_value.ToString();
            
            return ret;
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
        Asn1Type AsnType { get;}
        string ToString(bool includeParenthesis);
        PERIntegerEffectiveConstraint PEREffectiveIntegerRange { get;}
        PERSizeEffectiveConstraint PEREffectiveSizeConstraint { get;}
        PERAlphabetAndSizeEffectiveConstraint PEREffectiveAlphabetAndSizeConstraint { get;}

        string PrintCIsConstraintValid(StreamWriterLevel c, string varName, int lev);
        string PrintCIsRootConstraintValid(StreamWriterLevel c, string varName, int lev);
        void PrintCIsConstraintValidAux(StreamWriterLevel c);
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
        public virtual Asn1Type AsnType { get { return m_type; } }

        public virtual string ToString(bool includeParenthesis) 
        {
            if (includeParenthesis)
                return "(" + ToString() + ")";
            return ToString();
        }




        public virtual PERIntegerEffectiveConstraint PEREffectiveIntegerRange
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }




        public virtual PERSizeEffectiveConstraint PEREffectiveSizeConstraint
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public virtual PERAlphabetAndSizeEffectiveConstraint PEREffectiveAlphabetAndSizeConstraint
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }
        public virtual string PrintCIsConstraintValid(StreamWriterLevel c, string varName, int lev)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        public virtual void PrintCIsConstraintValidAux(StreamWriterLevel c)
        {
        }

        public virtual string PrintCIsRootConstraintValid(StreamWriterLevel c, string varName, int lev)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }

    public class RootConstraint : BaseConstraint
    {
        IConstraint m_constr;
        IConstraint m_extConstr;
        ExceptionSpec m_exceptionSpec;
        bool m_extended = false;

        public RootConstraint(Asn1Type type, IConstraint constr, bool extended, IConstraint extConstr, ExceptionSpec exceptionSpec)
            : base(type)
        {
            m_constr = constr;
            m_extended = extended;
            m_extConstr = extConstr;
            m_exceptionSpec = exceptionSpec;
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
            ExceptionSpec exceptionSpec = null;
            bool extended = false;
            for (int i = 1; i < tree.ChildCount; i++)
            {
                switch (tree.GetChild(i).Type)
                {
                    case asn1Parser.UNION_SET:
                    case asn1Parser.UNION_SET_ALL_EXCEPT:
                        extConstr = BaseConstraint.CreateUnionSet(tree.GetChild(i), type);
                        break;
                    case asn1Parser.EXT_MARK:
                        extended = true;
                        break;
                    case asn1Parser.EXCEPTION_SPEC:
                        exceptionSpec = ExceptionSpec.CreateFromAntlrAst(tree.GetChild(i));
                        break;
                    default:
                        throw new Exception("Internal Error");
                }
            }

            return new RootConstraint(type, constr, extended, extConstr, exceptionSpec);

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
            if (m_exceptionSpec != null && !m_exceptionSpec.isResolved())
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
            if (m_exceptionSpec != null && !m_exceptionSpec.isResolved())
                m_exceptionSpec.DoSemanticAnalysis();
        }
        public override IConstraint Simplify()
        {
            if (!m_extended && m_extConstr == null && m_exceptionSpec == null)
                return m_constr.Simplify();
            m_constr.Simplify();
            if (m_extConstr!=null)
                m_extConstr.Simplify();
            return this;
        }
        public override string ToString()
        {
            string ret = "";
            ret = m_constr.ToString();
            if (m_extended)
                ret += ",...";
            if (m_extConstr != null)
                ret += "," + m_extConstr.ToString();
            if (m_exceptionSpec != null)
                ret += m_exceptionSpec.ToString();
            return ret;
        }

        public override PERIntegerEffectiveConstraint PEREffectiveIntegerRange
        {
            get {
                PERIntegerEffectiveConstraint ret = new PERIntegerEffectiveConstraint();

                ret.m_rootRange = m_constr.PEREffectiveIntegerRange.m_rootRange;
                ret.m_isExtended = m_extended;
                if (m_extConstr != null)
                    ret.m_extRange = m_extConstr.PEREffectiveIntegerRange.m_rootRange;
                return ret;
            }
        }

        public override PERSizeEffectiveConstraint PEREffectiveSizeConstraint
        {
            get {
                PERSizeEffectiveConstraint ret = m_constr.PEREffectiveSizeConstraint;
                ret.Extensible = m_extended;
                return ret;
            }
        }

        public override PERAlphabetAndSizeEffectiveConstraint PEREffectiveAlphabetAndSizeConstraint
        {
            get {
                PERAlphabetAndSizeEffectiveConstraint ret = m_constr.PEREffectiveAlphabetAndSizeConstraint;
                ret.Extensible = m_extended;
                return ret;
            }
        }
        public override string PrintCIsConstraintValid(StreamWriterLevel c, string varName, int lev)
        {
            if (m_extConstr == null)
                return m_constr.PrintCIsConstraintValid(c, varName, lev);
            return "(" + m_constr.PrintCIsConstraintValid(c, varName, lev) + "||" + m_extConstr.PrintCIsConstraintValid(c, varName, lev) + ")";
        }
        public override string PrintCIsRootConstraintValid(StreamWriterLevel c, string varName, int lev)
        {
            return m_constr.PrintCIsConstraintValid(c, varName, lev);
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
            string ret ="";
            int cnt = m_items.Count;
            if (cnt>1)
                ret = "(";
            for (int i = 0; i < cnt - 1; i++)
            {
                ret += m_items[i].ToString() + "|";
            }

            ret += m_items[cnt-1].ToString();
            
            if (cnt > 1)
                ret += ")";
            
            return ret;
        }

        public override PERIntegerEffectiveConstraint PEREffectiveIntegerRange
        {
            get
            {
                PERIntegerEffectiveConstraint ret = new PERIntegerEffectiveConstraint();
                ret.m_rootRange = new IntegerRange();
                

                foreach (IConstraint con in m_items)
                    ret = PERIntegerEffectiveConstraint.Union(ret, con.PEREffectiveIntegerRange);

                return ret;
            }
        }

        public override PERSizeEffectiveConstraint PEREffectiveSizeConstraint
        {
            get
            {
                PERSizeEffectiveConstraint ret = PERSizeEffectiveConstraint.Empty;

                foreach (IConstraint con in m_items)
                {
                    PERSizeEffectiveConstraint c = con.PEREffectiveSizeConstraint;
                    if (c == null) //if there is just one non size constraint --> return non per visible constraint
                        return null;
                    ret = PERSizeEffectiveConstraint.Union(ret, c);
                }
                    
                return ret;
            }
        }
        public override PERAlphabetAndSizeEffectiveConstraint PEREffectiveAlphabetAndSizeConstraint
        {
            get
            {
                PERAlphabetAndSizeEffectiveConstraint ret = PERAlphabetAndSizeEffectiveConstraint.Empty;
                foreach (IConstraint con in m_items)
                {
                    PERAlphabetAndSizeEffectiveConstraint c = con.PEREffectiveAlphabetAndSizeConstraint;
                    if (c == null) //if there is just one non size constraint --> return non per visible constraint
                        return null;
                    ret = PERAlphabetAndSizeEffectiveConstraint.Union(ret, c);
                }
                return ret;
            }
        }
        public override string PrintCIsConstraintValid(StreamWriterLevel c, string varName, int lev)
        {
            string ret;
            if (m_items.Count == 1)
                return m_items[0].PrintCIsConstraintValid(c, varName, lev);
            ret = "(";
            for (int i = 0; i < m_items.Count; i++)
            {
                ret += m_items[i].PrintCIsConstraintValid(c, varName, lev);
                if (i != m_items.Count - 1)
                    ret += " || ";
            }
            ret += ")";
            return ret;
        }
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
            string ret = "";
            int cnt = m_items.Count;
            if (cnt>1)
                ret += "(";
            for (int i = 0; i < cnt - 1; i++)
            {
                ret += m_items[i].ToString() + "^";
            }

            ret += m_items[cnt - 1].ToString();

            if (cnt > 1)
                ret += ")";
            return ret;
        }

        public override PERIntegerEffectiveConstraint PEREffectiveIntegerRange
        {
            get
            {
                PERIntegerEffectiveConstraint ret = PERIntegerEffectiveConstraint.UncostraintInteger;

                foreach (IConstraint con in m_items)
                    ret = PERIntegerEffectiveConstraint.Intersection(ret, con.PEREffectiveIntegerRange);

                return ret;
            }
        }
        public override PERSizeEffectiveConstraint PEREffectiveSizeConstraint
        {
            get
            {
                PERSizeEffectiveConstraint ret = PERSizeEffectiveConstraint.Full;

                foreach (IConstraint con in m_items)
                {
                    PERSizeEffectiveConstraint c = con.PEREffectiveSizeConstraint;
                    if (c == null) //if there is one non size constraint ignore it
                        continue;
                    ret = PERSizeEffectiveConstraint.Intersection(ret, c);
                }

                return ret;
            }
        }

        public override PERAlphabetAndSizeEffectiveConstraint PEREffectiveAlphabetAndSizeConstraint
        {
            get
            {
                PERAlphabetAndSizeEffectiveConstraint ret = PERAlphabetAndSizeEffectiveConstraint.Full(m_type);
                foreach (IConstraint con in m_items)
                {
                    PERAlphabetAndSizeEffectiveConstraint c = con.PEREffectiveAlphabetAndSizeConstraint;
                    if (c == null) //if there is one non size constraint ignore it
                        continue;
                    ret = PERAlphabetAndSizeEffectiveConstraint.Intersection(ret, c);
                }
                return ret;
            }
        }
        public override string PrintCIsConstraintValid(StreamWriterLevel c, string varName, int lev)
        {
            string ret;
            if (m_items.Count == 1)
                return m_items[0].PrintCIsConstraintValid(c, varName, lev);
            ret = "(";
            for (int i = 0; i < m_items.Count; i++)
            {
                ret += m_items[i].PrintCIsConstraintValid(c, varName, lev);
                if (i != m_items.Count - 1)
                    ret += " && ";
            }
            ret += ")";
            return ret;
        }
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
            return m_c1.ToString() + " EXCEPT " + m_c2.ToString(true);
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

        public override PERIntegerEffectiveConstraint PEREffectiveIntegerRange
        {
            get
            {
                return m_c1.PEREffectiveIntegerRange;
            }
        }

        public override PERSizeEffectiveConstraint PEREffectiveSizeConstraint
        {
            get
            {
                return m_c1.PEREffectiveSizeConstraint;
            }
        }

        public override PERAlphabetAndSizeEffectiveConstraint PEREffectiveAlphabetAndSizeConstraint
        {
            get
            {
                return m_c1.PEREffectiveAlphabetAndSizeConstraint;
            }
        }

        public override string PrintCIsConstraintValid(StreamWriterLevel c, string varName, int lev)
        {
            return "(" + m_c1.PrintCIsConstraintValid(c, varName, lev) + " && !" + m_c2.PrintCIsConstraintValid(c, varName, lev) + ")";
        }
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
            return "ALL EXCEPT " + m_c.ToString(true);
        }
        public override PERIntegerEffectiveConstraint PEREffectiveIntegerRange
        {
            get
            {
                return PERIntegerEffectiveConstraint.UncostraintInteger;
            }
        }
        public override PERSizeEffectiveConstraint PEREffectiveSizeConstraint
        {
            get
            {
                return PERSizeEffectiveConstraint.Full;
            }
        }
        public override PERAlphabetAndSizeEffectiveConstraint PEREffectiveAlphabetAndSizeConstraint
        {
            get
            {
                return PERAlphabetAndSizeEffectiveConstraint.Full(m_type);
            }
        }
        public override string PrintCIsConstraintValid(StreamWriterLevel c, string varName, int lev)
        {
            return "!" + m_c.PrintCIsConstraintValid(c, varName, lev);
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
            if ((type.GetFinalType() is IA5StringType) && (((IA5StringType)type.GetFinalType()).IamUsedInPermittedAlphabet))
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


        public override string ToString()
        {
            return m_val.ToString();
        }

        public override PERIntegerEffectiveConstraint PEREffectiveIntegerRange
        {
            get
            {
                PERIntegerEffectiveConstraint ret = new PERIntegerEffectiveConstraint();
                ret.m_rootRange = new IntegerRange();
                ret.m_rootRange.m_max = ((IntegerValue)m_val).Value;
                ret.m_rootRange.m_min = ((IntegerValue)m_val).Value;
                ret.m_rootRange.m_maxIsIncluded = true;
                ret.m_rootRange.m_maxIsInfinite = false;
                ret.m_rootRange.m_minIsIncluded = true;
                ret.m_rootRange.m_minIsInfinite = false;
                return ret;
            }
        }
        public override PERSizeEffectiveConstraint PEREffectiveSizeConstraint
        {
            get
            {
                return null;
            }
        }
        public override PERAlphabetAndSizeEffectiveConstraint PEREffectiveAlphabetAndSizeConstraint
        {
            get
            {
                return null;
            }
        }

        public override string PrintCIsConstraintValid(StreamWriterLevel c, string varName, int lev)
        {
            return "(" + varName + " == " + m_val.ToStringC() + ")";
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

        public override string PrintCIsConstraintValid(StreamWriterLevel c, string varName, int lev)
        {
            ICharacterString set = m_val as ICharacterString;
            if (set == null)
                throw new Exception("Internal Error");

            return "strchr(\"" + set.Value + "\", " + varName + ")";
        }
        public override PERIntegerEffectiveConstraint PEREffectiveIntegerRange
        {
            get
            {
                throw new Exception("Internal Error");
            }
        }
        public override PERAlphabetAndSizeEffectiveConstraint PEREffectiveAlphabetAndSizeConstraint
        {
            get
            {
                ICharacterString set = m_val as ICharacterString;
                if (set == null)
                    throw new Exception("Internal Error");
                return new PERAlphabetAndSizeEffectiveConstraint(new List<Char>(set.Value.ToCharArray()));
            }
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

            if ((type.GetFinalType() is IA5StringType) && (((IA5StringType)type.GetFinalType()).IamUsedInPermittedAlphabet))
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


        public override PERIntegerEffectiveConstraint PEREffectiveIntegerRange
        {
            get
            {
                PERIntegerEffectiveConstraint ret = new PERIntegerEffectiveConstraint();
                ret.m_rootRange = new IntegerRange();
                if (m_min == null)
                    ret.m_rootRange.m_minIsInfinite = true;
                else
                {
                    ret.m_rootRange.m_min = ((IntegerValue)m_min).Value;
                    ret.m_rootRange.m_minIsIncluded = m_minValIsInluded;
                }

                if (m_max == null)
                    ret.m_rootRange.m_maxIsInfinite = true;
                else
                {
                    ret.m_rootRange.m_max = ((IntegerValue)m_max).Value;
                    ret.m_rootRange.m_maxIsIncluded = m_maxValIsInluded;
                }

                return ret;
            }
        }
        public override PERSizeEffectiveConstraint PEREffectiveSizeConstraint
        {
            get
            {
                return null;
            }
        }
        public override PERAlphabetAndSizeEffectiveConstraint PEREffectiveAlphabetAndSizeConstraint
        {
            get
            {
                return null;
            }
        }

        public override string ToString()
        {
            string ret = "";
            if (m_min == null)
                ret = "MIN";
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
        public override string PrintCIsConstraintValid(StreamWriterLevel c, string varName, int lev)
        {
            string ret="";
            if (m_max!=null && m_min!=null)
                ret = "(";
            if (m_min != null)
            {
                ret += "(" + varName +">";
                if (m_minValIsInluded)
                    ret += "=";
                ret += m_min.ToString() + ")";

            }
            if (m_max != null && m_min != null)
                ret += " && ";

            if (m_max != null)
            {
                ret += "(" + varName + "<";
                if (m_maxValIsInluded)
                    ret += "=";
                ret += m_max.ToString() + ")";
            }


            if (m_max != null && m_min != null)
                ret += ")";
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

        public override string PrintCIsConstraintValid(StreamWriterLevel c, string varName, int lev)
        {
            if (m_min != null && Lo.Value.Length != 1)
                return ""; // ignore constraint
            if (m_max != null && Hi.Value.Length != 1)
                return ""; // ignore constraint
            if (m_min == null && m_max == null)  //(MIN..MAX)
                return "";
            string ret = "";
            if (m_max != null && m_min != null)
                ret = "(";

            if (m_min != null)
            {
                ret += "(" + varName +">";
                if (m_minValIsInluded)
                    ret += "=";
                ret += "'" + m_min.ToString().Replace("\"","") + "')";

            }
            if (m_max != null && m_min != null)
                ret += " && ";

            if (m_max != null)
            {
                ret += "(" + varName + "<";
                if (m_maxValIsInluded)
                    ret += "=";
                ret += "'" + m_max.ToString().Replace("\"", "") + "')";
            }


            if (m_max != null && m_min != null)
                ret += ")";
            return ret;

        
        }

        public override PERIntegerEffectiveConstraint PEREffectiveIntegerRange
        {
            get
            {
                throw new Exception("Internal Error");
            }
        }

        public override PERAlphabetAndSizeEffectiveConstraint PEREffectiveAlphabetAndSizeConstraint
        {
            get
            {
                Char? min = null;
                if (m_min != null)
                    min = Lo.Value[0];
                Char? max = null;
                if (m_max != null)
                    max = Hi.Value[0];
                return new PERAlphabetAndSizeEffectiveConstraint(min,max, m_type as IStringType);
            }
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

        public override PERIntegerEffectiveConstraint PEREffectiveIntegerRange
        {
            get
            {
                throw new Exception("Internal Error");
            }
        }
        public override PERSizeEffectiveConstraint PEREffectiveSizeConstraint
        {
            get
            {
                return new PERSizeEffectiveConstraint(sizeCon.PEREffectiveConstraint as PERIntegerEffectiveConstraint);
            }
        }
        public override PERAlphabetAndSizeEffectiveConstraint PEREffectiveAlphabetAndSizeConstraint
        {
            get
            {
                return new PERAlphabetAndSizeEffectiveConstraint(sizeCon.PEREffectiveConstraint as PERIntegerEffectiveConstraint);
            }
        }

        public override string PrintCIsConstraintValid(StreamWriterLevel c, string varName, int lev)
        {
            string varName2="";
            if (m_type.GetFinalType() is IA5StringType)
                varName2 = "strlen(" + varName.Replace("*", "") + ")";
            else
            {
                if (varName.Contains("->"))
                    varName2 = varName + ".nCount";
                else
                    varName2 = varName.Replace("*","") + "->nCount";
                
            }

            string ret = "";
            for (int i = 0; i < sizeCon.m_constraints.Count; i++)
            {
                ret += sizeCon.m_constraints[i].PrintCIsConstraintValid(c, varName2, lev);
                if (i != sizeCon.m_constraints.Count-1)
                    ret += " && ";
            }
            return ret;
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

            IA5StringType ia = type.GetFinalType() as IA5StringType;
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
        public override PERIntegerEffectiveConstraint PEREffectiveIntegerRange
        {
            get
            {
                throw new Exception("Internal Error");
            }
        }

        public override PERSizeEffectiveConstraint PEREffectiveSizeConstraint
        {
            get
            {
                throw new Exception("Internal Error");
            }
        }


        public override PERAlphabetAndSizeEffectiveConstraint PEREffectiveAlphabetAndSizeConstraint
        {
            get
            {
                PERAlphabetAndSizeEffectiveConstraint ret = new PERAlphabetAndSizeEffectiveConstraint();
                ret = (PERAlphabetAndSizeEffectiveConstraint)ret.Compute(allowed_char_set.m_constraints, allowed_char_set);
                return ret;
            }
        }

        static int nCount=0;
        int AuxFunctionID;
        public override void PrintCIsConstraintValidAux(StreamWriterLevel c)
        {
            nCount++;
            AuxFunctionID = nCount;

            c.WriteLine("flag CheckString{0}(const char* str)", AuxFunctionID);
            c.WriteLine("{");
            c.P(1); c.WriteLine("size_t i;");
            c.P(1); c.WriteLine("size_t n = strlen(str);");
            c.P(1);
            c.WriteLine("for(i=0;i<n;i++)");
            c.P(1); c.WriteLine("{");

            c.P(2);
            c.Write("if (!");
            for (int i = 0; i < allowed_char_set.m_constraints.Count; i++)
            {
                c.Write(allowed_char_set.m_constraints[i].PrintCIsConstraintValid(c, "str[i]", 0));
                if (i != allowed_char_set.m_constraints.Count - 1)
                    c.Write(" && ");
            }
            c.WriteLine(")");
            c.P(3);
            c.WriteLine("return FALSE;");
            c.P(1); c.WriteLine("}");

            c.P(1); c.WriteLine("return TRUE;");
            c.WriteLine("}");
        }

        public override string PrintCIsConstraintValid(StreamWriterLevel c, string varName, int lev)
        {
            return "CheckString" + AuxFunctionID.ToString()+"("+varName.Replace("*","")+")";
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
                if (!type.Compatible(oth))
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

        public override PERIntegerEffectiveConstraint PEREffectiveIntegerRange
        {
            get
            {
                return (PERIntegerEffectiveConstraint)m_otherType.PEREffectiveConstraint;
            }
        }
        public override PERSizeEffectiveConstraint PEREffectiveSizeConstraint
        {
            get
            {
                return m_otherType.PEREffectiveConstraint as PERSizeEffectiveConstraint;
            }
        }
        public override PERAlphabetAndSizeEffectiveConstraint PEREffectiveAlphabetAndSizeConstraint
        {
            get
            {
                return m_otherType.PEREffectiveConstraint as PERAlphabetAndSizeEffectiveConstraint;
            }
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
            foreach (Asn1Value v in arval.Value)
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
        public override PERIntegerEffectiveConstraint PEREffectiveIntegerRange
        {
            get
            {
                throw new Exception("Internal Error");
            }
        }
        public override PERSizeEffectiveConstraint PEREffectiveSizeConstraint
        {
            get
            {
                return null;
            }
        }
        public override PERAlphabetAndSizeEffectiveConstraint PEREffectiveAlphabetAndSizeConstraint
        {
            get
            {
                return null;
            }
        }
    }

    public class WithComponentsConstraint : BaseConstraint
    {
        public class Component
        {
            public enum PresenseConstraint {
                PRESENT,
                ABSENT,
                OPTIONAL,
                None
            }
            public string m_name;
            public PresenseConstraint m_presenceConstraint = PresenseConstraint.None;
            public IConstraint m_valueConstraint = null;
            public Component(string name, PresenseConstraint presCon, IConstraint valCon)
            {
                m_name = name;
                m_presenceConstraint = presCon;
                m_valueConstraint = valCon;
            }

            public override string ToString()
            {
                string ret = m_name;
                if (m_valueConstraint != null)
                    ret += " ("+ m_valueConstraint.ToString()+")";
                if (m_presenceConstraint != PresenseConstraint.None)
                    ret += " " + m_presenceConstraint.ToString();
                return ret;
            }
        }

        protected bool m_partialSpecification = false; //i.e. ... are not present
        protected OrderedDictionary<string, Component> m_components = new OrderedDictionary<string, Component>();

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
            if (type.GetFinalType() is RealType)
                return WithComponentsRealConstraint.Create2(tree, (RealType)type.GetFinalType());
            

            throw new Exception("Internal Error");
        }

        public WithComponentsConstraint(Asn1Type type, bool partialSpecification, OrderedDictionary<string, Component> components)
            : base(type)
        {
            m_partialSpecification = partialSpecification;
            m_components = components;
        }

        public override IConstraint Simplify()
        {
            return this;
        }
        public override string ToString()
        {
            string ret = "WITH COMPONENTS {";
            if (m_partialSpecification)
                ret += "..., ";
            int cnt = m_components.Count;
            for (int i = 0; i < cnt - 1; i++)
                ret += m_components.Values[i].ToString() + ", ";

            ret += m_components.Values[cnt-1].ToString() + "}";
            return ret;
        }
        
        public override bool IsResolved()
        {
            foreach (Component c in m_components.Values)
                if (c.m_valueConstraint != null)
                    if (!c.m_valueConstraint.IsResolved())
                        return false;
            return true;
        }
        public override PERIntegerEffectiveConstraint PEREffectiveIntegerRange
        {
            get
            {
                throw new Exception("Internal Error");
            }
        }
        public override PERSizeEffectiveConstraint PEREffectiveSizeConstraint
        {
            get
            {
                return null;
            }
        }
        public override PERAlphabetAndSizeEffectiveConstraint PEREffectiveAlphabetAndSizeConstraint
        {
            get
            {
                return null;
            }
        }
    }

    public class WithComponentsSeqConstraint : WithComponentsConstraint
    {
        public WithComponentsSeqConstraint(Asn1Type type, bool partialSpecification, OrderedDictionary<string, Component> components)
            : base(type, partialSpecification, components)
        {
        }
        SequenceOrSetType  Type
        {
            get { return (SequenceOrSetType)m_type; }
        }
        internal static IConstraint Create2(ITree tree, SequenceOrSetType type)
        {
            OrderedDictionary<string, Component> components = new OrderedDictionary<string, Component>();
            bool partialSpecification = false;

            for (int i = 0; i < tree.ChildCount; i++)
            {
                ITree chTree = tree.GetChild(i);
                if (chTree.Type == asn1Parser.EXT_MARK)
                    partialSpecification = true;
                else if (chTree.Type == asn1Parser.NAME_CONSTRAINT_EXPR)
                {
                    string id = null;
                    Component.PresenseConstraint presenceConstr = Component.PresenseConstraint.None;
                    //if (!partialSpecification)
                    //    presenceConstr = Component.PresenseConstraint.Present;    //default setting if no optionality modifier is present
                    ITree constraint = null;
                    for (int j = 0; j < chTree.ChildCount; j++)
                    {
                        ITree grChTree = chTree.GetChild(j);
                        switch (grChTree.Type)
                        {
                            case asn1Parser.LID:
                            case asn1Parser.MANTISSA:
                            case asn1Parser.BASE:
                            case asn1Parser.EXPONENT:
                                id = grChTree.Text;
                                break;
                            case asn1Parser.PRESENT:
                                presenceConstr = Component.PresenseConstraint.PRESENT;
                                break;
                            case asn1Parser.ABSENT:
                                presenceConstr = Component.PresenseConstraint.ABSENT;
                                break;
                            case asn1Parser.OPTIONAL:
                                presenceConstr = Component.PresenseConstraint.OPTIONAL;
                                break;
                            case asn1Parser.CONSTRAINT:
                                constraint = grChTree;
                                break;
                            default:
                                throw new Exception("Internal Error");
                        }
                    }

                    // check that id is a child of the sequence or set
                    if (!type.m_children.ContainsKey(id))
                        throw new SemanticErrorException("Error: Line:"+chTree.GetChild(0).Line+". "+id+" is not a child");

                    //check that does not appears twice in the WITH COMPONENTS constraint
                    if (components.ContainsKey(id))
                        throw new SemanticErrorException("Error Line: "+chTree.GetChild(0).Line + ". name constraint' "+id+"' appears twice" );

                    SequenceOrSetType.Child childComp = type.m_children[id];

                    //Presence constraint appears on a non optional child --> error 47.8.9.1
                    if (!childComp.m_optional && presenceConstr!= Component.PresenseConstraint.None)
                    {
                        throw new SemanticErrorException("Error Line:" + chTree.GetChild(0).Line + ". Presence constraint '"+presenceConstr.ToString()+"' specified for component '" + id + "' which is not optional");
                    }

                    if (!partialSpecification)
                    {
                        if (presenceConstr == Component.PresenseConstraint.None)
                            presenceConstr = Component.PresenseConstraint.PRESENT;
                    }
                    
                    IConstraint con = null;
                    if (constraint!=null)
                        childComp.m_type.ResolveExternalConstraints(constraint, ref con);
                    if (con != null && con.IsResolved())
                        con = con.Simplify();
                    components.Add(id, new Component(id, presenceConstr, con));
                }
             
            }
            if (!partialSpecification) {
                foreach (SequenceOrSetType.Child cc in type.m_children.Values)
                {
                    //full specification, constraint component name does not appear (hence it ABSENT 47.8.6)
                    if (!components.ContainsKey(cc.m_childVarName))
                    {
                        //if component is not optional
                        if (cc.m_optional)
                            components.Add(cc.m_childVarName, new Component(cc.m_childVarName, Component.PresenseConstraint.ABSENT, null));
                        else
                            throw new SemanticErrorException("Error line" + tree.Line+" Component '"+cc.m_childVarName+
                                "' is not listed.\nEither make the WITH COMPONENTS constraint partial by using ... or add"+
                                " the '"+cc.m_childVarName+"' to the list");
                    }
                }
            }
            return new WithComponentsSeqConstraint(type, partialSpecification, components);
        }

        public override void DoSemanticAnalysis()
        {
            if (IsResolved())
                return;

            foreach (Component c in m_components.Values)
            {
                if (c.m_valueConstraint != null)
                {
                    if (!c.m_valueConstraint.IsResolved())
                    {
                        SequenceOrSetType.Child childComp = Type.m_children[c.m_name];
                        childComp.m_type.ResolveExternalConstraints(null, ref c.m_valueConstraint);
                        if (c.m_valueConstraint.IsResolved())
                            c.m_valueConstraint = c.m_valueConstraint.Simplify();
                    }
                }
            }
        }

        public override bool isValueAllowed(Asn1Value val)
        {

            SequenceOrSetValue sqval = val as SequenceOrSetValue;
            if (sqval == null)
                throw new Exception("Internal Error");
            
            // Check presence constraint
            foreach (Component c in m_components.Values)
            {
                if (c.m_presenceConstraint == Component.PresenseConstraint.PRESENT && !sqval.m_children.ContainsKey(c.m_name))
                        return false;
                if (c.m_presenceConstraint == Component.PresenseConstraint.ABSENT && sqval.m_children.ContainsKey(c.m_name))
                        return false;
            }
                

            //check value constraint
            foreach (string id in sqval.m_children.Keys)
            {
                Asn1Value v = sqval.m_children[id];
                if (m_components.ContainsKey(id))
                {
                    Component c = m_components[id];
                    if (c.m_valueConstraint!=null && !c.m_valueConstraint.isValueAllowed(v))
                        return false;
                }
            }
            return true;
        }
    }

    public class WithComponentsChConstraint : WithComponentsConstraint
    {
        ChoiceType Type
        {
            get { return (ChoiceType)m_type; }
        }
        public WithComponentsChConstraint(Asn1Type type, bool partialSpecification, OrderedDictionary<string, Component> components)
            : base(type, partialSpecification, components)
        {
        }
        internal static IConstraint Create2(ITree tree, ChoiceType type)
        {
            OrderedDictionary<string, Component> components = new OrderedDictionary<string, Component>();
            bool partialSpecification = false;

            for (int i = 0; i < tree.ChildCount; i++)
            {
                ITree chTree = tree.GetChild(i);
                if (chTree.Type == asn1Parser.EXT_MARK)
                    partialSpecification = true;
                else if (chTree.Type == asn1Parser.NAME_CONSTRAINT_EXPR)
                {
                    string id = null;
                    Component.PresenseConstraint presenceConstr = Component.PresenseConstraint.None;
                    //if (!partialSpecification)
                    //    presenceConstr = Component.PresenseConstraint.Present;    //default setting if no optionality modifier is present
                    ITree constraint = null;
                    for (int j = 0; j < chTree.ChildCount; j++)
                    {
                        ITree grChTree = chTree.GetChild(j);
                        switch (grChTree.Type)
                        {
                            case asn1Parser.LID:
                            case asn1Parser.MANTISSA:
                            case asn1Parser.BASE:
                            case asn1Parser.EXPONENT:
                                id = grChTree.Text;
                                break;
                            case asn1Parser.PRESENT:
                                presenceConstr = Component.PresenseConstraint.PRESENT;
                                break;
                            case asn1Parser.ABSENT:
                                presenceConstr = Component.PresenseConstraint.ABSENT;
                                break;
                            case asn1Parser.OPTIONAL:
                                throw new SemanticErrorException("Error Line:" + grChTree.Line + " OPTIONAL can not appear in CHOICE types");
                            case asn1Parser.CONSTRAINT:
                                constraint = grChTree;
                                break;
                            default:
                                throw new Exception("Internal Error");
                        }
                    }

                    // check that id is a child of the choice
                    if (!type.m_children.ContainsKey(id))
                        throw new SemanticErrorException("Error: Line:" + chTree.GetChild(0).Line + ". " + id + " is not a child");

                    //check that does not appears twice in the WITH COMPONENTS constraint
                    if (components.ContainsKey(id))
                        throw new SemanticErrorException("Error Line: " + chTree.GetChild(0).Line + ". name constraint' " + id + "' appears twice");

                    if (presenceConstr == Component.PresenseConstraint.PRESENT)
                    {
                        // make sure that no other past component is declared as PRESENT
                        foreach (Component c in components.Values)
                            if (c.m_presenceConstraint == Component.PresenseConstraint.PRESENT)
                                throw new SemanticErrorException("Error line:" + chTree.GetChild(0).Line + " there can be only one PRESENT constraint");
                    }

                    ChoiceChild childComp = type.m_children[id];

                    IConstraint con = null;
                    if (constraint != null)
                        childComp.m_type.ResolveExternalConstraints(constraint, ref con);
                    if (con != null && con.IsResolved())
                        con = con.Simplify();
                    components.Add(id, new Component(id, presenceConstr, con));
                }
            }

            if (!partialSpecification)
            {
                foreach (ChoiceChild cc in type.m_children.Values)
                {
                    //full specification, constraint component name does not appear (hence it ABSENT 47.8.6)
                    if (!components.ContainsKey(cc.m_childVarName))
                    {
                        components.Add(cc.m_childVarName, new Component(cc.m_childVarName, Component.PresenseConstraint.ABSENT, null));
                    }
                }
            }
            return new WithComponentsChConstraint(type, partialSpecification, components);
        }

        public override void DoSemanticAnalysis()
        {
            if (IsResolved())
                return;

            foreach (Component c in m_components.Values)
            {
                if (c.m_valueConstraint != null)
                {
                    if (!c.m_valueConstraint.IsResolved())
                    {
                        ChoiceChild childComp = Type.m_children[c.m_name];
                        childComp.m_type.ResolveExternalConstraints(null, ref c.m_valueConstraint);
                        if (c.m_valueConstraint.IsResolved())
                            c.m_valueConstraint = c.m_valueConstraint.Simplify();
                    }
                }
            }
        }

        public override bool isValueAllowed(Asn1Value val)
        {

            ChoiceValue sqval = val as ChoiceValue;
            if (sqval == null)
                throw new Exception("Internal Error");

            // Check presence constraint

            if (m_components.ContainsKey(sqval.AlternativeName))
            {
                Component c = m_components[sqval.AlternativeName];

                if (c.m_presenceConstraint == Component.PresenseConstraint.ABSENT)
                    return false;
                if (!c.m_valueConstraint.isValueAllowed(sqval.Value))
                    return false;
            }
            else
            {
                //check if there is another component marked as PRESENT
                Component presentComponent = m_components.Values.Find(delegate(Component c)
                {
                    return c.m_presenceConstraint == Component.PresenseConstraint.PRESENT;
                });
                if (presentComponent != null && presentComponent.m_name != sqval.AlternativeName)
                    return false;
            }

            return true;
        }
    }
    
    public class WithComponentsRealConstraint : WithComponentsConstraint
    {
        static List<string> realComponents = new List<string>(new string[] { "mantissa", "base", "exponent" });
        RealType Type
        {
            get { return (RealType)m_type; }
        }
        public WithComponentsRealConstraint(Asn1Type type, bool partialSpecification, OrderedDictionary<string, Component> components)
            : base(type, partialSpecification, components)
        {
        }
        internal static IConstraint Create2(ITree tree, RealType type)
        {
            OrderedDictionary<string, Component> components = new OrderedDictionary<string, Component>();
            bool partialSpecification = false;
            for (int i = 0; i < tree.ChildCount; i++)
            {
                ITree chTree = tree.GetChild(i);
                if (chTree.Type == asn1Parser.EXT_MARK)
                    partialSpecification = true;
                else if (chTree.Type == asn1Parser.NAME_CONSTRAINT_EXPR)
                {
                    string id = null;
                    ITree constraint = null;
                    for (int j = 0; j < chTree.ChildCount; j++)
                    {
                        ITree grChTree = chTree.GetChild(j);
                        switch (grChTree.Type)
                        {
                            case asn1Parser.LID:
                            case asn1Parser.MANTISSA:
                            case asn1Parser.BASE:
                            case asn1Parser.EXPONENT:
                                id = grChTree.Text;
                                if (!realComponents.Contains(id))
                                    throw new SemanticErrorException("Error: Line:" + grChTree.Line + ". " + id + " is unknown.");
                                break;
                            case asn1Parser.PRESENT:
                            case asn1Parser.ABSENT:
                            case asn1Parser.OPTIONAL:
                                throw new SemanticErrorException("Error Line:" + grChTree.Line+ " "+ grChTree.Text+" can not appear in a REAL types");
                            case asn1Parser.CONSTRAINT:
                                constraint = grChTree;
                                break;
                            default:
                                throw new Exception("Internal Error");
                        }
                    }


                    //check that does not appears twice in the WITH COMPONENTS constraint
                    if (components.ContainsKey(id))
                        throw new SemanticErrorException("Error Line: " + chTree.GetChild(0).Line + ". '" + id + "' appears twice");


                    IConstraint con = null;
                    if (constraint != null)
                    {
                        IntegerType dummyIntType = new IntegerType();
                        dummyIntType.antlrNode = tree;
                        dummyIntType.m_module = type.m_module;
                        dummyIntType.ResolveExternalConstraints(constraint, ref con);
                    }
                    if (con != null && con.IsResolved())
                        con = con.Simplify();
                    components.Add(id, new Component(id, Component.PresenseConstraint.None, con));
                }
            }

            if (!partialSpecification && components.Values.Count!=3)
            {
                throw new SemanticErrorException("Error Line:" + tree.Line + ".\n"+
                    "You must either use partial specification (i.e. use ...) or specify mantissa and base and exponent");
            }
            return new WithComponentsChConstraint(type, partialSpecification, components);
        }
        
        public override void DoSemanticAnalysis()
        {
            if (IsResolved())
                return;

            foreach (Component c in m_components.Values)
            {
                if (c.m_valueConstraint != null)
                {
                    if (!c.m_valueConstraint.IsResolved())
                    {
                        c.m_valueConstraint.AsnType.ResolveExternalConstraints(null, ref c.m_valueConstraint);
                        if (c.m_valueConstraint.IsResolved())
                            c.m_valueConstraint = c.m_valueConstraint.Simplify();
                    }
                }
            }
        }

        public override bool isValueAllowed(Asn1Value val)
        {

            RealValue sqval = val as RealValue;
            if (sqval == null)
                throw new Exception("Internal Error");

            // algorith to proceed:
            // get base (if both 2 and 10 are present try first with 10 and then with 2)
            // get minimum exponent
            // get maximum mantissa
            // Check if the components of the SqReal satisfy the constraints

/*
            RealValue.SqReal b2 = RealValue.SqReal.FromDouble2(sqval.Value);

            foreach (Component c in m_components.Values)
            {
                if (c.m_name == "mantissa")
                {
                    if (!c.m_valueConstraint.isValueAllowed(new IntegerValue(b2.m_mantissa, null, null, null)))
                        goto tryWithBase10;
                }
                else if (c.m_name == "base")
                {
                    if (!c.m_valueConstraint.isValueAllowed(new IntegerValue(2, null, null, null)))
                        goto tryWithBase10;
                }
                else if (c.m_name == "exponent")
                {
                    if (!c.m_valueConstraint.isValueAllowed(new IntegerValue(b2.m_exponent, null, null, null)))
                        goto tryWithBase10;
                }

            }
            return true;

tryWithBase10:
            RealValue.SqReal b10 = RealValue.SqReal.FromDouble2(sqval.Value);

            foreach (Component c in m_components.Values)
            {
                if (c.m_name == "mantissa")
                {
                    if (!c.m_valueConstraint.isValueAllowed(new IntegerValue(b10.m_mantissa, null, null, null)))
                        return false;
                }
                else if (c.m_name == "base")
                {
                    if (!c.m_valueConstraint.isValueAllowed(new IntegerValue(10, null, null, null)))
                        return false;
                }
                else if (c.m_name == "exponent")
                {
                    if (!c.m_valueConstraint.isValueAllowed(new IntegerValue(b10.m_exponent, null, null, null)))
                        return false;
                }
            }
            */

            return true;
        }
    }

}
