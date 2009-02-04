/**=============================================================================
Definition of EnumeratedType and EnumeratedValue classes
in autoICD and asn1scc projects  
================================================================================
Copyright(c) Semantix Information Technologies S.A www.semantix.gr
All rights reserved.

This source code is only intended as a supplement to the
Semantix Technical Reference and related electronic documentation 
provided with the autoICD and asn1scc applications.
See these sources for detailed information regarding the
asn1scc and autoICD applications.
==============================================================================*/
using System;
using System.Collections.Generic;
using System.Text;
using Antlr.Runtime.Tree;
using Antlr.Runtime;
using semantix.util;

namespace tinyAsn1
{
    /// <summary>
    /// Represents the ASN.1 ENUMERATED type
    /// </summary>
    public partial class EnumeratedType : Asn1Type
    {
        // list of enumerated items
        public OrderedDictionary<string, Item> m_enumValues = new OrderedDictionary<string, Item>();
        // true if enumerated type is marked as extended
        public bool m_extMarkPresent = false;
        // excpetion specification
        public ExceptionSpec m_exceptionSpec;

        public bool ValuesAutoCalculated = false;

        internal List<NumberedItem> m_enumValuesPriv = new List<NumberedItem>();

        /// <summary>
        /// Represents an enumerated item
        /// </summary>
        public class Item
        {
            public Item(string id, Int64 val, bool isExtended) { m_id = id; m_value = val; m_isExtended = isExtended; m_valCalculated = true; }
            public Item(string id, bool isExtended) { m_id = id; m_isExtended = isExtended; m_valCalculated = false; }
            public string m_id;
            public Int64 m_value;
            public bool m_isExtended = false;
            internal bool m_valCalculated = false;
            public List<string> m_comments = new List<string>();
            public ITree antlrNode;

            string _cid = null;
            public string CID
            {
                get
                {
                    if (_cid == null)
                        return C.ID(m_id);
                    return _cid;
                }
                set
                {
                    _cid = C.ID(value);
                }
            }
        }


        public override string Name
        {
            get { return "ENUMERATED"; }
        }

        public override Asn1Type.Tag UniversalTag
        {
            get
            {
                return DefaultBackend.Instance.Factory.CreateAsn1TypeTag(Tag.TagClass.UNIVERSAL, 10, TaggingMode.EXPLICIT, this);
            }
        }

        //^(ENUMERATED_TYPE enumeratedTypeItems ('...' exceptionSpec? enumeratedTypeItems?) ?)
        static public new EnumeratedType CreateFromAntlrAst(ITree tree)
        {
            EnumeratedType ret = DefaultBackend.Instance.Factory.CreateEnumeratedType();
            
            for (int i = 0; i < tree.ChildCount; i++)
            {
                ITree child = tree.GetChild(i);
                switch (child.Type)
                {
                    case asn1Parser.NUMBER_LST_ITEM:
                        NumberedItem item = NumberedItem.CreateFromAntlrAst(child);
                        if (ret.m_extMarkPresent)
                            item.m_extended = true;
                        //if (ret.m_enumValuesPriv.ContainsKey(item.m_id))
                        //    throw new SemanticErrorException(item.m_id + " has alrady been defined. Line: " + child.Line);
                        ret.m_enumValuesPriv.Add(item);
                        break;
                    case asn1Parser.EXT_MARK:
                        ret.m_extMarkPresent = true;
                        break;
                    case asn1Parser.EXCEPTION_SPEC:
                        ret.m_exceptionSpec = ExceptionSpec.CreateFromAntlrAst(child);
                        break;
                    default:
                        throw new Exception("Unkown child: " + child.Text + " for node: " + tree.Text);

                }
            }

            return ret;
        }

        bool isIdentifierDeclared(string id)
        {
            foreach (NumberedItem ni in m_enumValuesPriv)
                if (ni.m_id == id)
                    return true;

            return isIdentifierProcessed(id);
        }

        bool isIdentifierProcessed(string id)
        {
            return m_enumValues.ContainsKey(id);
        }

