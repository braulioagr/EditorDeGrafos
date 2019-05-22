using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditorDeGrafos
{
    [Serializable]
    class Arista
    {

        #region No Serializables
        [NonSerialized] public NumericUpDown numericPeso;
        [NonSerialized] public bool recorrida;
        [NonSerialized] private string tipo;
        #endregion

        #region Variables de instancia
        private int peso;
        private int id;
        private Point p1;
        private Point p2;
        private int anchoLinea;
        private Color colorLinea;
        private Nodo arriba;
        #endregion

        #region Constructor

        /**
         *  Este es el constructor de la clase NodoR
         *         @param int p Peso de la arista
         *         @param Point p1 Punto de origen de la
         *                         arista
         *         @param Point p2 Punto de destino de la
         *                         arista
         *         @param int anchoLinea Ancho de la linea
         *         @param Color colorLinea Color con la que
         *                      se dibuja la linea
         */
        public Arista(int p, Point p1, Point p2, int anchoLinea, Color colorLinea, Nodo arriba, int id)
        {
            this.Peso = p;
            this.p1 = p1;
            this.p2 = p2;
            this.anchoLinea = anchoLinea;
            this.colorLinea = colorLinea;
            this.arriba = arriba;
            this.id = id;
        }
        
        #endregion

        #region Gets & Sets

        public Point P1
        {
            set { p1 = value; }
            get { return p1; }
        }

        public Point P2
        {
            set { p2 = value; }
            get { return p2; }
        }
        
        public int AnchoLinea
        {
            set { anchoLinea = value; }
            get { return anchoLinea; }
        }
        
        public Color ColorLinea
        {
            set { colorLinea = value; }
            get { return colorLinea; }
        }
        
        public Nodo Arriba
        {
            set { this.arriba = value; }
            get { return this.arriba; }
        }
        
        public int Peso
        {
            set { peso = value; }
            get { return peso; }
        }

        public int Id
        {
            set { id = value; }
            get { return id; }
        }

        public string Tipo
        {
            get { return this.tipo; }
            set { this.tipo = value; }
        }

        #endregion

        #region Metodos
        /**
         * Este metodo es el que se encarga de dibujar la arista cuando sea necesaria, y se modificara
         *            el atributo CustomEndCap.
         *            @param Graphics g Dispositivo de contexo con el que sera dibujada la arista.
         *            @param bool dirigido Bandera qye indica si el grafo al que pertenece la arista
         *                                 es dirigido o no.
         */
        public void dibujaArista(Graphics g, bool dirigido,bool ponderado,bool existe)
        {
            Pen pen = new Pen(ColorLinea, anchoLinea);
            string etiqueta;
            etiqueta = "e" + id.ToString();
            if (dirigido)
            {
                pen.CustomEndCap = new AdjustableArrowCap(5, 5);
            }
            if (ponderado)
            {
                etiqueta += ": " + this.peso.ToString();
            }
            if(p1.Equals(p2))
            {
                g.DrawBezier(pen, arriba.Pc.X - 15, arriba.Pc.Y - 15, arriba.Pc.X - 20, arriba.Pc.Y - 60, arriba.Pc.X + 20, arriba.Pc.Y - 60, arriba.Pc.X + 15, arriba.Pc.Y - 15);
            }
            else
            {
                /*if (dirigido && existe)
                {
                    Spline spline;
                    spline = new Spline(this.p1, this.p2);
                    spline.PintaCurva(g,etiqueta);
                }
                else
                {
                }*/
                g.DrawLine(pen, p1.X, p1.Y, p2.X, p2.Y);
                g.DrawString(etiqueta, new Font("Times New Roman", 10), new SolidBrush(pen.Color), (p1.X + p2.X) / 2, (p1.Y + p2.Y) / 2);
            }

        }
        public void dibujaArista(Graphics gAux, bool dirigido, bool ponderado, Color color)
        {
            Pen pen = new Pen(color, anchoLinea + 2);
            string etiqueta;
            etiqueta = "e" + id.ToString();
            if (dirigido)
            {
                pen.CustomEndCap = new AdjustableArrowCap(5, 5);
            }
            if (p1.Equals(p2))
            {

                gAux.DrawBezier(pen, arriba.Pc.X - 15, arriba.Pc.Y - 15, arriba.Pc.X - 20, arriba.Pc.Y - 60, arriba.Pc.X + 20, arriba.Pc.Y - 60, arriba.Pc.X + 15, arriba.Pc.Y - 15);
            }
            else
            {
                gAux.DrawLine(pen, p1.X, p1.Y, p2.X, p2.Y);
            }
            if (ponderado)
            {
                etiqueta += ": " + this.peso.ToString();
            }
            gAux.DrawString(etiqueta, new Font("Times New Roman", 10), new SolidBrush(color), (p1.X + p2.X) / 2, (p1.Y + p2.Y) / 2);
        }

        public void dibujaArista(Graphics g, Color color, bool dirigido)
        {
            Pen pen = new Pen(color, anchoLinea + 2);
            if (dirigido)
            {
                pen.CustomEndCap = new AdjustableArrowCap(5, 5);
            }
            g.DrawLine(pen, p1.X, p1.Y, p2.X, p2.Y);
        }

        public void dibujaAristaBosque(Graphics g, bool dirigido, bool ponderado, int erdos)
        {
            Spline spline;
            string etiqueta;
            spline = new Spline(this.p1, this.p2);
            Pen pen = new Pen(this.colorLinea, anchoLinea + 2);
            etiqueta = "e" + id.ToString();
            if (dirigido)
            {
                pen.CustomEndCap = new AdjustableArrowCap(5, 5);
            }
            if (ponderado)
            {
                etiqueta += ": " + this.peso.ToString();
            }
            if(this.tipo.Equals("Arbol"))//Arbol, Avance, Cruce, Retroceso
            {
                pen.Color = Color.Red;
                g.DrawLine(pen, p1.X, p1.Y, p2.X, p2.Y);//Linea
                g.DrawString(etiqueta, new Font("Times New Roman", 10), new SolidBrush(Color.Purple), (p1.X + p2.X) / 2, (p1.Y + p2.Y) / 2);
            }
            else if (this.tipo.Equals("Cruce"))
            {
                pen.Color = Color.Green;
                if (erdos == this.arriba.Erdos)
                {
                    g.DrawLine(pen, p1.X, p1.Y, p2.X, p2.Y);//Linea
                    g.DrawString(etiqueta, new Font("Times New Roman", 10), new SolidBrush(Color.Purple), (p1.X + p2.X) / 2, (p1.Y + p2.Y) / 2);
                }
                else
                {
                    spline.PintaCurva(g, Color.Green, anchoLinea + 2, etiqueta);//Spline
                }
            }
            else if (this.tipo.Equals("Avance"))
            {
                spline.PintaCurva(g, Color.Blue,anchoLinea+2,etiqueta);//Spline
            }
            else if (this.tipo.Equals("Retroceso"))
            {
                spline.PintaCurva(g, Color.Yellow,anchoLinea+2,etiqueta);//Spline
            }
        }

        #endregion


    }
}
