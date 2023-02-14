using System;

namespace DCLinkedLists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DCLinkedList<int> MyList = new DCLinkedList<int>();

            //creating new nodes to build the linked list 10 20 30 40 50
            GenericNode<int> headNode = new GenericNode<int>(10);
            GenericNode<int> node20 = new GenericNode<int>(20);
            GenericNode<int> node30 = new GenericNode<int>(30);
            GenericNode<int> node40 = new GenericNode<int>(40);
            GenericNode<int> node50 = new GenericNode<int>(50);

            //hooking up the nodes to make it a doubly circular linked list by connecting the previous and next
            //our list is 10 20 30 40 50
            //10 is head node

            //previous for 10 is 50 and next for 10 is 20
            headNode.Prev = node50;
            headNode.Next = node20;

            //previous for 20 is 10 and next for 20 is 30
            node20.Prev = headNode;
            node20.Next = node30;

            //previous for 30 is 20 and next for 30 is 40
            node30.Prev = node20;
            node30.Next = node40;

            //previous for 40 is 30 and next for 40 is 50
            node40.Prev = node30;
            node40.Next = node50;

            //previous for 50 is 40 and next for 50 is 10,
            //here we circled back to 10  that is why it is doubly circular linked list.
            node50.Prev = node40;
            node50.Next = headNode;
            
            // setting the head which hold alll other nodes information
            MyList.Head = headNode;

            Console.WriteLine("Initial List");
            MyList.PrintList();
            Console.WriteLine("---------------------------------------------------\n");

            //Add new node 25 at the front
            MyList.PrintList();
            Console.WriteLine("AddFirst(node25): Expected 25 10 20 30 40 50");
            GenericNode<int> node25 = new GenericNode<int>(25);
            MyList.AddFirst(node25);
            MyList.PrintList();
            Console.WriteLine("---------------------------------------------------\n");

            //Add new node 60 at the end
            MyList.PrintList();
            Console.WriteLine("AddLast(node60): Expected 25 10 20 30 40 50 60");
            GenericNode<int> node60 = new GenericNode<int>(60);
            MyList.AddLast(node60);
            MyList.PrintList();
            Console.WriteLine("---------------------------------------------------\n");

            //Add new node 30 after existing node 20
            MyList.PrintList();
            Console.WriteLine("AddAfter(node20): Expected 25 10 20 30 30 40 50 60");
            GenericNode<int> newNode30 = new GenericNode<int>(30);
            MyList.AddAfter(node20, newNode30);
            MyList.PrintList();
            Console.WriteLine("---------------------------------------------------\n");

            //Add new node 50 before existing node 50
            MyList.PrintList();
            Console.WriteLine("AddBefore(node50): Expected 25 10 20 30 30 40 50 50 60");
            GenericNode<int> newNode50 = new GenericNode<int>(50);
            MyList.AddBefore(node50, newNode50);
            MyList.PrintList();
            Console.WriteLine("---------------------------------------------------\n");

            MyList.PrintList();
            Console.WriteLine("---------------------------------------------------\n");
            MyList.FindFirst(50);
            MyList.FindLast(50);
            Console.WriteLine("---------------------------------------------------\n");
            MyList.FindFirst(150);
            MyList.FindLast(150);
            Console.WriteLine("---------------------------------------------------\n");

            //Remove First node
            MyList.PrintList();
            Console.WriteLine("RemoveFirst: Expected 10 20 30 30 40 50 50 60");
            MyList.RemoveFirst();
            MyList.PrintList();
            Console.WriteLine("---------------------------------------------------\n");

            //Remove last node
            MyList.PrintList();
            Console.WriteLine("Removelast: Expected 10 20 30 30 40 50 50");
            MyList.RemoveLast();
            MyList.PrintList();
            Console.WriteLine("---------------------------------------------------\n");

            MyList.PrintList();
            Console.WriteLine("ToString() = " + MyList.ToString());
            Console.WriteLine("---------------------------------------------------\n");
            MyList.PrintList();
            Console.WriteLine("ToStringReverse() = " + MyList.ToStringReverse());
            Console.WriteLine("---------------------------------------------------\n");

            //Remove Node 40
            MyList.PrintList();
            Console.WriteLine("Remove node40: Expected 10 20 30 30 50 50");
            MyList.Remove(node40);
            MyList.PrintList();
            Console.WriteLine("---------------------------------------------------\n");

            //create new list for merging 11,21,31
            DCLinkedList<int> newList = new DCLinkedList<int>();
            GenericNode<int> newHeadNode = new GenericNode<int>(11);
            GenericNode<int> node21 = new GenericNode<int>(21);
            GenericNode<int> node31 = new GenericNode<int>(31);
            newHeadNode.Prev = node31;
            node21.Prev = newHeadNode;
            node31.Prev = node21;
            newHeadNode.Next = node21;
            node21.Next = node31;
            node31.Next = newHeadNode;

            newList.Head = newHeadNode;

            Console.WriteLine("NewList");
            newList.PrintList();
            Console.WriteLine("---------------------------------------------------\n");
            Console.WriteLine("CurrentList");
            MyList.PrintList();

            Console.WriteLine("Merge New list to CurrentList");
            MyList.Merge(newList);
            MyList.PrintList();

            Console.WriteLine("---------------------------------------------------\n");

            MyList.PrintList();
            Console.WriteLine("RotateRight(2)");
            MyList.RotateRight(2);
            MyList.PrintList();
            Console.WriteLine("---------------------------------------------------\n");

            MyList.PrintList();
            Console.WriteLine("RotateLeft(2)");
            MyList.RotateLeft(2);
            MyList.PrintList();
            Console.WriteLine("---------------------------------------------------\n");

            MyList.PrintList();
            Console.WriteLine("clear");
            MyList.Clear();
            MyList.PrintList();

            Console.ReadKey();
        }
    }
}
