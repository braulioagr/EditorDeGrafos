namespace EditorDeGrafos
{
    partial class GradosDir
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
            this.dataGridGrados = new System.Windows.Forms.DataGridView();
            this.Cerrar = new System.Windows.Forms.Button();
            this.Nodo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GradoEntrada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GradoSalida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridGrados)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridGrados
            // 
            this.dataGridGrados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridGrados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nodo,
            this.GradoEntrada,
            this.GradoSalida});
            this.dataGridGrados.Location = new System.Drawing.Point(12, 12);
            this.dataGridGrados.Name = "dataGridGrados";
            this.dataGridGrados.RowHeadersVisible = false;
            this.dataGridGrados.Size = new System.Drawing.Size(240, 201);
            this.dataGridGrados.TabIndex = 1;
            // 
            // Cerrar
            // 
            this.Cerrar.Location = new System.Drawing.Point(96, 226);
            this.Cerrar.Name = "Cerrar";
            this.Cerrar.Size = new System.Drawing.Size(75, 23);
            this.Cerrar.TabIndex = 2;
            this.Cerrar.Text = "Cerrar";
            this.Cerrar.UseVisualStyleBackColor = true;
            this.Cerrar.Click += new System.EventHandler(this.Cerrar_Click);
            // 
            // Nodo
            // 
            this.Nodo.HeaderText = "Nodo";
            this.Nodo.Name = "Nodo";
            this.Nodo.Width = 78;
            // 
            // GradoEntrada
            // 
            this.GradoEntrada.HeaderText = "Deg(+)";
            this.GradoEntrada.Name = "GradoEntrada";
            this.GradoEntrada.Width = 78;
            // 
            // GradoSalida
            // 
            this.GradoSalida.HeaderText = "Deg(-)";
            this.GradoSalida.Name = "GradoSalida";
            this.GradoSalida.Width = 78;
            // 
            // GradosDir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 261);
            this.ControlBox = false;
            this.Controls.Add(this.Cerrar);
            this.Controls.Add(this.dataGridGrados);
            this.Name = "GradosDir";
            this.Text = "GradosDir";
            this.Load += new System.EventHandler(this.GradosDir_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridGrados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridGrados;
        private System.Windows.Forms.Button Cerrar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nodo;
        private System.Windows.Forms.DataGridViewTextBoxColumn GradoEntrada;
        private System.Windows.Forms.DataGridViewTextBoxColumn GradoSalida;
    }
}