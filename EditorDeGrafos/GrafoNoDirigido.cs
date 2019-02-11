using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorDeGrafos
{
    [Serializable]
    class GrafoNoDirigido : Grafo
    {

        #region Constructores
        
        public GrafoNoDirigido(Grafo g)
        {
            foreach (Nodo n in g)
            {
                this.Add(n);
            }
            this.Ponderado = g.Ponderado;
            this.tipo = g.Tipo;
        }

        public GrafoNoDirigido(Grafo g, bool p)
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

        #region Operaciones Esenciales
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
                                foreach (Arista busca in arista.Arriba.Aristas)
                                {
                                    if (busca.Arriba.Equals(n))
                                    {
                                        arista.Arriba.Aristas.Remove(busca);
                                        break;
                                    }
                                }
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
                            foreach (Arista busca in arista.Arriba.Aristas)
                            {
                                if (busca.Arriba.Equals(n))
                                {
                                    arista.Arriba.Aristas.Remove(busca);
                                    break;
                                }
                            }
                            n.Aristas.Remove(arista);
                            return 1;
                        }
                    }
                }
            }
            return 0;
        }

        public override List<Nodo> DibujaGrafo(Graphics g, List<Nodo> pendientes, List<Nodo> aislados)
        {
            List<Nodo> cuts;
            cuts = new List<Nodo>();
            foreach (Nodo nodo in this)
            {
                foreach (Arista arista in nodo.Aristas)
                {
                    arista.dibujaArista(g, typeof(GrafoDirigido).IsInstanceOfType(this),ponderado);
                }
                if (MetodosAuxiliares.nodoEnLista(pendientes, nodo))
                {
                    nodo.dibujaNodo(g, Color.Blue);
                    cuts.Add(nodo.Aristas[0].Arriba);
                }
                else if (MetodosAuxiliares.nodoEnLista(aislados, nodo))
                {
                    nodo.dibujaNodo(g, Color.Yellow);
                }
                else
                {
                    nodo.dibujaNodo(g);
                }
            }
            foreach (Nodo nodo in pendientes)
            {
                nodo.aristaSoporte().dibujaArista(g, Color.Green, false);
            }
            foreach (Nodo nodo in cuts)
            {
                nodo.dibujaNodo(g, Color.Red);
            }
            return cuts;
        }

        #endregion

        #region Metodos de Grafo

        #region Pendientes
        /**
         * Este metodo es el encargado de buscar los nodos pendientes 
         *      en el grafo no dirigido el cual se basa en el concepto
         *      de que si un nodo solo tiene una arista y esa arista
         *      no apunta asi mismo es un nodo pendiente.
         *      
         * @return Retorna una lista de nodos los cuales corresponden
         *         a pendientes encontrados
         */
        public override List<Nodo> nodosPendientes()
        {
            List<Nodo> pendientes;
            pendientes = new List<Nodo>();
            foreach (Nodo nodo in this)
            {
                if (nodo.Aristas.Count == 1)
                {
                    if(!nodo.Aristas[0].Arriba.Equals(nodo))
                    {
                        pendientes.Add(nodo);
                    }
                }
                else if (nodo.Aristas.Count == 2)
                {
                    if (nodo.Aristas[0].Arriba.Equals(nodo) || nodo.Aristas[1].Arriba.Equals(nodo))
                    {
                        pendientes.Add(nodo);
                    }
                }
            }
            return pendientes;
        }

        /**
         * Este metodo es el encargado de buscar los nodos aislados 
         *      en el grafo no dirigido el cual se basa en el concepto
         *      de que si un nodo solo tiene no tiene aristas o si la
         *      tiene y esta aputa a si mismo es un nodo aislado
         *      
         * @return Retorna una lista de nodos los cuales corresponden
         *         a aislados encontrados
         */
        public override List<Nodo> nodosAislados()
        {

            List<Nodo> aislados;
            aislados = new List<Nodo>();
            foreach (Nodo nodo in this)
            {
                if (nodo.Aristas.Count == 0)
                {
                    aislados.Add(nodo);
                }
                else if(nodo.Aristas.Count == 1)
                {
                    if (nodo.Aristas[0].Arriba.Equals(nodo))
                    {
                        aislados.Add(nodo);
                    }
                }
            }
            return aislados;
        }
        #endregion

        #region Matriz de Adyacencia
        public override int[,] matrizDeAdyacencia()
        {
            int[,] matriz;
            int i;
            matriz = new int[this.Count,base.Aristas/2];
            for(i = 0 ; i < this.Count ; i++ )
            {
                for (int j = 0; j < base.Aristas / 2; j++)
                {
                    matriz[i, j] = 0;
                }
            }
            i = 0;
            foreach (Nodo nodo in this)
            {
                foreach (Arista arista in nodo.Aristas)
                {
                    matriz[i, arista.Id-1] = 1;
                }
                i++;
            }
            return matriz;
        }
        #endregion

        #endregion

    }
}
