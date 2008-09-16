/**=============================================================================
Definitions of all classes related to ASN.1 constraints semantic checking
in autoICD and asn1scc projects  
================================================================================
Copyright(c) Semantix Information Technologies S.A www.semantix.gr
All rights reserved.

This source code is only intended as a supplement to the
Semantix Technical Reference and related electronic documentation 
provided with the autoICD and asn1scc applications.
See these sources for detailed information regarding the
asn1scc and autoICD applications.
==============================================================================*/
using System;
using System.Collections.Generic;
using System.Text;

namespace tinyAsn1
{

     
    
    public interface ISet 
    {
        ISet Union(ISet s);
        ISet Intersect(ISet s2);
        ISet Minus(ISet s2);
        ISet Complement();
        bool isNull();
        SetDimension Dimension { get;}
        ISet Simplify();

        /// <summary>
        /// returns one (random) value from the set.
        /// It returns null, if no value can be calcualted
        /// </summary>
        /// <returns></returns>
        Asn1Value GetOneValue();
    }


    

    public class NullSet : ISet
    {
        #region ISet Members

        public ISet Union(ISet s)
        {
            return s;
        }

        public ISet Intersect(ISet s2)
        {
            return this;
        }

        public ISet Minus(ISet s2)
        {
            return this;
        }

        public ISet Complement()
        {
            return new UniversalSet();
        }

        public bool isNull()
        {
            return true;
        }

        public SetDimension Dimension
        {
            get { return  SetDimension.Mixed; }
        }

        public ISet Simplify()
        {
            return this;
        }

        public override string ToString()
        {
            return "NULL_SET";
        }

        public Asn1Value GetOneValue()
        {
            return null;
        }
        #endregion
    }

    public class UniversalSet : ISet
    {

        public ISet Union(ISet s)
        {
            return this;
        }

        public ISet Intersect(ISet s2)
        {
            return s2;
        }

        public ISet Minus(ISet s2)
        {
            return s2.Complement();
        }

        public ISet Complement()
        {
            return new NullSet();
        }

        public bool isNull()
        {
            return false;
        }

        public SetDimension Dimension
        {
            get { return  SetDimension.Mixed; }
        }

        public ISet Simplify()
        {
            return this;
        }

        public override string ToString()
        {
            return "UNIVERSAL_SET";
        }
        public Asn1Value GetOneValue()
        {
            return null;
        }
    }


    public enum SetDimension 
    {
        Value,
        Size,
        Alphabet,
        Mixed
    }


    
    public class UnionSet : ISet
    {
        List<ISet> m_items = new List<ISet>();

        public UnionSet Clone()
        {
            UnionSet ret = new UnionSet();
            ret.m_items.AddRange(m_items);
            return ret;
        }

        public ISet Simplify()
        {
            for (int i = 0; i < m_items.Count; i++)
                m_items[i] = m_items[i].Simplify();

            if (m_items.Count == 1)
                return m_items[0];
            return this;
        }

        
        
        public void AddUnionItem(ISet s)
        {
            if (s.Dimension != SetDimension.Mixed)
            {
                bool added = false;

                for (int i = 0; i < m_items.Count; i++)
                {
                    if (m_items[i].Dimension == s.Dimension)
                    {
                        m_items[i] = m_items[i].Union(s);
                        added = true;
                    }
                }
                if (!added)
                    m_items.Add(s);
            }
            else if (s is UnionSet)
            {
                UnionSet o = s as UnionSet;
                foreach (ISet iset in o.m_items)
                    AddUnionItem(iset);
            }
            else
            {
                m_items.Add(s);
            }

        }

        public UnionSet() { }

        


        #region ISet Members

        public ISet Union(ISet s)
        {

            UnionSet ret = Clone();
            ret.AddUnionItem(s);
            return ret;
        }

        public ISet Intersect(ISet s2)
        {
            if (s2.Dimension != SetDimension.Mixed)
            {
                UnionSet ret = new UnionSet();

                foreach (ISet s in m_items)
                {
                    if (s.Dimension == s2.Dimension)
                        ret.AddUnionItem(s.Intersect(s2));
                    else
                        ret.AddUnionItem(IntersectionSet.Create(s, s2));
                }

                return ret;
            }
            else
            {
                if (s2 is UnionSet)
                {
                    UnionSet ret = new UnionSet();
                    UnionSet o = s2 as UnionSet;
                    foreach (ISet si in m_items)
                        foreach (ISet sj in o.m_items)
                            ret.AddUnionItem(si.Intersect(si));

                    return ret;
                }
                else if (s2 is IntersectionSet)
                {
                    UnionSet ret = new UnionSet();
                    foreach (ISet si in m_items)
                        ret.AddUnionItem(s2.Intersect(si));
                    return ret;
                }
            }

            throw new Exception();

        }

