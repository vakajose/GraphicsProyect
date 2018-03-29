using GraphicsProyect.Clases;
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
    public partial class Form1 : Form
    {

        private Escenario escenario = new Escenario(new Point(0,0), false);

        public Form1()
        {
            InitializeComponent();
            this.Height = 700;
            this.Width = 1100;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            msnlbl.Text = "Click en el cuadro para fijar ejes";
            escenario.Centro = new Point(0, 0);
            escenario.EjeVisible = false;
            PanelDibujo.Location = new Point(15, 50);        
            dimensionarInterfaz();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            dimensionarInterfaz();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
                
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void PanelDibujo_Paint(object sender, PaintEventArgs e)
        {
            dibujarEjes();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            dimensionarInterfaz();

        }

        private void PanelDibujo_MouseClick(object sender, MouseEventArgs e)
        {
            Point click = e.Location;
            escenario.Centro = click;
            escenario.EjeVisible = ejeVisible.Checked;
            PanelDibujo.Refresh();
            
            msnlbl.Text = "Nuevo eje fijado en punto: (" + click.X + "," + click.Y + ")";
        }

       

        private void ejeVisible_CheckedChanged(object sender, EventArgs e)
        {
            escenario.EjeVisible = ejeVisible.Checked;
            PanelDibujo.Refresh();
        }


        /// <summary>
        /// metodos propios
        /// </summary>
        private void dimensionarInterfaz()
        {
            msnlbl.Location = new Point(this.Width - 200, 22);
            PanelDibujo.Height = this.Height - 100;
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

        }
    }
}
