﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwaitDemo
{
    internal class Program
    {
        static void Main()
        {
            CallingDB();
            APICall();
            FileRead();
            Console.ReadKey();

        }
        public static async Task CallingDB()
        {
            await Task.Run(() =>
            {

                Console.WriteLine("I am DB");
            });
        }

        public static async Task APICall()
        {
            await Task.Run(() =>
            {

                Console.WriteLine("I am APICALL");
            });
        }
        public static async Task FileRead()
        {
            await Task.Run(() =>
            {

                Console.WriteLine("I am File Read");
            });
        }

    }
}