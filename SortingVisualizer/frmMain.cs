using SortingVisualizer.Algorithm;
using SortingVisualizer.Visual;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SortingVisualizer
{
    public partial class frmMain : Form
    {
        private SortingVisualization _visual;

        public frmMain()
        {
            InitializeComponent();

            int[] set;
            int largest = 0;
            int smallest = 0;

            set = generate_random_set(1, 500, 500, out largest, out smallest);
            
            IGeneralSortingAlgorithm sort = new MergeSort<int>(set, largest, smallest);
            IVisualizer vis = new BarVisualizer<int>(ref pcbCanvas, ref sort);

            _visual = new SortingVisualization(sort, vis, 4, 30);
        }

        private void pcbCanvas_Click(object sender, EventArgs e)
        {
            _visual.Run();
        }

        public static int[] generate_random_set(int min, int max, int amount, out int largest, out int smallest)
        {
            int[] retval = new int[amount];
            Random rng = new Random();

            largest = smallest = 0;

            for (int i = 0; i < amount; i++)
            {
                int num = rng.Next(min, max);
                retval[i] = num;

                if (num > largest)
                    largest = num;
                else if (num < smallest)
                    smallest = num;

            }


            return retval;
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
