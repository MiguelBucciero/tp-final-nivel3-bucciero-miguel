using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace TPFinalNivel3BuccieroMiguel
{
    public partial class LIstadoArticulos : System.Web.UI.Page
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
                cargarArticulos();
                cargarFiltros();
            }

        }
        private void cargarArticulos()
        {
            try
            {
                ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                List<Articulo> listaArticulo;

                if (Session["listaArticulo"] != null)
                {
                    listaArticulo = (List<Articulo>)Session["listaArticulo"];
                    Session.Add("listaArticulo", listaArticulo);
                }
                else
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    listaArticulo = negocio.listarArticulos();
                    Session.Add("listaArticulo", listaArticulo);
                }
                if (!string.IsNullOrEmpty(txtBusqueda.Text) && txtBusqueda.Text.Length >= 3)
                {
                    string texto = txtBusqueda.Text.ToLower();
                    listaArticulo = listaArticulo.Where(x =>x.Nombre.ToLower().Contains(texto) || (x.Marca != null && x.Marca.Descripcion.ToLower().Contains(texto))).ToList();
                }

                gvListadoArticulos.DataSource = listaArticulo;
                gvListadoArticulos.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }
        private void cargarFiltros()
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            ddlFiltroMarca.DataSource = marcaNegocio.listar();
            ddlFiltroMarca.DataTextField = "Descripcion";
            ddlFiltroMarca.DataValueField = "Id";
            ddlFiltroMarca.DataBind();
            ddlFiltroMarca.Items.Insert(0, new ListItem("Todas", "0"));

            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            ddlFiltroCategoria.DataSource = categoriaNegocio.listar();
            ddlFiltroCategoria.DataTextField = "Descripcion";
            ddlFiltroCategoria.DataValueField = "Id";
            ddlFiltroCategoria.DataBind();
            ddlFiltroCategoria.Items.Insert(0, new ListItem("Todas", "0"));
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarArticulos.aspx");
        }

        protected void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            if (txtBusqueda.Text.Length >= 3 || txtBusqueda.Text.Length == 0)
            {
                cargarArticulos();
            }
        }

        protected void gvListadoArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListadoArticulos.PageIndex = e.NewPageIndex;
            cargarArticulos();
        }

        protected void gvListadoArticulos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Editar")
                {
                    int id = int.Parse(e.CommandArgument.ToString());
                    Response.Redirect("AgregarArticulos.aspx?id=" + id, false);
                }

                if (e.CommandName == "Eliminar")
                {
                    int id = int.Parse(e.CommandArgument.ToString());
                    hfIdEliminar.Value = id.ToString();
                    pnlConfirmar.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnConfirmarEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(hfIdEliminar.Value);

                ArticuloNegocio negocio = new ArticuloNegocio();
                if (negocio.eliminar(id) > 0)
                {
                    lblMensaje.Text = "Artículo eliminado correctamente.";
                    lblMensaje.CssClass = "text-success mt-3 d-block text-center fw-bold";
                    Session.Remove("listaArticulo");
                }
                else
                {
                    lblMensaje.Text = "No se pudo eliminar el artículo.";
                    lblMensaje.CssClass = "text-danger mt-3 d-block text-center fw-bold";
                }
                pnlConfirmar.Visible = false;
                cargarArticulos();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnCancelarEliminar_Click(object sender, EventArgs e)
        {
            pnlConfirmar.Visible = false;
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();

            int idMarca = int.Parse(ddlFiltroMarca.SelectedValue);
            int idCategoria = int.Parse(ddlFiltroCategoria.SelectedValue);

            decimal precioMin = 0;
            decimal precioMax = 0;
            precioMin = string.IsNullOrEmpty(txtPrecioMin.Text) ? 0 : decimal.Parse(txtPrecioMin.Text);
            precioMax = string.IsNullOrEmpty(txtPrecioMax.Text) ? 0 : decimal.Parse(txtPrecioMax.Text);

            List<Articulo> listaArticulo = negocio.filtrar(idMarca, idCategoria, precioMax, precioMin);

            gvListadoArticulos.DataSource = listaArticulo;
            gvListadoArticulos.DataBind();
            limpiarFiltros();
        }
        protected void limpiarFiltros()
        {
            ddlFiltroMarca.SelectedIndex = 0;
            ddlFiltroCategoria.SelectedIndex = 0;
            txtPrecioMin.Text = string.Empty;
            txtPrecioMax.Text = string.Empty;
        }

        protected void btnMostrarFiltros_Click(object sender, EventArgs e)
        {
            pnlFiltros.Visible = !pnlFiltros.Visible;
        }
    }
}