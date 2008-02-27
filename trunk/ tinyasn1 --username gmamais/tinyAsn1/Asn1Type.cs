using System;
using System.Collections.Generic;
using System.Text;
using Antlr.Runtime.Tree;

namespace tinyAsn1
{

    public partial class Asn1Type
    {
//public and internal members
        internal ITree antlrNode;
        public Module m_module;
        public Tag m_tag;
        public List<ITree> m_AntlrConstraints = new List<ITree>();
        public List<IConstraint> m_constraints = new List<IConstraint>();


        public virtual IEnumerable<T> GetMySelfAndAnyChildren<T>() where T : Asn1Type 
        {
         
            if (this is T)
                yield return this as T;
            yield break;
        }

        public virtual IEnumerable<KeyValuePair<string,T>> GetMySelfAndAnyChildrenWithPath<T>(string pathUpToHere) where T : Asn1Type
        {
            if (this is T)
                yield return new KeyValuePair<string,T>(pathUpToHere, this as T);
            yield break;
        }

        string _uniquePath = "";

        public string UniquePath
        {
            get { return _uniquePath; }
            set { _uniquePath = value; }
        }
        

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
            internal Asn1Type m_type;
            public TagClass m_class = TagClass.CONTEXT_SPECIFIC;
            public TaggingMode m_taggingMode = TaggingMode.AUTOMATIC; //invalid value

            public Tag()
            {
            }
            public Tag(TagClass Class, int tagValue, TaggingMode taggingMode, Asn1Type type)
            {
                m_class = Class;
                m_tag = tagValue;
                m_taggingMode = taggingMode;
                m_type = type;
            }
            public override int GetHashCode()
            {
                return m_tag;
            }

            public void PrintAsn1(StreamWriterLevel o, int lev)
            {
                o.Write("[");
                if (m_class != TagClass.CONTEXT_SPECIFIC)
                {
                    o.Write(m_class);
                    o.Write(" ");
                }
                o.Write(m_tag);
                o.Write("] ");
                o.Write(m_taggingMode);
                o.Write(" ");

            }
            private Asn1Value valReference = null;
            //(TYPE_TAG (UNIVERSAL | APPLICATION | PRIVATE)? INT ( IMPLICIT | EXPLICIT)?)
            static public Tag CreateFromAntlrAst(ITree tree)
            {
                Tag ret = new Tag();
                for (int i = 0; i < tree.ChildCount; i++)
                {
                    ITree child = tree.GetChild(i);
                    switch (child.Type)
                    {
                        case asn1Parser.INT:
                            ret.m_tag = int.Parse(child.Text);
                            if (ret.m_tag < 0)
                                throw new SemanticErrorException("Error Line:" + child.Line + " tags cannot be negative");
                            break;
                        case asn1Parser.VALUE_REFERENCE:
                            ret.valReference = Asn1Value.CreateFromAntlrAst(child);
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
                            ret.m_taggingMode = TaggingMode.IMPLICIT;
                            break;
                        case asn1Parser.EXPLICIT:
                            ret.m_taggingMode = TaggingMode.EXPLICIT;
                            break;
                        default:
                            throw new Exception("Unkown child: " + child.Text + " for node: " + tree.Text);
                    }
                }
                return ret;
            }
            public virtual void DoSemanticAnalysis()
            {
                if (SemanticAnalysisFinished())
                    return;

                if (valReference != null)
                {
                    IntegerType dummy = new IntegerType();
                    dummy.m_module = m_type.m_module;
                    valReference = dummy.ResolveVariable(valReference);
                    if (valReference.IsResolved())
                    {
                        m_tag = (int)((IntegerValue)valReference).Value;
                        valReference = null;
                    }
                }
                if (m_taggingMode == TaggingMode.AUTOMATIC)
                {
                    if (m_type.m_module.m_taggingMode == TaggingMode.EXPLICIT)
                        m_taggingMode = TaggingMode.EXPLICIT;
                    else
                    {
                        if (!m_type.IsTagged())
                        {
                            if ((m_type is ChoiceType) || ((m_type is ReferenceType) && (m_type.GetFinalType() is ChoiceType)))
                                m_taggingMode = TaggingMode.EXPLICIT;
                            else
                                m_taggingMode = TaggingMode.IMPLICIT;
                        }
                        else
                            m_taggingMode = TaggingMode.IMPLICIT;
                    }
                }
            }
            public virtual bool SemanticAnalysisFinished()
            {
                if (m_taggingMode == TaggingMode.AUTOMATIC)
                    return false;
                if (valReference != null)
                    return false;
                return true;
            }
            public override bool Equals(object obj)
            {
                Tag o = obj as Tag;
                if (o == null)
                    return false;

                return o.m_class == m_class && o.m_tag == m_tag;
            }
        }

