using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using MediaProcessor.ServiceLibrary.Common;
using System.Threading.Tasks;

namespace CoffeeEditor
{
    public partial class Form1 : Form
    {
        string _filePath;
        bool reday = false;
        private readonly object objLock = new object();
        string coffeeText;
        string javaScriptText;
        public Form1(string filePath)
        {
            _filePath = filePath;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtCoffee.Text = File.ReadAllText(_filePath);
            reday = true;
        }

        private void txtJavaScript_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCoffee_TextChanged(object sender, EventArgs e)
        {
        }

        private void Complie()
        {
            try
            {
               javaScriptText =  ExeRunner.Execute(@"C:\Users\Owner\AppData\Roaming\npm\coffee.cmd", @"--compile --print " + _filePath);

                BeginInvoke((Action)(() =>  txtJavaScript.Text = javaScriptText ));
             //  BeginInvoke(new Delegate() => );
               // javaScriptText = ExeRunner.Execute(@"C:\Users\Owner\AppData\Roaming\npm\coffee.cmd", @"--eval --print " + "\"" + txtCoffee.Text + "\"");
            }
            catch(ExeExecutionException ex)
            {
                MessageBox.Show(ex.ToString());
               // Error err = new Error(ex.Message);
               // err.Show();
            }
        }



        private void txtJavaScript_TextChanged_1(object sender, EventArgs e)
        {
        
        }

        private void txtCoffee_TextChanged_1(object sender, EventArgs e)
        {
            if (!reday)
                return;

            if (!backgroundWorker1.IsBusy)
            {
                coffeeText = txtCoffee.Text;
                backgroundWorker1.RunWorkerAsync();
            }
        }


        private void OnSourceChanged()
        {
            lock (objLock)
            {

                try
                {
                    File.WriteAllText(_filePath, coffeeText);

                    Complie();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            OnSourceChanged();
        }
    }
}
