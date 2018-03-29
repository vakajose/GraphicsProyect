using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsProyect
{
    public class Punto
    {
        private double x;
        private double y;

        public Punto  (double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public void setX(Double x)
        {
            this.x = x;
        }
        public void setY(Double y)
        {
            this.y = y;
        }
        public double getX()
        {
            return this.x;
        }
        public double getY()
        {
            return this.y;
        }

    }
}
