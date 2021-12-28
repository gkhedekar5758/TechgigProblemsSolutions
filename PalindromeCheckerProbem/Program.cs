using System;
using System.Collections.Generic;

namespace PalindromeCheckerProbem
{
    class Program
    {
        static int finalResult = 0;
        static void Main(string[] args)
        {
            int input1 = Convert.ToInt16(Console.ReadLine());
            string input2 = Console.ReadLine();

            finalResult = CountThePalindromes(input1, input2);
            Console.WriteLine(finalResult);
            Console.ReadLine();

        }

        private static int CountThePalindromes(int input1, string input2)
        {
            List<char> separateChar = new List<char>();

            //get the unique characters
            for (int i = 0; i < input2.Length; i++)
            {
                if (!separateChar.Contains(Convert.ToChar(input2.Substring(i, 1))))
                    separateChar.Add(Convert.ToChar(input2.Substring(i, 1)));
            }
            finalResult += separateChar.Count;  // single character

            List<string> uniquePalindormes = new List<string>();

            int lenthOfSStr = 2;
            while (input1 - lenthOfSStr != 0)
            {
                for (int i = 0; i < input1 - lenthOfSStr; i++)
                {

                    if (checkIfPalindrom(input2.Substring(i, lenthOfSStr))) { 
                    if (!uniquePalindormes.Contains(input2.Substring(i, lenthOfSStr))) {
                        uniquePalindormes.Add(input2.Substring(i, lenthOfSStr));
                    }
                    }


                }
                lenthOfSStr++;

            }
            finalResult += uniquePalindormes.Count;
            return finalResult;
            
        }

        private static bool checkIfPalindrom(string v)
        {
            char[] tempCharArr = v.ToCharArray();
            char[] tempCharArr1 = v.ToCharArray();
            Array.Reverse(tempCharArr);
            if (new string(tempCharArr) == new string(tempCharArr1)) return true;
            return false;
        }
    }
}
