using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace TPFinalNivel3BuccieroMiguel
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                cargarArticulos();
                cargarFiltros();
            }
            
        }

        private void cargarArticulos()
        {
            try
            {
                List<Articulo> listaArticulo;

                if (Session["listaArticulo"] != null)
                {
                    listaArticulo = (List<Articulo>)Session["listaArticulo"];
                }
                else
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    listaArticulo = negocio.listarArticulos();

                    Session.Add("listaArticulo", listaArticulo);
                }

                // FILTRO POR CATEGORIA
                if (Request.QueryString["categoria"] != null)
                {
                    int categoria = int.Parse(Request.QueryString["categoria"]);

                    listaArticulo = listaArticulo
                        .Where(x => x.Categoria != null && x.Categoria.Id == categoria)
                        .ToList();
                }

                // BUSQUEDA
                if (Request.QueryString["buscar"] != null)
                {
                    string texto = Request.QueryString["buscar"].ToLower();

                    listaArticulo = listaArticulo.Where(x =>
                        x.Nombre.ToLower().Contains(texto) ||
                        (x.Marca != null && x.Marca.Descripcion.ToLower().Contains(texto))
                    ).ToList();
                }

                // ORDENAMIENTO
                if (Request.QueryString["orden"] != null)
                {
                    string orden = Request.QueryString["orden"];

                    if (orden == "precio_desc")
                        listaArticulo = listaArticulo.OrderByDescending(x => x.Precio).ToList();
                    else if (orden == "precio_asc")
                        listaArticulo = listaArticulo.OrderBy(x => x.Precio).ToList();
                }

                repRepetidor.DataSource = listaArticulo;
                repRepetidor.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
        private void cargarFiltros()
        {
            try
            {
                CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                List<Categoria> listaCategoria = categoriaNegocio.listar();
                MarcaNegocio marcaNegocio = new MarcaNegocio();
                List<Marca> listaMarca = marcaNegocio.listar();

                // MARCAS
                var marcas = listaMarca.Select(x => x.Descripcion).Distinct().ToList();
                chkMarca.DataSource = marcas;
                chkMarca.DataBind();

                // CATEGORIAS
                var categorias = listaCategoria.Select(x => x.Descripcion).Distinct().ToList();
                chkCategoria.DataSource = categorias;
                chkCategoria.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
            
        }

        protected void lnkImagen_Click(object sender, EventArgs e)
        {
            string id = ((LinkButton)sender).CommandArgument;
            Session.Add("idArticulo", id);
            Response.Redirect("DetalleArticulo.aspx");
        }

        protected void agregarFavoritos_Click(object sender, EventArgs e)
        {
            string id = ((Button)sender).CommandArgument;
            //lo desarrollo luego esta parte
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            //lo desarrollo luego esta parte
        }
    }
}