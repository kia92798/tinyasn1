/**=============================================================================
Definition of GeneralizedTimeType, UTCTimeType, GeneralizedTimeValue and UTCTimeValue  class
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

namespace tinyAsn1
{
    /// <summary>
    /// Class representing the GeneralizedTime type
    /// </summary>
    public partial class GeneralizedTimeType : IA5StringType
    {
        public override string Name
        {
            get { return "GeneralizedTime"; }
        }

        public override Asn1Type.Tag UniversalTag
        {
            get
            {
                return DefaultBackend.Instance.Factory.CreateAsn1TypeTag(Tag.TagClass.UNIVERSAL, 24, TaggingMode.EXPLICIT, this);
            }
        }

        internal override Asn1Value ResolveVariable(Asn1Value val)
        {
            string referenceId = "";
            switch (val.antlrNode.Type)
            {
                case asn1Parser.StringLiteral:
                    return DefaultBackend.Instance.Factory.CreateGeneralizedTimeValue(val.antlrNode, m_module, this);
                case asn1Parser.VALUE_REFERENCE:
                    referenceId = val.antlrNode.GetChild(0).Text;
                    if (m_module.isValueDeclared(referenceId))
                    {
                        Asn1Value tmp = m_module.GetValue(referenceId);
                        switch (tmp.m_TypeID)
                        {
                            case Asn1Value.TypeID.GeneralizedTime:
                                return DefaultBackend.Instance.Factory.CreateGeneralizedTimeValue(tmp as GeneralizedTimeValue, val.antlrNode.GetChild(0));
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
                    throw new SemanticErrorException("Error in line : " + val.antlrNode.Line + ". Expecting GeneralizedTime constant or GeneralizedTime variable reference");
            }
        }
        public override bool Compatible(Asn1Type other)
        {
            return other.GetFinalType() is GeneralizedTimeType;
        }
    }

    /// <summary>
    /// Class representing the UTCTime type
    /// </summary>
    public partial class UTCTimeType : IA5StringType
    {
        public override string Name
        {
            get { return "UTCTimeType"; }
        }

        public override Asn1Type.Tag UniversalTag
        {
            get
            {
                return DefaultBackend.Instance.Factory.CreateAsn1TypeTag(Tag.TagClass.UNIVERSAL, 23, TaggingMode.EXPLICIT, this);
            }
        }

        internal override Asn1Value ResolveVariable(Asn1Value val)
        {
            string referenceId = "";
            switch (val.antlrNode.Type)
            {
                case asn1Parser.StringLiteral:
                    return DefaultBackend.Instance.Factory.CreateUTCTimeValueValue(val.antlrNode, m_module, this);
                case asn1Parser.VALUE_REFERENCE:
                    referenceId = val.antlrNode.GetChild(0).Text;
                    if (m_module.isValueDeclared(referenceId))
                    {
                        Asn1Value tmp = m_module.GetValue(referenceId);
                        switch (tmp.m_TypeID)
                        {
                            case Asn1Value.TypeID.UTCTime:
                                return DefaultBackend.Instance.Factory.CreateUTCTimeValueValue(tmp as UTCTimeValue, val.antlrNode.GetChild(0));
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
                    throw new SemanticErrorException("Error in line : " + val.antlrNode.Line + ". Expecting UTCTime constant or UTCTime variable reference");
            }
        }
        public override bool Compatible(Asn1Type other)
        {
            return other.GetFinalType() is UTCTimeType;
        }
    }

    /// <summary>
    /// Class representing the GeneralizedTime value
    /// </summary>
    public partial class GeneralizedTimeValue : IA5StringValue
    {
        static Char[] AllowedCharSet = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '+', '-', 'Z', '.', ',' };

        public GeneralizedTimeValue(ITree tree, Module mod, Asn1Type type)
            : base(tree, mod, type)
        {
            m_TypeID = Asn1Value.TypeID.GeneralizedTime;
            List<Char> acs = new List<char>(AllowedCharSet);
            m_value = m_value.Replace("\r", "").Replace("\n", "").Replace("\t", "").Replace(" ", "");
            foreach (Char ch in Value.ToCharArray())
                if (!acs.Contains(ch))
                    throw new SemanticErrorException("Error in line: " + antlrNode.Line + ", col: " + antlrNode.CharPositionInLine + ". Character: '" + ch + "' can not be contained in a GenaralizedTime string");
        }

        public GeneralizedTimeValue(GeneralizedTimeValue o, ITree antlr)
            : base(o, antlr)
        {
            m_TypeID = Asn1Value.TypeID.GeneralizedTime;
        }
    }

    /// <summary>
    /// Class representing the UTCTime value
    /// </summary>
    public partial class UTCTimeValue : IA5StringValue
    {
        static Char[] AllowedCharSet = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '+', '-', 'Z' };

        public UTCTimeValue(ITree tree, Module mod, Asn1Type type)
            : base(tree, mod, type)
        {
            m_TypeID = Asn1Value.TypeID.UTCTime;
            List<Char> acs = new List<char>(AllowedCharSet);
            m_value = m_value.Replace("\r", "").Replace("\n", "").Replace("\t", "").Replace(" ", "");
            foreach (Char ch in Value.ToCharArray())
                if (!acs.Contains(ch))
                    throw new SemanticErrorException("Error in line: " + antlrNode.Line + ", col: " + antlrNode.CharPositionInLine + ". Character: '" + ch + "' can not be contained in a UTCTimeValue string");
        }

        public UTCTimeValue(UTCTimeValue o, ITree antlr)
            : base(o, antlr)
        {
            m_TypeID = Asn1Value.TypeID.UTCTime;
        }
    }


}
