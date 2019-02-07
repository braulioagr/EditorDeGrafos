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
    partial class PendientesyCut : Form
    {

        #region Variables de Instancia
        private List<Nodo> pendientes;
        private List<Nodo> cuts;
        #endregion
        
        #region Constructores
        public PendientesyCut(List<Nodo> pendientes, List<Nodo> cuts)
        {
            this.pendientes = pendientes;
            this.cuts = cuts;
            InitializeComponent();
        }

        private void PendientesyCut_Load(object sender, EventArgs e)
        {
            string[] nodos;
            nodos = MetodosAuxiliares.NombresNodo(cuts);
            nodos[0] = "Nodos Cut";
            dataGridCut.ColumnCount = pendientes.Count + 1;
            dataGridCut.Rows.Add(MetodosAuxiliares.relacionDeAristasCut(pendientes));
            dataGridCut.Rows.Add(nodos);
            nodos = MetodosAuxiliares.NombresNodo(pendientes);
            nodos[0] = "Nodos Pendiente";
            dataGridCut.Rows.Add(nodos);
        }

        #endregion

        #region Eventos
        private void Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

    }
}
