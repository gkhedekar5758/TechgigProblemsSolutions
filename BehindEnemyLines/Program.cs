using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace BehindEnemyLines
{

    // Not solved
    class Program
    {
        static void Main(string[] args)
        {
            int input1 = Convert.ToInt32( Console.ReadLine());
            int input2 = Convert.ToInt32(Console.ReadLine());
            string input3 = Console.ReadLine();
            string input4 = Console.ReadLine();

            Console.WriteLine(new Program().FindTheString(input1,input2,input3,input4));
        }

        int FindTheString(int input1,int input2,string input3,string input4)
        {
            Regex.Matches(input4, input3).Count;

            return 0;
        }
    }
}
