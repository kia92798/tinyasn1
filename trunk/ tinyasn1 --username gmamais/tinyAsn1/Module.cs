using System;
using System.Collections.Generic;
using System.Text;
using Antlr.Runtime.Tree;
using Antlr.Runtime;
using System.IO;

namespace tinyAsn1
{
    public enum TaggingMode
    {
        EXPLICIT,
        IMPLICIT,
        AUTOMATIC
    }

    public partial class Module
    {
        public string m_moduleID = "";
        public TaggingMode m_taggingMode = TaggingMode.EXPLICIT;     // clause 12.2
        public bool m_extensibilityImplied = false;

        public List<string> m_exportedTypes = new List<string>();
        public List<string> m_exportedVariables = new List<string>();
        public List<ImportedModule> m_imports = new List<ImportedModule>();

        public OrderedDictionary<string, TypeAssigment> m_typeAssigments = new OrderedDictionary<string, TypeAssigment>();
        public OrderedDictionary<string, ValueAssigment> m_valuesAssigments = new OrderedDictionary<string, ValueAssigment>();

        public Asn1Value GetValue(string valueName)
        {
            if (!isValueDeclared(valueName))
                throw new Exception("Internal Error: variable '" + valueName + "' is not declared");
            if (m_valuesAssigments.ContainsKey(valueName))
                return m_valuesAssigments[valueName].m_value;
            foreach (ImportedModule im in m_imports)
            {
                if (im.m_importedVariables.Contains(valueName))
                {
                    Module otherModule = Asn1CompilerInvokation.Instance.GetModuleByName(im.m_moduleID);
                    return otherModule.GetValue(valueName);
                }
            }

            throw new Exception("Internal error: ");
        }


        public bool isValueDeclared(string valueName)
        {
            if (m_valuesAssigments.ContainsKey(valueName))
                return true;
            foreach (ImportedModule im in m_imports)
                if (im.m_importedVariables.Contains(valueName))
                    return true;

            return false;
        }

        public bool isValueDeclaredAsExported(string valueName)
        {
            if (!isValueDeclared(valueName))
                return false;
            if (m_exportedVariables.Contains(valueName))
                return true;
            return false;
        }

        public bool isTypeDeclared(string typeName)
        {
            if (m_typeAssigments.ContainsKey(typeName))
                return true;
            foreach (ImportedModule im in m_imports)
                if (im.m_importedTypes.Contains(typeName))
                    return true;

            return false;

        }

        public bool isTypeDeclaredAsExported(string typeName)
        {
            if (!isTypeDeclared(typeName))
                return false;
            if (m_exportedTypes.Contains(typeName))
                return true;
            return false;

        }

        // it return the type 
        public Asn1Type GetTypeByName(string typeName)
        {
            if (m_typeAssigments.ContainsKey(typeName))
                return m_typeAssigments[typeName].m_type;

            foreach (ImportedModule im in m_imports)
                if (im.m_importedTypes.Contains(typeName))
                {
                    Module otherMode = Asn1CompilerInvokation.Instance.GetModuleByName(im.m_moduleID);
                    return otherMode.GetTypeByName(typeName);
                }
            throw new SemanticErrorException("Error: '" + typeName + "' is undefined");
        }

        //        public OrderedDictionary<string, ValueSetAssigment> m_valueSetsAssigments = new OrderedDictionary<string, ValueSetAssigment>();

        internal Dictionary<string, Int64> m_resolvedIntegerVars = new Dictionary<string, Int64>();


        ITree tree;

