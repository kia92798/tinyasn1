using System;
using System.Collections.Generic;
using System.Text;
using Antlr.Runtime.Tree;
using Antlr.Runtime;
using tinyAsn1;

namespace asn1scc
{


    public class SCCBackendFactory : DefaultAsn1Factory
    {
        public override Asn1File CreateAsn1File()
        {
            return new SCCFile();
        }

        public override Module CreateModule()
        {
            return new SCCModule();
        }

        public override TypeAssigment CreateTypeAssigment()
        {
            return new SCCTypeAssigment();
        }

        public override ValueAssigment CreateValueAssigment()
        {
            return new SCCValueAssigment();
        }

        public override BitStringType CreateBitStringType()
        {
            return new SCCBitStringType();
        }

        public override BooleanType CreateBooleanType()
        {
            return new SCCBooleanType();
        }

        public override ChoiceType CreateChoiceType()
        {
            return new SCCChoiceType();
        }

        public override ChoiceChild CreateChoiceChildType()
        {
            return new SCCChoiceChild();
        }

        public override EnumeratedType CreateEnumeratedType()
        {
            return new SCCEnumeratedType();
        }


        public override IntegerType CreateIntegerType()
        {
            return new SCCIntegerType();
        }

        public override NullType CreateNullType()
        {
            return new SCCNullType();
        }

        public override ObjectIdentifier CreateObjectIdentifierType()
        {
            return new SCCObjectIdentifier();
        }

        public override OctetStringType CreateOctetStringType()
        {
            return new SCCOctetStringType();
        }

        public override RealType CreateRealType()
        {
            return new SCCRealType();
        }

        public override ReferenceType CreateReferenceType()
        {
            return new SCCReferenceType();
        }

        public override SequenceType CreateSequenceType()
        {
            return new SCCSequenceType();
        }

        public override SequenceOfType CreateSequenceOfType()
        {
            return new SCCSequenceOfType();
        }

        public override SetType CreateSetType()
        {
            return new SCCSetType();
        }

        public override SetOfType CreateSetOfType()
        {
            return new SCCSetOfType();
        }

        public override SequenceOrSetType.Child CreateSequenceOrSetChildType()
        {
            return new SCCSequenceOrSetTypeChild();
        }

        public override SequenceOrSetType.Child CreateSequenceOrSetChildType(SequenceOrSetType.Child o)
        {
            return new SCCSequenceOrSetTypeChild(o);
        }

        public override IA5StringType CreateIA5StringType()
        {
            return new SCCIA5StringType();
        }

        public override NumericStringType CreateNumericStringType()
        {
            return new SCCNumericStringType();
        }

        public override GeneralizedTimeType CreateGeneralizedTimeType()
        {
            return new SCCGeneralizedTimeType();
        }

        public override UTCTimeType CreateUTCTimeTypeType()
        {
            return new SCCUTCTimeType();
        }
    }


    public class SCCBackend : Asn1CompilerInvokation
    {
        SCCBackendFactory _factory = new SCCBackendFactory();
        public override IAsn1AbstractFactory Factory
        {
            get
            {
                return _factory;
            }
        }

        /// <summary>
        /// It checks that
        /// * All strings, SEQUENCE OFs, SETs etc have SIZE constraint and that MAX is bounded
        /// 
        /// </summary>
        private void CheckStrictConstraintsNeededForAsn1cc()
        {
            foreach (Asn1File f in m_files)
                foreach (Module m in f.m_modules)
                {
                    foreach (SizeableType st in m.GetTypes<SizeableType>())
                    {
                        PERSizeEffectiveConstraint sz = st.PEREffectiveConstraint as PERSizeEffectiveConstraint;
                        if (sz == null)
                            ErrorReporter.SemanticError(f.m_fileName, st.antlrNode.Line, "This type({0}) must have a non extensible size constraint", st.Name);
                        if (sz.Extensible || sz.m_size.m_isExtended)
                            ErrorReporter.SemanticError(f.m_fileName, st.antlrNode.Line, "This type({0}) must have a non extensible size constraint", st.Name);
                        if (sz.m_size.m_rootRange.m_maxIsInfinite)
                            ErrorReporter.SemanticError(f.m_fileName, st.antlrNode.Line, "This type({0}) must have a non extensible size constraint with finite upper value", st.Name);
                    }
                    foreach (SequenceOrSetType sq in m.GetTypes<SequenceOrSetType>())
                    {
                        if (sq.IsPERExtensible())
                            ErrorReporter.SemanticError(f.m_fileName, sq.antlrNode.Line, "This type({0}) cannot be extensible", sq.Name);
                    }
                    foreach (ChoiceType ch in m.GetTypes<ChoiceType>())
                    {
                        if (ch.IsPERExtensible())
                            ErrorReporter.SemanticError(f.m_fileName, ch.antlrNode.Line, "This type({0}) cannot be extensible", ch.Name);
                    }
                    foreach (EnumeratedType en in GetTypes<EnumeratedType>())
                    {
                        if (en.IsPERExtensible())
                            ErrorReporter.SemanticError(f.m_fileName, en.antlrNode.Line, "This type({0}) cannot be extensible", en.Name);
                    }
                }
        }

