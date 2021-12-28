using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TECHGIG
{
    class Program
    {
        //solved
        static void Main(string[] args)
        {
             //DoublyLinkedList DLinkList=new DoublyLinkedList();
             //DLinkList.DoublyLinkedListMethod(2, 0);
             //DLinkList.DoublyLinkedListMethod(3, 0);
             //DLinkList.printListForwad();
             //DLinkList.printListBackward();

            //MainLogic ml = new MainLogic();
            
            //string output=ml.MainMethod();

            //Console.WriteLine(output);

            //CollegeClassversion1 obj = new CollegeClassversion1();
            //obj.ColegeClassv1method();

            //TECH GIG competition

            //Console.WriteLine("enter no of player");
            //int NoOfPlayers = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("enter no of max a person can recive");
            //int MaxNoOfBall = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("enter no of gaps that one can have between two players");
            //int NoOfPass = Convert.ToInt32(Console.ReadLine());
            //PassingTheBall obj = new PassingTheBall();
            //obj.Passit(NoOfPlayers, MaxNoOfBall, NoOfPass);

            //link list

           //List lst=new List();
           //lst.Add();
           // Console.ReadLine();


            ///

            //Console.WriteLine("enter your end number");
            //int a=Convert.ToInt16(Console.ReadLine());

            //string[] Arr=new string[(a*2)];
            //for (int i = 1,j=1; i < Arr.Length; i++,j++)
            //{
            //    Arr[i] = j.ToString();
            //    i++;
            //}

            //foreach (var item in Arr)
            //{
            //    Console.WriteLine(item);
            //}
            string a = "3#4";
            Console.WriteLine(a.Split('#').ToString());
            Console.ReadLine();
            

        }
    }
    class MainLogic
    {
        public string MainMethod()
        {
            //string outptstring="";
            Console.Write("Please enter the number : ");
            //Console.ReadLine();
            int a = Convert.ToInt16(Console.ReadLine());
            int[] inputarray1=new int[a];
            int[] inputarray2 = new int[a];

            //List<int> values1 = new List<int>();
            //var value="";
            //do
            //{
            //    value = Console.ReadLine();
            //    var inputvalue = int.Parse(value);
            //    value = Convert.ToInt16(Console.ReadLine());
            //    values1.Add(value);

            //} while (value >= 1);
            for (int i = 0; i < inputarray1.Length; i++)
            {
                Console.Write("enter the number for college 1 :");
                inputarray1[i] = Convert.ToInt16(Console.ReadLine());
            }
            Console.WriteLine("\n\n");
            for (int i = 0; i < inputarray1.Length; i++)
            {
                Console.Write("enter the number for college 2 :");
                inputarray2[i] = Convert.ToInt16(Console.ReadLine());
            }

            for (int i = 0; i < inputarray1.Length; i++)
            {
                if (inputarray2[i]<0||inputarray1[i]<0)
                {
                    return "invalid";
                    //break;
                    
                }
               
            }
            Array.Sort(inputarray1);
            Array.Sort(inputarray2);
    //        if (Array.Equals(inputarray1,inputarray2))
    //        {
    //            return "equal";
                
    //        }
    //        else
    //{
    //            return "unequal";
    //}
            //if (inputarray1.Equals(inputarray2))
            //{
            //    return "equal";
                
            //}
            //else
            //{
            //    return "unseuql";
            //}
            bool result = false;
           // Array.Sort(inputarray1);
            //Array.Sort(inputarray2);
            for (int i = 0; i < inputarray1.Length; i++)
            {
                if (inputarray1[i] == inputarray2[i])
                {
                    result = true;
                    break;
                }
                else
                {
                    result = false;
                    break;
                }
            }

            if (result)
            {
                return "equal";
            }
            else
            {
                return "enequal";
            }
            return "a";
        }
       
    }
}
