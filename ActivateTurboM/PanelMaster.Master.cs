using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ActivateTurboM
{
    public partial class PanelMaster : System.Web.UI.MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }


        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            lblIDUsuario.Text = "";
            lblEstadoUsuario.Text = "";
            Session["IDU"] = null;
            Response.Redirect("/Ingreso.aspx", true);
        }

        protected void btnInicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inicio.aspx", true);
        }

        protected void btnPerfil_Click(object sender, EventArgs e)
        {
            Response.Redirect("Perfil.aspx", true);
        }

        protected void btnGenealogia_Click(object sender, EventArgs e)
        {
            Response.Redirect("Genealogia.aspx", true);
        }

        protected void btnGenealogiaMov_Click(object sender, EventArgs e)
        {
            Response.Redirect("Genealogia.aspx", true);
        }

        protected void btnInicioMov_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inicio.aspx", true);
        }

        protected void btnPerfilMov_Click(object sender, EventArgs e)
        {
            Response.Redirect("Perfil.aspx", true);
        }
    }
}