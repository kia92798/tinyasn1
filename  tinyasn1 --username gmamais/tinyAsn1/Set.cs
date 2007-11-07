using System;
using System.Collections.Generic;
using System.Text;

namespace tinyAsn1
{
    public abstract class ConstraintsSet<T> where T : IComparable<T>
    {
        public abstract T PERMin { get;}
        public abstract T PERMax { get;}
        public abstract bool HasValue(T val);
        public abstract bool IsNull();
        public abstract ConstraintsSet<T> Simplify();
    }

    public class Set1ExceptOfSet2Set<T> : ConstraintsSet<T> where T : IComparable<T>
    {
        ConstraintsSet<T> m_set1;
        ConstraintsSet<T> m_set2;

        public Set1ExceptOfSet2Set(ConstraintsSet<T> set1, ConstraintsSet<T> set2)
        {
            if (set1 == null)
                throw new ArgumentNullException("set1");
            if (set2 == null)
                throw new ArgumentNullException("set2");
            m_set1 = set1;
            m_set2 = set2;
        }

        public override T PERMin
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public override T PERMax
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public override bool HasValue(T val)
        {
            if (m_set1.HasValue(val) && !m_set2.HasValue(val))
                return true;
            return false;
        }

        public override bool IsNull()
        {
            return false;
        }
        public override ConstraintsSet<T> Simplify()
        {
            m_set1 = m_set1.Simplify();
            m_set2 = m_set2.Simplify();
            return this;
        }
        public override string ToString()
        {
            string ret = m_set1.ToString()+ " EXCEPT " + m_set2.ToString();
            return ret;
        }
    }
    
    public class AllExceptOfSet<T> : ConstraintsSet<T> where T : IComparable<T>
    {
        ConstraintsSet<T> m_set;
        public AllExceptOfSet(ConstraintsSet<T> set)
        {
            if (set == null)
                throw new ArgumentNullException("set");

            m_set = set;
        }

        public override T PERMin
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public override T PERMax
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public override bool HasValue(T val)
        {
            return !m_set.HasValue(val);
        }

        public override bool IsNull()
        {
            return false;
        }
        public override ConstraintsSet<T> Simplify()
        {
            m_set = m_set.Simplify();
            return this;
        }
        public override string ToString()
        {
            string ret = "ALL EXCEPT " + m_set.ToString();
            return ret;
        }
    }

    public class IntersectionSet<T> : ConstraintsSet<T> where T : IComparable<T>
    {
        List<ConstraintsSet<T>> m_elems;

        public IntersectionSet(List<ConstraintsSet<T>> elems)
        {
            if (elems == null)
                throw new ArgumentNullException("elems");
            if (elems.Count == 0)
                throw new ArgumentException("size of elems must be greater than zero");
            m_elems = elems;
///            CalcMin();
//            CalcMax();
        }


        T m_minCalcValue;
        void CalcMin()
        {
            m_minCalcValue = m_elems[0].PERMin;

            //retVal is the greatest min (provided that it is smaller than minimum max, otherwise set is null)
            foreach (ConstraintsSet<T> e in m_elems)
            {
                if (m_minCalcValue.CompareTo(e.PERMin) > 0)
                    m_minCalcValue = e.PERMin;

            }
        }
        
        public override T PERMin
        {
            get {
                if (IsNull())
                    throw new Exception("Internal Error");

                return m_minCalcValue;            
            }
        }

        T m_maxCalcValue;
        void CalcMax()
        {
            m_maxCalcValue = m_elems[0].PERMin;

            //retVal is the smallest max (provided that it is greater than maximum min, otherwise set is null)
            foreach (ConstraintsSet<T> e in m_elems)
            {
                if (m_maxCalcValue.CompareTo(e.PERMax) < 0)
                    m_maxCalcValue = e.PERMax;

            }
        }
        public override T PERMax
        {
            get
            {
                if (IsNull())
                    throw new Exception("Internal Error");

                return m_maxCalcValue;
            }
        }

        public override bool HasValue(T val)
        {
            if (IsNull())
                return false;

            foreach (ConstraintsSet<T> e in m_elems)
            {
                if (!e.HasValue(val))
                    return false;
            }

            return true;
        }

        public override bool IsNull()
        {
            if (PERMin.CompareTo(PERMax) > 0)
                return true;
            return false;
        }
        public override ConstraintsSet<T> Simplify()
        {
            if (m_elems.Count == 1)
                return m_elems[0].Simplify();
            for (int i = 0; i < m_elems.Count; i++)
                m_elems[i] = m_elems[i].Simplify();
            return this;
        }
        public override string ToString()
        {
            int cnt = m_elems.Count;
            string ret = "(";
            for (int i = 0; i < cnt - 1; i++)
            {
                ret += m_elems[i].ToString() + " ^ ";
            }
            ret += m_elems[cnt - 1].ToString() + ")";
            return ret;
        }
    }

