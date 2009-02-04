using System;
using System.Collections.Generic; using System.Linq;
using System.Text;
using CSharpAsn1CRT;


namespace Tap3Utils
{


    public static class BCDUtils
    {

        public static void Test()
        {

        }

        public static string BCDToString(List<byte> data)
        {

            Func<byte, byte> fix = delegate(byte orig)
            {
                if (orig < 10)
                    return (byte)('0' + orig);
                else
                    return (byte)('A' + orig - 10);
            };

            string ret = string.Empty;
            byte[] w = new byte[2];
            foreach (byte b in data)
            {
                w[0] = fix((byte)(b >> 4));
                w[1] = fix((byte)(b & (byte)0x0F));

                ret += ASCIIEncoding.ASCII.GetString(w);
            }

            return ret;
        }

        public static string BCDToString_noTrailingF(List<byte> data)
        {
            string ret = BCDToString(data);

            while (ret.EndsWith("F"))
                ret = ret.Substring(0, ret.Length - 1);
            return ret;
        }

        public static List<byte> StringToBCD(string data)
        {
            List<byte> ret = new List<byte>();
            bool firstNibble = true;
            byte currentByte = 0;
            foreach (char ch in data)
            {
                byte curNibble = 0;
                if (ch >= '0' && ch <= '9')
                    curNibble = (byte)(ch - '0');
                else if (ch >= 'A' && ch <= 'F')
                    curNibble = (byte)(ch - 'A' + 10);
                else
                    throw new Exception("Invalid BCD string");
                if (firstNibble)
                    currentByte = (byte)(curNibble << 4);
                else
                {
                    currentByte |= curNibble;
                    ret.Add(currentByte);
                }
                firstNibble = !firstNibble;
            }
            if (!firstNibble)
            {
                currentByte |= 0xF;
                ret.Add(currentByte);
            }

            return ret;
        }

        public static bool IsValidBCDString(string bcdStr)
        {
            foreach (char ch in bcdStr)
            {
                if ((ch >= '0' && ch <= '9') || (ch >= 'A' && ch <= 'F'))
                    continue;
                else
                    return false;
            }
            return true;
        }

    }
}