using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EditorDeGrafos
{
    class Partita : List<string>
    {
        public Partita()
        {
        }
        public Partita(string[] elementos)
        {
            foreach (string busca in elementos)
            {
                this.Add(busca);
            }
        }
        public Partita(List<string> elementos)
        {
            foreach (string busca in elementos)
            {
                this.Add(busca);
            }
        }
        public string[] elementos(int id)
        {
            string[] elementos;
            elementos = new string[2];
            elementos[0] = MetodosAuxiliares.convierteRomano(id);
            foreach (string busca in this)
            {
                elementos[1] += "," + busca;
            }
            elementos[1] = elementos[1].Substring(1);
            return elementos;
        }
    }
}
