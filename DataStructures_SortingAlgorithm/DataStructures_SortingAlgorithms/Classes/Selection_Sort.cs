using System.Windows.Forms;

namespace DataSctructures_SortingAlgorithms.Classes
{
    class Selection_Sort : SortPanel
    {
        public Selection_Sort(Form form, string title, int w, int h) : base(title, w, h)
        {
            this.Initialize_Array();
            this.myForm = form;
        }
        //TODO for Final Project 2 (Final Evaluation)
        // The time complexity of selection sort is Θ(N²) in all cases even if the whole array is sorted because
        // the entire array need to be iterated for every element and it contains two nested loops.
        public override void Run()
        {
            int n = array.Length;
            int temp;
            //from 0 to array length
            for (int i = 0; i < n; i++)
            {
                //assume current is minimum
                int min_idx = i;
                //and that min is sorted
                greenColumn = i;
                //will mark it as unsorted
                redColumn = greenColumn;
                //fro the next element to the end of the array
                // compare if there are any other elements lesser than this minimum
                for (int j = i + 1; j < n; j++)
                {
                    if (array[j] < array[min_idx])
                    {
                        //change the red to next element in the array
                        redColumn = j;
                        System.Threading.Thread.Sleep(sleepTime * 4);
                        myForm.Refresh();
                        //and set next element is the minimum element
                        //and the for loop will continue until the end
                        min_idx = j;
                    }
                }
                //so we found the index of the min element in the loop above 
                //now swap it to the right place in the array and continue the loop
                temp = array[min_idx];
                array[min_idx] = array[i];
                array[i] = temp;
                myForm.Refresh();
            }
            //no more unsorted elements
            redColumn = -1;
            myForm.Refresh();
        }
    }
}
