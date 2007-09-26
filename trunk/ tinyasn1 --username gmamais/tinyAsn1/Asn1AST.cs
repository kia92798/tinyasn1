using System;
using System.Collections.Generic;
using System.Text;
using Antlr.Runtime.Tree;

namespace tinyAsn1
{

    public partial class Asn1File
    {
        public string m_fileName = "";
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
        public MyDictionary<string, TypeAssigment> typeAssigments = new MyDictionary<string, TypeAssigment>();
//        public List<TypeAssigment> typeAssigments = new List<TypeAssigment>();
        public MyDictionary<string, ValueAssigment> valuesAssigments = new MyDictionary<string, ValueAssigment>();
        public MyDictionary<string, ValueSetAssigment> valueSetsAssigments = new MyDictionary<string, ValueSetAssigment>();
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
        public SetOfValues m_constr_body;

    }

    public partial class Asn1Type
    {

        public Module m_module;
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


    public partial class NumberedItem
    {
        public string m_id = "";
        public string m_valueAsReference = "";
        public Int64? m_valueAsInt;
        public bool m_extended = false;

        public Object Value
        {
            get {
                if (m_valueAsInt != null)
                    return m_valueAsInt;
                else
                    return m_valueAsReference;
            }
        }
    }

    public partial class NullType : Asn1Type
    {
        //here I should set the correct tag for NULL
    }

    public partial class BitStringType : Asn1Type
    {
        public MyDictionary<string, NumberedItem> m_namedBis = new MyDictionary<string, NumberedItem>();
    }

    public partial class BooleanType : Asn1Type
    {
    }

    public partial class RealType : Asn1Type
    {
    }

    public partial class EnumeratedType : Asn1Type
    {

        public MyDictionary<string, NumberedItem> m_enumValues = new MyDictionary<string, NumberedItem>();
        public bool m_extMarkPresent = false;
        public ExceptionSpec m_exceptionSpec;
//        public Dictionary<string, NumberedItem> m_additionalEnumValues = new Dictionary<string, NumberedItem>();
    }
    
    public partial class IntegerType : Asn1Type
    {
        public MyDictionary<string, NumberedItem> m_namedValues = new MyDictionary<string, NumberedItem>();
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

        public MyDictionary<string, Child> m_children = new MyDictionary<string, Child>();
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

        public MyDictionary<string, Child> m_children = new MyDictionary<string, Child>();
        public bool m_extMarkPresent = false;
        public ExceptionSpec m_exceptionSpec;
        public bool m_extMarkPresent2 = false;

        public int GetNumberOfOptionalOrDefaultFields()
        {
            int ret = 0;
            foreach (Child ch in m_children.Values)
                if (ch.m_optional || ch.m_default)
                    ret++;

            return ret;
        }
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

    public partial class OctetStringType : Asn1Type
    {
        public int m_stringType;
        public OctetStringType(int strType)
        {
            m_stringType = strType;
        }
    }

    public partial class ReferencedType : Asn1Type
    {
        public string m_referencedTypeName="";
        public string m_modName="";

        public Asn1Type Type
        {
            get
            {
                Asn1Type ret = this;

                while (ret is ReferencedType)
                {
                    if (((ReferencedType)ret).m_modName != "")
                        throw new Exception("Unimplemented feature ...");
                    if (ret.m_module.typeAssigments.ContainsKey(((ReferencedType)ret).m_referencedTypeName))
                        ret = ret.m_module.typeAssigments[((ReferencedType)ret).m_referencedTypeName].m_type;
                    else
                        throw new Exception("Unimplemented feature ...");
                }
                return ret;
            }
        }
    }

/* ************ VALUES ***********************/
    public partial class Asn1Value
    {
        public object m_value;

        public Module m_module;
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
            CHAR_SEQUENCE_VALUE,
            UNDEFINED
        }

        public ValType m_valType = ValType.UNDEFINED;

        public Int64 getValueAsInt()
        {
            if (m_valType == ValType.INT)
                return (Int64)m_value;
            else if (m_valType == ValType.VALUE_REFERENCE)
            {

                Asn1Value ret = this;

                while (ret.m_valType == ValType.VALUE_REFERENCE)
                {
                    if (ret.m_module.valuesAssigments.ContainsKey(ret.m_value.ToString()))
                        ret = ret.m_module.valuesAssigments[ret.m_value.ToString()].m_value;
                    else
                        throw new Exception("Unimplemented feature ...");
                }
                return ret.getValueAsInt();
            }
            else throw new SemanticErrorException(ToString() + " is not INTEGER");
        }

        public override string ToString()
        {
            if (m_valType != ValType.UNDEFINED)
                return m_value.ToString();
            throw new Exception("Value is undifined type");
        }
    }


/* ************ CONSTRAINTS ***********************/

    public partial class ExceptionSpec
    {

    }

    public partial class Constraint
    {
        public SetOfValues m_values;
        public ExceptionSpec m_exception;
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

    public partial class WithComponentsExpression : ConstraintExpression
    {
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
    public partial class PatternExpression : ConstraintExpression
    {
        public Asn1Value m_pattern;
    }

    public partial class SetOfValues : ConstraintExpression
    {
        public List<UnionElement> m_set1 = new List<UnionElement>();
        public bool m_extMarkPresent = false;
        public List<UnionElement> m_set2 = new List<UnionElement>();
    }


    public class SemanticErrorException : Exception
    {
        public SemanticErrorException(string ErrMsg)
            : base(ErrMsg)
        {
        }
    }


}