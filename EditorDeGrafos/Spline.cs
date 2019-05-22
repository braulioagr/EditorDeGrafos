using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorDeGrafos
{
    class Spline
    {
         private Point p1, p2, p3, p4; 
        private int numPtos;
        private Punto[] arrptos;
        private Pen pn;

        
        /// <summary>
        /// Constructor del bezier que recibe los puntos iniciales y finales del mismo
        /// </summary>
        /// <param name="pt1">Punto inicial del bezier</param>
        /// <param name="pt2">Punto final del bezier</param>
        public Spline(Point pt1, Point pt2)
        {
            p1 = new Point(pt1.X, pt1.Y);
            p4 = new Point(pt2.X, pt2.Y);
            p2 = new Point();
            p3 = new Point();
            pn = new Pen(Color.Black);
            numPtos = 30;
            arrptos = new Punto[numPtos];
            for (int i = 0; i < numPtos; i++)
                arrptos[i] = new Punto();
            Crea_Puntos();
        }

        public Point puntoMedio
        {
            get
            {
                int indiceMedio;
                Point p;
                indiceMedio = (int)Math.Round((double)arrptos.Length / 2);
                p = new Point((int)arrptos[indiceMedio].X, (int)arrptos[indiceMedio].Y);
                return p;
            }
        }
        /// <summary>
        /// Crea los puntos de control en los que se basara para crear el bezier, dandoles 
        /// una distancia apropiada para formar bien la curva
        /// </summary>
        public void Crea_Puntos()
        {
            double distancia, grados;
            //double angulo, d, m, xc, yc, xi, yi;
            float x1 = p1.X, y1 = p1.Y, x2, y2, x3, y3, x4 = p4.X, y4 = p4.Y;
            Point paux1 = new Point();
            Point paux2 = new Point();
            Point paux3 = new Point();
            Point paux4 = new Point();

            grados = Math.Atan2((p4.Y-p1.Y),p4.X-(p1.X+.0001));
            grados += Math.PI / 2;
            distancia = Math.Sqrt(Math.Pow(((p4.X-p1.X)/5),2)+Math.Pow(((p4.Y-p1.Y)/5),2));
            //Punto 2
            p2.X = p1.X + ((p4.X - p1.X) / 3);
            p2.Y = p1.Y + ((p4.Y - p1.Y) / 3);
            x2 = (float)(p2.X - (distancia * Math.Cos(grados)));
            y2 = (float)(p2.Y - (distancia * Math.Sin(grados)));
            //Punto 3
            p3.X = p4.X - ((p4.X - p1.X) / 3);
            p3.Y = p4.Y - ((p4.Y - p1.Y) / 3);
            x3 = (float)(p3.X - (distancia * Math.Cos(grados)));
            y3 = (float)(p3.Y - (distancia * Math.Sin(grados)));
            
            paux2.X = (int)x2;
            paux2.Y = (int)y2;
            paux3.X = (int)x3;
            paux3.Y = (int)y3;
            //Aqui se podria calcular de nuevo paux1 y paux4 para ponerlos afuera de un nodo
            paux1.X = (int)x1;
            paux1.Y = (int)y1;
            paux4.X = (int)x4;
            paux4.Y = (int)y4;
            calcPuntos(paux1,paux2,paux3,paux4,numPtos);
        }
        /// <summary>
        /// Calcula los puntos de control según los puntos inicial y final del bezier
        /// </summary>
        /// <param name="pt0">Punto inicial del bezier</param>
        /// <param name="pt1">Punto 2 de contrl del bezier</param>
        /// <param name="pt2">Punto 3 de contrl del bezier</param>
        /// <param name="pt3">Punto final del bezier</param>
        /// <param name="nptos">Numero total de puntos que forman el bezier</param>
        private void calcPuntos(Point pt0, Point pt1, Point pt2, Point pt3,int nptos)
        {
            double dt;

            dt = 1.0 / (nptos - 1);
            for (int i = 0; i < nptos; i++)
                arrptos[i] = PointCubicSpline(pt0, pt1, pt2, pt3, i*dt);
        }
        private Punto PointCubicSpline(Point pt0, Point pt1, Point pt2, Point pt3, double t)
        {
            double ax, bx, cx;
            double ay, by, cy;
            double tsquared, tcubed, xr, yr;
            Punto result;

            cx = 3.0 * (pt1.X - pt0.X);
            bx = 3.0 * (pt2.X - pt1.X)-cx;
            ax = pt3.X - pt0.X - cx - bx;
            cy = 3.0 * (pt1.Y - pt0.Y);
            by = 3.0 * (pt2.Y - pt1.Y) - cy;
            ay = pt3.Y - pt0.Y - cy - by;

            tsquared = t * t;
            tcubed = tsquared * t;
            xr = (ax * tcubed) + (bx * tsquared) + (cx * t) + pt0.X;
            yr = (ay * tcubed) + (by * tsquared) + (cy * t) + pt0.Y;            
            result = new Punto(xr, yr);

            return result;
        }
        /// <summary>
        /// Pinta el bezier
        /// </summary>
        /// <param name="grp">Parametro tipo Grahics utilizado para pintar las lineas</param>
        public void PintaCurva(Graphics grp)
        {
            float x, y, x2, y2;            

            for (int i = 0; i < arrptos.Length - 1; i++)
            {
                x = (float)arrptos[i].X;
                y = (float)arrptos[i].Y;
                x2 = (float)arrptos[i+1].X;
                y2 = (float)arrptos[i+1].Y;
                grp.DrawLine(pn, x, y, x2, y2);
            }
            pn.CustomEndCap = new AdjustableArrowCap(5, 5);
            grp.DrawLine(pn, (int)arrptos[arrptos.Length-2].X, (int)arrptos[arrptos.Length-2].Y, (int)arrptos[arrptos.Length-1].X, (int)arrptos[arrptos.Length-1].Y);
        }
        /// <summary>
        /// Asigna un nuevo valor al punto final del bezier (p4)
        /// </summary>
        /// <param name="pf">Punto nuevo al que se asignara p4</param>
        public void SetPtFinal(Point pf)
        {
            p4.X = pf.X;
            p4.Y = pf.Y;
        }


        internal void PintaCurva(Graphics g, Color color, int ancho)
        {
            float x, y, x2, y2;
            pn.Color = color;
            pn.Width = ancho;
            for (int i = 0; i < arrptos.Length - 1; i++)
            {
                x = (float)arrptos[i].X;
                y = (float)arrptos[i].Y;
                x2 = (float)arrptos[i + 1].X;
                y2 = (float)arrptos[i + 1].Y;
                g.DrawLine(pn, x, y, x2, y2);
            }
            pn.CustomEndCap = new AdjustableArrowCap(5, 5);
            g.DrawLine(pn, (int)arrptos[arrptos.Length - 2].X, (int)arrptos[arrptos.Length - 2].Y, (int)arrptos[arrptos.Length - 1].X, (int)arrptos[arrptos.Length - 1].Y);
        }

        public void PintaCurva(Graphics g, Color color, int ancho, string etiqueta)
        {
            float x, y, x2, y2;
            int indiceMedio;
            pn.Color = color;
            pn.Width = ancho;
            for (int i = 0; i < arrptos.Length - 1; i++)
            {
                x = (float)arrptos[i].X;
                y = (float)arrptos[i].Y;
                x2 = (float)arrptos[i + 1].X;
                y2 = (float)arrptos[i + 1].Y;
                g.DrawLine(pn, x, y, x2, y2);
            }
            pn.CustomEndCap = new AdjustableArrowCap(5, 5);
            g.DrawLine(pn, (int)arrptos[arrptos.Length - 2].X, (int)arrptos[arrptos.Length - 2].Y, (int)arrptos[arrptos.Length - 1].X, (int)arrptos[arrptos.Length - 1].Y);
            indiceMedio = (int)Math.Round((double)arrptos.Length / 2);
            g.DrawString(etiqueta, new Font("Times New Roman", 10), new SolidBrush(Color.Purple), new Point((int)arrptos[indiceMedio].X, (int)arrptos[indiceMedio].Y));
        }

        internal void PintaCurva(Graphics grp, string etiqueta)
        {
            float x, y, x2, y2;
            int indiceMedio;
            for (int i = 0; i < arrptos.Length - 1; i++)
            {
                x = (float)arrptos[i].X;
                y = (float)arrptos[i].Y;
                x2 = (float)arrptos[i + 1].X;
                y2 = (float)arrptos[i + 1].Y;
                grp.DrawLine(pn, x, y, x2, y2);
            }
            pn.CustomEndCap = new AdjustableArrowCap(5, 5);
            grp.DrawLine(pn, (int)arrptos[arrptos.Length - 2].X, (int)arrptos[arrptos.Length - 2].Y, (int)arrptos[arrptos.Length - 1].X, (int)arrptos[arrptos.Length - 1].Y);
            indiceMedio = (int)Math.Round((double)arrptos.Length / 2);
            grp.DrawString(etiqueta, new Font("Times New Roman", 10), new SolidBrush(Color.Black), new Point((int)arrptos[indiceMedio].X, (int)arrptos[indiceMedio].Y));
        }
    }
}
