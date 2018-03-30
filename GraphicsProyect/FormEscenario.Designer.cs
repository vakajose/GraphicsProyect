namespace GraphicsProyect
{
    partial class FormEscenario
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.PanelDibujo = new System.Windows.Forms.Panel();
            this.msnlbl = new System.Windows.Forms.Label();
            this.ejeVisible = new System.Windows.Forms.CheckBox();
            this.rbEjeFijado = new System.Windows.Forms.RadioButton();
            this.rbDibujar = new System.Windows.Forms.RadioButton();
            this.rbGrupo = new System.Windows.Forms.GroupBox();
            this.btnPolAbierto = new System.Windows.Forms.Button();
            this.btnPolCerrado = new System.Windows.Forms.Button();
            this.btnObjeto = new System.Windows.Forms.Button();
            this.lblPol = new System.Windows.Forms.Label();
            this.lblObjeto = new System.Windows.Forms.Label();
            this.lblLastPoint = new System.Windows.Forms.Label();
            this.lblPunto = new System.Windows.Forms.Label();
            this.btnCentrarEje = new System.Windows.Forms.Button();
            this.rbGrupo.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelDibujo
            // 
            this.PanelDibujo.BackColor = System.Drawing.SystemColors.Window;
            this.PanelDibujo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelDibujo.Location = new System.Drawing.Point(15, 88);
            this.PanelDibujo.Name = "PanelDibujo";
            this.PanelDibujo.Size = new System.Drawing.Size(1060, 561);
            this.PanelDibujo.TabIndex = 2;
            this.PanelDibujo.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelDibujo_Paint);
            this.PanelDibujo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PanelDibujo_MouseClick);
            // 
            // msnlbl
            // 
            this.msnlbl.AutoSize = true;
            this.msnlbl.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.msnlbl.Location = new System.Drawing.Point(889, 10);
            this.msnlbl.Name = "msnlbl";
            this.msnlbl.Size = new System.Drawing.Size(95, 13);
            this.msnlbl.TabIndex = 3;
            this.msnlbl.Text = "Click para fijar ejes";
            // 
            // ejeVisible
            // 
            this.ejeVisible.AutoSize = true;
            this.ejeVisible.Location = new System.Drawing.Point(892, 25);
            this.ejeVisible.Name = "ejeVisible";
            this.ejeVisible.Size = new System.Drawing.Size(70, 17);
            this.ejeVisible.TabIndex = 4;
            this.ejeVisible.Text = "ejeVisible";
            this.ejeVisible.UseVisualStyleBackColor = true;
            this.ejeVisible.CheckedChanged += new System.EventHandler(this.ejeVisible_CheckedChanged);
            // 
            // rbEjeFijado
            // 
            this.rbEjeFijado.AutoSize = true;
            this.rbEjeFijado.Checked = true;
            this.rbEjeFijado.Location = new System.Drawing.Point(6, 9);
            this.rbEjeFijado.Name = "rbEjeFijado";
            this.rbEjeFijado.Size = new System.Drawing.Size(67, 17);
            this.rbEjeFijado.TabIndex = 5;
            this.rbEjeFijado.TabStop = true;
            this.rbEjeFijado.Text = "Fijar Ejes";
            this.rbEjeFijado.UseVisualStyleBackColor = true;
            // 
            // rbDibujar
            // 
            this.rbDibujar.AutoSize = true;
            this.rbDibujar.Location = new System.Drawing.Point(6, 27);
            this.rbDibujar.Name = "rbDibujar";
            this.rbDibujar.Size = new System.Drawing.Size(102, 17);
            this.rbDibujar.TabIndex = 6;
            this.rbDibujar.Text = "Dibujar Poligono";
            this.rbDibujar.UseVisualStyleBackColor = true;
            this.rbDibujar.CheckedChanged += new System.EventHandler(this.rbDibujar_CheckedChanged);
            // 
            // rbGrupo
            // 
            this.rbGrupo.Controls.Add(this.rbDibujar);
            this.rbGrupo.Controls.Add(this.rbEjeFijado);
            this.rbGrupo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rbGrupo.Location = new System.Drawing.Point(12, 0);
            this.rbGrupo.Margin = new System.Windows.Forms.Padding(1);
            this.rbGrupo.Name = "rbGrupo";
            this.rbGrupo.Size = new System.Drawing.Size(121, 45);
            this.rbGrupo.TabIndex = 7;
            this.rbGrupo.TabStop = false;
            // 
            // btnPolAbierto
            // 
            this.btnPolAbierto.Enabled = false;
            this.btnPolAbierto.Location = new System.Drawing.Point(154, 4);
            this.btnPolAbierto.Name = "btnPolAbierto";
            this.btnPolAbierto.Size = new System.Drawing.Size(105, 22);
            this.btnPolAbierto.TabIndex = 8;
            this.btnPolAbierto.Text = "Poligono Abierto";
            this.btnPolAbierto.UseVisualStyleBackColor = true;
            this.btnPolAbierto.Click += new System.EventHandler(this.btnPolAbierto_Click);
            // 
            // btnPolCerrado
            // 
            this.btnPolCerrado.Enabled = false;
            this.btnPolCerrado.Location = new System.Drawing.Point(154, 32);
            this.btnPolCerrado.Name = "btnPolCerrado";
            this.btnPolCerrado.Size = new System.Drawing.Size(105, 22);
            this.btnPolCerrado.TabIndex = 9;
            this.btnPolCerrado.Text = "Poligono Cerrado";
            this.btnPolCerrado.UseVisualStyleBackColor = true;
            this.btnPolCerrado.Click += new System.EventHandler(this.btnPolCerrado_Click);
            // 
            // btnObjeto
            // 
            this.btnObjeto.Enabled = false;
            this.btnObjeto.Location = new System.Drawing.Point(154, 60);
            this.btnObjeto.Name = "btnObjeto";
            this.btnObjeto.Size = new System.Drawing.Size(105, 22);
            this.btnObjeto.TabIndex = 10;
            this.btnObjeto.Text = "Objeto";
            this.btnObjeto.UseVisualStyleBackColor = true;
            this.btnObjeto.Click += new System.EventHandler(this.btnObjeto_Click);
            // 
            // lblPol
            // 
            this.lblPol.AutoSize = true;
            this.lblPol.Location = new System.Drawing.Point(265, 25);
            this.lblPol.Name = "lblPol";
            this.lblPol.Size = new System.Drawing.Size(51, 13);
            this.lblPol.TabIndex = 11;
            this.lblPol.Text = "Total pol:";
            // 
            // lblObjeto
            // 
            this.lblObjeto.AutoSize = true;
            this.lblObjeto.Location = new System.Drawing.Point(265, 65);
            this.lblObjeto.Name = "lblObjeto";
            this.lblObjeto.Size = new System.Drawing.Size(34, 13);
            this.lblObjeto.TabIndex = 13;
            this.lblObjeto.Text = "Total:";
            // 
            // lblLastPoint
            // 
            this.lblLastPoint.AutoSize = true;
            this.lblLastPoint.Location = new System.Drawing.Point(889, 45);
            this.lblLastPoint.Name = "lblLastPoint";
            this.lblLastPoint.Size = new System.Drawing.Size(69, 13);
            this.lblLastPoint.TabIndex = 14;
            this.lblLastPoint.Text = "Ultimo punto:";
            // 
            // lblPunto
            // 
            this.lblPunto.AutoSize = true;
            this.lblPunto.Location = new System.Drawing.Point(889, 65);
            this.lblPunto.Name = "lblPunto";
            this.lblPunto.Size = new System.Drawing.Size(53, 13);
            this.lblPunto.TabIndex = 15;
            this.lblPunto.Text = "#Puntos: ";
            // 
            // btnCentrarEje
            // 
            this.btnCentrarEje.Location = new System.Drawing.Point(12, 55);
            this.btnCentrarEje.Name = "btnCentrarEje";
            this.btnCentrarEje.Size = new System.Drawing.Size(121, 23);
            this.btnCentrarEje.TabIndex = 16;
            this.btnCentrarEje.Text = "CENTRAR EJE";
            this.btnCentrarEje.UseVisualStyleBackColor = true;
            this.btnCentrarEje.Click += new System.EventHandler(this.btnCentrarEje_Click);
            // 
            // FormEscenario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 661);
            this.Controls.Add(this.btnCentrarEje);
            this.Controls.Add(this.lblPunto);
            this.Controls.Add(this.lblLastPoint);
            this.Controls.Add(this.lblObjeto);
            this.Controls.Add(this.lblPol);
            this.Controls.Add(this.btnObjeto);
            this.Controls.Add(this.btnPolCerrado);
            this.Controls.Add(this.btnPolAbierto);
            this.Controls.Add(this.rbGrupo);
            this.Controls.Add(this.ejeVisible);
            this.Controls.Add(this.msnlbl);
            this.Controls.Add(this.PanelDibujo);
            this.Name = "FormEscenario";
            this.Text = "Proyecto Prog. Grafica";
            this.Load += new System.EventHandler(this.FormEscenario_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormEscenario_Paint);
            this.Resize += new System.EventHandler(this.FormEscenario_Resize);
            this.rbGrupo.ResumeLayout(false);
            this.rbGrupo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel PanelDibujo;
        private System.Windows.Forms.Label msnlbl;
        private System.Windows.Forms.CheckBox ejeVisible;
        private System.Windows.Forms.RadioButton rbEjeFijado;
        private System.Windows.Forms.RadioButton rbDibujar;
        private System.Windows.Forms.GroupBox rbGrupo;
        private System.Windows.Forms.Button btnPolAbierto;
        private System.Windows.Forms.Button btnPolCerrado;
        private System.Windows.Forms.Button btnObjeto;
        private System.Windows.Forms.Label lblPol;
        private System.Windows.Forms.Label lblObjeto;
        private System.Windows.Forms.Label lblLastPoint;
        private System.Windows.Forms.Label lblPunto;
        private System.Windows.Forms.Button btnCentrarEje;
    }
}

