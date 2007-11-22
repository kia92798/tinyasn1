using System;
using System.Collections.Generic;
using System.Text;
using Antlr.Runtime.Tree;

namespace tinyAsn1
{
    /* ************ VALUES ***********************/

    public interface ISize
    {
        Int64 Size { get;}
    }

    public interface ICharacterString
    {
        string Value { get;}
    }


    public partial class Asn1Value : IComparable
    {
        internal ITree antlrNode;
        //m_module is the module where the variable is declared where it can be different to the module of the type
        public Module m_module;
        protected Asn1Type m_type=null;
        

        public enum TypeID
        {
            INT,
            REAL,
            BIT_STRING,
            OCTECT_STRING,
            BOOLEAN,
            STRING,
            VALUE_REFERENCE,
            ENUMERATED,
            UNRESOLVED,
            SEQUENCE_OR_SET,
            SEQUENCE_OF,
            SET_OF,
            CHOICE,
            OBJECT_IDENTIFIER,
            REL_OBJ_ID,
            IA5String,
            NumericString,
            NULL
        }


        public TypeID m_TypeID = TypeID.UNRESOLVED;

        public Asn1Type Type
        {
            get { return m_type; }
        }

//to be removed


        public override string ToString()
        {
            throw new Exception("Internal Error: Value is undifined type");
        }

        public virtual bool IsResolved()
        {
            return m_TypeID != TypeID.UNRESOLVED;
        }

        #region IComparable Members

        public virtual int CompareTo(object obj)
        {
            throw new Exception("Internal Error: Abstract Method Called.");
        }

        #endregion

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
                    case asn1Parser.NUMERIC_VALUE:
                        if (antlrNode.ChildCount == 1)
                            m_value = Int64.Parse(antlrNode.GetChild(0).Text);
                        else if ((antlrNode.ChildCount == 2) && (antlrNode.GetChild(1).Text == "-"))
                            m_value = -Int64.Parse(antlrNode.GetChild(0).Text);
                        else
                            throw new SemanticErrorException("Error in line : " + antlrNode.Line + " Expecting integer or integer variable");
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
                throw new SemanticErrorException("Error in line : " + antlrNode.Line + ". Integer value ("+m_value+") is too large and can be supported in the target platform");
        }
        public IntegerValue(IntegerValue o)
        {
            antlrNode = o.antlrNode;
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
            if (oth==null)
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

    }

    public partial class EnumeratedValue : Asn1Value
    {
        Int64 m_value;
        public virtual Int64 Value
        {
            get { return m_value; }
        }

        string m_id;
        public virtual string ID
        {
            get { return m_id; }
        }

        public EnumeratedValue(Int64 val, string id, ITree antlr, Module module, Asn1Type type)
        {
            m_TypeID = Asn1Value.TypeID.ENUMERATED;
            m_value = val;
            m_id = id;
            m_module = module;
            antlrNode = antlr;
            m_type = type;
        }
        public EnumeratedValue(EnumeratedValue o)
        {
            m_TypeID = Asn1Value.TypeID.ENUMERATED;
            m_value = o.m_value;
            m_id = o.m_id;
            m_module = o.m_module;
            antlrNode = o.antlrNode;
            m_type = o.m_type;
        }
        public override string ToString()
        {
            return ID + "(" + Value.ToString()+")";
        }

        public override bool Equals(object obj)
        {
            EnumeratedValue oth = obj as EnumeratedValue;
            if (oth == null)
                return false;
            return oth.m_value == m_value;
        }

        public override int GetHashCode()
        {
            return m_value.GetHashCode();
        }
    }

    public partial class BitStringValue : Asn1Value, ISize
    {
        static Dictionary<char, string> lookup = new Dictionary<char, string>();
        static BitStringValue()
        {
            lookup.Add('0', "0000");
            lookup.Add('1', "0001");
            lookup.Add('2', "0010");
            lookup.Add('3', "0011");
            lookup.Add('4', "0100");
            lookup.Add('5', "0101");
            lookup.Add('6', "0110");
            lookup.Add('7', "0111");
            lookup.Add('8', "1000");
            lookup.Add('9', "1001");
            lookup.Add('A', "1010");
            lookup.Add('B', "1011");
            lookup.Add('C', "1100");
            lookup.Add('D', "1101");
            lookup.Add('E', "1110");
            lookup.Add('F', "1111");
        }
        string m_value = "";
        public virtual string Value
        {
            get { return m_value; }
        }

