namespace EditorDeGrafos
{
    partial class Ciclos
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
            this.Pausa = new System.Windows.Forms.Button();
            this.Play = new System.Windows.Forms.Button();
            this.comboCiclos = new System.Windows.Forms.ComboBox();
            this.velocidadBar = new System.Windows.Forms.TrackBar();
            this.richTextCiclos = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridAristas = new System.Windows.Forms.DataGridView();
            this.Color = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Aristas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.velocidadBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAristas)).BeginInit();
            this.SuspendLayout();
            // 
            // Cerrar
            // 
            this.Cerrar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Cerrar.Location = new System.Drawing.Point(331, 161);
            this.Cerrar.Name = "Cerrar";
            this.Cerrar.Size = new System.Drawing.Size(75, 23);
            this.Cerrar.TabIndex = 0;
            this.Cerrar.Text = "Cerrar";
            this.Cerrar.UseVisualStyleBackColor = true;
            this.Cerrar.Click += new System.EventHandler(this.Cerrar_Click);
            // 
            // Pausa
            // 
            this.Pausa.Location = new System.Drawing.Point(493, 90);
            this.Pausa.Name = "Pausa";
            this.Pausa.Size = new System.Drawing.Size(75, 23);
            this.Pausa.TabIndex = 1;
            this.Pausa.Text = "Pausa";
            this.Pausa.UseVisualStyleBackColor = true;
            this.Pausa.Click += new System.EventHandler(this.Pausa_Click);
            // 
            // Play
            // 
            this.Play.Location = new System.Drawing.Point(596, 90);
            this.Play.Name = "Play";
            this.Play.Size = new System.Drawing.Size(75, 23);
            this.Play.TabIndex = 2;
            this.Play.Text = "Play";
            this.Play.UseVisualStyleBackColor = true;
            this.Play.Click += new System.EventHandler(this.Play_Click);
            // 
            // comboCiclos
            // 
            this.comboCiclos.FormattingEnabled = true;
            this.comboCiclos.Location = new System.Drawing.Point(369, 12);
            this.comboCiclos.Name = "comboCiclos";
            this.comboCiclos.Size = new System.Drawing.Size(64, 21);
            this.comboCiclos.TabIndex = 3;
            this.comboCiclos.SelectedIndexChanged += new System.EventHandler(this.comboCiclos_SelectedIndexChanged);
            // 
            // velocidadBar
            // 
            this.velocidadBar.Location = new System.Drawing.Point(493, 39);
            this.velocidadBar.Maximum = 5;
            this.velocidadBar.Minimum = 1;
            this.velocidadBar.Name = "velocidadBar";
            this.velocidadBar.Size = new System.Drawing.Size(178, 45);
            this.velocidadBar.TabIndex = 4;
            this.velocidadBar.Value = 1;
            this.velocidadBar.Scroll += new System.EventHandler(this.velocidadBar_Scroll);
            // 
            // richTextCiclos
            // 
            this.richTextCiclos.Location = new System.Drawing.Point(331, 39);
            this.richTextCiclos.Name = "richTextCiclos";
            this.richTextCiclos.Size = new System.Drawing.Size(156, 116);
            this.richTextCiclos.TabIndex = 5;
            this.richTextCiclos.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(328, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Ciclos:";
            // 
            // dataGridAristas
            // 
            this.dataGridAristas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridAristas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridAristas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridAristas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Color,
            this.Tipo,
            this.Aristas});
            this.dataGridAristas.Location = new System.Drawing.Point(12, 12);
            this.dataGridAristas.Name = "dataGridAristas";
            this.dataGridAristas.ReadOnly = true;
            this.dataGridAristas.RowHeadersVisible = false;
            this.dataGridAristas.Size = new System.Drawing.Size(310, 150);
            this.dataGridAristas.TabIndex = 7;
            // 
            // Color
            // 
            this.Color.HeaderText = "Color";
            this.Color.Name = "Color";
            this.Color.ReadOnly = true;
            this.Color.Width = 56;
            // 
            // Tipo
            // 
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            this.Tipo.ReadOnly = true;
            this.Tipo.Width = 53;
            // 
            // Aristas
            // 
            this.Aristas.HeaderText = "Aristas";
            this.Aristas.Name = "Aristas";
            this.Aristas.ReadOnly = true;
            this.Aristas.Width = 63;
            // 
            // Ciclos
            // 
            this.AcceptButton = this.Cerrar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 196);
            this.ControlBox = false;
            this.Controls.Add(this.dataGridAristas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextCiclos);
            this.Controls.Add(this.velocidadBar);
            this.Controls.Add(this.comboCiclos);
            this.Controls.Add(this.Play);
            this.Controls.Add(this.Pausa);
            this.Controls.Add(this.Cerrar);
            this.Name = "Ciclos";
            this.Text = "Ciclos";
            this.Load += new System.EventHandler(this.Ciclos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.velocidadBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAristas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Cerrar;
        private System.Windows.Forms.Button Pausa;
        private System.Windows.Forms.Button Play;
        private System.Windows.Forms.ComboBox comboCiclos;
        private System.Windows.Forms.TrackBar velocidadBar;
        private System.Windows.Forms.RichTextBox richTextCiclos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridAristas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Color;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Aristas;
    }
}