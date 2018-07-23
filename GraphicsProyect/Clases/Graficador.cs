using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsProyect.Clases
{
    [Serializable]
    class Graficador
    {
        public Escenario Escenario { get; set; }
        public Pintor Pintor { get; set; }
        public List<Animacion> Animaciones { get; set; }

        public Graficador(Escenario escenario, Pintor pintor, List<Animacion> Animaciones)
        {
            this.Escenario = escenario;
            this.Pintor = pintor;
            this.Animaciones = Animaciones;
        }
        public Graficador(Escenario escenario)
        {
            this.Escenario = escenario;
        }
    }
}