        public BitStringValue(ITree tree, Module mod, Asn1Type type) 
        {
            m_TypeID = TypeID.BIT_STRING;
            m_type = type;
            antlrNode = tree;
            if (tree.Type == asn1Parser.BitStringLiteral)
            {
                m_value = tree.Text.Substring(1);
                m_value = m_value.Remove(m_value.Length - 2);
                m_value = m_value.Replace("\r", "").Replace("\n", "").Replace("\t", "").Replace(" ", "");

                while (m_value.Length > 0 && m_value[m_value.Length - 1] == '0')
                    m_value = m_value.Remove(m_value.Length - 1);
            }
            else if (tree.Type == asn1Parser.OctectStringLiteral)
            {
                string tmp = tree.Text.Substring(1);
                tmp = tmp.Remove(tmp.Length - 2);

                foreach (Char ch in tmp.ToUpper())
                    m_value += lookup[ch];
                
                while (m_value.Length > 0 && m_value[m_value.Length - 1] == '0')
                    m_value = m_value.Remove(m_value.Length - 1);
            }
            else
                throw new Exception("Internal Error");
        }
        public BitStringValue(List<Int64> ids, ITree tree, Module mod, Asn1Type type)
        {
            m_TypeID = TypeID.BIT_STRING;
            m_type = type;
            antlrNode = tree;

            Int64 max = Int64.MinValue;
            foreach (Int64 i in ids)
                if (i > max)
                    max = i;
            for (int i = 0; i <= max; i++)
            {
                if (ids.Contains(i))
                    m_value += "1";
                else
                    m_value += "0";
            }
        }

        public BitStringValue(BitStringValue o)
        {
            m_TypeID = Asn1Value.TypeID.BIT_STRING;
            m_value = o.m_value;
            m_module = o.m_module;
            antlrNode = o.antlrNode;
            m_type = o.m_type;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
        public override bool Equals(object obj)
        {
            BitStringValue oth = obj as BitStringValue;
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
            get { return m_value.Length; }
        }

    }

    public partial class RealValue : Asn1Value
    {
        public class SqReal {
            public Int64 m_mantissa;
            public Int64 m_base;
            public Int64 m_exponent;
            public SqReal (double d, int newBase, Int64 minExp, Int64 maxMantissa)
            {
                if (d == 0.0 || double.IsInfinity(d))
                    throw new ArgumentOutOfRangeException();

                m_base = newBase;
                //Let mantissa be 1
                // then exponent is the logarithm of the input value.
                //However, since we need the expoent to be stored in an INT we get the Floor 
                // Floor return the largest integer less than or equal to the specified double-precision floating-point number
                m_exponent = (Int64)Math.Floor(Math.Log(Math.Abs(d),m_base));

                //Since exponent was 'Floored' mantissa is not 1 anymore but the following value
                // now mantissa has a value in the range [1..base)
                double mantissa = d / Math.Pow((double)m_base, (double)m_exponent);
                if (mantissa >= m_base)
                    throw new Exception("Mantissa("+mantissa.ToString()+") is greater or equal to base");

                while (m_exponent >= minExp)
                {
                    mantissa *= m_base;
                    m_exponent--;
                    if (mantissa - Math.Floor(mantissa)<Double.Epsilon)
                        break;
                    if (mantissa > maxMantissa)
                        break;
                }
                m_mantissa = (Int64)mantissa;
                if (d < 0)
                    m_mantissa = -m_mantissa;

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

            double mantissa = double.Parse(tree.GetChild(0).Text);
            double bas = double.Parse(tree.GetChild(1).Text);
            double exp = double.Parse(tree.GetChild(2).Text);

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

            double dbValVal;
            dbValVal = double.Parse(tree.GetChild(0).Text);
            bool negate = false;
            Int64 decPart = 0;
            
            if (tree.ChildCount == 2)
            {
                if (tree.GetChild(1).Text == "-")
                    negate = true;
                else
                    decPart = Int64.Parse(tree.GetChild(1).Text);
            }
            else if (tree.ChildCount == 3)
            {
                negate = tree.GetChild(1).Text == "-";
                decPart = Int64.Parse(tree.GetChild(2).Text);
            }

            double tmp = decPart;
            for (int i = 0; i < decPart.ToString().Length; i++)
                tmp = tmp / 10.0;
            m_value = dbValVal + tmp;

            if (negate)
                m_value = -m_value;

        }
        public RealValue(double v, Module m, ITree antlr, Asn1Type type)
        {
            m_TypeID = Asn1Value.TypeID.REAL;
            m_module = m;
            antlrNode = antlr;
            m_value = v;
            m_type = type;
        }
        public RealValue(RealValue o)
        {
            m_TypeID = Asn1Value.TypeID.REAL;
            m_module = o.m_module;
            antlrNode = o.antlrNode;
            m_value = o.m_value;
            m_type = o.m_type;
        }
        public override string ToString()
        {
//            return Value.ToString("0,0.0");
            string ret = Value.ToString().Replace(',','.');
            if (!ret.Contains("."))
                ret += ".0";
            return ret;
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
            if (bitString.Length % 4>0)
                nBitsToInsert = 4 - bitString.Length % 4;
            else
                nBitsToInsert = 0;

            for (int i = 0; i < nBitsToInsert; i++)
                bitString += "0" ;

            List<byte> nibles = new List<byte>();
            while (bitString.Length > 0)
            {
                string nible = bitString.Substring(0, 4);
                nibles.Add(lookup[nible]);
                bitString = bitString.Substring(4);
            }
            if (nibles.Count % 2 != 0)
                nibles.Insert(0,0);

            while (nibles.Count > 0)
            {
                byte curByte = (byte)(nibles[0]<<4);
                curByte|=nibles[1];
                m_value.Add(curByte);
                nibles.RemoveAt(0);
                nibles.RemoveAt(0);
            }
        }


