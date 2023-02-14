using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataSctructures_SortingAlgorithms.Classes
{
    public class Quick_Sort : SortPanel
    {
        public Quick_Sort(Form form, string title, int w, int h) : base(title, w, h)
        {
            this.Initialize_Array();
            this.myForm = form;
        }
        //TODO for Final Project 2 (Final Evaluation)
        //Time Complexity is  O(nlogn) in average cases
        //Worst case it is O(n2)
        public override void Run()
        {
            quicksort(array, 0, array.Length - 1);
            //set the last item as sorted
            greenColumn = array.Length - 1;
            //since array is sorted set to some non existing element
            redColumn = -1;
            myForm.Refresh();
        }

        // function for quick sort which calls partition function 
        // to arrange and split the list based on pivot element
        // quicksort is a recursive function
        private void quicksort(int[] Array, int left, int right)
        {
            // do it only if unsorted
            if (left < right)
            {
                //find the pivot everytime
                int pivot = partition(Array, left, right);
                //recursively calling the sort to compare the pivot and left
                quicksort(Array, left, pivot - 1);
                //the pivot is sorted
                greenColumn = pivot;
                myForm.Refresh();
                //recursively calling the sort to compare the pivot and right
                quicksort(Array, pivot + 1, right);
                //the pivot is sorted
                greenColumn = pivot;
                myForm.Refresh();
            }
        }

        // partition function arrange and split the list 
        // into two list based on pivot element
        // the last element of list is chosen 
        // as pivot element. (Left)one list contains all elements 
        // less than the pivot element another list(Right) contains 
        // all elements greater than the pivot element
        private int partition(int[] Array, int left, int right)
        {
            int i = left;
            int pivot = Array[right];
            int temp;

            for (int j = left; j <= right; j++)
            {
                //check if the element is less than the pivot
                if (Array[j] < pivot)
                {
                    //if less than pivot swap the element 
                    temp = Array[i];
                    Array[i] = Array[j];
                    Array[j] = temp;
                    i++;
                }
            }

            //Perform the swapping 
            temp = Array[right];
            Array[right] = Array[i];
            Array[i] = temp;
            redColumn = right;
            myForm.Refresh();
            System.Threading.Thread.Sleep(sleepTime * 4);
            return i;
        }
    }
}
