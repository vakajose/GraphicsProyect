using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsProyect.Interfaces
{
   public interface IPoligono
    {
        List<Point> Puntos { get; set; }
        int CantPuntos { get; }

        Point GetPunto(int index);
        Point SetPunto(int index, Point punto);
        void BorrarPunto(int index);
        void BorrarPunto(Point punto);
        void Dibujar();

    }
}

