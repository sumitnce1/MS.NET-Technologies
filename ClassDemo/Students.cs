using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace Day_2
    {
        internal class Student
        {
            public string Studentname;
            public string MobileNo;
            public int Age;
            public string Course;
            public double Fees;


            public void TakeInput()
            {
                Console.Write("Enter your name : ");
                Studentname = Console.ReadLine();

                Console.Write("Enter your mobile number : ");
                MobileNo = Console.ReadLine();

                Console.Write("Enter your course : ");
                Course = Console.ReadLine();

                Console.Write("Enter age : ");
                Age = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter fees : ");
                Fees = Convert.ToDouble(Console.ReadLine());
            }

            public void Printdata()
            {
                Console.WriteLine("-------------------");
                Console.WriteLine("Student's Name : " + Studentname);
                Console.WriteLine("Student's Mobile no : " + MobileNo);
                Console.WriteLine("Student's Age : " + Age);
                Console.WriteLine("Course's Name : " + Course);
                Console.WriteLine("Total Fees : " + Fees);

            }
        }
    }