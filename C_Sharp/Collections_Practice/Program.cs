using System;
using System.Collections.Generic;

namespace Collections_Practice
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Create an array to hold integer values 0 - 9
            int[] numArray = {0,1,2,3,4,5,6,7,8,9};
            for (int idx = 0; idx < numArray.Length; idx++)
            {
                Console.WriteLine(numArray[idx]);
            }
            
            //Create an array of the names "Tim", "Martin", "Nikki", & "Sara"
            string[] names = new string[4] {"Tim","Martin","Nikki","Sara"};
            for (int idx = 0; idx < names.Length; idx++)
            {
                Console.WriteLine(names[idx]);
            }
            
            //Create an array of length 10 that alternates between true & false values, starting with true
            string[] trueFalse = new string[10] {"True","False","True","False","True","False","True","False","True","False"};
            for (int idx = 0; idx < trueFalse.Length; idx++)
            {
                Console.WriteLine(trueFalse[idx]);
            }
            
            //With values 1-10, use code to generate a multiplication table (use multidimensional array)
            int [,] multiArray = new int[10,10];
            for (int x=1; x<=10; x++)
            {
                for (int y=1; y<=10; y++)
                {
                    multiArray[x-1,y-1] = x*y;
                }
                Console.WriteLine(multiArray);
            }

            int a=10;
            int b=3;
        
            //Create a list of Ice Cream Flavors that holds at least 5 different flavors
            //Output the length of the this list after building it
            //Output the 3rd flavor in the list, then remove this value
            //Output the new length of the list (Note it should be one less)
            List<string> flavors = new List<string>();
            flavors.Add("Chocolate");
            flavors.Add("Cookie Dough");
            flavors.Add("Moose Tracks");
            flavors.Add("Vanilla");
            flavors.Add("Peanut Butter Cup");
            flavors.Add("Mint Chocolate Chip");
            Console.WriteLine(flavors.Count);
            Console.WriteLine(flavors[2]);
            flavors.Remove(flavors[2]);
            Console.WriteLine(flavors.Count);

            //Create a dictionary that will store both string keys as well as string values
            //For each name in the array of names you made above, add it as a new key in this dict with value null
            //For each name key, select a random flavor from the flavor list & store it as the value
            //Loop through the dict & print out each user's name & associated ice cream flavor
            Dictionary<string,string> faveFlavors = new Dictionary<string,string>();
            Random rand = new Random();
            foreach(string name in names)
            {
                faveFlavors[name] = flavors[rand.Next(flavors.Count)];
            }
           
            foreach (KeyValuePair<string,string> entry in faveFlavors)
            {
                Console.WriteLine(entry.Key + " " + "-" + " " + entry.Value);
            }

        }
    }
}
