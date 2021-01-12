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
        private int numNodos;
        private int numAristas;
        private int opcion;
        private int tamNodo;
        private int altoName;
        private int tamName;
        private int anchoLineaN;
        private int anchoLineaA;
        private int rec;
        private string nombre;
        private string fuente;
        private bool band;
        private bool bandFinal;
        private bool bandNombre;
        private bool bandArista;
        private bool bandRecorrido;
        private bool bandPeso;
        private string directorio;
        private List<string> recorrido;
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
        private Nodo anterior;
        private Nodo actual;
        private Arista arista;
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
            this.rec = 0;
            this.directorio = Environment.CurrentDirectory + @"..\Grafos";
            this.numNodos = 1;
            this.numAristas = 0;
            this.bandFinal = false;
            this.band = false;
            this.bandNombre = false;
            this.bandArista = false;
            this.bandRecorrido = false;
            this.bandPeso = false;
            //this.recorrido = "";
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

        #region Menu

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
                case "Ponderación":
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
                /*Redireccion al Cliked de Configuracion*/
                #region Configuraciones
                case "Preferencias":
                case "EtiquetasNodo":
                case "pesosArista":
                    this.Configuracion_Clicked(sender, e);
                break;
                #endregion
            }
            #endregion
        }

        private void Archivo_Clicked(object sender, ToolStripItemClickedEventArgs e)
        {
            #region Archivo
            IFormatter formater = new BinaryFormatter();
            Stream stream;
            switch (e.ClickedItem.AccessibleName)
            {
                case "Abrir":
                    #region Abrir Grafo
                    openFileGrafo = new OpenFileDialog();
                    openFileGrafo.Filter = "(*.grafo) | *.grafo";
                    openFileGrafo.FilterIndex = 2;
                    openFileGrafo.RestoreDirectory = true;
                    openFileGrafo.InitialDirectory = directorio;
                    if (openFileGrafo.ShowDialog() == DialogResult.OK)
                    {
                        stream = new FileStream(openFileGrafo.FileName, FileMode.Open,
                            FileAccess.Read, FileShare.None);
                        grafo = (Grafo)formater.Deserialize(stream);
                        if (grafo.Count > 0)
                        {
                            nodo = grafo[0];
                            nombre = grafo[grafo.Count - 1].Nombre;
                            try
                            {
                                numNodos = Int32.Parse(nombre);
                            }
                            catch (FormatException)
                            {
                                char aux = nombre[0];
                                numNodos = aux - 64;
                            }
                            numNodos++;
                            nombre = ConvierteNombre(numNodos);
                            /*this.pref.Dispose();
                            if (grafo.buscaArista(ref arista))
                            {
                                this.pref = new Preferencias(nodo.AnchoContorno, nodo.TamNodo, nodo.TamLetra,
                                                                arista.AnchoLinea, arista.ColorLinea, nodo.ColorFuera,
                                                                nodo.BrushRelleno, nodo.Brushnombre);
                            }
                            else
                            {
                                this.pref = new Preferencias(nodo.AnchoContorno, nodo.TamNodo, nodo.TamLetra,
                                                                1, Color.Black, nodo.ColorFuera,
                                                                nodo.BrushRelleno, nodo.Brushnombre);
                            }*/
                        }
                        /*else
                        {
                            this.pref = new Preferencias(anchoLineaN, tamNodo, altonombre,
                                                         anchoLineaA, colorLinea, colorContorno,
                                                         colorRelleno, colorLetra);
                        }
                        PreferenciasBack(pref);*/
                        stream.Close();
                        this.habilitaOpcionesGrafo();
                        if (typeof(GrafoDirigido).IsInstanceOfType(grafo))
                        {
                            this.habilitaOpcionesGrafoDirigido();
                                this.numAristas = this.grafo.Aristas;
                        }
                        else if (typeof(GrafoNoDirigido).IsInstanceOfType(grafo))
                        {
                           this.habilitaOpcionesGrafoNoDirigido();
                           this.numAristas = this.grafo.Aristas / 2;
                        }
                        this.EditorDeGrafos_Paint(this, null);
                    }
                    #endregion
                break;
                case "Guardar":
                    #region Gurdar Grafo
                    saveFileGrafo.Filter = "(*.grafo) | *.grafo";
                    saveFileGrafo.InitialDirectory = directorio;
                    if (saveFileGrafo.ShowDialog() == DialogResult.OK)
                    {
                        stream = new FileStream(saveFileGrafo.FileName, FileMode.Create, FileAccess.Write, FileShare.None);
                        formater.Serialize(stream, grafo);
                        stream.Close();
                    }
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
                case "Ponderación":
                    bandPeso = !bandPeso;
                    numericKn.Visible = false;
                    numericCn.Visible = false;
                    numericWn.Visible = false;
                    if(bandPeso)
                    {
                        this.opcion = -1;
                        this.activaSpin();
                        this.deshabititaOpciones();
                        Archivo.Enabled = false;
                        CrearNodo.Enabled = false;
                        pesosArista.Enabled = false;
                        AbrirTool.Enabled = false;
                        GuardarTool.Enabled = false;
                        pesosAristaTool.Enabled = false;
                        CrearNodoTool.Enabled = false;
                        EspecialesTool.Enabled = false;
                        ToolBarMetodos.Enabled = false;
                        ToolBarMetodos2.Enabled = false;
                        PonderaciónArista.Enabled = true;
                        PonderaciónAristaTool.Enabled = true;
                    }
                    else
                    {
                        this.desactivaSpin();
                        EspecialesTool.Enabled = true;
                        ToolBarMetodos.Enabled = true;
                        ToolBarMetodos2.Enabled = true;
                        Archivo.Enabled = true;
                        this.habilitaOpcionesGrafo();
                        if (typeof(GrafoDirigido).IsInstanceOfType(grafo))
                        {
                            habilitaOpcionesGrafoDirigido();
                        }
                        else
                        {
                            if (typeof(GrafoNoDirigido).IsInstanceOfType(grafo))
                            {
                                habilitaOpcionesGrafoNoDirigido();
                            }
                        }
                    }
                break;
                case "EliminarGrafo":
                   if (MessageBox.Show("¿Seguro quiere eliminar el grafo?", "No me quiero ir señor usuario :'(", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        grafo.borraGrafo();
                        /*this.restauraConfiguracion();
                        PreferenciasBack(pref);*/
                        this.grafo = new Grafo();
                        this.numNodos = 1;
                        this.numAristas = 0;
                        this.nombre = ConvierteNombre(numNodos);
                        this.deshabititaOpciones();
                        this.EditorDeGrafos_Paint(this, null);
                    }
                break;
            }
            #endregion
        }

        private void Dirigido_Clicked(object sender, ToolStripItemClickedEventArgs e)
        {
            #region Grafo Dirigido
            switch (e.ClickedItem.AccessibleName)
            {
                case "Grados":
                    #region Grados
                    GradosDir grados;
                    grados = new GradosDir((GrafoDirigido)this.grafo);
                    grados.ShowDialog();
                    grados.Dispose();
                    #endregion
                break;
                case "MAdyacencia":
                    #region Matriz de Adyacencia
                    MatrizDeAdyacencia matrizA;
                    matrizA = new MatrizDeAdyacencia(grafo.grafoMatriz());
                    matrizA.ShowDialog();
                    matrizA.Dispose();
                    #endregion
                break;
                case "MIncidencia":
                    #region Matriz de Incidencia
                    MatrizDeIncidencia matrizI;
                    grafo.actualizaId();
                    matrizI = new MatrizDeIncidencia(grafo.matrizDeIncidencia(), grafo.Count, grafo.Aristas, grafo);
                    matrizI.ShowDialog();
                    matrizI.Dispose();
                    #endregion
                break;
                case "LAdyacencia":
                    #region Lista Adyacencia
                    ListaDeAdyacencia lista;
                    lista = new ListaDeAdyacencia(this.grafo);
                    lista.ShowDialog();
                    lista.Dispose();
                    #endregion
                break;
                case "TamOrd":
                    #region Tamaño y Orden
                    TamañoYOrden tamOrd;
                    tamOrd = new TamañoYOrden(grafo.Count, grafo.Aristas);
                    tamOrd.ShowDialog();
                    tamOrd.Dispose();
                    #endregion
                break;
                case "Complemento":
                    #region Complemento
                    this.grafo.complemento(this.colorLinea, this.anchoLineaA);
                    this.grafo.actualizaId();
                    this.EditorDeGrafos_Paint(this, null);
                    #endregion
                break;
                case "Euler":
                    #region Euler
                    Euler euler;
                    grafo.setGrados();
                    if (!grafo.aislado())//Si no tiene un nodo aislado puede que tenga circuito o camino
                    {
                        #region Circuito
                        this.grafo.setGrados();
                        if (grafo.gradosPares())//Si todos sus nodos son de grado par Existe circuito
                        {
                            /**/
                            this.recorrido = grafo.circuitoEuleriano();//Regresa una lista de strings que ya esta secuenciada el dato
                            euler = new Euler(recorrido, "Existe el circuito", relojEuler);//Inicializa el dialogo
                            euler.borra_Recorrido += new Euler.Borra_Recorrido(this.redibujaGrafo);//Detalles
                            rec = 0;//Detalles
                            bandRecorrido = false;//Detalles
                            euler.Show();//Detalles
                            this.EditorDeGrafos_Paint(this, null);//Detalles
                        }
                        #endregion

                        #region Camino
                        else
                        {
                            if (grafo.nodosImpares() == 2)//Si tiene 2 nodos de grado impar tiene camino
                            {
                                if (grafo.paresParejos())
                                {

                                    this.recorrido = grafo.caminoEuleriano();
                                    euler = new Euler(recorrido, "Existe el Camino", relojEuler);
                                    euler.borra_Recorrido += new Euler.Borra_Recorrido(this.redibujaGrafo);
                                    rec = 0;
                                    bandRecorrido = false;
                                    euler.Show();
                                    this.EditorDeGrafos_Paint(this, null);
                                }
                                else
                                {
                                    MessageBox.Show("Un nodo no cumple con las condiciones para poder hacer un ciclo", "No existe");
                                }
                            }
                            else
                            {
                                MessageBox.Show("El Grafo no tiene ni camino ni circuito", "No existe");
                            }
                        }
                        #endregion
                    }
                    else//Si tiene un nodo aislado tiene circuito y camino
                    {
                        MessageBox.Show("El grafo tiene un nodo aislado, por lo tanto no existe camino ni circuito", "No existe");
                    }
                    #endregion
                break;
                case "Dijkstra":
                    #region Dijkstra
                    Dijkstra dijkstra;
                    dijkstra = new Dijkstra(grafo, this.relojDijkstra);
                    dijkstra.dijsktra += new Dijkstra.EventoDijkstra(this.dijkstra);
                    dijkstra.borraRecorrido += new Dijkstra.BorraRecorrido(this.redibujaGrafo);
                    dijkstra.vector += new Dijkstra.VectorOrigen(grafo.vectorDijkstra);
                    if(!grafo.Ponderado)
                    {
                        grafo.Ponderado = true;
                    }
                    dijkstra.Show();
                    #endregion
                break;
                case "BBP":                
                    #region Bosqueda de Busqueda Profunda
                    SeleccionRaiz seleccion;
                    AristasBBP aristasBBP;
                    Stack<string> rama;
                    List<List<string>> ramas;
                    rama = new Stack<string>();
                    ramas = new List<List<string>>();
                    seleccion = new SeleccionRaiz(grafo);
                    if (seleccion.ShowDialog() == DialogResult.OK)
                    {
                        grafo.eliminaBosque();
                        grafo.bosqueBusquedaProfunda(grafo.BuscaNodo(seleccion.Raiz), 0, rama, ref ramas);
                        foreach (Nodo nodo in this.grafo)
                        {
                            if (nodo.Erdos == -1)
                            {
                                rama = new Stack<string>();
                                grafo.bosqueBusquedaProfunda(nodo, 0, rama, ref ramas);
                            }
                        }
                        aristasBBP = new AristasBBP(this.grafo);
                        g.Clear(BackColor);
                        grafo.DibujaGrafoBosque(g);
                        aristasBBP.ShowDialog();
                        aristasBBP.Dispose();
                        this.EditorDeGrafos_Paint(this, null);
                    }
                    seleccion.Dispose();
                    #endregion
                break;
                case "Aciclicidad":
                    #region Prueba de  Aciclicidad
                    List<List<string>> bucles;
                    bucles = new List<List<string>>();
                    List<string> arbol;
                    List<string> cruce;
                    List<string> avance;
                    List<string> retroceso;
                    if (!grafo.pruebaDeAciclicidad(ref bucles))
                    {
                        if ((MessageBox.Show("Existen: "+bucles.Count.ToString() +" ciclos en el grafo \n ¿Desea ver la simulación de los ciclos?", bucles.Count.ToString() + " ciclos", MessageBoxButtons.YesNo).Equals(DialogResult.Yes)))
                        {
                            Ciclos ciclos;
                            grafo.eliminaBosque();
                            List<List<string>> ramas2;
                            Stack<string> rama2;
                            rama2 = new Stack<string>();
                            ramas2 = new List<List<string>>();
                            grafo.bosqueBusquedaProfunda(grafo.First(), 0, rama2, ref ramas2);
                            foreach (Nodo nodo in this.grafo)
                            {
                                if (nodo.Erdos == -1)
                                {
                                    rama = new Stack<string>();
                                    grafo.bosqueBusquedaProfunda(nodo, 0, rama2, ref ramas2);
                                }
                            }
                            arbol =  grafo.AristasArbol;
                            cruce = grafo.AristasCruce;
                            avance = grafo.AristasAvance;
                            retroceso = grafo.AristasRetroceso;
                            ciclos = new Ciclos(bucles, relojCiclos, arbol, cruce, avance, retroceso);
                            ciclos.ciclo += new Ciclos.EventoCiclos(this.actualizaCiclo);
                            ciclos.borraRecorrido += new Ciclos.BorraRecorrido(this.redibujaGrafo);
                            ciclos.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("El grafo no presenta ningun ciclo");
                    }
                    #endregion
                break;
                case "Floyd":
                    #region Floyd
                    Floyd floyd;
                    string[,] caminos;
                    caminos = grafo.matrizCaminos();
                    floyd = new Floyd(this.grafo.matrizDeCostos(), this.grafo.FloydWarshall(ref caminos), this.grafo, caminos,this.relojFloyd);
                    floyd.floyd += new Floyd.EventoFloyd(this.floyd);
                    floyd.borraRecorrido += new Floyd.BorraRecorrido(this.redibujaGrafo);
                    floyd.Show();
                    #endregion
                break;
                default:
                    #region Inexistente
                    MessageBox.Show("Este metodo no esta disponible para los Grafos Dirigidofos", "Metodo Inexistente");
                    #endregion
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
                    #region Grados
                    GradosNoDir grados;
                    grados = new GradosNoDir((GrafoNoDirigido)this.grafo);
                    grados.ShowDialog();
                    grados.Dispose();
                    #endregion
                break;
                case "MAdyacencia":
                    #region Matriz de Adyacencia
                    MatrizDeAdyacencia matrizA;
                    matrizA = new MatrizDeAdyacencia(grafo.grafoMatriz());
                    matrizA.ShowDialog();
                    matrizA.Dispose();
                    #endregion
                break;
                case "MIncidencia":
                    #region Matriz de Adyacencia
                    MatrizDeIncidencia matrizI;
                    grafo.actualizaId();
                    matrizI = new MatrizDeIncidencia(grafo.matrizDeIncidencia(), grafo.Count, grafo.Aristas / 2, grafo);
                    matrizI.ShowDialog();
                    matrizI.Dispose();
                    #endregion
                break;
                case "LAdyacencia":
                    #region Lista Adyacencia
                    ListaDeAdyacencia lista;
                    lista = new ListaDeAdyacencia(this.grafo);
                    lista.ShowDialog();
                    lista.Dispose();
                    #endregion
                break;
                case "Pendientes":
                    #region Pendietes & Aislados
                    List<Nodo> pendientes;//Lista de pendientes
                    List<Nodo> soportes;//Lista de cuts
                    List<Nodo> aislados;
                    pendientes = grafo.nodosPendientes();//Obtiene todos los nodos pendientes
                    aislados = grafo.nodosAislados();
                    if (pendientes.Count != 0)
                    {
                        soportes = grafo.DibujaGrafo(g, pendientes, aislados);//Obtiene los nodos cuts y los dibuja junto con los pendientes
                        PendientesYAislados pendientesYCuts = new PendientesYAislados(pendientes, soportes, aislados);//Crea el dialogo que muestra la informacion
                        pendientesYCuts.ShowDialog();//Muestra el dialogo
                        pendientesYCuts.Dispose();//Destruye el dialogo
                    }
                    else
                    {
                        MessageBox.Show("El grafo no tiene nodos pendientes", "Sin Pendientes");
                    }
                    this.EditorDeGrafos_Paint(this, null);//Borra los nodos cuts & pendientes
                    #endregion
                break;
                case "TamOrd":
                    #region Tamaño y Orden
                    TamañoYOrden tamOrd;
                    tamOrd = new TamañoYOrden(grafo.Count, grafo.Aristas);
                    tamOrd.ShowDialog();
                    tamOrd.Dispose();
                    #endregion
                break;
                case "Complemento":
                    #region Complemento
                    this.grafo.complemento(this.colorLinea, this.anchoLineaA);
                    this.grafo.actualizaId();
                    this.EditorDeGrafos_Paint(this, null);
                    #endregion
                break;
                case "Isomorfismo":
                    #region Isomorfismo
                    Isomorfismo isomorfismo;
                    Grafo grafito;
                    GrafoSecundario sGrafo;
                    List<int[,]> pasos;
                    List<int> cambiados;
                    int[] cambios;
                    bool band;
                    int[,] matrizCambio;
                    sGrafo = new GrafoSecundario(grafo);
                    pasos = new List<int[,]>();
                    cambios = new int[grafo.Count];
                    cambiados = new List<int>();
                    if (sGrafo.ShowDialog() == DialogResult.OK)
                    {
                        grafito = sGrafo.Grafo;
                        if (grafo.Count == grafito.Count)
                        {
                            if (grafo.Aristas == grafito.Aristas)
                            {
                                pasos.Add(grafito.matrizDeAdyacencia());
                                band = grafo.isomorfismo(grafo.matrizDeAdyacencia(), grafito.matrizDeAdyacencia(), ref pasos, ref cambios);
                                matrizCambio = grafito.matrizDeAdyacencia();
                                if (band)
                                {
                                    MessageBox.Show("Los grafos SI son Isomorficos!! =)","Si Son Isomorficos");
                                }
                                else
                                {
                                    MessageBox.Show("Los grafos No son Isomorficos!! =(", "No Son Isomorficos");
                                }
                                for (int i = 0; i < grafito.Count; i++ )
                                {
                                    if(!MetodosAuxiliares.seAhCambio(i,cambiados) && !MetodosAuxiliares.seAhCambio(cambios[i],cambiados))
                                    {
                                        matrizCambio = MetodosAuxiliares.cambioIsomorfico(matrizCambio, i, cambios[i]);
                                        cambiados.Add(i);
                                        cambiados.Add(cambios[i]);
                                    }
                                }
                                isomorfismo = new Isomorfismo(grafo, grafito, pasos, cambios, band,  matrizCambio);
                                isomorfismo.ShowDialog();
                                isomorfismo.Dispose();
                            }
                            else
                            {
                                MessageBox.Show("Los grafos no tienen la misma cantidad de aristas no son isomorficos", "No son isomorficos");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Los grafos no tienen la misma cantidad de nodos no son isomorficos", "No son isomorficos");
                        }
                    }
                    #endregion
                break;
                case "Euler":
                    #region Euler
                    Euler euler;
                    if (!grafo.aislado()/* && !grafo.componentesSeparados()*/)//Si no tiene un nodo aislado puede que tenga circuito o camino
                    {
                        #region Circuito
                        if (grafo.gradosPares())//Si todos sus nodos son de grado par Existe circuito
                        {
                            /**/
                            this.recorrido = grafo.circuitoEuleriano();
                            euler = new Euler(recorrido, "Existe el circuito", relojEuler);
                            euler.borra_Recorrido += new Euler.Borra_Recorrido(this.redibujaGrafo);
                            rec = 0;
                            bandRecorrido = false;
                            euler.Show();
                            this.EditorDeGrafos_Paint(this, null);
                        }
                        #endregion

                        #region Camino
                        else
                        {
                            if (grafo.nodosImpares() == 2)//Si tiene 2 nodos de grado impar tiene camino
                            {
                                this.recorrido = grafo.caminoEuleriano();
                                /**/
                                euler = new Euler(recorrido, "Existe el Camino", relojEuler);
                                euler.borra_Recorrido += new Euler.Borra_Recorrido(this.redibujaGrafo);
                                rec = 0;
                                bandRecorrido = false;
                                euler.Show();
                                this.EditorDeGrafos_Paint(this, null);
                            }
                            else
                            {
                                MessageBox.Show("El Grafo no tiene ni camino ni circuito", "No existe");
                            }
                        }
                        #endregion
                    }
                    else//Si tiene un nodo aislado tiene circuito y camino
                    {
                        MessageBox.Show("El grafo tiene un nodo aislado, por lo tanto no existe camino ni circuito", "No existe");
                    }
                    #endregion
                break;
                case "Hamilton":
                    #region Hamilton
                    if (grafo.aislado())
                    {
                    }
                    else
                    {
                        MessageBox.Show("No existe circuito ni camino Hamiltoniano", "Tiene un nodo aislado");
                    }
                    #endregion
                break;
                case "Corolarios":
                    #region Corolarios
                    Corolarios corolarios;
                    corolarios = new Corolarios(this.grafo);
                    corolarios.ShowDialog();
                    corolarios.Dispose();
                    #endregion
                break;
                case "Regiones":
                    #region Regiones
                    Regiones regiones;
                    regiones = new Regiones(this.grafo);
                    regiones.ShowDialog();
                    regiones.Dispose();
                    #endregion
                break;
                case  "Kuratowski":
                    #region Kuratowski
                    Kuratowski kuratowski;
                    kuratowski = new Kuratowski(this.grafo);
                    kuratowski.ShowDialog();
                    kuratowski.Dispose();
                    #endregion
                break;
                case "Teorema4C":
                    #region Teorema 4 Colores
                    List<Partita> partitas;
                    partitas = grafo.nPartita(); //Obtiene en una lista de listas para sacar los nombres de las partitas
                    if (partitas.Count == 4)
                    {
                        grafo.DibujaGrafo(g, partitas);//Se llenan los nombres de las partitas
                        if (MessageBox.Show("El grafo si cumple con el teorema de los 4 colores \n ¿Desea ver los conjuntos?", "Si cumple", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            Partitas partitasdlg = new Partitas(partitas);//Se crea un dialogo con los nombres de las partitas
                            partitasdlg.ShowDialog();//Muestra el dialogo
                            partitasdlg.Dispose();//Borra el dialogo
                        }
                    }
                    else
                    {
                        MessageBox.Show("El grafo no cumple con el teorema de los 4 colores", "No cumple");
                    }
                    this.EditorDeGrafos_Paint(this, null);
                    #endregion
                break;
                case "NumeroC":
                    #region Numero Cromatico
                    List<Partita> colores;
                    colores = grafo.nPartita(); //Obtiene en una lista de listas para sacar los nombres de las partitas
                    grafo.DibujaGrafo(g, colores);//Se llenan los nombres de las partitas
                    if (MessageBox.Show("El número cromatico es: " + colores.Count.ToString() + "\n" + "¿Desea ver los conjuntos?", "Numero Cromatico", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Partitas partitasdlg = new Partitas(colores);//Se crea un dialogo con los nombres de las partitas
                        partitasdlg.ShowDialog();//Muestra el dialogo
                        partitasdlg.Dispose();//Borra el dialogo
                    }
                    this.EditorDeGrafos_Paint(this, null);
                    #endregion
                break;
                case "BBA":
                    #region Bosqueda de Busqueda Profunda
                    SeleccionRaiz seleccion;
                    AristasBBA aristasBBA;
                    seleccion = new SeleccionRaiz(grafo);
                    if (seleccion.ShowDialog() == DialogResult.OK)
                    {
                        List<Nodo> nivel;
                        List<string> aristasArbol;
                        List<string> aristasCruce;
                        Nodo raiz;
                        nivel = new List<Nodo>();
                        aristasArbol = new List<string>();
                        aristasCruce = new List<string>();
                        raiz = grafo.BuscaNodo(seleccion.Raiz);
                        raiz.visitado = true;
                        nivel.Add(raiz);
                        grafo.eliminaBosque();
                        grafo.bosqueBusquedaAmplitud(nivel,ref aristasArbol, ref aristasCruce);
                        foreach (Nodo nodo in this.grafo)
                        {
                            if (!nodo.visitado)
                            {
                                nivel.Clear();
                                nivel.Add(nodo);
                                nodo.visitado = true;
                                grafo.bosqueBusquedaAmplitud(nivel, ref aristasArbol, ref aristasCruce);
                            }
                        }
                        aristasBBA = new AristasBBA(this.grafo,aristasArbol,aristasCruce);
                        g.Clear(BackColor);
                        grafo.DibujaGrafoBosque(g);
                        aristasBBA.ShowDialog();
                        aristasBBA.Dispose();
                        this.EditorDeGrafos_Paint(this, null);
                    }
                    seleccion.Dispose();
                    #endregion
                break;
                case "Kruskal":
                    #region Kruskal
                    Kruskal kruskal;
                    List<Arista> aristas;
                    List<string> componente;
                    List<List<string>> componentes;
                    componentes = new List<List<string>>();//Genero una lista de listas
                    aristas = grafo.LAristas.OrderBy(arista => arista.Peso).ToList();//Ordena las aristas segun su peso
                    foreach (Nodo nodo in this.grafo)//Se crea un componente por cada nodo y se añade a la lista de nodos
                    {
                        componente = new List<string>();
                        componente.Add(nodo.Nombre);
                        componentes.Add(componente);
                    }
                    aristas = grafo.Kruskal(ref componentes, aristas);//Invocacmos al metodo en el grafo
                    kruskal = new Kruskal(aristas);
                    //g.Clear(BackColor);
                    grafo.dibujaArbolCostoMinimo(this.g, aristas);
                    kruskal.ShowDialog();
                    kruskal.Dispose();
                    g.Clear(BackColor);
                    grafo.DibujaGrafo(g);
                    #endregion
                break;
                default:
                    #region Inexistente
                    MessageBox.Show("Este metodo no esta disponible para los Grafos No Dirigidofos", "Metodo Inexistente");
                    #endregion
                break;
            }
            #endregion
        }

        private void MetodosTool_Clicked(object sender, ToolStripItemClickedEventArgs e)
        {
            #region Toolbar Metodos
            switch (e.ClickedItem.AccessibleName)
            {
                case "GrafoNull":

                    #region GrafoNulo
                    if (!typeof(GrafoNoDirigido).IsInstanceOfType(grafo) && !typeof(GrafoDirigido).IsInstanceOfType(grafo))
                    {
                        MessageBox.Show("El grafo no tiene aristas por lo tanto es nulo","Grafo nulo");
                    }
                    else
                    {
                        MessageBox.Show("El grafo tiene aristas por lo tanto no es nulo", "Grafo no nulo");
                    }
                    #endregion

                break;
                default :

                    #region GrafoDirigido
                    if (typeof(GrafoDirigido).IsInstanceOfType(grafo))
                    {
                        this.Dirigido_Clicked(sender, e);
                    }
                    #endregion

                    #region GrafoNoDirigido
                    else if (typeof(GrafoNoDirigido).IsInstanceOfType(grafo))
                    {
                        this.NoDirigido_Clicked(sender, e);
                    }
                    #endregion

                    #region Grafo
                    else
                    {
                        MessageBox.Show("Primero debe definir si un grafo es dirigido o no dirigido", "Por favor Inserte Arista");   
                    }
                    #endregion

                break;
            }            
            #endregion
        }

        private void Especiales_Clicked(object sender, ToolStripItemClickedEventArgs e)
        {
            #region Grafos Especiales
            IFormatter formater;
            Stream stream;
            switch (e.ClickedItem.AccessibleName)
            {
                case "Kn":
                    #region Kn
                    if (!numericKn.Visible)
                    {
                        numericKn.Visible = true;
                        numericCn.Visible = false;
                        numericWn.Visible = false;
                        this.deshabititaOpciones();
                        this.habilitaOpcionesGrafo();
                        this.habilitaOpcionesGrafoNoDirigido();
                        this.grafo.Clear();
                        this.numNodos = 1;
                        this.grafo = new GrafoNoDirigido(grafo);
                        this.grafo.CreaKn(this.ClientSize, (int)numericKn.Value, ref this.numNodos, this.tamNodo,
                                          this.altoName, this.brushRelleno, this.brushName, this.penNodo, this.penArista, this.fuente);
                        if (grafo.Count > 26)
                        {
                            this.grafo.Tipo = true;
                        }
                        else
                        {
                            grafo.CambiaNombre();
                        }
                        grafo.actualizaId();
                        nombre = ConvierteNombre(numNodos);
                        this.EditorDeGrafos_Paint(this, null);
                    }
                    else
                    {
                        numericKn.Visible = false;
                    }
                    #endregion
                break;
                case "Cn":
                    #region Cn
                    if (!numericCn.Visible)
                    {
                        numericKn.Visible = false;
                        numericCn.Visible = true;
                        numericWn.Visible = false;
                        this.deshabititaOpciones();
                        this.habilitaOpcionesGrafo();
                        this.habilitaOpcionesGrafoNoDirigido();
                        this.grafo.Clear();
                        this.numNodos = 1;
                        this.grafo = new GrafoNoDirigido(grafo);
                        this.grafo.CreaCn(this.ClientSize, (int)numericCn.Value, ref this.numNodos, this.tamNodo,
                                          this.altoName, this.brushRelleno, this.brushName, this.penNodo, this.penArista, this.fuente);
                        if (grafo.Count > 26)
                        {
                            this.grafo.Tipo = true;
                        }
                        else
                        {
                            grafo.CambiaNombre();
                        }
                        nombre = ConvierteNombre(numNodos);
                        this.grafo.actualizaId();
                        this.EditorDeGrafos_Paint(this, null);
                    }
                    else
                    {
                        numericCn.Visible = false;
                    }
                    #endregion
                break;
                case "Wn":
                    #region Wn
                    if (!numericWn.Visible)
                    {
                        numericCn.Visible = false;
                        numericKn.Visible = false;
                        numericWn.Visible = true;
                        this.deshabititaOpciones();
                        this.habilitaOpcionesGrafo();
                        this.habilitaOpcionesGrafoNoDirigido();
                        this.grafo.Clear();
                        this.numNodos = 1;
                        this.grafo = new GrafoNoDirigido(grafo);
                        this.grafo.CreaWn(this.ClientSize, (int)numericWn.Value, ref this.numNodos, this.tamNodo,
                                          this.altoName, this.brushRelleno, this.brushName, this.penNodo, this.penArista, this.fuente);
                        if (grafo.Count > 26)
                        {
                            this.grafo.Tipo = true;
                        }
                        else
                        {
                            grafo.CambiaNombre();
                        }
                        nombre = ConvierteNombre(numNodos);
                        this.grafo.actualizaId();
                        this.EditorDeGrafos_Paint(this, null);
                    }
                    else
                    {
                        numericWn.Visible = false;
                    }
                    #endregion
                break;
                case "Q3":
                    #region Q3
                    numericKn.Visible = false;
                    numericCn.Visible = false;
                    numericWn.Visible = false;
                    formater = new BinaryFormatter();
                    stream = new FileStream(Environment.CurrentDirectory +@"..\Grafos\Especiales\Q3.grafo",
                                                    FileMode.Open,FileAccess.Read, FileShare.None);
                    grafo = (Grafo)formater.Deserialize(stream);
                    //this.pref.Dispose();
                    nodo = grafo[0];
                    nombre = grafo[grafo.Count - 1].Nombre;
                    try
                    {
                        numNodos = Int32.Parse(nombre);
                    }
                    catch (FormatException)
                    {
                        char aux = nombre[0];
                        numNodos = aux - 64;
                    }
                    numNodos++;
                    nombre = ConvierteNombre(numNodos);
                    /*this.pref = new Preferencias(nodo.AnchoContorno, nodo.TamNodo, nodo.TamLetra,
                                                1, this.colorDefault, nodo.ColorFuera,
                                                nodo.BrushRelleno, nodo.BrushName);
                    PreferenciasBack(pref);*/
                    stream.Close();
                    g.Clear(BackColor);
                    grafo.DibujaGrafo(g);
                    this.habilitaOpcionesGrafo();
                    this.habilitaOpcionesGrafoNoDirigido();
                    #endregion
                break;
            }
            #endregion
        }

        private void Configuracion_Clicked(object sender, ToolStripItemClickedEventArgs e)
        {
            #region Configuración
            switch (e.ClickedItem.AccessibleName)
            {
                case "EtiquetasNodo":
                    #region EtiquetasNodo
                    grafo.Tipo = !grafo.Tipo;
                    grafo.CambiaNombre();
                    this.EditorDeGrafos_Paint(this, null);
                    this.nombre = ConvierteNombre(this.numNodos);
                    #endregion
                break;
                case "pesosArista":
                    #region Pesos Arista
                    grafo.Ponderado = !grafo.Ponderado;
                    this.EditorDeGrafos_Paint(this,null);
                    #endregion
                break;
            }
            #endregion
        }


        private void EspecialesToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            int[,] matriz;
            int aux;
            Grafo grafito;
            grafito = new GrafoNoDirigido(grafo,true);
            aux = 0;
            grafito.Clear();
            switch (e.ClickedItem.AccessibleName)
            {
                case "Kn":
                    grafito.CreaKn(this.ClientSize, this.grafo.Count, ref aux, this.tamNodo,
                                      this.altoName, this.brushRelleno, this.brushName, this.penNodo, this.penArista, this.fuente);
                    matriz = grafito.matrizDeAdyacencia();
                    break;
                case "Cn":
                    grafito.CreaCn(this.ClientSize, this.grafo.Count, ref aux, this.tamNodo,
                                      this.altoName, this.brushRelleno, this.brushName, this.penNodo, this.penArista, this.fuente);
                    matriz = grafito.matrizDeAdyacencia();
                    break;
                case "Wn":
                    grafito.CreaWn(this.ClientSize, this.grafo.Count, ref aux, this.tamNodo,
                                      this.altoName, this.brushRelleno, this.brushName, this.penNodo, this.penArista, this.fuente);
                    matriz = grafito.matrizDeAdyacencia();
                    break;
                default:
                    return;
                break;
            }
            this.verificaGrafo(matriz, e.ClickedItem.AccessibleName.First().ToString());
        }

        private void verificaGrafo(int[,] matriz, string verifica)
        {
            bool band;
            List<int[,]> pasos;
            int[] cambios;
            int[,] matrix;
            matrix = grafo.matrizDeAdyacencia();
            pasos = new List<int[,]>();
            cambios = new int[grafo.Count];
            band = grafo.isomorfismo(matrix, matriz,ref pasos,ref cambios);
            if (band)
            {
                verifica = "Si es un grafo" + verifica + grafo.Count.ToString();
            }
            else
            {
                verifica = "No es un grafo" + verifica + grafo.Count.ToString();
            }
            MessageBox.Show(verifica);
        }

        #endregion

        #region Mouse

        private void EditorDeGrafos_MouseDown(object sender, MouseEventArgs e)
        {
            switch (opcion)
            {
                case 1://Insertar Nodo
                    p1 = e.Location;
                    pe.X = p1.X - (tamNodo / 2);
                    pe.Y = p1.Y - (tamNodo / 2);
                    nodo = new Nodo(nombre, pe, p1, penNodo.Color, brushRelleno.Color, brushName.Color, tamNodo, altoName, anchoLineaN, fuente);
                    if (numNodos == 27)
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
                case 3://Borrar Nodo
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
                    p1 = e.Location;
                    bandFinal = grafo.BuscaNodo(ref nodo, p1);
                    break;
                case 5://Mover Grafo
                    p1 = e.Location;
                    bandFinal = grafo.BuscaNodo(ref nodo, p1);
                    break;
                case 6://EliminaArista
                    grafo.BorraArista(e.Location);
                    if (typeof(GrafoDirigido).IsInstanceOfType(grafo))
                    {
                        this.numAristas = grafo.Aristas;
                    }
                    else if(typeof(GrafoNoDirigido).IsInstanceOfType(grafo))
                    {
                        this.numAristas = grafo.Aristas/2;
                    }
                    if (grafo.Aristas == 0)
                    {
                        this.grafo = new Grafo(this.grafo);
                        this.numAristas = 0;
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
            PesosAristas pesos;
            switch (opcion)
            {
                case 2://AristaNoDirigida
                    #region  Arista no Dirigida
                    pesos = new PesosAristas(true);
                    if (grafo.BuscaNodo(ref p2) && bandArista && band)
                    {
                        if (pesos.ShowDialog().Equals(DialogResult.OK))
                        {
                            if (!typeof(GrafoNoDirigido).IsInstanceOfType(grafo))
                            {
                                grafo = new GrafoNoDirigido(grafo);
                                this.habilitaOpcionesGrafoNoDirigido();
                            }
                            if (!p1.Equals(p2))
                            {
                                    numAristas++;
                                    this.pI2 = MetodosAuxiliares.PuntoInterseccion(this.p2, this.p1, tamNodo / 2);
                                    this.grafo.InsertaArista(this.p1, this.p2, pesos.Valor, this.anchoLineaA, this.penArista.Color, numAristas);
                                    this.grafo.InsertaArista(this.p2, this.p1, pesos.Valor, this.anchoLineaA, this.penArista.Color, numAristas);
                                    band = false;
                                    bandFinal = true;
                                    bandArista = false;
                            }
                            else
                            {
                                    numAristas++;
                                    this.pI2 = MetodosAuxiliares.PuntoInterseccion(this.p2, this.p1, tamNodo / 2);
                                    this.grafo.InsertaArista(this.p1, this.p2, 0, this.anchoLineaA, this.penArista.Color,numAristas);
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
                    pesos = new PesosAristas(true);
                    if (grafo.BuscaNodo(ref p2) && bandArista && band)
                    {
                        if (pesos.ShowDialog().Equals(DialogResult.OK))
                        {
                            if (!typeof(GrafoDirigido).IsInstanceOfType(grafo))
                            {
                                grafo = new GrafoDirigido(grafo);
                                this.habilitaOpcionesGrafoDirigido();
                            }
                            if (!p1.Equals(p2))
                            {
                                numAristas++;
                                this.pI2 = MetodosAuxiliares.PuntoInterseccion(this.p2, this.p1, tamNodo / 2);
                                this.grafo.InsertaArista(this.p1, this.p2, pesos.Valor, this.anchoLineaA, this.penArista.Color, numAristas);
                                band = false;
                                bandFinal = true;
                                bandArista = false;
                            }
                            else
                            {
                                numAristas++;
                                this.pI2 = MetodosAuxiliares.PuntoInterseccion(this.p2, this.p1, tamNodo / 2);
                                this.grafo.InsertaArista(this.p1, this.p2, pesos.Valor, this.anchoLineaA, this.penArista.Color, numAristas);
                                band = false;
                                bandFinal = true;
                                bandArista = false;
                                bandFinal = false;
                                band = false;
                            }
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
            Point p = new Point(EspecialesTool.Location.X - 40, 0);
            p.Y = numericKn.Location.Y;
            numericKn.Location = p;
            p.Y = numericCn.Location.Y;
            numericCn.Location = p;
            p.Y = numericWn.Location.Y;
            numericWn.Location = p;
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
                            numNodos++;
                            this.nombre = ConvierteNombre(numNodos);
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

        #region numeric

        private void numericKn_ValueChanged(object sender, EventArgs e)
        {
            this.deshabititaOpciones();
            this.habilitaOpcionesGrafo();
            this.habilitaOpcionesGrafoNoDirigido();
            this.grafo.Clear();
            this.numNodos = 1;
            this.grafo = new GrafoNoDirigido(grafo);
            this.grafo.CreaKn(this.ClientSize, (int)numericKn.Value, ref this.numNodos, this.tamNodo,
                              this.altoName, this.brushRelleno, this.brushName, this.penNodo, this.penArista, this.fuente);
            if (grafo.Count > 26)
            {
                this.grafo.Tipo = true;
            }
            else
            {
                grafo.CambiaNombre();
            }
            nombre = ConvierteNombre(numNodos);
            grafo.actualizaId();
            this.numAristas = grafo.Aristas/2;
            this.EditorDeGrafos_Paint(this, null);
        }

        private void numericCn_ValueChanged(object sender, EventArgs e)
        {
            this.deshabititaOpciones();
            this.habilitaOpcionesGrafo();
            this.habilitaOpcionesGrafoNoDirigido();
            this.grafo.Clear();
            this.numNodos = 1;
            this.grafo = new GrafoNoDirigido(grafo);
            this.grafo.CreaCn(this.ClientSize, (int)numericCn.Value, ref this.numNodos, this.tamNodo,
                              this.altoName, this.brushRelleno, this.brushName, this.penNodo, this.penArista, this.fuente);
            if (grafo.Count > 26)
            {
                this.grafo.Tipo = true;
            }
            else
            {
                grafo.CambiaNombre();
            }
            nombre = ConvierteNombre(numNodos);
            grafo.actualizaId();
            this.numAristas = grafo.Aristas/2;
            this.EditorDeGrafos_Paint(this, null);
        }

        private void numericWn_ValueChanged(object sender, EventArgs e)
        {
            this.deshabititaOpciones();
            this.habilitaOpcionesGrafo();
            this.habilitaOpcionesGrafoNoDirigido();
            this.grafo.Clear();
            this.numNodos = 1;
            this.grafo = new GrafoNoDirigido(grafo);
            this.grafo.CreaWn(this.ClientSize, (int)numericWn.Value, ref this.numNodos, this.tamNodo,
                              this.altoName, this.brushRelleno, this.brushName, this.penNodo, this.penArista, this.fuente);
            if (grafo.Count > 26)
            {
                this.grafo.Tipo = true;
            }
            else
            {
                grafo.CambiaNombre();
            }
            nombre = ConvierteNombre(numNodos);
            grafo.actualizaId();
            this.numAristas = grafo.Aristas/2;
            this.EditorDeGrafos_Paint(this, null);
        }

        #endregion

        #region Timer
        private void relojCiclos_Tick(object sender, EventArgs e)
        {
            Graphics gAux;
            gAux = CreateGraphics();
            gAux = Graphics.FromImage(bmp);
            anterior = actual;
            if (rec > recorrido.Count - 1)
            {
                rec = 0;
                gAux.Clear(BackColor);
                grafo.DibujaGrafo(gAux);
                bandRecorrido = false;
            }
            if (!bandRecorrido)
            {
                actual = grafo.BuscaNodo(recorrido[rec].ToString());
                actual.dibujaNodo(gAux, Color.Blue);
                rec++;
            }
            else
            {
                anterior.dibujaNodo(gAux, Color.Red);
                actual = grafo.BuscaNodo(recorrido[rec].ToString());
                this.arista = grafo.buscaArista(anterior.Nombre, actual.Nombre);
                this.arista.dibujaArista(gAux, true, true, Color.Green);
            }
            bandRecorrido = !bandRecorrido;
            g.DrawImage(bmp, 0, 0);
        }

        private void relojFloyd_Tick(object sender, EventArgs e)
        {
            Graphics gAux;
            gAux = CreateGraphics();
            gAux = Graphics.FromImage(bmp);
            anterior = actual;
            if (rec > recorrido.Count - 1)
            {
                rec = 0;
                gAux.Clear(BackColor);
                grafo.DibujaGrafo(gAux);
                bandRecorrido = false;
            }
            if (!bandRecorrido)
            {
                actual = grafo.BuscaNodo(recorrido[rec].ToString());
                actual.dibujaNodo(gAux, Color.Blue);
                rec++;
            }
            else
            {
                anterior.dibujaNodo(gAux, Color.Red);
                actual = grafo.BuscaNodo(recorrido[rec].ToString());
                this.arista = grafo.buscaArista(anterior.Nombre, actual.Nombre);
                this.arista.dibujaArista(gAux, true, true, Color.Green);
            }
            bandRecorrido = !bandRecorrido;
            g.DrawImage(bmp, 0, 0);
        }

        private void relojDijkstra_Tick(object sender, EventArgs e)
        {
            Graphics gAux;
            gAux = CreateGraphics();
            gAux = Graphics.FromImage(bmp);
            anterior = actual;
            if (rec > recorrido.Count - 1)
            {
                rec = 0;
                gAux.Clear(BackColor);
                grafo.DibujaGrafo(gAux);
                bandRecorrido = false;
            }
            if (!bandRecorrido)
            {
                actual = grafo.BuscaNodo(recorrido[rec].ToString());
                actual.dibujaNodo(gAux, Color.Blue);
                rec++;
            }
            else
            {
                anterior.dibujaNodo(gAux, Color.Red);
                actual = grafo.BuscaNodo(recorrido[rec].ToString());
                this.arista = grafo.buscaArista(anterior.Nombre, actual.Nombre);
                this.arista.dibujaArista(gAux, true, true, Color.Green);
            }
            bandRecorrido = !bandRecorrido;
            g.DrawImage(bmp, 0, 0);
        }

        private void relojEuler_Tick(object sender, EventArgs e)
        {
            Graphics gAux;
            gAux = CreateGraphics();
            gAux = Graphics.FromImage(bmp);
            anterior = actual;
            if (rec > recorrido.Count - 1)
            {
                rec = 0;
                gAux.Clear(BackColor);
                grafo.DibujaGrafo(gAux);
                bandRecorrido = false;  
            }
            if (!bandRecorrido)
            {
                actual = grafo.BuscaNodo(recorrido[rec].ToString());
                actual.dibujaNodo(gAux, Color.Blue);
                rec++;
            }
            else
            {
                anterior.dibujaNodo(gAux, Color.Red);
                actual = grafo.BuscaNodo(recorrido[rec].ToString());
                this.arista = grafo.buscaArista(anterior.Nombre, actual.Nombre);
                this.arista.dibujaArista(gAux, true, false, Color.Green);
            }
            bandRecorrido = !bandRecorrido;
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
            CrearNodo.Enabled = true;
            CrearNodoTool.Enabled = true;
            AbrirTool.Enabled = true;
            GuardarTool.Enabled = true;
            grafoDirigidoToolStripMenuItem.Enabled = false;
            grafoNoDirigidoToolStripMenuItem.Enabled = true;
            AristaDirigida.Enabled = false;
            PonderaciónArista.Enabled = true;
            PonderaciónAristaTool.Enabled = true;
            pesosArista.Enabled = true;
            pesosAristaTool.Enabled = true;
            AristaDirigidaTool.Enabled = false;
            EliminarArista.Enabled = true;
            EliminarAristaTool.Enabled = true;
        }

        /**
         */
        private void habilitaOpcionesGrafoDirigido()
        {
            CrearNodo.Enabled = true;
            CrearNodoTool.Enabled = true;
            AbrirTool.Enabled = true;
            GuardarTool.Enabled = true;
            grafoDirigidoToolStripMenuItem.Enabled = true;
            grafoNoDirigidoToolStripMenuItem.Enabled = false;
            AristaNoDirigida.Enabled = false;
            AristaNoDirigidaTool.Enabled = false;
            pesosArista.Enabled = true;
            pesosAristaTool.Enabled = true;
            PonderaciónArista.Enabled = true;
            PonderaciónAristaTool.Enabled = true;
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
            PonderaciónArista.Enabled = false;
            PonderaciónAristaTool.Enabled = false;
            MoverNodoTool.Enabled = false;
            EliminarNodoTool.Enabled = false;
            AristaDirigidaTool.Enabled = false;
            AristaNoDirigidaTool.Enabled = false;
            EliminarAristaTool.Enabled = false;
            MoverGrafoTool.Enabled = false;
            EliminarGrafoTool.Enabled = false;
        }

        #endregion

        #region Area Cliente
        public void redibujaGrafo()
        {
            this.EditorDeGrafos_Paint(this, null);
        }
        #endregion

        #region Dijkstra
        public List<string> dijkstra(string origen, string destino)
        {
            this.recorrido = grafo.dijkstra(origen, destino);
            this.bandRecorrido = false;
            this.rec = 0;
            this.EditorDeGrafos_Paint(this, null);
            return this.recorrido;
        }
        #endregion

        #region Floyd

        private void floyd(List<string> recorrido)
        {
            this.recorrido = recorrido;
            this.bandRecorrido = false;
            this.rec = 0;
            this.EditorDeGrafos_Paint(this, null);
        }
        #endregion

        #region Pesos

        private void desactivaSpin()
        {
            if (typeof(GrafoDirigido).IsInstanceOfType(grafo))
            {
                #region Desactivacion y asignacion de pesos para grafos Dirigidos
                foreach (Nodo nodo in grafo)
                {
                    foreach (Arista arista in nodo.Aristas)
                    {
                        arista.Peso = (int)arista.numericPeso.Value;
                        this.Controls.Remove(arista.numericPeso);
                        arista.numericPeso.Dispose();
                    }
                }
                #endregion
            }
            if (typeof(GrafoNoDirigido).IsInstanceOfType(grafo))
            {
                #region Desactivacion y asignacion de pesos grafos no dirigidos
                foreach (Nodo nodo in grafo)
                {
                    foreach (Arista arista in nodo.Aristas)
                    {
                        if (arista.numericPeso != null)//Si es diferente a null significa que a el y a su reciproca aun no se le asigna un peso
                        {
                            arista.Peso = (int)arista.numericPeso.Value;
                            foreach (Arista reciproca in arista.Arriba.Aristas)
                            {
                                if (reciproca.Arriba.Nombre.Equals(nodo.Nombre))
                                {
                                    reciproca.Peso = (int)arista.numericPeso.Value;
                                    reciproca.numericPeso = null;
                                    break;
                                }
                            }
                            this.Controls.Remove(arista.numericPeso);
                            arista.numericPeso.Dispose();
                        }
                    }
                }
                #endregion
            }
        }

        private void activaSpin()
        {
            if (typeof(GrafoDirigido).IsInstanceOfType(grafo))
            {
                #region Activacion para grafos Dirigidos
                foreach (Nodo nodo in grafo)
                {
                    foreach (Arista arista in nodo.Aristas)
                    {
                        arista.numericPeso = new NumericUpDown();
                        arista.numericPeso.Value = arista.Peso;
                        if (arista.Arriba.existeReciproca(nodo))
                        {
                            Spline spline;
                            spline = new Spline(arista.P1, arista.P2);
                            arista.numericPeso.Location = new Point(spline.puntoMedio.X,spline.puntoMedio.Y);
                        }
                        else
                        {
                            arista.numericPeso.Location = new Point((int)((nodo.Pc.X + arista.Arriba.Pc.X) / 2),
                                                                    (int)((nodo.Pc.Y + arista.Arriba.Pc.Y) / 2));
                        }
                        arista.numericPeso.Size = new Size(40, 20);
                        this.Controls.Add(arista.numericPeso);
                    }
                }
                #endregion
            }
            if (typeof(GrafoNoDirigido).IsInstanceOfType(grafo))
            {
                #region Activacion para grafos no dirigidos
                foreach (Nodo nodo in grafo)
                {
                    foreach (Arista arista in nodo.Aristas)
                    {
                        if (arista.numericPeso == null)//Si es igual a null significa que a el y a su reciproca aun no se le asigna un spin
                        {
                            arista.numericPeso = new NumericUpDown();
                            arista.numericPeso.Location = new Point((int)((nodo.Pc.X + arista.Arriba.Pc.X) / 2),
                                                 (int)((nodo.Pc.Y + arista.Arriba.Pc.Y) / 2));
                            arista.numericPeso.Size = new Size(40, 20);
                            arista.numericPeso.Value = arista.Peso;
                            foreach (Arista reciproca in arista.Arriba.Aristas)
                            {
                                if (reciproca.Arriba.Nombre.Equals(nodo.Nombre))
                                {
                                    reciproca.numericPeso = arista.numericPeso;
                                    break;
                                }
                            }
                            this.Controls.Add(arista.numericPeso);
                        }
                    }
                }
                #endregion
            }
        }
        
        #endregion

        #region Ciclos

        public void actualizaCiclo(List<string> ciclo)
        {
            this.recorrido = ciclo;
            this.bandRecorrido = false;
            this.rec = 0;
            this.EditorDeGrafos_Paint(this, null);
        }

        #endregion

        #endregion

        private void MenuPrincipal_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}