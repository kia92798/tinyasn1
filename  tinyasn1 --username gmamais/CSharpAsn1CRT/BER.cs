using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace CSharpAsn1CRT
{
    public static class BER
    {
        public static Tag DecodeTag(Stream strm)
        {
            Tag ret = new Tag();

            long curPos = strm.Position;
            int rdVal = 0;
            while ((rdVal = strm.ReadByte()) > 0)
            {
                byte b = (byte)rdVal;

#warning "incomplete function"

            }


            return ret;
        }


        public static int EncodeTag(Stream strm, TagClass tagClass, bool primitive, uint tagNumber)
        {
            byte b1= (byte)((byte)tagClass<<6);
            if (!primitive)
                b1 |= 0x20;


            if (tagNumber <= 31)
            {
                b1 |= (byte)(0x1F & (byte)tagNumber);
                strm.WriteByte(b1);
                return 1;
            }

            b1 |= 0x1F;
            strm.WriteByte(b1);

            List<byte> encBytes = new List<byte>();

            while (tagNumber > 0)
            {
                byte encTagPart = (byte)(tagNumber & 0x7F);

                tagNumber = tagNumber >> 7;

                if (tagNumber > 0)
                    encBytes.Insert(0, (byte)(0x80 | encTagPart));
                else
                    encBytes.Insert(0, encTagPart);
            }

            strm.Write(encBytes.ToArray(), 0, encBytes.Count);

            return encBytes.Count + 1;
        }



        
        public static int EncodeLengthDF(Stream strm, uint length)
        {
            if (length <= 127)
            {
                strm.WriteByte((byte)length);
                return 1;
            }

            List<byte> encBytes = new List<byte>();

            while (length > 0)
            {
                byte val = (byte)length;
                encBytes.Insert(0, val);
                length >>= 8;
            }

            encBytes.Insert(0, (byte)(0x80 | encBytes.Count));
            
            strm.Write(encBytes.ToArray(), 0, encBytes.Count);

            return encBytes.Count;

        }

        public static void  DecodeLength(Stream strm, out uint length)
        {
            throw new UnexpectedEndOfStreamException();
        }

        public static bool DecodeTwoZeros(Stream strm)
        {
            throw new LengthMismatchException();
        }

        public static bool AreNextTwoBytesZeros(Stream strm)
        {
            throw new LengthMismatchException();
        }
    
    }


}