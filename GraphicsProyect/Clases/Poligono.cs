using GraphicsProyect.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GraphicsProyect
{
    abstract class Poligono : IPoligono
    {

        public List<Point> Puntos { get; set; }

        public int CantPuntos { get; }


        public Poligono( List<Point> puntos)
        {
            this.Puntos = puntos;
            this.CantPuntos = puntos.Count;
        }

        public void BorrarPunto(int index)
        {
            throw new NotImplementedException();
        }

        public void BorrarPunto(Point punto)
        {
            throw new NotImplementedException();
        }

        public Point GetPunto(int index)
        {
            throw new NotImplementedException();
        }

        public Point SetPunto(int index, Point punto)
        {
            throw new NotImplementedException();
        }

        public abstract void Dibujar();

    }
}
