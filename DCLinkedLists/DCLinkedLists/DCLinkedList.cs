using System;

namespace DCLinkedLists
{
    public class DCLinkedList<T>
    {
        private GenericNode<T> head;
        public GenericNode<T> Head { get => head; set => head = value; }

        public DCLinkedList()
        {
            head = null;
        }

        //***Time complexity : best case is O(1).
        //worst case O(n) where n is the number of nodes, the node we are trying to remove is the last node.
        //Add new element at the start of the list
        public void AddFirst(GenericNode<T> newNode)
        {
            //if the head node is null or the list is empty then the new node is head node
            if (head == null)
            {
                head = newNode;
                newNode.Next = head;
                newNode.Prev = head;
            }
            else
            {
                //if the list is not null proceed
                GenericNode<T> temp = head;
                //until one pass is done - find the last node
                while (temp.Next != head)
                    temp = temp.Next;
                //change last node to point to new node
                //adjust prev and last for new node
                // set the new node next
                temp.Next = newNode;
                newNode.Prev = temp;
                newNode.Next = head;
                head.Prev = newNode;
                // make new node as head
                head = newNode;
            }
        }

        //***Time complexity : best case is O(1).
        //worst case O(n) where n is the number of nodes
        //Add new element at the end of the list
        public void AddLast(GenericNode<T> newNode)
        {
            // Check the list is empty or not,
            //  if empty make the new node as head
            if (head == null)
            {
                head = newNode;
                newNode.Next = head;
                newNode.Prev = head;
            }
            else
            {
                // Else, traverse to the last node
                GenericNode<T> temp = head;
                while (temp.Next != head)
                    temp = temp.Next;

                // Adjust the links
                temp.Next = newNode;
                newNode.Next = head;
                newNode.Prev = temp;
                head.Prev = newNode;
            }
        }

        //***Time complexity : best case is O(1).
        public void AddAfter(GenericNode<T> node, GenericNode<T> newNode)
        {
            if (head == null)
            {
                //if there are no nodes then we add to the begining as head node
                AddFirst(newNode);
                return;
            }

            GenericNode<T> temp = node;
            GenericNode<T> next = node.Next;

            // insert new_node between temp and next.
            temp.Next = newNode;
            newNode.Prev = temp;
            newNode.Next = next;
            next.Prev = newNode;
        }

        //***Time complexity : best case is O(1) as we don't have any loops
        public void AddBefore(GenericNode<T> node, GenericNode<T> newNode)
        {
            //when no nodes or only one node
            if (head == null || node == head)
            {
                //if there are no nodes then we add to the begining as head node
                AddFirst(newNode);
                return;
            }

            GenericNode<T> temp = node.Prev;

            // insert new_node between temp and next.
            temp.Next = newNode;
            newNode.Prev = temp;
            newNode.Next = node;
        }

        //***Time complexity : best case is O(1).
        //worst case O(n) where n is the number of nodes
        public void RemoveFirst()
        {
            if (this.head != null)
            {
                // when the list contains one node, delete by making the head null
                if (this.head.Next == this.head)
                {
                    this.head = null;
                }
                else
                {
                    // If the list contains more than one node,
                    // create two nodes - temp and firstNode, both pointing to head node
                    GenericNode<T> temp = this.head;
                    //GenericNode<T> firstNode = this.head;

                    //using temp node, traverse to the last node as 
                    //we need to change the last.Next to the new head.prev after the delete
                    while (temp.Next != this.head)
                    {
                        temp = temp.Next;
                    }

                    //Make head as next of head, and 
                    //update links
                    this.head = this.head.Next;
                    this.head.Prev = temp;
                    temp.Next = this.head;
                }
            }
        }

