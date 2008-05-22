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

    internal /* not need to be abstract */partial class NumberedItem
    {
        public string m_id = "";
        public string m_valueAsReference = "";
        public Int64? m_valueAsInt;
        public bool m_extended = false;
        public ITree antlrNode;

/*
        public Object Value
        {
            get
            {
                if (m_valueAsInt != null)
                    return m_valueAsInt;
                else
                    return m_valueAsReference;
            }
        }
*/
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
                    //case asn1Parser.NUMERIC_VALUE:
                    //    ret.m_valueAsInt = Asn1Value.GetValFrom_NUMERIC_VALUE_asInt(child);
                    //    break;
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