        internal static Module CurrentlyConstructModule = null;
        //^(MODULE_DEF modulereference moduleTag? EXTENSIBILITY? exports? imports? typeAssigment* valueAssigment* valueSetAssigment*)
        internal bool bExportAll = false;
        static public Module CreateFromAntlrAst(ITree tree)
        {

            Module curModule;

            if (tree.Type != asn1Parser.MODULE_DEF)
                throw new Exception("MODULE_DEF");

            curModule = new Module();
            curModule.tree = tree;

            CurrentlyConstructModule = curModule;
            for (int i = 0; i < tree.ChildCount; i++)
            {
                ITree child = tree.GetChild(i);

                switch (child.Type)
                {
                    case asn1Parser.UID:
                        curModule.m_moduleID = child.Text;
                        break;
                    case asn1Parser.EXPLICIT:
                        curModule.m_taggingMode = TaggingMode.EXPLICIT;
                        break;
                    case asn1Parser.IMPLICIT:
                        curModule.m_taggingMode = TaggingMode.IMPLICIT;
                        break;
                    case asn1Parser.AUTOMATIC:
                        curModule.m_taggingMode = TaggingMode.AUTOMATIC;
                        break;
                    case asn1Parser.EXTENSIBILITY:
                        curModule.m_extensibilityImplied = true;
                        break;
                    case asn1Parser.EXPORTS_ALL:
                        curModule.bExportAll = true;
                        //                        curModule.m_exportStatus = ExportStatus.ALL;
                        break;
                    case asn1Parser.EXPORTS:
                        handleExports(curModule, child);
                        break;
                    case asn1Parser.IMPORTS_FROM_MODULE:
                        curModule.m_imports.Add(ImportedModule.CreateFromAntlrAst(child, curModule));
                        break;
                    case asn1Parser.TYPE_ASSIG:
                        TypeAssigment typeAssig = TypeAssigment.CreateFromAntlrAst(child);
                        if (curModule.isTypeDeclared(typeAssig.m_name))
                            throw new SemanticErrorException(typeAssig.m_name + " has alrady been defined or imported. Line: " + child.Line);
                        curModule.m_typeAssigments.Add(typeAssig.m_name, typeAssig);
                        break;
                    case asn1Parser.VAL_ASSIG:
                        ValueAssigment valAssig = ValueAssigment.CreateFromAntlrAst(child);
                        if (curModule.isValueDeclared(valAssig.m_name))
                            throw new SemanticErrorException(valAssig.m_name + " has alrady been defined or imported. Line: " + child.Line);
                        curModule.m_valuesAssigments.Add(valAssig.m_name, valAssig);
                        break;
                    /*                    case asn1Parser.VAL_SET_ASSIG:
                                            ValueSetAssigment valSetAssig = ValueSetAssigment.CreateFromAntlrAst(child);
                                            if (curModule.m_valueSetsAssigments.ContainsKey(valSetAssig.m_typeReference))
                                                throw new SemanticErrorException(valSetAssig.m_typeReference + " has alrady been defined. Line: " + child.Line);
                                            curModule.m_valueSetsAssigments.Add(valSetAssig.m_typeReference, valSetAssig);
                                            break;*/
                    default:
                        throw new Exception("Unkown child: " + child.Text + " for node: " + tree.Text);
                }

            }

            {
                // If EXPORT ALL OR nothing is exported ==> make all type, variable and imports assigment exportable
                if (curModule.bExportAll || (curModule.m_exportedTypes.Count == 0 && curModule.m_exportedVariables.Count == 0))
                {
                    foreach (TypeAssigment typeAss in curModule.m_typeAssigments.Values)
                        curModule.m_exportedTypes.Add(typeAss.m_name);
                    foreach (ValueAssigment valAsig in curModule.m_valuesAssigments.Values)
                        curModule.m_exportedVariables.Add(valAsig.m_name);
                    foreach (ImportedModule im in curModule.m_imports)
                    {
                        curModule.m_exportedTypes.AddRange(im.m_importedTypes);
                        curModule.m_exportedVariables.AddRange(im.m_importedVariables);
                    }

                    curModule.bExportAll = false;
                }
            }



            return curModule;
        }


        private static void handleExports(Module curMod, ITree tree)
        {
            for (int i = 0; i < tree.ChildCount; i++)
            {
                ITree child = tree.GetChild(i);

                switch (child.Type)
                {
                    case asn1Parser.UID:
                        curMod.m_exportedTypes.Add(child.Text);
                        break;
                    case asn1Parser.LID:
                        curMod.m_exportedVariables.Add(child.Text);
                        break;
                    default:
                        throw new Exception("Unkown child: " + child.Text + " for node: " + tree.Text);
                }
            }
        }

