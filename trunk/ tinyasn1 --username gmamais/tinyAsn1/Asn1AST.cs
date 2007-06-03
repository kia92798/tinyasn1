using System;
using System.Collections.Generic;
using System.Text;

namespace tinyAsn1
{


    public class Module
    {
        public enum Tags
        {
            EXPLICIT,
            IMPLICIT,
            AUTOMATIC,
            NONE
        }
        public enum ExportStatus
        {
            ALL,
            SOME,
            NONE
        }

        public string m_moduleID="";
        public Tags m_tags = Tags.NONE;
        public bool m_extensibilityImplied = false;
        public ExportStatus m_exportStatus = ExportStatus.NONE;
        public List<string> m_exportedTypes = new List<string>();
        public List<string> m_exportedVariables = new List<string>();
        public List<ImportedModule> m_imports = new List<ImportedModule>();
        public Dictionary<string, TypeAssigment> typeAssigments = new Dictionary<string, TypeAssigment>();
        public Dictionary<string, ValueAssigment> valuesAssigments = new Dictionary<string, ValueAssigment>();
        public Dictionary<string, ValueSetAssigment> valueSetsAssigments = new Dictionary<string, ValueSetAssigment>();
    }

    public class ImportedModule
    {
        public string m_moduleID = "";
        public List<string> m_exportedTypes = new List<string>();
        public List<string> m_exportedVariables = new List<string>();

    }

    public class ValueAssigment
    {
        public string m_name;
        public Asn1Type m_type;
        public Asn1Value m_value;
    }

    public class TypeAssigment
    {
        public string m_name;
        public Asn1Type m_type;
    }

    public class ValueSetAssigment
    {
        public string m_typeReference = "";
        public Asn1Type m_type;
        //public ConstraintBody body;

    }

    public class Asn1Type
    {
        public class Tag
        {
            public enum TagClass
            {
                UNIVERSAL,
                APPLICATION, 
                PRIVATE,
                NONE
            }
            public int m_tag;
            public TagClass m_class = TagClass.NONE;
            public Module.Tags ImpOrExpl = Module.Tags.NONE;
        }

        public Tag m_tag;
        public List<Constraint> m_constraints = new List<Constraint>();
    }

    public class NullType : Asn1Type
    {
        //here I should set the correct tag for NULL
    }

    public class BitStringType : Asn1Type
    {
        public class BitStringItem
        {
            public string m_id = "";
            public string m_valueAsReference = "";
            public int? m_valueAsInt;
        }

        public Dictionary<string, BitStringItem> m_namedBis = new Dictionary<string, BitStringItem>();
    }

    public class BooleanType : Asn1Type
    {
    }

    public class RealType : Asn1Type
    {
    }

    public class EnumeratedType : Asn1Type
    {
        public class EnumeratedItem
        {
            public string m_id = "";
            public string m_valueAsReference = "";
            public int? m_valueAsInt;
        }

        public Dictionary<string, EnumeratedItem> m_enumValues = new Dictionary<string, EnumeratedItem>();
        public bool m_extMarkPresent = false;
        public ExceptionSpec m_exceptionSpec;
        public Dictionary<string, EnumeratedItem> m_additionalEnumValues = new Dictionary<string, EnumeratedItem>();
    }
    
    public class IntegerType : Asn1Type
    {
        public class IntegerValueItem
        {
            public string m_id = "";
            public string m_valueAsReference = "";
            public int? m_valueAsInt;
        }

        public Dictionary<string, IntegerValueItem> namedValues = new Dictionary<string, IntegerValueItem>();
    }

    public class ChoiceType : Asn1Type
    {

        public class ChoiceExtendedItem
        {
            public enum Type {
                SINGLE_CHILD,
                LIST
            }
            Type type = Type.SINGLE_CHILD;
            public int m_version;
            public Dictionary<string, Asn1Type> m_children = new Dictionary<string, Asn1Type>();
            KeyValuePair<string, Asn1Type> m_child = new KeyValuePair<string, Asn1Type>();
        }

        public Dictionary<string, Asn1Type> m_children = new Dictionary<string, Asn1Type>();
        public bool m_extMarkPresent = false;
        public ExceptionSpec m_exceptionSpec;
        public List<ChoiceExtendedItem> m_additionalChildren = new List<ChoiceExtendedItem>();
        public bool m_extMarkPresent2 = false;

        public ChoiceType()
        {
        }
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


    public class ExceptionSpec
    {
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