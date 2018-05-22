<%@ Page Title="" Language="C#" MasterPageFile="~/PanelMaster.Master" AutoEventWireup="true" CodeBehind="Genealogia.aspx.cs" Inherits="ActivateTurboM.Panel.Genealogia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblDDL1" runat="server" Text="Label" Visible="false"></asp:Label><asp:Label ID="lblDDL2" runat="server" Text="Label" Visible="false"></asp:Label>

    <div class="container">

        <div class="card col s12">
            <div class="card-content">
                <span class="card-title">Ascendencia directa (Padre)</span>
                <asp:DropDownList ID="ddlAscendencia" runat="server" AutoPostBack="true" class="col s6" OnSelectedIndexChanged="ddlAscendencia_SelectedIndexChanged" CausesValidation="True"></asp:DropDownList>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlAscendencia" EventName="SelectedIndexChanged" />
                    </Triggers>
                    <ContentTemplate>
                        <div>
                            <asp:GridView ID="dgvAscendencia" class="highlight responsive-table" AutoGenerateColumns="False" runat="server">
                                <Columns>
                                    <asp:TemplateField HeaderText="Foto de perfil">
                                        <HeaderStyle Width="120px" />
                                        <ItemTemplate>
                                            <asp:Image ID="Image1" class="circle responsive-img" ImageUrl='<%#Eval("strDireccionFotoPerfil") %>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="strNumeroReferencia" HeaderText="Referencia" />
                                    <asp:BoundField DataField="strNombreCompleto" HeaderText="Nombre" />
                                    <asp:BoundField DataField="strOrigen" HeaderText="Ciudad" />
                                     <asp:BoundField DataField="intTelefono" HeaderText="Teléfono" />
                                    <asp:BoundField DataField="strCelular" HeaderText="Celular" />
                                    <asp:BoundField DataField="strEmail" HeaderText="Email" />
                                    
                                </Columns>
                            </asp:GridView>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>

        <div class="card col s12">
            <div class="card-content">
                <span class="card-title">Mis ventas</span>
                <asp:DropDownList ID="ddlMisVentas" runat="server" AutoPostBack="true" class="col s6" OnSelectedIndexChanged="ddlMisVentas_SelectedIndexChanged" CausesValidation="True"></asp:DropDownList>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlMisVentas" EventName="SelectedIndexChanged" />
                    </Triggers>
                    <ContentTemplate>
                        <div>
                            <asp:GridView ID="dgvVendidos" class="highlight responsive-table" AutoGenerateColumns="False" runat="server">
                                <Columns>
                                    <asp:TemplateField HeaderText="Foto de perfil">
                                        <HeaderStyle Width="120px" />
                                        <ItemTemplate>
                                            <asp:Image ID="Image1" class="circle responsive-img" ImageUrl='<%#Eval("strDireccionFotoPerfil") %>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="strNumeroReferencia" HeaderText="Referencia" />
                                    <asp:BoundField DataField="strNombreCompleto" HeaderText="Nombre" />
                                    <asp:BoundField DataField="strOrigen" HeaderText="Ciudad" />
                                    <asp:BoundField DataField="intTelefono" HeaderText="Teléfono" />
                                    <asp:BoundField DataField="strCelular" HeaderText="Celular" />
                                    <asp:BoundField DataField="strEmail" HeaderText="Email" />
                                </Columns>
                            </asp:GridView>
                        </div>
                        <div id="divEstadoDGV" runat="server" visible="false" class="col s6">
                            <p>
                                <asp:Label ID="lblEstadoDGV" runat="server" Text="Label"></asp:Label>
                            </p>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>

        <div class="card col s12">
            <div class="card-content">
                <span class="card-title">Descendencia</span>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnCargarDescendientes" EventName="Click" />
                    </Triggers>
                    <ContentTemplate>
                        <div>
                            <asp:GridView ID="dgvDescendencia" class="highlight responsive-table" AutoGenerateColumns="false" runat="server">
                                <Columns>
                                    <asp:TemplateField HeaderText="Foto de perfil">
                                        <HeaderStyle Width="120px" />
                                        <ItemTemplate>
                                            <asp:Image ID="Image1" class="circle responsive-img" ImageUrl='<%#Eval("strDireccionFotoPerfil") %>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="strNumeroReferencia" HeaderText="Referencia" />
                                    <asp:BoundField DataField="strNombreCompleto" HeaderText="Nombre" />
                                    <asp:BoundField DataField="strOrigen" HeaderText="Ciudad" />
                                    <asp:BoundField DataField="intTelefono" HeaderText="Teléfono" />
                                    <asp:BoundField DataField="strCelular" HeaderText="Celular" />
                                    <asp:BoundField DataField="strEmail" HeaderText="Email" />
                                </Columns>
                            </asp:GridView>
                            <br />
                            <div id="divEstadoHijos" runat="server" visible="false" class="col s12">
                            <p>
                                <asp:Label ID="lblEstadoHijos" runat="server" Text="Label"></asp:Label>
                            </p>
                        </div>
                        </div>
                        <div class="card-action">
                            <asp:LinkButton ID="btnCargarDescendientes" runat="server" OnClick="btnCargarDescendientes_Click">Cargar descendientes</asp:LinkButton>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>


    </div>



</asp:Content>
