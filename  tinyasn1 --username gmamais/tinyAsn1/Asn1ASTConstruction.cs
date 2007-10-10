using System;
using System.Collections.Generic;
using System.Text;
using Antlr.Runtime.Tree;

namespace tinyAsn1
{
    public class TreeVisitor
    {
        public delegate void OnTreeElementVisit(ITree curNode);

        public event OnTreeElementVisit ElementVisited;

        public void Visit(ITree root)
        {
            if (ElementVisited != null)
                ElementVisited(root);
            for (int i = 0; i < root.ChildCount; i++)
            {
                Visit(root.GetChild(i));
            }

        }
    }


    public partial class Asn1File
    {
        ITree tree;

        //^(ASN1_FILE moduleDefinition*)
        static public Asn1File CreateFromAntlrAst(ITree tree)
        {
            if (tree.Type != asn1Parser.ASN1_FILE)
                throw new Exception("ASN1_FILE");

            Asn1File ret = new Asn1File();
            ret.tree = tree;

            for (int i = 0; i < tree.ChildCount; i++)
                ret.m_modules.Add(Module.CreateFromAntlrAst(tree.GetChild(i)));

            return ret;
        }
    }

    partial class Module
    {
        ITree tree;
        public partial class ImportedModule
        {
            ITree tree;
            //^(IMPORTS_FROM_MODULE modulereference typereference* valuereference*  )
            static public ImportedModule CreateFromAntlrAst(ITree tree)
            {
                ImportedModule ret = new ImportedModule();
                ret.tree = tree;

                ret.m_moduleID = tree.GetChild(0).Text;

                for (int i = 1; i < tree.ChildCount; i++)
                {
                    ITree child = tree.GetChild(i);

                    switch (child.Type)
                    {
                        case asn1Parser.UID:
                            if (ret.m_importedTypes.Contains(child.Text))
                                throw new SemanticErrorException(child.Text + " has alrady been imported. Line: "+child.Line);
                            ret.m_importedTypes.Add(child.Text);
                            break;
                        case asn1Parser.LID:
                            if (ret.m_importedVariables.Contains(child.Text))
                                throw new SemanticErrorException(child.Text + " has alrady been imported. Line: " + child.Line);
                            ret.m_importedVariables.Add(child.Text);
                            break;
                        default:
                            throw new Exception("Unkown child: " + child.Text + " for node: " + tree.Text);
                    }
                }


                return ret;
            }
        }

        internal static Module CurrentlyConstructModule = null;
        //^(MODULE_DEF modulereference moduleTag? EXTENSIBILITY? exports? imports? typeAssigment* valueAssigment* valueSetAssigment*)
        internal bool bExportAll=false;
        static public Module CreateFromAntlrAst(ITree tree)
        {

            Module curModule;

            if (tree.Type != asn1Parser.MODULE_DEF)
                throw new Exception("MODULE_DEF");

            curModule = new Module();
            curModule.tree = tree;

            CurrentlyConstructModule = curModule;
            for (int i = 0; i < tree.ChildCount; i++)
            {
                ITree child = tree.GetChild(i);

                switch (child.Type)
                {
                    case asn1Parser.UID:
                        curModule.m_moduleID = child.Text;
                        break;
                    case asn1Parser.EXPLICIT:
                        curModule.m_tags = Tags.EXPLICIT;
                        break;
                    case asn1Parser.IMPLICIT:
                        curModule.m_tags = Tags.IMPLICIT;
                        break;
                    case asn1Parser.AUTOMATIC:
                        curModule.m_tags = Tags.AUTOMATIC;
                        break;
                    case asn1Parser.EXTENSIBILITY:
                        curModule.m_extensibilityImplied = true;
                        break;
                    case asn1Parser.EXPORTS_ALL:
                        curModule.bExportAll = true;
//                        curModule.m_exportStatus = ExportStatus.ALL;
                        break;
                    case asn1Parser.EXPORTS:
                        handleExports(curModule, child);                        
                        break;
                    case asn1Parser.IMPORTS_FROM_MODULE:
                        curModule.m_imports.Add(ImportedModule.CreateFromAntlrAst(child));
                        break;
                    case asn1Parser.TYPE_ASSIG:
                        TypeAssigment typeAssig = TypeAssigment.CreateFromAntlrAst(child);
                        if (curModule.m_typeAssigments.ContainsKey(typeAssig.m_name))
                            throw new SemanticErrorException(typeAssig.m_name + " has alrady been defined. Line: " + child.Line);
                        curModule.m_typeAssigments.Add(typeAssig.m_name,typeAssig);
                        break;
                    case asn1Parser.VAL_ASSIG:
                        ValueAssigment valAssig = ValueAssigment.CreateFromAntlrAst(child);
                        if (curModule.m_valuesAssigments.ContainsKey(valAssig.m_name) )
                            throw new SemanticErrorException(valAssig.m_name + " has alrady been defined. Line: " + child.Line);
                        curModule.m_valuesAssigments.Add(valAssig.m_name, valAssig);
                        break;
/*                    case asn1Parser.VAL_SET_ASSIG:
                        ValueSetAssigment valSetAssig = ValueSetAssigment.CreateFromAntlrAst(child);
                        if (curModule.m_valueSetsAssigments.ContainsKey(valSetAssig.m_typeReference))
                            throw new SemanticErrorException(valSetAssig.m_typeReference + " has alrady been defined. Line: " + child.Line);
                        curModule.m_valueSetsAssigments.Add(valSetAssig.m_typeReference, valSetAssig);
                        break;*/
                    default:
                        throw new Exception("Unkown child: " + child.Text + " for node: " + tree.Text);
                }

            }
            
//            curModule.fixTree();
            return curModule;
        }
/*
        private void fixTree()
        {
            // fix myself
            if (bExportAll)
            {
                foreach (TypeAssigment typeAss in m_typeAssigments.Values)
                    m_exportedTypes.Add(typeAss.m_name);
                foreach (ValueAssigment valAsig in m_valuesAssigments.Values)
                    m_exportedVariables.Add(valAsig.m_name);
            }
            //fix children
        }

        */


        private static void handleExports(Module curMod, ITree tree)
        {
            for (int i = 0; i < tree.ChildCount; i++)
            {
                ITree child = tree.GetChild(i);

                switch (child.Type)
                {
                    case asn1Parser.UID:
                        curMod.m_exportedTypes.Add(child.Text);
                        break;
                    case asn1Parser.LID:
                        curMod.m_exportedVariables.Add(child.Text);
                        break;
                    default:
                        throw new Exception("Unkown child: " + child.Text + " for node: " + tree.Text);
                }
            }
        }
    }

    public partial class ValueAssigment
    {
        //^(VAL_ASSIG valuereference type value)
        static public ValueAssigment CreateFromAntlrAst(ITree tree)
        {
            ValueAssigment ret = new ValueAssigment();
            ret.m_name = tree.GetChild(0).Text;
            ret.m_type = Asn1Type.CreateFromAntlrAst(tree.GetChild(1));
            ret.m_value = Asn1Value.CreateFromAntlrAst(tree.GetChild(2));
            return ret;
        } 
    }

