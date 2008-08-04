/**=============================================================================
Definition SCCBackend and  SCCBackendFactory classes used in asn1scc project  
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
using Antlr.Runtime.Tree;
using Antlr.Runtime;
using tinyAsn1;

namespace asn1scc
{




    public class SCCBackend : DefaultBackend
    {
        SCCBackendFactory _factory = new SCCBackendFactory();
        public override IAsn1AbstractFactory Factory
        {
            get
            {
                return _factory;
            }
        }

        /// <summary>
        /// It checks that
        /// * All strings, SEQUENCE OFs, SETs etc have SIZE constraint and that MAX is bounded
        /// 
        /// </summary>
        private void CheckStrictConstraintsNeededForAsn1cc()
        {
            foreach (Asn1File f in m_files)
                foreach (Module m in f.m_modules)
                {
                    foreach (SizeableType st in m.GetTypes<SizeableType>())
                    {
                        PERSizeEffectiveConstraint sz = st.PEREffectiveConstraint as PERSizeEffectiveConstraint;
                        if (sz == null)
                            ErrorReporter.SemanticError(f.m_fileName, st.antlrNode.Line, "This type({0}) must have a non extensible size constraint", st.Name);
                        if (sz.Extensible || sz.m_size.m_isExtended)
                            ErrorReporter.SemanticError(f.m_fileName, st.antlrNode.Line, "This type({0}) must have a non extensible size constraint", st.Name);
                        if (sz.m_size.m_rootRange.m_maxIsInfinite)
                            ErrorReporter.SemanticError(f.m_fileName, st.antlrNode.Line, "This type({0}) must have a non extensible size constraint with finite upper value", st.Name);
                    }
                    foreach (SequenceOrSetType sq in m.GetTypes<SequenceOrSetType>())
                    {
                        if (sq.IsPERExtensible())
                            ErrorReporter.SemanticError(f.m_fileName, sq.antlrNode.Line, "This type({0}) cannot be extensible", sq.Name);
                    }
                    foreach (ChoiceType ch in m.GetTypes<ChoiceType>())
                    {
                        if (ch.IsPERExtensible())
                            ErrorReporter.SemanticError(f.m_fileName, ch.antlrNode.Line, "This type({0}) cannot be extensible", ch.Name);
                    }
                    foreach (EnumeratedType en in GetTypes<EnumeratedType>())
                    {
                        if (en.IsPERExtensible())
                            ErrorReporter.SemanticError(f.m_fileName, en.antlrNode.Line, "This type({0}) cannot be extensible", en.Name);
                    }
                }
        }

        private void EnsureUniqueEnumerated()
        {
            List<string> enumKeys = new List<string>();
            List<string> doubleKeys = new List<string>();
            while (true)
            {
                enumKeys.Clear();
                foreach (EnumeratedType en in GetTypes<EnumeratedType>())
                {
                    List<string> path = new List<string>(en.UniquePath.Split('/'));
                    foreach (EnumeratedType.Item item in en.m_enumValues.Values)
                    {
                        if (doubleKeys.Contains(item.CID))
                        {
                            for (int i = path.Count - 1; i >= 0; i--)
                                if (!item.CID.Contains(path[i].Replace('-', '_')))
                                {
                                    item.CID = path[i] + "_" + item.CID;
                                    break;
                                }
                        }
                        enumKeys.Add(item.CID);
                    }
                }

                foreach (ChoiceType ch in GetTypes<ChoiceType>())
                {
                    List<string> path = new List<string>(ch.UniquePath.Split('/'));
                    if (doubleKeys.Contains(ch.CID_NONE))
                    {
                        for (int i = path.Count - 1; i >= 0; i--)
                            if (!ch.CID_NONE.Contains(path[i].Replace('-', '_')))
                            {
                                ch.CID_NONE = path[i] + "_" + ch.CID_NONE;
                                break;
                            }
                    }
                    enumKeys.Add(ch.CID_NONE);
                    foreach (ChoiceChild item in ch.m_children.Values)
                    {
                        if (doubleKeys.Contains(item.CID))
                        {
                            for (int i = path.Count - 1; i >= 0; i--)
                                if (!item.CID.Contains(path[i].Replace('-', '_')))
                                {
                                    item.CID = path[i] + "_" + item.CID;
                                    break;
                                }
                        }
                        enumKeys.Add(item.CID);
                    }
                }


                doubleKeys.Clear();
                for (int i = 0; i < enumKeys.Count; i++)
                {
                    for (int j = i + 1; j < enumKeys.Count; j++)
                    {
                        if (enumKeys[i] == enumKeys[j] && !doubleKeys.Contains(enumKeys[i]))
                            doubleKeys.Add(enumKeys[i]);
                    }
                }
                if (doubleKeys.Count == 0)
                    break;
            }
        }

        public void printC()
        {
            CheckStrictConstraintsNeededForAsn1cc();
            EnsureUniqueEnumerated();
            foreach (SCCFile file in m_files)
                file.printC();
        }
    }

    public class SCCBackendFactory : DefaultAsn1Factory
    {
        public override Asn1File CreateAsn1File()
        {
            return new SCCFile();
        }

        public override Module CreateModule()
        {
            return new SCCModule();
        }

        public override TypeAssigment CreateTypeAssigment()
        {
            return new SCCTypeAssigment();
        }

        public override ValueAssigment CreateValueAssigment()
        {
            return new SCCValueAssigment();
        }

        public override BitStringType CreateBitStringType()
        {
            return new SCCBitStringType();
        }

        public override BooleanType CreateBooleanType()
        {
            return new SCCBooleanType();
        }

        public override ChoiceType CreateChoiceType()
        {
            return new SCCChoiceType();
        }

        public override ChoiceChild CreateChoiceChildType()
        {
            return new SCCChoiceChild();
        }

        public override EnumeratedType CreateEnumeratedType()
        {
            return new SCCEnumeratedType();
        }


        public override IntegerType CreateIntegerType()
        {
            return new SCCIntegerType();
        }

        public override NullType CreateNullType()
        {
            return new SCCNullType();
        }

        public override ObjectIdentifier CreateObjectIdentifierType()
        {
            return new SCCObjectIdentifier();
        }

        public override OctetStringType CreateOctetStringType()
        {
            return new SCCOctetStringType();
        }

        public override RealType CreateRealType()
        {
            return new SCCRealType();
        }

        public override ReferenceType CreateReferenceType()
        {
            return new SCCReferenceType();
        }

        public override SequenceType CreateSequenceType()
        {
            return new SCCSequenceType();
        }

        public override SequenceOfType CreateSequenceOfType()
        {
            return new SCCSequenceOfType();
        }

        public override SetType CreateSetType()
        {
            return new SCCSetType();
        }

        public override SetOfType CreateSetOfType()
        {
            return new SCCSetOfType();
        }

        public override SequenceOrSetType.Child CreateSequenceOrSetChildType()
        {
            return new SCCSequenceOrSetTypeChild();
        }

        public override SequenceOrSetType.Child CreateSequenceOrSetChildType(SequenceOrSetType.Child o)
        {
            return new SCCSequenceOrSetTypeChild(o);
        }

        public override IA5StringType CreateIA5StringType()
        {
            return new SCCIA5StringType();
        }

        public override NumericStringType CreateNumericStringType()
        {
            return new SCCNumericStringType();
        }

        public override GeneralizedTimeType CreateGeneralizedTimeType()
        {
            return new SCCGeneralizedTimeType();
        }

        public override UTCTimeType CreateUTCTimeTypeType()
        {
            return new SCCUTCTimeType();
        }

        public override BitStringValue CreateBitStringValue(Antlr.Runtime.Tree.ITree antlrNode, Module module, Asn1Type type)
        {
            return new SCCBitStringValue(antlrNode, module, type);
        }

        public override BitStringValue CreateBitStringValue(BitStringValue o, Antlr.Runtime.Tree.ITree antlr)
        {
            return new SCCBitStringValue(o, antlr);
        }

        public override BitStringValue CreateBitStringValue(List<long> ids, Antlr.Runtime.Tree.ITree tree, Module mod, Asn1Type type)
        {
            return new SCCBitStringValue(ids, tree, mod, type);
        }

        public override BooleanValue CreateBooleanValue(Antlr.Runtime.Tree.ITree antlrNode, Module module, Asn1Type type)
        {
            return new SCCBooleanValue(antlrNode, module, type);
        }

        public override BooleanValue CreateBooleanValue(BooleanValue o, Antlr.Runtime.Tree.ITree antlr)
        {
            return new SCCBooleanValue(o, antlr);
        }

        public override ChoiceValue CreateChoiceValue(Antlr.Runtime.Tree.ITree antlrNode, Module module, Asn1Type type)
        {
            return new SCCChoiceValue(antlrNode, module, type);
        }

        public override ChoiceValue CreateChoiceValue(ChoiceValue o, Antlr.Runtime.Tree.ITree antlr)
        {
            return new SCCChoiceValue(o, antlr);
        }


        public override EnumeratedValue CreateEnumeratedValue(long val, string id, Antlr.Runtime.Tree.ITree antlr, Module module, Asn1Type type)
        {
            return new SCCEnumeratedValue(val, id, antlr, module, type);
        }

        public override EnumeratedValue CreateEnumeratedValue(EnumeratedValue o, Antlr.Runtime.Tree.ITree antlr)
        {
            return new SCCEnumeratedValue(o, antlr);
        }

        public override IntegerValue CreateIntegerValue(Antlr.Runtime.Tree.ITree antlrNode, Module module, Asn1Type type)
        {
            return new SCCIntegerValue(antlrNode, module, type);
        }

        public override IntegerValue CreateIntegerValue(IntegerValue o, Antlr.Runtime.Tree.ITree antlr)
        {
            return new SCCIntegerValue(o, antlr);
        }

        public override IntegerValue CreateIntegerValue(long val, Module m, Antlr.Runtime.Tree.ITree antlr, Asn1Type type)
        {
            return new SCCIntegerValue(val, m, antlr, type);
        }

        public override NullValue CreateNullValue(Antlr.Runtime.Tree.ITree antlrNode, Module module, Asn1Type type)
        {
            return new SCCNullValue(antlrNode, module, type);
        }

        public override NullValue CreateNullValue(NullValue o, Antlr.Runtime.Tree.ITree antlr)
        {
            return new SCCNullValue(o, antlr);
        }

        public override OctetStringValue CreateOctetStringValue(Antlr.Runtime.Tree.ITree antlrNode, Module module, Asn1Type type)
        {
            return new SCCOctetStringValue(antlrNode, module, type);
        }

        public override OctetStringValue CreateOctetStringValue(OctetStringValue o, Antlr.Runtime.Tree.ITree antlr)
        {
            return new SCCOctetStringValue(o, antlr);
        }

        public override RealValue CreateRealValue(Antlr.Runtime.Tree.ITree antlrNode, Module module, Asn1Type type)
        {
            return new SCCRealValue(antlrNode, module, type);
        }

        public override RealValue CreateRealValue(RealValue o, Antlr.Runtime.Tree.ITree antlr)
        {
            return new SCCRealValue(o, antlr);
        }

        public override SequenceOrSetValue CreateSequenceOrSetValue(Antlr.Runtime.Tree.ITree antlrNode, Module module, Asn1Type type)
        {
            return new SCCSequenceOrSetValue(antlrNode, module, type);
        }

        public override SequenceOrSetValue CreateSequenceOrSetValue(SequenceOrSetValue o, Antlr.Runtime.Tree.ITree antlr)
        {
            return new SCCSequenceOrSetValue(o, antlr);
        }

        public override SequenceOfValue CreateSequenceOfValue(Antlr.Runtime.Tree.ITree antlrNode, Module module, Asn1Type type)
        {
            return new SCCSequenceOfValue(antlrNode, module, type);
        }

        public override SequenceOfValue CreateSequenceOfValue(SequenceOfValue o, Antlr.Runtime.Tree.ITree antlr)
        {
            return new SCCSequenceOfValue(o, antlr);
        }


        public override SetOfValue CreateSetOfValue(Antlr.Runtime.Tree.ITree antlrNode, Module module, Asn1Type type)
        {
            return new SCCSetOfValue(antlrNode, module, type);
        }

        public override SetOfValue CreateSetOfValue(SetOfValue o, Antlr.Runtime.Tree.ITree antlr)
        {
            return new SCCSetOfValue(o, antlr);
        }

        public override IA5StringValue CreateIA5StringValue(Antlr.Runtime.Tree.ITree antlrNode, Module module, Asn1Type type)
        {
            return new SCCIA5StringValue(antlrNode, module, type);
        }

        public override IA5StringValue CreateIA5StringValue(IA5StringValue o, Antlr.Runtime.Tree.ITree antlr)
        {
            return new SCCIA5StringValue(o, antlr);
        }

        public override IA5StringValue CreateIA5StringValue(char str)
        {
            return new SCCIA5StringValue(str);
        }

        public override NumericStringValue CreateNumericStringValue(NumericStringValue o, Antlr.Runtime.Tree.ITree antlr)
        {
            return new SCCNumericStringValue(o, antlr);
        }

        public override NumericStringValue CreateNumericStringValue(Antlr.Runtime.Tree.ITree antlrNode, Module module, Asn1Type type)
        {
            return new SCCNumericStringValue(antlrNode, module, type);
        }

        public override GeneralizedTimeValue CreateGeneralizedTimeValue(GeneralizedTimeValue o, Antlr.Runtime.Tree.ITree antlr)
        {
            return new SCCGeneralizedTimeValue(o, antlr);
        }

        public override GeneralizedTimeValue CreateGeneralizedTimeValue(Antlr.Runtime.Tree.ITree antlrNode, Module module, Asn1Type type)
        {
            return new SCCGeneralizedTimeValue(antlrNode, module, type);
        }

        public override UTCTimeValue CreateUTCTimeValueValue(Antlr.Runtime.Tree.ITree antlrNode, Module module, Asn1Type type)
        {
            return new SCCUTCTimeValue(antlrNode, module, type);
        }

        public override UTCTimeValue CreateUTCTimeValueValue(UTCTimeValue o, Antlr.Runtime.Tree.ITree antlr)
        {
            return new SCCUTCTimeValue(o, antlr);
        }

        public override ObjectIdentifierValue CreateObjectIdentifierValue(Antlr.Runtime.Tree.ITree antlrNode, Module module, Asn1Type type)
        {
            return new SCCObjectIdentifierValue(antlrNode, module, type);
        }

        public override ObjectIdentifierValue CreateObjectIdentifierValue(ObjectIdentifierValue o, Antlr.Runtime.Tree.ITree antlr)
        {
            return new SCCObjectIdentifierValue(o, antlr);
        }

        public override ObjectIdentifierValue.ObjectIdentifierComponent CreateObjectIdentifierValueObjectIdentifierComponent()
        {
            return new SCCObjectIdentifierValueObjectIdentifierComponent();
        }


        //constraints
        public override ExceptionSpec CreateExceptionSpec()
        {
            return new SCCExceptionSpec();
        }

        public override RootConstraint CreateRootConstraint()
        {
            return new SCCRootConstraint();
        }

        public override UnionConstraint CreateUnionConstraint()
        {
            return new SCCUnionConstraint();
        }

        public override AndConstraint CreateAndConstraint()
        {
            return new SCCAndConstraint();
        }

        public override ExceptConstraint CreateExceptConstraint()
        {
            return new SCCExceptConstraint();
        }

        public override AllExceptConstraint CreateAllExceptConstraint()
        {
            return new SCCAllExceptConstraint();
        }

        public override SingleValueConstraint CreateSingleValueConstraint()
        {
            return new SCCSingleValueConstraint();
        }

        public override SinglePAValueConstraint CreateSinglePAValueConstraint()
        {
            return new SCCSinglePAValueConstraint();
        }

        public override RangeConstraint CreateRangeConstraint()
        {
            return new SCCRangeConstraint();
        }

        public override RangePAConstraint CreateRangePAConstraint()
        {
            return new SCCRangePAConstraint();
        }

        public override SizeConstraint CreateSizeConstraint()
        {
            return new SCCSizeConstraint();
        }

        public override PermittedAlphabetConstraint CreatePermittedAlphabetConstraint()
        {
            return new SCCPermittedAlphabetConstraint();
        }

        public override TypeInclusionConstraint CreateTypeInclusionConstraint()
        {
            return new SCCTypeInclusionConstraint();
        }

        public override WithComponentConstraint CreateWithComponentConstraint()
        {
            return new SCCWithComponentConstraint();
        }

        public override WithComponentsConstraint CreateWithComponentsConstraint()
        {
            return new SCCWithComponentsConstraint();
        }

        public override WithComponentsConstraint.Component CreateWithComponentsConstraintComponent(string name, WithComponentsConstraint.Component.PresenseConstraint presCon, IConstraint valCon)
        {
            return new SCCWithComponentsConstraintComponent(name, presCon, valCon);
        }

        public override WithComponentsSeqConstraint CreateWithComponentsSeqConstraint()
        {
            return new SCCWithComponentsSeqConstraint();
        }

        public override WithComponentsChConstraint CreateWithComponentsChConstraint()
        {
            return new SCCWithComponentsChConstraint();
        }

        public override WithComponentsRealConstraint CreateWithComponentsRealConstraint()
        {
            return new SCCWithComponentsRealConstraint();
        }


    }



    /// <summary>
    /// To be moved to CBackend
    /// </summary>
    public class CLocalVariable
    {
        public string varName = "";
        public string type = "";
        public int arrayLen = 0;
        public string initVal = "";
        public bool staticDeclaration = false;
        public CLocalVariable(string VarName, string Type, int ArrayLen, string InitVal)
        {
            varName = VarName;
            type = Type;
            arrayLen = ArrayLen;
            initVal = InitVal;
        }
        public CLocalVariable(string VarName, string Type, int ArrayLen, string InitVal, bool StaticDeclaration)
        {
            varName = VarName;
            type = Type;
            arrayLen = ArrayLen;
            initVal = InitVal;
            staticDeclaration = StaticDeclaration;
        }

        public static void Print(StreamWriterLevel c, OrderedDictionary<string, CLocalVariable> vars)
        {
            foreach (CLocalVariable v in vars.Values)
            {
                c.P(1);
                if (v.staticDeclaration)
                    c.Write("static ");

                c.Write("{0} {1}", v.type, v.varName);
                
                if (v.arrayLen > 0)
                    c.Write("[{0}]",v.arrayLen);

                if (v.initVal != "")
                    c.Write(" = {0}", v.initVal);
                c.WriteLine(";");

                //if (v.arrayLen == 0)
                //{
                //    c.WriteLine("{0} {1} = {2};", v.type, v.varName, v.initVal);
                //}
                //else
                //{
                //    c.WriteLine("{0} {1}[{2}];", v.type, v.varName, v.arrayLen);
                //}
            
            }
            if (vars.Count > 0)
                c.WriteLine();
        }

        public static int GetArrayIndex(string varName)
        {
            int ret = 0;
            foreach (char ch in varName.ToCharArray())
                if (ch == '[')
                    ret++;
            return ret;

        }

    }


}