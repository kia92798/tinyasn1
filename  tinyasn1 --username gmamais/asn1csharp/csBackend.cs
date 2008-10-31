using System;
using System.Collections.Generic;
using System.Text;
using Antlr.Runtime.Tree;
using Antlr.Runtime;
using tinyAsn1;

namespace asn1csharp
{

    public class CSharpBackend : DefaultBackend
    {
        CSharpBackendFactory _factory = new CSharpBackendFactory();
        public override IAsn1AbstractFactory Factory
        {
            get
            {
                return _factory;
            }
        }
        public void printCode()
        {
            foreach (CSharpFile file in m_files)
                file.printCode();
        }


    }

    public class CSharpBackendFactory : DefaultAsn1Factory
    {
        public override Asn1File CreateAsn1File()
        {
            return new CSharpFile();
        }

        public override Module CreateModule()
        {
            return new CSharpModule();
        }

        public override BooleanType CreateBooleanType()
        {
            return new CSharpBooleanType();
        }

        public override IntegerType CreateIntegerType()
        {
            return new CSharpIntegerType();
        }

        public override RealType CreateRealType()
        {
            return new CSharpRealType();
        }
        public override EnumeratedType CreateEnumeratedType()
        {
            return new CSharpEnumeratedType();
        }
        public override IA5StringType CreateIA5StringType()
        {
            return new CSharpIA5StringType();
        }
        public override NumericStringType CreateNumericStringType()
        {
            return new CSharpNumericStringType();
        }

        public override SequenceType CreateSequenceType()
        {
            return new CSharpSequenceType();
        }

        public override ChoiceType CreateChoiceType()
        {
            return new CSharpChoiceType();
        }

        public override SetType CreateSetType()
        {
            return new CSharpSetType();
        }
        public override SequenceOfType CreateSequenceOfType()
        {
            return new CSharpSequenceOfType();
        }

        public override SetOfType CreateSetOfType()
        {
            return new CSharpSetOfType();
        }

        public override OctetStringType CreateOctetStringType()
        {
            return new CSharpOctetStringType();
        }

        public override BitStringType CreateBitStringType()
        {
            return new CSharpBitStringType();
        }
        public override ReferenceType CreateReferenceType()
        {
            return new CSharpReferenceType();
        }

        public override NullType CreateNullType()
        {
            return new CSharpNullType();
        }

        //constraints

        public override RootConstraint CreateRootConstraint()
        {
            return new CSharpRootConstraint();
        }

        public override UnionConstraint CreateUnionConstraint()
        {
            return new CSharpUnionConstraint();
        }

        public override AndConstraint CreateAndConstraint()
        {
            return new CSharpAndConstraint();
        }

        public override ExceptConstraint CreateExceptConstraint()
        {
            return new CSharpExceptConstraint();
        }

        public override AllExceptConstraint CreateAllExceptConstraint()
        {
            return new CSharpAllExceptConstraint();
        }

        public override SingleValueConstraint CreateSingleValueConstraint()
        {
            return new CSharpSingleValueConstraint();
        }

        public override SinglePAValueConstraint CreateSinglePAValueConstraint()
        {
            return new CSharpSinglePAValueConstraint();
        }

        public override RangeConstraint CreateRangeConstraint()
        {
            return new CSharpRangeConstraint();
        }

        public override RangePAConstraint CreateRangePAConstraint()
        {
            return new CSharpRangePAConstraint();
        }

        public override SizeConstraint CreateSizeConstraint()
        {
            return new CSharpSizeConstraint();
        }

        public override PermittedAlphabetConstraint CreatePermittedAlphabetConstraint()
        {
            return new CSharpPermittedAlphabetConstraint();
        }




    }


}