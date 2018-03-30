using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GraphicsProyect.Interfaces;

namespace GraphicsProyect
{
    public class Objeto : IDibujable
    {
       public List<IPoligono> Poligonos { get; set; }

        public Point PInicial { get; }

        public Point PFinal { get; }

        public Point PCentral { get; set; }




        public Objeto(List<IPoligono> poligonos)
        {
            Poligonos = poligonos;
            if (poligonos.Count == 0)
            {
                PInicial = poligonos[0].GetPunto(0);
                IPoligono poligono = poligonos[poligonos.Count - 1];
                PFinal = poligono.GetPunto(poligono.CantPuntos-1);
                PCentral = poligonos[0].GetPunto(0);
            }
        }

        public Objeto(IPoligono p)
        {
            Poligonos = new List<IPoligono>();
            Poligonos.Add(p);
            PInicial = p.GetPunto(0);
            PCentral = p.GetPunto(0);
        }

        public void Add(IPoligono p)
        {
            Poligonos.Add(p);
        }

        public void Dibujarse(ref Graphics g)
        {
            foreach(IPoligono pol in Poligonos)
            {
                pol.Dibujarse(ref g);
            }
        }

        public void Dibujarse(ref Graphics g, Point eje)
        {
            foreach(IPoligono pol in Poligonos)
            {
                pol.Dibujarse(ref g, eje);
            }
        }
    }
}
