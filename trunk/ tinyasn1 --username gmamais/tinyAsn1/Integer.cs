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
            if (nNumberOfUnresolvedVarsInConstraints > 0)
                return false;
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

            SemanticCheckConstraints();
        }

        int nNumberOfUnresolvedVarsInConstraints = 0;
        void SemanticCheckConstraints()
        {
            nNumberOfUnresolvedVarsInConstraints = 0;
            AntlrTreeVisitor visit = new AntlrTreeVisitor();
            int[] AllowedTokes = { asn1Parser.CONSTRAINT, asn1Parser.EXCEPTION_SPEC, asn1Parser.EXT_MARK, 
                asn1Parser.UNION_SET, asn1Parser.UNION_SET_ALL_EXCEPT, asn1Parser.INTERSECTION_SET,
                asn1Parser.INTERSECTION_ELEMENT, asn1Parser.VALUE_RANGE_EXPR, asn1Parser.SUBTYPE_EXPR};
            int[] StopList = { asn1Parser.VALUE_RANGE_EXPR, asn1Parser.SUBTYPE_EXPR };

            //1. check that only single value, range and type constraints exist
            foreach (ITree cons in m_AntlrConstraints)
                visit.visitIfNot(cons, AllowedTokes, ConstraintCheck_InvalidConstraint, StopList);
            //2. Check Single Value & Value Range
            foreach (ITree cons in m_AntlrConstraints)
                visit.visit(cons, asn1Parser.VALUE_RANGE_EXPR, ConstraintCheck_CheckValue);

            //3. build set with allowed values
            if (nNumberOfUnresolvedVarsInConstraints == 0)
            {
                foreach (ITree cons in m_AntlrConstraints)
                {
                    m_AllowedValueSet = Constraints_BuildSetFromConstraint(cons);
                    if (m_AllowedValueSet != null)
                        m_AllowedValueSet = m_AllowedValueSet.Simplify();
                }
            }
        }

        void ConstraintCheck_InvalidConstraint(ITree root)
        {
            throw new SemanticErrorException("Error in Line:" + root.Line + ", col:" + root.CharPositionInLine +
                " . This type of constraint '" + root.Text + "'cannot appear under " + Name);
        }

        void ConstraintCheck_CheckValue(ITree root)
        {
            ValueRangeExpression valRange = ValueRangeExpression.CreateFromAntlrAst(root);
            Asn1Value minVal = ResolveVariable(valRange.m_minValue);
            IntegerValue min = minVal as IntegerValue;
            if (valRange.m_maxValue != null)
            {
                Asn1Value maxVal = ResolveVariable(valRange.m_maxValue);
                IntegerValue max = maxVal as IntegerValue;

                if (min != null && max != null)
                {
                    if (min.Value > max.Value)
                        throw new SemanticErrorException("Error in Line:" + root.Line + ", col:" + root.CharPositionInLine +
                " . Lower range value(" + min.Value + ") is greater than upper range value(" + max.Value + ").");
                }
                else
                    nNumberOfUnresolvedVarsInConstraints++;
            }
            else
            {
                if (min == null)
                    nNumberOfUnresolvedVarsInConstraints++;
            }
        }

        ConstraintsSet<Int64> Constraints_BuildSetFromConstraint(ITree root)
        {
            switch (root.Type)
            {
                case asn1Parser.VALUE_RANGE_EXPR:
                    ValueRangeExpression valRange = ValueRangeExpression.CreateFromAntlrAst(root);
                    Asn1Value minVal = ResolveVariable(valRange.m_minValue);
                    IntegerValue min = minVal as IntegerValue;
                    if (valRange.m_maxValue != null)
                    {
                        Asn1Value maxVal = ResolveVariable(valRange.m_maxValue);
                        IntegerValue max = maxVal as IntegerValue;

                        if (min != null && max != null)
                            return new RangeValueSet<Int64>(min.Value, max.Value, valRange.m_minValIsIncluded, valRange.m_maxValIsIncluded);
                    }
                    else
                    {
                        if (min != null)
                            return new SingleValueSet<Int64>(min.Value);
                    }
                    break;
                case asn1Parser.UNION_SET:
                    List<ConstraintsSet<Int64>> childSets = new List<ConstraintsSet<long>>();
                    for (int i = 0; i < root.ChildCount; i++)
                    {
                        childSets.Add(Constraints_BuildSetFromConstraint(root.GetChild(i)));
                    }
                    return new UnionSet<Int64>(childSets);
                case asn1Parser.UNION_SET_ALL_EXCEPT:
                    return new AllExceptOfSet<Int64>(Constraints_BuildSetFromConstraint(root.GetChild(0)));
                case asn1Parser.INTERSECTION_SET:
                    childSets = new List<ConstraintsSet<long>>();
                    for (int i = 0; i < root.ChildCount; i++)
                    {
                        childSets.Add(Constraints_BuildSetFromConstraint(root.GetChild(i)));
                    }
                    return new IntersectionSet<Int64>(childSets);
                case asn1Parser.INTERSECTION_ELEMENT:
                    if (root.ChildCount == 1)
                        return Constraints_BuildSetFromConstraint(root.GetChild(0));
                    return new Set1ExceptOfSet2Set<Int64>(Constraints_BuildSetFromConstraint(root.GetChild(0)),
                                                          Constraints_BuildSetFromConstraint(root.GetChild(1)));
                case asn1Parser.CONSTRAINT:
                    return Constraints_BuildSetFromConstraint(root.GetChild(0));
                default:
                    throw new Exception("You missed: " + root.Text);
            }
            return null;
        }

        public ConstraintsSet<Int64> m_AllowedValueSet;
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
 
        public Asn1Type Type
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
                        ret = otherModule.GetTypeByName(((ReferenceType)ret).m_referencedModName);
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

    }



}