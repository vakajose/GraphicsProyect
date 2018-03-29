namespace GraphicsProyect
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.PanelDibujo = new System.Windows.Forms.Panel();
            this.msnlbl = new System.Windows.Forms.Label();
            this.ejeVisible = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(112, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // PanelDibujo
            // 
            this.PanelDibujo.BackColor = System.Drawing.SystemColors.Window;
            this.PanelDibujo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelDibujo.Location = new System.Drawing.Point(12, 50);
            this.PanelDibujo.Name = "PanelDibujo";
            this.PanelDibujo.Size = new System.Drawing.Size(1060, 599);
            this.PanelDibujo.TabIndex = 2;
            this.PanelDibujo.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelDibujo_Paint);
            this.PanelDibujo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PanelDibujo_MouseClick);
            // 
            // msnlbl
            // 
            this.msnlbl.AutoSize = true;
            this.msnlbl.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.msnlbl.Location = new System.Drawing.Point(913, 22);
            this.msnlbl.Name = "msnlbl";
            this.msnlbl.Size = new System.Drawing.Size(95, 13);
            this.msnlbl.TabIndex = 3;
            this.msnlbl.Text = "Click para fijar ejes";
            // 
            // ejeVisible
            // 
            this.ejeVisible.AutoSize = true;
            this.ejeVisible.Location = new System.Drawing.Point(211, 16);
            this.ejeVisible.Name = "ejeVisible";
            this.ejeVisible.Size = new System.Drawing.Size(70, 17);
            this.ejeVisible.TabIndex = 4;
            this.ejeVisible.Text = "ejeVisible";
            this.ejeVisible.UseVisualStyleBackColor = true;
            this.ejeVisible.CheckedChanged += new System.EventHandler(this.ejeVisible_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 661);
            this.Controls.Add(this.ejeVisible);
            this.Controls.Add(this.msnlbl);
            this.Controls.Add(this.PanelDibujo);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel PanelDibujo;
        private System.Windows.Forms.Label msnlbl;
        private System.Windows.Forms.CheckBox ejeVisible;
    }
}

