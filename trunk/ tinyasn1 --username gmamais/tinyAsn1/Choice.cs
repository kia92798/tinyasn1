using System;
using System.Collections.Generic;
using System.Text;
using Antlr.Runtime.Tree;
using Antlr.Runtime;
using MB = System.Reflection.MethodBase;

namespace tinyAsn1
{

    public partial class ChoiceType : Asn1Type
    {
        public OrderedDictionary<string, ChoiceChild> m_children = new OrderedDictionary<string, ChoiceChild>();
        public bool m_extMarkPresent = false;
        public ExceptionSpec m_exceptionSpec;
        public bool m_extMarkPresent2 = false;

        string _cid_none = null;
        public string CID_NONE
        {
            get
            {
                if (_cid_none == null)
                {
                    string[] items = UniquePath.Split('/');
                    _cid_none = items[items.Length - 1] + "_NONE";
                }
                return C.ID(_cid_none);
            }
            set
            {
                _cid_none = C.ID(value);
            }
        }

        public override string Name { get { return "CHOICE"; } }

        //Choices do not have default tag!
        public override Asn1Type.Tag UniversalTag        { get { return null; } }

        public override IEnumerable<T> GetMySelfAndAnyChildren<T>()
        {
            if (this is T)
                yield return this as T;
            foreach (ChoiceChild ch in m_children.Values)
            {
                foreach (T grCh in ch.m_type.GetMySelfAndAnyChildren<T>())
                    yield return grCh;
            }
        }

        public override IEnumerable<KeyValuePair<string, T>> GetMySelfAndAnyChildrenWithPath<T>(string pathUpToHere)
        {
            if (this is T)
                yield return new KeyValuePair<string, T>(pathUpToHere, this as T);

            foreach (ChoiceChild ch in m_children.Values)
            {
                foreach (KeyValuePair<string, T> grCh in ch.m_type.GetMySelfAndAnyChildrenWithPath<T>(pathUpToHere + "/" + ch.m_childVarName))
                    yield return grCh;
            }
        }

