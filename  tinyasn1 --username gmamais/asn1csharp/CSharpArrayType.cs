using System;
using System.Collections.Generic;
using System.Text;
using tinyAsn1;
using System.Diagnostics;

namespace asn1csharp
{
    public static class CSharpArrayType
    {
        public static void DeclareTypeA(ArrayType pThis, StreamWriterLevel csFile, string TypeName, int level,
            string baseClassName, out string DeclaredTypeName)
        {
            ICSharpType childType = pThis.m_type as ICSharpType;


            if (childType.RequiresNewTypeDeclaration())
            {
                DeclaredTypeName = TypeName;

                string internalTypeName = "InternalType";

                int levCount = 0;
                StackTrace str = new StackTrace();
                foreach (StackFrame frm in str.GetFrames())
                    if (frm.GetMethod().Name.Contains("DeclareTypeA"))
                        levCount++;
                if (levCount > 1)
                    internalTypeName += (--levCount).ToString();
                

                csFile.WL(level, "public class {0} : {1}<{0}.{2}>", TypeName, baseClassName, internalTypeName);
                csFile.WL(level++, "{");

                childType.DeclareType(csFile, internalTypeName, level);
                csFile.WriteLine();
            }
            else
            {
                DeclaredTypeName = baseClassName + "<" + childType.DeclaredTypeName + ">";
                csFile.WL(level, "public class {0} : {1}<{2}>", TypeName, baseClassName, childType.DeclaredTypeName);
                csFile.WL(level++, "{");
            }

            CSharpType.WriteEncodeDecodeMethods(pThis, csFile, level);
            CSharpType.WriteIsConstraintValid(pThis, csFile, level, "m_children", "");

            //csFile.WL(level, "public {0}()", TypeName);
            //csFile.WL(level++, "{");
            //WriteConstructorCodeA(pThis, csFile, level, "", pThis.m_constraints, pThis.m_tag);
            //csFile.WL(--level, "}");


            csFile.WL(--level, "}");
        }

#if obsolete
        public static void WriteConstructorCodeA(ArrayType pThis, StreamWriterLevel csFile, int level, string pThisString, List<IConstraint> constraints, Asn1Type.Tag tag)
        {
            int levCount=0;
            StackTrace str = new StackTrace();
            foreach (StackFrame frm in str.GetFrames())
                if (frm.GetMethod().Name.Contains("WriteConstructorCodeA"))
                    levCount++;

            string retVarName = "ch" + levCount.ToString();
            ICSharpType childType = pThis.m_type as ICSharpType;

            string prefix = pThisString;
            if (pThisString != "")
                prefix += ".";

            csFile.WL(level, "{0}m_child.createObj = new Func<{1}>(delegate()", prefix,childType.DeclaredTypeName);
            csFile.WL(level++, "{");
            csFile.WL(level, "{0} {1} = new {0}();", childType.DeclaredTypeName, retVarName);
            csFile.WL(level, "return {0};", retVarName);
            csFile.WL(--level, "});");


            ChoiceType chChild = pThis.m_type.GetFinalType() as ChoiceType;
            if (chChild != null && !pThis.m_type.IsTagged())
            {
                csFile.WL(level, "{0}m_child.UnTaggedChoice = true;", prefix);
                csFile.WL(level, "{0}m_child.m_childrenTags = new List<Tag>();", prefix);

                List<Asn1Type.TagSequence> tags = chChild.getChildrenTags();
                foreach (Asn1Type.TagSequence tgSq in tags)
                {
                    csFile.WL(level, "{0}m_child.m_childrenTags.Add(new Tag({1}, TagClass.{2}));",prefix, tgSq.m_tags[0].m_tag, tgSq.m_tags[0].m_class);
                }
            }
            else
            {
                Asn1Type.Tag lstTag = pThis.m_type.Tags.m_tags[0];
                csFile.WL(level, "{0}m_child.m_Tag = new Tag({1}, TagClass.{2});",prefix, lstTag.m_tag, lstTag.m_class);

            }



        }
#endif

    }


    public class CSharpSequenceOfType : SequenceOfType, ICSharpType
    {
        private string _declaredTypeName = "Asn1SequenceOfObject";


        public void DeclareType(StreamWriterLevel csFile, string TypeName, int level)
        {
            CSharpArrayType.DeclareTypeA(this, csFile, TypeName, level, _declaredTypeName, out _declaredTypeName);
        }

        public string DeclaredTypeName
        {
            get { 
                if ( ((ICSharpType)m_type).RequiresNewTypeDeclaration())
                    return _declaredTypeName;
                return _declaredTypeName + "<" + ((ICSharpType)m_type).DeclaredTypeName + ">";
            }
        }

        public bool RequiresNewTypeDeclaration()
        {
//            return ((ICSharpType)m_type).RequiresNewTypeDeclaration();
            return true;
        }

        public string ConstraintVariable { get { return "this"; } }

    }

    public class CSharpSetOfType : SetOfType, ICSharpType
    {
        private string _declaredTypeName = "Asn1SetOfObject";


        public void DeclareType(StreamWriterLevel csFile, string TypeName, int level)
        {
            CSharpArrayType.DeclareTypeA(this, csFile, TypeName, level, _declaredTypeName, out _declaredTypeName);
        }

        public string DeclaredTypeName
        {
            get { return _declaredTypeName; }
        }
        public bool RequiresNewTypeDeclaration()
        {
//            return ((ICSharpType)m_type).RequiresNewTypeDeclaration();
            return true;

        }

        public string ConstraintVariable { get { return "this"; } }

    }

}