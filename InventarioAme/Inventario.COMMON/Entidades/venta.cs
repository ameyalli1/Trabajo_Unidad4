using System;
using System.Collections.Generic;
using System.Text;

namespace Inventario.COMMON.Entidades
{
  public   class venta:Base
    {
        public string NombreProducto { get; set; }
        public string Categoria { get; set; }
        public float PrecioVenta { get; set; }
        public int Cantidad { get; set; }
        public float Total { get; set; }
    }
}
