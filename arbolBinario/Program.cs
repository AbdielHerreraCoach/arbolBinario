using System;
using arbolBinario;

class Program
{
    static void Main()
    {
        ArbolBinario arbol = new ArbolBinario();

        arbol.Insertar(50);
        arbol.Insertar(30);
        arbol.Insertar(70);
        arbol.Insertar(20);
        arbol.Insertar(40);
        arbol.Insertar(60);
        arbol.Insertar(80);

        Console.WriteLine("Árbol en inorden:");
        Console.WriteLine(arbol.InOrden());

        Console.WriteLine("\nBuscar 40: " + arbol.Buscar(40));
        Console.WriteLine("Buscar 100: " + arbol.Buscar(100));

        arbol.Eliminar(30);

        Console.WriteLine("\nÁrbol después de eliminar 30:");
        Console.WriteLine(arbol.InOrden());

        Console.ReadKey();
    }
}
