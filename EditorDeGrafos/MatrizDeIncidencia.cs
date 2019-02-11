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

        #region Variables de Instancia
        private Grafo grafoMatriz;
        #endregion

        #region Constructores
        public MatrizDeIncidencia(Grafo grafoMatriz)
        {
            this.grafoMatriz = grafoMatriz;
            InitializeComponent();
        }

        private void MatrizDeAdyacencia_Load(object sender, EventArgs e)
        {
            
            dataGridMatriz.ColumnCount = grafoMatriz.Count+1;
            dataGridMatriz.Columns[0].Name = "Nodos";
            for (int i = 1; i < grafoMatriz.Count; i++)
            {
                dataGridMatriz.Columns[i].Name = grafoMatriz[i-1].Nombre;
            }
            dataGridMatriz.Columns[grafoMatriz.Count].Name = grafoMatriz.Last().Nombre;
            foreach (Nodo nodo in grafoMatriz)
            {
                dataGridMatriz.Rows.Add(nodo.Pesos());
            }
        }
        #endregion
        private void Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MatrizDeAdyacencia_Resize(object sender, EventArgs e)
        {
            Size size;
            size = new Size(this.Width - 40, this.Height - 99);
            dataGridMatriz.Size = size;
            Point punto;
            punto = new Point((this.Width/2)-75,this.Height-74);
            Cerrar.Location = punto;
        }
    }
}
