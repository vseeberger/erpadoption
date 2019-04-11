<%@ Page Title="" Language="C#" MasterPageFile="~/_MLogado.master" AutoEventWireup="true" CodeBehind="cadastro_de_perfil.aspx.cs" Inherits="Site.cadastro_de_perfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cHeaderScripts" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cConteudo" runat="server">
<%--    <asp:ScriptManager runat="server" ID="src01"></asp:ScriptManager>--%>
    <asp:Panel runat="server" ID="pnl01" DefaultButton="lnkSalvar">
        <div class="box-typical box-typical-padding">
            <h5 class="m-t-lg with-border">Cadastro de Perfil</h5>
            <div class="row">
                <div class="col-md-2 col-sm-4 col-xs-12">
                    <label class="form-control-label">Código</label>
                    <asp:TextBox readonly disabled runat="server" ID="txtCodigo" CssClass="form-control" Text="AUTOMATICO"></asp:TextBox>
                </div>
                    
                <div class="col-md-10 col-sm-8 col-xs-12">
                    <label class="form-control-label">Nome</label>
                    <asp:TextBox runat="server" ID="txtNome" MaxLength="250" CssClass="form-control primeiro"></asp:TextBox>
                </div>
            </div>

            <br /><div class="clearfix"></div>
            <div class="row">
                <div class="col-xl-12 dahsboard-column">
                    <section class="box-typical box-typical-dashboard panel panel-default scrollable">
	                    <header class="box-typical-header panel-heading"><h3 class="panel-title panel">Formulários e permissões</h3></header>
	                    <div class="box-typical-body panel-body">

                            <asp:UpdatePanel runat="server" ID="upnl001">
                                <ContentTemplate>
                                    <asp:GridView runat="server" OnRowCommand="gdvFormularios_RowCommand" ShowFooter="true" ID="gdvFormularios" CssClass="tbl-typical" AutoGenerateColumns="false" GridLines="None">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Formulário">
                                                <ItemTemplate>
                                                    <%#Eval("Formulario.Id").ToString() == Eval("Formulario.MenuPaiFull").ToString() ? "<i class='fa fa-arrow-circle-o-right'> </i>" : "&nbsp;&nbsp;&nbsp;>" %>
                                                    <%#Eval("Formulario.SNome") %>
                                                    <asp:HiddenField runat="server" ID="hdfFormulario" Value='<%#Eval("Formulario.Id") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            
                                            <asp:TemplateField HeaderText="Abrir">
                                                <ItemTemplate><asp:CheckBox runat="server" ID="cbxAbrir" Checked='<%#Eval("Abrir") %>' /></ItemTemplate>
                                                <FooterTemplate><asp:ImageButton runat="server" ID="cbxAbrirTodos" ImageUrl="~/img/checado.png" BorderStyle="None" CommandName="ChecarTodosAbrir" /></FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Pesq">
                                                <ItemTemplate><asp:CheckBox runat="server" Checked='<%#Eval("Pesquisar") %>' ID="cbxPesquisar" ToolTip="Permissão para Pesquisar" /></ItemTemplate>
                                                <FooterTemplate><asp:ImageButton runat="server" ID="cbxPesquisarTodos" ImageUrl="~/img/checado.png" BorderStyle="None" CommandName="ChecarTodosPesquisar" /></FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Ins">
                                                <ItemTemplate><asp:CheckBox runat="server" Checked='<%#Eval("Inserir") %>' ID="cbxInserir" ToolTip="Permissão para Inserir" /></ItemTemplate>
                                                <FooterTemplate><asp:ImageButton runat="server" ID="cbxInserirTodos" ImageUrl="~/img/checado.png" BorderStyle="None" CommandName="ChecarTodosInserir" /></FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Alt">
                                                <ItemTemplate><asp:CheckBox runat="server" Checked='<%#Eval("Alterar") %>' ID="cbxAlterar" ToolTip="Permissão para Alterar" /></ItemTemplate>
                                                <FooterTemplate><asp:ImageButton runat="server" ID="cbxAlterarTodos" ImageUrl="~/img/checado.png" BorderStyle="None" CommandName="ChecarTodosAlterar" /></FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Del">
                                                <ItemTemplate><asp:CheckBox runat="server" Checked='<%#Eval("Excluir") %>' ID="cbxExcluir" ToolTip="Permissão para Excluir" /></ItemTemplate>
                                                <FooterTemplate><asp:ImageButton runat="server" ID="cbxExcluirTodos" ImageUrl="~/img/checado.png" BorderStyle="None" CommandName="ChecarTodosExcluir" /></FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Esp">
                                                <ItemTemplate><asp:CheckBox runat="server" Checked='<%#Eval("Especial") %>' ID="cbxEspecial" ToolTip="Permissão para Especial" /></ItemTemplate>
                                                <FooterTemplate><asp:ImageButton runat="server" ID="cbxEspecialTodos" ImageUrl="~/img/checado.png" BorderStyle="None" CommandName="ChecarTodosEspecial" /></FooterTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
	                    </div><!--.box-typical-body-->
	                </section><!--.box-typical-dashboard-->
                </div><!--.col-->
            </div>

            <div class="row">
                <div class="col-md-2 col-sm-6 col-xs-12"><asp:LinkButton runat="server" CssClass="form-control btn btn-success swal-btn-basic" ID="lnkSalvar" OnClick="lnkSalvar_Click"><i class="fa fa-check"></i> Salvar</asp:LinkButton></div>
                <div class="col-md-2 col-sm-6 col-xs-12"><asp:LinkButton runat="server" CssClass="form-control btn btn-danger-outline swal-btn-basic" ID="lnkCancelar" OnClick="lnkCancelar_Click"><i class="fa fa-close"></i> Cancelar</asp:LinkButton></div>
            </div>
        </div>
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cFooterScripts" runat="server">
</asp:Content>