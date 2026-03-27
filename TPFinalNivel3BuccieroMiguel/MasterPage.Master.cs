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