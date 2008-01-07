using System;
using System.Collections.Generic;
using System.Text;
using Antlr.Runtime.Tree;

namespace tinyAsn1
{
    public class IntegerRange
    {
        public Int64 m_min;
        public bool m_minIsInfinite;
        public bool m_minIsIncluded;    
        public Int64 m_max;            
        public bool m_maxIsIncluded;
        public bool m_maxIsInfinite;

        public IntegerRange()
        {
            // create an Invalid range
            m_max = Config.MININT;
            m_min = Config.MAXINT;
        }

        public static IntegerRange UncostraintInteger {
            get
            {
                IntegerRange ret = new IntegerRange();
                ret.m_minIsInfinite = true;
                ret.m_maxIsInfinite = true;
                return ret;
            }
        }
        public static IntegerRange UncostraintPosInteger
        {
            get
            {
                IntegerRange ret = new IntegerRange();
                ret.m_minIsInfinite = false;
                ret.m_minIsIncluded = true;
                ret.m_min = 0;
                ret.m_maxIsInfinite = true;
                return ret;
            }
        }
        
        public void PrintAsn1(StreamWriterLevel o)
        {
            if (m_minIsInfinite)
                o.Write("MIN");
            else
            {
                if (m_minIsIncluded)
                    o.Write(m_min);
                else
                    o.Write(m_min + 1);
            }
            o.Write("..");
            if (m_maxIsInfinite)
                o.Write("MAX");
            else
            {
                if (m_maxIsIncluded)
                    o.Write(m_max);
                else
                    o.Write(m_max - 1);
            }
        }

/*        public bool IsValid()
        {
            if (m_max == Config.MININT)
                return false;
            if (m_min == Config.MAXINT)
                return false;
            if (m_maxIsInfinite || m_minIsInfinite)
                return true;
            return m_min <= m_max;
        }
 */ 

        public IntegerRange Clone()
        {
            IntegerRange c = new IntegerRange();
            c.m_max = m_max;
            c.m_maxIsIncluded = m_maxIsIncluded;
            c.m_maxIsInfinite = m_maxIsInfinite;

            c.m_min = m_min;
            c.m_minIsIncluded = m_minIsIncluded;
            c.m_minIsInfinite = m_minIsInfinite;
            return c;
        }
        
        public bool isValueWithinRange(Int64 val)
        {
            if (m_maxIsInfinite && m_minIsInfinite)
                return true;
            if (m_minIsInfinite && val < m_max)
                return true;
            if (m_min < val && m_maxIsInfinite)
                return true;
            if (m_min < val && val < m_max)
                return true;
            if (m_minIsIncluded && val == m_min)
                return true;
            if (m_maxIsIncluded && val == m_max)
                return true;
            return false;
        }


        public static IntegerRange Union(IntegerRange a, IntegerRange b)
        {
            IntegerRange c = new IntegerRange();

            if (a.m_minIsInfinite || b.m_minIsInfinite)
            {
                c.m_minIsInfinite = true;
            }
            else if (a.m_min < b.m_min)
            {
                c.m_min = a.m_min;
                c.m_minIsIncluded = a.m_minIsIncluded;
            }
            else if (b.m_min < a.m_min)
            {
                c.m_min = b.m_min;
                c.m_minIsIncluded = b.m_minIsIncluded;
            }
            else
            {
                c.m_min = a.m_min;
                c.m_minIsIncluded = a.m_minIsIncluded || b.m_minIsIncluded;
            }

            if (a.m_maxIsInfinite || b.m_maxIsInfinite)
            {
                c.m_maxIsInfinite = true;
            } 
            else if (a.m_max > b.m_max)
            {
                c.m_max = a.m_max;
                c.m_maxIsIncluded = a.m_maxIsIncluded;
            }
            else if (b.m_max > a.m_max)
            {
                c.m_max = b.m_max;
                c.m_maxIsIncluded = b.m_maxIsIncluded;
            }
            else
            {
                c.m_max = b.m_max;
                c.m_maxIsIncluded = a.m_maxIsIncluded || b.m_maxIsIncluded;
            }

            return c;
        }

