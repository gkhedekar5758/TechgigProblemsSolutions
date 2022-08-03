using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TECHGIG_small_tests
{
    public static class BinarySearch
    {
        public static int BinarySearchMethod()
        {
            int[] arr = {1,25,343,4678,556,64,7,2138,7789 };

            int searchElement = 7;

            int left = 0, mid = 0, right = arr.Length-1;
            mid = (left + right) / 2;
            Array.Sort(arr);
            while(arr[mid]!=searchElement)
            {

                if (right ==left+1 ) break;
                if(arr[mid] < searchElement)
                {
                    left = mid;
                    mid=(left+right)/ 2;
                    if (arr[mid] == searchElement) break;
                }
                else if(arr[mid]>searchElement)
                {
                    right = mid;
                    mid = (left + right) / 2;
                    if (arr[mid] == searchElement) break;
                }
            }

            if (arr[mid] == searchElement) return mid;
            else return -1;
        }

        
    }
    public static class MITOPENCOURSE
    {
        public static void method()
        {
            string inp = "cereal";
            downup(inp);
        }

        private static void downup(string inp)
        {
            if (inp.Length == 1)
                Console.WriteLine(inp);
            else
            {
                Console.WriteLine(inp);
                downup(inp.Substring(0,inp.Length - 1));
                Console.WriteLine(inp);
            }

        }
    }

    public static class BinarySearchApplication
    {
        public static void mehtod()
        {
            int[] arr = { 500,100,56, 45, 3, 2, 1 };
            Console.WriteLine( searchMaxNo(arr, arr.Length,0,(0+arr.Length)/2,arr.Length-1));
        }

        private static int searchMaxNo(int[] arr, int length,int l,int m,int r)
        {
            //base cases
            if (length == 1) return arr[0];
            if (length == 2) return arr[0] > arr[1] ? arr[0] : arr[1];

            if(m>l&&m<r)
            {
                if (arr[m] > arr[m-1] && arr[m] > arr[m+1]) return arr[m];

                if (arr[m] < arr[m + 1])
                {
                    l = m;
                    m = (l + r) / 2;
                   return searchMaxNo(arr, arr.Length, l, m, r);
                }
                if (arr[m] > arr[m + 1])
                {
                    r = m;
                    m = (l + r) / 2;
                   return searchMaxNo(arr, arr.Length, l, m, r);
                }
            }
            if (r == l + 1) return arr[l] >= arr[r] ? arr[l] : arr[r];

            return arr[m];

        }

        
    }


    public static class BinarySearchApplication2
    {
        public static void method()
        {
            int[] arr = { 1, 2, 8, 10, 10, 12, 19 };
            int n = arr.Length;
            int x = 3;

            int res = SerachCeil(arr,0, n-1, x);
        }

        private static int SerachCeil(int[] arr, int l,int r, int x)
        {

            if (x <= arr[l]) return l;
            if (x > arr[r]) return -1;

            int m;
            m = (l + r) / 2;

            if (x < arr[m]) return SerachCeil(arr, l, m, x);
            if (x >= arr[m]) return SerachCeil(arr, m, r, x);

            return -1;

        }

    }


    public class Node
    {
        public int data;
        public Node leftChild;
        public Node rightChild;

        public Node(int value)
        {
            data = value;
            leftChild = null;
            rightChild = null;
        }
    }

    public class BinarySearchTree
    {
        Node root;
        public BinarySearchTree()
        {
            root = null;
        }
        //This is the driver method like Main method which will drive the actions
        public void mainMethod(string method,int val= 0)
        {
            
            if(method=="I")  root=insertNodeInTree(root, val);
            
            if (method == "INT")
            {
                Console.WriteLine();
                Console.WriteLine("******* In Order Traversal ************");
                InOrderTraversal(root);
            }
            if (method == "PRE")
            {
                Console.WriteLine();
                Console.WriteLine("******* Pre Order Traversal ************");
                PreOrderTraversal(root);
            }
            if (method == "POST")
            {
                Console.WriteLine();
                Console.WriteLine("******* Post Order Traversal ************");
                PostOrderTraversal(root);
            }

            if(method == "SEARCH")
            {
                Console.WriteLine();
                Node returnedNode;
                returnedNode = SearchNodeInBST(root, val);
                Console.WriteLine(returnedNode.data);
                Console.WriteLine(returnedNode);
            }

            if (method == "DEL")
            {
                Console.WriteLine();
               
                 root=deleteNodeFromBST(root, val);
                
            }
        }

       

        //insert
        private static Node insertNodeInTree(Node root, int value)
        {
            //Node newNode = new Node(value);
            if(root==null)
            {
                root = new Node(value);
            }
            else
            {
                if (value < root.data)
                    root.leftChild = insertNodeInTree(root.leftChild, value);
                else
                    root.rightChild = insertNodeInTree(root.rightChild, value);
            }
            return root;
        }
        //delete
        // we can have 0 child,1 child or 2 children of the node
        // whom we want to delete
        private static Node  deleteNodeFromBST(Node nodeToBeDeleted,int value)
        {
            //Node parentNode;
            //Node currentNode;
            //Node tempNode;
            //if (root == null)
            //{
            //    Console.WriteLine("tree is empty");
            //    return;
            //}

            //parentNode = null;
            //currentNode = root;
            ////search for deletion, we need parent and the node itself here, so by ref
            //searchForDeletion(ref currentNode, ref parentNode, value);

            ////no child case
            //if (currentNode.leftChild == null && currentNode.rightChild == null)
            //{
            //    if (currentNode != root)
            //    {
            //        if (value < parentNode.data)
            //            parentNode.leftChild = null;
            //        else
            //            parentNode.rightChild = null;
            //    }
            //    else
            //        root = null;
            //}
            //else
            //{
            //    Node InOrderPredecssor = searchLargestInLeftSubTree(currentNode);

            //    if (currentNode != root)
            //    {
            //        if (value < parentNode.data)
            //            parentNode.leftChild = InOrderPredecssor;
            //        else
            //            parentNode.rightChild = InOrderPredecssor;
            //    }
            //    else
            //    {
            //        root.data = InOrderPredecssor.data;
            //        InOrderPredecssor = null;
            //    }
            //}
            ////left child case
            //if(currentNode.leftChild !=null)
            //{
            //    if (currentNode != root)
            //        parentNode.leftChild = currentNode.leftChild;
            //    else
            //    {
            //        //root = currentNode.leftChild;
            //        //root.data = currentNode.data;

            //    }


            //}
            ////right child case
            //else if(currentNode.rightChild !=null)
            //{
            //    if(currentNode !=root)
            //    {
            //        parentNode.rightChild = currentNode.rightChild;
            //    }
            //    else
            //    {
            //       // root = currentNode.rightChild;
            //        //root.data = currentNode.data;
            //    }

            //}

            //if the root itself is null then tree is empty
            if (nodeToBeDeleted == null)
                return null;
            if (nodeToBeDeleted.data > value)
                nodeToBeDeleted.leftChild= deleteNodeFromBST(nodeToBeDeleted.leftChild, value);
            else if (nodeToBeDeleted.data < value)
                nodeToBeDeleted.rightChild= deleteNodeFromBST(nodeToBeDeleted.rightChild, value);
            else
            {
                if (nodeToBeDeleted.leftChild == null)
                    return nodeToBeDeleted.rightChild;
                else if (nodeToBeDeleted.rightChild == null)
                    return nodeToBeDeleted.leftChild;
                else
                {
                    nodeToBeDeleted.data = searchLargestInLeftSubTree(nodeToBeDeleted.leftChild).data;
                    nodeToBeDeleted.leftChild = deleteNodeFromBST(nodeToBeDeleted.leftChild, nodeToBeDeleted.data);
                }



            }



            return nodeToBeDeleted;




        }

        private static void searchForDeletion(ref Node currentNode, ref Node parentNode, int value)
        {
            
            if(currentNode.data == value)
            {
                //parentNode = currentNode;
                return;
            }
            else if(currentNode.data < value)
            {
                parentNode = currentNode;
                currentNode = currentNode.rightChild;
                searchForDeletion(ref currentNode,ref parentNode, value);
            }
            else if(currentNode.data > value)
            {
                parentNode = currentNode;
                currentNode = currentNode.leftChild;
                searchForDeletion(ref currentNode,ref parentNode, value);
            }
        }

        private static Node searchLargestInLeftSubTree(Node node)
        {
            
            while(node.rightChild != null)
            {
                node = node.rightChild;
            }
            return node;
        }

        //search
        private static Node SearchNodeInBST(Node currentNode,int value)
        {
            if (currentNode == null) return null;
            if (currentNode.data == value) return currentNode;

            if (value < currentNode.data) return SearchNodeInBST(currentNode.leftChild, value);
            else return SearchNodeInBST(currentNode.rightChild, value);
        }


        private void InOrderTraversal(Node root)
        {
            if (root == null) return; //tree is empty
           if(root.leftChild !=null) InOrderTraversal(root.leftChild);
            
            Console.Write(root.data +" ");
            if (root.rightChild != null) InOrderTraversal(root.rightChild);
        }

        private void PreOrderTraversal(Node root)
        {
            if (root == null) return;
            Console.Write(root.data + " ");
            if (root.leftChild != null) PreOrderTraversal(root.leftChild);
            if (root.rightChild != null) PreOrderTraversal(root.rightChild);
        }

        private void PostOrderTraversal(Node root)
        {
            if (root == null) return;

            if (root.leftChild != null) PreOrderTraversal(root.leftChild);
            if (root.rightChild != null) PreOrderTraversal(root.rightChild);
            Console.Write(root.data + " ");
        }
    }

}
