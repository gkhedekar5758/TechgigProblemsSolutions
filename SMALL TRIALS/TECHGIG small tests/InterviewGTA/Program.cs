using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewGTA
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputData = "";
            string line;
            while ((line = Console.ReadLine()) != null)
            {
                inputData += line + "\n";
            }
            // Do not edit: Output solution to console
            Console.WriteLine(codeHere(inputData));
        }

        private static string codeHere(string inputData)
        {
            var values = inputData.Split(' ');
            int LowerBound = Convert.ToInt32(values[0]); 
            int UpperBound = Convert.ToInt32(values[1]);
            int firstNumber = 0;
            //find first number and then mulitply it with 5
            for (firstNumber = LowerBound; firstNumber <= UpperBound; firstNumber++)
            {
                if (firstNumber % 5 == 0) break;
            }

            StringBuilder finalResult = new StringBuilder();
            finalResult.Append(firstNumber.ToString()+" ");
            
            while(firstNumber +5 <= UpperBound && firstNumber!=0)
            {
                firstNumber += 5;
                finalResult.Append(firstNumber.ToString() + " ");
            }

            return finalResult.ToString();
        }
    }
}
