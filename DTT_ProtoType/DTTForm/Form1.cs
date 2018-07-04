using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DTTForm
{
    public partial class Form1 : Form
    {
        DriveInfo[] allDrives = DriveInfo.GetDrives();
        public Form1()
        {
            InitializeComponent();
            comboBox1.Text = "Select Software";
            label1.Text = "Location";
            label2.Text = "CheckSum";
            pictureBox1.Image = null;
            AddingToComboBox();
            refresh.Font = new Font("Wingdings 3", 12, FontStyle.Bold);
            refresh.Text = Char.ConvertFromUtf32(81); // or 80
            refresh.Width = 25;
            refresh.Height = 25;
            Drivers();
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex >= 0)
            {
                label1.Text = GettingElements().data[comboBox1.SelectedIndex].path;

                HashFiles(GettingElements().data[comboBox1.SelectedIndex].path);
            }
        }

        private void AddingToComboBox()
        {
            for (int i = 0; i < GettingElements().lengthOfData; i++)
            {
                comboBox1.Items.Add(GettingElements().data[i].name);
            }
        }

        private string Hash(string filename)
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

        private void HashFiles(string folderPath)
        {
            string hashFile = "";
            MessageBox.Show(folderPath);
            string[] files = Directory.GetFiles(folderPath.Replace("\r", ""));
            try
            {
                hashFile = File.ReadAllText(@"..\..\..\HashChecking.txt");
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: HashChecking file does not exist");
                Environment.Exit(0);
            }
            string[] hashCode = hashFile.Split('\n');
            string toDisplay = string.Join(Environment.NewLine, files);
            MessageBox.Show(toDisplay);
            string[] temp = new string[files.Length];

            int i = 0;
            while (i < files.Length)
            {
                temp[i] = Hash(files[i]);
                i++;
            }

            string tempDisplay = string.Join(Environment.NewLine, temp);
            MessageBox.Show(tempDisplay);
            for (int j = 0; j < hashCode.Length; j++)
            {
                if (temp.Contains(hashCode[j]))
                {
                    label2.Text = "passed";
                    copying();
                }
                else
                {
                    MessageBox.Show("Error: " + hashCode[j] + " is not in Hashing file");
                }
            }
        }

        public void copying()
        {
            string sourceFolder = GettingElements().data[comboBox1.SelectedIndex].path;
            if (label2.Text=="passed")
            {
                foreach (string desti in checkedListBox1.CheckedItems)
                {
                    MessageBox.Show(sourceFolder+"\n"+ desti);

                    foreach (string newPath in Directory.GetFiles(sourceFolder, "*.*",
                        SearchOption.AllDirectories))
                        File.Copy(newPath, newPath.Replace(sourceFolder, desti), true);
                }
            }
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.loading;
            checkedListBox1.Items.Clear();

            Drivers();
            int x = allDrives.Length;
            
        }
        private void Drivers()
        {
            checkedListBox1.Items.Add("Select All");
            foreach (var value in DriveInfo.GetDrives().Where(d => d.DriveType == DriveType.Removable))
            {
                checkedListBox1.Text = value.Name;
                checkedListBox1.Items.Add(value.Name);
            }
        }

        public struct Elements
        {
            public String name, path, hash;
        }
        public struct dataElements
        {
            public int lengthOfData;
            public Elements[] data;
        }

        public dataElements GettingElements()
        {
            string text = "";
            try
            {
               text = File.ReadAllText(@"..\..\..\SwTesting.txt");
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: SwTesting file does not exist");
                Environment.Exit(0);
            }

            string[] enter = text.Split('\n');
            int number_of_elements = enter.Length;
            dataElements values = new dataElements();
            values.lengthOfData = number_of_elements;
            values.data = new Elements[values.lengthOfData];

            for (int i = 0; i < values.lengthOfData; i++)
            {
                string[] element = enter[i].Split('\t');
                values.data[i].name = element[0];
                values.data[i].path = element[1];

                if (string.IsNullOrEmpty(values.data[i].name) || string.IsNullOrEmpty(values.data[i].path))
                {
                    MessageBox.Show("Error with SwTesting file");
                    Environment.Exit(0);
                }
            }
            return values;
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (checkedListBox1.Items.Clear(0))

        }
    }
}
