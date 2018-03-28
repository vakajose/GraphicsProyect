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
        public Form1()
        {
            InitializeComponent();
            this.Height = 500;
            this.Width = 500;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            Objeto ob = new Objeto(g);
            Pen pen = new Pen(Color.Black);
            Point[] points = new Point[] {new Point(100,200), new Point(300,400),new Point(350,250) };
            Point point = new Point(1, 1);
          
                
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
