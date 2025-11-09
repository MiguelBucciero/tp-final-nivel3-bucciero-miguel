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
        public List<Articulo> listarDgv()
        {
            List<Articulo> lista = new List<Articulo>();
            try
            {
                datos.setearConsulta("Select Id, Nombre, Descripcion, ImagenUrl , Precio From ARTICULOS");
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
        public List<Articulo> listarDetalle(Articulo nuevo)
        {
            List<Articulo> lista = new List<Articulo>();
            try
            {
                datos.setearConsulta("Select A.Id Id, Codigo, Nombre, A.Descripcion Descripcion, ImagenUrl, Precio , M.Descripcion Marca, C.Descripcion Categoria From ARTICULOS A, MARCAS M, CATEGORIAS C where A.IdMarca = M.Id AND A.IdCategoria = C.id AND A.Id = @Id");
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
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    aux.Marca = new Marca();
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    lista.Add(aux);
                }
                return lista;
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
        public void agregar(Articulo nuevo)
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
        public void modificar(Articulo nuevo)
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
        public void eliminar(int id)
        {
            try
            {
                datos.setearConsulta("DELETE FROM ARTICULOS WHERE Id = @Id");
                datos.setearParametro("@Id", id);
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
        
        public List<Articulo> filtrar(string campo, string criterio, string filtro)
        {
            List<Articulo> lista = new List<Articulo>();
            try
            {
                string consulta = (" Select A.Id, Codigo, Nombre, A.Descripcion, Precio, ImagenUrl, C.Descripcion ,C.Id, M.Descripcion,M.Id Marca From ARTICULOS A, CATEGORIAS C, MARCAS M Where  C.Id = A.IdCategoria AND M.Id = A.IdMarca AND ");
                if (campo == "Número")
                {
                    switch (criterio)
                    {
                        case "Mayor a":
                            consulta += "A.Id > " + filtro;
                            break;
                        case "Menor a":
                            consulta += "A.Id < " + filtro;
                            break;
                        default:
                            consulta += "A.Id = " + filtro;
                            break;
                    }
                }
                else if (campo == "Nombre")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "Nombre like '" + filtro + "%'";
                            break;
                        case "Termina con":
                            consulta += "Nombre like '% " + filtro + "'";
                            break;
                        default:
                            consulta += "Nombre like '%" + filtro + "%'";
                            break;
                    }
                }
                else
                {
                    switch (criterio)
                    {
                        case "Mayor a":
                            consulta += "Precio > " + filtro;
                            break;
                        case "Menor a":
                            consulta += "Precio < " + filtro;
                            break;
                        default:
                            consulta += "Precio = " + filtro;
                            break;
                    }
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


