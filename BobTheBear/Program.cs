using System;
using System.Collections.Generic;
using System.Linq;

namespace BobTheBear
{
    class Program
    {
        static void Main(string[] args)
        {
            int NumberOfSalmon = Convert.ToInt32(Console.ReadLine());
            var temp = Console.ReadLine().Split(' ');
            var lengthOfSalmons = new Int64[temp.Length];
            for (int i = 0; i < temp.Length; i++)
            {
                lengthOfSalmons[i] = Convert.ToInt64(temp[i]);
            }
            var temp2 = Console.ReadLine().Split(' ');
            var timeOfSalmons = new Int64[temp2.Length];
            for (int i = 0; i < temp.Length; i++)
            {
                timeOfSalmons[i] = Convert.ToInt64(temp2[i]);
            }
            string blankInput = Console.ReadLine();

            Console.WriteLine(CalculateMaxSalmons(ref NumberOfSalmon, ref lengthOfSalmons, ref timeOfSalmons));
            Console.ReadLine();
        }

        private static int CalculateMaxSalmons(ref int numberOfSalmons, ref long[] lengthOfSalmons, ref long[] timeOfSalmons)
        {
            int MaxSalmonCaught = 0;
            //this much need to sit at river bank for hunting fish
            Int64 MaxTimeNeedToSitAtRiver = CalculateTime(ref timeOfSalmons, ref lengthOfSalmons);

            //keep track what all fishes can be eaten at any second
            List<List<int>> fishCombinationList = new List<List<int>>();

            //prepare accessibility matrix
            /*
             *  fish/time  1 2 3 4 5
             *  1          0 1 0 0 0
             *  2          1 1 1 1 1  
             *  3          0 0 0 0 1
             * */
            List<List<int>> AccessibilityMatrix = new List<List<int>>();
            //AccessibilityMatrix.Capacity = numberOfSalmons;

            //fill it zero new startegy
            #region FillMatrixwithZero&One

            for (int fish = 0; fish < numberOfSalmons; fish++)
            {
                List<int> temp = new List<int>();
                for (Int64 time = 0; time < MaxTimeNeedToSitAtRiver; time++)
                {

                    if ((time + 1) >= timeOfSalmons[fish] && time < (timeOfSalmons[fish] + lengthOfSalmons[fish]))
                    {
                        temp.Add(1);
                    }
                    else
                    {
                        temp.Add(0);
                    }

                }
                AccessibilityMatrix.Add(temp);
            }
            #endregion
            //fill with zero ends here
            printAcce(ref AccessibilityMatrix); //commment this

            //FillTheMatrixArray(ref AccessibilityMatrix, ref lengthOfSalmons, ref timeOfSalmons,ref MaxTimeNeedToSitAtRiver);
            MaxSalmonCaught = StartEating(ref AccessibilityMatrix, lengthOfSalmons, numberOfSalmons, fishCombinationList);
            return MaxSalmonCaught;

        }

        private static void printAcce(ref List<List<int>> accessibilityMatrix)
        {
            for (int i = 0; i <= accessibilityMatrix.ElementAt(1).Count; i++)
            {
                List<int> temp = new List<int>();
                temp = accessibilityMatrix.ElementAt(i);
                for (int j   = 0; j < temp.Count; j++)
                {
                    Console.Write(temp.ElementAt(i));

                }
                Console.WriteLine();
            }
        }

        private static Int64 CalculateTime(ref long[] timeOfSalmons, ref long[] lengthOfSalmons)
        {
            List<Int64> tempList = new List<Int64>();
            for (int i = 0; i < lengthOfSalmons.Length; i++)
            {
                tempList.Add(lengthOfSalmons[i] + timeOfSalmons[i]);
            }
            return tempList.Max();
        }
        private static int StartEating(ref List<List<int>> accessibilityMatrix, long[] lengthOfSalmons, int numberOfSalmons, List<List<int>> fishCombinationList)
        {

            for (Int64 time = 0; time < accessibilityMatrix.ElementAt(1).Count; time++)
            {
                List<int> tempThisSecond = new List<int>();
                for (int fish = 0; fish < lengthOfSalmons.Length; fish++)
                {
                    var fishList = accessibilityMatrix.ElementAt(fish);
                    if (fishList.ElementAt(Convert.ToInt32(time)) == 1)
                    {
                        tempThisSecond.Add(fish);
                    }

                }
                fishCombinationList.Add(tempThisSecond);

            }
            var arrayofFish = fishCombinationList.ToArray();
            sortTheList(ref arrayofFish);
            fishCombinationList = arrayofFish.ToList();
            int retValue = LetsReallyEatWithMind(ref fishCombinationList, ref numberOfSalmons);
            return retValue;

        }
        private static void sortTheList(ref List<int>[] arrayofFish)
        {
            for (int i = 0; i < arrayofFish.Length; i++)
            {
                for (int j = 0; j < arrayofFish.Length; j++)
                {
                    if (arrayofFish[i].Count < arrayofFish[j].Count)
                    {

                        var temp = arrayofFish[i];
                        arrayofFish[i] = arrayofFish[j];
                        arrayofFish[j] = temp;
                    }

                }

            }
        }
        private static int LetsReallyEatWithMind(ref List<List<int>> fishCombinationList, ref int numberOfSalmons)
        {
            int FishInPass1 = 0;
            int FishInPass2 = 0;
            bool ShouldWeConsiderThis = false;
            List<int> finalCount = new List<int>();
            List<int> ListOfEatenFish = new List<int>();

            for (int i = fishCombinationList.Count - 1; i > 0; i--)
            {
                if (i == fishCombinationList.Count - 1)
                {
                    FishInPass1 = fishCombinationList.ElementAt(i).Count;
                    ListOfEatenFish = fishCombinationList.ElementAt(i);
                }
                if (FishInPass1 == numberOfSalmons) break;
                if (i != fishCombinationList.Count - 1)
                {
                    FishInPass2 = EatOtherLevels(ref ListOfEatenFish, fishCombinationList[i]);
                    finalCount.Add(FishInPass1 + FishInPass2);
                    //ShouldWeConsiderThis = ShouldWeConsiderThisLevel(ref ListOfEatenFish, fishCombinationList.ElementAt(i));
                    //if (ShouldWeConsiderThis) FishInPass2 = fishCombinationList.ElementAt(i).Count;
                }
                //if(FishInPass1 != 0 && FishInPass2 != 0) break;

            }


            return finalCount.Max();

        }
        private static int EatOtherLevels(ref List<int> listOfEatenFish, List<int> list)
        {
            List<int> remainingFish = new List<int>();
            remainingFish = list.Except(listOfEatenFish).ToList();
            return remainingFish.Count;
        }
    }
}
