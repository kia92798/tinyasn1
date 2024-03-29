﻿/**=============================================================================
Definition SCCTypeAssigment and SCCValueAssigment classes used in asn1scc project  
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
using semantix.util;

namespace asn1scc
{
    public class SCCModule : Module
    {
    }

    public class SCCTypeAssigment : TypeAssigment
    {

        internal void PrintH(StreamWriterLevel h, string uniqueID)
        {
            ////print type declaration
            //h.WriteLine("/*");
            //h.WriteLine("Definition of :{0}", m_name);
            //foreach(string line in m_comments)
            //    h.WriteLine("{0}", line);
            //h.WriteLine("*/");

            h.WriteComment(m_comments, 0);

            h.Write("typedef ");
            ((ISCCType)m_type).PrintHTypeDeclaration(m_type.PEREffectiveConstraint, h, uniqueID, "", 0);
            if (!(m_type is IA5StringType))
                h.WriteLine(" {0};", uniqueID);
            h.WriteLine();

            //print 
            h.WriteLine("#define {0}_REQUIRED_BYTES_FOR_ENCODING		{1}", uniqueID, m_type.MaxBytesInPER);
            h.WriteLine();
            ((ISCCType)m_type).PrintHConstraintConstant(h, uniqueID);
            h.WriteLine();
            string star = "";
            if (!(m_type is IA5StringType))
                star = "*";
            h.WriteLine("void {0}_Initialize({0}{1} pVal);", uniqueID, star);
            h.WriteLine("flag {0}_IsConstraintValid(const {0}{1} val, int* pErrCode);", uniqueID, star);
            h.WriteLine("flag {0}_Encode(const {0}{1} val, BitStream* pBitStrm, int* pErrCode, flag bCheckConstraints);", uniqueID, star);
            h.WriteLine("flag {0}_Decode({0}{1} pVal, BitStream* pBitStrm, int* pErrCode);", uniqueID, star);
            h.WriteLine();
            h.WriteLine();
        }

        internal void PrintC(StreamWriterLevel c, string uniqueID)
        {
            string star = "";
            if (!(m_type is IA5StringType))
                star = "*";
            c.WriteLine();
            c.WriteLine("void {0}_Initialize({0}{1} pVal)", uniqueID, star);
            c.WriteLine("{");
            c.WriteLine();
            OrderedDictionary<string, CLocalVariable> localVars = new OrderedDictionary<string, CLocalVariable>();
            ((ISCCType)m_type).VarsNeededForPrintCInitialize(1, localVars);
            CLocalVariable.Print(c, localVars);
            ((ISCCType)m_type).PrintCInitialize(m_type.PEREffectiveConstraint, m_type.GetOneValidValue(), c, uniqueID, "pVal", 1, 1);
            c.WriteLine("}");
            c.WriteLine();

            //print Constraints aux protypes
            foreach (Asn1Type t in m_type.GetMySelfAndAnyChildren<Asn1Type>())
                for (int i = 0; i < t.m_constraints.Count; i++)
                    ((ISCConstraint)t.m_constraints[i]).PrintCIsConstraintValidAux(uniqueID + star + " pVal", c);


            c.WriteLine();
            c.WriteLine("flag {0}_IsConstraintValid(const {0}{1} pVal, int* pErrCode)", uniqueID, star);
            c.WriteLine("{");
            localVars.Clear();
            ((ISCCType)m_type).VarsNeededForIsConstraintValid(1, localVars);
            CLocalVariable.Print(c, localVars);
            ((ISCCType)m_type).PrintCIsConstraintValid(m_type.PEREffectiveConstraint, c, uniqueID, uniqueID, "pVal", 1, 1);
            c.P(1); c.WriteLine("(void)pVal; /*Dummy statement, just to hide potential warning*/");
            c.P(1); c.WriteLine("(void)pErrCode; /*Dummy statement, just to hide potential warning*/");
            c.P(1); c.WriteLine("return TRUE;");
            c.WriteLine("}");
            c.WriteLine();

            //print Constraints aux body functions
            foreach (Asn1Type t in m_type.GetMySelfAndAnyChildren<Asn1Type>())
                for (int i = 0; i < t.m_constraints.Count; i++)
                    ((ISCConstraint)t.m_constraints[i]).PrintCIsConstraintValidAuxBody(c);


            c.WriteLine("flag {0}_Encode(const {0}{1} pVal, BitStream* pBitStrm, int* pErrCode, flag bCheckConstraints)", uniqueID, star);
            c.WriteLine("{");
            localVars.Clear();
            ((ISCCType)m_type).VarsNeededForEncode(m_type.PEREffectiveConstraint, 1, localVars);
            CLocalVariable.Print(c, localVars);
            c.P(1); c.WriteLine("if (bCheckConstraints && !{0}_IsConstraintValid(pVal, pErrCode))", uniqueID);
            c.P(2); c.WriteLine("return FALSE;");
            ((ISCCType)m_type).PrintCEncode(m_type.PEREffectiveConstraint, c, uniqueID, "pVal", 1);
            c.P(1); c.WriteLine("return TRUE;");
            c.WriteLine("}");
            c.WriteLine();

            c.WriteLine("flag {0}_Decode({0}{1} pVal, BitStream* pBitStrm, int* pErrCode)", uniqueID, star);
            c.WriteLine("{");
            localVars.Clear();
            ((ISCCType)m_type).VarsNeededForDecode(m_type.PEREffectiveConstraint, 1, localVars);
            CLocalVariable.Print(c, localVars);
            ((ISCCType)m_type).PrintCDecode(m_type.PEREffectiveConstraint, c, "pVal", 1);
            c.P(1); c.WriteLine("return TRUE;");
            c.WriteLine("}");
            c.WriteLine();

            /*
                        c.WriteLine("void {0}_PrintXml({0}{1} pVal, FILE* fp)", uniqueID, star);
                        c.WriteLine("{");
                        c.P(1);
                        c.Write("fprintf(fp,\"<{0}>\"", m_name);


                        c.P(1);
                        c.Write("fprintf(fp,\"</{0}>\"", m_name);
                        c.WriteLine("}");
                        c.WriteLine();
             */

        }

    }


    public class SCCValueAssigment : ValueAssigment
    {
        internal void PrintC(StreamWriterLevel c)
        {
            ((ISCCType)m_type).PrintHTypeDeclaration(m_type.PEREffectiveConstraint, c, "", "", 0);

            c.Write(" {0} = ", C.ID(m_name));
            //            c.Write("{0} {1} = ", C.ID(m_type.Name), C.ID(m_name));
            ((ISCCVariable)m_value).PrintC(c, 0);
            c.WriteLine(";");
        }
        public void PrintExternDeclaration(StreamWriterLevel h)
        {
            //            h.WriteLine("extern {0} {1};", C.ID(m_type.Name), C.ID(m_name));
            h.Write("extern ");
            ((ISCCType)m_type).PrintHTypeDeclaration(m_type.PEREffectiveConstraint, h, "", "", 0);
            h.WriteLine(" {0};", C.ID(m_name));
        }
    }

}
