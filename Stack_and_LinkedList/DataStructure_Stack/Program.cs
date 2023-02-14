using System;
using System.Linq;

namespace DataStructure_Stack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // DON'T FORGET TO SET THIS PROJECT (DataStructure_Stack) AS STARTUP
            // BEFORE RUNNING IT


            /* PART 1 - QUESTION 1
             * Create a StackDynamicArray<T> class that inherits from Stack<T>
             *   
             * PART 1 - QUESTION 2
             * In the StackDynamicArray<T> class, call the base constructor StackArray(int)
             * and pass the value 2.
             * 
             * PART 1 - QUESTION 3
             * In the StackDynamicArray<T> class, override the Push method so that
             * whenever you try to push an element and the internal array is full,
             * double it in the same way as done in GenericArrayExample.
             * Provide the time complexity for this override Push method. 
             * 
             * PART 1 - QUESTION 4
             * Provide the time complexity for all asked members in the Stack<T> class.
             * 
             * TEST THE APPLICATION
             * Uncomment the following code once your StackDynamicArray<T> class is done.
             * Run the application and add the following elements: A, B, C, D.
             * The output should be: DELTA, CHARLIE, BRAVO, ALPHA */

            // UNCOMMENT the following code once you StackDynamicArray<T> class is done:
            
            
            var myStack = new StackDynamicArray<string>();
            myStack.Push("ALPHA");
            myStack.Push("BRAVO");
            myStack.Push("CHARLIE");
            myStack.Push("DELTA");

            Console.WriteLine("These are your elements:");
            while (myStack.Count() > 0)
            {
                Console.Write(myStack.Pop());
                if (myStack.Count() > 0)
                    Console.Write(", ");
            }

            Console.WriteLine("\n\nPress enter to finish...");
            Console.ReadLine();
        }
    }
}
