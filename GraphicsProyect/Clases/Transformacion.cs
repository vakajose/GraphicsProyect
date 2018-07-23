using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsProyect.Clases
{
    class Transformacion
    {

        public static void transEscenario()
        {

        }
        public static Objeto transObjeto(Objeto objeto, Matriz matriz)
        {
            if(matriz.tmatriz==Matriz.TMatriz.Traslacion)
            {
                objeto.Centro = transPunto(objeto.Centro, matriz);
            }
            if(matriz.tmatriz==Matriz.TMatriz.Rotacion || matriz.tmatriz == Matriz.TMatriz.Escalamiento)        
            {
                foreach (Poligono poligono in objeto.Poligonos)
                {
                    transPoligono(poligono, matriz);
                }
            }
            return objeto;
        }
        public static Poligono transPoligono( Poligono poligono, Matriz matriz)
        {
            foreach (Punto punto in poligono.Puntos)
            {
                transPunto(punto, matriz);
            }
            return poligono;
        }
        public static Punto transPunto( Punto punto,Matriz matriz)
        {
            Punto puntoM = toPM(punto);
            puntoM.X = (puntoM.X * matriz.getElem(0, 0)) + (puntoM.Y * matriz.getElem(1, 0)) + (puntoM.Z * matriz.getElem(2, 0));
            puntoM.Y = (puntoM.X * matriz.getElem(0, 1)) + (puntoM.Y * matriz.getElem(1, 1)) + (puntoM.Z * matriz.getElem(2, 1));
            punto.X = puntoM.X;
            punto.Y = puntoM.Y;
            return punto ;
        }
        
        private static Punto toPM (Punto punto)
        {
            return new Punto(punto.X,punto.Y,1);
        }
    }
}
