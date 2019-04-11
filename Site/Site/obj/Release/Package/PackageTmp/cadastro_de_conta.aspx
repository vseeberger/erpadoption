<%@ Page Title="" Language="C#" MasterPageFile="~/_MLogado.master" AutoEventWireup="true" CodeBehind="cadastro_de_conta.aspx.cs" Inherits="Site.cadastro_de_conta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cHeaderScripts" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cConteudo" runat="server">
    <asp:Panel runat="server" ID="pnl01" DefaultButton="lnkSalvar">
        <div class="box-typical box-typical-padding">
            <h5 class="m-t-lg with-border">Cadastro de Conta</h5>
            <div class="row">
                <div class="col-md-2 col-sm-4 col-xs-12">
                    <label class="form-control-label">Código</label>
                    <asp:TextBox readonly disabled runat="server" ID="txtCodigo" CssClass="form-control" Text="AUTOMATICO"></asp:TextBox>
                </div>
                <div class="col-md-10 col-sm-8 col-xs-12">
                    <label class="form-control-label">Descrição</label>
                    <asp:TextBox runat="server" ID="txtDescricao" MaxLength="250" CssClass="form-control primeiro"></asp:TextBox>
                </div>
                    
                <div class="col-md-2 col-sm-2 col-xs-12">
                    <label title="Saldo inicial da conta.">Saldo</label>
                    <asp:TextBox runat="server" ID="txtSaldoinicial" CssClass="form-control money-mask"></asp:TextBox>
                </div>
                <div class="col-md-2 col-sm-2 col-xs-12">
                    <label class="form-control-label">Agência</label>
                    <asp:TextBox runat="server" ID="txtAgencia" MaxLength="250" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-3 col-sm-3 col-xs-12">
                    <label class="form-control-label">Conta</label>
                    <asp:TextBox runat="server" ID="txtConta" MaxLength="250" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-3 col-sm-3 col-xs-12">
                    <label class="form-control-label">Tipo</label>
                    <asp:DropDownList runat="server" ID="ddlTipo" CssClass="form-control dropdown"></asp:DropDownList>
                </div>
                <div class="col-md-1 col-sm-1 col-xs-12">
                    <label class="form-control-label">Principal</label>
                    <asp:CheckBox runat="server" ID="cbxPrincipal" CssClass="" />
                </div>

                <div class="col-md-6 col-sm-6 col-xs-12">
                    <label class="form-control-label">Nome do titular</label>
                    <asp:TextBox runat="server" ID="txtTitularNome" MaxLength="250" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <label class="form-control-label">Documento do titular</label>
                    <asp:TextBox runat="server" ID="txtTitularDocumento" MaxLength="250" CssClass="form-control"></asp:TextBox>
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