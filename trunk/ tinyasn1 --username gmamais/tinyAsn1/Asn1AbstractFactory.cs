/**=============================================================================
IAsn1AbstractFactory definition  
================================================================================
Copyright(c) Semantix Information Technologies S.A www.semantix.gr
All rights reserved.

This source code is only intended as a supplement to the
Semantix Technical Reference and related electronic documentation 
provided with the autoICD and asn1scc applications.
See these sources for detailed information regarding the
asn1scc and autoICD applications.
==============================================================================*/
using System;
using System.Collections.Generic;
using System.Text;
using Antlr.Runtime.Tree;

namespace tinyAsn1
{

    /// <summary>
    /// This is the interface of the Abstract Factory for all asn1 classes.
    /// Whenever, you need to build a new backend you must create a class
    /// that implements this interface. The easiest way to do this is to extend
    /// the DefaultAsn1Factory class which provides a default implementation
    /// of the IAsn1AbstractFactory interface
    /// </summary>
    public interface IAsn1AbstractFactory
    {
        Asn1File CreateAsn1File();
        Module CreateModule();
        ImportedModule CreateImportedModule();
        TypeAssigment CreateTypeAssigment();
        ValueAssigment CreateValueAssigment();

//types
        Asn1Type.TagSequence CreateAsn1TypeTagSequence();
        Asn1Type.Tag CreateAsn1TypeTag();
        Asn1Type.Tag CreateAsn1TypeTag(Asn1Type.Tag.TagClass Class, int tagValue, TaggingMode taggingMode, Asn1Type type);
        BitStringType CreateBitStringType();
        BooleanType CreateBooleanType();
        ChoiceType CreateChoiceType();
        ChoiceChild CreateChoiceChildType();
        EnumeratedType CreateEnumeratedType();
        EnumeratedType.Item CreateEnumeratedTypeItem(string id, Int64 val, bool isExtended);
        EnumeratedType.Item CreateEnumeratedTypeItem(string id, bool isExtended);
        IntegerType CreateIntegerType();
        NullType CreateNullType();
        ObjectIdentifier CreateObjectIdentifierType();
        OctetStringType CreateOctetStringType();
        RealType CreateRealType();
        ReferenceType CreateReferenceType();
        SequenceType CreateSequenceType();
        SequenceOfType CreateSequenceOfType();
        SetType CreateSetType();
        SetOfType CreateSetOfType();
        SequenceOrSetType.Child CreateSequenceOrSetChildType();
        SequenceOrSetType.Child CreateSequenceOrSetChildType(SequenceOrSetType.Child o);
        IA5StringType CreateIA5StringType();
        NumericStringType CreateNumericStringType();
        GeneralizedTimeType CreateGeneralizedTimeType();
        UTCTimeType CreateUTCTimeTypeType();

//variables
        BitStringValue CreateBitStringValue(ITree antlrNode, Module module, Asn1Type type);
        BitStringValue CreateBitStringValue(BitStringValue o, ITree antlr);
        BitStringValue CreateBitStringValue(List<Int64> ids, ITree tree, Module mod, Asn1Type type);
        BooleanValue CreateBooleanValue(ITree antlrNode, Module module, Asn1Type type);
        BooleanValue CreateBooleanValue(BooleanValue o, ITree antlr);
        ChoiceValue CreateChoiceValue(ITree antlrNode, Module module, Asn1Type type);
        ChoiceValue CreateChoiceValue(ChoiceValue o, ITree antlr);
        EnumeratedValue CreateEnumeratedValue(Int64 val, string id, ITree antlr, Module module, Asn1Type type);
        EnumeratedValue CreateEnumeratedValue(EnumeratedValue o, ITree antlr);
        IntegerValue CreateIntegerValue(ITree antlrNode, Module module, Asn1Type type);
        IntegerValue CreateIntegerValue(IntegerValue o, ITree antlr);
        IntegerValue CreateIntegerValue(Int64 val, Module m, ITree antlr, Asn1Type type);
        NullValue CreateNullValue(ITree antlrNode, Module module, Asn1Type type);
        NullValue CreateNullValue(NullValue o, ITree antlr);
        OctetStringValue CreateOctetStringValue(ITree antlrNode, Module module, Asn1Type type);
        OctetStringValue CreateOctetStringValue(OctetStringValue o, ITree antlr);
        RealValue CreateRealValue(ITree antlrNode, Module module, Asn1Type type);
        RealValue CreateRealValue(RealValue o, ITree antlr);
        SequenceOrSetValue CreateSequenceOrSetValue(ITree antlrNode, Module module, Asn1Type type);
        SequenceOrSetValue CreateSequenceOrSetValue(SequenceOrSetValue o, ITree antlr);
        SequenceOfValue CreateSequenceOfValue(ITree antlrNode, Module module, Asn1Type type);
        SequenceOfValue CreateSequenceOfValue(SequenceOfValue o, ITree antlr);
        SetOfValue CreateSetOfValue(ITree antlrNode, Module module, Asn1Type type);
        SetOfValue CreateSetOfValue(SetOfValue o, ITree antlr);
        IA5StringValue CreateIA5StringValue(ITree antlrNode, Module module, Asn1Type type);
        IA5StringValue CreateIA5StringValue(IA5StringValue o, ITree antlr);
        IA5StringValue CreateIA5StringValue(Char str);
        NumericStringValue CreateNumericStringValue(NumericStringValue o, ITree antlr);
        NumericStringValue CreateNumericStringValue(ITree antlrNode, Module module, Asn1Type type);
        GeneralizedTimeValue CreateGeneralizedTimeValue(GeneralizedTimeValue o, ITree antlr);
        GeneralizedTimeValue CreateGeneralizedTimeValue(ITree antlrNode, Module module, Asn1Type type);
        UTCTimeValue CreateUTCTimeValueValue(ITree antlrNode, Module module, Asn1Type type);
        UTCTimeValue CreateUTCTimeValueValue(UTCTimeValue o, ITree antlr);
        ObjectIdentifierValue CreateObjectIdentifierValue(ITree antlrNode, Module module, Asn1Type type);
        ObjectIdentifierValue CreateObjectIdentifierValue(ObjectIdentifierValue o, ITree antlr);
        ObjectIdentifierValue.ObjectIdentifierComponent CreateObjectIdentifierValueObjectIdentifierComponent();

//CONSTRAINTS
        ExceptionSpec CreateExceptionSpec();
        RootConstraint CreateRootConstraint();
        UnionConstraint CreateUnionConstraint();
        AndConstraint CreateAndConstraint();
        ExceptConstraint CreateExceptConstraint();
        AllExceptConstraint CreateAllExceptConstraint();
        SingleValueConstraint CreateSingleValueConstraint();
        SinglePAValueConstraint CreateSinglePAValueConstraint();
        RangeConstraint CreateRangeConstraint();
        RangePAConstraint CreateRangePAConstraint();
        SizeConstraint CreateSizeConstraint();
        PermittedAlphabetConstraint CreatePermittedAlphabetConstraint();
        TypeInclusionConstraint CreateTypeInclusionConstraint();
        WithComponentConstraint CreateWithComponentConstraint();
        WithComponentsConstraint CreateWithComponentsConstraint();
        WithComponentsConstraint.Component CreateWithComponentsConstraintComponent(string name, WithComponentsConstraint.Component.PresenseConstraint presCon, IConstraint valCon);
        WithComponentsSeqConstraint CreateWithComponentsSeqConstraint();
        WithComponentsChConstraint CreateWithComponentsChConstraint();
        WithComponentsRealConstraint CreateWithComponentsRealConstraint();

//PER
        IntegerRange CreateIntegerRange();
        PEREffectiveConstraint CreatePEREffectiveConstraint();
        PERIntegerEffectiveConstraint CreatePERIntegerEffectiveConstraint();
        PERSizeEffectiveConstraint CreatePERSizeEffectiveConstraint();
        PERSizeEffectiveConstraint CreatePERSizeEffectiveConstraint(PERIntegerEffectiveConstraint size);
        PERAlphabetAndSizeEffectiveConstraint CreatePERAlphabetAndSizeEffectiveConstraint();
        PERAlphabetAndSizeEffectiveConstraint CreatePERAlphabetAndSizeEffectiveConstraint(PERIntegerEffectiveConstraint size);
        PERAlphabetAndSizeEffectiveConstraint CreatePERAlphabetAndSizeEffectiveConstraint(List<Char> charSet);
        PERAlphabetAndSizeEffectiveConstraint CreatePERAlphabetAndSizeEffectiveConstraint(Char? min, Char? max, IStringType strType);
    }


}
