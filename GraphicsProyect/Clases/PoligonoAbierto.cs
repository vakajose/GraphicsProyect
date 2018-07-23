using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsProyect
{
    class PoligonoAbierto 
    {

        public PoligonoAbierto(List<Point> puntos){ }

        public  void Dibujarse(ref Graphics g)
        {
            Point[] points = Puntos.ToArray();
            Pen pen = new Pen(Color.Olive);
            g.DrawLines(pen, points);
        }

        public  void Dibujarse(ref Graphics g, Point eje)
        {
            Point[] points = GetAbsolutePoints(eje).ToArray();
            Pen pen = new Pen(Color.Olive);
            g.DrawLines(pen, points);
        }
    }
}
