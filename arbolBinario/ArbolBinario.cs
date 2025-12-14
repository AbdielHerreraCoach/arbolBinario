using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arbolBinario
{
    internal class ArbolBinario
    {
        public Nodo Raiz;

        public ArbolBinario()
        {
            Raiz = null;
        }

        // INSERCIÓN
        public void Insertar(int valor)
        {
            Raiz = InsertarRecursivo(Raiz, valor);
        }

        private Nodo InsertarRecursivo(Nodo actual, int valor)
        {
            if (actual == null)
                return new Nodo(valor);

            if (valor < actual.Valor)
                actual.Izquierdo = InsertarRecursivo(actual.Izquierdo, valor);
            else if (valor > actual.Valor)
                actual.Derecho = InsertarRecursivo(actual.Derecho, valor);

            return actual;
        }

        // BÚSQUEDA
        public bool Buscar(int valor)
        {
            return BuscarRecursivo(Raiz, valor);
        }

        private bool BuscarRecursivo(Nodo actual, int valor)
        {
            if (actual == null)
                return false;

            if (actual.Valor == valor)
                return true;

            if (valor < actual.Valor)
                return BuscarRecursivo(actual.Izquierdo, valor);
            else
                return BuscarRecursivo(actual.Derecho, valor);
        }

        // ELIMINACIÓN
        public void Eliminar(int valor)
        {
            Raiz = EliminarRecursivo(Raiz, valor);
        }

        private Nodo EliminarRecursivo(Nodo actual, int valor)
        {
            if (actual == null)
                return null;

            if (valor < actual.Valor)
                actual.Izquierdo = EliminarRecursivo(actual.Izquierdo, valor);
            else if (valor > actual.Valor)
                actual.Derecho = EliminarRecursivo(actual.Derecho, valor);
            else
            {
                // Caso 1: sin hijos
                if (actual.Izquierdo == null && actual.Derecho == null)
                    return null;

                // Caso 2: un hijo
                if (actual.Izquierdo == null)
                    return actual.Derecho;

                if (actual.Derecho == null)
                    return actual.Izquierdo;

                // Caso 3: dos hijos
                int menor = EncontrarMinimo(actual.Derecho);
                actual.Valor = menor;
                actual.Derecho = EliminarRecursivo(actual.Derecho, menor);
            }

            return actual;
        }

        private int EncontrarMinimo(Nodo actual)
        {
            while (actual.Izquierdo != null)
                actual = actual.Izquierdo;

            return actual.Valor;
        }

        // RECORRIDO (opcional para mostrar)
        public void InOrden(Nodo actual)
        {
            if (actual != null)
            {
                InOrden(actual.Izquierdo);
                Console.Write(actual.Valor + " ");
                InOrden(actual.Derecho);
            }
        }
    }
}
