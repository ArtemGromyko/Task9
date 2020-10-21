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
            set 
            {
                path = value;
                if (Directory.Exists(path))
                    dirInfo = new DirectoryInfo(path);
                else
                    dirInfo = null;
            } 
        }
        public AllFiles(string p)
        {
            Path = p;
        }
        public void DisplayFiles()
        {
            if(dirInfo == null)
            {
                Console.WriteLine("There is no such directory");
                return;
            }
            int index = 0;
            foreach(FileInfo s in dirInfo.GetFiles())
                Console.WriteLine(index++ +": "+s.Name);
        }
        public void ReadFile(int index)
        {
            if (dirInfo == null)
            {
                Console.WriteLine("There is no such directory");
                return;
            }
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
            else
            {
                Console.WriteLine("invalid index");
            }
        }
    }
}
