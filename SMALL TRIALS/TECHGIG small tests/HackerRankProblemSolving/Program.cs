using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankProblemSolving
{
    class Program
    {
        public class SinglyLinkedListNode
        {
            public int data;
            public SinglyLinkedListNode next;

            public SinglyLinkedListNode(int nodeData)
            {
                this.data = nodeData;
                this.next = null;
            }
        }

        ;public  class SinglyLinkedList
        {
            public SinglyLinkedListNode head;
            //public SinglyLinkedListNode tail;

            public SinglyLinkedList()
            {
                this.head = null;
                //this.tail = null;
            }

            public void InsertNode(int nodeData)
            {
                SinglyLinkedListNode node = new SinglyLinkedListNode(nodeData);

                if (this.head == null)
                {
                    this.head = node;
                }
                else
                {
                    //this.tail.next = node;
                    var cnode = head;
                    while (cnode.next != null)
                    {
                        cnode = cnode.next;
                    }
                    cnode.next = node;
                }

                //this.tail = node;
            }

            public void insertNodeAtTail(SinglyLinkedListNode head, int data)
            {
                SinglyLinkedListNode newNode = new SinglyLinkedListNode(data);

                if(head == null)
                {
                    head = newNode;
                    head.next = null;
                    
                }
                else
                {
                    var cnode = head;
                    while (cnode.next != null)
                    {
                        cnode = cnode.next;
                    }
                    cnode.next = newNode;
                }


               // tail = newNode;
                //tail.next = null;
            }

        }
            public static void arrayPrintingMethod(int[] array)
        {
            int lengthOfArray = array.Length;
            for (int index = 0; index < lengthOfArray; index++)
            {
                Console.Write(array[index] + " ");
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            //hacker rank2
            int[] arr25 = { 1, 2, 3, 4, 5 };
            int d = 2;
            var a = RotateLeftByD(d, arr25.ToList());
            arrayPrintingMethod(a.ToArray());


            // hacker rank3
            List<string> a1 = new List<string>() {"aba","baba","aba","xzxb" };
            List<string> a2 = new List<string>() { "aba", "xzxb","ab" };
            var a3 = matchingStrings(a1, a2);
            arrayPrintingMethod(a3.ToArray());

            //hackerrank4
            List<List<int>> a4 = new List<List<int>>() { new List<int>(){2,6,8 },new List<int>(){ 3,5,7},
                new List<int>(){1,8,1 },new List<int>(){5,10,15 } };
            int n = 10;
            Console.WriteLine( arrayManipulation(n, a4));

            //hackerrnk 5
            int Q = Convert.ToInt32(Console.ReadLine());
            int[] bucket = new int[Convert.ToInt32(Math.Pow(10, 6)) + 1];
            while (Q>0)
            {
                string qu = Console.ReadLine();
                string[] input=qu.Split(' ');
               
                if(input[0]=="R")
                {
                    long x = 0;
                    //int AA = bucket.ToList().Count(xx => xx != 0);
                    for (int i = Convert.ToInt32(input[1]); i <= Convert.ToInt32(input[2]); i++)
                    {
                        x += bucket[i];
                       
                    }
                    Console.WriteLine(x);
                }
                else if(input[0]=="U")
                {
                    update(Convert.ToInt32(input[1]), Convert.ToInt32(input[2]), Convert.ToInt32(input[3]),ref bucket);
                }

                Q--;
            }


            //hacker rank 6

            SinglyLinkedList llist = new SinglyLinkedList();

            int llistCount = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < llistCount; i++)
            {
                int llistItem = Convert.ToInt32(Console.ReadLine());
                llist.InsertNode(llistItem);
            }

            //insert node at tail
            Console.WriteLine("inserting node 78 at tail");
            SinglyLinkedListNode newListL = insertNodeAtTail(llist.head, 78);
            printLinkedList(newListL);

            //insert at Head
            Console.WriteLine("inserting node 45 at head");
            SinglyLinkedListNode newList = insertNodeAtHead(llist.head, 45);
            printLinkedList(newList);

            //hacker rank 7

            int data = Convert.ToInt32(Console.ReadLine());

            int position = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("inserting ${0} at poistion ${1} ",data,position);
            var llist_head = InsertNodeAtPosition(newList, data, position);
            printLinkedList(llist_head);

            //delete from head
            Console.WriteLine("Deleting from head");
            var list = DeleteFromHead(llist_head);
            printLinkedList(list);


            //delete from tail
            Console.WriteLine("deleting from tail");
            var lists = DeleteFromTail(llist.head);
            printLinkedList(lists);

            Console.Read();
        }

        private static SinglyLinkedListNode DeleteFromTail(SinglyLinkedListNode llist)
        {
            var currentNode=llist;
            SinglyLinkedListNode prevNodeOfCurrentNode = null;
            while (currentNode.next != null)
            {
                prevNodeOfCurrentNode = currentNode;
                currentNode = currentNode.next;
            }
            prevNodeOfCurrentNode.next = null;
            currentNode = null;
            return llist;
        }

        private static SinglyLinkedListNode DeleteFromHead(SinglyLinkedListNode paramHead)
        {

            paramHead = paramHead.next;
            return paramHead;
        }

        private static void printLinkedList(SinglyLinkedListNode head)
        {
            Console.WriteLine("============================");
            Console.WriteLine("Printing Link List Start");
            
            if (head != null)
            {
                var cnode = head;
                while(cnode != null)
                {
                    Console.WriteLine(cnode.data);

                    cnode = cnode.next;
                }
            }

            
            Console.WriteLine("Printing Link List End");
            Console.WriteLine("============================");
            Console.WriteLine();
        }

        public static SinglyLinkedListNode InsertNodeAtPosition(SinglyLinkedListNode llist, int data, int position)
        {
            int count = 1;
            var currentNode = llist;
            while (count  <position-1)
            {
                currentNode = currentNode.next;
                count++;
            }

            var nextNode = currentNode.next;
            SinglyLinkedListNode newNode = new SinglyLinkedListNode(data);
            currentNode.next = newNode;
            newNode.next = nextNode;

            return llist;
        }

        static SinglyLinkedListNode insertNodeAtHead(SinglyLinkedListNode llist, int data)
        {
            if(llist == null)
            {
                llist = new SinglyLinkedListNode(data);
                llist.next = null;
            }
            else
            {
                var newNode = new SinglyLinkedListNode(data);
                newNode.next = llist;
                llist = newNode;
            }

            return llist;

        }

        //public static SinglyLinkedListNode insertNodeAtPosition(SinglyLinkedListNode llist, int data, int position)
        //{
        //    int count = -1;
        //    if(position==0)
        //    {
        //        llist = new SinglyLinkedListNode(data);
        //        llist.next = null;
        //    }
        //    else
        //    {

        //    }
        //}
        private static SinglyLinkedListNode insertNodeAtTail(SinglyLinkedListNode head, int data)
        {
            SinglyLinkedListNode newNode = new SinglyLinkedListNode(data);

            if (head == null)
            {
                head = newNode;
                head.next = null;

            }
            else
            {
                var cnode = head;
                while (cnode.next != null)
                {
                    cnode = cnode.next;
                }
                cnode.next = newNode;
            }

            SinglyLinkedListNode tail = newNode;
            tail.next = null;
            return head;
        }

        private static int countSetBit(int n)
        {
            int count = 0;
            while (n>0)
            {
                count += n & 1;
                n >>= 1;
            }
            return count;
        }
        private static void update(int pos, int M, int plus, ref int[] bucket)
        {
            for (int i = 1; i < 50; i++)
            {
                int back = pos;
                for (int j = 1; j < 1000; j++)
                {
                    bucket[pos] += M;
                    int s;
                    int ins= countSetBit(pos);
                    for (int k = 0;  ; k++)
                    {
                        s = pos + Convert.ToInt32( Math.Pow(2, k));
                        if(countSetBit(s)<=ins)
                        {
                            ins = countSetBit(s);
                            pos = s;
                            if (pos > bucket.Length) break;
                            bucket[pos] += M;
                        }
                    }
                    pos = pos - bucket.Length;
                }
                pos = back + plus;
                if (pos > bucket.Length)
                    pos -= bucket.Length;
            }
        }

        private static List<int> RotateLeftByD(int d, List<int> arr)
        {
            var array = arr.ToArray();
            int lengthOfArray = array.Length;
            var resultArray = new int[lengthOfArray];
            int resIndex = lengthOfArray - d;
            for (int index = 0; index < lengthOfArray && resIndex<lengthOfArray; index++,resIndex++)
            {
                resultArray[resIndex] = arr[index];
            }
            int index1 = d;
            for (int resultIndex = 0; resultIndex < lengthOfArray-d; resultIndex++,index1++)
            {
                resultArray[resultIndex] = arr[index1];
            }
            return resultArray.ToList(); ;
        }

        public static List<int> matchingStrings(List<string> strings, List<string> queries)
        {


            #region O(N^2)
            List<int> result = new List<int>();

            foreach (var query in queries)
            {
                result.Add(strings.FindAll(x => x.Equals(query, StringComparison.CurrentCultureIgnoreCase)).Count);
            }



            #endregion
            return result;
        }
        public static long arrayManipulation(int n, List<List<int>> queries)
        {

            int[] array = new int[n + 1];
            foreach (var query in queries)
            {
                int a = query.ElementAt(0);
                int b = query.ElementAt(1);
                int k = query.ElementAt(2);
                array[a - 1] += k;
                array[b] -= k;
            }
            int x = 0, max = 0;

            for (int index = 0; index < n; index++)
            {
                x += array[index];
                max = x > max ? x : max;
            }
            return max;
        }
    }
}
