using System;
using System.Collections.Generic;
using System.Text;
using Antlr.Runtime.Tree;
using Antlr.Runtime;

namespace tinyAsn1
{
    public partial class OctetStringType : Asn1Type
    {
        public override string Name
        {
            get { return "OCTECT STRING"; }
        }

        public override Asn1Type.Tag UniversalTag
        {
            get
            {
                return new Tag(Tag.TagClass.UNIVERSAL, 4, TaggingMode.EXPLICIT, this);
            }
        }

        internal override Asn1Value ResolveVariable(Asn1Value val)
        {
            string referenceId = "";
            switch (val.antlrNode.Type)
            {
                case asn1Parser.BitStringLiteral:
                case asn1Parser.OctectStringLiteral:
                    return new OctectStringValue(val.antlrNode, m_module, this);
                case asn1Parser.VALUE_REFERENCE:
                    referenceId = val.antlrNode.GetChild(0).Text;
                    if (m_module.isValueDeclared(referenceId))
                    {
                        Asn1Value tmp = m_module.GetValue(referenceId);
                        switch (tmp.m_TypeID)
                        {
                            case Asn1Value.TypeID.OCTECT_STRING:
                                return new OctectStringValue(tmp as OctectStringValue, val.antlrNode.GetChild(0));
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
                    throw new SemanticErrorException("Error in line : " + val.antlrNode.Line + ". Expecting OCTECT STRING constant or OCTECT STRING variable");
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
        static List<int> m_allowedTokens = new List<int>(new int[]{ asn1Parser.CONSTRAINT, asn1Parser.EXCEPTION_SPEC, asn1Parser.EXT_MARK, 
                asn1Parser.UNION_SET, asn1Parser.UNION_SET_ALL_EXCEPT, asn1Parser.INTERSECTION_SET,
                asn1Parser.INTERSECTION_ELEMENT, asn1Parser.VALUE_RANGE_EXPR, asn1Parser.SUBTYPE_EXPR, asn1Parser.SIZE_EXPR});
        static List<int> m_stopList = new List<int>(new int[] { asn1Parser.VALUE_RANGE_EXPR, asn1Parser.SUBTYPE_EXPR, asn1Parser.SIZE_EXPR });

        protected override IEnumerable<int> AllowedTokensInConstraints { get { return m_allowedTokens; } }
        protected override IEnumerable<int> StopTokensInConstraints { get { return m_stopList; } }

    }


    public partial class OctectStringValue : Asn1Value, ISize
    {
        static Dictionary<string, byte> lookup = new Dictionary<string, byte>();
        static OctectStringValue()
        {
            lookup.Add("0000", 0x0);
            lookup.Add("0001", 0x1);
            lookup.Add("0010", 0x2);
            lookup.Add("0011", 0x3);
            lookup.Add("0100", 0x4);
            lookup.Add("0101", 0x5);
            lookup.Add("0110", 0x6);
            lookup.Add("0111", 0x7);
            lookup.Add("1000", 0x8);
            lookup.Add("1001", 0x9);
            lookup.Add("1010", 0xA);
            lookup.Add("1011", 0xB);
            lookup.Add("1100", 0xC);
            lookup.Add("1101", 0xF);
            lookup.Add("1110", 0xE);
            lookup.Add("1111", 0xF);
        }
        List<byte> m_value = new List<byte>();
        public List<byte> Value
        {
            get { return m_value; }
        }

        public override string ToString()
        {
            string ret = "";
            foreach (byte b in Value)
                ret += b.ToString("X2");
            return ret;
        }

        public OctectStringValue(ITree tree, Module mod, Asn1Type type)
        {
            m_TypeID = Asn1Value.TypeID.OCTECT_STRING;
            m_module = mod;
            antlrNode = tree;
            m_type = type;

            BitStringValue tmp = new BitStringValue(tree, mod, type);
            string bitString = tmp.Value;
            int nBitsToInsert = 0;
            if (bitString.Length % 4 > 0)
                nBitsToInsert = 4 - bitString.Length % 4;
            else
                nBitsToInsert = 0;

            for (int i = 0; i < nBitsToInsert; i++)
                bitString += "0";

            List<byte> nibles = new List<byte>();
            while (bitString.Length > 0)
            {
                string nible = bitString.Substring(0, 4);
                nibles.Add(lookup[nible]);
                bitString = bitString.Substring(4);
            }
            if (nibles.Count % 2 != 0)
                nibles.Insert(0, 0);

            while (nibles.Count > 0)
            {
                byte curByte = (byte)(nibles[0] << 4);
                curByte |= nibles[1];
                m_value.Add(curByte);
                nibles.RemoveAt(0);
                nibles.RemoveAt(0);
            }
        }


        public OctectStringValue(OctectStringValue o, ITree antlr)
        {
            m_TypeID = Asn1Value.TypeID.OCTECT_STRING;
            m_module = o.m_module;
            antlrNode = antlr;
            m_value.Clear();
            m_value.AddRange(o.m_value);
            m_type = o.m_type;
        }
        public override bool Equals(object obj)
        {
            OctectStringValue oth = obj as OctectStringValue;
            if (oth == null)
                return false;
            return oth.m_value == m_value;
        }

        public override int GetHashCode()
        {
            return m_value.GetHashCode();
        }


        public long Size
        {
            get { return Value.Count; }
        }

    }

}
