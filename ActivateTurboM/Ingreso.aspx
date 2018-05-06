<%@ Page Title="" Language="C#" MasterPageFile="~/PanelMaster.Master" AutoEventWireup="true" CodeBehind="Ingreso.aspx.cs" Inherits="ActivateTurboM.Ingreso" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row center">
        <img class="responsive-img" style="width: 250px;" src="image/logoAT.png" />
        <div class="section"></div>

        <h5 class="indigo-text">Ingrese sus datos para entrar</h5>
        <div class="section"></div>

        <div class="container">
            <div class="z-depth-1 grey lighten-4 row" style="display: inline-block; padding: 32px 48px 0px 48px; border: 1px solid #EEE;">

                <div class="col s12">
                    <div class="row">
                        <div class="col s12">
                        </div>
                    </div>

                    <div class="row">
                        <div class="input-field col s12">
                            <asp:TextBox ID="tbUsername" placeholder="Cuenta" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="row">
                        <div class="input-field col s12">
                            <asp:TextBox ID="tbPassword" type="password" placeholder="Contraseña" runat="server"></asp:TextBox>
                        </div>
                        <div class="row">
                            <asp:HyperLink ID="HyperLink1" class="col s6 pink-text" runat="server"><b>¿Olvidaste tu contraseña?</b></asp:HyperLink>
                            <asp:HyperLink ID="HyperLink2" class="col s6" runat="server">Crear cuenta</asp:HyperLink>
                        </div>
                    </div>
                    <asp:UpdatePanel ID="UpdatePanelLogin" runat="server">
                        <ContentTemplate>
                            <div class="row center">
                                <div id="divMensajeError" runat="server" visible="false">
                                    <asp:Label ID="lblMensajeError" class="red-text" runat="server"></asp:Label>
                                </div>
                                <br />
                                <div class="row">
                                    <asp:LinkButton ID="btnIngresar" class="col s12 btn btn-large waves-effect waves-light indigo" runat="server" OnClick="btnIngresar_Click">Iniciar sesión</asp:LinkButton>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
