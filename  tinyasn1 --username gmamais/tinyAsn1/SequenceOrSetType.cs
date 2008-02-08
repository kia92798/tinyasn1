using System;
using System.Collections.Generic;
using System.Text;
using Antlr.Runtime.Tree;
using Antlr.Runtime;

namespace tinyAsn1
{
    public partial class SequenceOrSetType : Asn1Type
    {
        public OrderedDictionary<string, Child> m_children = new OrderedDictionary<string, Child>();
        public bool m_extMarkPresent = false;
        public ExceptionSpec m_exceptionSpec;
        public bool m_extMarkPresent2 = false;

        public partial class Child 
        {
            public string m_childVarName;
            public Asn1Type m_type;
            public bool m_optional = false;
            public bool m_default = false;
            public Asn1Value m_defaultValue;
            public bool m_extended = false;
            public int? m_version=null;
            public List<string> m_comments = new List<string>();

            public Child()
            {
            }
            
            public Child(Child o)
            {
                m_childVarName = o.m_childVarName;
                m_type = o.m_type;
                m_optional = o.m_optional;
                m_default = o.m_default;
                m_defaultValue = o.m_defaultValue;
                m_extended = o.m_extended;
                m_version = o.m_version;
            }

            public void PrintAsn1(StreamWriterLevel o, int lev)
            {
                o.P(lev);
                if (m_version != null)
                    o.Write("[[{0}: ", m_version);
                o.Write(m_childVarName); o.Write(" ");
                m_type.PrintAsn1(o, lev);
                if (m_defaultValue != null)
                {
                    o.Write(" DEFAULT " + m_defaultValue.ToString());
                }
                else if (m_optional)
                    o.Write(" OPTIONAL");
                if (m_version != null)
                    o.Write("]]");

            }

