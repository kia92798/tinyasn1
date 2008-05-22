using System;
using System.Collections.Generic;
using System.Text;
using Antlr.Runtime.Tree;
using Antlr.Runtime;
using tinyAsn1;
using System.IO;

namespace autoICD
{
    public interface IInternalContentsInHtml
    {
        string InternalContentsInHtml(List<IConstraint> additionalConstraints);
    }


    public class ICDBitStringType : BitStringType, ICDType, IInternalContentsInHtml
    {
        public void Tabularize(string tasName)
        { 
        }
        public void PrintHtml(PEREffectiveConstraint cns, StreamWriterLevel o, int lev, List<string> comment, TypeAssigment tas, List<IConstraint> additonalConstraints)
        {
            ICDSizeableType.PrintHtml(this, cns, o, lev, comment, tas, additonalConstraints);
        }
        public string InternalContentsInHtml(List<IConstraint> additionalConstraints)
        {
            string ret = string.Empty;
            int cnt = m_namedBits.Count;
            if (cnt > 0)
            {
                ret = "Bit strings's special values:<br/>";
                ret += "<ul type=\"square\">";
                for (int i = 0; i < cnt; i++)
                {
                    string namedBit = m_namedBits.Keys[i];
                    long val = m_namedBits.Values[i];
                    ret += string.Format("<li><font  color=\"#5F9EA0\" >{0}</font>({1})</li>", namedBit, val);
                }
                ret += "</ul>";
            }
            return ret;
        }

    }

    public class ICDBooleanType : BooleanType, ICDType
    {
        public void Tabularize(string tasName)
        {
        }
        public void PrintHtml(PEREffectiveConstraint cns, StreamWriterLevel o, int lev, List<string> comment, TypeAssigment tas, List<IConstraint> additonalConstraints)
        {
            ICDBType.PrintHtml(this, cns, o, lev, comment, tas, additonalConstraints);
        }
    }

    public class ICDEnumeratedType : EnumeratedType, ICDType, IInternalContentsInHtml
    {
        public void Tabularize(string tasName)
        {
        }
        public void PrintHtml(PEREffectiveConstraint cns, StreamWriterLevel o, int lev, List<string> comment, TypeAssigment tas, List<IConstraint> additonalConstraints)
        {
            ICDBType.PrintHtml(this, cns, o, lev, comment, tas, additonalConstraints);
        }
        
        public string InternalContentsInHtml(List<IConstraint> additionalConstraints)
        {
            string ret = "Enumeration's values:<br/>";
            List<Item> tmpList = new List<Item>();
            foreach (Item it in m_enumValues.Values)
            {
                EnumeratedValue val = Asn1CompilerInvokation.Instance.Factory.CreateEnumeratedValue(it.m_value, it.m_id, null, m_module, this);
                if (isValueAllowed(val, additionalConstraints))
                    tmpList.Add(it);
            }

            int cnt = tmpList.Count;
            ret += "<ul type=\"square\">";
            for (int i = 0; i < cnt; i++)
            {
                Item it = tmpList[i];
                string itemComment = string.Empty;
                foreach(string line in it.m_comments)
                {
                    string l = line;
                    if (l.StartsWith("--@"))
                        l = l.Substring(3);
                    while (l.StartsWith("-"))
                        l = l.Substring(1);
                    if (l.StartsWith("/*") && l.EndsWith("*/"))
                        l = l.Substring(2, l.Length - 4);
                    itemComment += l;
                }
                ret += string.Format("<li><font  color=\"#5F9EA0\" >{0}</font>({1}) --{2}</li>", it.m_id, it.m_value, itemComment);
                //if (i < cnt - 1)
                //    ret += ", ";
                //if (i % 3 == 2)
                //    ret += "<br/>";
            }
            ret += "</ul>";
            //            ret += "</pre>";
            return ret;
        }

    }

    public class ICDIntegerType : IntegerType, ICDType
    {
        public void Tabularize(string tasName)
        {
        }
        public void PrintHtml(PEREffectiveConstraint cns, StreamWriterLevel o, int lev, List<string> comment, TypeAssigment tas, List<IConstraint> additonalConstraints)
        {
            ICDBType.PrintHtml(this, cns, o, lev, comment, tas, additonalConstraints);
        }
    }

