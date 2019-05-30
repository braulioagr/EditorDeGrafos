using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditorDeGrafos
{
    partial class Kuratowski : Form
    {

        #region Variables de Instancia

        #region Variables Elementales
        private int numNodos;
        private int numAristas;
        private int opcion;
        private int tamNodo;
        private int altoName;
        private int tamName;
        private int anchoLineaN;
        private int anchoLineaA;
        private int[,] matrizInicial;
        private string nombre;
        private string fuente;
        private bool bandFinal;
        private bool bandChingSu;
        private bool bandNombre;
        #endregion

        #region Estructuras
        Color colorRelleno;
        Color colorLinea;
        Color colorContorno;
        Color colorLetra;
        Point p1;
        Point pe;
        #endregion

        #region Objetos
        private Graphics g;//Pagina principal
        private SolidBrush brushRelleno;
        private SolidBrush brushName;
        private Pen penNodo;
        private Pen penArista;
        private Font font;
        private Bitmap bmp;
        private Nodo nodo;
        private Grafo grafo;
        private ReporteKuratowski reporte;
        #endregion

        #endregion

        #region Constructores

        public Kuratowski(Grafo grafo)
        {
            this.grafo = grafo;
            InitializeComponent();
        }

        private void Kuratowski_Load(object sender, EventArgs e)
        {

            #region Variables elementales
            this.opcion = 0;
            this.anchoLineaA = grafo.buscaArista().AnchoLinea;
            this.anchoLineaN = grafo[1].AnchoContorno;
            this.tamNodo = grafo[1].TamNodo;
            this.altoName = grafo[1].TamLetra;
            this.tamName = 6;
            this.numNodos = grafo.Count+1;
            this.nombre = this.ConvierteNombre(numNodos);
            this.bandFinal = false;
            this.bandNombre = false;
            this.bandChingSu = false;
            #endregion

            #region Estructuras
            this.colorRelleno = this.BackColor;
            this.colorLinea = Color.Black;
            this.colorContorno = Color.Black;
            this.colorLetra = Color.Black;
            #endregion

            #region Construccion de Objetos
            this.g = CreateGraphics();
            this.bmp = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            this.brushName = new SolidBrush(colorLetra);
            this.fuente = "Times New Roman";
            this.font = new Font(fuente, altoName);
            this.penNodo = new Pen(colorContorno);
            this.brushRelleno = new SolidBrush(colorRelleno);
            this.penArista = new Pen(colorLinea);
            if (typeof(GrafoNoDirigido).IsInstanceOfType(this.grafo))
            {
                this.matrizInicial = this.grafo.matrizDeAdyacencia();
                this.grafo = new GrafoNoDirigido(this.grafo.matrizAGrafo(matrizInicial));
                this.grafo.actualizaId();
                this.numAristas = grafo.Aristas / 2;
            }
            else
            {
               this.grafo = new GrafoDirigido(this.grafo.matrizAGrafo(this.grafo.matrizDeAdyacencia()));
               this.grafo.actualizaId();
               this.numAristas = grafo.Aristas;
            }
            #endregion

            this.Kuratowski_Paint(this, null);
        }
        #endregion

        #region Eventos

        #region AreaCliente
        
        private void Kuratowski_Paint(object sender, PaintEventArgs e)
        {
            Graphics gAux = CreateGraphics();
            gAux = Graphics.FromImage(bmp);
            gAux.Clear(this.BackColor);
            if (bandFinal)
            {
                switch (opcion)
                {
                        
                    case 1:// Nodo
                        gAux.FillEllipse(this.brushRelleno, pe.X, pe.Y, tamNodo, tamNodo);
                        gAux.DrawEllipse(this.penNodo, pe.X + (anchoLineaN / 2), pe.Y + (anchoLineaN / 2),
                                        tamNodo - (anchoLineaN / 2), tamNodo - (anchoLineaN / 2));
                        gAux.DrawString(this.nombre.ToString(), font, brushName, pe.X + (tamNodo / 2) - tamName, pe.Y + (tamNodo / 2) - tamName);
                        numNodos++;
                        this.nombre = ConvierteNombre(numNodos);
                        if (bandNombre)
                        {
                            grafo.CambiaNombre();
                            gAux.Clear(BackColor);
                            grafo.DibujaGrafo(gAux);
                            bandNombre = false;
                        }
                        this.grafo.actualizaId();
                        bandFinal = false;
                    break;
                }
            }
            grafo.DibujaGrafo(gAux);
            g.DrawImage(bmp, 0, 0);
        }

        private void Kuratowski_Resize(object sender, EventArgs e)
        {
            this.ClientSize = new Size(this.Size.Width - 16, this.Size.Height - 39);
            this.bmp = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            g = CreateGraphics();
        }

        #endregion

        #region Menu
        private void Clicked_Kuratowski(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.AccessibleName)
            {
                case "InsertaNodo":
                    this.opcion = 1;
                break;
                case "EliminarArista":
                    this.opcion = 2;
                break;
                case "BorraNodo":
                this.opcion = 3;
                break;
                case "HomeomorfoK5":
                    this.reporte = new ReporteKuratowski("K5", this.grafo,this.bandChingSu);
                    reporte.ShowDialog();
                    reporte.Dispose();
                    if (bandChingSu)
                    {
                        MessageBox.Show("Para comprar nuevamente con Kuratowski favor deeliminar Arista o Agregar un Nodo Corte", "Atención");
                    }
                    this.bandChingSu = false;
                    
                break;
                case "HomeomorfoK33":
                    this.reporte = new ReporteKuratowski("K33", this.grafo,this.bandChingSu);
                    reporte.ShowDialog();
                    reporte.Dispose();
                    if (bandChingSu)
                    {
                        MessageBox.Show("Para comprar nuevamente con Kuratowski favor deeliminar Arista o Agregar un Nodo Corte", "Atención");
                    }
                    this.bandChingSu = false;
                break;
            }
        }
        #endregion

        #region Mouse

        private void Kuratowski_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Left))
            {
                switch (this.opcion)
                {
                    case 1:
                        #region Añade Nodo Puente
                        p1 = e.Location;
                        pe.X = p1.X - (tamNodo / 2);
                        pe.Y = p1.Y - (tamNodo / 2);
                        nodo = new Nodo(nombre, pe, p1, penNodo.Color, brushRelleno.Color, brushName.Color, tamNodo, altoName, anchoLineaN, fuente);
                        if (numNodos == 27)
                        {
                            bandNombre = true;
                            grafo.Tipo = true;
                        }                        
                        this.bandChingSu = bandFinal = grafo.AddKuratoswki(nodo, p1);
                        #endregion
                    break;
                    case 2:
                        #region Borra Arista
                        if(grafo.BorraArista(e.Location) == 1)
                        {
                            this.bandChingSu = true;
                        }
                        bandFinal = false;
                        #endregion
                    break;
                    case 3:
                    #region BorraNodo   
                        p1 = e.Location;
                        if (grafo.BuscaNodo(ref nodo, p1))
                        {
                            grafo.borraNodo(nodo);
                            this.bandChingSu = true;
                            this.Kuratowski_Paint(this, null);
                        }
                    #endregion
                    break;
                }
                this.Kuratowski_Paint(this, null);
            }
        }

        #endregion

        #endregion

        #region Conversiones
        /**
         * Metodo que se encarga de convertir el indice de los nodos insertados
         *              en el valor ascci correspondiente o en su defecto en el
         *              numero correspondiente para despues convertirlos en cadena.
         *              @param int n indice de nodos insertados.
         *              @return retorna una cadena con el valor del nombre insertado.
         */
        public string ConvierteNombre(int n)
        {
            string cad;
            if (numNodos >= 27 || grafo.Tipo)
            {
                cad = numNodos.ToString();
            }
            else
            {
                cad = ((char)(numNodos + 64)).ToString();
            }
            return cad;
        }
        #endregion

    }
}
