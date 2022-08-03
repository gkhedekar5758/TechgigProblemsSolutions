using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace ArrayProblemsGFGHR
{
    public class Graph
    {
        int V; //edges
        List<int>[] adjustancyList;
        public Graph(int paramV)
        {
            V = paramV;
            adjustancyList = new List<int>[V];
            for (int i = 0; i < V; i++)
            {
                adjustancyList[i] = new List<int>();
            }
        }

        public void addEdge(int u,int v)
        {
            adjustancyList[u].Add(v);
        }

        public void BFSOfGraph(int sourceNode)
        {
            bool[] visited = new bool[V];
            LinkedList<int> queue = new LinkedList<int>();
            queue.AddLast(sourceNode);
            visited[sourceNode] = true;

            while (queue.Any())
            {
                sourceNode = queue.First();
                Console.Write(sourceNode+ " ");
                queue.RemoveFirst();

                foreach (var item in adjustancyList[sourceNode])
                {
                    if(!visited[item])
                    {
                        visited[item] = true;
                        queue.AddLast(item);
                    }
                }
            }

        }

        internal void DFSOfGraph(int sourceNode)
        {
            bool[] visited = new bool[V];
            DFSUtility(sourceNode, visited);
            
        }

        private void DFSUtility(int sourceNode, bool[] visited)
        {
            visited[sourceNode] = true;
            Console.Write(sourceNode + " ");
            //List<int> listOfAdjusants = ;
            foreach (var item in adjustancyList[sourceNode])
            {
                if (!visited[item])
                {
                    visited[item] = true;
                    DFSUtility(item, visited);
                }
            }
        }
    }

    /// <summary>
    /// CLEAN CODE DEMO
    /// I am going to write clean code in this whole file
    /// </summary>
    class Program
    {
        //O(N)
        public static void arrayPrintingMethod(int[] array)
        {
            int lengthOfArray = array.Length;
            for (int index = 0; index <lengthOfArray ; index++)
            {
                Console.Write(array[index] + " ");
            }
        }

        //O(1)
        public static void addBlankLinesBetweenOuput()
        {
            Console.WriteLine();
            Console.WriteLine("**************************************");
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
          //  String s = "";
          //if(String.IsNullOrEmpty(s))
          //  //reverse the array
          //  s.white
          //  //Hacker Rank DS-problem 1
          //  int[] ResultArray = reverseArray(array);
            //arrayPrintingMethod(ResultArray);

            addBlankLinesBetweenOuput();
            //Hacker Rank DS-problem 2
            /*int[,] arr2 = { { 1, 1, 1, 0, 0, 0 },
                            {0, 1, 0, 0, 0, 0 },{1, 1, 1, 0, 0, 0},{0 ,0, 2, 4, 4, 0},{0, 0, 0, 2, 0, 0},
                            {0, 0, 1, 2 ,4 ,0 }
                            };*/
            int[,] arr2 ={ {-1 ,-1, 0, -9, -2, -2},
                            {-2 ,-1, -6, -8, -2, -5 },{-1, -1, -1, -2, -3, -4},{-1 ,-9, -2, -4, -4, -5},{-7, -3, -3, -2, -9, -9},
                            {-1 ,-3 ,-1 ,-2, -4, -5 }
                            };


            Console.WriteLine($"Maximum Sum of HourGlass is {findMaximumSumOfHourGlass(arr2)}");
            addBlankLinesBetweenOuput();

            //Search an element in a sorted and rotated array
            //GFG
            //int[] arr3= { 5, 6, 7, 8, 9, 10, 1, 2, 3 };
            int[] arr3 = { 6, 7, 8, 9, 20, 21, 22, 23, 24, 25, 1, 3, 4 };
            int key = 33;
            Console.WriteLine($"Index of Key in rotated array is {findIndexOfKeyElementInRotatedArray(arr3, key)}");
            addBlankLinesBetweenOuput();

            //Given an array, only rotation operation is allowed on array.
            //We can rotate the array as many times as we want.Return the
            //maximum possible summation of i* arr[i].
            //GFG
            int[] arr4 = { -90, 20, -100 };
            Console.WriteLine($"The maximum sum obtained after rotation is {findMaximumSumAfterRotatingArray(arr4)}");
            addBlankLinesBetweenOuput();

            //Given an array of elements of length N, ranging from 0 to N – 1.
            //All elements may not be present in the array. If the element is not
            //present then there will be -1 present in the array. Rearrange the array
            //such that A[i] = i and if i is not present, display -1 at that place.
            int[] arr5 = {19, 7, 0, 3, 18, 15, 12, 6, 1, 8,
              11, 10, 9, 5, 13, 16, 2, 14, 17, 4};
            rearrangeArrayWithElement(arr5);
            Console.WriteLine("Rearranging the array and putting-1 at abesent element ");
            arrayPrintingMethod(arr5);
            addBlankLinesBetweenOuput();

            //Given an array of n elements. Our task is to write a program to rearrange
            //the array such that elements at even positions are greater than all elements
            //before it and elements at odd positions are less than all elements before it.

            int[] arr6 = { 1, 2, 1, 4, 5, 6, 8, 8 };
            int[] result = rearrangeArrayAsPerOddEvenPosition(arr6);
            Console.WriteLine("Element at even is greater than at odd ");
            arrayPrintingMethod(result);
            addBlankLinesBetweenOuput();

            //An array contains both positive and negative numbers in random order. Rearrange the
            //array elements so that positive and negative numbers are placed alternatively. Number
            //of positive and negative numbers need not be equal. If there are more positive numbers
            //they appear at the end of the array. If there are more negative numbers, they too appear
            //in the end of the array.

            int[] arr7 = { -1, 2, -3, 4, 5, 6, -7, 8, 9 };
            rearrangePositiveAndNegativeAtAlternatePosition(arr7);
            Console.WriteLine("After arranging +ve and -ve at alternate place");
            arrayPrintingMethod(arr7);
            addBlankLinesBetweenOuput();

            //Given an array of random numbers, Push all the zero’s of a given array to the end of the array.
            int[] arr8 = { 0, 1, 9, 8, 4, 0, 0, 2, 7, 0, 6, 0, 9 };
            pushAllZeroToTheEndOfArray(arr8);
            arrayPrintingMethod(arr8);
            addBlankLinesBetweenOuput();

            //Given an array of n positive integers and a number k. Find the minimum number of swaps
            //required to bring all the numbers less than or equal to k together.
            int[] arr9 = { 2, 7, 9, 5, 8, 7, 4 };
            int k = 5;
            Console.WriteLine($" Minimum swap required is {FindMinimumSwapsRequiredToBringTogether(arr9, k)}");
            addBlankLinesBetweenOuput();

            //Given an array of positive and negative numbers, arrange them such that all negative integers
            //appear before all the positive integers in the array without using any additional data structure
            //like a hash table, arrays, etc. The order of appearance should be maintained.

            int[] arr10 = { -12, -11, -13, -5, 6, -7, 5, -3, -6 };
            RearrangNegativeAndPositive(arr10);
            arrayPrintingMethod(arr10);
            addBlankLinesBetweenOuput();

            //For a given array of n integers and assume that ‘0’ is an invalid number and all others as a valid number.
            //Convert the array in such a way that if both current and next element is valid then double current value
            //and replace the next number with 0. After the modification, rearrange the array such that all 0’s
            //shifted to the end. 
            int[] arr11 = { 2, 2, 0, 4, 0, 8 };
            DoubleTheValidElementAndPush0ToEnd(arr11);
            arrayPrintingMethod(arr11);
            addBlankLinesBetweenOuput();

            //Given a sorted array of positive integers, rearrange the array alternately i.e first element should be maximum value,
            //second minimum value, third second max, fourth second min and so on. 
            int[] arr12 = { 1, 2, 3, 4, 5, 6, 7 };
            RearrangeArrayMaxMinElement(arr12);
            arrayPrintingMethod(arr12);
            addBlankLinesBetweenOuput();

            //Given an array and a number k where k is smaller than the size of the array, we need to find the k’th smallest element
            //in the given array. It is given that all array elements are distinct.
            int[] arr13 = { 7, 10, 4, 3, 20, 15 };
            int kK = 3;
            Console.WriteLine($"K th Minimum Element is {FindKthMinimumElement(arr13, kK)}");
            addBlankLinesBetweenOuput();

            //Given an array arr[] and size of array is n and one another key x, and give you a segment size k. The task is to
            //find that the key x present in every segment of size k in arr[].
            // Overlapping and NonOverlapping
            int[] arr14 = { 21, 23, 56, 65, 34, 54, 76, 32, 23, 45, 21, 22, 25 };
            int x = 23;
            int kkk = 5;
            Console.WriteLine($" Key {x} is present in All the segments of size {kkk} ? - {CheckIfKeyIsPresentInAllSegments(arr14, x, kkk)}");
            addBlankLinesBetweenOuput();

            //segregate 0,1,2 in the array, first have all 0 then all 1 and then all 2
            // This algorithm is called dutch national flag algorithm
            int[] arr15 = { 0, 1, 2, 0, 1, 2 };
            Arrange0s1s2sInArray(arr15);
            Console.WriteLine("Array after separting 0s 1s and 2s is as below");
            arrayPrintingMethod(arr15);
            addBlankLinesBetweenOuput();

            //Given an array of integers, and a number ‘sum’, find the number of pairs of integers in
            //the array whose sum is equal to ‘sum’.
            int[] arr16 = { 1, 5, 7, -1 ,5};
            int sum = 6;
            Console.WriteLine($"The number of pairs having sum ={sum} are {FindNumberOfPairsHavingSum(arr16, sum)}");// FindNumberOfPairsHavingSum(arr16, sum);
            addBlankLinesBetweenOuput();

            //Given an array of n elements that contains elements from 0 to n-1, with any of these numbers
            //appearing any number of times. Find these repeating numbers in O(n) and using only constant memory space.
            int[] arr17 = { 1, 2, 3,2 };
            FindDuplicateNumberInArray(arr17);
            addBlankLinesBetweenOuput();

            //Write an efficient program to find the sum of contiguous subarray within a one-dimensional array
            //of numbers that has the largest sum. 
            int[] arr18 = {-2,-3,4,-1,-2,-1,-5,-3 };
            Console.WriteLine($" The largest sum using Kadane's Algo is : {FindLargestContiguosSum(arr18)}");
            addBlankLinesBetweenOuput();
            //Given an array that contains both positive and negative integers, find the product of the maximum product subarray.
            //Expected Time complexity is O(n) and only O(1) extra space can be used.
            int[] arr19 = { -2, -40, -1, -2, -3,0 };
            Console.WriteLine($"Maximum product can be : {FindMaximumProduct(arr19)}");
            addBlankLinesBetweenOuput();
            //A sorted array is rotated at some unknown point, find the minimum element in it. 
            //The following solution assumes that all elements are distinct.
            int[] arr20 = { 5, 6, 7, 1, 2, 3, 4 };
            Console.WriteLine($"Minimum element in rotated array is {FindMinimumElementInArray(arr20)}");
            addBlankLinesBetweenOuput();

            //Given an array a[0 . . . n-1]. We should be able to efficiently find the GCD from index
            //qs (query start) to qe (query end) where 0 <= qs <= qe <= n-1.
            int[] arr21= { 2, 3, 60, 90, 50 };
            int l = 1;
            int r = 3;
            Console.WriteLine($"the GCD of range is {FindGCDOfRange(arr21,l,r)}");
            addBlankLinesBetweenOuput();

            //Given a boolean 2D array, where each row is sorted. Find the row with the maximum number of 1s. 
            int[,] darr = new int[,] { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } };
            Console.WriteLine($"Max no of 1s is in row # (0 based) {FindMaxNumberOf1s(darr)}");
            addBlankLinesBetweenOuput();

            //+++++++++++++ Hard Problems.. ha ha// +++++++++++++++++
            //Given an array arr[], find the maximum j – i such that arr[j] > arr[i].
            int[] arr22 = { 9, 2, 3, 4, 5, 6, 7, 8, 18, 0 };
            Console.WriteLine($"Maximum diff between I and J is {FindMaxDifference(arr22)}");
            addBlankLinesBetweenOuput();

            //Given an unsorted array of size n. Array elements are in the range
            //from 1 to n. One number from set {1, 2, …n} is missing and one number
            //occurs twice in the array. Find these two numbers.
            int[] arr23 = { 3, 1, 3 };
            int missingNumber = 0;
            Console.WriteLine($"The repeating number is {FindRepeatingAndMissingNumber(arr23,out missingNumber)} and Missing number is {missingNumber}");
            addBlankLinesBetweenOuput();

            //Given a sorted array and a number x, find a pair in array whose sum is closest to x.
            int[] arr24 = { 10, 22, 28, 29, 30, 40 };
            x = 54;
            int[] resultantArray = FindThePairWithClosestSum(arr24, x);
            Console.Write("Pair with closest sum is ");
            arrayPrintingMethod(resultantArray);
            addBlankLinesBetweenOuput();

            // hacker rank
            int n = 2;
            List<List<int>> queriesArray = new List<List<int>>();
            queriesArray.Add(new List<int> {1,0,4 });
            queriesArray.Add(new List<int> { 1, 1, 7 });
            queriesArray.Add(new List<int> { 1, 0, 3 });
            queriesArray.Add(new List<int> { 2, 1, 0 });
            queriesArray.Add(new List<int> { 2, 1, 1 });
            DesignDynamicArray(n, queriesArray);

            addBlankLinesBetweenOuput();

            //longest increasing subsequent
            /*The Longest Increasing Subsequence(LIS) problem is to 
             * find the length of the longest subsequence of a given sequence
             * such that all elements of the subsequence are sorted in increasing order. 
             * For example, the length of LIS for { 10, 22, 9, 33, 21, 50, 41, 60, 80} is
             * 6 and LIS is { 10, 22, 33, 50, 60, 80 }. 
             * 
             * */
            int[] arr35 = { 10, 22, 9, 33, 3, 50, 7, 60,70,80,90,100 };
            Console.WriteLine("Longest commonn subsequence length is : "+ LongestCommonSubsequence(arr35));
            addBlankLinesBetweenOuput();

            //****************************************
            //GRAPH PROBLEMS GFG
            //****************************************
            Graph graph = new Graph(4);
            graph.addEdge(0, 1);
            graph.addEdge(0, 2);
            graph.addEdge(1, 2);
            graph.addEdge(2, 0);
            graph.addEdge(2, 3);
            graph.addEdge(3, 3);
            Console.WriteLine("BFS of graph");
            //BFS
            graph.BFSOfGraph(sourceNode: 2);
            Console.WriteLine();

            //DFS
            Console.WriteLine("DFS of graph");
            //bool[] visited = new bool[4];
            graph.DFSOfGraph(sourceNode: 2);
            // String bare minimum problem from the interviewbit platform
            ArrayProblemsGFG.StringProblemInterViewBit.MasterMethod();
            //objectClass.MasterMethod();
            ArrayProblemsGFG.LeetCodeJuly.MasterMethod();
            Console.Read();
        }

        private static int LongestCommonSubsequence(int[] array)
        {
            int maxValue;
            
            int max = int.MinValue;
            for (int i = 0; i < array.Length; i++)
            {
                int c = 0;
                maxValue = array[i];
                for (int j = i+1; j < array.Length; j++)
                {
                    if(maxValue<array[j])
                    {
                        maxValue = array[j];
                        c++;
                    }
                }
                max = Math.Max(max, c);

            }


            return max+1;
        }

        private static List<int> DesignDynamicArray(int size, List<List<int>> queriesArray)
        {
            List<int> returnList = new List<int>();
            int lastAnswer = 0;

            var ans = new List<List<int>>(2);
            for (int i = 0; i < size; i++)
            {
                ans.Add(new List<int>());
            }
            foreach (var list in queriesArray)
            {
                int typeOfQuery = list.ElementAt(0);
                if(typeOfQuery==1)
                {
                    int x = list.ElementAt(1);
                    int y = list.ElementAt(2);
                    ans.ElementAt((x ^ lastAnswer) % size).Add(y);

                }
                else if(typeOfQuery==2)
                {
                    int x = list.ElementAt(1);
                    int y = list.ElementAt(2);
                    var a = ans.ElementAt((x ^ lastAnswer) % size);
                    lastAnswer = a.ElementAt(y % a.Count);
                    //Console.WriteLine(lastAnswer);
                    returnList.Add(lastAnswer);
                }
            }
            return returnList;
        }

        private static int[] FindThePairWithClosestSum(int[] array, int sum)
        {
            int differenceBetSumAndPairSum = int.MaxValue;
            int leftPointer = 0;
            int rightPointer = array.Length - 1;
            int[] result = new int[2];
            while (leftPointer<rightPointer)
            {
                if ( Math.Abs( array[leftPointer] + array[rightPointer] - sum) < differenceBetSumAndPairSum)
                {
                    differenceBetSumAndPairSum = Math.Abs( array[leftPointer] + array[rightPointer] - sum);
                    result[0] = array[leftPointer];
                    result[1] = array[rightPointer];
                }
                else if (array[leftPointer] + array[rightPointer] < sum)
                    leftPointer++;
                else if (array[leftPointer] + array[rightPointer] > sum)
                    rightPointer--;
            }
            return result;
        }

        //O(N)
        private static object FindRepeatingAndMissingNumber(int[] array, out int missingNumber)
        {
            int lengthOfArray = array.Length;
            int repeatingNumber=-1;
            Dictionary<int, int> indexCountDictionary = new Dictionary<int, int>();
            for (int index = 0; index < lengthOfArray; index++)
            {
                if (indexCountDictionary.ContainsKey(array[index]))
                {
                    indexCountDictionary[array[index]] += 1;
                }
                else
                    repeatingNumber = array[index];

                
            }
            
            ///var a = repeatingNumber[0].Key;
            var resultDic = indexCountDictionary.OrderBy(x => x.Key);
            missingNumber = 1;
            foreach (var item in resultDic)
            {
                if (item.Key != missingNumber)
                    break;

                missingNumber++;
            }

            
            return repeatingNumber; 
        }

        private static object FindMaxDifference(int[] array)
        {
            #region O(N^2) soution
            //int lengthOfArray = array.Length;
            //int maximumDifference = 0;
            //for (int index = 0; index < lengthOfArray; index++)
            //{
            //    for (int internalIndex = lengthOfArray-1; internalIndex > index+1; internalIndex--)
            //    {
            //        if (array[internalIndex] > array[index] && maximumDifference < internalIndex - index)
            //            maximumDifference = internalIndex - index;
            //    }
            //}
            //return maximumDifference;
            #endregion

            #region O(N) solution
            int lengthOfArray = array.Length;
            int[] leftMinimumElements = new int[lengthOfArray];
            int[] rightMaximumElement = new int[lengthOfArray];

            leftMinimumElements[0] = array[0];
            for (int index = 1; index < array.Length; index++)
            {
                leftMinimumElements[index] = Math.Min(array[index], leftMinimumElements[index - 1]);
            }
            rightMaximumElement[lengthOfArray - 1] = array[lengthOfArray - 1];
            for (int index = lengthOfArray-2; index >= 0; index--)
            {
                rightMaximumElement[index] = Math.Max(array[index], rightMaximumElement[index + 1]);
            }

            int maximumDifference = -1;
            int maxRIterator = 0;
            int minLIterator = 0;

            while (maxRIterator<lengthOfArray && minLIterator<lengthOfArray)
            {
                if (leftMinimumElements[minLIterator] < rightMaximumElement[maxRIterator])
                {
                    maximumDifference = Math.Max(maximumDifference, maxRIterator - minLIterator);
                    maxRIterator++;
                }
                else
                    minLIterator++;
            }
            return maximumDifference;
            #endregion
        }

        //O(N)
        private static object FindMaxNumberOf1s(int[,] twoDArray)
        {
            int maxNoOf1sInAllRows = 0;
            int noOf1sInCurrentRow = 0;
            int finalAnswer=-1;
            for (int rowIndex = twoDArray.GetUpperBound(0); rowIndex >= 0; rowIndex--)
            {
                noOf1sInCurrentRow = 0;
                for (int columnIndex = twoDArray.GetUpperBound(1); columnIndex >= 0; columnIndex--)
                {
                    if (twoDArray[rowIndex, columnIndex] == 1) noOf1sInCurrentRow++;
                }
                if (noOf1sInCurrentRow>maxNoOf1sInAllRows)
                {
                    maxNoOf1sInAllRows = noOf1sInCurrentRow;
                    finalAnswer = rowIndex;
                }
            }

            return finalAnswer;
        }

        //O(N^2)
        private static object FindGCDOfRange(int[] array, int leftIndex, int rightIndex)
        {
            int GCD=array[leftIndex];
            for (int index = leftIndex+1; index <= rightIndex; index++)
            {
                GCD = FindGCDOfTwoNo(GCD, array[index]);
            }
            return GCD;
        }

        //Euclidean algo
        private static int FindGCDOfTwoNo(int firstNumber, int secondNumber)
        {
            while(firstNumber!=secondNumber)
            {
                if(firstNumber>secondNumber)
                {
                    firstNumber -= secondNumber;
                }
                else
                {
                    secondNumber -= firstNumber;
                }
            }
            return firstNumber;
        }

        //O(NlogN)
        private static int FindMinimumElementInArray(int[] array)
        {
            int lengthOfArray = array.Length;
            return PerformBinarySearchAlgo(array, 0, lengthOfArray - 1);
            
        }

        private static int PerformBinarySearchAlgo(int[] array, int lowIndex, int highIndex)
        {
            if (highIndex < lowIndex)
                return array[0];
            if (highIndex == lowIndex)
                return array[lowIndex];
            int middleIndex = (highIndex + lowIndex) / 2;

            if (highIndex > middleIndex && array[middleIndex] > array[middleIndex + 1])
                return array[middleIndex + 1];
            if (middleIndex > lowIndex && array[middleIndex] < array[middleIndex - 1])
                return array[middleIndex];
           

            if (array[highIndex] > array[middleIndex])
                return PerformBinarySearchAlgo(array, lowIndex, middleIndex - 1);

            return PerformBinarySearchAlgo(array, middleIndex + 1, highIndex);
           
        }

        //O(N)
        private static int FindMaximumProduct(int[] array)
        {
            int maximumProdcutAtThis=1, maximumProductUntillNow=1, maximumProductGlobally=1;

            for (int index = 0; index < array.Length; index++)
            {
                if(array[index]!=0)
                {
                    maximumProdcutAtThis *= array[index];
                    maximumProductUntillNow = Math.Max(maximumProductUntillNow, maximumProdcutAtThis);
                    maximumProductGlobally = Math.Max(maximumProductGlobally, maximumProductUntillNow);
                }
                else
                {
                    maximumProductUntillNow = 1;
                    maximumProdcutAtThis = 1;                    
                }
                
            }

            return maximumProductGlobally;
        }

        //O(N)  // Kadane's algorithm
        private static int FindLargestContiguosSum(int[] array)
        {
            int maximumSoFar = int.MinValue;
            int maximumTillHere = 0;

            for (int index = 0; index < array.Length; index++)
            {
                maximumTillHere += array[index];

                maximumSoFar = maximumTillHere > maximumSoFar ? maximumTillHere : maximumSoFar;

                maximumTillHere = maximumTillHere < 0 ? 0 : maximumTillHere;
            }

            return maximumSoFar;
        }

        //O(N)
        private static void FindDuplicateNumberInArray(int[] array)
        {
            #region approach1
            Console.WriteLine("Repeating number are as below :");
            //int lengthOfArray = array.Length;
            //for (int index = 0; index < lengthOfArray; index++)
            //{
            //    int absValue = Math.Abs(array[index]);
            //    if (array[absValue] >= 0)
            //        array[absValue] = -array[absValue];
            //    else
            //        Console.WriteLine(Math.Abs(absValue));
            //}
            #endregion

            #region Approach2
            for (int index = 0; index < array.Length; index++)
            {
                int number = array[index] % array.Length;
                array[number] += array.Length;

            }
            for (int index = 0; index < array.Length; index++)
            {
                if(array[index]>array.Length*2)
                    Console.WriteLine(index);
            }
            #endregion
        }

        //O(N)
        private static int FindNumberOfPairsHavingSum(int[] array, int sum)
        {
            #region O(NlogN) Approach
            // sort the array using heapsort in NlogN time and then
            // use two pointer method to find out given sum in O(N) time
            //Total time= O(NlogN)+O(N)
            #endregion

            #region O(N) Approach
            Dictionary<int, int> elementOccurances = new Dictionary<int, int>();
            int lengthOfArray = array.Length;
            int numberOfPairsWithSum = 0;
            for (int index = 0; index < lengthOfArray; index++)
            {
                if (elementOccurances.ContainsKey(array[index]))
                    elementOccurances[array[index]]++;
                else
                    elementOccurances.Add(array[index], 1);
            }

            foreach (var keyValuePair in elementOccurances)
            {
                int pair = sum - keyValuePair.Key;
                if (elementOccurances.ContainsKey(pair))
                {
                    if (elementOccurances[pair] > 1)
                        numberOfPairsWithSum += elementOccurances[pair];
                    else if (elementOccurances[pair]==1)
                        numberOfPairsWithSum++;
                }
                    
            }

            return numberOfPairsWithSum / 2;
            #endregion
        }

        private static void Arrange0s1s2sInArray(int[] array)
        {
            int lengthOfArray = array.Length;
            int lowIndex=0, middleIndex = 0;
            int highIndex = lengthOfArray - 1;

            for (int index = 0; index < lengthOfArray; index++)
            {
                if (array[middleIndex] == 0)
                {
                    Swap(array, lowIndex, middleIndex);
                    lowIndex++;
                    middleIndex++;
                }
                else if(array[middleIndex]==1)
                {
                    middleIndex++;
                }
                else if(array[middleIndex]==2)
                {
                    Swap(array, middleIndex, highIndex);
                    
                    highIndex--;
                }
            }
        }

        private static void Swap(int[] array, int fromIndex , int toIndex)
        {
            int temp = array[fromIndex];
            array[fromIndex] = array[toIndex];
            array[toIndex] = temp;
        }

        private static bool CheckIfKeyIsPresentInAllSegments(int[] array, int key, int windowSize)
        {
            bool isKeyPresentInSegment = false;
            int lengthOfArray = array.Length;
            
            for (int index = 0; index < lengthOfArray; index+=windowSize)
            {
                if (index != 0 && !isKeyPresentInSegment) break;
                if (isKeyPresentInSegment) isKeyPresentInSegment = false;
                int counter = 0;
                while(counter < windowSize)
                {
                    if(index+counter <lengthOfArray)
                    {
                        if(array[index+counter]==key)
                        {
                            isKeyPresentInSegment = true;
                            break;
                        }
                    }
                    counter++;
                }
            }

            return isKeyPresentInSegment;
        }

        private static int FindKthMinimumElement(int[] array,int k)
        {
            #region O(NLogN) time and O(N) space
            //DoHeapSortingOnArray(array);
            //return array[k - 1];
            #endregion

            #region O(N) Time and O(K) space
            int[] kMimimumElementArray = new int[k];
            int indexOfMinArray = kMimimumElementArray.Length - 1;
            int lengthOfArray = array.Length;
            int minElement = int.MaxValue;
            for (int index = 0; index < lengthOfArray; index++)
            {
                if(minElement >array[index])
                {
                    minElement = array[index];
                    if(indexOfMinArray>=0)
                    {
                        kMimimumElementArray[indexOfMinArray] = minElement;
                        indexOfMinArray--;
                    }
                    else
                    {
                        RotateArrayRight(kMimimumElementArray, 0, kMimimumElementArray.Length - 1);
                        kMimimumElementArray[0] = minElement;
                    }
                }
            }
            return 0;
            #endregion
        }

        private static void DoHeapSortingOnArray(int[] array)
        {
            int[] heapArray = new int[array.Length];
            HeapSortingPreProcessing(heapArray,array);

            for (int index = 0; index < array.Length; index++)
            {
                int elementAt0Index = heapArray[0];
                heapArray[0] = heapArray[heapArray.Length - index - 1];
                HeapifyThisIndex(heapArray, 0, heapArray.Length - index - 1);
                array[heapArray.Length - index - 1]=elementAt0Index;
            }

        }

        private static void HeapSortingPreProcessing(int[] heapArray,int[] array)
        {
            
            for (int index = heapArray.Length-1 ; index >= 0; index--)
            {
                heapArray[index] = array[index];
                HeapifyThisIndex(heapArray, index, heapArray.Length);
            }
        }

        private static void HeapifyThisIndex(int[] heapArray, int index, int length)
        {
            int leftIndex = 2 * index + 1;
            int rightIndex = 2 * index + 2;

            int maximumElementIndex = index;

            if (leftIndex > length && rightIndex > length) return;

            if (leftIndex < length && heapArray[maximumElementIndex] < heapArray[leftIndex])
                maximumElementIndex = leftIndex;
            if (rightIndex < length && heapArray[maximumElementIndex] < heapArray[rightIndex])
                maximumElementIndex = rightIndex;

            if(maximumElementIndex!=index)
            {
                int temporaryHolder = heapArray[maximumElementIndex];
                heapArray[maximumElementIndex] = heapArray[index];
                heapArray[index] = temporaryHolder;
                HeapifyThisIndex(heapArray, maximumElementIndex, length);
            }
        }

        //O(N)
        private static void RearrangeArrayMaxMinElement(int[] array)
        {
            #region O(N) ExtraSpace
            //int lengthOfArray = array.Length;
            //int[] temporaryArray = new int[lengthOfArray];
            //int lowestElementIndex = 0, highestElementIndex = lengthOfArray - 1;
            //for (int index = 0; index < lengthOfArray; index++)
            //{
            //    if(index%2==0)
            //    {
            //        temporaryArray[index] = array[highestElementIndex];
            //        highestElementIndex--;
            //    }
            //    else
            //    {
            //        temporaryArray[index] = array[lowestElementIndex];
            //        lowestElementIndex++;
            //    }
            //}
            //for (int index = 0; index < lengthOfArray; index++)
            //{
            //    array[index] = temporaryArray[index];
            //}
            #endregion

            #region O(1) ExtraSpace
            int lengthOfArray = array.Length;
            int lastElementIndex = lengthOfArray - 1;

            for (int index = 0; index < lengthOfArray; index+=2)
            {
                int temporaryHolder = array[lastElementIndex];
                RotateArrayRight(array, index, lastElementIndex);
                array[index] = temporaryHolder;
            }
            #endregion
        }

        private static void RotateArrayRight(int[] array, int startingIndex, int EndingIndex)
        {
            for (int index = EndingIndex; index > startingIndex; index--)
            {
                //int tempHolder = array[index];
                array[index] = array[index - 1];

            }
        }

        //O(N)
        private static void DoubleTheValidElementAndPush0ToEnd(int[] array)
        {
            int lengthOfArray = array.Length;
            for (int index = 0; index < lengthOfArray-1; index++)
            {
                if (array[index] != 0 && array[index + 1] != 0)
                {
                    array[index] *= 2;
                    array[index + 1] = 0;
                }
                //else
                //    index++;
            }

            int countOfNonZeroElement = 0;
            for (int index = 0; index < lengthOfArray; index++)
            {
                if (array[index] != 0)
                    countOfNonZeroElement++;
            }

            int nonZeroIndex = 0;
            for (int index = 0; index < lengthOfArray; index++)
            {
                if(array[index]!=0)
                {
                    array[nonZeroIndex] = array[index];
                    nonZeroIndex++;
                }
            }

            while(countOfNonZeroElement<lengthOfArray)
            {
                array[countOfNonZeroElement] = 0;
                countOfNonZeroElement++;
            }
        }

        //O(N^2)
        private static void RearrangNegativeAndPositive(int[] array)
        {
            #region O(N^2) Approach
            //int lengthOfArray = array.Length;
            //for (int index = 0; index < lengthOfArray; index++)
            //{
            //    if (array[index] > 0)
            //        continue;
            //    int key = array[index];
            //    int shifterIndex = index-1;
            //    while(shifterIndex >=0 && array[shifterIndex]>0)
            //    {
            //        array[shifterIndex+1] = array[shifterIndex];
            //        shifterIndex--;
            //    }
            //    array[shifterIndex+1] = key;
            //}


            #endregion

            #region O(N)
            //two pointers technique
            int lengthOfArray = array.Length;
            int negativeIndex = 0, positiveIndex = lengthOfArray - 1;

            while(negativeIndex < positiveIndex)
            {
                if (negativeIndex < lengthOfArray && array[negativeIndex] < 0)
                    negativeIndex++;
                else if (positiveIndex > 0 && array[positiveIndex] > 0)
                    positiveIndex--;
                else
                {
                    Swap(array, negativeIndex, positiveIndex);
                }
            }
            
            #endregion
        }

       

        private static int FindMinimumSwapsRequiredToBringTogether(int[] array, int key)
        {
            int lengthOfArray = array.Length;
            int countOfNumberLessOrEqualKey = 0;
            int minimumSwaps = int.MaxValue;
            for (int index = 0; index < lengthOfArray; index++)
            {
                if (array[index] <= key) countOfNumberLessOrEqualKey++;
            }

            for (int index = 0; index <= lengthOfArray-countOfNumberLessOrEqualKey; index++)
            {
                int windowCounter = countOfNumberLessOrEqualKey;
                int currentSwaps = 0;
                while (windowCounter>0)
                {
                    if (array[index + windowCounter-1] > key)
                        currentSwaps++;
                    windowCounter--;
                }
                minimumSwaps = Math.Min(minimumSwaps, currentSwaps);
            }


            return minimumSwaps;
        }

        //O(N)
        private static void pushAllZeroToTheEndOfArray(int[] array)
        {
            int lengthOfArray = array.Length;
            int countOfNonZeroElements = 0;

            for (int index = 0; index < lengthOfArray; index++)
            {
                if(array[index] !=0)
                {
                    array[countOfNonZeroElements] = array[index];
                    countOfNonZeroElements++;
                }
            }

            while(countOfNonZeroElements<lengthOfArray)
            {
                array[countOfNonZeroElements] = 0;
                countOfNonZeroElements++;
            }
            
        }

        //O(N)
        private static void rearrangePositiveAndNegativeAtAlternatePosition(int[] array)
        {
            int lengthOfArray = array.Length;
            int positiveIndex = -1;
            for (int negativeIndex = 0; negativeIndex < lengthOfArray; negativeIndex++)
            {
                if (array[negativeIndex] < 0)
                {
                    //we are pushing the positive number to end. in a way sorting
                    positiveIndex++;
                    int temp = array[negativeIndex];
                    array[negativeIndex] = array[positiveIndex];
                    array[positiveIndex] = temp;
                }
            }

            positiveIndex += 1;
            int negativeIndex1 = 1;
            while(negativeIndex1 <lengthOfArray && positiveIndex<lengthOfArray && array[negativeIndex1] <0)
            {
                int temp = array[negativeIndex1];
                array[negativeIndex1] = array[positiveIndex];
                array[positiveIndex] = temp;
                positiveIndex++;
                negativeIndex1 += 2;
            }

        }

        

        private static int[] rearrangeArrayAsPerOddEvenPosition(int[] array)
        {
            int[] resultArrayToReturn = new int[array.Length];
            //we want to have heap sort so that it can take O(NlogN) time
            performHeapSortingOnArray(array);

            int lengthOfArray = array.Length;
            // if array's length is even then the last index will be odd which will be having
            //biggest element at the end
            if(lengthOfArray %2 ==0)
            {
                int counterForOriginalArray = lengthOfArray - 1;
                for (int oddIndex = lengthOfArray - 1; oddIndex > 0; oddIndex -= 2,counterForOriginalArray--)
                {
                    resultArrayToReturn[oddIndex] = array[counterForOriginalArray];
                }
                //counterForOriginalArray = 0;
                for (int evenIndex = 0; evenIndex < lengthOfArray; evenIndex+=2,counterForOriginalArray--)
                {
                    resultArrayToReturn[evenIndex] = array[counterForOriginalArray];
                }
            }
            // if array's length is odd then the last index will be event which will be having
            //smallest element at the end
            else
            {
                int counterForOriginalArray = 0;
                for (int evenIndex = lengthOfArray-1; evenIndex >= 0; evenIndex-=2,counterForOriginalArray++)
                {
                    resultArrayToReturn[evenIndex] = array[counterForOriginalArray];
                }
                //counterForOriginalArray = lengthOfArray - 1;
                for (int oddIndex = 1; oddIndex < lengthOfArray; oddIndex+=2,counterForOriginalArray++)
                {
                    resultArrayToReturn[oddIndex] = array[counterForOriginalArray];
                }
            }

            return resultArrayToReturn;

        }

        private static void performHeapSortingOnArray(int[] array)
        {
            int[] heapArray = new int[array.Length];
            for (int index = heapArray.Length-1; index >= 0; index--)
            {
                heapArray[index] = array[index];
                heapifyThisIndex(heapArray, index, heapArray.Length);
            }

            //now we will start deleting it from the heap and sort them

            for (int index = 0; index < heapArray.Length; index++)
            {
                int elementAt0Index = heapArray[0];
                heapArray[0] = heapArray[heapArray.Length - index - 1];
                heapifyThisIndex(heapArray, 0, heapArray.Length - index-1);
                heapArray[heapArray.Length - index - 1] = elementAt0Index;
            }

            for (int index = 0; index < array.Length; index++)
            {
                array[index] = heapArray[index];
            }
        }

        private static void heapifyThisIndex(int[] heapArray, int index, int length)
        {
            int leftChildIndex = index * 2 + 1;
            int rightChildIndex = index * 2 + 2;

            if (leftChildIndex > length && rightChildIndex > length) return;

            int maximumElementIndex = index;
            if (leftChildIndex < length && heapArray[leftChildIndex] >= heapArray[maximumElementIndex])
                maximumElementIndex = leftChildIndex;
            if (rightChildIndex < length && heapArray[rightChildIndex] > heapArray[maximumElementIndex])
                maximumElementIndex = rightChildIndex;

            if(maximumElementIndex != index)
            {
                int temporarayHolder = heapArray[index];
                heapArray[index] = heapArray[maximumElementIndex];
                heapArray[maximumElementIndex] = temporarayHolder;
                heapifyThisIndex(heapArray, maximumElementIndex, length);
            }

        }

        //O(N^2) and O(N)
        private static void rearrangeArrayWithElement(int[] array)
        {
            #region O(N^2) Solution
            int lengthOfArray = array.Length;
            for (int index = 0; index < lengthOfArray; index++)
            {
                for (int innerIndex = 0; innerIndex < lengthOfArray; innerIndex++)
                {
                    if (array[innerIndex] == index || array[innerIndex] == -1) continue;
                    else
                    {
                        int temporaryHolder = array[innerIndex];
                        array[innerIndex] = array[temporaryHolder];
                        array[temporaryHolder] = temporaryHolder;
                    }

                }
            }
            #endregion
            
        }

        //O(N^2)+O(N)=O(N^2)
        private static int findMaximumSumAfterRotatingArray(int[] array)
        {
            int biggestNumberInArray = array.Max();
            int lastIndexOfArray = array.Length - 1;
            int sumToBeReturned = 0;
            while(biggestNumberInArray != array[lastIndexOfArray])
            {
                rotateUntillMaxNumberReachesToEnd(array);
            }
            for (int index = 0; index <= lastIndexOfArray; index++)
            {
                sumToBeReturned += index * array[index];
            }

            return sumToBeReturned; //TODO
        }

        //O(N)
        private static void rotateUntillMaxNumberReachesToEnd(int[] array)
        {
            int lengthOfArray = array.Length;
            int temporaryHolder = array[0];
            for (int index = 0; index < lengthOfArray-1; index++)
            {
                array[index] = array[index + 1];
            }
            array[lengthOfArray - 1] = temporaryHolder;
        }

        //Two Binary Search O(LogN)+O(LogN) ~O(LogN)
        private static int findIndexOfKeyElementInRotatedArray(int[] array, int keyToBeFound)
        {
            int lengthOfArray = array.Length;
            const int START_OF_ARRAY = 0;
            int indexOfPivot = FindIndexOfPivotElement(array, START_OF_ARRAY, lengthOfArray - 1);

            if (array[START_OF_ARRAY] > keyToBeFound)
                return BinarySearch(array, indexOfPivot+1, lengthOfArray-1,keyToBeFound);
            if (array[START_OF_ARRAY] < keyToBeFound)
                return BinarySearch(array, START_OF_ARRAY, indexOfPivot,keyToBeFound);
            return 0;
        }

        //Official Binary Search O(LogN)
        private static int BinarySearch(int[] array, int StartOfArrayIndex, int EndOfArrayIndex,int keyToBeFound)
        {
            if (StartOfArrayIndex > EndOfArrayIndex) return -1;
            int MiddleIndex = (EndOfArrayIndex + StartOfArrayIndex) / 2;
            if (array[MiddleIndex] == keyToBeFound)
                return MiddleIndex;
            if (array[MiddleIndex] > keyToBeFound)
                return BinarySearch(array, StartOfArrayIndex, MiddleIndex-1, keyToBeFound);
            if (array[MiddleIndex] < keyToBeFound)
                return BinarySearch(array, MiddleIndex+1, EndOfArrayIndex, keyToBeFound);

            return -1;
        }

        //using Binary Search so O(LogN)
        private static int FindIndexOfPivotElement(int[] array, int StartOfArrayIndex, int EndOfArrayIndex)
        {
            if (StartOfArrayIndex == EndOfArrayIndex)
                return 1;
            if (EndOfArrayIndex < StartOfArrayIndex)
                return -1;

            int MiddleIndex = (EndOfArrayIndex + StartOfArrayIndex) / 2;

            if (MiddleIndex < EndOfArrayIndex && array[MiddleIndex] > array[MiddleIndex + 1])
                return MiddleIndex;
            if (MiddleIndex > StartOfArrayIndex && array[MiddleIndex] < array[MiddleIndex - 1])
                return MiddleIndex - 1;
            if (array[MiddleIndex] < array[MiddleIndex + 1])
                return FindIndexOfPivotElement(array, MiddleIndex, EndOfArrayIndex);

            return MiddleIndex;
        }

        //O(n^2)
        private static int findMaximumSumOfHourGlass(int[,] array)
        {
            int SumToBeReturned = int.MinValue;
            int SumForThisHourGlass = 0;
            int rowBoundry = array.GetUpperBound(0) / 2+1;
            int columnBoundry = array.GetUpperBound(1) / 2+1;

            for (int rowIndex = 0; rowIndex <= rowBoundry; rowIndex++)
            {
                SumForThisHourGlass = int.MinValue;
                for (int columnIndex = 0; columnIndex <= columnBoundry; columnIndex++)
                {
                    SumForThisHourGlass = array[rowIndex, columnIndex] + array[rowIndex, columnIndex + 1] + array[rowIndex, columnIndex + 2]
                                                                + array[rowIndex + 1, columnIndex + 1]
                                        + array[rowIndex + 2, columnIndex] + array[rowIndex + 2, columnIndex + 1] + array[rowIndex + 2, columnIndex + 2];

                    SumToBeReturned = SumForThisHourGlass > SumToBeReturned ? SumForThisHourGlass : SumToBeReturned;
                }
                
            }

            return SumToBeReturned;
        }

        //O(N)
        private static int[] reverseArray(int[] array)
        {
            int lengthOfArray = array.Length;
            const int DIVIDER = 2; //we will rotate half part
            for (int index = 0; index < lengthOfArray/DIVIDER; index++)
            {
                int temporaryHolder;
                temporaryHolder = array[index];
                array[index] = array[lengthOfArray - index - 1];
                array[lengthOfArray - index - 1] = temporaryHolder;
            }

            return array;
        }

        private static int[,] ConvertNestedListTo2DArray(List<List<int>> list)
        {
            int[,] array = new int[list.Count,list[0].Count];
            for (int j = 0; j < list.Count; j++)
            {
                for (int i = 0; i < list[j].Count; i++)
                {
                    array[j, i] = list[j][i];
                }
            }
            return array;
        }
    }
}