        public ISet Minus(ISet s2)
        {
            return Intersect(s2.Complement());
        }

        public ISet Complement()
        {
            IntersectionSet ret = new IntersectionSet();

            foreach (ISet s in m_items)
                ret.AddItem(s.Complement());

            return ret;
            
        }

        public bool isNull()
        {
            foreach (ISet s in m_items)
                if (!s.isNull())
                    return false;
            return true;
        }

        public SetDimension Dimension
        {
            get { return SetDimension.Mixed; }
        }

        public override string ToString()
        {
            string ret = "UNION(";

            foreach (ISet s in m_items)
                ret += s.ToString() + ",";

            if (ret.EndsWith(","))
                ret = ret.Substring(0, ret.Length - 1);
            ret += ")";
            return ret;
        }


        #endregion
        public Asn1Value GetOneValue()
        {
            return null;
        }
    }


    /// <summary>
    /// Intersection of 'primitive' sets. Eeach Intersection can have up to 3 sets one for each dimension
    /// </summary>
    public class IntersectionSet : ISet
    {

        public List<ISet> m_items = new List<ISet>();

        public IntersectionSet Clone()
        {
            IntersectionSet ret = new IntersectionSet();
            ret.m_items.AddRange(m_items);
            return ret;
        }

        public static IntersectionSet Create(ISet s1, ISet s2)
        {

            IntersectionSet ret = new IntersectionSet();
            ret.m_items.Add(s1);
            ret.m_items.Add(s2);
            return ret;
        }

        public void AddItem(ISet s) 
        {

            if (s.Dimension != SetDimension.Mixed)
            {
                bool added = false;

                for (int i = 0; i < m_items.Count; i++)
                {
                    if (m_items[i].Dimension == s.Dimension)
                    {
                        m_items[i] = m_items[i].Intersect(s);
                        added = true;
                    }
                }
                if (!added)
                    m_items.Add(s);
            }
            else if (s is UnionSet)
            {
                m_items.Add(s);
            }
            else if (s is IntersectionSet)
            {
                IntersectionSet o = s as IntersectionSet;
                foreach (ISet s2 in o.m_items)
                    AddItem(s2);
            }


        }

        public IntersectionSet()
        {
        }


        #region ISet Members

        public ISet Union(ISet s2)
        {

            IntersectionSet ret = new IntersectionSet();
            foreach (ISet s in m_items)
                ret.AddItem(s.Union(s2));
            
            return ret;
        }

        public ISet Intersect(ISet s2)
        {
            if (s2 is UniversalSet)
                return this;
            IntersectionSet ret = Clone();
            ret.AddItem(s2);
            return ret;
        }

        public ISet Minus(ISet s2)
        {
            return Intersect(s2.Complement());
        }

        public ISet Complement()
        {
            UnionSet ret = new UnionSet();
            foreach (ISet s in m_items)
                ret.AddUnionItem(s.Complement());
            return ret;
        }
        public bool isNull()
        {
            foreach (ISet s in m_items)
                if (s.isNull())
                    return true;

            DiscreetValueSet<Asn1Value> vs=null;
            foreach (ISet s in m_items)
                if (s is DiscreetValueSet<Asn1Value>)
                {
                    vs = s as DiscreetValueSet<Asn1Value>;
                    break;
                }

            if (vs != null && !vs.HasInfiniteValues)
            {
                foreach (ISet s in m_items)
                {
                    if (s.Dimension == SetDimension.Size)
                    {
                        SizeSet ss = s as SizeSet;

                        bool isnull = true;

                        foreach (Asn1Value v in vs.Values)
                        {
                            ISize size = v as ISize;

                            if (ss.Contains((ulong)size.Size))
                            {
                                isnull = false;
                                break;
                            }
                        }
                        if (isnull)
                            return true;

                    }

                    if (s.Dimension == SetDimension.Alphabet)
                    {
                        AlphabetSet aset = s as AlphabetSet;

                        bool isnull = true;

                        foreach (Asn1Value v in vs.Values)
                        {
                            IA5StringValue str = v as IA5StringValue;

                            if (aset.StringIsValid(str.Value) )
                            {
                                isnull = false;
                                break;
                            }
                        }

                        if (isnull)
                            return true;

                    }
                }
            }
            


            return false;
        }
        public SetDimension Dimension
        {
            get { return SetDimension.Mixed; }
        }
        public ISet Simplify()
        {
            for (int i = 0; i < m_items.Count; i++)
                m_items[i] = m_items[i].Simplify();

            if (m_items.Count == 1)
                return m_items[0];
            return this;
        }

