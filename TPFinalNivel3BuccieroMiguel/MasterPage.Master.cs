using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPFinalNivel3BuccieroMiguel
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] != null)
            {
                Usuario user = (Usuario)Session["usuario"];

                pnlLogin.Visible = false;
                pnlFavoritosTop.Visible = true;
                pnlLogout.Visible = true;
                pnlPerfilTop.Visible = true;
                lblUsuario.Text = user.Nombre;
                string imagenDefault = "~/Imagenes/imPerfil.jpg";

                if (!string.IsNullOrEmpty(user.UrlImagen))
                {
                    string rutaFisica = Server.MapPath(user.UrlImagen);
                    if (System.IO.File.Exists(rutaFisica))
                    {
                        imgPerfilNav.ImageUrl = ResolveUrl(user.UrlImagen);
                    }
                    else
                    {
                        imgPerfilNav.ImageUrl = ResolveUrl(imagenDefault);
                    }
                }
                else
                {
                    imgPerfilNav.ImageUrl = ResolveUrl(imagenDefault);
                }

                if (user.Admin)
                {
                    pnlAdminTop.Visible = true;
                }
            }
            else
            {
                pnlLogin.Visible = true;
                pnlLogout.Visible = false;
                pnlFavoritosTop.Visible = false;
                pnlAdminTop.Visible = false;
                pnlPerfilTop.Visible = false;
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string busqueda = txtBuscar.Text;

            Response.Redirect("Default.aspx?buscar=" + busqueda);
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();

            Response.Redirect("Default.aspx");
        }


    }
}