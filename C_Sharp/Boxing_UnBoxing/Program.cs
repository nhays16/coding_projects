using System;
using System.Collections.Generic;

namespace Boxing_UnBoxing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<object> boxed = new List<object>();
            boxed.Add(7);
            boxed.Add(28);
            boxed.Add(-1);
            boxed.Add(true);
            boxed.Add("chair");

            int sum = 0;

            foreach (var item in boxed)
            {
                if (item is int) {
                    Console.WriteLine(item + " " + "is an int");
                    sum += (int)item;
                }
                if (item is string){
                    Console.WriteLine(item + " " + "is a string");
                }
                if (item is bool){
                    Console.WriteLine(item + " " + "is a bool");
                }

            }
            Console.WriteLine("The sum of the integers is" + " " + sum);
        }
    }
}
