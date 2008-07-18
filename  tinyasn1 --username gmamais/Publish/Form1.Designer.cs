namespace Publish
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rootPath = new System.Windows.Forms.TextBox();
            this.publishAsn1Scc = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // rootPath
            // 
            this.rootPath.Location = new System.Drawing.Point(15, 25);
            this.rootPath.Name = "rootPath";
            this.rootPath.Size = new System.Drawing.Size(348, 20);
            this.rootPath.TabIndex = 0;
            this.rootPath.Text = "C:\\prj\\DataModeling\\tinyAsn1";
            // 
            // publishAsn1Scc
            // 
            this.publishAsn1Scc.Location = new System.Drawing.Point(12, 316);
            this.publishAsn1Scc.Name = "publishAsn1Scc";
            this.publishAsn1Scc.Size = new System.Drawing.Size(103, 23);
            this.publishAsn1Scc.TabIndex = 1;
            this.publishAsn1Scc.Text = "Publish Asn1scc";
            this.publishAsn1Scc.UseVisualStyleBackColor = true;
            this.publishAsn1Scc.Click += new System.EventHandler(this.publishAsn1Scc_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Root path";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Asn1scc Version";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(15, 69);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 351);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.publishAsn1Scc);
            this.Controls.Add(this.rootPath);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox rootPath;
        private System.Windows.Forms.Button publishAsn1Scc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
    }
}

