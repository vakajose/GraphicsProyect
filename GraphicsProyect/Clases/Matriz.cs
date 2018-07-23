using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsProyect.Clases
{
    [Serializable]
    class Matriz
    {
        public double[,] matriz { get; set; }
        public TMatriz tmatriz;
        [Serializable]
        public enum TMatriz
        {
            Traslacion,Rotacion,Escalamiento
        }
       
        public Matriz(double[,] matriz,TMatriz tmatriz)
        {
            this.matriz = matriz;
            this.tmatriz = tmatriz;
        }

        public Matriz (double tx, double ty)
        {
            double[,] m = new double[,]{ {  1,     0, 0 },
                                   {  0,     1, 0 },
                                   { tx,    ty, 1 }};
            matriz = m;
            tmatriz = TMatriz.Traslacion;
        }

        public Matriz(double angulo)
        {
            angulo = angulo * Math.PI / 180.0;

            double[,] m = new double[,] { { ( Math.Cos(angulo)), (Math.Sin(angulo)), 0 },
                                    { (-Math.Sin(angulo)), (Math.Cos(angulo)), 0 },
                                    {                          0,                         0, 1 }};
            matriz = m;
            tmatriz = TMatriz.Rotacion;
        }

        public Matriz(double escala, bool crece)
        {
            if (crece)
            {
                double[,] m = new double[,] { { escala,      0, 0 },
                                        {      0, escala, 0 },
                                        {      0,      0, 1 }};
                matriz = m;
                tmatriz = TMatriz.Escalamiento;
             
            }
            else
            {
                double[,] m = new double[,] { { 1/escala,        0, 0 },
                                        {        0, 1/escala, 0 },
                                        {        0,        0, 1 }};
                matriz = m;
                tmatriz = TMatriz.Escalamiento;
          
            }
        }

        public  Matriz(double escalaX, double escalaY, bool crece)
        {
            if (crece)
            {
                double[,] m = new double[,] { { escalaX,       0, 0 },
                                        {       0, escalaY, 0 },
                                        {       0,       0, 1 }};
                matriz = m;
                tmatriz = TMatriz.Escalamiento;
            }
            else
            {
                double[,] m = new double[,] { { 1/escalaX,         0, 0 },
                                        {         0, 1/escalaY, 0 },
                                        {         0,         0, 1 }};
                matriz = m;
                tmatriz = TMatriz.Escalamiento;
            }
        }

        public double getElem(int i, int j)
        {
            return this.matriz[i, j];
        }
    }
}
