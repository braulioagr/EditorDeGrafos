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
    public partial class TamañoYOrden : Form
    {

        #region Variables de Instancia
        private int tamaño;
        private int orden;
        #endregion

        #region Constructores

        public TamañoYOrden(int tamaño, int orden)
        {
            this.tamaño = tamaño;
            this.orden = orden;
            InitializeComponent();
        }

        private void TamañoYOrden_Load(object sender, EventArgs e)
        {
            this.label1.Text += ": " + tamaño.ToString();
            this.label2.Text += ": " + orden.ToString();
        }
        #endregion

        private void Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
