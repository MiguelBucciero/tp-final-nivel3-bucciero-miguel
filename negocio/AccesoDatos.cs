using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace negocio
{
    public class AccesoDatos
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;
        public SqlDataReader Lector 
        {
            get { return lector; } 
        }
        public AccesoDatos() 
        {
            // La cadena "CatalogoDB" vive en connectionStrings.config (no se sube a git):
            // en la PC apunta a SQLEXPRESS y en el hosting a db71080.
            conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["CatalogoDB"].ConnectionString);
            comando = new SqlCommand();
        }
        public void setearConsulta(string consulta)
        {
            comando.Parameters.Clear();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }
        public void ejecutarLectura()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int ejecutarAccion()
        {
            comando.Connection = conexion;
            int filasAfectadas = 0;
            try
            {
                conexion.Open();
                filasAfectadas = comando.ExecuteNonQuery();
                return filasAfectadas;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void setearParametro(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }
        public void cerrarConexion()
        {
            if (lector != null) 
                lector.Close();
            conexion.Close();
        }
    }
}