        internal bool SemanticCheckFinished()
        {
            foreach (TypeAssigment t in m_typeAssigments.Values)
                if (!t.m_type.SemanticAnalysisFinished())
                    return false;

            foreach (ValueAssigment v in m_valuesAssigments.Values)
            {
                if (!v.m_type.SemanticAnalysisFinished())
                    return false;
                if (!v.m_value.IsResolved())
                    return false;
            }
            return true;
        }



        public virtual void PrintAsn1(StreamWriterLevel o, int lev)
        {
            o.Write(m_moduleID + " DEFINITIONS ");
            switch (m_taggingMode)
            {
                case TaggingMode.AUTOMATIC:
                    o.Write("AUTOMATIC TAGS ");
                    break;
                case TaggingMode.EXPLICIT:
                    o.Write(" EXPLICIT TAGS ");
                    break;
                case TaggingMode.IMPLICIT:
                    o.Write(" IMPLICIT TAGS ");
                    break;
            }
            if (m_extensibilityImplied)
                o.Write(" EXTENSIBILITY IMPLIED ");

            o.WriteLine(" ::=");
            o.WriteLine("BEGIN");

            if (m_exportedTypes.Count > 0 || m_exportedVariables.Count > 0)
            {
                o.WriteLine("EXPORTS");
                List<string> export = new List<string>(m_exportedTypes);
                export.AddRange(m_exportedVariables);
                for (int i = 0; i < export.Count - 1; i++)
                {
                    o.WriteLine("\t" + export[i] + ",");
                }
                o.WriteLine("\t" + export[export.Count - 1] + ";");
                o.WriteLine();
            }

            //print imports
            foreach (ImportedModule imMod in m_imports)
                imMod.PrintAsn1(o, lev + 1);

            o.WriteLine();

            foreach (TypeAssigment tas in m_typeAssigments.Values)
                tas.PrintAsn1(o, lev+1);

            o.WriteLine();

            foreach (ValueAssigment vas in m_valuesAssigments.Values)
                vas.PrintAsn1(o, lev+1);

            o.WriteLine();
            o.WriteLine("END");
        }

        public void DoPhase1SemanticAnalysis()
        {
            Asn1CompilerInvokation m_compInv = Asn1CompilerInvokation.Instance;
            // Make sure that all imported types are defined in the reference module
            foreach (ImportedModule im in m_imports)
            {
                if (!m_compInv.isModuleDefined(im.m_moduleID))
                    throw new SemanticErrorException("Error: no module is defined with name: '" + im.m_moduleID + "'");

                Module otherModule = m_compInv.GetModuleByName(im.m_moduleID);
                foreach (string typeName in im.m_importedTypes)
                {
                    if (!otherModule.isTypeDeclaredAsExported(typeName))
                        throw new SemanticErrorException("Error: import type '" + typeName + "' which appears in the import list of module '" + m_moduleID + "' is not exported in module:'" + otherModule.m_moduleID + "'");
                }
                foreach (string varName in im.m_importedVariables)
                {
                    if (!otherModule.isValueDeclaredAsExported(varName))
                        throw new SemanticErrorException("Error: import variable '" + varName + "' which appears in the import list of module '" + m_moduleID + "' is not exported in module:'" + otherModule.m_moduleID + "'");
                }
            }
            //Make sure that every export is defined 
            foreach (string expTypeName in m_exportedTypes)
                if (!isTypeDeclared(expTypeName))
                    throw new SemanticErrorException("Error: type '" + expTypeName + "' which appears in the export list of module '" + m_moduleID + "' is not defined");
            foreach (string expVarName in m_exportedVariables)
                if (!isValueDeclared(expVarName))
                    throw new SemanticErrorException("Error: variable '" + expVarName + "' which appears in the export list of module '" + m_moduleID + "' is not defined");


            foreach (TypeAssigment tas in m_typeAssigments.Values)
                if (!tas.m_type.SemanticAnalysisFinished())
                    tas.m_type.DoSemanticAnalysis();

            foreach (ValueAssigment vas in m_valuesAssigments.Values)
            {
                if (!vas.m_type.SemanticAnalysisFinished())
                    vas.m_type.DoSemanticAnalysis();

                if (!vas.m_value.IsResolved())
                    vas.m_value = vas.m_type.ResolveVariable(vas.m_value);
            }
        }


