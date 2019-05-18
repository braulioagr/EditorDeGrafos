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
    partial class AristasBBA : Form
    {
        Grafo grafo;
        private List<string> aristasArbol;
        private List<string> aristasCruce;
        public AristasBBA(Grafo grafo, List<string> aristasArbol, List<string> aristasCruce)
        {
            // TODO: Complete member initialization
            this.grafo = grafo;
            this.aristasArbol = aristasArbol;
            this.aristasCruce = aristasCruce;
            InitializeComponent();
        }

        private void AristasBBA_Load(object sender, EventArgs e)
        {
            string aristas;
            aristas = "";
            for (int i = 0; i < aristasArbol.Count - 1; i++)
            {
                aristas += aristasArbol[i] + ", ";
            }
            aristas += aristasArbol.Last();
            dataGridAristas.Rows.Add("Rojo", "Arbol", aristas);
            /**/
            if (aristasCruce.Count > 0)
            {
                aristas = "";
                for (int i = 0; i < aristasCruce.Count - 1; i++)
                {
                    aristas += aristasCruce[i] + ", ";
                }
                aristas += aristasCruce.Last();
                dataGridAristas.Rows.Add("Verde", "Cruce", grafo.AristasCruce);
            }
            else
            {
                dataGridAristas.Rows.Add("Verde", "Cruce", "El grafo no precenta Aristas de cruce");
            }
        }

        private void Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
