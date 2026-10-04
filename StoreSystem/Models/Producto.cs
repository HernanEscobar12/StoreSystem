namespace StoreSystem.Models
{
    public class Producto
    {

        public int IdProducto { get; set; } 

        public string CodigoBarras { get; set; }    

        public string Nombre { get; set; } = "";

        public int CategoriaId { get; set; }    

        public Categoria ? Categoria {  get; set; } 

        public Decimal PrecioCosto { get; set; }    

        public Decimal PrecioVenta { get; set; }    

        public int Stock {  get; set; } 

        public int StockMinimo { get; set; }    

        public bool Estado { get; set; }


        public ICollection<DetalleCompra> detalleCompras { get; set; } = new List<DetalleCompra>();
        public ICollection<DetalleVenta> detalleVentas{ get; set; } = new List<DetalleVenta>();


    }
}