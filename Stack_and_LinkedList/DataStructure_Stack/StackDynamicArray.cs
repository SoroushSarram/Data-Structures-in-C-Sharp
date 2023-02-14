using System;

namespace DataStructure_Stack
{
    //PART 1 - QUESTION 1
    //Create a StackDynamicArray<T> class that inherits from Stack<T>
    public class StackDynamicArray<T> : StackArray<T>
    {
        //PART 1 - QUESTION 1
        //Create a StackDynamicArray<T> class that inherits from Stack<T>
        public StackDynamicArray()
            : base(2)
        {
        }

        //PART 1 - QUESTION 2
        //In the StackDynamicArray<T> class, call the base constructor StackArray(int)
        //and pass the value 2. When we call the method we will pass 2

        //*** Time complexity: The Push method adds one element into the stack at a time which is O(1)
        // but it will also have to double size of the array when it is full.
        // So the resize will have to create new array with new size and copy the elements.
        // consider there are N elements in the array,the time complexity of it is O(N)
        // where N is number of elements in the array. When N=1, time complexity is O(1), When N=2, time complexity is O(2)
        // When N=N, time complexity is O(N).
        // Finally, the best in the case scenario, the time complexity is O(1) and in the worst case it is O(N)
        public override void Push(T item)
        {
            if(item == null)
                throw new ArgumentNullException("item");

            int index = count;
            if (count == array.Length)
            {
                //double the array when array is full
                Array.Resize(ref array, count * 2);
            }

            array[index] = item;
            count++;
        }
    }
}
