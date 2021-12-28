using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Roadies
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfTestCases;
            Int32.TryParse(Console.ReadLine(), out numberOfTestCases);
            int[] numberOfBoxes = new int[numberOfTestCases];
            string[] tempArr = null;
            List<string[]> tempHolder = new List<string[]>();
            List<List<int>> boxNumbers = new List<List<int>>();
            for (int i = 0; i < numberOfTestCases; i++)
            {
                Int32.TryParse(Console.ReadLine(), out numberOfBoxes[i]);
                tempArr = Console.ReadLine().Trim().Split(' ');
                tempHolder.Add(tempArr);
            }

            for (int i = 0; i < tempHolder.Count; i++)
            {
                int[] tempIntArr = new int[tempHolder.ElementAt(i).Length];
                string[] temp = tempHolder.ElementAt(i);
                for (int j = 0; j < temp.Length; j++)
                {
                    Int32.TryParse(temp[j], out tempIntArr[j]);
                }
                var templist = tempIntArr.ToList();
                boxNumbers.Add(templist);
            }

            for (int i = 0; i < numberOfTestCases; i++)
            {
                Console.WriteLine(FindMaxSumForRanvijay(boxNumbers.ElementAt(i)));
            }
            Console.ReadLine();
        }

        private static int FindMaxSumForRanvijay(List<int> boxNumber)
        {
            //int returnMaxSum=0;
            //if there is one number then it is the greater
            if (boxNumber.Count == 1) return boxNumber[0];

            int[] BitArray = new int[1024];
            for (int i = 0; i < BitArray.Length; i++) BitArray[i] = -1;

            int returnMaxSum = 0;
            for (int i = 0; i < BitArray.Length; i++)
            {
                returnMaxSum = Math.Max(returnMaxSum, DynamicProgApproach(i, BitArray, boxNumber));
            }

            //List<int> consideredAlready = new List<int>();
            ////step 1) //very first thing is we will sort the array from max to min
            //boxNumber = boxNumber.OrderByDescending(x => x).ToArray();
            //int[,] globalArray = new int[boxNumber.Length, 10];


            #region algorithm 4
            //make all the combination. don't worrry abt the sum

            /// I have super hope on this method. wating for stack overflow- somehow took me to 24 and done
            //List<List<int>> combinationList = new List<List<int>>();
            //for (int i = 0; i < boxNumber.Length; i++)
            //{
            //    int prevLast = -1;
            //    while (true)
            //    {
            //        int localMaxSum = 0;  //new line
            //        bool breakLoop = false;
            //        int[] numberLocalArr = new int[10];
            //        for (int pass = 0; pass < numberLocalArr.Length; pass++)
            //        {
            //            numberLocalArr[pass] = -1;
            //        }
            //        List<int> localList = new List<int>();
            //        localMaxSum += boxNumber[i];
            //        localList.Add(i);
            //        BreakTheNumber(boxNumber[i], numberLocalArr);
            //        for (int j = i + 1; j < boxNumber.Length; j++)
            //        {
            //            if (prevLast == j) continue;
            //            if (BreakTheNumberAndCheck(boxNumber[j], numberLocalArr))
            //            {
            //                localList.Add(j);
            //                //prevLast = j;
            //                localMaxSum += boxNumber[j];
            //            }
            //        }
            //        prevLast = localList.Last();
            //        if (combinationList.Count == 0) combinationList.Add(localList);
            //        else
            //        {
            //            if(combinationList.Any(c=>c.SequenceEqual(localList)))
            //            {
            //                breakLoop = true;
            //            }
            //            else
            //            {
            //                combinationList.Add(localList);
            //            }
            //        }

            //        if (breakLoop) break;
            //        if (localMaxSum > returnMaxSum) returnMaxSum = localMaxSum;
            //    }

            //}
            #endregion
            #region algorithm5
            //List<List<int>> combinationList = new List<List<int>>();
            //for (int i = 0; i < boxNumber.Length; i++)
            //{
            //    int prevLast = -1;
            //    while (true)
            //    {
            //        int localMaxSum = 0;  //new line
            //        bool breakLoop = false;
            //        int[] numberLocalArr = new int[10];
            //        for (int pass = 0; pass < numberLocalArr.Length; pass++)
            //        {
            //            numberLocalArr[pass] = -1;
            //        }
            //        List<int> localList = new List<int>();
            //        localMaxSum += boxNumber[i];
            //        localList.Add(i);
            //        BreakTheNumber(boxNumber[i], numberLocalArr);
            //        for (int j = i + 1; j < boxNumber.Length; j++)
            //        {

            //            if (BreakTheNumberAndCheck(boxNumber[j], numberLocalArr))
            //            {

            //                localMaxSum += boxNumber[j];
            //            }
            //        }

            //        if (breakLoop) break;
            //        if (localMaxSum > returnMaxSum) returnMaxSum = localMaxSum;
            //    }

            //}
            #endregion

            return returnMaxSum;
        }

        private static int DynamicProgApproach(int i, int[] bitArray, List<int> boxNumber)
        {
            if (i == 0)
            {
                return bitArray[i] = 0;
            }
            if (bitArray[i] != -1)
                return bitArray[i];

            int res = 0;
            foreach (var num in boxNumber)
            {
                int bitmask = 0;
                for (int k = 1; num / k > 0; k *= 10)
                {
                    int digit = num / k % 10;
                    
                    bitmask |= 1 << digit;
                }

                if ((i | bitmask) == i)
                    res = Math.Max(DynamicProgApproach(i ^ bitmask, bitArray, boxNumber) + num, res);
            }
            return bitArray[i] = res;
        }

        private static int MaskTheNum(int n)
        {
            int mask = 0;
            for (int i = 1; n / i > 0; i *= 10)
            {
                int digit = n / i % 10;
                var a = 1 << digit; ;
                mask |= 1 << digit;
            }
            return mask;
        }

        private static int FindMaxSum(int[] boxNumber, int start, int end,int[,] globalArray)
        {
           if(start==end)  //base case 1
            {
                return boxNumber[start];
            }
           if(end-start==1)  //base case2
            {
                for (int d = 0; d < 9; d++)
                {
                    if(globalArray[start,d]>0 && globalArray[end,d]>0)
                    {
                        return boxNumber[start] > boxNumber[end] ? boxNumber[start] : boxNumber[end];
                    }
                }

                return boxNumber[start] + boxNumber[end];
            }

            int midend, midstart;
            midend = Convert.ToInt16(Math.Round(Convert.ToDouble(boxNumber.Length / 2)));
            midstart = midend + 1;

            return FindMaxSum(boxNumber, 0, midend, globalArray) + FindMaxSum(boxNumber, midstart, end, globalArray);





        }

        private static bool checkTheNumberWithGlobalArr(int v,int n, int[,] globalArray,List<int> consideredList)
        {
            bool returnBool = true;
            int[] cnt = new int[10];
            while (v > 0)
            {
                cnt[v % 10] = 1;
                v /= 10;
            }

            foreach (int i in consideredList)
            {
                for (int d = 0; d <= 9; d++)
                {
                    if (cnt[d] > 0 && globalArray[i,d]>0)
                    {
                        return false;
                    }
                }
            }
            return returnBool;
        }

        private static void PrepareGlobalArray(int[] arr, int n, int[,] globalArray)
        {
            int tmp;
            int[] cnt = new int[10];

            // For first element maximum length is 1 for 
            // each digit 
            tmp = arr[0];
            while (tmp > 0)
            {
                globalArray[0, tmp % 10] = 1;
                tmp /= 10;
            }

            for (int i = 1; i < n; i++)
            {
                tmp = arr[i];
                //locMax = 1;
                for (int x = 0; x < 10; x++)
                    cnt[x] = 0;

                // Find digits in current element 
                while (tmp > 0)
                {
                    cnt[tmp % 10] = 1;
                    tmp /= 10;
                }
                for (int d = 0; d <= 9; d++)
                {
                    if (cnt[d] > 0)
                    {
                        globalArray[i, d] = 1;

                    }
                }

            }
        }


        // if the number is considerable
        private static bool BreakTheNumberAndCheck(int n, int[] globalArray)
        {
            bool returnbool = false;
            List<int> localList = new List<int>();  //this is just for this number
            int rem;
            while (n != 0)
            {
                rem = n % 10;
                if (globalArray.ToList().Exists(x => x == rem)) return false;
                if(!(localList.Exists(x=>x==rem)) && !(globalArray.ToList().Exists(x=>x==rem))) localList.Add(rem);
                //if (!(localList.Exists(x => x == rem)) ) localList.Add(rem);
                n /= 10;
            }

            var CommonNumbres=globalArray.ToList().Intersect(localList).ToList();

            if (CommonNumbres.Count==0)
            {
                foreach (var item in localList)
                {
                    globalArray[item] = item;
                }
                returnbool = true;
            }
                
            else
            {
                returnbool = false;
            }
            
            return returnbool;
        }
        private static void BreakTheNumber(int n,int[] globalArray)
        {
            //List<int> returnResult = new List<int>();
            int rem;
            while (n != 0)
            {
                rem = n % 10;
                globalArray[rem] = rem;
                n /= 10;
            }
            //return considered;
        }
    }
}

