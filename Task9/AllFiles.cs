using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Task9
{
    class AllFiles
    {
        private DirectoryInfo dirInfo;
        private string path;
        public string Path
        { 
            get { return path; } 
            set { path = value; dirInfo = new DirectoryInfo(path); } 
        }
        public AllFiles(string p)
        {
            Path = p;
            dirInfo = new DirectoryInfo(path);
        }
        public void DisplayFiles()
        {
            int index = 0;
            foreach(FileInfo s in dirInfo.GetFiles())
                Console.WriteLine(index+++": "+s.Name);
        }
        public void ReadFile(int index)
        {
            string[] files = Directory.GetFiles(path);
            if(index >= 0 && index < files.Length)
            {
                using (FileStream fl = File.OpenRead(files[index]))
                {
                    byte[] arr = new byte[fl.Length];
                    fl.Read(arr, 0, arr.Length);
                    string text = Encoding.Default.GetString(arr);
                    Console.WriteLine("\ntext:\n\n" + text);
                }
            }
            
        }
    }
}
