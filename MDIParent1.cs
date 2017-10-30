// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MDIParent1.cs" company="">
//   
// </copyright>
// <summary>
//   The mdi parent 1.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#region

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

using EventPublisher;

using Microsoft.Win32;

#endregion

namespace CoffeeEditor
{
    /// <summary>
    /// The mdi parent 1.
    /// </summary>
    public partial class MDIParent1 : Form
    {

        private string _openedFileName;
        private int childFormNumber;
        private Editor _editor;
        private DirectoryTreeView directoryTreeView;
        string tempFileName = Path.Combine(Path.GetTempPath(), "CoffeEditor.menu");
        string tempRecentFoldersFileName = Path.Combine(Path.GetTempPath(), "RecentFolders.menu");

        private string startPage = string.Empty;
        private Process webServerProcess;
        ICompiler compiler = new CoffeCompiler();
        /// <summary>
        /// Initializes a new instance of the <see cref="MDIParent1"/> class.
        /// </summary>
        public MDIParent1()
        {
            InitializeComponent();
            SubScribeEvents();
            AppDomain.CurrentDomain.ProcessExit += CurrentDomain_ProcessExit;
        }

        void CurrentDomain_ProcessExit(object sender, EventArgs e)
        {

            if (webServerProcess != null && webServerProcess.HasExited)
            {
                return;
            }

            if (webServerProcess != null && webServerProcess.Responding)
            {
                webServerProcess.Kill();
            }

        }

