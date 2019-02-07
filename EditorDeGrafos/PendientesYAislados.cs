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
    partial class PendientesYAislados : Form
    {

        #region Variables de Instancia
        private List<Nodo> pendientes;
        private List<Nodo> soportes;
        private List<Nodo> aislados;
        #endregion
        
        #region Constructores
        public PendientesYAislados(List<Nodo> pendientes, List<Nodo> soportes, List<Nodo> aislados)
        {
            this.pendientes = pendientes;
            this.soportes = soportes;
            this.aislados = aislados;
            InitializeComponent();
        }

        private void PendientesyCut_Load(object sender, EventArgs e)
        {
            string[] nodos;
            nodos = MetodosAuxiliares.NombresNodo(soportes);
            nodos[0] = "Nodos Soportee";
            dataGridCut.ColumnCount = pendientes.Count + 1;
            dataGridCut.Rows.Add(MetodosAuxiliares.relacionDeAristasCut(pendientes));
            dataGridCut.Rows.Add(nodos);
            nodos = MetodosAuxiliares.NombresNodo(pendientes);
            nodos[0] = "Nodos Pendiente";
            dataGridCut.Rows.Add(nodos);
            nodos = MetodosAuxiliares.NombresNodo(aislados);
            nodos[0] = "Nodos Aislados";
            dataGridCut.Rows.Add(nodos);
        }

        #endregion

        #region Eventos

        private void Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PendientesYAislados_Resize(object sender, EventArgs e)
        {
            Size size;
            size = new Size(this.Width-40,dataGridCut.Height);
            dataGridCut.Size = size;
            Point punto;
            punto = new Point((this.Width/2)-38,this.Height-74);
            Cerrar.Location = punto;
        }
        #endregion

    }
}
