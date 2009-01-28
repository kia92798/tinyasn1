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
            Application.Idle += new EventHandler(Application_Idle);
        }

        void Application_Idle(object sender, EventArgs e)
        {
            btConvert.Enabled = System.IO.File.Exists(txtSource.Text) && txtDest.Text.Trim().Length>0;
                
        }

        void ShowMessageToStatusBar(string message, params object[] args)
        {

            label.ForeColor = Color.DarkBlue;
            label.Text = string.Format(message, args);

            Timer timer = new Timer();



            timer.Interval = 2000;

            timer.Start();

            timer.Tick += new EventHandler(delegate(object sender, EventArgs e)
            {
                label.ForeColor = Color.Black;
                label.Text = "Ready";
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
        
        private void btnSource_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (rdToBer.Checked)
                dlg.Filter = "XML files (*.xml)|*.xml";
            else
                dlg.Filter = "All files (*.*)|*.*";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtSource.Text = dlg.FileName;
                txtDest.Text = getDestFile();
                
            }
        }

        private void btnDest_Click(object sender, EventArgs e)
        {

            SaveFileDialog dlg = new SaveFileDialog();
            dlg.CheckFileExists = false;

            if (rdToBer.Checked)
                dlg.Filter = "All files (*.*)|*.*";
            else
                dlg.Filter = "XML files (*.xml)|*.xml";

            dlg.FileName = getDestFile();


            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtDest.Text = dlg.FileName;
            }
        }

        string getDestFile()
        {
            if (rdToBer.Checked)
            {
                if (txtSource.Text.EndsWith(".xml"))
                    return txtSource.Text.Substring(0, txtSource.Text.Length - 4);
                else
                    return txtSource.Text;
            }
            else
            {
                return txtSource.Text + ".xml";
            }
        }

        private void btConvert_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(txtDest.Text))
            {
                if (MessageBox.Show("Output file exists and will be overwritten.\nDo you want to proceed?",
                    Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;
            }

            Cursor cur = Cursor;
            try
            {
                Cursor = Cursors.WaitCursor;
                if (rdToBer.Checked)
                    RootNode.ToBer(txtSource.Text, txtDest.Text);
                else
                    RootNode.ToXml(txtSource.Text, txtDest.Text);

                Cursor = cur;
                ShowMessageToStatusBar("Conversion succeeded");


            }
            catch (Exception ex)
            {
                Cursor = cur;
                MessageBox.Show("Error file during conversion:\n\n" + ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void rdToXml_CheckedChanged(object sender, EventArgs e)
        {
            txtSource.Text = "";
            txtDest.Text = "";
        }


    }
}
