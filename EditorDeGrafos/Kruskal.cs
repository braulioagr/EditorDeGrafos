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
    partial class Kruskal : Form
    {
        private List<Arista> aristas;
        private int peso;

        public Kruskal(List<Arista> aristas)
        {
            // TODO: Complete member initialization
            this.aristas = aristas.OrderBy(arista => arista.Id).ToList();
            peso = 0;
            foreach (Arista arista in this.aristas)
            {
                peso += arista.Peso;
            }
            InitializeComponent();
        }

        private void Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Kruskal_Load(object sender, EventArgs e)
        {
            int peso;
            peso = 0;
            foreach (Arista arista in aristas)
            {
                peso += arista.Peso;
                dataGridArista.Rows.Add("e" + arista.Id, arista.Peso);
            }
            label2.Text = "Peso = " + peso.ToString();
        }
    }
}
