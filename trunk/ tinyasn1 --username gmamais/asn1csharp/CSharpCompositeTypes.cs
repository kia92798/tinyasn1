using System;
using System.Collections.Generic;
using System.Text;
using tinyAsn1;

namespace asn1csharp
{
    public static class CSharpSequenceOrSetType
    {

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

        public void WriteConstructorCode(StreamWriterLevel csFile, int level, string pThis, List<IConstraint> constraints)
        {
//            throw new Exception("Internal Error: This method should never be called for a sequence");
        }

        public string ConstraintType { get { return DeclaredTypeName; } }

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

        public void WriteConstructorCode(StreamWriterLevel csFile, int level, string pThis, List<IConstraint> constraints)
        {
//            throw new Exception("Internal Error: This method should never be called for a set");
        }

        public string ConstraintType { get { return DeclaredTypeName; } }
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

                csFile.WL(level, "get {{ return m_children[\"{0}\"].m_asn1Object as {1}; }}", C.ID(ch.m_childVarName), ((ICSharpType)ch.m_type).DeclaredTypeName);

                csFile.WL(--level, "}");


                csFile.WL(level, "public {0} Create_{1}()", childType.DeclaredTypeName, C.ID(ch.m_childVarName));
                csFile.WL(level++, "{");
                csFile.WL(level, "{0} ret = new {0}();", childType.DeclaredTypeName);
                if (!childType.RequiresNewTypeDeclaration())
                    childType.WriteConstructorCode(csFile, level, "ret", ch.m_type.m_constraints);
                csFile.WL(level, "if (m_AlternativeName != string.Empty)");
                csFile.WL(level + 1, "m_children[m_AlternativeName].m_asn1Object = null;");
                csFile.WL(level, "m_children[\"{0}\"].m_asn1Object = ret;", C.ID(ch.m_childVarName));
                csFile.WL(level, "m_AlternativeName = \"{0}\";", C.ID(ch.m_childVarName));
                csFile.WL(level, "return ret;");
                csFile.WL(--level, "}");

            }

            csFile.WL(level, "public {0}()", TypeName);
            csFile.WL(level++, "{");
            csFile.WL(level, "NamedChild ch;");
            foreach (ChoiceChild ch in m_children.Values)
            {
                csFile.WL(level, "ch = new NamedChild(\"{0}\", null, Create_{0});", C.ID(ch.m_childVarName));

                csFile.WL(level, "m_children.Add(\"{0}\", ch);", C.ID(ch.m_childVarName));

            }

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

        public void WriteConstructorCode(StreamWriterLevel csFile, int level, string pThis, List<IConstraint> constraints)
        {
//            throw new Exception("Internal Error: This method should never be called for a choice");
        }

        public string ConstraintType { get { return DeclaredTypeName; } }

    }


}