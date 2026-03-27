using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class FavoritoNegocio
    {
        AccesoDatos datos = new AccesoDatos();
        public int agregarFavoritos(Favorito favorito)
        {
            try
            {
                datos.setearConsulta("INSERT INTO FAVORITOS (IdUser, IdArticulo) VALUES (@idUser, @idArticulo)");
                datos.setearParametro("@idUser", favorito.IdUser);
                datos.setearParametro("@idArticulo", favorito.IdArticulo);
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
        public int eliminarFavoritos(int idUser, int idArticulo)
        {
            try
            {
                datos.setearConsulta("DELETE FROM FAVORITOS WHERE IdUser = @idUser AND IdArticulo = @idArticulo");
                datos.setearParametro("idUser", idUser);
                datos.setearParametro("idArticulo", idArticulo);

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
        public bool existeFavoritos(int idUser, int idArticulo)
        {
            try
            {
                datos.setearConsulta("SELECT 1 FROM FAVORITOS WHERE IdUser = @idUser AND IdArticulo = @idArticulo");
                datos.setearParametro("idUser", idUser);
                datos.setearParametro("idArticulo", idArticulo);

                datos.ejecutarLectura();

                return datos.Lector.Read();
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
        public List<Articulo> listarFavoritos(int idUser)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.Precio, A.ImagenUrl, C.Descripcion AS Categoria, C.Id AS IdCategoria, M.Descripcion AS Marca, M.Id AS IdMarca FROM FAVORITOS F INNER JOIN ARTICULOS A ON A.Id = F.IdArticulo INNER JOIN CATEGORIAS C ON C.Id = A.IdCategoria INNER JOIN MARCAS M ON M.Id = A.IdMarca WHERE F.IdUser = @idUser");

                datos.setearParametro("idUser", idUser);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.CodigoArticulo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    aux.Imagen = (string)datos.Lector["ImagenUrl"];

                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];

                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];

                    lista.Add(aux);
                }

                return lista;
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
