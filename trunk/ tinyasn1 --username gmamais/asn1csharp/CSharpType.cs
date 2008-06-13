using System;
using System.Collections.Generic;
using System.Text;
using tinyAsn1;

namespace asn1csharp
{
    public interface ICSharpType
    {

        void DeclareType(StreamWriterLevel csFile, string TypeName, int level);

        string DeclaredTypeName { get;}

        bool RequiresNewTypeDeclaration();

        void WriteConstructorCode(StreamWriterLevel csFile, int level, string pThis, List<IConstraint> constraints);

        string ConstraintType {get;}

    }

    public static class CSharpType
    {
        public static void DeclareType(Asn1Type pThis, StreamWriterLevel csFile, string TypeName, int level, string baseClassName,
            out string DeclaredTypeName)
        {
            
            DeclaredTypeName = TypeName;

            csFile.WL(level, "public class {0} : {1}", DeclaredTypeName, baseClassName);
            csFile.WL(level++, "{");
            csFile.WL(level, "public {0}()", DeclaredTypeName);
            csFile.WL(level++, "{");
            WriteConstructorCode(pThis, csFile, level, "", pThis.m_constraints);
            csFile.WL(--level, "}");
            csFile.WL(--level, "}");

        }

        public static void WriteConstructorCode(Asn1Type pThis, StreamWriterLevel csFile, int level, string pThisString, List<IConstraint> constraints)
        {
            string prefix = pThisString;
            if (pThisString != "")
                prefix += ".";

            csFile.WL(level, "//Write constraints");
            foreach (ICSharpConstraint con in constraints)
            {
                csFile.WL(level, "{0}m_constraints.Add(new Func<{1}, bool>(delegate({1} val) {{ return {2}; }}));", prefix, ((ICSharpType)pThis).ConstraintType, con.PrintConstraintCode("val","") );
            }

        }
    }




    public class CSharpIntegerType : IntegerType, ICSharpType
    {
        private string _declaredTypeName = "Asn1IntegerObject";

        public void DeclareType(StreamWriterLevel csFile, string TypeName, int level)
        {
            CSharpType.DeclareType(this, csFile, TypeName, level, _declaredTypeName, out _declaredTypeName);
        }

        public string DeclaredTypeName
        {
            get { return _declaredTypeName; }
        }
        public bool RequiresNewTypeDeclaration()
        {
            return false;
        }

        public void WriteConstructorCode(StreamWriterLevel csFile, int level, string pThis, List<IConstraint> constraints)
        {
            CSharpType.WriteConstructorCode(this, csFile, level, pThis, constraints);
        }
        public string ConstraintType { get { return "long"; } }


    }

    public class CSharpBooleanType : BooleanType, ICSharpType
    {
        private string _declaredTypeName = "Asn1BoolObject";

        public void DeclareType(StreamWriterLevel csFile, string TypeName, int level)
        {
            CSharpType.DeclareType(this, csFile, TypeName, level, _declaredTypeName, out _declaredTypeName);
        }

        public string DeclaredTypeName
        {
            get { return _declaredTypeName; }
        }
        public bool RequiresNewTypeDeclaration()
        {
            return false;
        }

        public void WriteConstructorCode(StreamWriterLevel csFile, int level, string pThis, List<IConstraint> constraints)
        {
            CSharpType.WriteConstructorCode(this, csFile, level, pThis, constraints);
        }
        public string ConstraintType { get { return "bool"; } }
    }

    public class CSharpRealType : RealType, ICSharpType
    {
        private string _declaredTypeName = "Asn1RealObject";

        public void DeclareType(StreamWriterLevel csFile, string TypeName, int level)
        {
            CSharpType.DeclareType(this, csFile, TypeName, level, _declaredTypeName, out _declaredTypeName);
        }

        public string DeclaredTypeName
        {
            get { return _declaredTypeName; }
        }
        public bool RequiresNewTypeDeclaration()
        {
            return false;
        }

        public void WriteConstructorCode(StreamWriterLevel csFile, int level, string pThis, List<IConstraint> constraints)
        {
            CSharpType.WriteConstructorCode(this, csFile, level, pThis, constraints);
        }
        public string ConstraintType { get { return "double"; } }
    }

    public class CSharpIA5StringType : IA5StringType, ICSharpType
    {
        private string _declaredTypeName = "Asn1IA5StringObject";

        public void DeclareType(StreamWriterLevel csFile, string TypeName, int level)
        {
            CSharpType.DeclareType(this, csFile, TypeName, level, _declaredTypeName, out _declaredTypeName);
        }

        public string DeclaredTypeName
        {
            get { return _declaredTypeName; }
        }
        public bool RequiresNewTypeDeclaration()
        {
            return false;
        }

        public void WriteConstructorCode(StreamWriterLevel csFile, int level, string pThis, List<IConstraint> constraints)
        {
            CSharpType.WriteConstructorCode(this, csFile, level, pThis, constraints);
        }
        public string ConstraintType { get { return "string"; } }
    }

    public class CSharpNumericStringType : NumericStringType, ICSharpType
    {
        private string _declaredTypeName = "Asn1NumericStringObject";

        public void DeclareType(StreamWriterLevel csFile, string TypeName, int level)
        {
            CSharpType.DeclareType(this, csFile, TypeName, level, _declaredTypeName, out _declaredTypeName);
        }

