using System;
using System.Collections.Generic;
using System.Text;
using Antlr.Runtime.Tree;

namespace tinyAsn1
{

    public partial class Asn1CompilerInvokation
    {
        private static Asn1CompilerInvokation m_instance;


        public static Asn1CompilerInvokation Instance
        {
            get
            {
                if (m_instance == null)
                    m_instance = new Asn1CompilerInvokation();
                return m_instance;
            }
        }
        private Asn1CompilerInvokation() { }
        public List<Asn1File> m_files = new List<Asn1File>();

        public bool isModuleDefined(string modName)
        {
            foreach (Asn1File f in m_files)
                foreach (Module m in f.m_modules)
                    if (m.m_moduleID == modName)
                        return true;
            return false;
        }

        public Module GetModuleByName(string modName)
        {
            foreach (Asn1File f in m_files)
                foreach (Module m in f.m_modules)
                    if (m.m_moduleID == modName)
                        return m;
            throw new SemanticErrorException("Error no module is defined with name: '"+modName+"'");
        }

        public void SemanticParse()
        {
            SemanticParser sp = new SemanticParser(this);
            Visit(sp);

            SemanticParserConstraints spcon = new SemanticParserConstraints(this);
            Visit(spcon);

            foreach (Asn1File f in m_files)
                foreach (Module m in f.m_modules)
                    foreach (TypeAssigment tas in m.m_typeAssigments.Values)
                        tas.m_type.CheckDefaultValues();

            foreach (Asn1File f in m_files)
                foreach (Module m in f.m_modules)
                    foreach (ValueAssigment vs in m.m_valuesAssigments.Values)
                        if (!vs.m_type.isValueAllowed(vs.m_value))
                            Console.Error.WriteLine("Warning: value '" + vs.m_name+ "'defined in line " + vs.m_value.antlrNode.Line +
                                " does not conform to its type constraints");

        }
        public void debug()
        {
            Console.WriteLine("Debugging ...");


            for (int i = 0; i < m_files.Count; i++)
            {
                StreamWriterLevel wr = new StreamWriterLevel(m_files[i].m_fileName + ".txt");
                try
                {
                    PrintASN1 pr = new PrintASN1(wr);
                    m_files[i].Visit(pr);
                }
                finally
                {
                    wr.Flush();
                    wr.Close();
                }
            }
        }
    }

    public partial class Asn1File
    {
        public string m_fileName = "";
        public List<Module> m_modules = new List<Module>();
    }


    public partial class Module
    {

        public partial class ImportedModule
        {
            public Module m_parentModule;          // parent module is the module that contains myself
            public string m_moduleID = "";  // moduleID is the module where the definition of imported types occurs
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
        public Tags m_tags = Tags.EXPLICIT;     // clause 12.2
        public bool m_extensibilityImplied = false;

        public Asn1Value GetValue(string valueName)
        {
            if (!isValueDeclared(valueName))
                throw new Exception("Internal Error: variable '"+valueName+"' is not declared");
            if (m_valuesAssigments.ContainsKey(valueName))
                return m_valuesAssigments[valueName].m_value;
            foreach (Module.ImportedModule im in m_imports)
            {
                if (im.m_importedVariables.Contains(valueName))
                {
                    Module otherModule = Asn1CompilerInvokation.Instance.GetModuleByName(im.m_moduleID);
                    return otherModule.GetValue(valueName);
                }
            }

            throw new Exception("Internal error: ");
        }

        //public ValueAssigment GetValueAssigment(string valueAssigId)
        //{
        //    if (!isValueDeclared(valueAssigId))
        //        throw new Exception("Internal Error: variable assigment '" + valueAssigId + "' is not declared");
        //    if (m_valuesAssigments.ContainsKey(valueAssigId))
        //        return m_valuesAssigments[valueAssigId];

        //    throw new Exception("Internal error: Imports/Exports are not implemented yet!");
        //}

        public bool isValueDeclared(string valueName)
        {
            if (m_valuesAssigments.ContainsKey(valueName))
                return true;
            foreach (ImportedModule im in m_imports)
                if (im.m_importedVariables.Contains(valueName))
                    return true;

            return false;
        }
        
        public bool isValueDeclaredAsExported(string valueName)
        {
            if (!isValueDeclared(valueName))
                return false;
            if (m_exportedVariables.Contains(valueName))
                return true;
            return false;
        }

        public bool isTypeDeclared(string typeName)
        {
            if (m_typeAssigments.ContainsKey(typeName))
                return true;
            foreach (ImportedModule im in m_imports)
                if (im.m_importedTypes.Contains(typeName))
                    return true;

            return false;

        }
        
        public bool isTypeDeclaredAsExported(string typeName)
        {
            if (!isTypeDeclared(typeName))
                return false;
            if (m_exportedTypes.Contains(typeName))
                return true;
            return false;

        }

        // it return the type 
        public Asn1Type GetTypeByName(string typeName)
        {
            if (m_typeAssigments.ContainsKey(typeName))
                return m_typeAssigments[typeName].m_type;

            foreach (ImportedModule im in m_imports)
                if (im.m_importedTypes.Contains(typeName))
                {
                    Module otherMode = Asn1CompilerInvokation.Instance.GetModuleByName(im.m_moduleID);
                    return otherMode.GetTypeByName(typeName);
                }
            throw new SemanticErrorException("Error: '" + typeName+"' is undefined");
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
        public List<string> m_comments = new List<string>();
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
//        public List<Constraint> m_constraints = new List<Constraint>();
        
        public List<ITree> m_AntlrConstraints = new List<ITree>();

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

    public partial class ObjectIdentifier : Asn1Type
    {
        
        public override string Name
        {
            get { return "OBJECT IDENTIFIER"; }
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

    public partial class ArrayType : Asn1Type
    {
        public string m_xmlVarName;
        public Asn1Type m_type;
    }

    public partial class SequenceOfType : ArrayType
    {
        public override string Name
        {
            get { return "SEQUENCE OF"; }
        }
    }

    public partial class SetOfType : ArrayType
    {
        public override string Name
        {
            get { return "SET OF"; }
        }
    }

    public partial class OctetStringType : Asn1Type
    {
        public override string Name
        {
            get { return "OCTECT STRING"; }
        }
    }

    public partial class IA5StringType : Asn1Type
    {
        public override string Name
        {
            get { return "IA5String"; }
        }
    }

    public partial class NumericStringType : IA5StringType
    {
        public override string Name
        {
            get { return "NumericString"; }
        }
    }

    public partial class ReferenceType : Asn1Type
    {
        public string m_referencedTypeName="";
        public string m_referencedModName = "";

    }



    public class SemanticErrorException : Exception
    {
        public SemanticErrorException(string ErrMsg)
            : base(ErrMsg)
        {
        }

    }


}