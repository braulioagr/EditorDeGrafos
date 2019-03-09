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
            this.Pestañas = new System.Windows.Forms.TabControl();
            this.Iteraciones = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridG1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboPasos = new System.Windows.Forms.ComboBox();
            this.dataGridG2 = new System.Windows.Forms.DataGridView();
            this.GrafoFinal = new System.Windows.Forms.TabPage();
            this.Cerrar = new System.Windows.Forms.Button();
            this.Pestañas.SuspendLayout();
            this.Iteraciones.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridG1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridG2)).BeginInit();
            this.SuspendLayout();
            // 
            // Pestañas
            // 
            this.Pestañas.Controls.Add(this.Iteraciones);
            this.Pestañas.Controls.Add(this.GrafoFinal);
            this.Pestañas.Location = new System.Drawing.Point(12, 12);
            this.Pestañas.Name = "Pestañas";
            this.Pestañas.SelectedIndex = 0;
            this.Pestañas.Size = new System.Drawing.Size(890, 331);
            this.Pestañas.TabIndex = 0;
            // 
            // Iteraciones
            // 
            this.Iteraciones.Controls.Add(this.groupBox2);
            this.Iteraciones.Controls.Add(this.groupBox1);
            this.Iteraciones.Location = new System.Drawing.Point(4, 22);
            this.Iteraciones.Name = "Iteraciones";
            this.Iteraciones.Padding = new System.Windows.Forms.Padding(3);
            this.Iteraciones.Size = new System.Drawing.Size(882, 305);
            this.Iteraciones.TabIndex = 0;
            this.Iteraciones.Text = "Iteraciones";
            this.Iteraciones.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridG1);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(403, 274);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Grafo Original";
            // 
            // dataGridG1
            // 
            this.dataGridG1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridG1.Location = new System.Drawing.Point(6, 65);
            this.dataGridG1.Name = "dataGridG1";
            this.dataGridG1.Size = new System.Drawing.Size(391, 189);
            this.dataGridG1.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboPasos);
            this.groupBox1.Controls.Add(this.dataGridG2);
            this.groupBox1.Location = new System.Drawing.Point(492, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(384, 274);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Iteraciones";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(80, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Intercambio: x->y";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Pasos";
            // 
            // comboPasos
            // 
            this.comboPasos.FormattingEnabled = true;
            this.comboPasos.Location = new System.Drawing.Point(7, 38);
            this.comboPasos.Name = "comboPasos";
            this.comboPasos.Size = new System.Drawing.Size(67, 21);
            this.comboPasos.TabIndex = 1;
            // 
            // dataGridG2
            // 
            this.dataGridG2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridG2.Location = new System.Drawing.Point(6, 65);
            this.dataGridG2.Name = "dataGridG2";
            this.dataGridG2.Size = new System.Drawing.Size(372, 189);
            this.dataGridG2.TabIndex = 0;
            // 
            // GrafoFinal
            // 
            this.GrafoFinal.Location = new System.Drawing.Point(4, 22);
            this.GrafoFinal.Name = "GrafoFinal";
            this.GrafoFinal.Padding = new System.Windows.Forms.Padding(3);
            this.GrafoFinal.Size = new System.Drawing.Size(882, 305);
            this.GrafoFinal.TabIndex = 1;
            this.GrafoFinal.Text = "Grafo Final";
            this.GrafoFinal.UseVisualStyleBackColor = true;
            // 
            // Cerrar
            // 
            this.Cerrar.Location = new System.Drawing.Point(424, 350);
            this.Cerrar.Name = "Cerrar";
            this.Cerrar.Size = new System.Drawing.Size(75, 23);
            this.Cerrar.TabIndex = 1;
            this.Cerrar.Text = "Cerrar";
            this.Cerrar.UseVisualStyleBackColor = true;
            this.Cerrar.Click += new System.EventHandler(this.Cerrar_Click);
            // 
            // Isomorfismo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 382);
            this.ControlBox = false;
            this.Controls.Add(this.Cerrar);
            this.Controls.Add(this.Pestañas);
            this.Name = "Isomorfismo";
            this.Text = "Isomorfismo";
            this.Load += new System.EventHandler(this.Isomorfismo_Load);
            this.Resize += new System.EventHandler(this.Isomorfismo_Resize);
            this.Pestañas.ResumeLayout(false);
            this.Iteraciones.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridG1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridG2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl Pestañas;
        private System.Windows.Forms.TabPage Iteraciones;
        private System.Windows.Forms.Button Cerrar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridG1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboPasos;
        private System.Windows.Forms.DataGridView dataGridG2;
        private System.Windows.Forms.TabPage GrafoFinal;
    }
}