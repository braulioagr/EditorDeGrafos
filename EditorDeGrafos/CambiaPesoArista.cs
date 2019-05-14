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
    partial class CambiaPesoArista : Form
    {
        #region Variables de Instancia
        private List<Arista> aristas;
        #endregion

        #region Constructores
        public CambiaPesoArista(List<Arista> aristas)
        {
            this.aristas = aristas;
            InitializeComponent();
        }

        private void CambiaPesoArista_Load(object sender, EventArgs e)
        {
            foreach (Arista arista in this.aristas)
            {
                comboAristas.Items.Add("e" + arista.Id.ToString());
            }
        }
        #endregion
        #region Evento
        private void comboAristas_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Arista arista in this.aristas)
            {
                if (comboAristas.Text.Equals("e" + arista.Id.ToString()))
                {
                    this.numericPeso.Value = arista.Peso;
                    break;
                }
            }
        }
        #endregion
    }
}
