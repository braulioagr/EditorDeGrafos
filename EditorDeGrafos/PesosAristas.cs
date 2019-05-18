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
    public partial class PesosAristas : Form
    {
        private bool p;

        public PesosAristas(bool p)
        {
            // TODO: Complete member initialization
            this.p = p;
            InitializeComponent();
        }
        public int Valor
        {
            get
            {
                return (int)this.numericUpDown1.Value;
            }
        }

        private void PesosAristas_Load(object sender, EventArgs e)
        {
            if (!p)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
