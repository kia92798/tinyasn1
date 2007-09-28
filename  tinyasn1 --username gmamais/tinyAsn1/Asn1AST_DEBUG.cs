using System;
using System.Collections.Generic;
using System.Text;
using Antlr.Runtime.Tree;

namespace tinyAsn1
{
    static class W
    {
        public static void TAB(System.IO.TextWriter w, int l)
        {
            for (int i = 0; i < l; i++)
                w.Write("  ");
        }
    }

    public partial class Asn1File
    {
        public virtual void printAstAsXml(System.IO.TextWriter w)
        {
            int level = 0;
            w.WriteLine("<ASN1FILE>");
            foreach (Module m in m_modules)
                m.printAstAsXml(w, level + 1);
            w.WriteLine("</ASN1FILE>");
        }
    }

    partial class Module
    {
        public partial class ImportedModule
        {
            public virtual void printAstAsXml(System.IO.TextWriter w, int l)
            {
                W.TAB(w,l);
                w.WriteLine("<ImportedModule module=\"{0}\">",m_moduleID);
                foreach (string str in m_importedTypes)
                {
                    W.TAB(w, l+1);
                    w.WriteLine("<ImportedType name=\"{0}\"/>",str);
                }

                foreach (string str in m_importedVariables)
                {
                    W.TAB(w, l + 1);
                    w.WriteLine("<ImportedVar name=\"{0}\" />", str);
                }

                W.TAB(w, l);
                w.WriteLine("</ImportedModule>", m_moduleID);
            }
        }

        public virtual void printAstAsXml(System.IO.TextWriter w, int l)
        {
            W.TAB(w, l);
            l++;
            w.Write("<Module name=\"" + m_moduleID +"\" ");
            w.Write("Tags=\"" + m_tags + "\" ");
//            w.Write("ExportStatus=\"" + m_exportStatus + "\" ");
            w.Write("ExtensibilityImplied=\"" + m_extensibilityImplied + "\" ");
            w.WriteLine(">");
            W.TAB(w, l);
            w.WriteLine("<EXPORTS>");
            foreach (string str in m_exportedTypes)
            {
                W.TAB(w, l+1);
                w.WriteLine("<EXPORT_TYPE>" + str + "</EXPORT_TYPE>");
            }

            foreach (string str in m_exportedVariables)
            {
                W.TAB(w, l + 1);
                w.WriteLine("<EXPORT_VAR>" + str + "</EXPORT_VAR>");
            }
            W.TAB(w, l);
            w.WriteLine("</EXPORTS>");

            W.TAB(w, l);
            w.WriteLine("<IMPORTS>");
            foreach (ImportedModule mod in m_imports)
                mod.printAstAsXml(w, l + 1);
            W.TAB(w, l);
            w.WriteLine("</IMPORTS>");

            W.TAB(w, l);
            w.WriteLine("<TYPE_ASSIGMENTS>");
            foreach (TypeAssigment assigment in m_typeAssigments.Values)
                assigment.printAstAsXml(w, l + 1);
            W.TAB(w, l);
            w.WriteLine("</TYPE_ASSIGMENTS>");

            W.TAB(w, l);
            w.WriteLine("<VALUE_ASSIGMENTS>");
            foreach (ValueAssigment assigment in m_valuesAssigments.Values)
                assigment.printAstAsXml(w, l + 1);
            W.TAB(w, l);
            w.WriteLine("</VALUE_ASSIGMENTS>");

/*            W.TAB(w, l);
            w.WriteLine("<VALUE__SET_ASSIGMENTS>");
            foreach (ValueSetAssigment assigment in m_valueSetsAssigments.Values)
                assigment.printAstAsXml(w, l + 1);
            W.TAB(w, l);
            w.WriteLine("</VALUE__SET_ASSIGMENTS>");
*/
            l--;
            W.TAB(w, l);
            w.WriteLine("</Module>");
        }
    }

