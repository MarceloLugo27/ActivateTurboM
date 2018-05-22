<%@ Page Title="" Language="C#" MasterPageFile="~/PanelMaster.Master" AutoEventWireup="true" CodeBehind="RegistroPreliminar.aspx.cs" Inherits="ActivateTurboM.RegistroPreliminar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h3>Registro preliminar</h3>

        <div class="section">
            <h5>Datos personales</h5>
            <div class="row">
                <div class="input-field col s12 m6 l6">
                    <i class="material-icons prefix">account_circle</i>
                    <asp:TextBox ID="tbNombres" placeholder="Nombres" class="validate" type="text" required="required" runat="server"></asp:TextBox>
                    <label for="tbNombres">Nombres</label>
                </div>
                <div class="input-field col s6 m3 l3">
                    <asp:TextBox ID="tbApellidoPaterno" placeholder="Apellido Paterno" type="text" class="validate" required="required" runat="server"></asp:TextBox>
                </div>
                <div class="input-field col s6 m3 l3">
                    <asp:TextBox ID="tbApellidoMaterno" placeholder="Apellido Materno" type="text" class="validate" required="required" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>

        <div class="divider"></div>
        <div class="section">
            <h5>Datos de contacto</h5>
            <div class="row">
                <div class="input-field col s12">
                    <i class="material-icons prefix">contact_mail</i>
                    <asp:TextBox ID="tbEmail" placeholder="Correo electrónico" class="validate" type="text" required="required" runat="server"></asp:TextBox>
                </div>
                <div class="input-field col s6">
                    <i class="material-icons prefix">local_phone</i>
                    <asp:TextBox ID="tbTelefono" MaxLength="99999999" placeholder="Teléfono" type="text" class="validate" ValidationGroup="guardar" runat="server"></asp:TextBox>
                    <label for="tbTelefono">Password</label>
                    <asp:RangeValidator ID="RangeValidator2" runat="server" MinimumValue="1" ValidationGroup="guardar"  ControlToValidate="tbTelefono" MaximumValue="999999999" class="invalid" ErrorMessage="Por favor introduzca un número válido."></asp:RangeValidator>
                </div>
                <div class="input-field col s6">
                    <i class="material-icons prefix">smartphone</i>
                    <asp:TextBox ID="tbCelular" placeholder="Celular" ValidationGroup="guardar" class="validate" type="text" runat="server"></asp:TextBox>
                    <asp:RangeValidator ID="RangeValidator1" runat="server" MinimumValue="1" ValidationGroup="guardar" ControlToValidate="tbCelular" MaximumValue="999999999" class="invalid" ErrorMessage="Por favor introduzca un número válido."></asp:RangeValidator>
                </div>
            </div>
        </div>

        <div class="row">
            <asp:Button ID="btnRegistrar" runat="server"  class="right waves-light indigo lighten-2 btn-large validate" ValidationGroup="guardar" Text="Registrar" OnClick="btnRegistrar_Click" />
        </div>

        <div class="divider"></div>
        <div class="section">
            <h5></h5>
            <p></p>
        </div>

        <div class="divider"></div>
        <div class="section">
            <h5></h5>
            <p></p>
        </div>
    </div>
</asp:Content>
