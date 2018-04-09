
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventario.COMMON.Entidades
{
   public  class Categoria:Base
    {
        public string categoria { get; set; }
        public override string ToString()
        {
            return categoria;
        }
    }
}
