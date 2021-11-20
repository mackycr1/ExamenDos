using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    class ProductoEntity : DBEntity
    {
        public ProductoEntity()
        {
        }
        
        public int? IdProducto { get; set; }
        
        public string NombreProducto { get; set; }

        public decimal PrecioProducto { get; set; }

    }
}
