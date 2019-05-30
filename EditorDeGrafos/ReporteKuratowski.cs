using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditorDeGrafos
{
    partial class ReporteKuratowski : Form
    {
        #region Variables de Instancia
        private string texto;
        private Grafo grafo;
        private bool bandChingSu;
        #endregion
        public ReporteKuratowski(string texto, Grafo grafo, bool bandChingSu)
        {
            // TODO: Complete member initialization
            this.grafo = grafo;
            this.bandChingSu = bandChingSu;
            this.texto = texto;
            this.grafo = grafo;
            InitializeComponent();
        }

        private void ReporteKuratowski_Load(object sender, EventArgs e)
        {
            Grafo grafo2;
            IFormatter formater = new BinaryFormatter();
            Stream stream;
            this.Text = "Reporte con " + this.texto;
            if (this.texto.Equals("K5"))
            {
                stream = new FileStream(Environment.CurrentDirectory + @"..\Grafos\Especiales\K5.grafo",
                                                    FileMode.Open, FileAccess.Read, FileShare.None);
                grafo2 = (Grafo)formater.Deserialize(stream);
                if (bandChingSu)
                {
                    if (grafo.homeomorficoK5())
                    {
                        this.richTextBoxReporte.Text = "El grafo es homeomorfo a K5";
                    }
                    else
                    {
                        this.richTextBoxReporte.Text = "No es Homeomorfico a K5";
                    }
                }
                else
                {
                    this.richTextBoxReporte.Text = "Por favor Modifique el grafo";
                }
            }
            else
            {
                stream = new FileStream(Environment.CurrentDirectory + @"..\Grafos\Especiales\K33.grafo",
                                                    FileMode.Open, FileAccess.Read, FileShare.None);
                grafo2 = (Grafo)formater.Deserialize(stream);
                if(bandChingSu)
                {
                    if (grafo.homeomorficoK33())
                    {
                        this.richTextBoxReporte.Text = "El grafo es homeomorfo a K33";
                    }
                    else
                    {
                        this.richTextBoxReporte.Text = "No es Homeomorfico a K33";
                    }
                }
                else
                {
                    this.richTextBoxReporte.Text = "Por favor Modifique el grafo";
                }
            }
            //Algoritmo para vaciar el grafo en datagird Original
            this.dataGridViewOriginal.ColumnCount = grafo2.Count+1;
            for (int i = 1; i < grafo2.Count + 1; i++)
            {
                this.dataGridViewOriginal.Columns[i].Name = grafo2[i-1].Nombre;
            }
            int[,] matriz = grafo2.matrizDeAdyacencia();
            string[] renglon;
            renglon = new string[grafo2.Count + 1];
            for (int i = 0; i < grafo2.Count; i ++)
            {
                renglon[0] = grafo2[i].Nombre;
                for (int k = 0; k < grafo2.Count; k++)
                {
                    renglon[k + 1] = matriz[i , k].ToString();
                }
                this.dataGridViewOriginal.Rows.Add(renglon);
            }
            this.dataGridViewResultante.ColumnCount = grafo.Count+1;
            //Algoritmo para vaciar el grafo en datagird Original
            for (int i = 1; i < grafo.Count + 1; i++)
            {
                this.dataGridViewResultante.Columns[i].Name = grafo[i-1].Nombre;
            }
            int[,] matrix = grafo.matrizDeAdyacencia();
            renglon = new string[grafo.Count + 1];
            for (int i = 0; i < grafo.Count; i++)
            {
                renglon[0] = grafo[i].Nombre;
                for (int k = 0; k < grafo.Count; k++)
                {
                    renglon[k + 1] = matrix[i, k].ToString();
                }
                this.dataGridViewResultante.Rows.Add(renglon);
            }
            string adyacencias;
            foreach (Nodo nodo in grafo)
            {
                adyacencias = "";
                foreach (Arista arista in nodo.Aristas)
                {
                    adyacencias += "," + arista.Arriba.Nombre;
                }
                if (!string.IsNullOrEmpty(adyacencias))
                {
                    adyacencias = adyacencias.Substring(1);
                    dataGridLista.Rows.Add(nodo.Nombre, adyacencias);
                }
                else
                {
                    dataGridLista.Rows.Add(nodo.Nombre, "Este grafo no Tiene Adyacencias");
                }
            }
            stream.Close();
            this.richTextBoxAdvertencia.Text = "En caso de no cumplir, si desea que el grafo sea homeomorfico a los grafos K5 y K3,3 cerrar el dialogo y modificar el grafo original y volver a abrir el dialogo para que se pueda hacer una prueba con el grafo modificado";
        }

        private void Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