        public IEnumerable<T> GetTypes<T>() where T : Asn1Type
        {
            foreach (TypeAssigment tas in m_typeAssigments.Values)
                foreach (T t in tas.m_type.GetMySelfAndAnyChildren<T>())
                    yield return t;
        }

        public IEnumerable<KeyValuePair<string,T>> GetTypesWithPath<T>() where T : Asn1Type
        {
            foreach (TypeAssigment tas in m_typeAssigments.Values)
                foreach (KeyValuePair<string, T> t in tas.m_type.GetMySelfAndAnyChildrenWithPath<T>(m_moduleID + "/" + tas.m_name))
                    yield return t;
        }


        internal void EncodeVars(string m_fileName)
        {
            foreach (ValueAssigment vas in m_valuesAssigments.Values)
            {
                if (vas.m_type.isValueAllowed(vas.m_value))
                {
                    System.IO.FileStream wr = new System.IO.FileStream(m_fileName + "-" + m_moduleID + "-" + vas.m_name, System.IO.FileMode.Create);
                    List<byte> bufer = vas.m_value.Encode2();
                    wr.Write(bufer.ToArray(), 0, bufer.Count);
                }
            }
        }

        public void PrintHtml(StreamWriterLevel wr, int p)
        {
            wr.WriteLine("<div style=\"width: 100%\">");
            wr.WriteLine(string.Format("<h2 >Module : {0}</h2>", m_moduleID));
            foreach (TypeAssigment tas in m_typeAssigments.Values)
                tas.PrintHtml(wr, p + 1);
            wr.WriteLine("</div>");
        }

        public void Tabularize()
        {
            int cnt = m_typeAssigments.Values.Count;
            for (int i=0;i < cnt;i++ ) {
                TypeAssigment tas = m_typeAssigments.Values[i];
                tas.m_type.Tabularize(tas.m_name);
            }
            //foreach (TypeAssigment tas in m_typeAssigments.Values)
            //    tas.m_type.Tabularize(tas.m_name);
        }

        public TypeAssigment CreateNewTypeAssigment(string name, Asn1Type asn1Type, List<string> commenst)
        {
            string newName = name[0].ToString().ToUpper() + name.Substring(1,name.Length-1);
            int i=0;
            while(m_typeAssigments.ContainsKey(newName)) {
                i++;
                newName += i.ToString();
            }
            TypeAssigment ret = new TypeAssigment();
            ret.m_name = newName;
            ret.m_type = asn1Type;
            ret.m_comments = commenst;
            m_typeAssigments.Add(newName, ret);
            ret.m_createdThroughTabulization = true;
            return ret;
        }


    }


    public partial class ImportedModule
    {
        public Module m_parentModule;          // parent module is the module that contains myself
        public string m_moduleID = "";  // moduleID is the module where the definition of imported types occurs
        public List<string> m_importedTypes = new List<string>();
        public List<string> m_importedVariables = new List<string>();

