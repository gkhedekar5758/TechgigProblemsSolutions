using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProfitProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] timesPerson = { "6AM#8AM", "11AM#1PM", "7AM#3PM", "7AM#10AM", "10AM#12PM", "2PM#4PM", "1PM#4PM", "8AM#9AM" };
            string[] timesPersonModifiedFromTime = new string[timesPerson.Length];
            string[] timesPersonModifiedToTime = new string[timesPerson.Length];
            //string[] sep = { "#" };
            int[] timeIntArray=new int[timesPerson.Length];
            //int kk = 0;
            for (int i = 0; i < timesPerson.Length; i++)
            {

                //if (i == 0) kk = i;
                //else kk++;
                //int kk = i;
                var k = timesPerson[i].Split('#');
                timesPersonModifiedFromTime[i] = k[0];
                
                timesPersonModifiedToTime[i] = k[1];
                
            }
            RoomFinder rfObj = new RoomFinder();
            
            int[] fromTimeInInteger=rfObj.TimeConverter(timesPersonModifiedFromTime);
            int[] toTimeInInteger = rfObj.TimeConverter(timesPersonModifiedToTime);
            int totalMoney = rfObj.ProfitCalculator(fromTimeInInteger, toTimeInInteger);

            //Array.Sort(totalTimeInIneteger);
            int[] totalTimeDiff = rfObj.TimeDiffFinder(fromTimeInInteger,toTimeInInteger);
            Console.ReadLine();
        }
    }
    class RoomFinder
    {
        public int ProfitCalculator(int[] timesFrom,int[] timesTo)
        {
            for (int i = 0; i < timesFrom.Length-2; i++)
            {
                for (int j = i; j < timesFrom.Length-2; j++)
                {
                    if (timesTo[j] - timesFrom[j] > timesTo[j + 1] - timesFrom[j + 1])
                    {
                        int temp = 0;
                        temp = timesFrom[j];
                        timesFrom[j] = timesFrom[j + 1];
                        timesFrom[j + 1] = temp;
                        temp = timesTo[j];
                        timesTo[j] = timesTo[j + 1];
                        timesTo[j + 1] = temp;
                    }
                }
            }
            return 0;
        }
        public int[] TimeConverter(string[] timeArr) // method to convert the string array to int array
        {
            int[] tempArr = new int[timeArr.Length];
            for (int i = 0; i < timeArr.Length; i++)
            {
                if (timeArr[i].Contains("AM")) timeArr[i]=timeArr[i].Replace("AM", " ");   //AM-PM logic
                else if (timeArr[i].Contains("PM"))
                {
                    timeArr[i]=timeArr[i].Replace("PM", "");
                    if (timeArr[i].Contains("12")) goto guk;
                    timeArr[i] = (Convert.ToInt16(timeArr[i]) + 12).ToString();
                    
                }
            guk: tempArr[i] = Convert.ToInt16(timeArr[i]);
                
            }
            
            return tempArr  ;

        }
        public int[] TimeDiffFinder(int[] tempArrF,int[] tempArrT)  // method to have the difference of time of stay
        {
            int[] tempArr2 = new int[tempArrF.Length];
            for (int p = 0; p < tempArrF.Length; p++)
            {
                tempArr2[p] = tempArrT[p] - tempArrF[p];
            }
            return tempArr2;
        }
    }
}
