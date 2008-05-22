using System;
using System.Collections.Generic;
using System.Text;
using tinyAsn1;
using Antlr.Runtime.Tree;

namespace asn1scc
{
    public interface ISCConstraint
    {
        string PrintCIsConstraintValid(string varName, int lev);
        string PrintCIsRootConstraintValid(string varName, int lev);
        void PrintCIsConstraintValidAux(StreamWriterLevel c);
    }

	public class SCCExceptionSpec : ExceptionSpec	
    {
	}

	public class SCCRootConstraint : RootConstraint, ISCConstraint
	{
        public string PrintCIsConstraintValid(string varName, int lev)
        {
            if (m_extConstr == null)
                return ((ISCConstraint)m_constr).PrintCIsConstraintValid(varName, lev);
            return "(" + ((ISCConstraint)m_constr).PrintCIsConstraintValid(varName, lev) + "||" + ((ISCConstraint)m_extConstr).PrintCIsConstraintValid(varName, lev) + ")";
        }

        public string PrintCIsRootConstraintValid(string varName, int lev)
        {
            return ((ISCConstraint)m_constr).PrintCIsConstraintValid(varName, lev);
        }

		public void PrintCIsConstraintValidAux(StreamWriterLevel c) {}
    }

	public class SCCUnionConstraint : UnionConstraint, ISCConstraint
	{
        public string PrintCIsConstraintValid(string varName, int lev)
        {
            string ret;
            if (m_items.Count == 1)
                return ((ISCConstraint)m_items[0]).PrintCIsConstraintValid(varName, lev);
            ret = "(";
            for (int i = 0; i < m_items.Count; i++)
            {
                ret += ((ISCConstraint)m_items[i]).PrintCIsConstraintValid(varName, lev);
                if (i != m_items.Count - 1)
                    ret += " || ";
            }
            ret += ")";
            return ret;
        }

		public string PrintCIsRootConstraintValid(string varName, int lev)
		{
			 throw new Exception("The method or operation is not implemented.");
		}

		public void PrintCIsConstraintValidAux(StreamWriterLevel c) {}
	}

	public class SCCAndConstraint : AndConstraint, ISCConstraint
	{
        public string PrintCIsConstraintValid(string varName, int lev)
        {
            string ret;
            if (m_items.Count == 1)
                return ((ISCConstraint)m_items[0]).PrintCIsConstraintValid(varName, lev);
            ret = "(";
            for (int i = 0; i < m_items.Count; i++)
            {
                ret += ((ISCConstraint)m_items[i]).PrintCIsConstraintValid(varName, lev);
                if (i != m_items.Count - 1)
                    ret += " && ";
            }
            ret += ")";
            return ret;
        }

		public string PrintCIsRootConstraintValid(string varName, int lev)
		{
			 throw new Exception("The method or operation is not implemented.");
		}

		public void PrintCIsConstraintValidAux(StreamWriterLevel c) {}
	}

	public class SCCExceptConstraint : ExceptConstraint, ISCConstraint
	{
        public string PrintCIsConstraintValid(string varName, int lev)
        {
            return "(" + ((ISCConstraint)m_c1).PrintCIsConstraintValid(varName, lev) + " && !" + ((ISCConstraint)m_c2).PrintCIsConstraintValid(varName, lev) + ")";
        }

		public string PrintCIsRootConstraintValid(string varName, int lev)
		{
			 throw new Exception("The method or operation is not implemented.");
		}

		public void PrintCIsConstraintValidAux(StreamWriterLevel c) {}
	}

	public class SCCAllExceptConstraint : AllExceptConstraint, ISCConstraint
	{
        public string PrintCIsConstraintValid(string varName, int lev)
        {
            return "!" + ((ISCConstraint)m_c).PrintCIsConstraintValid(varName, lev);
        }

		public string PrintCIsRootConstraintValid(string varName, int lev)
		{
			 throw new Exception("The method or operation is not implemented.");
		}

		public void PrintCIsConstraintValidAux(StreamWriterLevel c) {}
	}

	public class SCCSingleValueConstraint : SingleValueConstraint, ISCConstraint
	{
        public string PrintCIsConstraintValid(string varName, int lev)
        {
            return "(" + varName + " == " + m_val.ToStringC() + ")";
        }

		public string PrintCIsRootConstraintValid(string varName, int lev)
		{
			 throw new Exception("The method or operation is not implemented.");
		}

		public void PrintCIsConstraintValidAux(StreamWriterLevel c) {}
	}

	public class SCCSinglePAValueConstraint : SinglePAValueConstraint, ISCConstraint
	{
        public string PrintCIsConstraintValid(string varName, int lev)
        {
            ICharacterString set = m_val as ICharacterString;
            if (set == null)
                throw new Exception("Internal Error");

            return "strchr(\"" + set.Value + "\", " + varName + ")";
        }

		public string PrintCIsRootConstraintValid(string varName, int lev)
		{
			 throw new Exception("The method or operation is not implemented.");
		}

		public void PrintCIsConstraintValidAux(StreamWriterLevel c) {}
	}

	public class SCCRangeConstraint : RangeConstraint, ISCConstraint
	{
        public string PrintCIsConstraintValid(string varName, int lev)
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

		public string PrintCIsRootConstraintValid(string varName, int lev)
		{
			 throw new Exception("The method or operation is not implemented.");
		}

		public void PrintCIsConstraintValidAux(StreamWriterLevel c) {}
	}

	public class SCCRangePAConstraint : RangePAConstraint, ISCConstraint
	{
        public string PrintCIsConstraintValid(string varName, int lev)
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

		public string PrintCIsRootConstraintValid(string varName, int lev)
		{
			 throw new Exception("The method or operation is not implemented.");
		}

