namespace StoreSystem.Models
{
    public class Compra
    {
        public int IdCompra { get; set; }

        public DateTime Fecha {  get; set; }   

        public FormaDePago FormaDePago { get; set; }

        public int ProveedorId { get; set; }

        public Proveedor? Proveedor { get; set; }

        public decimal Total {  get; set; }

        public List<DetalleCompra> Detalles { get; set; } = new();

    }
}
