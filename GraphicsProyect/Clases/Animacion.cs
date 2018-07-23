using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsProyect.Clases
{
    [Serializable]
    class Animacion
    {
        public List<Matriz> Matrices { get; set; }
        public Animacion()
        {
            Matrices = new List<Matriz>();
        }
        public Animacion(Matriz matriz)
        {
            Matrices = new List<Matriz>();
            Matrices.Add(matriz);
        }
        public void addMatriz(Matriz matriz)
        {
            Matrices.Add(matriz);
        }
    }
}
