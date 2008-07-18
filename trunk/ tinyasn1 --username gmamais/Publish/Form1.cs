using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ICSharpCode.SharpZipLib.Zip;
using System.IO;



public delegate TRes Func<TRes>();
public delegate TRes Func<TRes, T1>(T1 t);


namespace Publish
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void publishAsn1Scc_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            using (ZipOutputStream s = new ZipOutputStream(File.Create(rootPath.Text + "\\Publish\\asn1scc\\asn1scc_src.zip")))
            {
                ZipDir(s, rootPath.Text, rootPath.Text, false, fileSel, dirSel);
                s.Finish();
                s.Close();
            }


            using (ZipOutputStream s = new ZipOutputStream(File.Create(rootPath.Text + "\\Publish\\asn1scc\\asn1scc_binaries.zip")))
            {
                string setupFolder = rootPath.Text + @"\asn1scc_setup\Debug";
                ZipDir(s, setupFolder, setupFolder, false, delegate(string f) { return true; }, delegate(string f) { return true; });
                s.Finish();
                s.Close();
            }


            Cursor = Cursors.Default;
                        
        }
        

        bool fileSel(string file)
        {
            List<string> fls = new List<string>(new string[] { "asn1scc.sln", "csproj", "cs", "g", 
                "dll", "jar", "vcproj", "asn1scc_setup.vdproj", ".c", ".h", ".resx" });

            if (file.Contains(@".svn"))
                return false;

            foreach (string okfile in fls)
                if (file.EndsWith(okfile))
                    return true;
            
            if (file.Contains(@"tinyAsn1\tests"))
                return true;
            if (file.Contains(@"asn1cc.regression\tcs"))
                return true;
            if (file.Contains(@"asn1cc.regression\asn1cc\runAsn1cc.py"))
                return true;

            return false;
        }
        bool dirSel(string dir)
        {
            List<string> dirs = new List<string>(new string[] { "AntrlParser", "asn1cc", "asn1crt", "tinyAsn1",
                "asn1scc_setup", "antrl", "Properties", "Resources", "asn1cc.regression" });

            foreach (string okDir in dirs)
                if (dir.EndsWith(okDir))
                    return true;
            if (dir.Contains(@"tinyAsn1\tests"))
                return true;

            if (dir.Contains(@"asn1cc.regression\tcs"))
                return true;
            if (dir.Contains(@"asn1cc.regression\asn1cc"))
                return true;

            return false;
        }

        void ZipDir(ZipOutputStream zip, string rootDirName, string dirName, bool prefixPath,
            Func<bool, string> fileSelector, Func<bool, string> dirSelector)
        {
            zip.SetLevel(9); // 0-9, 9 being the highest compression

            byte[] buffer = new byte[4096];


            string[] filenames = Directory.GetFiles(dirName);

            foreach (string file in filenames)
            {

                if (!fileSelector(file))
                    continue;

                string fname = Path.GetFileName(file);
                if (prefixPath)
                {
                    fname = file.Replace(rootDirName, "");
                    if (fname.StartsWith("\\"))
                        fname = fname.Substring(1);
                }

                ZipEntry entry = new ZipEntry(fname);



                entry.DateTime = File.GetLastWriteTime(file);
                zip.PutNextEntry(entry);

                using (FileStream fs = File.OpenRead(file))
                {
                    int sourceBytes;
                    do
                    {
                        sourceBytes = fs.Read(buffer, 0,
                        buffer.Length);

                        zip.Write(buffer, 0, sourceBytes);

                    } while (sourceBytes > 0);
                }
            }

            foreach (string dir in Directory.GetDirectories(dirName))
                if (dirSelector(dir))
                    ZipDir(zip, rootDirName, dir, true, fileSelector, dirSelector);

        }


    }
}