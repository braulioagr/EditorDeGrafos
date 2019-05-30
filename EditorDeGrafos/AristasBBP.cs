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
    partial class AristasBBP : Form
    {
        private Grafo grafo;
        public AristasBBP(Grafo grafo)
        {
            this.grafo = grafo;
            InitializeComponent();
        }
        private void AristasBBP_Load(object sender, EventArgs e)
        {
            dataGridAristas.Rows.Add("Rojo", "Arbol", MetodosAuxiliares.stringRamas(grafo.AristasArbol));
            dataGridAristas.Rows.Add("Verde", "Cruce",MetodosAuxiliares.stringRamas(grafo.AristasCruce));
            dataGridAristas.Rows.Add("Amarillo", "Retroceso",MetodosAuxiliares.stringRamas(grafo.AristasRetroceso));
            dataGridAristas.Rows.Add("Azul", "Avance",MetodosAuxiliares.stringRamas(grafo.AristasAvance));
        }

        private void Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
