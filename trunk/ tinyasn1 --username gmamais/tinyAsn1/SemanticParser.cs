using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace tinyAsn1
{
    class SemanticParser : IASTVisitor
    {
        public int PassNo = 0;
        bool bFinished = true;
        public bool Finished()
        {
            return bFinished;
        }


        public void OnBeforeAsn1File(Asn1File asn1File)
        {
            PassNo++;
            bFinished = true;
            if (PassNo > 100)
                throw new Exception("Bug. Number of semantic passes exceeded 100");
        }

        public void OnAfterAsn1File(Asn1File asn1File)
        {
        }

        public void OnBeforeModule(Asn1File asn1File, Module mod)
        {
//1 If EXPORT ALL ==> make all type and variable assigment exportable
            if (mod.bExportAll)
            {
                foreach (TypeAssigment typeAss in mod.m_typeAssigments.Values)
                    mod.m_exportedTypes.Add(typeAss.m_name);
                foreach (ValueAssigment valAsig in mod.m_valuesAssigments.Values)
                    mod.m_exportedVariables.Add(valAsig.m_name);
                mod.bExportAll = false;
            }

        }

        public void OnAfterModule(Asn1File asn1File, Module mod)
        {
        }

        public void OnBeforeTypeAssigment(Asn1File asn1File, Module mod, TypeAssigment tas)
        {
            if (!tas.m_type.SemanticCheckFinished())
                bFinished = false;
        }

        public void OnAfterTypeAssigment(Asn1File asn1File, Module mod, TypeAssigment tas)
        {
        }

        public void OnNullType(Asn1File asn1File, Module mod, NullType nullType, TypeAssigment tas)
        {

        }

        public void OnBitStringType(Asn1File asn1File, Module mod, BitStringType bsType, TypeAssigment tas)
        {
//            bFinished = bsType.SemanticCheck();
        }

        public void OnBooleanType(Asn1File asn1File, Module mod, BooleanType boolType, TypeAssigment tas)
        {

        }

        public void OnRealType(Asn1File asn1File, Module mod, RealType realType, TypeAssigment tas)
        {

        }

        public void OnEnumeratedType(Asn1File asn1File, Module mod, EnumeratedType enumType, TypeAssigment tas)
        {
//               bFinished = enumType.SemanticCheck();
        }

        public void OnIntegerType(Asn1File asn1File, Module mod, IntegerType intType, TypeAssigment tas)
        {
//               bFinished = intType.SemanticCheck();
        }

        public void OnChoiceType(Asn1File asn1File, Module mod, ChoiceType choiceType, TypeAssigment tas)
        {

        }

        public void OnSequenceType(Asn1File asn1File, Module mod, SequenceType seqType, TypeAssigment tas)
        {

        }

        public void OnSetType(Asn1File asn1File, Module mod, SetType setType, TypeAssigment tas)
        {

        }

        public void OnSequenceOfType(Asn1File asn1File, Module mod, SequenceOfType sqOfType, TypeAssigment tas)
        {

        }

        public void OnSetOfType(Asn1File asn1File, Module mod, SetOfType setOfType, TypeAssigment tas)
        {

        }

        public void OnOctectStringType(Asn1File asn1File, Module mod, OctetStringType osType, TypeAssigment tas)
        {

        }

        public void OnReferenceType(Asn1File asn1File, Module mod, ReferenceType refType, TypeAssigment tas)
        {

        }



        public void OnValueAssigment(Asn1File asn1File, Module mod, ValueAssigment vas)
        {
            if (vas.m_value.m_TypeID == Asn1Value.TypeID.UNDEFINED)
            {
                vas.m_value = vas.m_type.FixVariable(vas.m_value);
                if (vas.m_value.m_TypeID == Asn1Value.TypeID.UNDEFINED)
                    bFinished = false;
            }
        }

    }
}
