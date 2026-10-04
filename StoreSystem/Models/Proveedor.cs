namespace StoreSystem.Models
{
    public class Proveedor
    {
        public int IdProveedor { get; set; }

        public string Nombre { get; set; }

        public string ? Telefono { get; set; }

        public ICollection<Compra> Compras { get; set; } = new List<Compra>();
    }
}
