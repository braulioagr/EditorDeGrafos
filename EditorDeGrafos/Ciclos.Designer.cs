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
            ((System.ComponentModel.ISupportInitialize)(this.velocidadBar)).BeginInit();
            this.SuspendLayout();
            // 
            // Cerrar
            // 
            this.Cerrar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Cerrar.Location = new System.Drawing.Point(215, 95);
            this.Cerrar.Name = "Cerrar";
            this.Cerrar.Size = new System.Drawing.Size(75, 23);
            this.Cerrar.TabIndex = 0;
            this.Cerrar.Text = "Cerrar";
            this.Cerrar.UseVisualStyleBackColor = true;
            this.Cerrar.Click += new System.EventHandler(this.Cerrar_Click);
            // 
            // Pausa
            // 
            this.Pausa.Location = new System.Drawing.Point(174, 63);
            this.Pausa.Name = "Pausa";
            this.Pausa.Size = new System.Drawing.Size(75, 23);
            this.Pausa.TabIndex = 1;
            this.Pausa.Text = "Pausa";
            this.Pausa.UseVisualStyleBackColor = true;
            this.Pausa.Click += new System.EventHandler(this.Pausa_Click);
            // 
            // Play
            // 
            this.Play.Location = new System.Drawing.Point(255, 63);
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
            this.comboCiclos.Location = new System.Drawing.Point(104, 12);
            this.comboCiclos.Name = "comboCiclos";
            this.comboCiclos.Size = new System.Drawing.Size(64, 21);
            this.comboCiclos.TabIndex = 3;
            this.comboCiclos.SelectedIndexChanged += new System.EventHandler(this.comboCiclos_SelectedIndexChanged);
            // 
            // velocidadBar
            // 
            this.velocidadBar.Location = new System.Drawing.Point(174, 12);
            this.velocidadBar.Maximum = 5;
            this.velocidadBar.Minimum = 1;
            this.velocidadBar.Name = "velocidadBar";
            this.velocidadBar.Size = new System.Drawing.Size(156, 45);
            this.velocidadBar.TabIndex = 4;
            this.velocidadBar.Value = 1;
            this.velocidadBar.Scroll += new System.EventHandler(this.velocidadBar_Scroll);
            // 
            // richTextCiclos
            // 
            this.richTextCiclos.Location = new System.Drawing.Point(12, 39);
            this.richTextCiclos.Name = "richTextCiclos";
            this.richTextCiclos.Size = new System.Drawing.Size(156, 79);
            this.richTextCiclos.TabIndex = 5;
            this.richTextCiclos.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Ciclos:";
            // 
            // Ciclos
            // 
            this.AcceptButton = this.Cerrar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 127);
            this.ControlBox = false;
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
    }
}