// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Form1.cs" company="">
//   
// </copyright>
// <summary>
//   The form 1.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#region

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;



#endregion

namespace CoffeeEditor
{
    /// <summary>
    /// The form 1.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// The _file text.
        /// </summary>
        private  string _fileText;

        /// <summary>
        /// The obj lock.
        /// </summary>
        private readonly object objLock = new object();

        /// <summary>
        /// The coffee text.
        /// </summary>
        public string CoffeeText;

        /// <summary>
        /// The java script text.
        /// </summary>
        public string JavaScriptText;

        /// <summary>
        /// The reday.
        /// </summary>
        private bool reday;

        /// <summary>
        /// The temp file.
        /// </summary>
        private string tempFile;

        /// <summary>
        /// The undo list.
        /// </summary>
        private Stack<string> undoList = new Stack<string>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        /// <param name="fileText">
        /// The file text.
        /// </param>
        public Form1(string fileText)
        {
            _fileText = fileText;
            InitializeComponent();
        }

        /// <summary>
        /// The form 1_ load.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void Form1_Load(object sender, EventArgs e)
        {
            //txtCoffee.Text = _fileText;
            //tempFile = Path.Combine(Directory.GetCurrentDirectory(), "temp.coffee");
            //reday = true;
            //txtCoffee_TextChanged_1(null, null);
            this.Reset(_fileText);
        }

        public void SetTitle(string title)
        {
            this.Text = title;
        }

        public void Reset(string fileText)
        {
            reday = false;
            _fileText = fileText;
            txtCoffee.Text = _fileText;
            tempFile = Path.Combine(Directory.GetCurrentDirectory(), "temp.coffee");
            reday = true;
            txtCoffee_TextChanged_1(null, null);
        }

        /// <summary>
        /// The txt java script_ text changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void txtJavaScript_TextChanged(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// The txt coffee_ text changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void txtCoffee_TextChanged(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// The complie.
        /// </summary>
        private void Complie()
        {
            try
            {
                JavaScriptText = ExeRunner.Execute(Helper.GetCoffeePath(), @"--compile --print " + tempFile);

                BeginInvoke((Action)(() => txtJavaScript.Text = JavaScriptText));
                BeginInvoke((Action)(() => txtErrors.Text = string.Empty));
            }
            catch (CompileException ex)
            {
                BeginInvoke((Action)(() => txtErrors.Text = ex.ExeErrorMessage));
            }
        }

        /// <summary>
        /// The execute java script.
        /// </summary>
        public void ExecuteJavaScript()
        {
            string javaScript = txtJavaScript.Text;
            string html = "<html><body></body><script>@script</script></html>";
            html = html.Replace("@script", javaScript);
            File.WriteAllText("sample.htm", html);
            var dir = Directory.GetCurrentDirectory();
            webBrowser1.Navigate(Path.Combine(dir, "sample.htm"));
        }

        /// <summary>
        /// The txt coffee_ text changed_1.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void txtCoffee_TextChanged_1(object sender, EventArgs e)
        {
            if (!reday)
            {
                return;
            }

            if (!this.Text.EndsWith(" *"))
            {
                this.Text += " *";
            }

            // undoList.Push(txtCoffee.Text);
            if (!backgroundWorker1.IsBusy)
            {
                CoffeeText = txtCoffee.Text;
                backgroundWorker1.RunWorkerAsync();
            }

        }

        /// <summary>
        /// The on source changed.
        /// </summary>
        public void OnSourceChanged()
        {
            lock (objLock)
            {
                try
                {
                    File.WriteAllText(tempFile, CoffeeText);

                    Complie();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        /// <summary>
        /// The background worker 1_ do work.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            OnSourceChanged();
        }

        /// <summary>
        /// The txt coffee_ key down.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void txtCoffee_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Z)
            {
                if (txtCoffee.CanUndo)
                {
                    txtCoffee.Undo();
                }
            }

            if (e.Control && e.KeyCode == Keys.Y)
            {
                if (txtCoffee.CanRedo)
                {
                    txtCoffee.Redo();
                }
            }

            if (e.Control && e.KeyCode == Keys.Down)
            {
                txtCoffee_TextChanged_1(null, null);
            }
        }

        /// <summary>
        /// The txt errors_ double click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void txtErrors_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                var lineNumber = int.Parse(txtErrors.SelectedText);
                lineNumber = lineNumber - 1;
                var index = txtCoffee.GetFirstCharIndexFromLine(lineNumber);
                txtCoffee.SelectionStart = index;

                // txtCoffee.CaretP
                ////txtCoffee.SelectAll();
                // txtCoffee.SelectionBackColor = Color.BlueViolet;
                txtCoffee.Focus();
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// The form 1_ key down.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.R)
            {
                ExecuteJavaScript();
            }
        }

        public void FileSaved()
        {
            if (this.Text.EndsWith(" *"))
            {
               this.Text = this.Text.Replace(" *", "");
            }
        }


        private void txtJavaScript_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }
}