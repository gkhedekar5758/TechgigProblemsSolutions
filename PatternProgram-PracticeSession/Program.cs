using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternProgram_PracticeSession
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Enter a number (1 <= n <= 1000) :");
            int userInput = Convert.ToInt32(Console.ReadLine());
           // drawPattern(userInput);
            drawPatternABCD(userInput);
            Console.ReadLine();
        }

        private static void drawPatternABCD(int userInput)
        {
            //for (int iteration = 0; iteration < userInput; iteration++)
            //{
                for (int row = 0; row < userInput; row++)
                {
                    for (int column = 0; column <= userInput*2; column++)
                    {
                        if(column<=row)
                            Console.Write(Convert.ToChar(column+65));
                      
                    }
                    Console.WriteLine();
                }

            //}
            
        }

        private static void drawPattern(int userInput)
        {
            for (int i = userInput; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write(i.ToString());
                    if (j != i) Console.Write("");
                }
                Console.Write(Environment.NewLine);
                //Console.Write("\n");
                //Console.WriteLine();
            }
        }
    }
}
