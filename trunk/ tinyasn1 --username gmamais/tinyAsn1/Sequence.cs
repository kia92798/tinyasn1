using System;
using System.Collections.Generic;
using System.Text;
using Antlr.Runtime.Tree;
using Antlr.Runtime;

namespace tinyAsn1
{
    public partial class SequenceType : SequenceOrSetType
    {
        public override string Name
        {
            get { return "SEQUENCE"; }
        }

        public override Asn1Type.Tag UniversalTag
        {
            get
            {
                return new Tag(Tag.TagClass.UNIVERSAL, 16, TaggingMode.EXPLICIT, this);
            }
        }

        static public new SequenceType CreateFromAntlrAst(ITree tree)
        {
            SequenceType ret = new SequenceType();
            if (tree.ChildCount>0)
                SequenceOrSetType.CreateFromAntlrAst(ret, tree.GetChild(0));
            return ret;
        }

        public override void CheckChildrensTags()
        {
            string err = "Error: Tag clash for type defined in line {0}." +
            "The type contains has two children (or grandchilden a choice child) with the same tag. " +
            "The child that clashes are located in lines: {1} and {2}";

            List<TagSequence> chTags = new List<TagSequence>();

            bool clearTagsList = false;
            foreach (Child ch in Children)
            {

                if (!ch.m_optional && ch.m_defaultValue == null)    //non optional and no default value
                {
                    if (chTags.Count == 0)
                        continue;
                    else
                    {
                        clearTagsList = true;
                        //do the checking;
                        /*                        if (chTags.Contains(ch.m_type.Tags))
                                                {
                                                    TagSequence other = chTags[chTags.IndexOf(ch.m_type.Tags)];
                                                    err = string.Format(err,
                                                        antlrNode.Line,
                                                        other.m_tags[0].m_type.antlrNode.Line,
                                                        ch.m_type.antlrNode.Line);

                                                    throw new SemanticErrorException(err);
                                                }

                                                //chTags.Add(ch.m_type.Tags);
                                                chTags.Clear();
                                                continue;*/
                    }
                }

                ChoiceType chChild = ch.m_type.GetFinalType() as ChoiceType;

                if (chChild != null && !ch.m_type.IsTagged())
                {
                    List<TagSequence> choiceChildrenTages = chChild.getChildrenTags();
                    foreach (TagSequence tagSq in choiceChildrenTages)
                    {
                        if (chTags.Contains(tagSq))
                        {
                            TagSequence other = chTags[chTags.IndexOf(tagSq)];
                            err = string.Format(err,
                                antlrNode.Line,
                                other.m_tags[0].m_type.antlrNode.Line,
                                tagSq.m_tags[0].m_type.antlrNode.Line);

                            throw new SemanticErrorException(err);
                        }
                        else
                            chTags.Add(tagSq);
                    }
                }
                else
                {
                    if (chTags.Contains(ch.m_type.Tags))
                    {
                        TagSequence other = chTags[chTags.IndexOf(ch.m_type.Tags)];
                        err = string.Format(err,
                            antlrNode.Line,
                            other.m_tags[0].m_type.antlrNode.Line,
                            ch.m_type.antlrNode.Line);

                        throw new SemanticErrorException(err);
                    }
                    else
                        chTags.Add(ch.m_type.Tags);
                }

                if (clearTagsList)
                {
                    clearTagsList = false;
                    chTags.Clear();
                }

            }

            foreach (Child ch in Children)
            {
                ch.m_type.CheckChildrensTags();

            }
        }

        public override bool Compatible(Asn1Type other)
        {
            SequenceType o = other.GetFinalType() as SequenceType;
            if (o == null)
                return false;
            return base.Compatible(other);
        }

    }

}
