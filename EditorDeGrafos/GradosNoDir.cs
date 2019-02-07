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
    partial class GradosNoDir : Form
    {
        #region Variables de Instancia
        GrafoNoDirigido grafo;
        #endregion

        #region Constructores
        public GradosNoDir(GrafoNoDirigido grafo)
        {
            this.grafo = grafo;
            InitializeComponent();
        }

        private void GradosNoDir_Load(object sender, EventArgs e)
        {
            foreach (Nodo busca in grafo)
            {
                this.dataGridGrados.Rows.Add("deg(" + busca.Nombre + ")", busca.Aristas.Count.ToString());
            }
            this.dataGridGrados.Rows.Add("deg(Grafo)", grafo.Aristas.ToString());
        }
        #endregion

        private void Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
