using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaVirus
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] temp = Console.ReadLine().Trim().Split(' ');
            int NumberOfPatients = Convert.ToInt16(temp[0]);
            int NumberOfDoctors = Convert.ToInt16(temp[1]); 
            int[,] array = new int[NumberOfDoctors, NumberOfPatients];
            string[] tempe = null;
            for (int i = 0; i < NumberOfDoctors; i++)
            {
               tempe = Console.ReadLine().Trim().Split(' ');
                for (int j = 0; j < tempe.Length; j++)
                {
                    array[ i,j] = Convert.ToInt32(tempe[j]);
                }
            }

            Console.WriteLine(FindtheBestEfforts(NumberOfDoctors,NumberOfPatients,array));
            Console.WriteLine();
            Console.ReadLine();

        }

        private static int FindtheBestEfforts(int numberOfDoctors, int numberOfPatients, int[,] array)
        {
            int finalEffort = 0;
            Dictionary<string, int> DocPatEffort = new Dictionary<string, int>();
            int[] minOfColumns = new int[numberOfPatients];
            int[] docNumber = new int[numberOfPatients];
            if(numberOfDoctors==1)
            {
                for (int i = 0; i < numberOfPatients; i++)
                {
                    finalEffort += array[0, i];
                }
                return finalEffort;
            }
            //fillDictionary(DocPatEffort, array, numberOfPatients, numberOfDoctors);

            #region trial1
            //first compute the rowwise output// ie. if we assign all pt to same doc
            for (int i = 0; i < numberOfDoctors; i++)
            {
                int localSum = 0;
                for (int j = 0; j < numberOfPatients; j++)
                {
                    localSum += array[i, j];
                }
                if (finalEffort != 0 && finalEffort > localSum) finalEffort = localSum;
                else if (finalEffort == 0) finalEffort = localSum;

            }
            //we have more than one doctor, so let's move forward
            for (int doc = 0; doc < numberOfDoctors - 1; doc++)
            {
                int localSum = 0;
                for (int pat = 0; pat < numberOfPatients; pat++)
                {
                    
                    if (array[doc, pat] < array[doc + 1, pat])
                    {
                        minOfColumns[pat] = array[doc, pat];
                        localSum += array[doc, pat];
                        docNumber[pat] = doc;

                    }
                    else if (array[doc, pat] > array[doc + 1, pat])
                    {

                        minOfColumns[pat] = array[doc + 1, pat];
                        localSum += array[doc + 1, pat];
                        docNumber[pat] = doc + 1;

                    }
                    else if (array[doc, pat] == array[doc + 1, pat])
                    {
                        
                        minOfColumns[pat] = array[doc, pat];
                        localSum+= array[doc, pat];
                        if (pat > 0)
                            docNumber[pat] = docNumber[pat - 1];
                        else
                            docNumber[pat] = doc;

                    }
                }
                if (finalEffort > localSum) //finalEffort = localSum;
                {
                    bool isAcceptable = true;
                    List<int> alreadyIn = new List<int>();
                    for (int i = 0; i < docNumber.Length; i++)
                    {
                        if(i==0)alreadyIn.Add(docNumber[i]);
                        else
                        {
                            if (docNumber[i] != alreadyIn.Last() && alreadyIn.Exists(s => s == docNumber[i]))
                            {
                                isAcceptable = false;
                                break;
                               
                            }
                            else alreadyIn.Add(docNumber[i]);
                            
                        }
                        //finalEffort = localSum;
                    }
                    if(isAcceptable) finalEffort = localSum;
                }
            }
            
            #endregion

            return finalEffort;
        }

        private static void fillDictionary(Dictionary<string, int> docPatEffort, int[,] array, int numberOfPatients, int numberOfDoctors)
        {
            for (int i = 0; i < numberOfDoctors; i++)
            {
                for (int j = 0; j < numberOfPatients; j++)
                {
                    if(j==0) docPatEffort[makeKey(i,j)] = array[i, j];
                    else
                    {
                        docPatEffort[makeKey(i, j)] = docPatEffort[makeKey(i, j - 1)] + array[i, j];
                    }
                }
            }
        }

        private static string makeKey(int i, int j)
        {
            string key = i.ToString();
            for (int n = 0; n <= j; n++)
            {
                key = key + n.ToString();
            }
            return key;
        }
    }

    
        

}

