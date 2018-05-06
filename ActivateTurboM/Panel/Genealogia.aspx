<%@ Page Title="" Language="C#" MasterPageFile="~/PanelMaster.Master" AutoEventWireup="true" CodeBehind="Genealogia.aspx.cs" Inherits="ActivateTurboM.Panel.Genealogia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblDDL1" runat="server" Text="Label" Visible="false"></asp:Label><asp:Label ID="lblDDL2" runat="server" Text="Label" Visible="false"></asp:Label>
    <div>Ascendencia directa</div>
    <div>
        <div class="s3">
            <asp:DropDownList ID="ddlMisTickets1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMisTickets1_SelectedIndexChanged"></asp:DropDownList>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ddlMisTickets2" EventName="SelectedIndexChanged" />
            </Triggers>
            <ContentTemplate>
                <div class="responsive-table centered highlight">
                    <asp:GridView ID="dgvAscendencia" runat="server">
                        <Columns>
                            <asp:BoundField DataField="strNumeroReferencia" HeaderText="Referencia" />
                            <asp:BoundField DataField="strNombreCompleto" HeaderText="Nombre completo" />
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
    <div class="">Mis ventas</div>
    <div class="">
        <div class="s3">
            <asp:DropDownList ID="ddlMisTickets2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMisTickets2_SelectedIndexChanged"></asp:DropDownList>
        </div>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ddlMisTickets2" EventName="SelectedIndexChanged" />
            </Triggers>
            <ContentTemplate>
                <div class="responsive-table centered highlight">
                    <asp:GridView ID="dgvMisVentas" runat="server">
                        <Columns>
                            <asp:BoundField DataField="strNumeroReferencia" HeaderText="Referencia" />
                            <asp:BoundField DataField="strNombreCompleto" HeaderText="Nombre completo" />
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
    <div class="<%--collapsible-header--%>">Descendencia directa</div>
    <div class="<%--collapsible-body--%>">
        <div>
            <%--<asp:DropDownList ID="ddlMisTickets3" runat="server"></asp:DropDownList>--%>
        </div>
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                <div class="responsive-table centered highlight">
                    <asp:GridView ID="dgvDescendencia" runat="server">
                        <Columns>
                            <asp:BoundField DataField="strNumeroReferencia" HeaderText="Referencia" />
                            <asp:BoundField DataField="strNombreCompleto" HeaderText="Nombre completo" />
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



</asp:Content>
