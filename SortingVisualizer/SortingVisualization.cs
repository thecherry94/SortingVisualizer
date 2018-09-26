using SortingVisualizer.Algorithm;
using SortingVisualizer.Visual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SortingVisualizer
{
    public class SortingVisualization
    {
        private IGeneralSortingAlgorithm _algo;
        private IVisualizer _vis;

        private Thread _thr_algo;
        private Thread _thr_vis;

        private int _sleep;
        private int _fps;

        public SortingVisualization(IGeneralSortingAlgorithm algo, IVisualizer vis, int sleep, int frame_rate)
        {
            _algo = algo;
            _vis = vis;
            _sleep = sleep;
            _fps = frame_rate;

            _algo.SortingFinished += _algo_SortingFinished;

            _thr_algo = new Thread(() => sort());
            _thr_vis = new Thread(() => visualize());

            _thr_vis.Start();
        }

        private void _algo_SortingFinished(object sender, EventArgs e)
        {
            _thr_algo.Abort();
            _thr_vis.Abort();
                       
            _thr_algo = new Thread(() => sort());
            _thr_vis = new Thread(() => visualize());

            _thr_vis.Start();
        }

        private void sort()
        {
            try
            {
                _algo.Sort(_sleep);
            }
            catch(ThreadAbortException e)
            {
                _thr_vis.Abort();
            }
        }

        private void visualize()
        {
            try
            {
                while (true)
                {
                    _vis.Draw();
                    Thread.Sleep((int)(1.0f / ((float)_fps)));
                }
            }
            catch (ThreadAbortException e)
            {
                _vis.Draw();
            }
        }

        public void Run()
        {
            _thr_algo.Start();
        }
    }
}
