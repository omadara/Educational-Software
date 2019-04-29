using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Educational_Software
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Util.fixEmulatedIEVersion();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string filePath = Path.GetFullPath(@"..\..\course\" + e.Node.FullPath);
            if (e.Node.Parent == null) filePath += "\\" + e.Node.FullPath;
            webBrowser1.Navigate("file://" + filePath + ".html");
        }
    }
}