        #endregion

        public override string ToString()
        {
            string ret = "INTERSECTION(";

            foreach (ISet s in m_items)
                ret += s.ToString() + ",";

            if (ret.EndsWith(","))
                ret = ret.Substring(0, ret.Length - 1);
            ret += ")";
            return ret;
        }
        public Asn1Value GetOneValue()
        {
            return null;
        }
    }
    
    public class Range<T> where T : IComparable<T>, IEquatable<T>
    {
        
        public T MinValue { get { return _rangeSet.TypeMin; } }

        public T MaxValue { get { return _rangeSet.TypeMax; } }

        public T min;
        public T max;


        
        public bool IsNull()
        {
            return min.CompareTo(max) > 0;
        }

        public bool IsUniverse()
        {
            return min.CompareTo(MinValue) == 0 && max.CompareTo(MaxValue) == 0;
        }

        RangeSet<T> _rangeSet;
        public Range(RangeSet<T> rangeSet)
        {
            _rangeSet = rangeSet;
            this.min = MaxValue;
            this.max = MinValue;
        }

        public Range(RangeSet<T> rangeSet, T Min, T Max)
        {
            _rangeSet = rangeSet;
            System.Diagnostics.Debug.Assert(Min.CompareTo(Max)<=0, "INTERNAL ERROR");            
            this.min = Min;
            this.max = Max;
        }

        public Range<T> Clone()
        {
            return new Range<T>(_rangeSet, min, max);
        }

        public bool Contains(T v)
        {
            return min.CompareTo(v) <= 0 && v.CompareTo(max) <= 0;
        }

        public override bool Equals(object obj)
        {
            Range<T> o = obj as Range<T>;
            if (o == null)
                return false;
            return min.CompareTo(o.min) == 0 && max.CompareTo(o.max) == 0;
        }
        public override int GetHashCode()
        {
            return min.GetHashCode() | max.GetHashCode();
        }

        public override string ToString()
        {
            if (IsNull())
                return string.Empty;
            return string.Format("[{0},{1}]", min, max);
        }

        public static Range<T> Intersect(Range<T> r1, Range<T> r2)
        {
            Range<T> ret = new Range<T>(r1._rangeSet); // Null set;
            if (r1 == null || r1.IsNull())
                return ret;

            if (r2 == null || r2.IsNull())
                return ret;

            T a = r1.min;
            T b = r1.max;
            T c = r2.min;
            T d = r2.max;
            if (d.CompareTo(a) < 0)
                return ret;
            if (b.CompareTo(c) < 0)
                return ret;
            if (c.CompareTo(a) <= 0 && d.CompareTo(b) <= 0)
                return new Range<T>(r1._rangeSet, a, d);
            if (c.CompareTo(a) <= 0 && b.CompareTo(d) <= 0)
                return new Range<T>(r1._rangeSet, a, b);
            if (a.CompareTo(c) <= 0 && d.CompareTo(b) <= 0)
                return new Range<T>(r1._rangeSet, c, d);
            if (a.CompareTo(c) <= 0 && b.CompareTo(d) <= 0)
                return new Range<T>(r1._rangeSet, c, b);

            throw new Exception("INTERNAL ERROR");
        }

