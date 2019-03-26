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
    public partial class Euler : Form
    {

        #region Variables de Instancia
        private string titulo;
        private List<string> recorrido;
        private Timer reloj;
        public delegate void Borra_Recorrido();
        public event Borra_Recorrido borra_Recorrido;
        #endregion

        #region Constructores

        public Euler(List<string> recorrido, string titulo, Timer reloj)
        {
            this.recorrido = recorrido;
            this.titulo = titulo;
            this.reloj = reloj;
            InitializeComponent();
        }

        private void Euler_Load(object sender, EventArgs e)
        {
            this.Text = titulo;
            BarVelocidad.Value = this.reloj.Interval / 100;
            for (int i = 0; i < recorrido.Count - 1; i++)
            {
                this.richTextBoxCamino.Text += recorrido[i];
                this.richTextBoxCamino.Text += "->";
            }
            this.richTextBoxCamino.Text += recorrido.Last();
        }
        #endregion

        #region Eventos

        #region Botones
        private void play_Click(object sender, EventArgs e)
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
            borra_Recorrido();
            this.Close();
        }
        #endregion

        #region TrackBar
        private void BarVelocidad_Scroll(object sender, EventArgs e)
        {
            this.reloj.Interval = BarVelocidad.Value*100;
        }
        #endregion

        #endregion

    }
}
