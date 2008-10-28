using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using tinyAsn1;

namespace CSharpAsn1CRT
{
    public static class BERDump
    {
        public static void dump(string fileName)
        {
            using (MemoryStream f = new MemoryStream(File.ReadAllBytes(fileName), false))
            using (StreamWriterLevel w = new StreamWriterLevel(fileName + ".txt"))
            {
                BERNode root = BERNode.Create(f);
                root.dump(w, 0);
            }

        }
    }

    public abstract class BERNode
    {
        public Tag m_tag = null;

        public BERNode(Tag tg)
        {
            m_tag = tg;
        }

        public virtual void dump(StreamWriterLevel w, int level)
        {
            w.P(level);
            w.WriteLine("[{0} {1} {2}]", m_tag.m_tgClass.ToString(), m_tag.isPrimitive, m_tag.m_tagNo);
        }

        public static BERNode Create(Stream strm)
        {
            BERNode ret = null;
            Tag tg = BER.DecodeTag(strm);
            uint lenght = 0;
            BER.DecodeLength(strm, out lenght);
            if (tg.isPrimitive)
            {
                byte[] data = new byte[lenght];
                if (strm.Read(data, 0, (int)lenght) != lenght)
                    throw new LengthMismatchException();
                ret = new BERNodePrimitive(tg, data);
            }
            else
            {
                BERNodeConstructed retCon = new BERNodeConstructed(tg);
                ret = retCon;
                if (lenght == 0)
                {
                    while (!BER.AreNextTwoBytesZeros(strm))
                    {
                        retCon.m_children.Add(Create(strm));
                    }
                    BER.DecodeTwoZeros(strm);
                }
                else
                {
                    long initPos = strm.Position;
                    while (strm.Position < initPos + lenght)
                    {
                        retCon.m_children.Add(Create(strm));
                    }
                    if (strm.Position != initPos + lenght)
                        throw new LengthMismatchException();
                }

            }

            return ret;
        }
    }

    public class BERNodePrimitive : BERNode
    {
        public byte[] m_data = null;
        public BERNodePrimitive(Tag tg, byte[] data)
            : base(tg)
        {
            m_data = data;
        }
        public override void dump(StreamWriterLevel w, int level)
        {
            base.dump(w, level);
            w.P(level);
            w.Write("\tData:");

            
            foreach (byte b in m_data)
                w.Write("{0} ", b.ToString("X2"));
            w.WriteLine();
        }
    }

    public class BERNodeConstructed : BERNode
    {
        public List<BERNode> m_children = new List<BERNode>();
        public BERNodeConstructed(Tag tg)
            : base(tg)
        {
        }
        public override void dump(StreamWriterLevel w, int level)
        {
            base.dump(w, level);
            foreach (BERNode ch in m_children)
                ch.dump(w, level + 1);
        }
    }

}
