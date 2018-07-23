using GraphicsProyect.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GraphicsProyect
{   
    [Serializable]
    public class Poligono : IDibujable
    {

        public List<Punto> Puntos { get; set; }
        public Punto Centro { get; set; }
        public TipoPoligono Tipo_Poligono { get; set; }
        [Serializable]
        public enum TipoPoligono
        {
            Abierto, Cerrado
        }

        public Poligono(List<Punto> puntos)
        {
            this.Puntos = puntos;
            Centro = new Punto(0, 0);
        }
        public Poligono(List<Punto> puntos, TipoPoligono tipo)
        {
            this.Puntos = puntos;
            this.Tipo_Poligono = tipo;
            Centro = new Punto(0, 0);
        }
        public Poligono(TipoPoligono tipo)
        {
            this.Puntos = new List<Punto>();
            Centro = new Punto(0, 0);
            Tipo_Poligono = tipo;
        }
        public Poligono(Punto p)
        {
            Puntos = new List<Punto>();
            Puntos.Add(p);
            Centro = new Punto(0, 0);
        }
        public Poligono(Punto p, TipoPoligono tipo)
        {
            Puntos = new List<Punto>();
            Puntos.Add(p);
            Centro = new Punto(0, 0);
            Tipo_Poligono = tipo;
        }

        public void BorrarPunto(int index)
        {
            Puntos.RemoveAt(index);
        }

 
        public Punto GetPunto(int index) => Puntos[index];

        public void SetPunto(int index, Punto punto) => Puntos[index] = punto;

        public void Add(Punto p) => Puntos.Add(p);

        public void nuevoCentro(Punto nuevoCentro)
        {
            this.Centro = nuevoCentro;
            foreach (Punto punto in Puntos)
            {
                punto.X = punto.X - nuevoCentro.X;
                punto.Y = punto.Y - nuevoCentro.Y;
            }

        }
        
        public List<Punto> GetAbsolutePuntos(Punto eje)
        {
            double x;
            double y;
            List<Punto> absPuntos = new List<Punto>();
            foreach(Punto p in Puntos)
            {
                x = p.X + eje.X;
                y = p.Y + eje.Y;
                absPuntos.Add(new Punto(x,y));
            }

            return absPuntos;
        }

    }
}
