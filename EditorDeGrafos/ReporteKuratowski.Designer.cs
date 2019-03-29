namespace EditorDeGrafos
{
    partial class ReporteKuratowski
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
            this.dataGridViewResultante = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBoxReporte = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridViewOriginal = new System.Windows.Forms.DataGridView();
            this.Cerrar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridLista = new System.Windows.Forms.DataGridView();
            this.Nodo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Adyacencias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.richTextBoxAdvertencia = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResultante)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLista)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewResultante
            // 
            this.dataGridViewResultante.AllowUserToAddRows = false;
            this.dataGridViewResultante.AllowUserToDeleteRows = false;
            this.dataGridViewResultante.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewResultante.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewResultante.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewResultante.Location = new System.Drawing.Point(259, 28);
            this.dataGridViewResultante.MultiSelect = false;
            this.dataGridViewResultante.Name = "dataGridViewResultante";
            this.dataGridViewResultante.RowHeadersVisible = false;
            this.dataGridViewResultante.ShowCellErrors = false;
            this.dataGridViewResultante.ShowCellToolTips = false;
            this.dataGridViewResultante.ShowEditingIcon = false;
            this.dataGridViewResultante.ShowRowErrors = false;
            this.dataGridViewResultante.Size = new System.Drawing.Size(240, 150);
            this.dataGridViewResultante.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Matriz Original";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(261, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Matriz Resultante";
            // 
            // richTextBoxReporte
            // 
            this.richTextBoxReporte.Location = new System.Drawing.Point(12, 201);
            this.richTextBoxReporte.Name = "richTextBoxReporte";
            this.richTextBoxReporte.Size = new System.Drawing.Size(355, 96);
            this.richTextBoxReporte.TabIndex = 4;
            this.richTextBoxReporte.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Reporte";
            // 
            // dataGridViewOriginal
            // 
            this.dataGridViewOriginal.AllowUserToAddRows = false;
            this.dataGridViewOriginal.AllowUserToDeleteRows = false;
            this.dataGridViewOriginal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewOriginal.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewOriginal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOriginal.Location = new System.Drawing.Point(12, 28);
            this.dataGridViewOriginal.MultiSelect = false;
            this.dataGridViewOriginal.Name = "dataGridViewOriginal";
            this.dataGridViewOriginal.RowHeadersVisible = false;
            this.dataGridViewOriginal.ShowCellErrors = false;
            this.dataGridViewOriginal.ShowCellToolTips = false;
            this.dataGridViewOriginal.ShowEditingIcon = false;
            this.dataGridViewOriginal.ShowRowErrors = false;
            this.dataGridViewOriginal.Size = new System.Drawing.Size(240, 150);
            this.dataGridViewOriginal.TabIndex = 6;
            // 
            // Cerrar
            // 
            this.Cerrar.Location = new System.Drawing.Point(324, 305);
            this.Cerrar.Name = "Cerrar";
            this.Cerrar.Size = new System.Drawing.Size(75, 23);
            this.Cerrar.TabIndex = 7;
            this.Cerrar.Text = "Cerrar";
            this.Cerrar.UseVisualStyleBackColor = true;
            this.Cerrar.Click += new System.EventHandler(this.Cerrar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(508, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Lista de Adyacencia";
            // 
            // dataGridLista
            // 
            this.dataGridLista.AllowUserToAddRows = false;
            this.dataGridLista.AllowUserToDeleteRows = false;
            this.dataGridLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridLista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nodo,
            this.Adyacencias});
            this.dataGridLista.Location = new System.Drawing.Point(505, 28);
            this.dataGridLista.MultiSelect = false;
            this.dataGridLista.Name = "dataGridLista";
            this.dataGridLista.RowHeadersVisible = false;
            this.dataGridLista.ShowCellErrors = false;
            this.dataGridLista.ShowCellToolTips = false;
            this.dataGridLista.ShowEditingIcon = false;
            this.dataGridLista.ShowRowErrors = false;
            this.dataGridLista.Size = new System.Drawing.Size(207, 150);
            this.dataGridLista.TabIndex = 10;
            // 
            // Nodo
            // 
            this.Nodo.HeaderText = "Nodo";
            this.Nodo.Name = "Nodo";
            // 
            // Adyacencias
            // 
            this.Adyacencias.HeaderText = "Adyacencias";
            this.Adyacencias.Name = "Adyacencias";
            // 
            // richTextBoxAdvertencia
            // 
            this.richTextBoxAdvertencia.Location = new System.Drawing.Point(374, 201);
            this.richTextBoxAdvertencia.Name = "richTextBoxAdvertencia";
            this.richTextBoxAdvertencia.Size = new System.Drawing.Size(337, 96);
            this.richTextBoxAdvertencia.TabIndex = 11;
            this.richTextBoxAdvertencia.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(377, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Advertencia";
            // 
            // ReporteKuratowski
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 340);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.richTextBoxAdvertencia);
            this.Controls.Add(this.dataGridLista);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Cerrar);
            this.Controls.Add(this.dataGridViewOriginal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.richTextBoxReporte);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewResultante);
            this.Name = "ReporteKuratowski";
            this.Text = "ReporteKuratowski";
            this.Load += new System.EventHandler(this.ReporteKuratowski_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResultante)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOriginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLista)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewResultante;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBoxReporte;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridViewOriginal;
        private System.Windows.Forms.Button Cerrar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridLista;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nodo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Adyacencias;
        private System.Windows.Forms.RichTextBox richTextBoxAdvertencia;
        private System.Windows.Forms.Label label5;
    }
}