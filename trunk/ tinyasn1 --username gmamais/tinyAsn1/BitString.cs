using System;
using System.Collections.Generic;
using System.Text;
using Antlr.Runtime.Tree;
using Antlr.Runtime;

namespace tinyAsn1
{
    public partial class BitStringType : Asn1Type
    {
        internal List<NumberedItem> m_namedBitsPriv = new List<NumberedItem>();
        public OrderedDictionary<string, Int64> m_namedBits = new OrderedDictionary<string, Int64>();
        public override string Name
        {
            get { return "BIT STRING"; }
        }

        public override Asn1Type.Tag UniversalTag
        {
            get
            {
                return new Tag(Tag.TagClass.UNIVERSAL, 3, TaggingMode.EXPLICIT, this);
            }
        }

        static public new BitStringType CreateFromAntlrAst(ITree tree)
        {
            BitStringType ret = new BitStringType();
            for (int i = 0; i < tree.ChildCount; i++)
            {
                ITree child = tree.GetChild(i);
                NumberedItem item = NumberedItem.CreateFromAntlrAst(child);
                //                if (ret.m_namedBitsPriv.ContainsKey(item.m_id))
                //                    throw new SemanticErrorException(item.m_id + " has alrady been defined. Line: " + child.Line);

                ret.m_namedBitsPriv.Add(item);
            }


            return ret;
        }

