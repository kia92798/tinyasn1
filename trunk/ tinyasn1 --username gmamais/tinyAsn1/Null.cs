/**=============================================================================
Definition of NullType and NullValue classes
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
using semantix.util;

namespace tinyAsn1
{

    public partial class NullType : Asn1Type
    {
        public override string Name
        {
            get { return "NULL"; }
        }

        public override Asn1Type.Tag UniversalTag
        {
            get
            {

                return DefaultBackend.Instance.Factory.CreateAsn1TypeTag(Tag.TagClass.UNIVERSAL, 5, TaggingMode.EXPLICIT, this);
            }
        }

        internal override Asn1Value ResolveVariable(Asn1Value val)
        {
            string referenceId = "";
            switch (val.antlrNode.Type)
            {
                case asn1Parser.NULL:
                    return DefaultBackend.Instance.Factory.CreateNullValue(val.antlrNode, m_module, this);
                case asn1Parser.VALUE_REFERENCE:
                    referenceId = val.antlrNode.GetChild(0).Text;
                    if (m_module.isValueDeclared(referenceId))
                    {
                        Asn1Value tmp = m_module.GetValue(referenceId);
                        switch (tmp.m_TypeID)
                        {
                            case Asn1Value.TypeID.NULL:
                                return DefaultBackend.Instance.Factory.CreateNullValue(tmp as NullValue, val.antlrNode.GetChild(0));
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
                    throw new SemanticErrorException("Error in line : " + val.antlrNode.Line + ". Expecting NULL");
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
            NullType o = other.GetFinalType() as NullType;
            if (o == null)
                return false;

            return true;
        }

        public override long minBitsInPER(PEREffectiveConstraint cns)
        {
            return 0;
        }
        public override long maxBitsInPER(PEREffectiveConstraint cns)
        {
            return 0;
        }


        public override ISet GetSet(Asn1Value val)
        {
            List<NullValue> d = new List<NullValue>();
            d.Add(new NullValue());
            DiscreetValueSetWithFiniteUniverse<NullValue> ret = new DiscreetValueSetWithFiniteUniverse<NullValue>(d);

            ret.AddValue((NullValue)val);

            return ret;

        }

    }


    public partial class NullValue : Asn1Value, IEquatable<NullValue>
    {

        internal NullValue() { }
        public NullValue(ITree tree, Module mod, Asn1Type type)
        {
            m_TypeID = TypeID.NULL;
            m_module = mod;
            antlrNode = tree;
            m_type = type;
        }
        public NullValue(NullValue o, ITree antlr)
        {
            m_TypeID = Asn1Value.TypeID.BOOLEAN;
            m_module = o.m_module;
            antlrNode = antlr;
            m_type = o.m_type;
        }
        public override bool Equals(object obj)
        {
            NullValue oth = obj as NullValue;
            if (oth == null)
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return "NULL";
        }

        public override List<bool> Encode()
        {
            List<bool> ret = new List<bool>();
            return ret;
        }

        public override string ToStringC()
        {
            return "0";
        }



        public bool Equals(NullValue other)
        {
            return true;
        }

    }

}
