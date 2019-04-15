namespace EditorDeGrafos
{
    partial class Dijkstra
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
            this.DataGridMatriz = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboOrigen = new System.Windows.Forms.ComboBox();
            this.comboDestino = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridVector = new System.Windows.Forms.DataGridView();
            this.Nodo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Peso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.richTextBoxRecorrido = new System.Windows.Forms.RichTextBox();
            this.Pause = new System.Windows.Forms.Button();
            this.Play = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Cerrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridMatriz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridVector)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridMatriz
            // 
            this.DataGridMatriz.AllowUserToAddRows = false;
            this.DataGridMatriz.AllowUserToDeleteRows = false;
            this.DataGridMatriz.AllowUserToResizeColumns = false;
            this.DataGridMatriz.AllowUserToResizeRows = false;
            this.DataGridMatriz.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridMatriz.Cursor = System.Windows.Forms.Cursors.Default;
            this.DataGridMatriz.GridColor = System.Drawing.SystemColors.Control;
            this.DataGridMatriz.Location = new System.Drawing.Point(12, 12);
            this.DataGridMatriz.Name = "DataGridMatriz";
            this.DataGridMatriz.RowHeadersVisible = false;
            this.DataGridMatriz.ShowCellErrors = false;
            this.DataGridMatriz.ShowCellToolTips = false;
            this.DataGridMatriz.ShowEditingIcon = false;
            this.DataGridMatriz.ShowRowErrors = false;
            this.DataGridMatriz.Size = new System.Drawing.Size(367, 212);
            this.DataGridMatriz.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 237);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 32;
            this.label5.Text = "Origen";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(107, 237);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 31;
            this.label4.Text = "Destino";
            // 
            // comboOrigen
            // 
            this.comboOrigen.FormattingEnabled = true;
            this.comboOrigen.Location = new System.Drawing.Point(12, 253);
            this.comboOrigen.Name = "comboOrigen";
            this.comboOrigen.Size = new System.Drawing.Size(75, 21);
            this.comboOrigen.TabIndex = 30;
            this.comboOrigen.SelectedIndexChanged += new System.EventHandler(this.comboOrigen_SelectedIndexChanged);
            // 
            // comboDestino
            // 
            this.comboDestino.FormattingEnabled = true;
            this.comboDestino.Location = new System.Drawing.Point(93, 253);
            this.comboDestino.Name = "comboDestino";
            this.comboDestino.Size = new System.Drawing.Size(75, 21);
            this.comboDestino.TabIndex = 29;
            this.comboDestino.SelectedIndexChanged += new System.EventHandler(this.comboDestino_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(252, 230);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "Vector de origen";
            // 
            // dataGridVector
            // 
            this.dataGridVector.AllowUserToAddRows = false;
            this.dataGridVector.AllowUserToDeleteRows = false;
            this.dataGridVector.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridVector.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridVector.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nodo,
            this.Peso});
            this.dataGridVector.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridVector.Location = new System.Drawing.Point(249, 246);
            this.dataGridVector.MultiSelect = false;
            this.dataGridVector.Name = "dataGridVector";
            this.dataGridVector.RowHeadersVisible = false;
            this.dataGridVector.ShowCellErrors = false;
            this.dataGridVector.ShowCellToolTips = false;
            this.dataGridVector.ShowEditingIcon = false;
            this.dataGridVector.ShowRowErrors = false;
            this.dataGridVector.Size = new System.Drawing.Size(129, 148);
            this.dataGridVector.TabIndex = 33;
            this.dataGridVector.TabStop = false;
            // 
            // Nodo
            // 
            this.Nodo.HeaderText = "Nodo";
            this.Nodo.Name = "Nodo";
            this.Nodo.Width = 58;
            // 
            // Peso
            // 
            this.Peso.HeaderText = "Peso";
            this.Peso.Name = "Peso";
            this.Peso.Width = 58;
            // 
            // richTextBoxRecorrido
            // 
            this.richTextBoxRecorrido.Location = new System.Drawing.Point(12, 295);
            this.richTextBoxRecorrido.Name = "richTextBoxRecorrido";
            this.richTextBoxRecorrido.Size = new System.Drawing.Size(156, 33);
            this.richTextBoxRecorrido.TabIndex = 38;
            this.richTextBoxRecorrido.Text = "";
            // 
            // Pause
            // 
            this.Pause.Location = new System.Drawing.Point(12, 334);
            this.Pause.Name = "Pause";
            this.Pause.Size = new System.Drawing.Size(75, 21);
            this.Pause.TabIndex = 37;
            this.Pause.Text = "| |";
            this.Pause.UseVisualStyleBackColor = true;
            this.Pause.Click += new System.EventHandler(this.Pause_Click);
            // 
            // Play
            // 
            this.Play.Location = new System.Drawing.Point(93, 334);
            this.Play.Name = "Play";
            this.Play.Size = new System.Drawing.Size(75, 21);
            this.Play.TabIndex = 36;
            this.Play.Text = "|>";
            this.Play.UseVisualStyleBackColor = true;
            this.Play.Click += new System.EventHandler(this.Play_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 279);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "Recorrido";
            // 
            // Cerrar
            // 
            this.Cerrar.Location = new System.Drawing.Point(168, 371);
            this.Cerrar.Name = "Cerrar";
            this.Cerrar.Size = new System.Drawing.Size(75, 23);
            this.Cerrar.TabIndex = 39;
            this.Cerrar.Text = "Cerrar";
            this.Cerrar.UseVisualStyleBackColor = true;
            this.Cerrar.Click += new System.EventHandler(this.Cerrar_Click);
            // 
            // Dijkstra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 406);
            this.ControlBox = false;
            this.Controls.Add(this.Cerrar);
            this.Controls.Add(this.richTextBoxRecorrido);
            this.Controls.Add(this.Pause);
            this.Controls.Add(this.Play);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridVector);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboOrigen);
            this.Controls.Add(this.comboDestino);
            this.Controls.Add(this.DataGridMatriz);
            this.Name = "Dijkstra";
            this.Text = "Dijkstra";
            this.Load += new System.EventHandler(this.Dijkstra_Load);
            this.Resize += new System.EventHandler(this.Dijkstra_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridMatriz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridVector)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGridMatriz;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboOrigen;
        private System.Windows.Forms.ComboBox comboDestino;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridVector;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nodo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Peso;
        private System.Windows.Forms.RichTextBox richTextBoxRecorrido;
        private System.Windows.Forms.Button Pause;
        private System.Windows.Forms.Button Play;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Cerrar;
    }
}