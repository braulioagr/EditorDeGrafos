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
    partial class Dijkstra : Form
    {
        #region Variables de Instancia
        Grafo grafoMatriz;
        Grafo grafo;
        Timer reloj;
        List<string> recorrido;
        #endregion

        #region Declaracion de Delegados
        public delegate List<string> Evento_Dijkstra(string origen, string destino);
        public delegate string[] Vector_Origen(string origen);
        public delegate void Borra_Recorrido();
        #endregion

        #region Declaracion de Eventos
        public event Evento_Dijkstra dijsktra;
        public event Vector_Origen vector;
        public event Borra_Recorrido borra_Recorrido;
        #endregion

        #region Constructores

        public Dijkstra(Grafo grafo, Timer reloj)
        {
            this.grafo = grafo;
            this.grafoMatriz = grafo.matrizDeCostos();
            this.reloj = reloj;
            InitializeComponent();
        }

        private void Dijkstra_Load(object sender, EventArgs e)
        {

            int gradoInterno;
            DataGridMatriz.ColumnCount = grafoMatriz.Count + 1;
            int ancho = (this.DataGridMatriz.Width / grafoMatriz.Count) - (grafoMatriz.Count + 1);
            DataGridMatriz.Columns[0].Name = "Nodos";
            for (int i = 1; i < grafoMatriz.Count; i++)
            {
                DataGridMatriz.Columns[i].Name = grafoMatriz[i - 1].Nombre;
            }
            DataGridMatriz.Columns[grafoMatriz.Count].Name = grafoMatriz.Last().Nombre;
            foreach (Nodo busca in grafoMatriz)
            {
                DataGridMatriz.Rows.Add(busca.Pesos());
            }
            for (int i = 0; i < grafoMatriz.Count + 1; i++)
            {
                DataGridMatriz.Columns[i].Width = ancho;
            }
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
                if (nodo.Aristas.Count > 0)
                {
                    comboOrigen.Items.Add(nodo.Nombre);
                }
                if (gradoInterno > 0)
                {
                    comboDestino.Items.Add(nodo.Nombre);
                }
            }
            comboOrigen.Text = comboOrigen.Items[0].ToString();
            comboOrigen.Text = "";
        }

        #endregion

        #region Metodos
        public void actualizaVector()
        {
            dataGridVector.Rows.Clear();
            string[] vector = this.vector(comboOrigen.Text);
            for (int i = 0; i < grafo.Count; i++)
            {
                dataGridVector.Rows.Add(grafo[i].Nombre, vector[i]);
            }
            label2.Text = "Vector de origen: " + comboOrigen.Text;
        }

        #endregion

        #region Eventos

        #region ComboBox

        private void comboOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(comboOrigen.Text))
            {
                this.actualizaVector();
                if (!string.IsNullOrEmpty(comboDestino.Text))
                {
                    this.richTextBoxRecorrido.Text = "";
                    if (this.reloj.Enabled)
                    {
                        this.reloj.Enabled = false;
                        this.borra_Recorrido();
                    }
                    this.recorrido = this.dijsktra(comboOrigen.Text, comboDestino.Text);
                    if (!recorrido.Equals("No existe Camino"))
                    {
                        for (int i = 0; i < recorrido.Count - 1; i++)
                        {
                            this.richTextBoxRecorrido.Text += recorrido[i];
                            this.richTextBoxRecorrido.Text += "->";
                        }
                        this.richTextBoxRecorrido.Text += recorrido.Last();
                    }
                    else
                    {
                        this.richTextBoxRecorrido.Text = "No existe Camino";
                    }
                }
            }
        }

        private void comboDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(comboOrigen.Text) && !string.IsNullOrEmpty(comboDestino.Text))
            {
                this.richTextBoxRecorrido.Text = "";
                if (this.reloj.Enabled)
                {
                    this.reloj.Enabled = false;
                    this.borra_Recorrido();
                }
                this.recorrido = this.dijsktra(comboOrigen.Text, comboDestino.Text);
                if (!recorrido.Equals("No existe Camino"))
                {
                    for (int i = 0; i < recorrido.Count - 1; i++)
                    {
                        this.richTextBoxRecorrido.Text += recorrido[i];
                        this.richTextBoxRecorrido.Text += "->";
                    }
                    this.richTextBoxRecorrido.Text += recorrido.Last();
                }
                else
                {
                    this.richTextBoxRecorrido.Text = "No existe Camino";
                }
            }
        }

        #endregion

        #region Botones

        private void Play_Click(object sender, EventArgs e)
        {
            if (!recorrido.Equals("No existe Camino"))
            {
                this.reloj.Enabled = true;
            }
        }

        private void Pause_Click(object sender, EventArgs e)
        {
            if (!recorrido.Equals("No existe Camino"))
            {
                this.reloj.Enabled = false;
            }
        }

        private void Cerrar_Click(object sender, EventArgs e)
        {
            this.reloj.Enabled = false;
            this.borra_Recorrido();
            this.Close();
        }

        #endregion

        #region Area Cliente
        private void Dijkstra_Resize(object sender, EventArgs e)
        {
            Size size = new Size(this.Size.Width - 40, this.Size.Height - 162);
            this.DataGridMatriz.Size = size;
            Point p = new Point((this.Size.Width / 2) - 45, (this.Size.Height) - 74);
            this.Cerrar.Location = p;
            p = new Point((this.Size.Width / 2) - 45, (this.Size.Height) - 144);
        }
        #endregion

        #endregion

    }
}
