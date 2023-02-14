using DataSctructures_SortingAlgorithms.Classes;
using System;
using System.Windows.Forms;

namespace DataSctructures_SortingAlgorithms
{
    public partial class SortForm : Form
    {
        SortPanel sortMethod;

        public SortForm()
        {
            InitializeComponent();
            int Height = this.Height - this.button1.Height;
            //sortMethod = new Insertion_Sort(this, " Insertion Sort", this.Width, Height);
            sortMethod = new Bubble_Sort(this, " Bubble Sort", this.Width, Height);
            //sortMethod = new Selection_Sort(this, " Selection Sort", this.Width, Height);
            //sortMethod = new Quick_Sort(this, " Quick Sort", this.Width, Height);
            this.button1.Text = "     "+ sortMethod.Title;


            //Use Double Buffering
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint |
                          ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //start the timer
            DateTime startTime = DateTime.Now;
            //run the sorting algorithm
            sortMethod.Run();
            //end the timer
            DateTime endTime = DateTime.Now;
            
            //caculate the time took to complete sorting
            double runTimeMinutes = endTime.Subtract(startTime).TotalMinutes;  
            //set the time as the text for the label to display on screen
            this.label_RunTime.Text = Math.Round(runTimeMinutes, 3).ToString() + " Minutes";        
        }

        private void SortForm_Paint(object sender, PaintEventArgs e)
        {
            //this the method called at runtime to draw the bars
            // in the SortForm() method above we are setting sortMethod = new Insertion_Sort(this, " Insertion Sort", this.Width, Height);
            //Insertion_Sort class inherits from sortPanel which has the draw method to draw the bars on the screen at run time
            //same logic for all other sorts
            sortMethod.Draw(e.Graphics);
        }
    }
}
