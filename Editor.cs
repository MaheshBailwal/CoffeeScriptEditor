// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Editor.cs" company="">
//   
// </copyright>
// <summary>
//   The editor.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#region

using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

using EventPublisher;

#endregion

namespace CoffeeEditor
{
    /// <summary>
    /// The editor.
    /// </summary>
    public partial class Editor : Form
    {
        private const string notSavedSymbol = "*";
        private const string closeSymbol = " X";
        /// <summary>
        /// Initializes a new instance of the <see cref="Editor"/> class.
        /// </summary>
        public Editor()
        {
            InitializeComponent();
        }

        private void Editor_Load(object sender, System.EventArgs e)
        {
            SubScribeEvents();
        }

        private void SubScribeEvents()
        {
            EventContainer.SubscribeEvent(EventPublisher.Events.SaveLeftTextBoxChanges.ToString(), SaveLeftBoxText);
            EventContainer.SubscribeEvent(EventPublisher.Events.LeftTextBoxChanged.ToString(), LeftTextBoxChanged);
            EventContainer.SubscribeEvent(EventPublisher.Events.Complie.ToString(), Compile);
        }

        private void Compile(EventArg eventArg)
        {
            var slectedPage = tabControl1.TabPages[tabControl1.SelectedIndex];

            if (slectedPage != null)
            {
                var editorUserCon =
                    (WindowsFormsControlLibrary1.Editor)slectedPage.Controls[0];

                var compileEventArg = new EventArg(editorUserCon.Id,editorUserCon.LeftTextBoxText);
                EventContainer.PublishEvent(EventPublisher.Events.LeftTextBoxChanged.ToString(), compileEventArg);
            }
        }


        private void LeftTextBoxChanged(EventArg eventArg)
        {
            this.Invoke(new MethodInvoker(() => ffff(eventArg)));

        }

        private void ffff(EventArg eventArg)
        {
            if (!tabControl1.SelectedTab.Text.EndsWith(notSavedSymbol)
               && tabControl1.TabPages[tabControl1.SelectedIndex].Controls.Count > 0)
            {
                var editorUserCon =
                    (WindowsFormsControlLibrary1.Editor)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0];
                if (editorUserCon.Id == eventArg.EventId)
                {
                    tabControl1.SelectedTab.Text += notSavedSymbol;
                }
            }
        }

        private void tabPage1_Click(object sender, System.EventArgs e)
        {

        }

        public void OpenNewPage(string fileName, string leftText, string rightText)
        {
            var existingTab = this.GetTabByFileName(fileName);

            if (existingTab != null)
            {
                tabControl1.SelectTab(existingTab);
                return;
            }


            tabControl1.TabPages.Add(fileName);
            var tabPage2 = tabControl1.TabPages.OfType<TabPage>().Last();
            tabPage2.Tag = fileName;

            fileName = fileName + closeSymbol;
            tabPage2.Location = new System.Drawing.Point(4, 22);
            tabPage2.Name = fileName;
            tabPage2.Padding = new System.Windows.Forms.Padding(3);
            tabPage2.Size = new System.Drawing.Size(527, 238);
            tabPage2.TabIndex = 1;
            tabPage2.Text = fileName;
            tabPage2.UseVisualStyleBackColor = true;
            tabPage2.Dock = DockStyle.Fill;
            WindowsFormsControlLibrary1.Editor ed = new WindowsFormsControlLibrary1.Editor(leftText, rightText);
            ed.Dock = DockStyle.Fill;
            tabPage2.Controls.Add(ed);
            tabControl1.SelectTab(tabPage2);
        }


        private TabPage GetTabByFileName(string fileName)
        {
            foreach (var tab in tabControl1.TabPages)
            {
                var tab1 = (TabPage)tab;
                if (tab1.Tag.ToString().Equals(fileName, StringComparison.OrdinalIgnoreCase))
                {
                    return tab1;
                }
            }

            return null;
        }


        private void tabControl1_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < this.tabControl1.TabPages.Count; i++)
            {
                Rectangle r = tabControl1.GetTabRect(i);
                //Getting the position of the "x" mark.
                Rectangle closeButton = new Rectangle(r.Right - 15, r.Top + 4, 9, 7);
                if (closeButton.Contains(e.Location))
                {
                    this.tabControl1.TabPages.RemoveAt(i);
                    break;
                }
            }
        }

        private void SaveLeftBoxText(EventArg eventArg)
        {
            var selectedPage = tabControl1.TabPages[tabControl1.SelectedIndex];

            if (selectedPage != null)
            {
                SaveFile(selectedPage, eventArg.Arg.ToString());
            }
        }

        //Future use
        private void SaveAll(EventArg eventArg)
        {
            for (int i = 0; i < tabControl1.TabPages.Count; i++)
            {
                var page = tabControl1.TabPages[i];
                SaveFile(page, eventArg.Arg.ToString());
            }
        }

        private void SaveFile(TabPage page, string initDir)
        {
            string fileName = page.Tag.ToString();

            var editorUserCon = (WindowsFormsControlLibrary1.Editor)page.Controls[0];

            if (!Path.IsPathRooted(fileName))
            {
                var saveFileDialog = new SaveFileDialog();
                saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                saveFileDialog.InitialDirectory = initDir;
                saveFileDialog.Filter = "Coffee Files (*.coffee)|*.coffee";
                if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    fileName = saveFileDialog.FileName;
                }
                else
                {
                    return;
                }

            }

            if (!string.IsNullOrEmpty(fileName))
            {
                File.WriteAllText(fileName, editorUserCon.LeftTextBoxText);
            }

            File.WriteAllText(fileName.Replace(".coffee", ".js"), editorUserCon.RightTextBoxText);
            page.Tag = fileName;
            page.Text = fileName + closeSymbol;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}