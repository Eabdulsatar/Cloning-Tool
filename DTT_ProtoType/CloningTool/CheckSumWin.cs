using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;


namespace CloningTool
{
    public partial class CheckSumWin : Form
    {
        CloningTool cloningTool;

        public CheckSumWin(CloningTool parent)
        {
            InitializeComponent();
            this.cloningTool = parent;
            version.Text = "Version " + cloningTool.Version;
            AddingSwPackageTable();
            AddingToValidHashTable();
        }

        private void SwSaveBtn_Click(object sender, EventArgs e)
        {
            String strDestinationFile = cloningTool.SwPackages;

            SavingData(SoftwarePackageTable, strDestinationFile);
        }
        
        private void SaveHashBtn_Click(object sender, EventArgs e)
        {
            SavingData(ValidHashTable, cloningTool.HashesFile);
        }

        private bool EmptyCell(DataGridView dataGridView)
        {
            bool temp = false;
            for (int x = 0; x < dataGridView.Rows.Count - 1; x++)
            {
                for (int y = 0; y < dataGridView.Columns.Count; y++)
                {
                    if (Convert.ToString(dataGridView.Rows[x].Cells[y].Value) == string.Empty)
                    {
                        temp = true;
                        return temp;
                    }   
                }
            }
            return temp;
        }

        private void SavingData (DataGridView dataGridView, string file)
        {
            if (!EmptyCell(dataGridView))
            {
                TextWriter tw = new StreamWriter(file);
                //writing the data

                for (int x = 0; x < dataGridView.Rows.Count - 1; x++)
                {
                    for (int y = 0; y < dataGridView.Columns.Count; y++)
                    {
                        tw.Write(dataGridView.Rows[x].Cells[y].Value);
                        if (y != dataGridView.Columns.Count - 1)
                        {
                            tw.Write("\t");
                        }

                    }
                    tw.WriteLine();

                }
                tw.Close();
            }
            else
                MessageBox.Show("Please refill the empty cell", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BrowseHashBtn_Click(object sender, EventArgs e)
        {
            Browsing(ValidHashTable);
        }
        
        private void Browsing (DataGridView dataGridView)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            int i = 0;
            DialogResult result = openFileDialog.ShowDialog(); // Show the dialog.
            string[] hashCode, fileNames;
            if (result == DialogResult.OK) // Test result.
            {
                hashCode = new string[openFileDialog.FileNames.Length];
                fileNames = new string[openFileDialog.FileNames.Length];
                foreach (String file in openFileDialog.FileNames)
                {
                    try
                    {
                        CheckSumTools checkSumTool = new CheckSumTools(file);
                        string text = File.ReadAllText(file);
                        hashCode[i] = checkSumTool.CheckSum_From_File(file);
                        fileNames[i] = file;
                    }
                    catch (IOException)
                    {
                    }
                    if (!duplicateValues(dataGridView, file))
                    {
                        dataGridView.Rows.Add(fileNames[i], hashCode[i]);
                        i++;
                    }
                    else
                        break;
                     
                }
            }
        }

        private bool duplicateValues (DataGridView dataGridView ,string file)
        {
            for (int i = 0; i < dataGridView.Rows.Count; i++)

            {
                dataGridView.Rows[i].DefaultCellStyle.BackColor = Color.White;

                for (int j = 0; j < dataGridView.Columns.Count; j++)
                {
                    if (dataGridView.Rows[i].Cells[j].Value != null && file == dataGridView.Rows[i].Cells[j].Value.ToString())
                    {
                        dataGridView.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                        //MessageBox.Show("The file is already existed in the table.");
                        return true;
                    }
                }
            }
            return false;
        }
        
        private void Browse_Click(object sender, EventArgs e)
        {
            Browsing(CheckSumTable);
        } 

        private void AddingSwPackageTable()
        {
            string[] ItemNum_temp = new string[cloningTool.GettingElements(cloningTool.SwPackages).lengthOfData];
            string[] SMN_temp = new string[cloningTool.GettingElements(cloningTool.SwPackages).lengthOfData];
            string[] Desc_temp = new string[cloningTool.GettingElements(cloningTool.SwPackages).lengthOfData];
            string[] path_temp = new string[cloningTool.GettingElements(cloningTool.SwPackages).lengthOfData];
            for (int i = 0; i < cloningTool.GettingElements(cloningTool.SwPackages).lengthOfData; i++)
            {
                ItemNum_temp[i] = cloningTool.GettingElements(cloningTool.SwPackages).data[i].ItemNum;
                SMN_temp[i] = cloningTool.GettingElements(cloningTool.SwPackages).data[i].SMN;
                Desc_temp[i] = cloningTool.GettingElements(cloningTool.SwPackages).data[i].Desc;
                path_temp[i] = cloningTool.GettingElements(cloningTool.SwPackages).data[i].path;
                SoftwarePackageTable.Rows.Add(ItemNum_temp[i], SMN_temp[i] , Desc_temp[i], path_temp[i]);
            }
            
        }

        private void AddingToValidHashTable()
        {
            CheckSumTools checkSumTools = new CheckSumTools(cloningTool.HashesFile);

            string[] Hash_temp = new string[checkSumTools.GettingHashFileElements().lengthOfData];
            string[] path_temp = new string[checkSumTools.GettingHashFileElements().lengthOfData];
            for (int i = 0; i < checkSumTools.GettingHashFileElements().lengthOfData; i++)
            {
                Hash_temp[i] = checkSumTools.GettingHashFileElements().data[i].hashCode;
                path_temp[i] = checkSumTools.GettingHashFileElements().data[i].path;
                ValidHashTable.Rows.Add(path_temp[i], Hash_temp[i]);
            }
        }
        private void FindValue ( DataGridView dataGridView, TextBox textBox)
        {
            string searchValue = textBox.Text;

            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            try
            {
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    row.Selected = false;
                    for (int j = 0; j < dataGridView.Columns.Count; j++)
                    {
                        if (row.Cells[j].Value.ToString().Equals(searchValue))
                        {
                            row.Selected = true;
                            break;
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void Find_Click(object sender, EventArgs e)
        {
            FindValue(SoftwarePackageTable, SearchBoxSw);
        }

        private void HashFindBtn_Click(object sender, EventArgs e)
        {
            string searchValue = SearchBoxHash.Text;
            FindValue(ValidHashTable, SearchBoxHash);
        }

        private void SearchBoxSw_MouseHover(object sender, EventArgs e)
        {
            ToolTip MsgTip = new ToolTip();
            MsgTip.Show("Search by Item number, SMN, and Description", SearchBoxSw);
        }

        private void SearchBoxHash_MouseHover(object sender, EventArgs e)
        {
            ToolTip MsgTip = new ToolTip();
            MsgTip.Show("Search by Hash code", SearchBoxHash);
        }
    }
}
