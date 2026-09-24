using System;
using System.Collections.Generic;

namespace SistemaComprasProxy
{
    class Program
    {
        static void Main(string[] args)
        {
            Usuario usuario = new Usuario("Cliente", 500000);

            List<Producto> productos = new List<Producto>
            {
                new Producto("Teclado", 120000, 5),
                new Producto("Mouse", 60000, 10),
                new Producto("Monitor", 350000, 2)
            };

            ICompra proxy = new CompraProxy();
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("\n===== TIENDA VIRTUAL =====");
                Console.WriteLine("1. Iniciar sesión");
                Console.WriteLine("2. Ver productos");
                Console.WriteLine("3. Comprar producto");
                Console.WriteLine("4. Ver saldo");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        usuario.Autenticado = true;
                        Console.WriteLine("\nSesión iniciada correctamente.");
                        break;

                    case "2":
                        Console.WriteLine("\n--- Productos disponibles ---");
                        for (int i = 0; i < productos.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {productos[i].Nombre} - ${productos[i].Precio} - Stock: {productos[i].Cantidad}");
                        }
                        break;

                    case "3":
                        Console.WriteLine("\n--- Comprar producto ---");
                        for (int i = 0; i < productos.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {productos[i].Nombre} - ${productos[i].Precio}");
                        }
                        Console.Write("Seleccione el número del producto: ");

                        if (int.TryParse(Console.ReadLine(), out int index) &&
                            index >= 1 && index <= productos.Count)
                        {
                            Producto seleccionado = productos[index - 1];
                            Console.WriteLine($"\nProducto: {seleccionado.Nombre}");
                            Console.WriteLine($"Precio: ${seleccionado.Precio}");
                            proxy.Comprar(usuario, seleccionado);
                        }
                        else
                        {
                            Console.WriteLine("Opción inválida.");
                        }
                        break;

                    case "4":
                        Console.WriteLine($"\nSaldo actual: ${usuario.Saldo}");
                        break;

                    case "5":
                        salir = true;
                        Console.WriteLine("\nSaliendo del sistema...");
                        break;

                    default:
                        Console.WriteLine("\nOpción no válida.");
                        break;
                }
            }
        }
    }
}
