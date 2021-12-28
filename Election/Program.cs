using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Election
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfTestCases;
            Int32.TryParse(Console.ReadLine(), out numberOfTestCases);
            int[] PhaseArray = new int[numberOfTestCases];
            int[] StateArray = new int[numberOfTestCases];
            List<string[]> tempphaseseat = new List<string[]>();
            List<string[]> tempstateseat = new List<string[]>();
            List<int[]> intPhaseSeat = new List<int[]>();
            List<int[]> intStateSeat = new List<int[]>();
            //int[] numberOfBoxes = new int[numberOfTestCases];
            string[] tempStatePhase = null;
            string[] phasestemp = null;
            string[] statetemp = null;
            for (int i = 0; i < numberOfTestCases; i++)
            {
                tempStatePhase = Console.ReadLine().Trim(). Split(' ');
                //for (int j = 0; j < 2; j++)
                //{
                    phasestemp = Console.ReadLine().Trim().Split(' ');
                    statetemp = Console.ReadLine().Trim().Split(' ');
               // }
                
                Int32.TryParse(tempStatePhase[0], out PhaseArray[i]);
                Int32.TryParse(tempStatePhase[1], out StateArray[i]);

                tempphaseseat.Add(phasestemp);
                tempstateseat.Add(statetemp);
            }

            //phase seats
            for (int i = 0; i < tempphaseseat.Count; i++)
            {
                int[] tempIntArr = new int[tempphaseseat.ElementAt(i).Length];
                string[] temp = tempphaseseat.ElementAt(i);
                for (int j = 0; j < temp.Length; j++)
                {
                    Int32.TryParse(temp[j], out tempIntArr[j]);
                }
                intPhaseSeat.Add(tempIntArr);

            }
            //state seats
            for (int i = 0; i < tempstateseat.Count; i++)
            {
                int[] tempIntArr = new int[tempstateseat.ElementAt(i).Length];
                string[] temp = tempstateseat.ElementAt(i);
                for (int j = 0; j < temp.Length; j++)
                {
                    Int32.TryParse(temp[j], out tempIntArr[j]);
                }
                intStateSeat.Add(tempIntArr);

            }


            for (int i = 0; i < numberOfTestCases; i++)
            {
                bool res=    CanBJPWin(PhaseArray[i],StateArray[i],intPhaseSeat.ElementAt(i),intStateSeat.ElementAt(i));
                if (res) Console.WriteLine("YES");
                else Console.WriteLine("NO");
            }

            Console.ReadLine();
        }

        private static bool CanBJPWin(int numberOfPhases, int numberOfStates, int[] SeatsInPhasesArr, int[] SeatsInStatesArr)
        {

            #region myapproach
            //string returnString = string.Empty;
            //int[] SumOfCols = new int[numberOfStates];
            //int index = 0;
            //List<int> MaxSumCanBeFormedForState = new List<int>();
            //List<int> tempPhaseListToWork = new List<int>();
            //while (true)
            //{
            //    if (index == 0)
            //    {
            //         tempPhaseListToWork = SeatsInPhases.ToList().FindAll(x => x != 0).ToList();
            //    }
            //    else
            //    {
            //        tempPhaseListToWork = MaxSumCanBeFormedForState.FindAll(x => x != 0).ToList();
            //    }
            //    if (tempPhaseListToWork.Count == 0) break;
            //    //this is the max sume which can be formed for any state. so the matrix can be the same or bigger than thiss
            //    //see folded page in diary
            //     MaxSumCanBeFormedForState = tempPhaseListToWork.FindAll(x => x - 1 >= 0).ToList();
            //    SumOfCols[index] = MaxSumCanBeFormedForState.Count;
            //    MaxSumCanBeFormedForState= MaxSumCanBeFormedForState.Select(x => x = x - 1).ToList();

            //    index++;

            //}



            //if (SumOfCols.ToList().OrderBy(z => z).SequenceEqual(SeatsInStates.OrderBy(x => x))) return "YES";  // this is sure shot scenario
            //else returnString = "NO";  // as of now keeping this
            #endregion

            
             List<int> SeatsInPhases = SeatsInPhasesArr.ToList();
            List<int> SeatsInStates = SeatsInStatesArr.ToList();

            //obvious case 1
            if (SeatsInPhases.TrueForAll(x => x == 0)) return false;
            if (SeatsInStates.Sum() != SeatsInPhases.Sum()) return false;

            while (SeatsInPhases.Count!=0)
            {
                SeatsInStates = SeatsInStates.OrderByDescending(x => x).ToList();
                int lastPhaseSeat = SeatsInPhases.Last();
                SeatsInPhases.RemoveAt(SeatsInPhases.Count - 1);
                if (lastPhaseSeat > SeatsInStates.Count) return false;
                if (lastPhaseSeat == 0) continue;
                if (SeatsInStates[lastPhaseSeat - 1] == 0) return false;
                // Now remove the ones from the statelist
                for (int i = 0; i < lastPhaseSeat; i++)
                {
                    SeatsInStates[i]--;
                }
            }

            foreach (int item in SeatsInStates)
            {
                if (item != 0) return false;
            }


            return true;

        }


        #region Approach1
        //Int32[,] ExpertArray = new Int32[numberOfPhases, numberOfStates];
        //FillTheExpertArray(numberOfPhases, numberOfStates, SeatsInPhases, ExpertArray);
        //// the above section giving memory

        //int[] SumOfCols = new int[numberOfStates];
        ////se
        //for (int state = 0; state < numberOfStates; state++)
        //{
        //    int[] seatsInThisState = GetColumn(ExpertArray, state);
        //    var aa = seatsInThisState.ToList().FindAll(x => x == 1).ToList();
        //    SumOfCols[state] = aa.Count;
        //}

        //if (SumOfCols.ToList().Except(SeatsInStates.ToList()).ToList().Count == 0) return "YES";
        //else return "NO";

        //return "YES";
        #endregion
        //if there is one then its BJP orelse someone else
        private static void FillTheExpertArray(int numberOfPhases,int numberOfStates, int[] seatsInPhases, Int32[,] expertArray)
        {
            // this is my understding. if there are 2 seats in phase 1 (starting with 0) then it should be on 0 and 1 index rather
            // then 1 and 2.
            for (Int32 phase = 0; phase < numberOfPhases; phase++)
            {
                int seatsInThisPhase = seatsInPhases[phase];
                for (Int32 state = 0; state < seatsInThisPhase; state++)
                {
                    expertArray[phase, state] = 1;
                }

            }

          
        }
        public static int[] GetColumn(int[,] matrix, int columnNumber)
        {
            return Enumerable.Range(0, matrix.GetLength(0))
                    .Select(x => matrix[x, columnNumber])
                    .ToArray();
        }
    }
}