    public partial class TypeAssigment
    {
        public virtual void printAstAsXml(System.IO.TextWriter w, int l)
        {
            W.TAB(w, l);
            w.WriteLine("<TYPE_ASSIGMENT name=\"{0}\">",m_name);
            m_type.printAstAsXml(w, l + 1);
            W.TAB(w, l);
            w.WriteLine("</TYPE_ASSIGMENT>");
        }
    }

    public partial class ValueAssigment
    {
        public virtual void printAstAsXml(System.IO.TextWriter w, int l)
        {
            W.TAB(w, l);
            w.WriteLine("<VALUE_ASSIGMENT name=\"{0}\">", m_name);
            m_type.printAstAsXml(w, l + 1);
            m_value.printAstAsXml(w, l + 1);
            W.TAB(w, l);
            w.WriteLine("</VALUE_ASSIGMENT>");
        }
    }
/*
    public partial class ValueSetAssigment
    {
        public virtual void printAstAsXml(System.IO.TextWriter w, int l)
        {
            W.TAB(w, l);
            w.WriteLine("<VALUE_SET_ASSIGMENT name=\"{0}\">", m_typeReference);
            m_type.printAstAsXml(w, l + 1);
            m_constr_body.printAstAsXml(w, l + 1);
            W.TAB(w, l);
            w.WriteLine("</VALUE_SET_ASSIGMENT>");
        }

    }
*/

    public partial class Asn1Type
    {
        public partial class Tag
        {
            public virtual void printAstAsXml(System.IO.TextWriter w, int l)
            {
                w.Write("Class=\"{0}\" tag=\"{1}\" ImplOrExpl=\"{2}\" ", m_class, m_tag, ImpOrExpl);
            }
        }
        public virtual void printConstraints(System.IO.TextWriter w, int l)
        {
            if (m_constraints.Count == 0)
                return;
            W.TAB(w, l);
            w.WriteLine("<CONSTRAINTS_LIST>");
            foreach (Constraint con in m_constraints)
                con.printAstAsXml(w, l + 1);
            W.TAB(w, l);
            w.WriteLine("</CONSTRAINTS_LIST>");

        }
        
        public virtual void printAstAsXml(System.IO.TextWriter w, int l)
        {
            throw new Exception("Unimplemented fature ...");
        }
    }

    public partial class NullType : Asn1Type
    {
        public override void printAstAsXml(System.IO.TextWriter w, int l)
        {
            W.TAB(w, l);
            w.Write("<NULL_TYPE ");
            if (m_tag != null)
                m_tag.printAstAsXml(w, l);
            w.WriteLine(">");
            printConstraints(w, l + 1);
            W.TAB(w, l);
            w.WriteLine("</NULL_TYPE>");
        }
    }


    public partial class BooleanType : Asn1Type
    {
        public override void printAstAsXml(System.IO.TextWriter w, int l)
        {
            W.TAB(w, l);
            w.Write("<BOOLEAN_TYPE ");
            if (m_tag != null)
                m_tag.printAstAsXml(w, l);
            w.WriteLine(">");
            printConstraints(w, l + 1);
            W.TAB(w, l);
            w.WriteLine("</BOOLEAN_TYPE>");
        }
    }
    public partial class RealType : Asn1Type
    {
        public override void printAstAsXml(System.IO.TextWriter w, int l)
        {
            W.TAB(w, l);
            w.Write("<REAL_TYPE ");
            if (m_tag != null)
                m_tag.printAstAsXml(w, l);
            w.WriteLine(">");
            printConstraints(w, l + 1);
            W.TAB(w, l);
            w.WriteLine("</REAL_TYPE>");
        }
    }


    public partial class NumberedItem
    {
        public virtual void printAstAsXml(System.IO.TextWriter w, int l)
        {
            W.TAB(w, l);
            w.WriteLine("<NUMBERD_ITEM name=\"{0}\" value=\"{1}\" />",m_id,Value);
        }
    }


