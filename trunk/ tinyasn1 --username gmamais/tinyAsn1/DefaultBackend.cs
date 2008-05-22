using System;
using System.Collections.Generic;
using System.Text;
using Antlr.Runtime.Tree;

namespace tinyAsn1
{


    public class ICDAsn1CompilerInvokation : Asn1CompilerInvokation
    {

        public override IAsn1AbstractFactory Factory
        {
            get
            {
                return new DefaultAsn1Factory();
            }
        }


    }



    public class DefaultAsn1Factory : IAsn1AbstractFactory
    {

        public virtual  Asn1File CreateAsn1File()
        {
            return new Asn1File();
        }

        public virtual  Module CreateModule()
        {
            return new Module();
        }

        public virtual  ImportedModule CreateImportedModule()
        {
            return new ImportedModule();
        }

        public virtual  TypeAssigment CreateTypeAssigment()
        {
            return new TypeAssigment();
        }

        public virtual  ValueAssigment CreateValueAssigment()
        {
            return new ValueAssigment();
        }

        public virtual  Asn1Type.TagSequence CreateAsn1TypeTagSequence()
        {
            return new Asn1Type.TagSequence();
        }

        public virtual  Asn1Type.Tag CreateAsn1TypeTag()
        {
            return new Asn1Type.Tag();
        }

        public virtual  Asn1Type.Tag CreateAsn1TypeTag(Asn1Type.Tag.TagClass Class, int tagValue, TaggingMode taggingMode, Asn1Type type)
        {
            return new Asn1Type.Tag(Class, tagValue, taggingMode, type);
        }

        public virtual  BitStringType CreateBitStringType()
        {
            return new BitStringType();
        }

        public virtual  BooleanType CreateBooleanType()
        {
            return new BooleanType();
        }

        public virtual  ChoiceType CreateChoiceType()
        {
            return new ChoiceType();
        }

        public virtual  ChoiceChild CreateChoiceChildType()
        {
            return new ChoiceChild();
        }

        public virtual  EnumeratedType CreateEnumeratedType()
        {
            return new EnumeratedType();
        }

        public virtual  EnumeratedType.Item CreateEnumeratedTypeItem(string id, long val, bool isExtended)
        {
            return new EnumeratedType.Item(id, val, isExtended);
        }

        public virtual  EnumeratedType.Item CreateEnumeratedTypeItem(string id, bool isExtended)
        {
            return new EnumeratedType.Item(id, isExtended);
        }

        public virtual  IntegerType CreateIntegerType()
        {
            return new IntegerType();
        }

        public virtual  NullType CreateNullType()
        {
            return new NullType();
        }

        public virtual  ObjectIdentifier CreateObjectIdentifierType()
        {
            return new ObjectIdentifier();
        }

        public virtual  OctetStringType CreateOctetStringType()
        {
            return new OctetStringType();
        }

        public virtual  RealType CreateRealType()
        {
            return new RealType();
        }

        public virtual  ReferenceType CreateReferenceType()
        {
            return new ReferenceType();
        }

        public virtual  SequenceType CreateSequenceType()
        {
            return new SequenceType();
        }

        public virtual  SequenceOfType CreateSequenceOfType()
        {
            return new SequenceOfType();
        }

        public virtual  SetType CreateSetType()
        {
            return new SetType();
        }

        public virtual  SetOfType CreateSetOfType()
        {
            return new SetOfType();
        }

        public virtual  SequenceOrSetType.Child CreateSequenceOrSetChildType()
        {
            return new SequenceOrSetType.Child();
        }

        public virtual  SequenceOrSetType.Child CreateSequenceOrSetChildType(SequenceOrSetType.Child o)
        {
            return new SequenceOrSetType.Child(o);
        }

        public virtual  IA5StringType CreateIA5StringType()
        {
            return new IA5StringType();
        }

        public virtual  NumericStringType CreateNumericStringType()
        {
            return new NumericStringType();
        }

        public virtual  GeneralizedTimeType CreateGeneralizedTimeType()
        {
            return new GeneralizedTimeType();
        }

        public virtual  UTCTimeType CreateUTCTimeTypeType()
        {
            return new UTCTimeType();
        }


        public virtual  BitStringValue CreateBitStringValue(Antlr.Runtime.Tree.ITree antlrNode, Module module, Asn1Type type)
        {
            return new BitStringValue(antlrNode, module, type);
        }

