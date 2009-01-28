using System;
using System.Collections.Generic;
using System.Text;
using tinyAsn1;
using semantix.util;

namespace asn1csharp
{
    public interface ICSharpType
    {

        void DeclareType(StreamWriterLevel csFile, string TypeName, int level);

        string DeclaredTypeName { get;}

        bool RequiresNewTypeDeclaration();


        string ConstraintVariable {get;}

    }

    public static class CSharpType
    {
        public static void DeclareType(Asn1Type pThis, StreamWriterLevel csFile, string TypeName, int level, string baseClassName,
            out string DeclaredTypeName, string valueName, string enumPrefix)
        {
            
            DeclaredTypeName = TypeName;

            csFile.WL(level, "public partial class {0} : {1}", DeclaredTypeName, baseClassName);
            csFile.WL(level++, "{");
            WriteCustomAttrList(pThis, csFile, level);
            WriteEncodeDecodeMethods(pThis, csFile, level);
            WriteIsConstraintValid(pThis, csFile, level, valueName, enumPrefix);
            csFile.WL(--level, "}");

        }

        public static void WriteCustomAttrList(Asn1Type pThis, StreamWriterLevel csFile, int level)
        {
            if (pThis.m_CustomAttributes.Count == 0)
                return;
            csFile.WL(level, "private static Dictionary<string, string> m_CustomAttrs = new Dictionary<string, string>()");
            csFile.WL(level++, "{");
            foreach (var kv in pThis.m_CustomAttributes)
            {
                csFile.WL(level, "{{\"{0}\",\"{1}\"}},", kv.Key, kv.Value);
            }

            csFile.WL(--level, "};");
            csFile.WL(level, "public override Dictionary<string, string> CustomAttrs { get { return m_CustomAttrs; } }");

        }

        public static void WriteIsConstraintValid(Asn1Type pThis, StreamWriterLevel csFile, int level, 
            string valueName, string enumPrefix)
        {
            if (pThis.m_constraints.Count == 0)
                return;

            csFile.WL(level, "public override bool IsConstraintValid()");
            csFile.WL(level++, "{");
            csFile.P(level);
            csFile.Write("return ");
            foreach (ICSharpConstraint con in pThis.m_constraints)
            {
                csFile.Write("{0} && ",con.PrintConstraintCode(valueName,enumPrefix));

            }
            csFile.WriteLine("base.IsConstraintValid();");
            csFile.WL(--level, "}");

        }


        public static void WriteEncodeDecodeMethods(Asn1Type pThis, StreamWriterLevel csFile, int level)
        {
            if (pThis.m_tag == null)
                return;
            csFile.WriteLine();
            csFile.WL(level, "public override uint Encode(Stream strm, EncodingRules encRule)");
            csFile.WL(level++, "{");
            if (pThis.m_tag.m_taggingMode== TaggingMode.EXPLICIT)
//                csFile.WL(level, "return Encode(strm, encRule, TagClass.{0}, false, {1});", pThis.m_tag.m_class, pThis.m_tag.m_tag);
                csFile.WL(level, "return Encode(strm, encRule, false, 0x{0:X});", CSharpSequenceOrSetType.CalculateTag(pThis.m_tag));
            else
                csFile.WL(level, "return Encode(strm, encRule, IsPrimitive, 0x{0:X});", CSharpSequenceOrSetType.CalculateTag(pThis.m_tag));
//                csFile.WL(level, "return Encode(strm, encRule, TagClass.{0}, IsPrimitive, {1});", pThis.m_tag.m_class, pThis.m_tag.m_tag);
            csFile.WL(--level, "}");

            csFile.WriteLine();
            csFile.WL(level, "public override uint Decode(Stream strm, EncodingRules encRule)");
            csFile.WL(level++, "{");
            if (pThis.m_tag.m_taggingMode == TaggingMode.EXPLICIT)
                csFile.WL(level, "return Decode(strm, encRule, false, 0x{0:X});", CSharpSequenceOrSetType.CalculateTag(pThis.m_tag));
//                csFile.WL(level, "return Decode(strm, encRule, TagClass.{0}, false, {1});", pThis.m_tag.m_class, pThis.m_tag.m_tag);
            else
                csFile.WL(level, "return Decode(strm, encRule, IsPrimitive, 0x{0:X});", CSharpSequenceOrSetType.CalculateTag(pThis.m_tag));
//                csFile.WL(level, "return Decode(strm, encRule, TagClass.{0}, IsPrimitive, {1});", pThis.m_tag.m_class, pThis.m_tag.m_tag);
            csFile.WL(--level, "}");

            if (pThis.m_tag.m_taggingMode == TaggingMode.EXPLICIT)
            {
                csFile.WriteLine();
                csFile.WL(level, "public override uint EncodeContent(Stream strm, EncodingRules encRule)");
                csFile.WL(level++, "{");
                csFile.WL(level, "return base.Encode(strm, encRule);");
                csFile.WL(--level, "}");

                csFile.WriteLine();
                csFile.WL(level, "public override uint DecodeContent(Stream strm, EncodingRules encRule, uint dataLen)");
                csFile.WL(level++, "{");
                csFile.WL(level, "return base.Decode(strm, encRule);");
                csFile.WL(--level, "}");
            }

        }
    }




