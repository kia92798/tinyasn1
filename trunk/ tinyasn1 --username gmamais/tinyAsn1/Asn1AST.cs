using System;
using System.Collections.Generic;
using System.Text;

namespace tinyAsn1
{
    public class Module
    {
        public string moduleID;
        public List<TypeAssigment> typeAssigments = new List<TypeAssigment>();
        public List<ValueAssigment> valuesAssigments = new List<ValueAssigment>();
    }

    public class ValueAssigment
    {
        public string name;
        public Asn1Type type;
        public Asn1Value value;
    }

    public class TypeAssigment
    {
        public string name;
        public Asn1Type type;
    }

    public class Asn1Type
    {
        public Constraint constraint;
    }

    public class BitStringType : Asn1Type
    {
        public Dictionary<string, int> namedBis = new Dictionary<string, int>();
    }

    public class BooleanType : Asn1Type
    {
    }

    public class RealType : Asn1Type
    {
    }

    public class EnumeratedType : Asn1Type
    {
        public Dictionary<string, int?> enumValues = new Dictionary<string, int?>();
    }
    
    public class IntegerType : Asn1Type
    {
        public Dictionary<string, int> namedValues = new Dictionary<string, int>();
    }

    public class ChoiceType : Asn1Type
    {
        public Dictionary<string, Asn1Type> children = new Dictionary<string, Asn1Type>();
    }

    public class SequenceType : Asn1Type
    {
        public class SequenceChild
        {
            public Asn1Type type;
            public bool optional = false;
        }
        public Dictionary<string, SequenceChild> children = new Dictionary<string, SequenceChild>();
    }

    public class SequenceOfType : Asn1Type
    {
        public Asn1Type type;
        public Constraint sizeConstraint;
    }

    public class OctetStringType : Asn1Type
    {
    }

    public class Asn1Value
    {
        double dval;
        public Asn1Value(double v)
        {
            dval = v;
        }
        
        Int64 ival;
        public Asn1Value(Int64 v)
        {
            ival = v;
        }
    }




    public class Constraint
    {
//        UnionSet set;
        //UnionSet addSet;
    }

    public class UnionSet
    {
        public List<IntersectionSet> intersections = new List<IntersectionSet>();
        public Element except;
    }

    public class IntersectionSet
    {
        List<Element> elemenst = new List<Element>();
    }

    
    public class Element
    {
        public enum ElementType
        {
            SingleValue,
            ValueRange,
            Set
        }

        ElementType elementType = ElementType.Set;

        public ElementType ElementType1
        {
            get { return elementType; }
        }

        Asn1Value singleValue;
        public Element(Asn1Value v)
        {
            singleValue = v;
            elementType = ElementType.SingleValue;
        }

        Asn1Value minVal;
        Asn1Value maxVal;
        public Element(Asn1Value min, Asn1Value max)
        {
            minVal = min;
            maxVal = max;
            elementType = ElementType.ValueRange;
        }

        UnionSet set;
        public Element(UnionSet s)
        {
            set = s;
            elementType = ElementType.Set;
        }
     
    }
}