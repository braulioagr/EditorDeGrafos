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
    partial class Ciclos : Form
    {
        #region Variables de Instancia
        List<List<string>> ciclos;
        Timer reloj;
        List<string> arbol;
        List<string> cruce;
        List<string> avance;
        List<string> retroceso;
        #endregion

        #region Declaracion de Delegados
        public delegate void EventoCiclos(List<string>ciclo);
        public delegate void BorraRecorrido();
        #endregion

        #region Declaracion de Eventos
        public event EventoCiclos ciclo;
        public event BorraRecorrido borraRecorrido;
        #endregion

        #region Constructoeres
        public Ciclos(List<List<string>> ciclos, Timer reloj, List<string> arbol, List<string> cruce, List<string> avance, List<string> retroceso)
        {
            this.ciclos = ciclos;
            this.reloj = reloj;
            this.arbol = arbol;
            this.cruce = cruce;
            this.avance = avance;
            this.retroceso = retroceso;
            InitializeComponent();
        }

        private void Ciclos_Load(object sender, EventArgs e)
        {
            this.Text = "El grafo presenta: " +ciclos.Count.ToString() + " ciclos";
            for (int i = 0; i < ciclos.Count; i++)
            {
                comboCiclos.Items.Add((i+1).ToString());
            }
            comboCiclos.Text = "1";

            dataGridAristas.Rows.Add("Rojo", "Arbol", MetodosAuxiliares.stringRamas(arbol));
            dataGridAristas.Rows.Add("Verde", "Cruce", MetodosAuxiliares.stringRamas(cruce));
            dataGridAristas.Rows.Add("Amarillo", "Retroceso", MetodosAuxiliares.stringRamas(retroceso));
            dataGridAristas.Rows.Add("Azul", "Avance", MetodosAuxiliares.stringRamas(avance));
        }
        #endregion

        #region Eventos

        #region Botones
        private void Play_Click(object sender, EventArgs e)
        {
            this.reloj.Enabled = true;
        }

        private void Pausa_Click(object sender, EventArgs e)
        {
            this.reloj.Enabled = false;
        }

        private void Cerrar_Click(object sender, EventArgs e)
        {
            this.reloj.Enabled = false;
            this.borraRecorrido();
            this.Close();
        }
        #endregion

        #region trackBar
        private void velocidadBar_Scroll(object sender, EventArgs e)
        {
            this.reloj.Interval = velocidadBar.Value * 100;
        }
        #endregion

        #region ComoBox
        private void comboCiclos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.reloj.Enabled)
            {
                this.reloj.Enabled = false;
                this.borraRecorrido();
            }
            richTextCiclos.Text = "";
            for (int i = 0; i < ciclos[Int32.Parse(comboCiclos.Text)-1].Count - 1; i++)
            {
                this.richTextCiclos.Text += ciclos[Int32.Parse(comboCiclos.Text) - 1][i];
                this.richTextCiclos.Text += "->";
            }
            this.richTextCiclos.Text += ciclos[Int32.Parse(comboCiclos.Text) - 1].Last();
            ciclo(ciclos[Int32.Parse(comboCiclos.Text) - 1]);
        }
        #endregion
                
        #endregion
    }
}
