using System;
using System.Linq;

namespace CountingLeafs
{
    class Program
    {
        static void Main(string[] args)
        {
            int NumberOfNodes=1;
            int[] ArrayToRepresentTree = new int[NumberOfNodes];
            int NodeToDelete;
            NumberOfNodes = Convert.ToInt16(Console.ReadLine());
            NodeToDelete = Convert.ToInt16(Console.ReadLine());
            string temp = Console.ReadLine(); //here we are assuming that the user is smart enough to enter the data with space
           ArrayToRepresentTree = temp.Split(' ').Select(str => int.Parse(str)).ToArray();
            // ArrayToRepresentTree =temps
            CountTheTreeNodesLeft(NumberOfNodes, ArrayToRepresentTree, NodeToDelete);

        }

        private static void CountTheTreeNodesLeft(int numberOfNodes, int[] arrayToRepresentTree, int nodeToDelete)
        {
            throw new NotImplementedException();
        }
    }
}
