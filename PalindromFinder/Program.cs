using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalindromFinder
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] input1 = { 5,10 };
            int input2 = 2;
            Console.WriteLine(MaximizeTheProfit(input1, input2));
            Console.Read();
        }
        public static int MaximizeTheProfit(int[] input1,int input2)
        {
            
            int left = 0;
            int right = input1.Length ;
            int n = input1.Length + 1;
            return checkCombination(input1, left, right, n);
            
        }
        public static int checkCombination(int[] input1, int left, int right,int n)
        {
            int finalValue = 0;
            for (int i = left + 1; i < right; i++)
            {
                int value = checkCombination(input1, left,i,n) + checkCombination(input1, i,right,n);
                //int value = checkCombination(input1, left, right, n)

                if (left == 0 && right == n)
                    value = value + input1[i];
                else
                    value = value + (input1[left] * input1[i] * input1[right-1]);

                if (value > finalValue)
                    finalValue = value;

            }
            return finalValue;
        }
    }
}
