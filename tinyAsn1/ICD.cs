using System;
using System.Collections.Generic;
using System.Text;
using Antlr.Runtime.Tree;

namespace tinyAsn1
{
    public class PDUInstance
    {
        public string m_name="";
        public List<SingleField> m_fields = new List<SingleField>();
        public List<string> m_selectedChoices = new List<string>();
        public void sortFields()
        {
            m_fields.Sort(mycompare);
        }
        private static int mycompare(SingleField a1, SingleField a2)
        {
            return a1.m_order.CompareTo(a2.m_order);
        }

        public virtual void GenerateICD(System.IO.TextWriter w)
        {
            if (m_selectedChoices.Count > 0)
            {
                w.WriteLine("<b>selected choices</b><br>");
                foreach (string str in m_selectedChoices)
                    w.WriteLine("<b>{0}</b><br>", str);
            }

            w.WriteLine("<table border=\"1\">");
            w.WriteLine("<tr>");
            w.WriteLine("<td style=\"width: 44px; height: 21px\">");
            w.WriteLine("<strong>#</strong></td>");
            w.WriteLine("<td style=\"width: 291px; height: 21px\">");
            w.WriteLine("<strong>Field</strong></td>");
            w.WriteLine("<td style=\"width: 100px; height: 21px\">");
            w.WriteLine("<strong>min size</strong></td>");
            w.WriteLine("<td style=\"width: 100px; height: 21px\">");
            w.WriteLine("<strong>max size</strong></td>");
            w.WriteLine("</tr>");

            int i = 0;
            foreach (SingleField fld in m_fields)
            {
                fld.GenerateICD(++i, w);
            }

            w.WriteLine("</table>");

        }
    }

    public class ChoiceNode
    {
        public string m_name;
        public ChoiceAlternative m_parent;
        List<ChoiceAlternative> m_choiceAlternatives = new List<ChoiceAlternative>();

        public ChoiceNode (string name, ChoiceAlternative parent) 
        {
            m_parent = parent;
            m_name = name;
        }

        public ChoiceAlternative CreateAlternative(string altName)
        {
            ChoiceAlternative ret = new ChoiceAlternative(m_name + "." + altName, this);
            m_choiceAlternatives.Add(ret);
            return ret;
        }

        private int m_intret = -1;
        public int CalculateInstances()
        {
            if (m_intret == -1)
            {
                m_intret = 0;
                foreach (ChoiceAlternative chAlt in m_choiceAlternatives)
                {
                    m_intret += chAlt.CalculateInstances();
                }
            }
            return m_intret;
        }

        public void Visit(int pass, PDUInstance curInst)
        {
            int locTotal = 0;
            for (int i = 0; i < m_choiceAlternatives.Count; i++)
            {
                int m1 = locTotal;
                int m2 = locTotal + m_choiceAlternatives[i].CalculateInstances();

                if (m1 <= pass && pass < m2)
                {
                    int newpass = pass % m_choiceAlternatives[i].CalculateInstances();
                    m_choiceAlternatives[i].Visit(newpass, curInst);
                    break;
                }
                locTotal = m2;
            }

        }
    }

    public class ChoiceAlternative
    {
        public string m_name;
        public ChoiceNode m_parent;
        public List<SingleField> m_fields = new List<SingleField>();
        List<ChoiceNode> m_children = new List<ChoiceNode>();

        public ChoiceAlternative(string name)
        {
            m_name = name;
            m_parent = null;
        }
        public ChoiceAlternative(string name, ChoiceNode parent)
        {
            m_name = name;
            m_parent = parent;
        }

        public void AddField(string name, int minSize, int maxSize, bool optional)
        {
            m_fields.Add(new SingleField(name, minSize, maxSize, optional));
        }

        public void AddField(string name, int minSize, int maxSize, bool optional, int count)
        {
            m_fields.Add(new SingleField(name, minSize, maxSize, optional,count));
        }

        public ChoiceNode CreateChoice(string childName)
        {
            ChoiceNode ret;
            if (m_name!=childName)
                ret = new ChoiceNode(m_name + "." + childName, this);
            else
                ret = new ChoiceNode(childName, this);
            m_children.Add(ret);
            return ret;
        }



