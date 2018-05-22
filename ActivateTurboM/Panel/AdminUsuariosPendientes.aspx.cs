using ActivateTurboM.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ActivateTurboM.Panel
{
    public partial class AdminUsuariosPendientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSet dsUsuariosTemp = new DataSet();
                dsUsuariosTemp = Usuario.SelectDatosUsuarioTemp();
                dgvUsuariosPendientes.DataSource = dsUsuariosTemp.Tables[0];
                dgvUsuariosPendientes.DataBind();
            }
        }

        protected void dgvUsuariosPendientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int fila = int.Parse(e.CommandArgument.ToString());
            String IDUsuario = dgvUsuariosPendientes.Rows[fila].Cells[2].Text;
            lblIDUsuarioTemp.Text = IDUsuario;
            DataSet dsUsuarioElegido = new DataSet();
            dsUsuarioElegido = Usuario.SelectDatosUsuarioTemp(int.Parse(IDUsuario));

            if (e.CommandName == "Modificar")
            {
                string username = dsUsuarioElegido.Tables[0].Rows[0]["strNombre"].ToString().Substring(0, 1) +
                    dsUsuarioElegido.Tables[0].Rows[0]["strApellidoPaterno"].ToString() +
                    dsUsuarioElegido.Tables[0].Rows[0]["strApellidoMaterno"].ToString().Substring(0, 1) + IDUsuario;
                string usernamenormalizado = username.Normalize(NormalizationForm.FormD);
                tbUsername.Text = usernamenormalizado.ToLower();

                tbPassword.Text = RandomString(6);
                tbNombres.Text = dsUsuarioElegido.Tables[0].Rows[0]["strNombre"].ToString();
                tbApellidoPaterno.Text = dsUsuarioElegido.Tables[0].Rows[0]["strApellidoPaterno"].ToString();
                tbApellidoMaterno.Text = dsUsuarioElegido.Tables[0].Rows[0]["strApellidoMaterno"].ToString();
            }

            if (e.CommandName == "Eliminar")
            {
                Usuario.DeleteIDUsuarioTemp(int.Parse(lblIDUsuarioTemp.Text));
                Response.Redirect("AdminUSuariosPendientes.aspx");
            }
        }

        protected void btnCrearUsuario_Click(object sender, EventArgs e)
        {
            DataSet responseUsuarioCreado = new DataSet();
            Usuario usuario = new Usuario();
            usuario.IntIDUsuario = int.Parse(lblIDUsuarioTemp.Text);
            usuario.StrUsername = tbUsername.Text;
            usuario.StrPassword = tbPassword.Text;
            usuario.StrNumeroReferencia = tbNumeroReferencia.Text;

            responseUsuarioCreado = Usuario.AsignarCuentaUsuario(usuario);




            Response.Redirect("AdminUSuariosPendientes.aspx");
        }

        public string RandomString(int length)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            return finalString;
        }
    }
}