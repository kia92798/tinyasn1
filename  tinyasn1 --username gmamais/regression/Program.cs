using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace regression
{
    class Program
    {
        static void Main(string[] args)
        {
            System.IO.StreamWriter log = new System.IO.StreamWriter("log.txt");
            string[] TestCases = System.IO.Directory.GetFiles(".\\", "*.asn1", SearchOption.AllDirectories);
            foreach (string file in TestCases)
            {
                string cmdLine = "-debug "+file;
                Console.WriteLine("C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\bin\\Debug\\tinyAsn1.exe " + cmdLine);
                Process proc = Process.Start("C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\bin\\Debug\\tinyAsn1.exe",
                    cmdLine);

                proc.WaitForExit();
                if (proc.ExitCode == 0)
                {
                    if (file.Contains("FAIL"))
                        log.WriteLine("No error report: {0}",file);
                } else if (proc.ExitCode == 1)
                    log.WriteLine("Parser error: {0}", file);
                else if (proc.ExitCode == 2)
                {
                    if (!file.Contains("FAIL"))
                        log.WriteLine("Semantic Error: {0}", file);
                } else if (proc.ExitCode == 3) {
                    log.WriteLine("BOOM: {0}", file);
                }
                log.Flush();
            }
            log.Close();
        }
    }
}