#region comment


#region Recursion
//PrepareGlobalArray(boxNumber, boxNumber.Length, globalArray);

//var resultSum = FindMaxSum(boxNumber, 0, boxNumber.Length - 1,globalArray);

#endregion
//==========================================================================================================
//step 4) select next big and add them as well
#region algorithm1

//for (int j = 0; j < boxNumber.Length/2; j++)
//{
//    int lastConsideredIndexInPrevPass = -1;
//    consideredAlready.Clear();

//    while (consideredAlready.Count == 0||consideredAlready.Last() < boxNumber.Length-1)
//    {
//        if(consideredAlready.Count!=0)  lastConsideredIndexInPrevPass = consideredAlready.Last();
//        int localMaxsum = 0;
//        int[] numberLocalArr = new int[10];
//        localMaxsum += boxNumber[j];
//        consideredAlready.Add(j);
//        BreakTheNumber(boxNumber[j], numberLocalArr);
//        for (int i = j+1; i < boxNumber.Length; i++)
//        {
//            if (i == j) continue;
//            //if (consideredAlready.Exists(x => x == i)) continue; //not reliable but we will see
//            if (lastConsideredIndexInPrevPass == i) continue;
//            //bool canWeGoAhead;
//            if (BreakTheNumberAndCheck(boxNumber[i], numberLocalArr))
//            {
//                localMaxsum += boxNumber[i];
//                consideredAlready.Add(i);
//            }
//        }
//        if (localMaxsum > returnMaxSum)
//        {
//            returnMaxSum = localMaxsum;
//        }
//        if (localMaxsum < returnMaxSum) break;
//    }
//}
#endregion
//bool EasyArray = false;
//int[] maxSumPreserv = new int[boxNumber.Length/2+1];

