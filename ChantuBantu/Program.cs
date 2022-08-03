using System;
using System.Collections.Generic;

namespace ChantuBantu
{
    class Program
    {
        static void Main(string[] args)
        {
            /*int T = Convert.ToInt32(Console.ReadLine());
            int[] numberOfGifts = new int[T];
            List<int[]> price = new List<int[]>();
            for (int i = 0; i < T; i++)
            {
                numberOfGifts[i] = Convert.ToInt32(Console.ReadLine());
                int N = Convert.ToInt32(Console.ReadLine());
                var priceArr = Console.ReadLine().Split(' ');
                int[] priceA = new int[N];
                for (int j = 0; j < N; j++)
                {
                    priceA[j] = Convert.ToInt32(priceArr[j]);
                }
                price.Add(priceA);
            }
            for (int i = 0; i < T; i++)
            {
                int[] ar = price[i];
                
                Console.WriteLine(FindMinAmount(ar, numberOfGifts[i]));
            }*/

            int[] ar ={ 2,1,1,1,1,1,1 };
            Console.WriteLine(FindMinAmount(ar, 4));
        }

        private static int FindMinAmount(int[] array, int numberOfGift)
        {
            //do the heap sort as that will take O(NlogN) time
            int[] heapArray = new int[array.Length];
            DoHeapSortPreProcess(array, heapArray);
            DoActualHeapSort(heapArray);

            int finalAns = 0;
            for (int i = 0; i < numberOfGift; i++)
            {
                finalAns += heapArray[i];
            }
            return finalAns;
        }

        private static void DoActualHeapSort(int[] heapArray)
        {
            for (int i = 0; i < heapArray.Length; i++)
            {
                int elem0 = heapArray[0];
                heapArray[0] = heapArray[heapArray.Length - i - 1];
                Heapify(heapArray, 0, heapArray.Length - i - 1);
                heapArray[heapArray.Length - i - 1] = elem0;
            }
        }

        private static void DoHeapSortPreProcess(int[] array, int[] heapArray)
        {
            for (int i = array.Length-1; i >= 0; i--)
            {
                heapArray[i] = array[i];
                Heapify(heapArray, i, heapArray.Length);
            }
        }

        private static void Heapify(int[] heapArray, int index, int heapLength)
        {
            int leftChildIndex = 2 * index + 1;
            int rightChildIndex = 2 * index + 2;

            if (leftChildIndex > heapLength && rightChildIndex > heapLength) return;
            int maxIndex = index;
            if (leftChildIndex < heapLength && heapArray[maxIndex] < heapArray[leftChildIndex])
                maxIndex = leftChildIndex;

            if (rightChildIndex < heapLength && heapArray[maxIndex] < heapArray[rightChildIndex])
                maxIndex = rightChildIndex;

            if(maxIndex != index)
            {
                int temp = heapArray[maxIndex];
                heapArray[maxIndex] = heapArray[index];
                heapArray[index] = temp;
                Heapify(heapArray, maxIndex, heapLength);
            }
        }
    }
}
