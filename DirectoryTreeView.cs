using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using EventPublisher;

namespace CoffeeEditor
{
    public partial class DirectoryTreeView : Form
    {
        private string _folder;

        private ContextMenu contextMenu;

        public DirectoryTreeView()
        {
            InitializeComponent();
        }

        public Action<string> OpenFile;

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void DirectoryTreeView_Load(object sender, EventArgs e)
        {
            contextMenu = new ContextMenu();
            contextMenu.MenuItems.Add("Set Start Page", new EventHandler(SetStartPage));
         
      
        }

        private void SetStartPage(object sender, EventArgs e)
        {
            EventPublisher.EventContainer.PublishEvent(EventPublisher.Events.Complie.ToString(), new EventArg(Guid.Empty,treeView1.SelectedNode.Tag)); 
        }

        public void ShowFolder(string folder)
        {
            treeView1.Nodes.Clear();
            TreeNode rootnode = new TreeNode(folder);
            rootnode.Tag = "dir";
            treeView1.Nodes.Add(rootnode);
            FillChildNodes(rootnode);
            treeView1.Nodes[0].Expand();
            _folder = folder;
        }


        void FillChildNodes(TreeNode node)
        {
            try
            {
                if ((string)node.Tag != "dir")
                    return;

                foreach (var dir in Directory.GetDirectories(node.FullPath))
                {
                    var dirInfo = new DirectoryInfo(dir).Name;
                    var newnode = new TreeNode(dirInfo);
                    node.Nodes.Add(newnode);
                    newnode.Tag = "dir";
                    newnode.Nodes.Add("*");
                }

                var files = Directory.GetFiles(node.FullPath);
                var orderedFiles = files.OrderBy(p => Path.GetExtension(p));

                foreach (var file in orderedFiles)
                {

                    var ext = Path.GetExtension(file);

                    if (!imageList1.Images.ContainsKey(ext))
                    {
                        Icon result = Icon.ExtractAssociatedIcon(file);
                        imageList1.Images.Add(ext, result);
                    }
                    var imageIndex = imageList1.Images.IndexOfKey(ext);


                    var newnode = new TreeNode(Path.GetFileName(file), imageIndex, imageIndex);
                    node.Expand();
                    node.Nodes.Add(newnode);
                    newnode.Tag = "file";

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Nodes[0].Text == "*")
            {
                e.Node.Nodes.Clear();
                FillChildNodes(e.Node);
            }
        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode.Tag == "file")
            {
                if (OpenFile != null)
                {
                    OpenFile(treeView1.SelectedNode.FullPath);
                }
            }
        }

        private void treeView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                ShowFolder(_folder);
            }
        }

        private void treeView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Select the clicked node
                treeView1.SelectedNode = treeView1.GetNodeAt(e.X, e.Y);

                if (treeView1.SelectedNode != null)
                {
                    contextMenu.Show(treeView1, e.Location);
                }
            }
        }
    }
}
