using System;
using System.Collections.Generic;
using System.Linq;

namespace Puzzles
{
    public class Program
    {
        public static int[] RandomArray(){
            Random rand = new Random();
            int [] randArr = new int[10];
            int sum = 0;
            for(int i=0; i < randArr.Length; i++){
                int num = rand.Next(5,26);
                randArr[i] = num;
                sum += num;
            }
            Console.WriteLine("Max number is:" + " " + randArr.Max());
            Console.WriteLine("Min number is:" + " " +  randArr.Min());
            Console.WriteLine("Sum is:" + " " + sum);
            return randArr;
        }

        public static string TossCoin(Random rand){
            Console.WriteLine("Tossing a Coin!");
            string outcome = "Tails";
            if(rand.Next() == 0){
                outcome = "Heads";
            }
            Console.WriteLine(outcome);
            return outcome;
        }

        public static Double TossMultipleCoins(int num){
            int numHeads = 0;
            for(int y = 0; y < num; y++){
                if(TossCoin(new Random()) == "Heads"){
                    numHeads++;
                }
            }
            return numHeads/num;
        }

        public static string[] Names(){
            string[] names = new string[] {"Todd","Tiffany","Charlie","Geneva","Sydeny"};
            Random rand = new Random();
            for(var x = 0; x < names.Length-1; x++){
                int randX = rand.Next(x+1, names.Length -1);
                string temp = names[x];
                names[x] = names[randX];
                names[randX] = temp;
                Console.WriteLine(names[x]);
            }
            Console.WriteLine(names[names.Length-1]);

            List<string> namesList = new List<string>();
            foreach(var name in names){
                namesList.Add(name);
            }
            return namesList.ToArray();
        }

        public static void Main(string[] args)
        {
            RandomArray();
            TossMultipleCoins(6);
            Names();
        }
    }
}
