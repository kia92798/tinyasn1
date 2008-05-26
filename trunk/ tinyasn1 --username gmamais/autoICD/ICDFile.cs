/**=============================================================================
Definition of ICDBackendFactory, ICDBackend and ICDFile classes used
in autoICD project  
================================================================================
Copyright(c) Semantix Information Technologies S.A www.semantix.gr
All rights reserved.

This source code is only intended as a supplement to the
Semantix Technical Reference and related electronic documentation 
provided with the autoICD application.
See these sources for detailed information regarding the
autoICD application.
==============================================================================*/
using System;
using System.Collections.Generic;
using System.Text;
using Antlr.Runtime.Tree;
using Antlr.Runtime;
using tinyAsn1;
using System.IO;

namespace autoICD
{
    /// <summary>
    /// ICD factory. The class extends base class DefaultAsn1Factory and
    /// overrides only those methods needed to instantiate the new types
    /// define in the ICD backend
    /// </summary>
    public class ICDBackendFactory : DefaultAsn1Factory
    {
        public override Asn1File CreateAsn1File()
        {
            return new ICDFile();
        }

        public override Module CreateModule()
        {
            return new ICDModule();
        }

        public override TypeAssigment CreateTypeAssigment()
        {
            return new ICDTypeAssigment();
        }

        public override BitStringType CreateBitStringType()
        {
            return new ICDBitStringType();
        }

        public override BooleanType CreateBooleanType()
        {
            return new ICDBooleanType();
        }

        public override ChoiceType CreateChoiceType()
        {
            return new ICDChoiceType();
        }

        public override ChoiceChild CreateChoiceChildType()
        {
            return new ICDChoiceChild();
        }

        public override EnumeratedType CreateEnumeratedType()
        {
            return new ICDEnumeratedType();
        }


        public override IntegerType CreateIntegerType()
        {
            return new ICDIntegerType();
        }

        public override NullType CreateNullType()
        {
            return new ICDNullType();
        }

        public override ObjectIdentifier CreateObjectIdentifierType()
        {
            return new ICDObjectIdentifier();
        }

        public override OctetStringType CreateOctetStringType()
        {
            return new ICDOctetStringType();
        }

        public override RealType CreateRealType()
        {
            return new ICDRealType();
        }

        public override ReferenceType CreateReferenceType()
        {
            return new ICDReferenceType();
        }

        public override SequenceType CreateSequenceType()
        {
            return new ICDSequenceType();
        }

        public override SequenceOfType CreateSequenceOfType()
        {
            return new ICDSequenceOfType();
        }

        public override SetType CreateSetType()
        {
            return new ICDSetType();
        }

        public override SetOfType CreateSetOfType()
        {
            return new ICDSetOfType();
        }

        public override SequenceOrSetType.Child CreateSequenceOrSetChildType()
        {
            return new ICDSequenceOrSetTypeChild();
        }

        public override SequenceOrSetType.Child CreateSequenceOrSetChildType(SequenceOrSetType.Child o)
        {
            return new ICDSequenceOrSetTypeChild(o);
        }

        public override IA5StringType CreateIA5StringType()
        {
            return new ICDIA5StringType();
        }

        public override NumericStringType CreateNumericStringType()
        {
            return new ICDNumericStringType();
        }

        public override GeneralizedTimeType CreateGeneralizedTimeType()
        {
            return new ICDGeneralizedTimeType();
        }

        public override UTCTimeType CreateUTCTimeTypeType()
        {
            return new ICDUTCTimeType();
        }
    }



    /// <summary>
    /// The ICD backend. It mainly adds a new method PrintHtml
    /// </summary>
    public class ICDBackend : DefaultBackend
    {
        ICDBackendFactory _factory = new ICDBackendFactory();
        public override IAsn1AbstractFactory Factory
        {
            get
            {
                return _factory;
            }
        }

        void Tabularize()
        {
            foreach (ICDFile file in m_files)
                file.Tabularize();
        }


