using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditorDeGrafos
{
    public partial class MatrizDeIncidencia : Form
    {
        public MatrizDeIncidencia()
        {
            InitializeComponent();
        }

        private void MatrizDeIncidencia_Load(object sender, EventArgs e)
        {

        }

        private void MatrizDeIncidencia_Resize(object sender, EventArgs e)
        {

            Size size;
            size = new Size(this.Width - 40, this.Height - 99);
            dataGridMatriz.Size = size;
            Point punto;
            punto = new Point((this.Width / 2) - 75, this.Height - 74);
            Cerrar.Location = punto;
        }

        private void Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