        public RangeSet<T> Complement()
        {
            RangeSet<T> ret = _rangeSet.CreateRangeSet();
            if (IsNull()) 
            {
                ret.m_ranges.Add( new Range<T>(_rangeSet, _rangeSet.TypeMin, _rangeSet.TypeMax ));
                return ret;
            }

            if (IsUniverse())
                return ret; //empty list to indicate null

            if (min.CompareTo(MinValue) == 0)
            {
                ret.m_ranges.Add(new Range<T>(_rangeSet, _rangeSet.GetNextValue(max), MaxValue));
                return ret;
            }
            
            if (max.CompareTo(MaxValue) == 0)
            {
                ret.m_ranges.Add(new Range<T>(_rangeSet, MinValue, _rangeSet.GetPrevValue(min)));
                return ret;
            }

            ret.m_ranges.Add(new Range<T>(_rangeSet, MinValue, _rangeSet.GetPrevValue(min)));
            ret.m_ranges.Add(new Range<T>(_rangeSet, _rangeSet.GetNextValue(max), MaxValue));

            return ret;
        }


    }

    public abstract class RangeSet<T> : ISet where T : IComparable<T>, IEquatable<T>
    {

        public List<Range<T>> m_ranges = new List<Range<T>>();

        
        public abstract T TypeMin { get;}

        public abstract T TypeMax { get;}

        public abstract T GetNextValue(T v);

        public abstract T GetPrevValue(T v);

        public abstract RangeSet<T> CreateRangeSet();


        public ISet Union(ISet s)
        {
            if (GetType() == s.GetType())
                return RangeSet<T>.Union(this, s as RangeSet<T>);
            if (s is UnionSet)
                return s.Union(this);
            
            UnionSet ret = new UnionSet();
            ret.AddUnionItem(this);
            ret.AddUnionItem(s);
            return ret;
        }

        public ISet Intersect(ISet s2)
        {
            if (GetType() == s2.GetType())
                return RangeSet<T>.Intersect(this, s2 as RangeSet<T>);
            if (s2 is IntersectionSet)
                return s2.Intersect(this);

            return IntersectionSet.Create(this, s2);
        }

        public ISet Minus(ISet s2)
        {
            return Intersect(s2.Complement());
        }

        public ISet Complement() { return complement(); }


        public override bool Equals(object obj)
        {
            RangeSet<T> o = obj as RangeSet<T>;
            if (o == null)
                return false;
            if (o.m_ranges.Count != m_ranges.Count)
                return false;
            for (int i = 0; i < m_ranges.Count; i++)
                if (!m_ranges[i].Equals(o.m_ranges[i]))
                    return false;
            return true;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            if (isNull())
                return "RangeSet()";

            string ret = "RangeSet(";

            foreach (Range<T> r in m_ranges)
                if (!r.IsNull())
                    ret += r.ToString() + " ";

            ret += ")";
            return ret;
        }



        private Tuple<int, int> locatePoint(T a)
        {
            Tuple<int, int> A = Tuple.Create(-1, -1);

            T maxPrevRange = TypeMin;

            foreach (Range<T> cr in m_ranges)
            {
                if (cr.Contains(a))
                {
                    A.I1 = m_ranges.IndexOf(cr);
                    A.I2 = A.I1;
                    return A;
                }
                else if (maxPrevRange.CompareTo(a) <= 0 && a.CompareTo(cr.min) < 0)
                {
                    A.I2 = m_ranges.IndexOf(cr);
                    A.I1 = A.I2 - 1;
                    return A;
                }

                maxPrevRange = cr.max;
            }

            if (A.I1 == -1 && A.I2 == -1)
            {
                System.Diagnostics.Debug.Assert(m_ranges[m_ranges.Count - 1].max.CompareTo(a) < 0, "INTERNAL ERROR");
                A.I1 = m_ranges.Count - 1;
                A.I2 = m_ranges.Count;
            }

            return A;

        }

        public void AddRange(T a, T b)
        {
            AddRange( new Range<T>(this, a, b));
        }

        public void AddRange(Range<T> r)
        {
            if (r == null || r.IsNull())
                return;

            if (m_ranges.Count == 0)
            {
                m_ranges.Add(r.Clone());
                return;
            }
            T a = r.min;
            T b = r.max;


            Tuple<int, int> A = locatePoint(a);
            Tuple<int, int> B = locatePoint(b);

            if (A.I2 == m_ranges.Count) // range must be put at the end
            {
                m_ranges.Add(r.Clone());
                return;
            }

            if (B.I1 == -1)
            {
                m_ranges.Insert(0, r.Clone());
                return;
            }

            if (A.Equals(B) && A.I1 != A.I2)
            {
                m_ranges.Insert(A.I2, r.Clone());
                return;
            }

            int firstAffectRange = A.I2;
            if (A.I1 != A.I2)
                m_ranges[firstAffectRange].min = a;
            int lastAffectRange = B.I1;
            if (B.I1 != B.I2)
                m_ranges[lastAffectRange].max = b;

            m_ranges[firstAffectRange].max = m_ranges[lastAffectRange].max;

            while (lastAffectRange > firstAffectRange)
            {
                m_ranges.RemoveAt(lastAffectRange);
                lastAffectRange--;
            }
        }

