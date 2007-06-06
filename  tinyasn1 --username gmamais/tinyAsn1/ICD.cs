using System;
using System.Collections.Generic;
using System.Text;
using Antlr.Runtime.Tree;

namespace tinyAsn1
{
    public class PER_PDU
    {
        public string m_name;

        public PER_PDU m_parentPDU;

        public List<PERField> m_fields = new List<PERField>();

        List<PER_PDU> m_childrenPDUs = new List<PER_PDU>();

        public List<PER_PDU> m_AllPDUs = new List<PER_PDU>();


        public PER_PDU(string name)
        {
            m_name = name;
            m_parentPDU = null;
        }
        public PER_PDU(string name, PER_PDU parent)
        {
            m_name = name;
            m_parentPDU = parent;
        }

        public void AddField(string name, int minSize, int maxSize, bool optional)
        {
            m_fields.Add(new PERField(name, minSize, maxSize, optional));
        }

        public void AddField(string name, int minSize, int maxSize, bool optional, int count)
        {
            m_fields.Add(new PERField(name, minSize, maxSize, optional,count));
        }

        public PER_PDU CreateChildPDU(string childName)
        {
            PER_PDU ret = new PER_PDU(childName, this);
            m_childrenPDUs.Add(ret);
            return ret;

        }


        internal void Normalize()
        {
            MoveFieldsToChildren(this);
            foreach (PER_PDU norm in m_AllPDUs)
            {
                norm.sortFields();
            }
        }

        void MoveFieldsToChildren(PER_PDU root)
        {
            foreach (PER_PDU childPdu in m_childrenPDUs)
            {
                childPdu.AddFields(m_fields);
                childPdu.MoveFieldsToChildren(root);
            }
            if (m_childrenPDUs.Count > 0)
                m_fields.Clear();
            else
                root.m_AllPDUs.Add(this);
        }

        private void AddFields(List<PERField> fields)
        {
            m_fields.AddRange(fields);
        }

        void sortFields()
        {
            m_fields.Sort(mycompare);
        }
        private static int mycompare(PERField a1, PERField a2)
        {
            return a1.m_order.CompareTo(a2.m_order);
        }

        public virtual void GenerateICD(System.IO.TextWriter w)
        {
            w.WriteLine("=============================");
            foreach (PERField fld in m_fields)
            {
                fld.GenerateICD(w);
            }
        }
    }

    public class PERField
    {
        public string m_name;
        public int m_mimSize;
        public int m_maxSize;
        public bool m_optional = false;
        public int m_count = 1; // For SEQUENCE OF and SET OF is the length of the item
        public int m_order;

        public static int g_order = 1;
        
        public PERField(string name, int minSize, int maxSize, bool optional)
        {
            m_name = name;
            m_mimSize = minSize;
            m_maxSize = maxSize;
            m_optional = optional;
            m_order = g_order;
            g_order++;
        }

        public PERField(string name, int minSize, int maxSize, bool optional, int count)
        {
            m_name = name;
            m_mimSize = minSize;
            m_maxSize = maxSize;
            m_optional = optional;
            m_count = count;
            m_order = g_order;
            g_order++;
        }
        public virtual void GenerateICD(System.IO.TextWriter w)
        {
            w.WriteLine(m_name);
        }
    }



    public partial class Asn1File
    {
        public virtual void GenerateICD(System.IO.TextWriter w)
        {
            foreach (Module m in m_modules)
                m.GenerateICD(w);
        }
    }


    public partial class Module
    {
        public virtual void GenerateICD(System.IO.TextWriter w)
        {
            w.WriteLine("=======Module: {0} =======",m_moduleID);

            
            foreach (TypeAssigment asig in typeAssigments.Values)
            {
                List<PER_PDU> pdus = asig.m_type.GetPDUs("ROOT");
                foreach (PER_PDU pdu in pdus)
                {
                    pdu.GenerateICD(w);
                }
                break; //for now print only the first type assigment
            }
        }
    }


    public partial class Asn1Type
    {
        public virtual void CollectFields(PER_PDU curInst, string varName, bool optional)
        {
            throw new Exception("Asbtract method called ...");
        }

        public virtual List<PER_PDU> GetPDUs(string pduName)
        {
            PER_PDU ret = new PER_PDU(pduName);
            CollectFields(ret, "Value", false);
            ret.Normalize();
            return ret.m_AllPDUs;
        }
    }

    public partial class NullType : Asn1Type
    {
        public override void CollectFields(PER_PDU curInst, string varName, bool optional)
        {
            curInst.AddField(varName, 0, 0, optional);
        }

    }

    public partial class BitStringType : Asn1Type
    {
        public override void CollectFields(PER_PDU curInst, string varName, bool optional)
        {
            curInst.AddField(varName, 0, 0, optional);
        }
    }

    public partial class BooleanType : Asn1Type
    {
        public override void CollectFields(PER_PDU curInst, string varName, bool optional)
        {
            curInst.AddField(varName, 1, 1, optional);
        }
    }

    public partial class RealType : Asn1Type
    {
        public override void CollectFields(PER_PDU curInst, string varName, bool optional)
        {
            curInst.AddField(varName, 0, 0, optional);
        }
    }




    public partial class EnumeratedType : Asn1Type
    {

        public override void CollectFields(PER_PDU curInst, string varName, bool optional)
        {
            curInst.AddField(varName, 0, 0, optional);
        }
    }

    public partial class IntegerType : Asn1Type
    {
        public override void CollectFields(PER_PDU curInst, string varName, bool optional)
        {
            curInst.AddField(varName, 0, 0, optional);
        }
    }

    public partial class ChoiceType : Asn1Type
    {
        public override void CollectFields(PER_PDU curInst, string varName, bool optional)
        {
            foreach (Child ch in m_children.Values)
            {
                PER_PDU chPdu = curInst.CreateChildPDU(varName);
                chPdu.AddField(varName + "_choiceIndex", 0, 0, optional);
                ch.m_type.CollectFields(chPdu, ch.m_childVarName, false);
            }
        }

    }

    public partial class SequenceOrSetType : Asn1Type
    {
        public override void CollectFields(PER_PDU curInst, string varName, bool optional)
        {
            curInst.AddField(varName+"_preamble", 0, 0, false);
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
        public override void CollectFields(PER_PDU curInst, string varName, bool optional)
        {
            curInst.AddField(varName+"_length", 0, 0, optional);
            type.CollectFields(curInst, "SEQUENCE_OF_ELEMENT", false);
        }
    }

    public partial class SetOfType : Asn1Type
    {
    }

    public partial class OctetStringType : Asn1Type
    {
        public override void CollectFields(PER_PDU curInst, string varName, bool optional)
        {
            curInst.AddField(varName, 0, 0, optional);
        }
    }

    public partial class ReferencedType : Asn1Type
    {
        public override void CollectFields(PER_PDU curInst, string varName, bool optional)
        {
            Type.CollectFields(curInst, varName, optional);
        }
    }

}