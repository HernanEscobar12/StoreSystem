namespace StoreSystem.Models
{
    public class Venta
    {
        public int IdVenta { get; set; }
        public DateTime Fecha { get; set; }
        public FormaDePago FormaDePago { get; set; }
        public int IdCliente { get; set; }
        public Cliente? Cliente { get; set; }
        public decimal Total { get; set; }

        public decimal SaldoPendiente { get; set; }
        public List<DetalleVenta> Detalles { get; set; } = new();

    }
}
