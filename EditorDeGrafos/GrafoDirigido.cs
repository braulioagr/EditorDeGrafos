using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorDeGrafos
{
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
                    arista = new Arista(a.Peso, a.P1, a.P2, a.AnchoLinea, a.ColorLinea, a.Arriba);
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
        #endregion
    }
}
