/**=============================================================================
Definition of SetOfType class
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
    /// Represents the ASN.1 type SET OF
    /// Please also refer to base class ArrayType
    /// </summary>
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
                return DefaultBackend.Instance.Factory.CreateAsn1TypeTag(Tag.TagClass.UNIVERSAL, 17, TaggingMode.EXPLICIT, this);
            }
        }

        static public new SetOfType CreateFromAntlrAst(ITree tree)
        {
            SetOfType ret = DefaultBackend.Instance.Factory.CreateSetOfType();
            for (int i = 0; i < tree.ChildCount; i++)
            {
                ITree child = tree.GetChild(i);
                switch (child.Type)
                {
                    case asn1Parser.SIMPLIFIED_SIZE_CONSTRAINT:
                    case asn1Parser.CONSTRAINT:
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
                case asn1Parser.EMPTY_LIST:
                case asn1Parser.VALUE_LIST:
                case asn1Parser.OBJECT_ID_VALUE: //for catching case {valref} or {23}
                    if (sqVal == null)
                        return DefaultBackend.Instance.Factory.CreateSetOfValue(val.antlrNode, m_module, this);
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
                                        return DefaultBackend.Instance.Factory.CreateSetOfValue(tmp as SetOfValue, val.antlrNode.GetChild(0));
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

            foreach (Asn1Value item in v.Value)
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
        public override bool Compatible(Asn1Type other)
        {
            SetOfType o = other.GetFinalType() as SetOfType;
            if (o == null)
                return false;

            return base.Compatible(other);
        }
    }

    public partial class SetOfValue : ArrayValue
    {
        public SetOfType Type2
        {
            get
            {
                return (SetOfType)Type.GetFinalType();
            }
        }

        public override bool IsResolved()
        {
            foreach (Asn1Value v in m_children)
                if (!v.IsResolved())
                    return false;

            return true;
        }

        public SetOfValue(SetOfValue o, ITree antlr)
        {
            m_TypeID = Asn1Value.TypeID.SET_OF;
            m_module = o.m_module;
            antlrNode = antlr;
            m_type = o.m_type;
            m_children = o.m_children;
        }

        internal void FixChildrenVars()
        {
            for (int i = 0; i < m_children.Count; i++)
            {
                Asn1Value childVal = m_children[i];
                if (childVal.IsResolved())
                    continue;

                Asn1Type childType = Type2.m_type;
                m_children[i] = childType.ResolveVariable(childVal);
            }

            //check if a value exists twice in the set
            int cnt = m_children.Count;
            for (int i = 0; i < cnt; i++)
            {
                for (int j = i + 1; j < cnt; j++)
                {
                    if (m_children[i].Equals(m_children[j]))
                        throw new SemanticErrorException("Error: SET declared in line :" + antlrNode.Line + " contains value :" + m_children[i].ToString() + " more than once");
                }
            }

        }


        public override string ToString()
        {

            System.IO.StringWriter w = new System.IO.StringWriter();

            w.Write("{");
            int cnt = m_children.Count;
            for (int i = 0; i < cnt - 1; i++)
            {
                w.Write(" " + m_children[i].ToString() + ",");
            }

            if (cnt-1>=0)
                w.Write(m_children[cnt - 1].ToString());
            w.Write(" }");

            w.Flush();
            return w.ToString();
        }
        public SetOfValue(ITree antlrNode, Module module, Asn1Type type)
        {
            m_TypeID = Asn1Value.TypeID.SET_OF;
            this.antlrNode = antlrNode;
            m_module = module;
            m_type = type;

            if (antlrNode.Type == asn1Parser.VALUE_LIST || antlrNode.Type == asn1Parser.EMPTY_LIST)
            {
                for (int i = 0; i < antlrNode.ChildCount; i++)
                {
                    Asn1Value val = Asn1Value.CreateFromAntlrAst(antlrNode.GetChild(i));

                    m_children.Add(val);
                }
            }
            else if (antlrNode.Type == asn1Parser.OBJECT_ID_VALUE)
            {
                //we expect only one child either INT or identifier
                if (antlrNode.ChildCount != 1)
                    throw new SemanticErrorException("Error in line:" + antlrNode.Line + " col:" + antlrNode.CharPositionInLine + ". Expecting SEQUENCE OF value");
                if (antlrNode.GetChild(0).ChildCount != 1)
                    throw new SemanticErrorException("Error in line:" + antlrNode.Line + " col:" + antlrNode.CharPositionInLine + ". Expecting SEQUENCE OF value");
                ITree grandChild = antlrNode.GetChild(0).GetChild(0);

                Asn1Value val;
                if (grandChild.Type == asn1Parser.INT)
                    val = Asn1Value.CreateFromAntlrAst(grandChild);
                else if (grandChild.Type == asn1Parser.LID)
                {
                    SemanticTreeNode nodeValue;
                    nodeValue = new SemanticTreeNode(grandChild.CharPositionInLine, grandChild.Line, grandChild.Text, asn1Parser.VALUE_REFERENCE);
                    nodeValue.AddChild(grandChild);
                    val = Asn1Value.CreateFromAntlrAst(nodeValue);
                }
                else
                    throw new Exception("Internal Error");

                m_children.Add(val);


            }
            else
                throw new Exception("Internal Error: SetOfValue called with wrong antlr node type");



        }

        public override bool Equals(object obj)
        {
            SetOfValue oth = obj as SetOfValue;
            if (oth == null)
                return false;
            if (oth.m_children.Count != m_children.Count)
                return false;

            for (int i = 0; i < m_children.Count; i++)
            {
                if (!m_children[i].Equals(oth.m_children[i]))
                    return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            return m_children.GetHashCode();
        }

    }

}
