using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2_0016
{
    internal class Assignment_2
    {
        static void Main(string[] args)
        {
            List<(string, string, double)> studentDetails = new List<(string, string, double)>();

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Display Student Information");
                Console.WriteLine("3. Exit");
                Console.WriteLine();

                Console.Write("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        AddStudent(studentDetails);
                        break;
                    case 2:
                        DisplayStudentInformaton(studentDetails);
                        break;
                    case 3:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
                Console.WriteLine();
            }
        }

        static void AddStudent(List<(string, string, double)> studentDetails)
        {
            Console.WriteLine("Add Student");

            Console.Write("Enter name: ");
            string name = Console.ReadLine();

            Console.Write("Enter grade: ");
            string grade = Console.ReadLine();

            Console.Write("Enter fee amount paid: ");
            double feePaid = Convert.ToDouble(Console.ReadLine());

            studentDetails.Add((name, grade, feePaid));

            Console.WriteLine("Student details added");
        }

        static void DisplayStudentInformaton(List<(string, string, double)> studentDetails)
        {
            Console.WriteLine("Student Information");

            if (studentDetails.Count == 0)
            {
                Console.WriteLine("No student information found.");
            }
            else
            {
                foreach (var student in studentDetails)
                {
                    Console.WriteLine($"Name: {student.Item1}");
                    Console.WriteLine($"Grade: {student.Item2}");
                    Console.WriteLine($"Fee Paid: {student.Item3}");
                    Console.WriteLine();
                }
            }
        }
    }
}
