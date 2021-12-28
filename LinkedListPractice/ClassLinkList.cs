using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListPractice
{
    class ClassLinkList
    {
        private Node HeadNode;

        public void addFirstNode(int data)
        {
            Node newNode = new Node();
            newNode.NextNode = HeadNode;
            newNode.data = data;
            HeadNode = newNode;

        }
        public void printNodes()
        {
            Node currentNode = HeadNode;
            while (currentNode.NextNode != null)
            {
                Console.WriteLine(currentNode.data);
                currentNode = currentNode.NextNode;
            }
        }
        
        public void addNodes(int data)
        {
            if (HeadNode==null)
            {
                HeadNode = new Node();
                HeadNode.data = data;
                HeadNode.NextNode = null;

                
            }
            else
            {
                Node toAdd = new Node();
                toAdd.data = data;
                toAdd.NextNode = null;
                Node currentNode = HeadNode;
                while (currentNode.NextNode!=null)
                {
                    currentNode = currentNode.NextNode;
                    
                }
                currentNode.NextNode = toAdd;
            }
        }


    }
    public class Node
    {
        public Node NextNode;
        public int data;
        //public int PlayerNum;
        //public int countOfBall;
    }


    //class MyLinkList
    //{
    //    private Node FirstHead;

    //    // this is the first node and the 
    //    public MyLinkList()
    //    {
    //        Node newNode = new Node();
    //        newNode.NextNode = FirstHead;
    //        newNode.PlayerNum = 1;
    //        newNode.countOfBall = 1;
    //        FirstHead = newNode;
    //    }
    //}
}
