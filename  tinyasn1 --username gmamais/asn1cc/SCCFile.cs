﻿using System;
using System.Collections.Generic;
using System.Text;
using tinyAsn1;
using System.IO;

namespace asn1scc
{
    class SCCFile :  Asn1File
    {
        private List<TypeAssigment> GetTypesWithNoDepends()
        {

            List<TypeAssigment> ret = new List<TypeAssigment>();
            List<TypeAssigment> tmp = new List<TypeAssigment>();
            List<string> retStr = new List<string>();

            foreach (Module m in m_modules)
            {
                foreach (ImportedModule imp in m.m_imports)
                    retStr.AddRange(imp.m_importedTypes);
                foreach (TypeAssigment t in m.m_typeAssigments.Values)
                    tmp.Add(t);
            }

            while (tmp.Count > 0)
            {
                int lenBefore = tmp.Count;
                foreach (Module m in m_modules)
                {
                    foreach (TypeAssigment t in m.m_typeAssigments.Values)
                    {
                        if (t.DependsOnlyOn(retStr) && !ret.Contains(t))
                        {
                            ret.Add(t);
                            tmp.Remove(t);
                            retStr.Add(t.m_name);
                        }
                    }
                }
                if (lenBefore == tmp.Count)
                {
                    string err = string.Empty;
                    foreach (TypeAssigment t in tmp)
                        err += t.m_name + " ";

                    throw new SemanticErrorException("Error: Asn1 grammar has cyclic dependencies: " + err);
                }
            }

            return ret;
        }


        public void printC()
        {
            string path = Asn1CompilerInvokation.m_outDirectory;
            string fileName = Path.GetFileNameWithoutExtension(m_fileName);
            if (path != "" && !path.EndsWith(Path.DirectorySeparatorChar.ToString()))
                path += Path.DirectorySeparatorChar;

            using (StreamWriterLevel c = new StreamWriterLevel(path + fileName + ".c"))
            using (StreamWriterLevel h = new StreamWriterLevel(path + fileName + ".h"))
            {
                h.WriteLine("#ifndef _INC_{0}_H", C.ID(fileName).ToUpper());
                h.WriteLine("#define _INC_{0}_H", C.ID(fileName).ToUpper());
                h.WriteLine("/*");
                h.WriteLine("Code automatically generated by asn1cc tool");
                h.WriteLine("*/");
                h.WriteLine();


                foreach (Module m in m_modules)
                {
                    foreach (ImportedModule imp in m.m_imports)
                    {
                        Asn1File incf = null;
                        foreach (Asn1File f in Asn1CompilerInvokation.Instance.m_files)
                            foreach (Module exp in f.m_modules)
                                if (exp.m_moduleID == imp.m_moduleID)
                                    incf = f;
                        h.WriteLine("#include \"{0}.h\"", Path.GetFileNameWithoutExtension(incf.m_fileName));
                    }
                }


                h.WriteLine("#include \"asn1crt.h\"");
                h.WriteLine();
                h.WriteLine("#ifdef  __cplusplus");
                h.WriteLine("extern \"C\" {");
                h.WriteLine("#endif");
                h.WriteLine();
                List<TypeAssigment> tmp = GetTypesWithNoDepends();

                foreach (SCCTypeAssigment t in tmp)
                {
                    string uniqueID = Asn1CompilerInvokation.Instance.TypePrefix + Asn1CompilerInvokation.Instance.GetUniqueID(C.ID(t.m_name));
                    t.PrintH(h, uniqueID);
                }

                c.WriteLine();
                foreach (Module m in m_modules)
                    foreach (SCCValueAssigment v in m.m_valuesAssigments.Values)
                        v.PrintExternDeclaration(h);


                h.WriteLine("#ifdef  __cplusplus");
                h.WriteLine("}");
                h.WriteLine("#endif");
                h.WriteLine();

                h.WriteLine("#endif");


                c.WriteLine("/*");
                c.WriteLine("Code automatically generated by asn1cc tool");
                c.WriteLine("*/");

                c.WriteLine("#include <string.h>");
                //                c.WriteLine("#include <assert.h>");


                c.WriteLine("#include \"{0}\"", fileName + ".h");
                foreach (SCCTypeAssigment t in tmp)
                {
                    string uniqueID = Asn1CompilerInvokation.Instance.TypePrefix + Asn1CompilerInvokation.Instance.GetUniqueID(C.ID(t.m_name));
                    t.PrintC(c, uniqueID);
                }

                c.WriteLine();
                foreach (Module m in m_modules)
                    foreach (SCCValueAssigment v in m.m_valuesAssigments.Values)
                        v.PrintC(c);

            }
        }

    }





}