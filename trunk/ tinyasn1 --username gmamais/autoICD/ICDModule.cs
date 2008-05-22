using System;
using System.Collections.Generic;
using System.Text;
using Antlr.Runtime.Tree;
using Antlr.Runtime;
using System.IO;
using tinyAsn1;

namespace autoICD
{
    public class ICDModule : Module
    {
        private List<TypeAssigment> GetTopLevelTypes()
        {
            List<TypeAssigment> ret = new List<TypeAssigment>();
            foreach (TypeAssigment tas in m_typeAssigments.Values)
            {
                bool isTopLevelPDU = true;
                foreach (TypeAssigment tas2 in m_typeAssigments.Values)
                {
                    if (tas2 == tas)
                        continue;
                    if (tas2.m_type.ContainsTypeAssigment(tas.m_name))
                    {
                        isTopLevelPDU = false;
                        break;
                    }
                }
                if (isTopLevelPDU)
                    ret.Add(tas);

            }
            return ret;
        }

        public void PrintHtml(StreamWriterLevel wr, int p)
        {
            wr.WriteLine("<div style=\"width: 100%\">");
            wr.WriteLine(string.Format("<h2 >Module : {0}</h2>", m_moduleID));
            wr.WriteLine("<font face=\"Verdana\" color=\"DimGray\">");
            wr.WriteLine(wr.BR(m_comments));
            wr.WriteLine("</font>");

            List<TypeAssigment> topLevelPDUs = GetTopLevelTypes();

            if (!Asn1CompilerInvokation.displayTypesAsAppearInAsn1Grammar)
            {
                foreach (ICDTypeAssigment tas in topLevelPDUs)
                    tas.PrintHtml(wr, p + 1);
            }

            foreach (ICDTypeAssigment tas in m_typeAssigments.Values)
                if (!topLevelPDUs.Contains(tas))
                    tas.PrintHtml(wr, p + 1);

            wr.WriteLine("</div>");
        }

        public void Tabularize()
        {
            int cnt = m_typeAssigments.Values.Count;
            for (int i = 0; i < cnt; i++)
            {
                TypeAssigment tas = m_typeAssigments.Values[i];
                ((ICDType)tas.m_type).Tabularize(tas.m_name);
            }
        }


        /// <summary>
        /// Needed by Tabularize()
        /// </summary>
        /// <param name="name"></param>
        /// <param name="asn1Type"></param>
        /// <param name="commenst"></param>
        /// <returns></returns>
        public TypeAssigment CreateNewTypeAssigment(string name, Asn1Type asn1Type, List<string> commenst)
        {
            string newName = name[0].ToString().ToUpper() + name.Substring(1, name.Length - 1);
            int i = 0;
            while (m_typeAssigments.ContainsKey(newName))
            {
                i++;
                newName += i.ToString();
            }
            TypeAssigment ret = Asn1CompilerInvokation.Instance.Factory.CreateTypeAssigment();
            ret.m_name = newName;
            ret.m_type = asn1Type;
            ret.m_comments = commenst;
            m_typeAssigments.Add(newName, ret);
            ret.m_createdThroughTabulization = true;
            return ret;
        }
    }


    public class ICDTypeAssigment : TypeAssigment 
    {

        public void PrintHtml(StreamWriterLevel wr, int p)
        {
            ((ICDType)m_type).PrintHtml(m_type.PEREffectiveConstraint, wr, p, m_comments, this, null);
            wr.WriteLine("&nbsp;<br/>");
        }

    }
}
