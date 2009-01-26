using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Tap2XML_DNA_Win
{
    public partial class MyMessageBox : Form
    {
        public MyMessageBox()
        {
            InitializeComponent();
        }

        public static void ShowDlg(Exception ex)
        {
            MyMessageBox dlg = new MyMessageBox();
            dlg.Text = Application.ProductName;

        }
    }
}
