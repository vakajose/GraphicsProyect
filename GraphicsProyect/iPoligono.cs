using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsProyect
{
    interface iPoligono
    {

        List<Punto> getPuntos();
        void setPuntos(List<Punto> puntos);
        Punto getPunto(int index);
        Punto setPunto(int index, Punto punto);
        int getCantPuntos();
        void borrarPunto(int index);
        void borrarPunto(Punto punto);
        void dibujar();

    }
}

