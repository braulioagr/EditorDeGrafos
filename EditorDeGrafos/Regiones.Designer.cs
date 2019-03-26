namespace EditorDeGrafos
{
    partial class Regiones
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
            this.richTextBoxRegion = new System.Windows.Forms.RichTextBox();
            this.Cerrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBoxRegion
            // 
            this.richTextBoxRegion.Location = new System.Drawing.Point(13, 13);
            this.richTextBoxRegion.Name = "richTextBoxRegion";
            this.richTextBoxRegion.Size = new System.Drawing.Size(259, 210);
            this.richTextBoxRegion.TabIndex = 0;
            this.richTextBoxRegion.Text = "";
            // 
            // Cerrar
            // 
            this.Cerrar.Location = new System.Drawing.Point(107, 229);
            this.Cerrar.Name = "Cerrar";
            this.Cerrar.Size = new System.Drawing.Size(75, 23);
            this.Cerrar.TabIndex = 1;
            this.Cerrar.Text = "Cerrar";
            this.Cerrar.UseVisualStyleBackColor = true;
            this.Cerrar.Click += new System.EventHandler(this.Cerrar_Click);
            // 
            // Regiones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.Cerrar);
            this.Controls.Add(this.richTextBoxRegion);
            this.Name = "Regiones";
            this.Text = "Regiones";
            this.Load += new System.EventHandler(this.Regiones_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxRegion;
        private System.Windows.Forms.Button Cerrar;
    }
}