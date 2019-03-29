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
    partial class Regiones : Form
    {
        private Grafo grafo;
        public Regiones(Grafo grafo)
        {
            this.grafo = grafo;
            InitializeComponent();
        }

        private void Regiones_Load(object sender, EventArgs e)
        {
            richTextBoxRegion.Text += "Formula de Euler\n";
            richTextBoxRegion.Text += "V - E + R = 2 \n";
            richTextBoxRegion.Text += "V = "+grafo.Count+"\n";
            richTextBoxRegion.Text += "E"+grafo.Aristas/2+"\n";
            richTextBoxRegion.Text += grafo.Count + " - " + grafo.Aristas/2 + " + R = 2\n";
            richTextBoxRegion.Text += (this.grafo.Count - (this.grafo.Aristas / 2)) + "+ R = 2\n";
            richTextBoxRegion.Text += "R = " + "2";
            if ((this.grafo.Count - (this.grafo.Aristas / 2)) > 0)
            {
                richTextBoxRegion.Text += " - ";
            }
            else
            {
                richTextBoxRegion.Text += " + ";
            }
            richTextBoxRegion.Text += ((this.grafo.Count - (this.grafo.Aristas / 2))*-1) + "\n";
            richTextBoxRegion.Text += "R = " + (2 - (this.grafo.Count - (this.grafo.Aristas / 2))) + "\n";
        }

        private void Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
