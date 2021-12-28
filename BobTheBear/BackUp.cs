using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BobTheBear
{
    class BackUp
    {

        #region bkp1
        //        using System;
        //using System.Collections.Generic;
        //using System.Linq;

        //namespace BobTheBear
        //    {
        //        class Program
        //        {
        //            static void Main(string[] args)
        //            {
        //                int NumberOfSalmon = Convert.ToInt32(Console.ReadLine());
        //                var temp = Console.ReadLine().Split(' ');
        //                var lengthOfSalmons = new uint[temp.Length];
        //                for (int i = 0; i < temp.Length; i++)
        //                {
        //                    lengthOfSalmons[i] = Convert.ToUInt32(temp[i]);
        //                }
        //                var temp2 = Console.ReadLine().Split(' ');
        //                var timeOfSalmons = new uint[temp2.Length];
        //                for (int i = 0; i < temp.Length; i++)
        //                {
        //                    timeOfSalmons[i] = Convert.ToUInt32(temp2[i]);
        //                }
        //                string blankInput = Console.ReadLine();

        //                Console.WriteLine(CalculateMaxSalmons(ref NumberOfSalmon, ref lengthOfSalmons, ref timeOfSalmons));
        //                Console.ReadLine();
        //            }

        //            private static int CalculateMaxSalmons(ref int numberOfSalmons, ref uint[] lengthOfSalmons, ref uint[] timeOfSalmons)
        //            {
        //                int MaxSalmonCaught = 0;
        //                //this much need to sit at river bank for hunting fish
        //                UInt64 MaxTimeNeedToSitAtRiver = CalculateTime(ref timeOfSalmons, ref lengthOfSalmons);

        //                //keep track what all fishes can be eaten at any second
        //                List<uint>[] fishCombinationList = new List<uint>[MaxTimeNeedToSitAtRiver];

        //                //prepare accessibility matrix
        //                /*
        //                 *  fish/time  1 2 3 4 5
        //                 *  1          0 1 0 0 0
        //                 *  2          1 1 1 1 1  
        //                 *  3          0 0 0 0 1
        //                 * */
        //                uint[,] AccessibilityMatrix = new uint[numberOfSalmons, MaxTimeNeedToSitAtRiver];
        //                FillTheMatrixArray(ref AccessibilityMatrix, ref lengthOfSalmons, ref timeOfSalmons);
        //                MaxSalmonCaught = StartEating(ref AccessibilityMatrix, lengthOfSalmons, numberOfSalmons, fishCombinationList);
        //                return MaxSalmonCaught;

        //            }

        //            private static int StartEating(ref uint[,] accessibilityMatrix, uint[] lengthOfSalmons, int numberOfSalmons, List<uint>[] fishCombinationList)
        //            {
        //                //how many fishes can be eaten at this point- no matter what is the order of if or it has already been eaten
        //                uint[] numberOfFishesCanBeEatenThisTime = new uint[accessibilityMatrix.GetUpperBound(1) + 1];

        //                //now see how many fishes can be eaten every second and what fish can be eaten
        //                for (uint time = 0; time <= accessibilityMatrix.GetUpperBound(1); time++)
        //                {
        //                    List<uint> fishAtThisTime = new List<uint>();
        //                    for (uint fish = 0; fish <= accessibilityMatrix.GetUpperBound(0); fish++)
        //                    {
        //                        if (accessibilityMatrix[fish, time] == 1)
        //                        {
        //                            //   FishHasBeenEaten[fish] = 1;
        //                            fishAtThisTime.Add(fish);
        //                            //we need this because we need to swap and only array will have swap
        //                            numberOfFishesCanBeEatenThisTime[time] = numberOfFishesCanBeEatenThisTime[time] + 1;

        //                        }
        //                    }
        //                    fishCombinationList[time] = fishAtThisTime;
        //                }
        //                //now we are done with combination. let's first sort them
        //                sortTheArray(ref fishCombinationList);
        //                //now let's really start eating with mind
        //                int retValue = LetsReallyEatWithMind(ref fishCombinationList, ref numberOfSalmons);


        //                return retValue;
        //            }

        //            private static int LetsReallyEatWithMind(ref List<uint>[] fishCombinationList, ref int numberOfSalmons)
        //            {
        //                int FishInPass1 = 0;
        //                int FishInPass2 = 0;
        //                bool ShouldWeConsiderThis = false;
        //                List<uint> ListOfEatenFish = new List<uint>();
        //                for (uint i = 0; i < fishCombinationList.Length; i++)
        //                {
        //                    if (i == 0)
        //                    {
        //                        FishInPass1 = fishCombinationList[i].Count; //this is sorted so get the first 
        //                        ListOfEatenFish = fishCombinationList[i]; //if all has been eaten in first attempt then we are done.. No More fishes..  :(
        //                    }
        //                    if (FishInPass1 == numberOfSalmons) break;
        //                    if (i != 0)
        //                    {
        //                        ShouldWeConsiderThis = ShouldWeConsiderThisLevel(ref ListOfEatenFish, fishCombinationList[i]);
        //                        if (ShouldWeConsiderThis) FishInPass2 = fishCombinationList[i].Count;
        //                    }
        //                    if (FishInPass1 != 0 && FishInPass2 != 0) break;
        //                }


        //                return FishInPass1 + FishInPass2;
        //            }

        //            private static bool ShouldWeConsiderThisLevel(ref List<uint> listOfEatenFish, List<uint> list)
        //            {
        //                bool temp = true;
        //                for (int i = 0; i < list.Count; i++)
        //                {
        //                    if (listOfEatenFish.Contains(list.ElementAt(i)))
        //                    {
        //                        temp = false;
        //                        break;
        //                    }
        //                }
        //                return temp;
        //            }

        //            private static void sortTheArray(ref List<uint>[] fishCombinationList)
        //            {
        //                for (uint i = 0; i < fishCombinationList.Length; i++)
        //                {
        //                    for (uint j = i + 1; j < fishCombinationList.Length; j++)
        //                    {
        //                        if (fishCombinationList[i].Count < fishCombinationList[j].Count)
        //                        {
        //                            var temp = fishCombinationList[i];
        //                            fishCombinationList[i] = fishCombinationList[j];
        //                            fishCombinationList[j] = temp;
        //                        }
        //                        /*
        //                         * if the count is same then sort accoring to big number
        //                         * for eg
        //                         * combination can be
        //                         * 1 - 2,3,4
        //                         * 2 - 2,4,5
        //                         * so this should be
        //                         * 1 - 2,4,5
        //                         * 2 - 2,3,4
        //                         */

        //                        if (fishCombinationList[i].Count == fishCombinationList[j].Count)
        //                        {
        //                            if (fishCombinationList[i].Except(fishCombinationList[j]).ToList().Count != 0)
        //                            {
        //                                var iexjnotex = fishCombinationList[i].Except(fishCombinationList[j]).ToList();
        //                                var jexinotex = fishCombinationList[j].Except(fishCombinationList[i]).ToList();
        //                                if (iexjnotex.ElementAt(0) < jexinotex.ElementAt(0))
        //                                {
        //                                    var temp = fishCombinationList[i];
        //                                    fishCombinationList[i] = fishCombinationList[j];
        //                                    fishCombinationList[j] = temp;
        //                                }

        //                            }
        //                        }
        //                    }

        //                }
        //            }


        //            private static void FillTheMatrixArray(ref uint[,] accessibilityMatrix, ref uint[] lengthOfSalmons, ref uint[] timeOfSalmons)
        //            {
        //                for (UInt64 fish = 0; fish <= Convert.ToUInt64(accessibilityMatrix.GetUpperBound(0)); fish++)
        //                {
        //                    for (UInt64 time = 0; time <= Convert.ToUInt64(accessibilityMatrix.GetUpperBound(1)); time++)
        //                    {
        //                        // Console.WriteLine("Row = {0}  Column = {1}",row,column);
        //                        if ((time + 1) == timeOfSalmons[fish])
        //                        {
        //                            accessibilityMatrix[fish, time] = 1;
        //                            FillTheRow(fish, time, ref accessibilityMatrix, lengthOfSalmons[fish]);
        //                            break;
        //                        }
        //                    }
        //                }
        //            }

        //            private static void FillTheRow(UInt64 fish, UInt64 time, ref uint[,] accessibilityMatrix, uint v)
        //            {
        //                for (UInt64 i = time + 1; v > 0; i++)
        //                {
        //                    accessibilityMatrix[fish, i] = 1;
        //                    v -= 1;
        //                }
        //            }

        //            private static UInt64 CalculateTime(ref uint[] timeOfSalmons, ref uint[] lengthOfSalmons)
        //            {
        //                List<UInt64> tempList = new List<UInt64>();
        //                for (int i = 0; i < lengthOfSalmons.Length; i++)
        //                {
        //                    tempList.Add(lengthOfSalmons[i] + timeOfSalmons[i]);
        //                }
        //                return tempList.Max();
        //            }


        //        }
        //    }

        #endregion

        #region bkp2
//        using System;
//using System.Collections.Generic;
//using System.Linq;
//namespace CandidateCode
//    {
//        class CandidateCode
//        {
//            static void Main(string[] args)
//            {
//                //Write code here
//                int NumberOfSalmon = Convert.ToInt32(Console.ReadLine());
//                var temp = Console.ReadLine().Split(' ');
//                var lengthOfSalmons = new Int64[temp.Length];
//                for (int i = 0; i < temp.Length; i++)
//                {
//                    lengthOfSalmons[i] = Convert.ToInt64(temp[i]);
//                }
//                var temp2 = Console.ReadLine().Split(' ');
//                var timeOfSalmons = new Int64[temp2.Length];
//                for (int i = 0; i < temp.Length; i++)
//                {
//                    timeOfSalmons[i] = Convert.ToInt64(temp2[i]);
//                }
//                string blankInput = Console.ReadLine();

//                Console.WriteLine(CalculateMaxSalmons(ref NumberOfSalmon, ref lengthOfSalmons, ref timeOfSalmons));
//            }
//            private static int CalculateMaxSalmons(ref int numberOfSalmons, ref long[] lengthOfSalmons, ref long[] timeOfSalmons)
//            {
//                if (numberOfSalmons == 1 || numberOfSalmons == 2) return numberOfSalmons;
//                Int64[] tailArray = new Int64[numberOfSalmons];
//                PrepareTailArray(ref lengthOfSalmons, ref timeOfSalmons, ref tailArray);
//                sortTimingArray(ref lengthOfSalmons, ref timeOfSalmons, ref tailArray);

//                List<int> PosssibleEating = new List<int>();
//                return EatTheFish(ref lengthOfSalmons, ref timeOfSalmons, ref tailArray, ref PosssibleEating);
//                //return 0;
//            }

//            private static int EatTheFish(ref long[] lengthOfSalmons, ref long[] timeOfSalmons, ref long[] tailArray, ref List<int> posssibleEating)
//            {
//                List<int> ThisFishisEaten = new List<int>();
//                int eatingCount = 0;
//                int pass = 0;
//                for (int fish = 0; fish < timeOfSalmons.Length; fish++)
//                {
//                    eatingCount = 0;
//                    pass = 0;
//                    ThisFishisEaten.Clear();

//                    for (int i = fish; i < timeOfSalmons.Length && pass != 2; i++)
//                    {

//                        if (pass == 2)
//                        {
//                            posssibleEating.Add(eatingCount);
//                            eatingCount = 0;
//                            pass = 0;
//                            ThisFishisEaten.Clear();
//                            continue;
//                        }
//                        //int eatingCount = 0;
//                        if (ThisFishisEaten.Exists(x => x == i)) continue;
//                        if (!ThisFishisEaten.Exists(x => x == i))
//                        {
//                            ThisFishisEaten.Add(i);
//                            eatingCount++;
//                            pass++;
//                        }
//                        for (int j = i + 1; j < timeOfSalmons.Length; j++)
//                        {
//                            if (i == j) continue;
//                            if (timeOfSalmons[j] <= timeOfSalmons[i] || timeOfSalmons[j] <= tailArray[i])
//                            {
//                                if (!ThisFishisEaten.Exists(x => x == j))
//                                {
//                                    ThisFishisEaten.Add(j);
//                                    eatingCount++;

//                                }
//                            }
//                        }

//                        if (pass == 2) posssibleEating.Add(eatingCount);
//                    }

//                }
//                return posssibleEating.Max();
//            }



//            private static void sortTimingArray(ref long[] lengthOfSalmons, ref long[] timeOfSalmons, ref long[] tailArray)
//            {
//                for (int i = 0; i < timeOfSalmons.Length; i++)
//                {
//                    for (int j = i + 1; j < timeOfSalmons.Length; j++)
//                    {
//                        if (timeOfSalmons[i] > timeOfSalmons[j])
//                        {
//                            var temp = timeOfSalmons[i];
//                            timeOfSalmons[i] = timeOfSalmons[j];
//                            timeOfSalmons[j] = temp;

//                            var temp2 = lengthOfSalmons[i];
//                            lengthOfSalmons[i] = lengthOfSalmons[j];
//                            lengthOfSalmons[j] = temp2;

//                            var temp3 = tailArray[i];
//                            tailArray[i] = tailArray[j];
//                            tailArray[j] = temp3;

//                        }

//                    }
//                }
//            }

//            private static void PrepareTailArray(ref long[] lengthOfSalmons, ref long[] timeOfSalmons, ref long[] tailArray)
//            {
//                for (int i = 0; i < lengthOfSalmons.Length; i++)
//                {
//                    tailArray[i] = lengthOfSalmons[i] + timeOfSalmons[i];

//                }
//            }
//        }
//    }2
        #endregion
    }
}
