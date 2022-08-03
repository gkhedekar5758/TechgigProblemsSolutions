using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayProblemsGFG
{
    /// <summary>
    /// Clean Code
    /// </summary>
    public static class StringProblemInterViewBit
    {
        public static void addBlankLinesBetweenOuput()
        {
            Console.WriteLine();
            Console.WriteLine("**************************************");
            Console.WriteLine();
        }
        public static void MasterMethod()
        {
            //Given a string, determine if it is a palindrome, considering only
            //alphanumeric characters and ignoring cases.
            string A = "race a car";
            Console.WriteLine($"Given string is Palindrom ? - {IsStringPalindrom(A)}");
            addBlankLinesBetweenOuput();


            //Given a string A consisting of lowercase characters.
            // You have to find the number of substrings in A which starts with vowel and end with
            // consonants or vice - versa.
            //Return the count of substring modulo 109 + 7.
            string b = "abba";
            Console.WriteLine(Solve(b));
            addBlankLinesBetweenOuput();

            //Given a string A and integer B, remove all consecutive same characters
            //that have length exactly B.
            string c = "aabcc";
            int B = 2;
            Console.WriteLine(RemoveString(c,B));
            addBlankLinesBetweenOuput();

          List<string> a=new List<string>(){ "ABCD"};
            Console.WriteLine(LongestCommonPrefix(a));
            addBlankLinesBetweenOuput();


            //You are given a string S, and you have to find all the amazing substrings of S.
            //Amazing Substring is one that starts with a vowel(a, e, i, o, u, A, E, I, O, U).
            string ip = "abc";
            Console.WriteLine(FindAwesomeString(ip));

            //strstr - locate a substring ( needle ) in a string ( haystack ).
            string inputString = "ABCE";
            string searchString = "CE";
            Console.WriteLine(SearchAString(inputString,searchString));




        }

        private static int SearchAString(string A, string B)
        {
            int indexOfSubstring = -1;
            int lengthOfSearchString = B.Length;
            int lengthOfInputString = A.Length;

            //base case
            if ((lengthOfInputString == 0 && lengthOfSearchString == 0) || (lengthOfSearchString==0))
                return -1;
            for (int i = 0; i < lengthOfInputString; i++)
            {
                if(A[i]==B[0] && (lengthOfInputString-i >= lengthOfSearchString))
                {
                    if(SearchSub(i, B, A, lengthOfInputString, lengthOfSearchString))
                    {
                        indexOfSubstring = i;
                        break;
                    }    
                }
            }


            return indexOfSubstring;
        }

        private static bool SearchSub(int i, string searchString,string inputString, int lengthOfInputString, int lengthOfSearchString)
        {
            int seachStringIndex = 1;
            int inputStringIndex = i + 1;

            while (seachStringIndex < lengthOfSearchString)
            {
                if (inputString[inputStringIndex] == searchString[seachStringIndex])
                {
                    inputStringIndex++;
                    seachStringIndex++;
                }
                else
                    return false;
            }

            return true;
        }

        private static int FindAwesomeString(string A)
        {
            int count = 0;
            for (int i = 0; i < A.Length; i++)
            {
                if(isVovel(A[i]))
                {
                    count += (A.Length - i) ;
                }
            }

            return count % 10003;
        }

        private static void countAndSay(int A)
        {
            #region trial 1
            //int curr = 1;
            //String str = "1";
            //while (curr != n)
            //{
            //    StringBuilder sb = new StringBuilder();
            //    int idx = 0;
            //    int length = str.Length;
            //    while (idx < length)
            //    {
            //        char c = str.ElementAt(idx);
            //        int count = 0;
            //        while (idx < length && str.ElementAt(idx) == c)
            //        {
            //            idx++;
            //            count++;
            //        }
            //        sb.Append(count).Append(c);
            //    }
            //    str = sb.ToString();
            //    curr++;
            //}
            //return str;
            #endregion

            #region trial 2
            //int i, j, s1, count = 1;
            //string str1 = "1", str2 = "";
            //if (A == 1)    // Base Case
            //    return str1;
            //for (i = 2; i <= A; i++)
            //{
            //    count = 1; j = 0;
            //    s1 = str1.Length;
            //    while (j < s1)
            //    {
            //        // Keeping count of the current character
            //        if (str1[j] == str1[j + 1])
            //        {
            //            count++;
            //            j++;
            //        }
            //        else
            //        {
            //            // Append the count and current character
            //            str2 += count.ToString();
            //            str2 += str1[j];
            //            j++;
            //            count = 1;
            //        }
            //    }
            //    // Store the current result.
            //    str1 = str2;
            //    str2 = "";
            //}
            //// Return result
            //return str1;
            #endregion
        }

        private static string LongestCommonPrefix(List<string> A)
        {
            string[] stringArray = A.ToArray();

            if (stringArray.Length == 1) return stringArray[0];
            string answer = "";

            for (int index = 0; index < stringArray[0].Length; index++)
            {
                bool isAllHaveIt = false;
                
                char c = stringArray[0].ElementAt(index);
                for (int internalIndex = 1; internalIndex < stringArray.Length; internalIndex++)
                {
                    bool iscurrentHaveIt = false;
                    if (stringArray[internalIndex].Length>index     &&  c.Equals(stringArray[internalIndex].ElementAt(index)))
                    {
                        iscurrentHaveIt = true;
                    }
                    else
                    {
                        isAllHaveIt = false;
                        break;
                    }
                    isAllHaveIt = iscurrentHaveIt;
                }
                if (isAllHaveIt) answer += c;
                else break;
            }



            return answer;
        }

        private static string RemoveString(string stringToBeChanged, int B)
        {
            string answerString = "";
            int n = 0;
            while (n<stringToBeChanged.Length)
            {
                if (n + 1 < stringToBeChanged.Length)
                {
                    if (isSame(stringToBeChanged.Substring(n, B)))
                    {
                        n += B;
                    }
                    else
                    {
                        answerString += stringToBeChanged[n];
                        n++;
                    }
                }
                else
                {
                    answerString += stringToBeChanged[n];
                    n++;
                }
                   
                    

            }
            return answerString;
        }

        private static bool isSame(string v)
        {
            char prevChar = v[0];
            for (int i = 1; i < v.Length; i++)
            {
                if (!prevChar.Equals(v[i]))
                {
                    return false;
                }
            }

            return true;
        }

        private static int Solve(string inputString)
        {
            int answerCount = 0;
            for (int index = 0; index < inputString.Length; index++)
            {
                for (int indexJ = 2; indexJ+index <= inputString.Length; indexJ++)
                {
                    string stringToBeChecked = inputString.Substring(index, indexJ);
                    if (stringIsCountable(stringToBeChecked)) answerCount++;
                }
            }


            return answerCount;
        }

        private static bool stringIsCountable(string stringToBeChecked)
        {
            if ((isVovel(stringToBeChecked[0]) && isConsononat(stringToBeChecked[stringToBeChecked.Length - 1]))
                || (isConsononat(stringToBeChecked[0]) && isVovel(stringToBeChecked[stringToBeChecked.Length - 1])))
                return true;

            return false;
        }

        private static bool isConsononat(char v)
        {
            return (!(v == 'a' || v == 'e' || v == 'i' || v == 'o' || v == 'u' ||
                v == 'A' || v == 'E' || v == 'I' || v == 'O' || v == 'U'));
        }

        private static bool isVovel(char v)
        {
            return v == 'a' || v == 'e' || v == 'i' || v == 'o' || v == 'u' ||
                v == 'A' || v == 'E' || v == 'I' || v == 'O' || v == 'U';
        }

        private static int IsStringPalindrom(string stringToBeChecked)
        {
            int frontCounter = 0, rearCounter = stringToBeChecked.Length-1;
            while (frontCounter < rearCounter)
            {
                if (char.IsLetterOrDigit(stringToBeChecked[frontCounter]) 
                        && char.IsLetterOrDigit(stringToBeChecked[rearCounter]))
                {

                    if (!stringToBeChecked[frontCounter].ToString().
                        Equals(stringToBeChecked[rearCounter].ToString(),
                            StringComparison.CurrentCultureIgnoreCase))
                        return 0;

                    frontCounter++;
                    rearCounter--;

                }
                else
                {
                    if (!char.IsLetterOrDigit(stringToBeChecked[frontCounter]))
                        frontCounter++;
                    if (!char.IsLetterOrDigit(stringToBeChecked[rearCounter]))
                        rearCounter--;
                }

               
                
            }
            return 1;
        }
    }
}
