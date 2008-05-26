/**=============================================================================
Definition of constructed types classes used
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

    internal interface ICDType
    {
        void PrintHtml(PEREffectiveConstraint cns, StreamWriterLevel o, int lev, List<string> comment, TypeAssigment tas, List<IConstraint> additonalConstraints);
        void Tabularize(string tasName);
    }

    public static class ICDBType
    {
        //Default implementation of PrintHtml for all types
        public static void PrintHtml(Asn1Type pThis, PEREffectiveConstraint cns, StreamWriterLevel o, int lev, List<string> comment, TypeAssigment tas, List<IConstraint> additonalConstraints)
        {
            o.WriteLine("<a name=\"{0}\"></a>", "ICD_" + tas.m_name.Replace("-", "_"));
            o.WriteLine("<table border=\"0\" width=\"100%\" >");
            o.WriteLine("<tbody>");

            o.WriteLine("<tr  bgcolor=\"{0}\">", (tas.m_createdThroughTabulization ? "#379CEE" : "#FF8f00"));
            o.WriteLine("<td height=\"35\" colspan=\"2\"  >");
            o.WriteLine("<font face=\"Verdana\" color=\"#FFFFFF\" size=\"4\">{0}</font><font face=\"Verdana\" color=\"#FFFFFF\" size=\"2\">({1}) </font>", tas.m_name, pThis.Name);
            o.WriteLine("<font face=\"Verdana\" color=\"#FFFFFF\" size=\"2\"><a href=\"#{0}\">ASN.1</a></font>", "ASN1_" + tas.m_name.Replace("-", "_"));
            o.WriteLine("</td>");

            o.WriteLine("<td height=\"35\" align=\"center\">");
            o.WriteLine("    <font face=\"Verdana\" color=\"#FFFFFF\" size=\"2\">min = {0} bytes</font>", (pThis.MinBytesInPER == -1 ? "&#8734" : pThis.MinBytesInPER.ToString()));
            o.WriteLine("</td>");

            o.WriteLine("<td height=\"35\" align=\"center\">");
            o.WriteLine("    <font face=\"Verdana\" color=\"#FFFFFF\" size=\"2\">max = {0} bytes{1}</font>", (pThis.MaxBytesInPER == -1 ? "&#8734" : pThis.MaxBytesInPER.ToString()), pThis.MaxBitsInPER_Explained);
            o.WriteLine("</td>");
            o.WriteLine("</tr>");


            IInternalContentsInHtml pICIH = pThis as IInternalContentsInHtml;
            string tmp = string.Empty;
            if (pICIH != null)
                tmp = pICIH.InternalContentsInHtml(additonalConstraints);
            if (comment.Count > 0 || tmp.Length > 0)
            {
                o.WriteLine("<tr class=\"CommentRow\">");
                o.WriteLine("<td class=\"comment2\" colspan=\"4\">" + o.BR(comment) + tmp + "</td>");
                o.WriteLine("</tr>");
            }

            o.WriteLine("<tr class=\"headerRow\">");
            o.WriteLine("<td class=\"hrconstraint2\" colspan=\"2\">Constraints</td>");
            o.WriteLine("<td class=\"hrMin2\">Min Length (bits)</td>");
            o.WriteLine("<td class=\"hrMax2\">Max Length (bits)</td>");
            o.WriteLine("</tr>");



            o.WriteLine("<tr class=\"OddRow\">");
            o.WriteLine("    <td class=\"constraint\" colspan=\"2\">{0}</td>", o.Constraint(pThis.Constraints + BaseConstraint.AsString(additonalConstraints)));
            o.WriteLine("    <td class=\"min\" >{0}</td>", pThis.MinBitsInPER);
            o.WriteLine("    <td class=\"max\" >{0}{1}</td>", pThis.MaxBitsInPER, pThis.MaxBitsInPER_Explained);
            o.WriteLine("</tr>");


            o.WriteLine("</tbody>");
            o.WriteLine("</table>");

        }


    }

    public class ICDChoiceType : ChoiceType, ICDType
    {

        public void Tabularize(string tasName)
        {
            foreach (ChoiceChild ch in m_children.Values)
            {
                ((ICDType)ch.m_type).Tabularize(tasName);
                if (ch.m_type.Constructed)
                {

                    TypeAssigment newTas = ((ICDModule)m_module).CreateNewTypeAssigment(ch.m_childVarName, ch.m_type, ch.m_comments);
                    ch.m_type = ReferenceType.CreateByName(newTas);
                }
            }
        }

        public void PrintHtml(PEREffectiveConstraint cns, StreamWriterLevel o, int lev, List<string> comment, TypeAssigment tas, List<IConstraint> additonalConstraints)
        {
            o.WriteLine("<a name=\"{0}\"></a>", "ICD_" + tas.m_name.Replace("-", "_"));
            o.WriteLine("<table border=\"0\" width=\"100%\" >");
            o.WriteLine("<tbody>");
            o.WriteLine("<tr  bgcolor=\"{0}\">", (tas.m_createdThroughTabulization ? "#379CEE" : "#FF8f00"));
            o.WriteLine("<td height=\"35\" colspan=\"3\">");
            o.WriteLine("<font face=\"Verdana\" color=\"#FFFFFF\" size=\"4\">{0}</font><font face=\"Verdana\" color=\"#FFFFFF\" size=\"2\">({1}) </font>", tas.m_name, Name);
            o.WriteLine("<font face=\"Verdana\" color=\"#FFFFFF\" size=\"2\"><a href=\"#{0}\">ASN.1</a></font>", "ASN1_" + tas.m_name.Replace("-", "_"));
            o.WriteLine("</td>");
            o.WriteLine("<td height=\"35\" colspan=\"2\"  align=\"center\">");
            o.WriteLine("<font face=\"Verdana\" color=\"#FFFFFF\" size=\"2\">min = {0} bytes</font>", (MinBytesInPER == -1 ? "&#8734" : MinBytesInPER.ToString()));
            o.WriteLine("</td>");
            o.WriteLine("<td height=\"35\" colspan=\"2\" align=\"center\">");
            o.WriteLine("<font face=\"Verdana\" color=\"#FFFFFF\" size=\"2\">max = {0} bytes</font>", (MaxBytesInPER == -1 ? "&#8734" : MaxBytesInPER.ToString()));
            o.WriteLine("</td>");
            o.WriteLine("</tr>");

            if (comment.Count > 0)
            {
                o.WriteLine("<tr class=\"CommentRow\">");
                o.WriteLine("<td class=\"comment\" colspan=\"7\">" + o.BR(comment) + "</td>");
                o.WriteLine("</tr>");
            }

            o.WriteLine("<tr class=\"headerRow\">");
            o.WriteLine("<td class=\"hrNo\">No</td>");
            o.WriteLine("<td class=\"hrField\">Field</td>");
            o.WriteLine("<td class=\"hrComment\">Comment</td>");
            o.WriteLine("<td class=\"hrType\">Type</td>");
            o.WriteLine("<td class=\"hrconstraint\">Constraint</td>");
            o.WriteLine("<td class=\"hrMin\">Min Length (bits)</td>");
            o.WriteLine("<td class=\"hrMax\">Max Length (bits)</td>");
            o.WriteLine("</tr>");


            int index = 1;
            int chFldNo = 1;
            if (IsPERExtensible())
            {
                PrintChoiceExtBitHtml(o, index, chFldNo);
                chFldNo++;
                index++;
            }


            if (m_children.Count > 1)
            {
                PrintChoiceIndexHtml(o, lev + 1, index, chFldNo);
                chFldNo++;
                index++;
            }
            foreach (ICDChoiceChild ch in m_children.Values)
            {
                ch.PrintHtml(o, lev + 1, index, chFldNo);
                index++;
            }

            o.WriteLine("</tbody>");
            o.WriteLine("</table>");
        }

        private void PrintChoiceExtBitHtml(StreamWriterLevel o, int index, int fieldNo)
        {
            string cssClass = "OddRow";

            o.WriteLine("<tr class=\"" + cssClass + "\">");
            o.WriteLine("<td class=\"no\">{0}</td>", fieldNo);
            o.WriteLine("<td class=\"field\">Extension bit</td>");
            o.WriteLine("<td class=\"comment\">{0}</td>", "If set, an extension, i.e. an unknown to this grammar alternative, is present");
            o.WriteLine("<td class=\"type\">{0}</td>", "Bit");

            o.WriteLine("<td class=\"constraint\">{0}</td>", o.Constraint("N.A."));
            o.WriteLine("<td class=\"min\">{0}</td>", 1);
            o.WriteLine("<td class=\"max\">{0}</td>", 1);
            o.WriteLine("</tr>");
        }

        private void PrintChoiceIndexHtml(StreamWriterLevel o, int p, int index, int fieldNo)
        {
            string cssClass = "OddRow";
            if (index % 2 == 0)
                cssClass = "EvenRow";

            int nBits = PER.GetNumberOfBitsForNonNegativeInteger((ulong)(m_children.Count - 1));

            string commentFld = "Special field used by PER to indicate which choice alternative is present.<br/><ul type=\"square\">";

            for (int i = 0; i < m_children.Values.Count; i++)
            {
                commentFld += string.Format("<li>{0} &#8658 <font  color=\"#5F9EA0\" >{1}</font></li>", i, m_children.Values[i].m_childVarName);
            }
            commentFld += "</ul>";

            o.WriteLine("<tr class=\"" + cssClass + "\">");
            o.WriteLine("<td class=\"no\">{0}</td>", fieldNo);
            o.WriteLine("<td class=\"field\">ChoiceIndex</td>");
            o.WriteLine("<td class=\"comment\">{0}</td>", commentFld);
            o.WriteLine("<td class=\"type\">{0}</td>", "unsigned int");

            o.WriteLine("<td class=\"constraint\">{0}</td>", o.Constraint("N.A."));
            o.WriteLine("<td class=\"min\">{0}</td>", nBits);
            o.WriteLine("<td class=\"max\">{0}</td>", nBits);
            o.WriteLine("</tr>");
        }


    }

    public class ICDChoiceChild : ChoiceChild
    {
        internal void PrintHtml(StreamWriterLevel o, int p, int index, int fieldNo)
        {
            IInternalContentsInHtml intCont = m_type as IInternalContentsInHtml;


            string cssClass = "OddRow";
            if (index % 2 == 0)
                cssClass = "EvenRow";
            o.WriteLine("<tr class=\"" + cssClass + "\">");
            o.WriteLine("<td class=\"no\">{0}</td>", fieldNo);
            o.WriteLine("<td class=\"field\">{0}</td>", m_childVarName);
            if (intCont == null)
                o.WriteLine("<td class=\"comment\">{0}</td>", o.BR(m_comments));
            else
                o.WriteLine("<td class=\"comment\">{0}</td>", o.BR(m_comments) + intCont.InternalContentsInHtml(m_type.m_constraints));
            if (m_type is ReferenceType)
                o.WriteLine("<td class=\"type\"> <a href=\"#ICD_{0}\">{1}</a></td>", m_type.Name.Replace("-", "_"), m_type.Name);
            else
                o.WriteLine("<td class=\"type\">{0}</td>", m_type.Name);

            o.WriteLine("<td class=\"constraint\">{0}</td>", o.Constraint(m_type.Constraints));
            o.WriteLine("<td class=\"min\">{0}</td>", (m_type.MinBitsInPER == -1 ? "&#8734" : m_type.MinBitsInPER.ToString()));
            o.WriteLine("<td class=\"max\">{0}{1}</td>", (m_type.MaxBitsInPER == -1 ? "&#8734" : m_type.MaxBitsInPER.ToString()), m_type.MaxBitsInPER_Explained);
            o.WriteLine("</tr>");
        }
    }

    public class ICDSequenceOrSetTypeChild : SequenceOrSetType.Child
    {
        public ICDSequenceOrSetTypeChild() : base() { }
        public ICDSequenceOrSetTypeChild(SequenceOrSetType.Child o) : base(o) { }
        public void PrintHtml(StreamWriterLevel o, int p, int index)
        {
            IInternalContentsInHtml intCont = m_type as IInternalContentsInHtml;

            string cssClass = "OddRow";
            if (index % 2 == 0)
                cssClass = "EvenRow";
            o.WriteLine("<tr class=\"" + cssClass + "\">");
            o.WriteLine("<td class=\"no\">{0}</td>", index);
            o.WriteLine("<td class=\"field\">{0}</td>", m_childVarName);
            if (intCont == null)
                o.WriteLine("<td class=\"comment\">{0}</td>", o.BR(m_comments));
            else
                o.WriteLine("<td class=\"comment\">{0}</td>", o.BR(m_comments) + intCont.InternalContentsInHtml(m_type.m_constraints));
            if (m_optional)
                o.WriteLine("<td class=\"optional\">Yes</td>");
            else if (m_default)
                o.WriteLine("<td class=\"optional\">Def</td>");
            else
                o.WriteLine("<td class=\"optional\">No</td>");

            if (m_type is ReferenceType)
                o.WriteLine("<td class=\"type\"> <a href=\"#ICD_{0}\">{1}</a></td>", m_type.Name.Replace("-", "_"), m_type.Name);
            else
                o.WriteLine("<td class=\"type\">{0}</td>", m_type.Name);

            o.WriteLine("<td class=\"constraint\">{0}</td>", o.Constraint(m_type.Constraints));

            o.WriteLine("<td class=\"min\">{0}</td>", (m_type.MinBitsInPER == -1 ? "&#8734" : m_type.MinBitsInPER.ToString()));
            o.WriteLine("<td class=\"max\">{0}{1}</td>", (m_type.MaxBitsInPER == -1 ? "&#8734" : m_type.MaxBitsInPER.ToString()), m_type.MaxBitsInPER_Explained);
            o.WriteLine("</tr>");
        }

    }


    public static class ICDSequenceOrSetType
    {
        public static void Tabularize(SequenceOrSetType s, string tasName)
        {
            foreach (SequenceOrSetType.Child ch in s.m_children.Values)
            {
                ((ICDType)ch.m_type).Tabularize(tasName);
                if (ch.m_type.Constructed)
                {
                    TypeAssigment newTas = ((ICDModule)s.m_module).CreateNewTypeAssigment(ch.m_childVarName, ch.m_type, ch.m_comments);
                    ch.m_type = ReferenceType.CreateByName(newTas);
                }

            }
        }

        public static void PrintHtml(SequenceOrSetType pThis, PEREffectiveConstraint cns, StreamWriterLevel o, int lev, List<string> comment, TypeAssigment tas, List<IConstraint> additonalConstraints)
        {
            o.WriteLine("<a name=\"{0}\"></a>", "ICD_" + tas.m_name.Replace("-", "_"));
            o.WriteLine("<table border=\"0\" width=\"100%\" >");
            o.WriteLine("<tbody>");
            o.WriteLine("<tr  bgcolor=\"{0}\">", (tas.m_createdThroughTabulization ? "#379CEE" : "#FF8f00"));
            o.WriteLine("<td height=\"35\" colspan=\"4\">");
            o.WriteLine("<font face=\"Verdana\" color=\"#FFFFFF\" size=\"4\">{0}</font><font face=\"Verdana\" color=\"#FFFFFF\" size=\"2\">({1}) </font>", tas.m_name, pThis.Name);
            o.WriteLine("<font face=\"Verdana\" color=\"#FFFFFF\" size=\"2\"><a href=\"#{0}\">ASN.1</a></font>", "ASN1_" + tas.m_name.Replace("-", "_"));
            o.WriteLine("</td>");
            o.WriteLine("<td height=\"35\" colspan=\"2\"  align=\"center\">");
            o.WriteLine("<font face=\"Verdana\" color=\"#FFFFFF\" size=\"2\">min = {0} bytes</font>", (pThis.MinBytesInPER == -1 ? "&#8734" : pThis.MinBytesInPER.ToString()));
            o.WriteLine("</td>");
            o.WriteLine("<td height=\"35\" colspan=\"2\" align=\"center\">");
            o.WriteLine("<font face=\"Verdana\" color=\"#FFFFFF\" size=\"2\">max = {0} bytes</font>", (pThis.MaxBytesInPER == -1 ? "&#8734" : pThis.MaxBytesInPER.ToString()));
            o.WriteLine("</td>");
            o.WriteLine("</tr>");

            if (comment.Count > 0)
            {
                o.WriteLine("<tr class=\"CommentRow\">");
                o.WriteLine("<td class=\"comment\" colspan=\"8\">" + o.BR(comment) + "</td>");
                o.WriteLine("</tr>");
            }

            o.WriteLine("<tr class=\"headerRow\">");
            o.WriteLine("<td class=\"hrNo\">No</td>");
            o.WriteLine("<td class=\"hrField\">Field</td>");
            o.WriteLine("<td class=\"hrComment\">Comment</td>");
            o.WriteLine("<td class=\"hrOptional\">Optional</td>");

            o.WriteLine("<td class=\"hrType\">Type</td>");
            o.WriteLine("<td class=\"hrconstraint\">Constraint</td>");
            o.WriteLine("<td class=\"hrMin\">Min Length (bits)</td>");
            o.WriteLine("<td class=\"hrMax\">Max Length (bits)</td>");
            o.WriteLine("</tr>");

            int index = 0;
            if (pThis.PreambleLength > 0)
            {
                PrintPreambleHtml(pThis, o, lev + 1);
                index = 1;
            }
            foreach (ICDSequenceOrSetTypeChild ch in pThis.m_children.Values)
            {
                ch.PrintHtml(o, lev + 1, ++index);
            }
            o.WriteLine("</tbody>");
            o.WriteLine("</table>");
        }

        public static void PrintPreambleHtml(SequenceOrSetType pThis, StreamWriterLevel o, int p)
        {
            string comment = "Special field used by PER to indicate the presence/absence of optional and default fields.";
            if (pThis.IsPERExtensible())
                comment = "Special field used by PER to (a) mark the presence of extension(s) and (b) to indicate the presence/absence of optional and default fields.";
            List<ICDSequenceOrSetTypeChild> tmp = new List<ICDSequenceOrSetTypeChild>();
            foreach (ICDSequenceOrSetTypeChild ch in pThis.m_children.Values)
            {
                if (ch.m_optional || ch.m_defaultValue != null)
                    tmp.Add(ch);
            }
            if (tmp.Count > 0 || pThis.IsPERExtensible())
            {
                comment += "<br/><ul type=\"square\">";
                int bitStart = 0;
                if (pThis.IsPERExtensible())
                {
                    comment += string.Format("<li>bit0 == 1 &#8658 extension(s) is present");
                    bitStart++;
                }
                for (int i = 0; i < tmp.Count; i++)
                    comment += string.Format("<li>bit{0} == 1 &#8658 <font  color=\"#5F9EA0\" >{1}</font> is present</li>", i + bitStart, tmp[i].m_childVarName);
                comment += "</ul>";
            }
            string cssClass = "OddRow";
            o.WriteLine("<tr class=\"" + cssClass + "\">");
            o.WriteLine("<td class=\"no\">1</td>");
            o.WriteLine("<td class=\"field\">Preamble</td>");
            o.WriteLine("<td class=\"comment\">{0}</td>", comment);
            o.WriteLine("<td class=\"optional\">No</td>");
            o.WriteLine("<td class=\"type\">{0}</td>", "Bit mask");

            o.WriteLine("<td class=\"constraint\">{0}</td>", o.Constraint("N.A."));
            o.WriteLine("<td class=\"min\">{0}</td>", pThis.PreambleLength);
            o.WriteLine("<td class=\"max\">{0}</td>", pThis.PreambleLength);
            o.WriteLine("</tr>");
        }



    }

    public class ICDSequenceType : SequenceType, ICDType
    {
        public void Tabularize(string tasName)
        {
            ICDSequenceOrSetType.Tabularize(this, tasName);
        }
        public void PrintHtml(PEREffectiveConstraint cns, StreamWriterLevel o, int lev, List<string> comment, TypeAssigment tas, List<IConstraint> additonalConstraints)
        {
            ICDSequenceOrSetType.PrintHtml(this, cns, o, lev, comment, tas, additonalConstraints);
        }
    }

    public class ICDSetType : SetType, ICDType
    {
        public void Tabularize(string tasName)
        {
            ICDSequenceOrSetType.Tabularize(this, tasName);
        }
        public void PrintHtml(PEREffectiveConstraint cns, StreamWriterLevel o, int lev, List<string> comment, TypeAssigment tas, List<IConstraint> additonalConstraints)
        {
            ICDSequenceOrSetType.PrintHtml(this, cns, o, lev, comment, tas, additonalConstraints);
        }
    }



    public static class ICDSizeableType  
    {
        public static void PrintHtml(SizeableType pThis, PEREffectiveConstraint cns, StreamWriterLevel o, int lev, List<string> comment, TypeAssigment tas, List<IConstraint> additonalConstraints)
        {
            o.WriteLine("<a name=\"{0}\"></a>", "ICD_" + tas.m_name.Replace("-", "_"));
            o.WriteLine("<table border=\"0\" width=\"100%\" >");
            o.WriteLine("<tbody>");
            o.WriteLine("<tr  bgcolor=\"{0}\">", (tas.m_createdThroughTabulization ? "#379CEE" : "#FF8f00"));
            o.WriteLine("<td height=\"35\" colspan=\"3\">");
            o.WriteLine("<font face=\"Verdana\" color=\"#FFFFFF\" size=\"4\">{0}</font><font face=\"Verdana\" color=\"#FFFFFF\" size=\"2\">({1}) </font>", tas.m_name, pThis.Name);
            o.WriteLine("<font face=\"Verdana\" color=\"#FFFFFF\" size=\"2\"><a href=\"#{0}\">ASN.1</a></font>", "ASN1_" + tas.m_name.Replace("-", "_"));
            o.WriteLine("</td>");
            o.WriteLine("<td height=\"35\" colspan=\"2\"  align=\"center\">");
            o.WriteLine("<font face=\"Verdana\" color=\"#FFFFFF\" size=\"2\">min = {0} bytes</font>", (pThis.MinBytesInPER == -1 ? "&#8734" : pThis.MinBytesInPER.ToString()));
            o.WriteLine("</td>");
            o.WriteLine("<td height=\"35\" colspan=\"2\" align=\"center\">");
            o.WriteLine("<font face=\"Verdana\" color=\"#FFFFFF\" size=\"2\">max = {0} bytes</font>", (pThis.MaxBytesInPER == -1 ? "&#8734" : pThis.MaxBytesInPER.ToString()));
            o.WriteLine("</td>");
            o.WriteLine("</tr>");

            IInternalContentsInHtml pICIH = pThis as IInternalContentsInHtml;
            if (pICIH != null)
                comment.Add(pICIH.InternalContentsInHtml(additonalConstraints));
            if (comment.Count > 0)
            {
                o.WriteLine("<tr class=\"CommentRow\">");
                o.WriteLine("<td class=\"comment\" colspan=\"7\">" + o.BR(comment) + "</td>");
                o.WriteLine("</tr>");
            }

            o.WriteLine("<tr class=\"headerRow\">");
            o.WriteLine("<td class=\"hrNo\">No</td>");
            o.WriteLine("<td class=\"hrField\">Field</td>");
            o.WriteLine("<td class=\"hrComment\">Comment</td>");
            o.WriteLine("<td class=\"hrType\">Type</td>");
            o.WriteLine("<td class=\"hrconstraint\">Constraint</td>");
            o.WriteLine("<td class=\"hrMin\">Min Length (bits)</td>");
            o.WriteLine("<td class=\"hrMax\">Max Length (bits)</td>");
            o.WriteLine("</tr>");


            PrintSizeLengthHtml(pThis, cns, o, lev + 1, BaseConstraint.AsString(additonalConstraints));
            PrintItemHtml(pThis, cns, o, 1);

            long mxItems = pThis.maxItems(cns);
            if (mxItems > 2 || mxItems==-1)
            {
                o.WriteLine("<tr class=\"CommentRow\">");
                o.WriteLine("<td class=\"threeDots\" colspan=\"7\"> <p>. . .</p> </td>");
                o.WriteLine("</tr>");
            }
            if (pThis.maxItems(cns) >= 2 || mxItems==-1)
                PrintItemHtml(pThis, cns, o, pThis.maxItems(cns));

            o.WriteLine("</tbody>");
            o.WriteLine("</table>");

        }

        private static void PrintSizeLengthHtml(SizeableType pThis, PEREffectiveConstraint cns, StreamWriterLevel o, int p, string additonalConstraints)
        {
            string cssClass = "OddRow";
            long mnItems = pThis.minItems(cns);
            long mxItems = pThis.maxItems(cns);
            if (mnItems == mxItems)
                return;


            o.WriteLine("<tr class=\"" + cssClass + "\">");
            o.WriteLine("<td class=\"no\">1</td>");
            o.WriteLine("<td class=\"field\">Length</td>");
            //            if (mnItems!=mxItems)
            o.WriteLine("<td class=\"comment\">Special field used by PER to indicate the number of items present in the array.</td>");
            //            else
            //                o.WriteLine("<td class=\"comment\">Special field used by PER to indicate the number of items present in the array.In this case however, the length field requires zero bits because its value ({0}) is known in advanced by its size constraint.</td>", mxItems);

            o.WriteLine("<td class=\"type\">{0}</td>", "unsigned int");

            o.WriteLine("<td class=\"constraint\">{0}</td>", o.Constraint(cns.ToString() + additonalConstraints));
            o.WriteLine("<td class=\"min\">{0}</td>", pThis.minSizeBitsInPER(cns));
            o.WriteLine("<td class=\"max\">{0}</td>", (pThis.maxSizeBitsInPER(cns) == -1 ? "16<a href=\"#ARRAYS_SIZE_EXPLAINED123\"><span style=\"vertical-align: super\">why?</span></a>" : pThis.maxSizeBitsInPER(cns).ToString()));
            if (pThis.maxSizeBitsInPER(cns) == -1)
                DefaultBackend.m_HtmlLengthSizeMustBeExplained = true;
            o.WriteLine("</tr>");
        }

        private static void PrintItemHtml(SizeableType pThis, PEREffectiveConstraint cns, StreamWriterLevel o, long itemNo)
        {
            int inc = ((pThis.minItems(cns) == pThis.maxItems(cns) ? 0 : 1));
            string cssClass = "EvenRow";
            o.WriteLine("<tr class=\"" + cssClass + "\">");
            o.WriteLine("<td class=\"no\">{0}</td>", (itemNo) == -1 ? "&#8734" : (itemNo + inc).ToString());
            o.WriteLine("<td class=\"field\">Item #{0}</td>", (itemNo) == -1 ? "&#8734" : itemNo.ToString());
            o.WriteLine("<td class=\"comment\">{0}</td>", "");
            o.WriteLine("<td class=\"type\">{0}</td>", InternalTypeName(pThis));

            o.WriteLine("<td class=\"constraint\">{0}</td>", o.Constraint(pThis.ItemConstraint(cns)));
            o.WriteLine("<td class=\"min\">{0}</td>", (pThis.minItemBitsInPER(cns) == -1 ? "&#8734" : pThis.minItemBitsInPER(cns).ToString()));
            o.WriteLine("<td class=\"max\">{0}</td>", (pThis.maxItemBitsInPER(cns) == -1 ? "&#8734" : pThis.maxItemBitsInPER(cns).ToString()));
            o.WriteLine("</tr>");
        }

        private static string InternalTypeName(SizeableType pThis)
        {
            if (pThis is ArrayType)
            {
                if (((ArrayType)pThis).m_type is ReferenceType)
                    return "<a href=\"#ICD_" + ((ArrayType)pThis).m_type.Name.Replace("-", "_") + "\">" + ((ArrayType)pThis).m_type.Name + "</a>";
                else
                    return ((ArrayType)pThis).m_type.Name;

            }
            if (pThis is NumericStringType)
                return "NUMERIC CHARACTER";
            if (pThis is IA5StringType)
                return "ASCII CHARACTER";
            if (pThis is BitStringType)
                return "BIT";
            if (pThis is OctetStringType)
                return "OCTET";

            throw new Exception("Internal Error");
        }
    }



    public static class ICDArrayType 
    {
        public static void Tabularize(ArrayType a, string tasName)
        {
            ((ICDType)a.m_type).Tabularize(tasName);
            if (a.m_type.Constructed)
            {
                TypeAssigment newTas = ((ICDModule)a.m_module).CreateNewTypeAssigment(tasName, a.m_type, new List<string>());
                a.m_type = ReferenceType.CreateByName(newTas);
            }
        }



    }


    public class ICDSequenceOfType : SequenceOfType, ICDType
    {
        public void Tabularize(string tasName)
        {
            ICDArrayType.Tabularize(this, tasName);
        }
        public void PrintHtml(PEREffectiveConstraint cns, StreamWriterLevel o, int lev, List<string> comment, TypeAssigment tas, List<IConstraint> additonalConstraints)
        {
            ICDSizeableType.PrintHtml(this, cns, o, lev, comment, tas, additonalConstraints);
        }
    }

    public class ICDSetOfType : SetOfType, ICDType
    {
        public void Tabularize(string tasName)
        {
            ICDArrayType.Tabularize(this, tasName);
        }
        public void PrintHtml(PEREffectiveConstraint cns, StreamWriterLevel o, int lev, List<string> comment, TypeAssigment tas, List<IConstraint> additonalConstraints)
        {
            ICDSizeableType.PrintHtml(this, cns, o, lev, comment, tas, additonalConstraints);
        }
    }

}