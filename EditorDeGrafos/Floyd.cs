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
    partial class Floyd : Form
    {

        #region Variables de Instancia
        int[,] matrizCostos;
        int[,] matrizRecorridos;
        private string[,] caminos;
        Grafo grafo;
        Timer reloj;
        List<string> recorrido;
        #endregion

        #region Declaracion de Delegados
        public delegate void EventoFloyd(List<string> recorrido);
        public delegate void BorraRecorrido();
        #endregion

        #region Declaracion de Eventos
        public event EventoFloyd floyd;
        public event BorraRecorrido borraRecorrido;
        #endregion

        #region Constructores
        public Floyd(int[,] matrizCostos, int[,] matrizRecorridos, Grafo grafo, string[,] caminos, Timer reloj)
        {
            this.matrizCostos = matrizCostos;
            this.matrizRecorridos = matrizRecorridos;
            this.grafo = grafo;
            this.reloj = reloj;
            this.caminos = caminos;
            InitializeComponent();
        }

        private void Floyd_Load(object sender, EventArgs e)
        {
            int gradoInterno;
            string[] vector;
            dataGridCostos.ColumnCount = matrizCostos.GetLength(0) + 1;
            dataGridCostos.Columns[0].Name = "Nodos";
            for (int i = 1; i < grafo.Count; i++)
            {
                dataGridCostos.Columns[i].Name = grafo[i - 1].Nombre;
            }
            dataGridCostos.Columns[grafo.Count].Name = grafo.Last().Nombre;
            foreach (Nodo busca in grafo)
            {
                vector = MetodosAuxiliares.vectorNodo(busca.Nombre, grafo.encuentraIndice(busca), matrizCostos);
                dataGridCostos.Rows.Add(vector);
            }
            dataGridRecorridos.ColumnCount = matrizCostos.GetLength(0) + 1;
            dataGridRecorridos.Columns[0].Name = "Nodos";
            for (int i = 1; i < grafo.Count; i++)
            {
                dataGridRecorridos.Columns[i].Name = grafo[i - 1].Nombre;
            }
            dataGridRecorridos.Columns[grafo.Count].Name = grafo.Last().Nombre;
            foreach (Nodo busca in grafo)
            {
                dataGridRecorridos.Rows.Add(MetodosAuxiliares.vectorNodo(busca.Nombre, grafo.encuentraIndice(busca), matrizRecorridos));
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

        #region Botones

        private void Play_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(comboDestino.Text) && !string.IsNullOrEmpty(comboOrigen.Text))
            {
                if (!recorrido[0].Equals("No existe Camino"))
                {
                    this.reloj.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Uno de los ComboBox Esta vacio por favor seleccione el nodo que le falta", "Error");
            }
        }

        private void Pause_Click(object sender, EventArgs e)
        {
            if (!recorrido[0].Equals("No existe Camino"))
            {
                this.reloj.Enabled = false;
            }
        }

        private void Cerrar_Click(object sender, EventArgs e)
        {
            this.reloj.Enabled = false;
            this.borraRecorrido();
            this.Close();
        }

        #endregion

        #region ComboBox

        private void comboOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(comboOrigen.Text))
            {
                if (!string.IsNullOrEmpty(comboDestino.Text))
                {
                    this.richTextBoxRecorrido.Text = "";
                    if (this.reloj.Enabled)
                    {
                        this.reloj.Enabled = false;
                        this.borraRecorrido();
                    }
                    this.recorrido = recuperaRecorrido(comboOrigen.Text, comboDestino.Text);
                    this.floyd(this.recorrido);
                    if (!recorrido.First().Equals("No existe Camino"))
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
                    this.borraRecorrido();
                }
                this.recorrido = recuperaRecorrido(comboOrigen.Text, comboDestino.Text);
                this.floyd(this.recorrido);
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

        #region TrackBar
        private void BarVelocidad_Scroll(object sender, EventArgs e)
        {
            this.reloj.Interval = BarVelocidad.Value * 100;
        }
        #endregion

        private List<string> recuperaRecorrido(string origen, string destino)
        {
            int i,j;
            string aux;
            List<string> camino;
            camino = new List<string>();
            aux = "";
            i = grafo.encuentraIndice(origen);
            j = grafo.encuentraIndice(destino);
            camino.Add(destino);
            do
            {
                aux = caminos[j, i];
                camino.Add(aux);
                j = grafo.encuentraIndice(caminos[j, i]);
            } while (!aux.Equals(origen));
            camino.Reverse();
            /*if (this.matrizRecorridos[i, j] < int.MaxValue / 3)
            {
            }
            else
            {
                camino.Add("No existe Camino");
            }*/
            return camino;
        }

    }
}