    public class CSharpIntegerType : IntegerType, ICSharpType
    {
        private string _declaredTypeName = "Asn1IntegerObject";

        public void DeclareType(StreamWriterLevel csFile, string TypeName, int level)
        {
            CSharpType.DeclareType(this, csFile, TypeName, level, _declaredTypeName, out _declaredTypeName, "Value","");
        }

        public string DeclaredTypeName
        {
            get { return _declaredTypeName; }
        }
        public bool RequiresNewTypeDeclaration()
        {
            return true;
        }

        public string ConstraintVariable { get { return "Value"; } }


    }

    public class CSharpBooleanType : BooleanType, ICSharpType
    {
        private string _declaredTypeName = "Asn1BoolObject";

        public void DeclareType(StreamWriterLevel csFile, string TypeName, int level)
        {
            CSharpType.DeclareType(this, csFile, TypeName, level, _declaredTypeName, out _declaredTypeName, "Value", "");
        }

        public string DeclaredTypeName
        {
            get { return _declaredTypeName; }
        }
        public bool RequiresNewTypeDeclaration()
        {
            return true;
        }

        public string ConstraintVariable { get { return "Value"; } }
    }

    public class CSharpRealType : RealType, ICSharpType
    {
        private string _declaredTypeName = "Asn1RealObject";

        public void DeclareType(StreamWriterLevel csFile, string TypeName, int level)
        {
            CSharpType.DeclareType(this, csFile, TypeName, level, _declaredTypeName, out _declaredTypeName, "Value", "");
        }

        public string DeclaredTypeName
        {
            get { return _declaredTypeName; }
        }
        public bool RequiresNewTypeDeclaration()
        {
            return true;
        }

        public string ConstraintVariable { get { return "Value"; } }
    }

    public class CSharpIA5StringType : IA5StringType, ICSharpType
    {
        private string _declaredTypeName = "Asn1IA5StringObject";

        public void DeclareType(StreamWriterLevel csFile, string TypeName, int level)
        {
            CSharpType.DeclareType(this, csFile, TypeName, level, _declaredTypeName, out _declaredTypeName, "Value", "");
        }

        public string DeclaredTypeName
        {
            get { return _declaredTypeName; }
        }
        public bool RequiresNewTypeDeclaration()
        {
            return true;
        }

        public string ConstraintVariable { get { return "Value"; } }
    }

    public class CSharpNumericStringType : NumericStringType, ICSharpType
    {
        private string _declaredTypeName = "Asn1NumericStringObject";

        public void DeclareType(StreamWriterLevel csFile, string TypeName, int level)
        {
            CSharpType.DeclareType(this, csFile, TypeName, level, _declaredTypeName, out _declaredTypeName, "Value", "");
        }

        public string DeclaredTypeName
        {
            get { return _declaredTypeName; }
        }
        public bool RequiresNewTypeDeclaration()
        {
            return true;
        }

        public string ConstraintVariable { get { return "Value"; } }
    }


    public class CSharpEnumeratedType : EnumeratedType, ICSharpType
    {
        private string _declaredTypeName = string.Empty;

