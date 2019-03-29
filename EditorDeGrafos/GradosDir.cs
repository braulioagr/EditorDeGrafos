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
    partial class GradosDir : Form
    {

        #region Variables de Instancia
        private GrafoDirigido grafo;
        #endregion

        #region Constructores
        
        public GradosDir(GrafoDirigido grafo)
        {
            this.grafo = grafo;
            InitializeComponent();
        }

        private void GradosDir_Load(object sender, EventArgs e)
        {
            int gradoInterno;
            foreach (Nodo nodo in grafo)
            {
                gradoInterno = 0;
                foreach (Nodo nodo2 in grafo)
                {
                    foreach (Arista arista in nodo2.Aristas)
                    {
                        if (nodo.Equals(arista.Arriba))
                        {
                            gradoInterno++;
                        }
                    }
                }
                dataGridGrados.Rows.Add(nodo.Nombre, "deg-(" + gradoInterno.ToString() + ")", "deg+(" + (nodo.Aristas.Count.ToString()) + ")");
            }
            dataGridGrados.Rows.Add("Grafo", "deg-(" + grafo.Aristas + ")", "deg+(" + grafo.Aristas + ")");
        }
        
        #endregion

        #region Eventos
        private void Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

    }
}
