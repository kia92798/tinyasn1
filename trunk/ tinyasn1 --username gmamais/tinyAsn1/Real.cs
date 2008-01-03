using System;
using System.Collections.Generic;
using System.Text;
using Antlr.Runtime.Tree;
using Antlr.Runtime;
using System.Globalization;

namespace tinyAsn1
{
    public partial class RealType : Asn1Type
    {
        public override string Name
        {
            get { return "REAL"; }
        }

        public override Asn1Type.Tag UniversalTag
        {
            get
            {
                return new Tag(Tag.TagClass.UNIVERSAL, 9, TaggingMode.EXPLICIT, this);
            }
        }

        internal override Asn1Value ResolveVariable(Asn1Value val)
        {
            string referenceId = "";
            switch (val.antlrNode.Type)
            {
                case asn1Parser.INT:
                case asn1Parser.FloatingPointLiteral:
                case asn1Parser.MINUS_INFINITY:
                case asn1Parser.PLUS_INFINITY:
                    return new RealValue(val.antlrNode, m_module, this);

                case asn1Parser.NUMERIC_VALUE2: //e.g. {mantissa 2, base 10, exponent 0}
                    return new RealValue(val.antlrNode, m_module, this, 0);
                case asn1Parser.VALUE_REFERENCE:
                    referenceId = val.antlrNode.GetChild(0).Text;
                    if (m_module.isValueDeclared(referenceId))
                    {
                        Asn1Value tmp = m_module.GetValue(referenceId);
                        switch (tmp.m_TypeID)
                        {
                            case Asn1Value.TypeID.REAL:
                                return new RealValue(tmp as RealValue, val.antlrNode.GetChild(0));
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
                    throw new SemanticErrorException("Error in line : " + val.antlrNode.Line + ". Expecting REAL or REAL variable");
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
        static List<int> m_allowedTokens = new List<int>(new int[]{ asn1Parser.CONSTRAINT, asn1Parser.EXCEPTION_SPEC, asn1Parser.EXT_MARK, 
                asn1Parser.UNION_SET, asn1Parser.UNION_SET_ALL_EXCEPT, asn1Parser.INTERSECTION_SET,
                asn1Parser.INTERSECTION_ELEMENT, asn1Parser.VALUE_RANGE_EXPR, asn1Parser.SUBTYPE_EXPR, asn1Parser.WITH_COMPONENTS_CONSTR});
        static List<int> m_stopList = new List<int>(new int[] { asn1Parser.VALUE_RANGE_EXPR, asn1Parser.SUBTYPE_EXPR, asn1Parser.WITH_COMPONENTS_CONSTR, asn1Parser.EXCEPTION_SPEC });

        protected override IEnumerable<int> AllowedTokensInConstraints { get { return m_allowedTokens; } }
        protected override IEnumerable<int> StopTokensInConstraints { get { return m_stopList; } }

        public override bool Compatible(Asn1Type other)
        {
            RealType o = other.GetFinalType() as RealType;
            if (o == null)
                return false;

            return true;
        }
    }

    public partial class RealValue : Asn1Value
    {
        public class SqReal
        {
            public Int64 m_mantissa;
            public Int64 m_base;
            public Int64 m_exponent;
            public SqReal(double d, int newBase, Int64 minExp, Int64 maxMantissa)
            {
                if (d == 0.0 || double.IsInfinity(d))
                    throw new ArgumentOutOfRangeException();

                m_base = newBase;
                //Let mantissa be 1
                // then exponent is the logarithm of the input value.
                //However, since we need the expoent to be stored in an INT we get the Floor 
                // Floor return the largest integer less than or equal to the specified double-precision floating-point number
                m_exponent = (Int64)Math.Floor(Math.Log(Math.Abs(d), m_base));

                //Since exponent was 'Floored' mantissa is not 1 anymore but the following value
                // now mantissa has a value in the range [1..base)
                double mantissa = d / Math.Pow((double)m_base, (double)m_exponent);
                if (mantissa >= m_base)
                    throw new Exception("Mantissa(" + mantissa.ToString() + ") is greater or equal to base");

                while (m_exponent >= minExp)
                {
                    mantissa *= m_base;
                    m_exponent--;
                    if (mantissa - Math.Floor(mantissa) < Double.Epsilon)
                        break;
                    if (mantissa > maxMantissa)
                        break;
                }
                m_mantissa = (Int64)mantissa;
                if (d < 0)
                    m_mantissa = -m_mantissa;

            }
            
            public SqReal(double d, int newBase)
            {
                double maxMantissa = 4503599627370496;
                if (d == 0.0 || double.IsInfinity(d))
                    throw new ArgumentOutOfRangeException();

                m_base = newBase;
                //Let mantissa be 1
                // then exponent is the logarithm of the input value.
                //However, since we need the expoent to be stored in an INT we get the Floor 
                // Floor return the largest integer less than or equal to the specified double-precision floating-point number
                m_exponent = (Int64)Math.Floor(Math.Log(Math.Abs(d), m_base));

                //Since exponent was 'Floored' mantissa is not 1 anymore but the following value
                // now mantissa has a value in the range [1..base)
                double mantissa = d / Math.Pow((double)m_base, (double)m_exponent);
                if (mantissa >= m_base)
                    throw new Exception("Mantissa(" + mantissa.ToString() + ") is greater or equal to base");

                m_mantissa = (Int64)mantissa;
                if (d < 0)
                    m_mantissa = -m_mantissa;
                
                double error = Math.Abs(d - m_mantissa * Math.Pow((double)m_base, (double)m_exponent))/d;

                while (mantissa < maxMantissa && error > Double.Epsilon)
                {
                    mantissa *= m_base;
                    m_exponent--;
                    m_mantissa = (Int64)mantissa;
                    if (d < 0)
                        m_mantissa = -m_mantissa;
                    error = Math.Abs(d - m_mantissa * Math.Pow((double)m_base, (double)m_exponent)) / d;
                    if (mantissa - Math.Floor(mantissa) < Double.Epsilon)
                        break;
                }
                

            }
        }

        double m_value;
        public virtual double Value
        {
            get { return m_value; }
            set { m_value = value; }
        }


        public RealValue(ITree tree, Module module, Asn1Type type, int dummy)
        {
            m_TypeID = Asn1Value.TypeID.REAL;
            m_module = module;
            antlrNode = tree;
            m_type = type;

            int i = 0;
            double mantissa;
            double bas;
            double exp;

            try
            {
                mantissa = double.Parse(tree.GetChild(i).Text, NumberFormatInfo.InvariantInfo); i++;
                bas = double.Parse(tree.GetChild(i).Text, NumberFormatInfo.InvariantInfo); i++;
                exp = double.Parse(tree.GetChild(i).Text, NumberFormatInfo.InvariantInfo);
            }
            catch (OverflowException)
            {
                throw new SemanticErrorException("Error line:" + tree.GetChild(i).Line + " number('" + tree.GetChild(i) + "') is too large");
            }

            if (bas == 10 || bas == 2)
                m_value = mantissa * Math.Pow(bas, exp);
            else
                throw new SemanticErrorException("Error line:" + tree.GetChild(1).Line + ", col:" + tree.GetChild(1).CharPositionInLine +
                    " base must be 2 or 10");


        }

        public RealValue(ITree tree, Module module, Asn1Type type)
        {
            m_TypeID = Asn1Value.TypeID.REAL;
            m_module = module;
            antlrNode = tree;
            m_type = type;

            switch (tree.Type)
            {
                case asn1Parser.INT:
                case asn1Parser.FloatingPointLiteral:
                    try
                    {
                        m_value = double.Parse(tree.Text, NumberFormatInfo.InvariantInfo);
                    }
                    catch (OverflowException)
                    {
                        throw new SemanticErrorException("Error line:" + tree.Line + " value: " + tree.Text + " is too large");
                    }
                    break;
                case asn1Parser.MINUS_INFINITY:
                    m_value = double.NegativeInfinity;
                    break;
                case asn1Parser.PLUS_INFINITY:
                    m_value = double.PositiveInfinity;
                    break;
                default:
                    throw new Exception("Internal Error");
            }

        }
        public RealValue(double v, Module m, ITree antlr, Asn1Type type)
        {
            m_TypeID = Asn1Value.TypeID.REAL;
            m_module = m;
            antlrNode = antlr;
            m_value = v;
            m_type = type;
        }
        public RealValue(RealValue o, ITree antlr)
        {
            m_TypeID = Asn1Value.TypeID.REAL;
            m_module = o.m_module;
            antlrNode = antlr;
            m_value = o.m_value;
            m_type = o.m_type;
        }
        public override string ToString()
        {
            return Value.ToString(NumberFormatInfo.InvariantInfo);
        }
        public override bool Equals(object obj)
        {
            RealValue oth = obj as RealValue;
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
            RealValue oth = obj as RealValue;
            if (oth == null)
                throw new ArgumentException("obj is not an IntegerValue");
            return Value.CompareTo(oth.Value);
        }

        public override List<bool> Encode()
        {
            List<bool> ret = new List<bool>();
            if (Value == 0.0)
            {
                ret.AddRange(PER.EncodeConstraintWholeNumber(0, 0, 0xFF));  //encode length
                return ret;
            }
            
            if (Double.IsNegativeInfinity(Value))
            {
                ret.AddRange(PER.EncodeConstraintWholeNumber(1, 0, 0xFF));  //encode length
                ret.AddRange(PER.EncodeConstraintWholeNumber(0x41,0,0xFF));
                return ret;
            }
            
            if (Double.IsPositiveInfinity(Value))
            {
                ret.AddRange(PER.EncodeConstraintWholeNumber(1, 0, 0xFF)); //encode length
                ret.AddRange(PER.EncodeConstraintWholeNumber(0x40, 0, 0xFF));
                return ret;
            }

            /*
                        Bynary encoding will be used
                        REAL = M*B^E
                        where
                        M = S*N*2^F
            
                        ENCODING is done within three parts
                        part 1 is 1 byte header
                        part 2 is 1 or more byte for exponent
                        part 3 is 3 or more byte for mantissa (N)
            
                        First byte        
                        S :0-->+, S:1-->-1
                        Base will be always be 2 (implied by 7th and 6th bit which are zero)
                        ab: F  (0..3)
                        cd:00 --> 1 byte for exponent as 2's complement 
                        cd:01 --> 2 byte for exponent as 2's complement 
                        cd:10 --> 3 byte for exponent as 2's complement 
                        cd:11 --> 1 byte for encoding the length of the exponent, then the expoent 

                         8 7 6 5 4 3 2 1 
                        +-+-+-+-+-+-+-+-+
                        |1|S|0|0|a|b|c|d|
                        +-+-+-+-+-+-+-+-+
            */
            Byte Header = 0x80;
            SqReal tmp = new SqReal(Value, 2);
            if (Value < 0)
                Header |= 0x40;
            int nExpLen = PER.GetLengthInBytesOfSInt(tmp.m_exponent);
            if (nExpLen == 2)
                Header |= 1;
            else if (nExpLen == 3)
                Header |= 2;
            else if (nExpLen > 3)
                throw new Exception("Exponent is two big");

            //encode exponent
            List<bool> expBits = PER.Encode2ndComplementInteger(tmp.m_exponent);
            bool signBit = tmp.m_exponent < 0;
            while (expBits.Count < 8 * nExpLen)
                expBits.Insert(0, signBit);

            //encode mantissa
            int nManLen = PER.GetLengthInBytesOfSInt(tmp.m_mantissa);
            List<bool> manBits = PER.Encode2ndComplementInteger(Math.Abs(tmp.m_mantissa));
            while (manBits.Count < 8 * nManLen)
                manBits.Insert(0, false);

            ret.AddRange(PER.EncodeConstraintWholeNumber(1+nExpLen+nManLen,0,0xFF));//encode length
            ret.AddRange(PER.EncodeConstraintWholeNumber(Header, 0, 0xFF));
            ret.AddRange(expBits);
            ret.AddRange(manBits);

            return ret;
        }

    }

}
