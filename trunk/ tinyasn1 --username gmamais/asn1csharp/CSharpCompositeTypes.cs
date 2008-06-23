using System;
using System.Collections.Generic;
using System.Text;
using tinyAsn1;

namespace asn1csharp
{
    public static class CSharpSequenceOrSetType
    {

        public static UInt32 CalculateTag(Asn1Type.Tag tg)
        {
            UInt32 ret = (byte)((byte)tg.m_class << 6);

            uint tagNumber = (uint)tg.m_tag;


            if (tagNumber < 31)
            {
                ret |= (byte)tagNumber;

                return ret;
            }

            ret |= 0x1F;

            List<byte> encBytes = new List<byte>();

            while (tagNumber > 0)
            {
                byte encTagPart = (byte)(tagNumber & 0x7F);

                tagNumber = tagNumber >> 7;
                if (encBytes.Count == 0)
                    encBytes.Insert(0, encTagPart);
                else
                    encBytes.Insert(0, (byte)(0x80 | encTagPart));
            }

            if (encBytes.Count > 3)
                throw new SemanticErrorException("Tag is too big! :" + tg.m_tag.ToString());

            foreach (byte b in encBytes)
            {
                ret <<= 8;
                ret |= b;
            }

            return ret;
        }

        public static void DeclareType(SequenceOrSetType pThis, StreamWriterLevel csFile, string TypeName, int level, string baseClassName)
        {
            csFile.WL(level, "public class {0} : {1}", TypeName, baseClassName);
            csFile.WL(level++, "{");

            foreach (SequenceOrSetType.Child ch in pThis.m_children.Values)
            {
                csFile.WriteLine();

                ICSharpType childType = ch.m_type as ICSharpType;
                string propName = C.ID(ch.m_childVarName.Substring(0, 1).ToUpper() + ch.m_childVarName.Substring(1));

                if (childType.RequiresNewTypeDeclaration())
                {
                    childType.DeclareType(csFile, propName, level);
                    csFile.WriteLine();
                }

                

                csFile.WL(level, "public {0} {1}", ((ICSharpType)ch.m_type).DeclaredTypeName, C.ID(ch.m_childVarName));
                csFile.WL(level++, "{");

                csFile.WL(level, "get {{ return m_children[ClassDef.m_children[\"{0}\"].m_index] as {1}; }}", C.ID(ch.m_childVarName), ((ICSharpType)ch.m_type).DeclaredTypeName);
                
                csFile.WL(--level, "}");


                csFile.WL(level, "public {0} Create_{1}()", childType.DeclaredTypeName, C.ID(ch.m_childVarName));
                csFile.WL(level++, "{");

//                csFile.WL(level, "return CreateChild(\"{0}\");", C.ID(ch.m_childVarName));
                csFile.WL(level, "return CreateChild(\"{0}\") as {1};", C.ID(ch.m_childVarName), childType.DeclaredTypeName);
                csFile.WL(--level, "}");

            }
            
            CSharpType.WriteEncodeDecodeMethods(pThis, csFile, level);

            csFile.WL(level, "static Asn1CompositeClass<OptionalNamedChild> _clsDef = new {0}ClassDefinition();",TypeName);
            csFile.WL(level, "public override Asn1CompositeClass<OptionalNamedChild> ClassDef");
            csFile.WL(level++, "{");
            csFile.WL(level, "get");
            csFile.WL(level++, "{");
            csFile.WL(level, "return _clsDef;");
            csFile.WL(--level, "}");
            csFile.WL(--level, "}");


            csFile.WL(level, "public {0}()", TypeName);
            csFile.WL(level++, "{");
            csFile.WL(level, "m_children = new Asn1Object[{0}];",pThis.m_children.Count);
            csFile.WL(--level, "}");

//class definition

            csFile.WL(level, "public class {0}ClassDefinition : Asn1CompositeClass<OptionalNamedChild>", TypeName);
            csFile.WL(level++, "{");

            csFile.WL(level, "public {0}ClassDefinition()", TypeName);
            csFile.WL(level++, "{");


            csFile.WL(level, "OptionalNamedChild ch;");
            int idx = 0;
            foreach (SequenceOrSetType.Child ch in pThis.m_children.Values)
            {

                ICSharpType childType = ch.m_type as ICSharpType;

                csFile.WL(level, "ch = new OptionalNamedChild(\"{0}\", {1}, delegate() {{return new {2}();}}, {3}, null);", C.ID(ch.m_childVarName), idx,
                    childType.DeclaredTypeName, (ch.m_optional ? "true" : "false"));
                idx++;

                ChoiceType chChild = ch.m_type.GetFinalType() as ChoiceType;
                if (chChild != null && !ch.m_type.IsTagged())
                {
//                    csFile.WL(level, "ch.UnTaggedChoice = true;");
//                    csFile.WL(level, "ch.m_childrenTags = new List<Tag>();");

                    List<Asn1Type.TagSequence> tags = chChild.getChildrenTags();
                    foreach (Asn1Type.TagSequence tgSq in tags)
                    {
//                        csFile.WL(level, "ch.m_childrenTags.Add(new Tag({0}, TagClass.{1}));", tgSq.m_tags[0].m_tag, tgSq.m_tags[0].m_class);

                        csFile.WL(level, "m_posChildren.Add(0x{0:X}, ch);", CalculateTag(tgSq.m_tags[0]));
                    }
                }
                else
                {
                    Asn1Type.Tag lstTag = ch.m_type.Tags.m_tags[0];
//                    csFile.WL(level, "ch.m_Tag = new Tag({0}, TagClass.{1});", lstTag.m_tag, lstTag.m_class);

                    csFile.WL(level, "m_posChildren.Add(0x{0:X}, ch);", CalculateTag(lstTag));
                }

                
                csFile.WL(level, "m_children.Add(\"{0}\", ch);", C.ID(ch.m_childVarName));
                csFile.WriteLine();


            }

            csFile.WL(--level, "}");
            csFile.WL(--level, "}");
           

            csFile.WL(--level, "}");

        }
    }

