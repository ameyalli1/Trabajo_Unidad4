using Inventario.COMMON.Entidades;
using Inventario.COMMON.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inventario.BIZ
{
   public  class ManejadorProductos:IManejadorProductos
    {
        IRepositorio<Producto> repositorio;
        public ManejadorProductos(IRepositorio<Producto> repositorio)
        {
            this.repositorio = repositorio;
        }

        public List<Producto> Listar => repositorio.Read;

        public bool Agregar(Producto entidad)
        {
            return repositorio.Create(entidad);
        }

        public Producto BuscarPorId(string id)
        {
            return Listar.Where(e => e.Id == id).SingleOrDefault();
        }

        public bool Eliminar(string id)
        {
            return repositorio.Delete(id);
        }

       
        public bool Modificar(Producto entidad)
        {
            return repositorio.Update(entidad);
        }
    }
}
