namespace Entity
{
    public class OrdenEntity : DBEntity
    {
        public OrdenEntity()
        {
            Producto = Producto ?? new ProductoEntity();
        }

        public int? IdOrden { get; set; }

        public int? IdProducto { get; set; }

        public int CantidadProducto { get; set; }

        public bool Estado { get; set; }

        public virtual ProductoEntity Producto { get; set; }
    }
}
