using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TAP_0311_DNA;
using System.Xml;

namespace Tap2XML_DNA_Win
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnToXml_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "All files (*.*)|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                SaveFileDialog svDlg = new SaveFileDialog();
                svDlg.Filter = "XML files (*.xml)|*.xml";
                svDlg.FileName = dlg.FileName + ".xml";
                
                if (svDlg.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        RootNode.ToXml(dlg.FileName, svDlg.FileName);
                        ShowMessageToStatusBar("Conversion succeeded");

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error file during conversion:\n\n" + ex.Message+"\n\n Call stack:\n\n" +ex.StackTrace, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }


        }

        private void btnToBer_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "XML files (*.xml)|*.xml";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                SaveFileDialog svDlg = new SaveFileDialog();
                svDlg.Filter = "All files (*.*)|*.*";

                if (dlg.FileName.EndsWith(".xml"))
                    svDlg.FileName = dlg.FileName.Substring(0, dlg.FileName.Length - 4);
                else
                    svDlg.FileName = dlg.FileName;

                if (svDlg.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        RootNode.ToBer(dlg.FileName, svDlg.FileName);
                        ShowMessageToStatusBar("Conversion succeeded");

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error file during conversion:\n\n" + ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        void ShowMessageToStatusBar(string message, params object[] args)
        {
            label.Text = string.Format(message, args);

            Timer timer = new Timer();

            timer.Interval = 2000;

            timer.Start();

            timer.Tick += new EventHandler(delegate(object sender, EventArgs e)
            {
                label.Text = "";
                timer.Stop();
                timer.Dispose();
            });

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 about = new AboutBox1();
            about.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
