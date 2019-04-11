<%@ Page Title="" Language="C#" MasterPageFile="~/_MLogado.master" AutoEventWireup="true" CodeBehind="cadastro_de_cargo_cbo.aspx.cs" Inherits="Site.cadastro_de_cargo_cbo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cHeaderScripts" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cConteudo" runat="server">
    <asp:Panel runat="server" ID="pnl01" DefaultButton="lnkSalvar">
        <div class="box-typical box-typical-padding">
            <h5 class="m-t-lg with-border">Cadastro de CBO</h5>
            <div class="row">
                <div class="col-md-2 col-sm-4 col-xs-12">
                    <label class="form-control-label">Código</label>
                    <asp:TextBox readonly disabled runat="server" ID="txtCodigo" CssClass="form-control" Text="AUTOMATICO"></asp:TextBox>
                </div>
                    
                <div class="col-md-10 col-sm-8 col-xs-12">
                    <label class="form-control-label">Descrição</label>
                    <asp:TextBox runat="server" ID="txtNome" MaxLength="250" CssClass="form-control primeiro"></asp:TextBox>
                </div>
            </div>

            <div class="row">
                <div class="col-md-3 col-sm-4 col-xs-12">
                    <label title="código do cbo na tabela de ocupação">CBO</label>
                    <asp:TextBox runat="server" ID="txtCodigoCBO" MaxLength="250" CssClass="form-control" />
                </div>

                <div class="col-md-6 col-sm-4 col-xs-12">
                    <label>Complemento</label>
                    <asp:TextBox runat="server" ID="txtComplemento" MaxLength="250" CssClass="form-control" />
                </div>

                <div class="col-md-3 col-sm-4 col-xs-12">
                    <label>Versão</label>
                    <asp:TextBox runat="server" ID="txtVersao" MaxLength="250" CssClass="form-control" />
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