        public virtual  BitStringValue CreateBitStringValue(BitStringValue o, Antlr.Runtime.Tree.ITree antlr)
        {
            return new BitStringValue(o, antlr);
        }

        public virtual  BitStringValue CreateBitStringValue(List<long> ids, Antlr.Runtime.Tree.ITree tree, Module mod, Asn1Type type)
        {
            return new BitStringValue(ids, tree, mod,type);
        }

        public virtual  BooleanValue CreateBooleanValue(Antlr.Runtime.Tree.ITree antlrNode, Module module, Asn1Type type)
        {
            return new BooleanValue(antlrNode, module,type);
        }

        public virtual  BooleanValue CreateBooleanValue(BooleanValue o, Antlr.Runtime.Tree.ITree antlr)
        {
            return new BooleanValue(o, antlr);
        }

        public virtual  ChoiceValue CreateChoiceValue(Antlr.Runtime.Tree.ITree antlrNode, Module module, Asn1Type type)
        {
            return new ChoiceValue(antlrNode, module, type);
        }

        public virtual  ChoiceValue CreateChoiceValue(ChoiceValue o, Antlr.Runtime.Tree.ITree antlr)
        {
            return new ChoiceValue(o, antlr);
        }


        public virtual  EnumeratedValue CreateEnumeratedValue(long val, string id, Antlr.Runtime.Tree.ITree antlr, Module module, Asn1Type type)
        {
            return new EnumeratedValue(val, id, antlr, module, type);
        }

        public virtual  EnumeratedValue CreateEnumeratedValue(EnumeratedValue o, Antlr.Runtime.Tree.ITree antlr)
        {
            return new EnumeratedValue(o, antlr);
        }

        public virtual  IntegerValue CreateIntegerValue(Antlr.Runtime.Tree.ITree antlrNode, Module module, Asn1Type type)
        {
            return new IntegerValue(antlrNode, module, type);
        }

        public virtual  IntegerValue CreateIntegerValue(IntegerValue o, Antlr.Runtime.Tree.ITree antlr)
        {
            return new IntegerValue(o, antlr);
        }

        public virtual  IntegerValue CreateIntegerValue(long val, Module m, Antlr.Runtime.Tree.ITree antlr, Asn1Type type)
        {
            return new IntegerValue(val, m, antlr, type);
        }

        public virtual  NullValue CreateNullValue(Antlr.Runtime.Tree.ITree antlrNode, Module module, Asn1Type type)
        {
            return new NullValue(antlrNode, module, type);
        }

        public virtual  NullValue CreateNullValue(NullValue o, Antlr.Runtime.Tree.ITree antlr)
        {
            return new NullValue(o, antlr);
        }

        public virtual  OctetStringValue CreateOctetStringValue(Antlr.Runtime.Tree.ITree antlrNode, Module module, Asn1Type type)
        {
            return new OctetStringValue(antlrNode, module, type);
        }

        public virtual  OctetStringValue CreateOctetStringValue(OctetStringValue o, Antlr.Runtime.Tree.ITree antlr)
        {
            return new OctetStringValue(o, antlr);
        }

        public virtual  RealValue CreateRealValue(Antlr.Runtime.Tree.ITree antlrNode, Module module, Asn1Type type)
        {
            return new RealValue(antlrNode, module, type);
        }

        public virtual  RealValue CreateRealValue(RealValue o, Antlr.Runtime.Tree.ITree antlr)
        {
            return new RealValue(o, antlr);
        }

        public virtual  SequenceOrSetValue CreateSequenceOrSetValue(Antlr.Runtime.Tree.ITree antlrNode, Module module, Asn1Type type)
        {
            return new SequenceOrSetValue(antlrNode, module, type);
        }

        public virtual  SequenceOrSetValue CreateSequenceOrSetValue(SequenceOrSetValue o, Antlr.Runtime.Tree.ITree antlr)
        {
            return new SequenceOrSetValue(o, antlr);
        }

        public virtual  SequenceOfValue CreateSequenceOfValue(Antlr.Runtime.Tree.ITree antlrNode, Module module, Asn1Type type)
        {
            return new SequenceOfValue(antlrNode, module, type);
        }

