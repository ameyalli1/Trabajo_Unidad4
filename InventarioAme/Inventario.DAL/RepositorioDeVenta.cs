﻿
using Inventario.COMMON.Entidades;
using Inventario.COMMON.Interfaces;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inventario.DAL
{
  public  class RepositorioDeVenta : IRepositorio<venta>
    {
        private string DBName = "Inventario.db";
        private string TableName = "Vale";

        public List<venta> Read
        {
            get
            {
                List<venta> datos = new List<venta>();
                using (var db = new LiteDatabase(DBName))
                {
                    // todo lo que gaciemos antes lo hace con esta linea
                    datos = db.GetCollection<venta>(TableName).FindAll().ToList();
                }
                return datos;
            }
        }
        public bool Create(venta entidad)
        {
            entidad.Id = Guid.NewGuid().ToString();

            try
            {
                using (var db = new LiteDatabase(DBName))
                {
                    var coleccion = db.GetCollection<venta>(TableName);
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
                    var coleccion = db.GetCollection<venta>(TableName);
                    r = coleccion.Delete(e => e.Id == id);
                }

                return r > 0;

            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool Update(venta entidadModificada)
        {
            try
            {
                using (var db = new LiteDatabase(DBName))
                {
                    var coleccion = db.GetCollection<venta>(TableName);
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
