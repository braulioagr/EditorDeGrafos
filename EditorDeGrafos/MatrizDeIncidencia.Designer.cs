namespace EditorDeGrafos
{
    partial class MatrizDeIncidencia
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
            this.dataGridMatriz = new System.Windows.Forms.DataGridView();
            this.Cerrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMatriz)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridMatriz
            // 
            this.dataGridMatriz.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridMatriz.Location = new System.Drawing.Point(12, 12);
            this.dataGridMatriz.Name = "dataGridMatriz";
            this.dataGridMatriz.RowHeadersVisible = false;
            this.dataGridMatriz.Size = new System.Drawing.Size(242, 201);
            this.dataGridMatriz.TabIndex = 0;
            // 
            // Cerrar
            // 
            this.Cerrar.Location = new System.Drawing.Point(96, 226);
            this.Cerrar.Name = "Cerrar";
            this.Cerrar.Size = new System.Drawing.Size(75, 23);
            this.Cerrar.TabIndex = 1;
            this.Cerrar.Text = "Cerrar";
            this.Cerrar.UseVisualStyleBackColor = true;
            this.Cerrar.Click += new System.EventHandler(this.Cerrar_Click);
            // 
            // MatrizDeIncidencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 261);
            this.ControlBox = false;
            this.Controls.Add(this.Cerrar);
            this.Controls.Add(this.dataGridMatriz);
            this.Name = "MatrizDeIncidencia";
            this.Text = "Matriz De Incidencia";
            this.Load += new System.EventHandler(this.MatrizDeIncidencia_Load);
            this.Resize += new System.EventHandler(this.MatrizDeIncidencia_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMatriz)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridMatriz;
        private System.Windows.Forms.Button Cerrar;
    }
}