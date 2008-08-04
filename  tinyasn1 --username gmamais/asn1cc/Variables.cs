/**=============================================================================
Definition ASN.1 variables used in asn1scc project  
================================================================================
Copyright(c) Semantix Information Technologies S.A www.semantix.gr
All rights reserved.

This source code is only intended as a supplement to the
Semantix Technical Reference and related electronic documentation 
provided with the autoICD application.
See these sources for detailed information regarding the
autoICD application.
==============================================================================*/
using System;
using System.Collections.Generic;
using System.Text;
using tinyAsn1;
using Antlr.Runtime.Tree;

namespace asn1scc
{

    public interface ISCCVariable
    {
        void PrintC(StreamWriterLevel c, int lev);
    }

    public static class SCCValue
    {
        public static void PrintC(Asn1Value pThis, StreamWriterLevel c, int lev)
        {
            c.Write(pThis.ToStringC());
        }
    }

    public static class SCCArrayValue
    {
        public static void PrintC(ArrayValue pThis, StreamWriterLevel c, int lev)
        {
            c.WriteLine("{");
            lev++;

            int cnt = pThis.m_children.Count;

            c.P(lev); c.WriteLine("{0},", cnt);

            c.P(lev); c.WriteLine("{");
            for (int i = 0; i < cnt; i++)
            {
                c.P(lev + 1);
                ((ISCCVariable)pThis.m_children[i]).PrintC(c, lev + 1);
                if (i != cnt - 1)
                    c.WriteLine(",");
                else
                    c.WriteLine();
            }
            c.P(lev); c.WriteLine("}");

            lev--;
            c.P(lev);
            c.Write("}");
        }
    }



