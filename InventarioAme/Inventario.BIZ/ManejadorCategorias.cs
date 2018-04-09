using Inventario.COMMON.Entidades;
using Inventario.COMMON.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inventario.BIZ
{
   public class ManejadorCategorias : IManejadorCategoria
    {
        IRepositorio<Categoria> repositorio;
        public ManejadorCategorias(IRepositorio<Categoria> repo)

        
        {
            repositorio = repo;
        }


        public List<Categoria> Listar => repositorio.Read;

        public bool Agregar(Categoria entidad)
        {
            return repositorio.Create(entidad);
        }

        public Categoria BuscarPorId(string id)
        {
            return Listar.Where(e => e.Id == id).SingleOrDefault();
        }

        public bool Eliminar(string id)
        {
            return repositorio.Delete(id);
        }

        public bool Modificar(Categoria entidad)
        {
            return repositorio.Update(entidad);
        }
    }
}