        //***Time complexity : best case is O(1).
        //worst case O(n) where n is the number of nodes, the node we are trying to remove is the last node.
        public void RemoveLast()
        {
            //if list is not empty
            if (this.head != null)
            {
                if (this.head.Next == this.head)
                {
                    this.head = null;
                }
                else
                {
                    GenericNode<T> temp = this.head;
                    while (temp.Next.Next != this.head)
                        temp = temp.Next;
                    temp.Next = this.head;
                    this.head.prev = temp;
                }
            }
        }

        //***Time complexity :it will be done in some constant time
        public void Remove(GenericNode<T> node)
        {
            //if we are removing the head node then reuse remove first
            if (node == head)
            {
                RemoveFirst();
                return;
            }
            //if we are removing the Last node then reuse remove last
            if (node.Next == head)
            {
                RemoveLast();
                return;
            }

            GenericNode<T> temp = node;
            GenericNode<T> nextNode = node.Next;
            GenericNode<T> previousNode = node.Prev;

            //change the pointer as we removed a node
            previousNode.Next = temp.Next;
            nextNode.Prev = temp.Prev;
        }

        //***Time complexity : O(n) where n is the number of nodes, as we need to traverse the entire listto clear the data.
        public void Clear()
        {
            if (this.head != null)
            {

                // if head is not null create a temp node
                // and current node pointed to next of head
                GenericNode<T> temp;
                GenericNode<T> current = this.head.Next;

                // if current node is not equal to head, delete the
                // current node and move current to next node using temp,
                // repeat the process till the current reaches the head
                while (current != this.head)
                {
                    temp = current.Next;
                    current = temp;
                }

                // Delete the head
                this.head = null;
            }
            Console.WriteLine("All nodes are deleted successfully.");
        }

        //***Time complexity : O(n) where n is the number of nodes, as we need to traverse the entire list to get the data and convert to string output.
        public override string ToString()
        {
            //start from bigining
            GenericNode<T> temp = head;
            string result = string.Empty;
            //start from next element from head
            while (temp.Next != head)
            {
                //add to result
                result = result + temp.Data.ToString() + ' ';
                // move to next node
                temp = temp.Next;
            }
            //don't forget the head node as we started from head.next
            result = result + temp.Data.ToString() + ' ';
            return result;
        }

        //***Time complexity : O(n) where n is the number of nodes, as we need to traverse the entire list to extract the data.
        public string ToStringReverse()
        {
            //to store final result
            string result = string.Empty;
            //since we are doing reversing the list data
            //we start from last
            GenericNode<T> last = head.Prev;
            result = result + last.Data.ToString() + ' ';

            //start from last until one loop is done
            while (last != head)
            {
                //append to string result
                result = result + last.Data.ToString() + ' ';
                //move to previous node as we are starting from back
                last = last.prev;
            }
            //Don't forget to add first element
            result = result + last.Data.ToString() + ' ';
            //return result
            return result;
        }

        //***Time complexity : O(n) where n is the number of nodes, as we need to traverse the entire list to find the last occurance.
        // best case scenarion it is O(1) if we find the element at the head itself.
        public void FindFirst(T searchValue)
        {
            //create a temp node pointing to head
            GenericNode<T> temp = this.head;

            //create two variables: firstOccurance - to track
            //search, idx - to track current index
            int firstOccurance = 0;
            int i = 0;

            //if the temp node is not null check the
            //node value with searchValue, if found 
            //update variables and break the loop, else
            //continue searching till temp node is not head 
            if (temp != null)
            {
                while (true)
                {
                    //we are in next node so increment the index
                    i++;
                    // check if the current node data is matching search Value
                    if (temp.Data.Equals(searchValue))
                    {
                        //Once the first occurance is found, break the loop to stop processing further
                        firstOccurance = i;
                        break;
                    }
                    // change the temp to next node as we did not find the match yet
                    temp = temp.Next;
                    //Only one node found
                    if (temp == this.head) { break; }
                }
                if (firstOccurance > 0)
                {
                    Console.WriteLine("\nFirst Occurance of " + searchValue + " is at index = " + i + ".\n");
                }
                else
                {
                    Console.WriteLine("First Occurance: " + searchValue + " is not found in the list.\n");
                }
            }
            else
            {
                //If the temp node is null at the start, the list is empty
                Console.WriteLine("The list is empty.\n");
            }
        }