        public virtual void PrintHtml(string f)
        {
            if (m_files.Count > 0)
            {
                string fileName = null;
                if (f == null)
                {
                    fileName = m_files[0].m_fileName;

                    if (fileName.ToUpper().EndsWith(".ASN1"))
                        fileName = fileName.Substring(0, fileName.Length - 5) + ".html";
                    else if (fileName.ToUpper().EndsWith(".ASN"))
                        fileName = fileName.Substring(0, fileName.Length - 4) + ".html";
                    else
                        fileName += ".html";
                }
                else
                    fileName = f;

                StreamWriterLevel wr = null;
                try
                {
                    wr = new StreamWriterLevel(fileName);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex.Message);
                    return;
                }
                wr.WriteLine("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Strict//EN\"");
                wr.WriteLine("        \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd\">");

                wr.WriteLine("<html xmlns=\"http://www.w3.org/1999/xhtml\" >");
                wr.WriteLine("<head>");
                wr.WriteLine("    <title>ICD</title>");
                wr.WriteLine("    <style type=\"text/css\"> {0} </style>", ICDFile.css);
                wr.WriteLine("</head>");
                wr.WriteLine("<body>");
                wr.WriteLine("<em>The following tables describe the binary encodings of the data model using the ASN.1 Unaligned Packed Encoding Rules <a href=\"http://www.itu.int/ITU-T/studygroups/com17/languages/X.691-0207.pdf\">(PER)</a> - ITU-T Rec. X.691 (2002) | ISO/IEC 8825-2:2002 ASN.1 encoding rules.");
                wr.WriteLine(" This page was created by the ");
                wr.WriteLine("<a href=\"http://www.semantix.gr/DataModelling/OnlineDemo/icdDemo.htm\">Automatic ICD Generator tool</a></em><br/><br/>");


                foreach (ICDFile file in m_files)
                    file.PrintHtml(wr, 0);

                if (m_HtmlIntegerSizeMustBeExplained || m_HtmlLengthSizeMustBeExplained || m_HtmlRealSizeMustBeExplained)
                {

                    wr.WriteLine("<hr />");
                    if (m_HtmlIntegerSizeMustBeExplained)
                    {
                        wr.WriteLine("<a name=\"INT_SIZE_EXPLAINED123\"></a>");
                        wr.WriteLine("<em>Unconstraint integer's size explained</em><br/>");
                        wr.WriteLine("In unaligned PER, unconstraint integers are encoded into the minimum number of octets (using non negative binary integer or 2's-complement binary integer encoding) and a length determinant, containing the number of value octets, is added at the beginning of the encoding. Therefore uPER can support integers of any size, even of infinity value. However, in almost all processors, integers have limited capacity which is usually four or eight octets. Therefore, the reported maximum size in octets for an unconstraint integer is 1 (for the length determinant) plus the word size for the target processor which is specified in the command line by the wordSize argument. In this invocation, wordSize was specified to be {0} octets and therefore the maximum size of the unconstraint integers is {1} octets or {2} bits", Config.IntegerSize, Config.IntegerSize + 1, (Config.IntegerSize + 1) * 8);
                        wr.WriteLine("<br/>");
                        wr.WriteLine("<br/>");
                    }
                    if (m_HtmlRealSizeMustBeExplained)
                    {
                        wr.WriteLine("<a name=\"REAL_SIZE_EXPLAINED123\"></a>");
                        wr.WriteLine("<em>Real's size explained</em><br/>");
                        wr.WriteLine("In both uPER and aPER, real values are encoded as a pair of integers which represent the mantissa and exponent (real value = mantissa* 2<span style=\"vertical-align: super\">exponent</span>). In particular, a real is encoded into a length determinant field, a header field (always one octet), the exponent field using 2's complement binary integer and the mantissa field. Therefore uPER can support reals with infinity precision since both exponent and mantissa can, theoretically, have infinity length. However, in almost all processors, integers have limited capacity which is usually four or eight octets. Therefore, the reported maximum size in octets for a real is 1 for the length determinant plus 1 for header field plus 3 octets for exponent and finally plus the word size for the target processor which is specified in the command line by the wordSize argument. In this invocation, wordSize was specified to be {0} octets and therefore the maximum size of a real is {1} octets or {2} bits.", Config.IntegerSize, RealType.uPerMaxSize / 8, RealType.uPerMaxSize);
                        wr.WriteLine("<br/>");
                        wr.WriteLine("<br/>");
                    }
                    if (m_HtmlLengthSizeMustBeExplained)
                    {
                        wr.WriteLine("<a name=\"ARRAYS_SIZE_EXPLAINED123\"></a>");
                        wr.WriteLine("<em>Length's size explained</em><br/>");
                        wr.WriteLine("In uPER, the length determinant field, which used in the encoding of sizeable types such as SEQUENCE OFs, SET OFs, BIT STRINGs, OCTET STRINGs and character types, is at most two octets provided that (a) there is a SIZE constraint which limits the length count to a value less than 64K or (b) there is no size constraint, but in the given instance of the sizeable type the number of the elements is less than 16K. In all other cases, the sizeable type is encoded using fragmentation where the length determinant is encoded interstitially with the actual data. In this particular case (i.e. when fragmentation is applicable), the table produced by the autoICD generator does not represent correctly the physical PER encoding.");
                    }

                    wr.WriteLine("<hr />");
                }

                foreach (ICDFile file in m_files)
                    file.PrintAsn1InHtml(wr, 0);


                wr.WriteLine("</body>");
                wr.WriteLine("</html>");

                wr.Flush();
                wr.Close();

            }
        }
    }

    public class ICDFile : Asn1File
    {
        public void PrintHtml(StreamWriterLevel wr, int lev)
        {
            Tabularize();

            wr.WriteLine("    <div style=\"width: 100%\">");
            wr.WriteLine(string.Format("    <h1 >Asn1 file : {0}</h1>", System.IO.Path.GetFileName(m_fileName)));

            foreach (ICDModule m in m_modules)
                m.PrintHtml(wr, lev);

            wr.WriteLine("    </div>");

            wr.Flush();

        }

        public void PrintAsn1InHtml(StreamWriterLevel wr, int lev)
        {
            //string fname = m_fileName.Substring(m_fileName.LastIndexOf( 

            wr.WriteLine("    <div style=\"width: 100%\">");
            wr.WriteLine("    <h1 >File : {0}</h1>", System.IO.Path.GetFileName(m_fileName));
            wr.WriteLine("<div style=\"width: 100%; white-space:pre; font-family:Courier New; font-size:small\">");
            wr.Write(getAsn1InHtml());
            wr.WriteLine("</div>");
            wr.WriteLine("    </div>");
        }

        string getAsn1InHtml()
        {
            List<string> tas = new List<string>();
            Dictionary<int, string> tabulTyps = new Dictionary<int, string>();
            foreach (Module m in m_modules)
                foreach (TypeAssigment ta in m.m_typeAssigments.Values)
                {
                    if (!ta.m_createdThroughTabulization)
                        tas.Add(ta.m_name);
                    else
                        tabulTyps.Add(ta.m_type.antlrNode.TokenStartIndex, ta.m_name);
                }
            List<string> asn1Words = new List<string>(m_asn1Tokens);


            System.IO.StringWriter strm = new StringWriter();



            for (int i = 0; i < m_tokes.Count; i++)
            {
                IToken t = m_tokes[i];

                if (tabulTyps.ContainsKey(i))
                    strm.Write("<a name=\"ASN1_" + tabulTyps[i].Replace("-", "_") + "\">" + t.Text + "</a>");
                else if (asn1Words.Contains(t.Text))
                    strm.Write("<b><font  color=\"#5F9EA0\" >" + t.Text + "</font></b>");
                else if (t.Type == asn1Lexer.StringLiteral || t.Type == asn1Lexer.OctectStringLiteral || t.Type == asn1Lexer.BitStringLiteral)
                    strm.Write("<font  color=\"#A31515\" >" + t.Text + "</font>");
                else if (t.Type == asn1Lexer.UID && tas.Contains(t.Text))
                {
                    int j = i + 1;
                    while (j < m_tokes.Count)
                        if (m_tokes[j].Type == asn1Lexer.WS || m_tokes[j].Type == asn1Lexer.COMMENT || m_tokes[j].Type == asn1Lexer.COMMENT2)
                            j++;
                        else
                            break;
                    int k = i - 1;
                    while (k>0)
                        if (m_tokes[k].Type == asn1Lexer.WS || m_tokes[k].Type == asn1Lexer.COMMENT || m_tokes[k].Type == asn1Lexer.COMMENT2)
                            k--;
                        else
                            break;

                    if (m_tokes[j].Type == asn1Lexer.ASSIG_OP && m_tokes[k].Type != asn1Lexer.LID)
                        strm.Write("<a name=\"ASN1_" + t.Text.Replace("-", "_") + "\"></a><a href=\"#ICD_" + t.Text.Replace("-", "_") + "\"><font  color=\"#B8860B\" ><b>" + t.Text + "</b></font></a>");
                    else
                        strm.Write("<a href=\"#ASN1_" + t.Text.Replace("-", "_") + "\"><font  color=\"#000000\" >" + t.Text + "</font></a>");
                }
                else if (t.Type == asn1Lexer.COMMENT || t.Type == asn1Lexer.COMMENT2)
                    strm.Write("<font  color=\"#008000\" ><i>" + t.Text + "</i></font>");
                else
                    strm.Write(t.Text);
            }

            return strm.ToString();
        }


        public void Tabularize()
        {
            foreach (ICDModule m in m_modules)
                m.Tabularize();
        }

        static string[] m_asn1Tokens = {
            "PLUS-INFINITY", "MINUS-INFINITY", "GeneralizedTime", "UTCTime", "mantissa", "base", "exponent", "UNION", "INTERSECTION",
            "DEFINITIONS", "EXPLICIT", "TAGS", "IMPLICIT", "AUTOMATIC", "EXTENSIBILITY", "IMPLIED", "BEGIN", "END", "EXPORTS", "ALL",
            "IMPORTS", "FROM", "UNIVERSAL", "APPLICATION", "PRIVATE", "BIT", "STRING", "BOOLEAN", "ENUMERATED", "INTEGER", "REAL",
            "OPTIONAL", "SIZE", "OCTET", "MIN", "MAX", "TRUE", "FALSE", "ABSENT", "PRESENT", "WITH",
            "COMPONENT", "DEFAULT", "NULL", "PATTERN", "OBJECT", "IDENTIFIER", "RELATIVE-OID", "NumericString",
            "PrintableString", "VisibleString", "IA5String", "TeletexString", "VideotexString", "GraphicString", "GeneralString",
            "UniversalString", "BMPString", "UTF8String", "INCLUDES", "EXCEPT", "SET", "SEQUENCE","CHOICE","OF","COMPONENTS"
            };


        public static string css = @"
.headerRow
{
	background-color: #BBBBBB;
}

.hrNo
{
	text-align: center;
	font-family: Verdana;
	color: white;
	font-size: 10pt;
	width: 3%;
}
.hrField
{
	text-align: center;
	font-family: Verdana;
	color: white;
	font-size: 10pt;
	width:15%;
}

.hrComment
{
	text-align: center;
	font-family: Verdana;
	color: white;
	font-size: 10pt;
}

.hrType
{
	text-align: center;
	font-family: Verdana;
	color: white;
	font-size: 10pt;
	width:10%;
}

.hrconstraint
{
	text-align: center;
	font-family: Verdana;
	color: white;
	font-size: 10pt;
	width:10%;
}

.hrconstraint2
{
	text-align: center;
	font-family: Verdana;
	color: white;
	font-size: 10pt;
}

.hrOptional
{
	text-align: center;
	font-family: Verdana;
	color: white;
	font-size: 10pt;
	width:10%;
}
.hrMin
{
	text-align: center;
	font-family: Verdana;
	color: white;
	font-size: 10pt;
	width:10%;
}
.hrMax
{
	text-align: center;
	font-family: Verdana;
	color: white;
	font-size: 10pt;
	width:10%;
}

.hrMin2
{
	text-align: center;
	font-family: Verdana;
	color: white;
	font-size: 10pt;
	width:20%;
}
.hrMax2
{
	text-align: center;
	font-family: Verdana;
	color: white;
	font-size: 10pt;
	width:20%;
}

.CommentRow
{
	background-color: #e9e9e9;
	height:25px;
}

.OddRow
{
	background-color: #e9e9e9;
	height:25px;
}

.EvenRow
{
	background-color: #DBDBDB;
	height:25px;
}


.no
{
	text-align:  center;
	font-family: Verdana;
	color: black;
	font-size: 9pt;
/*	width:30pt;*/
}

.field
{
	text-align: center;
	font-family: Verdana;
	color: black;
	font-size: 9pt;
/*	width:15%;*/
}

.field2
{
	text-align: center;
	font-family: Verdana;
	color: black;
	font-size: 9pt;
}

.comment
{
	color: black;
/*	width:25%;*/
	font-family: Verdana;
	font-size: 9pt;
	text-align:left;
}

.comment2
{
	color: black;
	font-family: Verdana;
	font-size: 9pt;
	text-align:left;
}

.threeDots
{
	color: black;
	font-family: Verdana;
	font-size: 9pt;
	text-align:center;
}

.type
{
	text-align: center;
	font-family: Verdana;
	color: black;
	font-size: 9pt;
/*	width:10%;*/
}

.type2
{
	text-align: center;
	font-family: Verdana;
	color: black;
	font-size: 9pt;
}

.constraint
{
	text-align: center;
	font-family: Verdana;
	color: black;
	font-size: 9pt;
}

.optional
{
	text-align: center;
	font-family: Verdana;
	color: black;
	font-size: 9pt;
/*	width:10%;*/
}
.min
{
	text-align: center;
	font-family: Verdana;
	color: black;
	font-size: 9pt;
/*	width:70pt;*/
}
.max
{
	text-align: center;
	font-family: Verdana;
	color: black;
	font-size: 9pt;
/*	width:70pt;*/
}

.min2
{
	text-align: center;
	font-family: Verdana;
	color: black;
	font-size: 9pt;
}
.max2
{
	text-align: center;
	font-family: Verdana;
	color: black;
	font-size: 9pt;
}


h1
{
	font-family: Verdana, Tahoma;
	color: #033a7a;
	font-size: 14pt;
}

h2
{
	font-family: Verdana, Tahoma;
	color: #033a7a;
	font-size: 12pt;
}
";

    }


    




}