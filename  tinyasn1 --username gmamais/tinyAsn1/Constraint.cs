/**=============================================================================
Definitions of all classes related to ASN.1 constraints
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
using semantix.util;

namespace tinyAsn1
{


    // Constraint's interface
    public interface IConstraint
    {
        bool isValueAllowed(Asn1Value val);
        bool isPERVisible();
        IConstraint Simplify();
        bool IsResolved();
        void DoSemanticAnalysis();
        Asn1Type AsnType { get;}
        string ToString(bool includeParenthesis);
        PERIntegerEffectiveConstraint PEREffectiveIntegerRange { get;}
        PERSizeEffectiveConstraint PEREffectiveSizeConstraint { get;}
        PERAlphabetAndSizeEffectiveConstraint PEREffectiveAlphabetAndSizeConstraint { get;}

        //It return the minimum allowed value for a REAL type. If associated is not a RAEL type, it throws an exception
        double m_MinRealValue { get;}
        //It return the maximum allowed value for a REAL type. If associated is not a RAEL type, it throws an exception
        double m_MaxRealValue { get;}

        IEnumerable<T> GetMySelfAndAnyChildren<T>() where T : class, IConstraint;
        IEnumerable<Asn1Value> GetVariables();

        ISet GetSet();

        List<KeyValuePair<string, ISet>> GetSetWithComponent();


    }

    // base class for all constraints
    public abstract class BaseConstraint : IConstraint
    {


        public virtual IEnumerable<Asn1Value> GetVariables()
        {
            yield break;
        }
        public virtual IEnumerable<T> GetMySelfAndAnyChildren<T>() where T : class, IConstraint
        {

            if (this is T)
                yield return this as T;

            yield break;
        }



        public static string AsString(List<IConstraint> cons)
        {
            string ret = string.Empty;
            if (cons != null)
            {
                foreach (IConstraint con in cons)
                    ret += con.ToString(true);
            }

            return ret;
        }


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

        public Asn1Type m_type;
        
        
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

        public virtual double m_MinRealValue { get { throw new Exception("The method or operation is not implemented."); } }
        public virtual double m_MaxRealValue { get { throw new Exception("The method or operation is not implemented."); } }

        public virtual ISet GetSet()
        {
            return new UniversalSet();
        }

        public virtual List<KeyValuePair<string, ISet>> GetSetWithComponent()
        {
            return new List<KeyValuePair<string, ISet>>();
        }

    }

    /// <summary>
    /// Root constraint
    /// </summary>
    public class RootConstraint : BaseConstraint
    {
        protected IConstraint m_constr;
        protected IConstraint m_extConstr;
        protected ExceptionSpec m_exceptionSpec;
        protected bool m_extended = false;

        public override IEnumerable<Asn1Value> GetVariables()
        {
            foreach (Asn1Value v in m_constr.GetVariables())
                yield return v;

            if (m_extConstr != null)
                foreach (Asn1Value v in m_extConstr.GetVariables())
                    yield return v;

            if (m_exceptionSpec != null && m_exceptionSpec.m_value != null)
                yield return m_exceptionSpec.m_value;
            
            yield break;
        }

        public override IEnumerable<T> GetMySelfAndAnyChildren<T>()
        {

            if (this is T)
                yield return this as T;

            foreach (T t in m_constr.GetMySelfAndAnyChildren<T>())
                yield return t;

            if (m_extConstr != null)
                foreach (T t in m_extConstr.GetMySelfAndAnyChildren<T>())
                    yield return t;

            yield break;
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

            RootConstraint ret = DefaultBackend.Instance.Factory.CreateRootConstraint();
            ret.m_type = type;
            ret.m_constr = constr;
            ret.m_extended = extended;
            ret.m_extConstr = extConstr;
            ret.m_exceptionSpec = exceptionSpec;
            
            return ret;

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
                PERIntegerEffectiveConstraint ret = DefaultBackend.Instance.Factory.CreatePERIntegerEffectiveConstraint();

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

        public override double m_MinRealValue
        {
            get
            {
                if (m_extConstr != null)
                    return Math.Min(m_constr.m_MinRealValue, m_extConstr.m_MaxRealValue);
                return m_constr.m_MinRealValue;
            }
        }

        public override double m_MaxRealValue
        {
            get
            {
                if (m_extConstr != null)
                    return Math.Max(m_constr.m_MaxRealValue, m_extConstr.m_MaxRealValue);
                return m_constr.m_MaxRealValue;
            }
        }

        public override ISet GetSet() 
        {
            if (m_extConstr != null)
                return m_constr.GetSet().Simplify().Union(m_extConstr.GetSet().Simplify()).Simplify();
            return m_constr.GetSet().Simplify();
        }
    }
    
    /// <summary>
    /// Union constraint 
    /// </summary>
    public class UnionConstraint : BaseConstraint
    {
        protected List<IConstraint> m_items;

        public override IEnumerable<Asn1Value> GetVariables()
        {
            foreach (IConstraint con in m_items)
                foreach (Asn1Value v in con.GetVariables())
                    yield return v;

            yield break;
        }


        public override IEnumerable<T> GetMySelfAndAnyChildren<T>()
        {

            if (this is T)
                yield return this as T;

            foreach(IConstraint item in m_items)
                foreach (T t in item.GetMySelfAndAnyChildren<T>())
                    yield return t;


            yield break;
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
            UnionConstraint ret = DefaultBackend.Instance.Factory.CreateUnionConstraint();
            ret.m_type = type;
            ret.m_items = items;

            return ret;
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
                ret += m_items[i].ToString() + " | ";
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
                PERIntegerEffectiveConstraint ret = DefaultBackend.Instance.Factory.CreatePERIntegerEffectiveConstraint();
                ret.m_rootRange = DefaultBackend.Instance.Factory.CreateIntegerRange();
                

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

        public override double m_MinRealValue
        {
            get
            {
                if (m_items.Count == 0)
                    return double.NegativeInfinity;
                
                double ret = double.PositiveInfinity;
                foreach (IConstraint con in m_items)
                    ret = Math.Min(ret, con.m_MinRealValue);

                return ret;
            }
        }

        public override double m_MaxRealValue
        {
            get
            {
                if (m_items.Count == 0)
                    return double.PositiveInfinity;

                double ret = double.NegativeInfinity;
                foreach (IConstraint con in m_items)
                    ret = Math.Max(ret, con.m_MaxRealValue);

                return ret;
            }
        }

        public override ISet GetSet()
        {
            if (m_items.Count == 1)
                return m_items[0].GetSet().Simplify();

            UnionSet ret = new UnionSet();
            foreach(IConstraint c in m_items)
                ret.AddUnionItem(c.GetSet().Simplify());

            return ret.Simplify();
        }
    }

    /// <summary>
    /// Intersection, ^ constraint
    /// </summary>
 
    public class AndConstraint : BaseConstraint
    {
        protected List<IConstraint> m_items;

        public override IEnumerable<Asn1Value> GetVariables()
        {
            foreach (IConstraint con in m_items)
                foreach (Asn1Value v in con.GetVariables())
                    yield return v;

            yield break;
        }

        public override IEnumerable<T> GetMySelfAndAnyChildren<T>()
        {

            if (this is T)
                yield return this as T;

            foreach (IConstraint item in m_items)
                foreach (T t in item.GetMySelfAndAnyChildren<T>())
                    yield return t;


            yield break;
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

            AndConstraint ret = DefaultBackend.Instance.Factory.CreateAndConstraint();
            ret.m_type = type;
            ret.m_items = items;
            return ret;
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
                ret += m_items[i].ToString() + " ^ ";
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
        public override double m_MinRealValue
        {
            get
            {
                double ret = double.NegativeInfinity;
                foreach (IConstraint con in m_items)
                    ret = Math.Max(ret, con.m_MinRealValue);

                return ret;
            }
        }

        public override double m_MaxRealValue
        {
            get
            {
                double ret = double.PositiveInfinity;
                foreach (IConstraint con in m_items)
                    ret = Math.Min(ret, con.m_MaxRealValue);

                return ret;
            }
        }

        public override ISet GetSet()
        {
            if (m_items.Count == 1)
                return m_items[0].GetSet().Simplify();

            IntersectionSet ret = new IntersectionSet();
            foreach (IConstraint c in m_items)
                ret.AddItem(c.GetSet().Simplify());

            return ret.Simplify();
        }

    }

    /// <summary>
    /// Except Constraint
    /// </summary>
    public class ExceptConstraint : BaseConstraint
    {
        protected IConstraint m_c1;
        protected IConstraint m_c2;

        public override IEnumerable<Asn1Value> GetVariables()
        {
            if (m_c1!=null)
                foreach (Asn1Value v in m_c1.GetVariables())
                    yield return v;

            if (m_c2 != null)
                foreach (Asn1Value v in m_c2.GetVariables())
                    yield return v;

            yield break;
        }

        public override IEnumerable<T> GetMySelfAndAnyChildren<T>()
        {

            if (this is T)
                yield return this as T;

            foreach (T t in m_c1.GetMySelfAndAnyChildren<T>())
                yield return t;
            foreach (T t in m_c2.GetMySelfAndAnyChildren<T>())
                yield return t;

            yield break;
        }

        public static ExceptConstraint Create(ITree tree, Asn1Type type)
        {
            if (tree == null || type == null )
                throw new ArgumentNullException();
            if (tree.Type != asn1Parser.INTERSECTION_ELEMENT && tree.ChildCount==2)
                throw new Exception("Internal Error");

            ExceptConstraint ret = DefaultBackend.Instance.Factory.CreateExceptConstraint();

            ret.m_type = type;
            ret.m_c1 = BaseConstraint.CreateConstraintExpression(tree.GetChild(0), type);
            ret.m_c2 = BaseConstraint.CreateConstraintExpression(tree.GetChild(1), type);

            return ret;
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
        public override double m_MinRealValue
        {
            get
            {
                return m_c1.m_MinRealValue;
            }
        }
        public override double m_MaxRealValue
        {
            get
            {
                return m_c1.m_MaxRealValue;
            }
        }

        public override ISet GetSet()
        {
            return m_c1.GetSet().Simplify().Minus(m_c2.GetSet().Simplify()).Simplify();
        }

    }
    /// <summary>
    /// All Except constraint
    /// </summary>
    public class AllExceptConstraint : BaseConstraint
    {
        protected IConstraint m_c;

        public override IEnumerable<Asn1Value> GetVariables()
        {
            if (m_c != null)
                foreach (Asn1Value v in m_c.GetVariables())
                    yield return v;


            yield break;
        }

        public override IEnumerable<T> GetMySelfAndAnyChildren<T>()
        {

            if (this is T)
                yield return this as T;

            foreach (T t in m_c.GetMySelfAndAnyChildren<T>())
                yield return t;

            yield break;
        }

        public static AllExceptConstraint Create(ITree tree, Asn1Type type)
        {
            if (tree == null || type == null)
                throw new ArgumentNullException();
            if (tree.Type != asn1Parser.UNION_SET_ALL_EXCEPT)
                throw new Exception("Internal Error");

            AllExceptConstraint ret = DefaultBackend.Instance.Factory.CreateAllExceptConstraint();

            ret.m_type = type;
            ret.m_c = BaseConstraint.CreateConstraintExpression(tree.GetChild(0), type);

            return ret;
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
        public override double m_MinRealValue
        {
            get
            {
                return double.NegativeInfinity;
            }
        }
        public override double m_MaxRealValue
        {
            get
            {
                return double.PositiveInfinity;
            }
        }
        public override ISet GetSet()
        {
            return m_c.GetSet().Complement().Simplify();
        }
    }
    /// <summary>
    /// Single value constraint
    /// </summary>
    public class SingleValueConstraint : BaseConstraint
    {
        protected Asn1Value m_val;

        public override ISet GetSet()
        {
            return m_type.GetSet(m_val);
        }

        public override IEnumerable<Asn1Value> GetVariables()
        {
            if (m_val!=null)
                yield return m_val;
            yield break;
        }


        public Asn1Value ConstraintValue { get { return m_val; } }

        public override bool isValueAllowed(Asn1Value val)
        {
            return m_val.Equals(val);
        }

        public static SingleValueConstraint Create(ITree tree, Asn1Type type) 
        {
            if (tree == null || type == null)
                throw new ArgumentNullException();
            
            Asn1Value val = Asn1Value.CreateFromAntlrAst(tree);

            SingleValueConstraint ret;
            if ((type.GetFinalType() is IA5StringType) && (((IA5StringType)type.GetFinalType()).IamUsedInPermittedAlphabet))
                ret = DefaultBackend.Instance.Factory.CreateSinglePAValueConstraint();
            else
                ret = DefaultBackend.Instance.Factory.CreateSingleValueConstraint();

            ret.m_type = type;
            ret.m_val = val;

            return ret;
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
                PERIntegerEffectiveConstraint ret = DefaultBackend.Instance.Factory.CreatePERIntegerEffectiveConstraint();
                ret.m_rootRange = DefaultBackend.Instance.Factory.CreateIntegerRange();
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

        public override double m_MinRealValue
        {
            get
            {
                return ((RealValue)m_val).Value;
            }
        }

        public override double m_MaxRealValue
        {
            get
            {
                return ((RealValue)m_val).Value;
            }
        }

    }

    /// <summary>
    /// Single value constraint used in Permited alphabet (i.e. FROM("ABCD"))
    /// </summary>
    public class SinglePAValueConstraint : SingleValueConstraint
    {
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

        public override ISet GetSet()
        {
            ICharacterString set = m_val as ICharacterString;
            if (set == null)
                throw new Exception("Internal Error");
            return m_type.GetAlphabetSet(set.Value);
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
                return DefaultBackend.Instance.Factory.CreatePERAlphabetAndSizeEffectiveConstraint(new List<Char>(set.Value.ToCharArray()));
            }
        }
    }

    /// <summary>
    /// Rnage Constraint e.g. INTEGER(5..10)
    /// </summary>
    public class RangeConstraint : BaseConstraint
    {
        /// <summary>
        /// if m_min is null then m_min is MIN
        /// </summary>
        public Asn1Value m_min;
        /// <summary>
        /// if m_max is null then m_max is MAX
        /// </summary>
        public Asn1Value m_max;
        public bool m_minValIsInluded = true;
        public bool m_maxValIsInluded = true;

        public override ISet GetSet()
        {
            return m_type.GetSet(m_min, m_minValIsInluded, m_max, m_maxValIsInluded);
        }

        public override IEnumerable<Asn1Value> GetVariables()
        {
            if (m_min!=null)
                yield return m_min;
            if (m_max != null)
                yield return m_max;
            yield break;
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
            RangeConstraint ret = null;

            if ((type.GetFinalType() is IA5StringType) && (((IA5StringType)type.GetFinalType()).IamUsedInPermittedAlphabet))
                ret = DefaultBackend.Instance.Factory.CreateRangePAConstraint();
            else
                ret = DefaultBackend.Instance.Factory.CreateRangeConstraint();

            ret.m_type = type;
            ret.m_min = minVal;
            ret.m_max = maxVal;
            ret.m_minValIsInluded = minValIsInclude;
            ret.m_maxValIsInluded = maxValIsInclude;

            return ret;
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
                PERIntegerEffectiveConstraint ret = DefaultBackend.Instance.Factory.CreatePERIntegerEffectiveConstraint();
                ret.m_rootRange = DefaultBackend.Instance.Factory.CreateIntegerRange();
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

        public override double m_MinRealValue
        {
            get
            {
                if (m_min == null)
                    return double.NegativeInfinity;
                return ((RealValue)m_min).Value;
            }
        }
        public override double m_MaxRealValue
        {
            get
            {
                if (m_max == null)
                    return double.PositiveInfinity;
                return ((RealValue)m_max).Value;
            }
        }
    }

    /// <summary>
    /// Range constraints for string types eg FROM("A".."Z")
    /// </summary>
    public class RangePAConstraint : RangeConstraint
    {

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

        public override ISet GetSet()
        {
            return m_type.GetAlphabetSet(m_min, m_minValIsInluded, m_max, m_maxValIsInluded);
        }
        protected ICharacterString Lo
        {
            get { return (ICharacterString)m_min; }
        }
        protected ICharacterString Hi
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
                return DefaultBackend.Instance.Factory.CreatePERAlphabetAndSizeEffectiveConstraint(min, max, m_type as IStringType);
            }
        }
    }

    /// <summary>
    /// Size constraints e.g. SIZE(1..100)
    /// </summary>
    public class SizeConstraint : BaseConstraint
    {
        public override IEnumerable<T> GetMySelfAndAnyChildren<T>()
        {
            if (this is T)
                yield return this as T;

            foreach(IConstraint con in sizeCon.m_constraints)
                foreach (T t in con.GetMySelfAndAnyChildren<T>())
                    yield return t;

            yield break;
        }

        public override IEnumerable<Asn1Value> GetVariables()
        {
            foreach (IConstraint con in sizeCon.m_constraints)
                foreach (Asn1Value v in con.GetVariables())
                    yield return v;
            yield break;
        }

        public /*not need to be abstract*/ class DummyReferenceType : ReferenceType
        {
            IntegerType dummyInterger;
            public DummyReferenceType(Module mod, ITree antlr)
            {
                m_module = mod;
                antlrNode = antlr;
                dummyInterger = DefaultBackend.Instance.Factory.CreateIntegerType();
                dummyInterger.antlrNode = antlr;
                dummyInterger.m_module = mod;


                RangeConstraint ret = null;
                ret = DefaultBackend.Instance.Factory.CreateRangeConstraint();
                ret.m_type = dummyInterger;
                ret.m_min = DefaultBackend.Instance.Factory.CreateIntegerValue(0, mod, antlr, dummyInterger);
                ret.m_max = null;
                ret.m_minValIsInluded = true;
                ret.m_maxValIsInluded = true;



                dummyInterger.m_constraints.Add(ret);
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

        protected DummyReferenceType sizeCon;


        public static IConstraint Create(ITree tree, Asn1Type type)
        {
            if (tree == null || type == null)
                throw new ArgumentNullException();
            if (!(tree.Type == asn1Parser.SIZE_EXPR || tree.Type==asn1Parser.SIMPLIFIED_SIZE_CONSTRAINT))
                throw new Exception("Internal Error");

            SizeConstraint ret = DefaultBackend.Instance.Factory.CreateSizeConstraint();
            ret.m_type = type;
            ret.sizeCon = new DummyReferenceType(type.m_module, tree);
            ret.sizeCon.m_AntlrConstraints.Add(tree.GetChild(0));
            return ret;
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


            return sizeCon.isValueAllowed(DefaultBackend.Instance.Factory.CreateIntegerValue(size.Size, m_type.m_module, null, sizeCon));
        }

        public override ISet GetSet()
        {
            return ((IntegerValueSet)sizeCon.GetSet()).ToSizeSet();
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
                return DefaultBackend.Instance.Factory.CreatePERSizeEffectiveConstraint(sizeCon.PEREffectiveConstraint as PERIntegerEffectiveConstraint);
            }
        }
        public override PERAlphabetAndSizeEffectiveConstraint PEREffectiveAlphabetAndSizeConstraint
        {
            get
            {
                return DefaultBackend.Instance.Factory.CreatePERAlphabetAndSizeEffectiveConstraint(sizeCon.PEREffectiveConstraint as PERIntegerEffectiveConstraint);
            }
        }


    }

    public class PermittedAlphabetConstraint : BaseConstraint
    {
        protected IA5StringType allowed_char_set;


        public override IEnumerable<Asn1Value> GetVariables()
        {
            foreach (IConstraint con in allowed_char_set.m_constraints)
                foreach (Asn1Value v in con.GetVariables())
                    yield return v;
            yield break;
        }

        public override IEnumerable<T> GetMySelfAndAnyChildren<T>()
        {
            if (this is T)
                yield return this as T;

            foreach (IConstraint con in allowed_char_set.m_constraints)
                foreach (T t in con.GetMySelfAndAnyChildren<T>())
                    yield return t;

            yield break;
        }


        internal static IConstraint Create(ITree tree, Asn1Type type)
        {
            if (tree == null || type == null)
                throw new ArgumentNullException();
            if (tree.Type != asn1Parser.PERMITTED_ALPHABET_EXPR)
                throw new Exception("Internal Error");

            PermittedAlphabetConstraint ret = DefaultBackend.Instance.Factory.CreatePermittedAlphabetConstraint();

            IA5StringType ia = type.GetFinalType() as IA5StringType;
            IA5StringType set = ia.CreateForPA(type.m_module, tree);
            set.m_AntlrConstraints.Add(tree.GetChild(0));
            ret.m_type = type;
            ret.allowed_char_set = set;

            return ret;
        }

        public override bool IsResolved()
        {
            return allowed_char_set.AreConstraintsResolved();
        }
        public override void DoSemanticAnalysis()
        {
            allowed_char_set.ResolveConstraints();
        }
        public override ISet GetSet()
        {
            return allowed_char_set.GetSet();
        }

        public override bool isValueAllowed(Asn1Value val)
        {
            ICharacterString str = val as ICharacterString;
            if (str == null)
                throw new Exception("Internal error");
            foreach (Char ch in str.Value)
            {
                IA5StringValue v = DefaultBackend.Instance.Factory.CreateIA5StringValue(ch);
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
                PERAlphabetAndSizeEffectiveConstraint ret = DefaultBackend.Instance.Factory.CreatePERAlphabetAndSizeEffectiveConstraint();
                ret = (PERAlphabetAndSizeEffectiveConstraint)ret.Compute(allowed_char_set.m_constraints, allowed_char_set);
                return ret;
            }
        }

    }

    public class TypeInclusionConstraint : BaseConstraint
    {
        Asn1Type m_otherType;


        internal static IConstraint Create(ITree tree, Asn1Type type)
        {
            if (tree == null || type == null)
                throw new ArgumentNullException();
            if (tree.Type != asn1Parser.SUBTYPE_EXPR)
                throw new Exception("Internal Error");
            TypeInclusionConstraint ret = DefaultBackend.Instance.Factory.CreateTypeInclusionConstraint();

            Asn1Type oth = Asn1Type.CreateFromAntlrAst(tree.GetChild(0));
            if (oth.SemanticAnalysisFinished())
            {
                if (!type.Compatible(oth))
                    throw new SemanticErrorException("Error, line:" + oth.antlrNode.Line + " .Types '"+oth.Name+"' and '"+type.Name+"' are not compatible");
            }

            ret.m_otherType = oth;
            ret.m_type = type;

            return ret;
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
        public override ISet GetSet()
        {
            return m_otherType.GetSet();
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

        public override double m_MinRealValue
        {
            get
            {
                double ret = double.NegativeInfinity;
                foreach (IConstraint con in m_otherType.m_constraints)
                    ret = Math.Max(ret, con.m_MinRealValue);
                return ret;
            }
        }

        public override double m_MaxRealValue
        {
            get
            {
                double ret = double.PositiveInfinity;
                foreach (IConstraint con in m_otherType.m_constraints)
                    ret = Math.Min(ret, con.m_MaxRealValue);
                return ret;

            }
        }
    }

    public class WithComponentConstraint : BaseConstraint
    {
        public IConstraint m_innerTypeConstraint;
        protected Asn1Type m_innerType;


        public override IEnumerable<Asn1Value> GetVariables()
        {
            foreach (Asn1Value v in m_innerTypeConstraint.GetVariables())
                yield return v;
            yield break;
        }

        public override IEnumerable<T> GetMySelfAndAnyChildren<T>()
        {
            if (this is T)
                yield return this as T;

            foreach (T t in m_innerTypeConstraint.GetMySelfAndAnyChildren<T>())
                    yield return t;

            yield break;
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

            WithComponentConstraint ret = DefaultBackend.Instance.Factory.CreateWithComponentConstraint();

            ret.m_type = type;
            ret.m_innerType = innerType;
            ret.m_innerTypeConstraint = innerConstraint;

            return ret;
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

        public override List<KeyValuePair<string, ISet>> GetSetWithComponent()
        {
            List<KeyValuePair<string, ISet>> ret = new List<KeyValuePair<string, ISet>>();

            ISet retSet = m_innerType.GetSet().Simplify().Intersect(m_innerTypeConstraint.GetSet().Simplify()).Simplify();
            ret.Add(new KeyValuePair<string, ISet>("", retSet));

            return ret;
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

        public bool m_partialSpecification = false; //i.e. ... are not present
        public OrderedDictionary<string, Component> m_components = new OrderedDictionary<string, Component>();



        public override IEnumerable<Asn1Value> GetVariables()
        {
            foreach (Component c in m_components.Values)
                if (c.m_valueConstraint != null)
                    foreach (Asn1Value v in c.m_valueConstraint.GetVariables())
                        yield return v;
            yield break;
        }

        public override IEnumerable<T> GetMySelfAndAnyChildren<T>()
        {
            if (this is T)
                yield return this as T;

            foreach (Component c in m_components.Values)
                if (c.m_valueConstraint != null)
                    foreach (T t in c.m_valueConstraint.GetMySelfAndAnyChildren<T>())
                        yield return t;

            yield break;
        }



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

/*        public WithComponentsConstraint(Asn1Type type, bool partialSpecification, OrderedDictionary<string, Component> components)
            : base(type)
        {
            m_partialSpecification = partialSpecification;
            m_components = components;
        }*/

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
        //public WithComponentsSeqConstraint(Asn1Type type, bool partialSpecification, OrderedDictionary<string, Component> components)
        //    : base(type, partialSpecification, components)
        //{
        //}
        protected SequenceOrSetType  Type
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
                    components.Add(id, DefaultBackend.Instance.Factory.CreateWithComponentsConstraintComponent(id, presenceConstr, con));
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
                            components.Add(cc.m_childVarName, DefaultBackend.Instance.Factory.CreateWithComponentsConstraintComponent(cc.m_childVarName, Component.PresenseConstraint.ABSENT, null));
                        else
                            throw new SemanticErrorException("Error line" + tree.Line+" Component '"+cc.m_childVarName+
                                "' is not listed.\nEither make the WITH COMPONENTS constraint partial by using ... or add"+
                                " the '"+cc.m_childVarName+"' to the list");
                    }
                }
            }
            WithComponentsSeqConstraint ret = DefaultBackend.Instance.Factory.CreateWithComponentsSeqConstraint();
            ret.m_type = type;
            ret.m_partialSpecification = partialSpecification;
            ret.m_components = components;
            return ret;
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

        public override List<KeyValuePair<string, ISet>> GetSetWithComponent()
        {
            List<KeyValuePair<string, ISet>> ret = new List<KeyValuePair<string, ISet>>();

            foreach (Component c in m_components.Values)
            {
                if (c.m_valueConstraint != null)
                {
                    Asn1Type m_innerType = Type.m_children[c.m_name].m_type;
                    IConstraint m_innerTypeConstraint = c.m_valueConstraint;
                    ISet retSet = m_innerType.GetSet().Simplify().Intersect(m_innerTypeConstraint.GetSet().Simplify()).Simplify();
                    ret.Add(new KeyValuePair<string, ISet>(c.m_name, retSet));
                    
                }
            }

            return ret;
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
        protected ChoiceType Type
        {
            get { return (ChoiceType)m_type; }
        }
        //public WithComponentsChConstraint(Asn1Type type, bool partialSpecification, OrderedDictionary<string, Component> components)
        //    : base(type, partialSpecification, components)
        //{
        //}

        public override List<KeyValuePair<string, ISet>> GetSetWithComponent()
        {
            List<KeyValuePair<string, ISet>> ret = new List<KeyValuePair<string, ISet>>();

            foreach (Component c in m_components.Values)
            {
                if (c.m_valueConstraint != null)
                {
                    Asn1Type m_innerType = Type.m_children[c.m_name].m_type;
                    IConstraint m_innerTypeConstraint = c.m_valueConstraint;
                    ISet retSet = m_innerType.GetSet().Simplify().Intersect(m_innerTypeConstraint.GetSet().Simplify()).Simplify();
                    ret.Add(new KeyValuePair<string, ISet>(c.m_name, retSet));

                }
            }

            return ret;
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
                    components.Add(id, DefaultBackend.Instance.Factory.CreateWithComponentsConstraintComponent(id, presenceConstr, con));
                }
            }

            if (!partialSpecification)
            {
                foreach (ChoiceChild cc in type.m_children.Values)
                {
                    //full specification, constraint component name does not appear (hence it ABSENT 47.8.6)
                    if (!components.ContainsKey(cc.m_childVarName))
                    {
                        components.Add(cc.m_childVarName, DefaultBackend.Instance.Factory.CreateWithComponentsConstraintComponent(cc.m_childVarName, Component.PresenseConstraint.ABSENT, null));
                    }
                }
            }

            WithComponentsChConstraint ret = DefaultBackend.Instance.Factory.CreateWithComponentsChConstraint();
            ret.m_type = type;
            ret.m_partialSpecification = partialSpecification;
            ret.m_components = components;

            return ret;
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
        //public WithComponentsRealConstraint(Asn1Type type, bool partialSpecification, OrderedDictionary<string, Component> components)
        //    : base(type, partialSpecification, components)
        //{
        //}
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
                        IntegerType dummyIntType = DefaultBackend.Instance.Factory.CreateIntegerType();
                        dummyIntType.antlrNode = tree;
                        dummyIntType.m_module = type.m_module;
                        dummyIntType.ResolveExternalConstraints(constraint, ref con);
                    }
                    if (con != null && con.IsResolved())
                        con = con.Simplify();
                    components.Add(id, DefaultBackend.Instance.Factory.CreateWithComponentsConstraintComponent(id, Component.PresenseConstraint.None, con));
                }
            }

            if (!partialSpecification && components.Values.Count!=3)
            {
                throw new SemanticErrorException("Error Line:" + tree.Line + ".\n"+
                    "You must either use partial specification (i.e. use ...) or specify mantissa and base and exponent");
            }

            WithComponentsRealConstraint ret = DefaultBackend.Instance.Factory.CreateWithComponentsRealConstraint();
            ret.m_type = type;
            ret.m_partialSpecification = partialSpecification;
            ret.m_components = components;

            return ret;
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

        public override List<KeyValuePair<string, ISet>> GetSetWithComponent()
        {
            List<KeyValuePair<string, ISet>> ret = new List<KeyValuePair<string, ISet>>();

            foreach (Component c in m_components.Values)
            {
                if (c.m_valueConstraint != null)
                {
                    ISet retSet = c.m_valueConstraint.GetSet();
                    ret.Add(new KeyValuePair<string, ISet>(c.m_name, retSet));
                }
            }

            return ret;
        }

    }
    /// <summary>
    /// This class represent the exception specification associated with a constraint
    /// </summary>
    public partial class ExceptionSpec
    {
        public Asn1Type m_type = null;
        public Asn1Value m_value = null;
        public Module m_module = null;
        static public ExceptionSpec CreateFromAntlrAst(ITree tree)
        {
            if (tree.Type != asn1Parser.EXCEPTION_SPEC)
                throw new Exception("Internal Error");
            ExceptionSpec ret = DefaultBackend.Instance.Factory.CreateExceptionSpec();
            IntegerType dummyInt;
            switch (tree.GetChild(0).Type)
            {
                case asn1Parser.EXCEPTION_SPEC_CONST_INT:
                case asn1Parser.EXCEPTION_SPEC_VAL_REF:
                    dummyInt = DefaultBackend.Instance.Factory.CreateIntegerType();
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
            string ret = "!";
            if (m_type is IntegerType)
                ret += m_value.ToString();
            else
                ret += m_type.Name + ":" + m_value.ToString();

            return ret;
        }

    }

}
