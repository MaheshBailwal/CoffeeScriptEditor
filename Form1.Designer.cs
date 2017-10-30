namespace CoffeeEditor
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtCoffee = new System.Windows.Forms.RichTextBox();
            this.txtJavaScript = new System.Windows.Forms.RichTextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.txtErrors = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtCoffee);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtJavaScript);
            this.splitContainer1.Size = new System.Drawing.Size(855, 290);
            this.splitContainer1.SplitterDistance = 447;
            this.splitContainer1.TabIndex = 0;
            // 
            // txtCoffee
            // 
            this.txtCoffee.AcceptsTab = true;
            this.txtCoffee.BackColor = System.Drawing.Color.Black;
            this.txtCoffee.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCoffee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCoffee.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCoffee.ForeColor = System.Drawing.Color.White;
            this.txtCoffee.Location = new System.Drawing.Point(0, 0);
            this.txtCoffee.Name = "txtCoffee";
            this.txtCoffee.Size = new System.Drawing.Size(445, 288);
            this.txtCoffee.TabIndex = 0;
            this.txtCoffee.Text = "";
            this.txtCoffee.TextChanged += new System.EventHandler(this.txtCoffee_TextChanged_1);
            this.txtCoffee.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCoffee_KeyDown);
            // 
            // txtJavaScript
            // 
            this.txtJavaScript.AcceptsTab = true;
            this.txtJavaScript.BackColor = System.Drawing.Color.Black;
            this.txtJavaScript.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtJavaScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtJavaScript.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJavaScript.ForeColor = System.Drawing.Color.White;
            this.txtJavaScript.Location = new System.Drawing.Point(0, 0);
            this.txtJavaScript.Name = "txtJavaScript";
            this.txtJavaScript.Size = new System.Drawing.Size(402, 288);
            this.txtJavaScript.TabIndex = 0;
            this.txtJavaScript.Text = "";
            this.txtJavaScript.TextChanged += new System.EventHandler(this.txtJavaScript_TextChanged_1);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.webBrowser1);
            this.splitContainer2.Panel2.Controls.Add(this.txtErrors);
            this.splitContainer2.Size = new System.Drawing.Size(855, 358);
            this.splitContainer2.SplitterDistance = 290;
            this.splitContainer2.TabIndex = 1;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(855, 64);
            this.webBrowser1.TabIndex = 1;
            this.webBrowser1.Visible = false;
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // txtErrors
            // 
            this.txtErrors.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtErrors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtErrors.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtErrors.ForeColor = System.Drawing.Color.DarkRed;
            this.txtErrors.Location = new System.Drawing.Point(0, 0);
            this.txtErrors.Name = "txtErrors";
            this.txtErrors.Size = new System.Drawing.Size(855, 64);
            this.txtErrors.TabIndex = 0;
            this.txtErrors.Text = "";
            this.txtErrors.DoubleClick += new System.EventHandler(this.txtErrors_DoubleClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 358);
            this.Controls.Add(this.splitContainer2);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox txtJavaScript;
        private System.Windows.Forms.RichTextBox txtCoffee;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.RichTextBox txtErrors;
        private System.Windows.Forms.WebBrowser webBrowser1;

    }
}

