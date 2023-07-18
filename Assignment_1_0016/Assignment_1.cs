using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1_0016
{
    internal class Assignment_1
    {
        static void Main(string[] args)
        {
            List<(string, string, double, double, double)> studentScores = new List<(string, string, double, double, double)>
            {
                ("01", "Amit", 80, 90, 89),
                ("02", "Sumit", 88, 96, 99)
            };

            foreach (var student in studentScores)
            {
                string id = student.Item1;
                string name = student.Item2;
                double math = student.Item3;
                double eng = student.Item4;
                double scic = student.Item5;

                double avgScore = (math + eng + scic) / 3;
                string grade = GetGrade(avgScore);

                Console.WriteLine($"{id} \t {name} \t AverageScore: {avgScore} \t Grade: {grade}");
            }
            Console.ReadLine();
        }

        static string GetGrade(double avgScore)
        {
            if (avgScore >= 90)
                return "A";
            else if (avgScore >= 80)
                return "B";
            else if (avgScore >= 70)
                return "C";
            else if (avgScore >= 60)
                return "D";
            else
                return "F";
        }
    }
}