    public partial class BitStringType : Asn1Type
    {
        public override void printAstAsXml(System.IO.TextWriter w, int l)
        {
            W.TAB(w, l);
            w.Write("<BIT_STRING_TYPE ");
            if (m_tag != null)
                m_tag.printAstAsXml(w, l);
            w.WriteLine(">");
            foreach (NumberedItem item in m_namedBits.Values)
                item.printAstAsXml(w, l + 1);
            printConstraints(w, l + 1);
            W.TAB(w, l);
            w.WriteLine("</BIT_STRING_TYPE>");
        }
    }


    public partial class EnumeratedType : Asn1Type
    {
        public override void printAstAsXml(System.IO.TextWriter w, int l)
        {
           
            W.TAB(w, l);
            w.Write("<ENUMERATED_TYPE ");
            if (m_tag != null)
                m_tag.printAstAsXml(w, l);
            w.WriteLine(">");
            foreach (NumberedItem item in m_enumValues.Values)
                item.printAstAsXml(w, l + 1);
            if (m_exceptionSpec != null)
                m_exceptionSpec.printAstAsXml(w, l + 1);
            printConstraints(w, l + 1);
            W.TAB(w, l);
            w.WriteLine("</ENUMERATED_TYPE>");
        }
    }

    public partial class IntegerType : Asn1Type
    {
        public override void printAstAsXml(System.IO.TextWriter w, int l)
        {
            W.TAB(w, l);
            w.Write("<INTEGER_TYPE ");
            if (m_tag != null)
                m_tag.printAstAsXml(w, l);
            w.WriteLine(">");
            foreach (NumberedItem item in m_namedValues.Values)
                item.printAstAsXml(w, l + 1);
            printConstraints(w, l + 1);
            W.TAB(w, l);
            w.WriteLine("</INTEGER_TYPE>");
        }
    }


    public partial class ChoiceType : Asn1Type
    {
        public partial class Child
        {
            public virtual void printAstAsXml(System.IO.TextWriter w, int l)
            {
                W.TAB(w, l);
                w.WriteLine("<CHILD name=\"{0}\"  >", m_childVarName);
                m_type.printAstAsXml(w, l + 1);
                W.TAB(w, l);
                w.WriteLine("</CHILD>");

            }
        }

        public override void printAstAsXml(System.IO.TextWriter w, int l)
        {
            W.TAB(w, l);
            w.Write("<CHOICE_TYPE ");
            if (m_tag != null)
                m_tag.printAstAsXml(w, l);
            w.WriteLine(">");
            foreach (Child ch in m_children.Values)
                ch.printAstAsXml(w, l+1);
            W.TAB(w, l);
            w.Write("<CHOICE_TYPE ");
        }
    }



    public partial class SequenceOrSetType : Asn1Type
    {
        public partial class Child
        {
            public virtual void printAstAsXml(System.IO.TextWriter w, int l)
            {
                W.TAB(w, l);
                w.WriteLine("<CHILD name=\"{0}\" optinal=\"{1}\" default=\"{2}\" >", m_childVarName, m_optional,m_default);
                m_type.printAstAsXml(w, l + 1);
                if (m_defaultValue!=null)
                    m_defaultValue.printAstAsXml(w, l + 1);
                W.TAB(w, l);
                w.WriteLine("</CHILD>");

            }
        }

        public override void printAstAsXml(System.IO.TextWriter w, int l)
        {
            foreach (Child ch in m_children.Values)
                ch.printAstAsXml(w, l);
        }
    }



    public partial class SequenceType : SequenceOrSetType
    {
        public override void printAstAsXml(System.IO.TextWriter w, int l)
        {
            W.TAB(w, l);
            w.Write("<SEQUENCE_TYPE ");
            if (m_tag != null)
                m_tag.printAstAsXml(w, l);
            w.WriteLine(">");
            base.printAstAsXml(w, l + 1);
            printConstraints(w, l + 1);
            W.TAB(w, l);
            w.WriteLine("</SEQUENCE_TYPE>");
        }
    }

