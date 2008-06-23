using System;
using System.Collections.Generic;
using System.Text;
using TAP_0310;
namespace CSharpAsn1Test
{
    class Program
    {



        static void Main(string[] args)
        {

            long t1 = Environment.TickCount;

            string tapFile = @"C:\TAPKIT-nrtrde\SampleData\3.4\CDDEUD2GRCPF13110";
//            string tapFile = @"C:\TAPKIT-nrtrde\SampleData\3.10\CDDEUD2GRCPF11000.131072.tap310\CDDEUD2GRCPF10000.gprs";
//            string tapFile = @"C:\TAPKIT-nrtrde\SampleData\3.10\CDDEUD2GRCPF11000.131072.tap310\CDDEUD2GRCPF10000.10K";
            if (args.Length > 0)
                tapFile = args[0];

            
            


//            using (System.IO.FileStream f = new System.IO.FileStream(tapFile, System.IO.FileMode.Open))
            using (System.IO.MemoryStream f = new System.IO.MemoryStream(System.IO.File.ReadAllBytes(tapFile),false))
            {
                DataInterChange di = new DataInterChange();
                di.Decode(f, CSharpAsn1CRT.EncodingRules.CER);
                long t2 = Environment.TickCount;


                

                using (System.IO.FileStream w = new System.IO.FileStream(tapFile + ".new", System.IO.FileMode.Create))
                {
                    di.Encode(w, CSharpAsn1CRT.EncodingRules.CER);
                    long t3 = Environment.TickCount;

                    Console.WriteLine("Time for decoding: {0}", t2 - t1);
                    Console.WriteLine("Time for encoding: {0}", t3 - t2);
                    Console.WriteLine("Total time : {0}", t3 - t1);

                }
            }





        }
    }
}
