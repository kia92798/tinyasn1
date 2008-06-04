/**=============================================================================
Definition of ReferenceType class
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

namespace tinyAsn1
{
    public partial class ReferenceType : Asn1Type 
    {
        //the name of the type
        public string m_referencedTypeName = "";
        public string m_referencedModName = "";



        static public new ReferenceType CreateFromAntlrAst(ITree tree)
        {
            ReferenceType ret = DefaultBackend.Instance.Factory.CreateReferenceType();
            if (tree.ChildCount == 1)
                ret.m_referencedTypeName = tree.GetChild(0).Text;
            else if (tree.ChildCount == 2)
            {
                ret.m_referencedModName = tree.GetChild(0).Text;
                ret.m_referencedTypeName = tree.GetChild(1).Text;
            }
            else
                throw new Exception("Incorrect parse tree!");
            return ret;
        }

        internal override Asn1Value ResolveVariable(Asn1Value val)
        {
            Asn1Value ret = Type.ResolveVariable(val);
            ret.m_type = this;
            return ret;
        }

        /// <summary>
        /// Returns the final type. Example
        /// A ::=INTEGER
        /// B ::= A
        /// C ::= B
        /// 
        /// if we call this property for type C this it will return INTEGER (Nor B )
        /// </summary>
        public virtual Asn1Type Type
        {
            get
            {
                Asn1Type ret = this;

                while (ret is ReferenceType)
                {
                    if (((ReferenceType)ret).m_referencedModName != "")
                    {
                        //                        throw new Exception("Type references to external modules are not implemented (yet) ...");
                        if (!DefaultBackend.Instance.isModuleDefined(((ReferenceType)ret).m_referencedModName))
                            throw new SemanticErrorException("Error: No module is defined with name '" + ((ReferenceType)ret).m_referencedModName + "'. Line: " + ret.antlrNode.Line);
                        Module otherModule = DefaultBackend.Instance.GetModuleByName(((ReferenceType)ret).m_referencedModName);
                        ret = otherModule.GetTypeByName(((ReferenceType)ret).m_referencedTypeName);
                    }
                    if (ret.m_module.m_typeAssigments.ContainsKey(((ReferenceType)ret).m_referencedTypeName))
                        ret = ret.m_module.m_typeAssigments[((ReferenceType)ret).m_referencedTypeName].m_type;
                    else
                    {
                        if (!ret.m_module.isTypeDeclared(((ReferenceType)ret).m_referencedTypeName))
                            throw new SemanticErrorException("Error: referenced type with name '" + ((ReferenceType)ret).m_referencedTypeName + "' is not define. Line: " + ret.antlrNode.Line);
                        ret = ret.m_module.GetTypeByName(((ReferenceType)ret).m_referencedTypeName);
                    }
                }
                return ret;
            }
        }

        public override Asn1Type GetFinalType()
        {
            return Type;
        }

        

        public override Asn1Type ParentType
        {
            get
            {
                if (m_referencedModName != "")
                {
                    //                        throw new Exception("Type references to external modules are not implemented (yet) ...");
                    if (!DefaultBackend.Instance.isModuleDefined(m_referencedModName))
                        throw new SemanticErrorException("Error: No module is defined with name '" + m_referencedModName + "'. Line: " + antlrNode.Line);
                    Module otherModule = DefaultBackend.Instance.GetModuleByName(m_referencedModName);
                    return otherModule.GetTypeByName(m_referencedTypeName);
                }
                return m_module.GetTypeByName(m_referencedTypeName);
            }
        }
        public override TagSequence Tags
        {
            get
            {
                TagSequence ret = DefaultBackend.Instance.Factory.CreateAsn1TypeTagSequence();
                Asn1Type type = this;
                bool implicitTagging = false;
                while (type != null)
                {
                    Tag outerTag = type.m_tag;
                    if (outerTag != null)
                    {
                        implicitTagging = outerTag.m_taggingMode == TaggingMode.IMPLICIT;
                        break;
                    }
                    type = type.ParentType;
                }

                type = this;

                while (type != null)
                {
                    Tag tagToAdded = type.m_tag;
                    if (tagToAdded != null)
                    {
                        ret.m_tags.Add(tagToAdded);
                        if (implicitTagging)
                            break;
                    }
                    if (type.UniversalTag != null)
                        ret.m_tags.Add(type.UniversalTag);
                    type = type.ParentType;
                }
                return ret;
            }
        }

        public override bool IsTagged()
        {
            Asn1Type type = this;
            while (type != null)
            {
                if (type.m_tag != null)
                    return true;
                type = type.ParentType;
            }
            return false;
        }


        public override string Name
        {
            get
            {
                if (m_referencedModName == "")
                    return m_referencedTypeName;
                else
                    return m_referencedModName + "." + m_referencedTypeName;
            }
        }

        internal override bool SemanticAnalysisFinished()
        {
            return base.SemanticAnalysisFinished();
        }

        public override void DoSemanticAnalysis()
        {
            base.DoSemanticAnalysis();
        }

        public override void ResolveConstraints()
        {
            if (AreConstraintsResolved())
                return;

            if (!ParentType.AreConstraintsResolved())
                return;

            if (m_constraints.Count == 0)
            {
                foreach (ITree tree in m_AntlrConstraints)
                {
                    checkConstraintsSemantically(tree);
                    m_constraints.Add(RootConstraint.Create(tree, this));
                }
            }

            foreach (IConstraint cn in m_constraints)
                cn.DoSemanticAnalysis();

            if (AreConstraintsResolved())       //constraints have just been resolved so let's simplify them
            {
                for (int i = 0; i < m_constraints.Count; i++)
                {
                    m_constraints[i] = m_constraints[i].Simplify();
                }
            }
        }

        public override bool AreConstraintsResolved()
        {
            if (!DefaultBackend.EnterRecursiveFunc(MB.GetCurrentMethod().Name, this))
                return true;
            
            bool ret = _AreConstraintsResolved();

            DefaultBackend.LeaveRecursiveFunc(MB.GetCurrentMethod().Name, this);
            return ret;

        }



        bool _AreConstraintsResolved()
        {
            if (!ParentType.AreConstraintsResolved())
                return false;
            if (m_AntlrConstraints.Count > m_constraints.Count)
                return false;
            foreach (IConstraint cn in m_constraints)
                if (!cn.IsResolved())
                    return false;
            return true;
        }

        public override void CheckChildrensTags()
        {
            Type.CheckChildrensTags();
        }

        public override void checkConstraintsSemantically(ITree antrlConstraint)
        {
            Type.checkConstraintsSemantically(antrlConstraint);
        }
        public override void PerformAutomaticTagging()
        {
            Type.PerformAutomaticTagging();
        }

        public override bool Compatible(Asn1Type other)
        {
            return GetFinalType().Compatible(other.GetFinalType());
        }


// PER related methods

        private PEREffectiveConstraint m_perEffectiveConstraint = null;
        public override PEREffectiveConstraint PEREffectiveConstraint
        {
            get
            {
                if (m_perEffectiveConstraint != null)
                    return m_perEffectiveConstraint;
                if (Type.PEREffectiveConstraint == null)
                    return null;
                m_perEffectiveConstraint = Type.PEREffectiveConstraint.Compute(m_constraints, this);

                Asn1Type parType = ParentType;
                while (parType != null)
                {
                    m_perEffectiveConstraint = PEREffectiveConstraint.Intersection(m_perEffectiveConstraint, parType.PEREffectiveConstraint);

                    parType = parType.ParentType;
                }


                return m_perEffectiveConstraint;
            }
        }

        public double m_MinRealValue
        {
            get
            {
                double ret = double.NegativeInfinity;
                foreach (IConstraint con in m_constraints)
                    ret = Math.Max(ret, con.m_MinRealValue);

                Asn1Type parType = ParentType;
                while (parType != null)
                {
                    if (parType is RealType)
                        ret = Math.Max(ret, ((RealType)parType).m_MinRealValue);
                    else if (parType is ReferenceType)
                        ret = Math.Max(ret, ((ReferenceType)parType).m_MinRealValue);
                    else
                        throw new Exception("Internal Error: m_MinValue is not supported for type: " + parType.Name);
                    parType = parType.ParentType;
                }

                return ret;
            }
        }


        public double m_MaxRealValue
        {
            get
            {
                double ret = double.PositiveInfinity;
                foreach (IConstraint con in m_constraints)
                    ret = Math.Min(ret, con.m_MaxRealValue);
                Asn1Type parType = ParentType;
                while (parType != null)
                {
                    if (parType is RealType)
                        ret = Math.Min(ret, ((RealType)parType).m_MaxRealValue);
                    else if (parType is ReferenceType)
                        ret = Math.Min(ret, ((ReferenceType)parType).m_MaxRealValue);
                    else
                        throw new Exception("Internal Error: m_MinValue is not supported for type: " + parType.Name);
                    parType = parType.ParentType;
                }
                return ret;
            }
        }



        public override long minBitsInPER(PEREffectiveConstraint cns)
        {
            return Type.minBitsInPER(cns);
        }

        public override long maxBitsInPER(PEREffectiveConstraint cns)
        {
            return Type.maxBitsInPER(cns);
        }



        public static ReferenceType CreateByName(TypeAssigment newTas)
        {
            ReferenceType ret = DefaultBackend.Instance.Factory.CreateReferenceType();
            ret.m_referencedTypeName = newTas.m_name;
            ret.m_module = newTas.m_type.m_module;
            ret.antlrNode = newTas.m_type.antlrNode;
            return ret;
        }


        internal override bool DependsOnlyOn(List<string> values)
        {
            foreach (string str in values)
            {
                if (m_referencedTypeName == str)
                    return true;
            }
            return false;
        }


        public override bool ContainsTypeAssigment(string typeAssigment)
        {
            if (!DefaultBackend.EnterRecursiveFunc(MB.GetCurrentMethod().Name, this))
                return true;

            bool ret = _ContainsTypeAssigment(typeAssigment);

            

            DefaultBackend.LeaveRecursiveFunc(MB.GetCurrentMethod().Name, this);
            return ret;
        }


        bool _ContainsTypeAssigment(string typeAssigment)
        {
            ReferenceType cur = this as ReferenceType;
            
            while (cur != null)
            {
                if (cur.m_referencedTypeName == typeAssigment)
                    return true;

                cur = cur.ParentType as ReferenceType;
            }
            return Type.ContainsTypeAssigment(typeAssigment);
        }

        internal override List<string> TypesIDepend()
        {
            List<string> ret = new List<string>();

            ret.Add(m_referencedTypeName);

            ret.AddRange(Type.TypesIDepend());

            return ret;
        }

    }
}
