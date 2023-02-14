using System;
using System.Windows.Forms;

namespace DataSctructures_SortingAlgorithms.Classes
{
    class Bubble_Sort : SortPanel
    {
        public Bubble_Sort(Form form, string title, int w, int h) : base(title, w, h)
        {
            this.Initialize_Array();
            this.myForm = form;
        }
        //TODO for Final Project 2 (Final Evaluation)
        //***Time Complexitiy: Θ(N²) in all cases even if the whole array is sorted because
        //the entire array need to be iterated for every element and it contains two nested loops.
        public override void Run()
        {
            try
            {
                int n = array.Length;
                int temp;
                //from the start of the array to end
                //Time Complexity O(n)
                for (int i = 0; i < n; i++)
                {
                    //red column is i as it is unsorted and the item we are working on
                    redColumn = i;
                    //another loop to go from the beginning of the array until the unsorted item
                    //Time Complexity O(n)
                    for (int j = 0; j < n - i - 1; j++)
                    {
                        //set the unsorted item to next as we are sorting the current element
                        redColumn = j + 1;
                        myForm.Refresh();
                        //if the current element is greater than the next then proceed to swap
                        if (array[j] > array[j + 1])
                        {
                            //take current element into a temp variable
                            temp = array[j];
                            //set the current element as next element as current is greater than next
                            array[j] = array[j + 1];
                            //set the next to the element we are dealing with
                            array[j + 1] = temp;
                        }
                    }
                    //once one pass of an element is done we have sorted that element so set to green
                    greenColumn = i;
                    //refresh the form to update
                    myForm.Refresh();
                }
                //sorting has completed and no item is left so set to some non existent item
                redColumn = -1;
                myForm.Refresh();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            myForm.Refresh();
        }
    }
}
