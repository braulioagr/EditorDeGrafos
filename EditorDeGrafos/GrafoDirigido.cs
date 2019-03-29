using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorDeGrafos
{
    [Serializable]
    class GrafoDirigido : Grafo
    {

        #region Constructores
        public GrafoDirigido(Grafo g)
        {
            foreach (Nodo n in g)
            {
                this.Add(n);
            }
            this.Ponderado = g.Ponderado;
            this.tipo = g.Tipo;
        }

        public GrafoDirigido(Grafo g, bool p)
        {
            Nodo nodo;
            Arista arista;
            foreach (Nodo n in g)
            {
                nodo = new Nodo(n.Nombre, n.Pe, n.Pc, n.ColorFuera, n.BrushRelleno, n.BrushName, n.TamNodo, n.TamLetra, n.AnchoContorno, n.Fuente);
                foreach (Arista a in n.Aristas)
                {
                    arista = new Arista(a.Peso, a.P1, a.P2, a.AnchoLinea, a.ColorLinea, a.Arriba,a.Id);
                    nodo.Aristas.Add(arista);
                }
                this.Add(nodo);
            }
            this.Ponderado = g.Ponderado;
            this.tipo = g.Tipo;
        }
        #endregion

        #region operaciones Esenciales
        
        public override int BorraArista(Point p)
        {
            double m, b, y;
            double xp, yp, xn, yn, xarista, yarista;
            xp = p.X;
            yp = p.Y;
            int sensibilidad = 2;
            foreach (Nodo n in this)
            {
                foreach (Arista arista in n.Aristas)
                {
                    xn = n.Pc.X;
                    yn = n.Pc.Y;
                    xarista = arista.Arriba.Pc.X;
                    yarista = arista.Arriba.Pc.Y;

                    if (n.Equals(arista.Arriba))
                    {
                        Nodo nAux = BuscaNodo(p);
                        if (nAux != null && nAux.Equals(n))
                        {
                            n.Aristas.Remove(arista);
                            return 1;
                        }
                    }

                    if ((xarista - xn) == 0)
                    {
                        if ((yp < yn && yp > yarista) || (yp > yn && yp < yarista))
                        {
                            if ((xp < xarista + sensibilidad && xp > xn - sensibilidad) || (xp > xarista - sensibilidad && xp < xn + sensibilidad))
                            {
                                n.Aristas.Remove(arista);
                                return 1;
                            }
                        }
                    }

                    m = (yarista - yn) / (xarista - xn);
                    b = yn - (m * xn);
                    y = m * xp + b;

                    if (yp >= y - sensibilidad && yp <= y + sensibilidad)
                    {
                        if ((xp < xarista + sensibilidad && xp > xn - sensibilidad) || (xp > xarista - sensibilidad && xp < xn + sensibilidad))
                        {
                            n.Aristas.Remove(arista);
                            return 1;
                        }
                    }
                }
            }
            return 0;
        }

        public override void actualizaId()
        {
            int id;
            id = 0;
            foreach (Nodo nodo in this)
            {
                foreach (Arista arista in nodo.Aristas)
                {
                    id++;
                    arista.Id = id;
                }
            }
        }

        #endregion

        #region Matriz de Adyacencia

        public override int[,] matrizDeIncidencia()
        {
            int[,] matriz;
            int i;
            List<Arista> aristas;
            aristas = base.LAristas;
            matriz = new int[this.Count, aristas.Count];
            for (i = 0; i < this.Count; i++)
            {
                for (int j = 0; j < aristas.Count; j++)
                {
                    matriz[i, j] = 0;
                }
            }
            i = 0;
            foreach (Nodo nodo in this)
            {
                foreach (Arista arista in nodo.Aristas)
                {
                    matriz[i, arista.Id - 1] = 1;
                    matriz[this.encuentraIndice(arista.Arriba), arista.Id - 1] = -1;
                }
                i++;
            }
            return matriz;
        }

        private int encuentraIndice(Nodo nodo)
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
        #endregion

        #region Eulerianos
        
        #region Validaciones

        public override bool aislado()
        {
            bool aislado;
            aislado = false;
            foreach (Nodo nodo in this)
            {
                if (nodo.Aristas.Count == 0)//Si un nodo no tiene aristas regresa el true
                {
                    aislado = true;
                    break;
                }
            }
            return aislado;
        }

        public override bool paresParejos()
        {
            bool parejos;
            parejos = true;
            foreach (Nodo nodo in this)
            {
                if ((nodo.GradoEntrada + nodo.GradoSalida) % 2 == 0)
                {
                    if (nodo.GradoEntrada != nodo.GradoSalida)//Si un noodo de grado conjunto par (suma de entrada y salida) no tiene el mismo valor marca el falso
                    {
                        parejos = false;
                        break;
                    }
                }
            }
            return parejos;
        }

        public override int nodosImpares()
        {
            int impares;
            impares = 0;
            foreach (Nodo nodo in this)
            {
                if ((nodo.GradoEntrada + nodo.GradoSalida) % 2 != 0)//Si la suma del grado de entrada y salida no es par pone incrementa en 1 el contador
                {
                    impares++;
                }
            }
            return impares;
        }

        public override bool gradosPares()
        {
            bool cumple;
            cumple = true;
            foreach (Nodo nodo in this)
            {
                if ((nodo.GradoEntrada + nodo.GradoSalida) % 2 != 0)//Si la suma del grado de entrada y salida no es par pone la bandera en falso
                {
                    cumple = false;
                    break;
                }
            }
            return cumple;
        }

        #endregion

        /**
         * Este es el metodo encargado de asignar valores a los grados de entrada y de salida
         */
        public override void setGrados()
        {
            int gradoEntrada;
            gradoEntrada = 0;
            foreach (Nodo nodo in this)
            {
                gradoEntrada = 0;
                foreach (Nodo nodo2 in this)
                {
                    foreach (Arista arista in nodo2.Aristas)//Recorre las aristas del nodo2
                    {
                        if (nodo.Equals(arista.Arriba))//Si encuentra una arista que apunte a nodo incrementa el valor del grado de entrada
                        {
                            gradoEntrada++;
                        }
                    }
                }
                nodo.GradoEntrada = gradoEntrada;//asigna el grado de entrada
                nodo.Aristas = nodo.Aristas.OrderBy(nr => nr.Arriba.Nombre).ToList();//Ordena las aristas por nombre
                nodo.GradoSalida = nodo.Aristas.Count;//asigna el grado de salida
            }
        }

        public override List<string> circuitoEuleriano()
        {
            Nodo actual;//Nodo actual en la secuencia
            Nodo siguiente;//Nodo siguiente en la secuencia
            Arista arista;//Arista recorrida
            List<string> recorrido;//Lista que contendra la secuencia del circuito
            List<Arista> recorridas;//Lista de aristas recorridas
            recorrido = new List<string>();
            recorridas = new List<Arista>();
            this.setGrados();//inicializa el valor de los grados
            actual = this[0];//Inicia el recorrido en el primer nodo que se inserto en el grafo
            do
            {
                recorrido.Add(actual.Nombre);
                siguiente = MetodosAuxiliares.siguienteEnCircuito(actual, recorridas);//busca el siguiente  nodo en la secuencia
                arista = MetodosAuxiliares.encuentraArista(actual, siguiente);//Encuentra la arista que apunta al nodo
                recorridas.Add(arista);//Añade a la arista a la lista para no volver a ser recorrida
                actual.GradoSalida--;//Reduce en uno el grado de salida
                actual = siguiente;//El apuntador del nodo actual pasa a tener el valor del siguiente en la secuencia
            } while (actual.GradoSalida != 0);//El ciclo se mantiene hasta que el nodo
            recorrido.Add(actual.Nombre);//Añade el ultimo nombre al nodo de la secuencia
            return recorrido;
        }

        public override List<string> caminoEuleriano()
        {
            List<string> recorrido;
            List<string> recorridoAux;
            List<Arista> recorridas;
            Nodo actual;
            Nodo siguiente;
            Arista arista;
            recorrido = new List<string>();
            recorridoAux = new List<string>();
            this.setGrados();
            recorridas = new List<Arista>();
            actual = MetodosAuxiliares.inicioDeCaminoDir(this);
            do
            {
                recorridoAux.Add(actual.Nombre);
                do
                {
                    siguiente = MetodosAuxiliares.siguienteEnCaminoDir(actual, recorridas);
                    arista = MetodosAuxiliares.encuentraArista(actual, siguiente);
                    recorridas.Add(arista);
                    actual.GradoSalida--;
                    actual = siguiente;
                    recorridoAux.Add(actual.Nombre);
                } while (actual.GradoSalida != 0);
                recorrido = MetodosAuxiliares.sumaListas(recorridoAux, recorrido);
                recorridoAux = new List<string>();
                if (recorridas.Count != this.Aristas)
                {
                    actual = base.BuscaNodo(recorrido.First().ToString());
                    recorrido = MetodosAuxiliares.subList(recorrido, 1);
                }
            } while (recorridas.Count != this.Aristas);
            return recorrido;
        }

        #endregion

    }
}