        public bool isNull()
        {
            foreach (Range<T> r in m_ranges)
                if (!r.IsNull())
                    return false;
            return true;
        }
        
        public static RangeSet<T> Union(RangeSet<T> s1, RangeSet<T> s2)
        {

            RangeSet<T> ret = s1.CreateRangeSet();
            ret.m_ranges.AddRange(s1.m_ranges);
                //new RangeSet<T>(s1.TypeMin, s1.TypeMax, s1.m_ranges);

            foreach (Range<T> r in s2.m_ranges)
                ret.AddRange(r);



            return ret;
        }

        public static RangeSet<T> Intersect(RangeSet<T> s1, RangeSet<T> s2)
        {
            if (s1.isNull() || s2.isNull())
                return s1.CreateRangeSet();//new RangeSet<T>(s1.TypeMin, s1.TypeMax);

            List<Range<T>> rangeList = new List<Range<T>>();
            
            foreach (Range<T> r1 in s1.m_ranges)
                foreach (Range<T> r2 in s2.m_ranges)
                {
                    Range<T> it = Range<T>.Intersect(r1, r2);
                    if (!it.IsNull())
                        rangeList.Add(it);
                }

            RangeSet<T> ret = s1.CreateRangeSet(); //new RangeSet<T>(s1.TypeMin, s1.TypeMax);

            if (rangeList.Count == 0)
                return ret;
            ret.m_ranges.Add(rangeList[0]);
            rangeList.RemoveAt(0);

            foreach (Range<T> r in rangeList)
                ret.AddRange(r);

            return ret;

        }


        public RangeSet<T> complement()
        {
            RangeSet<T> ret;
            if (isNull()) {
                ret = CreateRangeSet();
                ret.AddRange(new Range<T>(ret, TypeMin, TypeMax));
                return ret; //new RangeSet<T>(TypeMin,TypeMax, new Range<T>(this, TypeMin, TypeMax));
            }

            // (A U B)' = A' ^ B^
            List<RangeSet<T>> list = new List<RangeSet<T>>();

            foreach (Range<T> r in m_ranges)
                list.Add(r.Complement());

            System.Diagnostics.Debug.Assert(list.Count>0, "INTERNAL ERROR");

            ret = list[0];

            for (int i = 1; i < list.Count; i++)
            {
                ret = Intersect(ret, list[i]);
            }

            return ret;
        }

        

        public static RangeSet<T> Minus(RangeSet<T> s1, RangeSet<T> s2)
        {
            // B\A = A' ^ B

            return Intersect(s2.complement(), s1);
        }

        public virtual SetDimension Dimension
        {
            get { throw new Exception(); }
        }

        public ISet Simplify()
        {
            return this;
        }

        public bool Contains(T v)
        {
            foreach(Range<T> r in m_ranges)
                if (r.Contains(v))
                    return true;
            return false;
        }

        protected T GetAValidValue()
        {
            if (m_ranges.Count > 0)
                return m_ranges[0].min;
            return default(T);
        }

        public virtual Asn1Value GetOneValue()
        {
            return null;
        }

        
    }

    public class SizeSet : RangeSet<ulong>
    {
        public override RangeSet<ulong> CreateRangeSet()
        {
            return new SizeSet();
        }

        public override ulong TypeMax  { get { return ulong.MaxValue; } }
        public override ulong TypeMin  { get { return 0; } }

        public override ulong GetNextValue(ulong v)  { return v+1; }

        public override ulong GetPrevValue(ulong v)
        {
            if (v>0)
                return v-1;
            throw new Exception();
        }

        public override SetDimension Dimension { get { return  SetDimension.Size; } }

        public override string ToString()
        {
            if (isNull())
                return "SizeSet()";

            string ret = "SizeSet(";

            foreach (Range<ulong> r in m_ranges)
                if (!r.IsNull())
                    ret += r.ToString() + " ";

            ret += ")";
            return ret;
        }

    }

