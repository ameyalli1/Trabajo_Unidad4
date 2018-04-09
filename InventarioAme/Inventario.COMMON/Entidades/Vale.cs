using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Inventario.COMMON.Entidades
{
     public class Vale
    {

        public string Archivo { get; set; }
        public Vale(string archivo)
        {
            Archivo = archivo;
        }
        public bool Guardar(string elementos)
        {
            try
            {
                StreamWriter fila = new StreamWriter(Archivo);
                fila.Write(elementos);
                fila.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public string Leer()
        {
            try
            {
                StreamReader fila = new StreamReader(Archivo);
                string elementos = fila.ReadToEnd();
                fila.Close();
                return elementos;
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}
