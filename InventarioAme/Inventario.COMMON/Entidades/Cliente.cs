using System;
using System.Collections.Generic;
using System.Text;

namespace Inventario.COMMON.Entidades
{
   public class Cliente:Base
    {
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Rfc { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        // para poner mas es con el + y comillas 
        public override string ToString()
        {
            return Nombre ;
        }

    }
}
