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
                ddlNodosUsuario.DataSource = dsDDL1.Tables[0];
                ddlNodosUsuario.DataTextField = "strNumeroReferencia";
                ddlNodosUsuario.DataValueField = "IDNodoPadre";
                ddlNodosUsuario.DataBind();
                ddlNodosUsuario.Items.Insert(0, new ListItem("Seleccione su ticket...", "-1"));
            }
        }

        protected void ddlNodosUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region Codigo comentado referencia

            //    dgvYo.DataSource = null;
            //    dgvYo.DataBind();
            //    dgvHijos.Columns[2].Visible = false;

            //    lblTicket.Text = ddlNodosUsuario.SelectedValue;
            //    lblNumeroReferenciaTicket.Text = ddlNodosUsuario.SelectedItem.Text;
            //    DataSet dsPadre = new DataSet();
            //    dsPadre = Nodo.SelectInfoNodoPadre(int.Parse(lblTicket.Text));
            //    dgvPadre.DataSource = dsPadre.Tables[0];
            //    dgvPadre.DataBind();


            //    DataSet dsMiNodo = new DataSet();
            //    dsMiNodo = Nodo.BuscarNodoPorReferencia(lblNumeroReferenciaTicket.Text);
            //    dgvYo.DataSource = dsMiNodo.Tables[0];
            //    dgvYo.DataBind();


            //    divEstadoDGV.Visible = false;

            //    if (ddlNodosUsuario.SelectedValue == "-1")
            //    {
            //        divEstadoDGV.Visible = false;
            //        dgvHijos.DataSource = null;
            //        dgvHijos.DataBind();
            //        dgvHijos.Columns[2].Visible = false;
            //    }


            //    DataSet dsMisHijos = new DataSet();
            //    dsMisHijos = Nodo.SelectInfoNodoVendido(int.Parse(lblTicket.Text));
            //    if (dsMisHijos.Tables[0].Rows.Count == 0)
            //    {
            //        divEstadoDGV.Visible = true;
            //        lblEstadoDGV.Text = "Actualmente no tiene ningún ticket vendido a algún socio con este número de referencia.";
            //        dgvHijos.DataSource = null;
            //        dgvHijos.DataBind();
            //        dgvHijos.Columns[2].Visible = false;

            //        if (ddlNodosUsuario.SelectedValue == "-1")
            //        {
            //            divEstadoDGV.Visible = false;
            //            dgvHijos.DataSource = null;
            //            dgvHijos.DataBind();
            //            dgvHijos.Columns[2].Visible = false;
            //        }
            //    }
            //    else
            //    {
            //        dgvHijos.DataSource = dsMisHijos.Tables[0];
            //        dgvHijos.DataBind();
            //        dgvHijos.Columns[2].Visible = false;
            //        divEstadoDGV.Visible = true;
            //        lblEstadoDGV.Text = String.Format("Actualmente cuenta con {0} tickets vendidos de 4 con este número de referencia ({0}/4).", dsMisHijos.Tables[0].Rows.Count);
            //    }

            //}

            //protected void dgvHijos_RowCommand(object sender, GridViewCommandEventArgs e)
            //{
            //    if (e.CommandName == "MoreInfo")
            //    {
            //        dgvNietos.DataSource = null;
            //        dgvNietos.DataBind();
            //        DataSet dsNietos = new DataSet();
            //        int fila = int.Parse(e.CommandArgument.ToString());

            //        String IDNodo = dgvHijos.Rows[fila].Cells[2].Text;

            //        dsNietos = Nodo.SelectInfoNodoDescendiente2(int.Parse(IDNodo));

            //        dgvNietos.DataSource = dsNietos.Tables[0];
            //        dgvNietos.DataBind();
            //        dgvNietos.Columns[2].Visible = false;
            //    }
            #endregion

            lblTicket.Text = ddlNodosUsuario.SelectedValue;
            lblNumeroReferenciaTicket.Text = ddlNodosUsuario.Items[ddlNodosUsuario.SelectedIndex].ToString();
            DataSet dsPadre = new DataSet();
            dsPadre = Nodo.SelectInfoNodoPadre(int.Parse(lblTicket.Text));
            dgvPadre.DataSource = dsPadre.Tables[0];
            dgvPadre.DataBind();

            DataSet dsMiNodo = new DataSet();
            dsMiNodo = Nodo.BuscarNodoPorReferencia(lblNumeroReferenciaTicket.Text);
            dgvYo.DataSource = dsMiNodo.Tables[0];
            dgvYo.DataBind();

        }
        protected void dgvHijos_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void dgvNietos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "MoreInfo")
            {
                dgvBisnietos.DataSource = null;
                dgvBisnietos.DataBind();
                DataSet dsBisnietos = new DataSet();
                int fila = int.Parse(e.CommandArgument.ToString());

                String IDNodo = dgvNietos.Rows[fila].Cells[2].Text;

                dsBisnietos = Nodo.SelectInfoNodoDescendiente2(int.Parse(IDNodo));

                dgvBisnietos.DataSource = dsBisnietos.Tables[0];
                dgvBisnietos.DataBind();
                dgvBisnietos.Columns[2].Visible = false;
            }
        }

        protected void dgvBisnietos_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

    }
}