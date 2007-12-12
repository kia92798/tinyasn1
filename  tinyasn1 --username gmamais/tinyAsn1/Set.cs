using System;
using System.Collections.Generic;
using System.Text;
using Antlr.Runtime.Tree;
using Antlr.Runtime;

namespace tinyAsn1
{


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
                return new Tag(Tag.TagClass.UNIVERSAL, 17, TaggingMode.EXPLICIT, this);
            }
        }

        static public new SetType CreateFromAntlrAst(ITree tree)
        {
            SetType ret = new SetType();
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





#if TO_BE_DELETED
    public abstract class CharSet
    {
        public abstract bool IsValueAllowed(string val);
    }


    public class SingleValueCharSet : CharSet
    {
        string m_value;

        public SingleValueCharSet(string val)
        {
            m_value = val;
        }

        public override bool IsValueAllowed(string val)
        {
            foreach(Char ch in val)
                if (!m_value.Contains(ch.ToString()))
                    return false;
            return true;
        }
    }

    public class RangeCharSet : CharSet
    {
        /// <summary>
        /// if m_min is null then m_min is MIN
        /// </summary>
        string m_min;
        /// <summary>
        /// if m_max is null then m_max is MAX
        /// </summary>
        string m_max;
        bool m_minValIsInluded = true;
        bool m_maxValIsInluded = true;

        public RangeCharSet(string minVal, string maxVal,
            bool minValIsInluded, bool maxValIsInluded)
        {
            m_min = minVal;
            m_max = maxVal;
            m_minValIsInluded = minValIsInluded;
            m_maxValIsInluded = maxValIsInluded;
        }
        public override bool IsValueAllowed(string val)
        {
            if (m_min != null && m_min.Length != 1)
                return true;
            if (m_max != null && m_max.Length != 1)
                return true;
            if (m_min == null && m_max == null)  //(MIN..MAX)
                return true;
            if (m_min == null && (val.CompareTo(m_max) < 0)) // (MIN..value)
                return true;
            if ((m_min.CompareTo(val) < 0) && m_max == null)
                return true;
            if ((m_min.CompareTo(val) < 0) && (val.CompareTo(m_max) < 0))
                return true;
            if (m_minValIsInluded && m_min != null && m_min.Equals(val))
                return true;
            if (m_maxValIsInluded && m_max != null && m_max.Equals(val))
                return true;
            return false;
        }
    }
#endif

}
