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
            AUTOMATIC
        }

        public string m_moduleID="";
        public Tags m_tags = Tags.EXPLICIT;
        public bool m_extensibilityImplied = false;

        public Asn1Value GetValue(string valueName)
        {
            if (!isValueDeclared(valueName))
                throw new Exception("Internal Error: variable '"+valueName+"' is not declared");
            if (m_valuesAssigments.ContainsKey(valueName))
                return m_valuesAssigments[valueName].m_value;

            throw new Exception("Internal error: Imports/Exports are not implemented yet!");
        }

        public ValueAssigment GetValueAssigment(string valueAssigId)
        {
            if (!isValueDeclared(valueAssigId))
                throw new Exception("Internal Error: variable assigment '" + valueAssigId + "' is not declared");
            if (m_valuesAssigments.ContainsKey(valueAssigId))
                return m_valuesAssigments[valueAssigId];

            throw new Exception("Internal error: Imports/Exports are not implemented yet!");
        }

        public bool isValueDeclared(string valueName)
        {
            if (m_valuesAssigments.ContainsKey(valueName))
                return true;
            foreach (ImportedModule im in m_imports)
                if (im.m_importedVariables.Contains(valueName))
                    return true;

            return false;
        }
        
        public List<string> m_exportedTypes = new List<string>();
        public List<string> m_exportedVariables = new List<string>();
        public List<ImportedModule> m_imports = new List<ImportedModule>();

        public OrderedDictionary<string, TypeAssigment> m_typeAssigments = new OrderedDictionary<string, TypeAssigment>();
        public OrderedDictionary<string, ValueAssigment> m_valuesAssigments = new OrderedDictionary<string, ValueAssigment>();
//        public OrderedDictionary<string, ValueSetAssigment> m_valueSetsAssigments = new OrderedDictionary<string, ValueSetAssigment>();

        internal Dictionary<string, Int64> m_resolvedIntegerVars = new Dictionary<string, Int64>(); 

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

/*
    public partial class ValueSetAssigment
    {
        public string m_typeReference = "";
        public Asn1Type m_type;
        public SetOfValues m_constr_body;

    }
 */ 

    public partial class Asn1Type
    {
        internal ITree antlrNode;
        public Module m_module;
        public partial class Tag
        {
            public enum TagClass
            {
                UNIVERSAL,
                APPLICATION, 
                PRIVATE,
                CONTEXT_SPECIFIC
            }
            public int m_tag;
            public TagClass m_class = TagClass.CONTEXT_SPECIFIC;
            public Module.Tags ImpOrExpl = Module.Tags.EXPLICIT;
        }

        public Tag m_tag;
        public List<Constraint> m_constraints = new List<Constraint>();

        public virtual Asn1Type GetFinalType()
        {
            return this;
        }

        public virtual string Name
        {
            get
            {
                throw new Exception("Internal Error: Abstract method call");
            }
        }
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
        public override string Name
        {
            get   { return "NULL"; }
        }
    }

    public partial class BitStringType : Asn1Type
    {
        internal List<NumberedItem> m_namedBitsPriv = new List<NumberedItem>();
        public OrderedDictionary<string, Int64> m_namedBits = new OrderedDictionary<string, Int64>();
        public override string Name
        {
            get { return "BIT STRING"; }
        }
    }

    public partial class BooleanType : Asn1Type
    {
        public override string Name
        {
            get { return "BOOLEAN"; }
        }

    }

    public partial class RealType : Asn1Type
    {
        public override string Name
        {
            get { return "REAL"; }
        }
    }

    public partial class EnumeratedType : Asn1Type
    {
        public class Item
        {
            public Item(string id, Int64 val, bool isExtended) { m_id = id; m_value = val; m_isExtended = isExtended; m_valCalculated = true; }
            public Item(string id, bool isExtended) { m_id = id; m_isExtended = isExtended; m_valCalculated = false; }
            public string m_id;
            public Int64 m_value;
            public bool m_isExtended=false;
            internal bool m_valCalculated = false;
        }

        internal List<NumberedItem> m_enumValuesPriv = new List<NumberedItem>();
        public OrderedDictionary<string, Item> m_enumValues = new OrderedDictionary<string, Item>();
        public bool m_extMarkPresent = false;
        public ExceptionSpec m_exceptionSpec;

        public override string Name
        {
            get { return "ENUMERATED"; }
        }
    }
    
    public partial class IntegerType : Asn1Type
    {
        internal List<NumberedItem> m_privNamedValues = new List<NumberedItem>();
        public OrderedDictionary<string, Int64> m_namedValues = new OrderedDictionary<string, Int64>();

        public override string Name
        {
            get { return "INTEGER"; }
        }

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

        public OrderedDictionary<string, Child> m_children = new OrderedDictionary<string, Child>();
        public bool m_extMarkPresent = false;
        public ExceptionSpec m_exceptionSpec;
        public bool m_extMarkPresent2 = false;

        public override string Name
        {
            get { return "CHOICE"; }
        }

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

        public OrderedDictionary<string, Child> m_children = new OrderedDictionary<string, Child>();
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
        public override string Name
        {
            get { return "SEQUENCE"; }
        }
    }

    public partial class SetType : SequenceOrSetType
    {
        public override string Name
        {
            get { return "SET"; }
        }
    }

    public partial class SequenceOfType : Asn1Type
    {
        public string m_xmlVarName;
        public Asn1Type type;
        public override string Name
        {
            get { return "SEQUENCE OF"; }
        }
    }

    public partial class SetOfType : Asn1Type
    {
        public string m_xmlVarName;
        public Asn1Type type;
        public override string Name
        {
            get { return "SET OF"; }
        }
    }

    public partial class OctetStringType : Asn1Type
    {
        public int m_stringType;
        public OctetStringType(int strType)
        {
            m_stringType = strType;
        }
        public override string Name
        {
            get { return "OCTECT STRING"; }
        }
    }

    public partial class ReferenceType : Asn1Type
    {
        public string m_referencedTypeName="";
        public string m_referencedModName = "";

        public Asn1Type Type
        {
            get
            {
                Asn1Type ret = this;

                while (ret is ReferenceType)
                {
                    if (((ReferenceType)ret).m_referencedModName != "")
                        throw new Exception("Type references to external modules are not implemented (yet) ...");
                    if (ret.m_module.m_typeAssigments.ContainsKey(((ReferenceType)ret).m_referencedTypeName))
                        ret = ret.m_module.m_typeAssigments[((ReferenceType)ret).m_referencedTypeName].m_type;
                    else
                    {
                        throw new Exception("Unimplemented feature ...");
                    }
                }
                return ret;
            }
        }
        public override Asn1Type GetFinalType()
        {
            return Type;
        }

        public override string Name
        {
            get {
                if (m_referencedModName == "")
                    return m_referencedTypeName;
                else
                    return m_referencedModName + "." + m_referencedTypeName;
            }
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