        public static IntegerRange Intersection(IntegerRange a, IntegerRange b)
        {
            IntegerRange c = new IntegerRange();

            if (a.m_minIsInfinite && b.m_minIsInfinite)
            {
                c.m_minIsInfinite = true;
            }
            else if (a.m_minIsInfinite && !b.m_minIsInfinite)
            {
                c.m_min = b.m_min;
                c.m_minIsIncluded = b.m_minIsIncluded;
            }
            else if (!a.m_minIsInfinite && b.m_minIsInfinite) 
            {
                c.m_min = a.m_min;
                c.m_minIsIncluded = a.m_minIsIncluded;
            }
            else if (a.m_min < b.m_min)
            {
                c.m_min = b.m_min;
                c.m_minIsIncluded = b.m_minIsIncluded;
            }
            else if (b.m_min < a.m_min)
            {
                c.m_min = a.m_min;
                c.m_minIsIncluded = a.m_minIsIncluded;
            }
            else
            {
                c.m_min = a.m_min;
                c.m_minIsIncluded = a.m_minIsIncluded && b.m_minIsIncluded;
            }

            if (a.m_maxIsInfinite && b.m_maxIsInfinite)
            {
                c.m_maxIsInfinite = true;
            }
            else if (a.m_maxIsInfinite && !b.m_maxIsInfinite)
            {
                c.m_max = b.m_max;
                c.m_maxIsIncluded = b.m_maxIsIncluded;
            }
            else if (!a.m_maxIsInfinite && b.m_maxIsInfinite)
            {
                c.m_max = a.m_max;
                c.m_maxIsIncluded = a.m_maxIsIncluded;
            }
            else if (a.m_max > b.m_max)
            {
                c.m_max = b.m_max;
                c.m_maxIsIncluded = b.m_maxIsIncluded;
            }
            else if (b.m_max > a.m_max)
            {
                c.m_max = a.m_max;
                c.m_maxIsIncluded = a.m_maxIsIncluded;
            }
            else
            {
                c.m_max = b.m_max;
                c.m_maxIsIncluded = a.m_maxIsIncluded && b.m_maxIsIncluded;
            }

            return c;
        }

        public override string ToString()
        {
            return m_min.ToString() + ".." + m_max.ToString();
        }


    }

    public class PEREffectiveConstraint
    {
        public virtual PEREffectiveConstraint  Compute(List<IConstraint> cons, Asn1Type type) 
        {
            throw new Exception("Abstract Method Called");
        }
        public static PEREffectiveConstraint Intersection(PEREffectiveConstraint a, PEREffectiveConstraint b)
        {
            if (a is PERIntegerEffectiveConstraint && b is PERIntegerEffectiveConstraint)
                return PERIntegerEffectiveConstraint.Intersection((PERIntegerEffectiveConstraint)a, (PERIntegerEffectiveConstraint)b);
            if (a is PERSizeEffectiveConstraint && b is PERSizeEffectiveConstraint)
                return PERSizeEffectiveConstraint.Intersection((PERSizeEffectiveConstraint)a, (PERSizeEffectiveConstraint)b);
            if (a is PERAlphabetAndSizeEffectiveConstraint && b is PERAlphabetAndSizeEffectiveConstraint)
                return PERAlphabetAndSizeEffectiveConstraint.Intersection((PERAlphabetAndSizeEffectiveConstraint)a,
                    (PERAlphabetAndSizeEffectiveConstraint)b);

            throw new Exception("Internal Error");
        }

        public virtual bool Extensible { 
            get { throw new Exception("Abstract Method Called"); } 
            set { throw new Exception("Abstract Method Called"); } 
        }


        public virtual void PrintAsn1(StreamWriterLevel o)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }




    public class PERIntegerEffectiveConstraint : PEREffectiveConstraint
    {
        public IntegerRange m_rootRange=null;
        public bool m_isExtended=false;
        public IntegerRange m_extRange=null;

        public override bool Extensible { 
            get { return m_isExtended; } 
            set { m_isExtended = value; } 
        }

/*
        public bool IsValid()
        {
            if (m_extRange != null)
                return m_rootRange.IsValid() && m_extRange.IsValid();
            return m_rootRange.IsValid();
        }
 */ 

        public static PERIntegerEffectiveConstraint UncostraintInteger
        {
            get
            {
                PERIntegerEffectiveConstraint ret = new PERIntegerEffectiveConstraint();
                ret.m_rootRange = IntegerRange.UncostraintInteger;
                return ret;
            }
        }

