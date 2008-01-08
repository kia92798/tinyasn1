using System;
using System.Collections.Generic;
using System.Text;
using Antlr.Runtime.Tree;
using Antlr.Runtime;

namespace tinyAsn1
{
    public partial class ObjectIdentifier : Asn1Type
    {

        public override string Name
        {
            get { return "OBJECT IDENTIFIER"; }
        }

        public override Asn1Type.Tag UniversalTag
        {
            get
            {
                return new Tag(Tag.TagClass.UNIVERSAL, 6, TaggingMode.EXPLICIT, this);
            }
        }

        static public new ObjectIdentifier CreateFromAntlrAst(ITree tree)
        {
            return new ObjectIdentifier();
        }
        internal override Asn1Value ResolveVariable(Asn1Value val)
        {
            string referenceId = "";
            ObjectIdentifierValue obVal = val as ObjectIdentifierValue;
            switch (val.antlrNode.Type)
            {
                case asn1Parser.OBJECT_ID_VALUE:
                    if (obVal == null)
                        return new ObjectIdentifierValue(val.antlrNode, m_module, this);
                    else
                    {
                        obVal.FixChildrenVars();
                        return obVal;
                    }
                case asn1Parser.VALUE_REFERENCE:
                    referenceId = val.antlrNode.GetChild(0).Text;
                    if (m_module.isValueDeclared(referenceId))
                    {
                        Asn1Value tmp = m_module.GetValue(referenceId);
                        switch (tmp.m_TypeID)
                        {
                            case Asn1Value.TypeID.OBJECT_IDENTIFIER:
                                if (tmp.IsResolved())
                                {
                                    if (tmp.Type.GetFinalType() == this)
                                        return new ObjectIdentifierValue(tmp as ObjectIdentifierValue, val.antlrNode.GetChild(0));
                                    throw new SemanticErrorException("Error in line : " + val.antlrNode.Line + ". Incompatible variable assigment");
                                }
                                return val; // not yet fully resolved, wait for next round
                            case Asn1Value.TypeID.UNRESOLVED:
                                // not yet resolved, wait for next round
                                return val;
                            default:
                                throw new SemanticErrorException("Error in line : " + val.antlrNode.Line + ". Incompatible variable assigment");
                        }
                    }
                    else
                        throw new SemanticErrorException("Error in line : " + val.antlrNode.Line + ". Identifier '" + referenceId + "' is unknown");

                default:
                    throw new SemanticErrorException("Error in line : " + val.antlrNode.Line + ". Expecting OBJECT IDENTIFIER variable");
            }
        }
        internal override bool SemanticAnalysisFinished()
        {
            return base.SemanticAnalysisFinished();
        }
        public override void DoSemanticAnalysis()
        {
            base.DoSemanticAnalysis();
        }

        public override bool Compatible(Asn1Type other)
        {
            ObjectIdentifier o = other.GetFinalType() as ObjectIdentifier;
            if (o == null)
                return false;
            

            return true;
        }

        public override long minBitsInPER(PEREffectiveConstraint cns)
        {
            return 8;
        }
        public override long maxBitsInPER(PEREffectiveConstraint cns)
        {
            return Config.MaxObjectIdentifierSize;
        }
    }

    public partial class ObjectIdentifierValue : Asn1Value
    {
        public List<ObjectIdentifierComponent> m_components = new List<ObjectIdentifierComponent>();
        public class ObjectIdentifierComponent
        {
            //cases:
            // case 1 : id1
            // is id1 reserved word    -->  label:=id1, no = id1.value
            // if (INDEX==0) && id1 is value reference to OBJ-ID ->replace component with components of other OBJ-ID
            // is id1 reference to INTEGER --> no := INTEGER value
            // is id1 reference to REL_OBJ ID --> ?
            //default: id1 is unknown or reference wrong type
            // case 2 : id1.id2
            // if (INDEX==0) && id1.id2 is value reference to OBJ-ID ->replace component with components of other OBJ-ID
            // is id1.id2 reference to INTEGER --> no := INTEGER value
            // is id1.id2 reference to REL_OBJ ID --> ?
            // case 3 : INT
            // no := INT
            // case 4 : id1 (INT)
            // label := id1, no := INT
            // case 5 : id1 (id2)
            // is id2 reference to INT val  -> label := id1, no:=INT of id2
            // case 6 : id1 (id2.id3)
            // is id2.id3 reference to INT val  -> label := id1, no:=INT of id2.id3
            public int? no = null;
            public string label = null;
            private string id1 = null;
            private string id2 = null;
            private string id3 = null;
            private ITree tr1 = null;
            private ITree tr2 = null;
            private ITree tr3 = null;
            private int caseNo = 0;

