using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TECHGIG_small_tests
{
    class RangeOfNumbers
    {
        int lengthOfArray = Convert.ToInt32(Console.ReadLine());
        string uInput = Console.ReadLine();
        int count = 0;
       public int method(){

            string[] nos = uInput.Split(' ');
            int[] noArray = new int[nos.Length];
            for (int i = 0; i < noArray.Length; i++)
            {
                noArray[i] = Convert.ToInt32(nos[i]);
                
            }

            foreach (var item in noArray)
            {
                if(item>100 & item<2000 & item%2==0) count+=1;
               
            }
            return count;
        }
        
    }
}


//MIAN
//int lengthOfArray = Convert.ToInt32(Console.ReadLine());
//string uInput = Console.ReadLine();
//int count = 0;
//string[] nos = uInput.Split(' ');
//int[] noArray = new int[nos.Length];
//for (int i = 0; i < noArray.Length; i++)
//{
//    noArray[i] = Convert.ToInt32(nos[i]);

//}

//foreach (var item in noArray)
//{
//    if (item > 100 & item < 2000 & item % 2 == 0) count += 1;

//}
//Console.WriteLine(count);

