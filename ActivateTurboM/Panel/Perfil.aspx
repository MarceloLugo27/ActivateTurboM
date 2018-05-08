<%@ Page Title="" Language="C#" MasterPageFile="~/PanelMaster.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="ActivateTurboM.Panel.Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="row">
            <h3 class="header indigo-text left">Perfil del usuario</h3>
        </div>
        <asp:Label ID="lblIDEstado" runat="server" Visible="false" Text=""></asp:Label>
        <asp:Label ID="lblIDCiudad" runat="server" Visible="false" Text=""></asp:Label>

        <div class="row">
            <div class="col s12 m5">
                <div class="card-panel teal">
                    <span class="white-text">Para guardar cualquier cambio, por favor use el botón de la esquina inferior derecha.</span>
                </div>
            </div>
        </div>
        <br />

        <div class="section">
            <h5>Datos de la cuenta</h5>
            <div class="row">
                <div class="input-field col s6">
                    <asp:TextBox ID="tbUsername" Enabled="false" placeholder="Nombre de usuario" runat="server"></asp:TextBox>
                </div>
                <div class="input-field col s6">
                    <asp:TextBox ID="tbPassword" placeholder="Contraseña" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="divider"></div>
        <div class="section">
            <h5>Datos personales</h5>
            <div class="row">
                <div class="input-field col s12 m6 l6">
                    <i class="material-icons prefix">account_circle</i>
                    <asp:TextBox ID="tbNombres" placeholder="Nombres" class="validate" required="required" runat="server"></asp:TextBox>
                </div>
                <div class="input-field col s6 m3 l3">
                    <asp:TextBox ID="tbApellidoPaterno" placeholder="Apellido Paterno" class="validate" required="required" runat="server"></asp:TextBox>
                </div>
                <div class="input-field col s6 m3 l3">
                    <asp:TextBox ID="tbApellidoMaterno" placeholder="Apellido Materno" class="validate" required="required" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="row">
                <div class="input-field col s6 m4 l6">
                    <asp:TextBox ID="tbCURP" placeholder="CURP" class="validate" required="required" runat="server"></asp:TextBox>
                </div>
                <div class="input-field col s6 m4 l3">
                    <asp:TextBox ID="tbRFC" placeholder="RFC" class="validate" required="required" runat="server"></asp:TextBox>
                </div>
                <div class="input-field col s12 m4 l3">
                    <asp:TextBox ID="tbSeguroSocial" placeholder="Seguro Social (NSS)" class="validate" required="required" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="divider"></div>
        <div class="section">
            <h5>Datos de contacto</h5>
            <div class="row">
                <div class="input-field col s12">
                    <i class="material-icons prefix">contact_mail</i>
                    <asp:TextBox ID="tbEmail" placeholder="Correo electrónico" class="validate" required="required" runat="server"></asp:TextBox>
                </div>
                <div class="input-field col s6">
                    <i class="material-icons prefix">local_phone</i>
                    <asp:TextBox ID="tbTelefono" MaxLength="99999999" placeholder="Teléfono" ValidationGroup="guardar" runat="server"></asp:TextBox>
                    <asp:RangeValidator ID="RangeValidator2" runat="server" MinimumValue="1" ValidationGroup="guardar" ControlToValidate="tbTelefono" MaximumValue="999999999" class="invalid" ErrorMessage="Por favor introduzca un número válido."></asp:RangeValidator>
                </div>
                <div class="input-field col s6">
                    <i class="material-icons prefix">smartphone</i>
                    <asp:TextBox ID="tbCelular" placeholder="Celular" ValidationGroup="guardar" runat="server"></asp:TextBox>
                    <asp:RangeValidator ID="RangeValidator1" runat="server" MinimumValue="1" ValidationGroup="guardar" ControlToValidate="tbCelular" MaximumValue="999999999" class="invalid" ErrorMessage="Por favor introduzca un número válido."></asp:RangeValidator>
                </div>
            </div>
        </div>
        <div class="divider"></div>
        <div class="section">
            <h5>Domicilio</h5>
            <div class="row">
                <div class="input-field col s6">
                    <asp:TextBox ID="tbCalle" placeholder="Calle" class="validate" required="required" runat="server"></asp:TextBox>
                </div>
                <div class="input-field col s3">
                    <asp:TextBox ID="tbNumeroExterior" placeholder="Núm. exterior" class="validate" required="required" runat="server"></asp:TextBox>
                </div>
                <div class="input-field col s3">
                    <asp:TextBox ID="tbNumeroInterior" placeholder="Núm. interior" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="row">
                <div class="input-field col s8">
                    <asp:TextBox ID="tbColonia" placeholder="Colonia" class="validate" required="required" runat="server"></asp:TextBox>
                </div>
                <div class="input-field col s4">
                    <asp:TextBox ID="tbCodigoPostal" placeholder="Codigo Postal" class="validate" required="required" runat="server"></asp:TextBox>
                    <asp:RangeValidator ID="RangeValidator3" runat="server" MinimumValue="1" ValidationGroup="guardar" ControlToValidate="tbCodigoPostal" MaximumValue="999999999" class="invalid" ErrorMessage="Por favor introduzca un código válido."></asp:RangeValidator>
                </div>
            </div>
            <div class="row">
                <div class="col s6">
                    <asp:Label ID="Label1" runat="server" Text="Estado:"></asp:Label>
                    <asp:DropDownList ID="ddlEstado" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEstado_SelectedIndexChanged"></asp:DropDownList>
                </div>
                <div class="col s6">
                    <asp:Label ID="Label2" runat="server" Text="Municipio:"></asp:Label>
                    <asp:DropDownList ID="ddlMunicipio" runat="server" class="validate" required="required" AutoPostBack="True" OnSelectedIndexChanged="ddlMunicipio_SelectedIndexChanged"></asp:DropDownList>
                </div>
            </div>
        </div>
        <div class="divider"></div>
        <div class="section">
            <h5>Documentación</h5>
            <p>En construcción</p>
        </div>
    </div>

    <div class="fixed-action-btn">
        <asp:LinkButton ID="btnGuardar" ValidationGroup="guardar" class="btn-floating btn-large red" runat="server" href="#modal1" OnClick="btnGuardar_Click"><i class="large material-icons">save</i></asp:LinkButton>
    </div>

</asp:Content>