    public partial class SetType : SequenceOrSetType
    {
        public override void printAstAsXml(System.IO.TextWriter w, int l)
        {
            W.TAB(w, l);
            w.Write("<SET_TYPE ");
            if (m_tag != null)
                m_tag.printAstAsXml(w, l);
            w.WriteLine(">");
            base.printAstAsXml(w, l + 1);
            printConstraints(w, l + 1);
            W.TAB(w, l);
            w.WriteLine("</SET_TYPE>");
        }
    }

    public partial class OctetStringType : Asn1Type
    {
        public override void printAstAsXml(System.IO.TextWriter w, int l)
        {
            W.TAB(w, l);
            w.Write("<OCTECT_STRING ");
            if (m_tag != null)
                m_tag.printAstAsXml(w, l);
            w.WriteLine(">");
            printConstraints(w, l + 1);
            W.TAB(w, l);
            w.WriteLine("</OCTECT_STRING>");
        }
    }

    public partial class SequenceOfType : Asn1Type
    {
        public override void printAstAsXml(System.IO.TextWriter w, int l)
        {
            W.TAB(w, l);
            w.Write("<SEQUENCE_OF_TYPE ");
            if (m_tag != null)
                m_tag.printAstAsXml(w, l);
            w.WriteLine(">");
            type.printAstAsXml(w, l + 1);
            printConstraints(w, l + 1);
            W.TAB(w, l);
            w.WriteLine("</SEQUENCE_OF_TYPE>");
        }
    }

    public partial class SetOfType : Asn1Type
    {
        public override void printAstAsXml(System.IO.TextWriter w, int l)
        {
            W.TAB(w, l);
            w.Write("<SET__OF_TYPE ");
            if (m_tag != null)
                m_tag.printAstAsXml(w, l);
            w.WriteLine(">");
            type.printAstAsXml(w, l + 1);
            printConstraints(w, l + 1);
            W.TAB(w, l);
            w.WriteLine("</SET__OF_TYPE>");
        }
    }


    public partial class ReferenceType : Asn1Type
    {
        public override void printAstAsXml(System.IO.TextWriter w, int l)
        {
            W.TAB(w, l);
            w.Write("<REFERENCED_TYPE name=\"{0}\" modName=\"{1}\" ", m_referencedTypeName, m_referencedModName);
            if (m_tag != null)
                m_tag.printAstAsXml(w, l);
            w.WriteLine(">");
            printConstraints(w, l + 1);
            W.TAB(w, l);
            w.WriteLine("</REFERENCED_TYPE>");
        }
    }
    
    public partial class Asn1Value
    {
        public virtual void printAstAsXml(System.IO.TextWriter w, int l)
        {
            W.TAB(w, l);
            w.WriteLine("<VALUE>{0}</VALUE>", m_value);
        }
    }

    public partial class ExceptionSpec
    {
        public virtual void printAstAsXml(System.IO.TextWriter w, int l)
        {
        }
    }

    public partial class Constraint
    {
        public virtual void printAstAsXml(System.IO.TextWriter w, int l)
        {
            W.TAB(w, l);
            w.WriteLine("<CONSTRAINT>");
            m_values.printAstAsXml(w, l + 1);
            if (m_exception!=null)
                m_exception.printAstAsXml(w, l + 1);
            W.TAB(w, l);
            w.WriteLine("</CONSTRAINT>");
        }
    }

    public partial class UnionElement
    {
        public virtual void printAstAsXml(System.IO.TextWriter w, int l)
        {
        }
    }


    public partial class UnionElementOfIntersectionItems : UnionElement
    {
        public override void printAstAsXml(System.IO.TextWriter w, int l)
        {
            W.TAB(w, l);
            w.WriteLine("<UNION_ELEMENT>");
            foreach (IntersectionElement i in m_intersectionElements)
                i.printAstAsXml(w, l + 1);
            W.TAB(w, l);
            w.WriteLine("</UNION_ELEMENT>");
        }
    }