    public partial class TypeAssigment
    {
        //^(TYPE_ASSIG typereference type)
        static public TypeAssigment CreateFromAntlrAst(ITree tree)
        {

            TypeAssigment ret = new TypeAssigment();
            ret.m_name = tree.GetChild(0).Text;
            ret.m_type = Asn1Type.CreateFromAntlrAst(tree.GetChild(1));
            return ret;
        }

    }

/*
    public partial class ValueSetAssigment
    {
        static public ValueSetAssigment CreateFromAntlrAst(ITree tree)
        {
            ValueSetAssigment ret = new ValueSetAssigment();
            ret.m_typeReference = tree.GetChild(0).Text;
            ret.m_type = Asn1Type.CreateFromAntlrAst(tree.GetChild(1));
            ret.m_constr_body = SetOfValues.CreateFromAntlrAst(tree.GetChild(2));
            return ret;
        }

    }
*/

    public partial class Asn1Type
    {
        public partial class Tag
        {
            //(TYPE_TAG (UNIVERSAL | APPLICATION | PRIVATE)? INT ( IMPLICIT | EXPLICIT)?)
            static public Tag CreateFromAntlrAst(ITree tree)
            {
                Tag ret = new Tag();
                for(int i=0; i<tree.ChildCount;i++)
                {
                    ITree child = tree.GetChild(i);
                    switch (child.Type)
                    {
                        case asn1Parser.INT:
                            ret.m_tag = int.Parse(child.Text);
                            break;
                        case asn1Parser.UNIVERSAL:
                            ret.m_class = TagClass.UNIVERSAL;
                            break;
                        case asn1Parser.APPLICATION:
                            ret.m_class = TagClass.APPLICATION;
                            break;
                        case asn1Parser.PRIVATE:
                            ret.m_class = TagClass.PRIVATE;
                            break;
                        case asn1Parser.IMPLICIT:
                            ret.ImpOrExpl = Module.Tags.IMPLICIT;
                            break;
                        case asn1Parser.EXPLICIT:
                            ret.ImpOrExpl = Module.Tags.EXPLICIT;
                            break;
                        default:
                            throw new Exception("Unkown child: "+child.Text+" for node: "+tree.Text);
                    }
                }
                return ret;
            }
        }

        static public Asn1Type CreateFromAntlrAst(ITree tree)
        {
            Asn1Type ret=null;
            Tag tag=null;
            for (int i = 0; i < tree.ChildCount; i++)
            {
                    ITree child = tree.GetChild(i);
                    switch (child.Type)
                    {
                        case asn1Parser.TYPE_TAG:
                            tag = Tag.CreateFromAntlrAst(child);
                            break;
                        case asn1Parser.NULL:
                            ret = new NullType();
                            break;
                        case asn1Parser.BIT_STRING_TYPE:
                            ret = BitStringType.CreateFromAntlrAst(child);
                            break;
                        case asn1Parser.BOOLEAN:
                            ret = new BooleanType();
                            break;
                        case asn1Parser.ENUMERATED_TYPE:
                            ret = EnumeratedType.CreateFromAntlrAst(child);
                            break;
                        case asn1Parser.INTEGER_TYPE:
                            ret = IntegerType.CreateFromAntlrAst(child);
                            break;
                        case asn1Parser.REAL:
                            ret = new RealType();
                            break;
                        case asn1Parser.CHOICE_TYPE:
                            ret = ChoiceType.CreateFromAntlrAst(child);
                            break;
                        case asn1Parser.SEQUENCE_TYPE:
                            ret = SequenceType.CreateFromAntlrAst(child);
                            break;
                        case asn1Parser.SET_TYPE:
                            ret = SetType.CreateFromAntlrAst(child);
                            break;
                        case asn1Parser.SEQUENCE_OF_TYPE:
                            ret = SequenceOfType.CreateFromAntlrAst(child);
                            break;
                        case asn1Parser.SET_OF_TYPE:
                            ret = SetOfType.CreateFromAntlrAst(child);
                            break;
                        case asn1Parser.REFERENCED_TYPE:
                            ret = ReferenceType.CreateFromAntlrAst(child);
                            break;
                        case asn1Parser.OBJECT_TYPE:
                            break;
                        case asn1Parser.RELATIVE_OID:
                            break;
                        case asn1Parser.OCTECT_STING:
                        case asn1Parser.NumericString:
                        case asn1Parser.PrintableString:
                        case asn1Parser.VisibleString:
                        case asn1Parser.IA5String:
                        case asn1Parser.TeletexString:
                        case asn1Parser.VideotexString:
                        case asn1Parser.GraphicString:
                        case asn1Parser.GeneralString:
                        case asn1Parser.UniversalString:
                        case asn1Parser.BMPString:
                        case asn1Parser.UTF8String:
                            ret = new OctetStringType(child.Type);
                            break;
                        case asn1Parser.SIMPLIFIED_SIZE_CONSTRAINT:
                            if (ret != null)
                                ret.m_constraints.Add(Constraint.CreateConstraintFromSizeConstraint(child));
                            break;
                        case asn1Parser.CONSTRAINT:
                            if (ret != null)
                                ret.m_constraints.Add(Constraint.CreateFromAntlrAst(child));
                            break;
                        default:
                            throw new Exception("Unkown child: " + child.Text + " for node: " + tree.Text);

                    }
            }
            if (ret != null)
            {
                ret.m_tag = tag;
                ret.m_module = Module.CurrentlyConstructModule;
                ret.antlrNode = tree;
            }
            return ret;
        }
        internal virtual Asn1Value FixVariable(Asn1Value val)
        {
            throw new Exception("Internal Error: abstract function call");
        }

        internal virtual bool NeedMorePasses()
        {
            return false;
        }

        /*
         * Returns TRUE if SemanticCheck has finished
         *         FALSE if SemanticCheck must be also called in a next round
         */
        internal virtual bool SemanticCheckFinished()
        {
            return true;
        }
    }

    public partial class NumberedItem
    {
        // ^(NUMBER_LST_ITEM identifier INT? valuereference?)
        //|^(NUMBER_LST_ITEM identifier signedNumber? valuereference?)
        static public NumberedItem CreateFromAntlrAst(ITree tree)
        {
            NumberedItem ret = new NumberedItem();
            ret.m_id = tree.GetChild(0).Text;
            for (int i = 1; i < tree.ChildCount; i++)
            {
                ITree child = tree.GetChild(i);
                switch (child.Type)
                {
                    case asn1Parser.INT:
                        ret.m_valueAsInt = int.Parse(child.Text);
                        break;
                    case asn1Parser.NUMERIC_VALUE:
                        ret.m_valueAsInt = Asn1Value.GetValFrom_NUMERIC_VALUE_asInt(child);
                        break;
                    case asn1Parser.LID:
                        ret.m_valueAsReference = child.Text;
                        break;
                    default:
                        throw new Exception("Unkown child: " + child.Text + " for node: " + tree.Text);
                }
            }

            return ret;
        }
    }

