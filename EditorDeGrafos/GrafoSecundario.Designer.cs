namespace EditorDeGrafos
{
    partial class GrafoSecundario
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GrafoSecundario));
            this.toolBar = new System.Windows.Forms.ToolStrip();
            this.Aceptar = new System.Windows.Forms.Button();
            this.Cancelar = new System.Windows.Forms.Button();
            this.CrearNodo = new System.Windows.Forms.ToolStripButton();
            this.MoverNodo = new System.Windows.Forms.ToolStripButton();
            this.EliminarNodo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.AristaNoDirigida = new System.Windows.Forms.ToolStripButton();
            this.AristaDirigida = new System.Windows.Forms.ToolStripButton();
            this.EliminarArista = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.MoverGrafo = new System.Windows.Forms.ToolStripButton();
            this.EliminarGrafo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.Guardar = new System.Windows.Forms.ToolStripButton();
            this.Abrir = new System.Windows.Forms.ToolStripButton();
            this.toolBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolBar
            // 
            this.toolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Abrir,
            this.Guardar,
            this.toolStripSeparator3,
            this.CrearNodo,
            this.MoverNodo,
            this.EliminarNodo,
            this.toolStripSeparator1,
            this.AristaNoDirigida,
            this.AristaDirigida,
            this.EliminarArista,
            this.toolStripSeparator2,
            this.MoverGrafo,
            this.EliminarGrafo});
            this.toolBar.Location = new System.Drawing.Point(0, 0);
            this.toolBar.Name = "toolBar";
            this.toolBar.Size = new System.Drawing.Size(753, 37);
            this.toolBar.TabIndex = 0;
            this.toolBar.Text = "toolStrip1";
            this.toolBar.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.Grafo_Clicked);
            // 
            // Aceptar
            // 
            this.Aceptar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Aceptar.Location = new System.Drawing.Point(666, 365);
            this.Aceptar.Name = "Aceptar";
            this.Aceptar.Size = new System.Drawing.Size(75, 23);
            this.Aceptar.TabIndex = 1;
            this.Aceptar.Text = "Aceptar";
            this.Aceptar.UseVisualStyleBackColor = true;
            this.Aceptar.Click += new System.EventHandler(this.Aceptar_Click);
            // 
            // Cancelar
            // 
            this.Cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancelar.Location = new System.Drawing.Point(12, 365);
            this.Cancelar.Name = "Cancelar";
            this.Cancelar.Size = new System.Drawing.Size(75, 23);
            this.Cancelar.TabIndex = 2;
            this.Cancelar.Text = "Cancelar";
            this.Cancelar.UseVisualStyleBackColor = true;
            this.Cancelar.Click += new System.EventHandler(this.Cancelar_Click);
            // 
            // CrearNodo
            // 
            this.CrearNodo.AccessibleName = "CrearNodo";
            this.CrearNodo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CrearNodo.Image = ((System.Drawing.Image)(resources.GetObject("CrearNodo.Image")));
            this.CrearNodo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.CrearNodo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CrearNodo.Name = "CrearNodo";
            this.CrearNodo.Size = new System.Drawing.Size(34, 34);
            this.CrearNodo.Text = "toolStripButton1";
            // 
            // MoverNodo
            // 
            this.MoverNodo.AccessibleName = "MoverNodo";
            this.MoverNodo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MoverNodo.Image = ((System.Drawing.Image)(resources.GetObject("MoverNodo.Image")));
            this.MoverNodo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MoverNodo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MoverNodo.Name = "MoverNodo";
            this.MoverNodo.Size = new System.Drawing.Size(34, 34);
            this.MoverNodo.Text = "Mover Nodo";
            // 
            // EliminarNodo
            // 
            this.EliminarNodo.AccessibleName = "EliminarNodo";
            this.EliminarNodo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.EliminarNodo.Image = ((System.Drawing.Image)(resources.GetObject("EliminarNodo.Image")));
            this.EliminarNodo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.EliminarNodo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EliminarNodo.Name = "EliminarNodo";
            this.EliminarNodo.Size = new System.Drawing.Size(34, 34);
            this.EliminarNodo.Text = "Eliminar Nodo";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 37);
            // 
            // AristaNoDirigida
            // 
            this.AristaNoDirigida.AccessibleName = "AristaNoDirigida";
            this.AristaNoDirigida.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AristaNoDirigida.Image = ((System.Drawing.Image)(resources.GetObject("AristaNoDirigida.Image")));
            this.AristaNoDirigida.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.AristaNoDirigida.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AristaNoDirigida.Name = "AristaNoDirigida";
            this.AristaNoDirigida.Size = new System.Drawing.Size(34, 34);
            this.AristaNoDirigida.Text = "Arista No Dirigida";
            // 
            // AristaDirigida
            // 
            this.AristaDirigida.AccessibleName = "AristaDirigida";
            this.AristaDirigida.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AristaDirigida.Image = ((System.Drawing.Image)(resources.GetObject("AristaDirigida.Image")));
            this.AristaDirigida.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.AristaDirigida.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AristaDirigida.Name = "AristaDirigida";
            this.AristaDirigida.Size = new System.Drawing.Size(34, 34);
            this.AristaDirigida.Text = "Arista Dirigida";
            // 
            // EliminarArista
            // 
            this.EliminarArista.AccessibleName = "EliminarArista";
            this.EliminarArista.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.EliminarArista.Image = ((System.Drawing.Image)(resources.GetObject("EliminarArista.Image")));
            this.EliminarArista.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.EliminarArista.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EliminarArista.Name = "EliminarArista";
            this.EliminarArista.Size = new System.Drawing.Size(34, 34);
            this.EliminarArista.Text = "Eliminar Arista";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 37);
            // 
            // MoverGrafo
            // 
            this.MoverGrafo.AccessibleName = "MoverGrafo";
            this.MoverGrafo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MoverGrafo.Image = ((System.Drawing.Image)(resources.GetObject("MoverGrafo.Image")));
            this.MoverGrafo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MoverGrafo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MoverGrafo.Name = "MoverGrafo";
            this.MoverGrafo.Size = new System.Drawing.Size(34, 34);
            this.MoverGrafo.Text = "Mover Grafo";
            // 
            // EliminarGrafo
            // 
            this.EliminarGrafo.AccessibleName = "EliminarGrafo";
            this.EliminarGrafo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.EliminarGrafo.Image = ((System.Drawing.Image)(resources.GetObject("EliminarGrafo.Image")));
            this.EliminarGrafo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.EliminarGrafo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EliminarGrafo.Name = "EliminarGrafo";
            this.EliminarGrafo.Size = new System.Drawing.Size(34, 34);
            this.EliminarGrafo.Text = "Eliminar Grafo";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 37);
            // 
            // Guardar
            // 
            this.Guardar.AccessibleName = "Guardar";
            this.Guardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Guardar.Image = ((System.Drawing.Image)(resources.GetObject("Guardar.Image")));
            this.Guardar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Guardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Guardar.Name = "Guardar";
            this.Guardar.Size = new System.Drawing.Size(34, 34);
            this.Guardar.Text = "Guardar Grafo";
            // 
            // Abrir
            // 
            this.Abrir.AccessibleName = "Abrir";
            this.Abrir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Abrir.Image = ((System.Drawing.Image)(resources.GetObject("Abrir.Image")));
            this.Abrir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Abrir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Abrir.Name = "Abrir";
            this.Abrir.Size = new System.Drawing.Size(34, 34);
            this.Abrir.Text = "Abrir Grafo";
            // 
            // GrafoSecundario
            // 
            this.AcceptButton = this.Aceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancelar;
            this.ClientSize = new System.Drawing.Size(753, 400);
            this.Controls.Add(this.Cancelar);
            this.Controls.Add(this.Aceptar);
            this.Controls.Add(this.toolBar);
            this.Name = "GrafoSecundario";
            this.Text = "GrafoSeccundario";
            this.Load += new System.EventHandler(this.GrafoSecundario_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GrafoSecundario_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GrafoSecundario_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GrafoSecundario_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GrafoSecundario_MouseUp);
            this.Resize += new System.EventHandler(this.GrafoSecundario_Resize);
            this.toolBar.ResumeLayout(false);
            this.toolBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolBar;
        private System.Windows.Forms.Button Aceptar;
        private System.Windows.Forms.Button Cancelar;
        private System.Windows.Forms.ToolStripButton Abrir;
        private System.Windows.Forms.ToolStripButton Guardar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton CrearNodo;
        private System.Windows.Forms.ToolStripButton MoverNodo;
        private System.Windows.Forms.ToolStripButton EliminarNodo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton AristaNoDirigida;
        private System.Windows.Forms.ToolStripButton AristaDirigida;
        private System.Windows.Forms.ToolStripButton EliminarArista;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton MoverGrafo;
        private System.Windows.Forms.ToolStripButton EliminarGrafo;
    }
}