﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TECHGIG
{
    class PassingTheBall
    {
        public Int32 Passit(int a ,int b,int c)
        {
        //int NoOfPlayers;
        //int MaxNoOfBall;
        //int NoOfPass;

           int[] player = new int[a];
            int terminatCount;
            player[1] = 1;
            increaseCount(player[1],player);


        return -1;
        }

        public void increaseCount(int plyr,int[] pl)
        {
            if (plyr/2==0)
            {
                pl[plyr + 2] = 1;
            }
            else
            {

            }
        }
    }

    // THIS IS LINKES LIST
    public class List
    {

        public class Node
        {
            public object NodeContent;
            public Node Next;
        }

        private int size;
        public int Count
        {
            get
            {
                return size;
            }
        }

        /// <summary>
        /// The head of the list.
        /// </summary>
        private Node head;

        /// <summary>
        /// The current node, used to avoid adding nodes before the head
        /// </summary>
        private Node current;

        public List()
        {
            size = 0;
            head = null;
        }


        /// <summary>
        /// Add a new Node to the list.
        /// </summary>
        public void Add(object content)
        {
            size++;

            // This is a more verbose implementation to avoid adding nodes to the head of the list
            var node = new Node()
            {
                NodeContent = content
            };

            if (head == null)
            {
                // This is the first node. Make it the head
                head = node;
            }
            else
            {
                // This is not the head. Make it current's next node.
                current.Next = node;
            }

            // Makes newly added node the current node
            current = node;


            // This implementation is simpler but adds nodes in reverse order. It adds nodes to the head of the list

            //head = new Node()
            //{
            //    Next = head,
            //    NodeContent = content
            //};

        }

        /// <summary>
        ///  Throwing this in to help test the list
        /// </summary>
        public void ListNodes()
        {
            Node tempNode = head;

            while (tempNode != null)
            {
                Console.WriteLine(tempNode.NodeContent);
                tempNode = tempNode.Next;
            }
        }



        /// <summary>
        /// Returns the Node in the specified position or null if inexistent
        /// </summary>
        /// <param name="Position">One based position of the node to retrieve</param>
        /// <returns>The desired node or null if inexistent</returns>
        public Node Retrieve(int Position)
        {
            Node tempNode = head;
            Node retNode = null;
            int count = 0;

            while (tempNode != null)
            {
                if (count == Position - 1)
                {
                    retNode = tempNode;
                    break;
                }
                count++;
                tempNode = tempNode.Next;
            }

            return retNode;
        }

        /// <summary>
        /// Delete a Node in the specified position
        /// </summary>
        /// <param name="Position">Position of node to be deleted</param>
        /// <returns>Successful</returns>
        public bool Delete(int Position)
        {
            if (Position == 1)
            {
                head = null;
                current = null;
                return true;
            }

            if (Position > 1 && Position <= size)
            {
                Node tempNode = head;

                Node lastNode = null;
                int count = 0;

                while (tempNode != null)
                {
                    if (count == Position - 1)
                    {
                        lastNode.Next = tempNode.Next;
                        return true;
                    }
                    count++;

                    lastNode = tempNode;
                    tempNode = tempNode.Next;
                }
            }

            return false;
        }
    }
}
