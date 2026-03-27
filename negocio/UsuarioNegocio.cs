using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class UsuarioNegocio
    {
        AccesoDatos datos = new AccesoDatos();
        public bool Login(Usuario usuario)
        {
            try
            {
                datos.setearConsulta("SELECT Id, Email, Pass, Nombre, Apellido, UrlImagenPerfil, admin FROM USERS WHERE Email = @email AND Pass = @pass");
                datos.setearParametro("@email", usuario.Email);
                datos.setearParametro("@pass", usuario.Pass);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    usuario.Id = (int)datos.Lector["Id"];
                    usuario.Admin = (bool)datos.Lector["admin"];
                    if (!(datos.Lector["Nombre"] is DBNull))
                        usuario.Nombre = (string)datos.Lector["Nombre"];
                    if (!(datos.Lector["Apellido"] is DBNull))
                        usuario.Apellido = (string)datos.Lector["Apellido"];
                    if (!(datos.Lector["UrlImagenPerfil"] is DBNull))
                        usuario.UrlImagen = (string)datos.Lector["UrlImagenPerfil"];
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

          
        public int Modificar(Usuario user)
        {
            try
            {
                datos.setearConsulta("UPDATE USERS SET Email = @email, Pass = @pass, Nombre = @nombre, Apellido = @apellido, UrlImagenPerfil = @urlImagen WHERE Id = @id");
                datos.setearParametro("@email", user.Email);
                datos.setearParametro("@pass", user.Pass);
                datos.setearParametro("@nombre", user.Nombre);
                datos.setearParametro("@apellido", user.Apellido);
                datos.setearParametro("@urlImagen", user.UrlImagen);
                datos.setearParametro("@id", user.Id);
                return datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public int agregarUsurio(Usuario nuevo)
        {
            try
            {
                datos.setearConsulta("INSERT INTO USERS (Email, Pass, admin) VALUES (@email, @pass, 0)");
                datos.setearParametro("@email", nuevo.Email);
                datos.setearParametro("@pass", nuevo.Pass);
                return datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

    }
}

