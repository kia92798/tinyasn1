using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace tinyAsn1
{
    class SemanticParser : IASTVisitor
    {
        int m_PassNo = 0;
        public int PassNo { get { return m_PassNo; } set { m_PassNo = value; } }


        Asn1CompilerInvokation m_compInv;

        public SemanticParser(Asn1CompilerInvokation compInv)
        {
            m_compInv = compInv;
        }

        
//        bool bFinished = true;
        public bool Finished()
        {
            return m_compInv.SemanticCheckFinished();
        }


        public void OnBeforeAsn1File(Asn1File asn1File)
        {
            PassNo++;
//            bFinished = true;
            if (PassNo > 100)
                throw new Exception("Bug. Number of semantic passes exceeded 100");
        }

        public void OnAfterAsn1File(Asn1File asn1File)
        {
        }

        public void OnBeforeModule(Asn1File asn1File, Module mod)
        {


// Make sure that all imported types are defined in the reference module
            foreach(Module.ImportedModule im in mod.m_imports) {
                if (!m_compInv.isModuleDefined(im.m_moduleID))
                    throw new SemanticErrorException("Error: no module is defined with name: '" + im.m_moduleID + "'");

                Module otherModule = m_compInv.GetModuleByName(im.m_moduleID);
                foreach (string typeName in im.m_importedTypes)
                {
                    if (!otherModule.isTypeDeclaredAsExported(typeName))
                        throw new SemanticErrorException("Error: import type '" + typeName + "' which appears in the import list of module '" + mod.m_moduleID + "' is not exported in module:'" + otherModule.m_moduleID+"'");
                }
                foreach (string varName in im.m_importedVariables)
                {
                    if (!otherModule.isValueDeclaredAsExported(varName))
                        throw new SemanticErrorException("Error: import variable '" + varName + "' which appears in the import list of module '" + mod.m_moduleID + "' is not exported in module:'" + otherModule.m_moduleID + "'");
                }
            }
//Make sure that every export is defined 
            foreach (string expTypeName in mod.m_exportedTypes)
                if (!mod.isTypeDeclared(expTypeName))
                    throw new SemanticErrorException("Error: type '" + expTypeName + "' which appears in the export list of module '" + mod.m_moduleID + "' is not defined");
            foreach(string expVarName in mod.m_exportedVariables)
                if (!mod.isValueDeclared(expVarName))
                    throw new SemanticErrorException("Error: variable '" + expVarName + "' which appears in the export list of module '" + mod.m_moduleID + "' is not defined");

        }

        public void OnAfterModule(Asn1File asn1File, Module mod)
        {
        }

        public void OnBeforeTypeAssigment(Asn1File asn1File, Module mod, TypeAssigment tas)
        {
            tas.m_type.SemanticCheckFinished();
            //    bFinished = false;

           
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
            if (!vas.m_value.SemanticCheckFinished())
            {
                vas.m_value = vas.m_type.FixVariable(vas.m_value);
                //if (!vas.m_value.SemanticCheckFinished())
                //    bFinished = false;
            }
        }

    }
}
