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
        static List<int> m_stopList = new List<int>(new int[] { asn1Parser.VALUE_RANGE_EXPR, asn1Parser.SUBTYPE_EXPR });
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
            }
        }
        
        public virtual void PrintAsn1(StreamWriterLevel o, int lev)
        {
            if (m_tag != null)
                m_tag.PrintAsn1(o, lev);
            o.Write(Name);
            PrintAsn1Constraints(o);
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
        protected Asn1Type m_type = null;


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

    }


}
