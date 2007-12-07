using System;
using System.Collections.Generic;
using System.Text;
using Antlr.Runtime.Tree;
using Antlr.Runtime;

namespace tinyAsn1
{
    public partial class RealType : Asn1Type
    {
        public override string Name
        {
            get { return "REAL"; }
        }

        public override Asn1Type.Tag UniversalTag
        {
            get
            {
                return new Tag(Tag.TagClass.UNIVERSAL, 9, TaggingMode.EXPLICIT, this);
            }
        }

        internal override Asn1Value ResolveVariable(Asn1Value val)
        {
            string referenceId = "";
            switch (val.antlrNode.Type)
            {
                case asn1Parser.INT:
                case asn1Parser.FloatingPointLiteral:
                case asn1Parser.MINUS_INFINITY:
                case asn1Parser.PLUS_INFINITY:
                    return new RealValue(val.antlrNode, m_module, this);

                case asn1Parser.NUMERIC_VALUE2: //e.g. {mantissa 2, base 10, exponent 0}
                    return new RealValue(val.antlrNode, m_module, this, 0);
                case asn1Parser.VALUE_REFERENCE:
                    referenceId = val.antlrNode.GetChild(0).Text;
                    if (m_module.isValueDeclared(referenceId))
                    {
                        Asn1Value tmp = m_module.GetValue(referenceId);
                        switch (tmp.m_TypeID)
                        {
                            case Asn1Value.TypeID.REAL:
                                return new RealValue(tmp as RealValue, val.antlrNode.GetChild(0));
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
                    throw new SemanticErrorException("Error in line : " + val.antlrNode.Line + ". Expecting REAL or REAL variable");
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
        static List<int> m_allowedTokens = new List<int>(new int[]{ asn1Parser.CONSTRAINT, asn1Parser.EXCEPTION_SPEC, asn1Parser.EXT_MARK, 
                asn1Parser.UNION_SET, asn1Parser.UNION_SET_ALL_EXCEPT, asn1Parser.INTERSECTION_SET,
                asn1Parser.INTERSECTION_ELEMENT, asn1Parser.VALUE_RANGE_EXPR, asn1Parser.SUBTYPE_EXPR, asn1Parser.WITH_COMPONENTS_CONSTR});
        static List<int> m_stopList = new List<int>(new int[] { asn1Parser.VALUE_RANGE_EXPR, asn1Parser.SUBTYPE_EXPR, asn1Parser.WITH_COMPONENTS_CONSTR });

        protected override IEnumerable<int> AllowedTokensInConstraints { get { return m_allowedTokens; } }
        protected override IEnumerable<int> StopTokensInConstraints { get { return m_stopList; } }

    }
}
