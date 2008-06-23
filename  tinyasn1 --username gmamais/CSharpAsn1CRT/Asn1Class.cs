using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CSharpAsn1CRT
{
    public abstract class Asn1Class
    {

    }

/*
    public class TagEq : IEqualityComparer<Tag>
    {

        public bool Equals(Tag x, Tag y)
        {
            return x.Equals(y);
        }

        public int GetHashCode(Tag obj)
        {
            return obj.GetHashCode();
        }

    }*/

    public abstract class Asn1CompositeClass<T> where T : NamedChild
    {
//        public OrderedDictionary<string, T> m_children = new OrderedDictionary<string, T>();
        public Dictionary<string, T> m_children = new Dictionary<string, T>();

//        private Dictionary<Tag, T> m_tags = null;




        public Dictionary<UInt32, T> m_posChildren = new Dictionary<uint, T>();
        public T getChildByTag2(UInt32 tg)
        {
            return m_posChildren[tg];
            //if (m_posChildren.ContainsKey(tg))
            //    return m_posChildren[tg];
            //return null;
        }

//        public T getChildByTag(Tag nextTag)
//        {
//            if (m_tags == null)
//            {
//                m_tags = new Dictionary<Tag, T>();
//                foreach (T child in m_children.Values)
//                {
//                    if (child.m_Tag != null)
//                        m_tags.Add(child.m_Tag, child);
//                    else
//                    {
//                        foreach (Tag t in child.m_childrenTags)
//                            m_tags.Add(t, child);

//                    }
//                }

//            }

//            if (m_tags.ContainsKey(nextTag))
//                return m_tags[nextTag];
//            //foreach (T child in m_children.Values)
//            //{
//            //    if (child.m_Tag == null && child.m_childrenTags.Contains(nextTag))
//            //        return child;
//            //}
//#if obsolete

//            foreach (T child in m_children.Values)
//            {
//                if (child.m_Tag != null)
//                {
//                    if (child.m_Tag.Equals(nextTag))
//                        return child;
//                }
//                else
//                {
//                    foreach (Tag grChild in child.m_childrenTags) //this is usually one (only for untagged choices can be more than one
//                    {
//                        if (nextTag.Equals(grChild))
//                            return child;
//                    }
//                }
//            }
//#endif
//            return null;
//        }


    }

}