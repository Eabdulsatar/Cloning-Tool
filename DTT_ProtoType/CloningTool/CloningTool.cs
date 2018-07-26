using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace CloningTool
{
    public partial class CloningTool : Form
    {
        DriveInfo[] allDrives = DriveInfo.GetDrives();
        public string Version = "1.0";
        private string SwPackages = @"SwPackages.ini";
        private string HashesFile = @"Hashes.ini";
        private List<Drivers> Drives_List = new List<Drivers>();
        private string[] FoldersPath;
        public string FromDrivers = "";
        public struct Elements
        {
            public string ItemNum, SMN, Desc, path;
        }
        public struct DataElements
        {
            public int lengthOfData;
            public Elements[] data;
        }

        private struct Unique_elements
        {
            public string[] folders;
            public string Item_Number, SMN_Number, Description;
        }

        enum Message_Status : int
        {
            IDEL = 0,
            FORMATTING = 1,
            COPYING = 2,
            COMPLETE = 3,
            ERROR_FORMATTING = 4,
            ERROR_HASHING = 5,
            ERROR_MISSING_DRIVE = 6,
            ERROR_CORRUPTED = 7
        }

        public CloningTool()
        {
            InitializeComponent();
            try
            {
                string LF = File.ReadAllText(SwPackages, Encoding.UTF8);
            }

            catch (Exception)
            {
                MessageBox.Show("SwPackages file is missing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }

            try
            {
                string LF = File.ReadAllText(HashesFile, Encoding.UTF8);
            }

            catch (Exception)
            {
                MessageBox.Show("Hashes file is missing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }

            version.Text = "Version " + Version;
        }

        private void Displaying_Msgs(string[] msgs)
        {
            string toDisplay = string.Join(Environment.NewLine, msgs);
            MessageBox.Show(toDisplay);
        }


        private void SoftwareList_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Unique_elements element;

            if (SoftwareList.SelectedIndex >= 0)
            {
                element = GetDataElements_FromSelection(SoftwareList.SelectedItem.ToString(), SMNRd.Checked);

                DescSW.Text = element.Description + "\n" + "SMN: " + element.SMN_Number
                   + "\n" + "Item Number: " + element.Item_Number;
                FoldersPath = element.folders;
            }
        }

        public DataElements GettingElements(String SWfile)
        {
            var text = File.ReadAllText(SWfile);
            string[] enter = text.Split('\n');
            int number_of_elements = enter.Length;
            DataElements values = new DataElements();
            values.lengthOfData = number_of_elements;
            values.data = new Elements[values.lengthOfData];

            for (int i = 0; i < values.lengthOfData; i++)
            {
                string[] element = enter[i].Split('\t');
                values.data[i].ItemNum = element[0];
                values.data[i].SMN = element[1];
                values.data[i].Desc = element[2];
                values.data[i].path = element[3];


                if (string.IsNullOrEmpty(values.data[i].ItemNum)
                    || string.IsNullOrEmpty(values.data[i].SMN)
                    || string.IsNullOrEmpty(values.data[i].Desc)
                    || string.IsNullOrEmpty(values.data[i].path))
                {
                    MessageBox.Show("Missing content in SwFile", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(0);
                }
            }
            return values;
        }

        private string[] Remove_Dupicate(bool Is_SMN)
        {
            string[] temp = new string[GettingElements(SwPackages).lengthOfData];

            if (Is_SMN)
            {
                for (int i = 0; i < GettingElements(SwPackages).lengthOfData; i++)
                {
                    temp[i] = GettingElements(SwPackages).data[i].SMN;
                }
                return temp.Distinct().ToArray();
            }
            else
            {
                for (int i = 0; i < GettingElements(SwPackages).lengthOfData; i++)
                {
                    temp[i] = GettingElements(SwPackages).data[i].ItemNum;
                }
                return temp.Distinct().ToArray();
            }
        }

        private Unique_elements GetDataElements_FromSelection(string data, bool Is_SMN)
        {
            List<string> temp = new List<string>();
            Unique_elements items = new Unique_elements();

            for (int i = 0; i < GettingElements(SwPackages).lengthOfData; i++)
            {
                if (Is_SMN)
                {
                    if (data == GettingElements(SwPackages).data[i].SMN)
                    {
                        items.Description = GettingElements(SwPackages).data[i].Desc;
                        items.SMN_Number = GettingElements(SwPackages).data[i].SMN;
                        items.Item_Number = GettingElements(SwPackages).data[i].ItemNum;
                        temp.Add(GettingElements(SwPackages).data[i].path);
                    }
                }
                else
                {
                    if (data == GettingElements(SwPackages).data[i].ItemNum)
                    {
                        items.Description = GettingElements(SwPackages).data[i].Desc;
                        items.SMN_Number = GettingElements(SwPackages).data[i].SMN;
                        items.Item_Number = GettingElements(SwPackages).data[i].ItemNum;
                        temp.Add(GettingElements(SwPackages).data[i].path);
                    }
                }
                items.folders = temp.ToArray();

            }
            return items;

        }

        private void RefreshBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Drives_List.Count; i++)
            {
                Drives_List[i].Dispose();

            }
            Drives_List.Clear();
            DriversList.Items.Clear();
            SelectAll.Checked = false;
            Drivers_Function();
        }

        private void SelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (SelectAll.Checked == true)
            {
                for (int i = DriversList.Items.Count - 1; i >= 0; i--)
                {
                    DriversList.SetItemCheckState(i, CheckState.Checked);
                }
            }
        }

        public struct Driverslist
        {
            public DriveInfo drive_information;
            public PictureBox image;
        }

        public string Drivers_Function()
        {

            int totalDrivers = DriveInfo.GetDrives().Where(d => d.DriveType == DriveType.Removable).Count();
            Driverslist[] drivers_read_list = new Driverslist[totalDrivers];
            string driversName = "";
            int j = 0;

            foreach (var value in DriveInfo.GetDrives().Where(d => d.DriveType == DriveType.Removable))
            {
                Controls.Add(drivers_read_list[j].image);
                drivers_read_list[j].drive_information = value;
                DriversList.Text = value.Name;
                driversName = DriversList.Text;
                DriversList.Items.Add(value.Name);
                j++;
            }

            if (j > 0)
            {
                for (int i = 0; i < j; i++)
                {
                    Drives_List.Add(new Drivers(drivers_read_list[i].drive_information.Name.ToString(), i, this));
                }
            }
            return (driversName);
        }

        private void CopyBtn_Click(object sender, EventArgs e)
        {
            var items = DriversList.CheckedItems.OfType<string>().ToArray();

            string selected = this.SoftwareList.GetItemText(this.SoftwareList.SelectedItem);

            if (FoldersPath == null)
            {
                MessageBox.Show("Please select an Item number or SMN number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                RefreshBtn.Enabled = false;
                copyBtn.Enabled = false;
                EraseBtn.Enabled = false;

                for (int i = 0; i < DriversList.CheckedItems.Count; i++)
                {
                    for (int j = 0; j < Drives_List.Count; j++)
                    {
                        if (items[i] == Drives_List[j].Drive_Name)
                        {
                            Drives_List[j].Copy_Files_Multiple_Sources(FoldersPath);
                        }
                    }
                }
                MainWorker.RunWorkerAsync();
            }
        }

        private void CloningTool_Load(object sender, EventArgs e)
        {
            RefreshBtn.PerformClick();
            ItemNumRd.Checked = true;
        }

        private void ItemNumRd_CheckedChanged(object sender, EventArgs e)
        {
            if (ItemNumRd.Checked)
            {
                SoftwareList.Items.Clear();
                SoftwareList.Items.AddRange(Remove_Dupicate(false));
            }
        }

        private void SMNRd_CheckedChanged(object sender, EventArgs e)
        {
            if (SMNRd.Checked)
            {
                SoftwareList.Items.Clear();
                SoftwareList.Items.AddRange(Remove_Dupicate(true));
            }
        }

        private void CheckSum_Btn_Click(object sender, EventArgs e)
        {
            CheckSumWin check = new CheckSumWin();
            check.Show();
        }

        private void EraseBtn_Click(object sender, EventArgs e)
        {
            RefreshBtn.Enabled = false;
            copyBtn.Enabled = false;
            EraseBtn.Enabled = false;

            var items = DriversList.CheckedItems.OfType<string>().ToArray();

            string selected = this.SoftwareList.GetItemText(this.SoftwareList.SelectedItem);

            for (int i = 0; i < DriversList.CheckedItems.Count; i++)
            {
                for (int j = 0; j < Drives_List.Count; j++)
                {
                    if (items[i] == Drives_List[j].Drive_Name) Drives_List[j].Format_MyDrive();
                }

            }
            MainWorker.RunWorkerAsync();
        }

        private void MainWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                bool output_status = true;
                for (int j = 0; j < Drives_List.Count; j++)
                {
                    output_status = output_status && !(Drives_List[j].Worker_IsBusy());
                }
                if (output_status) break;


                if (MainWorker.CancellationPending)
                {
                    break;
                }
            }
        }

        private void MainWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            RefreshBtn.Enabled = true;
            copyBtn.Enabled = true;
            EraseBtn.Enabled = true;
            string Message_string = "";

            for (int j = 0; j < Drives_List.Count; j++)
            {
                if(Drives_List[j].Worker_Status() == 4 
                    || Drives_List[j].Worker_Status() == 5 
                    || Drives_List[j].Worker_Status() == 6
                    || Drives_List[j].Worker_Status() == 7)
                {
                    if (Drives_List[j].Worker_Status() == 4)
                        Message_string = Message_string + Drives_List[j].Drive_Name + "Has Formatting Error\n";
                    else if (Drives_List[j].Worker_Status() == 6)
                        Message_string = Message_string + Drives_List[j].Drive_Name + "is not connected!\n";
                    else if (Drives_List[j].Worker_Status() == 5)
                        Message_string = Message_string + Drives_List[j].Drive_Name + "has an error with hashing. Please update the Hashes file.\n";
                    else if (Drives_List[j].Worker_Status() == 7)
                        Message_string = Message_string + Drives_List[j].Drive_Name + "has corrupted copied files\n";
                }
                
            }
            if (!(Message_string == ""))
            {
                MessageBox.Show(Message_string, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }
    }
}