    public partial class NullType : Asn1Type
    {
        internal override Asn1Value FixVariable(Asn1Value val)
        {
            string referenceId = "";
            switch (val.antlrNode.Type)
            {
                case asn1Parser.NULL:
                    return new NullValue();
                case asn1Parser.VALUE_REFERENCE:
                    referenceId = val.antlrNode.GetChild(0).Text;
                    if (m_module.isValueDeclared(referenceId))
                    {
                        Asn1Value tmp = m_module.GetValue(referenceId);
                        switch (tmp.m_TypeID)
                        {
                            case Asn1Value.TypeID.NULL:
                                return new NullValue();
                            case Asn1Value.TypeID.UNDEFINED:
                                // not yet resolved, wait for next round
                                return val;
                            default:
                                throw new SemanticErrorException("Error in line : " + val.antlrNode.Line + ". Incompatible variable assigment");
                        }
                    }
                    else
                        throw new SemanticErrorException("Error in line : " + val.antlrNode.Line + ". Identifier '" + referenceId + "' is unknown");

                default:
                    throw new SemanticErrorException("Error in line : " + val.antlrNode.Line + ". Expecting BIT STRING constant or BIT STRING variable");
            }
        }
    }

    public partial class BooleanType : Asn1Type
    {
        internal override Asn1Value FixVariable(Asn1Value val)
        {
            string referenceId = "";
            switch (val.antlrNode.Type)
            {
                case asn1Parser.TRUE:
                case asn1Parser.FALSE:
                    return new BooleanValue(val.antlrNode, m_module, this);
                case asn1Parser.VALUE_REFERENCE:
                    referenceId = val.antlrNode.GetChild(0).Text;
                    if (m_module.isValueDeclared(referenceId))
                    {
                        Asn1Value tmp = m_module.GetValue(referenceId);
                        switch (tmp.m_TypeID)
                        {
                            case Asn1Value.TypeID.BOOLEAN:
                                return new BooleanValue(tmp as BooleanValue);
                            case Asn1Value.TypeID.UNDEFINED:
                                // not yet resolved, wait for next round
                                return val;
                            default:
                                throw new SemanticErrorException("Error in line : " + val.antlrNode.Line + ". Incompatible variable assigment");
                        }
                    }
                    else
                        throw new SemanticErrorException("Error in line : " + val.antlrNode.Line + ". Identifier '" + referenceId + "' is unknown");

                default:
                    throw new SemanticErrorException("Error in line : " + val.antlrNode.Line + ". Expecting BIT STRING constant or BIT STRING variable");
            }
        }

    }

    public partial class BitStringType : Asn1Type
    {
        static public new BitStringType CreateFromAntlrAst(ITree tree)
        {
            BitStringType ret = new BitStringType();
            for (int i = 0; i < tree.ChildCount; i++)
            {
                ITree child = tree.GetChild(i);
                NumberedItem item = NumberedItem.CreateFromAntlrAst(child);
//                if (ret.m_namedBitsPriv.ContainsKey(item.m_id))
//                    throw new SemanticErrorException(item.m_id + " has alrady been defined. Line: " + child.Line);
                    
                ret.m_namedBitsPriv.Add(item);
            }


            return ret;
        }
        internal override bool NeedMorePasses()
        {
            return this.m_namedBitsPriv.Count>0;
        }


        internal override bool SemanticCheckFinished()
        {
            List<NumberedItem> toBeRemoved = new List<NumberedItem>();
            foreach (NumberedItem ni in m_namedBitsPriv)
            {
                if (m_namedBits.ContainsKey(ni.m_id))
                    throw new SemanticErrorException("The BIT STRING type defined in line " + antlrNode.Line +
                        " containts more than once the identifier " + ni.m_id);

                if (ni.m_valueAsInt != null)
                {
                    if (ni.m_valueAsInt.Value < 0)
                        throw new SemanticErrorException("Error in line : " + antlrNode.Line + ". Bit string ids must be no negative numbers");
                    m_namedBits.Add(ni.m_id, ni.m_valueAsInt.Value);
                    toBeRemoved.Add(ni);
                }
                else
                {
                    //We have to look up in the variables definitions
                    string refName = ni.m_valueAsReference;
                    if (m_module.isValueDeclared(refName))
                    {
                        Asn1Value tmpVal = m_module.GetValue(refName);
                        if (tmpVal.m_TypeID == Asn1Value.TypeID.UNDEFINED)
                            continue;
                        if (tmpVal.m_TypeID == Asn1Value.TypeID.INT)
                        {
                            Int64 val = ((IntegerValue)tmpVal).Value;
                            if (val < 0)
                                throw new SemanticErrorException("Error in line : " + antlrNode.Line + ". Identifier '" + refName + "' is a negative integer");
                            m_namedBits.Add(ni.m_id, val);
                            toBeRemoved.Add(ni);
                        }
                        else
                        {
                            throw new SemanticErrorException("Error in line : " + antlrNode.Line + ". Identifier '" + refName + "' is not an integer");
                        }
                        //else let it be resolved in a next parse round
                    }
                    else
                        throw new SemanticErrorException("Error in line : " + antlrNode.Line + ". Identifier '" + refName + "' is unknown");
                }

            }
            foreach (NumberedItem ni in toBeRemoved)
                m_namedBitsPriv.Remove(ni);
            if (m_namedBitsPriv.Count > 0)
                return false;
            
            return true;
        }


        internal override Asn1Value FixVariable(Asn1Value val)
        {
            string referenceId = "";
            switch (val.antlrNode.Type)
            {
                case asn1Parser.BitStringLiteral:
                case asn1Parser.OctectStringLiteral:
                    return new BitStringValue(val.antlrNode, m_module, this);
                case asn1Parser.BIT_STRING_VALUE: // { id, id2, id3}
                    {
                        if (NeedMorePasses())
                            return val;
                        List<Int64> ids = new List<Int64>();
                        for (int i = 0; i < val.antlrNode.ChildCount; i++)
                        {
                            string id = val.antlrNode.GetChild(i).Text;
                            if (!m_namedBits.ContainsKey(id))
                                throw new SemanticErrorException("Error in line: "+val.antlrNode.Line+". Unknown identifier '"+id+",");
                            ids.Add(m_namedBits[id]);
                        }
                        return new BitStringValue(ids, val.antlrNode, m_module, this);
                    }
                case asn1Parser.VALUE_REFERENCE:
                    referenceId = val.antlrNode.GetChild(0).Text;
                    if (m_module.isValueDeclared(referenceId))
                    {
                        Asn1Value tmp = m_module.GetValue(referenceId);
                        switch (tmp.m_TypeID)
                        {
                            case Asn1Value.TypeID.BIT_STRING:
                                return new BitStringValue(tmp as BitStringValue);
                            case Asn1Value.TypeID.UNDEFINED:
                                // not yet resolved, wait for next round
                                return val;
                            default:
                                throw new SemanticErrorException("Error in line : " + val.antlrNode.Line + ". Incompatible variable assigment");
                        }
                    }
                    else
                        throw new SemanticErrorException("Error in line : " + val.antlrNode.Line + ". Identifier '" + referenceId + "' is unknown");

                default:
                    throw new SemanticErrorException("Error in line : " + val.antlrNode.Line + ". Expecting BIT STRING constant or BIT STRING variable");
            }
        }
    }

