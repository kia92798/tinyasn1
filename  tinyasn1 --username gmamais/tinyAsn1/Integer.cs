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

            if (SemanticAnalysisFinished())
            {
                int cnt = m_namedValues.Count;
                for (int i = 0; i < cnt; i++)
                {
                    for (int j = i + 1; j < cnt; j++)
                    {
                        if (m_namedValues.Values[i] == m_namedValues.Values[j])
                        {
                            throw new SemanticErrorException("Error in line:" + antlrNode.Line.ToString() +
                                " named number items: " + m_namedValues.Keys[i] + " and " + m_namedValues.Keys[j] + " have the same value(" + m_namedValues.Values[j] + ")");
                        }
                    }
                }
            }

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

        public override bool Compatible(Asn1Type other)
        {
            IntegerType o = other.GetFinalType() as IntegerType;
            if (o == null)
                return false;


            if (m_namedValues.Count != o.m_namedValues.Count)
                return false;

            foreach (string id in m_namedValues.Keys)
            {
                if (!o.m_namedValues.ContainsKey(id))
                    return false;

                if (m_namedValues[id] != o.m_namedValues[id])
                    return false;
            }

            return true;
        }


        private PERIntegerEffectiveConstraint m_perEffectiveConstraint = null;
        public override PEREffectiveConstraint PEREffectiveConstraint
        {
            get
            {
                if (m_perEffectiveConstraint != null)
                    return m_perEffectiveConstraint;
                m_perEffectiveConstraint = new PERIntegerEffectiveConstraint();
                m_perEffectiveConstraint = (PERIntegerEffectiveConstraint)m_perEffectiveConstraint.Compute(m_constraints, this);
                return m_perEffectiveConstraint;
            }
        }
        public override long maxBitsInPER(PEREffectiveConstraint cns)
        {
            PERIntegerEffectiveConstraint cn = (PERIntegerEffectiveConstraint)cns;
            if (cn == null) //unconstraint integer
                return (Config.IntegerSize + 1) * 8;

            if (cn.Extensible)
                return (Config.IntegerSize + 1) * 8;

            if (!cn.m_rootRange.m_minIsInfinite && !cn.m_rootRange.m_maxIsInfinite)
                return PER.GetNumberOfBitsForNonNegativeInteger((UInt64)(cn.m_rootRange.m_max - cn.m_rootRange.m_min));


            return (Config.IntegerSize + 1) * 8;
        }
        public override long minBitsInPER(PEREffectiveConstraint cns)
        {
            PERIntegerEffectiveConstraint cn = (PERIntegerEffectiveConstraint)cns;
            if (cn == null) //unconstraint integer
                return 16;
            if (cn.Extensible)
                return 16;

            if (!cn.m_rootRange.m_minIsInfinite && !cn.m_rootRange.m_maxIsInfinite)
                return PER.GetNumberOfBitsForNonNegativeInteger((UInt64)(cn.m_rootRange.m_max - cn.m_rootRange.m_min));


            return 16;
        }


    }



    public partial class IntegerValue : Asn1Value
    {
        Int64 m_value;
        public virtual Int64 Value
        {
            get { return m_value; }
            set { m_value = value; }
        }

        public IntegerValue(ITree antlrNode, Module module, Asn1Type type)
        {
            m_TypeID = Asn1Value.TypeID.INT;
            this.antlrNode = antlrNode;
            m_module = module;
            m_type = type;
            try
            {
                switch (antlrNode.Type)
                {
                    case asn1Parser.INT:
                        m_value = Int64.Parse(antlrNode.Text);
                        /*                        if (antlrNode.ChildCount == 1)
                                                    m_value = Int64.Parse(antlrNode.GetChild(0).Text);
                                                else if ((antlrNode.ChildCount == 2) && (antlrNode.GetChild(1).Text == "-"))
                                                    m_value = -Int64.Parse(antlrNode.GetChild(0).Text);
                                                else
                                                    throw new SemanticErrorException("Error in line : " + antlrNode.Line + " Expecting integer or integer variable");*/
                        break;
                    default:
                        throw new SemanticErrorException("Error in line : " + antlrNode.Line + ". Expecting integer or integer variable");
                }
            }
            catch (OverflowException)
            {
                throw new SemanticErrorException("Error in line : " + antlrNode.Line + ". Integer value is too large");
            }

            if (m_value > Config.MAXINT || m_value < Config.MININT)
                throw new SemanticErrorException("Error in line : " + antlrNode.Line + ". Integer value (" + m_value + ") is too large and can be supported in the target platform");
        }
        public IntegerValue(IntegerValue o, ITree antlr)
        {
            antlrNode = antlr;
            m_TypeID = Asn1Value.TypeID.INT;
            m_value = o.m_value;
            m_module = o.m_module;
            m_type = o.m_type;
        }

        public IntegerValue(Int64 val, Module m, ITree antlr, Asn1Type type)
        {
            m_TypeID = Asn1Value.TypeID.INT;
            m_value = val;
            m_module = m;
            antlrNode = antlr;
            m_type = type;
        }
        public override string ToString()
        {
            return Value.ToString();
        }

        public override bool Equals(object obj)
        {
            IntegerValue oth = obj as IntegerValue;
            if (oth == null)
                return false;
            return oth.m_value == m_value;
        }

        public override int GetHashCode()
        {
            return m_value.GetHashCode();
        }
        public override int CompareTo(object obj)
        {
            IntegerValue oth = obj as IntegerValue;
            if (oth == null)
                throw new ArgumentException("obj is not an IntegerValue");
            return Value.CompareTo(oth.Value);
        }
 
        public override  List<bool> Encode()
        {
            List<bool> ret = new List<bool>();
            PERIntegerEffectiveConstraint cn = (PERIntegerEffectiveConstraint)Type.PEREffectiveConstraint;
            if (cn == null) //unconstraint integer
            {
                ret = PER.EncodeUnConstraintWholeNumber(Value);
            }
            else
            {
                if (cn.Extensible)
                {
                    if (cn.m_extRange != null && cn.m_extRange.isValueWithinRange(Value))
                    {
                        ret.Add(true);
                        ret.AddRange(PER.EncodeUnConstraintWholeNumber(Value));
                        return ret;
                    }
                    else
                        ret.Add(false);
                } 


                if (!cn.m_rootRange.m_minIsInfinite && !cn.m_rootRange.m_maxIsInfinite)
                    ret.AddRange(PER.EncodeConstraintWholeNumber(Value, cn.m_rootRange.m_min, cn.m_rootRange.m_max));
                else if (!cn.m_rootRange.m_minIsInfinite && cn.m_rootRange.m_maxIsInfinite)
                    ret.AddRange(PER.EncodeSemiConstraintWholeNumber(Value, cn.m_rootRange.m_min));
                else
                    ret.AddRange(PER.EncodeUnConstraintWholeNumber(Value));

            }
            return ret;
        }

    }



}