using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaybladeCompetition
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfTestCases = Convert.ToInt16(Console.ReadLine());
            int tempPlayers;
            string[] tempTeaG=null;
            string[] tempOppTeam = null;
            Int64[][] v = new Int64[numberOfTestCases][];
            Int64[][] w = new Int64[numberOfTestCases][]; ;
            for (int i = 0; i < numberOfTestCases; i++)
            {
                tempPlayers = Convert.ToInt16(Console.ReadLine());
                 tempTeaG = Console.ReadLine().Trim().Split(' ');
                tempOppTeam = Console.ReadLine().Trim().Split(' ');

                long[] TeamG = new long[tempPlayers];
                long[] TeamO = new long[tempPlayers];
                for (int j = 0; j < tempPlayers; j++)
                {
                    long.TryParse(tempTeaG[j], out TeamG[j]);
                    long.TryParse(tempOppTeam[j], out TeamO[j]);
                }

                v[i] = TeamG;
                w[i] = TeamO;
            }

            for (int i = 0; i < numberOfTestCases; i++)
            {
                Console.WriteLine(NumberOfMatcheWin(v[i],w[i]));
            }

        }

        private static int  NumberOfMatcheWin(long[] TeamG, long[] TeamO)
        {
            Array.Sort(TeamG);
            Array.Sort(TeamO);
            int MatchesWon = 0;

            int teamGConter = 0;
            for (int i = 0; i < TeamO.Length; i++)
            {
                while (teamGConter<TeamG.Length)
                {
                    if (TeamG[teamGConter] > TeamO[i])
                    {
                        MatchesWon++;
                        teamGConter++;
                        break;
                    }
                    else teamGConter++;
                }
                
            }
            return MatchesWon;
        }
    }
}
