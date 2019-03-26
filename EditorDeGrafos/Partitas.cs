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
    partial class Partitas : Form
    {
        #region Variables de instancia
        List<Partita> partitas;
        int mayor;
        #endregion

        #region Constructores
        public Partitas(List<Partita> partitas)
        {
            InitializeComponent();
            this.partitas = partitas;
            this.mayor = 0;
            foreach (Partita partita in partitas)
            {
                if (partita.Count > this.mayor)
                {
                    this.mayor = partita.Count;
                }
            }
        }

        private void Partitas_Load(object sender, EventArgs e)
        {
            //dataGridPartitas.ColumnCount = mayor + 1;
            int i = 1;
            foreach (Partita partita in this.partitas)
            {
                dataGridPartitas.Rows.Add(partita.elementos(i));
                i++;
            }
        }
        #endregion

        #region eventos

        private void Cerrar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }


        #endregion

        private void Partitas_Resize(object sender, EventArgs e)
        {
            Point p;
            this.dataGridPartitas.Width = this.Size.Width - 40;
            p = new Point((Size.Width / 2) - (38), Cerrar.Location.Y);
            Cerrar.Location = p;
        }

    }
}
