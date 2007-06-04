using System;
using System.Collections.Generic;
using System.Text;
using Antlr.Runtime.Tree;

namespace tinyAsn1
{

    public partial class Asn1File
    {
        public List<Module> m_modules = new List<Module>();
    }


    public partial class Module
    {

        public partial class ImportedModule
        {
            public string m_moduleID = "";
            public List<string> m_importedTypes = new List<string>();
            public List<string> m_importedVariables = new List<string>();
        }

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


    public partial class ValueAssigment
    {
        public string m_name;
        public Asn1Type m_type;
        public Asn1Value m_value;
    }

    public partial class TypeAssigment
    {
        public string m_name;
        public Asn1Type m_type;
    }

    public partial class ValueSetAssigment
    {
        public string m_typeReference = "";
        public Asn1Type m_type;
        //public ConstraintBody body;

    }

    public partial class Asn1Type
    {
        public partial class Tag
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

    public partial class NumberedItem
    {
        public string m_id = "";
        public string m_valueAsReference = "";
        public int? m_valueAsInt;
    }

    public partial class BitStringType : Asn1Type
    {
        public Dictionary<string, NumberedItem> m_namedBis = new Dictionary<string, NumberedItem>();
    }

    public class BooleanType : Asn1Type
    {
    }

    public class RealType : Asn1Type
    {
    }

    public partial class EnumeratedType : Asn1Type
    {

        public Dictionary<string, NumberedItem> m_enumValues = new Dictionary<string, NumberedItem>();
        public bool m_extMarkPresent = false;
        public ExceptionSpec m_exceptionSpec;
        public Dictionary<string, NumberedItem> m_additionalEnumValues = new Dictionary<string, NumberedItem>();
    }
    
    public partial class IntegerType : Asn1Type
    {
        public Dictionary<string, NumberedItem> m_namedValues = new Dictionary<string, NumberedItem>();
    }

    public partial class ChoiceType : Asn1Type
    {

        public partial class Child
        {
            public string m_childVarName="";
            public Asn1Type m_type;
            public bool m_extended = false;
            public int? m_version=null;
        }

        public Dictionary<string, Child> m_children = new Dictionary<string, Child>();
        public bool m_extMarkPresent = false;
        public ExceptionSpec m_exceptionSpec;
        public bool m_extMarkPresent2 = false;

    }

    public partial class SequenceOrSetType : Asn1Type
    {
        public partial class Child
        {
            public string m_childVarName;
            public Asn1Type m_type;
            public bool m_optional = false;
            public bool m_default = false;
            public Asn1Value m_defaultValue;
            public bool m_extended = false;
            public int? m_version=null;
        }

        public Dictionary<string, Child> m_children = new Dictionary<string, Child>();
        public bool m_extMarkPresent = false;
        public ExceptionSpec m_exceptionSpec;
        public bool m_extMarkPresent2 = false;
    }

    public partial class SequenceType : SequenceOrSetType
    {
    }

    public partial class SetType : SequenceOrSetType
    {
    }

    public partial class SequenceOfType : Asn1Type
    {
        public string m_xmlVarName;
        public Asn1Type type;
    }

    public partial class SetOfType : Asn1Type
    {
        public string m_xmlVarName;
        public Asn1Type type;
    }

    public class OctetStringType : Asn1Type
    {
    }

/* ************ VALUES ***********************/
    public partial class Asn1Value
    {
        public double m_dval;
        public Int64 m_ival;
        public string m_strVal;
        public List<string> m_bitStrVal;
        public List<int> m_charSeqVal;

        public enum ValType
        {
            INT,
            REAL,
            BIT_STRING_LITERAL,
            OCTECT_STRING_LITERAL,
            BIT_STRING_VALUE,
            BOOLEAN_TRUE,
            BOOLEAN_FALSE,
            STRING_LITERAL,
            VALUE_REFERENCE,
            MIN,
            MAX,
            CHAR_SEQUENCE_VALUE
        }

        public ValType m_valType = ValType.INT;

    }


/* ************ CONSTRAINTS ***********************/

    public partial class ExceptionSpec
    {
    }

    public partial class Constraint
    {
        public List<UnionElement> m_set1;
        public bool m_extMarkPresent = false;
        public List<UnionElement> m_set2;
        public Exception m_exception;
    }

    public partial class UnionElement
    {
    }

    public partial class UnionElementOfIntersectionItems : UnionElement
    {
        public List<IntersectionElement> m_intersectionElements = new List<IntersectionElement>();
    }

    public partial class UnionElementExceptOf : UnionElement
    {
        public ConstraintExpression m_exceptOfThis;
    }

    public partial class IntersectionElement
    {
        public ConstraintExpression m_exp;
        public ConstraintExpression m_except_exp;
    }

    public partial class ConstraintExpression
    {
    }

    public partial class ValueRangeExpression : ConstraintExpression
    {
        public Asn1Value m_minValue;
        public Asn1Value m_maxValue;
        public bool m_minValIsIncluded = false;
        public bool m_maxValIsIncluded = false;
    }

    public partial class SizeExpression : ConstraintExpression
    {
        public Constraint m_sizeConstraint;
    }

    public partial class SubtypeExpression : ConstraintExpression
    {
        public Asn1Type m_type;
        public bool m_includes = false;
    }

    public partial class PermittedAlphabetExpression : ConstraintExpression
    {
        public Constraint m_permittedAlphabetConstraint;
    }

    public partial class ConstraintBodyExpression : ConstraintExpression
    {
        public List<UnionElement> m_set1;
        public bool m_extMarkPresent = false;
        public List<UnionElement> m_set2;
    }

}