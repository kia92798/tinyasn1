using System;
using System.Collections.Generic;
using System.Text;

namespace tinyAsn1
{

    public abstract class CharSet
    {
        public abstract bool IsValueAllowed(string val);
    }


    public class SingleValueCharSet : CharSet
    {
        string m_value;

        public SingleValueCharSet(string val)
        {
            m_value = val;
        }

        public override bool IsValueAllowed(string val)
        {
            foreach(Char ch in val)
                if (!m_value.Contains(ch.ToString()))
                    return false;
            return true;
        }
    }

    public class RangeCharSet : CharSet
    {
        /// <summary>
        /// if m_min is null then m_min is MIN
        /// </summary>
        string m_min;
        /// <summary>
        /// if m_max is null then m_max is MAX
        /// </summary>
        string m_max;
        bool m_minValIsInluded = true;
        bool m_maxValIsInluded = true;

        public RangeCharSet(string minVal, string maxVal,
            bool minValIsInluded, bool maxValIsInluded)
        {
            m_min = minVal;
            m_max = maxVal;
            m_minValIsInluded = minValIsInluded;
            m_maxValIsInluded = maxValIsInluded;
        }
        public override bool IsValueAllowed(string val)
        {
            if (m_min != null && m_min.Length != 1)
                return true;
            if (m_max != null && m_max.Length != 1)
                return true;
            if (m_min == null && m_max == null)  //(MIN..MAX)
                return true;
            if (m_min == null && (val.CompareTo(m_max) < 0)) // (MIN..value)
                return true;
            if ((m_min.CompareTo(val) < 0) && m_max == null)
                return true;
            if ((m_min.CompareTo(val) < 0) && (val.CompareTo(m_max) < 0))
                return true;
            if (m_minValIsInluded && m_min != null && m_min.Equals(val))
                return true;
            if (m_maxValIsInluded && m_max != null && m_max.Equals(val))
                return true;
            return false;
        }
    }


}