        public string DeclaredTypeName
        {
            get { return _declaredTypeName; }
        }
        public bool RequiresNewTypeDeclaration()
        {
            return false;
        }

        public void WriteConstructorCode(StreamWriterLevel csFile, int level, string pThis, List<IConstraint> constraints)
        {
            CSharpType.WriteConstructorCode(this, csFile, level, pThis, constraints);
        }
        public string ConstraintType { get { return "string"; } }
    }


    public class CSharpEnumeratedType : EnumeratedType, ICSharpType
    {
        private string _declaredTypeName = string.Empty;

        public void DeclareType(StreamWriterLevel csFile, string TypeName, int level)
        {
            _declaredTypeName = TypeName;

            csFile.WL(level, "public class {0} : Asn1EnumeratedObject<{0}.Enumerated>", DeclaredTypeName);
            csFile.WL(level++, "{");
            csFile.WL(level,"public enum Enumerated");
            csFile.WL(level++, "{");
            foreach(EnumeratedType.Item it in m_enumValues.Values) 
            {
                csFile.WL(level, "{0} = {1},", it.CID, it.m_value);
            }
            csFile.WL(--level, "}");

            csFile.WL(level, "public {0}()", DeclaredTypeName);
            csFile.WL(level++, "{");
            WriteConstructorCode(csFile, level, "", m_constraints);
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

        public void WriteConstructorCode(StreamWriterLevel csFile, int level, string pThisString, List<IConstraint> constraints)
        {
            string prefix = pThisString;
            if (pThisString != "")
                prefix += ".";

            csFile.WL(level, "//Write constraints");
            foreach (ICSharpConstraint con in constraints)
            {
                csFile.WL(level, "{0}m_constraints.Add(new Func<{1}, bool>(delegate({1} val) {{ return {2}; }}));", 
                    prefix, ConstraintType, con.PrintConstraintCode("val", ConstraintType+"."));
            }
        }
        public string ConstraintType { get { return DeclaredTypeName + ".Enumerated"; } }
    }

    public class CSharpOctetStringType : OctetStringType, ICSharpType
    {
        private string _declaredTypeName = "Asn1OctetStringObject";

        public void DeclareType(StreamWriterLevel csFile, string TypeName, int level)
        {
            CSharpType.DeclareType(this, csFile, TypeName, level, _declaredTypeName, out _declaredTypeName);
        }

        public string DeclaredTypeName
        {
            get { return _declaredTypeName; }
        }
        public bool RequiresNewTypeDeclaration()
        {
            return false;
        }

        public void WriteConstructorCode(StreamWriterLevel csFile, int level, string pThis, List<IConstraint> constraints)
        {
            CSharpType.WriteConstructorCode(this, csFile, level, pThis, constraints);
        }
        public string ConstraintType { get { return "List<byte>"; } }
    }

    public class CSharpBitStringType : BitStringType, ICSharpType
    {
        private string _declaredTypeName = "Asn1BitStringObject";

        public void DeclareType(StreamWriterLevel csFile, string TypeName, int level)
        {
            CSharpType.DeclareType(this, csFile, TypeName, level, _declaredTypeName, out _declaredTypeName);
        }

        public string DeclaredTypeName
        {
            get { return _declaredTypeName; }
        }
        public bool RequiresNewTypeDeclaration()
        {
            return false;
        }

        public void WriteConstructorCode(StreamWriterLevel csFile, int level, string pThis, List<IConstraint> constraints)
        {
            CSharpType.WriteConstructorCode(this, csFile, level, pThis, constraints);
        }
        public string ConstraintType { get { return "List<byte>"; } }
    }

    public class CSharpReferenceType : ReferenceType, ICSharpType
    {
        private string _declaredTypeName = string.Empty;

        public void DeclareType(StreamWriterLevel csFile, string TypeName, int level)
        {
            _declaredTypeName = C.ID(m_referencedTypeName);
            CSharpType.DeclareType(this, csFile, TypeName, level, _declaredTypeName, out _declaredTypeName);
        }

        public string DeclaredTypeName
        {
            get { 
                if (_declaredTypeName == string.Empty)
                    _declaredTypeName = C.ID(m_referencedTypeName);
                return _declaredTypeName; 
            }
        }

        public bool RequiresNewTypeDeclaration()
        {
            return false;
        }

        public void WriteConstructorCode(StreamWriterLevel csFile, int level, string pThis, List<IConstraint> constraints)
        {
//            if ( !((ICSharpType)Type).RequiresNewTypeDeclaration())
                ((ICSharpType)Type).WriteConstructorCode(csFile, level, pThis, constraints);
        }
        public string ConstraintType { get { return ((ICSharpType)GetFinalType()).ConstraintType; } }
    }

    public class CSharpNullType : NullType, ICSharpType
    {
        private string _declaredTypeName = "Asn1NullObject";

        public void DeclareType(StreamWriterLevel csFile, string TypeName, int level)
        {
            CSharpType.DeclareType(this, csFile, TypeName, level, _declaredTypeName, out _declaredTypeName);
        }

        public string DeclaredTypeName
        {
            get { return _declaredTypeName; }
        }
        public bool RequiresNewTypeDeclaration()
        {
            return false;
        }

        public void WriteConstructorCode(StreamWriterLevel csFile, int level, string pThis, List<IConstraint> constraints)
        {
            CSharpType.WriteConstructorCode(this, csFile, level, pThis, constraints);
        }
        public string ConstraintType { get { return "int"; } }
    }

}