    public class AlphabetSet : RangeSet<Char>
    {
        public IEnumerable<Char> _alphabet;
        public AlphabetSet(IEnumerable<Char> Alphabet) 
        {
            _alphabet = Alphabet;
        }
        
        public override RangeSet<char> CreateRangeSet()
        {
            return new AlphabetSet(_alphabet);
        }

        public override SetDimension Dimension
        {
            get
            {
                return SetDimension.Alphabet;
            }
        }

        public override char TypeMax { get { return EnumerableUtils.GetLast(_alphabet); } }

        public override char TypeMin { get { return EnumerableUtils.GetFirst(_alphabet);  } }

        public override char GetNextValue(char v) { return EnumerableUtils.GetNext(v, _alphabet); }

        public override char GetPrevValue(char v) { return EnumerableUtils.GetPrev(v, _alphabet); }

        public override string ToString()
        {
            if (isNull())
                return "AlphabetSet()";

            string ret = "AlphabetSet(";

            foreach (Range<char> r in m_ranges)
                if (!r.IsNull())
                    ret += r.ToString() + " ";

            ret += ")";
            return ret;
        }

        public bool StringIsValid(string str)
        {
            foreach (Char c in str.ToCharArray())
                if (!Contains(c))
                    return false;
            return true;
        }


    }


    public class IntegerValueSet : RangeSet<long>
    {
        public SizeSet ToSizeSet()
        {
            SizeSet ret = new SizeSet();
            foreach (Range<long> r in m_ranges)
            {
                if (r.min < 0)
                    throw new Exception();
                ret.AddRange((ulong)r.min, (ulong)r.max);
            }
            return ret;
        }

        public override RangeSet<long> CreateRangeSet()
        {
            return new IntegerValueSet();
        }

        public override SetDimension Dimension
        {
            get
            {
                return SetDimension.Value;
            }
        }

        public override long TypeMax
        {
            get { return long.MaxValue; }
        }

        public override long TypeMin
        {
            get { return long.MinValue; }
        }
        public override long GetNextValue(long v)
        {
            return v + 1;
        }

        public override long GetPrevValue(long v)
        {
            return v - 1;
        }

        public override Asn1Value GetOneValue()
        {
            return new IntegerValue(GetAValidValue());
        }
    }

    public class RealValueSet : RangeSet<double>
    {
        public override RangeSet<double> CreateRangeSet()
        {
            return new RealValueSet();
        }

        public override SetDimension Dimension
        {
            get
            {
                return SetDimension.Value;
            }
        }

        public override double TypeMax
        {
            get { return double.PositiveInfinity; }
        }

        public override double TypeMin
        {
            get { return double.NegativeInfinity; }
        }
        public override double GetNextValue(double v)
        {
            double e = double.Epsilon;
            double ret = v + e;
            while (ret <= v)
            {
                ret = v + e;
                e = 2 * e;
            }
            return ret;
        }
        public override double GetPrevValue(double v)
        {
            double e = double.Epsilon;
            double ret = v - e;
            while (ret >= v)
            {
                ret = v - e;
                e = 2 * e;
            }
            return ret;
        }
        public override Asn1Value GetOneValue()
        {
            return new RealValue(GetAValidValue());
        }

    }


    //DiscreetSet
    public abstract class DiscreetValueSetWithInfiniteUniverse<T> : DiscreetValueSet<T>, ISet where T : Asn1Value, IEquatable<T> 
    {

        protected List<T> m_values = new List<T>();

        public virtual IEnumerable<T> Values { get { return m_values; } }

        public virtual bool HasInfiniteValues { get { return false; } }

        public abstract void AddValue(T v);

        public abstract bool Contains(T v);

        public virtual SetDimension Dimension
        {
            get { return SetDimension.Value; }
        }

        public abstract DiscreetValueSetWithInfiniteUniverse<T> Clone();


        public abstract bool isNull();

        public abstract ISet Union(ISet s);

        public abstract ISet Intersect(ISet s2);

        public abstract ISet Minus(ISet s2);

        public abstract ISet Complement();

        public ISet Simplify()
        {
            return this;
        }
        public virtual Asn1Value GetOneValue()
        {
            return null;
        }

    }


