using SortingVisualizer.Algorithm;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SortingVisualizer.Visual
{
    public class BarVisualizer<T> : IVisualizer
    {
        private Type[] _accepted_types = new Type[] { typeof(int), typeof(float) };


        private PictureBox _pcb;
        private Bitmap _c;
        private ISortingAlgorithm<T> _algo;

        public BarVisualizer(ref PictureBox canvas, ref IGeneralSortingAlgorithm algo)
        {
            if (!_accepted_types.Contains(typeof(T)))
            {
                throw new Exception("Data type of generic not accepted by class.");
            }

            _pcb = canvas;
            _algo = (ISortingAlgorithm<T>)algo;

            
        }

        public void Draw()
        {
            Pen pen_bar = Pens.White;
            Pen pen_bar_selected = Pens.Red;

            float bar_w = (float)_pcb.Width / (float)_algo.Data.Length;

            _c = new Bitmap(_pcb.Width, _pcb.Height);
            Graphics g = Graphics.FromImage(_c);

            for(int i = 0; i < _algo.Data.Length; i++)
            {
                float bar_h = (Convert.ToSingle(_algo.Data[i]) / Convert.ToSingle(_algo.Largest)) * (float)_pcb.Height;

                if (_algo.GetCurrentIndices().Contains(i))
                    g.FillRectangle(Brushes.Red, bar_w * i, _pcb.Height - bar_h, bar_w, bar_h);
                else
                    g.FillRectangle(Brushes.White, bar_w * i, _pcb.Height - bar_h, bar_w, bar_h);
            }

            _pcb.Image = _c;
        }
    }
}
