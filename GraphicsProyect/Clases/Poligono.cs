using GraphicsProyect.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GraphicsProyect
{
    abstract class Poligono : IPoligono, IDibujable
    {

        public List<Point> Puntos { get; set; }

        public int CantPuntos { get; }

        public Point PInicial { get; }

        public Point PFinal { get; }

        public Point PCentral { get; set ; }


        public Poligono(List<Point> puntos)
        {
            this.Puntos = puntos;
            this.CantPuntos = puntos.Count;
        }
        public Poligono(Point p)
        {
            Puntos.Add(p);
            CantPuntos++;
            PInicial = p;
            PCentral = p;
        }

        public void BorrarPunto(int index)
        {
           
        }

        public void BorrarPunto(Point punto)
        {
          
        }

        public Point GetPunto(int index) => Puntos[index];

        public void SetPunto(int index, Point punto) => Puntos[index] = punto;

        public void Add(Point p) => Puntos.Add(p);
        
        public List<Point> GetAbsolutePoints(Point eje)
        {
            int x;
            int y;
            List<Point> absPoints = new List<Point>();
            foreach(Point p in Puntos)
            {
                x = p.X + eje.X;
                y = p.Y + eje.Y;
                absPoints.Add(new Point(x,y));
            }

            return absPoints;
        }

        public abstract void Dibujarse(ref Graphics g);
        public abstract void Dibujarse(ref Graphics g, Point eje);
    }
}
