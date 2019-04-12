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
using System.IO;
namespace GraphicsProyect
{
    public partial class FormEscenario : Form 
    {
        private Graficador G = new Graficador(new Escenario(new Punto(0, 0), false));

        private List<Punto> puntosTemporales;
        private int nPuntos = 0;
        private int nPoligonos = 0;
        private int nObjetos = 0;
        private int timercount = 0;

        public FormEscenario()
        {
            InitializeComponent();
            this.Height = 700;
            this.Width = 1100;
        }
        //al cargar formulario
        private void FormEscenario_Load(object sender, EventArgs e)
        {           
            msnlbl.Text = "Click en el cuadro para fijar ejes";
            G.Escenario.Centro = new Punto(0, 0);
            G.Escenario.EjeVisible = true;
            ejeVisible.Checked = true;
            PanelDibujo.Location = new Point(15, 88);       //caso especial para usar point 
            timer.Stop();
            Graphics gr = PanelDibujo.CreateGraphics();   
            G.Pintor = new Pintor(ref gr);
            //creo una animacion por defecto
            Animacion ani = new Animacion(); //creo una animacion vacia
                ani.addMatriz(new Matriz(1.005, true)); // le inserto una matriz de escalamiento que crece
                ani.addMatriz(new Matriz(2.0)); //le inserto una matriz de rotacion con angulo 2
                ani.addMatriz(new Matriz(2, 0)); //le inserto una matriz de trslacion en eje x =2, y= 0
                List<Animacion> anis = new List<Animacion>(); //añado la animacion a una lista de animaciones
                anis.Add(ani);
                G.Animaciones = anis; // seteo la lista en el campo animaciones de mi GRAFICADOR
            //fin crear animacion por defecto 
            dimensionarInterfaz();
            actEtiquetas();
            
        }
        //al pintar formulario
        private void FormEscenario_Paint(object sender, PaintEventArgs e)
        {
            dimensionarInterfaz();
        }
        //al redimensionar el formulario
        private void FormEscenario_Resize(object sender, EventArgs e)
        {
            dimensionarInterfaz();
        }
        //al pintar el panel
        private void PanelDibujo_Paint(object sender, PaintEventArgs e)
        {
            dibujarEjes();
            dibujarEscenario();
            //dibujamos los elementos que no se hayan insertado en un objeto o poligono
            if(puntosTemporales !=null && puntosTemporales.Count > 0) { 
                dibujarTemporales();
            }
        }
        //al modificar el check de mostrar ejes
        private void ejeVisible_CheckedChanged(object sender, EventArgs e)
        {
            //se actualiza el check y se redibuja el panel
            G.Escenario.EjeVisible = ejeVisible.Checked;
            PanelDibujo.Refresh();
        }
        //al alternar entre mover eje o dibujar 
        private void rbDibujar_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDibujar.Checked)
            {
                btnPolAbierto.Enabled = true;
                btnPolCerrado.Enabled = true;
                btnObjeto.Enabled = true;

            }
            //cada vez que se alterna la opcion para mover eje se reinician temporales
            else
            {
                btnPolAbierto.Enabled = false;
                btnPolCerrado.Enabled = false;
                btnObjeto.Enabled = false;
                reiniciarTemp();
            }
        }


        private void PanelDibujo_MouseClick(object sender, MouseEventArgs e)
        {
            Point click = e.Location;
            double x = click.X - G.Escenario.Centro.X;
            double y = click.Y - G.Escenario.Centro.Y;
            Punto relClick = new Punto(x, y);
            if (rbEjeFijado.Checked) { 
                
                G.Escenario.Centro = new Punto(click.X,click.Y);
                G.Escenario.EjeVisible = ejeVisible.Checked;                        
                msnlbl.Text = "Nuevo eje fijado en punto: (" + click.X + "," + click.Y + ")";
                PanelDibujo.Refresh();
            }
            if (rbDibujar.Checked)
            {
                if(nPuntos  == 0)
                {
                    puntosTemporales = new List<Punto>();
                    puntosTemporales.Add(relClick);
                    
                }
                else
                {
                    puntosTemporales.Add(relClick);
                    
                }
                nPuntos++;
                dibujarTemporales();
                
                lblLastPoint.Text = "Ultimo punto rel: ("+x+","+y+")";
                actEtiquetas();
            }
           
        }

        private void btnPolAbierto_Click(object sender, EventArgs e)
        { 
            if(puntosTemporales!= null && puntosTemporales.Count > 1)
            {
                Poligono poligono = new Poligono(puntosTemporales,Poligono.TipoPoligono.Abierto);
                instanciarPoligono(ref poligono);
            }
            else
            {
                MessageBox.Show("No ha creado ningun punto o solo hay 1 punto");
            }
        }
        private void btnPolCerrado_Click(object sender, EventArgs e)
        {
            if (puntosTemporales != null && puntosTemporales.Count > 1)
            {
                Poligono poligono = new Poligono(puntosTemporales,Poligono.TipoPoligono.Cerrado);
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

                G.Escenario.Objetos[nObjetos - 1].convertirARelativo();
                nPoligonos = 0;
                nPuntos = 0;
                actEtiquetas();
               
                PanelDibujo.Refresh();
            }
            else
            {
                MessageBox.Show("No existe ningun poligono creado, cree al menos un poligono");
            }
        }

        /// <summary>
        /// metodos propios
        /// </summary>
        private void dimensionarInterfaz() //adaptamos el tamaño de la interfaz de usuario
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
            if (G.Escenario.EjeVisible)
            {
                Pen pen = new Pen(Color.Red);
                Graphics gr = PanelDibujo.CreateGraphics();
                G.Pintor = new Pintor(ref gr, pen);

                List<Punto> py = new List<Punto>();
                py.Add (new Punto(G.Escenario.Centro.X, 0));
                py.Add (new Punto(G.Escenario.Centro.X, PanelDibujo.Height));
                Poligono ejey = new Poligono(py, Poligono.TipoPoligono.Abierto);

                Poligono ejex = new Poligono( new Punto(0, G.Escenario.Centro.Y));
                ejex.Add (new Punto(PanelDibujo.Width, G.Escenario.Centro.Y));
                ejex.Tipo_Poligono = Poligono.TipoPoligono.Abierto;

                G.Pintor.dibujarPoligono(ejey);//poligonos absolutos
                G.Pintor.dibujarPoligono(ejex);

            }
        }


        private void dibujarEscenario()
        {
            Graphics gr = PanelDibujo.CreateGraphics();
            Pen pen = new Pen(Color.Olive);
            G.Pintor = new Pintor(ref gr, pen);
            G.Pintor.dibujarEscenario(G.Escenario);//dibujar escenario con putos relativos
        }



        private void dibujarTemporales()
        {
            Pen pen = new Pen(Color.Blue);
            Graphics gr = PanelDibujo.CreateGraphics();
            G.Pintor = new Pintor(ref gr, pen);

            if (nPuntos == 1)
            {
                double x = puntosTemporales[0].X + G.Escenario.Centro.X;
                double y = puntosTemporales[0].Y + G.Escenario.Centro.Y;
                G.Pintor.dibujarPunto(new Punto(x,y));
                
            }
            else
            {
                
                Punto aF = new Punto(puntosTemporales[nPuntos - 1].X + G.Escenario.Centro.X, puntosTemporales[nPuntos - 1].Y+ G.Escenario.Centro.Y);
                Punto aI = new Punto(puntosTemporales[nPuntos - 2].X + G.Escenario.Centro.X, puntosTemporales[nPuntos - 2].Y + G.Escenario.Centro.Y);
                Poligono pol = new Poligono(aF, Poligono.TipoPoligono.Abierto);
                pol.Add(aI);
                G.Pintor.dibujarPoligono(pol);//poligono absoluto dibujando temporales
            }

        }

        public void instanciarPoligono(ref Poligono poligono)
        {
            if (nPoligonos == 0)
            {
                //AÑADIR LOGICA NUEVA DE CREACION DE OBJETOS RELATIVOS A SI MISMOS
                Objeto obj = new Objeto(Objeto.Relatividad.escenario);//crea un nuevo objeto relativo al escenario con centro 0,0
                poligono.Centro = obj.Centro;
                obj.Add(poligono);
                G.Escenario.Objetos.Add(obj);
                nObjetos++;
            }
            else
            {
                poligono.Centro = G.Escenario.Objetos[nObjetos - 1].Centro;
                G.Escenario.Objetos[nObjetos - 1].Add(poligono);
            }
            nPuntos = 0;
            puntosTemporales = new List<Punto>();
            nPoligonos++;
            actEtiquetas();
            PanelDibujo.Refresh();
        }

        private void actEtiquetas()
        {
            nObjetos = G.Escenario.Objetos.Count;
            lblPol.Text = "Total pol: " + nPoligonos;
            lblObjeto.Text = "Total: " + nObjetos;
            lblPunto.Text = "#Puntos: " + nPuntos;
            listboxObjetos.Items.Clear(); int i = 1;
            foreach(Objeto obj in G.Escenario.Objetos)
            {
                if (obj.relatividad == Objeto.Relatividad.relativo)
                {
                    listboxObjetos.Items.Add(i);
                    i++;
                }
            }
            listboxAnimacion.Items.Clear(); i = 1;
            if(G.Animaciones != null)
            {
                foreach (Animacion ani in G.Animaciones)
                {
                    listboxAnimacion.Items.Add(i);
                    i++;
                }
            }
        }
        private void reiniciarTemp()
        {
            puntosTemporales = new List<Punto>();
            nPuntos = 0;
            actEtiquetas();
        }

        private void btnCentrarEje_Click(object sender, EventArgs e)
        {
            G.Escenario.Centro = new Punto(PanelDibujo.Width / 2, PanelDibujo.Height / 2);
            msnlbl.Text = "Eje centrado en: (" +G.Escenario.Centro.X + ","+G.Escenario.Centro.Y+")";
            PanelDibujo.Refresh();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            /*
            Matriz m1 = new Matriz();
            m1.MatrizEscala(1.005, 1);
            Transformacion.transObjeto(escenario.Objetos[listboxObjetos.SelectedIndex], m1);

            Matriz m2 = new Matriz();
            m2.MatrizRotacion(2);
            Transformacion.transObjeto(escenario.Objetos[listboxObjetos.SelectedIndex], m2);

            Matriz m3 = new Matriz();
            m3.MatrizTraslacion(2,0);
            Transformacion.transObjeto(escenario.Objetos[listboxObjetos.SelectedIndex], m3);
            */
            foreach (Matriz matriz in G.Animaciones[listboxAnimacion.SelectedIndex].Matrices)
            {
                Transformacion.transObjeto(G.Escenario.Objetos[listboxObjetos.SelectedIndex], matriz);
            }
            contador.Text = timercount.ToString();
            timercount++;
            PanelDibujo.Refresh();
        }

        private void playBtn_Click(object sender, EventArgs e)
        {
            if (listboxObjetos.SelectedItem!=null && listboxAnimacion.SelectedItem!=null)
            {
                if (timer.Enabled)
                {
                    timer.Stop();
                    playBtn.Text = "PLAY";
                }
                else
                {
                    timer.Start();
                    playBtn.Text = "STOP";
                }
            }
            else
            {
                MessageBox.Show("No ha seleccionado ningun objeto o animacion");
            }
        }

        private void listboxObjetos_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Delete && listboxObjetos.SelectedItem!=null)
            {
                G.Escenario.Objetos.RemoveAt(listboxObjetos.SelectedIndex);
                listboxObjetos.Items.RemoveAt(listboxObjetos.Items.Count-1);
                nObjetos--;
                actEtiquetas();
                PanelDibujo.Refresh();
            }
        }

        private void listboxAnimacion_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Delete && listboxAnimacion.SelectedItem != null)
            {
                G.Animaciones.RemoveAt(listboxAnimacion.SelectedIndex);
                listboxAnimacion.Items.RemoveAt(listboxAnimacion.Items.Count - 1);
            }
        }

       

        private void Guardar_Click(object sender, EventArgs e)
        {
            save();
        }
        private void save()
        {
            try
            {
                using (System.Windows.Forms.SaveFileDialog dialog = new SaveFileDialog())
                {
                    if (dialog.ShowDialog()== DialogResult.OK)
                    {
                        using (Stream st = File.Open(dialog.FileName,FileMode.Create))
                        {
                            var binfor = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                            binfor.Serialize(st, G);
                            MessageBox.Show("Se ha guardado de manera correcta");
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void Cargar_Click(object sender, EventArgs e)
        {
            load();
        }
        private void load()
        {
            try
            {
                using (System.Windows.Forms.OpenFileDialog dialog = new OpenFileDialog())
                {
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        using (Stream st = File.Open(dialog.FileName, FileMode.Open))
                        {
                            var binfor = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                            G = (Graficador) binfor.Deserialize(st);
                            PanelDibujo.Refresh();
                            actEtiquetas();
                            MessageBox.Show("CARGADO");
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
