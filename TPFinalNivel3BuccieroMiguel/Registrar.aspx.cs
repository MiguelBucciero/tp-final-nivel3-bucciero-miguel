using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPFinalNivel3BuccieroMiguel
{
    public partial class Registrar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            try
            {
                lblMensaje.Text = "";
                if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApellido.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtPassword.Text) || string.IsNullOrWhiteSpace(txtPassword2.Text))
                {
                    lblMensaje.Text = "Todos los campos son obligatorios";
                    lblMensaje.CssClass = "text-danger mt-3 d-block text-center fw-bold";
                    return;
                }

                if (txtPassword.Text != txtPassword2.Text)
                {
                    lblMensaje.Text = "Las contraseñas no coinciden";
                    lblMensaje.CssClass = "text-danger mt-3 d-block text-center fw-bold";
                    return;
                }

                Usuario nuevo = new Usuario();
                nuevo.Nombre = txtNombre.Text.Trim();
                nuevo.Apellido = txtApellido.Text.Trim();
                nuevo.Email = txtEmail.Text.Trim();
                nuevo.Pass = txtPassword.Text.Trim();

                UsuarioNegocio negocio = new UsuarioNegocio();
                if (negocio.existeEmail(nuevo.Email))
                {
                    lblMensaje.Text = "El email ya está registrado";
                    lblMensaje.CssClass = "text-danger mt-3 d-block text-center fw-bold";
                    return;
                }


                if (negocio.agregarUsurio(nuevo) > 0)
                {
                    Session.Add("usuario", nuevo);
                    Session.Add("esAdmin", false);
                    lblMensaje.Text = "Usurio registrado correctamente!";
                    lblMensaje.CssClass = "text-success mt-3 d-block text-center fw-bold";
                    Response.AddHeader("REFRESH", "2;URL=Default.aspx");
                }
                else
                {
                    lblMensaje.Text = "No se pudo registrar el usuario";
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