            static public ObjectIdentifierComponent CreateFromAntlrAst(ITree tree)
            {
                ObjectIdentifierComponent ret = new ObjectIdentifierComponent();
                switch (tree.Type)
                {
                    case asn1Parser.OBJ_LST_ITEM1:
                        ret.id1 = tree.GetChild(0).Text;
                        ret.tr1 = tree;
                        ret.caseNo = 1;
                        if (tree.ChildCount == 2)
                        {
                            ret.label = ret.id1;
                            ITree chTree = tree.GetChild(1);
                            if (chTree.Type == asn1Parser.INT)
                            {
                                ret.caseNo = 4;
                                ret.no = int.Parse(chTree.Text);
                            }
                            else if (chTree.Type == asn1Parser.DEFINED_VALUE)
                            {
                                if (chTree.ChildCount == 1)
                                {
                                    ret.caseNo = 5;
                                    ret.id2 = chTree.GetChild(0).Text;
                                    ret.tr2 = chTree.GetChild(0);
                                }
                                else if (chTree.ChildCount == 2)
                                {
                                    ret.caseNo = 6;
                                    ret.id2 = chTree.GetChild(0).Text;
                                    ret.tr2 = chTree.GetChild(0);
                                    ret.id3 = chTree.GetChild(1).Text;
                                    ret.tr3 = chTree.GetChild(1);
                                }
                                else
                                    throw new Exception("INTERNAL ERROR");
                            }
                        }
                        return ret;
                    case asn1Parser.OBJ_LST_ITEM2:
                        ret.caseNo = 3;
                        ret.no = int.Parse(tree.GetChild(0).Text);
                        return ret;
                    case asn1Parser.DEFINED_VALUE:
                        ret.caseNo = 2;
                        if (tree.ChildCount != 2)
                            throw new Exception("INTERNAL ERROR");
                        ret.tr1 = tree.GetChild(0);
                        ret.id1 = tree.GetChild(0).Text;
                        ret.tr2 = tree.GetChild(1);
                        ret.id2 = tree.GetChild(1).Text;
                        return ret;
                    default:
                        throw new Exception("Internal Error");
                }

            }

            internal List<ObjectIdentifierComponent> Fixup(int Index, Module mod, ObjectIdentifierComponent prev)
            {
                if (SemanticCheckFinished())
                    return null;
                switch (caseNo)
                {
                    case 1:
                        return handleCase1(Index, mod, prev);
                    case 2:
                        return handleCase2(Index, mod);
                    case 5:
                        return handleCase5(Index, mod);
                    case 6:
                        return handleCase6(Index, mod);
                    default:
                        throw new Exception("INTERNAL ERROR.");
                }
            }