        public static PERIntegerEffectiveConstraint UncostraintPosInteger
        {
            get
            {
                PERIntegerEffectiveConstraint ret = new PERIntegerEffectiveConstraint();
                ret.m_rootRange = IntegerRange.UncostraintPosInteger;

                return ret;
            }
        }

        public static PERIntegerEffectiveConstraint Union(PERIntegerEffectiveConstraint a, PERIntegerEffectiveConstraint b)
        {
            PERIntegerEffectiveConstraint c = new PERIntegerEffectiveConstraint();
            c.m_rootRange = IntegerRange.Union(a.m_rootRange, b.m_rootRange);

            c.m_isExtended = a.m_isExtended || b.m_isExtended;

            if (a.m_extRange!=null && b.m_extRange==null)
                c.m_extRange = a.m_extRange.Clone();
            else if (a.m_extRange==null && b.m_extRange!=null)
                c.m_extRange = b.m_extRange.Clone();
            else if (a.m_extRange != null && b.m_extRange != null)
                c.m_extRange = IntegerRange.Union(a.m_extRange, b.m_extRange);

            return c;
        }

        
        public static PERIntegerEffectiveConstraint Intersection(PERIntegerEffectiveConstraint a, PERIntegerEffectiveConstraint b)
        {
            PERIntegerEffectiveConstraint c = new PERIntegerEffectiveConstraint();
            c.m_rootRange = IntegerRange.Intersection(a.m_rootRange, b.m_rootRange);

            c.m_isExtended = a.m_isExtended || b.m_isExtended;

            if (a.m_extRange != null && b.m_extRange == null)
                c.m_extRange = a.m_extRange.Clone();
            else if (a.m_extRange == null && b.m_extRange != null)
                c.m_extRange = b.m_extRange.Clone();
            else if (a.m_extRange != null && b.m_extRange != null)
                c.m_extRange = IntegerRange.Intersection(a.m_extRange, b.m_extRange);

            return c;
        }

        public override PEREffectiveConstraint Compute(List<IConstraint> cons, Asn1Type type)
        {
            PERIntegerEffectiveConstraint ret = PERIntegerEffectiveConstraint.UncostraintInteger;
            
            foreach (IConstraint con in cons)
            {
                ret = Intersection(ret, con.PEREffectiveIntegerRange);
            }
            return ret;
        }

        public override void PrintAsn1(StreamWriterLevel o)
        {
            o.Write("[");
            m_rootRange.PrintAsn1(o);
            if (Extensible)
                o.Write(",...");
            if (m_extRange != null)
            {
                o.Write(",");
                m_extRange.PrintAsn1(o);
            }
            o.Write("]");
        }

        public override string ToString()
        {
            string ret = m_rootRange.ToString();
            if (Extensible)
                ret+=",...";
            if (m_extRange != null)
            {
                ret += "," + m_extRange.ToString();
            }

            return ret;
        }
    }

    /// <summary>
    /// SEQUENCE OF, SET OF, BIT STRING, OCTECT STRING
    /// </summary>

    public class PERSizeEffectiveConstraint : PEREffectiveConstraint
    {
        public PERIntegerEffectiveConstraint m_size = null;

        public PERSizeEffectiveConstraint(PERIntegerEffectiveConstraint size)
        {
            m_size = size;
        }

        public PERSizeEffectiveConstraint()
        {
            m_size = PERIntegerEffectiveConstraint.UncostraintPosInteger;
        }
        public static PERSizeEffectiveConstraint Full
        {
            get { return new PERSizeEffectiveConstraint(); }
        }

        public static PERSizeEffectiveConstraint Empty
        {
            get {
                PERSizeEffectiveConstraint ret = new PERSizeEffectiveConstraint();
                ret.m_size = new PERIntegerEffectiveConstraint();
                ret.m_size.m_rootRange = new IntegerRange();
                return ret; 
            }
        }

        public override bool Extensible { 
            get { return m_size.Extensible; } 
            set { m_size.Extensible = value; } 
        }

/*
        public bool IsValid()
        {
            return m_size.IsValid();
        }
*/

        public static PERSizeEffectiveConstraint Union(PERSizeEffectiveConstraint a, PERSizeEffectiveConstraint b)
        {
            PERSizeEffectiveConstraint c = new PERSizeEffectiveConstraint();

            c.m_size = PERIntegerEffectiveConstraint.Union(a.m_size, b.m_size);

            return c;
        }

