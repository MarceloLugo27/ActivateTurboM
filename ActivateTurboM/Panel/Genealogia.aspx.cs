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
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet dsDDL1 = new DataSet();
            DataSet dsDDL2 = new DataSet();

            if (!IsPostBack)
            {
                dgvAscendencia.AutoGenerateColumns = false;
                Label lblIDUsuario = this.Master.FindControl("lblIDUsuario") as Label;
                lblIDUsuario.Text = (string)Session["IDU"];
                dsDDL1 = Nodo.SelectNodoPadreDDL(int.Parse(lblIDUsuario.Text));
                dsDDL2 = Nodo.SelectNodoPadreDDL(int.Parse(lblIDUsuario.Text));

                ddlMisTickets1.DataSource = dsDDL1.Tables[0];
                ddlMisTickets1.DataTextField = "strNumeroReferencia";
                ddlMisTickets1.DataValueField = "IDNodoPadre";
                ddlMisTickets1.DataBind();

                ddlMisTickets2.DataSource = dsDDL2.Tables[0];
                ddlMisTickets2.DataTextField = "strNumeroReferencia";
                ddlMisTickets2.DataValueField = "IDNodoPadre";
                ddlMisTickets2.DataBind();

                DataSet dgv3 = new DataSet();
                dgv3 = Nodo.SelectInfoNodoDescendiente(int.Parse(lblIDUsuario.Text));
                dgvDescendencia.DataSource = dgv3.Tables[0];
                dgvDescendencia.DataBind();

                DataSet dgv1 = new DataSet();
                dgv1 = Nodo.SelectInfoNodoPadre(1);
                dgvAscendencia.DataSource = dgv1.Tables[0];
                dgvAscendencia.DataBind();
            }
        }

        protected void ddlMisTickets1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblDDL1.Text = ddlMisTickets1.SelectedValue;
            DataSet dgv1 = new DataSet();
            dgv1 = Nodo.SelectInfoNodoPadre(int.Parse(lblDDL1.Text));
            dgvAscendencia.DataSource = dgv1.Tables[0];
            dgvAscendencia.DataBind();
        }

        protected void ddlMisTickets2_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblDDL2.Text = ddlMisTickets2.SelectedValue;
            DataSet dgv2 = new DataSet();
            dgv2 = Nodo.SelectInfoNodoVendido(int.Parse(lblDDL2.Text));
            dgvMisVentas.DataSource = dgv2.Tables[0];
            dgvMisVentas.DataBind();
        }
    }
}