        private void EnsureUniqueEnumerated()
        {
            List<string> enumKeys = new List<string>();
            List<string> doubleKeys = new List<string>();
            while (true)
            {
                enumKeys.Clear();
                foreach (EnumeratedType en in GetTypes<EnumeratedType>())
                {
                    List<string> path = new List<string>(en.UniquePath.Split('/'));
                    foreach (EnumeratedType.Item item in en.m_enumValues.Values)
                    {
                        if (doubleKeys.Contains(item.CID))
                        {
                            for (int i = path.Count - 1; i >= 0; i--)
                                if (!item.CID.Contains(path[i].Replace('-', '_')))
                                {
                                    item.CID = path[i] + "_" + item.CID;
                                    break;
                                }
                        }
                        enumKeys.Add(item.CID);
                    }
                }

                foreach (ChoiceType ch in GetTypes<ChoiceType>())
                {
                    List<string> path = new List<string>(ch.UniquePath.Split('/'));
                    if (doubleKeys.Contains(ch.CID_NONE))
                    {
                        for (int i = path.Count - 1; i >= 0; i--)
                            if (!ch.CID_NONE.Contains(path[i].Replace('-', '_')))
                            {
                                ch.CID_NONE = path[i] + "_" + ch.CID_NONE;
                                break;
                            }
                    }
                    enumKeys.Add(ch.CID_NONE);
                    foreach (ChoiceChild item in ch.m_children.Values)
                    {
                        if (doubleKeys.Contains(item.CID))
                        {
                            for (int i = path.Count - 1; i >= 0; i--)
                                if (!item.CID.Contains(path[i].Replace('-', '_')))
                                {
                                    item.CID = path[i] + "_" + item.CID;
                                    break;
                                }
                        }
                        enumKeys.Add(item.CID);
                    }
                }


                doubleKeys.Clear();
                for (int i = 0; i < enumKeys.Count; i++)
                {
                    for (int j = i + 1; j < enumKeys.Count; j++)
                    {
                        if (enumKeys[i] == enumKeys[j] && !doubleKeys.Contains(enumKeys[i]))
                            doubleKeys.Add(enumKeys[i]);
                    }
                }
                if (doubleKeys.Count == 0)
                    break;
            }
        }

#if TO_BE_DELETED
        private void CheckDependencies()
        {
            List<string> ret = new List<string>();
            List<TypeAssigment> tmp = new List<TypeAssigment>();

            foreach (Asn1File f in m_files)
                foreach (Module m in f.m_modules)
                    foreach (TypeAssigment t in m.m_typeAssigments.Values)
                        tmp.Add(t);

            while (tmp.Count > 0)
            {
                int lenBefore = tmp.Count;
                foreach (Asn1File f in m_files)
                {
                    foreach (Module m in f.m_modules)
                    {
                        foreach (TypeAssigment t in m.m_typeAssigments.Values)
                        {
                            if (t.DependsOnlyOn(ret) && !ret.Contains(t.m_name))
                            {
                                ret.Add(t.m_name);
                                tmp.Remove(t);
                            }
                        }
                    }
                }
                if (lenBefore == tmp.Count)
                {
                    Console.Error.WriteLine("Cyclic dependencies detected");
                    List<string> tmpstr = new List<string>();
                    foreach (TypeAssigment t in tmp)
                        tmpstr.Add(t.m_name);
                    foreach (TypeAssigment t in tmp)
                    {
                        Console.Error.WriteLine("Type {0} depends on: ", t.m_name);
                        List<string> dps = t.TypesIDepend();
                        foreach (string l in dps)
                            Console.Error.WriteLine("\t{0}", l);
                    }
                    throw new SemanticErrorException("Error: Asn1 grammar has cyclic dependencies");
                }
            }

        }
#endif
        public void printC()
        {
            CheckStrictConstraintsNeededForAsn1cc();
            EnsureUniqueEnumerated();
            foreach (SCCFile file in m_files)
                file.printC();
        }








    }




}