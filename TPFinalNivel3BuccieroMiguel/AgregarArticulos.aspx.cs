using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPFinalNivel3BuccieroMiguel
{
    public partial class AgregarArticulos : System.Web.UI.Page
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
                cargarCombos();
                if (Request.QueryString["id"] != null)
                {
                    int id = int.Parse(Request.QueryString["id"]);
                    cargarArticulo(id);

                    btnGuardar.Text = "Actualizar";
                    titulo.InnerText = "Modificar Artículo";
                }
            }
        }
        
        private void cargarCombos()
        {
            try
            {
                MarcaNegocio marcaNegocio = new MarcaNegocio();
                ddlMarca.DataSource = marcaNegocio.listar();
                ddlMarca.DataTextField = "Descripcion";
                ddlMarca.DataValueField = "Id";
                ddlMarca.DataBind();

                CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                ddlCategoria.DataSource = categoriaNegocio.listar();
                ddlCategoria.DataTextField = "Descripcion";
                ddlCategoria.DataValueField = "Id";
                ddlCategoria.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
        private void cargarArticulo(int id)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            Articulo articulo = negocio.cargarArticulo(new Articulo { Id = id });

            txtCodigo.Text = articulo.CodigoArticulo;
            txtNombre.Text = articulo.Nombre;
            txtDescripcion.Text = articulo.Descripcion;
            txtPrecio.Text = articulo.Precio.ToString(CultureInfo.InvariantCulture);
            txtImagen.Text = articulo.Imagen;

            ddlMarca.SelectedValue = articulo.Marca.Id.ToString();
            ddlCategoria.SelectedValue = articulo.Categoria.Id.ToString();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                txtCodigo.CssClass = "form-control";
                txtNombre.CssClass = "form-control";
                txtPrecio.CssClass = "form-control";
                txtDescripcion.CssClass = "form-control";
                txtImagen.CssClass = "form-control";

                if (string.IsNullOrWhiteSpace(txtCodigo.Text))
                {
                    lblMensaje.Text = "Debe completar el código.";
                    lblMensaje.CssClass = "text-danger mt-3 d-block text-center fw-bold";

                    txtCodigo.CssClass = "form-control is-invalid";
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    lblMensaje.Text = "Debe completar el nombre.";
                    lblMensaje.CssClass = "text-danger mt-3 d-block text-center fw-bold";

                    txtNombre.CssClass = "form-control is-invalid";
                    return;
                }


                decimal precio;

                if (string.IsNullOrWhiteSpace(txtPrecio.Text))
                {
                    lblMensaje.Text = "Debe completar el precio.";
                    lblMensaje.CssClass = "text-danger mt-3 d-block text-center fw-bold";

                    txtPrecio.CssClass = "form-control is-invalid";
                    return;
                }

                if (!decimal.TryParse(txtPrecio.Text.Trim(), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out precio))
                {
                    lblMensaje.Text = "El precio debe ser un número válido.";
                    lblMensaje.CssClass = "text-danger mt-3 d-block text-center fw-bold";

                    txtPrecio.CssClass = "form-control is-invalid";
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
                {
                    lblMensaje.Text = "Debe completar la descripción.";
                    lblMensaje.CssClass = "text-danger mt-3 d-block text-center fw-bold";

                    txtDescripcion.CssClass = "form-control is-invalid";
                    return;
                }

                Articulo nuevo = new Articulo();
                if (Request.QueryString["id"] != null)
                {
                    nuevo.Id = int.Parse(Request.QueryString["id"]);
                }
                nuevo.CodigoArticulo = txtCodigo.Text.Trim();
                nuevo.Nombre = txtNombre.Text.Trim();
                nuevo.Descripcion = txtDescripcion.Text.Trim();

                nuevo.Marca = new Marca();
                nuevo.Marca.Id = int.Parse(ddlMarca.SelectedValue);

                nuevo.Categoria = new Categoria();
                nuevo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);

                nuevo.Precio = precio;

                nuevo.Imagen = txtImagen.Text.Trim();

                ArticuloNegocio negocio = new ArticuloNegocio();
                if (Request.QueryString["id"] != null)
                {
                    if (negocio.modificar(nuevo) > 0)
                    {
                        lblMensaje.Text = "Artículo modificado correctamente.";
                        lblMensaje.CssClass = "text-success mt-3 d-block text-center fw-bold";
                    }
                    else
                    {
                        lblMensaje.Text = "No se pudo agregar el artículo.";
                        lblMensaje.CssClass = "text-danger mt-3 d-block text-center fw-bold";
                    }
                }
                else
                {
                    
                    if (negocio.agregar(nuevo) > 0)
                    {
                        lblMensaje.Text = "Artículo agregado correctamente.";
                        lblMensaje.CssClass = "text-success mt-3 d-block text-center fw-bold";
                    }
                    else
                    {
                        lblMensaje.Text = "No se pudo agregar el artículo.";
                        lblMensaje.CssClass = "text-danger mt-3 d-block text-center fw-bold";
                    }
                }
                limpiarCampos();
                Session.Remove("listaArticulo");
                Response.AddHeader("REFRESH", "1;URL=ListadoArticulos.aspx");

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
        protected void limpiarCampos()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "";
            txtImagen.Text = "";
            ddlMarca.SelectedIndex = 0;
            ddlCategoria.SelectedIndex = 0;
        }
    }
}