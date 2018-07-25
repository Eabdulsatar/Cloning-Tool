using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CloningTool
{
    public partial class CheckSumWin : Form
    {
        CloningTool cloningTool = new CloningTool();
        public CheckSumWin()
        {
            InitializeComponent();
            version.Text = "Version " + cloningTool.Version;

        }
        private void Browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            string hashCode = "";
            DialogResult result = openFileDialog.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog.FileName;
                try
                {
                    CheckSumTools checkSumTool = new CheckSumTools(file);
                    string text = File.ReadAllText(file);
                    hashCode = checkSumTool.CheckSum_From_File(file);
                }
                catch (IOException)
                {
                }
                textBox1.Text = hashCode;
            }
        }
    }
}
