using System;
using System.Collections.Generic; using System.Linq;
using System.Text;
using System.IO;
using semantix.util;

namespace CSharpAsn1CRT
{
    public static class BERDump
    {
        public static void dump(string fileName, string outFileName, bool ignoreExtraBytes, bool handleExtraBytesAsDNA)
        {
            using (MemoryStream f = new MemoryStream(File.ReadAllBytes(fileName), false))
            using (StreamWriterLevel w = new StreamWriterLevel(outFileName))
            {

                do
                {
                    BERNode root = BERNode.Create(f);
                    root.dump(w, 0);
                } while (!ignoreExtraBytes && handleExtraBytesAsDNA && f.Length>f.Position);



                if (!ignoreExtraBytes && !handleExtraBytesAsDNA && f.Position < f.Length)
                {
                    w.WriteLine("File contains {0} extra bytes at the end", f.Length-f.Position);
                    int rdVal = 0;

                    int col = 0;
                    while ((rdVal = f.ReadByte()) != -1)
                    {
                        col++;
                        if (col % 80 == 0)
                            w.WriteLine();
                        byte b = (byte)rdVal;
                        w.Write(b.ToString("X2"));
                    }

                }
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


        public override string ToString()
        {
            return string.Format("[{0} {1} {2}]", m_tag.m_tgClass.ToString(), m_tag.isPrimitive, m_tag.m_tagNo);
        }
        public static BERNode Create(Stream strm)
        {
            BERNode ret = null;
            Tag tg = BER.DecodeTag(strm);
            uint lenght = 0;
            bool indefiniteForm;
            BER.DecodeLength(strm, out lenght, out indefiniteForm);
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
//                if (lenght == 0 && (strm.Position != strm.Length))
                if (indefiniteForm)
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


        public static IEnumerable<BERNode> GetNodes(Stream strm)
        {
            BERNode ret = null;
            Tag tg = BER.DecodeTag(strm);
            uint lenght = 0;
            bool indefiniteForm;
            BER.DecodeLength(strm, out lenght, out indefiniteForm);
            if (tg.isPrimitive)
            {
                byte[] data = new byte[lenght];
                if (strm.Read(data, 0, (int)lenght) != lenght)
                    throw new LengthMismatchException();
                ret = new BERNodePrimitive(tg, data);
                yield return ret;
            }
            else
            {
                yield return new BERNodeConstructed(tg);
                if (indefiniteForm)
                {
                    while (!BER.AreNextTwoBytesZeros(strm))
                    {

                        foreach(BERNode n in GetNodes(strm))
                            yield return n;
                    }
                    BER.DecodeTwoZeros(strm);
                }
                else
                {
                    long initPos = strm.Position;
                    while (strm.Position < initPos + lenght)
                    {
                        foreach (BERNode n in GetNodes(strm))
                            yield return n;
                    }
                    if (strm.Position != initPos + lenght)
                        throw new LengthMismatchException();
                }

            }


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

        public override string ToString()
        {
            string tmp = string.Empty;
            foreach (byte b in m_data)
                tmp+= string.Format("{0} ", b.ToString("X2"));
            return base.ToString() + " " + tmp;
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
