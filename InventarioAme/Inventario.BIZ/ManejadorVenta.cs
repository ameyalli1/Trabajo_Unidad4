using Inventario.COMMON.Entidades;
using Inventario.COMMON.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inventario.BIZ
{

    public class ManejadorVenta : IManejadorVenta
    {
        IRepositorio<venta> repositorio;
        public ManejadorVenta(IRepositorio<venta> repositorio)
        {
            this.repositorio = repositorio;
        }


        public List<venta> Listar => repositorio.Read;

        public bool Agregar(venta entidad)
        {
            return repositorio.Create(entidad);
        }

        public venta BuscarPorId(string id)
        {
            return Listar.Where(e => e.Id == id).SingleOrDefault();
        }

        public bool Eliminar(string id)
        {
            return repositorio.Delete(id);
        }

        public bool Modificar(venta entidad)
        {
            return repositorio.Update(entidad);
        }
    }
}
