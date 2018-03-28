namespace Altkom.CTI.CSharp.WinFormsClient
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
            this.bDownload = new System.Windows.Forms.Button();
            this.tURL = new System.Windows.Forms.TextBox();
            this.tResult = new System.Windows.Forms.TextBox();
            this.lURL = new System.Windows.Forms.Label();
            this.bCalculate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bDownload
            // 
            this.bDownload.Location = new System.Drawing.Point(335, 54);
            this.bDownload.Name = "bDownload";
            this.bDownload.Size = new System.Drawing.Size(149, 47);
            this.bDownload.TabIndex = 0;
            this.bDownload.Text = "Download";
            this.bDownload.UseVisualStyleBackColor = true;
            this.bDownload.Click += new System.EventHandler(this.bDownload_Click);
            // 
            // tURL
            // 
            this.tURL.Location = new System.Drawing.Point(12, 28);
            this.tURL.Name = "tURL";
            this.tURL.Size = new System.Drawing.Size(472, 20);
            this.tURL.TabIndex = 1;
            this.tURL.Text = "http://www.cti.org.pl";
            // 
            // tResult
            // 
            this.tResult.Location = new System.Drawing.Point(12, 107);
            this.tResult.Multiline = true;
            this.tResult.Name = "tResult";
            this.tResult.ReadOnly = true;
            this.tResult.Size = new System.Drawing.Size(472, 291);
            this.tResult.TabIndex = 2;
            // 
            // lURL
            // 
            this.lURL.AutoSize = true;
            this.lURL.Location = new System.Drawing.Point(9, 12);
            this.lURL.Name = "lURL";
            this.lURL.Size = new System.Drawing.Size(70, 13);
            this.lURL.TabIndex = 3;
            this.lURL.Text = "Address URL";
            // 
            // bCalculate
            // 
            this.bCalculate.Location = new System.Drawing.Point(12, 54);
            this.bCalculate.Name = "bCalculate";
            this.bCalculate.Size = new System.Drawing.Size(134, 47);
            this.bCalculate.TabIndex = 4;
            this.bCalculate.Text = "Calculate";
            this.bCalculate.UseVisualStyleBackColor = true;
            this.bCalculate.Click += new System.EventHandler(this.bCalculate_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 415);
            this.Controls.Add(this.bCalculate);
            this.Controls.Add(this.lURL);
            this.Controls.Add(this.tResult);
            this.Controls.Add(this.tURL);
            this.Controls.Add(this.bDownload);
            this.Name = "Form1";
            this.Text = "FrmDownloader";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bDownload;
        private System.Windows.Forms.TextBox tURL;
        private System.Windows.Forms.TextBox tResult;
        private System.Windows.Forms.Label lURL;
        private System.Windows.Forms.Button bCalculate;
    }
}