        public void DeclareType(StreamWriterLevel csFile, string TypeName, int level)
        {
            _declaredTypeName = TypeName;

            csFile.WL(level, "public partial class {0} : Asn1EnumeratedObject<{0}.Enumerated>", DeclaredTypeName);
            csFile.WL(level++, "{");
            csFile.WL(level,"public enum Enumerated");
            csFile.WL(level++, "{");
            foreach(EnumeratedType.Item it in m_enumValues.Values) 
            {
                csFile.WL(level, "{0} = {1},", it.CID, it.m_value);
            }
            csFile.WL(--level, "}");

            csFile.WL(level, "protected override long ValueAsLong { get {return (long)Value;}}");
            CSharpType.WriteEncodeDecodeMethods(this, csFile, level);


            if (m_constraints.Count > 0)
            {

                csFile.WL(level, "public override bool IsConstraintValid()");
                csFile.WL(level++, "{");
                csFile.WL(level, "bool ret=true;");


                foreach (ICSharpConstraint con in m_constraints)
                {
                    csFile.WL(level, "ret = ret && {0};", con.PrintConstraintCode("Value", DeclaredTypeName + ".Enumerated."));

                }
                csFile.WL(level, "return base.IsConstraintValid() && ret;");
                csFile.WL(--level, "}");
            }


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

        public string ConstraintVariable { get { return "Value"; } }
    }

    public class CSharpOctetStringType : OctetStringType, ICSharpType
    {
        private string _declaredTypeName = "Asn1OctetStringObject";

        public void DeclareType(StreamWriterLevel csFile, string TypeName, int level)
        {
            CSharpType.DeclareType(this, csFile, TypeName, level, _declaredTypeName, out _declaredTypeName, "m_Data", "");
        }

        public string DeclaredTypeName
        {
            get { return _declaredTypeName; }
        }
        public bool RequiresNewTypeDeclaration()
        {
            return true;
        }

        public string ConstraintVariable { get { return "Value"; } }
    }

    public class CSharpBitStringType : BitStringType, ICSharpType
    {
        private string _declaredTypeName = "Asn1BitStringObject";

        public void DeclareType(StreamWriterLevel csFile, string TypeName, int level)
        {
            CSharpType.DeclareType(this, csFile, TypeName, level, _declaredTypeName, out _declaredTypeName, "m_Data", "");
        }

        public string DeclaredTypeName
        {
            get { return _declaredTypeName; }
        }
        public bool RequiresNewTypeDeclaration()
        {
            return true;
        }

        public string ConstraintVariable { get { return "m_Data"; } }
    }

    public class CSharpReferenceType : ReferenceType, ICSharpType
    {
        private string _declaredTypeName = string.Empty;

        public void DeclareType(StreamWriterLevel csFile, string TypeName, int level)
        {
            _declaredTypeName = C.ID(m_referencedTypeName);
            string enumPrefix = string.Empty;
            if (GetFinalType() is EnumeratedType)
                enumPrefix = DeclaredTypeName + ".Enumerated.";

            CSharpType.DeclareType(this, csFile, TypeName, level, _declaredTypeName, out _declaredTypeName, ConstraintVariable, enumPrefix);
        }

        public string DeclaredTypeName
        {
            get  { 
                if (_declaredTypeName == string.Empty)
                    _declaredTypeName = C.ID(m_referencedTypeName);
                return _declaredTypeName; 
            }
        }

        public bool RequiresNewTypeDeclaration()
        {
            if (m_constraints.Count == 0 && m_tag == null)
                return false;
            return true;
        }

        public string ConstraintVariable { get { return ((ICSharpType)GetFinalType()).ConstraintVariable; } }
    }

    public class CSharpNullType : NullType, ICSharpType
    {
        private string _declaredTypeName = "Asn1NullObject";

        public void DeclareType(StreamWriterLevel csFile, string TypeName, int level)
        {
            CSharpType.DeclareType(this, csFile, TypeName, level, _declaredTypeName, out _declaredTypeName,"","");
        }

        public string DeclaredTypeName
        {
            get { return _declaredTypeName; }
        }
        public bool RequiresNewTypeDeclaration()
        {
            return true;
        }

        public string ConstraintVariable { get { return ""; } }
    }

}
