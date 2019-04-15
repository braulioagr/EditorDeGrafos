using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorDeGrafos
{
    [Serializable]
    class Nodo
    {
        #region NonSerialized
        [NonSerialized] public bool visitado;
        #endregion

        #region Variables de Instancia
        private string nombre;
        private List<Arista> aristas;
        private Point pc;
        private Point pe;
        private Color colorFuera;
        private Color colorRelleno;
        private Color colorNombre;
        private int tamNodo;
        private int tamLetra;
        private int anchoContorno;
        private int gradoEntrada;
        private int gradoSalida;
        private string fuente;
        #endregion

        #region Constructor
        /**
         * Constructor de la clase Nodo
         *            @param string nombre Nombre secueciado del nodo que
         *                                 se esta construyendo.
         *            @param Point  pE Punto de la ezquina superior del nodo
         *            @param Point  pC Punto del centro del nodo.
         *            @param Color  colorFuera Color con el que se pintara el
         *                                     contorno del nodo.
         *            @param Color  colorRelleno Color con el que se pintara el
         *                                       relleno del nodo.
         *            @param Color  colorName Color con el que se pintara la letra
         *                                     o numero del nodo
         *            @param int    tamañoNodo Tamaño (diametro) del nodo.
         *            @param int    tamañoLetra Tamaño con el que se dibujara la letra.
         *            @param int    anchoContorno Tamaño con el que se dibujara el ancho
         *                                        del contorno del nodo.
         */
        public Nodo(string nombre, Point pE, Point pC, Color colorFuera, Color colorRelleno,
                    Color colorName, int tamañoNodo, int tamañoLetra, int anchoContorno, string fuente)
        {
            this.nombre = nombre;
            this.pc = pC;
            this.pe = pE;
            this.colorFuera = colorFuera;
            this.colorRelleno = colorRelleno;
            this.colorNombre = colorName;
            this.tamNodo = tamañoNodo;
            this.tamLetra = tamañoLetra;
            this.anchoContorno = anchoContorno;
            this.fuente = fuente;
            this.aristas = new List<Arista>();
        }
        #endregion

        #region Gets & Sets
        
        public string Nombre
        {
            set { nombre = value; }
            get { return nombre; }
        }

        public List<Arista> Aristas
        {
            set { aristas = value; }
            get { return aristas; }
        }
        
        public Point Pc
        {
            set { pc = value; }
            get { return pc; }
        }
        
        public Point Pe
        {
            set { pe = value; }
            get { return pe; }
        }
        
        public Color ColorFuera
        {
            set { colorFuera = value; }
            get { return colorFuera; }
        }
        
        public Color BrushRelleno
        {
            set { colorRelleno = value; }
            get { return colorRelleno; }
        }
        
        public Color BrushName
        {
            set { colorNombre = value; }
            get { return colorNombre; }
        }
        
        public int TamNodo
        {
            set { tamNodo = value; }
            get { return tamNodo; }
        }
        
        public int TamLetra
        {
            set { tamLetra = value; }
            get { return tamLetra; }
        }
        
        public int AnchoContorno
        {
            set { anchoContorno = value; }
            get { return anchoContorno; }
        }

        public int GradoSalida
        {
            set { this.gradoSalida = value; }
            get { return this.gradoSalida; }
        }

        public int GradoEntrada
        {
            set { this.gradoEntrada = value; }
            get { return this.gradoEntrada; }
        }

        public string Fuente
        {
            get { return this.fuente; }
            set { this.fuente = value; }
        }

        public List<Nodo> nodosAdyacentes
        {
            get
            {
                List<Nodo> adyacentes = new List<Nodo>();
                foreach (Arista arista in this.Aristas)
                {
                    if (!arista.Arriba.Equals(this))
                    {
                        adyacentes.Add(arista.Arriba);
                    }
                }
                return adyacentes;
            }
        }

        public bool FataReccorer
        {
            get
            {
                bool falta;
                falta = false;
                foreach (Arista arista in this.aristas)
                {
                    if (!arista.recorrida)
                    {
                        falta = true;
                    }
                }
                return falta;
            }
        }

        #endregion

        #region Metodos

        /**
         * Este metodo es el que se encarga de diujar el nodp
         *            cuando sea necesario.
         *            @param Graphics g Graficos con los que sera
         *                              dibujado el nodo
         */
        public void dibujaNodo(Graphics g)
        {
            Pen pen = new Pen(colorFuera, (float)anchoContorno);
            SolidBrush brochaRelleno = new SolidBrush(colorRelleno);
            SolidBrush brochaLetra = new SolidBrush(colorNombre);
            Font font = new Font(fuente, tamLetra);
            g.FillEllipse(brochaRelleno, pe.X, pe.Y, tamNodo, tamNodo);
            g.DrawEllipse(pen, pe.X, pe.Y, tamNodo, tamNodo);
            g.DrawString(nombre.ToString(), font, brochaLetra, pe.X + (tamNodo / 2) - tamLetra / 2, pe.Y + (tamNodo / 2) - tamLetra / 2);
        }

        /**
         */
        public void dibujaNodo(Graphics g, Color color)
        {
            Pen pen = new Pen(color, this.anchoContorno + 2);
            SolidBrush brochaRelleno = new SolidBrush(colorRelleno);
            SolidBrush brochaLetra = new SolidBrush(colorNombre);
            Font font = new Font("Times New Roman", tamLetra);
            g.FillEllipse(brochaRelleno, pe.X, pe.Y, tamNodo, tamNodo);
            g.DrawEllipse(pen, pe.X, pe.Y, tamNodo, tamNodo);
            g.DrawString(nombre.ToString(), font, brochaLetra, pe.X + (tamNodo / 2) - tamLetra / 2, pe.Y + (tamNodo / 2) - tamLetra / 2);
        }

        public Arista aristaSoporte()
        {
            Arista puntero;
            puntero = null;
            foreach (Arista arista in this.aristas)
            {
                if (!arista.Arriba.Equals(this))
                {
                    puntero = arista;
                }
            }
            return puntero;
        }

        public string[] Pesos()
        {
            string[] pesos;
            pesos = new string[this.aristas.Count + 1];
            int i;
            i = 1;
            pesos[0] = this.nombre;
            foreach (Arista busca in this.aristas)
            {
                pesos[i] = busca.Peso.ToString();
                if (busca.Peso == int.MaxValue)
                {
                    pesos[i] = "∞";
                }
                i++;
            }
            return pesos;
        }

        public int grados()
        {
            int gr;
            gr = 0;
            foreach (Arista arista in aristas)
            {
                gr += arista.Arriba.gradoSalida;
            }
            return gr;
        }

        public Arista buscaRelacion(string nombre)
        {
            Arista arista;
            arista = null;
            foreach (Arista busca in this.Aristas)
            {
                if (busca.Arriba.Nombre.Equals(nombre))
                {
                    arista = busca;
                    break;
                }
            }
            return arista;
        }

        #endregion
        

    }
}
