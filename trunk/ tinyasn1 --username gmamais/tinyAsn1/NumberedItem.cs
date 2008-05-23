/**=============================================================================
Definition of NumberedItem class
in autoICD and asn1scc projects  
================================================================================
Copyright(c) Semantix Information Technologies S.A www.semantix.gr
All rights reserved.

This source code is only intended as a supplement to the
Semantix Technical Reference and related electronic documentation 
provided with the autoICD and asn1scc applications.
See these sources for detailed information regarding the
asn1scc and autoICD applications.
==============================================================================*/
using System;
using System.Collections.Generic;
using System.Text;
using Antlr.Runtime.Tree;
using Antlr.Runtime;

namespace tinyAsn1
{

    /// <summary>
    /// This class is uded ny enumerated, integer and bit strings for their children
    /// This class is not exposed to outside world 
    /// </summary>

    internal partial class NumberedItem
    {
        public string m_id = "";
        public string m_valueAsReference = "";
        public Int64? m_valueAsInt;
        public bool m_extended = false;
        public ITree antlrNode;

        // ^(NUMBER_LST_ITEM identifier INT? valuereference?)
        //|^(NUMBER_LST_ITEM identifier signedNumber? valuereference?)
        static public NumberedItem CreateFromAntlrAst(ITree tree)
        {
            NumberedItem ret = new NumberedItem();
            ret.antlrNode = tree;
            ret.m_id = tree.GetChild(0).Text;
            for (int i = 1; i < tree.ChildCount; i++)
            {
                ITree child = tree.GetChild(i);
                switch (child.Type)
                {
                    case asn1Parser.INT:
                        ret.m_valueAsInt = int.Parse(child.Text);
                        break;
                    case asn1Parser.LID:
                        ret.m_valueAsReference = child.Text;
                        break;
                    default:
                        throw new Exception("Unkown child: " + child.Text + " for node: " + tree.Text);
                }
            }

            return ret;
        }
    }
}
