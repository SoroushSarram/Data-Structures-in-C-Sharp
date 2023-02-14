using System;

namespace DataStructure_LinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // DON'T FORGET TO SET THIS PROJECT (DataStructure_LinkedList) AS STARTUP
            // BEFORE RUNNING IT

            LinkedList<int> myList = new LinkedList<int>();
            var node10 = new GenericNode<int>(10);
            myList.AddLast(node10);
            var node20 = myList.AddLast(20);
            var node30 = myList.AddLast(30);
            var node35 = myList.AddLast(35);
            var node40 = myList.AddLast(40);
            var node50 = myList.AddLast(50);
            var node60 = myList.AddLast(60);

            Console.WriteLine("Original values:");
            Console.WriteLine(myList); //will display: 10, 20, 30, 35, 40, 50, 60

            //PART 2 - QUESTION 1
            Console.WriteLine("\nQUESTION 1 - Implementing the AddBefore method");
            Console.WriteLine("Adding 45 before 50...");
            var node45 = myList.AddBefore(node50, 45);
            Console.WriteLine("Current values:");
            Console.WriteLine(myList);
            Console.WriteLine("Should display:");
            Console.WriteLine("10, 20, 30, 35, 40, 45, 50, 60");

            //PART 2 - QUESTION 2
            Console.WriteLine("\nQUESTION 2 - Implementing the AddSorted method");
            var node25 = myList.AddSorted(25);
            Console.WriteLine("Adding 25 using AddSorted...");
            Console.WriteLine("Current values:");
            Console.WriteLine(myList);
            Console.WriteLine("Should display:");
            Console.WriteLine("10, 20, 25, 30, 35, 40, 45, 50, 60");

            //PART 2 - QUESTION 3:
            Console.WriteLine("\nQUESTION 3 - Implementing the RemoveByIndex method");
            var nodeIndex1 = myList.RemoveByIndex(1);
            Console.WriteLine($"Removing {nodeIndex1.Data} (index 1) ... should display: Removing 20 (index 1)");
            Console.WriteLine("Current values:");
            Console.WriteLine(myList);
            Console.WriteLine("Should display:");
            Console.WriteLine("10, 25, 30, 35, 40, 45, 50, 60");

            //PART 2 - QUESTION 4
            Console.WriteLine("\nQUESTION 4 - Fixing the RemoveByValue method to be able to remove the head");
            Console.WriteLine("Removing value 10...");
            var returnedNode10 = myList.RemoveByValue(10);
            Console.WriteLine("Current values:");
            Console.WriteLine(myList);
            Console.WriteLine("Should display:");
            Console.WriteLine("25, 30, 35, 40, 45, 50, 60");
            Console.Write("node10 and returnedNode10 are the same: ");
            Console.WriteLine($"{returnedNode10 == node10} (should display True)");
            Console.WriteLine("Removing value 60...");
            var returnedNode60 = myList.RemoveByValue(60);
            Console.WriteLine("Current values:");
            Console.WriteLine(myList);
            Console.WriteLine("Should display:");
            Console.WriteLine("25, 30, 35, 40, 45, 50");
            Console.Write("node60 and returnedNode60 are the same: ");
            Console.WriteLine($"{returnedNode60 == node60} (should display True)");

            //PART 2 - QUESTION 5: Provide the time complexity for all asked members in the LinkedList<T> class.

            Console.WriteLine("\n\nPress enter to finish...");
            Console.ReadLine();
        }

    }
}
