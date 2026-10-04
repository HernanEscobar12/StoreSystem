namespace StoreSystem.Models
{
    public class DetalleVenta
    {
        public int IdDetalleVenta { get; set; }
        public int IdVenta { get; set; }
        public Venta ? Venta { get; set; }    
        public int ProductoId { get; set; }
        public Producto? Producto { get; set; }  
        public int Cantidad { get; set; }
        public Decimal PrecioUnitario { get; set; }
        public Decimal SubTotal =>  Cantidad * PrecioUnitario;
    }
}
