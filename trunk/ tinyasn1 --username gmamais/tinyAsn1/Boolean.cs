using System;
using System.Collections.Generic;
using System.Text;
using Antlr.Runtime.Tree;
using Antlr.Runtime;

namespace tinyAsn1
{
    public partial class BooleanType : Asn1Type
    {
        public override string Name
        {
            get { return "BOOLEAN"; }
        }

        public override Asn1Type.Tag UniversalTag
        {
            get
            {
                return new Tag(Tag.TagClass.UNIVERSAL, 1, TaggingMode.EXPLICIT, this);
            }
        }

        internal override Asn1Value ResolveVariable(Asn1Value val)
        {
            string referenceId = "";
            switch (val.antlrNode.Type)
            {
                case asn1Parser.TRUE:
                case asn1Parser.FALSE:
                    return new BooleanValue(val.antlrNode, m_module, this);
                case asn1Parser.VALUE_REFERENCE:
                    referenceId = val.antlrNode.GetChild(0).Text;
                    if (m_module.isValueDeclared(referenceId))
                    {
                        Asn1Value tmp = m_module.GetValue(referenceId);
                        switch (tmp.m_TypeID)
                        {
                            case Asn1Value.TypeID.BOOLEAN:
                                return new BooleanValue(tmp as BooleanValue, val.antlrNode.GetChild(0));
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
                    throw new SemanticErrorException("Error in line : " + val.antlrNode.Line + ". Expecting TRUE, FALSE or reference to a boolean variable");
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

        public override bool Compatible(Asn1Type other)
        {
            BooleanType o = other.GetFinalType() as BooleanType;
            if (o == null)
                return false;

            return true;
        }
        public override long minBitsInPER(PEREffectiveConstraint cns)
        {
            return 1;
        }

        public override long maxBitsInPER(PEREffectiveConstraint cns)
        {
            return 1;
        }
        internal override void PrintHTypeDeclaration(PEREffectiveConstraint cns, StreamWriterLevel h, string typeName, string varName, int lev)
        {
            h.Write("flag ");
        }
        internal override void PrintCInitialize(PEREffectiveConstraint cns, Asn1Value defaultVal, StreamWriterLevel h, string typeName, string varName, int lev)
        {
            bool topLevel = !varName.Contains("->");
            BooleanValue b = defaultVal as BooleanValue;
            string defVal = "FALSE";
            if (b != null && b.Value)
                defVal = "TRUE";
            h.P(lev);
            if (topLevel)
                h.WriteLine("*{0} = {1};", varName, defVal);
            else
                h.WriteLine("{0} = {1};", varName, defVal);

        }
        internal override void PrintCEncode(PEREffectiveConstraint cns, StreamWriterLevel c, string errorCode, string varName, int lev)
        {
            bool topLevel = !varName.Contains("->");
            c.P(lev);
            if (topLevel)
                c.WriteLine("BitStream_AppendBit(pBitStrm, *{0});", varName);
            else
                c.WriteLine("BitStream_AppendBit(pBitStrm, {0});", varName);
        }
    }

    public partial class BooleanValue : Asn1Value
    {
        bool m_value = false;
        public virtual bool Value
        {
            get { return m_value; }
        }

        public override string ToString()
        {
            if (Value)
                return "TRUE";
            return "FALSE";
        }
        public BooleanValue(ITree tree, Module mod, Asn1Type type)
        {
            m_TypeID = Asn1Value.TypeID.BOOLEAN;
            m_module = mod;
            antlrNode = tree;
            m_type = type;

            if (tree.Type == asn1Parser.TRUE)
                m_value = true;
            else if (tree.Type == asn1Parser.FALSE)
                m_value = false;
            else
                throw new Exception("Internal Error");

        }
        public BooleanValue(BooleanValue o, ITree antlr)
        {
            m_TypeID = Asn1Value.TypeID.BOOLEAN;
            m_module = o.m_module;
            antlrNode = antlr;
            m_value = o.m_value;
            m_type = o.m_type;
        }
        public override bool Equals(object obj)
        {
            BooleanValue oth = obj as BooleanValue;
            if (oth == null)
                return false;
            return oth.m_value == m_value;
        }

        public override int GetHashCode()
        {
            return m_value.GetHashCode();
        }

        public override List<bool> Encode()
        {
            List<bool> ret = new List<bool>();
            ret.Add(Value);
            return ret;
        }
    }

}