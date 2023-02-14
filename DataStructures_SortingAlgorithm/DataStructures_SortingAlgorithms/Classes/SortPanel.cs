using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace DataSctructures_SortingAlgorithms.Classes
{
    public abstract class SortPanel
    {
		protected Form myForm;
		public static int size = 30;
		protected int sleepTime = 10;
		protected int redColumn = -1; //where red starts. -1 means before first element.
		protected int greenColumn = -1; //where green starts. -1 means before first element.
		private   int BORDER_WIDTH = 10;
		protected int[] array;
		protected int Width;
		protected int Height;
		public string Title;

		protected SortPanel(string title, int width, int height)
		{
			//Constuctor and set the width, height and title of the 
			// panel we create
			Width = width;
			Height = height;
			Title = title;
		}
		
		//run the method set in the sortmethod in the sortForm initialization
		public abstract void Run();

		public void Initialize_Array()
		{
			//this code generate some random unsorted array
			//which is used as input for sorting
			this.array = new int[size];//create the are with sixe specified at the top = 30

			//loop from 0 to array length
			for (int i = 0; i < array.Length; i++)
			{
				//add elements to array
				array[i] = i + 1;
			}
			for (int i = 0; i < array.Length; i++)
			{
				//randomize the array so that they are unsorted
				int index = (int)(RandomGenerator.Get_Instance().NextDouble() * array.Length);
				int temp = array[i];
				array[i] = array[index];
				array[index] = temp;
			}
		}
		public void Reset()
		{
			//ths will make sure no bar is filled with red or green 
			redColumn = -1;
			greenColumn = -1;
		}
		public void Draw(Graphics G)
        {
			// all sorted items are green
			// item we are currently sorting is red
			// rest all are white

			//resposible for making the rest of the bars white/no fill
			for (int i = (greenColumn == -1 ? 0 : greenColumn); i < array.Length; i++)
			{
				//this will make sure that items are white 
				DrawColumn(G, Color.White, i);
			}
			//fills all sorted items with green
			for (int i = 0; i <= greenColumn; i++)
			{
				DrawColumn(G, Color.Green, i);
			}
			//fill the item maked red coulmn with red
			if (redColumn != -1)
			{
				DrawColumn(G, Color.Red, redColumn);
			}
		}
		public void DrawColumn(Graphics G, Color backColor, int index)
		{
			// this code dras the bars on the screen with appropriate width and heigh
			int columnWidth = (Width - 4 * BORDER_WIDTH) / size;
			int columnHeight = (Height - 4 * BORDER_WIDTH) / size;
			int x = 2 * BORDER_WIDTH + columnWidth * index;
			int y = Height - array[index] * columnHeight - 2 * BORDER_WIDTH;
			int w = columnWidth;
			int h = array[index] * columnHeight;
			Rectangle rectangle = new Rectangle(x, y, w, h);
			Brush brush = new SolidBrush(backColor);
			G.FillRectangle(brush, rectangle);
			Pen pen = new Pen(Color.Black, 2);
			G.DrawRectangle(pen, rectangle);
		}
    }
}
