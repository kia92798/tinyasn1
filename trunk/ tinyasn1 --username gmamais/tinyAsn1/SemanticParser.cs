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
        }

        public void OnAfterTypeAssigment(Asn1File asn1File, Module mod, TypeAssigment tas)
        {
        }

        public void OnNullType(Asn1File asn1File, Module mod, NullType nullType, TypeAssigment tas)
        {

        }

        public void OnBitStringType(Asn1File asn1File, Module mod, BitStringType bsType, TypeAssigment tas)
        {
            List<NumberedItem> toBeRemoved = new List<NumberedItem>();
            foreach (NumberedItem ni in bsType.m_namedBitsPriv)
            {
                if (bsType.m_namedBits.ContainsKey(ni.m_id))
                    throw new SemanticErrorException("The BIT STRING type defined in line " + bsType.antlrNode.Line +
                        " containts more than once the identifier " + ni.m_id);
                
                if (ni.m_valueAsInt != null)
                {
                    if (ni.m_valueAsInt.Value<0)
                        throw new SemanticErrorException("Error in line : " + bsType.antlrNode.Line + ". Bit string ids must be no negative numbers");
                    bsType.m_namedBits.Add(ni.m_id, ni.m_valueAsInt.Value);
                    toBeRemoved.Add(ni);
                }
                else
                {
                    //We have to look up in the variables definitions
                    string refName = ni.m_valueAsReference;
                    if (mod.isValueDeclared(refName))
                    {
                        Asn1Value tmpVal = mod.GetValue(refName);
                        if (tmpVal.m_valType == Asn1Value.ValType.UNDEFINED)
                            continue;
                        if (tmpVal.m_valType == Asn1Value.ValType.INT)
                        {
                            Int64 val = (Int64)tmpVal.m_value;
                            if (val<0)
                                throw new SemanticErrorException("Error in line : " + bsType.antlrNode.Line + ". Identifier '" + refName + "' is a negative integer");
                            bsType.m_namedBits.Add(ni.m_id, val);
                            toBeRemoved.Add(ni);
                        }
                        else
                        {
                            throw new SemanticErrorException("Error in line : " + bsType.antlrNode.Line + ". Identifier '" + refName + "' is not an integer");
                        }
                        //else let it be resolved in a next parse round
                    }
                    else
                        throw new SemanticErrorException("Error in line : " + bsType.antlrNode.Line + ". Identifier '" + refName + "' is unknown");
                }

            }
            foreach (NumberedItem ni in toBeRemoved)
                bsType.m_namedBitsPriv.Remove(ni);
            if (bsType.m_namedBitsPriv.Count > 0)
                bFinished = false;
        }

        public void OnBooleanType(Asn1File asn1File, Module mod, BooleanType boolType, TypeAssigment tas)
        {

        }

        public void OnRealType(Asn1File asn1File, Module mod, RealType realType, TypeAssigment tas)
        {

        }

        public void OnEnumeratedType(Asn1File asn1File, Module mod, EnumeratedType enumType, TypeAssigment tas)
        {
            List<NumberedItem> toBeRemoved = new List<NumberedItem>();
            foreach (NumberedItem ni in enumType.m_enumValuesPriv)
            {
                if (enumType.m_enumValues.ContainsKey(ni.m_id))
                    throw new SemanticErrorException("The ENUMERATED type defined in line " + enumType.antlrNode.Line +
                        " containts more than once the identifier " + ni.m_id);
                if (ni.m_valueAsInt != null)
                {
                    enumType.m_enumValues.Add(ni.m_id, new EnumeratedType.Item(ni.m_id, ni.m_valueAsInt.Value, ni.m_extended));
                    toBeRemoved.Add(ni);
                }
                else if (ni.m_valueAsReference == "")
                {
                    enumType.m_enumValues.Add(ni.m_id, new EnumeratedType.Item(ni.m_id, ni.m_extended));
                    toBeRemoved.Add(ni);
                }
                else
                {
                    //We have to look up in the variables definitions
                    string refName = ni.m_valueAsReference;
                    if (mod.isValueDeclared(refName))
                    {
                        Asn1Value tmpVal = mod.GetValue(refName);
                        if (tmpVal.m_valType == Asn1Value.ValType.UNDEFINED)
                            continue;
                        if (tmpVal.m_valType == Asn1Value.ValType.INT)
                        {
                            enumType.m_enumValues.Add(ni.m_id, new EnumeratedType.Item(ni.m_id, (Int64)tmpVal.m_value, ni.m_extended));
                            toBeRemoved.Add(ni);
                        }
                        else
                        {
                            throw new SemanticErrorException("Error in line : " + enumType.antlrNode.Line + ". Incompatible types assigment");
                        }
                        //else let it be resolved in a next parse round
                    }
                    else
                        throw new SemanticErrorException("Error in line : " + enumType.antlrNode.Line + ". Identifier '" + refName + "' is unknown");
                }
                
            }

            foreach (NumberedItem ni in toBeRemoved)
                enumType.m_enumValuesPriv.Remove(ni);
            if (enumType.m_enumValuesPriv.Count > 0)
                bFinished = false;
            else
                enumType.FixNumbers();

        }

        public void OnIntegerType(Asn1File asn1File, Module mod, IntegerType intType, TypeAssigment tas)
        {
            List<NumberedItem> toBeRemoved = new List<NumberedItem>();
            foreach (NumberedItem ni in intType.m_privNamedValues)
            {
                if (intType.m_namedValues.ContainsKey(ni.m_id))
                    throw new SemanticErrorException("The INTEGER type defined in line "+intType.antlrNode.Line+
                        " containts more than once the identifier "+ ni.m_id);
                if (ni.m_valueAsInt != null)
                {
                    intType.m_namedValues.Add(ni.m_id, ni.m_valueAsInt.Value);
                    toBeRemoved.Add(ni);
                }
                else
                {
                    //We have to look up in the variables definitions
                    string refName = ni.m_valueAsReference;
                    if (mod.isValueDeclared(refName))
                    {
                        Asn1Value tmpVal = mod.GetValue(refName);
                        if (tmpVal.m_valType == Asn1Value.ValType.UNDEFINED)
                            continue;
                        if (tmpVal.m_valType == Asn1Value.ValType.INT)
                        {
                            intType.m_namedValues.Add(ni.m_id, (Int64)tmpVal.m_value);
                            toBeRemoved.Add(ni);
                        }
                        else
                        {
                            throw new SemanticErrorException("Error in line : " + intType.antlrNode.Line + ". Incompatible types assigment");
                        }
                        //else let it be resolved in a next parse round
                    } else
                        throw new SemanticErrorException("Error in line : " + intType.antlrNode.Line + ". Identifier '" + refName + "' is unknown");

                }
            }
            foreach (NumberedItem ni in toBeRemoved)
                intType.m_privNamedValues.Remove(ni);
            if (intType.m_privNamedValues.Count > 0)
                bFinished = false;
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
            if (vas.m_value.m_valType == Asn1Value.ValType.UNDEFINED)
            {
                vas.m_type.FixVariable(vas.m_value);
                if (vas.m_value.m_valType == Asn1Value.ValType.UNDEFINED)
                    bFinished = false;
            }
        }

    }
}
