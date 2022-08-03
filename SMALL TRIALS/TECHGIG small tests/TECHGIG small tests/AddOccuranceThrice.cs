using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TECHGIG_small_tests
{
    class AddOccuranceThrice
    {

        public int method()
        {

            int lengthArray = Convert.ToInt32(Console.ReadLine());
            string strArray = Console.ReadLine();
            string[] st = strArray.Split(' ');
            int[] intArray = new int[lengthArray];
            for (int i = 0; i < intArray.Length; i++)
            {
                intArray[i] = Convert.ToInt32(st[i]);
                
            }
            for (int i = 0; i < intArray.Length-2; i++)
            {
                
            }

            return 0;
        }
    }
}
