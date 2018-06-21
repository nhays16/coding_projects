using System;
using System.Collections.Generic;
using System.Linq;

namespace Basic13
{
    public class Program
    {
        public static void Print_1to255(){
            for (int i=1; i<=255; i++){
                Console.WriteLine(i);
            }
        }

        public static void PrintOddNum(){
            for (int i=1; i<=255; i++){
                if (i%2 == 1){
                    Console.WriteLine(i);
                }
            }
        }
        
        public static void PrintSum(){
            int sum = 0;
            for (int i=0; i<=255; i++){
                sum += i;
                Console.WriteLine("New Number:" + " " + i + " " + "Sum:" + " " + sum);
            }
        }

        public static void IterateArray(int[] arr){
            string output = "[";
            for (int idx=0; idx < arr.Length; idx++){
                output += arr[idx] + ",";
            }
            output += "]";
            Console.WriteLine(output);
        }

        public static void MaxArray(int[] arr){
            int max = arr[0];
            foreach (int i in arr){
                if(i > max){
                    max = i;
                }
            }
            Console.WriteLine(max);
        }

        public static void ArrayAvg(int[] arr){
            int sum = 0;
            for(int i=0; i<arr.Length; i++){
                sum += arr[i];
            }
            int avg = sum/arr.Length;
            Console.WriteLine(avg);
        }

        public static int[] OddArray(){
            List<int> oddList = new List<int>();
            for (int i =1; i<=255; i++){
                if (i%2 == 1){
                    oddList.Add(i);
                }
            }
            return oddList.ToArray();  
        }

        public static void GreaterThan(int[] arr, int y){
            int total = 0;
            for(int idx = 0; idx < arr.Length; idx ++){
                if (arr[idx] > y){
                    total += 1;
                }
            }
            Console.WriteLine(total);
        }
            
        public static void SquareArray(int[] arr){
            for (int idx = 0; idx < arr.Length; idx++)
            {
                arr[idx] *= arr[idx];
            }
            Console.WriteLine(arr);
        }
            
        public static void EliminateNegNum(int[] arr){
            for (int idx = 0; idx < arr.Length; idx++){
                if (arr[idx] < 0 ){
                    arr[idx] = 0;
                }
            }
            Console.WriteLine(arr);
        }

        public static void MinMaxAvg(int[] arr){
            int sum = 0;
            int min = arr[0];
            int max = arr[0];
            foreach (int num in arr){
                sum += num;
                if(num < min){
                    min = num;
                }
                if(num > max){
                    max = num;
                }
            }
            int avg = sum/arr.Length;
            Console.WriteLine("Max:" + " " + max + "Min:" + " " + min + "Average:" + " " + avg);
        }

        public static void Shift(int[] arr){
            for (int idx = 0; idx < arr.Length; idx++){
                arr[idx] = arr[idx+1];
            }
            arr[arr.Length-1] = 0;
            Console.WriteLine(arr);
        }

        public static object[] NumToStr(object[] arr){
            for (int idx = 0; idx < arr.Length; idx++){
                if ((int)arr[idx] < 0){
                    arr[idx] = "Dojo";
                }
            }
            return arr;
        }

        public static void Main(string[] args){
            Print_1to255();
            PrintOddNum();
            PrintSum();
            int[] newArr = new int[8] {1,3,-5,7,-10,8,-6,4};
            IterateArray(newArr);
            MaxArray(newArr);
            ArrayAvg(newArr);
            OddArray();
            GreaterThan(newArr,2);
            SquareArray(newArr);
            EliminateNegNum(newArr);
            MinMaxAvg(newArr);
            Shift(newArr);
            object[] objArr = new object[] {-2,12,-8,25};
            NumToStr(objArr);
        }
    }
}
