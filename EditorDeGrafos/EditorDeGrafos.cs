using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditorDeGrafos
{
    public partial class EditorDeGrafos : Form
    {
        #region Variables de Instancia

        #region Variables Elementales
        private int num;
        private int opcion;
        private int tamNodo;
        private int altoName;
        private int tamName;
        private int anchoLineaN;
        private int anchoLineaA;
        private string nombre;
        private string fuente;
        private bool band;
        private bool bandFinal;
        private bool bandNombre;
        private bool bandArista;
        private string directorio;
        #endregion

        #region Estructuras
        Color colorRelleno;
        Color colorLinea;
        Color colorContorno;
        Color colorLetra;
        Point p1;
        Point p2;
        Point pe;
        Point pI1;
        Point pI2;
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
        #endregion

        #endregion

        #region Constructores
        public EditorDeGrafos()
        {
            InitializeComponent();
        }

        private void EditorDeGrafos_Load(object sender, EventArgs e)
        {

            #region Variables elementales
            this.opcion = 0;
            this.anchoLineaA = 1;
            this.anchoLineaN = 1;
            this.tamNodo = 50;
            this.altoName = 10;
            this.tamName = 6;
            this.nombre = "A";
            this.directorio = Environment.CurrentDirectory + @"..\Grafos";
            this.num = 1;
            this.bandFinal = false;
            this.band = false;
            this.bandNombre = false;
            this.bandArista = false;
            #endregion


            #region Estructuras
            this.colorRelleno = this.BackColor;
            this.colorLinea = Color.Black;
            this.colorContorno = Color.Black;
            this.colorLetra = Color.Black;
            #endregion

            #region Construccion de Objetos
            this.grafo = new Grafo();
            this.g = CreateGraphics();
            this.bmp = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            this.brushName = new SolidBrush(colorLetra);
            this.fuente = "Times New Roman";
            this.font = new Font(fuente, altoName);
            this.penNodo = new Pen(colorContorno);
            this.brushRelleno = new SolidBrush(colorRelleno);
            this.penArista = new Pen(colorLinea);
            #endregion

        }
        #endregion

        #region Eventos

        #region Eventos Menu

        private void Archivo_Clicked(object sender, ToolStripItemClickedEventArgs e)
        {
            #region Archivo

            IFormatter formater = new BinaryFormatter();
            switch (e.ClickedItem.AccessibleName)
            {
                case "Abrir":
                break;
                case "Guardar":
                saveFileGrafo.Filter = "(*.grafo) | *.grafo";
                saveFileGrafo.InitialDirectory = directorio;
                if (saveFileGrafo.ShowDialog() == DialogResult.OK)
                {
                    Stream stream = new FileStream(saveFileGrafo.FileName, FileMode.Create, FileAccess.Write, FileShare.None);
                    formater.Serialize(stream, grafo);
                    stream.Close();
                }
                break;
            }
            #endregion
        }

        private void Tool_Clicked(object sender, ToolStripItemClickedEventArgs e)
        {
            #region ToolBar
            band = false;
            bandFinal = false;
            bandArista = false;
            switch (e.ClickedItem.AccessibleName)
            {
                /*Redireccion al Clicked de Grafo*/
                #region Grafo
                case "CrearNodo":
                case "MoverNodo":
                case "EliminarNodo":
                case "AristaDirigida":
                case "AristaNoDirigida":
                case "EliminarArista":
                case "MoverGrafo":
                case "EliminarGrafo":
                    this.Grafo_Clicked(sender, e);
                break;
                #endregion
                /*Redireccion al Clicked de Archivo*/
                #region Archivo
                case "Abrir":
                case "Guardar":
                    this.Archivo_Clicked(sender, e);
                break;
                #endregion
                /*Redireccion al Cliked de Configuracion
                #region Configuraciones
                case "Preferencias":
                case "NombreNodo":
                    this.Configuracion_Clicked(sender, e);
                break;*/
            }
            #endregion
        }

        private void Dirigido_Clicked(object sender, ToolStripItemClickedEventArgs e)
        {
            #region Grafo Dirigido
            switch (e.ClickedItem.AccessibleName)
            {
                case "Grados":
                    GradosDir grados;
                    grados = new GradosDir((GrafoDirigido)this.grafo);
                    grados.ShowDialog();
                    grados.Dispose();
                break;
                case "MAdyacencia":
                break;
                case "MIncidencia":
                break;
                case "LAdyacencia":
                break;
            }
            #endregion
        }

        private void NoDirigido_Clicked(object sender, ToolStripItemClickedEventArgs e)
        {
            #region Grafo No Dirigido
            switch (e.ClickedItem.AccessibleName)
            {
                case "Grados":
                    GradosNoDir grados;
                    grados = new GradosNoDir((GrafoNoDirigido)this.grafo);
                    grados.ShowDialog();
                    grados.Dispose();
                break;
                case "MAdyacencia":
                break;
                case "MIncidencia":
                break;
                case "LAdyacencia":
                    ListaDeAdyacencia lista;
                    lista = new ListaDeAdyacencia(this.grafo);
                    lista.ShowDialog();
                    lista.Dispose();
                break;
                case "Pendientes":
                    #region Pendietes&Cut
                    List<Nodo> pendientes;//Lista de pendientes
                    List<Nodo> cuts;//Lista de cuts
                    pendientes = grafo.nodosPendientes();//Obtiene todos los nodos pendientes
                    if (pendientes.Count != 0)
                    {
                        cuts = grafo.DibujaGrafo(g, pendientes);//Obtiene los nodos cuts y los dibuja junto con los pendientes
                        PendientesyCut pendientesYCuts = new PendientesyCut(pendientes, cuts);//Crea el dialogo que muestra la informacion
                        pendientesYCuts.ShowDialog();//Muestra el dialogo
                        pendientesYCuts.Dispose();//Destruye el dialogo
                    }
                    else
                    {
                        MessageBox.Show("El grafo no tiene nodos pendientes");
                    }
                    this.EditorDeGrafos_Paint(this, null);//Borra los nodos cuts & pendientes
                    #endregion
                break;
            }
            #endregion
        }

        private void Grafo_Clicked(object sender, ToolStripItemClickedEventArgs e)
        {
            #region Grafo
            switch (e.ClickedItem.AccessibleName)
            {

                case "CrearNodo":
                    this.opcion = 1;
                break;
                case "MoverNodo":
                    this.opcion = 4;
                break;
                case "EliminarNodo":
                    this.opcion = 3;
                break;
                case "AristaDirigida":
                    this.opcion = 7;
                break;
                case "AristaNoDirigida":
                    this.opcion = 2;
                break;
                case "EliminarArista":
                    this.opcion = 6;
                break;
                case "MoverGrafo":
                    this.opcion = 5;
                break;
                case "EliminarGrafo":
                   if (MessageBox.Show("¿Seguro quiere eliminar el grafo?", "No me quiero ir señor usuario :'(", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        grafo.borraGrafo();
                        g.Clear(BackColor);
                        /*this.restauraConfiguracion();
                        PreferenciasBack(pref);*/
                        grafo = new Grafo();
                        num = 1;
                        nombre = ConvierteNombre(num);
                        this.deshabititaOpciones();
                    }
                break;
            }
            #endregion
        }
        #endregion

        #region Eventos Mouse
        private void EditorDeGrafos_MouseDown(object sender, MouseEventArgs e)
        {
            switch (opcion)
            {
                case 1://Insertar Nodo
                    p1 = e.Location;
                    pe.X = p1.X - (tamNodo / 2);
                    pe.Y = p1.Y - (tamNodo / 2);
                    nodo = new Nodo(nombre, pe, p1, penNodo.Color, brushRelleno.Color, brushName.Color, tamNodo, altoName, anchoLineaN, fuente);
                    if (num == 27)
                    {
                        bandNombre = true;
                        grafo.Tipo = true;
                    }
                    grafo.Add(nodo);
                    band = false;
                    bandFinal = true;
                    if (grafo.Count == 1)
                    {
                        this.habilitaOpcionesGrafo();
                    }
                    this.EditorDeGrafos_Paint(this, null);
                    break;
                case 2://AristaNoDirigida
                    p1 = e.Location;
                    if (grafo.BuscaNodo(ref p1))
                    {
                        band = true;
                        bandArista = true;
                    }
                    else
                    {
                        band = false;
                        bandArista = false;
                    }
                    break;
                case 3:
                    p1 = e.Location;
                    if (grafo.BuscaNodo(ref nodo, p1))
                    {
                        grafo.borraNodo(nodo);
                        if (grafo.Count == 0)
                        {
                            this.grafo = new Grafo(this.grafo);
                            this.deshabititaOpciones();

                        }
                        this.EditorDeGrafos_Paint(this, null);
                    }
                    break;
                case 4://Mover Nodo
                case 8://Algoritmo Warner
                    p1 = e.Location;
                    bandFinal = grafo.BuscaNodo(ref nodo, p1);
                    break;
                case 5://Mover Grafo
                    p1 = e.Location;
                    bandFinal = grafo.BuscaNodo(ref nodo, p1);
                    break;
                case 6://EliminaArista
                    grafo.BorraArista(e.Location);
                    if (grafo.Aristas == 0)
                    {
                        this.grafo = new Grafo(this.grafo);
                        this.habilitaOpcionesGrafo();
                    }
                    bandFinal = false;
                    this.EditorDeGrafos_Paint(this, null);
                break;
                case 7://AristaDirigida
                    p1 = e.Location;
                    if (grafo.BuscaNodo(ref p1))
                    {
                        band = true;
                        bandArista = true;
                    }
                    else
                    {
                        band = false;
                        bandArista = false;
                    }
                break;
            } 
        }

        private void EditorDeGrafos_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Left))
            {
                switch (opcion)
                {
                    case 2:
                    case 7:
                        #region Aristas
                        if (band && bandArista) //Solo redibuja la linea
                        {
                            p2 = e.Location;
                        }
                        #endregion
                    break;
                    case 4://Mover Nodo
                        #region Mover nodo & Algoritmo Warner
                        if (bandFinal)
                        {
                            p2 = e.Location;
                            nodo.Pc = p2;
                            grafo.MueveNodo(nodo);
                            //g.Clear(BackColor);
                        }
                        #endregion
                    break;
                    case 5://Mueve Grafo
                        #region MueveGrafo
                        if (opcion == 5 && bandFinal)
                        {
                            p2 = e.Location;
                            int difX = nodo.Pc.X - p2.X;
                            int difY = nodo.Pc.Y - p2.Y;
                            pe.X = p1.X - tamNodo / 2;
                            pe.Y = p1.Y - tamNodo / 2;
                            nodo.Pc = p2;
                            nodo.Pe = pe;
                            grafo.MueveNodo(nodo);
                            grafo.MueveGrafo(difX, difY, nodo);
                            g.Clear(BackColor);
                        }
                        #endregion
                    break;
                }
                this.EditorDeGrafos_Paint(this, null);
            }
        }

        private void EditorDeGrafos_MouseUp(object sender, MouseEventArgs e)
        {
            switch (opcion)
            {
                case 2://AristaNoDirigida
                    #region  Arista no Dirigida
                    if (grafo.BuscaNodo(ref p2) && bandArista && band)
                    {
                        if (!typeof(GrafoNoDirigido).IsInstanceOfType(grafo))
                        {
                            grafo = new GrafoNoDirigido(grafo);
                            this.habilitaOpcionesGrafoNoDirigido();
                        }
                        if (!p1.Equals(p2))
                        {

                            this.pI2 = MetodosAuxiliares.PuntoInterseccion(this.p2, this.p1, tamNodo / 2);
                            this.grafo.InsertaArista(this.p1, this.p2, 0, this.anchoLineaA, this.penArista.Color);
                            this.grafo.InsertaArista(this.p2, this.p1, 0, this.anchoLineaA, this.penArista.Color);
                            band = false;
                            bandFinal = true;
                            bandArista = false;
                        }
                    }
                    else
                    {
                        bandFinal = false;
                        band = false;
                    }
                    this.EditorDeGrafos_Paint(this, null);
                    #endregion
                    break;
                case 4://MueveNodo
                    #region Mueve Nodo
                    bandFinal = false;
                    #endregion
                    break;
                case 7://AristaDirigida
                    #region AristaDirigida
                    if (grafo.BuscaNodo(ref p2) && bandArista && band)
                    {
                        if (!p1.Equals(p2))
                        {
                            if (!typeof(GrafoDirigido).IsInstanceOfType(grafo))
                            {
                                grafo = new GrafoDirigido(grafo);
                                this.habilitaOpcionesGrafoDirigido();
                            }
                            this.pI2 = MetodosAuxiliares.PuntoInterseccion(this.p2, this.p1, tamNodo / 2);
                            this.grafo.InsertaArista(this.p1, this.p2, 0, this.anchoLineaA, this.penArista.Color);
                            band = false;
                            bandFinal = true;
                            bandArista = false;
                        }
                        else
                        {
                            bandFinal = false;
                            band = false;
                        }
                    }
                    else
                    {
                        bandFinal = false;
                        band = false;
                    }
                    this.EditorDeGrafos_Paint(this, null);
                    #endregion
                    break;
            }
            this.EditorDeGrafos_Paint(this, null);
        }
        #endregion

        #region Area Cliente
        private void EditorDeGrafos_Resize(object sender, EventArgs e)
        {
            this.ClientSize = new Size(this.Size.Width - 16, this.Size.Height - 39);
            this.bmp = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            g = CreateGraphics();
        }

        private void EditorDeGrafos_Paint(object sender, PaintEventArgs e)
        {
            Graphics gAux = CreateGraphics();
            gAux = Graphics.FromImage(bmp);
            gAux.Clear(this.BackColor);
            if (band)
            {
                Pen p = new Pen(Color.GreenYellow, penArista.Width + 1);
                switch (opcion)
                {
                    case 2://AristaNoDirigida
                        pI1 = MetodosAuxiliares.PuntoInterseccion(p1, p2, tamNodo / 2);
                        gAux.DrawLine(p, pI1, p2);
                        break;
                    case 7://AristaDirigida
                        p.CustomEndCap = new AdjustableArrowCap(5, 5);
                        pI1 = MetodosAuxiliares.PuntoInterseccion(p1, p2, tamNodo / 2);
                        gAux.DrawLine(p, pI1, p2);
                        break;
                }
            }
            else
            {
                //BanderaFinal
                if (bandFinal)
                {
                    switch (opcion)
                    {
                        case 1:// Nodo
                            gAux.FillEllipse(this.brushRelleno, pe.X, pe.Y, tamNodo, tamNodo);
                            gAux.DrawEllipse(this.penNodo, pe.X + (anchoLineaN / 2), pe.Y + (anchoLineaN / 2),
                                          tamNodo - (anchoLineaN / 2), tamNodo - (anchoLineaN / 2));
                            gAux.DrawString(this.nombre.ToString(), font, brushName, pe.X + (tamNodo / 2) - tamName, pe.Y + (tamNodo / 2) - tamName);
                            num++;
                            this.nombre = ConvierteNombre(num);
                            if (bandNombre)
                            {
                                grafo.CambiaNombre();
                                gAux.Clear(BackColor);
                                grafo.DibujaGrafo(gAux);
                                bandNombre = false;
                            }
                            bandFinal = false;
                            break;
                        case 2://AristaNoDirigida
                            gAux.DrawLine(penArista, pI1, pI2);
                            bandFinal = false;
                            break;
                        case 7://AristaDirigida
                            gAux.DrawLine(penArista, pI1, pI2);
                            bandFinal = false;
                            break;
                    }
                }
            }
            grafo.DibujaGrafo(gAux);
            g.DrawImage(bmp, 0, 0);
        }

        #endregion

        #endregion

        #region Metodos

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
            if (num >= 27 || grafo.Tipo)
            {
                cad = num.ToString();
            }
            else
            {
                cad = ((char)(num + 64)).ToString();
            }
            return cad;
        }
        #endregion

        #region Opciones

        /**
         */
        private void habilitaOpcionesGrafo()
        {

            MoverNodo.Enabled = true;
            EliminarNodo.Enabled = true;
            AristaDirigida.Enabled = true;
            AristaNoDirigida.Enabled = true;
            MoverGrafo.Enabled = true;
            EliminarGrafo.Enabled = true;
            MoverNodoTool.Enabled = true;
            EliminarNodoTool.Enabled = true;
            AristaDirigidaTool.Enabled = true;
            AristaNoDirigidaTool.Enabled = true;
            MoverGrafoTool.Enabled = true;
            EliminarGrafoTool.Enabled = true;
        }

        /**
         */
        private void habilitaOpcionesGrafoNoDirigido()
        {
            grafoDirigidoToolStripMenuItem.Enabled = false;
            grafoNoDirigidoToolStripMenuItem.Enabled = true;
            AristaDirigida.Enabled = false;
            AristaDirigidaTool.Enabled = false;
            EliminarArista.Enabled = true;
            EliminarAristaTool.Enabled = true;
        }

        /**
         */
        private void habilitaOpcionesGrafoDirigido()
        {
            grafoDirigidoToolStripMenuItem.Enabled = true;
            grafoNoDirigidoToolStripMenuItem.Enabled = false;
            AristaNoDirigida.Enabled = false;
            AristaNoDirigidaTool.Enabled = false;
            EliminarArista.Enabled = true;
            EliminarAristaTool.Enabled = true;
        }

        /**
         */
        private void deshabititaOpciones()
        {
            grafoDirigidoToolStripMenuItem.Enabled = false;
            grafoNoDirigidoToolStripMenuItem.Enabled = false;
            MoverNodo.Enabled = false;
            EliminarNodo.Enabled = false;
            AristaDirigida.Enabled = false;
            AristaNoDirigida.Enabled = false;
            EliminarArista.Enabled = false;
            MoverGrafo.Enabled = false;
            EliminarGrafo.Enabled = false;
            MoverNodoTool.Enabled = false;
            EliminarNodoTool.Enabled = false;
            AristaDirigidaTool.Enabled = false;
            AristaNoDirigidaTool.Enabled = false;
            EliminarAristaTool.Enabled = false;
            MoverGrafoTool.Enabled = false;
            EliminarGrafoTool.Enabled = false;
        }

        #endregion


        #endregion

    }
}
