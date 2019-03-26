namespace EditorDeGrafos
{
    partial class Euler
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
            this.richTextBoxCamino = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BarVelocidad = new System.Windows.Forms.TrackBar();
            this.Cerrar = new System.Windows.Forms.Button();
            this.play = new System.Windows.Forms.Button();
            this.Pausa = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.BarVelocidad)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBoxCamino
            // 
            this.richTextBoxCamino.Location = new System.Drawing.Point(12, 29);
            this.richTextBoxCamino.Name = "richTextBoxCamino";
            this.richTextBoxCamino.Size = new System.Drawing.Size(165, 96);
            this.richTextBoxCamino.TabIndex = 0;
            this.richTextBoxCamino.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Recorrido";
            // 
            // BarVelocidad
            // 
            this.BarVelocidad.Location = new System.Drawing.Point(183, 29);
            this.BarVelocidad.Maximum = 5;
            this.BarVelocidad.Minimum = 1;
            this.BarVelocidad.Name = "BarVelocidad";
            this.BarVelocidad.Size = new System.Drawing.Size(140, 45);
            this.BarVelocidad.TabIndex = 2;
            this.BarVelocidad.Value = 1;
            this.BarVelocidad.Scroll += new System.EventHandler(this.BarVelocidad_Scroll);
            // 
            // Cerrar
            // 
            this.Cerrar.Location = new System.Drawing.Point(130, 141);
            this.Cerrar.Name = "Cerrar";
            this.Cerrar.Size = new System.Drawing.Size(75, 23);
            this.Cerrar.TabIndex = 3;
            this.Cerrar.Text = "Cerrar";
            this.Cerrar.UseVisualStyleBackColor = true;
            this.Cerrar.Click += new System.EventHandler(this.Cerrar_Click);
            // 
            // play
            // 
            this.play.Location = new System.Drawing.Point(183, 80);
            this.play.Name = "play";
            this.play.Size = new System.Drawing.Size(59, 23);
            this.play.TabIndex = 4;
            this.play.Text = "Play";
            this.play.UseVisualStyleBackColor = true;
            this.play.Click += new System.EventHandler(this.play_Click);
            // 
            // Pausa
            // 
            this.Pausa.Location = new System.Drawing.Point(264, 80);
            this.Pausa.Name = "Pausa";
            this.Pausa.Size = new System.Drawing.Size(59, 23);
            this.Pausa.TabIndex = 5;
            this.Pausa.Text = "Pausa";
            this.Pausa.UseVisualStyleBackColor = true;
            this.Pausa.Click += new System.EventHandler(this.Pausa_Click);
            // 
            // Euler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 176);
            this.ControlBox = false;
            this.Controls.Add(this.Pausa);
            this.Controls.Add(this.play);
            this.Controls.Add(this.Cerrar);
            this.Controls.Add(this.BarVelocidad);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBoxCamino);
            this.Name = "Euler";
            this.Text = "Euler";
            this.Load += new System.EventHandler(this.Euler_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BarVelocidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxCamino;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar BarVelocidad;
        private System.Windows.Forms.Button Cerrar;
        private System.Windows.Forms.Button play;
        private System.Windows.Forms.Button Pausa;
    }
}