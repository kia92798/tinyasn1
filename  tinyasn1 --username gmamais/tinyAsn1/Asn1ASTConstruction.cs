using System;
using System.Collections.Generic;
using System.Text;
using Antlr.Runtime.Tree;

namespace tinyAsn1
{

    public partial class Asn1File
    {
        //^(ASN1_FILE moduleDefinition*)
        static public Asn1File CreateFromAntlrAst(ITree tree)
        {
            if (tree.Type != asn1Parser.ASN1_FILE)
                throw new Exception("ASN1_FILE");

            Asn1File ret = new Asn1File();

            for (int i = 0; i < tree.ChildCount; i++)
                ret.m_modules.Add(Module.CreateFromAntlrAst(tree.GetChild(i)));

            return ret;
        }
    }

    partial class Module
    {
        public partial class ImportedModule
        {
            //^(IMPORTS_FROM_MODULE modulereference typereference* valuereference*  )
            static public ImportedModule CreateFromAntlrAst(ITree tree)
            {
                ImportedModule ret = new ImportedModule();

                ret.m_moduleID = tree.GetChild(0).Text;

                for (int i = 1; i < tree.ChildCount; i++)
                {
                    ITree child = tree.GetChild(i);

                    switch (child.Type)
                    {
                        case asn1Parser.UID:
                            ret.m_importedTypes.Add(child.Text);
                            break;
                        case asn1Parser.LID:
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
        static public Module CreateFromAntlrAst(ITree tree)
        {
            Module curModule;

            if (tree.Type != asn1Parser.MODULE_DEF)
                throw new Exception("MODULE_DEF");

            curModule = new Module();
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
                        curModule.m_exportStatus = ExportStatus.ALL;
                        break;
                    case asn1Parser.EXPORTS:
                        handleExports(curModule, child);                        
                        break;
                    case asn1Parser.IMPORTS_FROM_MODULE:
                        curModule.m_imports.Add(ImportedModule.CreateFromAntlrAst(child));
                        break;
                    case asn1Parser.TYPE_ASSIG:
                        TypeAssigment typeAssig = TypeAssigment.CreateFromAntlrAst(child);
                        curModule.typeAssigments.Add(typeAssig.m_name, typeAssig);
                        break;
                    case asn1Parser.VAL_ASSIG:
                        ValueAssigment valAssig = ValueAssigment.CreateFromAntlrAst(child);
                        curModule.valuesAssigments.Add(valAssig.m_name, valAssig);
                        break;
                    default:
                        throw new Exception("Unkown child: " + child.Text + " for node: " + tree.Text);
                }

            }
            return curModule;
        }

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
                            ret = SequenceOfType.CreateFromAntlrAst(child);
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
                            ret = new OctetStringType();
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
            if (ret!=null)
                ret.m_tag = tag;
            return ret;
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
                        ret.m_valueAsInt = Helper.GetValFrom_NUMERIC_VALUE_asInt(child);
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


    public partial class BitStringType : Asn1Type
    {
        static public new BitStringType CreateFromAntlrAst(ITree tree)
        {
            BitStringType ret = new BitStringType();
            for (int i = 0; i < tree.ChildCount; i++)
            {
                ITree child = tree.GetChild(i);
                NumberedItem item = NumberedItem.CreateFromAntlrAst(child);
                ret.m_namedBis.Add(item.m_id, item);
            }


            return ret;
        }
    }


    public partial class EnumeratedType : Asn1Type
    {
        //^(ENUMERATED_TYPE enumeratedTypeItems ('...' exceptionSpec? enumeratedTypeItems?) ?)
        static public new EnumeratedType CreateFromAntlrAst(ITree tree)
        {
            EnumeratedType ret = new EnumeratedType();
            for (int i = 1; i < tree.ChildCount; i++)
            {
                ITree child = tree.GetChild(i);
                switch (child.Type)
                {
                    case asn1Parser.ENUMERATED_LST_ITEM:
                        NumberedItem item = NumberedItem.CreateFromAntlrAst(child);
                        if (ret.m_extMarkPresent)
                            ret.m_additionalEnumValues.Add(item.m_id, item);
                        else
                            ret.m_enumValues.Add(item.m_id, item);
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
                ret.m_namedValues.Add(item.m_id, item);
            }

            return ret;
            
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

                for (int i = 1; i < tree.ChildCount; i++)
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
        }

        //	^(CHOICE_TYPE choiceItemsList choiceExtensionBody?)
        static public new ChoiceType CreateFromAntlrAst(ITree tree)
        {
            ChoiceType ret = new ChoiceType();
            for (int i = 1; i < tree.ChildCount; i++)
            {
                ITree child = tree.GetChild(i);
                switch (child.Type)
                {
                    case asn1Parser.CHOICE_ITEM:
                        Child ch = Child.CreateFromAntlrAst(child, null, false);
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
            for (int i = 1; i < tree.ChildCount; i++)
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
                        ret.m_children.Add(ch.m_childVarName, ch);
                        break;
                    default:
                        throw new Exception("Unkown child: " + child.Text + " for node: " + tree.Text);
                }
            }
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

                for (int i = 1; i < tree.ChildCount; i++)
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
                        case asn1Parser.VAL_ASSIG:
                            ret.m_defaultValue = Asn1Value.CreateFromAntlrAst(child);
                            break;
                        default:
                            throw new Exception("Unkown child: " + child.Text + " for node: " + tree.Text);
                    }
                }

                return ret;
                
            }
        }