        internal override Asn1Value ResolveVariable(Asn1Value val)
        {
            string referenceId;
            switch (val.antlrNode.Type)
            {
                case asn1Parser.VALUE_REFERENCE:
                    referenceId = val.antlrNode.GetChild(0).Text;
                    if (this.isIdentifierDeclared(referenceId))
                    {
                        if (this.isIdentifierProcessed(referenceId))
                        {
                            if (m_enumValues[referenceId].m_valCalculated)
                                return DefaultBackend.Instance.Factory.CreateEnumeratedValue(m_enumValues[referenceId].m_value, referenceId,
                                    val.antlrNode, m_module, this);
                            else
                                return val; //leave for a next pass where value will have been calculated
                        }
                        else
                            return val;// leave for a next pass where (hopefully) it will have been resolved
                    }
                    else if (m_module.isValueDeclared(referenceId))
                    {
                        Asn1Value tmp = m_module.GetValue(referenceId);
                        if (tmp.m_TypeID == Asn1Value.TypeID.UNRESOLVED)
                            return val; // not yet resolved. Wait for next round
                        if (tmp.Type.GetFinalType() == this)
                        {
                            return DefaultBackend.Instance.Factory.CreateEnumeratedValue(tmp as EnumeratedValue, val.antlrNode.GetChild(0));

                        }
                        else
                            throw new SemanticErrorException("Error in line : " + val.antlrNode.Line + ". Identifier '" + referenceId + "' is unknown");
                    }
                    else
                        throw new SemanticErrorException("Error in line : " + val.antlrNode.Line + ". Identifier '" + referenceId + "' is unknown");
                default:
                    throw new SemanticErrorException("Error in line : " + val.antlrNode.Line + ". Expecting enumerated item or enumerated item variable");
            }
        }

        private bool IsValueDefined(Int64 val)
        {
            foreach (Item i in m_enumValues.Values)
                if (i.m_value == val)
                    return true;
            return false;
        }

        internal void FixNumbers()
        {
            int proposedVal = 0;
            foreach (Item i in m_enumValues.Values)
            {
                if (i.m_valCalculated)
                    continue;

//                while (IsValueDefined(proposedVal))

                ValuesAutoCalculated = true;
                i.m_value = proposedVal;
                i.m_valCalculated = true;

                proposedVal++;
            }
            int cnt = m_enumValues.Values.Count;
            for (int i = 0; i < cnt; i++)
            {
                for (int j = i + 1; j < cnt; j++)
                    if (m_enumValues.Values[j].m_value == m_enumValues.Values[i].m_value)
                        throw new SemanticErrorException("Error in line:" + antlrNode.Line.ToString() + 
                            " Enumerated items: " + m_enumValues.Values[i].m_id +" and " + m_enumValues.Values[j].m_id + " have the same value("+m_enumValues.Values[j].m_value+")");
            }


        }

        internal override bool SemanticAnalysisFinished()
        {
            if (m_enumValuesPriv.Count > 0)
                return false;
            if (m_exceptionSpec != null && !m_exceptionSpec.isResolved())
                return false;
            return base.SemanticAnalysisFinished();
        }
        public override void DoSemanticAnalysis()
        {
            EnumeratedType.Item curItem = null;
            base.DoSemanticAnalysis();

            List<NumberedItem> toBeRemoved = new List<NumberedItem>();
            foreach (NumberedItem ni in m_enumValuesPriv)
            {
                if (m_enumValues.ContainsKey(ni.m_id))
                    throw new SemanticErrorException("The ENUMERATED type defined in line " + antlrNode.Line +
                        " containts more than once the identifier " + ni.m_id);
                if (ni.m_valueAsInt != null)
                {
                    curItem = DefaultBackend.Instance.Factory.CreateEnumeratedTypeItem(ni.m_id, ni.m_valueAsInt.Value, ni.m_extended);
                    curItem.antlrNode = ni.antlrNode;
                    m_enumValues.Add(ni.m_id, curItem);
                    toBeRemoved.Add(ni);
                }
                else if (ni.m_valueAsReference == "")
                {
                    curItem = DefaultBackend.Instance.Factory.CreateEnumeratedTypeItem(ni.m_id, ni.m_extended);
                    curItem.antlrNode = ni.antlrNode;
                    m_enumValues.Add(ni.m_id, curItem);
                    toBeRemoved.Add(ni);
                }
                else
                {
                    //We have to look up in the variables definitions
                    string refName = ni.m_valueAsReference;
                    if (m_module.isValueDeclared(refName))
                    {
                        Asn1Value tmpVal = m_module.GetValue(refName);
                        if (tmpVal.m_TypeID == Asn1Value.TypeID.UNRESOLVED)
                            continue;
                        if (tmpVal.m_TypeID == Asn1Value.TypeID.INT)
                        {
                            curItem = DefaultBackend.Instance.Factory.CreateEnumeratedTypeItem(ni.m_id, ((IntegerValue)tmpVal).Value, ni.m_extended);
                            curItem.antlrNode = ni.antlrNode;
                            m_enumValues.Add(ni.m_id, curItem);
                            toBeRemoved.Add(ni);
                        }
                        else
                        {
                            throw new SemanticErrorException("Error in line : " + antlrNode.Line + ". Incompatible types assigment");
                        }
                        //else let it be resolved in a next parse round
                    }
                    else
                        throw new SemanticErrorException("Error in line : " + antlrNode.Line + ". Identifier '" + refName + "' is unknown");
                }

            }

            foreach (NumberedItem ni in toBeRemoved)
                m_enumValuesPriv.Remove(ni);

            if (SemanticAnalysisFinished())
                FixNumbers();

            if (m_exceptionSpec != null && !m_exceptionSpec.isResolved())
                m_exceptionSpec.DoSemanticAnalysis();

        }