            // case 1 : id1
            // is id1 reserved word    -->  label:=id1, no = id1.value
            // if (INDEX==0) && id1 is value reference to OBJ-ID ->replace component with components of other OBJ-ID
            // is id1 reference to INTEGER --> no := INTEGER value
            // is id1 reference to REL_OBJ ID --> ?
            //default: id1 is unknown or reference wrong type
            List<ObjectIdentifierComponent> handleCase1(int Index, Module mod, ObjectIdentifierComponent prev)
            {
                int tmp;
                string prvLbl = null;
                if (prev != null)
                    prvLbl = prev.label;
                if (YellowIDs.isYellowId(Index, id1, prvLbl, out tmp))
                {
                    no = tmp;
                    label = id1;
                    return null;
                }
                if (!mod.isValueDeclared(id1))
                    throw new SemanticErrorException("Error in line: " + tr1.Line + ", col:" + tr1.CharPositionInLine + ". Unknown identifier: " + id1);
                Asn1Value val = mod.GetValue(id1);
                if (val.m_TypeID == Asn1Value.TypeID.UNRESOLVED)
                    return null; // not yet resolved. wait for next round
                if (val.m_TypeID == TypeID.INT)
                {
                    tmp = (int)((IntegerValue)val).Value;
                    no = tmp;
                    return null;
                }
                if (val.m_TypeID == TypeID.OBJECT_IDENTIFIER)
                {
                    if (Index == 0)
                    {
                        ObjectIdentifierValue obj = val as ObjectIdentifierValue;
                        if (!obj.IsResolved())
                            return null; //wait until resolved
                        return obj.m_components;
                    }
                    else
                        throw new SemanticErrorException("Error in line: " + tr1.Line + ", col:" + tr1.CharPositionInLine + ". Identifier: " + id1 + "resolves to OBJECT IDENTIFIER but it is not the first item");
                }
                if (val.m_TypeID == TypeID.REL_OBJ_ID)
                {
                    throw new Exception("UNIMPLEMENTED FEATURE");
                }

                throw new SemanticErrorException("Error in line: " + tr1.Line + ", col:" + tr1.CharPositionInLine + ". Identifier: " + id1 + "does not resolve to INTEGER or RELATIVE-OID");
            }

            static class YellowIDs
            {
                class ID
                {
                    public int value;
                    public int level;
                    public string father;
                    public ID(int v, int l, string f) { value = v; level = l; father = f; }
                }
                static Dictionary<string, ID> ids = new Dictionary<string, ID>();
                static YellowIDs()
                {
                    ids.Add("itu-t", new ID(0, 0, null));
                    ids.Add("ccitt", new ID(0, 0, null));
                    ids.Add("iso", new ID(1, 0, null));
                    ids.Add("joint-iso-itu-t", new ID(2, 0, null));
                    ids.Add("joint-iso-ccitt", new ID(2, 0, null));

                    ids.Add("itu-t.recommendation", new ID(0, 1, "itu-t"));
                    ids.Add("itu-t.question", new ID(1, 1, "itu-t"));
                    ids.Add("itu-t.administration", new ID(2, 1, "itu-t"));
                    ids.Add("itu-t.network-operator", new ID(3, 1, "itu-t"));
                    ids.Add("itu-t.identified-organization", new ID(4, 1, "itu-t"));

                    ids.Add("iso.standard", new ID(0, 1, "iso"));
                    ids.Add("iso.member-body", new ID(2, 1, "iso"));
                    ids.Add("iso.identified-organization", new ID(3, 1, "iso"));

                    int j = 0;
                    for (char i = 'a'; i <= 'z'; i++)
                    {
                        j++;
                        ids.Add("recommendation." + new string(i, 1), new ID(j, 2, "recommendation"));
                    }
                }

                public static bool isYellowId(int level, string id, string prevId, out int retVal)
                {
                    retVal = 0;
                    if (prevId == "ccitt")
                        prevId = "itu-t";
                    if (prevId == "joint-iso-ccitt")
                        prevId = "joint-iso-itu-t";
                    if (prevId != null)
                        id = prevId + "." + id;

                    if (!ids.ContainsKey(id))
                        return false;

                    ID y = ids[id];
                    if (y.level == level)
                    {
                        retVal = y.value;
                        return true;
                    }
                    return false;
                }
            }


