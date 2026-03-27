using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;

namespace TPFinalNivel3BuccieroMiguel
{
    public partial class DetalleArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["idArticulo"] != null)
                {
                    cargarArticulo();
                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
            }
        }
        private void cargarArticulo()
        {
            try
            {
                ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                Articulo articulo = new Articulo();
                articulo.Id = int.Parse((string)Session["idArticulo"]);
                articulo = articuloNegocio.cargarArticulo(articulo);
                lblNombre.Text = articulo.Nombre;
                lblDescripcion.Text = articulo.Descripcion;
                lblPrecio.Text = articulo.Precio.ToString("N2");
                lblCodigo.Text = articulo.CodigoArticulo;
                lblMarca.Text = articulo.Marca.Descripcion;
                imgProducto.ImageUrl = articulo.Imagen;

                if (Session["usuario"] != null)
                {
                    Usuario user = (Usuario)Session["usuario"];

                    FavoritoNegocio negocio = new FavoritoNegocio();

                    if (negocio.existeFavoritos(user.Id, articulo.Id))
                    {
                        btnAgregarFavoritos.Text = "❤️ En favoritos";
                        btnAgregarFavoritos.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnAgregarFavoritos_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["usuario"] == null)
                {
                    Response.Redirect("Login.aspx");
                    return;
                }

                Usuario user = (Usuario)Session["usuario"];
                int idArticulo = int.Parse((string)Session["idArticulo"]);

                FavoritoNegocio negocio = new FavoritoNegocio();
                Favorito favorito = new Favorito();
                favorito.IdArticulo = idArticulo;
                favorito.IdUser = user.Id;
                if (negocio.agregarFavoritos(favorito) > 0)
                {
                    btnAgregarFavoritos.Text = "❤️ En favoritos";
                    btnAgregarFavoritos.Enabled = false;
                }


                btnAgregarFavoritos.Text = "❤️ En favoritos";
                btnAgregarFavoritos.Enabled = false;
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
    }
}