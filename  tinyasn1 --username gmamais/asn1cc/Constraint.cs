/**=============================================================================
Definition constraint related classes used in asn1scc project  
================================================================================
Copyright(c) Semantix Information Technologies S.A www.semantix.gr
All rights reserved.

This source code is only intended as a supplement to the
Semantix Technical Reference and related electronic documentation 
provided with the autoICD application.
See these sources for detailed information regarding the
autoICD application.
==============================================================================*/

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
        void PrintCIsConstraintValidAux(string args, StreamWriterLevel c);
        void PrintCIsConstraintValidAuxBody(StreamWriterLevel c);
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

		public void PrintCIsConstraintValidAux(string args, StreamWriterLevel c) {}
        public void PrintCIsConstraintValidAuxBody(StreamWriterLevel c) { }
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

		public void PrintCIsConstraintValidAux(string args, StreamWriterLevel c) {}
        public void PrintCIsConstraintValidAuxBody(StreamWriterLevel c) { }
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

		public void PrintCIsConstraintValidAux(string args, StreamWriterLevel c) {}
        public void PrintCIsConstraintValidAuxBody(StreamWriterLevel c) { }
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

		public void PrintCIsConstraintValidAux(string args, StreamWriterLevel c) {}
        public void PrintCIsConstraintValidAuxBody(StreamWriterLevel c) { }
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

		public void PrintCIsConstraintValidAux(string args, StreamWriterLevel c) {}
        public void PrintCIsConstraintValidAuxBody(StreamWriterLevel c) { }
    }

	public class SCCSingleValueConstraint : SingleValueConstraint, ISCConstraint
	{
        public string PrintCIsConstraintValid(string varName, int lev)
        {
            INonPrimitiveCType wscc = m_type as INonPrimitiveCType;
            if (wscc!=null)
                return wscc.CompareTo(varName, ConstraintValue);

            return "(" + varName + " == " + m_val.ToStringC() + ")";
        }

		public string PrintCIsRootConstraintValid(string varName, int lev)
		{
			 throw new Exception("The method or operation is not implemented.");
		}

		public void PrintCIsConstraintValidAux(string args, StreamWriterLevel c) {}
        public void PrintCIsConstraintValidAuxBody(StreamWriterLevel c) { }
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

		public void PrintCIsConstraintValidAux(string args, StreamWriterLevel c) {}
        public void PrintCIsConstraintValidAuxBody(StreamWriterLevel c) { }
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

		public void PrintCIsConstraintValidAux(string args, StreamWriterLevel c) {}
        public void PrintCIsConstraintValidAuxBody(StreamWriterLevel c) { }
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

		public void PrintCIsConstraintValidAux(string args, StreamWriterLevel c) {}
        public void PrintCIsConstraintValidAuxBody(StreamWriterLevel c) { }
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

		public void PrintCIsConstraintValidAux(string args, StreamWriterLevel c) {}
        public void PrintCIsConstraintValidAuxBody(StreamWriterLevel c) { }
    }

	public class SCCPermittedAlphabetConstraint : PermittedAlphabetConstraint, ISCConstraint
	{

		public string PrintCIsRootConstraintValid(string varName, int lev)
		{
			 throw new Exception("The method or operation is not implemented.");
		}

        static int nCount = 0;
        int AuxFunctionID;
        public void PrintCIsConstraintValidAux(string args, StreamWriterLevel c)
        {
            nCount++;
            AuxFunctionID = nCount;

            c.WriteLine("flag CheckString{0}(const char* str);", AuxFunctionID);
        }

        public void PrintCIsConstraintValidAuxBody(StreamWriterLevel c)
        {
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
                c.Write(((ISCConstraint)allowed_char_set.m_constraints[i]).PrintCIsConstraintValid("str[i]", 0));
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

		public void PrintCIsConstraintValidAux(string args, StreamWriterLevel c) {}
        public void PrintCIsConstraintValidAuxBody(StreamWriterLevel c) { }
	}

	public class SCCWithComponentConstraint : WithComponentConstraint, ISCConstraint
	{



        static int nCount = 0;
        int AuxFunctionID;
        string variableName = string.Empty;
        string m_args = string.Empty;
        public void PrintCIsConstraintValidAux(string args, StreamWriterLevel c)
        {
            nCount++;
            AuxFunctionID = nCount;
            m_args = args;
            c.WriteLine("flag WithComponentAux{0}({1});", AuxFunctionID, args);
        }
        public void PrintCIsConstraintValidAuxBody(StreamWriterLevel c) 
        {
            c.WriteLine("flag WithComponentAux{0}({1})", AuxFunctionID, m_args);
            c.WriteLine("{");
            c.P(1); c.WriteLine("size_t i;");
            c.P(1); c.WriteLine("size_t n = {0}nCount;", variableName);
            c.P(1);
            c.WriteLine("for(i=0;i<n;i++)");
            c.P(1); c.WriteLine("{");

            c.P(2);


            string varName = variableName + "arr[i]";
            
            c.Write("if (!");

            c.Write(((ISCConstraint)m_innerTypeConstraint).PrintCIsConstraintValid(varName, 0));

            c.WriteLine(")");
            c.P(3);
            c.WriteLine("return FALSE;");
            c.P(1); c.WriteLine("}");

            c.P(1); c.WriteLine("return TRUE;");
            c.WriteLine("}");
        }

        public string PrintCIsConstraintValid(string varName, int lev)
        {

            string varName2 = varName.Replace("*", "");
            if (!varName.Contains("->"))
                varName2 += "->";
            else
                varName2 += ".";

            variableName = varName2;

            return "WithComponentAux" + AuxFunctionID.ToString() + "(" + varName2.Substring(0,varName2.IndexOf("->")) + ")";
        }



		public string PrintCIsRootConstraintValid(string varName, int lev)
		{
			 throw new Exception("The method or operation is not implemented.");
		}

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

		public void PrintCIsConstraintValidAux(string args, StreamWriterLevel c) {}
        public void PrintCIsConstraintValidAuxBody(StreamWriterLevel c) { }
    }

	public class SCCWithComponentsConstraintComponent : WithComponentsConstraint.Component
	{
		public SCCWithComponentsConstraintComponent(string name, WithComponentsConstraint.Component.PresenseConstraint presCon, IConstraint valCon) :  base(name, presCon, valCon){}
	}

	public class SCCWithComponentsSeqConstraint : WithComponentsSeqConstraint, ISCConstraint
	{
		public string PrintCIsConstraintValid(string varName, int lev)
		{
            string ret = "";

            string varName2 = varName.Replace("*","");
            if (!varName.Contains("->"))
                varName2 += "->";
            else
                varName2 += ".";

            // Check presence constraint
            foreach (Component c in m_components.Values)
            {

                if (c.m_presenceConstraint == Component.PresenseConstraint.PRESENT)
                {
                    if (ret != "")
                        ret += " && ";
                    ret += varName2 +"exist." + C.ID(c.m_name);
                }
                if (c.m_presenceConstraint == Component.PresenseConstraint.ABSENT)
                {
                    if (ret != "")
                        ret += " && ";
                    ret += "!" + varName2 + "exist." + C.ID(c.m_name);
                }
            }


            
            //check value constraint
            foreach (string id in this.Type.m_children.Keys)
            {
                Asn1Type v = this.Type.m_children[id].m_type;
                if (m_components.ContainsKey(id))
                {
                    Component c = m_components[id];
                    if (c.m_valueConstraint != null) 
                    {
                        if (ret != "")
                            ret += " && ";
                        ret += ((ISCConstraint)c.m_valueConstraint).PrintCIsConstraintValid(varName2 + C.ID(id), lev);
                    }
                }

            }

            return ret;
		}

		public string PrintCIsRootConstraintValid(string varName, int lev)
		{
			 throw new Exception("The method or operation is not implemented.");
		}

		public void PrintCIsConstraintValidAux(string args, StreamWriterLevel c) {}
        public void PrintCIsConstraintValidAuxBody(StreamWriterLevel c) { }
    }

	public class SCCWithComponentsChConstraint : WithComponentsChConstraint, ISCConstraint
	{
		public string PrintCIsConstraintValid(string varName, int lev)
		{
            string ret = "";

            string varName2 = varName.Replace("*", "");
            if (!varName.Contains("->"))
                varName2 += "->";
            else
                varName2 += ".";

            // Check presence constraint
            foreach (Component c in m_components.Values)
            {

                if (c.m_presenceConstraint == Component.PresenseConstraint.PRESENT)
                {
                    if (ret != "")
                        ret += " && ";
                    ret += "("+ varName2 + "kind == " +  this.Type.m_children[c.m_name].CID +")";
                }
                if (c.m_presenceConstraint == Component.PresenseConstraint.ABSENT)
                {
                    if (ret != "")
                        ret += " && ";
                    ret += "("+varName2 + "kind != " + this.Type.m_children[c.m_name].CID+")";
                }
            }

            //check value constraint
            foreach (string id in this.Type.m_children.Keys)
            {
                Asn1Type v = this.Type.m_children[id].m_type;
                if (m_components.ContainsKey(id))
                {
                    Component c = m_components[id];
                    if (c.m_valueConstraint != null)
                    {
                        if (ret != "")
                            ret += " && ";
                        ret += "(" + varName2 + "kind == " + this.Type.m_children[c.m_name].CID + "?" +
                            ((ISCConstraint)c.m_valueConstraint).PrintCIsConstraintValid(varName2 + "u." + C.ID(id), lev) + ":TRUE)";
                    }
                }

            }


            return ret;
        }

		public string PrintCIsRootConstraintValid(string varName, int lev)
		{
			 throw new Exception("The method or operation is not implemented.");
		}

		public void PrintCIsConstraintValidAux(string args, StreamWriterLevel c) {}
        public void PrintCIsConstraintValidAuxBody(StreamWriterLevel c) { }
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

		public void PrintCIsConstraintValidAux(string args, StreamWriterLevel c) {}
        public void PrintCIsConstraintValidAuxBody(StreamWriterLevel c) { }
    }




}