    public class CSharpSequenceType : SequenceType, ICSharpType
    {
        private string _declaredTypeName = string.Empty;


        public void DeclareType(StreamWriterLevel csFile, string TypeName, int level)
        {
            _declaredTypeName = TypeName;
            CSharpSequenceOrSetType.DeclareType(this, csFile, TypeName, level, "Asn1SequenceObject");
        }

        public string DeclaredTypeName
        {
            get { return _declaredTypeName; }
        }

        public bool RequiresNewTypeDeclaration()
        {
            return true;
        }


        public string ConstraintVariable { get { return "this"; } }

    }

    public class CSharpSetType : SetType, ICSharpType
    {
        private string _declaredTypeName = string.Empty;


        public void DeclareType(StreamWriterLevel csFile, string TypeName, int level)
        {
            _declaredTypeName = TypeName;
            CSharpSequenceOrSetType.DeclareType(this, csFile, TypeName, level, "Asn1SetObject");
        }

        public string DeclaredTypeName
        {
            get { return _declaredTypeName; }
        }
        public bool RequiresNewTypeDeclaration()
        {
            return true;
        }


        public string ConstraintVariable { get { return "this"; } }
    }


#if fff


            foreach (SequenceOrSetType.Child ch in pThis.m_children.Values)
            {
                csFile.WriteLine();

                ICSharpType childType = ch.m_type as ICSharpType;
                string propName = C.ID(ch.m_childVarName.Substring(0, 1).ToUpper() + ch.m_childVarName.Substring(1));

                if (childType.RequiresNewTypeDeclaration())
                {
                    childType.DeclareType(csFile, propName, level);
                    csFile.WriteLine();
                }
                

                csFile.WL(level, "public {0} {1}", ((ICSharpType)ch.m_type).DeclaredTypeName, C.ID(ch.m_childVarName));
                csFile.WL(level++, "{");

                csFile.WL(level, "get {{ return m_children[\"{0}\"].m_asn1Object as {1}; }}", C.ID(ch.m_childVarName), ((ICSharpType)ch.m_type).DeclaredTypeName);

                csFile.WL(--level, "}");


                csFile.WL(level, "public {0} Create_{1}()", childType.DeclaredTypeName, C.ID(ch.m_childVarName));
                csFile.WL(level++, "{");
                csFile.WL(level, "{0} ret = new {0}();",childType.DeclaredTypeName);
                if (!childType.RequiresNewTypeDeclaration())
                    childType.WriteConstructorCode(csFile, level, "ret", ch.m_type.m_constraints);

                csFile.WL(level, "m_children[\"{0}\"].m_asn1Object = ret;", C.ID(ch.m_childVarName));

                csFile.WL(level, "return ret;");
                csFile.WL(--level, "}");

            }

            csFile.WL(level, "public {0}()", TypeName);
            csFile.WL(level++, "{");
            csFile.WL(level, "OptionalNamedChild ch;");
            foreach (SequenceOrSetType.Child ch in pThis.m_children.Values)
            {
                csFile.WL(level, "ch = new OptionalNamedChild(\"{0}\", null, Create_{0}, {1}, null);", C.ID(ch.m_childVarName), (ch.m_optional ? "true" : "false"));

                csFile.WL(level, "m_children.Add(\"{0}\", ch);", C.ID(ch.m_childVarName));

            }

            csFile.WL(--level, "}");
           

            csFile.WL(--level, "}");

#endif




    public class CSharpChoiceType : ChoiceType, ICSharpType
    {
        private string _declaredTypeName = string.Empty;


