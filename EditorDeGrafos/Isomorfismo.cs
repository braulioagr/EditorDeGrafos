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
    partial class Isomorfismo : Form
    {

        #region Variables de Instancia
        Grafo grafo;
        List<Paso> pasos;
        #endregion

        #region Constructores
        public Isomorfismo(Grafo grafo, List<Paso> pasos)
        {
            this.grafo = grafo;
            this.pasos = pasos;
            InitializeComponent();
        }

        private void Isomorfismo_Load(object sender, EventArgs e)
        {
        }

        #endregion
        
        #region Eventos

        private void Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Isomorfismo_Resize(object sender, EventArgs e)
        {
            Size size;
            size = new Size(this.Size.Width - 40, this.Size.Height - 92);
            Pestañas.Size = size;
        }

        #endregion


    }
}
