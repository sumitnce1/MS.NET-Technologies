using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleIO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*---------File Path--------------*/
            /*string filepath = @"C:\Users\User\Documents\DECELE\test.txt";
            File.WriteAllText(filepath, "Hello World Ram kumar");

            FileInfo fileInfo = new FileInfo(filepath);
            Console.WriteLine(fileInfo.FullName);
            Console.WriteLine(fileInfo.Exists);
            Console.WriteLine(fileInfo.Length);
            Console.WriteLine(fileInfo.CreationTime);
            Console.WriteLine(fileInfo.LastWriteTime);*/
            //fileInfo.Delete();
            //Console.WriteLine(fileInfo.LastWriteTimeUtc);

            /*
                        bool fileExists = File.Exists(filepath);
                        Console.WriteLine("File Exists: " + fileExists);

                        string fileContent = File.ReadAllText(filepath);
                        Console.WriteLine(fileContent);

                        File.Delete(filepath);*/
            //Console.ReadKey();

            /*---------Folder Path--------------*/

            /*string folderpath = @"D:\DotNet\1920";
            Directory.CreateDirectory(folderpath);
            Console.WriteLine(Directory.Exists(folderpath));

            string[] files = Directory.GetFiles(folderpath);
            Console.WriteLine("Files is Directory");
            foreach (string file in files)
            {
                Console.WriteLine(file);
            }
            Directory.Exists(folderpath);
            DirectoryInfo directoryInfo = new DirectoryInfo(folderpath);

            if (directoryInfo.Exists)
            {
                FileInfo[] fileInfos = directoryInfo.GetFiles();
                foreach (FileInfo fileInfo in fileInfos)
                {
                    Console.WriteLine($"{fileInfo.Name}: {fileInfo.CreationTime} : {fileInfo.Extension}");
                }
            }
            //Directory.Delete(folderpath,true);
            Console.ReadKey();*/


            /*---------FileStream Path--------------*/
            string filepath = @"D:\DotNet\1920\Sample.txt";
            FileStream fileStream = new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            string datatowriter = "Hello From FileStream";
            byte[] Bytowrite = System.Text.Encoding.UTF8.GetBytes(datatowriter);
            fileStream.Write(Bytowrite,0,Bytowrite.Length);
            fileStream.Seek(0, SeekOrigin.Begin);
            
            byte[] bytestored = new byte[fileStream.Length];
            fileStream.Read(bytestored, 0, bytestored.Length);
            string datered = System.Text.Encoding.UTF8.GetString(bytestored);
            Console.WriteLine(datered);
            fileStream.Close();

            Console.ReadKey();

        }
    }
}
