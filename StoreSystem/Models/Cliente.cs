namespace StoreSystem.Models
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Apellido { get; set; }

        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public string? Direccion { get; set; }
        public string? Dni { get; set; }

        public decimal Saldo { get; set; } = 0m;   // positivo = debe, negativo = a favor

        public bool Activo { get; set; } = true;
        public ICollection<Venta> Ventas { get; set; } = new List<Venta>();

    }
}
