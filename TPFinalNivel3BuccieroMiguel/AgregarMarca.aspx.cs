using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;

namespace TPFinalNivel3BuccieroMiguel
{
    public partial class AgregarMarca : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["EsAdmin"] == null || (bool)Session["EsAdmin"] == false)
            {
                Session.Add("error", "No tiene los permisos necesarios para acceder a esta página.");
                Response.Redirect("Error.aspx");
            }
            if (!IsPostBack)
            {
                cargarProximoId();
            }

        }

        private void cargarProximoId()
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            Marca marca = new Marca();
            marcaNegocio.proximoId(marca);
            txtProximoID.Text = marca.Id.ToString();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            Marca marca = new Marca();

            if (string.IsNullOrWhiteSpace(txtNombreMarca.Text))
            {
                lblMensaje.Text = "Debe completar el nombre.";
                lblMensaje.CssClass = "text-danger mt-3 d-block text-center fw-bold";

                txtNombreMarca.CssClass = "form-control is-invalid";
                return;
            }
            marca.Id = int.Parse (txtProximoID.Text);
            marca.Descripcion = txtNombreMarca.Text.Trim();
            if (marcaNegocio.agregarMarca(marca) > 0)
            {
                lblMensaje.Text = "Artículo agregado correctamente.";
                lblMensaje.CssClass = "text-success mt-3 d-block text-center fw-bold";
            }
            else
            {
                lblMensaje.Text = "No se pudo agregar el artículo.";
                lblMensaje.CssClass = "text-danger mt-3 d-block text-center fw-bold";
            }
            limpiarCampo();
            cargarProximoId();
        }
        private void limpiarCampo()
        {
            txtNombreMarca.Text = "";
        }
    }
}