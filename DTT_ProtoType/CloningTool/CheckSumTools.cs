﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace CloningTool
{

    public class CheckSumTools : IDisposable
    {
        private string CheckSumFile;
        public struct HashElements
        {
            public string path, hashCode;
        }
        public struct HashFileElements
        {
            public int lengthOfData;
            public HashElements[] data;
        }

        public CheckSumTools(string i_CheckSumFile)
        {
            CheckSumFile = i_CheckSumFile;
        }


/*        private string [] CheckSumArray (string CheckSumFile)
        { 
            // this function returns all the checksum list from the INI file
            string CheckSum_Text = File.ReadAllText(CheckSumFile); 
            string[] hashCode = CheckSum_Text.Split(new[] { "\r\n", "\r", "\n" },StringSplitOptions.None);
            return (hashCode);
        }
*/
        private string[] CheckSumArray()
        {
           var temp= GettingHashFileElements();
            
            // this function returns all the checksum list from the INI file
            string[] hashCode = new string[temp.lengthOfData];
            for (int i = 0; i < temp.lengthOfData ; i++)
            {
                hashCode[i]= temp.data[i].hashCode;
            }
            return (hashCode);
        }


        public string CheckSum_From_File(string file_path)
        {
            string msg = "";
            try
            {
                // this function returns the checksum of a single file
                FileInfo fi = new FileInfo(file_path);
                FileStream fs = new FileStream(file_path, FileMode.Open, FileAccess.Read);
                BinaryReader readBin = new BinaryReader(fs);
                byte[] data = readBin.ReadBytes((int)fi.Length);
                SHA1 sha1 = new SHA1CryptoServiceProvider();
                byte[] result = sha1.ComputeHash(data);
                
                foreach (byte d in result)
                {
                    msg = msg + d.ToString("x");
                }

                fs.Close();
                return msg;
            }
            catch(ArgumentNullException)
            {
                return msg;
            }
        }


        public bool Check_Valid_CheckSum(string file_path)
        {
            //this function checks if the file has a valid checksum and located in the INI file
            bool Is_Valid_CheckSum = false;
            try
            {

                string File_CheckSum = CheckSum_From_File(file_path);
                string[] Checksum_Array = CheckSumArray();

                foreach (string CheckSum_string in Checksum_Array)
                {
                    if (File_CheckSum == CheckSum_string)
                    {
                        Is_Valid_CheckSum = true;
                    }
                }

                return (Is_Valid_CheckSum);
            }
            catch(IOException)
            {
                return (Is_Valid_CheckSum);
            }
            
        }


        public bool Check_Valid_CheckSum_Folders(string[] Files_A, string[] Files_B)
        {
            // this function checks if the two file list have exactly the same files 
            bool Is_Match = true;

            if (Files_A.Length == Files_B.Length)
            {
                string[] Files_A_CheckSum_List = new string[Files_A.Length];
                string[] Files_B_CheckSum_List = new string[Files_A.Length];

                for (int i = 0; i < Files_A.Length; i++)
                {
                    Files_A_CheckSum_List[i] = CheckSum_From_File(Files_A[i]);
                    Files_B_CheckSum_List[i] = CheckSum_From_File(Files_B[i]);
                }
                Array.Sort(Files_A_CheckSum_List);
                Array.Sort(Files_B_CheckSum_List);

                for (int i = 0; i < Files_A_CheckSum_List.Length; i++)
                {
                    if (Files_A_CheckSum_List[i] != Files_B_CheckSum_List[i]) Is_Match = false;
                }

            }
            else return false;

            return Is_Match;
        }

        public HashFileElements GettingHashFileElements()
        {
            string HashFile = CheckSumFile;

            var text = File.ReadAllText(HashFile);
            if (text.EndsWith(Environment.NewLine)) File.WriteAllText(HashFile, text.TrimEnd(Environment.NewLine.ToCharArray())); // Removes ALL CR/LF from the end!

            text = File.ReadAllText(HashFile);
            string[] enter = text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            int number_of_elements = enter.Length;
            HashFileElements values = new HashFileElements();
            values.lengthOfData = number_of_elements;
            values.data = new HashElements[values.lengthOfData];

            for (int i = 0; i < values.lengthOfData; i++)
            {
                try
                {
                    string[] element = enter[i].Split('\t');
                    values.data[i].path = element[0];
                    values.data[i].hashCode = element[1];
                }
                catch(IndexOutOfRangeException)
                {
                    MessageBox.Show("Missing content in Hashes File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(0);
                }
                
               /* if (string.IsNullOrEmpty(values.data[i].path)
                   || string.IsNullOrEmpty(values.data[i].hashCode))
                {
                    
                }*/
            }
            return values;
        }
        public void Dispose()
        {
        }
    }
}
