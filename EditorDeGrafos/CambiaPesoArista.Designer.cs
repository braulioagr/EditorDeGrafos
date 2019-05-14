namespace EditorDeGrafos
{
    partial class CambiaPesoArista
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
            this.Cancel = new System.Windows.Forms.Button();
            this.Aceptar = new System.Windows.Forms.Button();
            this.comboAristas = new System.Windows.Forms.ComboBox();
            this.numericPeso = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericPeso)).BeginInit();
            this.SuspendLayout();
            // 
            // Cancel
            // 
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Location = new System.Drawing.Point(12, 39);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 0;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            // 
            // Aceptar
            // 
            this.Aceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Aceptar.Location = new System.Drawing.Point(109, 39);
            this.Aceptar.Name = "Aceptar";
            this.Aceptar.Size = new System.Drawing.Size(75, 23);
            this.Aceptar.TabIndex = 1;
            this.Aceptar.Text = "Aceptar";
            this.Aceptar.UseVisualStyleBackColor = true;
            // 
            // comboAristas
            // 
            this.comboAristas.FormattingEnabled = true;
            this.comboAristas.Location = new System.Drawing.Point(12, 12);
            this.comboAristas.Name = "comboAristas";
            this.comboAristas.Size = new System.Drawing.Size(75, 21);
            this.comboAristas.TabIndex = 2;
            this.comboAristas.SelectedIndexChanged += new System.EventHandler(this.comboAristas_SelectedIndexChanged);
            // 
            // numericPeso
            // 
            this.numericPeso.Location = new System.Drawing.Point(109, 12);
            this.numericPeso.Name = "numericPeso";
            this.numericPeso.Size = new System.Drawing.Size(75, 20);
            this.numericPeso.TabIndex = 3;
            // 
            // CambiaPesoArista
            // 
            this.AcceptButton = this.Aceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel;
            this.ClientSize = new System.Drawing.Size(196, 70);
            this.ControlBox = false;
            this.Controls.Add(this.numericPeso);
            this.Controls.Add(this.comboAristas);
            this.Controls.Add(this.Aceptar);
            this.Controls.Add(this.Cancel);
            this.Name = "CambiaPesoArista";
            this.Text = "CambiaPesoArista";
            this.Load += new System.EventHandler(this.CambiaPesoArista_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericPeso)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button Aceptar;
        private System.Windows.Forms.ComboBox comboAristas;
        private System.Windows.Forms.NumericUpDown numericPeso;
    }
}