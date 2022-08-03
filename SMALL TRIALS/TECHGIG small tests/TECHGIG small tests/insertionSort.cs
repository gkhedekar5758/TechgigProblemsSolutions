using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TECHGIG_small_tests
{
    class insertionSort
    {
        /*
         * 1) keep the key at i=1 index item
         * 2) if key is less then the i=0 then swap it if not then do step 3
         * 3) shift the key to one more
         * 4) repeat step2
         * 
         * 
         * ============ techgig
         
            int keyIndex ;
            for (int index = 1; index < input.Length; index++)
            {
                keyIndex = input[index];
                int j = index - 1;
                while (j>=0&&input[j] <= keyIndex)
                {
                   // var temp = input[j];
                    input[j+1] = input[j];
                    j--;

                }
                input[j + 1] = keyIndex;// input[keyIndex];
                

            }

            *===================
         
         
         */

        public void method(ref int[] input)
        {
            int keyIndex;
            for (int index = 1; index < input.Length; index++)
            {
                keyIndex = input[index];
                int j = index - 1;
                while (j >= 0 && input[j] <= keyIndex)
                {
                    // var temp = input[j];
                    input[j + 1] = input[j];
                    j--;

                }
                input[j + 1] = keyIndex;// input[keyIndex];


            }
            //534612
            //int keyIndex =1;
            //for (int index = 1; index < input.Length; index++)
            //{
                
            //    int j = index - 1;

            //    while (j>=0&&input[j]<=input[j+1])
            //    {
            //        var swap = input[j];
            //        input[j] = input[j+1];
            //        input[j+1] = swap;
            //        j--;
            //    }
            //    //keyIndex++;

            //}

            
        }

    }
}
