using System;
using System.Collections.Generic;
using System.Text;

namespace Inventario.COMMON.Entidades
{
    public class ReporteGeneral : Base
    {
        public string NombreProducto { get; set; }
        public string Empleado { get; set; }
        public string Cliente { get; set; }
     //   public float MyProperty { get; set; }
        public float Total { get; set; }

    }
}