        public virtual  SequenceOfValue CreateSequenceOfValue(SequenceOfValue o, Antlr.Runtime.Tree.ITree antlr)
        {
            return new SequenceOfValue(o, antlr);
        }


        public virtual  SetOfValue CreateSetOfValue(Antlr.Runtime.Tree.ITree antlrNode, Module module, Asn1Type type)
        {
            return new SetOfValue(antlrNode, module, type);
        }

        public virtual  SetOfValue CreateSetOfValue(SetOfValue o, Antlr.Runtime.Tree.ITree antlr)
        {
            return new SetOfValue(o, antlr);
        }

        public virtual  IA5StringValue CreateIA5StringValue(Antlr.Runtime.Tree.ITree antlrNode, Module module, Asn1Type type)
        {
            return new IA5StringValue(antlrNode, module, type);
        }

        public virtual  IA5StringValue CreateIA5StringValue(IA5StringValue o, Antlr.Runtime.Tree.ITree antlr)
        {
            return new IA5StringValue(o, antlr);
        }

        public virtual  IA5StringValue CreateIA5StringValue(char str)
        {
            return new IA5StringValue(str);
        }

        public virtual  NumericStringValue CreateNumericStringValue(NumericStringValue o, Antlr.Runtime.Tree.ITree antlr)
        {
            return new NumericStringValue(o, antlr);
        }

        public virtual  NumericStringValue CreateNumericStringValue(Antlr.Runtime.Tree.ITree antlrNode, Module module, Asn1Type type)
        {
            return new NumericStringValue(antlrNode, module, type);
        }

        public virtual  GeneralizedTimeValue CreateGeneralizedTimeValue(GeneralizedTimeValue o, Antlr.Runtime.Tree.ITree antlr)
        {
            return new GeneralizedTimeValue(o, antlr);
        }

        public virtual  GeneralizedTimeValue CreateGeneralizedTimeValue(Antlr.Runtime.Tree.ITree antlrNode, Module module, Asn1Type type)
        {
            return new GeneralizedTimeValue(antlrNode, module, type);
        }

        public virtual  UTCTimeValue CreateUTCTimeValueValue(Antlr.Runtime.Tree.ITree antlrNode, Module module, Asn1Type type)
        {
            return new UTCTimeValue(antlrNode, module, type);
        }

        public virtual  UTCTimeValue CreateUTCTimeValueValue(UTCTimeValue o, Antlr.Runtime.Tree.ITree antlr)
        {
            return new UTCTimeValue(o, antlr);
        }

        public virtual  ObjectIdentifierValue CreateObjectIdentifierValue(Antlr.Runtime.Tree.ITree antlrNode, Module module, Asn1Type type)
        {
            return new ObjectIdentifierValue(antlrNode, module, type);
        }

        public virtual  ObjectIdentifierValue CreateObjectIdentifierValue(ObjectIdentifierValue o, Antlr.Runtime.Tree.ITree antlr)
        {
            return new ObjectIdentifierValue(o, antlr);
        }

        public virtual  ObjectIdentifierValue.ObjectIdentifierComponent CreateObjectIdentifierValueObjectIdentifierComponent()
        {
            return new ObjectIdentifierValue.ObjectIdentifierComponent();
        }

        public virtual  ExceptionSpec CreateExceptionSpec()
        {
            return new ExceptionSpec();
        }

        public virtual  RootConstraint CreateRootConstraint()
        {
            return new RootConstraint();
        }

        public virtual  UnionConstraint CreateUnionConstraint()
        {
            return new UnionConstraint();
        }

        public virtual  AndConstraint CreateAndConstraint()
        {
            return new AndConstraint();
        }

        public virtual  ExceptConstraint CreateExceptConstraint()
        {
            return new ExceptConstraint();
        }

        public virtual  AllExceptConstraint CreateAllExceptConstraint()
        {
            return new AllExceptConstraint();
        }

        public virtual  SingleValueConstraint CreateSingleValueConstraint()
        {
            return new SingleValueConstraint();
        }

        public virtual  SinglePAValueConstraint CreateSinglePAValueConstraint()
        {
            return new SinglePAValueConstraint();
        }

        public virtual  RangeConstraint CreateRangeConstraint()
        {
            return new RangeConstraint();
        }

        public virtual  RangePAConstraint CreateRangePAConstraint()
        {
            return new RangePAConstraint();
        }

