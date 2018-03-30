using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsProyect.Interfaces
{
    public interface IDibujable
    {
        Point PInicial { get; }
        Point PFinal { get; }
        Point PCentral { get; set; }
        
    }
}