        public static PERSizeEffectiveConstraint Intersection(PERSizeEffectiveConstraint a, PERSizeEffectiveConstraint b)
        {
            PERSizeEffectiveConstraint c = new PERSizeEffectiveConstraint();

            c.m_size = PERIntegerEffectiveConstraint.Intersection(a.m_size, b.m_size);

            return c;
        }


        public override PEREffectiveConstraint Compute(List<IConstraint> cons, Asn1Type type)
        {
            PERSizeEffectiveConstraint ret = PERSizeEffectiveConstraint.Full;

            foreach (IConstraint con in cons)
            {
                PERSizeEffectiveConstraint c = con.PEREffectiveSizeConstraint;
                if (c!=null)
                    ret = Intersection(ret, c);
            }
            return ret;

        }

        public override void PrintAsn1(StreamWriterLevel o)
        {
            
            o.Write("SIZE [");
            m_size.m_rootRange.PrintAsn1(o);
            if (m_size.Extensible)
                o.Write(",...");
            if (m_size.m_extRange != null)
            {
                o.Write(",");
                m_size.m_extRange.PrintAsn1(o);
            }
            o.Write("]");

        }

        public override string ToString()
        {
            return "SIZE["+ m_size.ToString()+"]";
        }


//        public static 

    }


    public class CharSet
    {
        public List<Char> m_set = new List<char>();


        public CharSet()
        {
        }

        public CharSet(List<Char> set)
        {
            m_set = new List<char>(set);
        }

        public CharSet(Char min, Char max)
        {
            m_set = new List<char>();
            for (Char ch = min; ch <= max; ch++)
                m_set.Add(ch);
        }

        public static CharSet GetEmptySet()
        {
            return new CharSet();
        }
        
        public static CharSet FullSet(Asn1Type type)
        {
            IStringType strType = type as IStringType;
            if (strType == null)
                throw new Exception("Internal Error");

            return new CharSet(new List<char>(strType.AllowedCharSet));
        }

        public void PrintAsn1(StreamWriterLevel o)
        {
        }


        public CharSet Clone()
        {
            return new CharSet(m_set);
        }


        public static CharSet Union(CharSet a, CharSet b)
        {
            CharSet c = a.Clone();

            foreach (Char ch in b.m_set)
                if (!c.m_set.Contains(ch))
                    c.m_set.Add(ch);

            c.m_set.Sort();
            return c;
        }

        public static CharSet Intersection(CharSet a, CharSet b)
        {
            CharSet c = new CharSet();

            foreach (Char ch in a.m_set)
                if (b.m_set.Contains(ch))
                    c.m_set.Add(ch);

            c.m_set.Sort();
            return c;
        }

        public override string ToString()
        {
            string ret="";
            foreach(Char ch in m_set)
                    ret+=ch.ToString();

            return ret;
        }


    }


    public class PERAlphabetAndSizeEffectiveConstraint : PEREffectiveConstraint
    {
        public PERIntegerEffectiveConstraint m_size = null;
        public CharSet m_from = null;

        public PERAlphabetAndSizeEffectiveConstraint()
        {
        }

        public PERAlphabetAndSizeEffectiveConstraint(PERIntegerEffectiveConstraint size)
        {
            m_size = size;
        }

        public PERAlphabetAndSizeEffectiveConstraint(List<Char> charSet)
        {
            m_from = new CharSet(charSet);
        }

        public PERAlphabetAndSizeEffectiveConstraint(Char? min, Char? max, IStringType strType)
        {
            if (strType == null)
                throw new Exception("Internal Error");
            if (min ==null && max ==null)
                throw new Exception("Internal Error");

            if (min != null && max != null)
            {
                m_from = new CharSet(min.Value, max.Value);
            }
            else if (min != null && max == null)
            {
                m_from = new CharSet(min.Value, strType.AllowedCharSet[strType.AllowedCharSet.Length - 1]);
            }
            else if (min == null && max != null)
            {
                m_from = new CharSet(strType.AllowedCharSet[0], max.Value);
            }
            
        }

        public static PERAlphabetAndSizeEffectiveConstraint Full(Asn1Type type)
        {
            PERAlphabetAndSizeEffectiveConstraint ret = new PERAlphabetAndSizeEffectiveConstraint();

            ret.m_size = PERIntegerEffectiveConstraint.UncostraintPosInteger;
            ret.m_from = null;

            return ret;
        }

