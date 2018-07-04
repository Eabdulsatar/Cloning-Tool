using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTT_ProtoType
{
    class Program
    {
        static void Main(string[] args)
        {
 /*          string fileName = "123.txt";
            string sourcePath = @"C:\Users\ahmeha\source\repos\DTT_ProtoType\";
            string targetPath = @"D:\";
            string sourceFile = Path.Combine(sourcePath, fileName);
            string destFile = Path.Combine(targetPath, fileName);
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            
            // To copy a folder's contents to a new location:
            // Create a new target folder, if necessary.
            if (!Directory.Exists(targetPath))
            {
                Directory.CreateDirectory(targetPath);
            }

            // To copy a file to another location and 
            // overwrite the destination file if it already exists.
            File.Copy(sourceFile, destFile, true);

            foreach (DriveInfo d in allDrives)
            {
                
                Console.WriteLine("Drive {0}", d.Name);
                Console.WriteLine("  Drive type: {0}", d.DriveType);
                if (d.IsReady == true)
                {
                    Console.WriteLine("  Volume label: {0}", d.VolumeLabel);
                    Console.WriteLine("  File system: {0}", d.DriveFormat);
                    Console.WriteLine(
                        "  Available space to current user:{0, 15} bytes",
                        d.AvailableFreeSpace);

                    Console.WriteLine(
                        "  Total available space:          {0, 15} bytes",
                        d.TotalFreeSpace);

                    Console.WriteLine(
                        "  Total size of drive:            {0, 15} bytes ",
                        d.TotalSize);
                    if (d.Name == @"D:\")
                    {
                        //string DriveTotalSize = "Total size of drive:" + d.TotalSize.ToString();
                       // File.WriteAllText(@"C:\Users\ahmeha\source\repos\DTT_ProtoType\test.txt", DriveTotalSize);

                        string root = File.ReadAllText(@"C:\Users\ahmeha\source\repos\DTT_ProtoType\test.txt"); 
                        string root2 = File.ReadAllText(@"C:\Users\ahmeha\source\repos\DTT_ProtoType\test2.txt"); 
                        var temp= root.Remove(0,20);
                        var temp2 = root2.Remove(0,5);
                        Console.WriteLine(temp);
                        Console.WriteLine(temp2);
                        //string root3 = File.ReadAllText(@"");
                        string path = @"D:\testt.txt";
                        string createText = "Hello and Welcome" + Environment.NewLine;
                        File.WriteAllText(path, createText);
                        if (temp == temp2)
                        {
                            Console.WriteLine("true");
                            //Process process = Process.Start(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe");
                            //File.Open(@"D:\chrome.exe", FileMode.Open);
                        }
                        else
                            Console.WriteLine("false");
                    }
                }
            }
            Console.ReadLine(); 
            */
        }
       
    }
}
