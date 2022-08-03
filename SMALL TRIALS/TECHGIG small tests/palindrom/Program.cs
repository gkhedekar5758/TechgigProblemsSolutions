using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace palindrom
{
    public interface IAnimal
    {
        void speak();
        void interact(DOG d);
        void interact(CAT c);

        void interact(IAnimal a);
    }

    public class DOG : IAnimal
    {
        public void interact(DOG d)
        {
            Console.WriteLine("dog to dog");
        }

        public void interact(CAT c)
        {
            Console.WriteLine("dog to cat");
        }

        public void interact(IAnimal a)
        {
            Console.WriteLine("dog to animal");
        }

        public void speak()
        {
            Console.WriteLine("bow");
        }
    }

    public class CAT : IAnimal
    {
        public void interact(DOG d)
        {
            Console.WriteLine("cat to dog");
        }

        public void interact(CAT c)
        {
            Console.WriteLine("cat to cat");
        }

        public void interact(IAnimal a)
        {
            Console.WriteLine("cat to animal");
        }

        public void speak()
        {
            Console.WriteLine("Meow");
        }
    }

    public class TwoStack
    {
        List<int> _listArray = null;
        int _counterForFirstStack;
        int _counterForSecondStack;
        public TwoStack()
        {
            _listArray = new List<int>();
            _counterForFirstStack = -2;
            _counterForSecondStack = -1;
        }

        public void push1(int elementToBeInserted)
        {
            _counterForFirstStack+=2;
            _listArray.Insert(_counterForFirstStack, elementToBeInserted);
            
        }

        public int pop1()
        {
            int elementToBeReturned = _listArray.ElementAt(_counterForFirstStack);
            _listArray.RemoveAt(_counterForFirstStack);
            _counterForFirstStack -= 2;
            return elementToBeReturned;
        }
        public void push2(int elementToBeInserted)
        {
            _counterForSecondStack += 2;
            _listArray.Insert(_counterForSecondStack, elementToBeInserted);
        }

        public int pop2()
        {
            int elementToBeReturned = _listArray.ElementAt(_counterForSecondStack);
            _listArray.RemoveAt(_counterForSecondStack);
            _counterForSecondStack -= 2;
            return elementToBeReturned;
        }
    }
    class Program
    {
        static int countBit(int n)
        {
            int count = 0;
            while (n>0)
            {
                count += n & 1;
                n >>= 1;
            }
            return count;
        }
        static int getMinDiff(int[] arr, int n, int k)
        {
            if (n == 1)
                return 0;

            // Sort all elements
            Array.Sort(arr);

            // Initialize result
            int ans = arr[n - 1] - arr[0];

            // Handle corner elements
            int small = arr[0] + k;
            int big = arr[n - 1] - k;
            int temp = 0;

            if (small > big)
            {
                temp = small;
                small = big;
                big = temp;
            }

            // Traverse middle elements
            for (int i = 1; i < n - 1; i++)
            {
                int subtract = arr[i] - k;
                int add = arr[i] + k;

                // If both subtraction and
                // addition do not change diff
                if (subtract >= small || add <= big)
                    continue;

                // Either subtraction causes a smaller
                // number or addition causes a greater
                // number. Update small or big using
                // greedy approach (If big - subtract
                // causes smaller diff, update small
                // Else update big)
                if (big - subtract <= add - small)
                    small = subtract;
                else
                    big = add;
            }

            return Math.Min(ans, big - small);
        }
        static void Main(string[] args)
        {


            int[] array = new int[5];
            array[2] = 1;
            string s = "";
            for (int i = 0; i < array.Length; i++)
            {

                s += array[i].ToString();
            }
            int bin = Convert.ToInt16(s, 2);
            Dictionary<char, bool> dictCharBool = new Dictionary<char, bool>();
            for (int ind = 97; ind < 123; ind++)
            {
                dictCharBool.Add(Convert.ToChar(ind), false);
            }
            string check = "The quick brown fox jumps  the lazy dog";
            check = check.ToLower();
            for (int index = 0; index < check.Length; index++)
            {
                dictCharBool[check[index]] = true;
            }

            if (dictCharBool.Any(x => x.Value == false))
            {
                var remain = dictCharBool.Where(x => x.Value == false);
            }
                
            else
                Console.WriteLine("tru");
            int asciiValue;
            //int i = 0;
            for (asciiValue = 33; asciiValue <= 127; asciiValue++)
            {
                
                Console.WriteLine(" " + Convert.ToChar(asciiValue)+" => "+asciiValue);
                //i++;
            }
            int abn = countBit(9);
            TwoStack twoStack = new TwoStack();
            twoStack.push1(23);
            twoStack.push1(24);
            Console.WriteLine(twoStack.pop1());
            Console.WriteLine(twoStack.pop1());

            int[,] darr = new int[,] { { 0,1,1,1}, {0,0,1,1},{ 1,1,1,1} };
            int[] arr = { 1, 10, 14, 14, 14, 15 };
            int n = arr.Length;
            int k = 6;
            Console.Write("Maximum difference is " +
                            getMinDiff(arr, n, k));
            #region ecludian algo for GCD
            int aa = 90, bb = 60;
            while(aa!=bb)
            {
                if(aa>bb)
                {
                    aa = aa - bb;
                }
                else
                {
                    bb = bb - aa;
                }
            }
            #endregion
            int[,] a = new int[2, 3] { { 1, 2 ,4},
                                        { 3, 4,4 } };

            //int[][] a2=new int[2][3] {}
            IAnimal cat = new CAT();
            IAnimal dog = new DOG();
            cat.speak();
            dog.speak();
            cat.interact(dog);
            dog.interact(cat);

            for (int index = 0; index < 5; index++)
            {
                Console.WriteLine(index & 0x01);
            }
            int[] num = { 1,2,1};
            generateNextPalindrome(num, num.Length);
            ArrayProblem1.method();
            Console.Read();
        }

        static void generateNextPalindromeUtil(int[] num, int n)
        {
            int mid = n / 2;

            // end of left side is always 'mid -1'
            int i = mid - 1;

            // Beginning of right side depends
            // if n is odd or even
            int j = (n % 2 == 0) ? mid : mid + 1;

            // A bool variable to check if copy of left
            // side to right
            // is sufficient or not
            bool leftsmaller = false;

            // Initially, ignore the middle same digits
            while (i >= 0 && num[i] == num[j])
            {
                i--;
                j++;
            }

            // Find if the middle digit(s) need to
            // be incremented or not (or copying left
            // side is not sufficient)
            if (i < 0 || num[i] < num[j])
            {
                leftsmaller = true;
            }

            // Copy the mirror of left to tight
            while (i >= 0)
            {
                num[j++] = num[i--];
            }

            // Handle the case where middle digit(s)
            // must be incremented. This part of code
            // is for CASE 1 and CASE 2.2
            if (leftsmaller)
            {
                int carry = 1;

                // If there are odd digits, then increment
                // the middle digit and store the carry
                if (n % 2 == 1)
                {
                    num[mid] += 1;
                    carry = num[mid] / 10;
                    num[mid] %= 10;
                }
                i = mid - 1;
                j = (n % 2 == 0 ? mid : mid + 1);

                // Add 1 to the rightmost digit of the left
                // side, propagate the carry towards MSB digit
                // and simultaneously copying mirror of the
                // left side to the right side.
                while (i >= 0)
                {
                    num[i] = num[i] + carry;
                    carry = num[i] / 10;
                    num[i] %= 10;
                    num[j] = num[i];// copy mirror to right
                    i--;
                    j++;
                }

            }
        }

        // The function that prints next palindrome
        // of a given number num[] with n digits.
        static void generateNextPalindrome(int[] num, int n)
        {
            Console.WriteLine("Next Palindrome is:");

            // Input type 1: All the digits are 9,
            // simply o/p 1 followed by n-1 0's
            // followed by 1.
            if (isAll9(num, n))
            {
                Console.Write("1");
                for (int i = 0; i < n - 1; i++)
                    Console.Write("0");
                Console.Write("1");

            }

            // Input type 2 and 3
            else
            {
                generateNextPalindromeUtil(num, n);
                printarray(num);
            }
        }

        // A utility function to check if num has all 9s
        static bool isAll9(int[] num, int n)
        {
            for (int i = 0; i < n; i++)
                if (num[i] != 9)
                    return false;
            return true;
        }

        /* Utility that prints out an array on a line */
        static void printarray(int[] num)
        {
            for (int i = 0; i < num.Length; i++)
                Console.Write(num[i] + " ");
            Console.Write(" ");
        }
    }
}
