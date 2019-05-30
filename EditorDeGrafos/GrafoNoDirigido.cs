﻿using System;
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
            foreach (Nodo n in g)
            {
                nodo = new Nodo(n.Nombre, n.Pe, n.Pc, n.ColorFuera, n.BrushRelleno, n.BrushName, n.TamNodo, n.TamLetra, n.AnchoContorno, n.Fuente);
                this.Add(nodo);
            }
            this.Ponderado = g.Ponderado;
            this.tipo = g.Tipo;
        }

        #endregion

        #region Esenciales

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
                            this.actualizaId();
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
                                this.actualizaId();
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
                            this.actualizaId();
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
                    arista.dibujaArista(g, typeof(GrafoDirigido).IsInstanceOfType(this),ponderado,false);
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

        public override void DibujaGrafo(Graphics g, List<Partita> partitas)
        {
            Color[] colores;
            colores = MetodosAuxiliares.GeneraColores();
            int i;
            i = 0;
            foreach (Partita partita in partitas)
            {
                foreach (string nombre in partita)
                {
                    foreach (Nodo nodo in this)
                    {
                        if (nombre.Equals(nodo.Nombre))
                        {
                            foreach (Arista arista in nodo.Aristas)
                            {
                                arista.dibujaArista(g, false, this.ponderado,false);
                            }
                            nodo.dibujaNodo(g, colores[i]);
                        }
                    }
                }
                i++;
                if (i == colores.Length)
                {
                    i = 0;
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

        #region Especiales
        public override void CreaKn(Size s, int n, ref int num, int tam, int tamL, SolidBrush brushRelleno,
                                    SolidBrush brushName, Pen penNodo, Pen penArista, string fuente)
        {
            int ancho;
            double grados, x, y,contG;
            Nodo nodo;
            Arista arista;
            Point p1, pc, pe;
            ancho = ((s.Height - 50)/ 2) - 50;
            grados = ((360 / (double)n) * Math.PI)/ 180;
            contG = 0;
            p1 = new Point(s.Width / 2, (s.Height / 2) + 12);
            pc = p1;
            pe = new Point();
            for (int i = 0; i < n; i++)
            {
                x = Math.Round(ancho * Math.Sin(contG));
                y = Math.Round(ancho * Math.Cos(contG));
                pc.X += (int)x;
                pc.Y -= (int)y;
                contG += grados;
                pe.X = pc.X - (tam / 2);
                pe.Y = pc.Y - (tam / 2);
                nodo = new Nodo(num.ToString(), pe, pc, penNodo.Color, brushRelleno.Color, brushName.Color, tam, tamL, (int)penNodo.Width, fuente);
                this.Add(nodo);
                pc = p1;
                num++;
            }
            foreach (Nodo busca in this)
            {
                foreach (Nodo buscando in this)
                {
                    if (!busca.Equals(buscando))
                    {
                        arista = new Arista(0, MetodosAuxiliares.PuntoInterseccion(busca.Pc, buscando.Pc, tam / 2),
                                               MetodosAuxiliares.PuntoInterseccion(buscando.Pc, busca.Pc, tam / 2),
                                               (int)penArista.Width, penArista.Color,buscando,0);
                        busca.Aristas.Add(arista);
                    }
                }
            }
        }
        public override void CreaCn(Size s, int n, ref int num, int tam, int tamL, SolidBrush brushRelleno,
                                    SolidBrush brushName, Pen penNodo, Pen penArista, string fuente)
        {
            int ancho;
            double grados, x, y, contG;
            Nodo nodo;
            Nodo anterior;
            Arista arista;
            Point p1, pc, pe;
            ancho = ((s.Height - 50) / 2) - 50;
            grados = ((360 / (double)n) * Math.PI) / 180;
            contG = 0;
            p1 = new Point(s.Width / 2, (s.Height / 2) + 12);
            pc = p1;
            pe = new Point();
            anterior = null;
            for (int i = 0; i < n; i++)
            {
                x = Math.Round(ancho * Math.Sin(contG));
                y = Math.Round(ancho * Math.Cos(contG));
                pc.X += (int)x;
                pc.Y -= (int)y;
                contG += grados;
                pe.X = pc.X - (tam / 2);
                pe.Y = pc.Y - (tam / 2);
                nodo = new Nodo(num.ToString(), pe, pc, penNodo.Color, brushRelleno.Color, brushName.Color, tam, tamL, (int)penNodo.Width, fuente);
                if (i > 0)
                {
                    arista = new Arista(0, MetodosAuxiliares.PuntoInterseccion(nodo.Pc, anterior.Pc, tam / 2),
                                           MetodosAuxiliares.PuntoInterseccion(anterior.Pc, nodo.Pc, tam / 2),
                                           (int)penArista.Width, penArista.Color, anterior, 0);
                    nodo.Aristas.Add(arista);
                    arista = new Arista(0, MetodosAuxiliares.PuntoInterseccion(anterior.Pc, nodo.Pc, tam / 2),
                                           MetodosAuxiliares.PuntoInterseccion(nodo.Pc, anterior.Pc, tam / 2),
                                           (int)penArista.Width, penArista.Color, nodo, 0);
                    anterior.Aristas.Add(arista);
                }
                this.Add(nodo);
                anterior = nodo;
                pc = p1;
                num++;
            }
            arista = new Arista(0, MetodosAuxiliares.PuntoInterseccion(this[0].Pc, anterior.Pc, tam / 2),
                                   MetodosAuxiliares.PuntoInterseccion(anterior.Pc, this[0].Pc, tam / 2),
                                   (int)penArista.Width, penArista.Color, anterior, 0);
            this[0].Aristas.Add(arista);
            arista = new Arista(0, MetodosAuxiliares.PuntoInterseccion(anterior.Pc, this[0].Pc, tam / 2),
                                   MetodosAuxiliares.PuntoInterseccion(this[0].Pc, anterior.Pc, tam / 2),
                                   (int)penArista.Width, penArista.Color, this[0], 0);
            anterior.Aristas.Add(arista);

        }
        public override void CreaWn(Size s, int n, ref int num, int tam, int tamL, SolidBrush brushRelleno,
                                    SolidBrush brushName, Pen penNodo, Pen penArista, string fuente)
        {
            Arista a;
            Nodo fin;
            Point pc;
            Point pe;
            pc = new Point(s.Width / 2, s.Height / 2 + 12);
            pe = new Point((pc.X - (tam / 2)), (pc.Y - (tam / 2)));
            this.CreaCn(s, n, ref num, tam, tamL, brushRelleno, brushName, penNodo, penArista, fuente);
            fin = new Nodo(num.ToString(), pe, pc, penNodo.Color, brushRelleno.Color,
                     brushName.Color, tam, tamL, (int)penNodo.Width, fuente);
            foreach (Nodo busca in this)
            {
                a = new Arista(0, MetodosAuxiliares.PuntoInterseccion(busca.Pc, fin.Pc, tam / 2),
                                  MetodosAuxiliares.PuntoInterseccion(fin.Pc, busca.Pc, tam / 2),
                                  (int)penArista.Width, penArista.Color, fin, 0);
                busca.Aristas.Add(a);
                a = new Arista(0, MetodosAuxiliares.PuntoInterseccion(fin.Pc, busca.Pc, tam / 2),
                                  MetodosAuxiliares.PuntoInterseccion(busca.Pc, fin.Pc, tam / 2),
                                  (int)penArista.Width, penArista.Color, busca, 0);
                fin.Aristas.Add(a);
            }
            this.Add(fin);
        }
        #endregion

        #region Isomorfismo

        public override bool isomorfismo(int[,] g1, int[,] g2, ref List<int[,]> pasos, ref int[] cambios)
        {
            int[] p;
            List<int> p2 = new List<int>();
            long fact = MetodosAuxiliares.factorial(this.Count);
            int[] indexp = new int[this.Count]; 

            for (int i = 0 ; i < this.Count ; i++)//se llena indexp con el numero de nodos
            {
                indexp[i] = i;
            }
            
            if (MetodosAuxiliares.comparaMatrices(g1,g2))
            {
                sep(ref p2, indexp);
                cambios = indexp;
                return true;
            }
            p = indexp;
            //creamos una permutacion y la probamos
            for (int i = 0 ; i < fact ; i++)
            {
                biyeccion(indexp);
                if (PruebaPermutacion(g1, g2, indexp, ref p, ref pasos))
                {
                    cambios = indexp;
                    return true;
                }
            }
            cambios = indexp;
            return false;
        }

        private void sep(ref List<int> p2, int[] p)
        {
            for (int i = 0; i < p.Length; i++)
            {
                p2.Add(p[i]);//El Orden de cambios
            }
        }
        public bool PruebaPermutacion(int[,] M1, int[,] M2, int[] permutacion, ref int[] p, ref List<int[,]> pasos)
        {
            p = permutacion;
            bool band;
            band = true;
            int x = permutacion.Length;
            for (int i = 0; i < permutacion.Length; i++)
            {
                for (int j = 0; j < permutacion.Length; j++)
                {
                    if (M1[i, j] != M2[permutacion[i], permutacion[j]])
                    {
                        band = false;
                        break;
                    }
                }
                if (!band)
                {
                    break;
                }
            }
            pasos.Add(MetodosAuxiliares.clonaMatriz(M1));
            return band;
        }

        public static bool biyeccion(int[] numList)
        {
            /*
            * Knuths 
            * 1. Find the largest index j such that a[j] < a[j + 1]. If no such index exists, the permutation is the last permutation. 
            * 2. Find the largest index l such that a[j] < a[l]. Since j + 1 is such an index, l is well defined and satisfies j < l. 
            * 3. Swap a[j] with a[l]. 
            * 4. Reverse the sequence from a[j + 1] up to and including the final element a[n]. 
            */
            var largestIndex = -1;
            for (var i = numList.Length - 2; i >= 0; i--)
            {
                if (numList[i] < numList[i + 1])
                {
                    largestIndex = i;
                    break;
                }
            }
            if (largestIndex < 0)
            {
                return false;
            }
            var largestIndex2 = -1;
            for (var i = numList.Length - 1; i >= 0; i--)
            {
                if (numList[largestIndex] < numList[i])
                {
                    largestIndex2 = i;
                    break;
                }
            }
            var tmp = numList[largestIndex];
            numList[largestIndex] = numList[largestIndex2];
            numList[largestIndex2] = tmp;
            for (int i = largestIndex + 1, j = numList.Length - 1; i < j; i++, j--)
            {
                tmp = numList[i];
                numList[i] = numList[j];
                numList[j] = tmp;
            }
            return true;
        }

        public override Grafo matrizAGrafo(int[,] matriz)
        {
            Grafo grafo;
            List<Arista> eliminadas;
            grafo = this.grafoMatriz();
            eliminadas = new List<Arista>();
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(0); j++)
                {
                    grafo[i].Aristas[j].Peso = matriz[i, j];
                }
            }
            foreach (Nodo nodo in grafo)
            {
                foreach (Arista arista in nodo.Aristas)
                {
                    if (arista.Peso == 0)
                    {
                        eliminadas.Add(arista);
                    }
                }
                foreach (Arista arista2 in eliminadas)
                {
                    nodo.Aristas.Remove(arista2);
                }
                eliminadas.Clear();
            }
            return grafo;
        }
        #endregion

        #region Eulerianos

        #region Validaciones
        public override bool pendientes()
        {
            bool existe;
            existe = false;
            foreach (Nodo busca in this)
            {
                if (nodo.Aristas.Count <= 1)
                {
                    existe = true;
                    break;
                }
            }
            return existe;
        }
        public override bool gradosPares()
        {
            bool cumple;
            cumple = true;
            foreach (Nodo nodo in this)
            {
                if (nodo.Aristas.Count % 2 != 0)
                {
                    cumple = false;
                    break;
                }
            }
            return cumple;
        }
        
        public override int nodosImpares()
        {
            int impares;
            impares = 0;
            foreach (Nodo nodo in this)
            {
                if (nodo.Aristas.Count % 2 != 0)
                {
                    impares++;
                }

            }
            return impares;
        }

        public override bool aislado()
        {
            bool aislado;
            aislado = false;
            foreach (Nodo nodo in this)
            {
                if (nodo.Aristas.Count == 0)
                {
                    aislado = true;
                    break;
                }
            }
            return aislado;
        }

        public override bool componentesSeparados()
        {
            bool separados;
            separados = false;
            Nodo actual;
            Nodo siguiente;
            Arista arista;
            List<Arista> recorridas;
            this.setGrados();
            recorridas = new List<Arista>();
            actual = this[0];
            do
            {
                siguiente = MetodosAuxiliares.siguienteEnCaminoNoDir(actual, recorridas);
                arista = MetodosAuxiliares.encuentraArista(siguiente, actual);
                recorridas.Add(arista);
                siguiente.GradoSalida--;
                arista = MetodosAuxiliares.encuentraArista(actual, siguiente);
                recorridas.Add(arista);
                actual.GradoSalida--;
                actual = siguiente;
            } while (actual.grados() != 0);
            if (this.Aristas != recorridas.Count)
            {
                separados = true;
            }
            return separados;
        }
        #endregion

        public override void setGrados()
        {
            foreach (Nodo nodo in this)
            {
                nodo.Aristas = nodo.Aristas.OrderBy(nr => nr.Arriba.Nombre).ToList();
                nodo.GradoSalida = nodo.Aristas.Count;
            }
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
            actual = MetodosAuxiliares.inicioDeCaminoNoDir(this);
            do
            {
                recorridoAux.Add(actual.Nombre);
                do
                {
                    siguiente = MetodosAuxiliares.siguienteEnCaminoNoDir(actual, recorridas);
                    arista = MetodosAuxiliares.encuentraArista(siguiente, actual);
                    recorridas.Add(arista);
                    siguiente.GradoSalida--;
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

        public override List<string> circuitoEuleriano()
        {
            List<string> recorrido;
            Nodo actual;
            Nodo siguiente;
            Arista arista;
            List<Arista> recorridas;
            recorrido = new List<string>(); ;
            this.setGrados();
            recorridas = new List<Arista>();
            actual = this[0];
            do
            {
                recorrido.Add(actual.Nombre);
                siguiente = MetodosAuxiliares.siguienteEnCircuito(actual, recorridas);
                arista = MetodosAuxiliares.encuentraArista(siguiente, actual);
                recorridas.Add(arista);
                siguiente.GradoSalida--;
                arista = MetodosAuxiliares.encuentraArista(actual, siguiente);
                recorridas.Add(arista);
                actual.GradoSalida--;
                actual = siguiente;

            } while (actual.grados() != 0);
            recorrido.Add(actual.Nombre);
            return recorrido;
        }

        #endregion

        #region nPartita
        
        /**/
        public override List<Partita> nPartita()
        {
            Partita partita;
            List<Partita> partitas;
            partitas = new List<Partita>();
            partita = new Partita();
            foreach (Nodo busca in this)
            {
                foreach (Arista buscando in busca.Aristas)
                {
                    partita = new Partita();
                    foreach (Nodo encuentra in this)
                    {
                        if (!buscando.Arriba.Nombre.Equals(encuentra.Nombre))
                            if (!encuentraLista(partita, encuentra.Nombre))
                            {
                                if (!buscaRelacion(busca, encuentra.Nombre, partita))
                                {
                                    if (!encuentraNombre(partitas, encuentra.Nombre))
                                    {
                                        partita.Add(encuentra.Nombre);
                                    }
                                }
                            }
                    }
                }
                if (partita.Count > 0)
                {
                    if (!encuentraNombre(partitas, busca.Nombre))
                    {
                        partitas.Add(partita);
                    }
                }
            }
            return partitas;
        }
        
        /**/
        public bool encuentraNombre(List<Partita> partitas, string nombre)
        {
            bool encontrado;
            encontrado = false;
            foreach (Partita busca in partitas)
            {
                foreach (string buscando in busca)
                {
                    if (buscando.Equals(nombre))
                    {
                        encontrado = true;
                        break;
                    }
                }
            }
            return encontrado;
        }
        
        /**/
        public bool encuentraLista(Partita lista, string nombre)
        {
            bool encontrado;
            encontrado = false;
            foreach (string busca in lista)
            {
                if (busca.Equals(nombre))
                {
                    encontrado = true;
                    break;
                }
            }
            return encontrado;
        }
        
        /**/
        public bool buscaRelacion(Nodo nodo, string nombre, Partita lista)
        {
            bool encontrada;
            encontrada = false;
            foreach (Nodo busca in this)
            {
                foreach (string buscando in lista)
                {
                    if (buscando.Equals(busca.Nombre))
                    {
                        foreach (Arista encuentra in busca.Aristas)
                        {
                            if (encuentra.Arriba.Nombre.Equals(nombre))
                            {
                                encontrada = true;
                                break;
                            }
                        }
                        break;
                    }
                }
            }
            return encontrada;
        }

        #endregion

        #region Corolarios
        public override bool corolario1()
        {
            //Corolario 1
            //E<=3V-6
            bool band;
            band = false;
            if((this.Aristas/2) <= (3*this.Count) - 6)
            {
                band = true;
            }
            return band;
        }

        public override bool corolario2()
        {
            //Corolario 2
            //E <= 2V – 4
            bool band;
            band = false;
            if ((this.Aristas / 2) <= (2 * this.Count) - 4)
            {
                band = true;
            }
            return band;
        }
        #endregion

        #region Kuratowski
        
        public override bool AddKuratoswki(Nodo nodo, Point p)
        {
            double m, b, y;
            double xp, yp, xn, yn, xarista, yarista;
            xp = p.X;
            yp = p.Y;
            int sensibilidad = 3;
            Arista arista2;
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
                            return false;
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
                                        arista2 = new Arista(0, MetodosAuxiliares.PuntoInterseccion(nodo.Pc, arista.Arriba.Pc, nodo.TamNodo / 2),
                                                             MetodosAuxiliares.PuntoInterseccion(arista.Arriba.Pc, nodo.Pc, nodo.TamNodo / 2),
                                                             arista.AnchoLinea, arista.ColorLinea,arista.Arriba,0);
                                        nodo.Aristas.Add(arista2);
                                        arista2 = new Arista(0, MetodosAuxiliares.PuntoInterseccion(arista.Arriba.Pc, nodo.Pc, nodo.TamNodo / 2),
                                                             MetodosAuxiliares.PuntoInterseccion(nodo.Pc, arista.Arriba.Pc, nodo.TamNodo / 2),
                                                             arista.AnchoLinea, arista.ColorLinea, nodo, 0);
                                        arista.Arriba.Aristas.Add(arista2);
                                        arista.Arriba.Aristas.Remove(busca);
                                        break;
                                    }
                                }
                                arista2 = new Arista(0, MetodosAuxiliares.PuntoInterseccion(nodo.Pc, n.Pc, nodo.TamNodo / 2),
                                                     MetodosAuxiliares.PuntoInterseccion(n.Pc, nodo.Pc, nodo.TamNodo / 2),
                                                     arista.AnchoLinea, arista.ColorLinea, n, 0);
                                nodo.Aristas.Add(arista2);
                                arista2 = new Arista(0, MetodosAuxiliares.PuntoInterseccion(n.Pc, nodo.Pc, nodo.TamNodo / 2),
                                                     MetodosAuxiliares.PuntoInterseccion(nodo.Pc, n.Pc, nodo.TamNodo / 2),
                                                     arista.AnchoLinea, arista.ColorLinea, nodo, 0);
                                arista.Arriba.Aristas.Add(arista2);
                                n.Aristas.Remove(arista);
                                this.Add(nodo);
                                return true;
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
                                    arista2 = new Arista(0, MetodosAuxiliares.PuntoInterseccion(nodo.Pc, arista.Arriba.Pc, nodo.TamNodo / 2),
                                                         MetodosAuxiliares.PuntoInterseccion(arista.Arriba.Pc, nodo.Pc, nodo.TamNodo / 2),
                                                         arista.AnchoLinea, arista.ColorLinea, arista.Arriba, 0);
                                    nodo.Aristas.Add(arista2);
                                    arista2 = new Arista(0, MetodosAuxiliares.PuntoInterseccion(arista.Arriba.Pc, nodo.Pc, nodo.TamNodo / 2),
                                                         MetodosAuxiliares.PuntoInterseccion(nodo.Pc, arista.Arriba.Pc, nodo.TamNodo / 2),
                                                         arista.AnchoLinea, arista.ColorLinea, nodo, 0);
                                    arista.Arriba.Aristas.Add(arista2);
                                    arista.Arriba.Aristas.Remove(busca);
                                    break;
                                }
                            }
                            arista2 = new Arista(0, MetodosAuxiliares.PuntoInterseccion(nodo.Pc, n.Pc, nodo.TamNodo / 2),
                                                 MetodosAuxiliares.PuntoInterseccion(n.Pc, nodo.Pc, nodo.TamNodo / 2),
                                                 arista.AnchoLinea, arista.ColorLinea, n, 0);
                            nodo.Aristas.Add(arista2);
                            arista2 = new Arista(0, MetodosAuxiliares.PuntoInterseccion(n.Pc, nodo.Pc, nodo.TamNodo / 2),
                                                 MetodosAuxiliares.PuntoInterseccion(nodo.Pc, n.Pc, nodo.TamNodo / 2),
                                                 arista.AnchoLinea, arista.ColorLinea, nodo, 0);
                            n.Aristas.Add(arista2);
                            n.Aristas.Remove(arista);
                            this.Add(nodo);
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public override void borraNodoKuratowski(Nodo nodo)
        {
            Arista arista;
            List<Nodo> relaciones;
            relaciones = new List<Nodo>();
            arista = base.buscaArista();
            foreach (Arista aristaI in nodo.Aristas)
            {
                relaciones.Add(aristaI.Arriba);
            }
            this.Remove(nodo);
            foreach (Nodo nodo1 in relaciones)
            {
                foreach (Nodo nodo2 in relaciones)
                {
                    if (!nodo1.Equals(nodo2))
                    {
                        arista = new Arista(0, MetodosAuxiliares.PuntoInterseccion(nodo1.Pc, nodo2.Pc, nodo1.TamNodo / 2),
                                            MetodosAuxiliares.PuntoInterseccion(nodo2.Pc, nodo1.Pc, nodo1.TamNodo / 2),
                                            arista.AnchoLinea, arista.ColorLinea, nodo2,0);
                        nodo1.Aristas.Add(arista);
                        arista = new Arista(0, MetodosAuxiliares.PuntoInterseccion(nodo2.Pc, nodo1.Pc, nodo1.TamNodo / 2),
                                            MetodosAuxiliares.PuntoInterseccion(nodo1.Pc, nodo2.Pc, nodo1.TamNodo / 2),
                                            arista.AnchoLinea, arista.ColorLinea, nodo1, 0);
                        nodo2.Aristas.Add(arista);
                    }
                }
            }
        }

        public override bool homeomorficoK5()
        {
            if (this.Count >= 5)
            {
                List<Nodo> vertices = new List<Nodo>();
                foreach (Nodo nodo in this)
                {
                    vertices = nodo.nodosAdyacentes;
                    List<Nodo> grado4 = new List<Nodo>();
                    foreach (Nodo adyacente in vertices)
                        if (grado4.Count <= 3)
                        {
                            if (adyacente.Aristas.Count >= 4)
                            {
                                grado4.Add(adyacente);
                            }                                
                        }
                        else
                            break;
                    if (grado4.Count >= 4)
                    {
                        grado4.Insert(0, nodo);
                        return true;
                    }
                    vertices.Clear();
                }
                return false;
            }
            return false;
        }

        public override bool homeomorficoK33()
        {
            if (this.Count >= 6)
            {
                List<List<Nodo>> nodos = new List<List<Nodo>>();
                foreach (Nodo nodo in this)
                {
                    List<Nodo> adyacentes = nodo.nodosAdyacentes;
                    for (int i = 0; i < adyacentes.Count; i++)
                    {
                        if (adyacentes[i].Aristas.Count != 3)
                        {
                            adyacentes.Remove(adyacentes[i]);
                        }
                    }
                    if (adyacentes.Count >= 3)
                    {
                        nodos.Add(adyacentes);
                    }
                }
                if (nodos.Count >= 6)
                {
                    return true;
                }
            }
            return false;
        }


        #endregion

        #region Bosque de Busqueda en Amplitud

        public override void bosqueBusquedaAmplitud(List<Nodo> nivel, ref List<string> arbol, ref List<string> cruce)
        {
            List<Nodo> sigNivel;
            sigNivel = new List<Nodo>();
            /*foreach (Nodo nodo in nivel)
            {
                nodo.visitado = true;
            }*/
            foreach (Nodo nodo in nivel)
            {
                foreach (Arista arista in nodo.Aristas)
                {
                    if (arista.Tipo.Equals("null"))//Si la arista no tiene tipo se le asigna uno
                    {
                        if (!arista.Arriba.visitado)//Si no esta visitado es de arbol y por consiguiente su nodo debe ser
                        {
                            arista.Tipo = "Arbol";
                            base.buscaReciproca(nodo, arista.Arriba).Tipo = "Arbol";
                            arbol.Add("e" + arista.Id.ToString());
                            sigNivel.Add(arista.Arriba);
                            arista.Arriba.visitado = true;

                        }
                        else//En caso contrario es de cruce
                        {
                            arista.Tipo = "Cruce";
                            base.buscaReciproca(nodo, arista.Arriba).Tipo = "Cruce";
                            cruce.Add("e" + arista.Id.ToString());
                        }
                    }
                }
            }
            if (sigNivel.Count != 0)
            {
                this.bosqueBusquedaAmplitud(sigNivel, ref arbol, ref cruce);
            }

        }

        #endregion

        #region Kruskal

        public override List<Arista> Kruskal(ref List<List<string>> componentes, List<Arista> aristas)
        {
            List<Arista> ramas;
            Arista arista2;
            int i,j;
            i = 0;
            j = 0;
            arista2 = null;
            ramas = new List<Arista>();
            foreach(Arista arista in aristas)
            {
                arista2 = arista.Arriba.buscaReciproca(arista.Id);//Busca la arista reciproca de esta
                if(!MetodosAuxiliares.mismoComponente(componentes,arista2.Arriba.Nombre,arista.Arriba.Nombre))
                {//Se verifica que no esten en el mismo componente (Misma list de string)
                    //ramas.Add(arista);//Se añadan ambas aristas
                    ramas.Add(arista2);//Se añadan ambas aristas
                    i = MetodosAuxiliares.indiceDeComponente(componentes, arista2.Arriba.Nombre);//Encuentran los indices de los componentes a mezclar
                    j = MetodosAuxiliares.indiceDeComponente(componentes, arista.Arriba.Nombre);//
                    MetodosAuxiliares.combinaComponentes(ref componentes,i,j);//Se convinan las listas de string
                }
            }
            return ramas;
        }

        #endregion

        #endregion

    }
}
