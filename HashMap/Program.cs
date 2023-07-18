using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashMap
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1.

            //ArrayList arrayList = new ArrayList();
            ////Console.WriteLine(arrayList.Capacity);
            //arrayList.Add(1);
            //arrayList.Add(2);
            //arrayList.Add(3);
            ////Console.WriteLine(arrayList.Capacity);
            //arrayList.Add(4);
            //arrayList.Add(6);
            //arrayList.Add("Atul");
            //arrayList.Add(7);
            //arrayList.Insert(3, 55);


            ////arrayList.RemoveAt(0);
            ////arrayList.Remove(5);
            //foreach(object i in arrayList)
            //{
            //    Console.WriteLine(i);
            //}
            ////Console.WriteLine(arrayList.Capacity);
            //Console.ReadKey(); 

            //2.

            Hashtable ht = new Hashtable();
            ht.Add("Name", "SUMIT KUMAR");
            ht.Add("Age", "23");
            ht.Add("City", "Patna");
            ht.Add("Gender", "Male");
            ht.Add(5, 345);

            foreach (object key in ht.Keys)
            {
                Console.WriteLine($"{key} \t {ht[key]}");
                //Console.WriteLine(key.GetHashCode());
            }
            Console.ReadKey();
        }
    }
}