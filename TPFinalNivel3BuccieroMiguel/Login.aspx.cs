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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            bool esAdmin = true;
            Usuario usuario = new Usuario();
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            try
            {
                usuario.Email = txtEmail.Text.Trim();
                usuario.Pass = txtPassword.Text.Trim();
                if (usuarioNegocio.Login(usuario))
                {
                    if (usuario.Admin)
                    {
                        esAdmin = true;
                        Session.Add("usuario", usuario);
                        Session.Add("esAdmin", esAdmin);
                        Response.Redirect("Default.aspx", false);
                    }
                    else
                    {
                        esAdmin = false;
                        Session.Add("usuario", usuario);
                        Session.Add("esAdmin", esAdmin);
                        Response.Redirect("Default.aspx", false);
                    }
                }
                else
                {
                    lblMensaje.Text = "Usuario o contraseña incorrectos.";
                    lblMensaje.CssClass = "text-danger mt-3 d-block text-center fw-bold";
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
    }
}