        //***Time complexity : O(n) where n is the number of nodes, as we need to traverse the entire list to find the last occurance.
        public void FindLast(T searchValue)
        {
            //create a temp node pointing to head
            GenericNode<T> temp = this.head;

            //create two variables: lastIndex - to track
            //search, idx - to track current index
            int i = 0;
            int lastIndex = 0;

            //if the temp node is not null check the
            //node value with searchValue, if found 
            //update variables andloop until last is found, else
            //continue searching till temp node is not head 
            if (temp != null)
            {
                while (true)
                {
                    //we are in next node so increment the index
                    i++;
                    // check if the current node data is matching search Value
                    if (temp.Data.Equals(searchValue))
                    {
                        // change the index to current node index
                        lastIndex = i;
                    }
                    // change the temp to next node as we did not find the match yet
                    temp = temp.Next;
                    //Only one node found
                    if (temp == this.head) { break; }
                }
                if (lastIndex > 0)
                {
                    Console.WriteLine("Last Occurance of " + searchValue + " is at index = " + lastIndex + ".\n");
                }
                else
                {
                    Console.WriteLine("Last Occurance: " + searchValue + " is not found in the list.\n");
                }
            }
            else
            {
                //If the temp node is null at the start, the list is empty
                Console.WriteLine("The list is empty.\n");
            }
        }

        //***Time complexity : it will be done in some Constant time as we are not going any loops.
        public void Merge(DCLinkedList<T> newList)
        {
            //if currsnt list is null, just make the new list as head
            if (head == null)
            {
                head = newList.head;
                return;
            }

            //if the new list is null do not do anything leave it as is
            if (newList.head == null)
            {
                return;
            }
            //if both the lists are not null proceed
            GenericNode<T> lastNode = head.Prev; //get the last node of current list
            GenericNode<T> newLastNode = newList.head.Prev;// get the last of new list
            newList.head.prev = lastNode;// changes the previous of new list head to point to last of the current list
            head.prev.Next = newList.head;//point the current list last node to point to head of new list
            head.prev = newLastNode;//change the head.previous to new last node from the new list
            newLastNode.Next = head;// point next of last to head
        }

        //***Time complexity : O(n) where in is the number of rotations
        public void RotateRight(int nRotations)
        {
            int noOfRotations = 0;

            //start from 0 and increment noOfRotations until it reaches nRotations
            while (noOfRotations != nRotations)
            {
                //set the head to the previous of head as we are rotating right
                head = head.Prev;
                noOfRotations++;
            }
        }

        //***Time complexity : O(n) where in is the number of rotations
        public void RotateLeft(int nRotations)
        {
            int noOfRotations = 0;

            //start from 0 and increment noOfRotations until it reaches nRotations
            while (noOfRotations != nRotations)
            {
                //set the head to the next of head as we are rotating left
                head = head.Next;
                noOfRotations++;
            }
        }

        //***Time complexity : O(n) where n is the number nodes in the list.
        //display the content of the list
        public void PrintList()
        {
            //get the head
            GenericNode<T> temp = this.head;
            //if list is not null
            if (temp != null)
            {
                Console.Write("The list contains: ");
                //keep looping until there are elements
                while (true)
                {
                    //print the node data
                    Console.Write(temp.Data + " ");
                    //move to the next node
                    temp = temp.Next;
                    //when we finished one round of traversing and reached the starting point - break
                    if (temp == this.head)
                        break;
                }
                Console.WriteLine();
            }
            else
            {
                //if list is empty
                Console.WriteLine("The list is empty.");
            }
        }
    }
}
