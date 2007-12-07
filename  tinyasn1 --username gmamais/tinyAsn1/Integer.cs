using System;
using System.Collections.Generic;
using System.Text;
using Antlr.Runtime.Tree;
using Antlr.Runtime;

namespace tinyAsn1
{

    public partial class IntegerType : Asn1Type
    {
        internal List<NumberedItem> m_privNamedValues = new List<NumberedItem>();
        public OrderedDictionary<string, Int64> m_namedValues = new OrderedDictionary<string, Int64>();

        public override string Name
        {
            get { return "INTEGER"; }
        }

        public override Asn1Type.Tag UniversalTag
        {
            get
            {
                return new Tag(Tag.TagClass.UNIVERSAL, 2, TaggingMode.EXPLICIT, this);
            }
        }

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
                case asn1Parser.INT:
                    return new IntegerValue(val.antlrNode, m_module, this);
                case asn1Parser.VALUE_REFERENCE:
                    referenceId = val.antlrNode.GetChild(0).Text;
                    if (m_module.isValueDeclared(referenceId))
                    {
                        Asn1Value tmp = m_module.GetValue(referenceId);
                        switch (tmp.m_TypeID)
                        {
                            case Asn1Value.TypeID.INT:
                                return new IntegerValue(tmp as IntegerValue, val.antlrNode.GetChild(0));
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
            //if (nNumberOfUnresolvedVarsInConstraints > 0)
            //    return false;
            return base.SemanticAnalysisFinished();
        }

        public override void DoSemanticAnalysis()
        {
            base.DoSemanticAnalysis();
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

//            SemanticCheckConstraints();
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
        

        public override void PrintAsn1(StreamWriterLevel o, int lev)
        {
            if (m_tag != null)
                m_tag.PrintAsn1(o, lev);
            if (m_namedValues.Count > 0)
            {
                o.WriteLine("INTEGER {");
                int cnt = m_namedValues.Count;
                for (int i = 0; i < m_namedValues.Count - 1; i++)
                {
                    o.P(lev + 1);
                    o.WriteLine(m_namedValues.Keys[i] + "(" + m_namedValues.Values[i] + "),");
                }
                o.P(lev + 1);
                o.WriteLine(m_namedValues.Keys[cnt - 1] + "(" + m_namedValues.Values[cnt - 1] + ")");
                o.P(lev);
                o.Write("}");
            }
            else
                o.Write("INTEGER ");

            PrintAsn1Constraints(o);

        }
    }




}