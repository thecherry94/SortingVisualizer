using SortingVisualizer.Algorithm.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SortingVisualizer.Algorithm
{
    public class BubbleSort<T> : ISortingAlgorithm<T>
    {
        private static readonly Type[] _accepted_types = new Type[] { typeof(int), typeof(float), typeof(string), };

        private T[] _data;
        private T _largest;
        private T _smallest;

        int _current_index = -1;

        public BubbleSort(T[] data, T largest, T smallest)
        {
            if (!_accepted_types.Contains(typeof(T)))
                throw new InvalidGenericTypeException(typeof(T), _accepted_types);

            _data = data;
            _largest = largest;
            _smallest = smallest;
        }

        public T[] Data
        {
            get { return _data; }
        }

        public T Largest
        {
            get { return _largest; }
        }

        public T Smallest
        {
            get { return _smallest; }
        }

        public event EventHandler SortingFinished;

        public int[] GetCurrentIndices()
        {
            return new int[] { _current_index };
        }

        public void Sort(int sleep)
        {
            Comparer<T> cmp = Comparer<T>.Default;

            int i_tail = _data.Length - 1;
            int i = 0;

            while(i_tail > 1)
            {
                if (cmp.Compare(_data[i], _data[i+1]) > 0)
                    swap(i, i + 1);
              
                if (i == i_tail - 1)
                {
                    i_tail--;
                    i = 0;
                }

                _current_index = i;

                if(sleep > 0)
                    Thread.Sleep(sleep);

                i++;
            }

            SortingFinished(this, null);
        }

        private void swap(int i_a, int i_b)
        {
            T ph = _data[i_a];
            _data[i_a] = _data[i_b];
            _data[i_b] = ph;
        }
    }
}
