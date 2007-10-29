using System;
using System.Collections.Generic;
using System.Text;
using Antlr.Runtime.Tree;

namespace tinyAsn1
{
    /* ************ VALUES ***********************/
    public partial class Asn1Value
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
            UNDEFINED,
            SEQUENCE_OR_SET,
            SEQUENCE_OF,
            SET_OF,
            CHOICE,
            NULL
        }


        public TypeID m_TypeID = TypeID.UNDEFINED;

        public Asn1Type Type
        {
            get { return m_type; }
        }

//to be removed

        public virtual Int64 getValueAsInt()
        {
            throw new Exception("Internal Error: Abstract method called is not INTEGER");
        }

        public override string ToString()
        {
            throw new Exception("Internal Error: Value is undifined type");
        }

        public virtual bool SemanticCheckFinished()
        {
            return m_TypeID != TypeID.UNDEFINED;
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
                case asn1Parser.MIN:
                    m_value = Int64.MinValue;
                    break;
                case asn1Parser.MAX:
                    m_value = Int64.MaxValue;
                    break;
                default:
                    throw new SemanticErrorException("Error in line : " + antlrNode.Line + ". Expecting integer or integer variable");
            }
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

    public partial class BitStringValue : Asn1Value
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

    }

    public partial class RealValue : Asn1Value
    {
        double m_value;
        public virtual double Value
        {
            get { return m_value; }
            set { m_value = value; }
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
            return Value.ToString();
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
    }

    public partial class OctectStringValue : Asn1Value
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
            return Value.ToString();
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
        public override bool SemanticCheckFinished()
        {
            return m_value.SemanticCheckFinished();
        }


        internal void FixChildrenVars()
        {
            if (SemanticCheckFinished())
                return;

            Asn1Type childType = ChoiceType.m_children[m_alternativeName].m_type;
            m_value = childType.FixVariable(m_value);
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

        public override bool SemanticCheckFinished()
        {
            foreach (Asn1Value v in m_children.Values)
                if (!v.SemanticCheckFinished())
                    return false;
            
            return true;
        }

        public SequenceOrSetValue(SequenceOrSetValue o)
        {
            m_TypeID = Asn1Value.TypeID.SEQUENCE_OR_SET;
            m_module = o.m_module;
            antlrNode = o.antlrNode;
            m_type = o.m_type;
            m_children = o.m_children;
        }

        public SequenceOrSetValue(ITree antlrNode, Module module, Asn1Type type, bool checkChildrenOrder)
        {
            m_TypeID = Asn1Value.TypeID.SEQUENCE_OR_SET;
            this.antlrNode = antlrNode;
            m_module = module;
            m_type = type;

            if (antlrNode.Type != asn1Parser.NAMED_VALUE_LIST)
                throw new Exception("Internal Error: SequenceOrSetValue called with wrong antlr node type");

            for (int i = 0; i < antlrNode.ChildCount; i++)
            {
                ITree namedValue = antlrNode.GetChild(i);
                if (namedValue.Type!=asn1Parser.NAMED_VALUE)
                    throw new Exception("Internal Error");

                string id = namedValue.GetChild(0).Text;

                if (m_children.ContainsKey(id))
                    throw new SemanticErrorException("Error in line :" + antlrNode.GetChild(i).Line + ". '" + id + "' already exists");

                if (!Type2.m_children.ContainsKey(id))
                    throw new SemanticErrorException("Error in line :" + antlrNode.GetChild(i).Line + ". '" + id + "' is not a member");

                Asn1Value val = Asn1Value.CreateFromAntlrAst(namedValue.GetChild(1));

                m_children.Add(id, val);
            }

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
                if (childVal.SemanticCheckFinished())
                    continue;
                
                Asn1Type childType = Type2.m_children[id].m_type;
                m_children[id] = childType.FixVariable(childVal);
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



    public partial class SequenceOfValue : Asn1Value
    {
        public List<Asn1Value> m_children = new List<Asn1Value>();
        public SequenceOfType Type2
        {
            get
            {
                return (SequenceOfType)Type;
            }
        }

        public override bool SemanticCheckFinished()
        {
            foreach (Asn1Value v in m_children)
                if (!v.SemanticCheckFinished())
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
                if (childVal.SemanticCheckFinished())
                    continue;

                Asn1Type childType = Type2.m_type;
                m_children[i] = childType.FixVariable(childVal);
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

            if (antlrNode.Type != asn1Parser.VALUE_LIST)
                throw new Exception("Internal Error: SequenceOfValue called with wrong antlr node type");

            for (int i = 0; i < antlrNode.ChildCount; i++)
            {
                Asn1Value val = Asn1Value.CreateFromAntlrAst(antlrNode.GetChild(i));

                m_children.Add(val);
            }


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

    }



    public partial class SetOfValue : Asn1Value
    {
        public List<Asn1Value> m_children = new List<Asn1Value>();
        public SetOfType Type2
        {
            get
            {
                return (SetOfType)Type;
            }
        }

        public override bool SemanticCheckFinished()
        {
            foreach (Asn1Value v in m_children)
                if (!v.SemanticCheckFinished())
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
                if (childVal.SemanticCheckFinished())
                    continue;

                Asn1Type childType = Type2.m_type;
                m_children[i] = childType.FixVariable(childVal);
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

            if (antlrNode.Type != asn1Parser.VALUE_LIST)
                throw new Exception("Internal Error: SetOfValue called with wrong antlr node type");

            for (int i = 0; i < antlrNode.ChildCount; i++)
            {
                Asn1Value val = Asn1Value.CreateFromAntlrAst(antlrNode.GetChild(i));

                m_children.Add(val);
            }


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