        private void OnNewClick(object sender, EventArgs e)
        {
            _openedFileName = string.Empty;
            this.NewFile();

        }


        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = @"D:\Git\MediaValetWebUI\src\fe\core\scripts";
            openFileDialog.Filter = "Text Files (*.coffee)|*.coffee|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
                OpenFile(FileName);
            }
        }

        private void MDIParent1_Load(object sender, EventArgs e)
        {
            LastOpenFolder();
            NewFile();
            ShowRecentFolder();
        }

        private void NewFile()
        {
            if (_editor == null || !_editor.Visible)
            {
                _editor = new Editor();
                _editor.MdiParent = this;
                _editor.Show();

            }
            _editor.OpenNewPage("New file", "", "");

            OnResize();

        }

        private void LastOpenFolder()
        {
            if (File.Exists(tempFileName))
            {
                this.ShowTreeview(File.ReadAllText(tempFileName));
            }
        }

        private void OpenFile(string filePath)
        {

            if (Path.GetExtension(filePath) != ".coffee")
            {
                OpenOtherFiles(filePath);
                return;
            }

            if (_editor == null || !_editor.Visible)
            {
                _editor = new Editor();
                _editor.MdiParent = this;
                _editor.Show();

            }

            _editor.OpenNewPage(filePath, File.ReadAllText(filePath), "");
            this.OnResize();
            _openedFileName = filePath;
        }

        private void OpenOtherFiles(string filePath)
        {
            Process.Start("devenv.exe", "/edit " + filePath);
        }


        private void toolStripButtonRun_Click(object sender, EventArgs e)
        {

            try
            {

                if (webServerProcess != null && webServerProcess.Responding)
                {
                    MessageBox.Show("Web server alreday runnning");
                    return;
                }
            }
            catch (InvalidOperationException)
            {
            }

            if (File.Exists(tempFileName))
            {
                var exePath = System.Configuration.ConfigurationManager.AppSettings["WebServerExepath"];
                ProcessStartInfo info = new ProcessStartInfo();
                info.Arguments = File.ReadAllText(tempFileName);
                info.FileName = exePath;
                webServerProcess = new Process();
                webServerProcess.StartInfo = info;
                webServerProcess.Start();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void SaveFile()
        {
            EventPublisher.EventContainer.PublishEvent(
             EventPublisher.Events.SaveLeftTextBoxChanges.ToString(),
             new EventArg(Guid.Empty, File.ReadAllText(tempFileName)));

        }

        private void openFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFolder();
        }

        private void OpenFolder()
        {
            startPage = string.Empty;

            if (File.Exists(tempFileName))
            {
                folderBrowserDialog1.SelectedPath = File.ReadAllText(tempFileName);
            }

            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.ShowTreeview(folderBrowserDialog1.SelectedPath);
                this.SaveRecentFolders(folderBrowserDialog1.SelectedPath);
                ShowRecentFolder();
            }

        }

        private void ShowTreeview(string dir)
        {
            if (directoryTreeView == null || !directoryTreeView.Visible)
            {
                directoryTreeView = new DirectoryTreeView();
                directoryTreeView.OpenFile = this.OpenFile;
            }

            directoryTreeView.ShowFolder(dir);
            directoryTreeView.MdiParent = this;
            directoryTreeView.Show();

            this.OnResize();

            File.WriteAllText(tempFileName, dir);
        }

        private void OnResize()
        {
            if (directoryTreeView != null && directoryTreeView.Visible && _editor != null && _editor.Visible)
            {
                directoryTreeView.WindowState = FormWindowState.Normal;
                directoryTreeView.Location = new Point(0, 0);
                directoryTreeView.Height = directoryTreeView.Parent.Height - 20;
                _editor.WindowState = FormWindowState.Normal;
                _editor.Location = new Point(directoryTreeView.Width, 0);
                _editor.Width = (_editor.ParentForm.Width - directoryTreeView.Width) - 20;
                _editor.Height = _editor.Parent.Height - 20;
            }
        }

        private void MDIParent1_Resize(object sender, EventArgs e)
        {
            this.OnResize();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            this.SaveFile();
        }

        private void openToolStripButton_Click_1(object sender, EventArgs e)
        {
            this.OpenFolder();
        }

        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            EventPublisher.EventContainer.PublishEvent(EventPublisher.Events.Complie.ToString(), null);
        }

        private void SubScribeEvents()
        {
            EventContainer.SubscribeEvent(EventPublisher.Events.LeftTextBoxChanged.ToString(), CoffeTextChanged);
            EventContainer.SubscribeEvent(EventPublisher.Events.SetStartPage.ToString(), CoffeTextChanged);
        }


        private void SetStartPage(EventArg eventArg)
        {
            _leftTextBoxChangedEventArg = eventArg;

            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }


        #region complie

        private EventArg _leftTextBoxChangedEventArg;
        private readonly object objLock = new object();


        private void CoffeTextChanged(EventArg eventArg)
        {
            _leftTextBoxChangedEventArg = eventArg;

            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void Complie()
        {
            var eventArg = new EventArg(_leftTextBoxChangedEventArg.EventId, _leftTextBoxChangedEventArg.Arg);
            try
            {
                var javaScript = compiler.Complie(eventArg.Arg.ToString());
                var arg = new EventArg(eventArg.EventId, javaScript);
                EventPublisher.EventContainer.PublishEvent(EventPublisher.Events.SetRightTextBoxText.ToString(), arg);

                var clearErrorArg = new EventArg(eventArg.EventId, "");
                EventPublisher.EventContainer.PublishEvent(EventPublisher.Events.SetBottomTextBoxText.ToString(), clearErrorArg);
            }
            catch (CompileException ex)
            {
                var arg = new EventArg(eventArg.EventId, ex.ExeErrorMessage);
                EventPublisher.EventContainer.PublishEvent(EventPublisher.Events.SetBottomTextBoxText.ToString(), arg);
            }

        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            lock (objLock)
            {
                try
                {
                    Complie();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        #endregion

        private void recentFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var subItem = new System.Windows.Forms.ToolStripMenuItem();
            subItem.Text = "Recefdfd";
            this.recentFolderToolStripMenuItem.DropDownItems.Add(subItem);

        }

        private void ShowRecentFolder()
        {
            this.recentFolderToolStripMenuItem.DropDownItems.Clear();

            if (File.Exists(tempRecentFoldersFileName))
            {
                var lines = File.ReadAllLines(tempRecentFoldersFileName);
                foreach (var line in lines)
                {
                    var recentFolderSubMenuItem = new System.Windows.Forms.ToolStripMenuItem();
                    recentFolderSubMenuItem.Text = line;
                    this.recentFolderToolStripMenuItem.DropDownItems.Add(recentFolderSubMenuItem);
                    recentFolderSubMenuItem.Click += newFolderToolStripMenuItem_Click;
                }
            }
        }

        private void newFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var toolStripMenuItem = (ToolStripMenuItem)sender;
            this.ShowTreeview(toolStripMenuItem.Text);
        }

        private void SaveRecentFolders(string folder)
        {
            var lines = new List<string>();

            if (File.Exists(tempRecentFoldersFileName))
            {
                var fileLines = File.ReadAllLines(tempRecentFoldersFileName);

                if (!fileLines.Any(x => x.Equals(folder, StringComparison.OrdinalIgnoreCase)))
                {
                    lines.Add(folder);
                }

                lines.AddRange(fileLines);
            }

            File.WriteAllLines(tempRecentFoldersFileName, lines);
        }

        private void buildProject_Click(object sender, EventArgs e)
        {
            try
            {

                Cursor.Current = Cursors.WaitCursor;

                if (File.Exists(tempFileName))
                {
                    var dir = File.ReadAllText(tempFileName);

                    var files = Directory.GetFiles(dir, "*.coffee", SearchOption.AllDirectories);
             
                    Parallel.ForEach(
                        files,
                        (file) =>
                        {
                            var javaScript = compiler.Complie(File.ReadAllText(file));
                            var jsFile = file.Replace(".coffee", ".js");
                            File.WriteAllText(jsFile, javaScript);

                        });

                    MessageBox.Show("Done");
                }
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
    }

}