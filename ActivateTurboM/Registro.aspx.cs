using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ActivateTurboM.Framework;

namespace ActivateTurboM
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = "Pre-registro";

            if (!IsPostBack)
            {

            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            DataTable dsResponse = new DataTable();

            Usuario nuevoUsuario = new Usuario();
            nuevoUsuario.StrNombres = tbNombres.Text;
            nuevoUsuario.StrApellidoPaterno = tbApellidoPaterno.Text;
            nuevoUsuario.StrApellidoMaterno = tbApellidoMaterno.Text;
            nuevoUsuario.IntTelefono = int.Parse(tbTelefono.Text);
            nuevoUsuario.StrCelular = tbCelular.Text;
            nuevoUsuario.StrEmail = tbCorreo.Text;
            nuevoUsuario.StrNumeroReferencia = "";
            nuevoUsuario.IntTipoContrato = 1;
            String strMensajeSQL;

            dsResponse = Usuario.InsertarUsuarioTemporal(nuevoUsuario).Tables[0];
            strMensajeSQL = dsResponse.Rows[0]["ErrorMessage"].ToString();

            if (String.IsNullOrEmpty(strMensajeSQL))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "El empleado ha sido actualizado correctamente." + "');", true);
                tbNombres.Text = "";
                tbApellidoPaterno.Text = "";
                tbApellidoMaterno.Text = "";
                tbTelefono.Text = "";
                tbCelular.Text = "";
                tbCorreo.Text = "";
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