        public virtual  SizeConstraint CreateSizeConstraint()
        {
            return new SizeConstraint();
        }

        public virtual  PermittedAlphabetConstraint CreatePermittedAlphabetConstraint()
        {
            return new PermittedAlphabetConstraint();
        }

        public virtual  TypeInclusionConstraint CreateTypeInclusionConstraint()
        {
            return new TypeInclusionConstraint();
        }

        public virtual  WithComponentConstraint CreateWithComponentConstraint()
        {
            return new WithComponentConstraint();
        }

        public virtual  WithComponentsConstraint CreateWithComponentsConstraint()
        {
            return new WithComponentsConstraint();
        }

        public virtual  WithComponentsConstraint.Component CreateWithComponentsConstraintComponent(string name, WithComponentsConstraint.Component.PresenseConstraint presCon, IConstraint valCon)
        {
            return new WithComponentsConstraint.Component(name, presCon, valCon);
        }

        public virtual  WithComponentsSeqConstraint CreateWithComponentsSeqConstraint()
        {
            return new WithComponentsSeqConstraint();
        }

        public virtual  WithComponentsChConstraint CreateWithComponentsChConstraint()
        {
            return new WithComponentsChConstraint();
        }

        public virtual  WithComponentsRealConstraint CreateWithComponentsRealConstraint()
        {
            return new WithComponentsRealConstraint();
        }

        public virtual  IntegerRange CreateIntegerRange()
        {
            return new IntegerRange();
        }

        public virtual  PEREffectiveConstraint CreatePEREffectiveConstraint()
        {
            return new PEREffectiveConstraint();
        }

        public virtual  PERIntegerEffectiveConstraint CreatePERIntegerEffectiveConstraint()
        {
            return new PERIntegerEffectiveConstraint();
        }

        public virtual  PERSizeEffectiveConstraint CreatePERSizeEffectiveConstraint()
        {
            return new PERSizeEffectiveConstraint();
        }

        public virtual  PERSizeEffectiveConstraint CreatePERSizeEffectiveConstraint(PERIntegerEffectiveConstraint size)
        {
            return new PERSizeEffectiveConstraint(size);
        }

        public virtual  PERAlphabetAndSizeEffectiveConstraint CreatePERAlphabetAndSizeEffectiveConstraint()
        {
            return new PERAlphabetAndSizeEffectiveConstraint();
        }

        public virtual  PERAlphabetAndSizeEffectiveConstraint CreatePERAlphabetAndSizeEffectiveConstraint(PERIntegerEffectiveConstraint size)
        {
            return new PERAlphabetAndSizeEffectiveConstraint(size);
        }

        public virtual  PERAlphabetAndSizeEffectiveConstraint CreatePERAlphabetAndSizeEffectiveConstraint(List<char> charSet)
        {
            return new PERAlphabetAndSizeEffectiveConstraint(charSet);
        }

        public virtual  PERAlphabetAndSizeEffectiveConstraint CreatePERAlphabetAndSizeEffectiveConstraint(char? min, char? max, IStringType strType)
        {
            return new PERAlphabetAndSizeEffectiveConstraint(min, max, strType);
        }

    }

#if TO_BE_DELETED
    public class DBAsn1File<T>  : Asn1File where T : new() { public T m_backend = new T(); }
    public class DBModule<T> : Module where T : new() { public T m_backend = new T(); }
    public class DBImportedModule<T> : ImportedModule where T : new() { public T m_backend = new T(); }
    public class DBTypeAssigment<T> : TypeAssigment where T : new()  { public T m_backend = new T(); }
    public class DBValueAssigment<T> : ValueAssigment where T : new() { public T m_backend = new T(); }
    public class DBAsn1TypeTagSequence<T> : Asn1Type.TagSequence where T : new()  { public T m_backend = new T();  }
    
    public class DBAsn1TypeTag<T> : Asn1Type.Tag where T : new()
    {
        public T m_backend = new T();
        public DBAsn1TypeTag() : base() { }
        public DBAsn1TypeTag(Asn1Type.Tag.TagClass Class, int tagValue, TaggingMode taggingMode, Asn1Type type)
            :
            base(Class, tagValue, taggingMode, type) { }
    }
    
