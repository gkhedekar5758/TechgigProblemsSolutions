using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TECHGIG_small_tests
{
    class AllProblems
    {
       public int FindAllPrimeNumbersBetwenRange(int lowerBound,int upperBound)
        {
            int countOfPrimeNo = 0;
            for (int i = lowerBound; i <= upperBound; i++)
            {
                if (IsItPrime(i,lowerBound,upperBound)) countOfPrimeNo++;
            }
            return countOfPrimeNo;
        }
        bool IsItPrime(int no,int l,int u)
        {
            if (no == 0 || no == 1 || no == 2) return false;
            
                for (int i = 2; i < no; i++)
                {
                    if ((no % i) == 0) return false;
                }
            
            return true;
        }

    }
    

    public class candidate
    {
        public void met()
        {
            //Write code here
            String s;
            String totalnumber = "";
            String array = "";
            int ctr = 0;
            do
            {
                ctr++;
                s = Console.ReadLine();
                //Console.WriteLine("Line {0}: {1}", ctr, s);
                if (ctr == 1) totalnumber = s;
                if (ctr == 2) array = s;
            } while (s != null);

            // Console.Write("ttl "+ totalnumber + "array" + array);

            int[] a = new int[100];
            String[] arrayelements = array.Split(' ');
            // Console.Write(arrayelements.Length); 
            // Console.Write(arrayelements[1]);
            //  Console.Write(int.Parse(totalnumber));
            //a = new int[int.Parse(Console.ReadLine())];

            for (int i = 0; i < int.Parse(totalnumber); i++)
            {
                //  Console.Write(i);
                a[i] = int.Parse(arrayelements[i]);

            }
            // Console.Write(a.Length);


            int max1, max2;
            max1 = max2 = a[0];
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] > max1)
                {
                    max2 = max1;
                    max1 = a[i];
                }
                else
                    if ((a[i] > max2 && a[i] < max1) || max1 == max2)
                {
                    max2 = a[i];
                }
            }
            Console.Write(max2);
        }
    }
    }

