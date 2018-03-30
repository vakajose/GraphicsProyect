﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsProyect.Interfaces

{
    interface IEscenario
    {
        List<Objeto> listElem { get; set; }
        Point Centro { get; set; }
        bool EjeVisible { set; get; }

        void GuardarEscenario();

    }
}
