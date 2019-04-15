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
        //[NonSerialized] public NumericUpDown numericPeso;
        [NonSerialized] public bool recorrida;
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
        #endregion

        #region Metodos
        /**
         * Este metodo es el que se encarga de dibujar la arista cuando sea necesaria, y se modificara
         *            el atributo CustomEndCap.
         *            @param Graphics g Dispositivo de contexo con el que sera dibujada la arista.
         *            @param bool dirigido Bandera qye indica si el grafo al que pertenece la arista
         *                                 es dirigido o no.
         */
        public void dibujaArista(Graphics g, bool dirigido,bool ponderado)
        {
            Pen pen = new Pen(ColorLinea, anchoLinea);
            if (dirigido)
            {
                pen.CustomEndCap = new AdjustableArrowCap(5, 5);
            }
            if(p1.Equals(p2))
            {

                g.DrawBezier(pen, arriba.Pc.X - 15, arriba.Pc.Y - 15, arriba.Pc.X - 20, arriba.Pc.Y - 60, arriba.Pc.X + 20, arriba.Pc.Y - 60, arriba.Pc.X + 15, arriba.Pc.Y - 15);
            }
            else
            {
                g.DrawLine(pen, p1.X, p1.Y, p2.X, p2.Y);
            }
            if (ponderado)
            {
                g.DrawString("e" + id.ToString() + ": " + this.peso.ToString(), new Font("Times New Roman", 10), new SolidBrush(pen.Color), (p1.X + p2.X) / 2, (p1.Y + p2.Y) / 2);
            }
            else
            {
                g.DrawString("e" + id.ToString(), new Font("Times New Roman", 10), new SolidBrush(pen.Color), (p1.X + p2.X) / 2, (p1.Y + p2.Y) / 2);
            }

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
        #endregion

    }
}
