using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewYearParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfTestCases;
            Int32.TryParse(Console.ReadLine(), out numberOfTestCases);

            int[] numberOfTickets = new int[numberOfTestCases];
            string[] tempArr = null;
            List<string[]> tempHolder = new List<string[]>();
            List<int[]> ticketList = new List<int[]>();
            for (int i = 0; i < numberOfTestCases; i++)
            {
                Int32.TryParse(Console.ReadLine(), out numberOfTickets[i]);
                tempArr = Console.ReadLine().Trim(). Split(' ');
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
                ticketList.Add(tempIntArr);
            }

            for (int i = 0; i < numberOfTestCases; i++)
            {
                Console.WriteLine(PrepareSequence(ticketList.ElementAt(i)));
            }
            Console.ReadLine();
        }

        private static string PrepareSequence(int[] ArrayToWork)
        {
            string returnString=string.Empty;
            List<int> selectedIndex = new List<int>();
            int sumOfSelectedIndex = 0;
            int[] ExcludeArray = new int[ArrayToWork.Length];
            int[] IncludeArray = new int[ArrayToWork.Length];
            MakeArraysToWork(ArrayToWork, ExcludeArray, IncludeArray);
            Console.WriteLine();
            Console.WriteLine("Array" + "\t" + "Incl" + "\t" + "Excl");
            for (int inn = 0; inn < IncludeArray.Length; inn++)
            {
                Console.WriteLine(ArrayToWork[inn] + "\t " + IncludeArray[inn] + " \t " + ExcludeArray[inn]);
            }

            //start from the last index and progress through up
            for (int indexLast = ArrayToWork.Length -1 ; indexLast >= 1; indexLast--)
            {
                if (CheckIfNeighbours(selectedIndex, indexLast)) continue; // if the last selected was neighbour then do not go forward
                if(ExcludeArray[indexLast]>IncludeArray[indexLast] )
                {
                    continue; // exclude is greater so we want to exclude this index. Let's move forward
                }
                else if (ExcludeArray[indexLast] == IncludeArray[indexLast])
                {
                    //here exclude and include are same so we want to make sure if the next is having greater value with same
                    //weight then select it
                    if(IncludeArray[indexLast] == IncludeArray[indexLast -1] && ArrayToWork[indexLast]<=ArrayToWork[indexLast-1])
                    {
                        selectedIndex.Add(indexLast - 1);
                        sumOfSelectedIndex += ArrayToWork[indexLast - 1];
                    }
                }
                else if(ExcludeArray[indexLast] < IncludeArray[indexLast])
                {
                    selectedIndex.Add(indexLast);
                    sumOfSelectedIndex += ArrayToWork[indexLast];
                }

            }
            if(!CheckIfNeighbours(selectedIndex,0))
            {
                if(sumOfSelectedIndex < sumOfSelectedIndex+ArrayToWork[0])
                {
                    selectedIndex.Add(0);
                }
            }

            selectedIndex.Sort();
            for (int i = selectedIndex.Count-1; i >= 0; i--)
            {
                returnString += ArrayToWork[selectedIndex.ElementAt(i)];
            }
            return returnString;
        }

        private static void MakeArraysToWork(int[] arrayToWork, int[] excludeArray, int[] includeArray)
        {
            int includingIndex = arrayToWork[0];

            int prevExcludingIndex = 0;
            int currentExcludingIndex;

            for (int index = 1; index < arrayToWork.Length; index++)
            {
                currentExcludingIndex = includingIndex > prevExcludingIndex ? includingIndex : prevExcludingIndex;
                includingIndex = prevExcludingIndex + arrayToWork[index];
                includeArray[index] = includingIndex;

                prevExcludingIndex = currentExcludingIndex;
                excludeArray[index] = prevExcludingIndex;

            }
        }

        private static int returnBiggestValueIndex(List<int> leftChoosen, int[] arrayToWork)
        {
            int biggest=-1;
            int max = -1001;
            foreach (int index in leftChoosen)
            {
                if(max<arrayToWork[index])
                {
                    max = arrayToWork[index];
                    biggest = index;
                }
            }

            return biggest;
        }

        private static List<int> findAllPosssibleNeighbours(List<int> choosenOne, int len)
        {
            List<int> returnList = new List<int>();
            for (int i = 0; i < len; i++)
            {
                if (choosenOne.Exists(x => x == i)) continue;
                if(!CheckIfNeighbours(choosenOne,i))
                {
                    returnList.Add(i);
                }
            }
            return returnList;
        }

        private static string convertit(int input)
        {
            return input.ToString();
        }

        private static bool CheckIfNeighbours(List<int> consideredElement, int j)
        {
            //bool returnBool = false;
            if (consideredElement.Exists(x => x == j))
            {
                return true;
            }
            
            return consideredElement.Any(x => (x == j + 1)||(x == j - 1));
        }

        private static bool CheckIfNeighbours(int i, int j)
        {
            if (j == i + 1) return true;
            else return false;
        }

        private static int CheckSumOfThisList(List<int> tempList, int[] arrayToWork)
        {
            int sum = 0;
            foreach (var item in tempList)
            {
                sum += arrayToWork[item];
            }
            return sum;
        }

        private static void MakePossibleCombination(int[] arrayToWork, List<List<int>> possibleCombiOfTickets)
        {

            bool breakTheLoop= true;
            int addition;// = 2;
            for (int i = 0; i < arrayToWork.Length-2;i++ )
            {
                addition = 2;
                breakTheLoop = true;
                while (breakTheLoop)
                {
                    
                    List<int> tempList = new List<int>();
                    int j = i + addition;
                    tempList.Add(i);
                    for (; j < arrayToWork.Length; j+=2)
                    {
                        tempList.Add(j);
                    }
                    if ((i + addition) >= arrayToWork.Length-1) breakTheLoop = false;
                    addition++;
                    possibleCombiOfTickets.Add(tempList);
                    
                }
               
            }
        }

        //List<List<int>> listOFList = new List<List<int>>();


        #region atHomeMyMindWorksFaster
        //this region is with making an aray f max sum till now

        //List<int> maxSumAtThisIndexWithAllPossibilities = new List<int>();
        //List<List<int>> ConsideredElementAtThisIndex = new List<List<int>>();



        //for (int index = 0; index < ArrayToWork.Length/2+1; index++)
        //{

        //    int initialAddition = 2; // we will always start from immediate nonneighbour


        //    bool breakLook = true;
        //    while (breakLook)
        //    {
        //        List<int> indexMaxAtThisIndex = new List<int>(); // this will hold the maximum sum at this i , sume will be with all possibilities
        //        int currentSum = ArrayToWork[index];
        //        indexMaxAtThisIndex.Add(index);
        //        int j = index + initialAddition;  

        //        for (; j < ArrayToWork.Length; j += 2)
        //        {
        //           if(currentSum < currentSum + ArrayToWork[j])
        //            {
        //                currentSum +=  ArrayToWork[j];
        //                indexMaxAtThisIndex.Add(j);
        //            }
        //        }
        //        if (index + initialAddition > ArrayToWork.Length-1) breakLook = false;
        //        initialAddition++; // now the next seq is 3 and 4 and so on
        //        //if(maxSumAtThisIndexWithAllPossibilities[index] <= currentSum)
        //        if (maxSumAtThisIndexWithAllPossibilities.Count==0 || maxSumAtThisIndexWithAllPossibilities.Max() < currentSum)
        //        {
        //            maxSumAtThisIndexWithAllPossibilities.Add(currentSum); // a knid of memoization //this is like storing previous sum
        //            ConsideredElementAtThisIndex.Add(indexMaxAtThisIndex);
        //        }
        //        //if we are seeing the same result then decide the correct result here
        //        else if(maxSumAtThisIndexWithAllPossibilities.Max()==currentSum)
        //        {
        //            int reduce = 0;
        //            int mIndex = maxSumAtThisIndexWithAllPossibilities.FindIndex(x => x == maxSumAtThisIndexWithAllPossibilities.Max());
        //            List<int> tempList = ConsideredElementAtThisIndex.ElementAt(mIndex);
        //            tempList=tempList.OrderByDescending(x => x).ToList();
        //            indexMaxAtThisIndex=indexMaxAtThisIndex.OrderByDescending(x=>x).ToList();
        //            while (true)
        //            {
        //                if (tempList.Count >= reduce || indexMaxAtThisIndex.Count >= reduce) break;
        //                if (ArrayToWork[tempList.ElementAt(reduce)] < ArrayToWork[indexMaxAtThisIndex.ElementAt(reduce)])
        //                {
        //                    ConsideredElementAtThisIndex.RemoveAt(mIndex);
        //                    ConsideredElementAtThisIndex.Insert(mIndex, indexMaxAtThisIndex);
        //                    break;
        //                }

        //                else if (ArrayToWork[tempList.ElementAt(reduce)] > ArrayToWork[indexMaxAtThisIndex.ElementAt(reduce)])
        //                    break;

        //                else if (ArrayToWork[tempList.ElementAt(reduce)] == ArrayToWork[indexMaxAtThisIndex.ElementAt(reduce)])
        //                    reduce++;

        //            }
        //        }

        //    }
        //}
        ////now these are the indexes where maximum sum lies
        //var indexesWhereMaxSumLies = maxSumAtThisIndexWithAllPossibilities.Select((b, i) => b == maxSumAtThisIndexWithAllPossibilities.Max() ? i : -1).Where(i => i != -1).ToArray();

        //foreach (var index in indexesWhereMaxSumLies)
        //{
        //      List<int> LeftChoosen = new List<int>();
        //      LeftChoosen = findAllPosssibleNeighbours(ConsideredElementAtThisIndex.ElementAt(index), ArrayToWork.Length);
        //    if (LeftChoosen.Count == 0) continue;
        //    foreach (var item in LeftChoosen)
        //    {
        //        if(maxSumAtThisIndexWithAllPossibilities.ElementAt(index) < maxSumAtThisIndexWithAllPossibilities.ElementAt(index) + ArrayToWork[item])
        //        {
        //            //maxSumAtThisIndexWithAllPossibilities.ElementAt(index)= maxSumAtThisIndexWithAllPossibilities.ElementAt(index) + ArrayToWork[item]
        //            ConsideredElementAtThisIndex.ElementAt(index).Add(item);
        //        }
        //    }
        //}

        ////TODO- return the correct result when two are having same some
        //var semifinal = ConsideredElementAtThisIndex.ElementAt(indexesWhereMaxSumLies[0]);//.OrderByDescending(x => x).ToList();
        //var final = semifinal.OrderByDescending(x => x).ToList();
        //foreach (int item in final )
        //{
        //    returnString = returnString + ArrayToWork[item];
        //}




        #endregion

        #region doubleMatrix
        //  int[,] weightMatrixOfTickets = new int[ArrayToWork.Length,ArrayToWork.Length];
        //  int[] MaxSumFromThisIndex = new int[ArrayToWork.Length]; // this will have max sum of all indexes
        //  List<int>[] consideredElementArrayAtThisIndex = new List<int>[ArrayToWork.Length]; // this has all considered neighbours which makes biggest sum

        //  //fill the matrix
        //  for (int row = 0; row < ArrayToWork.Length; row++)
        //  {
        //      for (int column = 0; column < ArrayToWork.Length; column++)
        //      {
        //          if (row == column)
        //              weightMatrixOfTickets[row, column] = ArrayToWork[row];
        //          else if ((!(row == column + 1)) && (!(row == column - 1)))
        //              weightMatrixOfTickets[row, column] = ArrayToWork[row] + ArrayToWork[column];
        //          else
        //              weightMatrixOfTickets[row, column] = -1001; //this is invalid
        //      }

        //  }

        //  // now travers the biggest sum


        //  for (int row = 0; row < ArrayToWork.Length/2+1; row++)
        //  {
        //      List<int> tempList = new List<int>();
        //      int maxSum = 0;
        //      //maxSum = ArrayToWork[row];
        //      var tempArray = new int[ArrayToWork.Length];
        //      const int intSize = 4;
        //      Buffer.BlockCopy(weightMatrixOfTickets, intSize * ArrayToWork.Length * row, tempArray, 0, intSize * ArrayToWork.Length);
        //      int maxIndex = tempArray.ToList().FindIndex(x => x == tempArray.Max());
        //      maxSum = tempArray.Max();
        //      if(row==maxIndex)
        //      {
        //          tempList.Add(row);
        //      }
        //      else
        //      {
        //          tempList.Add(row);
        //          tempList.Add(maxIndex);
        //      }


        //      MaxSumFromThisIndex[row] = maxSum;
        //      consideredElementArrayAtThisIndex[row] = tempList;
        //  }
        //  // this is just one level
        //var result=  Enumerable.Range(0, MaxSumFromThisIndex.Length)
        //   .Where(i => MaxSumFromThisIndex[i] == MaxSumFromThisIndex.Max())
        //   .ToList();
        //  int maxIndexTillNow = MaxSumFromThisIndex.ToList().FindIndex(x => x == MaxSumFromThisIndex.Max());
        //  int maxSumTillNow = MaxSumFromThisIndex.Max();
        //  List<int> choosenOne = consideredElementArrayAtThisIndex[maxIndexTillNow];

        //  List<int> LeftChoosen = new List<int>();
        //  LeftChoosen = findAllPosssibleNeighbours(choosenOne,ArrayToWork.Length);

        //  if (LeftChoosen.Count == 0)
        //      goto Done;
        //  //now we need to pick those which needs to be in the list
        //  bool breakLoop=true;
        //  while (breakLoop)
        //  {
        //      int last = choosenOne.Last();
        //      int biggestIndex = returnBiggestValueIndex(LeftChoosen, ArrayToWork);
        //      if (biggestIndex == -1) break;
        //      if (!CheckIfNeighbours(choosenOne, biggestIndex))
        //      {
        //          if(maxSumTillNow<maxSumTillNow+ArrayToWork[biggestIndex])
        //          {
        //              choosenOne.Add(biggestIndex);
        //              LeftChoosen.Remove(biggestIndex);
        //          }

        //      }
        //      //if (LeftChoosen.Count == 0 || (CheckIfNeighbours(choosenOne, biggestIndex) && LeftChoosen.Count==1 && maxSumTillNow < maxSumTillNow + ArrayToWork[biggestIndex]))
        //      if(last==choosenOne.Last())
        //          breakLoop = false;


        //  }


        //  Done:
        //  choosenOne.Sort();
        //  for (int i = choosenOne.Count - 1; i >= 0; i--)
        //  {
        //      returnString += ArrayToWork[choosenOne.ElementAt(i)].ToString();
        //  }



        #endregion

        #region DynamicProgramingFULLANDFINAL

        //List<int>[] neighboursArray = new List<int>[ArrayToWork.Length]; // this has all possible neighbours of a particular index
        ////List<int> consideredElement = new List<int>();
        //int[] MaxSumFromThisIndex = new int[ArrayToWork.Length]; // this will have max sum of all indexes
        //List<int>[] consideredElementArrayAtThisIndex = new List<int>[ArrayToWork.Length]; // this has all considered neighbours which makes biggest sum


        ////we are preparing for the neighbours. we will not go back as anyway the same combination are there in forward list
        ////for eg 854318 we will move forward as the revers will add overhead
        //for (int i = 0; i < ArrayToWork.Length; i++)
        //{

        //        List<int> tempList = new List<int>();

        //        for (int j=0; j < ArrayToWork.Length; j ++)
        //        {
        //            if( !(i==j) && !(i==j+1) && !(i==j-1))
        //            tempList.Add(j);
        //        }

        //        neighboursArray[i] = tempList;

        //}
        ////combination making ends here
        //bool[] isThisIndexChecked = new bool[neighboursArray.Length];
        //for (int i = 0; i < neighboursArray.Length; i++)
        //{
        //    if (isThisIndexChecked[i]) continue;

        //    bool workDone = true;
        //    List<int> consideredIndex = new List<int>(); // this is local for this index only
        //    int PreviousSum = ArrayToWork[i]; //think the first element is the biggest
        //    consideredIndex.Add(i);

        //    while(workDone)
        //    {
        //        int lastConsideredIndex = consideredIndex.Last();
        //        isThisIndexChecked[lastConsideredIndex] = true;

        //        foreach (var index in neighboursArray[lastConsideredIndex])
        //        {
        //            if (!CheckIfNeighbours(consideredIndex, index))
        //            {
        //                if (PreviousSum < (PreviousSum + ArrayToWork[index]))
        //                {
        //                    consideredIndex.Add(index);
        //                    PreviousSum += ArrayToWork[index];

        //                }
        //            }
        //        }
        //        if (lastConsideredIndex == consideredIndex.Last()) workDone = false;
        //    }





        //    MaxSumFromThisIndex[i] = PreviousSum;
        //    consideredElementArrayAtThisIndex[i] = consideredIndex;
        //}


        ////find all the maximum and start comaring them so that we can solve 4 5 4 3 issue
        ////if only one is maximum then no tension


        ////var sequence=MaxSumFromThisIndex.ToList()

        //var maxindex = MaxSumFromThisIndex.ToList().FindIndex(x => x == MaxSumFromThisIndex.Max());
        //List<int> maxList = consideredElementArrayAtThisIndex[maxindex];
        //maxList.Sort();
        //for (int i = maxList.Count-1; i >=0; i--)
        //{
        //    returnString += ArrayToWork[maxList.ElementAt(i)].ToString();
        //}

        #endregion

        #region trial1
        //// take one and then increase the addition type logic
        //int sumOfCurrentList;
        //int biggestSum = -1;
        //List<int> biggestList = new List<int>();
        //List<List<int>> possibleCombiOfTickets = new List<List<int>>();
        ////MakePossibleCombination(ArrayToWork,possibleCombiOfTickets);
        //List<int> realList = new List<int>();
        //bool breakTheLoop = true;
        //int addition;// = 2;
        //for (int i = 0; i < ArrayToWork.Length - 2; i++)
        //{
        //    addition = 2;
        //    breakTheLoop = true;
        //    while (breakTheLoop)
        //    {

        //        List<int> tempList = new List<int>();
        //        int j = i + addition;
        //        tempList.Add(i);
        //        for (; j < ArrayToWork.Length; j += 2)
        //        {
        //            tempList.Add(j);
        //        }
        //        if ((i + addition) >= ArrayToWork.Length - 1) breakTheLoop = false;
        //        addition++;
        //        //possibleCombiOfTickets.Add(tempList);
        //        sumOfCurrentList = CheckSumOfThisList(tempList, ArrayToWork);
        //        if (biggestSum < sumOfCurrentList)
        //        {
        //            biggestSum = sumOfCurrentList;
        //            biggestList = tempList;
        //        }

        //    }

        //}
        //if (ArrayToWork.Max() >= biggestSum)
        //{
        //    returnString = ArrayToWork.Max().ToString();
        //}
        //else
        //{
        //    for (int i = biggestList.Count; i > 0; i--)
        //    {
        //        if (ArrayToWork[biggestList.ElementAt(i - 1)] != 0)
        //            returnString = string.Concat(returnString, ArrayToWork[biggestList.ElementAt(i - 1)]);
        //    }
        //}
        #endregion

        #region trial2
        // //sort by maximum and then do the calculation
        // int previousSum = 0;
        // int currentSum = 0;
        // List<int> consideredElements = new List<int>();
        // Dictionary<int, int> ticketPosition = new Dictionary<int, int>();
        // //preserv the value of index and the values of the array so that we can use it letter
        // for (int i = 0; i < ArrayToWork.Length; i++)
        // {
        //     ticketPosition.Add(i, ArrayToWork[i]);
        // }
        // //srot thge array so that biggest elements are togather
        // ArrayToWork = ArrayToWork.OrderByDescending(x => x).ToArray();
        // previousSum = ArrayToWork[0]; //this is biggest
        // consideredElements.Add(ticketPosition.FirstOrDefault(x=>x.Value==ArrayToWork[0]).Key);  //this has element ranks in real (input) array

        // for (int i = 0; i < ArrayToWork.Length - 1; i++)
        // {
        //     //start taking adjucent,because this is sorted array
        //     for (int j = i+1; j < ArrayToWork.Length; j++)
        //     //for (int j = 1; j < ArrayToWork.Length; j++)
        //     {
        //         var keys = from entry in ticketPosition
        //                    where entry.Value == ArrayToWork[j]
        //                    select entry.Key;

        //         foreach (var key in keys)
        //         {
        //             if (!CheckIfNeighbours(consideredElements, key))
        //             {
        //                 if (previousSum < previousSum + ArrayToWork[j])
        //                 {
        //                     currentSum = previousSum + ArrayToWork[j];
        //                     consideredElements.Add(key);
        //                     previousSum = currentSum;
        //                 }
        //             } 
        //         }

        //     }


        // }
        //consideredElements=  consideredElements.OrderByDescending(x=>x).ToList();


        // for (int i =0; i < consideredElements.Count; i++)
        // {
        //     //if (ArrayToWork[biggestList.ElementAt(i - 1)] != 0)
        //     returnString = string.Concat(returnString, ticketPosition[ consideredElements.ElementAt(i)]);
        // }
        #endregion
        #region trialN
        //int maxSum = 0;
        //int previousSeqMaxSum = 0;
        //Dictionary<int, List<string>> keyAndConsideredElement = new Dictionary<int, List<string>>();
        //List<int> prevConsideredElement =  new List<int>();
        //for (int i = 0; i < ArrayToWork.Length; i++)
        //{
        //    List<int> consideredElement = new List<int>();
        //    consideredElement.Add(i);
        //    maxSum = ArrayToWork[i];
        //    for (int j = i+1; j < ArrayToWork.Length; j++)
        //    {
        //        if(!CheckIfNeighbours(consideredElement,j))
        //        {
        //            if(maxSum<maxSum+ArrayToWork[j])
        //            {
        //                maxSum += ArrayToWork[j];
        //                consideredElement.Add(j);
        //            }
        //        }
        //    }
        //    if(previousSeqMaxSum<maxSum)
        //    {
        //        previousSeqMaxSum = maxSum;
        //        List<string> tempString;
        //        if(!keyAndConsideredElement.TryGetValue(i,out tempString))
        //        {
        //            keyAndConsideredElement[i] = consideredElement.ConvertAll(new Converter<int, string>( convertit));
        //        }
        //        //prevConsideredElement = consideredElement;

        //        maxSum = 0;
        //        consideredElement.Clear();
        //    }
        //    maxSum = 0;
        //    consideredElement.Clear();
        //}
        #endregion
        #region Comment
        //        string returnString = string.Empty;
        //        //List<string> SeqOfThis = new List<string>();
        //        List<string>[] arrayOfSeq = new List<string>[ArrayToWork.Length - 2];
        //        int[] sumOfSeq = new int[ArrayToWork.Length - 2];
        //        string seq = string.Empty;

        //            for (int i = 0; i<ArrayToWork.Length; i++)
        //            {
        //                List<string> SeqOfThis = new List<string>();
        //                if (i >= sumOfSeq.Length) break;
        //                int sumOfThisSeq = 0;
        //        sumOfThisSeq = ArrayToWork[i];
        //                SeqOfThis.Add(ArrayToWork[i].ToString());
        //                for (int j = i + 2; j<ArrayToWork.Length; )
        //                {
        //                    if (sumOfThisSeq< (sumOfThisSeq + ArrayToWork[j]))
        //                    {
        //                        sumOfThisSeq += ArrayToWork[j];
        //                        SeqOfThis.Add(ArrayToWork[j].ToString());
        //                        //returnSeq += ArrayToWork[j].ToString();
        //                        j += 2;
        //                    }
        //                    else j++;

        //                }
        //sumOfSeq[i] = sumOfThisSeq;
        //                arrayOfSeq[i] = SeqOfThis;
        //            }
        //            int index = -1;
        //            for (int i = 0; i<sumOfSeq.Length; i++)
        //            {
        //                if(sumOfSeq[i]==sumOfSeq.Max())
        //                {
        //                    index = i;
        //                    break;
        //                }
        //            }
        //            for (int i = arrayOfSeq[index].Count; i >0; i--)
        //            {
        //                returnString = string.Concat(returnString, arrayOfSeq[index].ElementAt(i-1));
        //            }

        //            return returnString;
        #endregion
        #region Comment1
        //string returnString = string.Empty;
        //int sumOfCurrentList;
        //int biggestSum = -1;
        //List<int> biggestList = new List<int>();
        //List<List<int>> possibleCombiOfTickets = new List<List<int>>();
        ////MakePossibleCombination(ArrayToWork,possibleCombiOfTickets);
        //List<int> realList = new List<int>();
        //bool breakTheLoop = true;
        //int addition;// = 2;
        //    for (int i = 0; i<ArrayToWork.Length - 2; i++)
        //    {
        //        addition = 2;
        //        breakTheLoop = true;
        //        while (breakTheLoop)
        //        {

        //            List<int> tempList = new List<int>();
        //int j = i + addition;
        //tempList.Add(i);
        //            for (; j<ArrayToWork.Length; j += 2)
        //            {
        //                tempList.Add(j);
        //            }
        //            if ((i + addition) >= ArrayToWork.Length - 1) breakTheLoop = false;
        //            addition++;
        //            possibleCombiOfTickets.Add(tempList);
        //            sumOfCurrentList = CheckSumOfThisList(tempList, ArrayToWork);
        //            if(biggestSum<sumOfCurrentList)
        //            {
        //                biggestSum = sumOfCurrentList;
        //                biggestList = tempList;
        //            }

        //        }

        //    }
        //    if(ArrayToWork.Max()>= biggestSum)
        //    {
        //        returnString = ArrayToWork.Max().ToString();
        //    }
        //    else
        //    {
        //        for (int i = biggestList.Count; i > 0; i--)
        //        {
        //            if(ArrayToWork[biggestList.ElementAt(i - 1)]!=0)
        //            returnString = string.Concat(returnString, ArrayToWork[biggestList.ElementAt(i - 1)]);
        //        }
        //    }
        #endregion
        #region Comment2
        //    int previousSum = 0;
        //    int currentSum = 0;
        //    List<int> consideredElements = new List<int>();
        //    Dictionary<int, int> ticketPosition = new Dictionary<int, int>();
        //        //preserv the value of index and the values of the array so that we can use it letter
        //        for (int i = 0; i<ArrayToWork.Length; i++)
        //        {
        //            ticketPosition.Add(i, ArrayToWork[i]);
        //        }
        ////srot thge array so that biggest elements are togather
        //ArrayToWork = ArrayToWork.OrderByDescending(x => x).ToArray();
        //previousSum = ArrayToWork[0];
        //        consideredElements.Add(ArrayToWork[0]);

        //        for (int i = 0; i<ArrayToWork.Length-1; i++)
        //        {
        //            var Max = ticketPosition.FirstOrDefault(x => x.Value == ArrayToWork.Max()).Key;
        //var NextIndex = ticketPosition.FirstOrDefault(x => x.Value == ArrayToWork[i + 1]).Key;
        //            //if the adjucent elements are neighbours then we can't do this. thye both will never be in sum
        //            if (!((ticketPosition.FirstOrDefault(x=>x.Value==ArrayToWork.Max()).Key) == (ticketPosition.FirstOrDefault(x => x.Value == ArrayToWork[i + 1]).Key + 1))
        //                && !((ticketPosition.FirstOrDefault(x => x.Value == ArrayToWork.Max()).Key) == (ticketPosition.FirstOrDefault(x => x.Value == ArrayToWork[i + 1]).Key - 1)))
        //            {
        //                if(previousSum<previousSum+ArrayToWork[i + 1])
        //                {
        //                    currentSum = previousSum + ArrayToWork[i + 1];
        //                    consideredElements.Add(ArrayToWork[i + 1]);
        //                    previousSum = currentSum;
        //                }

        //            }
        //        }

        //        for (int i = consideredElements.Count; i > 0; i--)
        //        {
        //            //if (ArrayToWork[biggestList.ElementAt(i - 1)] != 0)
        //                returnString = string.Concat(returnString, consideredElements.ElementAt(i - 1));
        //        }
        #endregion


        #region fastestAndCorrect
        //    //sort by maximum and then do the calculation
        //    int previousSum = 0;
        //    int currentSum = 0;
        //    List<int> consideredElements = new List<int>();
        //    Dictionary<int, int> ticketPosition = new Dictionary<int, int>();
        //        //preserv the value of index and the values of the array so that we can use it letter
        //        for (int i = 0; i<ArrayToWork.Length; i++)
        //        {
        //            ticketPosition.Add(i, ArrayToWork[i]);
        //        }
        ////srot thge array so that biggest elements are togather
        //ArrayToWork = ArrayToWork.OrderByDescending(x => x).ToArray();
        //previousSum = ArrayToWork[0]; //this is biggest
        //        consideredElements.Add(ticketPosition.FirstOrDefault(x=>x.Value==ArrayToWork[0]).Key);  //this has element ranks in real (input) array

        //        for (int i = 0; i<ArrayToWork.Length - 1; i++)
        //        {
        //            //start taking adjucent,because this is sorted array
        //            for (int j = i + 1; j<ArrayToWork.Length; j++)
        //            //for (int j = 1; j < ArrayToWork.Length; j++)
        //            {
        //                var keys = from entry in ticketPosition
        //                           where entry.Value == ArrayToWork[j]
        //                           select entry.Key;

        //                foreach (var key in keys)
        //                {
        //                    if (!CheckIfNeighbours(consideredElements, key))
        //                    {
        //                        if (previousSum<previousSum + ArrayToWork[j])
        //                        {
        //                            currentSum = previousSum + ArrayToWork[j];
        //                            consideredElements.Add(key);
        //                            previousSum = currentSum;
        //                        }
        //                    } 
        //                }
        //            }

        //        }
        //       consideredElements=  consideredElements.OrderByDescending(x=>x).ToList();

        //        for (int i = 0; i<consideredElements.Count; i++)
        //        {
        //            //if (ArrayToWork[biggestList.ElementAt(i - 1)] != 0)
        //            returnString = string.Concat(returnString, ticketPosition[consideredElements.ElementAt(i)]);
        //        }
        #endregion
    }
}