//step 0.5) //decide if we want to sumup everything, if all are different

//TODO : redesign this
#region redesign
//int prevEle = -1;
//for (int i = 0; i < boxNumber.Length; i++)
//{
//    if (prevEle == boxNumber[i])
//    {
//        EasyArray = true;
//        break;
//    }

//    prevEle = boxNumber[i];

//}
//if(EasyArray)
//{
//   return boxNumber.Sum();
//}

#endregion
// now the real work starts here

//step 2) take the highest number
//returnMaxSum += boxNumber[0];

//step 3) get the elements in the array
// BreakTheNumber(boxNumber[0], numberGlobalArray);
//consideredAlready = BreakTheNumber(boxNumber[0],consideredAlready);
//==========================================================================================================
#region  algorithm 2

// going in loops
//for (int index = 0; index < boxNumber.Length; index++)
//{
//    int lastConsideredIndex = 0;
//    int lastConsideredIndexPrevIteration = 0;

//    //int searchIndex = 0; //start from next index
//    int savprevsum=-1;

//    while (true)
//    {

//        int localMaxsum = 0;
//        if (lastConsideredIndex+1 == boxNumber.Length) break;


//        int[] numberLocalArr = new int[10];
//        localMaxsum += boxNumber[index];
//        BreakTheNumber(boxNumber[index], numberLocalArr);



//        //if (lastConsideredIndex == 0) searchIndex = 1;//if we just started then first
//        //else searchIndex = lastConsideredIndex+1;    //otherwise last considered
//        int searchIndex = index + 1;

//        for (; searchIndex < boxNumber.Length; searchIndex++)
//        {

//            if (searchIndex == lastConsideredIndexPrevIteration) continue;
//            if (BreakTheNumberAndCheck(boxNumber[searchIndex], numberLocalArr))
//            {
//                localMaxsum += boxNumber[searchIndex];
//                lastConsideredIndex = searchIndex;
//                if(searchIndex>lastConsideredIndexPrevIteration) lastConsideredIndexPrevIteration = searchIndex;
//            }
//            //searchIndex++;
//        }
//        savprevsum = localMaxsum;

//        if (localMaxsum>returnMaxSum)
//        {
//            returnMaxSum = localMaxsum;
//        }
//        if ((localMaxsum == boxNumber[index])) || (savprevsum==lo) break;
//    }

//}

#endregion

#region algorithm 3
//PrepareGlobalArray(boxNumber, boxNumber.Length, globalArray);

//int searchIndex = 0;
//for (int index = 0; index < boxNumber.Length; index++)
//{
//    //consideredAlready.Clear();
//    while (consideredAlready.Count==0 || consideredAlready.Last()<boxNumber.Length)
//    {
//        int localMaxSum = 0;
//        //searchIndex = consideredAlready.Last();

//        //consideredAlready.RemoveAt(consideredAlready.Last());
//        if(consideredAlready.Count!=0)
//        {
//            searchIndex = consideredAlready.Last();
//            consideredAlready.RemoveAt(consideredAlready.Count-1);
//            foreach (var item in consideredAlready)
//            {
//                if(!consideredAlready.Exists(x=>x==item))
//                {
//                    localMaxSum += boxNumber[index];
//                    consideredAlready.Add(index);
//                }
//            }
//        }



//        if (consideredAlready.Count == 0)
//        {
//            searchIndex = index + 1;
//            localMaxSum += boxNumber[index];
//            consideredAlready.Add(index);

//        }
//        //else
//        //{
//        //    searchIndex = consideredAlready.Last();
//        //    consideredAlready.RemoveAt(consideredAlready.Last());
//        //}

//        for (; searchIndex < boxNumber.Length; searchIndex++)
//        {
//            if (checkTheNumberWithGlobalArr(boxNumber[searchIndex], boxNumber.Length, globalArray, consideredAlready))
//            {
//                localMaxSum += boxNumber[searchIndex];
//                consideredAlready.Add(searchIndex);
//            }
//        }
//        if (localMaxSum > returnMaxSum)
//        {
//            returnMaxSum = localMaxSum;
//        } 
//    }

//}





#endregion
#endregion