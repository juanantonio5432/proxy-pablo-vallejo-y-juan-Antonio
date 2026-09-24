using System;

namespace SistemaComprasProxy
{
    class CompraProxy : ICompra
    {
        private CompraReal compraReal = new CompraReal();

        public void Comprar(Usuario usuario, Producto producto)
        {
            Console.WriteLine("\nVerificando usuario...");
            if (!usuario.Autenticado)
            {
                Console.WriteLine("Acceso denegado.");
                Console.WriteLine("Debe iniciar sesión antes de comprar.");
                return;
            }

            Console.WriteLine("Verificando saldo...");
            if (usuario.Saldo < producto.Precio)
            {
                Console.WriteLine("Compra rechazada: saldo insuficiente.");
                return;
            }

            if (producto.Cantidad <= 0)
            {
                Console.WriteLine("Compra rechazada: producto sin stock.");
                return;
            }

            compraReal.Comprar(usuario, producto);
        }
    }
}