    public class DiscreetValueSetWithInfiniteUniverseNorm<T> : DiscreetValueSetWithInfiniteUniverse<T> where T : Asn1Value, IEquatable<T> 
    {
        public override void AddValue(T v)
        {
            if (!m_values.Contains(v))
                m_values.Add(v);
        }

        public override bool Contains(T v)
        {
            return m_values.Contains(v);
        }

        public override bool isNull()
        {
            return m_values.Count == 0;
        }

        public override DiscreetValueSetWithInfiniteUniverse<T> Clone()
        {
            DiscreetValueSetWithInfiniteUniverseNorm<T> ret = new DiscreetValueSetWithInfiniteUniverseNorm<T>();
            ret.m_values.AddRange(m_values);
            return ret;
        }
        public override ISet Union(ISet s)
        {
            DiscreetValueSetWithInfiniteUniverse<T> o = s as DiscreetValueSetWithInfiniteUniverse<T>;
            if (o != null)
            {
                DiscreetValueSetWithInfiniteUniverse<T> ret = o.Clone();

                foreach (T t in m_values)
                    ret.AddValue(t);

                return ret;
            }

            return s.Union(this);

        }

        public override ISet Intersect(ISet s2)
        {
            DiscreetValueSetWithInfiniteUniverse<T> o = s2 as DiscreetValueSetWithInfiniteUniverse<T>;
            if (o != null)
            {
                DiscreetValueSetWithInfiniteUniverse<T> ret = new DiscreetValueSetWithInfiniteUniverseNorm<T>();

                foreach (T t in m_values)
                    if (o.Contains(t))
                        ret.AddValue(t);

                return ret;
            }

            return s2.Intersect(this);
        }

        public override ISet Minus(ISet s2)
        {
            DiscreetValueSetWithInfiniteUniverseNorm<T> o = s2 as DiscreetValueSetWithInfiniteUniverseNorm<T>;
            if (o != null)
            {
                DiscreetValueSetWithInfiniteUniverseNorm<T> ret = Clone() as DiscreetValueSetWithInfiniteUniverseNorm<T>;
                foreach (T v in o.m_values)
                    if (ret.Contains(v))
                        ret.m_values.Remove(v);
                return ret;
            }

            return Intersect(s2.Complement());

            
        }

        public override ISet Complement()
        {
            DiscreetValueSetWithInfiniteUniverseComp<T> ret = new DiscreetValueSetWithInfiniteUniverseComp<T>();
            foreach (T t in m_values)
                ret.AddValue(t);
            return ret;
        }

        public override string ToString()
        {
            string ret = "DVS(";
            foreach (T t in m_values)
                ret += t.ToString() + ",";
            if (ret.EndsWith(","))
                ret = ret.Substring(0, ret.Length - 1);
            ret += ")";
            return ret;
        }

        public override Asn1Value GetOneValue()
        {
            if (m_values.Count > 0)
                return m_values[0];
            return null;
        }
    }


    public class DiscreetValueSetWithInfiniteUniverseComp<T> : DiscreetValueSetWithInfiniteUniverse<T> where T : Asn1Value, IEquatable<T>
    {
        public override void AddValue(T v)
        {
            if (!m_values.Contains(v))
                m_values.Add(v);
        }
        public override bool Contains(T v)
        {
            return !m_values.Contains(v);
        }
        
        public override ISet Union(ISet s)
        {
            if (s is DiscreetValueSetWithInfiniteUniverseComp<T>)
                return Complement().Intersect(s.Complement()).Complement();
            if (s is DiscreetValueSetWithInfiniteUniverseNorm<T>)
                return s.Union(this);

            return s.Union(this);            
        }

        public override ISet Intersect(ISet s2)
        {
            if (s2 is DiscreetValueSetWithInfiniteUniverseComp<T>)
                return Complement().Union(s2.Complement()).Complement();
            if (s2 is DiscreetValueSetWithInfiniteUniverseNorm<T>)
                return s2.Intersect(this);

            return s2.Intersect(this);
        }

        public override ISet Minus(ISet s2)
        {
            return Intersect(s2.Complement());
        }

        public override ISet Complement()
        {
            DiscreetValueSetWithInfiniteUniverseNorm<T> ret = new DiscreetValueSetWithInfiniteUniverseNorm<T>();
            foreach (T t in m_values)
                ret.AddValue(t);
            return ret;
        }
        public override bool isNull()
        {
            return false;
        }

