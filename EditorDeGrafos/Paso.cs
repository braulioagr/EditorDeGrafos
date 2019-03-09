using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorDeGrafos
{
    class Paso
    {

        #region Variables de Instancia
        private int[,] matriz;
        private string cambio;
        #endregion

        #region Consstructores
        public Paso(int[,] matriz, string cambio)
        {
            this.matriz = new int[matriz.GetLength(0),matriz.GetLength(0)];
            this.cambio = cambio;
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(0); j++)
                {
                    this.matriz[i, j] = matriz[i, j];
                }
            }
        }

        #endregion
        
        #region Gets & Sets
        public int[,] Matriz
        {
            get { return this.matriz; }
        }
        public string Cambio
        {
            get{ return this.cambio; }
        }
        #endregion

    }
}
