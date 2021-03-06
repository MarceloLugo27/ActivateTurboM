﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ActivateTurboM.Framework;

namespace ActivateTurboM
{
    public partial class Ingreso : System.Web.UI.Page
    {
        DataSet dsLogin = new DataSet();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                System.Web.UI.HtmlControls.HtmlGenericControl navbarUser = this.Master.FindControl("navbarUser") as System.Web.UI.HtmlControls.HtmlGenericControl;
                LinkButton btnModoAdmin = this.Master.FindControl("btnModoAdmin") as LinkButton;
                System.Web.UI.HtmlControls.HtmlGenericControl divModoAdminSidebar = this.Master.FindControl("divModoAdminSidebar") as System.Web.UI.HtmlControls.HtmlGenericControl;
                navbarUser.Visible = false;
                btnModoAdmin.Visible = false;
                divModoAdminSidebar.Visible = false;
            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            dsLogin = Conexion.SysLogin(tbUsername.Text, tbPassword.Text);
            
            if (dsLogin.Tables[0].Rows.Count > 0)
            {
                divMensajeError.Visible = false;
                
                Session["IDU"] = dsLogin.Tables[0].Rows[0]["IDUsuario"].ToString();
                Session["BTU"] = dsLogin.Tables[0].Rows[0]["bitTipoUsuario"].ToString();
                
                Response.Redirect("Panel/Inicio.aspx");
            }
            else
            {
                divMensajeError.Visible = true;
                lblMensajeError.Text = "<b>Nombre de usuario y/contraseña inválidos.</b>";
                tbUsername.Text = "";
                tbPassword.Text = "";
            }
        }

        protected void btnCrearCuenta_Click(object sender, EventArgs e)
        {
                Response.Redirect("/RegistroPreliminar.aspx");
        }
    }
}