    public class DBBitStringType<T> : BitStringType where T : new() { public T m_backend = new T(); }
    public class DBBooleanType<T> : BooleanType where T : new() {public T m_backend = new T(); }
    public class DBChoiceType<T> : ChoiceType where T : new()  { public T m_backend = new T(); }
    public class DBChoiceChild<T> : ChoiceChild where T : new() { public T m_backend = new T(); }
    public class DBEnumeratedType<T> : EnumeratedType where T : new() { public T m_backend = new T();}

    public class DBEnumeratedTypeItem<T> : EnumeratedType.Item where T : new()
    {
        public T m_backend = new T();
        public DBEnumeratedTypeItem(string id, Int64 val, bool isExtended) : base(id, val, isExtended) { }
        public DBEnumeratedTypeItem(string id, bool isExtended) : base(id, isExtended) { }
    }

    public class DBIntegerType<T> : IntegerType, IBackend<T> where T : new() 
    { 
        public T m_backend = new T();
        public T Backend { get { return m_backend; } }
    }
    public class DBNullType<T> : NullType where T : new() { public T m_backend = new T(); }
    public class DBObjectIdentifier<T> : ObjectIdentifier where T : new() { public T m_backend = new T(); }
    public class DBOctetStringType<T> : OctetStringType where T : new() { public T m_backend = new T(); }
    public class DBRealType<T> : RealType where T : new() { public T m_backend = new T(); }
    public class DBReferenceType<T> : ReferenceType where T : new() { public T m_backend = new T(); }
    public class DBSequenceType<T> : SequenceType, IBackend<T> where T : new() 
    { 
        public T m_backend = new T();
        public T Backend { get { return m_backend; } }
    }
    public class DBSequenceOfType<T> : SequenceOfType where T : new() { public T m_backend = new T(); }
    public class DBSetType<T> : SetType where T : new() { public T m_backend = new T(); }
    public class DBSetOfType<T> : SetOfType where T : new() { public T m_backend = new T(); }
    public class DBSizeableType<T> : SizeableType where T : new() { public T m_backend = new T(); }
    public class DBArrayType<T> : ArrayType where T : new() { public T m_backend = new T(); }

    public class DBSequenceOrSetTypeChild<T> : SequenceOrSetType.Child where T : new()
    {
        public T m_backend = new T();
        public DBSequenceOrSetTypeChild():base() {}
        public DBSequenceOrSetTypeChild(SequenceOrSetType.Child o) : base(o) { }
    }

    public class DBIA5StringType<T> : IA5StringType  where T : new() { public T m_backend = new T(); }
    public class DBNumericStringType<T> : NumericStringType  where T : new() { public T m_backend = new T(); }
    public class DBGeneralizedTimeType<T> : GeneralizedTimeType  where T : new() { public T m_backend = new T(); }
    public class DBUTCTimeType<T> : UTCTimeType  where T : new() { public T m_backend = new T(); }


/* ********************************************************************/