    public class UnionSet<T> : ConstraintsSet<T> where T : IComparable<T>
    {
        List<ConstraintsSet<T>> m_elems;

        public UnionSet(List<ConstraintsSet<T>> elems)
        {
            if (elems == null)
                throw new ArgumentNullException("elems");
            if (elems.Count == 0)
                throw new ArgumentException("size of elems must be greater than zero");
            m_elems = elems;
        }

        bool m_minHasBeenCalculated=false;
        T m_minCalcValue;
        public override T PERMin
        {
            get
            {
                if (m_minHasBeenCalculated)
                    return m_minCalcValue;
                T retVal = m_elems[0].PERMin;
                foreach (ConstraintsSet<T> e in m_elems)
                {
                    if (e.PERMin.CompareTo(retVal) < 0) //e.Min<retVal
                        retVal = e.PERMin;
                }
                m_minCalcValue = retVal;
                m_minHasBeenCalculated = true;
                return retVal;
             }
        }

        bool m_maxHasBeenCalculated = false;
        T m_maxCalcValue;
        public override T PERMax
        {
            get {
                if (m_maxHasBeenCalculated)
                    return m_maxCalcValue;
                T retVal = m_elems[0].PERMax;
                foreach (ConstraintsSet<T> e in m_elems)
                {
                    if (e.PERMax.CompareTo(retVal) > 0) //e.Max<retVal
                        retVal = e.PERMax;
                }
                m_maxCalcValue = retVal;
                m_maxHasBeenCalculated = true;
                return retVal;
            }
        }

        public override bool HasValue(T val)
        {
            foreach (ConstraintsSet<T> e in m_elems)
            {
                if (e.HasValue(val))
                    return true;
            }
            
            return false;
        }

        public override bool IsNull()
        {
            foreach (ConstraintsSet<T> e in m_elems)
            {
                if (!e.IsNull())
                    return false;
            }

            return true;
        }

        public override ConstraintsSet<T> Simplify()
        {
            if (m_elems.Count == 1)
                return m_elems[0].Simplify();
            for (int i = 0; i < m_elems.Count; i++)
                m_elems[i] = m_elems[i].Simplify();
            return this;
        }

        public override string ToString()
        {
            int cnt = m_elems.Count;
            string ret = "(";
            for (int i = 0; i < cnt - 1; i++)
            {
                ret += m_elems[i].ToString() + " | ";
            }
            ret += m_elems[cnt-1].ToString() + ")";
            return ret;
        }
    }

    public class SingleValueSet<T> : ConstraintsSet<T> where T : IComparable<T>
    {
        T m_value;

        public SingleValueSet(T val) {
            m_value = val;
        }
        public override T PERMin
        {
            get { return m_value; }
        }

        public override T PERMax
        {
            get { return m_value; }
        }

        public override bool HasValue(T val)
        {
            return m_value.Equals(val);
        }

        public override bool IsNull()
        {
            return false;
        }
        public override ConstraintsSet<T> Simplify()
        {
            return this;
        }
        public override string ToString()
        {
            return m_value.ToString();
        }
    }

    public class RangeValueSet<T> : ConstraintsSet<T> where T : IComparable<T>
    {
        
        T m_min;
        T m_max;
        bool m_minValIsInluded = true;
        bool m_maxValIsInluded = true;


        public RangeValueSet(T min, T max, bool minIsIncluded, bool maxIsIncluded)
        {
            m_min = min;
            m_max = max;
            m_minValIsInluded = minIsIncluded;
            m_maxValIsInluded = maxIsIncluded;
        }
        
        public override T PERMin
        {
            get { return m_min; }
        }

        public override T PERMax
        {
            get { return m_max; }
        }

        public override bool HasValue(T val)
        {
            if (!m_minValIsInluded && val.Equals(m_min))
                return false;
            if (val.CompareTo(m_min) < 0) //val<m_min
                return false;
            if (!m_maxValIsInluded && val.Equals(m_max))
                return false;
            if (val.CompareTo(m_max) > 0)   //val>m_max
                return false;

            return true;
        }

        public override bool IsNull()
        {
            if (m_min.CompareTo(m_max) > 0) // m_min>m_max
                return true;
            return false;
        }

        public override ConstraintsSet<T> Simplify()
        {
            return this;
        }

        public override string ToString()
        {
            string ret = m_min.ToString();
            if (m_minValIsInluded)
                ret += "<";
            ret += "..";
            if (m_maxValIsInluded)
                ret += "<";
            ret += m_max.ToString();
            return ret;
        }
    }
}
