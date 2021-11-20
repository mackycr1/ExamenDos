﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    class OrdenEntity : DBEntity
    {
        public OrdenEntity()
        {
            Producto = Producto ?? new ProductoEntity();
        }

        public int? IdOrden { get; set; }

        public int? IdProducto { get; set; }

        public int CantidadProducto { get; set; }

        public virtual ProductoEntity Producto { get; set; }
    }
}