        ITree tree;
        //^(IMPORTS_FROM_MODULE modulereference typereference* valuereference*  )
        static public ImportedModule CreateFromAntlrAst(ITree tree, Module parent)
        {
            ImportedModule ret = new ImportedModule();
            ret.m_parentModule = parent;
            ret.tree = tree;

            ret.m_moduleID = tree.GetChild(0).Text;
            if (ret.m_moduleID == ret.m_parentModule.m_moduleID)
                throw new SemanticErrorException("Error: Can not import from myself. Line: " + tree.Line);

            for (int i = 1; i < tree.ChildCount; i++)
            {
                ITree child = tree.GetChild(i);

                switch (child.Type)
                {
                    case asn1Parser.UID:
                        if (ret.m_parentModule.isTypeDeclared(child.Text))
                            throw new SemanticErrorException(child.Text + " has alrady been imported. Line: " + child.Line);
                        ret.m_importedTypes.Add(child.Text);
                        break;
                    case asn1Parser.LID:
                        if (ret.m_parentModule.isValueDeclared(child.Text))
                            throw new SemanticErrorException(child.Text + " has alrady been imported. Line: " + child.Line);
                        ret.m_importedVariables.Add(child.Text);
                        break;
                    default:
                        throw new Exception("Unkown child: " + child.Text + " for node: " + tree.Text);
                }
            }


            return ret;
        }
        public virtual void PrintAsn1(StreamWriterLevel o, int lev)
        {
        }

    }



    public partial class ValueAssigment
    {
        public string m_name;
        public Asn1Type m_type;
        public Asn1Value m_value;

        //^(VAL_ASSIG valuereference type value)
        static public ValueAssigment CreateFromAntlrAst(ITree tree)
        {
            ValueAssigment ret = new ValueAssigment();
            ret.m_name = tree.GetChild(0).Text;
            ret.m_type = Asn1Type.CreateFromAntlrAst(tree.GetChild(1));
            ret.m_value = Asn1Value.CreateFromAntlrAst(tree.GetChild(2));
            return ret;
        }
        

        public virtual void PrintAsn1(StreamWriterLevel o, int lev)
        {
            if (m_value.m_TypeID == Asn1Value.TypeID.UNRESOLVED)
            {
                Console.Error.WriteLine("Variable assigment '" + m_name + "' is still in UNDEFINED state. It will be ignored");
                return;
            }
            o.P(lev);
            o.Write(m_name + " ");
            m_type.PrintAsn1(o, 0);
            o.WriteLine(" ::= " + m_value.ToString());
            o.P(lev);
            o.Write("--PER:");
            if (m_type.isValueAllowed(m_value))
            {

                List<byte> PERBuffer = m_value.Encode2();
                foreach (byte b in PERBuffer)
                    o.Write(b.ToString("X2"));
            }
            else
            {
                o.Write("Invalid!!!");
            }
            o.WriteLine();
            o.WriteLine();

        }
        internal void PrintC(StreamWriterLevel c)
        {
            c.Write("{0} {1} = ", C.ID(m_type.Name), C.ID(m_name));
            m_value.PrintC(c, 0);
            c.WriteLine(";");
        }
    }

    public partial class TypeAssigment
    {
        public List<string> m_comments = new List<string>();
        public string m_name;
        public Asn1Type m_type;
        public bool m_createdThroughTabulization = false;

        //^(TYPE_ASSIG typereference type)
        static public TypeAssigment CreateFromAntlrAst(ITree tree)
        {

            TypeAssigment ret = new TypeAssigment();
            ret.m_name = tree.GetChild(0).Text;
            ret.m_type = Asn1Type.CreateFromAntlrAst(tree.GetChild(1));
            for (int i = 2; i < tree.ChildCount; i++)
            {
                string comment = tree.GetChild(i).Text.Replace("--@", "").Replace("\r", "").Replace("\n", "").Replace("--", "");
                ret.m_comments.Add(comment);
            }
            return ret;
        }

        public virtual void PrintAsn1(StreamWriterLevel o, int lev)
        {
            foreach (string line in m_comments)
            {
                o.P(1); o.Write("--"); o.WriteLine(line);
            }
            o.P(lev); o.Write(m_name + " ::= "); m_type.PrintAsn1(o, lev); o.WriteLine();
            o.WriteLine();
        }


