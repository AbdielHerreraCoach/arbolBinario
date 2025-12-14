using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arbolBinario
{
    internal class Nodo
    {
        public int Valor;
        public Nodo Izquierdo;
        public Nodo Derecho;

        public Nodo(int valor)
        {
            Valor = valor;
            Izquierdo = null;
            Derecho = null;
        }
    }
}
