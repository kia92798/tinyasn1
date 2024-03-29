/**=============================================================================
Asn1Type and Asn1Value class definitions
in autoICD and asn1scc projects  
================================================================================
Copyright(c) Semantix Information Technologies S.A www.semantix.gr
All rights reserved.

This source code is only intended as a supplement to the
Semantix Technical Reference and related electronic documentation 
provided with the autoICD and asn1scc applications.
See these sources for detailed information regarding the
asn1scc and autoICD applications.
==============================================================================*/

using System;
using System.Collections.Generic;
using System.Text;
using Antlr.Runtime.Tree;
using semantix.util;

namespace tinyAsn1
{



    /// <summary>
    /// Base class for all ASN.1 types
    /// </summary>
    public abstract partial class Asn1Type
    {
        // The antlr tree node for this type
        public ITree antlrNode;
        // The module where this type is defined
        public Module m_module;
        // type's tag
        public Tag m_tag;
        // constraints associated with this type
        public List<IConstraint> m_constraints = new List<IConstraint>();
        
        public List<ITree> m_AntlrConstraints = new List<ITree>();

        public Dictionary<string, string> m_CustomAttributes = new Dictionary<string, string>();


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

        public IEnumerable<Asn1Value> GetAllVariables()
        {
            foreach (Asn1Type t in GetMySelfAndAnyChildren<Asn1Type>())
                foreach (Asn1Value v in t.GetVariables())
                    yield return v;
            yield break;
        }

        public virtual IEnumerable<Asn1Value> GetVariables()
        {
            foreach(IConstraint con in m_constraints)
                foreach (Asn1Value v in con.GetVariables())
                    yield return v;
            yield break;

        }


        string _uniquePath = "";

        public string UniquePath
        {
            get { return _uniquePath; }
            set { _uniquePath = value; }
        }
        
        /// <summary>
        /// This class represents the ASN.1 tags
        /// </summary>
        public partial class Tag
        {
            public enum TagClass
            {
                UNIVERSAL = 0,
                APPLICATION = 1,
                CONTEXT_SPECIFIC = 2,
                PRIVATE = 3,
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
                Tag ret = DefaultBackend.Instance.Factory.CreateAsn1TypeTag();
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
                    IntegerType dummy = DefaultBackend.Instance.Factory.CreateIntegerType();
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
                        ret = DefaultBackend.Instance.Factory.CreateNullType();
                        break;
                    case asn1Parser.BIT_STRING_TYPE:
                        ret = BitStringType.CreateFromAntlrAst(child);
                        break;
                    case asn1Parser.BOOLEAN:
                        ret = DefaultBackend.Instance.Factory.CreateBooleanType();
                        break;
                    case asn1Parser.ENUMERATED_TYPE:
                        ret = EnumeratedType.CreateFromAntlrAst(child);
                        break;
                    case asn1Parser.INTEGER_TYPE:
                        ret = IntegerType.CreateFromAntlrAst(child);
                        break;
                    case asn1Parser.REAL:
                        ret = DefaultBackend.Instance.Factory.CreateRealType();
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
                        ret = DefaultBackend.Instance.Factory.CreateOctetStringType();
                        break;
                    case asn1Parser.IA5String:
                        ret = DefaultBackend.Instance.Factory.CreateIA5StringType();
                        break;
                    case asn1Parser.NumericString:
                        ret = DefaultBackend.Instance.Factory.CreateNumericStringType();
                        break;
                    case asn1Parser.UTCTime:
                        ret = DefaultBackend.Instance.Factory.CreateUTCTimeTypeType();
                        break;
                    case asn1Parser.GeneralizedTime:
                        ret = DefaultBackend.Instance.Factory.CreateGeneralizedTimeType();
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
                        ret = DefaultBackend.Instance.Factory.CreateIA5StringType();
                        break;

                    //                            throw new SemanticErrorException("Error line: " + child.Line + ", col: " + child.CharPositionInLine + ". "+child.Text+" is currently not supported.");
                    case asn1Parser.SELECTION_TYPE:
                        throw new SemanticErrorException("Error line: " + child.GetChild(0).Line + ", col: " + child.GetChild(0).CharPositionInLine + ". Selection types are currently not supported.");
                    case asn1Parser.CONSTRAINT:
                        //if (ret != null)
                        //    ret.m_constraints.Add(Constraint.CreateFromAntlrAst(child));
                        ret.m_AntlrConstraints.Add(child);
                        break;
                    case asn1Parser.CUSTOM_ATTR_LIST:
                        HandleCustomAttrList(ret, child);
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

        static void HandleCustomAttrList(Asn1Type asn1Type, ITree list)
        {
            if (list.Type != asn1Parser.CUSTOM_ATTR_LIST)
                throw new Exception("BUG");

            for (int i = 0; i < list.ChildCount; i++)
            {
                ITree child = list.GetChild(i);

                string key = child.GetChild(0).Text;
                string value = child.GetChild(1).Text;

                if (value.StartsWith("\""))
                    value = value.Substring(1);
                if (value.EndsWith("\""))
                    value = value.Substring(0, value.Length - 1);

                if (asn1Type.m_CustomAttributes.ContainsKey(key))
                    throw new SemanticErrorException("Error1 in Line:" + child.Line + ", col:" + child.CharPositionInLine +
                    " . Custom attribute '" + key + "' appears twice ");
                asn1Type.m_CustomAttributes.Add(key, value);                
            }
        }

