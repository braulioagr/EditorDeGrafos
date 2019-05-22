namespace EditorDeGrafos
{
    partial class Floyd
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
            this.dataGridCostos = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridRecorridos = new System.Windows.Forms.DataGridView();
            this.Cerrar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.BarVelocidad = new System.Windows.Forms.TrackBar();
            this.richTextBoxRecorrido = new System.Windows.Forms.RichTextBox();
            this.Pause = new System.Windows.Forms.Button();
            this.Play = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboOrigen = new System.Windows.Forms.ComboBox();
            this.comboDestino = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCostos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRecorridos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarVelocidad)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridCostos
            // 
            this.dataGridCostos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridCostos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridCostos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridCostos.Location = new System.Drawing.Point(12, 32);
            this.dataGridCostos.Name = "dataGridCostos";
            this.dataGridCostos.RowHeadersVisible = false;
            this.dataGridCostos.Size = new System.Drawing.Size(264, 202);
            this.dataGridCostos.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Matriz de Costos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(285, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Matriz Resultante";
            // 
            // dataGridRecorridos
            // 
            this.dataGridRecorridos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridRecorridos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridRecorridos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridRecorridos.Location = new System.Drawing.Point(292, 32);
            this.dataGridRecorridos.Name = "dataGridRecorridos";
            this.dataGridRecorridos.RowHeadersVisible = false;
            this.dataGridRecorridos.Size = new System.Drawing.Size(258, 202);
            this.dataGridRecorridos.TabIndex = 2;
            // 
            // Cerrar
            // 
            this.Cerrar.Location = new System.Drawing.Point(247, 340);
            this.Cerrar.Name = "Cerrar";
            this.Cerrar.Size = new System.Drawing.Size(75, 23);
            this.Cerrar.TabIndex = 4;
            this.Cerrar.Text = "Cerrar";
            this.Cerrar.UseVisualStyleBackColor = true;
            this.Cerrar.Click += new System.EventHandler(this.Cerrar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(407, 245);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 52;
            this.label3.Text = "Velocidad";
            // 
            // BarVelocidad
            // 
            this.BarVelocidad.LargeChange = 1;
            this.BarVelocidad.Location = new System.Drawing.Point(292, 262);
            this.BarVelocidad.Maximum = 5;
            this.BarVelocidad.Minimum = 1;
            this.BarVelocidad.Name = "BarVelocidad";
            this.BarVelocidad.Size = new System.Drawing.Size(258, 45);
            this.BarVelocidad.TabIndex = 51;
            this.BarVelocidad.Value = 1;
            this.BarVelocidad.Scroll += new System.EventHandler(this.BarVelocidad_Scroll);
            // 
            // richTextBoxRecorrido
            // 
            this.richTextBoxRecorrido.Location = new System.Drawing.Point(12, 301);
            this.richTextBoxRecorrido.Name = "richTextBoxRecorrido";
            this.richTextBoxRecorrido.Size = new System.Drawing.Size(264, 33);
            this.richTextBoxRecorrido.TabIndex = 49;
            this.richTextBoxRecorrido.Text = "";
            // 
            // Pause
            // 
            this.Pause.Location = new System.Drawing.Point(369, 313);
            this.Pause.Name = "Pause";
            this.Pause.Size = new System.Drawing.Size(65, 21);
            this.Pause.TabIndex = 48;
            this.Pause.Text = "Pause";
            this.Pause.UseVisualStyleBackColor = true;
            this.Pause.Click += new System.EventHandler(this.Pause_Click);
            // 
            // Play
            // 
            this.Play.Location = new System.Drawing.Point(440, 313);
            this.Play.Name = "Play";
            this.Play.Size = new System.Drawing.Size(63, 21);
            this.Play.TabIndex = 47;
            this.Play.Text = "Play";
            this.Play.UseVisualStyleBackColor = true;
            this.Play.Click += new System.EventHandler(this.Play_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(97, 285);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 46;
            this.label4.Text = "Recorrido";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(62, 241);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 45;
            this.label5.Text = "Origen";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(139, 241);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 44;
            this.label6.Text = "Destino";
            // 
            // comboOrigen
            // 
            this.comboOrigen.FormattingEnabled = true;
            this.comboOrigen.Location = new System.Drawing.Point(44, 257);
            this.comboOrigen.Name = "comboOrigen";
            this.comboOrigen.Size = new System.Drawing.Size(75, 21);
            this.comboOrigen.TabIndex = 43;
            this.comboOrigen.SelectedIndexChanged += new System.EventHandler(this.comboOrigen_SelectedIndexChanged);
            // 
            // comboDestino
            // 
            this.comboDestino.FormattingEnabled = true;
            this.comboDestino.Location = new System.Drawing.Point(125, 257);
            this.comboDestino.Name = "comboDestino";
            this.comboDestino.Size = new System.Drawing.Size(75, 21);
            this.comboDestino.TabIndex = 42;
            this.comboDestino.SelectedIndexChanged += new System.EventHandler(this.comboDestino_SelectedIndexChanged);
            // 
            // Floyd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 372);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BarVelocidad);
            this.Controls.Add(this.richTextBoxRecorrido);
            this.Controls.Add(this.Pause);
            this.Controls.Add(this.Play);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboOrigen);
            this.Controls.Add(this.comboDestino);
            this.Controls.Add(this.Cerrar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridRecorridos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridCostos);
            this.Name = "Floyd";
            this.Text = "Floyd";
            this.Load += new System.EventHandler(this.Floyd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCostos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRecorridos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarVelocidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridCostos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridRecorridos;
        private System.Windows.Forms.Button Cerrar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar BarVelocidad;
        private System.Windows.Forms.RichTextBox richTextBoxRecorrido;
        private System.Windows.Forms.Button Pause;
        private System.Windows.Forms.Button Play;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboOrigen;
        private System.Windows.Forms.ComboBox comboDestino;
    }
}