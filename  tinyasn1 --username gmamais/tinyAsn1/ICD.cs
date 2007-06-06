using System;
using System.Collections.Generic;
using System.Text;
using Antlr.Runtime.Tree;

namespace tinyAsn1
{
    public class PER_PDU
    {
        public string m_name;
        public List<PER_PDU_Instance> m_instances = new List<PER_PDU_Instance>();
        
        public PER_PDU(string pduName)
        {
            m_name = pduName;
        }

        public PER_PDU_Instance AddEmptyInstance(string instanceName)
        {
            PER_PDU_Instance ret = new PER_PDU_Instance(this, instanceName);
            m_instances.Add(ret);
            return ret;
        }


    }

    public class PER_PDU_Instance
    {
        public PER_PDU m_pdu;
        public List<PERField> m_fields = new List<PERField>();

        public string m_name;


        internal List<PER_PDU_Instance> MultiplyYourself(List<string> insNames)
        {
            List<PER_PDU_Instance> lst = new List<PER_PDU_Instance>();

            lst.Add(this);
            for (int i = 1; i < insNames.Count;i++)
            {
                PER_PDU_Instance clone = MakeClone();
                clone.m_name += "." + insNames[i];
                lst.Add(clone);
                m_pdu.m_instances.Add(clone);
            }
            m_name += "."+insNames[0];

            return lst;
        }

        public PER_PDU_Instance MakeClone()
        {
            PER_PDU_Instance ret = new PER_PDU_Instance(m_pdu, m_name);
            ret.m_fields.AddRange(m_fields);
            return ret;
        }

        public PER_PDU_Instance(PER_PDU pdu,string name) 
        {
            m_pdu = pdu;
            m_name = name;
        }

        public void AddField(string name, int minSize, int maxSize, bool optional) 
        {
            m_fields.Add(new PERField(name, minSize, maxSize, optional));
        }

    }

    public class PERField
    {
        public string m_name;
        public int m_mimSize;
        public int m_maxSize;
        public bool m_optional = false;
        public PERField()
        {
        }
        
        public PERField(string name, int minSize, int maxSize, bool optional)
        {
            m_name = name;
            m_mimSize = minSize;
            m_maxSize = maxSize;
            m_optional = optional;
        }
    }


    public partial class Module
    {
        
    }


    public partial class Asn1Type
    {
        public virtual void CollectFields(PER_PDU_Instance curInst, string varName, bool optional)
        {
            throw new Exception("Asbtract method called ...");
        }

        public virtual PER_PDU GetPDU(string pduName)
        {
            PER_PDU ret = new PER_PDU(pduName);
            PER_PDU_Instance inst = ret.AddEmptyInstance(pduName);
            CollectFields(inst, "Value", false);
            return ret;
        }
    }

    public partial class NullType : Asn1Type
    {
        public override void CollectFields(PER_PDU_Instance curInst, string varName, bool optional)
        {
            curInst.AddField(varName, 0, 0, optional);
        }

    }

    public partial class BitStringType : Asn1Type
    {
        public override void CollectFields(PER_PDU_Instance curInst, string varName, bool optional)
        {
            curInst.AddField(varName, 0, 0, optional);
        }
    }

    public partial class BooleanType : Asn1Type
    {
        public override void CollectFields(PER_PDU_Instance curInst, string varName, bool optional)
        {
            curInst.AddField(varName, 1, 1, optional);
        }
    }

    public partial class RealType : Asn1Type
    {
        public override void CollectFields(PER_PDU_Instance curInst, string varName, bool optional)
        {
            curInst.AddField(varName, 0, 0, optional);
        }
    }




    public partial class EnumeratedType : Asn1Type
    {

        public override void CollectFields(PER_PDU_Instance curInst, string varName, bool optional)
        {
            curInst.AddField(varName, 0, 0, optional);
        }
    }

    public partial class IntegerType : Asn1Type
    {
        public override void CollectFields(PER_PDU_Instance curInst, string varName, bool optional)
        {
            curInst.AddField(varName, 0, 0, optional);
        }
    }

    public partial class ChoiceType : Asn1Type
    {

        //public override void CollectFields(PER_PDU_Instance inst)
        //{
        //    List <PER_PDU_Instance> newInstances = inst.MultiplyYourself(m_children.Keys);
        //    //for(int =0;i<childcount;i++) {
        //    //  newInstances[i].AddField("Preamble");
        //    //}
        //}

        public override void CollectFields(PER_PDU_Instance curInst, string varName, bool optional)
        {
            curInst.AddField(varName+"_choiceIndex", 0, 0, optional);
        }

    }

    public partial class SequenceOrSetType : Asn1Type
    {
        public override void CollectFields(PER_PDU_Instance curInst, string varName, bool optional)
        {
            //if has optional or default fields
            curInst.AddField(varName+"_preamble", 0, 0, false);
            foreach (Child ch in m_children.Values)
            {
                // I need to get all instances from this level and below!
//                foreach(PER_PDU_Instance ins in curInst.m_pdu.m_instances)
//                    ch.m_type.CollectFields(ins, ch.m_childVarName, ch.m_optional || ch.m_default);
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
    }

    public partial class SetOfType : Asn1Type
    {
    }

    public partial class OctetStringType : Asn1Type
    {
        public override void CollectFields(PER_PDU_Instance curInst, string varName, bool optional)
        {
            curInst.AddField(varName, 0, 0, optional);
        }
    }

    public partial class ReferencedType : Asn1Type
    {
        public override void CollectFields(PER_PDU_Instance curInst, string varName, bool optional)
        {
        }
    }

}