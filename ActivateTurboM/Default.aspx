<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ActivateTurboM._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="section no-pad-bot" id="index-banner">
            <div class="container">
                <br>
                <div class="row center col s12"><asp:Image ID="Image1" runat="server" ImageUrl="~/image/logoAT.png" /></div>
                <br>
                <h1 class="header center indigo-text">Pre-registro Activate Turbo</h1>
                <div class="row center">
                    <h5 class="header col s12 light">¡Registrate ahora y recibe un correo con clave y tu acceso el día del lanzamiento!</h5>
                </div>
                <div class="row center">
                    <asp:HyperLink ID="hlRegistro" href="Registro.aspx" class="waves-effect waves-light btn-large indigo lighten-2" runat="server">Registrarme</asp:HyperLink>
                </div>
                <br>
                <br>
            </div>
        </div>
</asp:Content>
