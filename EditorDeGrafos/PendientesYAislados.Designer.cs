namespace EditorDeGrafos
{
    partial class PendientesYAislados
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
            this.Cerrar = new System.Windows.Forms.Button();
            this.dataGridCut = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCut)).BeginInit();
            this.SuspendLayout();
            // 
            // Cerrar
            // 
            this.Cerrar.Location = new System.Drawing.Point(177, 137);
            this.Cerrar.Name = "Cerrar";
            this.Cerrar.Size = new System.Drawing.Size(75, 23);
            this.Cerrar.TabIndex = 0;
            this.Cerrar.Text = "Cerrar";
            this.Cerrar.UseVisualStyleBackColor = true;
            this.Cerrar.Click += new System.EventHandler(this.Cerrar_Click);
            // 
            // dataGridCut
            // 
            this.dataGridCut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridCut.ColumnHeadersVisible = false;
            this.dataGridCut.Location = new System.Drawing.Point(12, 12);
            this.dataGridCut.Name = "dataGridCut";
            this.dataGridCut.RowHeadersVisible = false;
            this.dataGridCut.Size = new System.Drawing.Size(403, 119);
            this.dataGridCut.TabIndex = 1;
            // 
            // PendientesYAislados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 172);
            this.ControlBox = false;
            this.Controls.Add(this.dataGridCut);
            this.Controls.Add(this.Cerrar);
            this.Name = "PendientesYAislados";
            this.Text = "Soportes y Pendientes";
            this.Load += new System.EventHandler(this.PendientesyCut_Load);
            this.Resize += new System.EventHandler(this.PendientesYAislados_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCut)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Cerrar;
        private System.Windows.Forms.DataGridView dataGridCut;
    }
}