using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // classname classname = new classname();

            Student student = new Student();
            student.TakeInput();
            student.Printdata();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}