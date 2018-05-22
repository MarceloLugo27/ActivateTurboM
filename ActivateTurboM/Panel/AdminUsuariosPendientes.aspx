<%@ Page Title="" Language="C#" MasterPageFile="~/PanelMaster.Master" AutoEventWireup="true" CodeBehind="AdminUsuariosPendientes.aspx.cs" Inherits="ActivateTurboM.Panel.AdminUsuariosPendientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="card col s12">
            <div class="card-content">
                <span class="card-title">Usuarios temporales agregados</span>

                <div>
                    <asp:GridView ID="dgvUsuariosPendientes" class="highlight responsive-table" AutoGenerateColumns="False" runat="server" OnRowCommand="dgvUsuariosPendientes_RowCommand">
                        <Columns>
                            <asp:ButtonField ButtonType="Image" ImageUrl="~/image/icon_editar.png" HeaderText="Editar" CommandName="Modificar">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" Width="70px" />
                            </asp:ButtonField>
                            <asp:ButtonField ButtonType="Image" ImageUrl="~/image/icon_delete.png" HeaderText="Borrar" CommandName="Eliminar">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" Width="70px" />
                            </asp:ButtonField>
                            <asp:BoundField DataField="IDUsuarioTemp" HeaderText="IDUsuario" />
                            <asp:BoundField DataField="strNumeroReferencia" HeaderText="Referencia" />
                            <asp:BoundField DataField="strNombreCompleto" HeaderText="Nombre" />
                            <asp:BoundField DataField="intTelefono" HeaderText="Teléfono" />
                            <asp:BoundField DataField="strCelular" HeaderText="Celular" />
                            <asp:BoundField DataField="strEmail" HeaderText="Email" />

                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="dgvUsuariosPendientes" EventName="RowCommand" />
            </Triggers>
            <ContentTemplate>
                <asp:Label ID="lblIDUsuarioTemp" runat="server" Text="" Visible="false"></asp:Label>
                <div class="card col s12">
                    <div class="card-content">
                        <div class="row">
                            <div class="input-field col s6">
                                <asp:TextBox ID="tbUsername" placeholder="Nombre de usuario" runat="server" type="text" class="validate" required="required" TabIndex="1"></asp:TextBox>
                            </div>
                            <div class="input-field col s6">
                                <asp:TextBox ID="tbPassword" placeholder="Contraseña" runat="server" type="text" class="validate" required="required" TabIndex="2"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row">
                            <div class="input-field col s6">
                                <asp:TextBox ID="tbNumeroReferencia" placeholder="Número de referencia" runat="server" type="text" class="validate" required="required" TabIndex="1"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="input-field col s12 m6 l6">
                                <asp:TextBox ID="tbNombres" placeholder="Nombres" class="validate" Enabled="false" type="text" required="required" runat="server"></asp:TextBox>
                            </div>
                            <div class="input-field col s6 m3 l3">
                                <asp:TextBox ID="tbApellidoPaterno" placeholder="Apellido Paterno" Enabled="false" runat="server"></asp:TextBox>
                            </div>
                            <div class="input-field col s6 m3 l3">
                                <asp:TextBox ID="tbApellidoMaterno" placeholder="Apellido Materno" Enabled="false" type="text" class="validate" required="required" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="divider"></div>
                        <br />
                        <br />
                        <div class="row">
                            <asp:Button ID="btnCrearUsuario" class="btn teal white-text right" runat="server" Text="Asignar" OnClick="btnCrearUsuario_Click" />
                        </div>
                    </div>
                    <div class="row">
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

    </div>
</asp:Content>
