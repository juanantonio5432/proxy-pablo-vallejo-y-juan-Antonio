using System;

namespace SistemaComprasProxy
{
    class CompraReal : ICompra
    {
        public void Comprar(Usuario usuario, Producto producto)
        {
            usuario.Saldo -= producto.Precio;
            producto.Cantidad--;

            Console.WriteLine("\nCompra realizada correctamente.");
            Console.WriteLine($"Saldo restante: ${usuario.Saldo}");
        }
    }
}
