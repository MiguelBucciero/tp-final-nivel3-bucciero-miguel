using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPFinalNivel3BuccieroMiguel
{
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["usuario"] == null)
                {
                    Response.Redirect("Login.aspx");
                    return;
                }
                cargarDatos();
                habilitarEdicion(false);
            }
        }
        private void cargarDatos()
        {
            Usuario user = (Usuario)Session["usuario"];

            txtNombre.Text = user.Nombre;
            txtApellido.Text = user.Apellido;
            txtEmail.Text = user.Email;

            txtPassword.Text = "";

            imgPerfil.ImageUrl = !string.IsNullOrEmpty(user.UrlImagen)
                ? user.UrlImagen
                : "https://img.freepik.com/premium-vector/vector-flat-illustration-grayscale-avatar-user-profile-person-icon-gender-neutral-silhouette-profile-picture-suitable-social-media-profiles-icons-screensavers-as-templatex9xa_719432-2201.jpg?semt=ais_incoming&w=740&q=80";
        }
        private void habilitarEdicion(bool estado)
        {
            txtNombre.Enabled = estado;
            txtApellido.Enabled = estado;
            txtPassword.Enabled = estado;
            txtEmail.Enabled = false;

            btnGuardar.Visible = estado;
            btnEditar.Visible = !estado;
            fuImagen.Visible = estado;
            lblImagen.Visible = estado;
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            habilitarEdicion(true);
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                txtNombre.CssClass = "form-control";
                txtApellido.CssClass = "form-control";
                txtPassword.CssClass = "form-control";

                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    lblMensaje.Text = "Debe completar el nombre.";
                    lblMensaje.CssClass = "text-danger mt-3 d-block text-center fw-bold";

                    txtNombre.CssClass = "form-control is-invalid";
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtApellido.Text))
                {
                    lblMensaje.Text = "Debe completar el apellido.";
                    lblMensaje.CssClass = "text-danger mt-3 d-block text-center fw-bold";

                    txtApellido.CssClass = "form-control is-invalid";
                    return;
                }
           
                string extension = Path.GetExtension(fuImagen.FileName).ToLower();
                if (fuImagen.HasFile && extension != ".jpg" && extension != ".png" && extension != ".jpeg")
                {
                    lblMensaje.Text = "Solo se permiten imágenes (.jpg, .png, .jpeg)";
                    lblMensaje.CssClass = "text-danger mt-3 d-block text-center fw-bold";
                    return;
                }

                Usuario user = (Usuario)Session["usuario"];
                string rutaImagen = user.UrlImagen;
                if (fuImagen.HasFile)
                {
                    string carpeta = Server.MapPath("~/Imagenes/");
            
                    string nombreArchivo = Path.GetFileName(fuImagen.FileName);
                    string rutaCompleta = Path.Combine(carpeta, nombreArchivo);
                    fuImagen.SaveAs(rutaCompleta);
                    rutaImagen = "~/Imagenes/" + nombreArchivo;
                }

                user.Nombre = txtNombre.Text.Trim();
                user.Apellido = txtApellido.Text.Trim();
                user.UrlImagen = rutaImagen;

                if (!string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    user.Pass = txtPassword.Text.Trim();
                }

                UsuarioNegocio negocio = new UsuarioNegocio();

                if (negocio.ModificarUsuario(user) > 0)
                {
                    Session["usuario"] = user;
                    cargarDatos();
                    lblMensaje.Text = "Datos actualizados correctamente";
                    lblMensaje.CssClass = "text-success mt-3 d-block text-center fw-bold";

                    habilitarEdicion(false);
                }
                else
                {
                    lblMensaje.Text = "No se pudieron actualizar los datos";
                    lblMensaje.CssClass = "text-danger mt-3 d-block text-center fw-bold";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error: " + ex.Message;
                lblMensaje.CssClass = "text-danger mt-3 d-block text-center fw-bold";
            }
        }
    }
}