        public static PERAlphabetAndSizeEffectiveConstraint Empty
        {
            get
            {
                PERAlphabetAndSizeEffectiveConstraint ret = new PERAlphabetAndSizeEffectiveConstraint();
                ret.m_size = new PERIntegerEffectiveConstraint();
                ret.m_size.m_rootRange = new IntegerRange();
                ret.m_from = CharSet.GetEmptySet();
                return ret;
            }
        }

        public override bool Extensible
        {
            get { return m_size.Extensible; }
            set { 
                m_size.Extensible = value;
                if (value)
                    m_from = null;
            }
        }

        public static PERAlphabetAndSizeEffectiveConstraint Union(PERAlphabetAndSizeEffectiveConstraint a, PERAlphabetAndSizeEffectiveConstraint b)
        {
            PERAlphabetAndSizeEffectiveConstraint c = new PERAlphabetAndSizeEffectiveConstraint();
            if (a == null || b==null)
                return null;


            if (a.m_size != null && b.m_size != null)
                c.m_size = PERIntegerEffectiveConstraint.Union(a.m_size, b.m_size);

            if (a.m_from != null && b.m_from != null)
                c.m_from = CharSet.Union(a.m_from, b.m_from);
            if (c.m_size == null && c.m_from == null)
                return null;
            return c;
        }

        public static PERAlphabetAndSizeEffectiveConstraint Intersection(PERAlphabetAndSizeEffectiveConstraint a, PERAlphabetAndSizeEffectiveConstraint b)
        {
            PERAlphabetAndSizeEffectiveConstraint c = new PERAlphabetAndSizeEffectiveConstraint();
            if (a == null)
                return b;
            if (b == null)
                return a;
            
            if (a.m_size != null && b.m_size != null)
                c.m_size = PERIntegerEffectiveConstraint.Intersection(a.m_size, b.m_size);
            else if (a.m_size != null && b.m_size == null)
                c.m_size = a.m_size;
            else if (a.m_size == null && b.m_size != null)
                c.m_size = b.m_size;
            
            if (a.m_from != null && b.m_from != null)
                c.m_from = CharSet.Intersection(a.m_from, b.m_from);
            else if (a.m_from != null && b.m_from == null)
                c.m_from = a.m_from;
            else if (a.m_from == null && b.m_from != null)
                c.m_from = b.m_from;

            if (c.m_size == null && c.m_from == null)
                return null;
            return c;
        }

        public override PEREffectiveConstraint Compute(List<IConstraint> cons, Asn1Type type)
        {
            PERAlphabetAndSizeEffectiveConstraint ret = PERAlphabetAndSizeEffectiveConstraint.Full(type);

            foreach (IConstraint con in cons)
            {
                PERAlphabetAndSizeEffectiveConstraint c = con.PEREffectiveAlphabetAndSizeConstraint;
                if (c != null)
                    ret = Intersection(ret, c);
            }
            return ret;

        }
        public override void PrintAsn1(StreamWriterLevel o)
        {
            if (m_size != null)
            {

                o.Write("SIZE [");
                m_size.m_rootRange.PrintAsn1(o);
                if (m_size.Extensible)
                    o.Write(",...");
                if (m_size.m_extRange != null)
                {
                    o.Write(",");
                    m_size.m_extRange.PrintAsn1(o);
                }
                o.Write("]");
            }
            if (m_from != null)
            {
                o.Write("FROM [\"");
                o.Write(m_from.ToString());
                o.Write("\"]");
            }
        }
        public override string ToString()
        {
            string ret = "null";
            if (m_size !=null)
                ret+= "SIZE[" + m_size.ToString() + "]";
            if (m_from != null)
                ret += " FROM[\"" + m_from.ToString() + "\"]";
            return ret;
        }
    }



 
    public class PER
    {

        //List<bool> represents a stream of bits. [0] is the most significant bit

        public static List<bool> EncodeNonNegativeInteger(UInt64 v) 
        {
            List<bool> ret = new List<bool>();


            UInt64 mask=1;

            while (v>0)
            {
                bool curBit = (v & mask) > 0;
                ret.Insert(0,curBit);
                v >>= 1;
            }

            return ret;
        }

