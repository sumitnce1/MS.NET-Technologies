using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Session9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            (string, int, double) GetDetails() //tubple As method/function
            {


            }
            // Deconstruct Tuple
            var person = (name: "SUMIT", age: 30, city: "PATNA");
            Console.WriteLine(person.name);
            Console.WriteLine(person.age);
            Console.WriteLine(person.city);

            // Deconstruct tuple
            var (name, age, city) = person;
            Console.WriteLine(name);
            Console.WriteLine(age);
            Console.WriteLine(city);

            var details = GetDetails();
            Console.WriteLine(details.Item1);
            Console.WriteLine(details.Item2);
            Console.WriteLine(details.Item3);

            Console.ReadKey();
        }
    }
}
