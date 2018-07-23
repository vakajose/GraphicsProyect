using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsProyect
{
    [Serializable]
    public class Punto 
    {
        public double X {get;set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Punto  (double x, double y)
        {
            this.X = x;
            this.Y = y;
        }
        public Punto(double x, double y,double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

    }
}
