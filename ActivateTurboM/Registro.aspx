<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="ActivateTurboM.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col s12 card-panel center-align centered white">
        <div class="row">

            <asp:Image ID="Image1" runat="server" class="responsive-img" ImageUrl="~/image/logoAT.png" />
        </div>
        <h3 class="header center-align indigo-text">Formulario de pre-registro</h3>
        <h4 class="header center-align indigo-text">Activate Turbo</h4>
        <br />
        <h6 class="left-align indigo-text"><i class="material-icons prefix">account_circle</i> Datos personales</h6>
        <div class="row">
            <%--Fila de Nombres, apellidos--%>
            <div class="input-field col s12">
                <asp:TextBox ID="tbNombres" runat="server" placeholder="Nombres" type="text" class="validate" required="required" TabIndex="2"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="input-field col s6">
                <asp:TextBox ID="tbApellidoPaterno" placeholder="Apellido Paterno" runat="server" type="text" class="validate" required="required" TabIndex="3"></asp:TextBox>
            </div>
            <div class="input-field col s6">
                <asp:TextBox ID="tbApellidoMaterno" placeholder="Apellido Materno" runat="server" type="text" class="validate" required="required" TabIndex="4"></asp:TextBox>
            </div>
        </div>
        <h6 class="left-align indigo-text"><i class="material-icons prefix">contacts</i> Datos de contacto</h6>
        <div class="row">
            <div class="input-field col s6">
                <i class="material-icons prefix">call</i>
                <asp:TextBox ID="tbTelefono" runat="server" placeholder="Teléfono" MaxLength="99999999" type="text" class="validate" ValidationGroup="guardar" required="required" TabIndex="5"></asp:TextBox>
                <asp:RangeValidator ID="RangeValidator2" runat="server" MinimumValue="1" ValidationGroup="guardar" ControlToValidate="tbTelefono" MaximumValue="999999999" class="invalid" ErrorMessage="Por favor introduzca un número válido."></asp:RangeValidator>
            </div>
            <div class="input-field col s6">
                <i class="material-icons prefix">smartphone</i>
                <asp:TextBox ID="tbCelular" placeholder="Celular" runat="server" type="text" class="validate" ValidationGroup="guardar" required="required" TabIndex="6"></asp:TextBox>
                <asp:RangeValidator ID="RangeValidator1" runat="server" MinimumValue="1" ValidationGroup="guardar" ControlToValidate="tbCelular" MaximumValue="999999999" class="invalid" ErrorMessage="Por favor introduzca un número válido."></asp:RangeValidator>
            </div>
        </div>
        <div class="row">
            <div class="input-field col s12">
                <i class="material-icons prefix">email</i>
                <label for="tbCorreo">Correo</label>
                <asp:TextBox ID="tbCorreo" placeholder="usuario@ejemplo.com" runat="server" required="required" type="email" class="validate" TabIndex="7"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <asp:Button class="right waves-light indigo lighten-2 btn-large" ID="btnRegistrar" ValidationGroup="guardar" runat="server" Text="Registrar" OnClick="btnRegistrar_Click" />
        </div>
    </div>
</asp:Content>
