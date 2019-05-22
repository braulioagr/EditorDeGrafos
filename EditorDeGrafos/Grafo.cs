using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditorDeGrafos
{
    [Serializable]
    class Grafo : List <Nodo>
    {

        #region Vairables de instancia
        protected Arista arista;
        protected Nodo nodo;
        protected bool tipo;//Numerico = true Alfabetico = false
        protected bool ponderado;
        #endregion

        #region Constructores
        public Grafo()
        {
            tipo = false;
            this.ponderado = false;
        }

        public Grafo(Grafo g)
        {
            foreach (Nodo n in g)
            {
                this.Add(n);
            }
            this.tipo = g.Tipo;
            this.ponderado = g.Ponderado;
        }

        public Grafo(Grafo g, bool p)
        {
            Nodo nodo;
            foreach (Nodo n in g)
            {
                nodo = new Nodo(n.Nombre, n.Pe, n.Pc, n.ColorFuera, n.BrushRelleno, n.BrushName, n.TamNodo, n.TamLetra, n.AnchoContorno, n.Fuente);
                this.Add(nodo);
            }
            this.Ponderado = g.Ponderado;
            this.tipo = g.Tipo;
        }
        #endregion

        #region Gets & Sets

        public bool Tipo
        {
            get { return this.tipo; }
            set { this.tipo = value; }
        }

        public bool Ponderado
        {
            get { return this.ponderado; }
            set { this.ponderado = value; }
        }

        public Arista nr
        {
            get { return this.arista; }
            set { this.arista = value; }
        }

        public Nodo Np
        {
            get { return this.nodo; }
            set { this.nodo = value; }
        }

        public int Aristas
        {
            get
            {
                int aristas;
                aristas = 0;
                foreach (Nodo busca in this)
                {
                    aristas += busca.Aristas.Count;
                }
                return aristas;
            }
        }

        public List<Arista> LAristas
        {
            get
            {
                List<Arista> aristas;
                aristas = new List<Arista>();
                foreach (Nodo nodo in this)
                {
                    foreach (Arista arista in nodo.Aristas)
                    {
                        aristas.Add(arista);
                    }
                }
                aristas = aristas.OrderBy(arista => arista.Id).ToList();
                return aristas;
            }
        }

        public string AristasArbol
        {
            get
            {
                string aristasArbol;
                aristasArbol = "";
                foreach (Nodo nodo in this)
                {
                    foreach (Arista arista in nodo.Aristas)
                    {
                        if (arista.Tipo.Equals("Arbol"))
                        {
                            aristasArbol += ", e" + arista.Id;
                        }
                    }
                }
                if (!string.IsNullOrEmpty(aristasArbol))
                {
                    aristasArbol = aristasArbol.Substring(1);
                }
                else
                {
                    aristasArbol = "No existen Aristas de Arbol";
                }
                return aristasArbol;

            }
        }

        public string AristasCruce
        {
            get
            {
                string aristasCruce;
                aristasCruce = "";
                foreach (Nodo nodo in this)
                {
                    foreach (Arista arista in nodo.Aristas)
                    {
                        if (arista.Tipo.Equals("Cruce"))
                        {
                            aristasCruce += ", e" + arista.Id;
                        }
                    }
                }
                if (!string.IsNullOrEmpty(aristasCruce))
                {
                    aristasCruce = aristasCruce.Substring(1);
                }
                else
                {
                    aristasCruce = "No existen Aristas de Cruce";
                }
                return aristasCruce;
            }
        }

        public string AristasAvance
        {
            get
            {
                string aristasAvance;
                aristasAvance = "";
                foreach (Nodo nodo in this)
                {
                    foreach (Arista arista in nodo.Aristas)
                    {
                        if (arista.Tipo.Equals("Avance"))
                        {
                            aristasAvance += ", e" + arista.Id;
                        }
                    }
                }
                if(!string.IsNullOrEmpty(aristasAvance))
                {
                    aristasAvance = aristasAvance.Substring(1);
                }
                else
                {
                    aristasAvance = "No existen Aristas de Avance";
                }
                return aristasAvance;
            }
        }

        public string AristasRetroceso
        {
            get
            {
                string aristasRetroceso;
                aristasRetroceso = "";
                foreach (Nodo nodo in this)
                {
                    foreach (Arista arista in nodo.Aristas)
                    {
                        if (arista.Tipo.Equals("Retroceso"))
                        {
                            aristasRetroceso += ", e" + arista.Id;
                        }
                    }
                }
                if (!string.IsNullOrEmpty(aristasRetroceso))
                {
                    aristasRetroceso = aristasRetroceso.Substring(1);
                }
                else
                {
                    aristasRetroceso = "No existen Aristas de Retroceso";
                }
                return aristasRetroceso;
            }
        }
        #endregion

        #region Metodos

        #region Escenciales

        public int encuentraIndice(Nodo nodo)
        {
            int j;
            j = 0;
            for (int i = 0; i < this.Count; i++)
            {
                if (nodo.Equals(this[i]))
                {
                    j = i;
                    break;
                }
            }
            return j;
        }


        public int encuentraIndice(string nodo)
        {
            int j;
            j = 0;
            for (int i = 0; i < this.Count; i++)
            {
                if (nodo.Equals(this[i].Nombre))
                {
                    j = i;
                    break;
                }
            }
            return j;
        }

        public void InsertaArista(Point p1, Point p2, int peso, int AnchoLinea, Color colorLinea,int id)
        {
            Nodo np1, np2;
            Point pi1, pi2;
            np1 = BuscaNodo(p1);
            if (np1 != null)
            {
                np2 = BuscaNodo(p2);
                if (np2 != null)
                {
                    pi1 = MetodosAuxiliares.PuntoInterseccion(p1, p2, this[0].TamNodo / 2);
                    pi2 = MetodosAuxiliares.PuntoInterseccion(p2, p1, this[0].TamNodo / 2);
                    arista = new Arista(peso, pi1, pi2, AnchoLinea, colorLinea, np2,id);
                    np1.Aristas.Add(arista);
                }
            }
            this.actualizaId();
        }

        /**
         *  Metodo el cual dibuja un grafo en el area cliente haciendo un llamado a los
         *                      metodos dibuja nodo y dibuja arista de las clases 
         *                      Nodo & Arista respectivamente recorriendo la lista de listas
         *                      contenida en el grafo
         *  @param EditorGrafos Esta es la form principal del programa la cual se utilza
         *                      para poder utilizar el area cliente como impresion
         */
        public void DibujaGrafo(Graphics g)
        {
            foreach (Nodo nodo in this)
            {
                foreach (Arista arista in nodo.Aristas)
                {
                    arista.dibujaArista(g, typeof(GrafoDirigido).IsInstanceOfType(this),this.ponderado,arista.Arriba.existeReciproca(nodo));
                }
                nodo.dibujaNodo(g);
            }
        }

        public void dibujaArbolCostoMinimo(Graphics g, List<Arista> ramas)
        {
            foreach (Nodo nodo in this)
            {
                nodo.dibujaNodo(g,Color.Green);
            }
            foreach (Arista arista in ramas)
            {
                arista.dibujaArista(g, false, true, Color.Red);
            }
        }

        public void DibujaGrafoBosque(Graphics g)
        {
            foreach (Nodo nodo in this)
            {
                foreach (Arista arista in nodo.Aristas)
                {
                    arista.dibujaAristaBosque(g, typeof(GrafoDirigido).IsInstanceOfType(this),this.ponderado,nodo.Erdos);
                }
                nodo.dibujaNodo(g);
            }
        }

        public void DibujaGrafo(Graphics g, List<Nodo> conjunto)
        {
            foreach (Nodo nodo in this)
            {
                foreach (Arista arista in nodo.Aristas)
                {
                    arista.dibujaArista(g, typeof(GrafoDirigido).IsInstanceOfType(this), this.ponderado,arista.Arriba.existeReciproca(nodo));
                }
                if (conjunto.Contains(nodo))
                {
                    nodo.dibujaNodo(g, Color.Green);
                }
                else
                {
                    nodo.dibujaNodo(g);
                }
            }
        }

        /**
         *  Metodo el cual cambia los nombres del grafo segun el tipo del grafo
         *                  ya sea numerico o alphabetico
         */
        public void CambiaNombre()
        {
            int num;
            char aux;
            if (this.tipo)//Convertir de letra a Numero
            {
                foreach (Nodo busca in this)
                {
                    try
                    {
                        num = Int32.Parse(busca.Nombre);
                    }
                    catch (FormatException)
                    {
                        aux = busca.Nombre[0];
                        num = aux - 64;
                    }
                    busca.Nombre = num.ToString();
                }
            }
            else//Convertir de Numero a letra
            {

                if (Int32.Parse(this.Last().Nombre) < 27)
                {
                    foreach (Nodo busca in this)
                    {
                        num = Int32.Parse(busca.Nombre);
                        aux = (char)(num + 64);
                        busca.Nombre = aux.ToString();
                    }
                }
                else
                {
                    MessageBox.Show("Tienes mas de 26 Nodos no puedes usar letras");
                    this.tipo = true;
                }
            }
        }

        /**
         * Este metodo se utiliza para borrar el nodo  mediante 2 ciclos anidados
         *      el cual busca las relaciones que se tienen con ese nodo para despues
         *      eliminarlas.
         * @param Nodo Este es el nodo que se planea borrar
         *              del grafo.
         */
        public void borraNodo(Nodo eliminado)
        {
            List<Arista> l = new List<Arista>();
            foreach (Nodo nodo in this)
            {
                l = buscaRelaciones(nodo, eliminado);
                foreach (Arista nodo2 in l)
                {
                    nodo.Aristas.Remove(nodo2);
                }
            }
            this.Remove(eliminado);
        }

        /**
         * Metodo que recibe 2 Nodo como parametro para buscar
         *              los Arista que tengar relación entre ellos
         *              para despues regresarlos en una lista.
         * @param Nodo Nodo emisor de la relación
         * @param Nodo nodo receptor de la relación
         * @return Retorna una lista con los Arista que tienen relación
         *         entre los nodos enviados como parametro
         */
        public List<Arista> buscaRelaciones(Nodo busca, Nodo n)
        {
            List<Arista> l = new List<Arista>();
            foreach (Arista buscando in busca.Aristas)
            {
                if (buscando.Arriba.Equals(n))
                {
                    l.Add(buscando);
                }
            }
            return l;
        }

        /**
         * Este metodo se encarga de mover un nodo mediante ciclos anidados
         *          para poder corregir el punto central y la direccion de las
         *          aristas para que estas le sigan.
         *          @param Nodo p Nodo que se desea mover
         */
        public void MueveNodo(Nodo p)
        {
            Point pc;
            pc = new Point(0, 0);
            pc.X = p.Pc.X - (this[0].TamNodo / 2);
            pc.Y = p.Pc.Y - (this[0].TamNodo / 2);
            p.Pe = pc;
            List<Arista> l = new List<Arista>();
            foreach (Nodo busca in this)
            {
                if (!p.Equals(busca))
                {
                    foreach (Arista buscando in busca.Aristas)
                    {
                        buscando.P1 = MetodosAuxiliares.PuntoInterseccion(busca.Pc, buscando.Arriba.Pc, this[0].TamNodo / 2);
                        buscando.P2 = MetodosAuxiliares.PuntoInterseccion(buscando.Arriba.Pc, busca.Pc, this[0].TamNodo / 2);
                    }
                }

            }
            foreach (Arista buscando in p.Aristas)
            {
                buscando.P1 = MetodosAuxiliares.PuntoInterseccion(p.Pc, buscando.Arriba.Pc, this[0].TamNodo / 2);
                buscando.P2 = MetodosAuxiliares.PuntoInterseccion(buscando.Arriba.Pc, p.Pc, this[0].TamNodo / 2);
            }

        }

        /**
         * Este metodo se encarga de mover todo el grafo mediante ciclos anidados
         * @param int difX Distancia que se desplazo en X el grafo.
         * @param int difY Distancia que se desplazo en X el grafo.
         * @param Nodo nodo Nodo desde el cual se esta moviendo el grafo.
         */
        public void MueveGrafo(int difX, int difY, Nodo p)
        {
            Point pt1, pe;//Este show es porque no deja modificar los atributos directamente
            pt1 = new Point(0, 0);
            pe = new Point(0, 0);

            foreach (Nodo np in this)
            {
                if (!p.Equals(np))//Mientras sea el mismo nodo y cambia las coordenadas de los nodos
                {
                    pt1.X = np.Pc.X - difX;
                    pt1.Y = np.Pc.Y - difY;
                    np.Pc = pt1;
                    pe.X = pt1.X - this[0].TamNodo / 2;
                    pe.Y = pt1.Y - this[0].TamNodo / 2;
                    np.Pe = pe;
                }
            }
        }

        /**
         * Este metodo borra todo el contenido de la lista del grafo dejandolo como nuevo.
         */
        public void borraGrafo()
        {
            this.nodo = null;
            this.arista = null;
            this.Clear();
        }

        public virtual List<Nodo> DibujaGrafo(Graphics g, List<Nodo> pendientes, List<Nodo> aislados)
        {
            return null;
        }

        public virtual void DibujaGrafo(Graphics g, List<Partita> partitas)
        {
            throw new NotImplementedException();
        }

        public virtual int BorraArista(Point p)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Busqueda

        #region Nodo

        /**
         * Sobrecarga del metodo busca nodo el cual regresa una bandera
         *      boleana y un nodo por referenciapara poder ser modificado
         *  @param ref Nodo Nodo mandado por referencia para poder ser modificado
         *  @param Point Punto el cual se verificara si selecciono el area de alguno
         *               de  
         *  @return bool retorna verdadero si encuentra el nodo y falso en
         *               caso de no encontrarlo.
         */
        public bool BuscaNodo(ref Nodo np, Point p1)
        {
            int difX;
            int difY;
            bool band = false;
            foreach (Nodo n in this)
            {
                difX = Math.Abs(p1.X - n.Pc.X);
                difY = Math.Abs(p1.Y - n.Pc.Y);
                if (difX < n.TamNodo / 2 && difY < n.TamNodo / 2)
                {
                    np = n;
                    band = true;
                }
            }
            return band;
        }

        public bool BuscaNodo(Nodo nodo, ref Nodo nodo2)
        {
            int difX;
            int difY;
            bool band = false;
            foreach (Nodo n in this)
            {
                difX = Math.Abs(nodo.Pc.X - n.Pc.X);
                difY = Math.Abs(nodo.Pc.Y - n.Pc.Y);
                if ((difX < n.TamNodo / 2 && difY < n.TamNodo / 2) && !nodo.Nombre.Equals(n.Nombre))
                {
                    nodo2 = n;
                    band = true;
                }
            }
            return band;
        }

        /**
         * Este metodo es un algoritmo de busqueda que permite idetificar si
         * si el punto donde se dio el click esta en el area de alguno de los
         * guardados en este grafo.
         * 
         * @param ref Point Este punto es el punto en el que se dio el click,
         *                  esta referenciado debido a que si se en cuentra
         *                  detro del área de un nodo se modificara para estar
         *                  en el centro de este.
         * @return bool retorna un booleano que indica si en efecto el punto
         *              en el que se le dio click esta dentro del área de la
         *              lista de nodos correspondiente.
         */
        public bool BuscaNodo(ref Point p1)
        {
            int difX;
            int difY;
            bool band = false;
            foreach (Nodo n in this)
            {
                difX = Math.Abs(p1.X - n.Pc.X);
                difY = Math.Abs(p1.Y - n.Pc.Y);
                if (difX < n.TamNodo / 2 && difY < n.TamNodo / 2)
                {
                    p1 = n.Pc;
                    band = true;
                }
            }
            return band;
        }

        /**
         * Sobrecarga del metodo busca nodo, este algoritmo se encarga
         *  @param Point Punto con el cual se cicla para saber si esta 
         *              dentro del area de alguno de los nodos del grafo.
         *  @return Nodo regresa el nodo encontrado;
         */
        public Nodo BuscaNodo(Point p1)
        {

            int difX;
            int difY;
            foreach (Nodo busca in this)
            {
                difX = Math.Abs(p1.X - busca.Pc.X);
                difY = Math.Abs(p1.Y - busca.Pc.Y);
                if (difX < busca.TamNodo / 2 && difY < busca.TamNodo / 2)
                {
                    nodo = busca;
                }
            }
            return nodo;
        }

        /**
         */
        public Nodo BuscaNodo(string nombre)
        {
            Nodo nodo;
            nodo = null;
            foreach (Nodo busca in this)
            {
                if (busca.Nombre.Equals(nombre))
                {
                    nodo = busca;
                    break;
                }
            }
            return nodo;
        }

        #endregion

        #region Arista
        /**
         * Metodo que se realiza para buscar el un nodo que contenga almenos
         *           una arista, mediante un ciclo for-each va recorriendo la
         *           lista de nodos contenida en este grafo, al detectar que el
         *           Count de la lista de nodosR sea mayor a 0 obtiene el primer
         *           elemento de esa lista modifica la bandera en true
         * @param ref Arista Este nodo al encontrar que el count de la lista de 
         *                  Arista se iguala al primer elemento de dicha lista para
         *                  poder ser referenciado y ser utilizado mas adelante
         * @return bool Bandera que indica si se encontro almenos una arista dentro
         *              del grafo
         */
        public bool buscaArista(ref Arista arista)
        {
            bool band = false;
            foreach (Nodo busca in this)
            {
                if (busca.Aristas.Count > 0)
                {
                    arista = busca.Aristas[0];
                    band = true;
                }
            }
            return band;
        }

        public Arista buscaArista()
        {
            Arista arista;
            arista = null;
            foreach (Nodo busca in this)
            {
                if (busca.Aristas.Count > 0)
                {
                    arista = busca.Aristas[0];
                    break;
                }
            }
            return arista;
        }

        public Arista buscaArista(string origen, string destino)
        {
            this.nodo = this.BuscaNodo(origen);
            foreach (Arista arista in nodo.Aristas)
            {
                if(arista.Arriba.Nombre.Equals(destino))
                {
                    this.arista = arista;
                    break;
                }
            }
            return this.arista;
        }

        public Arista buscaReciproca(Nodo origen, Nodo destino)
        {
            Arista reciproca;
            reciproca = null;
            foreach (Arista arista in destino.Aristas)
            {
                if (arista.Arriba.Equals(origen))
                {
                    reciproca = arista;
                    break;
                }
            }
            return reciproca;
        }

        #endregion

        #endregion

        #region Operaciones

        #region Complemento
        public void complemento(Color color, int ancho)
        {
            Arista aux;
            List<Nodo> complementos = new List<Nodo>();
            Point pi1, pi2;
            Nodo n;
            bool band = false;
            int id;
            id = 0;
            foreach (Nodo busca in this)
            {
                if (busca.Aristas.Count > 0)
                {
                    foreach (Nodo buscando in this)
                    {
                        band = false;
                        foreach (Arista encuentra in busca.Aristas)
                        {
                            if (buscando.Equals(encuentra.Arriba))
                            {
                                band = true;
                                break;
                            }
                        }
                        if (!band)
                        {
                            n = buscando;
                            complementos.Add(n);
                        }
                    }
                    busca.Aristas.Clear();
                    foreach (Nodo buscando in complementos)
                    {
                        if (!busca.Equals(buscando))
                        {
                            pi1 = MetodosAuxiliares.PuntoInterseccion(busca.Pc, buscando.Pc, this[0].TamNodo / 2);
                            pi2 = MetodosAuxiliares.PuntoInterseccion(buscando.Pc, busca.Pc, this[0].TamNodo / 2);
                            id++;
                            aux = new Arista(0, pi1, pi2, ancho, color, buscando,id);
                            busca.Aristas.Add(aux);
                        }
                    }
                    complementos.Clear();
                }
                else
                {
                    foreach (Nodo buscando in this)
                    {
                        if (!busca.Equals(buscando))
                        {
                            pi1 = MetodosAuxiliares.PuntoInterseccion(busca.Pc, buscando.Pc, this[0].TamNodo / 2);
                            pi2 = MetodosAuxiliares.PuntoInterseccion(buscando.Pc, busca.Pc, this[0].TamNodo / 2);
                            id++;
                            aux = new Arista(0, pi1, pi2, ancho, color, buscando,id);
                            busca.Aristas.Add(aux);
                        }
                    }
                }
            }
        }
        #endregion

        #region Matriz de Adyacencia

        public int[,] matrizDeAdyacencia()
        {
            int[,] matrizAdyacencia;
            Grafo grafoM;
            grafoM = this.grafoMatriz();
            matrizAdyacencia = new int[this.Count, this.Count];
            for (int i = 0; i < this.Count; i++)
            {
                for (int j = 0; j < this.Count; j++)
                {
                    matrizAdyacencia[i, j] = grafoM[i].Aristas[j].Peso;
                }
            }
            return matrizAdyacencia;
        }

        public Grafo grafoMatriz()
        {
            Grafo grafo = new Grafo(this, true);
            Arista arista;
            int id;
            id = 0;
            arista = this.buscaArista();
            foreach (Nodo nodo in grafo)
            {
                foreach (Nodo nodo2 in grafo)
                {
                    id++;
                    arista = new Arista(0, MetodosAuxiliares.PuntoInterseccion(nodo.Pc, nodo2.Pc, nodo.TamNodo / 2),
                                        MetodosAuxiliares.PuntoInterseccion(nodo2.Pc, nodo.Pc, nodo.TamNodo / 2),
                                        arista.AnchoLinea, arista.ColorLinea, nodo2, id);
                    nodo.Aristas.Add(arista);
                }
            }
            string origen, destino;
            foreach (Nodo nodo in grafo)
            {
                origen = nodo.Nombre;
                foreach (Arista arista2 in nodo.Aristas)
                {
                    destino = arista2.Arriba.Nombre;
                    arista2.Peso = relacion(origen, destino);
                }
            }

            return grafo;
        }

        private int relacion(string origen, string destino)
        {
            foreach (Nodo busca in this)
            {
                if (busca.Nombre.Equals(origen))
                {
                    foreach (Arista buscando in busca.Aristas)
                    {
                        if (buscando.Arriba.Nombre.Equals(destino))
                        {
                            return 1;
                        }
                    }
                    break;
                }
            }
            return 0;
        }

        #endregion

        #region Pendientes & Aislados
        
        public virtual List<Nodo> nodosPendientes()
        {
            throw new NotImplementedException();
        }

        public virtual List<Nodo> nodosAislados()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Matriz de Incidencia

        public virtual int[,] matrizDeIncidencia()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Grafos Especiales

        public virtual void CreaKn(Size s, int n, ref int num, int tam, int tamL, SolidBrush brushRelleno, SolidBrush brushName, Pen penNodo, Pen penArista, string fuente)
        {
            throw new NotImplementedException();
        }

        public virtual void CreaCn(Size s, int n, ref int num, int tam, int tamL, SolidBrush brushRelleno, SolidBrush brushName, Pen penNodo, Pen penArista, string fuente)
        {
            throw new NotImplementedException();
        }

        public virtual void CreaWn(Size s, int n, ref int num, int tam, int tamL, SolidBrush brushRelleno, SolidBrush brushName, Pen penNodo, Pen penArista, string fuente)
        {
            throw new NotImplementedException();
        }

        public virtual void actualizaId()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Isomorfismo

        public virtual bool isomorfismo(ref Grafo grafito, ref List<Paso> pasos)
        {
            throw new NotImplementedException();
        }

        public virtual Grafo matrizAGrafo(int[,] matriz)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Euler

        public virtual bool aislado()
        {
            throw new NotImplementedException();
        }

        public virtual bool componentesSeparados()
        {
            throw new NotImplementedException();
        }

        public virtual bool pendientes()
        {
            throw new NotImplementedException();
        }

        public virtual List<string> circuitoEuleriano()
        {
            throw new NotImplementedException();
        }

        public virtual bool gradosPares()
        {
            throw new NotImplementedException();
        }

        public virtual int nodosImpares()
        {
            throw new NotImplementedException();
        }

        public virtual bool paresParejos()
        {
            throw new NotImplementedException();
        }

        public virtual List<string> caminoEuleriano()
        {
            throw new NotImplementedException();
        }

        public virtual void setGrados()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region nPartitas

        public virtual List<Partita> nPartita()
        {
            throw new NotImplementedException();
        }
        
        #endregion

        #region Corolarios

        public virtual bool corolario1()
        {
            throw new NotImplementedException();
        }

        public virtual bool corolario2()
        {
            throw new NotImplementedException();
        }
        
        #endregion

        #region Kuratoski

        public virtual void borraNodoKuratowski(Nodo nodo)
        {
            throw new NotImplementedException();
        }

        public virtual bool AddKuratoswki(Nodo nodo, Point p)
        {
            throw new NotImplementedException();
        }

        public virtual bool homeomorficoK5()
        {
            throw new NotImplementedException();
        }

        public virtual bool homeomorficoK33()
        {
            throw new NotImplementedException();
        }
        
        #endregion

        #region Dijkstra

        public virtual List<string> dijkstra(string origen, string destino)
        {
            throw new NotImplementedException();
        }

        public virtual int[,] matrizDeCostos()
        {
            throw new NotImplementedException();
        }

        public virtual string[] vectorDijkstra(string origen)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Floyd

        public virtual List<string> floyd(string origen, string destino)
        {
            throw new NotImplementedException();
        }

        public string[,] matrizCaminos()
        {
            string[,] caminos;
            caminos = new string[this.Count,this.Count];
            for (int i = 0; i < this.Count; i++)
            {
                for (int j = 0; j < this.Count; j++)
                {
                    caminos[i, j] = this[j].Nombre;
                }
            }
            return caminos;
        }

        public virtual int[,] FloydWarshall(ref string[,] caminos)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Bosque de Busqueda Profunda

        public virtual void bosqueBusquedaProfunda(Nodo nodo, int erdoz, Stack<string> rama, ref List<List<string>> ramas)
        {
            throw new NotImplementedException();
        }

        public void eliminaBosque()
        {
            foreach (Nodo nodo in this)
            {
                nodo.Erdos = -1;
                foreach (Arista arista in nodo.Aristas)
                {
                    arista.Tipo = "null";
                }
                nodo.Aristas = nodo.Aristas.OrderBy(arista => arista.Arriba.Nombre).ToList();
                nodo.visitado = false;
            }
        }

        #endregion

        #region Prueba De Aciclicidad

        public virtual bool pruebaDeAciclicidad(ref List<List<string>> ciclo)
        {
            throw new NotImplementedException();
        }

        public virtual void buscaCiclos(Nodo nodo, int erdoz, Stack<string> rama, ref List<List<string>> ramas, ref List<List<string>> ciclos)
        {
            throw new NotImplementedException();
        }

        public virtual List<string> refinaCiclos(Stack<string> rama, string origen, string destino)
        {
            throw new NotImplementedException();
        }

        public virtual List<List<string>> eliminaRepetidos(List<List<string>> ciclos)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Bosque de Busqueda en Amplitud
        public virtual void bosqueBusquedaAmplitud(List<Nodo> nivel, ref List<string> arbol, ref List<string> cruce)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Kruskal

        public virtual List<Arista> Kruskal(ref List<List<string>> componentes, List<Arista> aristas)
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion

        #endregion
    }
}
