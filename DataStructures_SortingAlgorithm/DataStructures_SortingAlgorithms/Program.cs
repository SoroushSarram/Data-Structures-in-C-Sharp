using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataSctructures_SortingAlgorithms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //standard stuff
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //create new form
            Application.Run(new SortForm());
        }
    }
}
