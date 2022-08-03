using System;

namespace ArmyVsAliens
{
    class Program
    {
        static void Main(string[] args)
        {
            /*var temp1Launch = Console.ReadLine().Split(' ');
            var temp2Travel = Console.ReadLine().Split(' ');

            int launchMM = Convert.ToInt32(temp1Launch[1]);
            int launchHH = Convert.ToInt32(temp1Launch[0]);

            int travelMM = Convert.ToInt32(temp2Travel[1]);
            int travelHH = Convert.ToInt32(temp2Travel[0]);*/

            int launchHH = 23;
            int launchMM = 30;

            int travelHH = 00;
            int travelMM = 30;
            

            string finalAnswer = GetImpactTime(launchHH, launchMM, travelHH, travelMM);
            Console.WriteLine(finalAnswer);

        }

        private static string GetImpactTime(int launchHH, int launchMM, int travelHH, int travelMM)
        {
            int minuteUC = 60, hourUC = 24;
            bool hourCarry = false;
            var sumMM = launchMM + travelMM;
            if (sumMM >= minuteUC)
            {
                sumMM -= minuteUC;
                hourCarry = true;
            }

            var sumHH = hourCarry? launchHH + travelHH +1 : launchHH + travelHH  ;

            if (sumHH >= hourUC)
            {
                sumHH -= hourUC;
            }

            string HH="", MM="";

            if (sumHH.ToString().Length == 1) HH = "0" + sumHH.ToString();
            else HH = sumHH.ToString();
            if (sumMM.ToString().Length == 1) MM = "0" + sumMM.ToString();
            else MM = sumMM.ToString();

            return HH + " " + MM;
        }
    }
}
