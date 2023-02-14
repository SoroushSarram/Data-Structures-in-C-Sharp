using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataSctructures_SortingAlgorithms.Classes
{
    public class Insertion_Sort : SortPanel
    {
		public Insertion_Sort(Form form, string title, int w, int h) : base(title, w, h)
		{	//intialization
			
			this.Initialize_Array();
			this.myForm = form;
		}
		public override void Run()
        {
			try
			{
				//loop from start of the array to end
				for (int i = 1; i < array.Length; i++)
				{
					//initially red/green point to the element we are going to sort
					greenColumn = i;
					redColumn = greenColumn;
					int k;
					//loop to compare the i th item, which will from the previous element
					for (k = i - 1; k >= 0 && array[k] > array[k + 1]; k--)
					{
						Thread.Sleep(3 * sleepTime);
						//repaint
						myForm.Refresh();
						// move the red column to the next element 
						redColumn = k + 1;
						//repaint
						myForm.Refresh();
						Thread.Sleep(4 * sleepTime);
						//since item at k > k+1, we need to swap and continue this loop until sorting is done
						int tmp = array[k + 1];
						array[k + 1] = array[k];
						array[k] = tmp;
					}
					//move the red bar to next element
					redColumn = k + 1;
					//repaint					
					myForm.Refresh();
				}
				//all are sorted
				redColumn = -1;
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception: "+ e.Message);
			}
			myForm.Refresh();
		}

		
	}
}