    public partial class OctetStringType : Asn1Type
    {
        internal override Asn1Value FixVariable(Asn1Value val)
        {
            string referenceId = "";
            switch (val.antlrNode.Type)
            {
                case asn1Parser.BitStringLiteral:
                case asn1Parser.OctectStringLiteral:
                    return new OctectStringValue(val.antlrNode, m_module, this);
                case asn1Parser.VALUE_REFERENCE:
                    referenceId = val.antlrNode.GetChild(0).Text;
                    if (m_module.isValueDeclared(referenceId))
                    {
                        Asn1Value tmp = m_module.GetValue(referenceId);
                        switch (tmp.m_TypeID)
                        {
                            case Asn1Value.TypeID.OCTECT_STRING:
                                return new OctectStringValue(tmp as OctectStringValue);
                            case Asn1Value.TypeID.UNDEFINED:
                                // not yet resolved, wait for next round
                                return val;
                            default:
                                throw new SemanticErrorException("Error in line : " + val.antlrNode.Line + ". Incompatible variable assigment");
                        }
                    }
                    else
                        throw new SemanticErrorException("Error in line : " + val.antlrNode.Line + ". Identifier '" + referenceId + "' is unknown");

                default:
                    throw new SemanticErrorException("Error in line : " + val.antlrNode.Line + ". Expecting BIT STRING constant or BIT STRING variable");
            }
        }

    }


    public partial class RealType : Asn1Type
    {

        internal override Asn1Value FixVariable(Asn1Value val)
        {
            string referenceId = "";
            switch (val.antlrNode.Type)
            {
                case asn1Parser.NUMERIC_VALUE:
                    return new RealValue(val.antlrNode, m_module, this);
                case asn1Parser.VALUE_REFERENCE:
                    referenceId = val.antlrNode.GetChild(0).Text;
                    if (m_module.isValueDeclared(referenceId))
                    {
                        Asn1Value tmp = m_module.GetValue(referenceId);
                        switch (tmp.m_TypeID)
                        {
                            case Asn1Value.TypeID.REAL:
                                return new RealValue(tmp as RealValue);
                            case Asn1Value.TypeID.UNDEFINED:
                                // not yet resolved, wait for next round
                                return val;
                            default:
                                throw new SemanticErrorException("Error in line : " + val.antlrNode.Line + ". Incompatible variable assigment");
                        }
                    }
                    else
                        throw new SemanticErrorException("Error in line : " + val.antlrNode.Line + ". Identifier '" + referenceId + "' is unknown");

                default:
                    throw new SemanticErrorException("Error in line : " + val.antlrNode.Line + ". Expecting REAL or REAL variable");
            }
        }
            

    }

    public partial class EnumeratedType : Asn1Type
    {
        //^(ENUMERATED_TYPE enumeratedTypeItems ('...' exceptionSpec? enumeratedTypeItems?) ?)
        static public new EnumeratedType CreateFromAntlrAst(ITree tree)
        {
            EnumeratedType ret = new EnumeratedType();
            for (int i = 0; i < tree.ChildCount; i++)
            {
                ITree child = tree.GetChild(i);
                switch (child.Type)
                {
                    case asn1Parser.NUMBER_LST_ITEM:
                        NumberedItem item = NumberedItem.CreateFromAntlrAst(child);
                        if (ret.m_extMarkPresent)
                            item.m_extended = true;
                        //if (ret.m_enumValuesPriv.ContainsKey(item.m_id))
                        //    throw new SemanticErrorException(item.m_id + " has alrady been defined. Line: " + child.Line);
                        ret.m_enumValuesPriv.Add(item);
                        break;
                    case asn1Parser.EXT_MARK:
                        ret.m_extMarkPresent = true;
                        break;
                    case asn1Parser.EXCEPTION_SPEC:
                        ret.m_exceptionSpec = ExceptionSpec.CreateFromAntlrAst(child);
                        break;
                    default:
                        throw new Exception("Unkown child: " + child.Text + " for node: " + tree.Text);

                }
            }
            
            return ret;
        }

        bool isIdentifierDeclared(string id)
        {
            foreach (NumberedItem ni in m_enumValuesPriv)
                if (ni.m_id == id)
                    return true;

            return isIdentifierProcessed(id);
        }

        bool isIdentifierProcessed(string id)
        {
            return m_enumValues.ContainsKey(id);
        }

        internal override Asn1Value FixVariable(Asn1Value val)
        {
            string referenceId;
            switch (val.antlrNode.Type)
            {
                case asn1Parser.VALUE_REFERENCE:
                    referenceId = val.antlrNode.GetChild(0).Text;
                    if (this.isIdentifierDeclared(referenceId))
                    {
                        if (this.isIdentifierProcessed(referenceId))
                        {
                            if (m_enumValues[referenceId].m_valCalculated)
                                return new EnumeratedValue(m_enumValues[referenceId].m_value, referenceId,
                                    val.antlrNode, m_module, this);
                            else
                                return val; //leave for a next pass where value will have been calculated
                        } 
                        else
                            return val;// leave for a next pass where (hopefully) it will have been resolved
                    }
                    else if (m_module.isValueDeclared(referenceId)) 
                    {
                        Asn1Value tmp = m_module.GetValue(referenceId);
                        if (tmp.m_TypeID == Asn1Value.TypeID.UNDEFINED)
                            return val; // not yet resolved. Wait for next round
                        if (tmp.Type.GetFinalType() == this)
                        {
                            return new EnumeratedValue(tmp as EnumeratedValue);

                        } else
                            throw new SemanticErrorException("Error in line : " + val.antlrNode.Line + ". Identifier '" + referenceId + "' is unknown");
                    }
                    else
                        throw new SemanticErrorException("Error in line : " + val.antlrNode.Line + ". Identifier '" + referenceId + "' is unknown");
                default:
                    throw new SemanticErrorException("Error in line : " + val.antlrNode.Line + ". Expecting enumerated item or enumerated item variable");
            }
        }

        private bool IsValueDefined(Int64 val)
        {
            foreach (Item i in m_enumValues.Values)
                if (i.m_value == val)
                    return true;
            return false;
        }

        internal void FixNumbers()
        {
            int proposedVal = 0;
            foreach (Item i in m_enumValues.Values)
            {
                if (i.m_valCalculated)
                    continue;
                
                while (IsValueDefined(proposedVal))
                    proposedVal++;

                i.m_value = proposedVal;
                i.m_valCalculated = true;
                
            }

            
        }

