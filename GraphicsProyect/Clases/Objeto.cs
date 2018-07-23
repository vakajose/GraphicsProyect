using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GraphicsProyect.Interfaces;

namespace GraphicsProyect
{
    [Serializable]
    public class Objeto : IDibujable
    {
        public List<Poligono> Poligonos { get; set; }
        public Punto Centro { get; set; }
        public Relatividad relatividad { get; set; }

        [Serializable]
        public enum Relatividad
        {
            relativo,escenario,absoluto
        }

        public Objeto(List<Poligono> poligonos)
        {
            this.Poligonos = poligonos;
            relatividad = Relatividad.escenario;
        }

        public Objeto(Poligono p)
        {
            this.Poligonos = new List<Poligono>();
            Poligonos.Add(p);
            relatividad = Relatividad.escenario;
        }
        public Objeto(Relatividad rel)
        {
            Centro = new Punto(0, 0);
            Poligonos = new List<Poligono>();
            relatividad = rel;
        }
        public void Add(Poligono p)
        {
            Poligonos.Add(p);
        }
        public Punto encontrarCentro()
        {
            double xm=Poligonos[0].Puntos[0].X;
            double ym= Poligonos[0].Puntos[0].Y; ;
            double xM= Poligonos[0].Puntos[0].X; ;
            double yM= Poligonos[0].Puntos[0].Y; ;

            foreach (Poligono poligono in Poligonos)
            {
                foreach (Punto punto in poligono.Puntos)
                {
                    double x = punto.X;
                    double y = punto.Y;

                    if (x > xM) xM = x;
                    if (y > yM) yM = y;
                    if (x < xm) xm = x;
                    if (y < ym) ym = y;
                }
            }

            double xC = (xm + xM) / 2;
            double yC = (ym + yM) / 2;
            return new Punto(xC, yC);
        }
        public void convertirARelativo()
        {
            this.Centro = encontrarCentro();
            this.relatividad = Relatividad.relativo;
            foreach (Poligono poligono in Poligonos)
            {
                poligono.nuevoCentro(this.Centro);
            }
        }

       
    }
}