    public partial class UnionElementExceptOf : UnionElement
    {
        public override void printAstAsXml(System.IO.TextWriter w, int l)
        {
            W.TAB(w, l);
            w.WriteLine("<UNION_ELEMENT_EXCEPT>");
            m_exceptOfThis.printAstAsXml(w, l + 1);
            W.TAB(w, l);
            w.WriteLine("</UNION_ELEMENT_EXCEPT>");
        }
    }

    public partial class IntersectionElement
    {
        public virtual void printAstAsXml(System.IO.TextWriter w, int l)
        {
            W.TAB(w, l);
            w.WriteLine("<INTERSECTION_ELEMENT>");
            m_exp.printAstAsXml(w, l + 1);
            if (m_except_exp != null)
                m_except_exp.printAstAsXml(w, l + 1);
            W.TAB(w, l);
            w.WriteLine("</INTERSECTION_ELEMENT>");
        }
    }

    public partial class ConstraintExpression
    {
        public virtual void printAstAsXml(System.IO.TextWriter w, int l)
        {
        }
    }


    public partial class ValueRangeExpression : ConstraintExpression
    {
        public override void printAstAsXml(System.IO.TextWriter w, int l)
        {
            W.TAB(w, l);
            w.Write("<RANGE min=\"{0}\" ",m_minValue);
            if (m_maxValue!=null)
                w.Write("max=\"{0}\" ", m_maxValue);
            w.Write("minValIsIncluded=\"{0}\" ", m_minValIsIncluded);
            w.WriteLine("maxValIsIncluded=\"{0}\" />", m_maxValIsIncluded);
        }
    }

    public partial class SizeExpression : ConstraintExpression
    {
        public override void printAstAsXml(System.IO.TextWriter w, int l)
        {
            W.TAB(w, l);
            w.WriteLine("<SIZE_CONSTRAINT>");

            m_sizeConstraint.printAstAsXml(w, l + 1);

            W.TAB(w, l);
            w.WriteLine("</SIZE_CONSTRAINT>");
        }
    }

    public partial class SubtypeExpression : ConstraintExpression
    {
        public override void printAstAsXml(System.IO.TextWriter w, int l)
        {
            W.TAB(w, l);
            w.WriteLine("<SUBTYPE_CONSTRAINT Includes=\"{0}\">",m_includes);

            m_type.printAstAsXml(w, l + 1);

            W.TAB(w, l);
            w.WriteLine("</SUBTYPE_CONSTRAINT>");
        }
    }

    public partial class PermittedAlphabetExpression : ConstraintExpression
    {
        public override void printAstAsXml(System.IO.TextWriter w, int l)
        {
            W.TAB(w, l);
            w.WriteLine("<PERMITTED_ALPHABET_CONSTRAINT>");

            m_permittedAlphabetConstraint.printAstAsXml(w, l + 1);

            W.TAB(w, l);
            w.WriteLine("</PERMITTED_ALPHABET_CONSTRAINT>");
        }
    }

    public partial class SetOfValues : ConstraintExpression
    {
        public override void printAstAsXml(System.IO.TextWriter w, int l)
        {
            W.TAB(w, l);
            w.WriteLine("<SET_OF_VALUES ExtensionPresent=\"{0}\">", m_extMarkPresent);

            l++;
            W.TAB(w, l);
            w.WriteLine("<UNION_SET1>");
            foreach (UnionElement u in m_set1)
                u.printAstAsXml(w, l + 1);
            W.TAB(w, l);
            w.WriteLine("</UNION_SET1>");

            if (m_set2.Count > 0)
            {
                W.TAB(w, l);
                w.WriteLine("<UNION_SET2>");
                foreach (UnionElement u in m_set2)
                    u.printAstAsXml(w, l + 1);
                W.TAB(w, l);
                w.WriteLine("</UNION_SET2>");
            }

            l--;

            W.TAB(w, l);
            w.WriteLine("</SET_OF_VALUES>");
        }
    }
}