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
        private string swPath = "";
        private string langPath = "";
        private string keyPath = "";
        private List<Drivers> Drives_List = new List<Drivers>();
         


        public CloningTool()
        {
            InitializeComponent();

            /*
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
            */
            pictureBox1.Visible = false;
            refresh.Font = new Font("Wingdings 3", 12, FontStyle.Bold);
            refresh.Text = Char.ConvertFromUtf32(81); // or 80
            refresh.Width = 25;
            refresh.Height = 25;
          //  copyBtn.Enabled = false;
           

            //ItemNumRd.Checked = true; Drivers_Function();
            version.Text = "Version " + Version;
        }
        private void SoftwareList_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            completed.Visible = false;
            if (SoftwareList.SelectedIndex >= 0)
            {
              //  HashReturn();
            }
        }
        /*
        public IEnumerable<string> HashReturn ()
        {
            Invoke((MethodInvoker)(delegate {
                if (ItemNumRd.Checked==true)
                {
                    DescSW.Text = GettingElements(SwPackages).data[SoftwareList.SelectedIndex].Desc
                + "\n" + "SMN: " + GettingElements(SwPackages).data[SoftwareList.SelectedIndex].SMN;
                }
                else if (SMNRd.Checked==true)
                {
                    DescSW.Text = GettingElements(SwPackages).data[SoftwareList.SelectedIndex].Desc
                + "\n" + "Item Number: " + GettingElements(SwPackages).data[SoftwareList.SelectedIndex].ItemNum;
                }
                

                swPath = GettingElements(SwPackages).data[SoftwareList.SelectedIndex].SwPath;

                langPath = GettingElements(SwPackages).data[SoftwareList.SelectedIndex].LangPath;

            }));

            IEnumerable<string> total = null;
            this.Invoke((MethodInvoker)delegate ()
            {
                var swHashes = HashFiles(GettingElements(SwPackages).data[SoftwareList.SelectedIndex].SwPath);
                var langHashes = HashFiles(GettingElements(SwPackages).data[SoftwareList.SelectedIndex].LangPath);
                total = swHashes.Concat(langHashes);
                if (GettingElements(SwPackages).data[SoftwareList.SelectedIndex].Language == "CN")
                {
                    keyPath= GettingElements(SwPackages).data[SoftwareList.SelectedIndex].KeyPath;
                    var keyHashes = HashFiles(GettingElements(SwPackages).data[SoftwareList.SelectedIndex].KeyPath);
                    total = total.Concat(keyHashes);
                }
                if (FileHash.Text == "Passed")
                {
                    copyBtn.Enabled = true;
                }
            });
            
            return total;
        }

        public string Hash(string filename)
        {
            FileInfo fi = new FileInfo(filename);
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            BinaryReader readBin = new BinaryReader(fs);
            byte[] data = readBin.ReadBytes((int)fi.Length);
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            byte[] result = sha1.ComputeHash(data);
            string msg = "";
            foreach (byte d in result)
            {
                msg = msg + d.ToString("x");
            }
            return msg;
        }
        */
        public IEnumerable<string> HashFiles(string folderPath)
        {
            var ext = new List<string> { ".htm", ".lnk", ".cab", ".CAB", ".sig", ".bmp", ".bin", ".lst", ".exe" };
            var files = Directory.GetFiles(folderPath.Replace("\r", ""), "*.*", SearchOption.AllDirectories)
                    .Where(s => ext.Contains(Path.GetExtension(s)));
            string hashFile = File.ReadAllText(HashesFile);
            string[] hashCode = hashFile.Split('\n');
            string[] temp = new string[files.ToArray().Length];
            int i = 0;

            while (i < files.ToArray().Length)
            {
                foreach (string file in files)
                {
                  //  temp[i] = Hash(file).Replace("\r", "");
                    i++;
                }
            }

            string[] hashTemp = new string[hashCode.Length];
            int j = 0;

            while (j < hashCode.Length)
            {
                foreach (string hash in hashCode)
                {
                    hashTemp[j] = hash.Replace("\r", "");
                    j++;
                }
            }

            foreach (string str in temp)
            {
                if (!hashTemp.Contains(str))
                {
                    FileHash.Invoke((MethodInvoker)(delegate {
                        FileHash.ForeColor = Color.Red;
                        FileHash.Text = "Failed!!";

                    }));
                   // copyBtn.Enabled = false;
                    break;
                }
                else
                {
                    FileHash.Invoke((MethodInvoker)(delegate {
                        FileHash.ForeColor = Color.Black;
                        FileHash.Text = "Passed";
                    }));
                    
                }
            }
            return temp;
        }
       
        private void Refresh_Click(object sender, EventArgs e)
        {
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
                   // MessageBox.Show(j.ToString() + "\n" + i.ToString()+"\n"+ drivers_read_list[i].drive_information.Name);
                    Drives_List.Add(new Drivers(drivers_read_list[i].drive_information.Name.ToString(), i, this));
                }

                    
            }
            




            return (driversName);
        }

        public struct Elements
        {
            public string ItemNum, SMN, Desc, SwPackage, SwPath, Language, LangPath, Keyboard, KeyPath;
        }

        public struct DataElements
        {
            public int lengthOfData;
            public Elements[] data;
        }
        /*
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
                values.data[i].SwPackage = element[3];
                values.data[i].SwPath = element[4];
                values.data[i].Language = element[5];
                values.data[i].LangPath = element[6];
                values.data[i].Keyboard = element[7];
                values.data[i].KeyPath = element[8];


                if (string.IsNullOrEmpty(values.data[i].ItemNum)
                    || string.IsNullOrEmpty(values.data[i].SMN)
                    || string.IsNullOrEmpty(values.data[i].Desc)
                    || string.IsNullOrEmpty(values.data[i].SwPackage)
                    || string.IsNullOrEmpty(values.data[i].SwPath)
                    || string.IsNullOrEmpty(values.data[i].Language)
                    || string.IsNullOrEmpty(values.data[i].LangPath)
                    || string.IsNullOrEmpty(values.data[i].Keyboard)
                    || string.IsNullOrEmpty(values.data[i].KeyPath))
                {
                    MessageBox.Show("Missing content in SwFile", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(0);
                }
            }
            return values;
        }

       */
        
        
        /*
        public void CopyBtn_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            if (!backgroundWorker1.IsBusy)
                 backgroundWorker1.RunWorkerAsync();
        }
        */
        /*
        private void button1_Click(object sender, EventArgs e)
        {
            foreach (string desti in DriversList.CheckedItems)
            {
                try
                {
                    Array.ForEach(Directory.GetFiles(desti),
                                                       delegate (string path) { File.Delete(path); });
                }
                catch (IOException)
                {
                    MessageBox.Show("The Drive " + desti + " is not connected!\nPlease press refresh.");
                }
            } 
        }
        */
        /*
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pictureBox1.Visible = false;
        }
        */
        /*
        private void button2_Click_1(object sender, EventArgs e)
        {
            CheckSumWin check = new CheckSumWin();
            check.Show();
        }
        */
        /*
        private void ItemNumRd_CheckedChanged(object sender, EventArgs e)
        {
            if (ItemNumRd.Checked)
            {
                for (int i = 0; i < GettingElements(SwPackages).lengthOfData; i++)
                {
                    SoftwareList.Items.Remove(GettingElements(SwPackages).data[i].SMN);
                    SoftwareList.Items.Add(GettingElements(SwPackages).data[i].ItemNum);
                }
            }
        }
        
        private void SMNRd_CheckedChanged(object sender, EventArgs e)
        {
            if (SMNRd.Checked)
            {
                for (int i = 0; i < GettingElements(SwPackages).lengthOfData; i++)
                {
                    SoftwareList.Items.Remove(GettingElements(SwPackages).data[i].ItemNum);
                    SoftwareList.Items.Add(GettingElements(SwPackages).data[i].SMN);
                }
            }
        }
        */
        private void copyBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("step1");
            string[] folders = new string[4] { @"C:\testsf", @"C:\testsf2", @"C:\testsf3", @"C:\Full Installation\storage card" };  

        Drives_List[0].Copy_Files_Multiple_Sources(folders,Drives_List[0].Drive_Name);
           // Drives_List[0].Copy_File(@"C:\testsf", Drives_List[0].Drive_Name);

        }

       
    }
    }

