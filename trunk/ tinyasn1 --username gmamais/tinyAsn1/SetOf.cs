using System;
using System.Collections.Generic;
using System.Text;
using Antlr.Runtime.Tree;
using Antlr.Runtime;

namespace tinyAsn1
{
    public partial class SetOfType : ArrayType
    {
        public override string Name
        {
            get { return "SET OF"; }
        }

        public override Asn1Type.Tag UniversalTag
        {
            get
            {
                return new Tag(Tag.TagClass.UNIVERSAL, 17, TaggingMode.EXPLICIT, this);
            }
        }

        static public new SetOfType CreateFromAntlrAst(ITree tree)
        {
            SetOfType ret = new SetOfType();
            for (int i = 0; i < tree.ChildCount; i++)
            {
                ITree child = tree.GetChild(i);
                switch (child.Type)
                {
                    case asn1Parser.SIMPLIFIED_SIZE_CONSTRAINT:
                    //                        ret.m_constraints.Add(Constraint.CreateConstraintFromSizeConstraint(child));
                    //                        break;
                    case asn1Parser.CONSTRAINT:
                        //                        ret.m_constraints.Add(Constraint.CreateFromAntlrAst(child));
                        ret.m_AntlrConstraints.Add(child);
                        break;
                    case asn1Parser.LID:
                        ret.m_xmlVarName = child.Text;
                        break;
                    case asn1Parser.TYPE_DEF:
                        ret.m_type = Asn1Type.CreateFromAntlrAst(child);
                        break;
                    default:
                        throw new Exception("Unkown child: " + child.Text + " for node: " + tree.Text);
                }
            }

            return ret;
        }
        internal override bool SemanticAnalysisFinished()
        {
            return m_type.SemanticAnalysisFinished() && base.SemanticAnalysisFinished();
        }

        public override void DoSemanticAnalysis()
        {
            if (SemanticAnalysisFinished())
                return;
            base.DoSemanticAnalysis();

            m_type.DoSemanticAnalysis();
        }
        internal override Asn1Value ResolveVariable(Asn1Value val)
        {
            string referenceId = "";
            SetOfValue sqVal = val as SetOfValue;
            switch (val.antlrNode.Type)
            {
                case asn1Parser.VALUE_LIST:
                case asn1Parser.OBJECT_ID_VALUE: //for catching case {valref} or {23}
                    if (sqVal == null)
                        return new SetOfValue(val.antlrNode, m_module, this);
                    else
                    {
                        sqVal.FixChildrenVars();
                        return sqVal;
                    }
                case asn1Parser.VALUE_REFERENCE:
                    referenceId = val.antlrNode.GetChild(0).Text;
                    if (m_module.isValueDeclared(referenceId))
                    {
                        Asn1Value tmp = m_module.GetValue(referenceId);
                        switch (tmp.m_TypeID)
                        {
                            case Asn1Value.TypeID.SET_OF:
                                if (tmp.IsResolved())
                                {
                                    if (tmp.Type.GetFinalType() == this)
                                        return new SetOfValue(tmp as SetOfValue, val.antlrNode.GetChild(0));
                                    throw new SemanticErrorException("Error in line : " + val.antlrNode.Line + ". Incompatible variable assigment");
                                }
                                return val; // not yet fully resolved, wait for next round
                            case Asn1Value.TypeID.UNRESOLVED:
                                // not yet resolved, wait for next round
                                return val;
                            default:
                                throw new SemanticErrorException("Error in line : " + val.antlrNode.Line + ". Incompatible variable assigment");
                        }
                    }
                    else
                        throw new SemanticErrorException("Error in line : " + val.antlrNode.Line + ". Identifier '" + referenceId + "' is unknown");

                default:
                    throw new SemanticErrorException("Error in line : " + val.antlrNode.Line + ". Expecting SET OF variable");
            }
        }

        public override void ResolveConstraints()
        {
            m_type.ResolveConstraints();
            base.ResolveConstraints();
        }
        public override bool AreConstraintsResolved()
        {
            return base.AreConstraintsResolved() && m_type.AreConstraintsResolved();
        }
        public override bool isValueAllowed(Asn1Value val)
        {
            if (!base.isValueAllowed(val))
                return false;
            SetOfValue v = val as SetOfValue;
            if (v == null)
                throw new Exception("Internal Error");

            foreach (Asn1Value item in v.m_children)
                if (!m_type.isValueAllowed(item))
                    return false;

            return true;
        }
        public override void CheckDefaultValues()
        {
            m_type.CheckDefaultValues();
        }


        public override void PrintAsn1(StreamWriterLevel o, int lev)
        {
            if (m_tag != null)
                m_tag.PrintAsn1(o, lev);
            o.Write("SET ");
            PrintAsn1Constraints(o);
            o.Write(" OF ");
            m_type.PrintAsn1(o, lev);
        }
    }
}
