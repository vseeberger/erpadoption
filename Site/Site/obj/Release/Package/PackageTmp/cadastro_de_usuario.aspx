<%@ Page Title="" Language="C#" MasterPageFile="~/_MLogado.master" AutoEventWireup="true" CodeBehind="cadastro_de_usuario.aspx.cs" Inherits="Site.cadastro_de_usuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cHeaderScripts" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cConteudo" runat="server">
<%--    <asp:ScriptManager runat="server" ID="src001"></asp:ScriptManager>--%>
    <asp:Panel runat="server" ID="pnl01" DefaultButton="lnkSalvar">
        <div class="box-typical box-typical-padding">
            <h5 class="m-t-lg with-border">Cadastro de Usuários</h5>
            <div class="row">
                <div class="col-md-2 col-sm-4 col-xs-12">
                    <label class="form-control-label">Código</label>
                    <asp:TextBox readonly disabled runat="server" ID="txtCodigo" CssClass="form-control" Text="AUTOMATICO"></asp:TextBox>
                    <asp:HiddenField runat="server" ID="hdfID" />
                </div>
                <div class="col-md-10 col-sm-8 col-xs-12">
                    <label class="form-control-label">Nome</label>
                    <asp:TextBox runat="server" ID="txtNome" MaxLength="250" CssClass="form-control primeiro"></asp:TextBox>
                </div>


                <div class="col-md-6 col-sm-6 col-xs-12">
                    <label class="form-control-label">Perfil</label>
                    <asp:DropDownList runat="server" ID="ddlPerfil" CssClass="select2"></asp:DropDownList>
                </div>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <label class="form-control-label">Pessoa</label>
                    <asp:DropDownList runat="server" ID="ddlPessoaVincular" CssClass="select2"></asp:DropDownList>
                </div>

            </div>
            <br /><div class="clearfix"></div>                        
            <div class="row">
                <div class="col-md-4 col-sm-4 col-xs-12">
                    <label class="form-control-label">Login</label>
                    <asp:TextBox runat="server" ID="txtLogin" MaxLength="250" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-2 col-sm-4 col-xs-12">
                    <label class="form-control-label">Senha</label>
                    <asp:TextBox runat="server" ID="txtSenha" CssClass="form-control" TextMode="Password"></asp:TextBox>
                    <asp:HiddenField runat="server" ID="hdfSenha" />
                </div>
                <div class="col-md-6 col-sm-4 col-xs-12">
                    <label class="form-control-label">E-mail</label>
                    <asp:TextBox runat="server" ID="txtEmail" MaxLength="250" CssClass="form-control emails"></asp:TextBox>
                </div>
            </div>
            <br /><div class="clearfix"></div>
            <div class="row">
                <div class="col-md-2 col-sm-6 col-xs-12"><asp:LinkButton runat="server" CssClass="form-control btn btn-success swal-btn-basic" ID="lnkSalvar" OnClick="lnkSalvar_Click"><i class="fa fa-check"></i> Salvar</asp:LinkButton></div>
                <div class="col-md-2 col-sm-6 col-xs-12"><asp:LinkButton runat="server" CssClass="form-control btn btn-danger-outline swal-btn-basic" ID="lnkCancelar" OnClick="lnkCancelar_Click"><i class="fa fa-close"></i> Cancelar</asp:LinkButton></div>
            </div>
        </div>
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cFooterScripts" runat="server">
</asp:Content>