        public void DeclareType(StreamWriterLevel csFile, string TypeName, int level)
        {
            _declaredTypeName = TypeName;
            csFile.WL(level, "public class {0} : Asn1ChoiceObject", TypeName);
            csFile.WL(level++, "{");

            foreach (ChoiceChild ch in m_children.Values)
            {
                csFile.WriteLine();
                ICSharpType childType = ch.m_type as ICSharpType;
                string propName = C.ID(ch.m_childVarName.Substring(0, 1).ToUpper() + ch.m_childVarName.Substring(1));

                if (childType.RequiresNewTypeDeclaration())
                {
                    childType.DeclareType(csFile, propName, level);
                    csFile.WriteLine();
                }


                csFile.WL(level, "public {0} {1}", ((ICSharpType)ch.m_type).DeclaredTypeName, C.ID(ch.m_childVarName));
                csFile.WL(level++, "{");

                csFile.WL(level, "get {{ return m_children[ClassDef.m_children[\"{0}\"].m_index] as {1}; }}", C.ID(ch.m_childVarName), ((ICSharpType)ch.m_type).DeclaredTypeName);
                //
                csFile.WL(--level, "}");


                csFile.WL(level, "public {0} Create_{1}()", childType.DeclaredTypeName, C.ID(ch.m_childVarName));
                csFile.WL(level++, "{");
                //csFile.WL(level, "{0} ret = new {0}();", childType.DeclaredTypeName);
                //csFile.WL(level, "if (m_AlternativeName != string.Empty)");
                //csFile.WL(level + 1, "m_children[m_AlternativeName].m_asn1Object = null;");
                //csFile.WL(level, "m_children[\"{0}\"].m_asn1Object = ret;", C.ID(ch.m_childVarName));
                //csFile.WL(level, "m_AlternativeName = \"{0}\";", C.ID(ch.m_childVarName));
                csFile.WL(level, "return CreateChild(\"{0}\") as {1};", C.ID(ch.m_childVarName), childType.DeclaredTypeName);
                csFile.WL(--level, "}");

            }

            CSharpType.WriteEncodeDecodeMethods(this, csFile, level);

            csFile.WL(level, "static Asn1CompositeClass<NamedChild> _clsDef = new {0}ClassDefinition();", TypeName);
            csFile.WL(level, "public override Asn1CompositeClass<NamedChild> ClassDef");
            csFile.WL(level++, "{");
            csFile.WL(level, "get");
            csFile.WL(level++, "{");
            csFile.WL(level, "return _clsDef;");
            csFile.WL(--level, "}");
            csFile.WL(--level, "}");


            csFile.WL(level, "public {0}()", TypeName);
            csFile.WL(level++, "{");
            csFile.WL(level, "m_children = new Asn1Object[{0}];", m_children.Count);
            csFile.WL(--level, "}");

            //class definition

            csFile.WL(level, "public class {0}ClassDefinition : Asn1CompositeClass<NamedChild>", TypeName);
            csFile.WL(level++, "{");

            csFile.WL(level, "public {0}ClassDefinition()", TypeName);
            csFile.WL(level++, "{");

 
            csFile.WL(level, "NamedChild ch;");
            int idx = 0;
            foreach (ChoiceChild ch in m_children.Values)
            {
                ICSharpType childType = ch.m_type as ICSharpType;

                csFile.WL(level, "ch = new NamedChild(\"{0}\", {1}, delegate() {{return new {2}();}});", C.ID(ch.m_childVarName), idx, childType.DeclaredTypeName);

                idx++;

                ChoiceType chChild = ch.m_type.GetFinalType() as ChoiceType;

                if (chChild != null && !ch.m_type.IsTagged())
                {
//                    csFile.WL(level, "ch.UnTaggedChoice = true;");
//                    csFile.WL(level, "ch.m_childrenTags = new List<Tag>();");

                    List<Asn1Type.TagSequence> tags = chChild.getChildrenTags();
                    foreach (Asn1Type.TagSequence tgSq in tags)
                    {
//                        csFile.WL(level, "ch.m_childrenTags.Add(new Tag({0}, TagClass.{1}));", tgSq.m_tags[0].m_tag, tgSq.m_tags[0].m_class);

                        csFile.WL(level, "m_posChildren.Add(0x{0:X}, ch);", CSharpSequenceOrSetType.CalculateTag(tgSq.m_tags[0]));
                    }
                }
                else
                {
                    Asn1Type.Tag lstTag = ch.m_type.Tags.m_tags[0];
//                    csFile.WL(level, "ch.m_Tag = new Tag({0}, TagClass.{1});", lstTag.m_tag, lstTag.m_class);
                    csFile.WL(level, "m_posChildren.Add(0x{0:X}, ch);", CSharpSequenceOrSetType.CalculateTag(lstTag));

                }


                csFile.WL(level, "m_children.Add(\"{0}\", ch);", C.ID(ch.m_childVarName));

            }

            csFile.WL(--level, "}");
            csFile.WL(--level, "}");
           

            csFile.WL(--level, "}");


        }

        public string DeclaredTypeName
        {
            get { return _declaredTypeName; }
        }
        public bool RequiresNewTypeDeclaration()
        {
            return true;
        }


        public string ConstraintVariable { get { return "this"; } }

    }


}