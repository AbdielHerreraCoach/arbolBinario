using System.Text;

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

            return valor < actual.Valor
                ? BuscarRecursivo(actual.Izquierdo, valor)
                : BuscarRecursivo(actual.Derecho, valor);
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
                // Sin hijos
                if (actual.Izquierdo == null && actual.Derecho == null)
                    return null;

                // Un hijo
                if (actual.Izquierdo == null)
                    return actual.Derecho;

                if (actual.Derecho == null)
                    return actual.Izquierdo;

                // Dos hijos
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

        // RECORRIDO INORDEN (devuelve texto)
        public string InOrden()
        {
            StringBuilder resultado = new StringBuilder();
            InOrdenRecursivo(Raiz, resultado);
            return resultado.Length == 0 ? "Árbol vacío" : resultado.ToString();
        }

        private void InOrdenRecursivo(Nodo actual, StringBuilder resultado)
        {
            if (actual != null)
            {
                InOrdenRecursivo(actual.Izquierdo, resultado);
                resultado.Append(actual.Valor + " ");
                InOrdenRecursivo(actual.Derecho, resultado);
            }
        }
    }
}
