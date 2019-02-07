namespace EditorDeGrafos
{
    partial class PendientesyCut
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
            this.Cerrar.Location = new System.Drawing.Point(117, 100);
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
            this.dataGridCut.Size = new System.Drawing.Size(285, 82);
            this.dataGridCut.TabIndex = 1;
            // 
            // PendientesyCut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 135);
            this.ControlBox = false;
            this.Controls.Add(this.dataGridCut);
            this.Controls.Add(this.Cerrar);
            this.Name = "PendientesyCut";
            this.Text = "PendientesyCut";
            this.Load += new System.EventHandler(this.PendientesyCut_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCut)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Cerrar;
        private System.Windows.Forms.DataGridView dataGridCut;
    }
}