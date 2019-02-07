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
    partial class ListaDeAdyacencia : Form
    {

        #region Variables de Instancia
        private Grafo grafo;
        #endregion

        #region Constructores
        public ListaDeAdyacencia(Grafo grafo)
        {
            this.grafo = grafo;
            InitializeComponent();
        }
        private void ListaDeAdyacencia_Load(object sender, EventArgs e)
        {
            string adyacencias;
            foreach (Nodo nodo in grafo)
            {
                adyacencias = "";
                foreach(Arista arista in nodo.Aristas)
                {
                    adyacencias += "," + arista.Arriba.Nombre;
                }
                adyacencias = adyacencias.Substring(1);
                dataGridLista.Rows.Add(nodo.Nombre,adyacencias);
            }
        }
        #endregion

        private void Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
