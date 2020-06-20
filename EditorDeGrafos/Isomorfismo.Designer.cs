namespace EditorDeGrafos
{
    partial class Isomorfismo
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboPasos = new System.Windows.Forms.ComboBox();
            this.dataGridG2 = new System.Windows.Forms.DataGridView();
            this.dataGridG1 = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridIntecambios = new System.Windows.Forms.DataGridView();
            this.Original = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cambio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridG2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridG1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridIntecambios)).BeginInit();
            this.SuspendLayout();
            // 
            // Cerrar
            // 
            this.Cerrar.Location = new System.Drawing.Point(347, 230);
            this.Cerrar.Name = "Cerrar";
            this.Cerrar.Size = new System.Drawing.Size(75, 23);
            this.Cerrar.TabIndex = 1;
            this.Cerrar.Text = "Cerrar";
            this.Cerrar.UseVisualStyleBackColor = true;
            this.Cerrar.Click += new System.EventHandler(this.Cerrar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(639, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Matrices";
            // 
            // comboPasos
            // 
            this.comboPasos.FormattingEnabled = true;
            this.comboPasos.Location = new System.Drawing.Point(692, 6);
            this.comboPasos.Name = "comboPasos";
            this.comboPasos.Size = new System.Drawing.Size(67, 21);
            this.comboPasos.TabIndex = 6;
            this.comboPasos.SelectedIndexChanged += new System.EventHandler(this.comboPasos_SelectedIndexChanged);
            // 
            // dataGridG2
            // 
            this.dataGridG2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridG2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridG2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridG2.Location = new System.Drawing.Point(472, 32);
            this.dataGridG2.Name = "dataGridG2";
            this.dataGridG2.RowHeadersVisible = false;
            this.dataGridG2.Size = new System.Drawing.Size(287, 189);
            this.dataGridG2.TabIndex = 5;
            // 
            // dataGridG1
            // 
            this.dataGridG1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridG1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridG1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridG1.Location = new System.Drawing.Point(15, 32);
            this.dataGridG1.Name = "dataGridG1";
            this.dataGridG1.RowHeadersVisible = false;
            this.dataGridG1.Size = new System.Drawing.Size(287, 189);
            this.dataGridG1.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Grafo Original";
            // 
            // dataGridIntecambios
            // 
            this.dataGridIntecambios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridIntecambios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Original,
            this.Cambio});
            this.dataGridIntecambios.Location = new System.Drawing.Point(308, 32);
            this.dataGridIntecambios.Name = "dataGridIntecambios";
            this.dataGridIntecambios.RowHeadersVisible = false;
            this.dataGridIntecambios.Size = new System.Drawing.Size(158, 189);
            this.dataGridIntecambios.TabIndex = 11;
            // 
            // Original
            // 
            this.Original.HeaderText = "Original";
            this.Original.Name = "Original";
            this.Original.Width = 75;
            // 
            // Cambio
            // 
            this.Cambio.HeaderText = "Cambio";
            this.Cambio.Name = "Cambio";
            this.Cambio.ReadOnly = true;
            this.Cambio.Width = 75;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(305, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Nodos Intercambiados";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(469, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Grafo Secundario";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 228);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "label5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(469, 228);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "label6";
            // 
            // Isomorfismo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 262);
            this.ControlBox = false;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridIntecambios);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboPasos);
            this.Controls.Add(this.dataGridG2);
            this.Controls.Add(this.dataGridG1);
            this.Controls.Add(this.Cerrar);
            this.Name = "Isomorfismo";
            this.Text = "Isomorfismo";
            this.Load += new System.EventHandler(this.Isomorfismo_Load);
            this.Resize += new System.EventHandler(this.Isomorfismo_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridG2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridG1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridIntecambios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Cerrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboPasos;
        private System.Windows.Forms.DataGridView dataGridG2;
        private System.Windows.Forms.DataGridView dataGridG1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridIntecambios;
        private System.Windows.Forms.DataGridViewTextBoxColumn Original;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cambio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}