        internal override bool SemanticCheckFinished()
        {
            List<NumberedItem> toBeRemoved = new List<NumberedItem>();
            foreach (NumberedItem ni in m_enumValuesPriv)
            {
                if (m_enumValues.ContainsKey(ni.m_id))
                    throw new SemanticErrorException("The ENUMERATED type defined in line " + antlrNode.Line +
                        " containts more than once the identifier " + ni.m_id);
                if (ni.m_valueAsInt != null)
                {
                    m_enumValues.Add(ni.m_id, new EnumeratedType.Item(ni.m_id, ni.m_valueAsInt.Value, ni.m_extended));
                    toBeRemoved.Add(ni);
                }
                else if (ni.m_valueAsReference == "")
                {
                    m_enumValues.Add(ni.m_id, new EnumeratedType.Item(ni.m_id, ni.m_extended));
                    toBeRemoved.Add(ni);
                }
                else
                {
                    //We have to look up in the variables definitions
                    string refName = ni.m_valueAsReference;
                    if (m_module.isValueDeclared(refName))
                    {
                        Asn1Value tmpVal = m_module.GetValue(refName);
                        if (tmpVal.m_TypeID == Asn1Value.TypeID.UNDEFINED)
                            continue;
                        if (tmpVal.m_TypeID == Asn1Value.TypeID.INT)
                        {
                            m_enumValues.Add(ni.m_id, new EnumeratedType.Item(ni.m_id, ((IntegerValue)tmpVal).Value, ni.m_extended));
                            toBeRemoved.Add(ni);
                        }
                        else
                        {
                            throw new SemanticErrorException("Error in line : " + antlrNode.Line + ". Incompatible types assigment");
                        }
                        //else let it be resolved in a next parse round
                    }
                    else
                        throw new SemanticErrorException("Error in line : " + antlrNode.Line + ". Identifier '" + refName + "' is unknown");
                }

            }

            foreach (NumberedItem ni in toBeRemoved)
                m_enumValuesPriv.Remove(ni);
            if (m_enumValuesPriv.Count > 0)
                return false;
            else
            {
                FixNumbers();
                return true;
            }

        }
    }

    public partial class IntegerType : Asn1Type
    {
        static public new IntegerType CreateFromAntlrAst(ITree tree)
        {
            IntegerType ret = new IntegerType();
            for (int i = 0; i < tree.ChildCount; i++)
            {
                ITree child = tree.GetChild(i);
                NumberedItem item = NumberedItem.CreateFromAntlrAst(child);
                ret.m_privNamedValues.Add(item);
            }

            return ret;
            
        }

        bool isIdentifierDeclared(string id)
        {
            foreach (NumberedItem ni in m_privNamedValues)
                if (ni.m_id == id)
                    return true;

            return isIdentifierProcessed(id);
        }

        bool isIdentifierProcessed(string id)
        {
            return m_namedValues.ContainsKey(id);
        }



        internal override Asn1Value FixVariable(Asn1Value val)
        {
            if (m_module == null)
                throw new Exception("Bug m_module is null");
            string referenceId="";
            switch (val.antlrNode.Type)
            {
                case asn1Parser.NUMERIC_VALUE:
                case asn1Parser.MIN:
                case asn1Parser.MAX:
                    return new IntegerValue(val.antlrNode, m_module, this);
                case asn1Parser.VALUE_REFERENCE:
                    referenceId = val.antlrNode.GetChild(0).Text;
                    if (m_module.isValueDeclared(referenceId))
                    {
                        Asn1Value tmp = m_module.GetValue(referenceId);
                        switch (tmp.m_TypeID)
                        {
                            case Asn1Value.TypeID.INT:
                                return new IntegerValue(tmp as IntegerValue);
                            case Asn1Value.TypeID.UNDEFINED:
                                return val;
                            default:
                                throw new SemanticErrorException("Error in line : " + val.antlrNode.Line + ". Incompatible variable assigment");
                        }
                    }
                    else if (this.isIdentifierDeclared(referenceId))
                    {
                        if (this.isIdentifierProcessed(referenceId))
                            return new IntegerValue(m_namedValues[referenceId], m_module, val.antlrNode,this);
                        return val; //else wait for next round
                    } else
                        throw new SemanticErrorException("Error in line : " + val.antlrNode.Line + ". Identifier '" + referenceId + "' is unknown");

                default:
                    throw new SemanticErrorException("Error in line : "+val.antlrNode.Line+". Expecting integer or integer variable");
            }


        }

        internal override bool SemanticCheckFinished()
        {
            List<NumberedItem> toBeRemoved = new List<NumberedItem>();
            foreach (NumberedItem ni in m_privNamedValues)
            {
                if (m_namedValues.ContainsKey(ni.m_id))
                    throw new SemanticErrorException("The INTEGER type defined in line " + antlrNode.Line +
                        " containts more than once the identifier " + ni.m_id);
                if (ni.m_valueAsInt != null)
                {
                    m_namedValues.Add(ni.m_id, ni.m_valueAsInt.Value);
                    toBeRemoved.Add(ni);
                }
                else
                {
                    //We have to look up in the variables definitions
                    string refName = ni.m_valueAsReference;
                    if (m_module.isValueDeclared(refName))
                    {
                        Asn1Value tmpVal = m_module.GetValue(refName);
                        if (tmpVal.m_TypeID == Asn1Value.TypeID.UNDEFINED)
                            continue;
                        if (tmpVal.m_TypeID == Asn1Value.TypeID.INT)
                        {
                            m_namedValues.Add(ni.m_id, ((IntegerValue)tmpVal).Value);
                            toBeRemoved.Add(ni);
                        }
                        else
                        {
                            throw new SemanticErrorException("Error in line : " + antlrNode.Line + ". Incompatible types assigment");
                        }
                        //else let it be resolved in a next parse round
                    }
                    else
                        throw new SemanticErrorException("Error in line : " + antlrNode.Line + ". Identifier '" + refName + "' is unknown");

                }
            }
            foreach (NumberedItem ni in toBeRemoved)
                m_privNamedValues.Remove(ni);
            if (m_privNamedValues.Count > 0)
                return false;
            
            return true;
        }

    }


    public partial class ChoiceType : Asn1Type
    {

        public partial class Child
        {
            //^(CHOICE_ITEM identifier type )
            static public Child CreateFromAntlrAst(ITree tree, int? version, bool extended)
            {
                Child ret = new Child();
                ret.m_version = version;
                ret.m_extended = extended;

                for (int i = 0; i < tree.ChildCount; i++)
                {
                    ITree child = tree.GetChild(i);
                    switch (child.Type)
                    {
                        case asn1Parser.LID:
                            ret.m_childVarName = child.Text;
                            break;
                        case asn1Parser.TYPE_DEF:
                            ret.m_type = Asn1Type.CreateFromAntlrAst(child);
                            break;
                        default:
                            throw new Exception("Unkown child: " + child.Text + " for node: " + tree.Text);
                    }
                }

                return ret;

            }
            internal bool SemanticCheckFinished()
            {
                return m_type.SemanticCheckFinished(); 
            }

        }

        //	^(CHOICE_TYPE choiceItemsList choiceExtensionBody?)
        static public new ChoiceType CreateFromAntlrAst(ITree tree)
        {
            ChoiceType ret = new ChoiceType();
            for (int i = 0; i < tree.ChildCount; i++)
            {
                ITree child = tree.GetChild(i);
                switch (child.Type)
                {
                    case asn1Parser.CHOICE_ITEM:
                        Child ch = Child.CreateFromAntlrAst(child, null, false);
                        if (ret.m_children.ContainsKey(ch.m_childVarName))
                            throw new SemanticErrorException(ch.m_childVarName + " has alrady been defined. Line: " + child.Line);
                        ret.m_children.Add(ch.m_childVarName, ch);
                        break;
                    case asn1Parser.CHOICE_EXT_BODY:
                        handleExtension(ret, child);
                        break;
                    default:
                        throw new Exception("Unkown child: " + child.Text + " for node: " + tree.Text);
                }
            }
            return ret;
        }

