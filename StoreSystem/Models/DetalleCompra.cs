namespace StoreSystem.Models
{
    public class DetalleCompra
    {
        public int IdDetalleCompra { get; set; }

        public int IdCompra { get; set; }

        public Compra? Compra { get; set; }

        public int ProductoID { get; set; }

        public Producto? Producto { get; set; }

        public int Cantidad {  get; set; }  

        public decimal PrecioUnitario { get; set; } 

        public decimal SubTotal => Cantidad * PrecioUnitario;
    }
}
