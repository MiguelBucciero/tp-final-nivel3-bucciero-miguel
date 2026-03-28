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
            try
            {
                if (string.IsNullOrWhiteSpace(txtEmail.Text))
                {
                    lblMensaje.Text = "Debe completar Email.";
                    lblMensaje.CssClass = "text-danger mt-3 d-block text-center fw-bold";
                    txtEmail.CssClass = "form-control is-invalid";
                    txtPassword.CssClass = "form-control";
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    lblMensaje.Text = "Debe completar Contraseña.";
                    lblMensaje.CssClass = "text-danger mt-3 d-block text-center fw-bold";
                    txtPassword.CssClass = "form-control is-invalid";
                    txtEmail.CssClass = "form-control";
                    return;
                }
                Usuario usuario = new Usuario();
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();

                usuario.Email = txtEmail.Text.Trim();
                usuario.Pass = txtPassword.Text.Trim();

                usuario = usuarioNegocio.Login(usuario);

                if (usuario != null)
                {
                    Session.Add("usuario", usuario);
                    Session.Add("esAdmin", usuario.Admin);

                    Response.Redirect("Default.aspx", false);
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