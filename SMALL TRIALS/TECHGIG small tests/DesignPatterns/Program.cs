using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    class Program
    {
        static int longestSubSeg(int[] a, int n,
                                      int k)
        {

   
            int cnt0 = 0;
            int l = 0;
            int max_len = 0;

            // i decides current ending point
            for (int i = 0; i < n; i++)
            {
                if (a[i] == 0)
                    cnt0++;

                // If there are more 0's move
                // left point for current ending
                // point.
                while (cnt0 > k)
                {
                    if (a[l] == 0)
                        cnt0--;
                    l++;
                }

                max_len = Math.Max(max_len, i - l + 1);
            }

            return max_len;
        }
        
        static void Main(string[] args)
        {
            

            int[] a = { 1, 0, 0, 1, 0, 1, 0, 1 };
            int k = 1;
            int n = a.Length;
            Console.WriteLine(longestSubSeg(a, n, k));

            Console.Read();




            #region AbstractFactoryPatternCodeDemo
            
            var factory = AnimalFactoryCreator.createAnimalFactory("wild");
            IDog dog = factory.GetDog();
            dog.aboutMe();
            dog.bark();

            var factory2 = AnimalFactoryCreator.createAnimalFactory("pet");
            IDog dog2 = factory.GetDog();
            dog2.aboutMe();dog2.bark();
            
            Console.Read();
            #endregion
            LinkedList myList = new LinkedList();
            myList.addLast(10);
            myList.addLast(20);
            myList.addFirst(5);
            myList.addFirst(30);
            //myList.deleteFirst();
            //myList.deleteFirst();
            myList.deleteLast();
            Console.WriteLine(myList.indexOf(50));
            Console.WriteLine(myList.contains(1).ToString());
            Console.WriteLine(myList.ToString());

            Console.Read();
        }
    }
    public class Node
    {
      public  int value;
       public Node link;
        public Node(int val)
        {
            this.value = val;
        }
    }

    public class LinkedList
    {
        Node first;
        Node last;
        //public LinkedList()
        //{
        //    first = new Node();
        //    last = first;
        //    //initially both are at same
        //    //last.link = null;
        //    //first = last;
        //}

        //addFirst
        public void addFirst(int value)
        {
            var node = new Node(value);
            ////if nothing is at first
            if (last == null && last == null)
                first = last = node;
            else
            {
                node.link = first;
                first = node;
            }

            //if something is at first
        }
        //addLast
        public void addLast(int value)
        {
            var node = new Node(value);
            ////if nothing is at first
            if (first == null)
                first = last = node;
            else
            {
                last.link = node;
                last = node;
            }

            //if something is at first
        }
        //deleteFirst
        public void deleteFirst()
        {
            if (first == last)
                first = last = null;
            else
            {
                var node = first.link;
                first.link = null;
                first = node;
            }

        }
        //deleteLast
        public void deleteLast()
        {
            if (first == last)
            {
                first = last = null;
            }
            else
            {
                var currentNode = first;
                while(currentNode !=null)
                {
                    if(currentNode.link==last)
                    {
                        last = currentNode;
                        last.link = null;
                    }
                    currentNode = currentNode.link;
                }
                   
            }
        }
        //contains
        public bool contains(int item)
        {
            var current = first;
            while(current !=null)
            {
                if (current.value == item)
                    return true;

                current = current.link;
            }
            return false;
        }
        //indexOf
        public int  indexOf(int item)
        {
            int index=0;
            var currentNode = first;
             while(currentNode != null)
             {
                if (currentNode.value == item)
                    return index;

                currentNode = currentNode.link;
                index++;
             }
            return -1;
                
        }
    }
    public interface IAnimal
    {
        void aboutMe();
    }
    public interface IDog:IAnimal
    {
        void bark();
    }
    public interface ITiger:IAnimal
    {
        void growl();
    }

    public class WildTiger : ITiger
    {
        public void aboutMe()
        {
            Console.WriteLine("I am a wild Tiger");
        }

        public void growl()
        {
            Console.WriteLine("I growl like real tiger");
        }
    }
    public class PetTiger : ITiger
    {
        public void aboutMe()
        {
            Console.WriteLine("I am a pet Tiger");
        }

        public void growl()
        {
            Console.WriteLine("I almost never growl like real tiger");
        }
    }

    public class WildDog : IDog
    {
        public void aboutMe()
        {
            Console.WriteLine("I am a wild Dog");
        }

        public void bark()
        {
            Console.WriteLine("I bark like a wild Dog");
        }

    }
    public class PetDog : IDog
    {
        public void aboutMe()
        {
            Console.WriteLine("I am a pet Dog");
        }

        public void bark()
        {
            Console.WriteLine("I wimp like a pet Dog");
        }
    }

    public interface IBear
    {

    }
    public interface IAbstractAnimalFactory
    {
        //IBear GetBear();  -- this will break the concrete factories
        ITiger getTiger();
        IDog GetDog();
    }

    public class WildAnimalFactory : IAbstractAnimalFactory
    {
        public IDog GetDog()
        {
            return new WildDog();
        }

        public ITiger getTiger()
        {
            return new WildTiger();
        }
    }

    public class PetAnimalFactory : IAbstractAnimalFactory
    {
        public IDog GetDog()
        {
            return new PetDog();
        }

        public ITiger getTiger()
        {
            return new PetTiger();
        }
    }

    public static class AnimalFactoryCreator
    {
        public static IAbstractAnimalFactory createAnimalFactory(string type)
        {
            if(type.Contains("wild"))
            {
                return new WildAnimalFactory();
            }
            else if(type.Contains("pet"))
            {
                return new PetAnimalFactory();
            }
            else
            {
                throw new NotImplementedException("Not impletement yet");
            }
        }
    }


}
