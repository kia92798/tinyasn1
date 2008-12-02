using System;
using System.Collections.Generic;
using System.Text;
using tinyAsn1;
using System.IO;



namespace asn1csharp
{

    using MyInt = System.Int32;
    using semantix.util;


    class CSharpFile : Asn1File
    {
        public void printCode()
        {
            string path = DefaultBackend.m_outDirectory;
            string fileName = Path.GetFileNameWithoutExtension(m_fileName);
            if (path != "" && !path.EndsWith(Path.DirectorySeparatorChar.ToString()))
                path += Path.DirectorySeparatorChar;

            using (StreamWriterLevel csFile = new StreamWriterLevel(path + fileName + ".cs"))
            {
                csFile.WriteLine("using System;");
                csFile.WriteLine("using System.Collections.Generic;");
                csFile.WriteLine("using System.Text;");
                csFile.WriteLine("using System.IO;");
                csFile.WriteLine("using CSharpAsn1CRT;");
                foreach (CSharpModule m in m_modules)
                    m.printCode(csFile);

            }
        }
    }





    class CSharpModule : Module
    {
        public string NameSpace
        {
            get { return C.ID(m_moduleID); }
        }
        
        public void printCode(StreamWriterLevel csFile)
        {
            csFile.WriteLine();

            foreach (ImportedModule im in m_imports)
                csFile.WriteLine("using {0};",C.ID(im.m_moduleID));
            csFile.WriteLine("namespace {0}", NameSpace);
            csFile.WriteLine("{");
            csFile.WriteLine();
            foreach (TypeAssigment tas in m_typeAssigments.Values)
            {
                ICSharpType csType = tas.m_type as ICSharpType;
                csType.DeclareType(csFile, C.ID(tas.m_name), 1);
                csFile.WriteLine();
            }

            csFile.WriteLine("}");


        }
    }


}


