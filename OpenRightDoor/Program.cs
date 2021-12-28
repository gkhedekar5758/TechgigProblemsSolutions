using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenRightDoor
{
    class Program
    {
        static void Main(string[] args)
        {
            int output;
            int ip1;
            ip1 = Convert.ToInt32(Console.ReadLine());
            string ip2 = Console.ReadLine();
            output = openinngRightDoor(ip1, ip2);
            Console.WriteLine(output);
            Console.ReadLine();
        }

        static int totalCharacterAdded = 0;
       static List<char> justfortrack = new List<char>();
        static int openinngRightDoor(int input1,string input2)
        {
            if (CheckIfPalindrom(input2)) return totalCharacterAdded;
            else
            {
                bool finalQuitFlag = false;
                //char[] charArray = input2.ToCharArray();
                List<char> charList = new List<char>();
                charList = input2.ToList();

                #region LogicOne  
                //contains for loop
                //for (int i = 0,j=input2.Length-1; i < input2.Length-1; i++,j--)
                //{
                //    if (finalQuitFlag) break;
                //    if(charList[i]!=charList[j])   //check if first and last are same and keep on doing that
                //    {
                //        //charList.Add(charArray[i]);
                //        charList.Insert(j+1, charList[i]);
                //        totalCharacterAdded++;
                //        //charList.ToArray();
                //       // charArray = charList.ToArray();
                //        if (CheckIfPalindrom(new string(charList.ToArray()))) finalQuitFlag = true;
                //        //if(CheckIfPalindrom(new string()))
                //        j = charList.Count;
                //    }
                //}
                #endregion

                #region LogicTwo
                //contains while loop
                //int i = 0;
                //int j = input2.Length - 1;
                //while (!finalQuitFlag)
                //{
                //   // j--;
                //    if(charList[i]!=charList[j])
                //    {
                //        char temp;
                //        temp = charList[j+1];
                //        charList.Insert(j+1, charList[i]);
                //        totalCharacterAdded++;
                //        if (CheckIfPalindrom(new string(charList.ToArray()))) finalQuitFlag = true;
                //        j = charList.Count;
                //        i++;
                //        j--;
                //    }

                //}
                #endregion

                #region LogicThree

                // List<char> worklist = new List<char>();
                //charList = AddORRemoveNull("ADD", charList);
                //int i = 0;
                //int j = charList.Count-1;
                //int lastIndex = charList.Count-1;
                //while (!finalQuitFlag)
                //{

                //    if (charList[i]!=charList[lastIndex])
                //    {
                //        //if(i==0)
                //        //{
                //        //    charList = AddORRemoveNull("ADD", charList,charList.Count);
                //        //    charList.Insert(j + 1, charList[i]);
                //        //    totalCharacterAdded++;
                //        //    charList = AddORRemoveNull("REMOVE", charList,charList.Count);
                //        //    if (CheckIfPalindrom(new string(charList.ToArray()))) finalQuitFlag = true;
                //        //    j = charList.Count;
                //        //    i++;
                //        //    j--;
                //        //}
                //        //else
                //        //{
                //            charList = AddORRemoveNull("ADD", charList,charList.Count);
                //            //swaping logic
                //            char temp;
                //            temp = charList[lastIndex];
                //            charList.Insert(lastIndex+1, charList[i]);
                //            //lastIndex = j;
                //           // charList.Insert(j + 1, temp);
                //            //swaping logic ends here
                //            totalCharacterAdded++;
                //            charList = AddORRemoveNull("REMOVE", charList,charList.Count);
                //            if (CheckIfPalindrom(new string(charList.ToArray()))) finalQuitFlag = true;
                //            j = charList.Count;
                //            i++;
                //            j--;
                //        //}
                //    }
                //    else
                //    {
                //        i++;
                //        lastIndex = j;
                //        j--;
                //    }
                //}
                #endregion

                #region NoDaysLeft4/24/2017
                //int i = 0;
                //int j = charList.Count - 1;
                //int lastIndex = charList.Count - 1;

                if(charList.Count%2==0)    //if string is of even length
                {
                    int firstIndex = 0;
                    int lastIndex = charList.Count - 1;
                    while (!finalQuitFlag)
                    {
                        if(charList[firstIndex]!=charList[lastIndex])
                        {
                            charList = AddORRemoveNull("ADD", charList, charList.Count);
                            charList.Insert(lastIndex + 1, charList[firstIndex]);
                            firstIndex++;
                            totalCharacterAdded++;
                            charList = AddORRemoveNull("REMOVE", charList, charList.Count);
                            if (CheckIfPalindrom(new string(charList.ToArray()))) finalQuitFlag = true;
                            //if (firstIndex + 1 == lastIndex) finalQuitFlag = true;
                        }
                        else
                        {
                            firstIndex++;
                            lastIndex--;
                            //if (firstIndex + 1 == lastIndex) finalQuitFlag = true;
                        }
                        //if (firstIndex + 1 == lastIndex) finalQuitFlag = true;
                    }
                }
                else
                {
                    // int firstIndex = 0;
                    int mismatchCounter = 0;
                    int middleIndex = (charList.Count - 1) / 2;
                    for (int i = 0; i < middleIndex; i++)
                    {
                        for (int j = middleIndex+1; j <= charList.Count-1; j++)
                        {
                            if (charList[i] != charList[j]) mismatchCounter++;
                            if (charList[i] == charList[j])
                            {
                                mismatchCounter = 0;
                                finalQuitFlag=true;
                            }
                            if (mismatchCounter > charList.Count - 1) finalQuitFlag = true;
                            //if (totalCharacterAdded == ((charList.Count - 1) - middleIndex)) finalQuitFlag = true;
                            //else totalCharacterAdded = 0;
                            //if (finalQuitFlag) break;
                        }
                        if (finalQuitFlag) continue;
                        totalCharacterAdded = mismatchCounter;
                    //    if (finalQuitFlag) break;
                    }
                   // int lastIndex = charList.Count - 1;

                }
                #endregion

                justfortrack = charList;

            }
            
            return totalCharacterAdded;
        }

        static bool CheckIfPalindrom(string input)   //check if the string is already palindrom
        {
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            if (input == new string(charArray)) return true;
            return false;
        }

        static List<char> AddORRemoveNull(string input,List<char> input2,int length)
        {
            if(input=="ADD")
            {
               // int length = input2.Count;
                for (int i = input2.Count; i < length*2; i++)
                {
                    input2.Add(' ');
                }
            }
            else if(input=="REMOVE")
            {
                for (int i = length-1; i >length/2; i--)
                {
                    if (input2[i] == ' ') input2.RemoveAt(i);
                }

            }

            return input2;
        }
    }
}