        public void PrintHtml(StreamWriterLevel wr, int p)
        {
            wr.WriteLine("        <div style=\"width: 100%; float:left\" >");
            m_type.PrintHtml(m_type.PEREffectiveConstraint, wr, p, m_comments, this);
            wr.WriteLine("        </div>");
            wr.WriteLine("&nbsp;<br/>");
        }

        internal void PrintH(StreamWriterLevel h, string uniqueID)
        {
            //print type declaration
            h.WriteLine("/*");
            h.WriteLine("Definition of :{0}", m_name);
            h.WriteLine("*/");
            h.Write("typedef ");
            m_type.PrintHTypeDeclaration(m_type.PEREffectiveConstraint, h, uniqueID, "", 0);
            if (!(m_type is IA5StringType))
                h.WriteLine(" {0};", uniqueID);
            h.WriteLine();

            //print 
            h.WriteLine("#define {0}_REQUIRED_BYTES_FOR_ENCODING		{1}",uniqueID, m_type.MaxBytesInPER);
            h.WriteLine();
            m_type.PrintHConstraintConstant(h, uniqueID);
            h.WriteLine();
            string star = "";
            if (!(m_type is IA5StringType))
                star = "*";
            h.WriteLine("void {0}_Initialize({0}{1} pVal);", uniqueID,star);
            h.WriteLine("flag {0}_IsConstraintValid({0}{1} val, int* pErrCode);", uniqueID,star);
            h.WriteLine("flag {0}_Encode({0}{1} val, BitStream* pBitStrm, int* pErrCode, flag bCheckConstraints);", uniqueID, star);
            h.WriteLine("flag {0}_Decode({0}{1} val, BitStream* pBitStrm, int* pErrCode);",uniqueID, star);
            h.WriteLine();
            h.WriteLine();
        }

        internal bool DependsOnlyOn(List<TypeAssigment> values)
        {
            return m_type.DependsOnlyOn(values);
        }

        internal void PrintC(StreamWriterLevel c, string uniqueID)
        {
            string star = "";
            if (!(m_type is IA5StringType))
                star = "*";
            c.WriteLine();
            c.WriteLine("void {0}_Initialize({0}{1} pVal)", uniqueID,star);
            c.WriteLine("{");
            m_type.PrintCInitialize(m_type.PEREffectiveConstraint, null, c, uniqueID, "pVal", 1);
            c.WriteLine("}");
            c.WriteLine();

            m_type.PrintCIsConstraintValidAux(c);

            c.WriteLine();
            c.WriteLine("flag {0}_IsConstraintValid({0}{1} pVal, int* pErrCode)", uniqueID, star);
            c.WriteLine("{");
            c.P(1); c.WriteLine("flag ret;");
            m_type.PrintCIsConstraintValid(m_type.PEREffectiveConstraint, c, uniqueID, uniqueID, "pVal", 1);
            c.P(1); c.WriteLine("return TRUE;");
            c.WriteLine("}");
            c.WriteLine();

            c.WriteLine("flag {0}_Encode({0}{1} pVal, BitStream* pBitStrm, int* pErrCode, flag bCheckConstraints)", uniqueID, star);
            c.WriteLine("{");
            c.P(1); c.WriteLine("if (bCheckConstraints && !{0}_IsConstraintValid(pVal, pErrCode))", uniqueID);
            c.P(2); c.WriteLine("return FALSE;");
            

            m_type.PrintCEncode(m_type.PEREffectiveConstraint, c, uniqueID, "pVal", 1);
            c.P(1); c.WriteLine("return TRUE;");
            c.WriteLine("}");
            c.WriteLine();

            c.WriteLine("flag {0}_Decode({0}{1} pVal, BitStream* pBitStrm, int* pErrCode)", uniqueID, star);
            c.WriteLine("{");
            c.P(1); c.WriteLine("flag ret;");
            m_type.PrintCDecode(m_type.PEREffectiveConstraint, c, uniqueID, "pVal", 1);
            c.P(1); c.WriteLine("return TRUE;");
            c.WriteLine("}");
            c.WriteLine();
        }
    }

}