        static public SequenceOrSetType CreateFromAntlrAst(SequenceOrSetType ret, ITree tree)
        {
            for (int i = 1; i < tree.ChildCount; i++)
            {
                ITree child = tree.GetChild(i);
                switch (child.Type)
                {
                    case asn1Parser.SEQUENCE_ITEM:
                        Child ch = Child.CreateFromAntlrAst(child, null, false);
                        ret.m_children.Add(ch.m_childVarName, ch);
                        break;
                    case asn1Parser.SEQUENCE_EXT_BODY:
                        handleExtension(ret, child);
                        break;
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
                        ret.m_children.Add(ch.m_childVarName, ch);
                        break;
                    case asn1Parser.SEQUENCE_EXT_GROUP:
                        handleVersionGroup(ret, child);
                        break;
                    default:
                        throw new Exception("Unkown child: " + child.Text + " for node: " + tree.Text);
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
                        ret.m_children.Add(ch.m_childVarName, ch);
                        break;
                    default:
                        throw new Exception("Unkown child: " + child.Text + " for node: " + tree.Text);
                }
            }
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
                        ret.type = Asn1Type.CreateFromAntlrAst(child);
                        break;
                    default:
                        throw new Exception("Unkown child: " + child.Text + " for node: " + tree.Text);
                }
            }

            return ret;
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
                        ret.type = Asn1Type.CreateFromAntlrAst(child);
                        break;
                    default:
                        throw new Exception("Unkown child: " + child.Text + " for node: " + tree.Text);
                }
            }

            return ret;
        }
    }





    public partial class Asn1Value
    {
        static public Asn1Value CreateFromAntlrAst(ITree tree)
        {
            Asn1Value ret = new Asn1Value();

            switch (tree.Type)
            {
                case asn1Parser.BitStringLiteral:
                    ret.m_strVal = tree.Text;
                    ret.m_valType = ValType.BIT_STRING_LITERAL;
                    break;
                case asn1Parser.BIT_STRING_VALUE:
                    ret.m_bitStrVal = new List<string>();
                    ret.m_valType = ValType.BIT_STRING_VALUE;
                    for (int i = 0; i < tree.ChildCount; i++)
                        ret.m_bitStrVal.Add(tree.GetChild(i).Text);
                    break;
                case asn1Parser.OctectStringLiteral:
                    ret.m_valType = ValType.OCTECT_STRING_LITERAL;
                    ret.m_strVal = tree.Text;
                    break;
                case asn1Parser.TRUE:
                    ret.m_valType = ValType.BOOLEAN_TRUE;
                    break;
                case asn1Parser.FALSE:
                    ret.m_valType = ValType.BOOLEAN_FALSE;
                    break;
                case asn1Parser.StringLiteral:
                    ret.m_valType = ValType.STRING_LITERAL;
                    ret.m_strVal = tree.Text;
                    break;
                case asn1Parser.LID:
                    ret.m_valType = ValType.VALUE_REFERENCE;
                    ret.m_strVal = tree.Text;
                    break;
                case asn1Parser.NUMERIC_VALUE:
                    handleNumeric(ret, tree);
                    break;
                case asn1Parser.MIN:
                    ret.m_valType = ValType.MIN;
                    break;
                case asn1Parser.MAX:
                    ret.m_valType = ValType.MAX;
                    break;
                case asn1Parser.CHAR_SEQUENCE_VALUE:
                    ret.m_charSeqVal = new List<int>();
                    ret.m_valType = ValType.CHAR_SEQUENCE_VALUE;
                    for (int i = 0; i < tree.ChildCount; i++)
                        ret.m_charSeqVal.Add(int.Parse(tree.GetChild(i).Text));
                    break;

            }

            return ret;
        }

        static void handleNumeric(Asn1Value ret,ITree tree) 
        {
            ret.m_valType = ValType.INT;
            ret.m_ival = Int64.Parse(tree.GetChild(0).Text);
            bool negate = false;
            Int64 decPart = 0;
            if (tree.ChildCount == 2)
            {
                if (tree.GetChild(1).Text == "-")
                {
                    ret.m_ival = -ret.m_ival;
                    return;
                }
                else
                {
                    ret.m_valType = ValType.REAL;
                    ret.m_dval = ret.m_ival;
                    negate = false;
                    decPart = Int64.Parse(tree.GetChild(1).Text);
                }
            } else 
            {
                ret.m_valType = ValType.REAL;
                ret.m_dval = ret.m_ival;
                negate = tree.GetChild(1).Text == "-";
                decPart = Int64.Parse(tree.GetChild(1).Text);
            }

            double tmp = decPart;
            for (int i = 0; i < decPart.ToString().Length; i++)
                tmp = tmp / 10.0;

            ret.m_dval += tmp;
            if (negate)
                ret.m_dval = -ret.m_dval;
        }
    }

    public partial class ExceptionSpec
    {
        static public ExceptionSpec CreateFromAntlrAst(ITree tree)
        {
            throw new Exception("Unimplemented feature!");
        }
    }

    public partial class Constraint
    {
        static public Constraint CreateFromAntlrAst(ITree tree)
        {
            throw new Exception("Unimplemented feature!");
        }
        static public Constraint CreateConstraintFromSizeConstraint(ITree tree)
        {
            throw new Exception("Unimplemented feature!");
        }
    }



        
    public static class Helper
    {
        //^(NUMERIC_VALUE $intPart $s? $decPart?)
        public static int GetValFrom_NUMERIC_VALUE_asInt(ITree tree)
        {
            int ret = int.Parse(tree.GetChild(0).Text);
            if (tree.ChildCount > 1 && tree.GetChild(1).Text == "-")
                ret = -ret;
            return ret;
        }
    }

}