            //            bool componentsOf = false;
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
                        case asn1Parser.SPECIAL_COMMENT:
                            ret.m_comments.Add(child.Text.Replace("--@", "").Replace("\r", "").Replace("\n", "").Replace("--", ""));
                            break;
                        default:
                            throw new Exception("Internal Error, unexpected child: " + child.Text + " for node: " + tree.Text);
                    }
                }
                return ret;

            }

            public bool SemanticAnalysisFinished()
            {
                if (m_defaultValue == null)
                    return m_type.SemanticAnalysisFinished();

                return m_type.SemanticAnalysisFinished() && m_defaultValue.IsResolved();

            }

            public void DoSemanticAnalysis()
            {
                if (SemanticAnalysisFinished())
                    return;

                m_type.DoSemanticAnalysis();

                if (m_defaultValue != null)
                {
                    if (!m_defaultValue.IsResolved())
                        m_defaultValue = m_type.ResolveVariable(m_defaultValue);

                }
            }

            internal bool Compatible(Child child)
            {
                bool ret = true;
                if (m_defaultValue != null)
                    ret = m_defaultValue.Equals(child.m_default);
                ret =  m_childVarName == child.m_childVarName && m_optional == child.m_optional &&
                    m_type.Compatible(child.m_type) && ret;
                return ret;
            }

            public void PrintHtml(StreamWriterLevel o, int p, int index)
            {
                string cssClass = "OddRow";
                if (index%2==0)
                    cssClass="EvenRow";
                o.WriteLine("<tr class=\""+cssClass+"\">");
                o.WriteLine("<td class=\"no\">{0}</td>",index);
                o.WriteLine("<td class=\"field\">{0}</td>",m_childVarName);
                o.WriteLine("<td class=\"comment\">{0}</td>", o.BR(m_comments));
                if (m_type is ReferenceType)
                    o.WriteLine("<td class=\"type\"> <a href=\"#ICD_{0}\">{1}</a></td>",m_type.Name.Replace("-","_"),m_type.Name);
                else
                    o.WriteLine("<td class=\"type\">{0}</td>",m_type.Name);
                
                o.WriteLine("<td class=\"constraint\">{0}</td>",m_type.Constraints);
                if (m_optional)
                    o.WriteLine("<td class=\"optional\">Yes</td>");
                else if (m_default)
                    o.WriteLine("<td class=\"optional\">Def</td>");
                else
                    o.WriteLine("<td class=\"optional\">No</td>");
                
                o.WriteLine("<td class=\"min\">{0}</td>",(m_type.MinBitsInPER==-1?"&#8734":m_type.MinBitsInPER.ToString()));
                o.WriteLine("<td class=\"max\">{0}</td>", (m_type.MaxBitsInPER == -1 ? "&#8734" : m_type.MaxBitsInPER.ToString()));
                o.WriteLine("</tr>");
            }
        }
        
        class ComponentChild : Child
        {
            static new public ComponentChild CreateFromAntlrAst(ITree tree, int? version, bool extended)
            {
                ComponentChild ret = new ComponentChild();
                ret.m_version = version;
                ret.m_extended = extended;
                for (int i = 0; i < tree.ChildCount; i++)
                {
                    ITree child = tree.GetChild(i);
                    switch (child.Type)
                    {
                        case asn1Parser.TYPE_DEF:
                            ret.m_type = Asn1Type.CreateFromAntlrAst(child);
                            break;
                        default:
                            throw new Exception("Internal Error, unexpected child: " + child.Text + " for node: " + tree.Text);
                    }
                }
                return ret;
            }
        }



        public int GetNumberOfOptionalOrDefaultFields()
        {
            int ret = 0;
            foreach (Child ch in m_children.Values)
                if (ch.m_optional || ch.m_default)
                    ret++;

            return ret;
        }
        
        protected virtual List<Child> Children
        {
            get
            {
                List<Child> ret = new List<Child>();
                foreach (Child ch in m_children.Values)
                    ret.Add(ch);
                return ret;
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
                        ComponentChild comChild = ComponentChild.CreateFromAntlrAst(child, null, false);
                        ret.m_children.Add("COMPONENTS_OF", comChild);
                        break;
                    default:
                        throw new Exception("Internal Error, unexpected child: " + child.Text + " for node: " + tree.Text);
                }
            }

            return ret;
        }

        private static void handleExtension(SequenceOrSetType ret, ITree tree)
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
                        ComponentChild comChild = ComponentChild.CreateFromAntlrAst(child, null, !ret.m_extMarkPresent2);
                        ret.m_children.Add("COMPONENTS_OF", comChild);
                        break;
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
            int? version = null;
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
                        ComponentChild comChild = ComponentChild.CreateFromAntlrAst(child, version, true);
                        ret.m_children.Add("COMPONENTS_OF", comChild);
                        break;
                    default:
                        throw new Exception("Internal Error, unexpected child: " + child.Text + " for node: " + tree.Text);
                }
            }
        }


        internal override bool SemanticAnalysisFinished()
        {
            foreach (Child ch in m_children.Values)
            {
                if (ch is ComponentChild)
                    return false;
            }
            foreach (Child ch in m_children.Values)
            {
                if (!ch.SemanticAnalysisFinished())
                    return false;
            }
            if (!m_Check243Performed)
                return false;
            if (m_exceptionSpec != null && !m_exceptionSpec.isResolved())
                return false;
            return base.SemanticAnalysisFinished();
        }

        private bool m_AutomaticTaggingTransformationCanBeApplied = true; //24.3
        private bool m_Check243Performed = false;

        public override void DoSemanticAnalysis()
        {
            if (SemanticAnalysisFinished())
                return;
            base.DoSemanticAnalysis();

            if (!m_Check243Performed)
            {
                m_Check243Performed = true;
                foreach (Child ch in m_children.Values)
                {
                    if (ch is ComponentChild)
                        continue;
                    if (ch.m_type.m_tag != null)
                    {
                        m_AutomaticTaggingTransformationCanBeApplied = false;
                        break;
                    }
                }
                m_AutomaticTaggingTransformationCanBeApplied = m_AutomaticTaggingTransformationCanBeApplied && m_module.m_taggingMode == TaggingMode.AUTOMATIC;
            }

            // first get rid off COMPONENTS OF
            OrderedDictionary<string, Child> newChildren = new OrderedDictionary<string, Child>();
            bool ReplacementOccurerred = false;
            foreach (Child ch in m_children.Values)
            {
                ComponentChild compChild = ch as ComponentChild;
                if (compChild != null)
                {
                    if (!compChild.m_type.SemanticAnalysisFinished())
                        return;
                    SequenceOrSetType sq = compChild.m_type.GetFinalType() as SequenceOrSetType;
                    if (sq == null)
                        throw new SemanticErrorException("Error line: " + compChild.m_type.antlrNode.Line + ". " + compChild.m_type.Name + " is not SEQUENCE or SET");
                    //We have to replace compChild with sq.m_children
                    foreach (Child otherChild in sq.m_children.Values)
                    {
                        if (newChildren.ContainsKey(otherChild.m_childVarName))
                            throw new SemanticErrorException("Error line: " + compChild.m_type.antlrNode.Line + ". " + compChild.m_type.Name + " can not be expanded. Duplicate child name(" + otherChild.m_childVarName + ")");
                        if (otherChild.m_extended)
                            continue;
                        Child childCopy = new Child(otherChild);
                        childCopy.m_version = compChild.m_version;
                        childCopy.m_extended = compChild.m_extended;
                        newChildren.Add(childCopy.m_childVarName, childCopy);
                        ReplacementOccurerred = true;
                    }

                }
                else
                {
                    newChildren.Add(ch.m_childVarName, ch);
                }
            }

            if (ReplacementOccurerred)
                m_children = newChildren;

            foreach (Child ch in m_children.Values)
            {
                ch.DoSemanticAnalysis();
            }
            if (m_exceptionSpec != null && !m_exceptionSpec.isResolved())
                m_exceptionSpec.DoSemanticAnalysis();

        }

        public override void PerformAutomaticTagging()
        {
            int curTag = 0;
            foreach (Child ch in m_children.Values)
            {
                if (m_AutomaticTaggingTransformationCanBeApplied)
                {

                    ch.m_type.m_tag = new Tag();
                    ch.m_type.m_tag.m_class = Tag.TagClass.CONTEXT_SPECIFIC;
                    ch.m_type.m_tag.m_tag = curTag;
                    ch.m_type.m_tag.m_type = ch.m_type;
                    if (ch.m_type.GetFinalType() is ChoiceType)
                        ch.m_type.m_tag.m_taggingMode = TaggingMode.EXPLICIT;
                    else
                        ch.m_type.m_tag.m_taggingMode = TaggingMode.IMPLICIT;
                    curTag++;
                }
                ch.m_type.PerformAutomaticTagging();
            }
        }


        internal override Asn1Value ResolveVariable(Asn1Value val)
        {
            string referenceId = "";
            SequenceOrSetValue sqVal = val as SequenceOrSetValue;
            switch (val.antlrNode.Type)
            {
                case asn1Parser.NAMED_VALUE_LIST:
                case asn1Parser.EMPTY_LIST:
                case asn1Parser.OBJECT_ID_VALUE:    // for catching cases {id id2} or {id 4}
                    if (sqVal == null)
                        if (this is SequenceType)
                            return new SequenceOrSetValue(val.antlrNode, m_module, this, true);
                        else
                            return new SequenceOrSetValue(val.antlrNode, m_module, this, false);
                    else
                    {
                        sqVal.FixChildrenVars();
                        return sqVal;
                    }
                case asn1Parser.VALUE_REFERENCE:
                    referenceId = val.antlrNode.GetChild(0).Text;
                    if (m_module.isValueDeclared(referenceId))
                    {
                        Asn1Value tmp = m_module.GetValue(referenceId);
                        switch (tmp.m_TypeID)
                        {
                            case Asn1Value.TypeID.SEQUENCE_OR_SET:
                                if (tmp.IsResolved())
                                {
                                    if (tmp.Type.GetFinalType() == this)
                                        return new SequenceOrSetValue(tmp as SequenceOrSetValue, val.antlrNode.GetChild(0));
                                    throw new SemanticErrorException("Error in line : " + val.antlrNode.Line + ". Incompatible variable assigment");
                                }
                                return val; // not yet fully resolved, wait for next round
                            case Asn1Value.TypeID.UNRESOLVED:
                                // not yet resolved, wait for next round
                                return val;
                            default:
                                throw new SemanticErrorException("Error in line : " + val.antlrNode.Line + ". Incompatible variable assigment");
                        }
                    }
                    else
                        throw new SemanticErrorException("Error in line : " + val.antlrNode.Line + ". Identifier '" + referenceId + "' is unknown");

                default:
                    throw new SemanticErrorException("Error in line : " + val.antlrNode.Line + ". Expecting SEQUENCE variable");
            }
        }

        public override void ResolveConstraints()
        {
            if (AreConstraintsResolved())
                return;
            foreach (Child ch in m_children.Values)
                ch.m_type.ResolveConstraints();
            base.ResolveConstraints();

        }
        public override void CheckDefaultValues()
        {
            foreach (Child ch in m_children.Values)
            {
                if (ch.m_defaultValue != null && !ch.m_type.isValueAllowed(ch.m_defaultValue))
                    throw new SemanticErrorException("Error: line " + ch.m_type.antlrNode.Line + " Default value does not satisfy type constraints");
                ch.m_type.CheckDefaultValues();
            }
        }

        public override bool AreConstraintsResolved()
        {
            foreach (Child ch in m_children.Values)
                if (!ch.m_type.AreConstraintsResolved())
                    return false;
            return base.AreConstraintsResolved();
        }
        public override bool isValueAllowed(Asn1Value val)
        {
            if (!base.isValueAllowed(val))
                return false;
            SequenceOrSetValue v = val as SequenceOrSetValue;
            if (v == null)
                throw new Exception("Internal Error");

            foreach (string chName in v.m_children.Keys)
            {
                Asn1Value chValue = v.m_children[chName];
                if (!m_children[chName].m_type.isValueAllowed(chValue))
                    return false;
            }

            return true;
        }
        static List<int> m_allowedTokens = new List<int>(new int[]{ asn1Parser.CONSTRAINT, asn1Parser.EXCEPTION_SPEC, asn1Parser.EXT_MARK, 
                asn1Parser.UNION_SET, asn1Parser.UNION_SET_ALL_EXCEPT, asn1Parser.INTERSECTION_SET,
                asn1Parser.INTERSECTION_ELEMENT, asn1Parser.VALUE_RANGE_EXPR, asn1Parser.SUBTYPE_EXPR, 
                asn1Parser.WITH_COMPONENTS_CONSTR});
        static List<int> m_stopList = new List<int>(new int[] { asn1Parser.VALUE_RANGE_EXPR, asn1Parser.SUBTYPE_EXPR, 
            asn1Parser.WITH_COMPONENTS_CONSTR , asn1Parser.EXCEPTION_SPEC});

        protected override IEnumerable<int> AllowedTokensInConstraints { get { return m_allowedTokens; } }
        protected override IEnumerable<int> StopTokensInConstraints { get { return m_stopList; } }

        public override void PrintAsn1(StreamWriterLevel o, int lev)
        {
            Child ch;
            if (m_tag != null)
                m_tag.PrintAsn1(o, lev);
            o.WriteLine(Name + " {");
            bool extMark1Printed = false;
            bool extMark2Printed = false;
            for (int i = 0; i < m_children.Values.Count - 1; i++)
            {
                ch = m_children.Values[i];

                if (m_extMarkPresent && !extMark1Printed && ch.m_extended)
                {
                    extMark1Printed = true;
                    o.P(lev+1);
                    o.Write("...");
                    if (m_exceptionSpec != null) 
                        o.Write(m_exceptionSpec.ToString());
                    o.WriteLine(",");
                }
                if (m_extMarkPresent2 && extMark1Printed && !extMark2Printed && !ch.m_extended)
                {
                    extMark2Printed = true;
                    o.P(lev+1);
                    o.WriteLine("...,");
                }

                ch.PrintAsn1(o, lev + 1);
                o.WriteLine(",");
            }
            if (m_children.Values.Count > 0)
            {
                ch = m_children.Values[m_children.Values.Count - 1];
                if (m_extMarkPresent && !extMark1Printed && ch.m_extended)
                {
                    extMark1Printed = true;
                    o.P(lev+1);
                    o.Write("...");
                    if (m_exceptionSpec != null)
                        o.Write(m_exceptionSpec.ToString());
                    o.WriteLine(",");
                }
                if (m_extMarkPresent2 && extMark1Printed && !extMark2Printed && !ch.m_extended)
                {
                    extMark2Printed = true;
                    o.P(lev+1);
                    o.WriteLine("...,");
                }

                ch.PrintAsn1(o, lev + 1);
                o.WriteLine();
            }
            if (m_extMarkPresent && !extMark1Printed)
            {
                extMark1Printed = true;
                o.P(lev+1);
                o.Write(",...");
                if (m_exceptionSpec != null)
                    o.WriteLine(m_exceptionSpec.ToString());
            }

            if (m_extMarkPresent2 && extMark1Printed && !extMark2Printed )
            {
                extMark2Printed = true;
                o.P(lev+1);
                o.WriteLine(",...");
            }

            o.P(lev);
            o.Write("}");
            PrintAsn1Constraints(o);
        }

        public override bool Compatible(Asn1Type other)
        {
            SequenceOrSetType o = other.GetFinalType() as SequenceOrSetType;
            if (o == null)
                return false;


            if (m_children.Count != o.m_children.Count)
                return false;

            foreach (string id in m_children.Keys)
            {
                if (!o.m_children.ContainsKey(id))
                    return false;

                if (!m_children[id].Compatible(o.m_children[id]))
                    return false;
            }

            return true;
        }

        public override void ComputePEREffectiveConstraints()
        {
            base.ComputePEREffectiveConstraints();
            foreach (Child child in m_children.Values)
            {
                child.m_type.ComputePEREffectiveConstraints();
            }
        }
        public override bool IsPERExtensible()
        {
            if (m_module.m_extensibilityImplied)
                return true;
            return m_extMarkPresent;
        }

        public int PreambleLength
        {
            get
            {
                int ret = 0;
                if (IsPERExtensible())
                    ret++;
                foreach (Child ch in m_children.Values)
                {
                    if (ch.m_extended)
                        continue;
                    if (ch.m_optional || ch.m_default)
                        ret++;
                }


                return ret;
            }
        }

        public override long maxBitsInPER(PEREffectiveConstraint cns)
        {
            if (IsPERExtensible())
                return -1;

            long ret = PreambleLength;
            foreach (Child ch in m_children.Values)
            {
                if (ch.m_extended)
                    continue;
                long m = ch.m_type.MaxBitsInPER;
                if (m == -1)
                    return -1;
                ret += m;
            }

            return ret;
        }

        public override long minBitsInPER(PEREffectiveConstraint cns)
        {
            long ret = PreambleLength;
            if (IsPERExtensible())
                ret++;

            foreach (Child ch in m_children.Values)
            {
                if (ch.m_extended || ch.m_optional || ch.m_default)
                    continue;
                long m = ch.m_type.MinBitsInPER;
                if (m == -1)
                    return -1;
                ret += m;
            }
            return ret;
        }


        public override void PrintHtml(PEREffectiveConstraint cns, StreamWriterLevel o, int lev, List<string> comment, TypeAssigment tas)
        {
            o.WriteLine("<a name=\"{0}\"></a>", "ICD_" + tas.m_name.Replace("-", "_"));
            o.WriteLine("<table border=\"0\" width=\"100%\" align=\"left\">");
            o.WriteLine("<tbody>");
            o.WriteLine("<tr  bgcolor=\"{0}\">", (tas.m_createdThroughTabulization ? "#379CEE" : "#FF8f00"));
            o.WriteLine("<td height=\"35\" colspan=\"4\">");
            o.WriteLine("<font face=\"Verdana\" color=\"#FFFFFF\" size=\"4\">{0}</font><font face=\"Verdana\" color=\"#FFFFFF\" size=\"2\">({1}) </font>", tas.m_name, Name);
            o.WriteLine("<font face=\"Verdana\" color=\"#FFFFFF\" size=\"2\"><a href=\"#{0}\">ASN.1</a></font>", "ASN1_" + tas.m_name.Replace("-", "_"));
            o.WriteLine("</td>");
            o.WriteLine("<td height=\"35\" colspan=\"2\"  align=\"center\">");
            o.WriteLine("<font face=\"Verdana\" color=\"#FFFFFF\" size=\"2\">min = {0} bytes</font>", (MinBytesInPER == -1 ? "&#8734" : MinBytesInPER.ToString()));
            o.WriteLine("</td>");
            o.WriteLine("<td height=\"35\" colspan=\"2\" align=\"center\">");
            o.WriteLine("<font face=\"Verdana\" color=\"#FFFFFF\" size=\"2\">max = {0} bytes</font>", (MaxBytesInPER == -1 ? "&#8734" : MaxBytesInPER.ToString()));
            o.WriteLine("</td>");
            o.WriteLine("</tr>");

            if (comment.Count > 0)
            {
                o.WriteLine("<tr class=\"CommentRow\">");
                o.WriteLine("<td class=\"comment\" colspan=\"8\">" + o.BR(comment) + "</td>");
                o.WriteLine("</tr>");
            }

            o.WriteLine("<tr class=\"headerRow\">");
            o.WriteLine("<td class=\"hrNo\">No</td>");
            o.WriteLine("<td class=\"hrField\">Field</td>");
            o.WriteLine("<td class=\"hrComment\">Comment</td>");
            o.WriteLine("<td class=\"hrType\">Type</td>");
            o.WriteLine("<td class=\"hrconstraint\">Constraint</td>");
            o.WriteLine("<td class=\"hrOptional\">Optional</td>");
            o.WriteLine("<td class=\"hrMin\">Min Length (bits)</td>");
            o.WriteLine("<td class=\"hrMax\">Max Length (bits)</td>");
            o.WriteLine("</tr>");

            int index=0;
            if (PreambleLength > 0)
            {
                PrintPreambleHtml(o, lev + 1);
                index = 1;
            }
            foreach (Child ch in m_children.Values)
            {
                ch.PrintHtml(o, lev + 1, ++index);
            }
            o.WriteLine("</tbody>");
            o.WriteLine("</table>");
//            o.WriteLine("</a>");
        }
        public void PrintPreambleHtml(StreamWriterLevel o, int p)
        {
            string cssClass = "OddRow";
            o.WriteLine("<tr class=\"" + cssClass + "\">");
            o.WriteLine("<td class=\"no\">0</td>");
            o.WriteLine("<td class=\"field\">Preamble</td>");
            o.WriteLine("<td class=\"comment\">{0}</td>", "Special field used by PER to indicate the presence of optional and default fields.");
            o.WriteLine("<td class=\"type\">{0}</td>", "Bit mask");

            o.WriteLine("<td class=\"constraint\">{0}</td>", "-");
            o.WriteLine("<td class=\"optional\">No</td>" );
            o.WriteLine("<td class=\"min\">{0}</td>", PreambleLength);
            o.WriteLine("<td class=\"max\">{0}</td>", PreambleLength);
            o.WriteLine("</tr>");
        }

        public override bool Constructed
        {
            get { return true; }
        }

        public override void Tabularize(string tasName)
        {
            foreach(Child ch in m_children.Values) 
            {
                ch.m_type.Tabularize(tasName);
                if (ch.m_type.Constructed)
                {
                    TypeAssigment newTas = m_module.CreateNewTypeAssigment(ch.m_childVarName, ch.m_type, ch.m_comments);
                    ch.m_type = ReferenceType.CreateByName(newTas);
                }

            }
        }
        internal override void PrintHTypeDeclaration(PEREffectiveConstraint cns, StreamWriterLevel h, string typeName, string varName, int lev)
        {
            h.WriteLine("struct {0} {{", typeName);
            foreach (Child ch in m_children.Values)
            {
                h.P(lev + 1);
                ch.m_type.PrintHTypeDeclaration(ch.m_type.PEREffectiveConstraint, h, "", C.ID(ch.m_childVarName), lev + 1);
                if (!(ch.m_type is IA5StringType))
                    h.WriteLine(" {0};", C.ID(ch.m_childVarName));
            }
            if (GetNumberOfOptionalOrDefaultFields() != 0)
            {
                h.P(lev + 1);
                h.WriteLine("struct {");
                foreach (Child ch in m_children.Values)
                {
                    if (ch.m_optional || ch.m_defaultValue!=null)
                    {
                        h.P(lev + 2);
                        h.WriteLine("unsigned int {0}:1;", C.ID(ch.m_childVarName));
                    }
                }
                h.P(lev + 1);
                h.WriteLine("} exist;");
                
            }
            h.P(lev);
            h.Write("}");
        }

        internal override bool DependsOnlyOn(List<TypeAssigment> values)
        {
            foreach (Child ch in m_children.Values)
                if (!ch.m_type.DependsOnlyOn(values))
                    return false;
            return true;
        }

        internal override void PrintCInitialize(PEREffectiveConstraint cns, StreamWriterLevel c, string typeName, string varName, int lev)
        {
            bool topLevel = !varName.Contains("->");
            string prefix = "";
            if (topLevel)
                prefix = varName + "->";
            else
                prefix = varName + ".";

            foreach (Child ch in m_children.Values)
            {
                ch.m_type.PrintCInitialize(ch.m_type.PEREffectiveConstraint, c, "", prefix+C.ID(ch.m_childVarName), lev);
            }
        }

        internal override void PrintHConstraintConstant(StreamWriterLevel h, string name)
        {
            base.PrintHConstraintConstant(h, name);
            foreach (Child ch in m_children.Values)
            {
                ch.m_type.PrintHConstraintConstant(h, name + "_" + ch.m_childVarName);
            }
        }
    }

    public partial class SequenceOrSetValue : Asn1Value
    {
        public OrderedDictionary<string, Asn1Value> m_children = new OrderedDictionary<string, Asn1Value>();
        public SequenceOrSetType Type2
        {
            get
            {
                return (SequenceOrSetType)Type.GetFinalType();
            }
        }

        public override bool IsResolved()
        {
            foreach (Asn1Value v in m_children.Values)
                if (!v.IsResolved())
                    return false;

            return true;
        }

        public SequenceOrSetValue(SequenceOrSetValue o, ITree antlr)
        {
            m_TypeID = Asn1Value.TypeID.SEQUENCE_OR_SET;
            m_module = o.m_module;
            antlrNode = antlr;
            m_type = o.m_type;
            m_children = o.m_children;
        }

        public SequenceOrSetValue(ITree antlrNode, Module module, Asn1Type type, bool checkChildrenOrder)
        {
            m_TypeID = Asn1Value.TypeID.SEQUENCE_OR_SET;
            this.antlrNode = antlrNode;
            m_module = module;
            m_type = type;


            if (antlrNode.Type == asn1Parser.NAMED_VALUE_LIST || antlrNode.Type == asn1Parser.EMPTY_LIST)
            {

                for (int i = 0; i < antlrNode.ChildCount; i++)
                {
                    ITree namedValue = antlrNode.GetChild(i);
                    if (namedValue.Type != asn1Parser.NAMED_VALUE)
                        throw new Exception("Internal Error");

                    string id = namedValue.GetChild(0).Text;

                    if (m_children.ContainsKey(id))
                        throw new SemanticErrorException("Error in line :" + antlrNode.GetChild(i).Line + ". '" + id + "' already exists");

                    if (!Type2.m_children.ContainsKey(id))
                        throw new SemanticErrorException("Error in line :" + antlrNode.GetChild(i).Line + ". '" + id + "' is not a member");

                    Asn1Value val = Asn1Value.CreateFromAntlrAst(namedValue.GetChild(1));

                    m_children.Add(id, val);
                }
            }
            else if (antlrNode.Type == asn1Parser.OBJECT_ID_VALUE)
            {
                //we expect two children, no more no less
                if (antlrNode.ChildCount != 2)
                    throw new SemanticErrorException("Error in line :" + antlrNode.Line + ", col:" + antlrNode.CharPositionInLine + ". Expecting a SEQUENCE variable");
                // first child must be an identifier and nothing else
                ITree ObjListItem1 = antlrNode.GetChild(0);
                if (ObjListItem1.ChildCount != 1)
                    throw new SemanticErrorException("Error in line :" + antlrNode.Line + ", col:" + antlrNode.CharPositionInLine + ". Expecting a SEQUENCE variable");
                ITree identifier = ObjListItem1.GetChild(0);
                if (identifier.Type != asn1Parser.LID)
                    throw new SemanticErrorException("Error in line :" + identifier.Line + ", col:" + identifier.CharPositionInLine + ". Expecting identifier");

                string id = identifier.Text;
                if (m_children.ContainsKey(id))
                    throw new SemanticErrorException("Error in line :" + identifier.Line + ",col:" + identifier.CharPositionInLine + ". '" + id + "' already exists");
                if (!Type2.m_children.ContainsKey(id))
                    throw new SemanticErrorException("Error in line :" + identifier.Line + ",col:" + identifier.CharPositionInLine + ". '" + id + "' is not a member");
                //second child must be an INT or valuereference
                ITree ObjListItem2 = antlrNode.GetChild(1);
                if (ObjListItem2.ChildCount != 1)
                    throw new SemanticErrorException("Error in line :" + antlrNode.Line + ", col:" + antlrNode.CharPositionInLine + ". Expecting a SEQUENCE variable");
                ITree grChild = ObjListItem2.GetChild(0);
                if (grChild.Type == asn1Parser.INT)
                {
                    //SemanticTreeNode numericValue = new SemanticTreeNode(grChild.CharPositionInLine, grChild.Line, grChild.Text, asn1Parser.NUMERIC_VALUE);
                    //numericValue.AddChild(grChild);
                    Asn1Value val = Asn1Value.CreateFromAntlrAst(grChild);
                    m_children.Add(id, val);
                }
                else if (ObjListItem2.GetChild(0).Type == asn1Parser.LID)
                {
                    SemanticTreeNode valueReference = new SemanticTreeNode(grChild.CharPositionInLine, grChild.Line, grChild.Text, asn1Parser.VALUE_REFERENCE);
                    valueReference.AddChild(grChild);
                    Asn1Value val = Asn1Value.CreateFromAntlrAst(valueReference);
                    m_children.Add(id, val);
                }
                else
                    throw new Exception("Internal Error");


            }
            else
                throw new Exception("Internal Error: SequenceOrSetValue called with wrong antlr node type");

            foreach (string typeChildName in Type2.m_children.Keys)
            {
                SequenceOrSetType.Child child = Type2.m_children[typeChildName];
                if (child.m_optional || child.m_default)
                    continue;
                if (!m_children.ContainsKey(typeChildName))
                    throw new SemanticErrorException("Error in line :" + antlrNode.Line + ". Mandatory child '" + typeChildName + "' missing");
            }

            if (checkChildrenOrder)
            {
                //to be implemented
            }

        }

        internal void FixChildrenVars()
        {
            foreach (string id in m_children.Keys)
            {
                Asn1Value childVal = m_children[id];
                if (childVal.IsResolved())
                    continue;

                Asn1Type childType = Type2.m_children[id].m_type;
                m_children[id] = childType.ResolveVariable(childVal);
            }
        }

        public override string ToString()
        {

            System.IO.StringWriter w = new System.IO.StringWriter();

            string key;
            w.Write("{");
            int cnt = m_children.Count;
            for (int i = 0; i < cnt - 1; i++)
            {
                key = m_children.Keys[i];
                w.Write(" " + key + " " + m_children[key].ToString() + ",");
            }

            key = m_children.Keys[cnt - 1];
            w.Write(" " + key + " " + m_children[key].ToString() + " }");

            w.Flush();
            return w.ToString();
        }
        public override bool Equals(object obj)
        {
            SequenceOrSetValue oth = obj as SequenceOrSetValue;
            if (oth == null)
                return false;
            if (oth.m_children.Count != m_children.Count)
                return false;

            for (int i = 0; i < m_children.Count; i++)
            {
                if (m_children.Keys[i] != oth.m_children.Keys[i])
                    return false;
                if (!m_children.Values[i].Equals(oth.m_children.Values[i]))
                    return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            return m_children.GetHashCode();
        }


        public override List<bool> Encode()
        {
            List<bool> ret = new List<bool>();

            SequenceOrSetType myType = m_type.GetFinalType() as SequenceOrSetType;

            if (myType == null)
                throw new Exception("Internal Error");
            if (m_type.IsPERExtensible())
            {
                bool bIHaveExtendedChildren = false;
                foreach (string varName in m_children.Keys)
                {
                    if (myType.m_children[varName].m_extended)
                    {
                        bIHaveExtendedChildren = true;
                        throw new Exception("Unimplemented feature: Sequence/Set extensions are not fully supported. Sorry!");
                    }
                }
                ret.Add(bIHaveExtendedChildren);                    
            }

            //first encode RootComponent Type list items;

            //encode bit-map for optional and defaults
            List<string> vasToBeIgnored = new List<string>();
            foreach (string varName in myType.m_children.Keys)
            {
                SequenceOrSetType.Child ch = myType.m_children[varName];
                if (ch.m_extended)
                    continue;
                if (ch.m_optional)
                {
                    ret.Add(m_children.ContainsKey(varName));
                }
                else if (ch.m_defaultValue != null)
                {
                    if (m_children.ContainsKey(varName))
                    {
                        if (ch.m_defaultValue.Equals(m_children[varName]))
                        {
                            ret.Add(false); //18.5 CANONICAL encoding
                            vasToBeIgnored.Add(varName);
                        }
                        else
                            ret.Add(true);
                    }
                    else
                    {
                        ret.Add(false); 
                    }
                }
            }
            //encode non extended children
            foreach (string varName in myType.m_children.Keys)
            {
                SequenceOrSetType.Child ch = myType.m_children[varName];
                if (ch.m_extended || vasToBeIgnored.Contains(varName))
                    continue;
                if (m_children.ContainsKey(varName))
                    ret.AddRange(m_children[varName].Encode());
            }
            
            return ret;
        }
    }

}