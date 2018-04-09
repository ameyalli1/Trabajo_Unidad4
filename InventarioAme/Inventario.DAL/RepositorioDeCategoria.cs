using Inventario.COMMON.Entidades;
using Inventario.COMMON.Interfaces;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inventario.DAL
{
   public  class RepositorioDeCategoria : IRepositorio<Categoria>
    {
        private string DBName = "Inventario.db";
        private string TableName = "Categoria";

        public List<Categoria> Read
        {
            get
            {
                List<Categoria> datos = new List<Categoria>();
                using (var db = new LiteDatabase(DBName))
                {
                    // todo lo que gaciemos antes lo hace con esta linea
                    datos = db.GetCollection<Categoria>(TableName).FindAll().ToList();
                }
                return datos;
            }
        }

        public bool Create(Categoria entidad)
        {
            entidad.Id = Guid.NewGuid().ToString();

            try
            {
                using (var db = new LiteDatabase(DBName))
                {
                    var coleccion = db.GetCollection<Categoria>(TableName);
                    coleccion.Insert(entidad);
                }

                return true;

            }
            catch (Exception)
            {
                return false;

            }
        }

        public bool Delete(string id)
        {
            try
            {
                int r;
                using (var db = new LiteDatabase(DBName))
                {
                    var coleccion = db.GetCollection<Categoria>(TableName);
                    r = coleccion.Delete(e => e.Id == id);
                }

                return r > 0;

            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool Update(Categoria entidadModificada)
        {
            try
            {
                using (var db = new LiteDatabase(DBName))
                {
                    var coleccion = db.GetCollection<Categoria>(TableName);
                    coleccion.Update(entidadModificada);
                }

                return true;

            }
            catch (Exception)
            {
                return false;

            }
        }
    }
}
