namespace SistemaComprasProxy
{
    class Usuario
    {
        public string Nombre { get; set; }
        public decimal Saldo { get; set; }
        public bool Autenticado { get; set; }

        public Usuario(string nombre, decimal saldo)
        {
            Nombre = nombre;
            Saldo = saldo;
            Autenticado = false;
        }
    }
}
