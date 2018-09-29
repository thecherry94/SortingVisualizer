using SortingVisualizer.Algorithm.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SortingVisualizer.Algorithm
{
    public class MergeSort<T> : ISortingAlgorithm<T>
    {
        private static readonly Type[] _accepted_types = new Type[] { typeof(int), typeof(float), typeof(string) };
        private Comparer<T> _cmp = Comparer<T>.Default;

        private T[] _data;
        private T _largest;
        private T _smallest;

        int[] _current_indeces = new int[6];
        int _sleep = 0;

        public MergeSort(T[] data, T largest, T smallest)
        {
            if (!_accepted_types.Contains(typeof(T)))
                throw new InvalidGenericTypeException(typeof(T), _accepted_types);

            _data = data;
            _largest = largest;
            _smallest = smallest;
        }

        /*
        private void merge_sort_iterative()
        {
            int low = 0;
            int high = _data.Length - 1;

            T[] temp = new T[_data.Length];

            for (int m = 1; m <= high - low; m *= 2)
            {
                for (int i = low; i < high; i += 2 * m)
                {
                    int from = i;
                    int mid = i + m - 1;
                    int to = Math.Min(i + 2 * m - 1, high);

                    merge_iterative(temp, from, mid, to);
                }
            }
        }

        private void merge_iterative(T[] temp, int from, int mid, int to)
        {
            int k = from;
            int i = from;
            int j = mid + 1;

            _current_indeces[0] = from;
            _current_indeces[1] = to;

            Comparer<T> cmp = Comparer<T>.Default;
            

            while (i <= mid && j <= to)
            {
                if (cmp.Compare(_data[i], _data[j]) < 0)
                    temp[k++] = _data[i++];
                else
                    temp[k++] = _data[j++];
                

                _current_indeces[2] = i;
                Thread.Sleep(_sleep);
            }

            while(i < _data.Length && i <= mid)
                temp[k++] = _data[i++];
            
            for(i = from; i <= to; i++)
            {
                _data[i] = temp[i];
                _current_indeces[2] = i;

                if (_sleep > 0)
                  Thread.Sleep(_sleep/4);
            }
        }
        */

        /*
        private T[] merge_sort_recursive(T[] list)
        {
            if (list.Length <= 1)
                return list;

            // Correcting number if source list can not be split equally
            int c = 0;
            if (list.Length % 2 != 0)
                c = 1;

            T[] left = new T[list.Length / 2];
            T[] right = new T[list.Length / 2 + c];

            Array.Copy(list, 0, left, 0, list.Length / 2);
            Array.Copy(list, list.Length / 2, right, 0, list.Length / 2 + c);

            T[] new_left = merge_sort_recursive(left);
            T[] new_right = merge_sort_recursive(right);

            return merge(new_left, new_right);
        }
        */

        public void merge_sort_iterative()
        {
            Comparer<T> cmp = Comparer<T>.Default;

            for (int i = 1; i <= _data.Length / 2 + 1; i *= 2)
            {
                for (int j = i; j < _data.Length + 1; j += 2 * i)
                {
                    merge_iterative(j - i, j, Math.Min(j + i, _data.Length), cmp);
                }
            }

            //merge_iterative(0, 2 * _data.Length / 3 - 1, _data.Length, cmp);
            _current_indeces = new int[6];
        }

        private void merge_iterative(int start, int middle, int end, Comparer<T> comparer)
        {
            _current_indeces[0] = start;
            _current_indeces[1] = end;

            T[] merge = new T[end - start];
            int l = 0, r = 0, i = 0;
            while (l < middle - start && r < end - middle)
            {
                if (comparer.Compare(_data[start + l], _data[middle + r]) < 0)
                {
                    merge[i++] = _data[start + l++];
                }
                else
                { 
                    merge[i++] = _data[middle + r++];
                }

                
                _current_indeces[3] = start + l;
                _current_indeces[4] = middle + r;

                if (_sleep > 0)
                    Thread.Sleep(_sleep);
            }

            while (r < end - middle)
            {
                merge[i++] = _data[middle + r++];
                _current_indeces[2] = middle + r;

                if (_sleep > 0)
                    Thread.Sleep(_sleep/2);
            }

            while (l < middle - start)
            {
                merge[i++] = _data[start + l++];
                _current_indeces[2] = start + l;

                if (_sleep > 0)
                    Thread.Sleep(_sleep/2);
            }

            for (i = 0; i < merge.Length; i++)
            {
                _data[start + i] = merge[i];
                _current_indeces[2] = start + i;

                if (_sleep > 0)
                    Thread.Sleep(_sleep/2);
            }

            //Array.Copy(merge, 0, _data, start, merge.Length);
        }

        private T[] merge(T[] left, T[] right)
        {
            if (Math.Abs(left.Length - right.Length) > 1)
                throw new Exception("List lengths differ too much");

            

            T[] merged = new T[left.Length + right.Length];
            int ri = 0;
            int li = 0;
            
            while(li < left.Length && ri < right.Length)
            {
                if (_cmp.Compare(left[li], right[ri]) < 0)
                {
                    merged[li + ri] = left[li];
                    li++;
                }
                else
                {
                    merged[li + ri] = right[ri];
                    ri++;
                }
            }

            if (li < left.Length)
                Array.Copy(left, li, merged, li + ri, left.Length - li);
            else if (ri < right.Length)
                Array.Copy(right, ri, merged, li + ri, right.Length - ri);

            return merged;
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
            return _current_indeces;
        }

        public void Sort(int sleep)
        {
            //_data = merge_sort_recursive(_data);
            _sleep = sleep;

            merge_sort_iterative();

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