		public void PrintCIsConstraintValidAux(StreamWriterLevel c) {}
	}

	public class SCCSizeConstraint : SizeConstraint, ISCConstraint
	{
        public string PrintCIsConstraintValid(string varName, int lev)
        {
            string varName2 = "";
            if (m_type.GetFinalType() is IA5StringType)
                varName2 = "strlen(" + varName.Replace("*", "") + ")";
            else
            {
                if (varName.Contains("->"))
                    varName2 = varName + ".nCount";
                else
                    varName2 = varName.Replace("*", "") + "->nCount";

            }

            string ret = "";
            for (int i = 0; i < sizeCon.m_constraints.Count; i++)
            {
                ret += ((ISCConstraint)sizeCon.m_constraints[i]).PrintCIsConstraintValid(varName2, lev);
                if (i != sizeCon.m_constraints.Count - 1)
                    ret += " && ";
            }
            return ret;
        }

		public string PrintCIsRootConstraintValid(string varName, int lev)
		{
			 throw new Exception("The method or operation is not implemented.");
		}

		public void PrintCIsConstraintValidAux(StreamWriterLevel c) {}
	}

	public class SCCPermittedAlphabetConstraint : PermittedAlphabetConstraint, ISCConstraint
	{

		public string PrintCIsRootConstraintValid(string varName, int lev)
		{
			 throw new Exception("The method or operation is not implemented.");
		}

        static int nCount = 0;
        int AuxFunctionID;
        public void PrintCIsConstraintValidAux(StreamWriterLevel c)
        {
            nCount++;
            AuxFunctionID = nCount;

            c.WriteLine("flag CheckString{0}(const char* str)", AuxFunctionID);
            c.WriteLine("{");
            c.P(1); c.WriteLine("size_t i;");
            c.P(1); c.WriteLine("size_t n = strlen(str);");
            c.P(1);
            c.WriteLine("for(i=0;i<n;i++)");
            c.P(1); c.WriteLine("{");

            c.P(2);
            c.Write("if (!");
            for (int i = 0; i < allowed_char_set.m_constraints.Count; i++)
            {
                c.Write( ((ISCConstraint)allowed_char_set.m_constraints[i]).PrintCIsConstraintValid("str[i]", 0));
                if (i != allowed_char_set.m_constraints.Count - 1)
                    c.Write(" && ");
            }
            c.WriteLine(")");
            c.P(3);
            c.WriteLine("return FALSE;");
            c.P(1); c.WriteLine("}");

            c.P(1); c.WriteLine("return TRUE;");
            c.WriteLine("}");
        }

        public string PrintCIsConstraintValid(string varName, int lev)
        {
            return "CheckString" + AuxFunctionID.ToString() + "(" + varName.Replace("*", "") + ")";
        }
    }

	public class SCCTypeInclusionConstraint : TypeInclusionConstraint, ISCConstraint
	{
		public string PrintCIsConstraintValid(string varName, int lev)
		{
			 throw new Exception("The method or operation is not implemented.");
		}

		public string PrintCIsRootConstraintValid(string varName, int lev)
		{
			 throw new Exception("The method or operation is not implemented.");
		}

		public void PrintCIsConstraintValidAux(StreamWriterLevel c) {}
	}

	public class SCCWithComponentConstraint : WithComponentConstraint, ISCConstraint
	{
		public string PrintCIsConstraintValid(string varName, int lev)
		{
			 throw new Exception("The method or operation is not implemented.");
		}

		public string PrintCIsRootConstraintValid(string varName, int lev)
		{
			 throw new Exception("The method or operation is not implemented.");
		}

		public void PrintCIsConstraintValidAux(StreamWriterLevel c) {}
	}

	public class SCCWithComponentsConstraint : WithComponentsConstraint, ISCConstraint
	{
		public string PrintCIsConstraintValid(string varName, int lev)
		{
			 throw new Exception("The method or operation is not implemented.");
		}

		public string PrintCIsRootConstraintValid(string varName, int lev)
		{
			 throw new Exception("The method or operation is not implemented.");
		}

		public void PrintCIsConstraintValidAux(StreamWriterLevel c) {}
	}

	public class SCCWithComponentsConstraintComponent : WithComponentsConstraint.Component
	{
		public SCCWithComponentsConstraintComponent(string name, WithComponentsConstraint.Component.PresenseConstraint presCon, IConstraint valCon) :  base(name, presCon, valCon){}
	}

	public class SCCWithComponentsSeqConstraint : WithComponentsSeqConstraint, ISCConstraint
	{
		public string PrintCIsConstraintValid(string varName, int lev)
		{
			 throw new Exception("The method or operation is not implemented.");
		}

		public string PrintCIsRootConstraintValid(string varName, int lev)
		{
			 throw new Exception("The method or operation is not implemented.");
		}

		public void PrintCIsConstraintValidAux(StreamWriterLevel c) {}
	}

	public class SCCWithComponentsChConstraint : WithComponentsChConstraint, ISCConstraint
	{
		public string PrintCIsConstraintValid(string varName, int lev)
		{
			 throw new Exception("The method or operation is not implemented.");
		}

		public string PrintCIsRootConstraintValid(string varName, int lev)
		{
			 throw new Exception("The method or operation is not implemented.");
		}

		public void PrintCIsConstraintValidAux(StreamWriterLevel c) {}
	}

	public class SCCWithComponentsRealConstraint : WithComponentsRealConstraint, ISCConstraint
	{
		public string PrintCIsConstraintValid(string varName, int lev)
		{
			 throw new Exception("The method or operation is not implemented.");
		}

		public string PrintCIsRootConstraintValid(string varName, int lev)
		{
			 throw new Exception("The method or operation is not implemented.");
		}

		public void PrintCIsConstraintValidAux(StreamWriterLevel c) {}
	}




}