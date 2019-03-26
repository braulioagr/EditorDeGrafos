namespace EditorDeGrafos
{
    partial class Corolarios
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.richTextBoxCorolario1 = new System.Windows.Forms.RichTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.richTextBoxCorolario2 = new System.Windows.Forms.RichTextBox();
            this.Cerrar = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.richTextBoxC = new System.Windows.Forms.RichTextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(13, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(269, 200);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.richTextBoxCorolario1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(261, 174);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Corolario1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // richTextBoxCorolario1
            // 
            this.richTextBoxCorolario1.Location = new System.Drawing.Point(7, 7);
            this.richTextBoxCorolario1.Name = "richTextBoxCorolario1";
            this.richTextBoxCorolario1.Size = new System.Drawing.Size(248, 164);
            this.richTextBoxCorolario1.TabIndex = 0;
            this.richTextBoxCorolario1.Text = "";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.richTextBoxCorolario2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(261, 174);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Corolario2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // richTextBoxCorolario2
            // 
            this.richTextBoxCorolario2.Location = new System.Drawing.Point(3, 6);
            this.richTextBoxCorolario2.Name = "richTextBoxCorolario2";
            this.richTextBoxCorolario2.Size = new System.Drawing.Size(251, 161);
            this.richTextBoxCorolario2.TabIndex = 0;
            this.richTextBoxCorolario2.Text = "";
            // 
            // Cerrar
            // 
            this.Cerrar.Location = new System.Drawing.Point(106, 220);
            this.Cerrar.Name = "Cerrar";
            this.Cerrar.Size = new System.Drawing.Size(75, 23);
            this.Cerrar.TabIndex = 1;
            this.Cerrar.Text = "Cerrar";
            this.Cerrar.UseVisualStyleBackColor = true;
            this.Cerrar.Click += new System.EventHandler(this.Cerrar_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.richTextBoxC);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(261, 174);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Conclusión";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // richTextBoxC
            // 
            this.richTextBoxC.Location = new System.Drawing.Point(7, 7);
            this.richTextBoxC.Name = "richTextBoxC";
            this.richTextBoxC.Size = new System.Drawing.Size(248, 161);
            this.richTextBoxC.TabIndex = 0;
            this.richTextBoxC.Text = "";
            // 
            // Corolarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 251);
            this.ControlBox = false;
            this.Controls.Add(this.Cerrar);
            this.Controls.Add(this.tabControl1);
            this.Name = "Corolarios";
            this.Text = "Corolarios";
            this.Load += new System.EventHandler(this.Corolarios_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RichTextBox richTextBoxCorolario1;
        private System.Windows.Forms.RichTextBox richTextBoxCorolario2;
        private System.Windows.Forms.Button Cerrar;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.RichTextBox richTextBoxC;
    }
}