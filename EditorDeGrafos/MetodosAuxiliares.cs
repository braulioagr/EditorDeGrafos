using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorDeGrafos
{
    class MetodosAuxiliares
    {

        #region Coordenadas Polares
        
        /**
         * El metodo calcula pendiente esta basado en el teorema
         *      de pitagoras para poder calcular un valor en base
         *      a 2 puntos.
         *      @param Point p1 es el primer punto con el cual se
         *                   hara dicho caculo.
         *      @param Point p2 es el segundo punto con el cual se
         *                   hara dicho calculo.
         *      @return double retorna una variable doble la cual
         *                   el cual es la pendiente calculada
         */
        public static double CalculaPendiente(Point p1, Point p2)
        {
            double a, b, m;
            a = (double)(p2.Y - p1.Y);
            b = (double)(p2.X - p1.X);
            m = a / b;
            return m;
        }
        
        /**
         * Este metodo sirve para calcular el angulo entre los 2 puntos
         *      basandose en la funcion trigonometrica ArcoTangente.
         *      @param double m es la pendiente que existe entre los 2
         *                    angulos.
         *      @return double regresa el angulo que existe entre los puntos.
         */
        public static double CalculaAngulo(double m)
        {
            double angulo;
            angulo = Math.Atan(m);
            return angulo;
        }
        
        /**
         * Este metodo sirve para calcular el cateto adyacente mediante la
         *            identidad trigonometrica del coseno con el metodo para
         *            calcular las coordenadas polares del circulo.
         *            @param double  angulo Es el angulo entre 2 puntos.
         *            @param int radio Es el radio del circulo donde se desea
         *                             calcular la coordenada polar.
         *            @return regresa el cateto adyacente calculado con dichos
         *                    datos.
         */
        public static double CalculaCA(double angulo, int radio)
        {
            double ca;
            ca = Math.Cos(angulo) * radio;
            return Math.Round(ca);
        }

        /**
         * Este metodo sirve para calcular el cateto opuesto mediante la
         *            identidad trigonometrica del coseno con el metodo para
         *            calcular las coordenadas polares del circulo.
         *            @param double  angulo Es el angulo entre 2 puntos.
         *            @param int radio Es el radio del circulo donde se desea
         *                             calcular la coordenada polar.
         *            @return regresa el cateto opuesto calculado con dichos
         *                    datos.
         */
        public static double CalculaCO(double angulo, int radio)
        {
            double co;
            co = Math.Sin(angulo) * radio;
            return Math.Round(co);
        }

        /**
         * Metodo estatico que calcula el punto intermedio entre el radio y el 
         *            borde del nodo en dirección a otro centro de otro nodo.
         *            @param Point p1 Coordenadas del punto central del nodo de
         *                            origen del cual se desea calcular el punto.
         *            @param Point p2 Corrdenadas del punto central del nodo hacia
         *                            el cual apunta el nodo resultante.
         *            @param int Radio de ambos circulos (deben tener el mismo
         *                       radio)
         *            @return Regresa el punto con las coordenadas polares
         *                    necesarias.
         */
        public static Point PuntoInterseccion(Point p1, Point p2, int radio)
        {
            Point pI;
            pI = new Point();
            double m, angulo;
            m = CalculaPendiente(p1, p2);
            angulo = CalculaAngulo(m);
            if (p1.X == p2.X)
            {
                pI.X = p1.X;
                if (p2.Y > p1.Y)
                {
                    pI.Y = p1.Y + radio;
                }
                if (p1.Y > p2.Y)
                {
                    pI.Y = p1.Y - radio;
                }
            }
            if (p2.X > p1.X)
            {
                pI.X = p1.X + (int)CalculaCA(angulo, radio);
                pI.Y = p1.Y + (int)CalculaCO(angulo, radio);
            }
            if (p1.X > p2.X)
            {
                pI.X = p1.X - (int)CalculaCA(angulo, radio);
                pI.Y = p1.Y - (int)CalculaCO(angulo, radio);
            }
            return pI;
        }
        
        #endregion

        #region Nodos Pendientes

        public static string[] NombresNodo(List<Nodo> nodos)
        {
            string[] nod;
            int i;
            nod = new string[nodos.Count + 1];
            i = 0;
            foreach (Nodo nodo in nodos)
            {
                i++;
                nod[i] = nodo.Nombre;
            }
            return nod;
        }

        public static string[] relacionDeAristasCut(List<Nodo> nodos)
        {
            string[] aristas;
            int i;
            aristas = new string[nodos.Count + 1];
            i = 0;
            aristas[i] = "Aristas Cut";
            foreach (Nodo nodo in nodos)
            {
                i++;
                aristas[i] = nodo.Aristas[0].Arriba.Nombre + " - " + nodo.Nombre;
            }
            aristas[nodos.Count] = nodos.Last().Nombre + " - " + nodos.Last().Aristas[0].Arriba.Nombre;
            return aristas;
        }

        public static bool nodoEnLista(List<Nodo> nombres, Nodo busqueda)
        {
            bool band;
            band = false;
            foreach (Nodo nodo in nombres)
            {
                if (nodo.Equals(busqueda))
                {
                    band = true;
                    break;
                }
            }
            return band;
        }
        #endregion

        #region Isomorfismo
        public static bool comparaMatrices(int[,] matriz1, int[,] matriz2)
        {
            bool bandera;
            bandera = true;
            for (int i = 0 ; i < matriz1.GetLength(0) ; i++)
            {
                for (int j = 0; j < matriz1.GetLength(0); j++)
                {
                    if (matriz1[i,j] != matriz2[i, j])
                    {
                        bandera = false;
                        break;
                    }
                }
            }
            return bandera;
        }

        public static int[,] CambioIsomorfico(int[,] matrix, int i1, int i2)
        {
            int aux;
            aux = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                aux = matrix[i1, i];
                matrix[i1, i] = matrix[i2, i];
                matrix[i2, i] = aux;
            }
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                aux = matrix[j, i1];
                matrix[j, i1] = matrix[j, i2];
                matrix[j, i2] = aux;
            }
            return matrix;
        }
        public static void biyectividad(int[,] matriz, int[,] matrix, ref int i1, ref int i2)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
