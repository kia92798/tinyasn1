using System;
using System.Collections.Generic;
using System.Text;
using Antlr.Runtime.Tree;
using Antlr.Runtime;

namespace tinyAsn1
{

    public partial class IntegerType : Asn1Type
    {
        static public new IntegerType CreateFromAntlrAst(ITree tree)
        {
            IntegerType ret = new IntegerType();
            for (int i = 0; i < tree.ChildCount; i++)
            {
                ITree child = tree.GetChild(i);
                NumberedItem item = NumberedItem.CreateFromAntlrAst(child);
                ret.m_privNamedValues.Add(item);
            }

            return ret;

        }

        bool isIdentifierDeclared(string id)
        {
            foreach (NumberedItem ni in m_privNamedValues)
                if (ni.m_id == id)
                    return true;

            return isIdentifierProcessed(id);
        }

        bool isIdentifierProcessed(string id)
        {
            return m_namedValues.ContainsKey(id);
        }

        internal override Asn1Value ResolveVariable(Asn1Value val)
        {
            if (m_module == null)
                throw new Exception("Bug m_module is null");
            string referenceId = "";
            switch (val.antlrNode.Type)
            {
                case asn1Parser.NUMERIC_VALUE:
                    return new IntegerValue(val.antlrNode, m_module, this);
                case asn1Parser.VALUE_REFERENCE:
                    referenceId = val.antlrNode.GetChild(0).Text;
                    if (m_module.isValueDeclared(referenceId))
                    {
                        Asn1Value tmp = m_module.GetValue(referenceId);
                        switch (tmp.m_TypeID)
                        {
                            case Asn1Value.TypeID.INT:
                                return new IntegerValue(tmp as IntegerValue);
                            case Asn1Value.TypeID.UNRESOLVED:
                                return val;
                            default:
                                throw new SemanticErrorException("Error in line : " + val.antlrNode.Line + ". Incompatible variable assigment");
                        }
                    }
                    else if (this.isIdentifierDeclared(referenceId))
                    {
                        if (this.isIdentifierProcessed(referenceId))
                            return new IntegerValue(m_namedValues[referenceId], m_module, val.antlrNode, this);
                        return val; //else wait for next round
                    }
                    else
                        throw new SemanticErrorException("Error in line : " + val.antlrNode.Line + ". Identifier '" + referenceId + "' is unknown");

                default:
                    throw new SemanticErrorException("Error in line : " + val.antlrNode.Line + ". Expecting integer or integer variable");
            }


        }

        internal override bool SemanticAnalysisFinished()
        {
            if (m_privNamedValues.Count > 0)
                return false;
            //if (nNumberOfUnresolvedVarsInConstraints > 0)
            //    return false;
            return true;
        }

        public override void DoSemanticAnalysis()
        {
            List<NumberedItem> toBeRemoved = new List<NumberedItem>();
            foreach (NumberedItem ni in m_privNamedValues)
            {
                if (m_namedValues.ContainsKey(ni.m_id))
                    throw new SemanticErrorException("The INTEGER type defined in line " + antlrNode.Line +
                        " containts more than once the identifier " + ni.m_id);
                if (ni.m_valueAsInt != null)
                {
                    m_namedValues.Add(ni.m_id, ni.m_valueAsInt.Value);
                    toBeRemoved.Add(ni);
                }
                else
                {
                    //We have to look up in the variables definitions
                    string refName = ni.m_valueAsReference;
                    if (m_module.isValueDeclared(refName))
                    {
                        Asn1Value tmpVal = m_module.GetValue(refName);
                        if (tmpVal.m_TypeID == Asn1Value.TypeID.UNRESOLVED)
                            continue;
                        if (tmpVal.m_TypeID == Asn1Value.TypeID.INT)
                        {
                            m_namedValues.Add(ni.m_id, ((IntegerValue)tmpVal).Value);
                            toBeRemoved.Add(ni);
                        }
                        else
                        {
                            throw new SemanticErrorException("Error in line : " + antlrNode.Line + ". Incompatible types assigment");
                        }
                        //else let it be resolved in a next parse round
                    }
                    else
                        throw new SemanticErrorException("Error in line : " + antlrNode.Line + ". Identifier '" + refName + "' is unknown");

                }
            }
            foreach (NumberedItem ni in toBeRemoved)
                m_privNamedValues.Remove(ni);

//            SemanticCheckConstraints();
        }


        public override void checkConstraintsSemantically(ITree antrlConstraint)
        {
            AntlrTreeVisitor visit = new AntlrTreeVisitor();

            visit.visitIfNot(antrlConstraint, AllowedTokensInConstraints, delegate(ITree root)
            {
                throw new SemanticErrorException("Error in Line:" + root.Line + ", col:" + root.CharPositionInLine +
                    " . This type of constraint '" + root.Text + "'cannot appear under " + Name);
                },
                StopTokensInConstraints);
        }
    }



    public partial class ReferenceType : Asn1Type
    {
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
            return Type.ResolveVariable(val);
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
            return true;
        }
        
        public override void DoSemanticAnalysis()
        {
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
        
        public override void checkConstraintsSemantically(ITree antrlConstraint)
        {
            Type.checkConstraintsSemantically(antrlConstraint);
        }
    }



}