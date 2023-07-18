using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session9_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double basicSalary = 50000;
            var result = CalculateSalary(basicSalary);

            double ta = result.ta;
            double da = result.da;
            double hra = result.hra;
            double total = result.total;
            double sal = result.sal;

            Console.WriteLine("Total Salary is: " + sal);
            Console.ReadKey();
        }

        public static (double ta, double da, double hra, double total, double sal) CalculateSalary(double bs)
        {
            double ta = bs * 0.15;
            double da = bs * 0.10;
            double hra = bs * 0.20;
            double total = ta + da + hra;
            double sal = bs + total;

            return (ta, da, hra, total, sal);
        }
    }
}
