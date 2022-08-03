using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TECHGIG_small_tests
{
    public static class ArraySplit
    {
        public static void method()
        {
            int[] arr = new int[] { 1, 2,3,4 };
            Array.Sort(arr);
            int middleIndex = arr.Length / 2;
            int leftSum = 0;
            int rightSum=0;
            for (int i = 0; i < middleIndex; i++)
            {
                leftSum += arr[i];
            }
            for (int i = middleIndex; i < arr.Length; i++)
            {
                rightSum += arr[i];
            }

            checkIfSubsetExist(leftSum, rightSum, middleIndex, arr);

        }

        private static bool checkIfSubsetExist(int leftSum, int rightSum, int middleIndex, int[] arr)
        {
            if (leftSum == rightSum) return true;

            while(leftSum < rightSum)
            {
                middleIndex++;
                leftSum += arr[middleIndex-1];
                rightSum -= arr[middleIndex-1];

                if (leftSum == rightSum) return true;
            }
            return false;
        }
    }
}
