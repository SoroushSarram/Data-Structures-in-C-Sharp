using System;

namespace DataStructure_Stack
{
    public class StackArray<T> : IStack<T>
    {
        protected T[] array;
        protected int count;

        //PART 1 - QUESTION 4: Provide the time complexity for all asked members in the Stack<T> class.

        //*** Time complexity: this method takes the size of the array and intializes an array with the size provided.
        // since is not doing any other iterations in the method, the time complexity of it is O(1)
        public StackArray(int size)
        {
            array = new T[size];
            count = 0;
        }

        //*** Time complexity: Best care scenario O(1) and the worst case is O(n) where n is the count of elements in the stack.
        // since we are loop through all the elements in the stack and we have to enter the loop at least once the best case is O(1)
        // and if have elements in the stack we have to loop through all of them, the worst case is O(n).
        public void Clear()
        {
            for (int i = 0; i < count; i++)
            {
                array[i] = default(T);
            }
            count = 0;
        }

        //*** Time complexity: Best care scenario O(1) and the worst case is O(n) where n is the count of elements in the stack.
        // since we are loop through all the elements in the stack and we have to enter the loop at least once.
        // if we find the element in the fisrt pass itself then the best case is O(1)
        // and in the worst case we have to loop through all find the element then the worst case is O(n).
        public bool Contains(T item)
        {
            for (int i = 0; i < count; i++)
            {
                if (array[i].Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        //*** Time complexity: since we are just returning the value stored, it can be achieved in some Constant time.
        public int Count()
        {
            return count;
        }

        //*** Time complexity: Worst Case Scenario would be O(n) in case of a array implementation of stack
        // where the array is completely filled, then the array size needs to be changed
        // and all the elements must be copied from one array to another, this would result in time being O(n)
        public virtual void Push(T item)
        {
            if (count == array.Length)
                throw new IndexOutOfRangeException();
            array[count] = item;
            count++;
        }

        //*** Time complexity: O(1) as we peek only one element in the stack at a given time
        public T Peek()
        {
            if (count == 0)
                throw new
                InvalidOperationException("Stack empty");

            int last_index = count - 1;
            return array[last_index];
        }

        //*** Time complexity:
        //Worst Case Scenario is O(1) , as Deletion operation only removes the top element.
        //Best Case Scenario is O(1).
        // Average Case Scenario would be O(1) as only the top element is needed to be removed.
        public T Pop()
        {
            if (count == 0)
                throw new
                InvalidOperationException("Stack empty");

            int last_index = count - 1;
            T item = array[last_index];
            array[last_index] = default(T);
            count--;
            return item;
        }
    }
}
