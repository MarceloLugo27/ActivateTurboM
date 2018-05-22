using ActivateTurboM.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ActivateTurboM
{
    public partial class RegistroPreliminar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                System.Web.UI.HtmlControls.HtmlGenericControl navbarUser = this.Master.FindControl("navbarUser") as System.Web.UI.HtmlControls.HtmlGenericControl;
                navbarUser.Visible = false;
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            DataTable dsResponse = new DataTable();

            Usuario nuevoUsuario = new Usuario();
            nuevoUsuario.StrNombres = tbNombres.Text;
            nuevoUsuario.StrApellidoPaterno = tbApellidoPaterno.Text;
            nuevoUsuario.StrApellidoMaterno = tbApellidoMaterno.Text;
            nuevoUsuario.StrTelefono = tbTelefono.Text;
            nuevoUsuario.StrCelular = tbCelular.Text;
            nuevoUsuario.StrEmail = tbEmail.Text;
            nuevoUsuario.StrNumeroReferencia = "";
            nuevoUsuario.IntTipoContrato = 1;
            String strMensajeSQL;

            dsResponse = Usuario.InsertarUsuarioTemporal(nuevoUsuario).Tables[0];
            strMensajeSQL = dsResponse.Rows[0]["ErrorMessage"].ToString();

            if (String.IsNullOrEmpty(strMensajeSQL))
            {
                tbNombres.Text = "";
                tbApellidoPaterno.Text = "";
                tbApellidoMaterno.Text = "";
                tbTelefono.Text = "";
                tbCelular.Text = "";
                tbEmail.Text = "";
                Response.Redirect("~/Exito.aspx");
            }

            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + strMensajeSQL + "');", true);
                Response.Redirect("~/Default.aspx");
            }
        }
    }
}