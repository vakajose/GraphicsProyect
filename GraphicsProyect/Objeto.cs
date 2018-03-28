using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicsProyect
{
    class Objeto
    {
        Graphics g;

        public Objeto(Graphics g)
        {
            this.g = g;
        }

        public Graphics getGraphics()
        {
            return this.g;
        }
        public void setGraphics(Graphics g)
        {
            this.g = g;
        }

    }
}
