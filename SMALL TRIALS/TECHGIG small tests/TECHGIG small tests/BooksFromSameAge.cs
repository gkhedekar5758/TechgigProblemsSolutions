using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TECHGIG_small_tests
{
    public static  class BooksFromSameAge
    {
        public static void Method()
        {
            /*
             * 1 - run thhorugh the SB and compare letter by letter to SA
             * 2 - 
             */
            string sa = "geek";
            string sb = "gesek";

            int a = 0;
            for (int i = 0; i < sb.Length; i++)
            {

            }


            int[] inputArray =new int[]{1,1,3,4,7,6,2,9,3,3,4 };
            int k = 2;
            //int a=inputArray
            Dictionary<int, int> occuranceInArray = new Dictionary<int, int>();
            Dictionary<int, List<int>> indexesOfNumber = new Dictionary<int, List<int>>();
            findOccurancesInArray(inputArray, occuranceInArray,indexesOfNumber);
            var Max = occuranceInArray.OrderBy(x => x.Value).Last();
           int res=  longestSubSeg(inputArray, inputArray.Length, k, Max.Key);
            //done with it
            occuranceInArray.Remove(Max.Key);
        }

        private static void findOccurancesInArray(int[] inputArray, Dictionary<int, int> occuranceInArray, Dictionary<int, List<int>> indexesOfNumber)
        {
            for (int i = 0; i < inputArray.Length; i++)
            {
                if (occuranceInArray.ContainsKey(inputArray[i]))
                {
                    occuranceInArray[inputArray[i]] += 1;
                    indexesOfNumber[inputArray[i]].Add(i);
                }
                    
                else
                {
                    occuranceInArray.Add(inputArray[i], 1);
                    indexesOfNumber.Add(inputArray[i], new List<int> { i });
                }
                    
            }
        }

        static int longestSubSeg(int[] a, int n,
                                      int k,int num)
        {


            int cnt0 = 0;
            int l = 0;
            int max_len = 0;

            // i decides current ending point
            for (int r = 0; r < n; r++)
            {
                if (a[r] !=num)
                    cnt0++;

                // If there are more 0's move
                // left point for current ending
                // point.
                while (cnt0 > k)
                {
                    if (a[l] != num)
                        cnt0--;
                    l++;
                }

                max_len = Math.Max(max_len, r - l + 1);
            }

            return max_len;
        }
    }
}
