using System;
using System.Collections.Generic;
using System.Text;
using Antlr.Runtime.Tree;
using Antlr.Runtime;

namespace tinyAsn1
{
    public partial class ObjectIdentifier : Asn1Type
    {

        public override string Name
        {
            get { return "OBJECT IDENTIFIER"; }
        }

        public override Asn1Type.Tag UniversalTag
        {
            get
            {
                return new Tag(Tag.TagClass.UNIVERSAL, 6, TaggingMode.EXPLICIT, this);
            }
        }

        static public new ObjectIdentifier CreateFromAntlrAst(ITree tree)
        {
            return new ObjectIdentifier();
        }
        internal override Asn1Value ResolveVariable(Asn1Value val)
        {
            string referenceId = "";
            ObjectIdentifierValue obVal = val as ObjectIdentifierValue;
            switch (val.antlrNode.Type)
            {
                case asn1Parser.OBJECT_ID_VALUE:
                    if (obVal == null)
                        return new ObjectIdentifierValue(val.antlrNode, m_module, this);
                    else
                    {
                        obVal.FixChildrenVars();
                        return obVal;
                    }
                case asn1Parser.VALUE_REFERENCE:
                    referenceId = val.antlrNode.GetChild(0).Text;
                    if (m_module.isValueDeclared(referenceId))
                    {
                        Asn1Value tmp = m_module.GetValue(referenceId);
                        switch (tmp.m_TypeID)
                        {
                            case Asn1Value.TypeID.OBJECT_IDENTIFIER:
                                if (tmp.IsResolved())
                                {
                                    if (tmp.Type.GetFinalType() == this)
                                        return new ObjectIdentifierValue(tmp as ObjectIdentifierValue, val.antlrNode.GetChild(0));
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
                    throw new SemanticErrorException("Error in line : " + val.antlrNode.Line + ". Expecting OBJECT IDENTIFIER variable");
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
    }
}
