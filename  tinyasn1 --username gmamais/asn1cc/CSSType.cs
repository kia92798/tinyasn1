/**=============================================================================
Definition CSSType class and ISCCType interface used in asn1scc project  
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

namespace asn1scc
{

    public interface ISCCType
    {
        void PrintHTypeDeclaration(PEREffectiveConstraint cns, StreamWriterLevel h, string typeName, string varName, int lev);
        void PrintHConstraintConstant(StreamWriterLevel h, string name);
        void VarsNeededForPrintCInitialize(int arrayDepth, OrderedDictionary<string, CLocalVariable> existingVars);
        // Initialize type. If there is a default value (i.e. as child of a sequence, or set), this value is used for 
        // initialization. Otherwise set to 0, or 0.0 or memset(0x0)
        void PrintCInitialize(PEREffectiveConstraint cns, Asn1Value defauleVal, StreamWriterLevel h, string typeName, string varName, int lev, int arrayDepth);
        void VarsNeededForIsConstraintValid(int arrayDepth, OrderedDictionary<string, CLocalVariable> existingVars);
        void PrintCIsConstraintValid(PEREffectiveConstraint cns, StreamWriterLevel c, string errorCode, string typeName, string varName, int lev, int arrayDepth);
        void VarsNeededForEncode(PEREffectiveConstraint cns, int arrayDepth, OrderedDictionary<string, CLocalVariable> existingVars);
        void PrintCEncode(PEREffectiveConstraint cns, StreamWriterLevel c, string errorCode, string varName, int lev);
        void VarsNeededForDecode(PEREffectiveConstraint cns, int arrayDepth, OrderedDictionary<string, CLocalVariable> existingVars);
        void PrintCDecode(PEREffectiveConstraint cns, StreamWriterLevel c, string varName, int lev);
    }

    public static class CSSType
    {
        public static void PrintHConstraintConstant(Asn1Type pThis, StreamWriterLevel h, string name)
        {
            if (pThis.m_constraints.Count > 0)
                h.WriteLine("#define ERR_{0}\t\t{1} /* {2} */", C.ID(name), DefaultBackend.Instance.ConstraintErrorID++, pThis.Constraints);
        }

        public static void PrintCIsConstraintValid(Asn1Type pThis, PEREffectiveConstraint cns, StreamWriterLevel c, string errorCode, string typeName, string varName, int lev, int arrayDepth)
        {
            string varName2 = varName;
            if (!varName.Contains("->"))
                varName2 = "*" + varName;

            if (pThis.m_constraints.Count > 0)
            {
                c.P(lev); c.Write("if ( !(");
                for (int i = 0; i < pThis.m_constraints.Count; i++)
                {
                    string ret = ((ISCConstraint)pThis.m_constraints[i]).PrintCIsConstraintValid(varName2, lev);
                    c.Write(ret);
                    if (i != pThis.m_constraints.Count - 1)
                        c.Write(" && ");
                }
                c.WriteLine(") ) {");
                c.P(lev + 1);
                c.WriteLine("*pErrCode = ERR_{0};", C.ID(errorCode));
                c.P(lev + 1);
                c.WriteLine("return FALSE;");
                c.P(lev);
                c.WriteLine("}");
            }
        }

    }
}
