using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TECHGIG_small_tests
{
    public static class TIMSORT
    {
        public  const int RUN = 32;

        // This function sorts array from left index to
        // to right index which is of size atmost RUN
        public static void insertionSort(int[] arr,
                                    int left, int right)
        {
            for (int i = left + 1; i <= right; i++)
            {
                int temp = arr[i];
                int j = i - 1;
                while (j >= left && arr[j] > temp)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = temp;
            }
        }

        // merge function merges the sorted runs
        public static void merge(int[] arr, int l,
                                       int m, int r)
        {
            // original array is broken in two parts
            // left and right array
            int len1 = m - l + 1, len2 = r - m;
            int[] left = new int[len1];
            int[] right = new int[len2];
            for (int x = 0; x < len1; x++)
                left[x] = arr[l + x];
            for (int x = 0; x < len2; x++)
                right[x] = arr[m + 1 + x];

            int i = 0;
            int j = 0;
            int k = l;

            // After comparing, we merge those two array
            // in larger sub array
            while (i < len1 && j < len2)
            {
                if (left[i] <= right[j])
                {
                    arr[k] = left[i];
                    i++;
                }
                else
                {
                    arr[k] = right[j];
                    j++;
                }
                k++;
            }

            // Copy remaining elements
            // of left, if any
            while (i < len1)
            {
                arr[k] = left[i];
                k++;
                i++;
            }

            // Copy remaining element
            // of right, if any
            while (j < len2)
            {
                arr[k] = right[j];
                k++;
                j++;
            }
        }

        // Iterative Timsort function to sort the
        // array[0...n-1] (similar to merge sort)
        public static void timSort(int[] arr, int n)
        {

            // Sort individual subarrays of size RUN
            for (int i = 0; i < n; i += RUN)
                insertionSort(arr, i,
                             Math.Min((i + RUN - 1), (n - 1)));

            // Start merging from size RUN (or 32).
            // It will merge
            // to form size 64, then
            // 128, 256 and so on ....
            for (int size = RUN; size < n;
                                     size = 2 * size)
            {

                // Pick starting point of
                // left sub array. We
                // are going to merge
                // arr[left..left+size-1]
                // and arr[left+size, left+2*size-1]
                // After every merge, we increase
                // left by 2*size
                for (int left = 0; left < n;
                                      left += 2 * size)
                {

                    // Find ending point of left sub array
                    // mid+1 is starting point of
                    // right sub array
                    int mid = left + size - 1;
                    int right = Math.Min((left +
                                        2 * size - 1), (n - 1));

                    // Merge sub array arr[left.....mid] &
                    // arr[mid+1....right]
                    if (mid < right)
                        merge(arr, left, mid, right);
                }
            }
        }

        // Utility function to print the Array
        public static void printArray(int[] arr, int n)
        {
            for (int i = 0; i < n; i++)
                Console.Write(arr[i] + " ");
            Console.Write("\n");
        }

    }
    public static class SelectionSorting
    {
        public static void method(int[] arr)
        {
            //List<int> a = new List<int>();
            //var r = new Random();
            //for (int i = 1000; i >0; i--)
            //{
            //    a.Add(i+r.Next(int.MaxValue));
            //}
            //var arr = a.ToArray();
            var start = DateTime.Now;
            DoSelectionSort(arr,0, arr.Length);
            Console.WriteLine("*******Selection Sort ********************");
            Console.WriteLine(DateTime.Now - start);
        }

        private static void DoSelectionSort(int[] arr,int start, int length)
        {
            if (start >= length) return;
           
            int min = int.MaxValue;
            int minIndex = -1;
            for (int i = start; i < length; i++)
            {
              if( arr[i] < min)
              {
                    min = arr[i];
                    minIndex = i;
              }
            }
            int temp = arr[start];
            arr[start] = arr[minIndex];
            arr[minIndex] = temp;

            DoSelectionSort(arr, start + 1, length);
        }
    }

    public static class BubbleSorting
    {
        public static void method(int[] arr)
        {
            //List<int> a = new List<int>();
            //var r = new Random();
            //for (int i = 10000; i > 0; i--)
            //{
            //    a.Add(i + r.Next(int.MaxValue));
            //}
            //var arr = a.ToArray();
            var start = DateTime.Now;
            DoBubbleSort(arr, arr.Length);
            Console.WriteLine("*******Bubble Sort ********************");
            Console.WriteLine(DateTime.Now - start);

        }

        private static void DoBubbleSort(int[] arr, int length)
        {
            for (int i = 0; i < length; i++)
            {
                for (int j = i+1; j < length; j++)
                {
                    if(arr[i]>arr[j])
                    {
                        int temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
        }
    }

    /// <summary>
    /// insertion sort
    /// </summary>
    public class InsertionSorting
    {
        public static void method(int[] arr)
        {
            //int[] arr = { 12, 11, 13, 5, 6 };
            //List<int> a = new List<int>();
            //var r = new Random();
            //for (int i = 10000; i > 0; i--)
            //{
            //    a.Add(i + r.Next(int.MaxValue));
            //}
            //var arr = a.ToArray();
            var start = DateTime.Now;
            DoInsertionSort(arr);
            Console.WriteLine("*******Insertion Sort ********************");
           // Console.WriteLine("tast "+start +"   " +DateTime.Now);
            Console.WriteLine(DateTime.Now - start);
        }

        private static void DoInsertionSort(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                int key = arr[i];
                int j = i - 1;

                while(j >=0 && key < arr[j])
                {
                    arr[j+1] = arr[j];
                    j--;
                }
                arr[j + 1] = key;
            }
        }
    }

    public class MergeSorting
    {
        public static void method()
        {
            int[] arr = { 12, 11, 13 };
            DoMergeSortin(arr, 0, arr.Length - 1);
        }

        private static void DoMergeSortin(int[] arr, int l, int r)
        {
            if (l<r)
            {
                int m = l + (r - l) / 2;

                DoMergeSortin(arr, l, m);
                DoMergeSortin(arr, m + 1, r);

                DoMerging(arr, l, m, r); 
            }
        }

        private static void DoMerging(int[] arr, int l, int m, int r)
        {
            // Find sizes of two
            // subarrays to be merged
            int n1 = m - l + 1;
            int n2 = r - m;

            // Create temp arrays
            int[] L = new int[n1];
            int[] R = new int[n2];
            int i, j;

            // Copy data to temp arrays
            for (i = 0; i < n1; ++i)
                L[i] = arr[l + i];
            for (j = 0; j < n2; ++j)
                R[j] = arr[m + 1 + j];

            // Merge the temp arrays

            // Initial indexes of first
            // and second subarrays
            i = 0;
            j = 0;

            // Initial index of merged
            // subarry array
            int k = l;
            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    arr[k] = L[i];
                    i++;
                }
                else
                {
                    arr[k] = R[j];
                    j++;
                }
                k++;
            }

            // Copy remaining elements
            // of L[] if any
            while (i < n1)
            {
                arr[k] = L[i];
                i++;
                k++;
            }

            // Copy remaining elements
            // of R[] if any
            while (j < n2)
            {
                arr[k] = R[j];
                j++;
                k++;
            }
        }
    }


    public static class QuickSorting
    {
        public static void method()
        {
            int[] arr = { 12, 11, 13, 5, 6 };

            DoQuickSorting(arr, 0, arr.Length - 1);
        }

        private static void DoQuickSorting(int[] arr, int low, int high)
        {
            if (low < high)
            {
                 int partitionIdx = partition(arr, low, high);

                DoQuickSorting(arr, low, partitionIdx-1);
                DoQuickSorting(arr, partitionIdx + 1, high);
            }
        }

        private static int partition(int[] arr, int low, int high)
        {
            int pivot = arr[high];
            int i = low - 1;

            for (int j = low; j <= high-1; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

            int temp1 = arr[i+1];
            arr[i + 1] = arr[high];
            arr[high] = temp1;

            return i +1;

        }
    }

    public static class HeapSorting
    {
        public static void method()
        {
            int[] arr = { 50,70,30,100,80,20,150,10};
            int[] heapArray = new int[arr.Length];

            DoHeapSortPrepProcessing(arr, heapArray);
            DoActualHeapSort(heapArray);
        }

        private static void DoActualHeapSort(int[] heapArray)
        {
            for (int i = 0; i < heapArray.Length; i++)
            {
                int elmAtIndex0 = heapArray[0];
                heapArray[0] = heapArray[heapArray.Length - i-1];
                HeapifyIndex(heapArray, 0,heapArray.Length-i-1);
                heapArray[heapArray.Length - i - 1] = elmAtIndex0;
            }
        }

        private static void DoHeapSortPrepProcessing(int[] arr, int[] heapArray)
        {
            //heapArray[0] = arr[0];
            for (int i = arr.Length-1; i >=0 ; i--)
            {
                heapArray[i] = arr[i];
                HeapifyIndex(heapArray, i,heapArray.Length);
            }
        }

        private static void HeapifyIndex(int[] heapArray, int i,int heapLength)
        {
            int leftChildIndex = 2 * i + 1;
            int rightChildIndex = 2 * i + 2;

            if (leftChildIndex > heapLength && rightChildIndex > heapLength) return;

            int maxIndex = i;
            if(leftChildIndex< heapLength && heapArray[maxIndex] < heapArray[leftChildIndex])
            {
                
                maxIndex = leftChildIndex;
            }
            if(rightChildIndex < heapLength && heapArray[maxIndex] < heapArray[rightChildIndex])
            {
                maxIndex = rightChildIndex;
            }

            if (maxIndex != i)
            {
                int temp = heapArray[maxIndex];
                heapArray[maxIndex] = heapArray[i];
                heapArray[i] = temp;
                HeapifyIndex(heapArray, maxIndex,heapLength);
            }

        }
    }

    public static class CountingSorting
    {
        public static void method()
        {
            int[] arr = { 1, 4, 1, 2, 7, 5, 2 };

            DoCountingSort(arr);
        }

        private static void DoCountingSort(int[] arr)
        {
            int maxItem = arr.Max();
            int[] count = new int[maxItem+1];
            //prepare count array
            for (int i = 0; i < arr.Length; i++)
            {
                count[arr[i]] += 1;
            }
            //update count array
            for (int i = 1; i < count.Length; i++)
            {
                count[i] += count[i - 1];
            }
            //make a copy array
            int[] copyArr = new int[arr.Length];

            for (int i = arr.Length-1  ; i >= 0; i--)
            {
                count[arr[i]] -= 1;
                copyArr[count[arr[i]]] = arr[i];
            }
            
        }
    }

    public static class RadixSorting
    {
        public static void method()
        {
            int[] arr = { 170, 45, 75, 90, 802, 24, 2, 66 };//, 45, 28, 21, 30 };
            DoRadixSort(arr);
        }

        private static void DoRadixSort(int[] arr)
        {
            int maxEle = arr.Max();

            for (int exp = 1; maxEle/exp > 0; exp*=10)
            {
                CountingSorting(arr, exp);
            }
        }

        private static void CountingSorting(int[] arr, int exp)
        {
            int[] count = new int[10];
            int[] copyArr = new int[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                count[((arr[i] / exp) % 10)] += 1;
            }

            for (int i = 1; i < count.Length; i++)
            {
                count[i] += count[i - 1];
            }

            for (int i = arr.Length-1; i >= 0; i--)
            {
                count[((arr[i] / exp) % 10)] -= 1;
                copyArr[count[((arr[i] / exp) % 10)]] = arr[i];
            }

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = copyArr[i]; 
            }
        }


       
    }
    public static class BucketSorting
    {
        public static void method()
        {
            int[] arr = { 1, 4, 6, 2, 7, 15, 8 };

            DobucketSort(arr);
        }

        private static void DobucketSort(int[] arr)
        {
            //int n = arr.Length - 1;

            List<int>[] buckets = new List<int>[arr.Length];
            for (int i = 0; i < buckets.Length; i++)
            {
                buckets[i] = new List<int>();
            }

            for (int i = 0; i < buckets.Length; i++)
            {
                int bktIndex = arr[i] / buckets.Length;
                buckets[bktIndex].Add(arr[i]);
            }
            for (int i = 0; i < buckets.Length; i++)
            {
                buckets[i].Sort();
            }
            int ind = 0;
            for (int i = 0; i < buckets.Length; i++)
            {
                var temp = buckets[i].ToArray();
                for (int j = 0; j < buckets[i].Count; j++)
                {
                    
                    arr[ind] = temp[j];
                    ind++;
                }
            }
            
        }
    }
}
