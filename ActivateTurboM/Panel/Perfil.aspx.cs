using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ActivateTurboM.Framework;

namespace ActivateTurboM.Panel
{
    public partial class Perfil : System.Web.UI.Page
    {
        Label lblIDUsuario;
        DataSet dsCiudad = new DataSet();
        DataSet dsEstado = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["IDU"] == null)
                {
                    Response.Redirect("/Ingreso.aspx", true);
                }

                lblIDUsuario = this.Master.FindControl("lblIDUsuario") as Label;

                dsEstado = Conexion.SelectEstados();
                ddlEstado.DataSource = dsEstado.Tables[0];
                ddlEstado.DataTextField = "strNombreEstado";
                ddlEstado.DataValueField = "IDEstado";
                ddlEstado.DataBind();
                ddlEstado.Items.Insert(0, new ListItem("Seleccione un estado...", "-1"));
            }

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Usuario perfil = new Usuario();
            perfil.StrNombres = tbNombres.Text;
            perfil.StrApellidoPaterno = tbApellidoPaterno.Text;
            //perfil.
        }

        protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblIDEstado.Text = ddlEstado.SelectedValue;
            //lblIDCiudad.Text = "";
            //ddlMunicipio.DataSource = null;
            //ddlMunicipio.DataBind();

            dsCiudad = Conexion.SelectCiudad(int.Parse(ddlEstado.SelectedValue));
            ddlMunicipio.DataSource = dsCiudad.Tables[0];
            ddlMunicipio.DataTextField = "strNombreCiudad";
            ddlMunicipio.DataValueField = "IDCiudad";
            ddlMunicipio.DataBind();
            

        }

        protected void ddlMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblIDCiudad.Text = ddlMunicipio.SelectedValue;
        }
    }
}