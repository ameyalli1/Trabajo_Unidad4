using System;
using System.Collections.Generic;
using System.Text;

namespace Inventario.COMMON.Entidades
{
  public  class Empleado:Base
    {

       
        public string Nombre { get; set; }

        public string Direccion { get; set; }
        public string Rfc { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }

        public string Sueldo { get; set; }
        public string Area { get; set; }
        public override string ToString()
        {
            return Nombre;
        }
    }
}
