using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
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
            lblIDUsuario = this.Master.FindControl("lblIDUsuario") as Label;
            lblIDUsuario.Text = (string)Session["IDU"];

            

            if (!IsPostBack)
            {
                if (Session["IDU"] == null)
                {
                    Response.Redirect("/Ingreso.aspx", true);
                }

                dsEstado = Conexion.SelectEstados();
                ddlEstado.DataSource = dsEstado.Tables[0];
                ddlEstado.DataTextField = "strNombreEstado";
                ddlEstado.DataValueField = "IDEstado";
                ddlEstado.DataBind();
                ddlEstado.Items.Insert(0, new ListItem("Seleccione un estado...", "-1"));

                dsCiudad = Conexion.SelectCiudad(int.Parse(ddlEstado.SelectedValue));
                ddlMunicipio.DataSource = dsCiudad.Tables[0];
                ddlMunicipio.DataTextField = "strNombreCiudad";
                ddlMunicipio.DataValueField = "IDCiudad";
                ddlMunicipio.DataBind();
                lblIDCiudad.Text = ddlMunicipio.SelectedValue;

                CargarDatosPerfil(int.Parse(lblIDUsuario.Text));
            }

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string directoriointerno = Server.MapPath(@"~\uploads\");
            if (String.IsNullOrEmpty(lblIDCiudad.Text))
            {
                lblIDCiudad.Text = "1";
            }
            if (String.IsNullOrEmpty(tbNumeroExterior.Text))
            {
                tbNumeroExterior.Text = "0";
            }
            if (String.IsNullOrEmpty(tbNumeroInterior.Text))
            {
                tbNumeroInterior.Text = "0";
            }
            if (String.IsNullOrEmpty(tbCodigoPostal.Text))
            {
                tbCodigoPostal.Text = "0";
            }

            

            Usuario perfil = new Usuario();
            perfil.StrPassword = tbPassword.Text;
            perfil.IntIDUsuario = int.Parse(lblIDUsuario.Text);
            perfil.IntIDCiudad = int.Parse(lblIDCiudad.Text);
            perfil.StrNombres = tbNombres.Text;
            perfil.StrApellidoPaterno = tbApellidoPaterno.Text;
            perfil.StrApellidoMaterno = tbApellidoMaterno.Text;
            perfil.StrCURP = tbCURP.Text;
            perfil.StrRFC = tbRFC.Text;
            perfil.StrSeguroSocial = tbSeguroSocial.Text;
            perfil.StrEmail = tbEmail.Text;
            perfil.StrTelefono = tbTelefono.Text;
            perfil.StrCelular = tbCelular.Text;
            perfil.StrCalle = tbCalle.Text;
            perfil.IntNumeroInterior = int.Parse(tbNumeroInterior.Text);
            perfil.IntNumeroExterior = int.Parse(tbNumeroExterior.Text);
            perfil.StrColonia = tbColonia.Text;
            perfil.IntCodigoPostal = int.Parse(tbCodigoPostal.Text);
            if (String.IsNullOrEmpty(ddlMunicipio.SelectedValue))
            {
                perfil.IntIDCiudad = 1;
            }
            else
            {
            perfil.IntIDCiudad = int.Parse(ddlMunicipio.SelectedValue);
            }

            perfil.StrDireccionFotoPerfil = "";
            perfil.StrDireccionActaNacimiento = "";
            perfil.StrDireccionCURP = "";
            perfil.StrDireccionComprobanteDomicilio = "";

            //documentación

            if (uploadFotoPerfil.HasFile /*&& String.IsNullOrEmpty(lblDireccionFotoPerfil.Text)*/)
            {
                FTP.SubirArchivoFTP(uploadFotoPerfil, directoriointerno, lblIDUsuario.Text, "FPerfil", out string DireccionFotoPerfil);
                perfil.StrDireccionFotoPerfil = DireccionFotoPerfil;
            }
            if (uploadActaNacimiento.HasFile/* && String.IsNullOrEmpty(lblDireccionActaNac.Text)*/)
            {
                FTP.SubirArchivoFTP(uploadActaNacimiento, directoriointerno, lblIDUsuario.Text, "ActaNac", out string DireccionActaNacimiento);
                perfil.StrDireccionActaNacimiento = DireccionActaNacimiento;
            }
            if (uploadCURP.HasFile/* && String.IsNullOrEmpty(lblDireccionCURP.Text)*/)
            {
                FTP.SubirArchivoFTP(uploadCURP, directoriointerno, lblIDUsuario.Text, "CURP", out string DireccionCURP);
                perfil.StrDireccionCURP = DireccionCURP;
            }
            if (uploadComprobanteDom.HasFile/* && String.IsNullOrEmpty(lblComprobanteDom.Text)*/)
            {
                FTP.SubirArchivoFTP(uploadComprobanteDom, directoriointerno, lblIDUsuario.Text, "CompDom", out string DireccionComprobanteDom);
                perfil.StrDireccionComprobanteDomicilio = DireccionComprobanteDom;
            }

            DataSet response = new DataSet();
            
            response = Usuario.UpdatePerfilUsuario(perfil);

            string MensajeError = response.Tables[0].Rows[0]["ErrorMessage"].ToString();
            if (String.IsNullOrEmpty(MensajeError))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('" + MensajeError + "');", true);
                Response.Redirect("/Panel/Perfil.aspx", true);
            }

            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('"+ MensajeError + "');", true);
            }


        }

        protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblIDEstado.Text = ddlEstado.SelectedValue;
            lblIDCiudad.Text = "";
            ddlMunicipio.DataSource = null;
            ddlMunicipio.DataBind();

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


        protected void CargarDatosPerfil(int IDUsuario)
        {
            DataSet dsPerfil = new DataSet();
            dsCiudad = Usuario.SelectDatosPerfilUsuario(IDUsuario);
            ddlEstado.SelectedValue = dsCiudad.Tables[0].Rows[0]["IDEstado"].ToString();
            lblIDEstado.Text = ddlEstado.SelectedValue;
            ddlMunicipio.SelectedValue = dsCiudad.Tables[0].Rows[0]["IDCiudad"].ToString();
            lblIDCiudad.Text = ddlMunicipio.SelectedValue;
            tbUsername.Text = dsCiudad.Tables[0].Rows[0]["strUsername"].ToString();
            tbPassword.Text = dsCiudad.Tables[0].Rows[0]["strPassword"].ToString();
            tbNombres.Text = dsCiudad.Tables[0].Rows[0]["strNombre"].ToString();
            tbApellidoPaterno.Text = dsCiudad.Tables[0].Rows[0]["strApellidoPaterno"].ToString();
            tbApellidoMaterno.Text = dsCiudad.Tables[0].Rows[0]["strApellidoMaterno"].ToString();
            tbEmail.Text = dsCiudad.Tables[0].Rows[0]["strEmail"].ToString();
            tbTelefono.Text = dsCiudad.Tables[0].Rows[0]["intTelefono"].ToString();
            tbCelular.Text = dsCiudad.Tables[0].Rows[0]["strCelular"].ToString();
            tbRFC.Text = dsCiudad.Tables[0].Rows[0]["strRFC"].ToString();
            tbCURP.Text = dsCiudad.Tables[0].Rows[0]["strCURP"].ToString();
            tbSeguroSocial.Text = dsCiudad.Tables[0].Rows[0]["strSeguroSocial"].ToString();
            tbCalle.Text = dsCiudad.Tables[0].Rows[0]["strCalle"].ToString();
            tbNumeroExterior.Text = dsCiudad.Tables[0].Rows[0]["intNumeroExterior"].ToString();
            tbNumeroInterior.Text = dsCiudad.Tables[0].Rows[0]["intNumeroInterior"].ToString();
            tbColonia.Text = dsCiudad.Tables[0].Rows[0]["strColonia"].ToString();
            tbCodigoPostal.Text = dsCiudad.Tables[0].Rows[0]["intCodigoPostal"].ToString();
            
            if (!String.IsNullOrEmpty(dsCiudad.Tables[0].Rows[0]["strDireccionFotoPerfil"].ToString()))
            {
                imgFotoPerfil.ImageUrl = dsCiudad.Tables[0].Rows[0]["strDireccionFotoPerfil"].ToString();
                lblDireccionFotoPerfil.Text = imgFotoPerfil.ImageUrl;
            }

            if (!String.IsNullOrEmpty(dsCiudad.Tables[0].Rows[0]["strDireccionCURP"].ToString()))
            {
                imgCURP.ImageUrl = dsCiudad.Tables[0].Rows[0]["strDireccionCURP"].ToString();
                lblDireccionCURP.Text = imgCURP.ImageUrl;
            }

            if (!String.IsNullOrEmpty(dsCiudad.Tables[0].Rows[0]["strDireccionActaNac"].ToString()))
            {
                imgActaNacimiento.ImageUrl = dsCiudad.Tables[0].Rows[0]["strDireccionActaNac"].ToString();
                lblDireccionActaNac.Text = imgActaNacimiento.ImageUrl;
            }

            if (!String.IsNullOrEmpty(dsCiudad.Tables[0].Rows[0]["strDireccionDomicilio"].ToString()))
            {
                imgComprobanteDom.ImageUrl = dsCiudad.Tables[0].Rows[0]["strDireccionDomicilio"].ToString();
                lblComprobanteDom.Text = imgComprobanteDom.ImageUrl;
            }
        }
    }
}