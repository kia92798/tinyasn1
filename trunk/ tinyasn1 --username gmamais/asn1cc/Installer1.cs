using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;

namespace asn1scc
{
    [RunInstaller(true)]
    public partial class Installer1 : Installer
    {
        public Installer1()
        {
            InitializeComponent();
        }

        public override void Install(System.Collections.IDictionary stateSaver)
        {
            base.Install(stateSaver);
            stateSaver.Add("TargetDir", Context.Parameters["DP_TargetDir"].ToString());
        }

        public override void Commit(System.Collections.IDictionary savedState)
        {
            base.Commit(savedState);
            string outDir = savedState["TargetDir"].ToString();
            string path = System.Environment.GetEnvironmentVariable("Path",EnvironmentVariableTarget.Machine);

            if (!path.Contains(outDir))
            {
                if (!path.EndsWith(";"))
                    path+=";";  
                path += outDir;
                System.Environment.SetEnvironmentVariable("Path", path, EnvironmentVariableTarget.Machine);
            }
        }

        public override void Uninstall(System.Collections.IDictionary savedState)
        {
            base.Uninstall(savedState);
            string outDir = savedState["TargetDir"].ToString();

            string path = System.Environment.GetEnvironmentVariable("Path", EnvironmentVariableTarget.Machine);
            if (path.Contains(outDir))
            {
                if (path.Contains(";" + outDir))
                    outDir = ";" + outDir;
                path = path.Replace(outDir, "");
                System.Environment.SetEnvironmentVariable("Path", path, EnvironmentVariableTarget.Machine);
            }
        }
    }
}