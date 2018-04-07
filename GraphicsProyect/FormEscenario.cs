using GraphicsProyect.Clases;
using GraphicsProyect.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicsProyect
{
    public partial class FormEscenario : Form 
    {

        private Escenario escenario = new Escenario(new Point(0,0), false);
        private List<Point> puntos;
        private int nPuntos = 0;
        private int nPoligonos = 0;
        private int nObjetos = 0;

        public FormEscenario()
        {
            InitializeComponent();
            this.Height = 700;
            this.Width = 1100;
        }

        private void FormEscenario_Load(object sender, EventArgs e)
        {
           
            msnlbl.Text = "Click en el cuadro para fijar ejes";
            escenario.Centro = new Point(0, 0);
            escenario.EjeVisible = true;
            ejeVisible.Checked = true;
            PanelDibujo.Location = new Point(15, 88);        
            dimensionarInterfaz();
        }

        private void FormEscenario_Paint(object sender, PaintEventArgs e)
        {
            dimensionarInterfaz();
        }

        private void PanelDibujo_Paint(object sender, PaintEventArgs e)
        {
            dibujarEjes();
            dibujarEscenario();
            if(puntos !=null && puntos.Count > 0) { 
                dibujarTemporales();
            }
        }

        

        private void FormEscenario_Resize(object sender, EventArgs e)
        {
            dimensionarInterfaz();

        }

        private void PanelDibujo_MouseClick(object sender, MouseEventArgs e)
        {
            Point click = e.Location;
            int x = click.X - escenario.Centro.X;
            int y = click.Y - escenario.Centro.Y;
            Point relClick = new Point(x, y);
            if (rbEjeFijado.Checked) { 
                
                escenario.Centro = click;
                escenario.EjeVisible = ejeVisible.Checked;
                           
                msnlbl.Text = "Nuevo eje fijado en punto: (" + click.X + "," + click.Y + ")";
                PanelDibujo.Refresh();
            }
            if (rbDibujar.Checked)
            {
                if(nPuntos  == 0)
                {
                    puntos = new List<Point>();
                    puntos.Add(relClick);
                    
                }
                else
                {
                    puntos.Add(relClick);
                    
                }
                nPuntos++;
                dibujarTemporales();
                
                lblLastPoint.Text = "Ultimo punto rel: ("+x+","+y+")";
                actEtiquetas();
            }
           
        }

       

        private void ejeVisible_CheckedChanged(object sender, EventArgs e)
        {
            escenario.EjeVisible = ejeVisible.Checked;
            PanelDibujo.Refresh();
        }
        private void rbDibujar_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDibujar.Checked)
            {
                btnPolAbierto.Enabled = true;
                btnPolCerrado.Enabled = true;
                btnObjeto.Enabled = true;

            }
            else
            {
                btnPolAbierto.Enabled = false;
                btnPolCerrado.Enabled = false;
                btnObjeto.Enabled = false;
                reiniciarTemp();
            }
        }

       

        private void btnPolAbierto_Click(object sender, EventArgs e)
        { 
            if(puntos!= null && puntos.Count > 1)
            {
                IPoligono poligono = new PoligonoAbierto(puntos);
                instanciarPoligono(ref poligono);
            }
            else
            {
                MessageBox.Show("No ha creado ningun punto o solo hay 1 punto");
            }
        }
        private void btnPolCerrado_Click(object sender, EventArgs e)
        {
            if (puntos != null && puntos.Count > 1)
            {
                IPoligono poligono = new PoligonoCerrado(puntos);
                instanciarPoligono(ref poligono);
            }
            else
            {
                MessageBox.Show("No ha creado ningun punto o solo hay 1 punto");
            }
        }

        private void btnObjeto_Click(object sender, EventArgs e)
        {
            if (nPoligonos > 0) { 
                nPoligonos = 0;
                nPuntos = 0;
                actEtiquetas();
            }
            else
            {
                MessageBox.Show("No existe ningun poligono creado, cree al menos un poligono");
            }
        }

        /// <summary>
        /// metodos propios
        /// </summary>
        private void dimensionarInterfaz()
        {
            msnlbl.Location = new Point(this.Width - 211, 10);
            msnlbl.ForeColor = Color.Red;
            ejeVisible.Location = new Point(this.Width - 208, 25);
            lblLastPoint.Location = new Point(this.Width - 211, 45);
            lblPunto.Location = new Point(this.Width - 211, 65);
            PanelDibujo.Height = this.Height - 139;
            PanelDibujo.Width = this.Width - 43;
        }
        private void dibujarEjes()
        {

            if (escenario.EjeVisible)
            {
                Pen pen = new Pen(Color.Red);
                Graphics g = PanelDibujo.CreateGraphics();
                g.DrawLine(pen, new Point(escenario.Centro.X, 0),
                               new Point(escenario.Centro.X, PanelDibujo.Height));
                g.DrawLine(pen, new Point(0, escenario.Centro.Y),
                               new Point(PanelDibujo.Width, escenario.Centro.Y));

            }
        }


        private void dibujarEscenario()
        {
            Graphics g = PanelDibujo.CreateGraphics();

            foreach(Objeto obj in escenario.listElem)
            {
                obj.Dibujarse(ref g,escenario.Centro);
            }
        }



        private void dibujarTemporales()
        {
            Pen pen = new Pen(Color.Blue);
            Graphics g = PanelDibujo.CreateGraphics();
            if (nPuntos == 1)
            {
                int x = puntos[0].X + escenario.Centro.X;
                int y = puntos[0].Y + escenario.Centro.Y;
                g.DrawRectangle(pen, x, y, 1, 1);
            }
            else
            {
                Point aF = new Point(puntos[nPuntos - 1].X + escenario.Centro.X, puntos[nPuntos - 1].Y+ escenario.Centro.Y);
                Point aI = new Point(puntos[nPuntos - 2].X + escenario.Centro.X, puntos[nPuntos - 2].Y + escenario.Centro.Y);
                g.DrawLine(pen,aF,aI);
            }

        }

        public void instanciarPoligono(ref IPoligono poligono)
        {
            if (nPoligonos == 0)
            {
                Objeto obj = new Objeto(poligono);
                escenario.listElem.Add(obj);
                nObjetos++;
            }
            else
            {
                escenario.listElem[nObjetos - 1].Add(poligono);

            }
            nPuntos = 0;
            puntos = new List<Point>();
            nPoligonos++;
            actEtiquetas();
            PanelDibujo.Refresh();
        }

        private void actEtiquetas()
        {
            lblPol.Text = "Total pol: " + nPoligonos;
            lblObjeto.Text = "Total: " + nObjetos;
            lblPunto.Text = "#Puntos: " + nPuntos;
            

        }
        private void reiniciarTemp()
        {
            puntos = new List<Point>();
            nPuntos = 0;
            actEtiquetas();
        }

        private void btnCentrarEje_Click(object sender, EventArgs e)
        {
            escenario.Centro = new Point(PanelDibujo.Width / 2, PanelDibujo.Height / 2);
            msnlbl.Text = "Eje centrado en: (" +escenario.Centro.X + ","+escenario.Centro.Y+")";
            PanelDibujo.Refresh();
        }
    }
}
