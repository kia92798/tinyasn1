using System;
using System.Collections.Generic;
using System.Text;
using tinyAsn1;
using System.Diagnostics;

namespace asn1csharp
{
    public static class CSharpArrayType
    {
        public static void DeclareType(ArrayType pThis, StreamWriterLevel csFile, string TypeName, int level,
            string baseClassName, out string DeclaredTypeName)
        {
            ICSharpType childType = pThis.m_type as ICSharpType;


            if (childType.RequiresNewTypeDeclaration())
            {
                DeclaredTypeName = TypeName;

                csFile.WL(level, "public class {0} : {1}<{0}.InternalType>", TypeName, baseClassName);
                csFile.WL(level++, "{");

                childType.DeclareType(csFile, "InternalType", level);
                csFile.WriteLine();
            }
            else
            {
                DeclaredTypeName = baseClassName + "<" + childType.DeclaredTypeName + ">";
                csFile.WL(level, "public class {0} : {1}<{2}>", TypeName, baseClassName, childType.DeclaredTypeName);
                csFile.WL(level++, "{");
            }

            csFile.WL(level, "public {0}()", TypeName);
            csFile.WL(level++, "{");
            WriteConstructorCodeA(pThis, csFile, level, "", pThis.m_constraints);
            csFile.WL(--level, "}");


            csFile.WL(--level, "}");
        }
        
        public static void WriteConstructorCodeA(ArrayType pThis, StreamWriterLevel csFile, int level, string pThisString, List<IConstraint> constraints)
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
            if (!childType.RequiresNewTypeDeclaration())
                childType.WriteConstructorCode(csFile, level, retVarName, pThis.m_type.m_constraints);
            csFile.WL(level, "return {0};", retVarName);
            csFile.WL(--level, "});");


            csFile.WL(level, "//Write constraints");
            foreach (ICSharpConstraint con in constraints)
            {
                csFile.WL(level, "{0}m_constraints.Add(new Func<{1}, bool>(delegate({1} val) {{ return {2}; }}));", prefix, ((ICSharpType)pThis).ConstraintType, con.PrintConstraintCode("val",""));
            }

        }

    }


    public class CSharpSequenceOfType : SequenceOfType, ICSharpType
    {
        private string _declaredTypeName = "Asn1SequenceOfObject";


        public void DeclareType(StreamWriterLevel csFile, string TypeName, int level)
        {
            CSharpArrayType.DeclareType(this, csFile, TypeName, level, _declaredTypeName, out _declaredTypeName);
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
            return ((ICSharpType)m_type).RequiresNewTypeDeclaration();
        }

        public void WriteConstructorCode(StreamWriterLevel csFile, int level, string pThis, List<IConstraint> constraints)
        {
            if (RequiresNewTypeDeclaration())
                throw new Exception("Internal Error");

            CSharpArrayType.WriteConstructorCodeA(this, csFile, level, pThis, constraints);
        }
        public string ConstraintType { get { return "Asn1ArrayObject<"+((ICSharpType)m_type).DeclaredTypeName+ ">"; } }

    }

    public class CSharpSetOfType : SetOfType, ICSharpType
    {
        private string _declaredTypeName = "Asn1SetOfObject";


        public void DeclareType(StreamWriterLevel csFile, string TypeName, int level)
        {
            CSharpArrayType.DeclareType(this, csFile, TypeName, level, _declaredTypeName, out _declaredTypeName);
        }

        public string DeclaredTypeName
        {
            get { return _declaredTypeName; }
        }
        public bool RequiresNewTypeDeclaration()
        {
            return ((ICSharpType)m_type).RequiresNewTypeDeclaration();
        }

        public void WriteConstructorCode(StreamWriterLevel csFile, int level, string pThis, List<IConstraint> constraints)
        {
            if (RequiresNewTypeDeclaration())
                throw new Exception("Internal Error");

            CSharpArrayType.WriteConstructorCodeA(this, csFile, level, pThis, constraints);
        }
        public string ConstraintType { get { return DeclaredTypeName; } }

    }

}