            // case 2 : id1.id2
            // if (INDEX==0) && id1.id2 is value reference to OBJ-ID ->replace component with components of other OBJ-ID
            // is id1.id2 reference to INTEGER --> no := INTEGER value
            // is id1.id2 reference to REL_OBJ ID --> ?
            List<ObjectIdentifierComponent> handleCase2(int Index, Module m)
            {
                if (!Asn1CompilerInvokation.Instance.isModuleDefined(id1))
                    throw new SemanticErrorException("Error in line: " + tr1.Line + ", col:" + tr1.CharPositionInLine + ". Identifier: " + id1 + " does not resolve to a MODULE");

                Module mod = Asn1CompilerInvokation.Instance.GetModuleByName(id1);

                if (!mod.isValueDeclared(id2))
                    throw new SemanticErrorException("Error in line: " + tr2.Line + ", col:" + tr2.CharPositionInLine + ". Unknown identifier: " + id2);
                Asn1Value val = mod.GetValue(id2);
                if (val.m_TypeID == Asn1Value.TypeID.UNRESOLVED)
                    return null; // not yet resolved. wait for next round
                if (val.m_TypeID == TypeID.INT)
                {
                    int tmp = (int)((IntegerValue)val).Value;
                    no = tmp;
                    return null;
                }
                if (val.m_TypeID == TypeID.OBJECT_IDENTIFIER)
                {
                    if (Index == 0)
                    {
                        ObjectIdentifierValue obj = val as ObjectIdentifierValue;
                        if (!obj.IsResolved())
                            return null; //wait until resolved
                        return obj.m_components;
                    }
                    else
                        throw new SemanticErrorException("Error in line: " + tr1.Line + ", col:" + tr1.CharPositionInLine + ". Identifier: " + id1 + "." + id2 + " resolves to OBJECT IDENTIFIER but it is not the first item");
                }

                if (val.m_TypeID == TypeID.REL_OBJ_ID)
                {
                    throw new Exception("UNIMPLEMENTED FEATURE");
                }

                throw new SemanticErrorException("Error in line: " + tr2.Line + ", col:" + tr2.CharPositionInLine + ". Identifier: " + id2 + "does not resolve to INTEGER or RELATIVE-OID");
            }
            // case 5 : id1 (id2)
            // is id2 reference to INT val  -> label := id1, no:=INT of id2
            List<ObjectIdentifierComponent> handleCase5(int Index, Module mod)
            {
                if (!mod.isValueDeclared(id2))
                    throw new SemanticErrorException("Error in line: " + tr2.Line + ", col:" + tr2.CharPositionInLine + ". Unknown identifier: " + id2);
                Asn1Value val = mod.GetValue(id2);
                if (val.m_TypeID == Asn1Value.TypeID.UNRESOLVED)
                    return null; // not yet resolved. wait for next round
                if (val.m_TypeID == TypeID.INT)
                {
                    int tmp = (int)((IntegerValue)val).Value;
                    no = tmp;
                    return null;
                }

                throw new SemanticErrorException("Error in line: " + tr2.Line + ", col:" + tr2.CharPositionInLine + ". Identifier: " + id2 + "does not resolve to INTEGER or RELATIVE-OID");
            }
            // case 6 : id1 (id2.id3)
            // is id2.id3 reference to INT val  -> label := id1, no:=INT of id2.id3
            List<ObjectIdentifierComponent> handleCase6(int Index, Module m)
            {
                if (!Asn1CompilerInvokation.Instance.isModuleDefined(id2))
                    throw new SemanticErrorException("Error in line: " + tr2.Line + ", col:" + tr2.CharPositionInLine + ". Identifier: " + id2 + "does not resolve to a MODULE");

                Module mod = Asn1CompilerInvokation.Instance.GetModuleByName(id2);

                if (!mod.isValueDeclared(id3))
                    throw new SemanticErrorException("Error in line: " + tr3.Line + ", col:" + tr3.CharPositionInLine + ". Unknown identifier: " + id3);
                Asn1Value val = mod.GetValue(id3);
                if (val.m_TypeID == Asn1Value.TypeID.UNRESOLVED)
                    return null; // not yet resolved. wait for next round
                if (val.m_TypeID == TypeID.INT)
                {
                    int tmp = (int)((IntegerValue)val).Value;
                    no = tmp;
                    return null;
                }

                throw new SemanticErrorException("Error in line: " + tr3.Line + ", col:" + tr2.CharPositionInLine + ". Identifier: " + id3 + "does not resolve to INTEGER or RELATIVE-OID");
            }

            public override string ToString()
            {
                if (no == null)
                    throw new Exception("Internal Error");

                if (label != null)
                    return label + "(" + no.Value.ToString() + ")";

                return no.Value.ToString();

            }
            public override bool Equals(object obj)
            {
                ObjectIdentifierComponent oth = obj as ObjectIdentifierComponent;
                if (oth == null)
                    return false;
                if (no == null)
                    throw new Exception("Internal Error");
                if (oth.no == null)
                    throw new Exception("Internal Error");

                return oth.no == no;
            }
            public override int GetHashCode()
            {
                return ToString().GetHashCode();
            }