        //choiceExtensionBody: ^(CHOICE_EXT_BODY exceptionSpec? choiceListExtension? $extMark2?)
        static void handleExtension(ChoiceType ret, ITree tree)
        {
            ret.m_extMarkPresent = true;
            for (int i = 0; i < tree.ChildCount; i++)
            {
                ITree child = tree.GetChild(i);
                switch (child.Type)
                {
                    case asn1Parser.EXCEPTION_SPEC:
                        ret.m_exceptionSpec = ExceptionSpec.CreateFromAntlrAst(child);
                        break;
                    case asn1Parser.EXT_MARK:
                        ret.m_extMarkPresent2 = true;
                        break;
                    case asn1Parser.CHOICE_ITEM:
                        Child ch = Child.CreateFromAntlrAst(child, null, !ret.m_extMarkPresent2);
                        if (ret.m_children.ContainsKey(ch.m_childVarName))
                            throw new SemanticErrorException(ch.m_childVarName + " has alrady been defined. Line: " + child.Line);
                        ret.m_children.Add(ch.m_childVarName, ch);
                        break;
                    case asn1Parser.CHOICE_EXT_ITEM:
                        handleExtensionItem(ret, child);
                        break;
                    default:
                        throw new Exception("Unkown child: " + child.Text + " for node: " + tree.Text);
                }
            }
        }

        private static void handleExtensionItem(ChoiceType ret, ITree tree)
        {
            int? version=null;
            for (int i = 0; i < tree.ChildCount; i++)
            {
                ITree child = tree.GetChild(i);
                switch (child.Type)
                {
                    case asn1Parser.INT:
                        version = int.Parse(child.Text);
                        break;
                    case asn1Parser.CHOICE_ITEM:
                        Child ch = Child.CreateFromAntlrAst(child, version, true);
                        if (ret.m_children.ContainsKey(ch.m_childVarName))
                            throw new SemanticErrorException(ch.m_childVarName + " has alrady been defined. Line: " + child.Line);
                        ret.m_children.Add(ch.m_childVarName, ch);
                        break;
                    default:
                        throw new Exception("Unkown child: " + child.Text + " for node: " + tree.Text);
                }
            }
        }
        internal override bool SemanticCheckFinished()
        {
            bool bFinished = true;

            foreach (Child ch in m_children.Values)
            {
                if (!ch.SemanticCheckFinished())
                    bFinished = false;
            }
            return bFinished;
        }

    }



    public partial class SequenceOrSetType : Asn1Type
    {
        public partial class Child
        {
            //^(SEQUENCE_ITEM identifier type (OPTIONAL|DEFAULT)? value?)
            static public Child CreateFromAntlrAst(ITree tree, int? version, bool extended)
            {
                Child ret = new Child();
                ret.m_version = version;
                ret.m_extended = extended;

                for (int i = 0; i < tree.ChildCount; i++)
                {
                    ITree child = tree.GetChild(i);
                    switch (child.Type)
                    {
                        case asn1Parser.LID:
                            ret.m_childVarName = child.Text;
                            break;
                        case asn1Parser.TYPE_DEF:
                            ret.m_type = Asn1Type.CreateFromAntlrAst(child);
                            break;
                        case asn1Parser.OPTIONAL:
                            ret.m_optional = true;
                            break;
                        case asn1Parser.DEFAULT:
                            ret.m_default = true;
                            break;
                        case asn1Parser.DEFAULT_VALUE:
                            ret.m_defaultValue = Asn1Value.CreateFromAntlrAst(child.GetChild(0));
                            break;
                        default:
                            throw new Exception("Internal Error, unexpected child: " + child.Text + " for node: " + tree.Text);
                    }
                }

                return ret;
                
            }
            
            internal bool SemanticCheckFinished()
            {
                bool bFinished = m_type.SemanticCheckFinished();
                if (!bFinished)
                    return false;

                if (m_defaultValue != null)
                {
                    if (m_defaultValue.m_TypeID == Asn1Value.TypeID.UNDEFINED)
                    {
                        m_defaultValue = m_type.FixVariable(m_defaultValue);
                        if (m_defaultValue.m_TypeID == Asn1Value.TypeID.UNDEFINED)
                            return false;
                    }

                }

                return true;
            }
        }

        static public SequenceOrSetType CreateFromAntlrAst(SequenceOrSetType ret, ITree tree)
        {
            for (int i = 0; i < tree.ChildCount; i++)
            {
                ITree child = tree.GetChild(i);
                switch (child.Type)
                {
                    case asn1Parser.SEQUENCE_ITEM:
                        Child ch = Child.CreateFromAntlrAst(child, null, false);
                        if (ret.m_children.ContainsKey(ch.m_childVarName))
                            throw new SemanticErrorException(ch.m_childVarName + " has alrady been defined. Line: " + child.Line);
                        ret.m_children.Add(ch.m_childVarName, ch);
                        break;
                    case asn1Parser.SEQUENCE_EXT_BODY:
                        handleExtension(ret, child);
                        break;
                    case asn1Parser.COMPONENTS_OF:
                        throw new SemanticErrorException("COMPONENTS OF are not implemented yet. Sorry ...");
                    default:
                        throw new Exception("Internal Error, unexpected child: " + child.Text + " for node: " + tree.Text);
                }
            }
            
            return ret;
        }

        private static void handleExtension(SequenceOrSetType ret,  ITree tree)
        {
            ret.m_extMarkPresent = true;
            for (int i = 0; i < tree.ChildCount; i++)
            {
                ITree child = tree.GetChild(i);
                switch (child.Type)
                {
                    case asn1Parser.EXCEPTION_SPEC:
                        ret.m_exceptionSpec = ExceptionSpec.CreateFromAntlrAst(child);
                        break;
                    case asn1Parser.EXT_MARK:
                        ret.m_extMarkPresent2 = true;
                        break;
                    case asn1Parser.SEQUENCE_ITEM:
                        Child ch = Child.CreateFromAntlrAst(child, null, !ret.m_extMarkPresent2);
                        if (ret.m_children.ContainsKey(ch.m_childVarName))
                            throw new SemanticErrorException(ch.m_childVarName + " has alrady been defined. Line: " + child.Line);
                        ret.m_children.Add(ch.m_childVarName, ch);
                        break;
                    case asn1Parser.COMPONENTS_OF:
                        throw new SemanticErrorException("COMPONENTS OF are not implemented yet. Sorry ...");
                    case asn1Parser.SEQUENCE_EXT_GROUP:
                        handleVersionGroup(ret, child);
                        break;
                    default:
                        throw new Exception("Internal Error, unexpected child: " + child.Text + " for node: " + tree.Text);
                }
            }

        }

