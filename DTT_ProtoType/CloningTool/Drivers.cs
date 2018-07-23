using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Windows.Forms;
using System.IO;
using System.Drawing;


namespace CloningTool
{
    class Drivers
    {

        const int X_Location = 131;
        const int Y_Location = 180;
        const int Y_Multiplier_Value=15;
        const int Icon_Size = 13;

        private BackgroundWorker Drive_Worker;
        public string Drive_Name;
        private int Drive_Order;
        PictureBox Loading_pic;
        PictureBox Complete_pic;
        PictureBox Error_pic;


        public string Version = "1.0";
        private string SwPackages = @"SwPackages.ini";
        private string HashesFile = @"Hashes.ini";
        private string swPath = "";
        private string langPath = "";
        private string keyPath = "";
        private string [] Source_Folders;
        CloningTool Main_Form;
        CheckSumTools CheckSumTools;





       






       struct Copy_Struct
        {
            public string [] Source_Folders;
            public string Destination_Folder;

        }


        public Drivers (string drive_name, int drive_order, CloningTool Parent)
        {
            Drive_Worker = new BackgroundWorker();
            Drive_Name = drive_name;
            Drive_Order = drive_order;
           // Source_Folders = SourceFolders;
            Main_Form = Parent;

            PictureBox Loading_pic = new PictureBox
            {
                Name = "Loading_Icon",
                Size = new Size(Icon_Size, Icon_Size),
                Location = new Point(X_Location, Y_Location + drive_order * Y_Multiplier_Value),
                Image = Image.FromFile("Loading.gif"),
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackgroundImageLayout = ImageLayout.None,
                BackColor = Color.Transparent,
            }; 

            PictureBox Complete_pic = new PictureBox
            {
                Name = "Check_Icon",
                Size = new Size(Icon_Size, Icon_Size),
                Location = new Point(X_Location, Y_Location + drive_order * Y_Multiplier_Value),
                Image = Image.FromFile("Check.ico"),
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackgroundImageLayout = ImageLayout.None,
                BackColor = Color.Transparent,
            };

            PictureBox Error_pic = new PictureBox
            {
                Name = "Error_Icon",
                Size = new Size(Icon_Size, Icon_Size),
                Location = new Point(X_Location, Y_Location + drive_order * Y_Multiplier_Value),
                Image = Image.FromFile("Error.png"),
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackgroundImageLayout = ImageLayout.None,
                BackColor = Color.Transparent,
            };

            Main_Form.Controls.Add(Loading_pic);
            Main_Form.Controls.Add(Complete_pic);
            Main_Form.Controls.Add(Error_pic);

            CheckSumTools = new CheckSumTools(HashesFile);


            this.Drive_Worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Drive_Worker_DoWork);
            this.Drive_Worker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.Drive_Worker_ProgressChanged);
            this.Drive_Worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.Drive_Worker_RunWorkerCompleted);
            Drive_Worker.WorkerReportsProgress = true;

        }






        /*
        public void Copy_File(string Source_Folder, string Destination_Folder)
        {
            MessageBox.Show("step2");
            Copy_Struct Copy_Struct_Data;
            Copy_Struct_Data.Source_Folder = Source_Folder;
            Copy_Struct_Data.Destination_Folder = Destination_Folder;
            MessageBox.Show(Drive_Worker.IsBusy.ToString());
            if (!Drive_Worker.IsBusy) Drive_Worker.RunWorkerAsync(Copy_Struct_Data);
        }
        */

        public void Copy_Files_Multiple_Sources(string [] Source_Folders, string Destination_Folder)
        {
            Copy_Struct Copy_Struct_Data;
            Copy_Struct_Data.Source_Folders = Source_Folders;
            Copy_Struct_Data.Destination_Folder = Destination_Folder;
            if (!Drive_Worker.IsBusy) Drive_Worker.RunWorkerAsync(Copy_Struct_Data);
        }

        public bool Copy_Status()
        {
            bool Copy_Status = false;

            return (Copy_Status);
        }









        private bool Format_Drive(string Drive)
        {
            return (FMT_DRV(Drive.Replace(@"\",""), "FAT32", true, 8192, "", false));
        }

        public bool FMT_DRV(string driveLetter, string fileSystem = "FAT32", bool quickFormat = true,
                                    int clusterSize = 4096, string label = "", bool enableCompression = false)
        {
            
            //add logic to format Usb drive
            //verify conditions for the letter format: driveLetter[0] must be letter. driveLetter[1] must be ":" and all the characters mustn't be more than 2
            if (driveLetter.Length != 2 || driveLetter[1] != ':' || !char.IsLetter(driveLetter[0]))
                return false;

            //query and format given drive 
            //best option is to use ManagementObjectSearcher

            var files = Directory.GetFiles(driveLetter);
            var directories = Directory.GetDirectories(driveLetter);
            foreach (var item in files)
            {
                try
                {
                    File.Delete(item);
                }
                catch (UnauthorizedAccessException) { }
                catch (IOException) { }
            }
            foreach (var item in directories)
            {
                try
                {
                    Directory.Delete(item);
                }
                catch (UnauthorizedAccessException) { }
                catch (IOException) { }
            }
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(@"select * from Win32_Volume WHERE DriveLetter = '" + driveLetter + "'");
            foreach (ManagementObject vi in searcher.Get())
            {
                try
                {
                    var completed = false;
                    var watcher = new ManagementOperationObserver();

                    watcher.Completed += (sender, args) =>
                    {
                       // MessageBox.Show("USB format completed " + args.Status);
                        
                        completed = true;
                    };
                    watcher.Progress += (sender, args) =>
                    {
                        //MessageBox.Show("USB format in progress " + args.Current);
                
                    };

                    vi.InvokeMethod(watcher, "Format", new object[] { fileSystem, quickFormat, clusterSize, label, enableCompression });

                    while (!completed) { System.Threading.Thread.Sleep(1000); }


                }
                catch
                {

                }
            }

            return true;
        }




        private void Copying_Function(string [] SourceFolders, string Destination)
        {
            var File_Extentions = new List<string> { ".htm", ".lnk", ".cab", ".CAB", ".sig", ".bmp", ".bin", ".lst", ".exe" };
            IEnumerable<string> SWFiles;

            foreach(string SourceFolder in SourceFolders)
            {
                //MessageBox.Show(SourceFolder);
                SWFiles = Directory.GetFiles(SourceFolder.Replace("\r", ""), "*.*", SearchOption.AllDirectories)
                                    .Where(s => File_Extentions.Contains(Path.GetExtension(s)));

                string[] Destination_Files = new string[SWFiles.Count()];
                string[] Source_Files = new string[SWFiles.Count()];



                int i = 0;
                int j = 0;
               
                foreach (string File_Path in SWFiles)
                {
                    MessageBox.Show("file to copy\n" + File_Path);
                    if (true/*CheckSumTools.Check_Valid_CheckSum(File_Path)*/)
                    {
                        File.Copy(File_Path, Destination + Path.GetFileName(File_Path), true);

                        Destination_Files[j] = Destination + Path.GetFileName(File_Path);
                        Source_Files[j] = File_Path;

                        Drive_Worker.ReportProgress(i++);
                    }
                    else
                    {
                        MessageBox.Show("Error Wrong File in list");

                        break;
                    }

                    if (Drive_Worker.CancellationPending)
                    {

                        break;
                    }
                    j++;
                }
                if (!CheckSumTools.Check_Valid_CheckSum_Folders(Destination_Files, Source_Files))
                {
                    MessageBox.Show("Error Cpying");

                    break;
                }
            }

            

        }


       





        private void Drive_Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                MessageBox.Show("step3");
                Format_Drive(Drive_Name);
                
                if (Format_Drive(Drive_Name))
                {
                    MessageBox.Show("step4");
                    Copying_Function(((Copy_Struct)e.Argument).Source_Folders, ((Copy_Struct)e.Argument).Destination_Folder);
                }
                else
                { 
                    MessageBox.Show("Error Formatting Drive");
                }
                
            }

            catch (IOException)
            {
                MessageBox.Show("The Drive " + Drive_Name + " is not connected!\nPlease press refresh.");  
                e.Cancel = true;
            }
            
        }


        private void Drive_Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            MessageBox.Show("stepprogress changed");
        }

        private void Drive_Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Drive_Worker_RunWorkerCompleted");

        }


        public void  Dispose_Worker()
        {
            Drive_Worker.Dispose();
        }



    }
}
