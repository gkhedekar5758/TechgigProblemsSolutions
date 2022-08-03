using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayProblemsGFG
{
    public class LeetCodeJuly
    {
        public static void MasterMethod()
        {
            int n = 5;
            var ans = GrayCode(n);
            Console.WriteLine(ans);

            //two sum
            int[] nums = {3,2,4 };
            int target = 6;
            var answer = TwoSum(nums, target);

        }

        public static int[] TwoSum(int[] nums, int target)
        {
            int[] result = new int[2];
            Dictionary<int, int> valIndex = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!(valIndex.ContainsKey(target - nums[i])))
                    valIndex.Add(nums[i], i);
                else
                {
                    result[0] = valIndex[target - nums[i]];
                    result[1] = i;
                    break;
                }

            }

            return result;
        }
        public static List<long> GrayCode(int n)
        {
            // base case 
            if (n <= 0)
            {
                return null;
            }

            // 'arr' will store all generated codes 
            List<string> arr = new List<string>();

            // start with one-bit pattern 
            arr.Add("0");
            arr.Add("1");

            // Every iteration of this loop generates 2*i codes from previously 
            // generated i codes. 
            int i, j;
            for (i = 2; i < (1 << n); i = i << 1)
            {
                // Enter the prviously generated codes again in arr[] in reverse 
                // order. Nor arr[] has double number of codes. 
                for (j = i - 1; j >= 0; j--)
                {
                    arr.Add(arr[j]);
                }

                // append 0 to the first half 
                for (j = 0; j < i; j++)
                {
                    arr[j] = "0" + arr[j];
                }

                // append 1 to the second half 
                for (j = i; j < 2 * i; j++)
                {
                    arr[j] = "1" + arr[j];
                }
            }

            return ConvertArrayToIntAddToList(arr);

            //return arr;
        }

        private static List<long> ConvertArrayToIntAddToList(List<string> arr)
        {
            List<long> answer = new List<long>();
            foreach (var item in arr)
            {
                answer.Add(Convert.ToInt64(item, 2));
            }

            return answer;
        }

        private static void ConvertArrayToIntAddToList(ref int[] array, ref List<int> answer)
        {
            string binaryRepresentation = "";
            for (int index = 0; index < array.Length; index++)
            {
                binaryRepresentation += array[index].ToString();
            }
            answer.Add(Convert.ToInt16(binaryRepresentation, 2));
        }
    }
}