        public override void PrintAsn1(StreamWriterLevel o, int lev)
        {
            bool extMark1Printed = false;
            if (m_tag != null)
                m_tag.PrintAsn1(o, lev);
            if (m_enumValues.Count > 0)
            {
                o.WriteLine("ENUMERATED {");
                int cnt = m_enumValues.Count;
                for (int i = 0; i < m_enumValues.Count - 1; i++)
                {
                    o.P(lev + 1);
                    if (m_extMarkPresent && !extMark1Printed && m_enumValues.Values[i].m_isExtended)
                    {
                        extMark1Printed = true;
                        o.P(lev + 1);
                        o.Write("...");
                        if (m_exceptionSpec != null)
                            o.Write(m_exceptionSpec.ToString());
                        o.WriteLine(",");
                    }

                    o.WriteLine(m_enumValues.Keys[i] + "(" + m_enumValues.Values[i].m_value + "),");
                }

                if (m_extMarkPresent && !extMark1Printed && m_enumValues.Values[cnt - 1].m_isExtended)
                {
                    extMark1Printed = true;
                    o.P(lev + 1);
                    o.Write("...");
                    if (m_exceptionSpec != null)
                        o.Write(m_exceptionSpec.ToString());
                    o.WriteLine(",");
                }
                o.P(lev + 1);
                o.WriteLine(m_enumValues.Keys[cnt - 1] + "(" + m_enumValues.Values[cnt - 1].m_value + ")");

                if (m_extMarkPresent && !extMark1Printed)
                {
                    extMark1Printed = true;
                    o.P(lev + 1);
                    o.Write(",...");
                    if (m_exceptionSpec != null)
                        o.Write(m_exceptionSpec.ToString());
                    o.WriteLine();
                }
                
                o.P(lev);
                o.Write("}");
            }
            PrintAsn1Constraints(o);
        }

        public override bool Compatible(Asn1Type other)
        {
            EnumeratedType o = other.GetFinalType() as EnumeratedType;
            if (o == null)
                return false;


            if (m_enumValues.Count != o.m_enumValues.Count)
                return false;

            foreach (string id in m_enumValues.Keys)
            {
                if (!o.m_enumValues.ContainsKey(id))
                    return false;

                if (m_enumValues[id].m_value != o.m_enumValues[id].m_value)
                    return false;
            }

            return true;
        }
        public override bool IsPERExtensible()
        {
            return m_extMarkPresent;
        }


        public int RootItemsCount
        {
            get
            {
                int ret=0;
                foreach(Item it in m_enumValues.Values)
                {
                    if (it.m_isExtended)
                        break;
                    ret++;
                }
                return ret;
            }
        }
        public int ExtendedItemsCount
        {
            get
            {
                int ret = 0;
                foreach (Item it in m_enumValues.Values)
                {
                    if (!it.m_isExtended)
                        continue;
                    ret++;
                }
                return ret;
            }
        }
        public bool IsValueWithRootRange(EnumeratedValue val)
        {
            foreach (Item it in m_enumValues.Values)
            {
                if (it.m_isExtended)
                    break;
                if (it.m_value == val.Value)
                    return true;
            }
            return false;
        }

        public override long maxBitsInPER(PEREffectiveConstraint cns)
        {
            if (!IsPERExtensible())
                return PER.GetNumberOfBitsForNonNegativeInteger((UInt64)(RootItemsCount - 1));

            return 1 + (Config.IntegerSize + 1) * 8;
            
        }

        public override long minBitsInPER(PEREffectiveConstraint cns)
        {
            long ret = 0;
            if (IsPERExtensible())
                ret++;

            ret += PER.GetNumberOfBitsForNonNegativeInteger((UInt64)(RootItemsCount - 1));
            return ret;
        }

