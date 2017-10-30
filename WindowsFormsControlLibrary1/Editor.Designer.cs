namespace WindowsFormsControlLibrary1
{
    partial class Editor
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtRight = new System.Windows.Forms.RichTextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtLeft = new System.Windows.Forms.RichTextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.txtBotttom = new System.Windows.Forms.RichTextBox();
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
            // txtRight
            // 
            this.txtRight.AcceptsTab = true;
            this.txtRight.BackColor = System.Drawing.Color.Black;
            this.txtRight.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRight.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRight.ForeColor = System.Drawing.Color.White;
            this.txtRight.Location = new System.Drawing.Point(0, 0);
            this.txtRight.Name = "txtRight";
            this.txtRight.Size = new System.Drawing.Size(177, 181);
            this.txtRight.TabIndex = 0;
            this.txtRight.Text = "";
            this.txtRight.TextChanged += new System.EventHandler(this.txtRight_TextChanged);
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
            this.splitContainer1.Panel1.Controls.Add(this.txtLeft);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtRight);
            this.splitContainer1.Size = new System.Drawing.Size(383, 183);
            this.splitContainer1.SplitterDistance = 200;
            this.splitContainer1.TabIndex = 0;
            // 
            // txtLeft
            // 
            this.txtLeft.AcceptsTab = true;
            this.txtLeft.BackColor = System.Drawing.Color.Black;
            this.txtLeft.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLeft.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLeft.ForeColor = System.Drawing.Color.White;
            this.txtLeft.Location = new System.Drawing.Point(0, 0);
            this.txtLeft.Name = "txtLeft";
            this.txtLeft.Size = new System.Drawing.Size(198, 181);
            this.txtLeft.TabIndex = 0;
            this.txtLeft.Text = "";
            this.txtLeft.TextChanged += new System.EventHandler(this.txtLeft_TextChanged);
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
            this.splitContainer2.Panel2.Controls.Add(this.txtBotttom);
            this.splitContainer2.Size = new System.Drawing.Size(383, 226);
            this.splitContainer2.SplitterDistance = 183;
            this.splitContainer2.TabIndex = 2;
            // 
            // txtBotttom
            // 
            this.txtBotttom.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBotttom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBotttom.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBotttom.ForeColor = System.Drawing.Color.DarkRed;
            this.txtBotttom.Location = new System.Drawing.Point(0, 0);
            this.txtBotttom.Name = "txtBotttom";
            this.txtBotttom.Size = new System.Drawing.Size(383, 39);
            this.txtBotttom.TabIndex = 0;
            this.txtBotttom.Text = "";
            this.txtBotttom.TextChanged += new System.EventHandler(this.txtBotttom_TextChanged);
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer2);
            this.Name = "Editor";
            this.Size = new System.Drawing.Size(383, 226);
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

        private System.Windows.Forms.RichTextBox txtRight;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox txtLeft;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.RichTextBox txtBotttom;



    }
}
