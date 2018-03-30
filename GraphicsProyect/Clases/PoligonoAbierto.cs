using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsProyect
{
    class PoligonoAbierto : Poligono
    {

        public PoligonoAbierto(List<Point> puntos) : base(puntos) { }

        public override void Dibujarse(ref Graphics g)
        {
            Point[] points = Puntos.ToArray();
            Pen pen = new Pen(Color.Olive);
            g.DrawLines(pen, points);
        }

        public override void Dibujarse(ref Graphics g, Point eje)
        {
            Point[] points = GetAbsolutePoints(eje).ToArray();
            Pen pen = new Pen(Color.Olive);
            g.DrawLines(pen, points);
        }
    }
}