	public class SCCBitStringValue : BitStringValue, ISCCVariable
	{
		public SCCBitStringValue(ITree antlrNode, Module module, Asn1Type type) :  base(antlrNode, module, type){}
		public SCCBitStringValue(BitStringValue o, ITree antlr) :  base( o, antlr){}
		public SCCBitStringValue(List<Int64> ids, ITree tree, Module mod, Asn1Type type) :  base(ids, tree, mod, type){}
        public void PrintC(StreamWriterLevel c, int lev)
        {
            c.WriteLine("{");
            lev++;

            List<byte> val = OctetStringValue.ConvertToOctetArray(this,false);

            int cnt = val.Count;

            c.P(lev); c.WriteLine("{0},", this.Value.Length);

            c.P(lev); c.WriteLine("{");
            for (int i = 0; i < cnt; i++)
            {
                c.P(lev + 1);
                c.Write("0x{0:X2}", val[i]);
                if (i != cnt - 1)
                    c.WriteLine(",");
                else
                    c.WriteLine();
            }
            c.P(lev); c.WriteLine("}");

            lev--;
            c.P(lev);
            c.Write("}");
        }

    }
	public class SCCBooleanValue : BooleanValue, ISCCVariable
	{
		public SCCBooleanValue(ITree antlrNode, Module module, Asn1Type type) :  base(antlrNode, module, type){}
		public SCCBooleanValue(BooleanValue o, ITree antlr) :  base( o, antlr){}
        public void PrintC(StreamWriterLevel c, int lev) {  SCCValue.PrintC(this, c, lev); }
	}
	public class SCCChoiceValue : ChoiceValue, ISCCVariable
	{
		public SCCChoiceValue(ITree antlrNode, Module module, Asn1Type type) :  base(antlrNode, module, type){}
		public SCCChoiceValue(ChoiceValue o, ITree antlr) :  base( o, antlr){}
        public void PrintC(StreamWriterLevel c, int lev)
        {
            c.WriteLine("{");
            c.P(lev + 1);
            c.WriteLine(".kind = {0},", ChoiceType.m_children[AlternativeName].CID);
            c.P(lev + 1);
            c.Write(".u = {{ .{0}=", ChoiceType.m_children[AlternativeName].CID.Replace("_PRESENT", ""));
            ((ISCCVariable)Value).PrintC(c, lev + 1);

            c.WriteLine();
            c.P(lev);
            c.Write("} }");
        }
    }
	public class SCCEnumeratedValue : EnumeratedValue, ISCCVariable
	{
		public SCCEnumeratedValue(Int64 val, string id, ITree antlr, Module module, Asn1Type type) :  base(val, id, antlr, module, type){}
		public SCCEnumeratedValue(EnumeratedValue o, ITree antlr) :  base( o, antlr){}
        public void PrintC(StreamWriterLevel c, int lev) {  SCCValue.PrintC(this, c, lev); }
	}
	public class SCCIntegerValue : IntegerValue, ISCCVariable
	{
		public SCCIntegerValue(ITree antlrNode, Module module, Asn1Type type) :  base(antlrNode, module, type){}
		public SCCIntegerValue(IntegerValue o, ITree antlr) :  base( o, antlr){}
		public SCCIntegerValue(Int64 val, Module m, ITree antlr, Asn1Type type) :  base(val, m, antlr, type){}
        public void PrintC(StreamWriterLevel c, int lev) {  SCCValue.PrintC(this, c, lev); }
	}
	public class SCCNullValue : NullValue, ISCCVariable
	{
		public SCCNullValue(ITree antlrNode, Module module, Asn1Type type) :  base(antlrNode, module, type){}
		public SCCNullValue(NullValue o, ITree antlr) :  base( o, antlr){}
        public void PrintC(StreamWriterLevel c, int lev) {  SCCValue.PrintC(this, c, lev); }
	}
	public class SCCOctetStringValue : OctetStringValue, ISCCVariable
	{
		public SCCOctetStringValue(ITree antlrNode, Module module, Asn1Type type) :  base(antlrNode, module, type){}
		public SCCOctetStringValue(OctetStringValue o, ITree antlr) :  base( o, antlr){}
        public void PrintC(StreamWriterLevel c, int lev)
        {
            c.WriteLine("{");
            lev++;


            int cnt = Value.Count;

            c.P(lev); c.WriteLine("{0},", cnt);

            c.P(lev); c.WriteLine("{");
            for (int i = 0; i < cnt; i++)
            {
                c.P(lev + 1);
                c.Write("0x{0:X2}", Value[i]);
                if (i != cnt - 1)
                    c.WriteLine(",");
                else
                    c.WriteLine();
            }
            c.P(lev); c.WriteLine("}");

            lev--;
            c.P(lev);
            c.Write("}");
        }
    }
	public class SCCRealValue : RealValue, ISCCVariable
	{
		public SCCRealValue(ITree antlrNode, Module module, Asn1Type type) :  base(antlrNode, module, type){}
		public SCCRealValue(RealValue o, ITree antlr) :  base( o, antlr){}
        public void PrintC(StreamWriterLevel c, int lev) {  SCCValue.PrintC(this, c, lev); }
	}
	public class SCCSequenceOrSetValue : SequenceOrSetValue, ISCCVariable
	{
		public SCCSequenceOrSetValue(ITree antlrNode, Module module, Asn1Type type) :  base(antlrNode, module, type){}
		public SCCSequenceOrSetValue(SequenceOrSetValue o, ITree antlr) :  base( o, antlr){}
        public void PrintC(StreamWriterLevel c, int lev)
        {
            //calculate optional fields which are present
            SequenceOrSetType myType = Type.GetFinalType() as SequenceOrSetType;
            List<string> existedFields = new List<string>();
            if (myType.GetNumberOfOptionalOrDefaultFields() > 0)
            {
                foreach (string varName in myType.m_children.Keys)
                {
                    SequenceOrSetType.Child ch = myType.m_children[varName];
                    if (ch.m_optional || ch.m_defaultValue != null)
                    {
                        if (m_children.ContainsKey(varName))
                        {
                            existedFields.Add(varName);
                        }
                    }
                }
            }



            c.WriteLine("{");
            int cnt = m_children.Count;
            for (int i = 0; i < cnt; i++)
            {
                c.P(lev + 1);
                c.Write(".{0} = ", m_children.Keys[i]);
                ((ISCCVariable)m_children.Values[i]).PrintC(c, lev + 1);
                if (i != cnt - 1 || existedFields.Count > 0)
                    c.WriteLine(",");
                else
                    c.WriteLine();
            }



            if (existedFields.Count > 0)
            {
                lev++;
                c.P(lev);
                c.WriteLine(".exist = {");
                lev++;

                cnt = existedFields.Count;
                for (int i = 0; i < cnt; i++)
                {
                    c.P(lev);
                    c.Write(".{0} = 1", existedFields[i]);
                    if (i != cnt - 1)
                        c.WriteLine(",");
                    else
                        c.WriteLine();
                }
                lev--;
                c.P(lev);
                c.WriteLine("}");
                lev--;
            }




            c.P(lev);
            c.Write("}");
        }
    }
	public class SCCSequenceOfValue : SequenceOfValue, ISCCVariable
	{
		public SCCSequenceOfValue(ITree antlrNode, Module module, Asn1Type type) :  base(antlrNode, module, type){}
		public SCCSequenceOfValue(SequenceOfValue o, ITree antlr) :  base( o, antlr){}
        public void PrintC(StreamWriterLevel c, int lev) { SCCArrayValue.PrintC(this, c, lev); }
	}
	public class SCCSetOfValue : SetOfValue, ISCCVariable
	{
		public SCCSetOfValue(ITree antlrNode, Module module, Asn1Type type) :  base(antlrNode, module, type){}
		public SCCSetOfValue(SetOfValue o, ITree antlr) :  base( o, antlr){}
        public void PrintC(StreamWriterLevel c, int lev) { SCCArrayValue.PrintC(this, c, lev); }
	}
	public class SCCIA5StringValue : IA5StringValue, ISCCVariable
	{
		public SCCIA5StringValue(ITree antlrNode, Module module, Asn1Type type) :  base(antlrNode, module, type){}
		public SCCIA5StringValue(IA5StringValue o, ITree antlr) :  base( o, antlr){}
		public SCCIA5StringValue(Char str) :  base(str){}
        public void PrintC(StreamWriterLevel c, int lev) {  SCCValue.PrintC(this, c, lev); }
	}
	public class SCCNumericStringValue : NumericStringValue, ISCCVariable
	{
		public SCCNumericStringValue(NumericStringValue o, ITree antlr) :  base( o, antlr){}
		public SCCNumericStringValue(ITree antlrNode, Module module, Asn1Type type) :  base(antlrNode, module, type){}
        public void PrintC(StreamWriterLevel c, int lev) {  SCCValue.PrintC(this, c, lev); }
	}
	public class SCCGeneralizedTimeValue : GeneralizedTimeValue, ISCCVariable
	{
		public SCCGeneralizedTimeValue(GeneralizedTimeValue o, ITree antlr) :  base( o, antlr){}
		public SCCGeneralizedTimeValue(ITree antlrNode, Module module, Asn1Type type) :  base(antlrNode, module, type){}
        public void PrintC(StreamWriterLevel c, int lev) {  SCCValue.PrintC(this, c, lev); }
	}
	public class SCCUTCTimeValue : UTCTimeValue, ISCCVariable
	{
		public SCCUTCTimeValue(ITree antlrNode, Module module, Asn1Type type) :  base(antlrNode, module, type){}
		public SCCUTCTimeValue(UTCTimeValue o, ITree antlr) :  base( o, antlr){}
        public void PrintC(StreamWriterLevel c, int lev) {  SCCValue.PrintC(this, c, lev); }
	}
	public class SCCObjectIdentifierValue : ObjectIdentifierValue, ISCCVariable
	{
		public SCCObjectIdentifierValue(ITree antlrNode, Module module, Asn1Type type) :  base(antlrNode, module, type){}
		public SCCObjectIdentifierValue(ObjectIdentifierValue o, ITree antlr) :  base( o, antlr){}
        public void PrintC(StreamWriterLevel c, int lev) {  SCCValue.PrintC(this, c, lev); }
	}
	
   public class SCCObjectIdentifierValueObjectIdentifierComponent : ObjectIdentifierValue.ObjectIdentifierComponent
   { 
   }







}