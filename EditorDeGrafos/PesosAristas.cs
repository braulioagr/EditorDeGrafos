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
        public PesosAristas()
        {
            InitializeComponent();
        }
        public int Valor
        {
            get
            {
                return (int)this.numericUpDown1.Value;
            }
        }
    }
}
