using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingVisualizer.Algorithm
{
    public interface ISortingAlgorithm<T> : IGeneralSortingAlgorithm
    {
        //void Sort();

        T[] Data { get; }
        T Largest { get; }
        T Smallest { get; }
    }
}
