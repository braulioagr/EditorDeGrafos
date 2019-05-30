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
        private Grafo grafo;
        private Grafo grafito;
        private List<int[,]> pasos;
        private int[] cambios;
        private bool band;
        private int[,] resultante;
        #endregion

        #region Constructores

        public Isomorfismo(Grafo grafo, Grafo grafito, List<int[,]> pasos1, int[] cambios, bool band,int[,] resultante)
        {
            // TODO: Complete member initialization
            this.grafo = grafo;
            this.grafito = grafito;
            this.pasos = pasos1;
            this.cambios = cambios;
            this.band = band;
            this.resultante = resultante;
            InitializeComponent();
        }

        private void Isomorfismo_Load(object sender, EventArgs e)
        {
            string[] vector;
            dataGridG1.ColumnCount = grafo.Count + 1;
            dataGridG1.Columns[0].Name = "Nodos";
            label5.Text = "Nodos: " + grafo.Count.ToString() + "\n Aristas: " + (grafo.Aristas/2).ToString();
            label6.Text = "Nodos: " + grafito.Count.ToString() + "\n Aristas: " + (grafito.Aristas/2).ToString();
            for (int i = 1; i < grafo.Count + 1; i++)
            {
                dataGridG1.Columns[i].Name = grafo[i - 1].Nombre;
            }
            foreach (Nodo nodo in grafo)
            {
                vector = MetodosAuxiliares.vectorNodo(nodo.Nombre, grafo.encuentraIndice(nodo), grafo.matrizDeAdyacencia());
                dataGridG1.Rows.Add(vector);
            }
            dataGridG2.ColumnCount = grafo.Count + 1;
            dataGridG2.Columns[0].Name = "Nodos";
            for (int i = 1; i < grafo.Count + 1; i++)
            {
                dataGridG2.Columns[i].Name = grafito[i - 1].Nombre;
            }
            foreach (Nodo nodo in grafito)
            {
                vector = MetodosAuxiliares.vectorNodo(nodo.Nombre, grafito.encuentraIndice(nodo), this.pasos.First());
                dataGridG2.Rows.Add(vector);
            }
            comboPasos.Items.Add("Original");
            comboPasos.Items.Add("Final");
            comboPasos.Text = "Original";
            for (int i = 0; i < this.cambios.Length; i++)
            {
                dataGridIntecambios.Rows.Add(grafo[i].Nombre, grafito[this.cambios[i]].Nombre);
            }
            if (band)
            {
                this.Text = "Los grafos SI son Isomorficos";
            }
            else
            {
                this.Text = "Los grafos NO son Isomorficos";
            }
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
        }

        #endregion

        private void comboPasos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] vector;
            dataGridG2.Rows.Clear();
            if (comboPasos.Text.Equals("Original"))
            {
                foreach (Nodo nodo in grafito)
                {
                    vector = MetodosAuxiliares.vectorNodo(nodo.Nombre, grafito.encuentraIndice(nodo), this.grafito.matrizDeAdyacencia());
                    dataGridG2.Rows.Add(vector);
                }
            }
            else if (comboPasos.Text.Equals("Final"))
            {
                if (band)
                {
                    foreach (Nodo nodo in grafito)
                    {
                        vector = MetodosAuxiliares.vectorNodo(nodo.Nombre, grafito.encuentraIndice(nodo), this.grafo.matrizDeAdyacencia());
                        dataGridG2.Rows.Add(vector);
                    }
                }
                else
                {
                    foreach (Nodo nodo in grafito)
                    {
                        vector = MetodosAuxiliares.vectorNodo(nodo.Nombre, grafito.encuentraIndice(nodo), this.resultante);
                        dataGridG2.Rows.Add(vector);
                    }
                }
            }
        }



    }
}