        public OctectStringValue(OctectStringValue o)
        {
            m_TypeID = Asn1Value.TypeID.OCTECT_STRING;
            m_module = o.m_module;
            antlrNode = o.antlrNode;
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

    public partial class IA5StringValue : Asn1Value, ISize, ICharacterString
    {
        string m_value;
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


        public IA5StringValue(IA5StringValue o)
        {
            m_TypeID = Asn1Value.TypeID.IA5String;
            m_module = o.m_module;
            antlrNode = o.antlrNode;
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
        
        public NumericStringValue(ITree tree, Module mod, Asn1Type type) : base(tree, mod, type)
        {
            m_TypeID = Asn1Value.TypeID.NumericString;
            List<Char> acs = new List<char>(AllowedCharSet);
            foreach(Char ch in Value.ToCharArray())
                if (!acs.Contains(ch))
                    throw new SemanticErrorException("Error in line: "+antlrNode.Line+", col: "+antlrNode.CharPositionInLine+". Character: '"+ch+"' can not be contained in a Numeric string");
        }
        public NumericStringValue(NumericStringValue o) :base(o)
        {
            m_TypeID = Asn1Value.TypeID.NumericString;
        }
    }

    public partial class BooleanValue : Asn1Value
    {
        bool m_value=false;
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
        public BooleanValue(BooleanValue o)
        {
            m_TypeID = Asn1Value.TypeID.BOOLEAN;
            m_module = o.m_module;
            antlrNode = o.antlrNode;
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
    }

    public partial class NullValue : Asn1Value
    {
        public NullValue()
        {
            m_TypeID = TypeID.NULL;
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
    }
    
    public partial class ChoiceValue : Asn1Value
    {
        public ChoiceType ChoiceType
        {
            get { return (ChoiceType)m_type; }
        }
        Asn1Value m_value;
        public virtual Asn1Value Value
        {
            get { return m_value; }
        }

        string m_alternativeName;
        public virtual string AlternativeName
        {
            get { return m_alternativeName; }
        }
        public ChoiceValue(ChoiceValue o)
        {
            m_TypeID = Asn1Value.TypeID.CHOICE;
            m_module = o.m_module;
            antlrNode = o.antlrNode;
            m_type = o.m_type;
            m_value = o.m_value;
            m_alternativeName = o.m_alternativeName;
        }

        public ChoiceValue(ITree antlrNode, Module module, Asn1Type type)
        {
            m_TypeID = Asn1Value.TypeID.CHOICE;
            this.antlrNode = antlrNode;
            m_module = module;
            m_type = type;

            if (antlrNode.Type != asn1Parser.CHOICE_VALUE)
                throw new Exception("Internal Error: ChoiceValue called with wrong antlr node type");


            m_alternativeName = antlrNode.GetChild(0).Text;

            m_value = Asn1Value.CreateFromAntlrAst(antlrNode.GetChild(1));

            if (!ChoiceType.m_children.ContainsKey(m_alternativeName))
                throw new SemanticErrorException("Error in line :" + antlrNode.Line + ". '" + m_alternativeName + "' is not a member of the choice");
        }
        public override bool IsResolved()
        {
            return m_value.IsResolved();
        }


        internal void FixChildrenVars()
        {
            if (IsResolved())
                return;

            Asn1Type childType = ChoiceType.m_children[m_alternativeName].m_type;
            m_value = childType.ResolveVariable(m_value);
        }

        public override string ToString()
        {
            return m_alternativeName + ":" + m_value.ToString();
        }


        public override bool Equals(object obj)
        {
            ChoiceValue oth = obj as ChoiceValue;
            if (oth == null)
                return false;
            return (oth.m_value == m_value) && (oth.m_alternativeName == m_alternativeName);
        }

        public override int GetHashCode()
        {
            return m_value.GetHashCode();
        }
    }

    public partial class SequenceOrSetValue : Asn1Value
    {
        public OrderedDictionary<string, Asn1Value> m_children = new OrderedDictionary<string, Asn1Value>();
        public SequenceOrSetType Type2
        {
            get
            {
                return (SequenceOrSetType)Type;
            }
        }

        public override bool IsResolved()
        {
            foreach (Asn1Value v in m_children.Values)
                if (!v.IsResolved())
                    return false;
            
            return true;
        }

        public SequenceOrSetValue(SequenceOrSetValue o, ITree antlr)
        {
            m_TypeID = Asn1Value.TypeID.SEQUENCE_OR_SET;
            m_module = o.m_module;
            antlrNode = antlr;
            m_type = o.m_type;
            m_children = o.m_children;
        }

        public SequenceOrSetValue(ITree antlrNode, Module module, Asn1Type type, bool checkChildrenOrder)
        {
            m_TypeID = Asn1Value.TypeID.SEQUENCE_OR_SET;
            this.antlrNode = antlrNode;
            m_module = module;
            m_type = type;


            if (antlrNode.Type == asn1Parser.NAMED_VALUE_LIST)
            {

                for (int i = 0; i < antlrNode.ChildCount; i++)
                {
                    ITree namedValue = antlrNode.GetChild(i);
                    if (namedValue.Type != asn1Parser.NAMED_VALUE)
                        throw new Exception("Internal Error");

                    string id = namedValue.GetChild(0).Text;

                    if (m_children.ContainsKey(id))
                        throw new SemanticErrorException("Error in line :" + antlrNode.GetChild(i).Line + ". '" + id + "' already exists");

                    if (!Type2.m_children.ContainsKey(id))
                        throw new SemanticErrorException("Error in line :" + antlrNode.GetChild(i).Line + ". '" + id + "' is not a member");

                    Asn1Value val = Asn1Value.CreateFromAntlrAst(namedValue.GetChild(1));

                    m_children.Add(id, val);
                }
            }
            else if (antlrNode.Type == asn1Parser.OBJECT_ID_VALUE)
            {
                //we expect two children, no more no less
                if (antlrNode.ChildCount != 2)
                    throw new SemanticErrorException("Error in line :"+antlrNode.Line+", col:"+antlrNode.CharPositionInLine+". Expecting a SEQUENCE variable");
                // first child must be an identifier and nothing else
                ITree ObjListItem1 = antlrNode.GetChild(0);
                if (ObjListItem1.ChildCount!=1)
                    throw new SemanticErrorException("Error in line :" + antlrNode.Line + ", col:" + antlrNode.CharPositionInLine + ". Expecting a SEQUENCE variable");
                ITree identifier = ObjListItem1.GetChild(0);
                if (identifier.Type != asn1Parser.LID)
                    throw new SemanticErrorException("Error in line :" + identifier.Line + ", col:" + identifier.CharPositionInLine + ". Expecting identifier");

                string id = identifier.Text;
                if (m_children.ContainsKey(id))
                    throw new SemanticErrorException("Error in line :" + identifier.Line + ",col:" + identifier.CharPositionInLine+ ". '" + id + "' already exists");
                if (!Type2.m_children.ContainsKey(id))
                    throw new SemanticErrorException("Error in line :" + identifier.Line + ",col:" + identifier.CharPositionInLine+ ". '" + id + "' is not a member");
                //second child must be an INT or valuereference
                ITree ObjListItem2 = antlrNode.GetChild(1);
                if (ObjListItem2.ChildCount != 1)
                    throw new SemanticErrorException("Error in line :" + antlrNode.Line + ", col:" + antlrNode.CharPositionInLine + ". Expecting a SEQUENCE variable");
                ITree grChild = ObjListItem2.GetChild(0);
                if (grChild.Type == asn1Parser.INT)
                {
                    SemanticTreeNode numericValue = new SemanticTreeNode(grChild.CharPositionInLine, grChild.Line, grChild.Text, asn1Parser.NUMERIC_VALUE);
                    numericValue.AddChild(grChild);
                    Asn1Value val = Asn1Value.CreateFromAntlrAst(numericValue);
                    m_children.Add(id, val);
                }
                else if (ObjListItem2.GetChild(0).Type == asn1Parser.LID)
                {
                    SemanticTreeNode valueReference = new SemanticTreeNode(grChild.CharPositionInLine, grChild.Line, grChild.Text, asn1Parser.VALUE_REFERENCE);
                    valueReference.AddChild(grChild);
                    Asn1Value val = Asn1Value.CreateFromAntlrAst(valueReference);
                    m_children.Add(id, val);
                }
                else
                    throw new Exception("Internal Error");


            } else
                throw new Exception("Internal Error: SequenceOrSetValue called with wrong antlr node type");

            foreach (string typeChildName in Type2.m_children.Keys)
            {
                SequenceOrSetType.Child child = Type2.m_children[typeChildName];
                if (child.m_optional || child.m_default)
                    continue;
                if (!m_children.ContainsKey(typeChildName))
                    throw new SemanticErrorException("Error in line :" + antlrNode.Line + ". Mandatory child '" + typeChildName + "' missing");
            }

            if (checkChildrenOrder)
            {
                //to be implemented
            }

        }

        internal void FixChildrenVars()
        {
            foreach (string id in m_children.Keys)
            {
                Asn1Value childVal = m_children[id];
                if (childVal.IsResolved())
                    continue;
                
                Asn1Type childType = Type2.m_children[id].m_type;
                m_children[id] = childType.ResolveVariable(childVal);
            }
        }

        public override string ToString()
        {

            System.IO.StringWriter w = new System.IO.StringWriter();
            
            string key;
            w.Write("{");
            int cnt = m_children.Count;
            for (int i = 0; i < cnt - 1; i++)
            {
                key = m_children.Keys[i];
                w.Write(" "+ key + " " + m_children[key].ToString() +",");
            }

            key = m_children.Keys[cnt-1];
            w.Write(" " + key + " " + m_children[key].ToString()+" }");

            w.Flush();
            return w.ToString();
        }
        public override bool Equals(object obj)
        {
            SequenceOrSetValue oth = obj as SequenceOrSetValue;
            if (oth == null)
                return false;
            if (oth.m_children.Count != m_children.Count)
                return false;
            
            for (int i = 0; i < m_children.Count; i++)
            {
                if (m_children.Keys[i] != oth.m_children.Keys[i])
                    return false;
                if (!m_children.Values[i].Equals(oth.m_children.Values[i]))
                    return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            return m_children.GetHashCode();
        }
    }

    public partial class ArrayValue : Asn1Value
    {
        public List<Asn1Value> m_children = new List<Asn1Value>();
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

        public SequenceOfValue(SequenceOfValue o)
        {
            m_TypeID = Asn1Value.TypeID.SEQUENCE_OF;
            m_module = o.m_module;
            antlrNode = o.antlrNode;
            m_type = o.m_type;
            m_children = o.m_children;
        }

        internal void FixChildrenVars()
        {
            for (int i = 0; i < m_children.Count;i++ )
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
                    throw new SemanticErrorException("Error in line:"+antlrNode.Line+" col:"+antlrNode.CharPositionInLine+". Expecting SEQUENCE OF value");
                if (antlrNode.GetChild(0).ChildCount != 1)
                    throw new SemanticErrorException("Error in line:" + antlrNode.Line + " col:" + antlrNode.CharPositionInLine + ". Expecting SEQUENCE OF value");
                ITree grandChild = antlrNode.GetChild(0).GetChild(0);

                SemanticTreeNode nodeValue;
                if (grandChild.Type == asn1Parser.INT) 
                    nodeValue = new SemanticTreeNode(grandChild.CharPositionInLine, grandChild.Line, grandChild.Text, asn1Parser.NUMERIC_VALUE);
                else if (grandChild.Type == asn1Parser.LID)
                    nodeValue = new SemanticTreeNode(grandChild.CharPositionInLine, grandChild.Line, grandChild.Text, asn1Parser.VALUE_REFERENCE);
                else
                    throw new Exception("Internal Error");

                nodeValue.AddChild(grandChild);
                Asn1Value val = Asn1Value.CreateFromAntlrAst(nodeValue);
                m_children.Add(val);


            } else
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

    public partial class SetOfValue : ArrayValue, ISize
    {
        public SetOfType Type2
        {
            get
            {
                return (SetOfType)Type;
            }
        }

        public override bool IsResolved()
        {
            foreach (Asn1Value v in m_children)
                if (!v.IsResolved())
                    return false;

            return true;
        }

        public SetOfValue(SetOfValue o)
        {
            m_TypeID = Asn1Value.TypeID.SET_OF;
            m_module = o.m_module;
            antlrNode = o.antlrNode;
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
                for (int j = i+1; j < cnt; j++)
                {
                    if (m_children[i].Equals(m_children[j]))
                        throw new SemanticErrorException("Error: SET declared in line :" + antlrNode.Line + " contains value :" + m_children[i].ToString()+" more than once");
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

            w.Write(m_children[cnt - 1].ToString() + " }");

            w.Flush();
            return w.ToString();
        }
        public SetOfValue(ITree antlrNode, Module module, Asn1Type type)
        {
            m_TypeID = Asn1Value.TypeID.SET_OF;
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

                SemanticTreeNode nodeValue;
                if (grandChild.Type == asn1Parser.INT)
                    nodeValue = new SemanticTreeNode(grandChild.CharPositionInLine, grandChild.Line, grandChild.Text, asn1Parser.NUMERIC_VALUE);
                else if (grandChild.Type == asn1Parser.LID)
                    nodeValue = new SemanticTreeNode(grandChild.CharPositionInLine, grandChild.Line, grandChild.Text, asn1Parser.VALUE_REFERENCE);
                else
                    throw new Exception("Internal Error");

                nodeValue.AddChild(grandChild);
                Asn1Value val = Asn1Value.CreateFromAntlrAst(nodeValue);
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

        public long Size
        {
            get { return m_children.Count; }
        }
    }
    
    public partial class ObjectIdentifierValue : Asn1Value
    {
        public List<ObjectIdentifierComponent> m_components = new List<ObjectIdentifierComponent>();
        public class ObjectIdentifierComponent
        {
            //cases:
            // case 1 : id1
                            // is id1 reserved word    -->  label:=id1, no = id1.value
                            // if (INDEX==0) && id1 is value reference to OBJ-ID ->replace component with components of other OBJ-ID
                            // is id1 reference to INTEGER --> no := INTEGER value
                            // is id1 reference to REL_OBJ ID --> ?
                            //default: id1 is unknown or reference wrong type
            // case 2 : id1.id2
                            // if (INDEX==0) && id1.id2 is value reference to OBJ-ID ->replace component with components of other OBJ-ID
                            // is id1.id2 reference to INTEGER --> no := INTEGER value
                            // is id1.id2 reference to REL_OBJ ID --> ?
            // case 3 : INT
                            // no := INT
            // case 4 : id1 (INT)
                            // label := id1, no := INT
            // case 5 : id1 (id2)
                            // is id2 reference to INT val  -> label := id1, no:=INT of id2
            // case 6 : id1 (id2.id3)
                            // is id2.id3 reference to INT val  -> label := id1, no:=INT of id2.id3
            public int? no = null;
            public string label = null;
            private string id1 = null;
            private string id2 = null;
            private string id3 = null;
            private ITree tr1 = null;
            private ITree tr2 = null;
            private ITree tr3 = null;
            private int caseNo = 0;

            static public ObjectIdentifierComponent CreateFromAntlrAst(ITree tree)
            {
                ObjectIdentifierComponent ret = new ObjectIdentifierComponent();
                switch (tree.Type)
                {
                    case asn1Parser.OBJ_LST_ITEM1:
                        ret.id1 = tree.GetChild(0).Text;
                        ret.tr1 = tree;
                        ret.caseNo = 1;
                        if (tree.ChildCount == 2)
                        {
                            ret.label = ret.id1;
                            ITree chTree = tree.GetChild(1);
                            if (chTree.Type == asn1Parser.INT)
                            {
                                ret.caseNo = 4;
                                ret.no = int.Parse(chTree.Text);
                            }
                            else if (chTree.Type == asn1Parser.DEFINED_VALUE)
                            {
                                if (chTree.ChildCount == 1)
                                {
                                    ret.caseNo = 5;
                                    ret.id2 = chTree.GetChild(0).Text;
                                    ret.tr2 = chTree.GetChild(0);
                                }
                                else if (chTree.ChildCount == 2)
                                {
                                    ret.caseNo = 6;
                                    ret.id2 = chTree.GetChild(0).Text;
                                    ret.tr2 = chTree.GetChild(0);
                                    ret.id3 = chTree.GetChild(1).Text;
                                    ret.tr3 = chTree.GetChild(1);
                                }
                                else
                                    throw new Exception("INTERNAL ERROR");
                            }
                        }
                        return ret;
                    case asn1Parser.OBJ_LST_ITEM2:
                        ret.caseNo = 3;
                        ret.no = int.Parse(tree.GetChild(0).Text);
                        return ret;
                    case asn1Parser.DEFINED_VALUE:
                        ret.caseNo = 2;
                        if (tree.ChildCount!=2)
                            throw new Exception("INTERNAL ERROR");
                        ret.tr1 = tree.GetChild(0);
                        ret.id1 = tree.GetChild(0).Text;
                        ret.tr2 = tree.GetChild(1);
                        ret.id2 = tree.GetChild(1).Text;
                        return ret;
                    default:
                        throw new Exception("Internal Error");
                }

            }

            internal List<ObjectIdentifierComponent> Fixup(int Index, Module mod, ObjectIdentifierComponent prev)
            {
                if (SemanticCheckFinished())
                    return null;
                switch (caseNo)
                {
                    case 1:
                        return handleCase1(Index,mod,prev);
                    case 2:
                        return handleCase2(Index, mod);
                    case 5:
                        return handleCase5(Index, mod);
                    case 6:
                        return handleCase6(Index, mod);
                    default:
                        throw new Exception("INTERNAL ERROR.");
                }
            }

            // case 1 : id1
                // is id1 reserved word    -->  label:=id1, no = id1.value
                // if (INDEX==0) && id1 is value reference to OBJ-ID ->replace component with components of other OBJ-ID
                // is id1 reference to INTEGER --> no := INTEGER value
                // is id1 reference to REL_OBJ ID --> ?
                //default: id1 is unknown or reference wrong type
            List<ObjectIdentifierComponent> handleCase1(int Index, Module mod, ObjectIdentifierComponent prev)
            {
                int tmp;
                string prvLbl = null;
                if (prev != null)
                    prvLbl = prev.label;
                if (YellowIDs.isYellowId(Index, id1, prvLbl, out tmp))
                {
                    no = tmp;
                    label = id1;
                    return null;
                }
                if (!mod.isValueDeclared(id1))
                    throw new SemanticErrorException("Error in line: " + tr1.Line + ", col:"+tr1.CharPositionInLine+". Unknown identifier: "+id1);
                Asn1Value val = mod.GetValue(id1);
                if (val.m_TypeID == Asn1Value.TypeID.UNRESOLVED)
                    return null; // not yet resolved. wait for next round
                if (val.m_TypeID == TypeID.INT)
                {
                    tmp = (int)((IntegerValue)val).Value;
                    no = tmp;
                    return null;
                }
                if (val.m_TypeID == TypeID.OBJECT_IDENTIFIER)
                {
                    if (Index == 0)
                    {
                        ObjectIdentifierValue obj = val as ObjectIdentifierValue;
                        if (!obj.IsResolved())
                            return null; //wait until resolved
                        return obj.m_components;
                    } else
                        throw new SemanticErrorException("Error in line: " + tr1.Line + ", col:" + tr1.CharPositionInLine + ". Identifier: " + id1 + "resolves to OBJECT IDENTIFIER but it is not the first item");
                }
                if (val.m_TypeID == TypeID.REL_OBJ_ID)
                {
                    throw new Exception("UNIMPLEMENTED FEATURE");
                }

                throw new SemanticErrorException("Error in line: " + tr1.Line + ", col:" + tr1.CharPositionInLine + ". Identifier: " + id1 + "does not resolve to INTEGER or RELATIVE-OID");
            }

            static class YellowIDs
            {
                class ID
                {
                    public int value;
                    public int level;
                    public string father;
                    public ID(int v, int l, string f) { value = v; level = l; father = f; }
                }
                static Dictionary<string, ID> ids = new Dictionary<string, ID>();
                static YellowIDs()
                {
                    ids.Add("itu-t", new ID(0, 0, null));
                    ids.Add("ccitt", new ID(0, 0, null));
                    ids.Add("iso", new ID(1, 0, null));
                    ids.Add("joint-iso-itu-t", new ID(2, 0, null));
                    ids.Add("joint-iso-ccitt", new ID(2, 0, null));

                    ids.Add("itu-t.recommendation", new ID(0, 1, "itu-t"));
                    ids.Add("itu-t.question", new ID(1, 1, "itu-t"));
                    ids.Add("itu-t.administration", new ID(2, 1, "itu-t"));
                    ids.Add("itu-t.network-operator", new ID(3, 1, "itu-t"));
                    ids.Add("itu-t.identified-organization", new ID(4, 1, "itu-t"));

                    ids.Add("iso.standard", new ID(0, 1, "iso"));
                    ids.Add("iso.member-body", new ID(2, 1, "iso"));
                    ids.Add("iso.identified-organization", new ID(3, 1, "iso"));

                    int j = 0;
                    for (char i = 'a'; i <= 'z'; i++)
                    {
                        j++;
                        ids.Add("recommendation." + new string(i,1), new ID(j, 2, "recommendation"));
                    }
                }

                public static bool isYellowId(int level, string id, string prevId, out int retVal)
                {
                    retVal = 0;
                    if (prevId == "ccitt")
                        prevId = "itu-t";
                    if (prevId == "joint-iso-ccitt")
                        prevId = "joint-iso-itu-t";
                    if (prevId != null)
                        id = prevId + "." + id;

                    if (!ids.ContainsKey(id))
                        return false;

                    ID y = ids[id];
                    if (y.level == level)
                    {
                        retVal = y.value;
                        return true;
                    }
                    return false;
                }
            }


            // case 2 : id1.id2
                // if (INDEX==0) && id1.id2 is value reference to OBJ-ID ->replace component with components of other OBJ-ID
                // is id1.id2 reference to INTEGER --> no := INTEGER value
                // is id1.id2 reference to REL_OBJ ID --> ?
            List<ObjectIdentifierComponent> handleCase2(int Index, Module m)
            {
                if (!Asn1CompilerInvokation.Instance.isModuleDefined(id1))
                    throw new SemanticErrorException("Error in line: " + tr1.Line + ", col:" + tr1.CharPositionInLine + ". Identifier: " + id1 + " does not resolve to a MODULE");
                
                Module mod = Asn1CompilerInvokation.Instance.GetModuleByName(id1);

                if (!mod.isValueDeclared(id2))
                    throw new SemanticErrorException("Error in line: " + tr2.Line + ", col:" + tr2.CharPositionInLine + ". Unknown identifier: " + id2);
                Asn1Value val = mod.GetValue(id2);
                if (val.m_TypeID == Asn1Value.TypeID.UNRESOLVED)
                    return null; // not yet resolved. wait for next round
                if (val.m_TypeID == TypeID.INT)
                {
                    int tmp = (int)((IntegerValue)val).Value;
                    no = tmp;
                    return null;
                }
                if (val.m_TypeID == TypeID.OBJECT_IDENTIFIER)
                {
                    if (Index == 0)
                    {
                        ObjectIdentifierValue obj = val as ObjectIdentifierValue;
                        if (!obj.IsResolved())
                            return null; //wait until resolved
                        return obj.m_components;
                    }
                    else
                        throw new SemanticErrorException("Error in line: " + tr1.Line + ", col:" + tr1.CharPositionInLine + ". Identifier: " + id1 + "."+id2+" resolves to OBJECT IDENTIFIER but it is not the first item");
                }

                if (val.m_TypeID == TypeID.REL_OBJ_ID)
                {
                    throw new Exception("UNIMPLEMENTED FEATURE");
                }

                throw new SemanticErrorException("Error in line: " + tr2.Line + ", col:" + tr2.CharPositionInLine + ". Identifier: " + id2 + "does not resolve to INTEGER or RELATIVE-OID");
            }
            // case 5 : id1 (id2)
                // is id2 reference to INT val  -> label := id1, no:=INT of id2
            List<ObjectIdentifierComponent> handleCase5(int Index, Module mod)
            {
                if (!mod.isValueDeclared(id2))
                    throw new SemanticErrorException("Error in line: " + tr2.Line + ", col:" + tr2.CharPositionInLine + ". Unknown identifier: " + id2);
                Asn1Value val = mod.GetValue(id2);
                if (val.m_TypeID == Asn1Value.TypeID.UNRESOLVED)
                    return null; // not yet resolved. wait for next round
                if (val.m_TypeID == TypeID.INT)
                {
                    int tmp = (int)((IntegerValue)val).Value;
                    no = tmp;
                    return null;
                }

                throw new SemanticErrorException("Error in line: " + tr2.Line + ", col:" + tr2.CharPositionInLine + ". Identifier: " + id2 + "does not resolve to INTEGER or RELATIVE-OID");
            }
            // case 6 : id1 (id2.id3)
                // is id2.id3 reference to INT val  -> label := id1, no:=INT of id2.id3
            List<ObjectIdentifierComponent> handleCase6(int Index, Module m)
            {
                if (!Asn1CompilerInvokation.Instance.isModuleDefined(id2))
                    throw new SemanticErrorException("Error in line: " + tr2.Line + ", col:" + tr2.CharPositionInLine + ". Identifier: " + id2 + "does not resolve to a MODULE");

                Module mod = Asn1CompilerInvokation.Instance.GetModuleByName(id2);

                if (!mod.isValueDeclared(id3))
                    throw new SemanticErrorException("Error in line: " + tr3.Line + ", col:" + tr3.CharPositionInLine + ". Unknown identifier: " + id3);
                Asn1Value val = mod.GetValue(id3);
                if (val.m_TypeID == Asn1Value.TypeID.UNRESOLVED)
                    return null; // not yet resolved. wait for next round
                if (val.m_TypeID == TypeID.INT)
                {
                    int tmp = (int)((IntegerValue)val).Value;
                    no = tmp;
                    return null;
                }

                throw new SemanticErrorException("Error in line: " + tr3.Line + ", col:" + tr2.CharPositionInLine + ". Identifier: " + id3 + "does not resolve to INTEGER or RELATIVE-OID");
            }
            
            public override string ToString()
            {
                if (no==null)
                    throw new Exception("Internal Error");

                if (label != null )
                    return label + "(" + no.Value.ToString() + ")";

                return no.Value.ToString();

            }
            public override bool Equals(object obj)
            {
                ObjectIdentifierComponent oth = obj as ObjectIdentifierComponent;
                if (oth == null)
                    return false;
                if (no == null)
                    throw new Exception("Internal Error");
                if (oth.no == null)
                    throw new Exception("Internal Error");

                return oth.no== no;
            }
            public override int GetHashCode()
            {
                return ToString().GetHashCode();
            }

            public bool SemanticCheckFinished()
            {
                return no!=null;
            }


        }
        public override string ToString()
        {

            System.IO.StringWriter w = new System.IO.StringWriter();

            w.Write("{");
            int cnt = m_components.Count;
            for (int i = 0; i < cnt - 1; i++)
            {
                w.Write(" " + m_components[i].ToString() + ",");
            }

            w.Write(m_components[cnt - 1].ToString() + " }");

            w.Flush();
            return w.ToString();
        }
        public override bool Equals(object obj)
        {
            ObjectIdentifierValue oth = obj as ObjectIdentifierValue;
            if (oth == null)
                return false;
            if (oth.m_components.Count != m_components.Count)
                return false;

            for (int i = 0; i < m_components.Count; i++)
            {
                if (!m_components[i].Equals(oth.m_components[i]))
                    return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            return m_components.GetHashCode();
        }
        public ObjectIdentifierValue(ObjectIdentifierValue o)
        {
            m_TypeID = Asn1Value.TypeID.OBJECT_IDENTIFIER;
            m_module = o.m_module;
            antlrNode = o.antlrNode;
            m_type = o.m_type;
            m_components = o.m_components;
        }
        public ObjectIdentifierValue(ITree antlrNode, Module module, Asn1Type type)
        {
            m_TypeID = Asn1Value.TypeID.OBJECT_IDENTIFIER;
            this.antlrNode = antlrNode;
            m_module = module;
            m_type = type;

            if (antlrNode.Type != asn1Parser.OBJECT_ID_VALUE)
                throw new Exception("Internal Error. ObjectIdentifierValue() constructot called with wrong antlr node type");
            for (int i = 0; i < antlrNode.ChildCount; i++)
            {
                m_components.Add(ObjectIdentifierComponent.CreateFromAntlrAst(antlrNode.GetChild(i)));
            }
            

        }

        public override bool IsResolved()
        {
            foreach (ObjectIdentifierComponent cm in m_components)
                if (!cm.SemanticCheckFinished())
                    return false;

            return true;
        }


        internal void FixChildrenVars()
        {

            List<ObjectIdentifierComponent> items;
            for (int i = 0; i < m_components.Count; i++)
            {
                if (i > 0)
                    items = m_components[i].Fixup(i, m_module, m_components[i - 1]);
                else
                    items = m_components[i].Fixup(i, m_module, null);

                if (items != null)
                {
                    //replace i item with items
                    m_components.RemoveAt(i);
                    m_components.InsertRange(i, items);
                }
            }
        }
    }

}