        //	^(CHOICE_TYPE choiceItemsList choiceExtensionBody?)
        static public new ChoiceType CreateFromAntlrAst(ITree tree)
        {
            ChoiceType ret = Asn1CompilerInvokation.Instance.Factory.CreateChoiceType();
            for (int i = 0; i < tree.ChildCount; i++)
            {
                ITree child = tree.GetChild(i);
                switch (child.Type)
                {
                    case asn1Parser.CHOICE_ITEM:
                        ChoiceChild ch = ChoiceChild.CreateFromAntlrAst(child, null, false);
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
                        ChoiceChild ch = ChoiceChild.CreateFromAntlrAst(child, null, !ret.m_extMarkPresent2);
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
            int? version = null;
            for (int i = 0; i < tree.ChildCount; i++)
            {
                ITree child = tree.GetChild(i);
                switch (child.Type)
                {
                    case asn1Parser.INT:
                        version = int.Parse(child.Text);
                        break;
                    case asn1Parser.CHOICE_ITEM:
                        ChoiceChild ch = ChoiceChild.CreateFromAntlrAst(child, version, true);
                        if (ret.m_children.ContainsKey(ch.m_childVarName))
                            throw new SemanticErrorException(ch.m_childVarName + " has alrady been defined. Line: " + child.Line);
                        ret.m_children.Add(ch.m_childVarName, ch);
                        break;
                    default:
                        throw new Exception("Unkown child: " + child.Text + " for node: " + tree.Text);
                }
            }
        }


        internal override bool SemanticAnalysisFinished()
        {

            foreach (ChoiceChild ch in m_children.Values)
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
                foreach (ChoiceChild ch in m_children.Values)
                {
                    if (ch.m_type.m_tag != null)
                    {
                        m_AutomaticTaggingTransformationCanBeApplied = false;
                        break;
                    }
                }
                m_AutomaticTaggingTransformationCanBeApplied = m_AutomaticTaggingTransformationCanBeApplied && m_module.m_taggingMode == TaggingMode.AUTOMATIC;
            }


            foreach (ChoiceChild ch in m_children.Values)
                ch.DoSemanticAnalysis();

            if (m_exceptionSpec != null && !m_exceptionSpec.isResolved())
                m_exceptionSpec.DoSemanticAnalysis();

        }

        public override void PerformAutomaticTagging()
        {
            if (!Asn1CompilerInvokation.EnterRecursiveFunc(MB.GetCurrentMethod().Name, this))
                return;

            int curTag = 0;
            foreach (ChoiceChild ch in m_children.Values)
            {
                if (m_AutomaticTaggingTransformationCanBeApplied)
                {

                    ch.m_type.m_tag = Asn1CompilerInvokation.Instance.Factory.CreateAsn1TypeTag();
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

            Asn1CompilerInvokation.LeaveRecursiveFunc(MB.GetCurrentMethod().Name, this);

        }



        internal override Asn1Value ResolveVariable(Asn1Value val)
        {
            string referenceId = "";
            ChoiceValue sqVal = val as ChoiceValue;
            switch (val.antlrNode.Type)
            {
                case asn1Parser.CHOICE_VALUE:
                    if (sqVal == null)
                        return Asn1CompilerInvokation.Instance.Factory.CreateChoiceValue(val.antlrNode, m_module, this);
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
                            case Asn1Value.TypeID.CHOICE:
                                if (tmp.IsResolved())
                                {
                                    if (tmp.Type.GetFinalType() == this)
                                        return Asn1CompilerInvokation.Instance.Factory.CreateChoiceValue(tmp as ChoiceValue, val.antlrNode.GetChild(0));
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
                    throw new SemanticErrorException("Error in line : " + val.antlrNode.Line + ". Expecting CHOICE variable");
            }
        }
        public override void ResolveConstraints()
        {
            if (AreConstraintsResolved())
                return;
            foreach (ChoiceChild ch in m_children.Values)
                ch.m_type.ResolveConstraints();
            base.ResolveConstraints();

        }
        public override void CheckDefaultValues()
        {
            foreach (ChoiceChild ch in m_children.Values)
                ch.m_type.CheckDefaultValues();
        }



        public override bool AreConstraintsResolved()
        {
            if (!Asn1CompilerInvokation.EnterRecursiveFunc(MB.GetCurrentMethod().Name, this))
                return true;

            bool ret = true;
            foreach (ChoiceChild ch in m_children.Values)
                if (!ch.m_type.AreConstraintsResolved())
                {
                    ret = false;
                }

            ret = ret && base.AreConstraintsResolved();

            Asn1CompilerInvokation.LeaveRecursiveFunc(MB.GetCurrentMethod().Name, this);

            return ret;

        }
        
        public override bool isValueAllowed(Asn1Value val)
        {
            if (!base.isValueAllowed(val))
                return false;
            ChoiceValue v = val as ChoiceValue;
            if (v == null)
                throw new Exception("Internal Error");

            return m_children[v.AlternativeName].m_type.isValueAllowed(v.Value);
        }

        static List<int> m_allowedTokens = new List<int>(new int[]{ asn1Parser.CONSTRAINT, asn1Parser.EXCEPTION_SPEC, asn1Parser.EXT_MARK, 
                asn1Parser.UNION_SET, asn1Parser.UNION_SET_ALL_EXCEPT, asn1Parser.INTERSECTION_SET,
                asn1Parser.INTERSECTION_ELEMENT, asn1Parser.VALUE_RANGE_EXPR, asn1Parser.SUBTYPE_EXPR, 
                asn1Parser.WITH_COMPONENTS_CONSTR});
        static List<int> m_stopList = new List<int>(new int[] { asn1Parser.VALUE_RANGE_EXPR, asn1Parser.SUBTYPE_EXPR, 
            asn1Parser.WITH_COMPONENTS_CONSTR, asn1Parser.EXCEPTION_SPEC });

        protected override IEnumerable<int> AllowedTokensInConstraints { get { return m_allowedTokens; } }
        protected override IEnumerable<int> StopTokensInConstraints { get { return m_stopList; } }



        public override void PrintAsn1(StreamWriterLevel o, int lev)
        {
            ChoiceChild ch;
            bool extMark1Printed = false;
            bool extMark2Printed = false;
            if (m_tag != null)
                m_tag.PrintAsn1(o, lev);
            o.WriteLine(Name + " {");
            for (int i = 0; i < m_children.Values.Count - 1; i++)
            {
                ch = m_children.Values[i];
                if (m_extMarkPresent && !extMark1Printed && ch.m_extended)
                {
                    extMark1Printed = true;
                    o.P(lev + 1);
                    o.Write("...");
                    if (m_exceptionSpec != null)
                        o.Write(m_exceptionSpec.ToString());
                    o.WriteLine(",");
                }
                if (m_extMarkPresent2 && extMark1Printed && !extMark2Printed && !ch.m_extended)
                {
                    extMark2Printed = true;
                    o.P(lev + 1);
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
                    o.P(lev + 1);
                    o.Write("...");
                    if (m_exceptionSpec != null)
                        o.Write(m_exceptionSpec.ToString());
                    o.WriteLine(",");
                }
                if (m_extMarkPresent2 && extMark1Printed && !extMark2Printed && !ch.m_extended)
                {
                    extMark2Printed = true;
                    o.P(lev + 1);
                    o.WriteLine("...,");
                }
                ch.PrintAsn1(o, lev + 1);
                o.WriteLine();
            }
            if (m_extMarkPresent && !extMark1Printed)
            {
                extMark1Printed = true;
                o.P(lev + 1);
                o.Write(",...");
                if (m_exceptionSpec != null)
                    o.WriteLine(m_exceptionSpec.ToString());
            }

            if (m_extMarkPresent2 && extMark1Printed && !extMark2Printed)
            {
                extMark2Printed = true;
                o.P(lev + 1);
                o.WriteLine(",...");
            }

            o.P(lev);
            o.Write("}");
            PrintAsn1Constraints(o);
        }
        
        internal List<Asn1Type.TagSequence> getChildrenTags()
        {
            List<TagSequence> ret = new List<TagSequence>();
            foreach (ChoiceChild ch in m_children.Values)
            {
                ChoiceType chChild = ch.m_type.GetFinalType() as ChoiceType;
                if (chChild != null && !ch.m_type.IsTagged())
                    ret.AddRange(chChild.getChildrenTags());
                else
                    ret.Add(ch.m_type.Tags);
            }
            return ret;
        }

        public override void CheckChildrensTags()
        {
            if (!Asn1CompilerInvokation.EnterRecursiveFunc(MB.GetCurrentMethod().Name, this))
                return;

            

            List<TagSequence> chTags = getChildrenTags();

            for (int i = 0; i < chTags.Count; i++)
                for (int j = i + 1; j < chTags.Count; j++)
                {
                    if (chTags[i].Equals(chTags[j]))
                    {

                        string err = string.Format("Error: Tag clash for type defined in line {0}." +
                        "The type has two children with the same tag. " +
                        "The children that clashes are located in lines: {1} and {2}. Use AUTOMATIC TAGS!", antlrNode.Line, chTags[i].m_tags[0].m_type.antlrNode.Line, chTags[j].m_tags[0].m_type.antlrNode.Line);
                        throw new SemanticErrorException(err);
                    }

                    //
                }

            foreach (ChoiceChild ch in m_children.Values)
            {
                ch.m_type.CheckChildrensTags();
            }
            
            Asn1CompilerInvokation.LeaveRecursiveFunc(MB.GetCurrentMethod().Name, this);

        }
        
        public override bool Compatible(Asn1Type other)
        {
            ChoiceType o = other.GetFinalType() as ChoiceType;
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
            foreach (ChoiceChild child in m_children.Values)
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

        public override long minBitsInPER(PEREffectiveConstraint cns)
        {
            if (!Asn1CompilerInvokation.EnterRecursiveFunc(MB.GetCurrentMethod().Name, this))
                return 0;

            long ret = 0;
            if (IsPERExtensible())
                ret++;
            UInt16 nRootChildren=0;
            long smallestChild = long.MaxValue;
            foreach (ChoiceChild ch in m_children.Values)
            {
                if (ch.m_extended)
                    continue;
                if (ch.m_type.MinBitsInPER < smallestChild)
                    smallestChild = ch.m_type.MinBitsInPER;
                nRootChildren++;
            }
            ret+=PER.GetNumberOfBitsForNonNegativeInteger(nRootChildren);
            ret += smallestChild;

            Asn1CompilerInvokation.LeaveRecursiveFunc(MB.GetCurrentMethod().Name, this);

            return ret;
        }

        public override long maxBitsInPER(PEREffectiveConstraint cns)
        {
            if (!Asn1CompilerInvokation.EnterRecursiveFunc(MB.GetCurrentMethod().Name, this))
                return -1;

            long ret = 0;
            if (IsPERExtensible())
                ret = -1;
            else
            {
                UInt16 nRootChildren = 0;
                long largestChild = 0;
                foreach (ChoiceChild ch in m_children.Values)
                {
                    if (ch.m_extended)
                        continue;
                    if (ch.m_type.MaxBitsInPER > largestChild)
                        largestChild = ch.m_type.MaxBitsInPER;
                    nRootChildren++;
                }
                ret += PER.GetNumberOfBitsForNonNegativeInteger(nRootChildren);
                ret += largestChild;
            }

            Asn1CompilerInvokation.LeaveRecursiveFunc(MB.GetCurrentMethod().Name, this);

            return ret;
        }
        public override bool Constructed
        {
            get { return true; }
        }


        
        internal override void PrintHTypeDeclaration(PEREffectiveConstraint cns, StreamWriterLevel h, string typeName, string varName, int lev)
        {
//            h.WriteLine("struct {0} {{", typeName);
            h.WriteLine("struct {");
            h.P(lev + 1);
            h.WriteLine("enum {");
//            h.WriteLine("enum {0}_PR {{", typeName);
            h.P(lev + 2);
            h.WriteLine("{0},	/* No components present */", CID_NONE);
//            h.WriteLine("{0}_NONE,	/* No components present */", typeName);
            int i = 0;
            foreach (ChoiceChild ch in m_children.Values)
            {
                h.P(lev + 2);
//                h.Write("{0}_{1}", typeName, ch.m_childVarName);
                h.Write("{0}", ch.CID);
                if (i < m_children.Values.Count - 1)
                    h.WriteLine(",");
                else
                    h.WriteLine();
                i++;
            }
            h.P(lev + 1);
            h.WriteLine("} kind;");


            h.P(lev + 1);
            h.WriteLine("union {");
//            h.WriteLine("union {0}_data {{", typeName);
            foreach (ChoiceChild ch in m_children.Values)
            {
                h.WriteComment(ch.m_comments, lev + 2);

                h.P(lev + 2);
                ch.m_type.PrintHTypeDeclaration(ch.m_type.PEREffectiveConstraint, h, 
                    typeName + "_" + C.ID(ch.m_childVarName), 
                    C.ID(ch.m_childVarName), lev + 1);
                if (!(ch.m_type is IA5StringType))
                    h.WriteLine(" {0};", C.ID(ch.m_childVarName));
            }
            h.P(lev + 1);
            h.WriteLine("} u;");


            h.P(lev);
            h.Write("}");
        }
        internal override bool DependsOnlyOn(List<string> values)
        {
            foreach (ChoiceChild ch in m_children.Values)
                if (!ch.m_type.DependsOnlyOn(values))
                    return false;
            return true;
        }

        public override bool ContainsTypeAssigment(string typeAssigment)
        {
            foreach (ChoiceChild ch in m_children.Values)
                if (ch.m_type.ContainsTypeAssigment(typeAssigment))
                    return true;
            return false;
        }

        internal override List<string> TypesIDepend()
        {
            List<string> ret = new List<string>();

            foreach (ChoiceChild ch in m_children.Values)
            {
                foreach (string d in ch.m_type.TypesIDepend())
                {
                    if (!ret.Contains(d))
                        ret.Add(d);
                }
            }

            return ret;
        }

        internal override void PrintCInitialize(PEREffectiveConstraint cns, Asn1Value defauleVal, StreamWriterLevel c, string typeName, string varName, int lev, int arrayDepth)
        {
            bool topLevel = !varName.Contains("->");
            string prefix = "";
            if (topLevel)
                prefix = varName + "->";
            else
                prefix = varName + ".";

            c.P(lev); c.WriteLine("{0}kind = {1};", prefix, CID_NONE);
//            c.P(lev); c.WriteLine("{0}kind = {1}_NONE;", prefix, typeName);
        }

        internal override void PrintHConstraintConstant(StreamWriterLevel h, string name)
        {
            h.WriteLine("#define ERR_{0}\t\t{1} /* {2} */", C.ID(name), Asn1CompilerInvokation.Instance.ConstraintErrorID++, Constraints);
//            base.PrintHConstraintConstant(h, name);
            foreach (ChoiceChild ch in m_children.Values)
            {
                ch.m_type.PrintHConstraintConstant(h, C.ID(name) + "_" + C.ID(ch.m_childVarName));
            }
        }
        internal override void VarsNeededForIsConstraintValid(int lev, OrderedDictionary<string, CLocalVariable> existingVars)
        {
            foreach (ChoiceChild ch in m_children.Values)
            {
                ch.m_type.VarsNeededForIsConstraintValid(lev, existingVars);
            }
        }


        internal override void PrintCIsConstraintValid(PEREffectiveConstraint cns, StreamWriterLevel c, string errorCode, string typeName, string varName, int lev, int arrayDepth)
        {
            string varName2 = varName;
            if (!varName.Contains("->"))
                varName2 += "->";
            else
                varName2 += ".";

            c.P(lev);
            c.WriteLine("switch({0}kind)", varName2);
            c.P(lev); c.WriteLine("{");
            foreach (ChoiceChild ch in m_children.Values)
            {
//                c.P(lev); c.WriteLine("case {0}_{1}:", typeName, ch.m_childVarName);
                c.P(lev); c.WriteLine("case {0}:", ch.CID);
                ch.m_type.PrintCIsConstraintValid(ch.m_type.PEREffectiveConstraint, c, errorCode + "_" + ch.m_childVarName,
                    typeName + "_" + C.ID(ch.m_childVarName), varName2 + "u." + C.ID(ch.m_childVarName), lev + 1, arrayDepth);
                c.P(lev + 1);
                c.WriteLine("break;");
            }
            c.P(lev);
            c.WriteLine("default:");
            c.P(lev+1);
            c.WriteLine("*pErrCode = ERR_{0};",C.ID(errorCode));
            c.P(lev + 1);
            c.WriteLine("return FALSE;");
            c.P(lev); c.WriteLine("}");
                        
        }
/*
        internal override void PrintCIsConstraintValidAux(StreamWriterLevel c)
        {
            base.PrintCIsConstraintValidAux(c);
            foreach (ChoiceChild ch in m_children.Values)
                ch.m_type.PrintCIsConstraintValidAux(c);
        }
*/

        internal override void VarsNeededForEncode(PEREffectiveConstraint cns, int arrayDepth, OrderedDictionary<string, CLocalVariable> existingVars)
        {
            foreach (ChoiceChild ch in m_children.Values)
            {
                ch.m_type.VarsNeededForEncode(ch.m_type.PEREffectiveConstraint, arrayDepth, existingVars);
            }
        }

        internal override void PrintCEncode(PEREffectiveConstraint cns, StreamWriterLevel c, string errorCode, string varName, int lev)
        {
            int largestIndex = -1;
            foreach (string v in m_children.Keys)
            {
                if (m_children[v].m_extended)
                    continue;
                largestIndex++;
            }

            string varName2 = varName;
            if (!varName.Contains("->"))
                varName2 += "->";
            else
                varName2 += ".";

            c.P(lev);
            c.WriteLine("switch({0}kind)", varName2);
            c.P(lev); c.WriteLine("{");
            int choiceIndex = 0;
            foreach (ChoiceChild ch in m_children.Values)
            {
                c.P(lev); c.WriteLine("case {0}:", ch.CID);
                c.P(lev + 1);
                c.WriteLine("BitStream_EncodeConstraintWholeNumber(pBitStrm, {0}, {1}, {2});", choiceIndex, 0, largestIndex);
                ch.m_type.PrintCEncode(ch.m_type.PEREffectiveConstraint, c, errorCode + "_" + ch.m_childVarName,
                    varName2 + "u." + C.ID(ch.m_childVarName), lev + 1);

                c.P(lev + 1);
                c.WriteLine("break;");
                choiceIndex++;
            }
            c.P(lev); c.WriteLine("}");
        }

        internal override void VarsNeededForDecode(PEREffectiveConstraint cns, int arrayDepth, OrderedDictionary<string, CLocalVariable> existingVars)
        {
            if (!existingVars.ContainsKey("nChoiceIndex"))
                existingVars.Add("nChoiceIndex", new CLocalVariable("nChoiceIndex", "asn1SccSint", 0, "0"));
            foreach (ChoiceChild ch in m_children.Values)
            {
                ch.m_type.VarsNeededForDecode(ch.m_type.PEREffectiveConstraint, arrayDepth, existingVars);
            }
        }

        internal override void PrintCDecode(PEREffectiveConstraint cns, StreamWriterLevel c, string varName, int lev)
        {
            string varName2 = varName;
            if (!varName.Contains("->"))
                varName2 += "->";
            else
                varName2 += ".";

            int largestIndex = -1;
            foreach (string v in m_children.Keys)
            {
                if (m_children[v].m_extended)
                    continue;
                largestIndex++;
            }

            
            c.P(lev);
            c.WriteLine("if (!BitStream_DecodeConstraintWholeNumber(pBitStrm, &nChoiceIndex, {0}, {1})) {{", 0, largestIndex);
            c.P(lev + 1);
            c.WriteLine("*pErrCode = ERR_INSUFFICIENT_DATA;");
            c.P(lev + 1);
            c.WriteLine("return FALSE;");
            c.P(lev);
            c.WriteLine("}");
            c.P(lev);
            c.WriteLine("switch(nChoiceIndex)");
            c.P(lev); c.WriteLine("{");
            int choiceIndex = 0;
            foreach (ChoiceChild ch in m_children.Values)
            {
                c.P(lev); c.WriteLine("case {0}:", choiceIndex);
                ch.m_type.PrintCDecode(ch.m_type.PEREffectiveConstraint, c, 
                    varName2 + "u." + C.ID(ch.m_childVarName), lev + 1);


                c.P(lev + 1);
                c.WriteLine("{0}kind = {1};", varName2, ch.CID);
                c.P(lev + 1);
                c.WriteLine("break;");
                choiceIndex++;
            }
            c.P(lev); c.WriteLine("}");

        }

    }

    public partial class ChoiceChild 
    {
        public string m_childVarName = "";
        public Asn1Type m_type;
        public bool m_extended = false;
        public int? m_version = null;
        public List<string> m_comments = new List<string>();
        public ITree antlrNode = null;

        string _cid = null;
        public string CID
        {
            get
            {
                if (_cid == null)
                    return C.ID(m_childVarName)+ "_PRESENT";
                return _cid;
            }
            set
            {
                _cid = C.ID(value);
            }
        }


        public void PrintAsn1(StreamWriterLevel o, int lev)
        {
            o.P(lev);
            if (m_version != null)
                o.Write("[[{0}: ", m_version);
            o.Write(m_childVarName); o.Write(" ");
            m_type.PrintAsn1(o, lev);
            if (m_version != null)
                o.Write("]]", m_version);
        }

        //^(CHOICE_ITEM identifier type )
        static public ChoiceChild CreateFromAntlrAst(ITree tree, int? version, bool extended)
        {
            ChoiceChild ret = Asn1CompilerInvokation.Instance.Factory.CreateChoiceChildType();
            ret.m_version = version;
            ret.m_extended = extended;
            ret.antlrNode = tree;

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
                    //case asn1Parser.SPECIAL_COMMENT:
                    //    ret.m_comments.Add(child.Text.Replace("--@", "").Replace("\r", "").Replace("\n", "").Replace("--", ""));
                    //    break;
                    default:
                        throw new Exception("Unkown child: " + child.Text + " for node: " + tree.Text);
                }
            }

            return ret;

        }

        internal bool SemanticAnalysisFinished()
        {
            return m_type.SemanticAnalysisFinished();
        }

        public void DoSemanticAnalysis()
        {
            m_type.DoSemanticAnalysis();
        }


        internal bool Compatible(ChoiceChild other)
        {
            return m_childVarName==other.m_childVarName && m_type.Compatible(other.m_type);
        }

    }


    public partial class ChoiceValue : Asn1Value
    {
        public ChoiceType ChoiceType
        {
            get { return (ChoiceType)m_type.GetFinalType(); }
        }
        Asn1Value m_value;
        public virtual Asn1Value Value
        {
            get { return m_value; }
        }

        string m_alternativeName;
        public virtual string AlternativeName
        {
            get { return m_alternativeName; }
        }
        public ChoiceValue(ChoiceValue o, ITree antlr)
        {
            m_TypeID = Asn1Value.TypeID.CHOICE;
            m_module = o.m_module;
            antlrNode = antlr;
            m_type = o.m_type;
            m_value = o.m_value;
            m_alternativeName = o.m_alternativeName;
        }

        public ChoiceValue(ITree antlrNode, Module module, Asn1Type type)
        {
            m_TypeID = Asn1Value.TypeID.CHOICE;
            this.antlrNode = antlrNode;
            m_module = module;
            m_type = type;

            if (antlrNode.Type != asn1Parser.CHOICE_VALUE)
                throw new Exception("Internal Error: ChoiceValue called with wrong antlr node type");


            m_alternativeName = antlrNode.GetChild(0).Text;

            m_value = Asn1Value.CreateFromAntlrAst(antlrNode.GetChild(1));

            if (!ChoiceType.m_children.ContainsKey(m_alternativeName))
                throw new SemanticErrorException("Error in line :" + antlrNode.Line + ". '" + m_alternativeName + "' is not a member of the choice");
        }
        public override bool IsResolved()
        {
            return m_value.IsResolved();
        }


        internal void FixChildrenVars()
        {
            if (IsResolved())
                return;

            Asn1Type childType = ChoiceType.m_children[m_alternativeName].m_type;
            m_value = childType.ResolveVariable(m_value);
        }

        public override string ToString()
        {
            return m_alternativeName + ":" + m_value.ToString();
        }


        public override bool Equals(object obj)
        {
            ChoiceValue oth = obj as ChoiceValue;
            if (oth == null)
                return false;
            return (oth.m_value == m_value) && (oth.m_alternativeName == m_alternativeName);
        }

        public override int GetHashCode()
        {
            return m_value.GetHashCode();
        }
        
        public override List<bool> Encode()
        {
            List<bool> ret = new List<bool>();
            ChoiceType myType = m_type.GetFinalType() as ChoiceType;
            if (myType == null)
                throw new Exception("Internal Error");
            ChoiceChild myChildType = myType.m_children[AlternativeName];

            if (myChildType.m_extended)
                throw new Exception("Unimplemented feature: Choice extensions are not fully supported. Sorry!");
            if (m_type.IsPERExtensible())
                ret.Add(myChildType.m_extended);

            int choiceIndex = myType.m_children.Keys.IndexOf(AlternativeName);
            int largestIndex = -1;
            foreach (string v in myType.m_children.Keys)
            {
                if (myType.m_children[v].m_extended)
                    continue;
                largestIndex++;
            }
            
            if (largestIndex>0)
                ret.AddRange(PER.EncodeConstraintWholeNumber(choiceIndex,0,largestIndex));
            ret.AddRange(Value.Encode());
            

            return ret;
        }
        internal override void PrintC(StreamWriterLevel c, int lev)
        {
            c.WriteLine("{");
            c.P(lev + 1);
            c.WriteLine(".kind = {0},", ChoiceType.m_children[m_alternativeName].CID);
            c.P(lev + 1);
            c.Write(".u = {{ .{0}=", ChoiceType.m_children[m_alternativeName].CID.Replace("_PRESENT", ""));
            m_value.PrintC(c, lev + 1);
            
            c.WriteLine();
            c.P(lev);
            c.Write("} }");
        }
    }


}
