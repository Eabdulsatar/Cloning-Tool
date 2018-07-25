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
    class Drivers : IDisposable
    {

        const int X_Location = 131;
        const int X_Location_status = 68;
        const int Y_Location = 180;
        const int Y_Multiplier_Value=15;
        const int Icon_Size = 13;

        private BackgroundWorker Drive_Worker;
        public string Drive_Name;
        private int Drive_Order;
        private string HashesFile = @"Hashes.ini";
        CloningTool Main_Form;
        CheckSumTools CheckSumTools;


        private PictureBox Loading_pic = new PictureBox
        {
            Name = "Loading_Icon",
            Size = new Size(Icon_Size, Icon_Size),
            Image = Image.FromFile("Loading.gif"),
            SizeMode = PictureBoxSizeMode.StretchImage,
            BackgroundImageLayout = ImageLayout.None,
            BackColor = Color.Transparent,
            Visible = false,
        };
        private PictureBox Complete_pic = new PictureBox
        {
            Name = "Check_Icon",
            Size = new Size(Icon_Size, Icon_Size),
            Image = Image.FromFile("Check.ico"),
            SizeMode = PictureBoxSizeMode.StretchImage,
            BackgroundImageLayout = ImageLayout.None,
            BackColor = Color.Transparent,
            Visible = false,
        };

        private PictureBox Error_pic = new PictureBox
        {
            Name = "Error_Icon",
            Size = new Size(Icon_Size, Icon_Size),
            Image = Image.FromFile("Error.png"),
            SizeMode = PictureBoxSizeMode.StretchImage,
            BackgroundImageLayout = ImageLayout.None,
            BackColor = Color.Transparent,
            Visible = false,
        };

        private Label Loading_Status = new Label
        {
            AutoSize = true,
            Name = "Loading_Status",
            Size = new Size(35, 13),
            TabIndex = 1,
            BackColor = Color.Transparent,
            Visible = true,
        };
        
        struct Copy_Struct
        {
            public string [] Source_Folders;
            public string Destination_Folder;
            public bool Is_Format;
         

        }

        enum Message_Status : int 
        {
            IDEL=0,
            FORMATTING=1,
            COPYING=2,
            COMPLETE=3,
            ERROR_FORMATTING=4,
            ERROR_HASHING=5,
            ERROR_MISSING_DRIVE=6,
            ERROR_CORRUPTED=7
        }

        enum Image_Control_Message : int
        {
            IDEL,
            FORMATTING,
            COPYING,
            ERROR,
            COMPLETE,
        }
        private int MessageStatus;


        public Drivers (string drive_name, int drive_order, CloningTool Parent)
        {
            Drive_Worker = new BackgroundWorker();
            Drive_Name = drive_name;
            Drive_Order = drive_order;
            Main_Form = Parent;
            Loading_Status.Location = new Point(X_Location_status, Y_Location + drive_order * Y_Multiplier_Value);
            Complete_pic.Location = new Point(X_Location, Y_Location + drive_order * Y_Multiplier_Value);
            Error_pic.Location = new Point(X_Location, Y_Location + drive_order * Y_Multiplier_Value);
            Loading_pic.Location = new Point(X_Location, Y_Location + drive_order * Y_Multiplier_Value);

            Main_Form.Controls.Add(Loading_pic);
            Main_Form.Controls.Add(Complete_pic);
            Main_Form.Controls.Add(Error_pic);
            Main_Form.Controls.Add(Loading_Status);

            CheckSumTools = new CheckSumTools(HashesFile);

            this.Drive_Worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Drive_Worker_DoWork);
            this.Drive_Worker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.Drive_Worker_ProgressChanged);
            this.Drive_Worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.Drive_Worker_RunWorkerCompleted);
            Drive_Worker.WorkerReportsProgress = true;

        }
       

        public void Copy_Files_Multiple_Sources(string [] Source_Folders)
        {
            Copy_Struct Copy_Struct_Data;
            Copy_Struct_Data.Source_Folders = Source_Folders;
            Copy_Struct_Data.Destination_Folder = Drive_Name;
            Copy_Struct_Data.Is_Format = false;
            if (!Drive_Worker.IsBusy) Drive_Worker.RunWorkerAsync(Copy_Struct_Data);
        }

        public void Format_MyDrive()
        {
            Copy_Struct Copy_Struct_Data;
            Copy_Struct_Data.Source_Folders = null;
            Copy_Struct_Data.Destination_Folder = null ;
            Copy_Struct_Data.Is_Format = true;
            if (!Drive_Worker.IsBusy) Drive_Worker.RunWorkerAsync(Copy_Struct_Data);
        }
        
        private bool Format_Drive(string Drive)
        {
            Drive_Worker.ReportProgress(0, Message_Status.FORMATTING);
            if (FMT_DRV(Drive.Replace(@"\", ""), "FAT32", true, 8192, "", false))
            {
                Drive_Worker.ReportProgress(0, Message_Status.COMPLETE);
                return (true);
            }
            else
            {
                Drive_Worker.ReportProgress(0, Message_Status.ERROR_FORMATTING);
                return (false);
            }
        }
      
        private bool FMT_DRV(string driveLetter, string fileSystem = "FAT32", bool quickFormat = true,
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
                catch (UnauthorizedAccessException) { return false; }
                catch (IOException e) {
                    //MessageBox.Show(e.ToString());
                    return false;
                    break; }
            }
            foreach (var item in directories)
            {
                try
                {
                    Directory.Delete(item);
                }
                catch (UnauthorizedAccessException) { return false; }
                catch (IOException e)
                {
                    //MessageBox.Show(e.ToString());
                    return false;
                    break; }
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

                    while (!completed)
                    { /*System.Threading.Thread.Sleep(1000);*/
                       
                    }
                }
                catch
                {
                    return false;

                }
            }
            return true;
        }


        private void Copying_Function(string [] SourceFolders, string Destination)
        {
            var File_Extentions = new List<string> { ".htm", ".lnk", ".cab", ".CAB", ".sig", ".bmp", ".bin", ".lst", ".exe" };
            IEnumerable<string> SWFiles;
            Drive_Worker.ReportProgress(0, Message_Status.COPYING);
            bool errorStatus_temp = true;

            foreach (string SourceFolder in SourceFolders)
            {
                SWFiles = Directory.GetFiles(SourceFolder.Replace("\r", ""), "*.*", SearchOption.AllDirectories)
                                    .Where(s => File_Extentions.Contains(Path.GetExtension(s)));

                string[] Destination_Files = new string[SWFiles.Count()];
                string[] Source_Files = new string[SWFiles.Count()];

                int j = 0;
                foreach (string File_Path in SWFiles)
                {
                    if (CheckSumTools.Check_Valid_CheckSum(File_Path))
                    {
                        File.Copy(File_Path, Destination + Path.GetFileName(File_Path), true);

                        Destination_Files[j] = Destination + Path.GetFileName(File_Path);
                        Source_Files[j] = File_Path;
                    }
                    else
                    {
                        Drive_Worker.ReportProgress(0, Message_Status.ERROR_HASHING);
                    errorStatus_temp = false;
                        break;
                    }

                    if (Drive_Worker.CancellationPending)
                    {
                    errorStatus_temp = false;
                        break;
                    }

                    j++;
                }
                
                if (!CheckSumTools.Check_Valid_CheckSum_Folders(Destination_Files, Source_Files))
                {
                    Drive_Worker.ReportProgress(0, Message_Status.ERROR_CORRUPTED);
                    errorStatus_temp = false;
                    break;
                }
                
            }

            if (!errorStatus_temp == false)  Drive_Worker.ReportProgress(0, Message_Status.COMPLETE);
            
        }


        private void Drive_Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Drive_Worker.ReportProgress(0, Message_Status.IDEL);
            try
           {
                if (Format_Drive(Drive_Name))
                {
                    if (!((Copy_Struct)e.Argument).Is_Format)
                    {
                        Copying_Function(((Copy_Struct)e.Argument).Source_Folders, ((Copy_Struct)e.Argument).Destination_Folder);
                    }
                }
                else
                {
                    Drive_Worker.ReportProgress(0, Message_Status.ERROR_FORMATTING);
                }
            }

            catch (IOException)
            {
                Drive_Worker.ReportProgress(0, Message_Status.ERROR_MISSING_DRIVE);
                e.Cancel = true;
            }
        }


        private void Drive_Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            MessageStatus = (int)e.UserState;
            switch (e.UserState)
            {
                case Message_Status.IDEL:
                    Image_Control(Image_Control_Message.IDEL);
                    break;
                case Message_Status.FORMATTING:
                    Image_Control(Image_Control_Message.FORMATTING);
                    break;
                case Message_Status.COPYING:
                    Image_Control(Image_Control_Message.COPYING);
                    break;
                case Message_Status.COMPLETE:
                    Image_Control(Image_Control_Message.COMPLETE);
                    break;
                case Message_Status.ERROR_FORMATTING:
                   // MessageBox.Show("Error Formatting Drive", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Image_Control(Image_Control_Message.ERROR);
                    break;
                case Message_Status.ERROR_MISSING_DRIVE:
                    //MessageBox.Show(ErrorMsg);
                    Image_Control(Image_Control_Message.ERROR);
                    break;
                case Message_Status.ERROR_HASHING:
                    //MessageBox.Show("Please update the Hashes file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Image_Control(Image_Control_Message.ERROR);
                    break;
                case Message_Status.ERROR_CORRUPTED:
                   // MessageBox.Show("Please check the SD card connection.\nFiles was not being copied properly. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Image_Control(Image_Control_Message.ERROR);
                    break;
            }
        }

        private void Drive_Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        public void Dispose()
        {
            Drive_Worker.Dispose();
            Loading_pic.Dispose();
            Complete_pic.Dispose();
            Error_pic.Dispose();
            Loading_Status.Dispose();
            CheckSumTools.Dispose();
        }


        private void Image_Control(Image_Control_Message message)
        {
            switch (message)
            {
                case Image_Control_Message.IDEL:
                    Loading_pic.Visible = false;
                    Complete_pic.Visible = false;
                    Error_pic.Visible = false;
                break;

                case Image_Control_Message.FORMATTING://loading
                    Loading_Status.Text = "Formatting...";
                    Loading_pic.Visible = true;
                    Complete_pic.Visible = false;
                    Error_pic.Visible = false;
                    break;

                case Image_Control_Message.COPYING://loading
                    Loading_Status.Text = "Copying...";
                    Loading_Status.Visible = true;
                    Loading_pic.Visible = true;
                    Complete_pic.Visible = false;
                    Error_pic.Visible = false;
                    break;

                case Image_Control_Message.COMPLETE://complete
                    Loading_Status.Text = "Completed";
                    Loading_Status.Visible = true;
                    Loading_pic.Visible = false;
                    Complete_pic.Visible = true;
                    Error_pic.Visible = false;
                    break;

                case Image_Control_Message.ERROR://error
                    Loading_Status.Visible = false;
                    Loading_pic.Visible = false;
                    Complete_pic.Visible = false;
                    Error_pic.Visible = true;
                    break;

            }
        }

        public int Worker_Status()
        {
            return (MessageStatus);
        }

        public bool Worker_IsBusy()
        {
            return (Drive_Worker.IsBusy);
        }
    }
}
