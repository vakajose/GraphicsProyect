using GraphicsProyect.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsProyect.Clases
{
    [Serializable]
    class Escenario: IEscenario
    {
        
        public Punto Centro { get ; set ; }
        public bool EjeVisible { get; set; }
        public List<Objeto> Objetos { get; set ; }

        public Escenario(Punto centro, bool ejeVisible)
        {
            this.Centro = centro;
            this.EjeVisible = ejeVisible;
            this.Objetos = new List<Objeto>();

        }

        public void GuardarEscenario()
        {
            throw new NotImplementedException();
        }
    }
}
