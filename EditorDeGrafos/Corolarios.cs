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
    partial class Corolarios : Form
    {
        #region Variables de Instancia
        private Grafo grafo;
        private string texto;
        #endregion
        public Corolarios(Grafo grafo)
        {
            texto = "null";
            this.grafo = grafo;
            InitializeComponent();
        }

        public Corolarios(Grafo grafo, string texto)
        {
            this.grafo = grafo;
            this.texto = texto;
            InitializeComponent();
        }
        private void Corolarios_Load(object sender, EventArgs e)
        {
            int E;
            int V;
            V = grafo.Count;
            if (typeof(GrafoNoDirigido).IsInstanceOfType(grafo))
            {
                E = grafo.Aristas / 2;
            }
            else
            {
                E = grafo.Aristas;
            }
            richTextBoxC.Text = "Counclusión\n";
            //Corolario 1
            //E<=3V-6
            richTextBoxCorolario1.Text += "E: " + E.ToString() + "\n";
            richTextBoxCorolario1.Text += "V: " + V.ToString() + "\n";
            richTextBoxCorolario1.Text = "Formula:\n";
            richTextBoxCorolario1.Text += "E <= 3V - 6\n";
            richTextBoxCorolario1.Text += E.ToString() + " <= " + 3 + "(" + V.ToString() + ") - 6\n";
            if (grafo.corolario1())
            {
                richTextBoxCorolario1.Text += "El grafo si cumple con el corolario 1";
                richTextBoxC.Text = "Corolario1: Si cumple\n";
            }
            else
            {
                richTextBoxCorolario1.Text += "El grafo no cumple con el corolario 1";
                richTextBoxC.Text = "Corolario1: No cumple\n";
            }
            //Corolario 2
            //E <= 2V – 4
            richTextBoxCorolario2.Text += "E: " + E.ToString() + "\n";
            richTextBoxCorolario2.Text += "V: " + V.ToString() + "\n";
            richTextBoxCorolario2.Text = "Formula:\n";
            richTextBoxCorolario2.Text += "E <= 2V – 4\n";
            richTextBoxCorolario2.Text += E.ToString() + " <= " + 2 + "(" + V.ToString() + ") - 4\n";
            if (grafo.corolario2())
            {
                richTextBoxCorolario2.Text += "El grafo si cumple con el corolario 2";
                richTextBoxC.Text += "Corolario2: Si cumple\n";
            }
            else
            {
                richTextBoxCorolario2.Text += "El grafo no cumple con el corolario 2";
                richTextBoxC.Text += "Corolario2: No cumple\n";
            }
            if (grafo.corolario1() && grafo.corolario2())
            {
                richTextBoxC.Text += "El grafo es plano";
            }
            else
            {
                if (!this.texto.Equals("null"))
                {
                    richTextBoxC.Text += "El grafo es Homeomorfico con un grafo " + texto + "\n";
                }
                richTextBoxC.Text += "El grafo no es plano";
            }
        }

        private void Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
