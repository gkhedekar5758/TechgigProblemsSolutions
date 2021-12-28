using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BhopalJailBreak
{
    //solved
    class Program
    {
        static void Main(string[] args)
        {
            // take the input
            int abilityToJump = Convert.ToInt32(Console.ReadLine());
            int slipHeight = Convert.ToInt32(Console.ReadLine());
            int noOfWalls = Convert.ToInt32(Console.ReadLine());
            int[] heightsOfWall = new int[noOfWalls];

            for (int i = 0; i < noOfWalls; i++)
            {
                heightsOfWall[i] = Convert.ToInt32(Console.ReadLine());

            }

            MainLogic mj = new MainLogic();
            int finalAnswer = mj.MethodOne(abilityToJump, slipHeight, heightsOfWall);
            Console.WriteLine("answer "+finalAnswer);
            Console.ReadLine();
        }
    }
}
