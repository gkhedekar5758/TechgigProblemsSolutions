using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeGame_Allscript2021
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int numberOfTest = Convert.ToInt32(Console.ReadLine());
            int[] leftBound = new int[numberOfTest];
            int[] rightBound = new int[numberOfTest];
            for (int i = 0; i < numberOfTest; i++)
            {
                string[] ip = Console.ReadLine().Split(' ');
                leftBound[i] = Convert.ToInt32(  ip[0]);
                rightBound[i] = Convert.ToInt32(ip[1]);
            }
            
            int maxNumbers = rightBound.Max();
            bool[] primes = new bool[maxNumbers+1];

            PreparePrimesArray(primes);
            
            for (int i = 0; i < numberOfTest; i++)
            {
                Console.WriteLine(FindMaxDiffBetweenPrimes(leftBound[i], rightBound[i],primes));
            }

            //====================================================================

            //static code
            /*//int[] leftBound = new int[] {3,56,45,67,687,4657 };
            //int[] rightBound = new int[] { 45,6786,456,6666,5424,5678};

            int[] leftBound = new int[] {  45 };
            int[] rightBound = new int[] { 456 };
            //int L = 45;
            //int R = 456;
            int maxNumbers = rightBound.Max();
            bool[] primes = new bool[maxNumbers];

            PreparePrimesArray(primes);
            
            for (int i = 0; i < leftBound.Length; i++)
            {
                Console.WriteLine(FindMaxDiffBetweenPrimes(leftBound[i], rightBound[i],primes));
            }
            */
            


            Console.ReadKey();

        }

        private static void PreparePrimesArray(bool[] primes)
        {
            for (int i = 0; i < primes.Length; i++)
            {
                primes[i] = true; //we will think that all are primes
            }

            for (int i = 2; i*i < primes.Length; i++)
            {
                if(primes[i])
                {
                    for (int j = i*i; j < primes.Length; j+=i)
                    {
                        primes[j] = false;
                    }
                }
            }
        }

        private static int FindMaxDiffBetweenPrimes(int l, int r, bool[] primes)
        {
            #region trial1
            /*int finalLeft = -1;
            int finalRight = -1;
            //base case 1
            if (l == r)
            {
                if (checkIf2357(l)) return 0;
                else if (checkIfDivisibleBy2357(l)) return -1;
                else return 1;
            }

            //normal prcessing
            //1- first we will find the left side, in forward direction
            for (finalLeft = l; finalLeft <= r; finalLeft++)
            {
                if (checkIf2357(finalLeft)) break;  // we are done for left as we got prime there
                if (!checkIfDivisibleBy2357(finalLeft)) break;  // no one could divide it so it is a prime number
            }
            //if (finalLeft == r) return -1; // we are done with roaming but could not find any prime

            //2- second we will find the right side, in backward direction
            for (finalRight = r; finalRight >= finalLeft; finalRight--)
            {
                if (checkIf2357(finalRight)) break;  // we are done for left as we got prime there
                if (!checkIfDivisibleBy2357(finalRight)) break;  // no one could divide it so it is a prime number
            }
            if (finalRight == finalLeft) return 0; // we are done with roaming but could not find any prime

            return finalRight - finalLeft;*/
            #endregion

            #region Trial2
            //base case
            if (l == r && primes[l]) return 0;
            if (l == r && !primes[l]) return -1;

            //normal processing
            int finalLeft = -1;
            int finalRight = -1;

            for (finalLeft = l; finalLeft <= r; finalLeft++)
            {
                if (primes[finalLeft]) break;
            }

            if (finalLeft == r && !primes[r]) return -1; //final digit is not prime so we could not find any in range
            if (finalLeft == r && primes[r]) return 0; //final digit is prime then we atleast found one

            for (finalRight = r;finalRight  >= finalLeft; finalRight--)
            {
                if (primes[finalRight]) break;
            }

            return finalRight - finalLeft;

            #endregion

        }
        private static bool checkIf2357(int l)
        {
            return l == 2 || l == 3 || l == 5 || l == 7;
        }
        private static bool checkIfDivisibleBy2357(int l)
        {
            return l % 2 == 0 || l % 3 == 0 || l % 5 == 0 || l % 7 == 0;
        }
    }
}
