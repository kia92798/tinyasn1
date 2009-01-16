using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace CSharpAsn1CRT
{
    public static class BER
    {
        

        public static UInt32 DecodeTagAsInt(Stream strm)
        {
            UInt32 ret = 0;
            int rdVal = 0;
            while ((rdVal = strm.ReadByte())>=0)
            {
                byte b = (byte)rdVal;

                ret <<= 8;
                ret |= b;

                if (ret<255)        //first byte
                {
                    ret &= 0xDF;    // Set primitive bit to zero
                    if ((ret & 0x1F) < 31)
                        return ret;
                    continue;
                }

                if ((b & 0x80) == 0)
                    return ret;

            }
            return UInt32.MaxValue; //end of stream --> Invalid tag! 
        }


        public static void EncodeTagAsInt(Stream strm, UInt32 tag, bool primitive)
        {
            byte b1;
            if (tag < 0x100)
            {
                if (!primitive && tag < 256)
                    tag |= 0x20;
                strm.WriteByte((byte)tag);
                return;
            }

            if (tag < 0x10000)
            {
                b1 = (byte)((0xFF00 & tag) >> 8);
                if (!primitive)
                    b1 |= 0x20;
                strm.WriteByte(b1);
                strm.WriteByte((byte)tag);
                return;
            }

            if (tag < 0x1000000)
            {
                b1 = (byte)((0xFF0000 & tag) >> 16);
                if (!primitive)
                    b1 |= 0x20;
                strm.WriteByte(b1);
                b1 = (byte)((0xFF00 & tag) >> 8);
                strm.WriteByte(b1);
                strm.WriteByte((byte)tag);
                return;
            }
            
            b1 = (byte)((0xFF000000 & tag) >> 24);
            if (!primitive)
                b1 |= 0x20;
            strm.WriteByte(b1);

            b1 = (byte)((0xFF0000 & tag) >> 16);
            strm.WriteByte(b1);

            b1 = (byte)((0xFF00 & tag) >> 8);
            strm.WriteByte(b1);

            strm.WriteByte((byte)tag);




            //while (tag > 0)
            //{
            //    if (!primitive && tag < 256)
            //        tag |= 0x20;
                    
            //    strm.WriteByte((byte)tag);
            //    tag >>= 8;
            //}
        }


        public static Tag DecodeTag(Stream strm)
        {
            Tag ret = null;


            //            long curPos = strm.Position;
            int rdVal = 0;
            uint tagNo = 0;
            int i = 0;
            while (true)
            {
                rdVal = strm.ReadByte();

                if (rdVal == -1)
                    return ret; // null

                byte b = (byte)rdVal;
                if (i == 0)
                {
                    ret = new Tag();
                    //                    ret.m_tgClass = (TagClass)Enum.ToObject(typeof(TagClass), b >> 6);
                    ret.m_tgClass = (TagClass)(b >> 6);
                    ret.isPrimitive = (b & 0x20) == 0;
                    ret.m_tagNo = (uint)((uint)0x1F & b);
                    if (ret.m_tagNo < 31)
                        return ret;
                    i++;
                    continue;
                }

                tagNo = tagNo << 7;
                tagNo = tagNo | (byte)(b & (byte)0x7F);

                if ((b & 0x80) == 0)
                    break;

            }
            ret.m_tagNo = tagNo;

            return ret;
        }


//        public static int EncodeTag(Stream strm, TagClass tagClass, bool primitive, uint tagNumber)
//        {

//#if DEBUG0
//            long l1 = strm.Position;
//            long l2;
//            Tag tmp = null;
//            uint origTagNumber = tagNumber;

//            if (tagNumber == 196)
//                origTagNumber = origTagNumber;
//#endif


//            byte b1= (byte)((byte)tagClass<<6);
//            if (!primitive)
//                b1 |= 0x20;


//            if (tagNumber < 31)
//            {
//                b1 |= (byte)(0x1F & (byte)tagNumber);
//                strm.WriteByte(b1);

//#if DEBUG0
//                l2 = strm.Position;
//                strm.Position = l1;
//                tmp = BER.DecodeTag(strm);
//                if (tmp.m_tagNo != origTagNumber || tmp.m_tgClass != tagClass || tmp.isPrimitive != primitive)
//                    throw new Exception();
//                strm.Position = l2;
//#endif


//                return 1;
//            }

//            b1 |= 0x1F;
//            strm.WriteByte(b1);

//            List<byte> encBytes = new List<byte>();

//            while (tagNumber > 0)
//            {
//                byte encTagPart = (byte)(tagNumber & 0x7F);

//                tagNumber = tagNumber >> 7;
//                if (encBytes.Count==0)
//                    encBytes.Insert(0, encTagPart);
//                else
//                    encBytes.Insert(0, (byte)(0x80 | encTagPart));
//            }

//            strm.Write(encBytes.ToArray(), 0, encBytes.Count);





//#if DEBUG0
//            l2 = strm.Position;
//            strm.Position = l1;
//            tmp = BER.DecodeTag(strm);
//            if (tmp.m_tagNo != origTagNumber || tmp.m_tgClass != tagClass || tmp.isPrimitive != primitive)
//                throw new Exception();
//            strm.Position = l2;
//#endif



//            return encBytes.Count + 1;

//        }



        
        public static int EncodeLengthDF(Stream strm, uint length)
        {

#if DEBUG0
            long l1 = strm.Position;
            long l2;
            uint tlen;
            uint origLen = length;
#endif

            if (length <= 127)
            {
                strm.WriteByte((byte)length);
#if DEBUG0
                l2 = strm.Position;
                strm.Position = l1;
                DecodeLength(strm, out tlen);
                if (origLen != tlen)
                    throw new Exception();

                strm.Position = l2;
#endif

                
                return 1;
            }

            List<byte> encBytes = new List<byte>();

            while (length > 0)
            {
                byte val = (byte)length;
                encBytes.Insert(0, val);
                length >>= 8;
            }

            encBytes.Insert(0, (byte)(0x80 | encBytes.Count)); //encode length of length
            
            strm.Write(encBytes.ToArray(), 0, encBytes.Count);


#if DEBUG0
            l2 = strm.Position;
            strm.Position = l1;
            DecodeLength(strm, out tlen);
            if (origLen != tlen)
                throw new Exception();

            strm.Position = l2;
#endif



            return encBytes.Count;

        }

        public static void  DecodeLength(Stream strm, out uint length, out bool indefiniteForm)
        {
            indefiniteForm = false;
            int rdVal = 0;
            rdVal = strm.ReadByte();

            if (rdVal == -1)
                throw new UnexpectedEndOfStreamException();

            byte b = (byte)rdVal;

            if ( (b & 0x80) == 0)
            {
                length = (uint)0x7F & b;
                return;
            }

            byte lenlen = (byte)(b &0x7F);
            indefiniteForm = (lenlen == 0);
            length  = 0;


            for (int i = 0; i < lenlen; i++)
            {
                rdVal = strm.ReadByte();

                if (rdVal == -1)
                    throw new UnexpectedEndOfStreamException();

                b = (byte)rdVal;

                length <<= 8;
                length |= b;
            }
        }

        public static void DecodeTwoZeros(Stream strm)
        {
            if (strm.ReadByte() == 0 && strm.ReadByte() == 0)
                return ;
            throw new LengthMismatchException();
        }

        public static bool AreNextTwoBytesZeros(Stream strm)
        {
            long curPos = strm.Position;

            int rdVal1 = strm.ReadByte();
            int rdVal2 = strm.ReadByte();

            bool ret = (rdVal1 == 0 && rdVal2 == 0);

            strm.Position = curPos;

            return ret;
        }


        //public static bool GetNextTag(Stream strm, out Tag nextTag)
        //{
        //    long curPos = strm.Position;
        //    nextTag = DecodeTag(strm);
        //    strm.Position = curPos;
        //    return (nextTag !=null);
        //}

        public static bool GetNextTag(Stream strm, out UInt32 nextTag)
        {
            long curPos = strm.Position;
            nextTag = DecodeTagAsInt(strm);

            bool invalidTag = (nextTag == UInt32.MaxValue) || (nextTag == 0);
            strm.Position = curPos; //if invalid tag then seek back

            return !invalidTag;
        }


        public static uint EncodeInteger(Stream strm, long Value)
        {
#if DEBUG0
            long l1 = strm.Position;
            long l2;
#endif

            
            
            
            uint ret = 0;

            byte[] bytes = BitConverter.GetBytes(Value);

            for (int i = bytes.Length - 1; i > 0; i--)
            {
                if (Value<0 && bytes[i] == 0xFF && (bytes[i - 1] & 0x80) == 0x80)
                    continue;
                if (Value>=0 && bytes[i] == 0x0 && (bytes[i - 1] & 0x80) == 0x0)
                    continue;
                ret ++;
                strm.WriteByte(bytes[i]);
            }

            ret ++;
            strm.WriteByte(bytes[0]);



#if DEBUG0
            l2 = strm.Position;
            strm.Position = l1;
            long decodedValue = BER.DecodeInteger(strm, ret);

            if (decodedValue != Value)
                throw new Exception();

            strm.Position = l2;

#endif


            return ret;
        }

        public static long DecodeInteger(Stream strm, uint dataLen)
        {
            byte[] bytes = new byte[8];
            if (dataLen == 0)
                return 0;
            for (long i = dataLen-1; i>=0 ; i--)
            {
                int nReadValue = strm.ReadByte();
                if (nReadValue == -1)
                    throw new UnexpectedEndOfStreamException();
                bytes[i] = (byte)nReadValue;
            }

            if ((bytes[dataLen - 1] & 0x80) == 0x80)
            {
                for (uint i = dataLen; i < 8; i++)
                    bytes[i] = 0xFF;
            }


            return BitConverter.ToInt64(bytes, 0);

        }
    }


}