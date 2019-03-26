namespace EditorDeGrafos
{
    partial class Kuratowski
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Kuratowski));
            this.ToolBar = new System.Windows.Forms.ToolStrip();
            this.InsertaNodo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.EliminaNodo = new System.Windows.Forms.ToolStripButton();
            this.Aceptar = new System.Windows.Forms.Button();
            this.Cancelar = new System.Windows.Forms.Button();
            this.ToolBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolBar
            // 
            this.ToolBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.InsertaNodo,
            this.toolStripSeparator1,
            this.EliminaNodo});
            this.ToolBar.Location = new System.Drawing.Point(0, 0);
            this.ToolBar.Name = "ToolBar";
            this.ToolBar.Size = new System.Drawing.Size(847, 37);
            this.ToolBar.TabIndex = 0;
            this.ToolBar.Text = "ToolBar";
            this.ToolBar.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.Clicked_Kuratowski);
            // 
            // InsertaNodo
            // 
            this.InsertaNodo.AccessibleName = "InsertaNodo";
            this.InsertaNodo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.InsertaNodo.Image = ((System.Drawing.Image)(resources.GetObject("InsertaNodo.Image")));
            this.InsertaNodo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.InsertaNodo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.InsertaNodo.Name = "InsertaNodo";
            this.InsertaNodo.Size = new System.Drawing.Size(34, 34);
            this.InsertaNodo.Text = "Inserta Nodo";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 37);
            // 
            // EliminaNodo
            // 
            this.EliminaNodo.AccessibleName = "EliminaNodo";
            this.EliminaNodo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.EliminaNodo.Image = ((System.Drawing.Image)(resources.GetObject("EliminaNodo.Image")));
            this.EliminaNodo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.EliminaNodo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EliminaNodo.Name = "EliminaNodo";
            this.EliminaNodo.Size = new System.Drawing.Size(34, 34);
            this.EliminaNodo.Text = "Elimina Nodo";
            // 
            // Aceptar
            // 
            this.Aceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Aceptar.Location = new System.Drawing.Point(760, 409);
            this.Aceptar.Name = "Aceptar";
            this.Aceptar.Size = new System.Drawing.Size(75, 23);
            this.Aceptar.TabIndex = 1;
            this.Aceptar.Text = "Aceptar";
            this.Aceptar.UseVisualStyleBackColor = true;
            // 
            // Cancelar
            // 
            this.Cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancelar.Location = new System.Drawing.Point(12, 409);
            this.Cancelar.Name = "Cancelar";
            this.Cancelar.Size = new System.Drawing.Size(75, 23);
            this.Cancelar.TabIndex = 2;
            this.Cancelar.Text = "Cancelar";
            this.Cancelar.UseVisualStyleBackColor = true;
            // 
            // Kuratowski
            // 
            this.AcceptButton = this.Aceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancelar;
            this.ClientSize = new System.Drawing.Size(847, 444);
            this.Controls.Add(this.Cancelar);
            this.Controls.Add(this.Aceptar);
            this.Controls.Add(this.ToolBar);
            this.Name = "Kuratowski";
            this.Text = "Kuratowski";
            this.Load += new System.EventHandler(this.Kuratowski_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Kuratowski_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Kuratowski_MouseDown);
            this.Resize += new System.EventHandler(this.Kuratowski_Resize);
            this.ToolBar.ResumeLayout(false);
            this.ToolBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip ToolBar;
        private System.Windows.Forms.ToolStripButton InsertaNodo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton EliminaNodo;
        private System.Windows.Forms.Button Aceptar;
        private System.Windows.Forms.Button Cancelar;
    }
}