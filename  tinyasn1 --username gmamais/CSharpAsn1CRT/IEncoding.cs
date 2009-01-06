using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CSharpAsn1CRT
{



    public interface IAsn1EncodingEngine
    {
        void EncodeInteger(Asn1IntegerObject Obj, Stream strm);
        void DecodeInteger(Asn1IntegerObject Obj, Stream strm);

        void EncodeReal(Asn1RealObject Obj, Stream strm);
        void DecodeReal(Asn1RealObject Obj, Stream strm);

        void EncodeBoolean(Asn1BoolObject Obj, Stream strm);
        void DecodeBoolean(Asn1BoolObject Obj, Stream strm);

        void EncodeAsn1IA5String(Asn1IA5StringObject Obj, Stream strm);
        void DecodeAsn1IA5String(Asn1IA5StringObject Obj, Stream strm);

        void EncodeAsn1NumericString(Asn1NumericStringObject Obj, Stream strm);
        void DecodeAsn1NumericString(Asn1NumericStringObject Obj, Stream strm);

        void EncodeAsn1Enumerated<T>(Asn1EnumeratedObject<T> Obj, Stream strm);
        void DecodeAsn1Enumerated<T>(Asn1EnumeratedObject<T> Obj, Stream strm);

    }


    public class BEREncodingEngine
    {
        void EncodeObject(Stream strm, Action<Stream> encContent)
        {
            encContent(strm);
        }


        void EncodeInteger(Asn1IntegerObject Obj, Stream strm)
        {
            EncodeObject(strm, delegate(Stream str)
            {
                BER.EncodeInteger(str, Obj.Value);
            });
        }



    }






}
