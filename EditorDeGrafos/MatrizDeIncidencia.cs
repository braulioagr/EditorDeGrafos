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
    partial class MatrizDeIncidencia : Form
    {
        private int[,] matriz;
        private int nodos;
        private int aristas;
        private Grafo grafo;
        public MatrizDeIncidencia(int[,] matriz,int nodos, int aristas,Grafo grafo)
        {
            this.nodos = nodos;
            this.aristas = aristas;
            this.matriz = matriz;
            this.grafo = grafo;
            InitializeComponent();
        }

        private void MatrizDeIncidencia_Load(object sender, EventArgs e)
        {
            dataGridMatriz.ColumnCount = aristas + 1;
            for (int x = 1; x < aristas + 1 ; x++)
            {
                dataGridMatriz.Columns[x].Name = "e" + (x).ToString();
            }
            string[] renglon;
            renglon = new string[aristas+1];
            for (int i = 0; i < nodos; i++)
            {
                renglon[0] = grafo[i].Nombre;
                for (int j = 0; j < aristas; j++)
                {
                    renglon[j + 1] = matriz[i, j].ToString();
                }
                dataGridMatriz.Rows.Add(renglon);
            }
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
