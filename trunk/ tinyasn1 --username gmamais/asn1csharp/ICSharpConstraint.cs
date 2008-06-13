using System;
using System.Collections.Generic;
using System.Text;
using tinyAsn1;

namespace asn1csharp
{
    public interface ICSharpConstraint
    {
        string PrintConstraintCode(string varName, string enumPrefix);
    }



    public class CSharpRootConstraint : RootConstraint, ICSharpConstraint
    {
        public string PrintConstraintCode(string varName, string enumPrefix)
        {
            if (m_extConstr == null)
                return ((ICSharpConstraint)m_constr).PrintConstraintCode(varName, enumPrefix);
            return "(" + ((ICSharpConstraint)m_constr).PrintConstraintCode(varName, enumPrefix) + "||" + ((ICSharpConstraint)m_extConstr).PrintConstraintCode(varName, enumPrefix) + ")";
        }

    }

    public class CSharpUnionConstraint : UnionConstraint, ICSharpConstraint
    {
        public string PrintConstraintCode(string varName, string enumPrefix)
        {
            string ret;
            if (m_items.Count == 1)
                return ((ICSharpConstraint)m_items[0]).PrintConstraintCode(varName, enumPrefix);
            ret = "(";
            for (int i = 0; i < m_items.Count; i++)
            {
                ret += ((ICSharpConstraint)m_items[i]).PrintConstraintCode(varName, enumPrefix);
                if (i != m_items.Count - 1)
                    ret += " || ";
            }
            ret += ")";
            return ret;
        }

    }

    public class CSharpAndConstraint : AndConstraint, ICSharpConstraint
    {
        public string PrintConstraintCode(string varName, string enumPrefix)
        {
            string ret;
            if (m_items.Count == 1)
                return ((ICSharpConstraint)m_items[0]).PrintConstraintCode(varName, enumPrefix);
            ret = "(";
            for (int i = 0; i < m_items.Count; i++)
            {
                ret += ((ICSharpConstraint)m_items[i]).PrintConstraintCode(varName, enumPrefix);
                if (i != m_items.Count - 1)
                    ret += " && ";
            }
            ret += ")";
            return ret;
        }

    }

    public class CSharpExceptConstraint : ExceptConstraint, ICSharpConstraint
    {
        public string PrintConstraintCode(string varName, string enumPrefix)
        {
            return "(" + ((ICSharpConstraint)m_c1).PrintConstraintCode(varName, enumPrefix) + " && !" + ((ICSharpConstraint)m_c2).PrintConstraintCode(varName, enumPrefix) + ")";
        }
    }

    public class CSharpAllExceptConstraint : AllExceptConstraint, ICSharpConstraint
    {
        public string PrintConstraintCode(string varName, string enumPrefix)
        {
            return "!" + ((ICSharpConstraint)m_c).PrintConstraintCode(varName, enumPrefix);
        }

    }

    public class CSharpSingleValueConstraint : SingleValueConstraint, ICSharpConstraint
    {
        public string PrintConstraintCode(string varName, string enumPrefix)
        {

            string val = m_val.ToString();
            if (val.Contains("("))
                val = val.Substring(0, val.IndexOf('('));


            return "(" + varName + " == " + enumPrefix+val + ")";
        }

    }

    public class CSharpSinglePAValueConstraint : SinglePAValueConstraint, ICSharpConstraint
    {
        public string PrintConstraintCode(string varName, string enumPrefix)
        {
            ICharacterString set = m_val as ICharacterString;
            if (set == null)
                throw new Exception("Internal Error");

            return "string.Format(\""+set.Value+"\")" + ".Contains(" + varName +".ToString())";
        }

    }

    public class CSharpRangeConstraint : RangeConstraint, ICSharpConstraint
    {
        public string PrintConstraintCode(string varName, string enumPrefix)
        {
            string ret = "";
            if (m_max != null && m_min != null)
                ret = "(";
            if (m_min != null)
            {
                ret += "(" + varName + ">";
                if (m_minValIsInluded)
                    ret += "=";
                ret += m_min.ToString() + ")";

            }
            if (m_max != null && m_min != null)
                ret += " && ";

            if (m_max != null)
            {
                ret += "(" + varName + "<";
                if (m_maxValIsInluded)
                    ret += "=";
                ret += m_max.ToString() + ")";
            }


            if (m_max != null && m_min != null)
                ret += ")";
            return ret;
        }

    }

    public class CSharpRangePAConstraint : RangePAConstraint, ICSharpConstraint
    {
        public string PrintConstraintCode(string varName, string enumPrefix)
        {
            if (m_min != null && Lo.Value.Length != 1)
                return ""; // ignore constraint
            if (m_max != null && Hi.Value.Length != 1)
                return ""; // ignore constraint
            if (m_min == null && m_max == null)  //(MIN..MAX)
                return "";
            string ret = "";
            if (m_max != null && m_min != null)
                ret = "(";

            if (m_min != null)
            {
                ret += "(" + varName + ">";
                if (m_minValIsInluded)
                    ret += "=";
                ret += "'" + m_min.ToString().Replace("\"", "") + "')";

            }
            if (m_max != null && m_min != null)
                ret += " && ";

            if (m_max != null)
            {
                ret += "(" + varName + "<";
                if (m_maxValIsInluded)
                    ret += "=";
                ret += "'" + m_max.ToString().Replace("\"", "") + "')";
            }


            if (m_max != null && m_min != null)
                ret += ")";
            return ret;


        }

    }

    public class CSharpSizeConstraint : SizeConstraint, ICSharpConstraint
    {
        public string PrintConstraintCode(string varName, string enumPrefix)
        {
            string varName2 = "";
            if (m_type.GetFinalType() is IA5StringType)
                varName2 = varName + ".Length";
            else if (m_type.GetFinalType() is OctetStringType || m_type.GetFinalType() is BitStringType)
                varName2 = varName + ".Count";
            else if (m_type.GetFinalType() is ArrayType)
                varName2 = varName + ".m_children.Count";


            string ret = "";
            for (int i = 0; i < sizeCon.m_constraints.Count; i++)
            {
                ret += ((ICSharpConstraint)sizeCon.m_constraints[i]).PrintConstraintCode(varName2, enumPrefix);
                if (i != sizeCon.m_constraints.Count - 1)
                    ret += " && ";
            }
            return ret;
        }

    }

    public class CSharpPermittedAlphabetConstraint : PermittedAlphabetConstraint, ICSharpConstraint
    {
        public string PrintConstraintCode(string varName, string enumPrefix)
        {
            System.IO.StringWriter o = new System.IO.StringWriter();

            o.Write("new List<char>(val).TrueForAll(delegate(char c) { return ");
            for (int i = 0; i < allowed_char_set.m_constraints.Count; i++)
            {
                o.Write(((ICSharpConstraint)allowed_char_set.m_constraints[i]).PrintConstraintCode("c", enumPrefix));
                if (i != allowed_char_set.m_constraints.Count - 1)
                    o.Write(" && ");
            }
            o.Write("; })");

            return o.ToString();
        }
    }







}