        private int m_intret = -1;
        public int CalculateInstances()
        {
            if (m_intret == -1)
            {
                m_intret = 1;
                foreach (ChoiceNode chNode in m_children)
                {
                    m_intret *= chNode.CalculateInstances();
                }

            }
            return m_intret;
        }

        public List<PDUInstance> GetPDUInstances()
        {
            int nTotalInst = CalculateInstances();
            List<PDUInstance> ret = new List<PDUInstance>();

            for (int i = 0; i < nTotalInst; i++)
            {
                PDUInstance curPDUInstance = new PDUInstance();
                ret.Add(curPDUInstance);
                Visit(i, curPDUInstance);
            }

            return ret;
        }

        public void Visit(int pass, PDUInstance curInst)
        {
            curInst.m_fields.AddRange(m_fields);
            if (curInst.m_name=="")     //top Alternative contains the PDU name
                curInst.m_name = m_name;
            else                       // child alternatives contain choice selected nodes
                curInst.m_selectedChoices.Add(m_name);
            foreach (ChoiceNode curNode in m_children)
            {
                int weight = curNode.CalculateInstances();
                curNode.Visit(pass % weight, curInst);
            }
        }

    }



    public class SingleField
    {
        public string m_name;
        public int m_mimSize=-1;
        public int m_maxSize=-1;
        public bool m_optional = false;
        public int m_count = 1; // For SEQUENCE OF and SET OF is the length of the item
        public int m_order;

        public static int g_order = 1;
        
        public SingleField(string name, int minSize, int maxSize, bool optional)
        {
            m_name = name;
            m_mimSize = minSize;
            m_maxSize = maxSize;
            m_optional = optional;
            m_order = g_order;
            g_order++;
        }

        public SingleField(string name, int minSize, int maxSize, bool optional, int count)
        {
            m_name = name;
            m_mimSize = minSize;
            m_maxSize = maxSize;
            m_optional = optional;
            m_count = count;
            m_order = g_order;
            g_order++;
        }
        public virtual void GenerateICD(int i, System.IO.TextWriter w)
        {
            w.WriteLine("<tr>");

            w.WriteLine("<td style=\"width: 44px\">");
            w.WriteLine(i.ToString("0000"));
            w.WriteLine("</td>");

            w.WriteLine("<td style=\"width: 291px\">");
            w.WriteLine(m_name);
            w.WriteLine("</td>");
            w.WriteLine("<td style=\"width: 100px\">");
            if (m_mimSize != -1)
                w.WriteLine(m_mimSize);
            else
                w.WriteLine("-");
            w.WriteLine("</td>");
            w.WriteLine("<td style=\"width: 100px\">");
            if (m_maxSize != -1)
                w.WriteLine(m_maxSize);
            else
                w.WriteLine("-");
            w.WriteLine("</td>");
            w.WriteLine("<tr>");

        }
    }



    public partial class Asn1File
    {
        public virtual void GenerateICD(System.IO.TextWriter w)
        {
            w.WriteLine("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">");
            w.WriteLine("<html xmlns=\"http://www.w3.org/1999/xhtml\" >");
            w.WriteLine("<head>");
            w.WriteLine("<title>{0}Page</title>",m_fileName);
            w.WriteLine("</head>");
            w.WriteLine("<body bgcolor=\"floralwhite\" >");

            w.WriteLine("<h1>{0}</h1>", m_fileName);
            foreach (Module m in m_modules)
                m.GenerateICD(w);

            w.WriteLine("</body>");
            w.WriteLine("</html>");

        }
    }


    public partial class Module
    {
        public virtual void GenerateICD(System.IO.TextWriter w)
        {
            w.WriteLine("<h2>{0}</h2>", m_moduleID);

            
            foreach (TypeAssigment asig in typeAssigments.Values)
            {
                w.WriteLine("<h3>{0}</h3>", asig.m_name);
                List<PDUInstance> pdus = asig.m_type.GetPDUs(asig.m_name);
                foreach (PDUInstance pdu in pdus)
                {
                    pdu.GenerateICD(w);
                }
//                break; //for now print only the first type assigment
            }
        }
    }


    public partial class Asn1Type
    {
        public virtual void CollectFields(ChoiceAlternative curInst, string varName, bool optional)
        {
            throw new Exception("Asbtract method called ...");
        }

        public virtual List<PDUInstance> GetPDUs(string pduName)
        {
            ChoiceAlternative ret = new ChoiceAlternative(pduName);
            CollectFields(ret, pduName, false);
            return ret.GetPDUInstances();
        }
    }

