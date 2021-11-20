namespace Entity
{
    public class ProductoEntity : DBEntity
    {
        public ProductoEntity()
        {
        }
        
        public int? IdProducto { get; set; }
        
        public string NombreProducto { get; set; }

        public decimal PrecioProducto { get; set; }

    }
}
