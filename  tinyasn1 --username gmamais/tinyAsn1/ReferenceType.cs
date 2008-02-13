using System;
using System.Collections.Generic;
using System.Text;
using Antlr.Runtime.Tree;
using Antlr.Runtime;

namespace tinyAsn1
{
    public partial class ReferenceType : Asn1Type
    {
        public string m_referencedTypeName = "";
        public string m_referencedModName = "";


        static public new ReferenceType CreateFromAntlrAst(ITree tree)
        {
            ReferenceType ret = new ReferenceType();
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
                        if (!Asn1CompilerInvokation.Instance.isModuleDefined(((ReferenceType)ret).m_referencedModName))
                            throw new SemanticErrorException("Error: No module is defined with name '" + ((ReferenceType)ret).m_referencedModName + "'. Line: " + ret.antlrNode.Line);
                        Module otherModule = Asn1CompilerInvokation.Instance.GetModuleByName(((ReferenceType)ret).m_referencedModName);
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
                    if (!Asn1CompilerInvokation.Instance.isModuleDefined(m_referencedModName))
                        throw new SemanticErrorException("Error: No module is defined with name '" + m_referencedModName + "'. Line: " + antlrNode.Line);
                    Module otherModule = Asn1CompilerInvokation.Instance.GetModuleByName(m_referencedModName);
                    return otherModule.GetTypeByName(m_referencedTypeName);
                }
                return m_module.GetTypeByName(m_referencedTypeName);
            }
        }
        public override TagSequence Tags
        {
            get
            {
                TagSequence ret = new TagSequence();
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

        /*        public override IConstraint ParentConstraint
                {
                    get
                    {
                        return ParentType.Constraint;
                    }
                }
        */
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
                    m_perEffectiveConstraint = PEREffectiveConstraint.Intersection(m_perEffectiveConstraint, ParentType.PEREffectiveConstraint);

                    parType = parType.ParentType;
                }


                return m_perEffectiveConstraint;
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


        public override void PrintHtml(PEREffectiveConstraint cns, StreamWriterLevel o, int lev, List<string> comment, TypeAssigment tas)
        {
            Type.PrintHtml(cns, o, lev, comment, tas);
        }
        public static ReferenceType CreateByName(TypeAssigment newTas)
        {
            ReferenceType ret = new ReferenceType();
            ret.m_referencedTypeName = newTas.m_name;
            ret.m_module = newTas.m_type.m_module;
            ret.antlrNode = newTas.m_type.antlrNode;
            return ret;
        }

        internal override void PrintHTypeDeclaration(PEREffectiveConstraint cns, StreamWriterLevel h, string typeName, string varName, int lev)
        {
            h.Write(m_referencedTypeName);
        }

        internal override bool DependsOnlyOn(List<TypeAssigment> values)
        {
            foreach (TypeAssigment t in values)
            {
                if (m_referencedTypeName == t.m_name)
                    return true;
            }
            return false;
        }
        internal override void PrintCInitialize(PEREffectiveConstraint cns, Asn1Value defauleVal, StreamWriterLevel h, string typeName, string varName, int lev)
        {
            h.P(lev);
            if (!(Type is IA5StringType))
                h.WriteLine("{0}_Initialize(&{1});", m_referencedTypeName, varName);
            else
                h.WriteLine("{0}_Initialize({1});", m_referencedTypeName, varName);

        }
        internal override void PrintHConstraintConstant(StreamWriterLevel h, string name)
        {
            Asn1Type cur = this;
            int nCount = 0;
            string conConstraints = "";
            while (cur != null)
            {
                nCount = cur.m_constraints.Count;
                conConstraints += cur.Constraints;
                cur = cur.ParentType;
            }
            if (nCount>0)
                h.WriteLine("#define ERR_{0}_CONSTRAINT_FAILED\t\t{1} /* {2} */", name, Asn1CompilerInvokation.Instance.ConstraintErrorID++, conConstraints);
        }

        internal override void PrintCIsConstraintValid(PEREffectiveConstraint cns, StreamWriterLevel c, string errorCode, string typeName, string varName, int lev)
        {
            c.P(lev); c.Write("ret =");
            if (!(Type is IA5StringType))
                c.WriteLine("{0}_IsConstraintValid(&{1}, pErrCode);", m_referencedTypeName, varName);
            else
                c.WriteLine("{0}_IsConstraintValid({1}, pErrCode);", m_referencedTypeName, varName);

            c.P(lev);
            c.WriteLine("if (!ret)");
            c.P(lev + 1);
            c.WriteLine("return FALSE;");

            base.PrintCIsConstraintValid(cns, c, errorCode, typeName, varName, lev);
            
        }
    }
}