        public static List<bool> Encode2ndComplementInteger(Int64 v)
        {
            List<bool> ret = new List<bool>();
            if (v >= 0)
            {
                ret.Add(false);
                ret.AddRange(EncodeNonNegativeInteger((UInt64)v));
            }
            else
            {
                ret.Add(true);
                List<bool> ret2 = EncodeNonNegativeInteger((UInt64)(-v - 1));
                foreach (bool bit in ret2)
                    ret.Add(!bit);
            }
                
            return ret;
        }

        public static int GetNumberOfBitsForNonNegativeInteger(UInt64 v)
        {
            int ret = 0;
            
            while (v > 0)
            {
                v >>= 1;
                ret++;
            }
            return ret;
        }


        public static int GetLengthInBytesOfUInt(UInt64 v)
        {
            UInt64 curLimit=0xFF;
            for (int i = 1; i <= 7; i++)
            {
                if (v <= curLimit)
                    return i;
                curLimit <<= 8;
                curLimit |= 0xFF;
            }
            return 8;
        }

        public static int GetLengthSIntHelper(UInt64 v)
        {
            if (v > Int64.MaxValue)
                throw new Exception("Internal Error");
            UInt64 curLimit = 0x7F;
            for (int i = 1; i <= 7; i++)
            {
                if (v <= curLimit)
                    return i;
                curLimit <<= 8;
                curLimit |= 0xFF;
            }
            return 8;
        }

        public static int GetLengthInBytesOfSInt(Int64 v)
        {
            if (v >= 0)
                return GetLengthSIntHelper((UInt64)v);

            return GetLengthSIntHelper((UInt64)(-v - 1));
        }
        
 
        public static List<bool> EncodeConstraintWholeNumber(Int64 v, Int64 min, Int64 max)
        {
            if (min > max)
                throw new ArgumentException();
            if (min == max)
                return new List<bool>();

            UInt64 range = (UInt64)(max - min );
            int nBits = GetNumberOfBitsForNonNegativeInteger(range);

            List<bool> ret = EncodeNonNegativeInteger((UInt64)(v - min));
            while (ret.Count < nBits)
                ret.Insert(0, false);

            return ret;
        }

        public static List<bool> EncodeNormallySmallNonNegativeNumber(UInt64 v)
        {
            List<bool> ret = null;
            if (v <= 63)
                ret = EncodeConstraintWholeNumber((Int64)v, 0, 127); //7 bits, first bit is always 0
            else
            {
                ret = new List<bool>();
                ret.Add(true);  //first bit is zero
                if (v > Int64.MaxValue)
                    throw new Exception("Internal Error");
                ret.AddRange(EncodeSemiConstraintWholeNumber((Int64)v, 0));
            }

            return ret;
        }
        
        public static List<bool> EncodeSemiConstraintWholeNumber(Int64 v, Int64 min)
        {
            List<bool> ret = null;
            int nBytes = GetLengthInBytesOfUInt((UInt64)(v - min));
            if (nBytes >= 9)
                throw new Exception("Internal Error");

            ret = EncodeConstraintWholeNumber(nBytes, 0, 255); //8 bits, first bit is always 0
            List<bool> realContent = EncodeNonNegativeInteger((UInt64)(v - min));
            while (realContent.Count < 8 * nBytes)
                realContent.Insert(0, false);
            ret.AddRange(realContent);

            return ret;
        }
        
        public static List<bool> EncodeUnConstraintWholeNumber(Int64 v)
        {
            List<bool> ret = null;
            int nBytes = GetLengthInBytesOfSInt(v);
            if (nBytes >= 9)
                throw new Exception("Internal Error");
            ret = EncodeConstraintWholeNumber(nBytes, 0, 255); //8 bits, first bit is always 0
            List<bool> realContent = Encode2ndComplementInteger(v);
            bool signBit = v < 0;
            while (realContent.Count < 8 * nBytes)
                realContent.Insert(0, signBit);
            ret.AddRange(realContent);
            return ret;
        }

/*        public static List<bool> EncodeLength12(UInt64 len)
        {
            List<bool> ret = null;
            if (len <= 127)
                ret = EncodeConstraintWholeNumber((Int64)len, 0, 255);   //8 bits, first bit is always 0
            else if (len<=16383)
            {
                ret = EncodeConstraintWholeNumber((Int64)len, 0, 32767);   //15 bits, first bit is always 0
                ret.Insert(0, true);
            }

            return ret;
        }

        public static List<List<bool>> EncodeLength3(UInt64 len)
        {
            return null;
        }*/
    }


}