        public override DiscreetValueSetWithInfiniteUniverse<T> Clone()
        {
            DiscreetValueSetWithInfiniteUniverseComp<T> ret = new DiscreetValueSetWithInfiniteUniverseComp<T>();
            ret.m_values.AddRange(m_values);
            return ret;
        }
        public override string ToString()
        {
            string ret = "DVS_CMP(";
            foreach (T t in m_values)
                ret += "!" + t.ToString() + ",";
            if (ret.EndsWith(","))
                ret = ret.Substring(0, ret.Length - 1);
            ret += ")";
            return ret;
        }

        public override  IEnumerable<T> Values { get { throw new Exception("Set has infinite values"); } }

        public override  bool HasInfiniteValues { get { return true; } }

    }



    public interface DiscreetValueSet<T>
    {
        IEnumerable<T> Values { get;  }

        bool HasInfiniteValues { get; }

    }

    public class DiscreetValueSetWithFiniteUniverse<T> : DiscreetValueSet<T>, ISet where T : Asn1Value, IEquatable<T>
    {
        protected List<T> m_values = new List<T>();

        public virtual IEnumerable<T> Values { get { return m_values; } }

        public virtual bool HasInfiniteValues { get { return false; } }


        IEnumerable<T> m_universe;

        public DiscreetValueSetWithFiniteUniverse(IEnumerable<T> Universe)
        {
            m_universe = Universe;
        }


        public void AddValue(T v)
        {
            if (!m_values.Contains(v))
                m_values.Add(v);
        }
        public bool Contains(T v)
        {
            return m_values.Contains(v);
        }

        public DiscreetValueSetWithFiniteUniverse<T> Clone()
        {
            DiscreetValueSetWithFiniteUniverse<T> ret = new DiscreetValueSetWithFiniteUniverse<T>(m_universe);
            ret.m_values.AddRange(m_values);
            return ret;
        }


        #region ISet Members

        public ISet Union(ISet s)
        {
            DiscreetValueSetWithFiniteUniverse<T> o = s as DiscreetValueSetWithFiniteUniverse<T>;
            if (o != null)
            {
                DiscreetValueSetWithFiniteUniverse<T> ret = Clone();
                foreach (T v in o.m_values)
                    ret.AddValue(v);

                return ret;
            }

            return s.Union(this);
        }

        public ISet Intersect(ISet s2)
        {
            DiscreetValueSetWithFiniteUniverse<T> o = s2 as DiscreetValueSetWithFiniteUniverse<T>;
            if (o != null)
            {
                DiscreetValueSetWithFiniteUniverse<T> ret = new DiscreetValueSetWithFiniteUniverse<T>(m_universe);
                foreach (T v in m_values)
                    if (o.Contains(v))
                        ret.AddValue(v);

                return ret;
            }
            return s2.Intersect(this);
        }

        public ISet Minus(ISet s2)
        {
            DiscreetValueSetWithFiniteUniverse<T> o = s2 as DiscreetValueSetWithFiniteUniverse<T>;
            if (o != null)
            {
                DiscreetValueSetWithFiniteUniverse<T> ret = Clone();
                foreach (T v in o.m_values)
                    if (ret.Contains(v))
                        ret.m_values.Remove(v);

                return ret;
            }
            return s2.Complement().Intersect(this);
        }

        public ISet Complement()
        {
            DiscreetValueSetWithFiniteUniverse<T> ret = new DiscreetValueSetWithFiniteUniverse<T>(m_universe);
            ret.m_values.AddRange(m_universe);
            foreach (T v in m_values)
                ret.m_values.Remove(v);
            return ret;
        }

        public bool isNull()
        {
            return m_values.Count == 0;
        }

        public SetDimension Dimension
        {
            get { return SetDimension.Value; }
        }
        public ISet Simplify()
        {
            return this;
        }

        #endregion
        public override string ToString()
        {
            string ret = "DVSF(";
            foreach (T t in m_values)
                ret += t.ToString() + ",";
            if (ret.EndsWith(","))
                ret = ret.Substring(0, ret.Length - 1);
            ret += ")";
            return ret;
        }
        public Asn1Value GetOneValue()
        {
            if (m_values.Count > 0)
                return m_values[0];
            return null;
        }
    }
    
    








}
