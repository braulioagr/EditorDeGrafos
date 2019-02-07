namespace EditorDeGrafos
{
    partial class ListaDeAdyacencia
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
            this.dataGridLista = new System.Windows.Forms.DataGridView();
            this.Cerrar = new System.Windows.Forms.Button();
            this.Nodo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Adyacencias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLista)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridLista
            // 
            this.dataGridLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridLista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nodo,
            this.Adyacencias});
            this.dataGridLista.Location = new System.Drawing.Point(12, 12);
            this.dataGridLista.Name = "dataGridLista";
            this.dataGridLista.RowHeadersVisible = false;
            this.dataGridLista.Size = new System.Drawing.Size(240, 201);
            this.dataGridLista.TabIndex = 2;
            // 
            // Cerrar
            // 
            this.Cerrar.Location = new System.Drawing.Point(96, 226);
            this.Cerrar.Name = "Cerrar";
            this.Cerrar.Size = new System.Drawing.Size(75, 23);
            this.Cerrar.TabIndex = 3;
            this.Cerrar.Text = "Cerrar";
            this.Cerrar.UseVisualStyleBackColor = true;
            this.Cerrar.Click += new System.EventHandler(this.Cerrar_Click);
            // 
            // Nodo
            // 
            this.Nodo.HeaderText = "Nodo";
            this.Nodo.Name = "Nodo";
            this.Nodo.Width = 118;
            // 
            // Adyacencias
            // 
            this.Adyacencias.HeaderText = "Adyacencias";
            this.Adyacencias.Name = "Adyacencias";
            this.Adyacencias.Width = 118;
            // 
            // ListaDeAdyacencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 261);
            this.ControlBox = false;
            this.Controls.Add(this.Cerrar);
            this.Controls.Add(this.dataGridLista);
            this.Name = "ListaDeAdyacencia";
            this.Text = "ListaDeAdyacencia";
            this.Load += new System.EventHandler(this.ListaDeAdyacencia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLista)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridLista;
        private System.Windows.Forms.Button Cerrar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nodo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Adyacencias;
    }
}