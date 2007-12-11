using System;
using System.Collections.Generic;
using System.Text;
using Antlr.Runtime.Tree;
using Antlr.Runtime;

namespace tinyAsn1
{
    public partial class IA5StringType : Asn1Type
    {
        public override string Name
        {
            get { return "IA5String"; }
        }

        public override Asn1Type.Tag UniversalTag
        {
            get
            {
                return new Tag(Tag.TagClass.UNIVERSAL, 22, TaggingMode.EXPLICIT, this);
            }
        }

        internal override Asn1Value ResolveVariable(Asn1Value val)
        {
            string referenceId = "";
            switch (val.antlrNode.Type)
            {
                case asn1Parser.StringLiteral:
                    return new IA5StringValue(val.antlrNode, m_module, this);
                case asn1Parser.VALUE_REFERENCE:
                    referenceId = val.antlrNode.GetChild(0).Text;
                    if (m_module.isValueDeclared(referenceId))
                    {
                        Asn1Value tmp = m_module.GetValue(referenceId);
                        switch (tmp.m_TypeID)
                        {
                            case Asn1Value.TypeID.IA5String:
                                return new IA5StringValue(tmp as IA5StringValue, val.antlrNode.GetChild(0));
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
                    throw new SemanticErrorException("Error in line : " + val.antlrNode.Line + ". Expecting string constant or string variable reference");
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
                asn1Parser.INTERSECTION_ELEMENT, asn1Parser.VALUE_RANGE_EXPR, asn1Parser.SUBTYPE_EXPR, asn1Parser.SIZE_EXPR, asn1Parser.PERMITTED_ALPHABET_EXPR});
        static List<int> m_stopList = new List<int>(new int[] { asn1Parser.VALUE_RANGE_EXPR, asn1Parser.SUBTYPE_EXPR, asn1Parser.SIZE_EXPR, asn1Parser.PERMITTED_ALPHABET_EXPR, asn1Parser.EXCEPTION_SPEC });

        protected override IEnumerable<int> AllowedTokensInConstraints
        {
            get
            {
                if (m_IamUsedInPermittedAlphabet)
                    return m_allowedTokensPA;
                return m_allowedTokens;
            }
        }
        protected override IEnumerable<int> StopTokensInConstraints
        {
            get
            {
                if (m_IamUsedInPermittedAlphabet)
                    return m_stopListPA;
                return m_stopList;
            }
        }


        private bool m_IamUsedInPermittedAlphabet = false;

        public bool IamUsedInPermittedAlphabet
        {
            get { return m_IamUsedInPermittedAlphabet; }
            set { m_IamUsedInPermittedAlphabet = value; }
        }
        static List<int> m_allowedTokensPA = new List<int>(new int[]{ asn1Parser.CONSTRAINT, asn1Parser.EXCEPTION_SPEC, asn1Parser.EXT_MARK, 
                asn1Parser.UNION_SET, asn1Parser.UNION_SET_ALL_EXCEPT, asn1Parser.INTERSECTION_SET,
                asn1Parser.INTERSECTION_ELEMENT, asn1Parser.VALUE_RANGE_EXPR});
        static List<int> m_stopListPA = new List<int>(new int[] { asn1Parser.VALUE_RANGE_EXPR });

        public virtual IA5StringType CreateForPA(Module mod, ITree antrl)
        {
            IA5StringType ret = new IA5StringType();
            ret.m_IamUsedInPermittedAlphabet = true;
            ret.m_module = mod;
            ret.antlrNode = antrl;
            return ret;
        }
        public override void checkConstraintsSemantically(ITree antrlConstraint)
        {
            if (!IamUsedInPermittedAlphabet)
                base.checkConstraintsSemantically(antrlConstraint);
            else
            {
                AntlrTreeVisitor visit = new AntlrTreeVisitor();


                visit.visitIfNot(antrlConstraint, AllowedTokensInConstraints, delegate(ITree root)
                {
                    throw new SemanticErrorException("Error1 in Line:" + root.Line + ", col:" + root.CharPositionInLine +
                        " . This type of constraint '" + root.Text + "' cannot appear under " + Name);
                },
                    StopTokensInConstraints);
            }
        }
    }

    public partial class NumericStringType : IA5StringType
    {
        public override string Name
        {
            get { return "NumericString"; }
        }

        public override Asn1Type.Tag UniversalTag
        {
            get
            {
                return new Tag(Tag.TagClass.UNIVERSAL, 18, TaggingMode.EXPLICIT, this);
            }
        }

        internal override Asn1Value ResolveVariable(Asn1Value val)
        {
            string referenceId = "";
            switch (val.antlrNode.Type)
            {
                case asn1Parser.StringLiteral:
                    return new NumericStringValue(val.antlrNode, m_module, this);
                case asn1Parser.VALUE_REFERENCE:
                    referenceId = val.antlrNode.GetChild(0).Text;
                    if (m_module.isValueDeclared(referenceId))
                    {
                        Asn1Value tmp = m_module.GetValue(referenceId);
                        switch (tmp.m_TypeID)
                        {
                            case Asn1Value.TypeID.NumericString:
                                return new NumericStringValue(tmp as NumericStringValue, val.antlrNode.GetChild(0));
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
                    throw new SemanticErrorException("Error in line : " + val.antlrNode.Line + ". Expecting NumericString constant or NumericString variable reference");
            }
        }
        public override IA5StringType CreateForPA(Module mod, ITree antrl)
        {
            NumericStringType ret = new NumericStringType();
            ret.IamUsedInPermittedAlphabet = true;
            ret.m_module = mod;
            ret.antlrNode = antrl;
            return ret;
        }
    }


    public partial class IA5StringValue : Asn1Value, ISize, ICharacterString
    {
        protected string m_value;
        public string Value
        {
            get { return m_value; }
        }

        public override string ToString()
        {
            return "\"" + Value + "\"";
        }

        public IA5StringValue(ITree tree, Module mod, Asn1Type type)
        {
            m_TypeID = Asn1Value.TypeID.IA5String;
            m_module = mod;
            antlrNode = tree;
            m_type = type;

            if (antlrNode.Type != asn1Parser.StringLiteral)
                throw new Exception("INTERNAL ERROR");

            m_value = antlrNode.Text;
            if (m_value == null)
                m_value = "";

            m_value = m_value.Replace("\"\"", "\"");
            if (m_value.StartsWith("\""))
                m_value = m_value.Substring(1);
            if (m_value.EndsWith("\""))
                m_value = m_value.Substring(0, m_value.Length - 1);

        }


        public IA5StringValue(IA5StringValue o, ITree antlr)
        {
            m_TypeID = Asn1Value.TypeID.IA5String;
            m_module = o.m_module;
            antlrNode = antlr;
            m_value = o.m_value;
            m_type = o.m_type;
        }
        public override bool Equals(object obj)
        {
            IA5StringValue oth = obj as IA5StringValue;
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
            get { return Value.Length; }
        }


        public override int CompareTo(object obj)
        {
            IA5StringValue oth = obj as IA5StringValue;
            if (oth == null)
                throw new ArgumentException("obj is not an IA5StringValue");
            return Value.CompareTo(oth.Value);
        }
        public IA5StringValue(Char str)
        {
            m_TypeID = Asn1Value.TypeID.IA5String;
            m_value = str.ToString();
        }
    }

    public partial class NumericStringValue : IA5StringValue
    {
        static Char[] AllowedCharSet = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ' ' };

        public NumericStringValue(ITree tree, Module mod, Asn1Type type)
            : base(tree, mod, type)
        {
            m_TypeID = Asn1Value.TypeID.NumericString;
            List<Char> acs = new List<char>(AllowedCharSet);
            m_value = m_value.Replace("\r", "").Replace("\n", "").Replace("\t", "").Replace(" ", "");
            foreach (Char ch in Value.ToCharArray())
                if (!acs.Contains(ch))
                    throw new SemanticErrorException("Error in line: " + antlrNode.Line + ", col: " + antlrNode.CharPositionInLine + ". Character: '" + ch + "' can not be contained in a Numeric string");
        }
        public NumericStringValue(NumericStringValue o, ITree antlr)
            : base(o, antlr)
        {
            m_TypeID = Asn1Value.TypeID.NumericString;
        }
    }


}
