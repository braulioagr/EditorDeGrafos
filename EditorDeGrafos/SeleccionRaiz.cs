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
    partial class SeleccionRaiz : Form
    {
        #region Variables de Instancia
        private List<string> nombres;
        #endregion

        #region Constructor
        public SeleccionRaiz(Grafo grafo)
        {
            nombres = new List<string>();
            foreach (Nodo nodo in grafo)
            {
                nombres.Add(nodo.Nombre);
            }
            InitializeComponent();
        }
        private void SeleccionRaiz_Load(object sender, EventArgs e)
        {
            foreach (string nombre in nombres)
            {
                comboBoxNombres.Items.Add(nombre);
            }
        }
        #endregion

        #region Gets&Sets
        public string Raiz
        {
            get { return this.comboBoxNombres.Text; }
        }
        #endregion

    }
}
