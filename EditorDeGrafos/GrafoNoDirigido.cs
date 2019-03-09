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

        public override void actualizaId()
        {
            int id;
            id = 0;
            foreach (Nodo nodo in this)
            {
                foreach (Arista arista in nodo.Aristas)
                {
                    arista.Id = 0;
                }
            }
            foreach (Nodo nodo in this)
            {
                foreach (Arista arista in nodo.Aristas)
                {
                    if (arista.Id == 0)
                    {
                        id++;
                        arista.Id = id;
                        foreach (Arista arista2 in arista.Arriba.Aristas)
                        {
                            if (arista2.Arriba.Equals(nodo))
                            {
                                arista2.Id = id;
                                break;
                            }
                        }
                    }
                }
            }
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
        public override int[,] matrizDeIncidencia()
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

        #region GrafosEspeciales
        public override void CreaKn(Size s, int n, ref int num, int tam, int tamL, SolidBrush brushRelleno,
                                    SolidBrush brushName, Pen penNodo, Pen penArista, string fuente)
        {
            Arista a;
            Nodo nodo;
            Point p1 = new Point(s.Width / 2, s.Height / 2 + 37);
            Point Pc = p1;
            Point Pe = new Point();
            int ancho = s.Height / 2 - 50;
            double grados = 360 / (double)n;
            grados = grados * Math.PI / 180;
            double contG = 0;
            double x, y;
            for (int i = 0; i < n; i++)
            {
                x = Math.Round(ancho * Math.Sin(contG));
                y = Math.Round(ancho * Math.Cos(contG));
                Pc.X += (int)x;
                Pc.Y -= (int)y;
                contG += grados;
                Pe.X = Pc.X - (tam / 2);
                Pe.Y = Pc.Y - (tam / 2);
                nodo = new Nodo(num.ToString(), Pe, Pc, penNodo.Color, brushRelleno.Color, brushName.Color, tam, tamL, (int)penNodo.Width, fuente);
                this.Add(nodo);
                Pc = p1;
                num++;
            }
            foreach (Nodo busca in this)
            {
                foreach (Nodo buscando in this)
                {
                    if (!busca.Equals(buscando))
                    {
                        a = new Arista(0, MetodosAuxiliares.PuntoInterseccion(busca.Pc, buscando.Pc, tam / 2),
                                       MetodosAuxiliares.PuntoInterseccion(buscando.Pc, busca.Pc, tam / 2), (int)penArista.Width, penArista.Color,buscando,0);
                        busca.Aristas.Add(a);
                    }
                }
            }
        }
        public override void CreaCn(Size s, int n, ref int num, int tam, int tamL, SolidBrush brushRelleno,
                                    SolidBrush brushName, Pen penNodo, Pen penArista, string fuente)
        {
            Nodo nodo;
            Nodo ant = null;
            Arista a;
            Point p1 = new Point(s.Width / 2, s.Height / 2 + 37);
            Point Pc = p1;
            Point Pe = new Point();
            int ancho = s.Height / 2 - 50;
            double grados = 360 / (double)n;
            grados = grados * Math.PI / 180;
            double contG = 0;
            double x, y;
            for (int i = 0; i < n; i++)
            {
                x = Math.Round(ancho * Math.Sin(contG));
                y = Math.Round(ancho * Math.Cos(contG));
                Pc.X += (int)x;
                Pc.Y -= (int)y;
                contG += grados;
                Pe.X = Pc.X - (tam / 2);
                Pe.Y = Pc.Y - (tam / 2);
                nodo = new Nodo(num.ToString(), Pe, Pc, penNodo.Color, brushRelleno.Color, brushName.Color, tam, tamL, (int)penNodo.Width, fuente);
                if (i > 0)
                {
                    a = new Arista(0, MetodosAuxiliares.PuntoInterseccion(nodo.Pc, ant.Pc, tam / 2),
                                   MetodosAuxiliares.PuntoInterseccion(ant.Pc, nodo.Pc, tam / 2),
                                   (int)penArista.Width, penArista.Color, ant, 0);
                    nodo.Aristas.Add(a);
                    a = new Arista(0, MetodosAuxiliares.PuntoInterseccion(ant.Pc, nodo.Pc, tam / 2),
                                   MetodosAuxiliares.PuntoInterseccion(nodo.Pc, ant.Pc, tam / 2),
                                   (int)penArista.Width, penArista.Color, nodo, 0);
                    ant.Aristas.Add(a);
                }
                this.Add(nodo);
                ant = nodo;
                Pc = p1;
                num++;
            }
            a = new Arista(0, MetodosAuxiliares.PuntoInterseccion(this[0].Pc, ant.Pc, tam / 2),
                           MetodosAuxiliares.PuntoInterseccion(ant.Pc, this[0].Pc, tam / 2),
                           (int)penArista.Width, penArista.Color, ant, 0);
            this[0].Aristas.Add(a);
            a = new Arista(0, MetodosAuxiliares.PuntoInterseccion(ant.Pc, this[0].Pc, tam / 2),
                           MetodosAuxiliares.PuntoInterseccion(this[0].Pc, ant.Pc, tam / 2),
                           (int)penArista.Width, penArista.Color, this[0], 0);
            ant.Aristas.Add(a);

        }
        public override void CreaWn(Size s, int n, ref int num, int tam, int tamL, SolidBrush brushRelleno,
                                    SolidBrush brushName, Pen penNodo, Pen penArista, string fuente)
        {
            Arista a;
            Nodo fin;
            Point Pc = new Point(s.Width / 2, s.Height / 2 + 37);
            Point Pe = new Point((Pc.X - (tam / 2)), (Pc.Y - (tam / 2)));
            this.CreaCn(s, n, ref num, tam, tamL, brushRelleno, brushName, penNodo, penArista, fuente);
            fin = new Nodo(num.ToString(), Pe, Pc, penNodo.Color, brushRelleno.Color,
                     brushName.Color, tam, tamL, (int)penNodo.Width, fuente);
            foreach (Nodo busca in this)
            {
                a = new Arista(0, MetodosAuxiliares.PuntoInterseccion(busca.Pc, fin.Pc, tam / 2),
                              MetodosAuxiliares.PuntoInterseccion(fin.Pc, busca.Pc, tam / 2), (int)penArista.Width, penArista.Color, fin, 0);
                busca.Aristas.Add(a);
                a = new Arista(0, MetodosAuxiliares.PuntoInterseccion(fin.Pc, busca.Pc, tam / 2),
                               MetodosAuxiliares.PuntoInterseccion(busca.Pc, fin.Pc, tam / 2), (int)penArista.Width, penArista.Color, busca, 0);
                fin.Aristas.Add(a);
            }
            this.Add(fin);
        }
        #endregion

        #region Isomorfismo
        public override bool isomorfismo(ref Grafo grafito, ref List<Paso> pasos)
        {
            int limCambio;
            int cambios;
            int i1;
            int i2;
            bool isomorfismo;
            string cambio;
            int[,] matriz;
            int[,] matrix;
            Paso paso;
            i1 = 0;
            i2 = 0;
            matriz = base.matrizDeAdyacencia();
            matrix = grafito.matrizDeAdyacencia();
            limCambio = Convert.ToInt32(Math.Pow((double)grafito.Count, (double)2));
            cambios = 0;
            isomorfismo = MetodosAuxiliares.comparaMatrices(matriz, matrix);
            while (isomorfismo || cambios == limCambio)
            {
                MetodosAuxiliares.biyectividad(matriz, matrix, ref i1, ref i2);
                matrix = MetodosAuxiliares.CambioIsomorfico(matrix, i1, i2);
                isomorfismo = MetodosAuxiliares.comparaMatrices(matriz, matrix);
                cambio = grafito[i1].Nombre + "->" + grafito[i2].Nombre;
                paso = new Paso(matrix, cambio);
                pasos.Add(paso);
                cambios++;
            }
            grafito = grafito.matrizAGrafo(matrix);
            return isomorfismo;
        }

        #endregion

        #endregion

    }
}
