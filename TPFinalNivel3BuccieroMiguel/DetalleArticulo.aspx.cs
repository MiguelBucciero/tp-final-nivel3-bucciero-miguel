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
                articuloNegocio.cargarArticulo(articulo);
                lblNombre.Text = articulo.Nombre;
                lblDescripcion.Text = articulo.Descripcion;
                lblPrecio.Text = articulo.Precio.ToString("N2");
                lblCodigo.Text = articulo.CodigoArticulo;
                lblMarca.Text = articulo.Marca.Descripcion;
                imgProducto.ImageUrl = articulo.Imagen;
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
            
        }

        protected void btnAgregarFavoritos_Click(object sender, EventArgs e)
        {

        }
    }
}