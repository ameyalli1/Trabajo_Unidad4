using Inventario.COMMON.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventario.COMMON.Interfaces
{
   public  interface IManejadorProductos:IManejadorGenerico<Producto>
    {
        // esta era mi error
       // List<Producto> MaterialesDeCategoria(string categoria);

    }
}
