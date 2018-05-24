<%@ Page Title="" Language="C#" MasterPageFile="~/PanelMaster.Master" AutoEventWireup="true" CodeBehind="MiGenealogia.aspx.cs" Inherits="ActivateTurboM.Panel.MiGenealogia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <asp:Label ID="lblTicket" runat="server" Text="Label" Visible="false"></asp:Label>
        <asp:Label ID="lblNumeroReferenciaTicket" runat="server" Text="Label" Visible="false"></asp:Label>
        <asp:Label ID="lblGridNivelPadre" runat="server" Text="Label" Visible="false"></asp:Label>
        <asp:Label ID="Label4" runat="server" Text="Label" Visible="false"></asp:Label>

        <div class="row s12">
            <asp:Label ID="Label1" runat="server" class="s4" Text="Mis tickets:"></asp:Label>
            <asp:DropDownList ID="ddlNodosUsuario" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlNodosUsuario_SelectedIndexChanged" CausesValidation="True"></asp:DropDownList>
        </div>

        <br />

        <div class="row">
            <div class="col s12">
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
                                                <HeaderStyle Width="120px" Height="120px" />
                                                <ItemTemplate>
                                                    <asp:Image ID="Image1" class="responsive-img" ImageUrl='<%#Eval("strDireccionFotoPerfil") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="IDNodo" HeaderText="IDNodo" Visible="false" />
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
            <div class="col s12">
                <div class="card white">
                    <div class="card-content black-text">
                        <span class="card-title">Este ticket (1)</span>
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always">
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="dgvPadre" EventName="SelectedIndexChanged" />
                            </Triggers>
                            <ContentTemplate>
                                <div>
                                    <asp:GridView ID="dgvYo" class="highlight responsive-table" AutoGenerateColumns="False" runat="server">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Foto de perfil">
                                                <HeaderStyle Width="120px" Height="120px" />
                                                <ItemTemplate>
                                                    <asp:Image ID="Image1" class="responsive-img" ImageUrl='<%#Eval("strDireccionFotoPerfil") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="IDNodo" HeaderText="IDNodo" />
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
            <div class="col s12">
                <div class="card white">
                    <div class="card-content black-text">
                        <span class="card-title">Mis hijos (2)</span>
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ddlNodosUsuario" EventName="SelectedIndexChanged" />
                            </Triggers>
                            <ContentTemplate>
                                <div>
                                    <asp:GridView ID="dgvHijos" class="highlight responsive-table" AutoGenerateColumns="False" runat="server" OnRowCommand="dgvHijos_RowCommand">
                                        <Columns>
                                            <asp:ButtonField ButtonType="Image" ImageUrl="~/image/more_info.png" HeaderText="Info" CommandName="MoreInfo">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" Width="70px" />
                                            </asp:ButtonField>
                                            <asp:TemplateField HeaderText="Foto de perfil">
                                                <HeaderStyle Width="120px" Height="120px" />
                                                <ItemTemplate>
                                                    <asp:Image ID="Image1" class="responsive-img" ImageUrl='<%#Eval("strDireccionFotoPerfil") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:BoundField DataField="IDNodo" HeaderText="IDNodo" />
                                            <asp:BoundField DataField="strNumeroReferencia" HeaderText="Referencia" />
                                            <asp:BoundField DataField="strNombreCompleto" HeaderText="Nombre" />
                                            <asp:BoundField DataField="strOrigen" HeaderText="Ciudad" />
                                            <asp:BoundField DataField="intTelefono" HeaderText="Teléfono" />
                                            <asp:BoundField DataField="strCelular" HeaderText="Celular" />
                                            <asp:BoundField DataField="strEmail" HeaderText="Email" />

                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <div id="divEstadoDGV" runat="server" visible="false" class="card-action">
                            <p>
                                <asp:Label ID="lblEstadoDGV" runat="server" Text="Label"></asp:Label>
                            </p>
                        </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col s12">
                <div class="card white">
                    <div class="card-content black-text">
                        <span class="card-title">Nietos (3)</span>
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="dgvHijos" EventName="RowCommand" />
                            </Triggers>
                            <ContentTemplate>
                                <div>
                                    <asp:GridView ID="dgvNietos" class="highlight responsive-table" AutoGenerateColumns="False" runat="server" OnRowCommand="dgvNietos_RowCommand">
                                        <Columns>
                                            <asp:ButtonField ButtonType="Image" ImageUrl="~/image/more_info.png" HeaderText="Info" CommandName="MoreInfo">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" Width="70px" />
                                            </asp:ButtonField>
                                            <asp:TemplateField HeaderText="Foto de perfil">
                                                <HeaderStyle Width="120px" />
                                                <ItemTemplate>
                                                    <asp:Image ID="Image1" class="responsive-img" ImageUrl='<%#Eval("strDireccionFotoPerfil") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="IDNodo" HeaderText="IDNodo"/>
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
            <div class="col s12">
                <div class="card white">
                    <div class="card-content black-text">
                        <span class="card-title">Bisnietos (4)</span>
                        <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="dgvNietos" EventName="RowCommand" />
                            </Triggers>
                            <ContentTemplate>
                                <div>
                                    <asp:GridView ID="dgvBisnietos" class="highlight responsive-table" AutoGenerateColumns="False" runat="server" OnRowCommand="dgvBisnietos_RowCommand">
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


        <%--<div class="row">
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
        </div>--%>

        <div class="divider"></div>
        <div class="section">
            <h5></h5>
            <p></p>
        </div>

    </div>


</asp:Content>
