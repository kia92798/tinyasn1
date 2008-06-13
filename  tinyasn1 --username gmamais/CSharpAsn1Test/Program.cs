using System;
using System.Collections.Generic;
using System.Text;
using TYPES;

namespace CSharpAsn1Test
{
    class Program
    {

        public enum a1
        {
            a,
            b

        }


        static void Main(string[] args)
        {

            Nullable<Int32> f = 34;

            Nullable<a1> ff = a1.a;

            


            MySeqOF2 root = new MySeqOF2();

        }
    }
}