        private List<EnumeratedValue> m_allEnumValues = null;
        private List<EnumeratedValue> AllEnumValues
        {
            get
            {
                if (m_allEnumValues == null)
                {
                    m_allEnumValues = new List<EnumeratedValue>();

                    foreach (EnumeratedType.Item item in m_enumValues.Values)
                    {
                        EnumeratedValue val = DefaultBackend.Instance.Factory.CreateEnumeratedValue(
                            item.m_value, item.m_id, item.antlrNode, m_module, this);

                        m_allEnumValues.Add(val);
                    }

                }

                return m_allEnumValues;
            }
        }

        public override ISet GetSet(Asn1Value val)
        {
            DiscreetValueSetWithFiniteUniverse<EnumeratedValue> ret = new DiscreetValueSetWithFiniteUniverse<EnumeratedValue>(AllEnumValues);

            ret.AddValue((EnumeratedValue)val);

            return ret;
        }

        public override void ToXml2(StreamWriterLevel o, int p)
        {
            o.P(p); o.WriteLine("<EnumeratedType Extensible=\"{0}\" ValuesAutoCalculated=\"{1}\">", m_extMarkPresent.ToString(), ValuesAutoCalculated.ToString());
            o.P(p + 1); o.WriteLine("<EnumValues>");
            foreach (Item it in m_enumValues.Values)
            {
                o.P(p + 2); o.WriteLine("<EnumValue StringValue=\"{0}\" IntValue=\"{1}\" Line=\"{2}\" CharPositionInLine=\"{3}\" />",
                    it.m_id, it.m_value,it.antlrNode.Line, it.antlrNode.CharPositionInLine);
            }
            o.P(p + 1); o.WriteLine("</EnumValues>");
            o.P(p); o.WriteLine("</EnumeratedType>");
        }

    }




    public partial class EnumeratedValue : Asn1Value, IEquatable<EnumeratedValue>
    {
        Int64 m_value;
        public virtual Int64 Value
        {
            get { return m_value; }
        }

        string m_id;
        public virtual string ID
        {
            get { return m_id; }
        }

        public EnumeratedValue(Int64 val, string id, ITree antlr, Module module, Asn1Type type)
        {
            m_TypeID = Asn1Value.TypeID.ENUMERATED;
            m_value = val;
            m_id = id;
            m_module = module;
            antlrNode = antlr;
            m_type = type;
        }
        public EnumeratedValue(EnumeratedValue o, ITree antlr)
        {
            m_TypeID = Asn1Value.TypeID.ENUMERATED;
            m_value = o.m_value;
            m_id = o.m_id;
            m_module = o.m_module;
            antlrNode = antlr;
            m_type = o.m_type;
        }
        public override string ToString()
        {
            return ID + "(" + Value.ToString() + ")";
        }

        public bool Equals(EnumeratedValue v)
        {
            return v.m_value == m_value;
        }

        public override bool Equals(object obj)
        {
            EnumeratedValue oth = obj as EnumeratedValue;
            if (oth == null)
                return false;
            return oth.m_value == m_value;
        }

        public override int GetHashCode()
        {
            return m_value.GetHashCode();
        }

        public int Index
        {
            get
            {
                EnumeratedType myType = Type.GetFinalType() as EnumeratedType;
                if (myType==null)
                    throw new Exception("Internal Error");
                int ret = 0;
                foreach (EnumeratedType.Item it in myType.m_enumValues.Values)
                {
                    if (it.m_isExtended)
                        break;
                    if (it.m_value == Value)
                        return ret;
                    ret++;
                }
                ret = 0;
                foreach (EnumeratedType.Item it in myType.m_enumValues.Values)
                {
                    if (!it.m_isExtended)
                        continue;
                    if (it.m_value == Value)
                        return ret;
                    ret++;
                }
                throw new Exception("Internal Error");
            }
        }

        public override List<bool> Encode()
        {
            EnumeratedType myType = Type.GetFinalType() as EnumeratedType;
            if (myType==null)
                throw new Exception("Internal Error");

            List<bool> ret = new List<bool>();

            if (!myType.IsPERExtensible())
            {
                ret = PER.EncodeConstraintWholeNumber(Index, 0, myType.RootItemsCount-1);
            }
            else
            {
                if (myType.IsValueWithRootRange(this))
                {
                    ret.Add(false);
                    ret.AddRange(PER.EncodeConstraintWholeNumber(Index, 0, myType.RootItemsCount - 1));
                }
                else
                {
                    ret.Add(true);
                    ret.AddRange(PER.EncodeNormallySmallNonNegativeNumber((UInt64)Index));
                }
            }

            return ret;
        }

        public override string ToStringC()
        {
            EnumeratedType type = m_type.GetFinalType() as EnumeratedType;
            if (type == null)
                throw new Exception("Internal Error");

            return type.m_enumValues[ID].CID;
            
        }
    }

}