        private static void handleVersionGroup(SequenceOrSetType ret, ITree tree)
        {
            int? version=null;
            for (int i = 0; i < tree.ChildCount; i++)
            {
                ITree child = tree.GetChild(i);
                switch (child.Type)
                {
                    case asn1Parser.INT:
                        version = int.Parse(child.Text);
                        break;
                    case asn1Parser.SEQUENCE_ITEM:
                        Child ch = Child.CreateFromAntlrAst(child, version, true);
                        if (ret.m_children.ContainsKey(ch.m_childVarName))
                            throw new SemanticErrorException(ch.m_childVarName + " has alrady been defined. Line: " + child.Line);
                        ret.m_children.Add(ch.m_childVarName, ch);
                        break;
                    case asn1Parser.COMPONENTS_OF:
                        throw new SemanticErrorException("COMPONENTS OF are not implemented yet. Sorry ...");
                    default:
                        throw new Exception("Internal Error, unexpected child: " + child.Text + " for node: " + tree.Text);
                }
            }
        }


        internal override bool SemanticCheckFinished()
        {
            bool bFinished = true;
            
            foreach (Child ch in m_children.Values)
            {
                if (!ch.SemanticCheckFinished())
                    bFinished = false;
            }
            return bFinished;
        }

    }



    public partial class SequenceType : SequenceOrSetType
    {
        static public new SequenceType CreateFromAntlrAst(ITree tree)
        {
            SequenceType ret = new SequenceType();
            SequenceOrSetType.CreateFromAntlrAst(ret, tree.GetChild(0));
            return ret;
        }
    }

    public partial class SetType : SequenceOrSetType
    {
        static public new SetType CreateFromAntlrAst(ITree tree)
        {
            SetType ret = new SetType();
            SequenceOrSetType.CreateFromAntlrAst(ret, tree.GetChild(0));
            return ret;
        }
    }

    public partial class SequenceOfType : Asn1Type
    {
        //^(SEQUENCE_OF_TYPE (SIMPLIFIED_SIZE_CONSTRAINT $sz)? $gen? identifier? type)
        static public new SequenceOfType CreateFromAntlrAst(ITree tree)
        {

            SequenceOfType ret = new SequenceOfType();
            for (int i = 0; i < tree.ChildCount; i++)
            {
                ITree child = tree.GetChild(i);
                switch (child.Type)
                {
                    case asn1Parser.SIMPLIFIED_SIZE_CONSTRAINT:
                        ret.m_constraints.Add(Constraint.CreateConstraintFromSizeConstraint(child));
                        break;
                    case asn1Parser.CONSTRAINT:
                        ret.m_constraints.Add(Constraint.CreateFromAntlrAst(child));
                        break;
                    case asn1Parser.LID:
                        ret.m_xmlVarName = child.Text;
                        break;
                    case asn1Parser.TYPE_DEF:
                        ret.m_type = Asn1Type.CreateFromAntlrAst(child);
                        break;
                    default:
                        throw new Exception("Unkown child: " + child.Text + " for node: " + tree.Text);
                }
            }

            return ret;
        }
        internal override bool SemanticCheckFinished()
        {
            return m_type.SemanticCheckFinished();   
        }
    }

    public partial class SetOfType : Asn1Type
    {
        static public new SetOfType CreateFromAntlrAst(ITree tree)
        {
            SetOfType ret = new SetOfType();
            for (int i = 0; i < tree.ChildCount; i++)
            {
                ITree child = tree.GetChild(i);
                switch (child.Type)
                {
                    case asn1Parser.SIMPLIFIED_SIZE_CONSTRAINT:
                        ret.m_constraints.Add(Constraint.CreateConstraintFromSizeConstraint(child));
                        break;
                    case asn1Parser.CONSTRAINT:
                        ret.m_constraints.Add(Constraint.CreateFromAntlrAst(child));
                        break;
                    case asn1Parser.LID:
                        ret.m_xmlVarName = child.Text;
                        break;
                    case asn1Parser.TYPE_DEF:
                        ret.m_type = Asn1Type.CreateFromAntlrAst(child);
                        break;
                    default:
                        throw new Exception("Unkown child: " + child.Text + " for node: " + tree.Text);
                }
            }

            return ret;
        }
        internal override bool SemanticCheckFinished()
        {
            return m_type.SemanticCheckFinished();
        }
    }

    public partial class ReferenceType : Asn1Type
    {
        static public new ReferenceType CreateFromAntlrAst(ITree tree)
        {
            ReferenceType ret = new ReferenceType();
            if (tree.ChildCount == 1)
                ret.m_referencedTypeName = tree.GetChild(0).Text;
            else if (tree.ChildCount == 2)
            {
                ret.m_referencedModName = tree.GetChild(0).Text;
                ret.m_referencedTypeName = tree.GetChild(1).Text;
            }
            else
                throw new Exception("Incorrect parse tree!");
            return ret;
        }

        internal override Asn1Value FixVariable(Asn1Value val)
        {
            return Type.FixVariable(val);
        }

    }


    public partial class Asn1Value
    {
        
        //^(NUMERIC_VALUE $intPart $s? $decPart?)
        public static Int64 GetValFrom_NUMERIC_VALUE_asInt(ITree tree)
        {
            Int64 ret = Int64.Parse(tree.GetChild(0).Text);
            if (tree.ChildCount > 1 && tree.GetChild(1).Text == "-")
                ret = -ret;
            return ret;
        }

        static public Asn1Value CreateFromAntlrAst(ITree tree)
        {

            Asn1Value ret = new Asn1Value();
            ret.antlrNode = tree;
            // Asn1Value will be modified in a second tree pass
            return ret;
        }
    }




    public partial class ExceptionSpec
    {
        static public ExceptionSpec CreateFromAntlrAst(ITree tree)
        {
            Console.Error.WriteLine("Unimplemented feature ASN.1 Exception are parsed but ignored");
            return new ExceptionSpec();
        }
    }

    public partial class Constraint
    {
        static public Constraint CreateFromAntlrAst(ITree tree)
        {
            if (tree.Type != asn1Parser.CONSTRAINT)
                throw new Exception(tree.Text + " is not a constraint");
            Constraint ret = new Constraint();
            for (int i = 0; i < tree.ChildCount; i++)
            {
                ITree child = tree.GetChild(i);
                switch (child.Type)
                {
                    case asn1Parser.SET_OF_VALUES:
                        ret.m_values = SetOfValues.CreateFromAntlrAst(child);
                        break;
                    case asn1Parser.EXCEPTION_SPEC:
                        ret.m_exception = ExceptionSpec.CreateFromAntlrAst(child);
                        break;
                    default:
                        throw new Exception("Unkown child: " + child.Text + " for node: " + tree.Text);
                }
            }

            return ret;
        }

        static public void HandleBody(Constraint ret, ITree tree)
        {
        }

        static public Constraint CreateConstraintFromSizeConstraint(ITree tree)
        {


            Constraint ret = new Constraint();
            ret.m_values = new SetOfValues();
            UnionElementOfIntersectionItems un = new UnionElementOfIntersectionItems();
            ret.m_values.m_set1.Add(un);
            IntersectionElement ir = new IntersectionElement();
            un.m_intersectionElements.Add(ir);
            SizeExpression sz = new SizeExpression();
            ir.m_exp = sz;
            sz.m_sizeConstraint = Constraint.CreateFromAntlrAst(tree.GetChild(0));

            return ret;
        }
    }


