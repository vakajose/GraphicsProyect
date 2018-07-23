using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsProyect.Clases
{
    class PoligonoCerrado
    {

        public PoligonoCerrado(List<Point> puntos) { }

        public  void Dibujarse(ref Graphics g)
        {
            Point[] points = Puntos.ToArray();
            Pen pen = new Pen(Color.Olive);
            g.DrawPolygon(pen, points);
        }

        public  void Dibujarse(ref Graphics g, Point eje)
        {
            Point[] points = GetAbsolutePoints(eje).ToArray();
            Pen pen = new Pen(Color.Olive);
            g.DrawPolygon(pen, points);
        }
    }
}
