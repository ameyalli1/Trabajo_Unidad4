﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Inventario.COMMON.Entidades
{
   public class Producto:Base
    {

    
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public string Descripcion { get; set; }
        public string PrecioVenta { get; set; }
        public string PrecioCompra { get; set; }
        public string Presentacion { get; set; }

    }
}
