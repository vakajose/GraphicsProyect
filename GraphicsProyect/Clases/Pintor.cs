using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsProyect.Clases
{
    
    class Pintor
    {
        public Graphics Gr { get; set; }
        public Pen Lapiz { get; set; }

        public Pintor() { }
        public Pintor(ref Graphics gr)
        {
            this.Gr = gr;
        }
        public Pintor(ref Graphics gr,Pen lapiz)
        {
            this.Gr = gr;
            this.Lapiz = lapiz;
        }
        public void dibujarEscenario(Escenario escenario)
        {
            Punto c = escenario.Centro;
            foreach (Objeto obj in escenario.Objetos)
            {
                if (obj.relatividad == Objeto.Relatividad.relativo)
                {
                    Lapiz = new Pen(Color.Black);
                    dibujarObjeto(obj,c);
                }
                else
                {
                    Lapiz = new Pen(Color.Olive);
                    dibujarObjeto(obj, c);
                }
            }
        }
        public void dibujarObjeto(Objeto objeto, Punto centroEsc)
        {
            Punto factorCentro = new Punto(objeto.Centro.X + centroEsc.X,objeto.Centro.Y +centroEsc.Y);
            foreach (Poligono pol in objeto.Poligonos)
            {
                dibujarPoligono(pol, factorCentro);
            }
        }
        public void dibujarPoligono(Poligono poligono)
        {
            if (poligono.Tipo_Poligono==Poligono.TipoPoligono.Abierto)
            {
                Gr.DrawLines(Lapiz, getPointFArray(poligono));
            }
            else
            {
                Gr.DrawPolygon(Lapiz, getPointFArray(poligono));
            }
        }
        public void dibujarPoligono(Poligono poligono, Punto factorCentro)
        {
            if (poligono.Tipo_Poligono == Poligono.TipoPoligono.Abierto)
            {
                Gr.DrawLines(Lapiz, getPointFArray(poligono,factorCentro));
            }
            else
            {
                Gr.DrawPolygon(Lapiz, getPointFArray(poligono,factorCentro));
            }
        }
        public void dibujarPunto(Punto punto)
        {
            Gr.DrawRectangle(Lapiz,(float) punto.X,(float)punto.Y, 1, 1);
        }
        private PointF[] getPointFArray(Poligono poligono)
        {
            List<PointF> points = new List<PointF>();
            foreach (Punto punto in poligono.Puntos)
            {
                points.Add(new PointF((float)punto.X, (float)punto.Y));
            }
            return points.ToArray();
        }
        private PointF[] getPointFArray(Poligono poligono,Punto factorCentro)
        {
            List<PointF> points = new List<PointF>();
            foreach (Punto punto in poligono.Puntos)
            {
                points.Add(new PointF((float)punto.X+ (float)factorCentro.X, (float)punto.Y+ (float)factorCentro.Y));
            }
            return points.ToArray();
        }
    }
}
