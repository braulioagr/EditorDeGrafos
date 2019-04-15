namespace EditorDeGrafos
{
    partial class Partitas
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
            this.dataGridPartitas = new System.Windows.Forms.DataGridView();
            this.Conjuntos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nodos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cerrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPartitas)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridPartitas
            // 
            this.dataGridPartitas.AllowUserToAddRows = false;
            this.dataGridPartitas.AllowUserToDeleteRows = false;
            this.dataGridPartitas.AllowUserToOrderColumns = true;
            this.dataGridPartitas.CausesValidation = false;
            this.dataGridPartitas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridPartitas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Conjuntos,
            this.Nodos});
            this.dataGridPartitas.Location = new System.Drawing.Point(13, 13);
            this.dataGridPartitas.Name = "dataGridPartitas";
            this.dataGridPartitas.RowHeadersVisible = false;
            this.dataGridPartitas.ShowCellErrors = false;
            this.dataGridPartitas.ShowCellToolTips = false;
            this.dataGridPartitas.ShowEditingIcon = false;
            this.dataGridPartitas.ShowRowErrors = false;
            this.dataGridPartitas.Size = new System.Drawing.Size(259, 236);
            this.dataGridPartitas.TabIndex = 0;
            // 
            // Conjuntos
            // 
            this.Conjuntos.HeaderText = "Conjunto";
            this.Conjuntos.Name = "Conjuntos";
            this.Conjuntos.Width = 128;
            // 
            // Nodos
            // 
            this.Nodos.HeaderText = "Nodos";
            this.Nodos.Name = "Nodos";
            this.Nodos.Width = 128;
            // 
            // Cerrar
            // 
            this.Cerrar.Location = new System.Drawing.Point(107, 260);
            this.Cerrar.Name = "Cerrar";
            this.Cerrar.Size = new System.Drawing.Size(75, 23);
            this.Cerrar.TabIndex = 1;
            this.Cerrar.Text = "Cerrar";
            this.Cerrar.UseVisualStyleBackColor = true;
            this.Cerrar.Click += new System.EventHandler(this.Cerrar_Click_1);
            // 
            // Partitas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 295);
            this.Controls.Add(this.Cerrar);
            this.Controls.Add(this.dataGridPartitas);
            this.Name = "Partitas";
            this.Text = "Colores";
            this.Load += new System.EventHandler(this.Partitas_Load);
            this.Resize += new System.EventHandler(this.Partitas_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPartitas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridPartitas;
        private System.Windows.Forms.Button Cerrar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Conjuntos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nodos;
    }
}