    public partial class UnionElementOfIntersectionItems : UnionElement
    {
        static public UnionElementOfIntersectionItems CreateFromAntlrAst(ITree tree)
        {
            UnionElementOfIntersectionItems ret = new UnionElementOfIntersectionItems();
            for (int i = 0; i < tree.ChildCount; i++)
            {
                ITree child = tree.GetChild(i);
                switch (child.Type)
                {
                    case asn1Parser.INTERSECTION_ELEMENT:
                        ret.m_intersectionElements.Add(IntersectionElement.CreateFromAntlrAst(child));
                        break;
                    default:
                        throw new Exception("Unkown child: " + child.Text + " for node: " + tree.Text);
                }
            }
            return ret;
        }
    }

    public partial class UnionElementExceptOf : UnionElement
    {
        static public UnionElementExceptOf CreateFromAntlrAst(ITree tree)
        {
            UnionElementExceptOf ret = new UnionElementExceptOf();
            ret.m_exceptOfThis = ConstraintExpression.CreateFromAntlrAst(tree.GetChild(0));
            return ret;
        }
    }

    public partial class IntersectionElement
    {
        static public IntersectionElement CreateFromAntlrAst(ITree tree)
        {
            IntersectionElement ret = new IntersectionElement();

            ret.m_exp = ConstraintExpression.CreateFromAntlrAst(tree.GetChild(0));
            if (tree.ChildCount>1)
                ret.m_except_exp = ConstraintExpression.CreateFromAntlrAst(tree.GetChild(1));

            return ret;
        }
    }

    public partial class ConstraintExpression
    {
        static public ConstraintExpression CreateFromAntlrAst(ITree tree)
        {
            ConstraintExpression ret = null;

            switch (tree.Type)
            {
                case asn1Parser.VALUE_RANGE_EXPR:
                    ret = ValueRangeExpression.CreateFromAntlrAst(tree);
                    break;
                case asn1Parser.SIZE_EXPR:
                    ret = SizeExpression.CreateFromAntlrAst(tree);
                    break;
                case asn1Parser.PERMITTED_ALPHABET_EXPR:
                    ret = PermittedAlphabetExpression.CreateFromAntlrAst(tree);
                    break;
                case asn1Parser.SUBTYPE_EXPR:
                    ret = SubtypeExpression.CreateFromAntlrAst(tree);
                    break;
                case asn1Parser.SET_OF_VALUES:
                    ret = SetOfValues.CreateFromAntlrAst(tree);
                    break;
                case asn1Parser.PATTERN_EXPR:
                    ret = PatternExpression.CreateFromAntlrAst(tree);
                    break;
                case asn1Parser.INNER_TYPE_EXPR:
                    Console.Error.WriteLine("Unimplemented feature, 'WITH COMPONENTS' is ignored");
                    ret = new WithComponentsExpression();
                    break;
                default:
                    throw new Exception("Unkown constraint expression: " + tree.Text);
            }

            return ret;
        }
    }

    

    public partial class ValueRangeExpression : ConstraintExpression
    {
        static public new ValueRangeExpression CreateFromAntlrAst(ITree tree)
        {
            ValueRangeExpression ret = new ValueRangeExpression();
            ret.m_minValue = Asn1Value.CreateFromAntlrAst(tree.GetChild(0));
            int lineNo = tree.GetChild(0).Line;
            for (int i = 1; i < tree.ChildCount; i++)
            {
                ITree child = tree.GetChild(i);
                switch (child.Type)
                {
                    case asn1Parser.MAX_VAL_PRESENT:
                        ret.m_maxValue = Asn1Value.CreateFromAntlrAst(child.GetChild(0));
                        break;
                    case asn1Parser.MIN_VAL_INCLUDED:
                        ret.m_minValIsIncluded = true;
                        break;
                    case asn1Parser.MAX_VAL_INCLUDED:
                        ret.m_maxValIsIncluded = true;
                        break;
                    default:
                        throw new Exception("Unkown child: " + child.Text + " for node: " + tree.Text);
                }
            }

            //if (ret.m_maxValue != null && ret.m_minValue.m_valType != ret.m_maxValue.m_valType)
            //    throw new SemanticErrorException("Semantic Error: Both values in a range must be of the same type. Line:" +lineNo.ToString());

            return ret;
        }
    }

    public partial class SizeExpression : ConstraintExpression
    {
        static public new SizeExpression CreateFromAntlrAst(ITree tree)
        {
            SizeExpression ret = new SizeExpression();
            ret.m_sizeConstraint = Constraint.CreateFromAntlrAst(tree.GetChild(0));
            return ret;
        }
    }

    public partial class SubtypeExpression : ConstraintExpression
    {
        static public new SubtypeExpression CreateFromAntlrAst(ITree tree)
        {
            SubtypeExpression ret = new SubtypeExpression();
            ret.m_type = Asn1Type.CreateFromAntlrAst(tree.GetChild(0));
            if (tree.ChildCount > 1)
                ret.m_includes = true;
            return ret;
        }
    }

    public partial class PermittedAlphabetExpression : ConstraintExpression
    {
        static public new PermittedAlphabetExpression CreateFromAntlrAst(ITree tree)
        {
            PermittedAlphabetExpression ret = new PermittedAlphabetExpression();
            ret.m_permittedAlphabetConstraint = Constraint.CreateFromAntlrAst(tree.GetChild(0));
            return ret;
        }
    }

    public partial class PatternExpression : ConstraintExpression
    {
        static public new PatternExpression CreateFromAntlrAst(ITree tree)
        {
            PatternExpression ret = new PatternExpression();
            ret.m_pattern = Asn1Value.CreateFromAntlrAst(tree.GetChild(0));
            return ret;
        }
    }

    public partial class SetOfValues : ConstraintExpression
    {
        static public new SetOfValues CreateFromAntlrAst(ITree tree)
        {
            SetOfValues ret = new SetOfValues();
            UnionElement element = null;
            for (int i = 0; i < tree.ChildCount; i++)
            {
                ITree child = tree.GetChild(i);
                switch (child.Type)
                {
                    case asn1Parser.UNION_ELEMENT:
                        element = UnionElementOfIntersectionItems.CreateFromAntlrAst(child);
                        if (!ret.m_extMarkPresent)
                            ret.m_set1.Add(element);
                        else
                            ret.m_set2.Add(element);
                        break;
                    case asn1Parser.UNION_ELEMENT_ALL_EXCEPT:
                        element = UnionElementExceptOf.CreateFromAntlrAst(child);
                        if (ret.m_extMarkPresent)
                            ret.m_set2.Add(element);
                        else
                            ret.m_set1.Add(element);
                        break;
                    case asn1Parser.EXT_MARK:
                        ret.m_extMarkPresent = true;
                        break;
                    default:
                        throw new Exception("Unkown child: " + child.Text + " for node: " + tree.Text);
                }
            }
            return ret;
        }

    }

        
 
}