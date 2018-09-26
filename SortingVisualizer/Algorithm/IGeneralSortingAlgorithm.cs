using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingVisualizer.Algorithm
{
    public interface IGeneralSortingAlgorithm
    {
        void Sort(int sleep);

        int[] GetCurrentIndices();

        event EventHandler SortingFinished;
    }
}