	public class DBAsn1Value<T> : Asn1Value where T : new(){ public T m_backend = new T(); }
	public class DBBitStringValue<T> : BitStringValue where T : new()
	{
		public T m_backend = new T();
		public DBBitStringValue(ITree antlrNode, Module module, Asn1Type type) :  base(antlrNode, module, type){}
		public DBBitStringValue(BitStringValue o, ITree antlr) :  base( o, antlr){}
		public DBBitStringValue(List<Int64> ids, ITree tree, Module mod, Asn1Type type) :  base(ids, tree, mod, type){}
	}
	public class DBBooleanValue<T> : BooleanValue where T : new()
	{
		public T m_backend = new T();
		public DBBooleanValue(ITree antlrNode, Module module, Asn1Type type) :  base(antlrNode, module, type){}
		public DBBooleanValue(BooleanValue o, ITree antlr) :  base( o, antlr){}
	}
	public class DBChoiceValue<T> : ChoiceValue where T : new()
	{
		public T m_backend = new T();
		public DBChoiceValue(ITree antlrNode, Module module, Asn1Type type) :  base(antlrNode, module, type){}
		public DBChoiceValue(ChoiceValue o, ITree antlr) :  base( o, antlr){}
	}
	public class DBEnumeratedValue<T> : EnumeratedValue where T : new()
	{
		public T m_backend = new T();
		public DBEnumeratedValue(Int64 val, string id, ITree antlr, Module module, Asn1Type type) :  base(val, id, antlr, module, type){}
		public DBEnumeratedValue(EnumeratedValue o, ITree antlr) :  base( o, antlr){}
	}
	public class DBIntegerValue<T> : IntegerValue where T : new()
	{
		public T m_backend = new T();
		public DBIntegerValue(ITree antlrNode, Module module, Asn1Type type) :  base(antlrNode, module, type){}
		public DBIntegerValue(IntegerValue o, ITree antlr) :  base( o, antlr){}
		public DBIntegerValue(Int64 val, Module m, ITree antlr, Asn1Type type) :  base(val, m, antlr, type){}
	}
	public class DBNullValue<T> : NullValue where T : new()
	{
		public T m_backend = new T();
		public DBNullValue(ITree antlrNode, Module module, Asn1Type type) :  base(antlrNode, module, type){}
		public DBNullValue(NullValue o, ITree antlr) :  base( o, antlr){}
	}
	public class DBOctetStringValue<T> : OctetStringValue where T : new()
	{
		public T m_backend = new T();
		public DBOctetStringValue(ITree antlrNode, Module module, Asn1Type type) :  base(antlrNode, module, type){}
		public DBOctetStringValue(OctetStringValue o, ITree antlr) :  base( o, antlr){}
	}
	public class DBRealValue<T> : RealValue where T : new()
	{
		public T m_backend = new T();
		public DBRealValue(ITree antlrNode, Module module, Asn1Type type) :  base(antlrNode, module, type){}
		public DBRealValue(RealValue o, ITree antlr) :  base( o, antlr){}
	}
	public class DBSequenceOrSetValue<T> : SequenceOrSetValue where T : new()
	{
		public T m_backend = new T();
		public DBSequenceOrSetValue(ITree antlrNode, Module module, Asn1Type type) :  base(antlrNode, module, type){}
		public DBSequenceOrSetValue(SequenceOrSetValue o, ITree antlr) :  base( o, antlr){}
	}
	public class DBSequenceOfValue<T> : SequenceOfValue where T : new()
	{
		public T m_backend = new T();
		public DBSequenceOfValue(ITree antlrNode, Module module, Asn1Type type) :  base(antlrNode, module, type){}
		public DBSequenceOfValue(SequenceOfValue o, ITree antlr) :  base( o, antlr){}
	}
	public class DBArrayValue<T> : ArrayValue where T : new()
	{
		public T m_backend = new T();
	}
	public class DBSetOfValue<T> : SetOfValue where T : new()
	{
		public T m_backend = new T();
		public DBSetOfValue(ITree antlrNode, Module module, Asn1Type type) :  base(antlrNode, module, type){}
		public DBSetOfValue(SetOfValue o, ITree antlr) :  base( o, antlr){}
	}
	public class DBIA5StringValue<T> : IA5StringValue where T : new()
	{
		public T m_backend = new T();
		public DBIA5StringValue(ITree antlrNode, Module module, Asn1Type type) :  base(antlrNode, module, type){}
		public DBIA5StringValue(IA5StringValue o, ITree antlr) :  base( o, antlr){}
		public DBIA5StringValue(Char str) :  base(str){}
	}
	public class DBNumericStringValue<T> : NumericStringValue where T : new()
	{
		public T m_backend = new T();
		public DBNumericStringValue(NumericStringValue o, ITree antlr) :  base( o, antlr){}
		public DBNumericStringValue(ITree antlrNode, Module module, Asn1Type type) :  base(antlrNode, module, type){}
	}
	public class DBGeneralizedTimeValue<T> : GeneralizedTimeValue where T : new()
	{
		public T m_backend = new T();
		public DBGeneralizedTimeValue(GeneralizedTimeValue o, ITree antlr) :  base( o, antlr){}
		public DBGeneralizedTimeValue(ITree antlrNode, Module module, Asn1Type type) :  base(antlrNode, module, type){}
	}
	public class DBUTCTimeValue<T> : UTCTimeValue where T : new()
	{
		public T m_backend = new T();
		public DBUTCTimeValue(ITree antlrNode, Module module, Asn1Type type) :  base(antlrNode, module, type){}
		public DBUTCTimeValue(UTCTimeValue o, ITree antlr) :  base( o, antlr){}
	}
	public class DBObjectIdentifierValue<T> : ObjectIdentifierValue where T : new()
	{
		public T m_backend = new T();
		public DBObjectIdentifierValue(ITree antlrNode, Module module, Asn1Type type) :  base(antlrNode, module, type){}
		public DBObjectIdentifierValue(ObjectIdentifierValue o, ITree antlr) :  base( o, antlr){}
	}
	public class DBObjectIdentifierValueObjectIdentifierComponent<T> : ObjectIdentifierValue.ObjectIdentifierComponent where T : new(){ public T m_backend = new T(); }
	public class DBExceptionSpec<T> : ExceptionSpec where T : new(){ public T m_backend = new T(); }
	public class DBRootConstraint<T> : RootConstraint where T : new(){ public T m_backend = new T(); }
	public class DBUnionConstraint<T> : UnionConstraint where T : new(){ public T m_backend = new T(); }
	public class DBAndConstraint<T> : AndConstraint where T : new(){ public T m_backend = new T(); }
	public class DBExceptConstraint<T> : ExceptConstraint where T : new(){ public T m_backend = new T(); }
	public class DBAllExceptConstraint<T> : AllExceptConstraint where T : new(){ public T m_backend = new T(); }
	public class DBSingleValueConstraint<T> : SingleValueConstraint where T : new(){ public T m_backend = new T(); }
	public class DBSinglePAValueConstraint<T> : SinglePAValueConstraint where T : new(){ public T m_backend = new T(); }
	public class DBRangeConstraint<T> : RangeConstraint where T : new(){ public T m_backend = new T(); }
	public class DBRangePAConstraint<T> : RangePAConstraint where T : new(){ public T m_backend = new T(); }
	public class DBSizeConstraint<T> : SizeConstraint where T : new(){ public T m_backend = new T(); }
	public class DBPermittedAlphabetConstraint<T> : PermittedAlphabetConstraint where T : new(){ public T m_backend = new T(); }
	public class DBTypeInclusionConstraint<T> : TypeInclusionConstraint where T : new(){ public T m_backend = new T(); }
	public class DBWithComponentConstraint<T> : WithComponentConstraint where T : new(){ public T m_backend = new T(); }
	public class DBWithComponentsConstraint<T> : WithComponentsConstraint where T : new(){ public T m_backend = new T(); }
	public class DBWithComponentsConstraintComponent<T> : WithComponentsConstraint.Component where T : new()
	{
		public T m_backend = new T();
		public DBWithComponentsConstraintComponent(string name, WithComponentsConstraint.Component.PresenseConstraint presCon, IConstraint valCon) :  
            base(name, presCon, valCon){}
	}
	public class DBWithComponentsSeqConstraint<T> : WithComponentsSeqConstraint where T : new(){ public T m_backend = new T(); }
	public class DBWithComponentsChConstraint<T> : WithComponentsChConstraint where T : new(){ public T m_backend = new T(); }
	public class DBWithComponentsRealConstraint<T> : WithComponentsRealConstraint where T : new(){ public T m_backend = new T(); }
	public class DBIntegerRange<T> : IntegerRange where T : new(){ public T m_backend = new T(); }
	public class DBPEREffectiveConstraint<T> : PEREffectiveConstraint where T : new(){ public T m_backend = new T(); }
	public class DBPERIntegerEffectiveConstraint<T> : PERIntegerEffectiveConstraint where T : new(){ public T m_backend = new T(); }
	public class DBPERSizeEffectiveConstraint<T> : PERSizeEffectiveConstraint where T : new()
	{
		public T m_backend = new T();
		public DBPERSizeEffectiveConstraint() :  base(){}
		public DBPERSizeEffectiveConstraint(PERIntegerEffectiveConstraint size) :  base(size){}
	}
	public class DBPERAlphabetAndSizeEffectiveConstraint<T> : PERAlphabetAndSizeEffectiveConstraint where T : new()
	{
		public T m_backend = new T();
		public DBPERAlphabetAndSizeEffectiveConstraint() :  base(){}
		public DBPERAlphabetAndSizeEffectiveConstraint(PERIntegerEffectiveConstraint size) :  base(size){}
		public DBPERAlphabetAndSizeEffectiveConstraint(List<Char> charSet) :  base(charSet){}
		public DBPERAlphabetAndSizeEffectiveConstraint(Char? min, Char? max, IStringType strType) :  base(min, max, strType){}
	}
#endif
}
