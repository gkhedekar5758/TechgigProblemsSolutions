using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TECHGIG_small_tests
{

    class Program
    {

        public static string Numerals(int num)
        {
            int[] numbers = new int[] { 1,4,5,9,10,40,50,90,100,400,500,900,1000};
            string[] romanValues = new string[] {"I","IV","V","IX","X","XL","L","XC","C","CD","D","CM","M" };
            Array.Reverse(numbers);
            Array.Reverse(romanValues);

            StringBuilder result = new StringBuilder();
            for (int index =0; index < numbers.Length; index++)
            {
                while(num>=numbers[index])
                {
                    result.Append(romanValues[index]);
                    num -= numbers[index];
                }
            }
            return result.ToString();
        }

        public static int Decode(string roman)
        {
            //base case
            if (String.IsNullOrWhiteSpace(roman)) return -1;
            int[] numbers = new int[] { 1, 5, 10, 50, 100, 500, 1000 };
            string[] romanValues = new string[] { "I", "V", "X", "L", "C", "D", "M" };
            
            
            int finalResult = numbers[romanValues.ToList().IndexOf(roman[roman.Length-1].ToString())];
            for (int index = roman.Length-2; index >=0; index--)
            {
                if (numbers[romanValues.ToList().IndexOf(roman[index].ToString())] >= numbers[romanValues.ToList().IndexOf(roman[index + 1].ToString())])
                {
                    finalResult += numbers[romanValues.ToList().IndexOf(roman[index].ToString())];
                }
                else
                    finalResult -= numbers[romanValues.ToList().IndexOf(roman[index].ToString())];

            }
            return finalResult;
        }

        public static double Calc(string expression)
        {
            //char[] parsedExp = expression.Trim(' ').ToCharArray();
            char[] parsedExp = ProcessEx(expression);
            Stack<char> operatorStack = new Stack<char>();
            Stack<double> valueStack = new Stack<double>();
            bool appendMinus = false;
            for (int i = 0; i < parsedExp.Length; i++)
            {
                if (parsedExp[i] == ' ') continue;
                if (parsedExp[i] == '-' && i == 0) appendMinus = true;
                if(isOperator(parsedExp[i]) && i!=0)
                {
                    while (operatorStack.Count>0 && isSamePresedence(parsedExp[i],operatorStack.Peek()))
                    {
                        if(parsedExp[i]=='-' && isOperator(parsedExp[i-1]))
                        {
                            var result = DoMaths(operatorStack.Pop(), valueStack.Pop(), valueStack.Pop());
                            valueStack.Push(result);
                        }
                        
                    }
                    if (parsedExp[i] == '-' && !isOperator(parsedExp[i - 1])) operatorStack.Push(parsedExp[i]);
                    else
                        appendMinus = true;
                    //previousChar = parsedExp[i];
                }
                if(isNumber(parsedExp[i]))
                {
                    StringBuilder wholeNumberString = new StringBuilder();
                    if (appendMinus)
                    {
                        wholeNumberString.Append('-');
                        appendMinus = false;
                    }
                        
                    while (i < parsedExp.Length && isNumber(parsedExp[i]))
                    {
                        wholeNumberString.Append(parsedExp[i++]);
                    }
                    
                    valueStack.Push(Convert.ToInt32( wholeNumberString.ToString()));  //as of now int only
                    
                    i--;
                   // previousChar = parsedExp[i];
                }
                if(parsedExp[i]=='(')
                {
                    operatorStack.Push(parsedExp[i]);
                }
                if(parsedExp[i]==')')
                {
                    while(operatorStack.Peek()!='(')
                    {
                        var result = DoMaths(operatorStack.Pop(),valueStack.Pop(),valueStack.Pop());
                        valueStack.Push(result);
                    }
                    operatorStack.Pop();
                }
            }

            while (operatorStack.Count >0 && valueStack.Count >= 2)
            {
                var result = DoMaths(operatorStack.Pop(), valueStack.Pop(), valueStack.Pop());
                valueStack.Push(result);
            }

            return valueStack.Pop();
        }

        private static char[] ProcessEx(string expression)
        {
            //return expression.Replace(' ', '');
            List<char> trimmed = new List<char>();
            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == ' ') continue;
                trimmed.Add(expression[i]);
            }
            return trimmed.ToArray();
        }

        private static bool isSamePresedence(char v1, char v2)
        {
            if(v1=='('|| v2==')')
            {
                return false;
            }
            if (v1 == '+' && v2 == '-')
                return true;
            if (v1 == '*' && v2 == '/')
                return true;


            return false;
        }

        private static double DoMaths(char op, double v1, double v2)
        {
            if (op == '+') return v2 + v1;
            if (op == '-') return v2 - v1;
            if (op == '*') return v2 * v1;
            if (op == '/' && v1!=0) return v2 / v1;
            return -1;
        }

        private static bool isNumber(char v)
        {
            return v >= '0' && v <= '9';
        }

        private static bool isOperator(char v)
        {
            //try
            //{
            //    int A = 0;
            //    int B = 3 / A;
            //   // return v.Equals('+') || v.Equals('-') || v.Equals('*') || v.Equals('/');
            //    int k = 3;
            //}
            //catch (Exception E) { throw E; }
            //finally
            //{
            //    Console.Write("FINALLY CALLED");
            //}
            //return v.Equals('+') || v.Equals('-') || v.Equals('*') || v.Equals('/');
            return false;
        }

        public class ParentClass
        {
            public  void ClassMethod()
            {
                Console.WriteLine($" I am in {typeof(ParentClass)}");
            }
        }
        public class ChildClass:ParentClass
        {
            public  void ClassMethod()
            {
                Console.WriteLine($"I am in {typeof(ChildClass)}");
            }
        }
        static void Main(string[] args)
        {
            //string[] atim = new string[] { "aa","a" };
            //TIMSORT.timSort(atim, atim.Length);
            //TIMSORT.printArray(atim,atim.Length);
            ChildClass child = new ChildClass();
            child.ClassMethod();
            var a = isOperator('*');
            //Method1();
            //string s=Console.ReadLine();
            //int wordCnt = 1;
            //for (int i = 0; i < s.Length; i++)
            //{
            //    Console.WriteLine(s[i]);
            //}
            //int c = 0;
            //if(c==0)
            //    Console.WriteLine("true"); Console.WriteLine("zalak");

            //Console.WriteLine(c);

            //dynamic vntData = new object[1, 30];

            //for (int i = 0; i < vntData.GetUpperBound(1); i++)
            //{
            //    vntData[0, i] = new object[19, 1];
            //}

            //for (int i = 0; i < vntData.GetUpperBound(1); i++)
            //{
            //    var objArray = vntData[0, i];
            //    for (int j = 0; j <= objArray.GetUpperBound(0); j++)
            //    {
            //        vntData[0, i][j, 0] = 'r' + j.ToString();
            //        if (j==8 || j==9 || j==15)
            //        {
            //            vntData[0, i][j, 0] = null;
            //        }
                    
            //    }
            //}

            //Console.WriteLine(vntData.GetLowerBound(0));
            //Console.WriteLine(vntData.GetUpperBound(0));


            //Console.WriteLine(vntData.GetLowerBound(1));
            
            //Console.WriteLine(vntData.GetUpperBound(0));




            //Console.WriteLine(Calc("1 - - 123 + 4"));
            //Console.WriteLine(Decode("MIXX"));
            //Console.WriteLine(  Numerals(91));
            //Console.WriteLine(Numerals(111));
            //for (int i = 0; i < 5; i++)
            //{
            //    var log = new System.Diagnostics.EventLog("Application");
            //    log.Source = "APM app";
            //    log.WriteEntry(" rotate " + i.ToString());
            //}
            //string path = @"C:\APM Data\Concentra Merge Patient Plan.docx";
            //var dttim = System.IO.File.GetLastWriteTime(path);
            //Console.WriteLine(dttim.Year);
            //Console.WriteLine(dttim.Month);
            //Console.WriteLine(dttim.Day);
            //Console.WriteLine(dttim.Hour);
            //Console.WriteLine(dttim.Minute);
            //Console.WriteLine(dttim.Second);



            //Console.WriteLine(BinarySearch.BinarySearchMethod());
            //Console.WriteLine();
            //Console.WriteLine();
            //MITOPENCOURSE.method();
            //BinarySearchApplication.mehtod();
            ////BinarySearchApplication2.method();

            //#region sorting

            //List<int> a = new List<int>();
            //var r = new Random();
            //for (int i = 1000; i > 0; i--)
            //{
            //    a.Add(i + r.Next(int.MaxValue));
            //}
            //var arr = a.ToArray();

            //SelectionSorting.method(arr);
            //BubbleSorting.method(arr);
            //InsertionSorting.method(arr);
            MergeSorting.method();
            QuickSorting.method();
            HeapSorting.method();
            CountingSorting.method();
            RadixSorting.method();
            BucketSorting.method();
            //#endregion


            #region treeRegion
            BinarySearchTree BST = new BinarySearchTree();
            BST.mainMethod(method:"I",val:25);
            //BST.mainMethod(3);
            BST.mainMethod( "I",12);
            BST.mainMethod("I",4);
            BST.mainMethod( "I",67);
            BST.mainMethod( "I",34);
            BST.mainMethod( "I",1);
            BST.mainMethod("I", 13);

            BST.mainMethod(method: "INT");
            BST.mainMethod("PRE");
            BST.mainMethod("POST");


            BST.mainMethod(method: "SEARCH", 1);

            BST.mainMethod(method: "DEL", 25);
            BST.mainMethod(method: "INT");
            
            #endregion

            ArraySplit.method();

            BooksFromSameAge.Method();
            // NOTE: You can use the following input values to test this function.
            int[] a1 = { -1, 3, 8, 2, 9, 5 };
            int[] a2 = { 4, 1, 2, 10, 5, 20 };
            int aTarget = 24;
            // closestSumPair(a1, a2, aTarget) should return {5, 20} or {3, 20}
            int[] result=closestSumPair(a1, a2, aTarget);
            printResult(result);

            int[] b1 = { 7, 4, 1, 10 };
            int[] b2 = { 4, 5, 8, 7 };
            int bTarget = 13;
            // closestSumPair(b1, b2, bTarget) should return {4, 8}, {7, 7}, {7, 5}, or {10, 4}

            int[] c1 = { 6, 8, -1, -8, -3 };
            int[] c2 = { 4, -6, 2, 9, -3 };
            int cTarget = 3;
            // closestSumPair(c1, c2, cTarget) should return {-1, 4} or {6, -3}

            int[] d1 = { 19, 14, 6, 11, -16, 14, -16, -9, 16, 13 };
            int[] d2 = { 13, 9, -15, -2, -18, 16, 17, 2, -11, -7 };
            int dTarget = -15;
            // closestSumPair(d1, d2, dTarget) should return {-16, 2}, {-9, -7}

            //find max in K window
            Console.WriteLine();
            int[] arr = { 1, 2, 3, 1, 4, 5, 2, 3, 6 };
            int K = 5;
            FindTheMaxInAllK(arr, K);

            //find if the expression is balanced or not
            Console.WriteLine();
            //string ex = "[()]{}{[()()]()}";
            string ex = "[(}";
            Console.WriteLine("Balanced :"+FindIfBalanced(ex));

            //find the minimum flips needed to make the 
            //            string expre = "}{{}}{{{{}{}{}{}{{{{}{{}"; // this is not giving correct OP
            string expre = "}{{{{{{{";
            Console.WriteLine("Min Swap needed :" + MinSwapNeeded(expre));

            //Rabin Karp algo- find if the string pattern is there in the String Text
            string txt = "AABAACAADAABAABA";
            string ptrn = "ABA";
            FindAllOccuranceInTXT(txt, ptrn);
            Console.ReadLine();
        }

        private static void FindAllOccuranceInTXT(string txt, string ptrn)
        {
            int leftPointer = 0;
            int patternLength = ptrn.Length;
            while (leftPointer <= txt.Length-patternLength)
            {
                if(txt.Substring(leftPointer,patternLength).Equals(ptrn))
                    Console.WriteLine("Pattern found at : "+leftPointer);

                leftPointer++;
            }

        }

        private static int MinSwapNeeded(string expre)
        {
            if (expre.Length % 2!=0)
             return -1;

            Stack<char> stack = new Stack<char>();
            for (int i = 0; i < expre.Length; i++)
            {
                char charAtIndexI = expre[i];
                if(charAtIndexI=='}' && stack.Count>0)
                {
                    if (stack.Peek() == '{')
                        stack.Pop();
                    else
                        stack.Push(charAtIndexI);
                }
                else
                {
                    stack.Push(charAtIndexI);
                }
            }

            int reducedCount = stack.Count;
            int n = 0;
            while (stack.Count>0 && stack.Peek()=='{')
            {
                stack.Pop();
                n++;
            }

            //return (int)(Math.Ceiling((decimal)(reducedCount / 2)) + Math.Ceiling((decimal)(n / 2)));
            return (reducedCount / 2 + n % 2);

            //return 0;
        }

        private static string FindIfBalanced(string v)
        {
            Stack<char> stack = new Stack<char>();
            for (int i = 0; i < v.Length; i++)
            {
                char charAtIndexI = v[i];
                if(OpeningBracket(charAtIndexI))
                {
                    stack.Push(charAtIndexI);
                }
                else if(ClosingBracket(charAtIndexI))
                {
                    char openingChar = stack.Peek();
                    if (!MakesAPair(openingChar, charAtIndexI))
                        return "Not Balanced";
                    else
                        stack.Pop();
                }
            }

            return "Balanced";
        }

        private static bool MakesAPair(char openingChar, char closingChar)
        {
            return (openingChar == '{' && closingChar == '}') || (openingChar == '[' && closingChar == ']') || (openingChar == '(' && closingChar == ')');
        }

        private static bool ClosingBracket(char charAtIndexI)
        {
            return charAtIndexI == '}' || charAtIndexI == ']' || charAtIndexI == ')';
        }

        private static bool OpeningBracket(char charAtIndexI)
        {
            return charAtIndexI == '{' || charAtIndexI == '[' || charAtIndexI == '(';
        }

        //O(N)
        private static void FindTheMaxInAllK(int[] arr, int k)
        {
            int leftPointer = 0;
            int rightPointer = k - 1;
            int currentMax = int.MinValue;
            while (rightPointer < arr.Length)
            {
                if (leftPointer == 0)
                {
                    currentMax=Math.Max(currentMax, arr.Take(rightPointer+1).Max());
                    Console.Write(currentMax + " ");
                }
                else
                {
                    currentMax = Math.Max(currentMax, arr[rightPointer]);
                    Console.Write(currentMax + " ");
                }
                leftPointer++;
                rightPointer++;
            }
        }

        private static void Method1()
        {
            try
            {
                string a = "ca";
                method2();
            }
            catch (Exception ex)
            {
                Console.WriteLine("there was problem " + ex.Message);
                throw;
            }
        }

        private static void method2()
        {
            //int k = 0;
            //int d = 5 / k;
        }

        private static void printResult(int[] result)
        {
            for (int i = 0; i < result.Length; i++)
            {
                Console.Write(result[i].ToString() +" ");
            }
        }

        public static int[] closestSumPair(int[] a1, int[] a2, int target)
        {
            int[] a1Sorted = new int[a1.Length];
             Array.Copy(a1,a1Sorted, a1.Length);
            Array.Sort(a1Sorted);
            int[] a2Sorted = new int[a2.Length];
           Array.Copy(a2,a2Sorted, a2.Length);
            Array.Sort(a2Sorted);

            int i = 0;
            int j = a2Sorted.Length - 1;
            int smallestDiff = Math.Abs(a1Sorted[0] + a2Sorted[0] - target);
            int[] closestPair = { a1Sorted[0], a2Sorted[0] };

            while (i < a1Sorted.Length && j >= 0)
            {
                int v1 = a1Sorted[i];
                int v2 = a2Sorted[j];
                int currentDiff = v1 + v2 - target;
                if (Math.Abs(currentDiff) < smallestDiff)
                {
                    smallestDiff = Math.Abs(currentDiff);
                    closestPair[0] = v1; closestPair[1] = v2;
                }

                if (currentDiff == 0)
                {
                    return closestPair;
                }
                else if (currentDiff < 0)
                {
                    i += 1;
                }
                else
                {
                    j -= 1;
                }
            }

            return closestPair;
        }
        #region FindAllPrimeNumbersBetwenRange
        static int FindAllPrimeNumbersBetwenRange(int lowerBound, int upperBound)
        {
            int countOfPrimeNo = 0;
            for (int i = lowerBound; i <= upperBound; i++)
            {
                if (IsItPrime(i, lowerBound, upperBound)) countOfPrimeNo++;
            }
            return countOfPrimeNo;
        }
      static  bool IsItPrime(int no, int l, int u)
        {
            if (no == 0 || no == 1 || no == 2) return false;

            for (int i = 2; i < no; i++)
            {
                if ((no % i) == 0) return false;
            }

            return true;
        }
        #endregion

        #region FindArmStrongNumberBetweenRange

        static bool FindArmStrongNumberBetweenRange(int numberToCheck)
        {
            List<int> ASnumberList = new List<int>();
            int savNumberToCheck = numberToCheck;
            int sum = 0;
            while(numberToCheck>0)
            {
                ASnumberList.Add(numberToCheck % 10);
                numberToCheck /= 10;
            }
            var asNumberArr = ASnumberList.ToArray();
            for (int i = 0; i < asNumberArr.Length; i++)
            {
                sum += Convert.ToInt16( (Math.Pow( asNumberArr[i],3)));
            }
            if (sum == savNumberToCheck) return true;
            return false;
            
        }
        #endregion

        #region Is Your Number Narcissistic
        static bool IsYourNumberNarcissistic(int numberToCheck)
        {
            int savNumberToCheck = numberToCheck;
            int pow = numberToCheck.ToString().Length;
            List<int> aList = new List<int>();
            int sum = 0;
            while (numberToCheck>0)
            {
                aList.Add(numberToCheck % 10);
                numberToCheck /= 10;
            }
            var aArr = aList.ToArray();
            for (int i = 0; i < aArr.Length; i++)
            {
                sum += Convert.ToInt32(Math.Pow(aArr[i], pow));
            }
            if (sum == savNumberToCheck) return true;
            return false;

        }
        #endregion

        #region FindTheSecondHighestNumberInArray

        static int FindTheSecondHighestNumberInArray(int[] inputArray)
        {
            return 0;
        }

        #endregion
    }
}
