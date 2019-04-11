<%@ Page Title="" Language="C#" MasterPageFile="~/_MLogado.master" AutoEventWireup="true" CodeBehind="cadastro_de_fornecedor.aspx.cs" Inherits="Site.cadastro_de_fornecedor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cHeaderScripts" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cConteudo" runat="server">
    <asp:Panel runat="server" ID="pnl01" DefaultButton="lnkSalvar">
        <div class="box-typical box-typical-padding">
            <h5 class="m-t-lg with-border">Cadastro de Fornecedor</h5>
            <div class="row">
                <div class="col-md-2 col-sm-4 col-xs-12">
                    <label class="form-control-label">Código</label>
                    <asp:TextBox readonly disabled runat="server" ID="txtCodigo" CssClass="form-control" Text="AUTOMATICO"></asp:TextBox>
                </div>
                    
                <div class="col-md-5 col-sm-12 col-xs-12">
                    <label class="form-control-label">Razao Social/Nome</label>
                    <asp:TextBox runat="server" ID="txtRazaoSocial" MaxLength="250" CssClass="form-control primeiro"></asp:TextBox>
                </div>
                    
                <div class="col-md-5 col-sm-12 col-xs-12">
                    <label class="form-control-label">Nome Fantasia</label>
                    <asp:TextBox runat="server" ID="txtNomeFantasia" MaxLength="250" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="col-md-4 col-sm-4 col-xs-12">
                    <label class="form-control-label">CNPJ</label>
                    <asp:TextBox runat="server" ID="txtCnpj" CssClass="form-control cnpj"></asp:TextBox>
                </div>

                <div class="col-md-4 col-sm-4 col-xs-12">
                    <label class="form-control-label">Email</label>
                    <asp:TextBox runat="server" ID="txtEmail" MaxLength="250" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="col-md-4 col-sm-4 col-xs-12">
                    <label class="form-control-label">Site</label>
                    <asp:TextBox runat="server" ID="txtSite" MaxLength="250" CssClass="form-control"></asp:TextBox>
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