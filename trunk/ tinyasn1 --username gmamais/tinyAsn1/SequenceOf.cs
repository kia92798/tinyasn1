using System;
using System.Collections.Generic;
using System.Text;
using Antlr.Runtime.Tree;
using Antlr.Runtime;

namespace tinyAsn1
{
    public partial class SequenceOfType : ArrayType
    {
        public override string Name
        {
            get { return "SEQUENCE OF"; }
        }

        public override Asn1Type.Tag UniversalTag
        {
            get
            {
                return new Tag(Tag.TagClass.UNIVERSAL, 16, TaggingMode.EXPLICIT, this);
            }
        }

        //^(SEQUENCE_OF_TYPE (SIMPLIFIED_SIZE_CONSTRAINT $sz)? $gen? identifier? type)
        static public new SequenceOfType CreateFromAntlrAst(ITree tree)
        {

            SequenceOfType ret = new SequenceOfType();
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
            SequenceOfValue sqVal = val as SequenceOfValue;
            switch (val.antlrNode.Type)
            {
                case asn1Parser.VALUE_LIST:
                case asn1Parser.OBJECT_ID_VALUE:    //for catching case {valref} or {23}
                    if (sqVal == null)
                        return new SequenceOfValue(val.antlrNode, m_module, this);
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
                            case Asn1Value.TypeID.SEQUENCE_OF:
                                if (tmp.IsResolved())
                                {
                                    if (tmp.Type.GetFinalType() == this)
                                        return new SequenceOfValue(tmp as SequenceOfValue, val.antlrNode.GetChild(0));
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
                    throw new SemanticErrorException("Error in line : " + val.antlrNode.Line + ". Expecting SEQUENCE OF variable");
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
            SequenceOfValue v = val as SequenceOfValue;
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
            o.Write("SEQUENCE");
            PrintAsn1Constraints(o);
            o.Write(" OF ");
            m_type.PrintAsn1(o, lev);
        }

    }

    public partial class SequenceOfValue : ArrayValue, ISize
    {
        public SequenceOfType Type2
        {
            get
            {
                return (SequenceOfType)Type;
            }
        }

        public override bool IsResolved()
        {
            foreach (Asn1Value v in m_children)
                if (!v.IsResolved())
                    return false;

            return true;
        }

        public SequenceOfValue(SequenceOfValue o, ITree antlr)
        {
            m_TypeID = Asn1Value.TypeID.SEQUENCE_OF;
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

            w.Write(m_children[cnt - 1].ToString() + " }");

            w.Flush();
            return w.ToString();
        }

        public SequenceOfValue(ITree antlrNode, Module module, Asn1Type type)
        {
            m_TypeID = Asn1Value.TypeID.SEQUENCE_OF;
            this.antlrNode = antlrNode;
            m_module = module;
            m_type = type;

            if (antlrNode.Type == asn1Parser.VALUE_LIST)
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
                {
                    val = Asn1Value.CreateFromAntlrAst(grandChild);
                }
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
                throw new Exception("Internal Error: SequenceOfValue called with wrong antlr node type");


        }

        public override bool Equals(object obj)
        {
            SequenceOfValue oth = obj as SequenceOfValue;
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




        public long Size
        {
            get { return m_children.Count; }
        }


    }

}