    public class ICDNullType : NullType, ICDType
    {
        public void Tabularize(string tasName)
        {
        }
        public void PrintHtml(PEREffectiveConstraint cns, StreamWriterLevel o, int lev, List<string> comment, TypeAssigment tas, List<IConstraint> additonalConstraints)
        {
            ICDBType.PrintHtml(this, cns, o, lev, comment, tas, additonalConstraints);
        }
    }

    public class ICDObjectIdentifier : ObjectIdentifier, ICDType
    {
        public void Tabularize(string tasName)
        {
        }
        public void PrintHtml(PEREffectiveConstraint cns, StreamWriterLevel o, int lev, List<string> comment, TypeAssigment tas, List<IConstraint> additonalConstraints)
        {
            ICDBType.PrintHtml(this, cns, o, lev, comment, tas, additonalConstraints);
        }
    }

    public class ICDOctetStringType : OctetStringType, ICDType
    {
        public void Tabularize(string tasName)
        {
        }
        public void PrintHtml(PEREffectiveConstraint cns, StreamWriterLevel o, int lev, List<string> comment, TypeAssigment tas, List<IConstraint> additonalConstraints)
        {
            ICDSizeableType.PrintHtml(this, cns, o, lev, comment, tas, additonalConstraints);
        }
    }

    public class ICDRealType : RealType, ICDType
    {
        public void Tabularize(string tasName)
        {
        }
        public void PrintHtml(PEREffectiveConstraint cns, StreamWriterLevel o, int lev, List<string> comment, TypeAssigment tas, List<IConstraint> additonalConstraints)
        {
            ICDBType.PrintHtml(this, cns, o, lev, comment, tas, additonalConstraints);
        }
    }

    public class ICDReferenceType : ReferenceType, ICDType, IInternalContentsInHtml
    {
        public void Tabularize(string tasName)
        {
        }
        public void PrintHtml(PEREffectiveConstraint cns, StreamWriterLevel o, int lev, List<string> comment, TypeAssigment tas, List<IConstraint> additonalConstraints)
        {
            ((ICDType)Type).PrintHtml(cns, o, lev, comment, tas, m_constraints);
        }
        public string InternalContentsInHtml(List<IConstraint> additionalConstraints)
        {
            string ret = string.Empty;
            IInternalContentsInHtml g = Type as IInternalContentsInHtml;
            if (g != null)
            {
                List<IConstraint> replica = new List<IConstraint>(additionalConstraints);
                Asn1Type cur = this;
                while (cur != g)
                {
                    replica.AddRange(cur.m_constraints);
                    cur = cur.ParentType;
                }
                return g.InternalContentsInHtml(replica);
            }
            return ret;
        }
    }

    public class ICDIA5StringType : IA5StringType, ICDType
    {
        public void Tabularize(string tasName)
        {
        }
        public void PrintHtml(PEREffectiveConstraint cns, StreamWriterLevel o, int lev, List<string> comment, TypeAssigment tas, List<IConstraint> additonalConstraints)
        {
            ICDSizeableType.PrintHtml(this, cns, o, lev, comment, tas, additonalConstraints);
        }
    }

    public class ICDNumericStringType : NumericStringType, ICDType
    {
        public void Tabularize(string tasName)
        {
        }
        public void PrintHtml(PEREffectiveConstraint cns, StreamWriterLevel o, int lev, List<string> comment, TypeAssigment tas, List<IConstraint> additonalConstraints)
        {
            ICDSizeableType.PrintHtml(this, cns, o, lev, comment, tas, additonalConstraints);
        }
    }

    public class ICDGeneralizedTimeType : GeneralizedTimeType, ICDType
    {
        public void Tabularize(string tasName)
        {
        }
        public void PrintHtml(PEREffectiveConstraint cns, StreamWriterLevel o, int lev, List<string> comment, TypeAssigment tas, List<IConstraint> additonalConstraints)
        {
            ICDSizeableType.PrintHtml(this, cns, o, lev, comment, tas, additonalConstraints);
        }
    }

    public class ICDUTCTimeType : UTCTimeType, ICDType
    {
        public void Tabularize(string tasName)
        {
        }
        public void PrintHtml(PEREffectiveConstraint cns, StreamWriterLevel o, int lev, List<string> comment, TypeAssigment tas, List<IConstraint> additonalConstraints)
        {
            ICDSizeableType.PrintHtml(this, cns, o, lev, comment, tas, additonalConstraints);
        }
    }
}