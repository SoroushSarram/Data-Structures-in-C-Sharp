using System;

namespace DataStructure_LinkedList
{
    public class LinkedList<T> : ILinkedList<T>
    {
        private GenericNode<T> head;
        private int count;

        public int Count { get => count; set => count = value; }
        public GenericNode<T> Head { get => head; set => head = value; }

        //*** TODO Time complexity: this operation can be performed constant time 
        public LinkedList()
        {
            head = null;
            count = 0;
        }

        //*** TODO Time complexity:  O(1)
        // We just need to check the head node and make necessary changes. so O(1) 
        public void AddFirst(GenericNode<T> node)
        {
            node.Next = head;
            head = node;
            count++;
        }

        //*** TODO Time complexity:  O(1)
        // We just need to check the head node and make necessary changes. so O(1)
        public GenericNode<T> AddFirst(T data)
        {
            GenericNode<T> node = new GenericNode<T>(data);
            AddFirst(node);
            return node;
        }


        //*** TODO Time complexity:  O(n)
        // We have a while loop to loop through all the nodes until we visit the last node
        public void AddLast(GenericNode<T> node)
        {
            if (head == null)
            {
                AddFirst(node);
                return;
            }
            GenericNode<T> current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = node;
            count++;
        }

        //*** TODO Time complexity:  O(n)
        // We have a while loop to loop through all the nodes until we visit the last node
        public GenericNode<T> AddLast(T data)
        {
            GenericNode<T> node = new GenericNode<T>(data);
            AddLast(node);
            return node;
        }

        //*** TODO Time complexity:  O(n)
        // We have a while loop to loop through all the nodes until we find the previous node.
        //The best case scenario is O(1) and the worst case scenario is O(n) where n is the number of nodes in the list.
        public void AddBefore(GenericNode<T> node, GenericNode<T> newNode)
        {
            bool refNodeFound = false;
            //TODO PART 2 - QUESTION 1 - Implement here the AddBefore method:
            if (head == null)
            {
                //if there are no nodes then we add to the begining as head node
                AddFirst(newNode);
                return;
            }

           GenericNode<T> current = head;
            while (!refNodeFound)
            {
                // find the value of the next node and check if that is equal to what are adding
                // so that we can insert before that
                if (current.Next != null && current.Next.Data.Equals(node.Data))
                {
                    newNode.Next = node;
                    current.Next = newNode;
                    refNodeFound = true;
                }
                else
                {
                    current = current.Next;
                }
            }
            count++;
        }

        //*** TODO Time complexity:  O(n)
        // We have a while loop to loop through all the nodes until we find the previous node.
        //The best case scenario is O(1) and the worst case scenario is O(n) where n is the number of nodes in the list.
        public GenericNode<T> AddBefore(GenericNode<T> node, T data)
        {
            GenericNode<T> newNode = new GenericNode<T>(data);
            AddBefore(node, newNode);
            return newNode;
        }

        //*** TODO Time complexity:  O(n)
        // We have a while loop to loop through all the nodes until we find the right place to insert.
        //The best case scenario is O(1) and the worst case scenario is O(n) where n is the number of nodes in the list.
        public void AddSorted(GenericNode<T> newNode)
        {
            bool sorted = false;
            //TODO PART 2 - QUESTION 2 - Implement here the AddSorted method
            GenericNode<T> current = head;
            while (!sorted)
            {
                if (Convert.ToInt32(newNode.Data.ToString()) < Convert.ToInt32(current.Data.ToString()))
                {
                    AddBefore(current, newNode);
                    sorted = true;
                }
                else
                {
                    current = current.Next;
                }
            }
        }

        //*** TODO Time complexity:  O(n)
        // We have a while loop to loop through all the nodes until we find the right place to insert.
        //The best case scenario is O(1) and the worst case scenario is O(n) where n is the number of nodes in the list.
        public GenericNode<T> AddSorted(T data)
        {
            GenericNode<T> newNode = new GenericNode<T>(data);
            AddSorted(newNode);
            return newNode;
        }

        //*** TODO Time complexity:  O(n)
        // We have a for loop to loop through all the nodes to find the previous node before the node to be deleted.
        //The best case scenario is O(1) and the worst case scenario is O(n) where n is the number of nodes in the list.
        public GenericNode<T> RemoveByIndex(int index)
        {
            //TODO PART 2 - QUESTION 3: Remove the following line and
            //implement the RemoveByIndex method here:

            // If linked list is empty
            if (head == null)
                return null;

            // Store head node
            GenericNode<T> temp = head;

            // If head needs to be removed
            if (index == 0)
            {
                // Change head
                head = temp.Next;
                return head;
            }

            // Find previous node of the node to be deleted
            for (int i = 0; temp != null && i < index - 1;
                 i++)
                temp = temp.Next;

            // If position is more than number of nodes
            if (temp == null || temp.Next == null)
                return null;

            // temp.next is the node to be deleted
            // Store pointer to the next of node to be deleted
            GenericNode<T> next = temp.Next.Next;

            // Unlink the deleted node from list
            temp.Next = next;
            return temp;
        }

        //*** TODO Time complexity:  O(n)
        // We have a while loop to loop through all the nodes until we find the matching node.
        //The best case scenario is O(1) and the worst case scenario is O(n) where n is the number of nodes in the list.
        public GenericNode<T> RemoveByValue(T data)
        {
            //TODO PART 2 - QUESTION 4 - Fix the RemoveByValue method to be able to remove the head.

            GenericNode<T> current = head;
            GenericNode<T> previous = null;

            if (head.Data.Equals(data))
            {
                //if we are removing the head node then change the head.next as head
                head = head.Next;
                return current;
            }

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    // If we try to remove the head then the previous
                    // node will be null and will cause an exception
                    previous.Next = current.Next;
                    count--;
                    return current;
                }
                previous = current;
                current = current.Next;
            }
            return null;
        }

        //*** TODO Time complexity:  O(n)
        // We have a while loop to loop through all the nodes until all the nodes visited.
        public override string ToString()
        {
            var sb = new System.Text.StringBuilder();
            var current = head;
            while (current != null)
            {
                if (sb.Length > 0)
                    sb.Append(", ");
                sb.Append(current.Data);
                current = current.Next;
            }
            return sb.ToString();
        }
    }
}
