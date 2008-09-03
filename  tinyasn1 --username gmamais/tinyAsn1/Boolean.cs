/**=============================================================================
BooleanType and BooleanValue class definitions
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
                return DefaultBackend.Instance.Factory.CreateAsn1TypeTag(Tag.TagClass.UNIVERSAL, 1, TaggingMode.EXPLICIT, this);
            }
        }

        internal override Asn1Value ResolveVariable(Asn1Value val)
        {
            string referenceId = "";
            switch (val.antlrNode.Type)
            {
                case asn1Parser.TRUE:
                case asn1Parser.FALSE:
                    return DefaultBackend.Instance.Factory.CreateBooleanValue(val.antlrNode, m_module, this);
                case asn1Parser.VALUE_REFERENCE:
                    referenceId = val.antlrNode.GetChild(0).Text;
                    if (m_module.isValueDeclared(referenceId))
                    {
                        Asn1Value tmp = m_module.GetValue(referenceId);
                        switch (tmp.m_TypeID)
                        {
                            case Asn1Value.TypeID.BOOLEAN:
                                return DefaultBackend.Instance.Factory.CreateBooleanValue(tmp as BooleanValue, val.antlrNode.GetChild(0));
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

        static List<BooleanValue> _UniverseSet = new List<BooleanValue>();

        public IEnumerable<BooleanValue> UniverseValues
        {
            get
            {
                if (_UniverseSet.Count == 0)
                {
                    _UniverseSet.Add(new BooleanValue(true));
                    _UniverseSet.Add(new BooleanValue(false));
                }
                return _UniverseSet;
            }
        }

        public override ISet GetSet(Asn1Value val)
        {
            DiscreetValueSetWithFiniteUniverse<BooleanValue> ret = new DiscreetValueSetWithFiniteUniverse<BooleanValue>(UniverseValues);

            ret.AddValue((BooleanValue)val);

            return ret;
        }

    }

    public partial class BooleanValue : Asn1Value, IEquatable<BooleanValue>
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

        internal BooleanValue(bool value) { m_value = value; }

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


        public bool Equals(BooleanValue other)
        {
            return m_value == other.m_value;
        }

    }

}
