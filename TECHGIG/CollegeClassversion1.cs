using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace TECHGIG
{
    class DoublyLinkedList
    {
        public Node HeadNode;
        public DoublyLinkedList()
        {

            Node newnode = new Node();
            newnode.nextNode = HeadNode;
            newnode.PrevNode = null;
            newnode.noOfPlayer = 1;
            newnode.noOfTime = 1;
            HeadNode = newnode;
            HeadNode.nextNode = null;
        }

        public void DoublyLinkedListMethod(int data1,int data2)
        {

            Node NewNodeToAdd = new Node();
            NewNodeToAdd.PrevNode = HeadNode;
            NewNodeToAdd.nextNode = null;
            NewNodeToAdd.noOfPlayer = data1;
            NewNodeToAdd.noOfTime = data2;
            Node currentNode = HeadNode;
            while (currentNode.nextNode != null)
            {
                currentNode = currentNode.nextNode;
            }

            currentNode.nextNode = NewNodeToAdd;

            
            
        }
        public void printListForwad()
        {
            Node currentNode = HeadNode;
            while (currentNode.nextNode!=null)
            {
                Console.WriteLine("Player no :"+currentNode.noOfPlayer);
                Console.WriteLine("Count :"+currentNode.noOfTime);
                currentNode = currentNode.nextNode;
            }
        }

        /// <summary>
        /// sa of now backward is not working
        /// </summary>
        public void printListBackward()
        {
            Node temp = HeadNode;
            while (temp.nextNode != null) { temp = temp.nextNode; }
            Node currentNode = temp;
            while (currentNode.PrevNode!=null)
            {
                Console.WriteLine("Player no :" + currentNode.noOfPlayer);
                Console.WriteLine("Count :" + currentNode.noOfTime);
                currentNode = currentNode.PrevNode;
            } 
        }
    }

    class Node
    {
        public Node nextNode;
        public Node PrevNode;
        public  int noOfPlayer;
        public int noOfTime;
    }
}