        public partial class TagSequence
        {
            public List<Tag> m_tags = new List<Tag>();

            public override bool Equals(object obj)
            {
                TagSequence o = obj as TagSequence;
                if (o == null)
                    return false;
                // new implementation
                // if first tag matches return true else return false;
                if (m_tags.Count == 0 || o.m_tags.Count==0)
                    throw new Exception("Internal error");

                return m_tags[0].Equals(o.m_tags[0]);

/*
                // old implementation: Two tag sequences are identical if every tag matches
                if (m_tags.Count != o.m_tags.Count)
                    return false;
                for (int i = 0; i < m_tags.Count; i++)
                    if (!m_tags[i].Equals(o.m_tags[i]))
                        return false;

                return true;
 */ 
            }
            public override int GetHashCode()
            {
                return m_tags.GetHashCode();
            }
            public override string ToString()
            {
                string ret = "";
                foreach (Tag t in m_tags)
                    ret += "[" + (t.m_class != Tag.TagClass.CONTEXT_SPECIFIC ? t.m_class.ToString() : "") + " " + t.m_tag + "]";
                return ret;
            }
        }

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

        static public Asn1Type CreateFromAntlrAst(ITree tree)
        {
            Asn1Type ret = null;
            Tag tag = null;
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
                        ret = ObjectIdentifier.CreateFromAntlrAst(child);
                        break;
                    case asn1Parser.RELATIVE_OID:
                        throw new SemanticErrorException("Error line: " + child.Line + ", col: " + child.CharPositionInLine + ". RELATIVE-OID are not supported. Use OBJECT IDENTIFIER instead");
                    case asn1Parser.OCTECT_STING:
                        ret = new OctetStringType();
                        break;
                    case asn1Parser.IA5String:
                        ret = new IA5StringType();
                        break;
                    case asn1Parser.NumericString:
                        ret = new NumericStringType();
                        break;
                    case asn1Parser.UTCTime:
                        ret = new UTCTimeType();
                        break;
                    case asn1Parser.GeneralizedTime:
                        ret = new GeneralizedTimeType();
                        break;
                    case asn1Parser.PrintableString:
                    case asn1Parser.VisibleString:
                    case asn1Parser.TeletexString:
                    case asn1Parser.VideotexString:
                    case asn1Parser.GraphicString:
                    case asn1Parser.GeneralString:
                    case asn1Parser.UniversalString:
                    case asn1Parser.BMPString:
                    case asn1Parser.UTF8String:
                        ret = new IA5StringType();
                        break;

                    //                            throw new SemanticErrorException("Error line: " + child.Line + ", col: " + child.CharPositionInLine + ". "+child.Text+" is currently not supported.");
                    case asn1Parser.SELECTION_TYPE:
                        throw new SemanticErrorException("Error line: " + child.GetChild(0).Line + ", col: " + child.GetChild(0).CharPositionInLine + ". Selection types are currently not supported.");
                    case asn1Parser.CONSTRAINT:
                        //if (ret != null)
                        //    ret.m_constraints.Add(Constraint.CreateFromAntlrAst(child));
                        ret.m_AntlrConstraints.Add(child);
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
                if (ret.m_tag != null)
                    ret.m_tag.m_type = ret;
            }
            return ret;
        }

        public virtual Tag UniversalTag { get { return null; } }

        public virtual TagSequence Tags
        {
            get
            {
                TagSequence ret = new TagSequence();

                if (m_tag != null)
                {
                    ret.m_tags.Add(m_tag);
                    if (m_tag.m_taggingMode == TaggingMode.IMPLICIT)
                        return ret;
                }

                if (UniversalTag != null)
                    ret.m_tags.Add(UniversalTag);
                return ret;
            }
        }

        public virtual bool IsTagged()
        {
            return m_tag != null;
        }

        /// <summary>
        /// SEQUENCE, SET, CHOICE, SEQUENCE OF and SET OF must override this method.
        /// </summary>
        public virtual void CheckDefaultValues()
        {
        }

        /// <summary>
        /// SEQUENCE, SET, CHOICE, SEQUENCE OF and SET OF must override this method.
        /// </summary>
        public virtual void CheckChildrensTags()
        {
        }

        /// <summary>
        /// This method takes as input an unresolved variable and 
        /// either returns the same variable if resolving can not be done in this round
        /// or returns a new resolved variable
        /// or throws a SemanticError Exception if resolving cannot be done due to semantic error 
        /// </summary>
        /// <param name="val">value to be resolved</param>
        /// <returns>the resolved variable or the same variable as input</returns>
        internal virtual Asn1Value ResolveVariable(Asn1Value val)
        {
            throw new Exception("Internal Error: abstract function call");
        }

        /*
         * This method does not change the state of the object
         * Returns TRUE if SemanticCheck has finished
         *         FALSE if SemanticCheck must be also called in a next round
         */
        internal virtual bool SemanticAnalysisFinished()
        {
            if (m_tag == null)
                return true;
            return m_tag.SemanticAnalysisFinished();
        }

        /*
         * This method does the semantic analysis. It may may be called multiple times per time.
         * This method changes the state of the object
         * This involves: 
         * - semantic checking 
         * - resolution of enumerates for enumerated types, integers and bit strings
         * - check of children for constructed types (e.g. no duplicate names on SEQUENCE etc)
         * - constraints check
         * 
         * The overrides should first call SemanticAnalysisFinished() 
         * */
        public virtual void DoSemanticAnalysis()
        {
            if (m_tag != null)
                m_tag.DoSemanticAnalysis();
        }


        /// <summary>
        /// This method resolves all constraints associated with this type. 
        /// The method must be called only after the type has been resolved
        /// This method must be overrider by types that contain other types (e.g. SEQUENCE, 
        /// CHOICE etc) and for ReferenceType
        /// </summary>
        public virtual void ResolveConstraints()
        {
            if (AreConstraintsResolved())
                return;

            if (m_constraints.Count == 0)
            {
                foreach (ITree tree in m_AntlrConstraints)
                {
                    checkConstraintsSemantically(tree);
                    m_constraints.Add(RootConstraint.Create(tree, this));
                }
            }

            foreach (IConstraint cn in m_constraints)
                cn.DoSemanticAnalysis();

            if (AreConstraintsResolved())       //constraints have just been resolved so let's simplify them
            {
                for (int i = 0; i < m_constraints.Count; i++)
                {
                    m_constraints[i] = m_constraints[i].Simplify();
                }
            }
        }

        /// <summary>
        /// This method does not change the state of the object. It acts like ResolveConstraints() but
        /// the results are not stored internally
        /// </summary>
        /// <param name="antlrConstr"></param>
        /// <param name="resultConstraint"></param>
        /// <returns>true if constraint has been resolved</returns>
        public bool ResolveExternalConstraints(ITree antlrConstr, ref IConstraint resultConstraint)
        {
            if (resultConstraint == null)
            {
                checkConstraintsSemantically(antlrConstr);
                resultConstraint = RootConstraint.Create(antlrConstr, this);
                resultConstraint.DoSemanticAnalysis();
            }
            else
            {
                if (!resultConstraint.IsResolved())
                    resultConstraint.DoSemanticAnalysis();
            }

            return resultConstraint.IsResolved();
        }

        /// <summary>
        /// Checks if a value is allowed or not. 
        /// </summary>
        /// <param name="val">the value to be check</param>
        /// <returns>true if value is allowed</returns>
        public virtual bool isValueAllowed(Asn1Value val)
        {
            if (!AreConstraintsResolved())
                throw new Exception("Internal Error");
            if (!val.IsResolved())
                throw new Exception("Internal Error");

            if (ParentType != null)
                if (!ParentType.isValueAllowed(val))
                    return false;

            foreach (IConstraint cn in m_constraints)
            {
                if (!cn.isValueAllowed(val))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Returns parent type. It must be overwritten in Reference Type
        /// </summary>
        public virtual Asn1Type ParentType
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// This method must check weather the constraints are Semantically OK. It actually checks if e.g. under an
        /// Integer SIZE or FROM or pattern constraints are NOT allowed
        /// The default implementation accepts only Single Value & Type Inclusion constraints
        /// </summary>
        static List<int> m_allowedTokens = new List<int>(new int[]{ asn1Parser.CONSTRAINT, asn1Parser.EXCEPTION_SPEC, asn1Parser.EXT_MARK, 
                asn1Parser.UNION_SET, asn1Parser.UNION_SET_ALL_EXCEPT, asn1Parser.INTERSECTION_SET,
                asn1Parser.INTERSECTION_ELEMENT, asn1Parser.VALUE_RANGE_EXPR, asn1Parser.SUBTYPE_EXPR});
        static List<int> m_stopList = new List<int>(new int[] { asn1Parser.VALUE_RANGE_EXPR, asn1Parser.SUBTYPE_EXPR, asn1Parser.EXCEPTION_SPEC });
        protected virtual IEnumerable<int> AllowedTokensInConstraints { get { return m_allowedTokens; } }
        protected virtual IEnumerable<int> StopTokensInConstraints { get { return m_stopList; } }
        public virtual void checkConstraintsSemantically(ITree antrlConstraint)
        {
            AntlrTreeVisitor visit = new AntlrTreeVisitor();

            //Console.WriteLine();
            //foreach (int d in StopList)
            //    Console.Write(d.ToString()+" ");
            //Console.WriteLine();

            visit.visitIfNot(antrlConstraint, AllowedTokensInConstraints, delegate(ITree root)
            {
                throw new SemanticErrorException("Error1 in Line:" + root.Line + ", col:" + root.CharPositionInLine +
                    " . This type of constraint '" + root.Text + "' cannot appear under " + Name);
            },
                StopTokensInConstraints);

            visit.visit(antrlConstraint, asn1Parser.VALUE_RANGE_EXPR, delegate(ITree root)
            {
                if (root.ChildCount != 1)
                    throw new SemanticErrorException("Error2 in Line:" + root.Line + ", col:" + root.CharPositionInLine +
                    " . This type of constraint '" + root.Text + "' cannot appear under " + Name);
            }, StopTokensInConstraints);

        }


        /// <summary>
        /// This method resolves all constraints associated with this type. 
        /// The method must be called only after the type has been resolved
        /// This method must be overrider by types that contain other types (e.g. SEQUENCE, CHOICE etc)
        /// </summary>
        public virtual bool AreConstraintsResolved()
        {
            if (m_AntlrConstraints.Count > m_constraints.Count)
                return false;
            foreach (IConstraint cn in m_constraints)
                if (!cn.IsResolved())
                    return false;
            return true;
        }

        public virtual void PerformAutomaticTagging()
        {
        }
       
        

/// <summary>
/// Print methods
/// </summary>
/// <param name="o"></param>

        public virtual void PrintAsn1Constraints(StreamWriterLevel o)
        {
            if (m_constraints.Count > 0)
            {
                o.Write(" ");
                foreach (IConstraint con in m_constraints)
                    o.Write(con.ToString(true));
                PEREffectiveConstraint dummy = PEREffectiveConstraint;
                if (dummy != null)
                {
                    o.Write("--");
                    dummy.PrintAsn1(o);
                    o.Write("--");
                }
            }
        }

        public virtual string Constraints
        {
            get
            {
                string ret = "";
                foreach (IConstraint con in m_constraints)
                    ret+=con.ToString(true);

                return ret;
            }
        }

        public virtual void PrintAsn1(StreamWriterLevel o, int lev)
        {
            if (m_tag != null)
                m_tag.PrintAsn1(o, lev);
            o.Write(Name);
            PrintAsn1Constraints(o);
        }

        public virtual bool Compatible(Asn1Type o)
        {
            throw new Exception("Abstract method called: Compatible()");
        }

// PER related methods

        /// <summary>
        /// This method is called by SemanticParse() of the Asn1CompilerInvokation.
        /// This method must be overriden in types that include other types (i.e. SEQUENCE etc)
        /// </summary>
        public virtual void ComputePEREffectiveConstraints()
        {
            PEREffectiveConstraint dummy = PEREffectiveConstraint;
        }
        
        public virtual bool IsPERExtensible()
        {
            if (PEREffectiveConstraint!=null)
                return PEREffectiveConstraint.Extensible;
            return false;
        }

        /// <summary>
        /// Returns the PER effective constraint for the given type
        /// If there is no effective constraint returns null
        /// </summary>
        public virtual PEREffectiveConstraint PEREffectiveConstraint
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// This function should never be called directly.
        /// Instead call the property MinBitsInPER
        /// </summary>
        /// <param name="cns"></param>
        /// <returns></returns>
        public virtual long minBitsInPER(PEREffectiveConstraint cns)
        {
            return 0;
        }

        /// <summary>
        /// This function should never be called directly.
        /// Instead call the property MaxBitsInPER
        /// </summary>
        /// <param name="cns"></param>
        /// <returns></returns>
        public virtual long maxBitsInPER(PEREffectiveConstraint cns)
        {
            return -1;
        }

        /// <summary>
        /// Return -1 if infinite
        /// </summary>
        public long MinBitsInPER
        {
            get
            {
                return minBitsInPER(PEREffectiveConstraint);
            }
        }

        /// <summary>
        /// Return -1 if infinite
        /// </summary>
        public long MaxBitsInPER
        {
            get { return maxBitsInPER(PEREffectiveConstraint); }
        }

        /// <summary>
        /// Return -1 if infinite
        /// </summary>
        public virtual long MinBytesInPER
        {
            get {
                long bits = MinBitsInPER;
                if (bits == -1)
                    return -1;

                return (long)Math.Ceiling((double)bits / 8.0); 
            }
        }

        /// <summary>
        /// Return -1 if infinite
        /// </summary>
        public virtual long MaxBytesInPER
        {
            get
            {
                long bits = MaxBitsInPER;
                if (bits == -1)
                    return -1;

                return (long)Math.Ceiling((double)bits / 8.0);
            }
        }


//Backend functions
        public virtual void PrintHtml(PEREffectiveConstraint cns, StreamWriterLevel o, int lev, List<string> comment, TypeAssigment tas)
        {
            o.WriteLine("<a name=\"{0}\"></a>", "ICD_" + tas.m_name.Replace("-", "_"));
            o.WriteLine("<table border=\"0\" width=\"100%\" align=\"left\">");
            o.WriteLine("<tbody>");

            o.WriteLine("<tr  bgcolor=\"{0}\">", (tas.m_createdThroughTabulization ? "#379CEE" : "#FF8f00"));
            o.WriteLine("<td height=\"35\" colspan=\"2\"  >");
            o.WriteLine("<font face=\"Verdana\" color=\"#FFFFFF\" size=\"4\">{0}</font><font face=\"Verdana\" color=\"#FFFFFF\" size=\"2\">({1}) </font>", tas.m_name, Name);
            o.WriteLine("<font face=\"Verdana\" color=\"#FFFFFF\" size=\"2\"><a href=\"#{0}\">ASN.1</a></font>", "ASN1_" + tas.m_name.Replace("-", "_"));
            o.WriteLine("</td>");

            o.WriteLine("<td height=\"35\" align=\"center\">");
            o.WriteLine("    <font face=\"Verdana\" color=\"#FFFFFF\" size=\"2\">min = {0} bytes</font>", (MinBytesInPER == -1 ? "&#8734" : MinBytesInPER.ToString()));
            o.WriteLine("</td>");

            o.WriteLine("<td height=\"35\" align=\"center\">");
            o.WriteLine("    <font face=\"Verdana\" color=\"#FFFFFF\" size=\"2\">max = {0} bytes</font>", (MaxBytesInPER == -1 ? "&#8734" : MaxBytesInPER.ToString()));
            o.WriteLine("</td>");
            o.WriteLine("</tr>");

            if (comment.Count > 0)
            {
                o.WriteLine("<tr class=\"CommentRow\">");
                o.WriteLine("<td class=\"comment2\" colspan=\"4\">" + o.BR(comment) + "</td>");
                o.WriteLine("</tr>");
            }

            o.WriteLine("<tr class=\"headerRow\">");
            o.WriteLine("<td class=\"hrconstraint2\" colspan=\"2\">Constraints</td>");
            o.WriteLine("<td class=\"hrMin2\">Min Length (bits)</td>");
            o.WriteLine("<td class=\"hrMax2\">Max Length (bits)</td>");
            o.WriteLine("</tr>");



            o.WriteLine("<tr class=\"OddRow\">");
            o.WriteLine("    <td class=\"constraint\" colspan=\"2\">{0}</td>", Constraints);
            o.WriteLine("    <td class=\"min\" >{0}</td>", MinBitsInPER);
            o.WriteLine("    <td class=\"max\" >{0}</td>", MaxBitsInPER);
            o.WriteLine("</tr>");


            o.WriteLine("</tbody>");
            o.WriteLine("</table>");
//            o.WriteLine("</a>");

        }

        /// <summary>
        /// Must be overriden in Contstucted types
        /// </summary>
        public virtual bool Constructed
        {
            get { return false; }
        }

        /// <summary>
        /// Must be overriden in Contstucted types
        /// </summary>
        public virtual void Tabularize(string tasName)
        {
        }

        internal virtual void PrintHTypeDeclaration(PEREffectiveConstraint cns, StreamWriterLevel h, string typeName, string varName, int lev)
        {
            throw new Exception("Abstract method called");
        }

        internal virtual bool DependsOnlyOn(List<TypeAssigment> values)
        {
            return true;
        }

        internal virtual void VarsNeededForPrintCInitialize(int lev, OrderedDictionary<string, CLocalVariable> existingVars)
        {
        }

        /// <summary>
        /// Initialize type. If there is a default value (i.e. as child of a sequence, or set), this value is used for 
        /// initialization. Otherwise set to 0, or 0.0 or memset(0x0)
        /// </summary>
        /// <param name="cns"></param>
        /// <param name="h"></param>
        /// <param name="typeName"></param>
        /// <param name="varName"></param>
        /// <param name="lev"></param>
        internal virtual void PrintCInitialize(PEREffectiveConstraint cns, Asn1Value defauleVal, StreamWriterLevel h, string typeName, string varName, int lev)
        {
            throw new Exception("Abstract method called");
        }

        internal virtual void PrintHConstraintConstant(StreamWriterLevel h, string name)
        {
            if (m_constraints.Count>0)
                h.WriteLine("#define ERR_{0}\t\t{1} /* {2} */", C.ID(name), Asn1CompilerInvokation.Instance.ConstraintErrorID++, Constraints);
        }
/*
 
        internal virtual void PrintCIsConstraintValidAux(StreamWriterLevel c)
        {
            if (m_constraints.Count > 0)
            {
                for (int i = 0; i < m_constraints.Count; i++)
                {
                    m_constraints[i].PrintCIsConstraintValidAux(c);
                }
            }
        }
*/        
 
        


        internal virtual void PrintCIsConstraintValid(PEREffectiveConstraint cns, StreamWriterLevel c, string errorCode, string typeName, string varName, int lev)
        {
            string varName2 = varName;
            if (!varName.Contains("->"))
                varName2 = "*" + varName;

            if (m_constraints.Count > 0)
            {
                c.P(lev); c.Write("if ( !");
                for (int i = 0; i < m_constraints.Count; i++)
                {
                    string ret = m_constraints[i].PrintCIsConstraintValid(c, varName2, lev);
                    c.Write(ret);
                    if (i != m_constraints.Count - 1)
                        c.Write(" && ");
                }
                c.WriteLine(" ) {");
                c.P(lev + 1);
                c.WriteLine("*pErrCode = ERR_{0};", C.ID(errorCode));
                c.P(lev + 1);
                c.WriteLine("return FALSE;");
                c.P(lev);
                c.WriteLine("}");
            }

        }

        internal virtual void PrintCEncode(PEREffectiveConstraint cns, StreamWriterLevel c, string errorCode, string varName, int lev)
        {
//            throw new Exception("Abstract method called");
            c.P(lev);
            c.WriteLine("assert(0);");
        }
        
        internal virtual void PrintCDecode(PEREffectiveConstraint cns, StreamWriterLevel c, string varName, int lev)
        {
            //            throw new Exception("Abstract method called");
            c.P(lev);
            c.WriteLine("assert(0);");
        }
    }



    public interface ISize
    {
        Int64 Size { get;}
    }

    public interface ICharacterString
    {
        string Value { get;}
    }


    public partial class Asn1Value : IComparable
    {
        internal ITree antlrNode;
        //m_module is the module where the variable is declared where it can be different to the module of the type
        public Module m_module;
        internal Asn1Type m_type = null;


        static public Asn1Value CreateFromAntlrAst(ITree tree)
        {

            Asn1Value ret = new Asn1Value();
            ret.antlrNode = tree;
            return ret;
        }

        public enum TypeID
        {
            INT,
            REAL,
            BIT_STRING,
            OCTECT_STRING,
            BOOLEAN,
            STRING,
            VALUE_REFERENCE,
            ENUMERATED,
            UNRESOLVED,
            SEQUENCE_OR_SET,
            SEQUENCE_OF,
            SET_OF,
            CHOICE,
            OBJECT_IDENTIFIER,
            REL_OBJ_ID,
            IA5String,
            NumericString,
            NULL,
            GeneralizedTime,
            UTCTime
        }


        public TypeID m_TypeID = TypeID.UNRESOLVED;

        public Asn1Type Type
        {
            get { return m_type; }
        }

        //to be removed


        public override string ToString()
        {
            throw new Exception("Internal Error: Value is undifined type");
        }

        public virtual bool IsResolved()
        {
            return m_TypeID != TypeID.UNRESOLVED;
        }

        #region IComparable Members

        public virtual int CompareTo(object obj)
        {
            throw new Exception("Internal Error: Abstract Method Called.");
        }

        #endregion


        public virtual List<bool> Encode()
        {
//            throw new Exception("The method or operation is not implemented.");
            return new List<bool>();
        }

        public virtual List<byte> Encode2()
        {
            List<bool> bitStream = Encode();
            while (bitStream.Count % 8 > 0)
                bitStream.Add(false);
            List<byte> bufer = new List<byte>();

            LinkedList<bool> bs = new LinkedList<bool>(bitStream);

            while (bs.Count > 0)
            {
                byte curByte = 0;
                byte curMask = 0x80;

                for (int i = 0; i < 8; i++)
                {
                    if (bs.First.Value)
                        curByte |= curMask;
                    curMask >>= 1;
                    bs.RemoveFirst();
                }
                bufer.Add(curByte);
            }
            return bufer;
        }

        internal virtual void PrintC(StreamWriterLevel c, int lev)
        {
            c.Write(ToStringC());
        }

        public virtual string ToStringC()
        {
            return ToString();
        }
    }


}
