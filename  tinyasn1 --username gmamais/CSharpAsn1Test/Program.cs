using System;
using System.Collections.Generic;
using System.Text;
using TAP_0311;
using CSharpAsn1CRT;
using RAP_0104;
namespace CSharpAsn1Test
{
    class Program
    {


        static void Main(string[] args)
        {

            long t1 = Environment.TickCount;

//            string tapFile = @"C:\TAPKIT-nrtrde\SampleData\3.4\CDDEUD2GRCPF13110";
//            string tapFile = @"C:\TAPKIT-nrtrde\SampleData\3.10\CDDEUD2GRCPF11000.131072.tap310\CDDEUD2GRCPF10000.gprs";
//            string tapFile = @"C:\TAPKIT-nrtrde\SampleData\3.10\CDDEUD2GRCPF11000.131072.tap310\CDDEUD2GRCPF10000.10K";
            string tapFile = @"C:\prj\DataModeling\tinyAsn1\CSharpAsn1Test\RCCHNCMINDHR00293.dat";

            //string tapFile = @"\\192.168.0.145\vmware\home\gmamais\tap3oss\oss.ber_out.dat_OK_extra_field_present_in_grammar";
            //if (args.Length > 0)
            //    tapFile = args[0];


            


            //BERDump.dump(tapFile);
            //return;


//            using (System.IO.FileStream f = new System.IO.FileStream(tapFile, System.IO.FileMode.Open))
            using (System.IO.MemoryStream f = new System.IO.MemoryStream(System.IO.File.ReadAllBytes(tapFile),false))
            {
//                DataInterChange di = new DataInterChange();
                RapDataInterChange di = new RapDataInterChange();
                di.Decode(f, CSharpAsn1CRT.EncodingRules.CER);
                long t2 = Environment.TickCount;


                using (System.IO.StreamWriter oo = new System.IO.StreamWriter(tapFile + ".xml"))
                {

                    di.ToXml(oo, "RAP");
                }



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


    public class Parents : Stack<Asn1Object>
    {

        public TRes GetParentOfType<TRes>() where TRes : Asn1Object
        {


            foreach (Asn1Object obj in this) 
                if (obj is TRes)
                    return obj as TRes;
            return null;
        }
    }

    public static class Validations
    {


        public static bool ChargeDetail_100(ChargeDetail cd, Parents pars)
        {
            //pars.GetParentOfType<CallEventDetail>()

            if (cd.charge != null && cd.charge.Value > 0)
                return false;

            return true;
        }
    }

}