            public bool SemanticCheckFinished()
            {
                return no != null;
            }


        }
        public override string ToString()
        {

            System.IO.StringWriter w = new System.IO.StringWriter();

            w.Write("{");
            int cnt = m_components.Count;
            for (int i = 0; i < cnt; i++)
            {
                w.Write(m_components[i].ToString() + " ");
            }

            w.Write(" }");

            w.Flush();
            return w.ToString();
        }
        public override bool Equals(object obj)
        {
            ObjectIdentifierValue oth = obj as ObjectIdentifierValue;
            if (oth == null)
                return false;
            if (oth.m_components.Count != m_components.Count)
                return false;

            for (int i = 0; i < m_components.Count; i++)
            {
                if (!m_components[i].Equals(oth.m_components[i]))
                    return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            return m_components.GetHashCode();
        }
        public ObjectIdentifierValue(ObjectIdentifierValue o, ITree antlr)
        {
            m_TypeID = Asn1Value.TypeID.OBJECT_IDENTIFIER;
            m_module = o.m_module;
            antlrNode = antlr;
            m_type = o.m_type;
            m_components = o.m_components;
        }
        public ObjectIdentifierValue(ITree antlrNode, Module module, Asn1Type type)
        {
            m_TypeID = Asn1Value.TypeID.OBJECT_IDENTIFIER;
            this.antlrNode = antlrNode;
            m_module = module;
            m_type = type;

            if (antlrNode.Type != asn1Parser.OBJECT_ID_VALUE)
                throw new Exception("Internal Error. ObjectIdentifierValue() constructot called with wrong antlr node type");
            for (int i = 0; i < antlrNode.ChildCount; i++)
            {
                m_components.Add(ObjectIdentifierComponent.CreateFromAntlrAst(antlrNode.GetChild(i)));
            }


        }

        public override bool IsResolved()
        {
            foreach (ObjectIdentifierComponent cm in m_components)
                if (!cm.SemanticCheckFinished())
                    return false;

            return true;
        }


        internal void FixChildrenVars()
        {

            List<ObjectIdentifierComponent> items;
            for (int i = 0; i < m_components.Count; i++)
            {
                if (i > 0)
                    items = m_components[i].Fixup(i, m_module, m_components[i - 1]);
                else
                    items = m_components[i].Fixup(i, m_module, null);

                if (items != null)
                {
                    //replace i item with items
                    m_components.RemoveAt(i);
                    m_components.InsertRange(i, items);
                }
            }
        }


        List<bool> EncodeSubIdentifier(int value)
        {
            List<bool> ret = new List<bool>();
            LinkedList<bool> tmp = new LinkedList<bool>(PER.EncodeNonNegativeInteger((UInt64)Math.Abs(value)));

            while (tmp.Count > 0)
            {
                ret.Insert(0, tmp.Last.Value);

                if (ret.Count % 8 == 7)
                {
                    if (ret.Count == 7)
                        ret.Insert(0, false);
                    else
                        ret.Insert(0, true);
                }
                tmp.RemoveLast();
            }

            while (ret.Count % 8 > 0)
                ret.Add(false);
            if (ret.Count > 8)
                ret[0] = true;

            return ret;
        }
        public override List<bool> Encode()
        {
            List<bool> ret = new List<bool>();
            List<int> subIDs = new List<int>();

            subIDs.Add(m_components[0].no.Value * 40 + m_components[1].no.Value);
            for (int i = 2; i < m_components.Count - 1; i++)
                subIDs.Add(m_components[i].no.Value);

            foreach (int subID in subIDs)
                ret.AddRange(EncodeSubIdentifier(subID));
            if (ret.Count % 8 != 0)
                throw new Exception("Internal Error");

            int nBytes = ret.Count / 8;

            if (nBytes <= 0x7F)
            {
                ret.InsertRange(0, PER.EncodeConstraintWholeNumber(nBytes, 0, 0xFF));
            }
            else if (nBytes <= 0x3FFF)
            {
                ret.Insert(0,true);
                ret.InsertRange(0, PER.EncodeConstraintWholeNumber(nBytes, 0, 0x7FFF));
            }
            else
            {
                throw new Exception("Internal Error");
            }

            return ret;
        }
    }

}
