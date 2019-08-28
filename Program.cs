using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace GraBook
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\windows";
            //ShowLargeFilesWithoutLinq(path);
            ShowLargeFilesWithLinq(path);
        }

        private static void ShowLargeFilesWithLinq(string path)
        {
            var query = from file in new DirectoryInfo(path).GetFiles()
                        orderby file.Length descending
                        select file;
                        
            foreach (var F in query.Take(5))
            {
              Console.WriteLine(F.Name + " : " + F.Length + " : " + F.LastAccessTime);
                //Console.WriteLine("$ {F.Name} : {F.Length} : {F.LastAccessTime}");
            }


        }

        private static void ShowLargeFilesWithoutLinq(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            FileInfo[] files = directory.GetFiles();

            Array.Sort(files, new FileInfoComparer());
            foreach (FileInfo F in files)
            {
              Console.WriteLine(F.Name + " : " + F.Length + " : " + F.LastAccessTime);
                //Console.WriteLine("$ {F.Name} : {F.Length} : {F.LastAccessTime}");
            }


        }

    }
    public class FileInfoComparer : IComparer<FileInfo>
    {

        public int Compare(FileInfo x, FileInfo y)
        {
            return y.Length.CompareTo(x.Length);
        }
    }
}