        public virtual Tag UniversalTag { get { return null; } }

        public virtual TagSequence Tags
        {
            get
            {
                TagSequence ret = DefaultBackend.Instance.Factory.CreateAsn1TypeTagSequence();

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

        public virtual bool isValueAllowed(Asn1Value val, List<IConstraint> addionalConstraints)
        {
            bool ret = isValueAllowed(val);
            if (!ret)
                return false;
            if (addionalConstraints != null)
            {
                foreach (IConstraint cn in addionalConstraints)
                {
                    if (!cn.isValueAllowed(val))
                        return false;
                }
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
                return BaseConstraint.AsString(m_constraints);
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
        /// 
        private long _minBitsInPer = -314;
        public long MinBitsInPER
        {
            get
            {
                if (_minBitsInPer == -314)
                    _minBitsInPer = minBitsInPER(PEREffectiveConstraint);

                return _minBitsInPer;
            }
        }

        /// <summary>
        /// Return -1 if infinite
        /// </summary>
        /// 
        private long _maxBitsInPER = -314;
        public long MaxBitsInPER
        {
            get { 
                if (_maxBitsInPER == -314)
                    _maxBitsInPER = maxBitsInPER(PEREffectiveConstraint); 
                return _maxBitsInPER;
            }
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

        public virtual bool IsOctetAligned(PEREffectiveConstraint cns)
        {
            throw new AbstractMethodCalledException();
        }



        public virtual string MaxBitsInPER_Explained { get { return string.Empty; } }


        /// <summary>
        /// Must be overriden in Contstucted types
        /// </summary>
        public virtual bool Constructed
        {
            get { return false; }
        }



        internal virtual bool DependsOnlyOn(List<string> values)
        {
            return true;
        }

        public virtual bool ContainsTypeAssigment(string typeAssigment)
        {
            return false;
        }

        internal virtual List<string> TypesIDepend()
        {
            return new List<string>();
        }


        public Asn1Value GetOneValidValue()
        {
            return GetSet().GetOneValue();
        }
        public virtual ISet GetSet()
        {
            return GetSet(m_constraints);
        }

        public ISet GetSet(IEnumerable<IConstraint> constraints)
        {
            ISet curSet = new UniversalSet();
            foreach (IConstraint con in m_constraints)
                curSet = curSet.Intersect(con.GetSet().Simplify());
            return curSet;
        }


        public virtual ISet GetSet(Asn1Value val)
        {
            DiscreetValueSetWithInfiniteUniverseNorm<Asn1Value> ret = new DiscreetValueSetWithInfiniteUniverseNorm<Asn1Value>();
            ret.AddValue(val);

            return ret;
        }


        public virtual ISet GetSet(Asn1Value min, bool minIsIncluded, Asn1Value max, bool maxIsIncluded)
        {
            throw new Exception("abstract method called");
        }

        public virtual ISet GetAlphabetSet(string val)
        {
            throw new Exception("abstract method called");
        }

        public virtual ISet GetAlphabetSet(Asn1Value min, bool minIsIncluded, Asn1Value max, bool maxIsIncluded)
        {
            throw new Exception("abstract method called");
        }


        public virtual OrderedDictionary<string, ISet> GetSetWithComponent()
        {
            OrderedDictionary<string, ISet> ret = new OrderedDictionary<string, ISet>();
            foreach (IConstraint con in m_constraints)
            {
                List<KeyValuePair<string, ISet>> list = con.GetSetWithComponent();
                foreach (KeyValuePair<string, ISet> p in list)
                {
                    if (!ret.ContainsKey(p.Key))
                        ret.Add(p.Key, p.Value);
                    else
                        ret[p.Key] = ret[p.Key].Intersect(p.Value);
                }
            }
            return ret;
        }





        public void ToXml(StreamWriterLevel o, int p)
        {
            if (Tags.m_tags.Count > 0)
            {
                Tag prTag = Tags.m_tags[0];
                o.P(p); o.WriteLine("<Type Line=\"{0}\" CharPositionInLine=\"{1}\" TagClass=\"{2}\" TaggingMode=\"{3}\" TagNo=\"{4}\">",
    antlrNode.Line, antlrNode.CharPositionInLine, prTag.m_class.ToString(), prTag.m_taggingMode.ToString(), prTag.m_tag);
            }
            else
            {
                o.P(p); o.WriteLine("<Type Line=\"{0}\" CharPositionInLine=\"{1}\">",antlrNode.Line, antlrNode.CharPositionInLine);
            }

            ToXml2(o, p + 1);

            
            o.P(p); o.WriteLine("</Type>");
        }

        public virtual void ToXml2(StreamWriterLevel o, int p)
        {

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




    /// <summary>
    /// Base class for all ASN.1 values
    /// </summary>
    public partial class Asn1Value : IComparable, IEquatable<Asn1Value>
    {
        internal ITree antlrNode;
        //m_module is the module where the variable is declared where it can be different to the module of the type
        public Module m_module;
        internal Asn1Type m_type = null;


        string m_cname=string.Empty;
        public string CName { get { return m_cname; } set { m_cname = value; } }


        public virtual IEnumerable<T> GetMySelfAndAnyChildren<T>() where T : Asn1Value
        {

            if (this is T)
                yield return this as T;

            yield break;
        }


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


        public virtual string ToStringC()
        {
            return ToString();
        }

        public virtual bool Equals(Asn1Value obj)
        {
            return Equals((object)obj);
        }

    }


}
