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
        List<Punto> Puntos { get; set; }
      
        Punto GetPunto(int index);
        void SetPunto(int index, Punto punto);
        void BorrarPunto(int index);
        void Dibujarse(ref Graphics g);
        void Dibujarse(ref Graphics g, Punto eje);

    }
}

