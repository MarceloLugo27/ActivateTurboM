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
    public partial class Genealogia : System.Web.UI.Page
    {
        DataSet dsDDL1 = new DataSet();
        DataSet dsDDL2 = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                if (Session["IDU"] == null)
                {
                    Response.Redirect("/Ingreso.aspx", true);
                }

                divEstadoDGV.Visible = false;
                divEstadoHijos.Visible = false;
                Label lblIDUsuario = this.Master.FindControl("lblIDUsuario") as Label;
                lblIDUsuario.Text = (string)Session["IDU"];

                dsDDL1 = Nodo.SelectNodoPadreDDL(int.Parse(lblIDUsuario.Text));
                dsDDL2 = Nodo.SelectNodoPadreDDL(int.Parse(lblIDUsuario.Text));

                ddlAscendencia.DataSource = dsDDL1.Tables[0];
                ddlAscendencia.DataTextField = "strNumeroReferencia";
                ddlAscendencia.DataValueField = "IDNodoPadre";
                ddlAscendencia.DataBind();
                ddlAscendencia.Items.Insert(0, new ListItem("Seleccione su ticket...", "-1"));

                ddlMisVentas.DataSource = dsDDL2.Tables[0];
                ddlMisVentas.DataTextField = "strNumeroReferencia";
                ddlMisVentas.DataValueField = "IDNodo";
                ddlMisVentas.DataBind();
                ddlMisVentas.Items.Insert(0, new ListItem("Seleccione su ticket...", "-1"));
            }
        }

        protected void ddlAscendencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblDDL1.Text = ddlAscendencia.SelectedValue;
            DataSet dsAscendencia = new DataSet();
            dsAscendencia = Nodo.SelectInfoNodoPadre(int.Parse(lblDDL1.Text));
            dgvAscendencia.DataSource = dsAscendencia.Tables[0];
            dgvAscendencia.DataBind();

        }

        protected void ddlMisVentas_SelectedIndexChanged(object sender, EventArgs e)
        {
            divEstadoDGV.Visible = false;
            lblDDL2.Text = ddlMisVentas.SelectedValue;
            if (ddlMisVentas.SelectedValue == "-1")
            {
                divEstadoDGV.Visible = false;
                dgvVendidos.DataSource = null;
                dgvVendidos.DataBind();
            }
            DataSet dsMisVentas = new DataSet();
            dsMisVentas = Nodo.SelectInfoNodoVendido(int.Parse(lblDDL2.Text));
            if (dsMisVentas.Tables[0].Rows.Count == 0)
            {
                divEstadoDGV.Visible = true;
                lblEstadoDGV.Text = "Actualmente no tiene ningún ticket vendido a algún socio con este número de referencia.";
                dgvVendidos.DataSource = null;
                dgvVendidos.DataBind();
                if (ddlMisVentas.SelectedValue == "-1")
                {
                    divEstadoDGV.Visible = false;
                    dgvVendidos.DataSource = null;
                    dgvVendidos.DataBind();
                }
            }
            else
            {
                dgvVendidos.DataSource = dsMisVentas.Tables[0];
                dgvVendidos.DataBind();
                divEstadoDGV.Visible = true;
                lblEstadoDGV.Text = String.Format("Actualmente cuenta con {0} tickets vendidos de 4 con este número de referencia ({0}/4).", dsMisVentas.Tables[0].Rows.Count);
            }
        }

        protected void btnCargarDescendientes_Click(object sender, EventArgs e)
        {
            DataSet dgv3 = new DataSet();
            Label lblIDUsuario = this.Master.FindControl("lblIDUsuario") as Label;
            lblIDUsuario.Text = (string)Session["IDU"];
            dgv3 = Nodo.SelectInfoNodoDescendiente(int.Parse(lblIDUsuario.Text));
            if (dgv3.Tables[0].Rows.Count == 0)
            {
                divEstadoHijos.Visible = true;
                lblEstadoDGV.Text = "Actualmente no cuenta con descendientes en ninguno de sus números de referencia.";
                dgvDescendencia.DataSource = null;
                dgvDescendencia.DataBind();
            }
            dgvDescendencia.DataSource = dgv3.Tables[0];
            dgvDescendencia.DataBind();
        }
    }
}