using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPFinalNivel3BuccieroMiguel
{
    public partial class Favoritos : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarFavoritos();
            }
        }
        private void cargarFavoritos()
        {
            try
            {
                if (Session["usuario"] == null)
                {
                    Response.Redirect("Login.aspx", false);
                    return;
                }

                Usuario user = (Usuario)Session["usuario"];

                FavoritoNegocio negocio = new FavoritoNegocio();
                List<Articulo> lista = negocio.listarFavoritos(user.Id);

                repFavoritos.DataSource = lista;
                repFavoritos.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void lnkImagen_Click(object sender, EventArgs e)
        {
            try
            {
                string id = ((LinkButton)sender).CommandArgument;

                Session.Add("idArticulo", id);
                Response.Redirect("DetalleArticulo.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["usuario"] == null)
                {
                    Response.Redirect("Login.aspx");
                    return;
                }

                Usuario user = (Usuario)Session["usuario"];
                Button btn = (Button)sender;

                int idArticulo = int.Parse(btn.CommandArgument);
                FavoritoNegocio negocio = new FavoritoNegocio();
                negocio.eliminarFavoritos(user.Id, idArticulo);

                cargarFavoritos();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
    }
}