        internal override bool SemanticAnalysisFinished()
        {
            if (m_namedBitsPriv.Count > 0)
                return false;

            return base.SemanticAnalysisFinished();
        }
        public override void DoSemanticAnalysis()
        {
            base.DoSemanticAnalysis();
            List<NumberedItem> toBeRemoved = new List<NumberedItem>();
            foreach (NumberedItem ni in m_namedBitsPriv)
            {
                if (m_namedBits.ContainsKey(ni.m_id))
                    throw new SemanticErrorException("The BIT STRING type defined in line " + antlrNode.Line +
                        " containts more than once the identifier " + ni.m_id);

                if (ni.m_valueAsInt != null)
                {
                    if (ni.m_valueAsInt.Value < 0)
                        throw new SemanticErrorException("Error in line : " + antlrNode.Line + ". Bit string ids must be no negative numbers");
                    m_namedBits.Add(ni.m_id, ni.m_valueAsInt.Value);
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
                            Int64 val = ((IntegerValue)tmpVal).Value;
                            if (val < 0)
                                throw new SemanticErrorException("Error in line : " + antlrNode.Line + ". Identifier '" + refName + "' is a negative integer");
                            m_namedBits.Add(ni.m_id, val);
                            toBeRemoved.Add(ni);
                        }
                        else
                        {
                            throw new SemanticErrorException("Error in line : " + antlrNode.Line + ". Identifier '" + refName + "' is not an integer");
                        }
                        //else let it be resolved in a next parse round
                    }
                    else
                        throw new SemanticErrorException("Error in line : " + antlrNode.Line + ". Identifier '" + refName + "' is unknown");
                }

            }
            foreach (NumberedItem ni in toBeRemoved)
                m_namedBitsPriv.Remove(ni);
        }

        internal override Asn1Value ResolveVariable(Asn1Value val)
        {
            string referenceId = "";
            switch (val.antlrNode.Type)
            {
                case asn1Parser.BitStringLiteral:
                case asn1Parser.OctectStringLiteral:
                    return new BitStringValue(val.antlrNode, m_module, this);

                case asn1Parser.OBJECT_ID_VALUE: // There is case { id } that the parser thinks that this a OBJECT ID value
                    // although it should handled as VALUE_LIST
                    if (!SemanticAnalysisFinished())
                        return val;
                    if (val.antlrNode.ChildCount != 1)
                        throw new SemanticErrorException("Error in line : " + val.antlrNode.Line + ". Expecting BIT STRING constant or BIT STRING variable");
                    ITree objLstItem = val.antlrNode.GetChild(0);
                    if (objLstItem.ChildCount != 1)
                        throw new SemanticErrorException("Error in line : " + val.antlrNode.Line + ". Expecting BIT STRING constant or BIT STRING variable");
                    ITree identifier = objLstItem.GetChild(0);

                    if (identifier.Type != asn1Parser.LID)
                        throw new SemanticErrorException("Error in line: " + identifier.Line + ", col: " + identifier.CharPositionInLine + ". Expecting identifier");
                    else
                    {
                        string id = identifier.Text;
                        if (!m_namedBits.ContainsKey(id))
                            throw new SemanticErrorException("Error in line: " + identifier.Line + ", col: " + identifier.CharPositionInLine + ". Unknown identifier '" + id + ",");

                        List<Int64> ids = new List<Int64>();
                        ids.Add(m_namedBits[id]);
                        return new BitStringValue(ids, val.antlrNode, m_module, this);
                    }


                //To resolve another grammar Ambiguouity, we no more declare bitStringValue. 
                //The parser will only return valueList. 
                //Therefore, we must make sure that all values are identifiers
                //case asn1Parser.BIT_STRING_VALUE: // { id, id2, id3}
                case asn1Parser.VALUE_LIST: // { val1, val2, val3}
                    {
                        if (!SemanticAnalysisFinished())
                            return val;
                        List<Int64> ids = new List<Int64>();
                        for (int i = 0; i < val.antlrNode.ChildCount; i++)
                        {
                            ITree child = val.antlrNode.GetChild(i);
                            string id;
                            if (child.Type == asn1Parser.LID)
                                id = child.Text;
                            else if (child.Type == asn1Parser.VALUE_REFERENCE)
                                id = child.GetChild(0).Text;
                            else
                                throw new SemanticErrorException("Error in line: " + child.Line + ", col: " + child.CharPositionInLine + ". Expecting identifier");
                            if (!m_namedBits.ContainsKey(id))
                                throw new SemanticErrorException("Error in line: " + child.Line + ", col: " + child.CharPositionInLine + ". Unknown identifier '" + id + ",");

                            ids.Add(m_namedBits[id]);
                        }
                        return new BitStringValue(ids, val.antlrNode, m_module, this);
                    }
                case asn1Parser.VALUE_REFERENCE:
                    referenceId = val.antlrNode.GetChild(0).Text;
                    if (m_module.isValueDeclared(referenceId))
                    {
                        Asn1Value tmp = m_module.GetValue(referenceId);
                        switch (tmp.m_TypeID)
                        {
                            case Asn1Value.TypeID.BIT_STRING:
                                return new BitStringValue(tmp as BitStringValue, val.antlrNode.GetChild(0));
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
                    throw new SemanticErrorException("Error in line : " + val.antlrNode.Line + ". Expecting BIT STRING constant or BIT STRING variable");
            }
        }

        static List<int> m_allowedTokens = new List<int>(new int[]{ asn1Parser.CONSTRAINT, asn1Parser.EXCEPTION_SPEC, asn1Parser.EXT_MARK, 
                asn1Parser.UNION_SET, asn1Parser.UNION_SET_ALL_EXCEPT, asn1Parser.INTERSECTION_SET,
                asn1Parser.INTERSECTION_ELEMENT, asn1Parser.VALUE_RANGE_EXPR, asn1Parser.SUBTYPE_EXPR, asn1Parser.SIZE_EXPR});
        static List<int> m_stopList = new List<int>(new int[] { asn1Parser.VALUE_RANGE_EXPR, asn1Parser.SUBTYPE_EXPR, asn1Parser.SIZE_EXPR });

        protected override IEnumerable<int> AllowedTokensInConstraints { get { return m_allowedTokens; } }
        protected override IEnumerable<int> StopTokensInConstraints { get { return m_stopList; } }


        public override void PrintAsn1(StreamWriterLevel o, int lev)
        {
            if (m_tag != null)
                m_tag.PrintAsn1(o, lev);
            if (m_namedBits.Count > 0)
            {
                o.WriteLine("BIT STRING {");
                int cnt = m_namedBits.Count;
                for (int i = 0; i < m_namedBits.Count - 1; i++)
                {
                    o.P(lev + 1);
                    o.WriteLine(m_namedBits.Keys[i] + "(" + m_namedBits.Values[i] + "),");
                }
                o.P(lev + 1);
                o.WriteLine(m_namedBits.Keys[cnt - 1] + "(" + m_namedBits.Values[cnt - 1] + ")");

                o.P(lev); o.Write("}");
            }
            else
                o.Write(" BIT STRING");
            PrintAsn1Constraints(o);
        }
    }
}
