using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using dominio;
using static System.Net.Mime.MediaTypeNames;

namespace negocio
{
    public class ArticuloNegocio
    {
        AccesoDatos datos = new AccesoDatos();
        public List<Articulo> listarArticulos()
        {
            List<Articulo> lista = new List<Articulo>();
            try
            {
                datos.setearConsulta("SELECT A.Id, A.Nombre, A.Descripcion, A.ImagenUrl, A.Precio, A.IdCategoria, C.Descripcion AS Categoria, M.Id AS IdMarca, M.Descripcion AS Marca FROM ARTICULOS A INNER JOIN MARCAS M ON A.IdMarca = M.Id INNER JOIN CATEGORIAS C ON A.IdCategoria=C.Id");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        aux.Imagen = (string)datos.Lector["ImagenUrl"];
                    aux.Precio = (Decimal)datos.Lector["Precio"];
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
        public Articulo cargarArticulo(Articulo nuevo)
        {
            try
            {
                datos.setearConsulta("SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.ImagenUrl, A.Precio, A.IdCategoria, C.Descripcion AS Categoria, M.Id AS IdMarca, M.Descripcion AS Marca FROM ARTICULOS A INNER JOIN MARCAS M ON A.IdMarca = M.Id INNER JOIN CATEGORIAS C ON A.IdCategoria=C.Id where A.Id=@Id");
                datos.setearParametro("Id",nuevo.Id );
                datos.ejecutarLectura();
                
                Articulo aux = new Articulo();
                if (datos.Lector.Read())
                {
                    aux.Id = (int)datos.Lector["Id"];
                    aux.CodigoArticulo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        aux.Imagen = (string)datos.Lector["ImagenUrl"];
                    aux.Precio = (Decimal)datos.Lector["Precio"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                }
                return aux;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
      
        public Articulo listarArticuloModificar(Articulo nuevo) 
        {
            try
            {
                datos.setearConsulta("Select Codigo, Nombre, A.Descripcion, IdMarca, IdCategoria, ImagenUrl, M.Descripcion Marca, C.Descripcion Categoria From ARTICULOS A, MARCAS M, CATEGORIAS C Where A.IdCategoria=C.Id AND A.IdMarca=M.Id AND A.Id = @Id");
                datos.setearParametro("Id", nuevo.Id);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {

                    nuevo.CodigoArticulo = (string)datos.Lector["Codigo"];
                    nuevo.Nombre = nuevo.Nombre;
                    nuevo.Descripcion = nuevo.Descripcion;
                    nuevo.Marca = new Marca();
                    nuevo.Marca.Id = (int)datos.Lector["IdMarca"];
                    nuevo.Categoria = new Categoria();
                    nuevo.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        nuevo.Imagen = (string)datos.Lector["ImagenUrl"];
                    nuevo.Marca.Descripcion = (string)datos.Lector["Marca"];
                    nuevo.Categoria.Descripcion = (string)datos.Lector["Categoria"];

                    return nuevo;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public int agregar(Articulo nuevo)
        {
            try
            {

                datos.setearConsulta("INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio) VALUES (@Codigo, @Nombre, @Descripcion, @IdMarca, @IdCategoria, @ImagenUrl, @Precio)");
                datos.setearParametro("@Codigo", nuevo.CodigoArticulo);
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Descripcion", nuevo.Descripcion);
                datos.setearParametro("@IdMarca", nuevo.Marca.Id);
                datos.setearParametro("@IdCategoria", nuevo.Categoria.Id);
                datos.setearParametro("@ImagenUrl", nuevo.Imagen);
                datos.setearParametro("@Precio", nuevo.Precio);
                
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
        public int modificar(Articulo nuevo)
        {
            try
            {
                datos.setearConsulta("UPDATE ARTICULOS SET Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, IdMarca=@IdMarca, IdCategoria=@IdCategoria, ImagenUrl=@ImagenUrl, Precio = @Precio WHERE Id = @Id");
                datos.setearParametro("@Codigo", nuevo.CodigoArticulo);
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Descripcion", nuevo.Descripcion);
                datos.setearParametro("@IdMarca", nuevo.Marca.Id);
                datos.setearParametro("@IdCategoria", nuevo.Categoria.Id);
                datos.setearParametro("@ImagenUrl", nuevo.Imagen);
                datos.setearParametro("@Precio", nuevo.Precio);
                datos.setearParametro("@Id", nuevo.Id);
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
        public int eliminar(int id)
        {
            try
            {
                datos.setearConsulta("DELETE FROM ARTICULOS WHERE Id = @Id");
                datos.setearParametro("@Id", id);
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
        
        public void modificarImagen(Articulo nuevo)
        {
            try
            {
                datos.setearConsulta("UPDATE ARTICULOS SET ImagenUrl = @ImagenUrl WHERE Id = @Id");
                datos.setearParametro("@Id", nuevo.Id);
                datos.setearParametro("@ImagenUrl", nuevo.Imagen);
                datos.ejecutarAccion();
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
        
        public List<Articulo> filtrar(int marca, int categoria, decimal precioMax, decimal precioMin)
        {
            List<Articulo> lista = new List<Articulo>();
            try
            {
                string consulta = @" SELECT A.Id, Codigo, Nombre, A.Descripcion, Precio, ImagenUrl, C.Descripcion AS Categoria, C.Id, M.Descripcion AS Marca, M.Id AS IdMarca FROM ARTICULOS A INNER JOIN CATEGORIAS C ON C.Id = A.IdCategoria INNER JOIN MARCAS M ON M.Id = A.IdMarca WHERE 1=1";
                if (marca != 0)
                {
                    consulta += " AND M.Id = " + marca;
                }
                if (categoria != 0)
                {
                    consulta += " AND C.Id = " + categoria;
                }
                if (precioMin != 0 && precioMax != 0)
                {
                    consulta += " AND Precio BETWEEN " + precioMin + " AND " + precioMax;
                }
                else if (precioMin != 0)
                {
                    consulta += " AND Precio >= " + precioMin;
                }
                else if (precioMax != 0)
                {
                    consulta += " AND Precio <= " + precioMax;
                }

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.CodigoArticulo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Precio = (Decimal)datos.Lector["Precio"];
                    aux.Imagen = (string)datos.Lector["ImagenUrl"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Categoria.Id = (int)datos.Lector["Id"];
                    aux.Marca = new Marca();
                    aux.Marca.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Marca.Id = (int)datos.Lector["Id"];

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


