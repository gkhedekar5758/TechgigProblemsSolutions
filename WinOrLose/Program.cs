using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinOrLose
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfTestCases;
            Int32.TryParse(Console.ReadLine(), out numberOfTestCases);
            int[] numberOfPVGame = new int[numberOfTestCases];
            string[] tempList = null;
            List<string[]> playerRecord = new List<string[]>();
            List<int[]> playerRecordFinal = new List<int[]>();
            for (int i = 0; i < numberOfTestCases; i++)
            {
                Int32.TryParse(Console.ReadLine(), out numberOfPVGame[i]);
                //numberOfPVGame[i] = Console.Read();
                for (int j = 0; j < 2; j++)
                {
                    tempList = Console.ReadLine().Split(' ');
                    playerRecord.Add(tempList);
                }
                
            }
           // int[] tempArr = null;
            for (int i = 0; i < playerRecord.Count; i++)
            {
                int[] tempArr = new int[playerRecord.ElementAt(i).Length];
                string[] temp = playerRecord.ElementAt(i);
                //int tempArr = new int[temp.Length
                for (int j = 0; j < temp.Length; j++)
                {
                    Int32.TryParse(temp[j], out tempArr[j]);
                }
                playerRecordFinal.Add(tempArr);
            }

            for (int i = 0; i < numberOfTestCases; i++)
            {
                Console.WriteLine(ShowWinORLose(numberOfPVGame[i],playerRecordFinal.ElementAt(i*2),playerRecordFinal.ElementAt((i*2)+1)));
            }
            Console.ReadLine();
        }

        private static string ShowWinORLose(int numberOfPlayer, int[] V, int[] H)
        {
            string finalResult = "WIN";
            // int[] VillanStrength
            // List<int> VillanStrength=V.ConvertAll(new Converter<string,int>(convertIt));
            //List<int> HeroEnergy = H.ConvertAll(new Converter<string, int>(convertIt));
            Array.Sort(V);
            Array.Sort(H);

            //if the highest villanstrength is greater than hero energy then atlease one will be loose so so finally LOSE
            if (V.Last() > H.Last()) return "LOSE";

            for (int i = 0; i < V.Length; i++)
            {
                if(V[i]>H[i])
                {
                    finalResult = "LOSE";
                    break;
                }
            }
            return finalResult;
        }

        
    }
}