    public partial class NullType : Asn1Type
    {
        public override void CollectFields(ChoiceAlternative curInst, string varName, bool optional)
        {
            curInst.AddField(varName, 0, 0, optional);
        }

    }

    public partial class BitStringType : Asn1Type
    {
        public override void CollectFields(ChoiceAlternative curInst, string varName, bool optional)
        {
            IntRange sz = SizeConstraint;
            int nminbits = (int)sz.min;
            int nmaxbits = (int)sz.max;
            curInst.AddField(varName, nminbits, nmaxbits, optional);
        }
    }

    public partial class BooleanType : Asn1Type
    {
        public override void CollectFields(ChoiceAlternative curInst, string varName, bool optional)
        {
            curInst.AddField(varName, 1, 1, optional);
        }
    }

    public partial class RealType : Asn1Type
    {
        public override void CollectFields(ChoiceAlternative curInst, string varName, bool optional)
        {
            curInst.AddField(varName, 8, 0, optional);
        }
    }




    public partial class EnumeratedType : Asn1Type
    {

        public override void CollectFields(ChoiceAlternative curInst, string varName, bool optional)
        {
            int nbits = IntRange.getNumberOfEncodedBits((UInt64)m_enumValues.Count - 1);
            curInst.AddField(varName, nbits, nbits, optional);
        }
    }

    public partial class IntegerType : Asn1Type
    {
        public override void CollectFields(ChoiceAlternative curInst, string varName, bool optional)
        {
            IntRange r = IntRangeConstraint;
            curInst.AddField(varName, r.getNumberOfEncodedBits(), r.getNumberOfEncodedBits(), optional);
        }
    }

    public partial class ChoiceType : Asn1Type
    {
        public override void CollectFields(ChoiceAlternative curInst, string varName, bool optional)
        {
            ChoiceNode node = curInst.CreateChoice(varName);
            int nbits = IntRange.getNumberOfEncodedBits((UInt64)m_children.Count-1);
            foreach (Child ch in m_children.Values)
            {
                ChoiceAlternative chPdu = node.CreateAlternative(ch.m_childVarName);
                chPdu.AddField(varName + "_choiceIndex", nbits, nbits, false);
                ch.m_type.CollectFields(chPdu, ch.m_childVarName, false);
            }
        }

    }

    public partial class SequenceOrSetType : Asn1Type
    {
        public override void CollectFields(ChoiceAlternative curInst, string varName, bool optional)
        {
            int nOptFlds = GetNumberOfOptionalOrDefaultFields();
            if (nOptFlds>0)
                curInst.AddField(varName + "_preamble", nOptFlds, nOptFlds, false);
            foreach (Child ch in m_children.Values)
            {
                ch.m_type.CollectFields(curInst, ch.m_childVarName, ch.m_optional||ch.m_default);
            }

        }
    }

    public partial class SequenceType : SequenceOrSetType
    {
    }

    public partial class SetType : SequenceOrSetType
    {
    }

    public partial class SequenceOfType : Asn1Type
    {
        public override void CollectFields(ChoiceAlternative curInst, string varName, bool optional)
        {
            IntRange sz = SizeConstraint;
            if (sz.max != sz.min)
            {
                int nmaxbits = IntRange.getNumberOfEncodedBits((UInt64)sz.max);
                curInst.AddField(varName + "_length", nmaxbits, nmaxbits, optional);
            }
            type.CollectFields(curInst, "SEQUENCE_OF_ELEMENT", false);
        }
    }

    public partial class SetOfType : Asn1Type
    {
    }

    public partial class OctetStringType : Asn1Type
    {
        public override void CollectFields(ChoiceAlternative curInst, string varName, bool optional)
        {
            IntRange sz = SizeConstraint;
            int nminbits = -1;
            int nmaxbits = -1;
            if (sz.Inf)
            {
                nminbits = (int)sz.min * 8;
                nmaxbits = (int)sz.max * 8;
            }
            curInst.AddField(varName, nminbits, nmaxbits, optional);
        }
    }

    public partial class ReferencedType : Asn1Type
    {
        public override void CollectFields(ChoiceAlternative curInst, string varName, bool optional)
        {
            Type.CollectFields(curInst, varName, optional);
        }
    }

}