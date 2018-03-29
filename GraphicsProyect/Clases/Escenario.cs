using GraphicsProyect.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsProyect.Clases
{
    class Escenario : IEscenario
    {
        public Point Centro { get ; set ; }
        public bool EjeVisible { get; set; }

        public Escenario(Point centro, bool ejeVisible)
        {
            this.Centro = centro;
            this.EjeVisible = ejeVisible;

        }

 
    }
}
