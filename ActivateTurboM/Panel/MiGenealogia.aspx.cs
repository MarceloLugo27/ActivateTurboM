using ActivateTurboM.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ActivateTurboM.Panel
{
    public partial class MiGenealogia : System.Web.UI.Page
    {
        DataSet dsDDL1 = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["IDU"] == null)
                {
                    Response.Redirect("/Ingreso.aspx", true);
                }

                Label lblIDUsuario = this.Master.FindControl("lblIDUsuario") as Label;
                lblIDUsuario.Text = (string)Session["IDU"];
                dsDDL1 = Nodo.SelectNodoPadreDDL(int.Parse(lblIDUsuario.Text));
            }
        }

    }
}