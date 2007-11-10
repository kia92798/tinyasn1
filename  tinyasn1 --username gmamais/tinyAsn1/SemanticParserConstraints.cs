using System;
using System.Collections.Generic;
using System.Text;

namespace tinyAsn1
{
    class SemanticParserConstraints : IASTVisitor
    {
        int m_PassNo = 0;
        public int PassNo { get { return m_PassNo; } set { m_PassNo = value; } }


        Asn1CompilerInvokation m_compInv;

        public SemanticParserConstraints(Asn1CompilerInvokation compInv)
        {
            m_compInv = compInv;
        }

        
        public bool Finished()
        {
            foreach (Asn1File f in m_compInv.m_files)
                foreach (Module m in f.m_modules)
                    foreach (TypeAssigment t in m.m_typeAssigments.Values)
                        if (!t.m_type.AreConstraintsResolved())
                            return false;
            return true;
        }


        public void OnBeforeAsn1File(Asn1File asn1File)
        {
            PassNo++;
            if (PassNo > 100)
                throw new Exception("Bug. Number of semantic passes exceeded 100");
        }

        public void OnAfterAsn1File(Asn1File asn1File)
        {
        }

        public void OnBeforeModule(Asn1File asn1File, Module mod)
        {
        }

        public void OnAfterModule(Asn1File asn1File, Module mod)
        {
        }

        public void OnBeforeTypeAssigment(Asn1File asn1File, Module mod, TypeAssigment tas)
        {
            tas.m_type.ResolveConstraints();
        }

        public void OnAfterTypeAssigment(Asn1File asn1File, Module mod, TypeAssigment tas)
        {
        }

        public void OnNullType(Asn1File asn1File, Module mod, NullType nullType, TypeAssigment tas)
        {

        }

        public void OnBitStringType(Asn1File asn1File, Module mod, BitStringType bsType, TypeAssigment tas)
        {
        }

        public void OnBooleanType(Asn1File asn1File, Module mod, BooleanType boolType, TypeAssigment tas)
        {

        }

        public void OnRealType(Asn1File asn1File, Module mod, RealType realType, TypeAssigment tas)
        {

        }

        public void OnEnumeratedType(Asn1File asn1File, Module mod, EnumeratedType enumType, TypeAssigment tas)
        {
        }

        public void OnIntegerType(Asn1File asn1File, Module mod, IntegerType intType, TypeAssigment tas)
        {
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
        }

    }

}
