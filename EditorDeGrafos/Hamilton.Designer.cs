namespace EditorDeGrafos
{
    partial class Hamilton
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
            this.play = new System.Windows.Forms.Button();
            this.BarVelocidad = new System.Windows.Forms.TrackBar();
            this.Pausa = new System.Windows.Forms.Button();
            this.Cerrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.BarVelocidad)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBoxCamino
            // 
            this.richTextBoxCamino.Location = new System.Drawing.Point(12, 26);
            this.richTextBoxCamino.Name = "richTextBoxCamino";
            this.richTextBoxCamino.Size = new System.Drawing.Size(165, 96);
            this.richTextBoxCamino.TabIndex = 1;
            this.richTextBoxCamino.Text = "";
            // 
            // play
            // 
            this.play.Location = new System.Drawing.Point(183, 77);
            this.play.Name = "play";
            this.play.Size = new System.Drawing.Size(59, 23);
            this.play.TabIndex = 6;
            this.play.Text = "Play";
            this.play.UseVisualStyleBackColor = true;
            this.play.Click += new System.EventHandler(this.play_Click);
            // 
            // BarVelocidad
            // 
            this.BarVelocidad.Location = new System.Drawing.Point(183, 26);
            this.BarVelocidad.Name = "BarVelocidad";
            this.BarVelocidad.Size = new System.Drawing.Size(140, 45);
            this.BarVelocidad.TabIndex = 5;
            this.BarVelocidad.Scroll += new System.EventHandler(this.BarVelocidad_Scroll);
            // 
            // Pausa
            // 
            this.Pausa.Location = new System.Drawing.Point(264, 77);
            this.Pausa.Name = "Pausa";
            this.Pausa.Size = new System.Drawing.Size(59, 23);
            this.Pausa.TabIndex = 8;
            this.Pausa.Text = "Pausa";
            this.Pausa.UseVisualStyleBackColor = true;
            this.Pausa.Click += new System.EventHandler(this.Pausa_Click);
            // 
            // Cerrar
            // 
            this.Cerrar.Location = new System.Drawing.Point(130, 138);
            this.Cerrar.Name = "Cerrar";
            this.Cerrar.Size = new System.Drawing.Size(75, 23);
            this.Cerrar.TabIndex = 7;
            this.Cerrar.Text = "Cerrar";
            this.Cerrar.UseVisualStyleBackColor = true;
            this.Cerrar.Click += new System.EventHandler(this.Cerrar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Recorrido";
            // 
            // Hamilton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 176);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Pausa);
            this.Controls.Add(this.Cerrar);
            this.Controls.Add(this.play);
            this.Controls.Add(this.BarVelocidad);
            this.Controls.Add(this.richTextBoxCamino);
            this.Name = "Hamilton";
            this.Text = "Hamilton";
            this.Load += new System.EventHandler(this.Hamilton_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BarVelocidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxCamino;
        private System.Windows.Forms.Button play;
        private System.Windows.Forms.TrackBar BarVelocidad;
        private System.Windows.Forms.Button Pausa;
        private System.Windows.Forms.Button Cerrar;
        private System.Windows.Forms.Label label1;

    }
}