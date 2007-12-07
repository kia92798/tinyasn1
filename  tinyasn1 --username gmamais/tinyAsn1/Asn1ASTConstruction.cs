using System;
using System.Collections.Generic;
using System.Text;
using Antlr.Runtime.Tree;
using Antlr.Runtime;

namespace tinyAsn1
{

/*
    public class TreeVisitor
    {
        public delegate void OnTreeElementVisit(ITree curNode);

        public event OnTreeElementVisit ElementVisited;

        public void Visit(ITree root)
        {
            if (ElementVisited != null)
                ElementVisited(root);
            for (int i = 0; i < root.ChildCount; i++)
            {
                Visit(root.GetChild(i));
            }

        }
    }

*/


/*
    public partial class ValueSetAssigment
    {
        static public ValueSetAssigment CreateFromAntlrAst(ITree tree)
        {
            ValueSetAssigment ret = new ValueSetAssigment();
            ret.m_typeReference = tree.GetChild(0).Text;
            ret.m_type = Asn1Type.CreateFromAntlrAst(tree.GetChild(1));
            ret.m_constr_body = SetOfValues.CreateFromAntlrAst(tree.GetChild(2));
            return ret;
        }

    }
*/






}




