/**=============================================================================
Definition of SetType class
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
using semantix.util;

namespace tinyAsn1
{


    /// <summary>
    /// Represents ASN.1 type SET
    /// Most functionality is implemented in the base class SequenceOrSetType
    /// so please refer to this class for more information
    /// </summary>
    public partial class SetType : SequenceOrSetType
    {
        public override string Name
        {
            get { return "SET"; }
        }

        public override Asn1Type.Tag UniversalTag
        {
            get
            {
                return DefaultBackend.Instance.Factory.CreateAsn1TypeTag(Tag.TagClass.UNIVERSAL, 17, TaggingMode.EXPLICIT, this);
            }
        }

        static public new SetType CreateFromAntlrAst(ITree tree)
        {
            SetType ret = DefaultBackend.Instance.Factory.CreateSetType();
            if (tree.ChildCount>0)
                SequenceOrSetType.CreateFromAntlrAst(ret, tree.GetChild(0));
            return ret;
        }

        
        private List<Asn1Type.TagSequence> getChildrenTags()
        {
            List<TagSequence> ret = new List<TagSequence>();
            foreach (Child ch in Children)
            {
                ChoiceType chChild = ch.m_type.GetFinalType() as ChoiceType;
                if (chChild != null && !ch.m_type.IsTagged())
                    ret.AddRange(chChild.getChildrenTags());
                else
                    ret.Add(ch.m_type.Tags);
            }
            return ret;
        }

        public override void CheckChildrensTags()
        {
            List<TagSequence> chTags = getChildrenTags();

            for (int i = 0; i < chTags.Count; i++)
                for (int j = i + 1; j < chTags.Count; j++)
                {
                    if (chTags[i].Equals(chTags[j]))
                    {

                        string err = string.Format("Error: Tag clash for type defined in line {0}." +
                        "The type contains has two children (or grandchilden a choice child) with the same tag. " +
                        "The child that clashes are located in lines: {1} and {2}", antlrNode.Line, chTags[i].m_tags[0].m_type.antlrNode.Line, chTags[j].m_tags[0].m_type.antlrNode.Line);
                        throw new SemanticErrorException(err);
                    }

                    //
                }

            foreach (Child ch in Children)
            {
                ch.m_type.CheckChildrensTags();
            }

        }
        public override bool Compatible(Asn1Type other)
        {
            SetType o = other.GetFinalType() as SetType;
            if (o == null)
                return false;
            return base.Compatible(other);
        }
    }



}
