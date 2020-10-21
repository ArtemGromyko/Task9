using System;

namespace Task9
{
    class Program
    {
        static void Main(string[] args)
        {
            AllFiles f = new AllFiles(@"D:\directory");
            f.DisplayFiles();
            f.ReadFile(0);
        }
    }
}
