using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace palindrom
{
    /*
     * Given an array arr[] and size of array is n and one another key x, and give you a segment size k. 
     * The task is to find that the key x present in every segment of size k in arr[].
     * */
    public class ArrayProblem1 
    {
        public static void method()
        {
            
            
            int[] arr = { 21, 23, 56, 65, 34, 54, 76, 32, 23, 45, 21, 23, 25 };
            int x = 23;
            int k = 5;

            Console.WriteLine(checkIfPresentInEverySegment(arr, arr.Length, x, k));

            //sort the array with all 0 all 1 and all2
            int[] arr1 = { 0, 1, 1, 0, 1, 2, 1, 2, 0, 0, 0, 1 };
            dutchNationalFlag(arr1);

            //find the kth minimum number
            int[] arr2 = {7, 10, 4, 3, 20, 15};
            int kk = 3;
            findKthMinimum(arr2,kk);

            //find all the number of pairs with given sum in array
            int[] arr3 = { 1, 1, 1, 1 };
            int sum = 2;
            int res=findNumberOfPairs(arr3, sum);

            //rotate the array with given degree
            int[] arr4 = { 1, 2, 3, 4, 5 };
            int degree = 3;
            rotateCyclic(arr4, degree);
            //Given an array of n elements that contains elements from 0 to n-1, with any of these numbers
            //appearing any number of times. Find these repeating numbers in O(n) and using only constant
            //memory space.

            int[] arr5 = { 1, 2, 3, 6, 3, 6, 1 };
            int n = 7;
            findNumberOfRepeats(arr5, n);

            //Given three arrays sorted in non-decreasing order, print all common elements in these arrays.
            int[] ar1 = {1 , 5, 10, 20, 40, 80 };
            int[] ar2 = { 6, 7, 20, 80, 100 };
            int[] ar3 = { 3, 4, 15, 20, 30, 70, 80, 120 };

            findCommonNumber(ar1, ar2, ar3);

            //Find the first non-repeating element in a given array of integers.
            int[] arr6 = { 9, 4, 9, 6, 7, 4 };
            findFirstNonRepeating(arr6);

            //Given an array with all distinct elements, find the largest three elements.
            //Expected time complexity is O(n) and extra space is O(1). 
            int[] arr7 = { 10, 4, 3, 50, 23, 90 };
            FindLargestThree(arr7);

            //Rearrange array in alternating positive & negative items with O(1) extra space | Set 1
            int[] arr8 = {7,3,5,-1,-2 };
            RearrangeArray(arr8);

            //Given an array of positive and negative numbers,
            //find if there is a subarray (of size at-least one) with 0 sum.
            int[] arr9 = { 3, 2, 3, 1, 6 };
            Console.WriteLine( findIfSubArraywith0sum(arr9));

            //Given an array of N elements. The task is to find the length
            //of the longest subarray such that sum of the subarray is even.
            int[] arr10 = { 1, 2, 3, 2, 1, 4 };
            Console.WriteLine(FindLengthOfSubArrayWithEvenSum(arr10));

            //Write an efficient program to find the sum of contiguous subarray
            //within a one-dimensional array of numbers that has the largest sum. 
            int[] arr11 = { -2, -3, 4, -1, -2, 1, 5, -3 };
            Console.WriteLine(FindTheLargestSumOfSubArray(arr11));

            //Given an array that contains both positive and negative integers,
            //find the product of the maximum product subarray. Expected Time complexity is
            //O(n) and only O(1) extra space can be used.
            int[] arr12 = { 6, -3, -10, 0, 2 };
            Console.WriteLine(FindTheLargestProductOfSubArray(arr12));





            int[] arr13 = { 12, 11, -13, -5, 6, -7, 5, -3, -6 };
            RearrangeArra(arr13, 0, arr13.Length - 1);
            ReverseArray(arr13, 5, arr13.Length - 1);
        }

        private static int FindTheLargestProductOfSubArray(int[] a)
        {
            int localMax = a[0];
            int globalMax = a[0];

            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] == 0) break;
                localMax = Math.Max(a[i], localMax * a[i]);

                if (localMax > globalMax)
                    globalMax = localMax;
            }
            return globalMax;
        }

        private static int FindTheLargestSumOfSubArray(int[] a)
        {
            int localMax = a[0];
            int globalMax = a[0];

            for (int i = 0; i < a.Length; i++)
            {
                localMax = Math.Max(a[i], localMax + a[i]);

                if (localMax > globalMax)
                    globalMax = localMax;
            }
            return globalMax;
        }

        private static int FindLengthOfSubArrayWithEvenSum(int[] arr)
        {
            int res = -1;
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            if (sum % 2 == 0) return arr.Length;
            else
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] % 2 != 0)
                    {
                        res = Math.Max(res, Math.Max(i, arr.Length - i - 1));
                    }
                }
            }
            return res;

        }   
            //HashSet
        

        private static bool findIfSubArraywith0sum(int[] arr)
        {
            #region O(N^2) solution

            int sum = -1;
            bool found = false;
            for (int i = 0; i < arr.Length; i++)
            {
                if(sum==0)
                {
                    found = true;
                    break;
                }
                if (found) break;
                found = false;
                sum = arr[i];
                if (!found)
                {
                    for (int j = i + 1; j < arr.Length; j++)
                    {
                        if (sum == 0)
                        {
                            found = true;
                            break;
                        }
                        sum += arr[j];

                    } 
                }
            }
            return found;
            #endregion
        }

        private static void RearrangeArray(int[] arr)
        {
            #region myTry
            /* int outOfPlace = -1;

             for (int index = 0; index < arr.Length; index++)
             {
                 if(outOfPlace >= 0)
                 {
                     if((arr[index]>=0 && arr[outOfPlace] <0) || (arr[index]<0 && arr[outOfPlace] >= 0))
                     {
                         rightRotate(arr, arr.Length, outOfPlace, index);
                     }
                     if (index - outOfPlace > 2)
                         outOfPlace += 2;
                     else
                         outOfPlace = -1;
                 }
                 if (outOfPlace == -1)
                 {
                     if ((arr[index] >=0 && ((index & 0x01) == 0)) || ((arr[index]<0) && ((index & 0x01)==1)))
                     {
                         outOfPlace = index;
                     }
                 }
             }*/
            #endregion

            #region GFG
            /*int outofplace = -1;
            int n = arr.Length;

            for (int index = 0; index < n; index++)
            {
                if (outofplace >= 0)
                {
                    // find the item which must be moved
                    // into the out-of-place entry if out-of-
                    // place entry is positive and current
                    // entry is negative OR if out-of-place
                    // entry is negative and current entry
                    // is negative then right rotate
                    // [...-3, -4, -5, 6...] --> [...6, -3, -4,
                    // -5...]
                    //     ^                         ^
                    //     |                         |
                    //     outofplace     -->     outofplace
                    //
                    if (((arr[index] >= 0)
                         && (arr[outofplace] < 0))
                        || ((arr[index] < 0)
                            && (arr[outofplace] >= 0)))
                    {
                        rightRotate(arr, n, outofplace, index);

                        // the new out-of-place entry
                        // is now 2 steps ahead
                        if (index - outofplace > 2)
                            outofplace = outofplace + 2;
                        else
                            outofplace = -1;
                    }
                }

                // if no entry has been flagged out-of-place
                if (outofplace == -1)
                {
                    // check if current entry is out-of-place
                    if (((arr[index] >= 0)
                         && ((index & 0x01) == 0))
                        || ((arr[index] < 0)
                            && (index & 0x01) == 1))
                        outofplace = index;
                }
            }*/
            #endregion

            #region GFG2
            int neg = 0, pos = 0;
            int n = arr.Length;
            for (int i = 0; i < n; i++)
            {
                if (arr[i] < 0)
                    neg++;
                else
                    pos++;
            }
            // Sort the array
            Array.Sort(arr);

            if (neg <= pos)
            {
                fill1(arr, neg, pos);
            }
            else
            {
                // reverse the array in this condition
                reverse(arr, n);
                fill2(arr, neg, pos);
            }
            #endregion
        }

        private static void fill2(int[] a, int neg, int pos)
        {
            if (pos % 2 == 1)
            {
                for (int i = 1; i < pos; i += 2)
                {
                    int c = a[i];
                    int d = a[i + pos];
                    int temp = c;
                    a[i] = d;
                    a[i + pos] = temp;
                }
            }
            else
            {
                for (int i = 1; i <= pos; i += 2)
                {
                    int c = a[i];
                    int d = a[i + pos - 1];
                    int temp = c;
                    a[i] = d;
                    a[i + pos - 1] = temp;
                }
            }
        }

        private static void reverse(int[] a, int n)
        {
            int i, k, t;
            for (i = 0; i < n / 2; i++)
            {
                t = a[i];
                a[i] = a[n - i - 1];
                a[n - i - 1] = t;
            }
        }

        private static void fill1(int[] a, int neg, int pos)
        {
            if (neg % 2 == 1)
            {
                for (int i = 1; i < neg; i += 2)
                {
                    int c = a[i];
                    int d = a[i + neg];
                    int temp = c;
                    a[i] = d;
                    a[i + neg] = temp;
                }
            }
            else
            {
                for (int i = 1; i <= neg; i += 2)
                {
                    int c = a[i];
                    int d = a[i + neg - 1];
                    int temp = c;
                    a[i] = d;
                    a[i + neg - 1] = temp;
                }
            }
        }

        private static void rightRotate(int[] arr, int length, int outOfPlace, int index)
        {
            int temp = arr[index];
            for (int i = index; i > outOfPlace; i--)
            {
                arr[i] = arr[i - 1];
            }
            arr[outOfPlace] = temp;
        }

        private static void FindLargestThree(int[] arr)
        {
            int[] res = new int[3];
            int cnt = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if(res.Max() < arr[i])
                {
                    if(cnt<3)
                    {
                        res[cnt] = arr[i];
                        cnt++;
                    }
                }
            }
        }

        private static void findFirstNonRepeating(int[] arr6)
        {
            Dictionary<int, int> a = new Dictionary<int, int>();
            for (int i = 0; i < arr6.Length; i++)
            {
                if(a.ContainsKey(arr6[i]))
                {
                    a[arr6[i]] += 1;
                }
                else
                {
                    a.Add(arr6[i], 1);
                }
            }

            for (int i = 0; i < arr6.Length; i++)
            {
                if(a[arr6[i]]==1)
                {
                    Console.WriteLine(arr6[i]);
                    break;
                }
            }

            
        }

        private static void findCommonNumber(int[] ar1, int[] ar2, int[] ar3)
        {
            #region Trial1
            //Dictionary<int, int> map = new Dictionary<int, int>();

            //for (int i = 0; i < ar1.Length; i++)
            //{
            //    if (!map.ContainsKey(ar1[i])) map[ar1[i]]= 1;
            //}
            //for (int i = 0; i < ar2.Length; i++)
            //{
            //    if (map.ContainsKey(ar2[i])) map[ar2[i]] += 1;
            //}
            //for (int i = 0; i < ar3.Length; i++)
            //{
            //    if (map.ContainsKey(ar3[i])) map[ar3[i]] += 1;
            //}

            //foreach (var item in map)
            //{
            //    if(item.Value == 3)
            //    {
            //        Console.Write(item.Key+" ") ;
            //    }
            //}
            #endregion

            #region Trial2
            List<int> ar4 = new List<int>();
            List<int> ar5 = new List<int>();
            int i=0, j=0;
            int m = ar1.Length, n = ar2.Length;


            while(i <m && j<n)
            {
                if (ar1[i] > ar2[j])
                    j++;
                else if (ar1[i] < ar2[j])
                    i++;
                else
                {
                    //i++;
                    j++;
                    ar4.Add(ar1[i]);
                    i++;
                }
            }

            int[] ar = ar4.ToArray();
            i = 0; j = 0;
            m = ar3.Length; n = ar.Length;


            while (i < m && j < n)
            {
                if (ar3[i] > ar[j])
                    j++;
                else if (ar3[i] < ar[j])
                    i++;
                else
                {
                    //i++;
                    j++;
                    ar5.Add(ar3[i]);
                    i++;
                }
            }
            #endregion
        }

        private static void findNumberOfRepeats(int[] arr, int n)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (!map.ContainsKey(arr[i])) map[arr[i]] = 1;
                else map[arr[i]] += 1;
            }

            var list = map.Where(x => x.Value > 1);
            var a=map.Where(x => x.Value >1).Select(x => x.Key);
        }

        private static void rotateCyclic(int[] arr, int degree)
        {
            int n = arr.Length;
            int[] newArr = new int[arr.Length];
            int j = 0;
            for (int i = arr.Length-degree; i < arr.Length; i++,j++)
            {
                newArr[j] = arr[i];
            }
            int k = 0;
            for (int i = j; k < arr.Length-degree; i++,k++)
            {
                newArr[i] = arr[k];
            }
        }

        private static int findNumberOfPairs(int[] arr, int sum)
        {
            #region O(N^2)Solution
            //int cnt = 0;

            //for (int i = 0; i < arr.Length; i++)
            //{
            //    for (int j = i+1; j < arr.Length; j++)
            //    {
            //        if (sum == arr[i] + arr[j]) cnt++;
            //    }
            //}
            //return cnt;
            #endregion

            #region O(N)solution
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (!map.ContainsKey(arr[i])) map[arr[i]] = 0;

                map[arr[i]] += 1;
            }

            int twice_cnt = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if(map[sum-arr[i]]!=0)
                {
                    twice_cnt += map[sum - arr[i]];
                }

                if (sum - arr[i] == arr[i]) twice_cnt--;
            }
            return twice_cnt / 2;
            #endregion
        }

        private static void findKthMinimum(int[] arr,int a)
        {
            //first of all merge sorting should happen O(nlogn)
            DoHeapSortPreProcessing(arr);
            int ans = arr[a - 1];
        }

        private static void DoHeapSortPreProcessing(int[] arr)
        {
            int[] heapArray = new int[arr.Length];
            for (int i = heapArray.Length-1; i >=0 ; i--)
            {
                heapArray[i] = arr[i];
                HeapifyIndex(heapArray, i, heapArray.Length);
            }

            DoActualHeapSort(heapArray);
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = heapArray[i];
            }
        }

        private static void DoActualHeapSort(int[] heapArray)
        {
            for (int i = 0; i < heapArray.Length; i++)
            {
                int elementat0 = heapArray[0];
                heapArray[0] = heapArray[heapArray.Length - i - 1];
                HeapifyIndex(heapArray, 0, heapArray.Length - i - 1);
                heapArray[heapArray.Length - i - 1] = elementat0;

            }
        }

        private static void HeapifyIndex(int[] heapArray, int i, int length)
        {
            int leftChildIndex = 2 * i + 1;
            int rightChildIndex = 2 * i + 2;
            if (leftChildIndex > length && rightChildIndex > length) return;

            int maxIndex = i;
            if (leftChildIndex < length && heapArray[maxIndex] < heapArray[leftChildIndex])
                maxIndex = leftChildIndex;
            if (rightChildIndex < length && heapArray[maxIndex] < heapArray[rightChildIndex])
                maxIndex = rightChildIndex;
            if(maxIndex!=i)
            {
                int temp = heapArray[maxIndex];
                heapArray[maxIndex] = heapArray[i];
                heapArray[i] = temp;
                HeapifyIndex(heapArray, maxIndex, length);
            }
        }

        private static void dutchNationalFlag(int[] arr1)
        {
            int l, m, h;
            l = m = 0;
            h = arr1.Length - 1;

            for (int i = 0; i < arr1.Length; i++)
            {
                if(arr1[m]==0)
                {
                    swap(arr1, l, m);
                    l++;
                    m++;
                }
                else if(arr1[m]==1)
                {
                    m++;
                }
                else if(arr1[m]==2)
                {
                    swap(arr1, m, h);
                    h--;
                }
            }
        }

        private static void swap(int[] arr1, int l, int m)
        {
            int tem = arr1[l];
            arr1[l] = arr1[m];
            arr1[m] = tem;
        }

        private static bool checkIfPresentInEverySegment(int[] arr,int n, int x, int k)
        {
            int i;
            for (i = 0; i < n; i = i + k)
            {

                // Search x in segment
                // starting from index i.
                int j;
                for (j = 0; j < k; j++)
                    if (arr[i + j] == x)
                        break;

                // If loop didn't break
                if (j == k)
                    return false;
            }

            // If n is a multiple of k
            if (i == n)
                return true;

            // Check in last segment if
            // n is not multiple of k.
            int l;
            for (l = i - k; l < n; l++)
                if (arr[l] == x)
                    break;
            if (l == n)
                return false;

            return true;
        }

        private static void RearrangeArra(int[] array,int startingIndex,int endingIndex)
        {
            if (startingIndex == endingIndex)
                return;

            RearrangeArra(array, startingIndex + 1, endingIndex);

            if(array[startingIndex]>=0)
            {
                ReverseArray(array, startingIndex + 1, endingIndex);
                ReverseArray(array, startingIndex, endingIndex);
            }

        }

        private static void ReverseArray(int[] array, int startingIndex, int endingIndex)
        {
            while(startingIndex<endingIndex)
            {
                int temp = array[startingIndex];
                array[startingIndex] = array[endingIndex];
                array[endingIndex] = temp;
                startingIndex++;
                endingIndex--;
            }
        }
    }
}
