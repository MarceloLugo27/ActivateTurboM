<%@ Page Title="" Language="C#" MasterPageFile="~/PanelMaster.Master" AutoEventWireup="true" CodeBehind="MiGenealogia.aspx.cs" Inherits="ActivateTurboM.Panel.MiGenealogia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <asp:Label ID="lblTicket" runat="server" Text="Label" Visible="false"></asp:Label>
        <asp:Label ID="lblGridNivelPadre" runat="server" Text="Label" Visible="false"></asp:Label>
        <asp:Label ID="Label4" runat="server" Text="Label" Visible="false"></asp:Label>

        <div class="row s10 m4 l4 left">
            <asp:Label ID="Label1" runat="server" Text="Mis tickets:"></asp:Label>
            <asp:DropDownList ID="ddlNodosUsuario" runat="server"></asp:DropDownList>
        </div>


        <div class="row">
            <div class="col s12 m6">
                <div class="card white">
                    <div class="card-content black-text">
                        <span class="card-title">Padre (0)</span>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ddlNodosUsuario" EventName="SelectedIndexChanged" />
                            </Triggers>
                            <ContentTemplate>
                                <div>
                                    <asp:GridView ID="dgvPadre" class="highlight responsive-table" AutoGenerateColumns="False" runat="server">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Foto de perfil">
                                                <HeaderStyle Width="120px" />
                                                <ItemTemplate>
                                                    <asp:Image ID="Image1" class="responsive-img" ImageUrl='<%#Eval("strDireccionFotoPerfil") %>' runat="server" />
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
            </div>
        </div>

        <div class="row">
            <div class="col s12 m6">
                <div class="card white">
                    <div class="card-content black-text">
                        <span class="card-title">Yo (1)</span>
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="dgvPadre" EventName="RowCommand" />
                            </Triggers>
                            <ContentTemplate>
                                <div>
                                    <asp:GridView ID="dgvYo" class="highlight responsive-table" AutoGenerateColumns="False" runat="server">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Foto de perfil">
                                                <HeaderStyle Width="120px" />
                                                <ItemTemplate>
                                                    <asp:Image ID="Image1" class="responsive-img" ImageUrl='<%#Eval("strDireccionFotoPerfil") %>' runat="server" />
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
            </div>
        </div>

        <div class="row">
            <div class="col s12 m6">
                <div class="card white">
                    <div class="card-content black-text">
                        <span class="card-title">Hijos (2)</span>
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="dgvPadre" EventName="RowCommand" />
                            </Triggers>
                            <ContentTemplate>
                                <div>
                                    <asp:GridView ID="dgvHijos" class="highlight responsive-table" AutoGenerateColumns="False" runat="server">
                                        <Columns>
                                            <asp:ButtonField ButtonType="Image" ImageUrl="~/image/more_info.png" HeaderText="Editar" CommandName="MoreInfo">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" Width="70px" />
                                            </asp:ButtonField>
                                            <asp:TemplateField HeaderText="Foto de perfil">
                                                <HeaderStyle Width="120px" />
                                                <ItemTemplate>
                                                    <asp:Image ID="Image1" class="responsive-img" ImageUrl='<%#Eval("strDireccionFotoPerfil") %>' runat="server" />
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
            </div>
        </div>

        <div class="row">
            <div class="col s12 m6">
                <div class="card white">
                    <div class="card-content black-text">
                        <span class="card-title">Nietos (3)</span>
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="dgvHijos" EventName="RowCommand" />
                            </Triggers>
                            <ContentTemplate>
                                <div>
                                    <asp:GridView ID="dgvNietos" class="highlight responsive-table" AutoGenerateColumns="False" runat="server">
                                        <Columns>
                                            <asp:ButtonField ButtonType="Image" ImageUrl="~/image/more_info.png" HeaderText="Editar" CommandName="MoreInfo">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" Width="70px" />
                                            </asp:ButtonField>
                                            <asp:TemplateField HeaderText="Foto de perfil">
                                                <HeaderStyle Width="120px" />
                                                <ItemTemplate>
                                                    <asp:Image ID="Image1" class="responsive-img" ImageUrl='<%#Eval("strDireccionFotoPerfil") %>' runat="server" />
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
            </div>
        </div>

        <div class="row">
            <div class="col s12 m6">
                <div class="card white">
                    <div class="card-content black-text">
                        <span class="card-title">Bisnietos (3)</span>
                        <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="dgvBisnietos" EventName="RowCommand" />
                            </Triggers>
                            <ContentTemplate>
                                <div>
                                    <asp:GridView ID="dgvBisnietos" class="highlight responsive-table" AutoGenerateColumns="False" runat="server">
                                        <Columns>
                                            <asp:ButtonField ButtonType="Image" ImageUrl="~/image/more_info.png" HeaderText="Editar" CommandName="MoreInfo">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" Width="70px" />
                                            </asp:ButtonField>
                                            <asp:TemplateField HeaderText="Foto de perfil">
                                                <HeaderStyle Width="120px" />
                                                <ItemTemplate>
                                                    <asp:Image ID="Image1" class="responsive-img" ImageUrl='<%#Eval("strDireccionFotoPerfil") %>' runat="server" />
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
            </div>
        </div>

        <div class="row">
            <div class="col s12 m6">
                <div class="card white">
                    <div class="card-content black-text">
                        <span class="card-title">Tataranietos (4)</span>
                        <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="dgvTataranietos" EventName="RowCommand" />
                            </Triggers>
                            <ContentTemplate>
                                <div>
                                    <asp:GridView ID="dgvTataranietos" class="highlight responsive-table" AutoGenerateColumns="False" runat="server">
                                        <Columns>
                                            <asp:ButtonField ButtonType="Image" ImageUrl="~/image/more_info.png" HeaderText="Editar" CommandName="MoreInfo">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" Width="70px" />
                                            </asp:ButtonField>
                                            <asp:TemplateField HeaderText="Foto de perfil">
                                                <HeaderStyle Width="120px" />
                                                <ItemTemplate>
                                                    <asp:Image ID="Image1" class="responsive-img" ImageUrl='<%#Eval("strDireccionFotoPerfil") %>' runat="server" />
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
            </div>
        </div>

        <div class="row">
            <div class="col s12 m6">
                <div class="card white">
                    <div class="card-content black-text">
                        <span class="card-title">Tataratataranietos (5)</span>
                        <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional">
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="dgvTataratataranietos" EventName="RowCommand" />
                            </Triggers>
                            <ContentTemplate>
                                <div>
                                    <asp:GridView ID="GridView5" class="highlight responsive-table" AutoGenerateColumns="False" runat="server">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Foto de perfil">
                                                <HeaderStyle Width="120px" />
                                                <ItemTemplate>
                                                    <asp:Image ID="Image1" class="responsive-img" ImageUrl='<%#Eval("strDireccionFotoPerfil") %>' runat="server" />
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
            </div>
        </div>


    </div>


</asp:Content>
