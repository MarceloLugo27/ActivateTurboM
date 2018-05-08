using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ActivateTurboM.Framework;

namespace ActivateTurboM.Panel
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Session["IDU"] == null)
                {
                    Response.Redirect("/Ingreso.aspx", true);
                }

                System.Web.UI.HtmlControls.HtmlGenericControl navbarUser = this.Master.FindControl("navbarUser") as System.Web.UI.HtmlControls.HtmlGenericControl;
                navbarUser.Visible = true;

                Label lblIDUsuario = this.Master.FindControl("lblIDUsuario") as Label;
                Label lblEstadoUsuario = this.Master.FindControl("lblEstadoUsuario") as Label;

                lblIDUsuario.Text = (string)Session["IDU"];

                DataSet dsNombre = new DataSet();
                dsNombre = Usuario.SelectNombreCompletoUsuario(int.Parse(lblIDUsuario.Text));

                if (dsNombre.Tables[0].Rows.Count > 0)
                {
                    string nombreCompleto = dsNombre.Tables[0].Rows[0]["strNombreUsuario"].ToString();
                    lblTarjetaInicial.Text = String.Format("Bienvenido {0}.", nombreCompleto);
                }
            }

        }
    }
}