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

        public bool IsValid()
        {
            if (m_max == Config.MININT)
                return false;
            if (m_min == Config.MAXINT)
                return false;
            if (m_maxIsInfinite || m_minIsInfinite)
                return true;
            return m_min <= m_max;
        }

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
        public virtual PEREffectiveConstraint  Compute(List<IConstraint> cons) 
        {
            throw new Exception("Abstract Method Called");
        }
        public static PEREffectiveConstraint Intersection(PEREffectiveConstraint a, PEREffectiveConstraint b)
        {
            if (a is PERIntegerEffectiveConstraint && b is PERIntegerEffectiveConstraint)
                return PERIntegerEffectiveConstraint.Intersection((PERIntegerEffectiveConstraint)a, (PERIntegerEffectiveConstraint)b);
            if (a is PERSizeEffectiveConstraint && b is PERSizeEffectiveConstraint)
                return PERSizeEffectiveConstraint.Intersection((PERSizeEffectiveConstraint)a, (PERSizeEffectiveConstraint)b);

            throw new Exception("Internal Error");
        }

        public virtual bool Extensible { get { throw new Exception("Abstract Method Called"); } }


        public virtual void PrintAsn1(StreamWriterLevel o)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }




    public class PERIntegerEffectiveConstraint : PEREffectiveConstraint
    {
        public IntegerRange m_rootRange=null;
        public bool m_hasExtension=false;
        public IntegerRange m_extRange=null;

        public override bool Extensible { get { return m_hasExtension; } }


        public bool IsValid()
        {
            if (m_extRange != null)
                return m_rootRange.IsValid() && m_extRange.IsValid();
            return m_rootRange.IsValid();
        }

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

            c.m_hasExtension = a.m_hasExtension || b.m_hasExtension;

            if (a.m_hasExtension && !b.m_hasExtension)
                c.m_extRange = a.m_extRange.Clone();
            else if (!a.m_hasExtension && b.m_hasExtension)
                c.m_extRange = b.m_extRange.Clone();
            else if (a.m_hasExtension && b.m_hasExtension)
                c.m_extRange = IntegerRange.Union(a.m_extRange, b.m_extRange);

            return c;
        }

        
        public static PERIntegerEffectiveConstraint Intersection(PERIntegerEffectiveConstraint a, PERIntegerEffectiveConstraint b)
        {
            PERIntegerEffectiveConstraint c = new PERIntegerEffectiveConstraint();
            c.m_rootRange = IntegerRange.Intersection(a.m_rootRange, b.m_rootRange);

            c.m_hasExtension = a.m_hasExtension || b.m_hasExtension;

            if (a.m_hasExtension && !b.m_hasExtension)
                c.m_extRange = a.m_extRange.Clone();
            else if (!a.m_hasExtension && b.m_hasExtension)
                c.m_extRange = b.m_extRange.Clone();
            else if (a.m_hasExtension && b.m_hasExtension)
                c.m_extRange = IntegerRange.Intersection(a.m_extRange, b.m_extRange);

            return c;
        }

        public override PEREffectiveConstraint Compute(List<IConstraint> cons)
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
        PERIntegerEffectiveConstraint m_size = null;

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
                return ret; 
            }
        }

        public override bool Extensible { get { return m_size.Extensible; } }


        public bool IsValid()
        {
            return m_size.IsValid();
        }


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


        public override PEREffectiveConstraint Compute(List<IConstraint> cons)
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

    public class PERAlphabetAndSizeEffectiveConstraint : PEREffectiveConstraint
    {
    }



 
    public class PER
    {

        //List<bool> represents a stream of bits. [0] is the most significant bit

        public static List<bool> EncodeNonNegativeInteger(UInt64 v) 
        {
            List<bool> ret = new List<bool>();
            return ret;
        }

        public static List<bool> Encode2ndComplementInteger(Int64 v)
        {
            List<bool> ret = new List<bool>();
            return ret;
        }

        public static int GetNumberOfBitsForNonNegativeInteger(UInt64 v)
        {
            return EncodeNonNegativeInteger(v).Count;
        }

        public static int GetNumberOfBits2ndComplementInteger(Int64 v)
        {
            return Encode2ndComplementInteger(v).Count;
        }

        public static List<bool> EncodeConstraintWholeNumber(Int64 v, Int64 min, Int64 max)
        {
            if (min > max)
                throw new ArgumentException();
            
            UInt64 range = (UInt64)(max-min+1);
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
            UInt64 nBits = (UInt64)GetNumberOfBitsForNonNegativeInteger((UInt64)(v-min));
            if (nBits >= 128)
                throw new Exception("Internal Error");

            ret = EncodeLength12(nBits); //8 bits, first bit is always 0
            ret.AddRange(EncodeNonNegativeInteger((UInt64)(v - min)));

            return ret;
        }
        
        public static List<bool> EncodeUnConstraintWholeNumber(Int64 v)
        {
            List<bool> ret = null;
            UInt64 nBits = (UInt64)GetNumberOfBits2ndComplementInteger(v);
            if (nBits >= 16384)
                throw new Exception("Internal Error");
            ret = EncodeLength12(nBits);   //8 bits, first bit is always 0
            ret.AddRange(Encode2ndComplementInteger(v));
            return ret;
        }

        public static List<bool> EncodeLength12(UInt64 len)
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
        }
    }


}