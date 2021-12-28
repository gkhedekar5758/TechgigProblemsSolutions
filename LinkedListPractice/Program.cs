using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            //ClassLinkList obj = new ClassLinkList();
            //Console.WriteLine("adding first");
            //obj.addFirstNode(1);
            //Console.WriteLine("added");
            //Console.WriteLine("adding next nodes");
            //obj.addNodes(2);
            //obj.addNodes(3);
            //obj.addNodes(4);
            //Console.WriteLine("addition done");
            //Console.WriteLine("now printing nodes");
            //obj.printNodes();

            /* system inbuild linked list */
            //LinkedList<int> linkList = new LinkedList<int>();
            //linkList.AddFirst(1);
            //linkList.AddLast(12);
            //linkList.AddLast(10);
            //linkList.AddBefore(linkList.First, 101);
           
            ////linkList.AddBefore(1, 23);
            //foreach (var item in linkList)
            //{
            //    Console.WriteLine(item);
            //}
            Console.Write("Enter no of player (N) :");
            int a = Convert.ToInt16(Console.ReadLine());
            Console.Write("Max no of ball (M) :");
            int b = Convert.ToInt16(Console.ReadLine());
            Console.Write("PASS to number (L) :");
            int c = Convert.ToInt16(Console.ReadLine());
            MainMethod an = new MainMethod();
            //an.PlayGame(a, b, c);
            Console.WriteLine("Result AKA Total Number of Passes"+an.PlayGame(a,b,c));
            Console.WriteLine("press any key to continue..");
            Console.ReadLine();
        }
    }
    class MainMethod
    {
        public int PlayGame(int a,int b,int c)
        {
            int TotalNumberOfPlayer = a;
            int MaxTimeBallReceive = b;
            int PassToLR = c;

            int[] playerArray = new int[TotalNumberOfPlayer];
            int TotalNumberOfBallPassed = 0;
            int PlayerWithBall = 0;
            int NextPlayerToPass=PassToLR;
            playerArray[0]=1;
            try { 
            while (!playerArray.Contains(MaxTimeBallReceive))
            {
               
                if (playerArray[NextPlayerToPass]%2==0)
                {
                    playerArray[NextPlayerToPass] = playerArray[NextPlayerToPass] + 1;  //increasing the count
                    NextPlayerToPass = NextPlayerToPass + PassToLR;
                    if (NextPlayerToPass>TotalNumberOfPlayer-1)
                    {
                        NextPlayerToPass =  NextPlayerToPass-TotalNumberOfPlayer;
                    }
                    
                }
                else
                {
                    playerArray[NextPlayerToPass] = playerArray[NextPlayerToPass] + 1;
                    NextPlayerToPass = NextPlayerToPass - PassToLR;

                    if (NextPlayerToPass<0)
                    {
                        NextPlayerToPass = TotalNumberOfPlayer + NextPlayerToPass;
                        
                    }
                }
                TotalNumberOfBallPassed++;

            }

            return TotalNumberOfBallPassed;
                }
            catch
            {
                return -1;
            }
        }
    }
}
