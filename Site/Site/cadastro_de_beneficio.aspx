<%@ Page Title="" Language="C#" MasterPageFile="~/_MLogado.master" AutoEventWireup="true" CodeBehind="cadastro_de_beneficio.aspx.cs" Inherits="Site.cadastro_de_beneficio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cHeaderScripts" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cConteudo" runat="server">
    <asp:Panel runat="server" ID="pnl01" DefaultButton="lnkSalvar">
        <div class="box-typical box-typical-padding">
            <h5 class="m-t-lg with-border">Cadastro de Benefício/Desconto</h5>
            <div class="row">
                <div class="col-md-2 col-sm-4 col-xs-12">
                    <label class="form-control-label">Código</label>
                    <asp:TextBox readonly disabled runat="server" ID="txtCodigo" CssClass="form-control" Text="AUTOMATICO"></asp:TextBox>
                </div>
                    
                <div class="col-md-8 col-sm-8 col-xs-12">
                    <label class="form-control-label">Descrição</label>
                    <asp:TextBox runat="server" ID="txtNome" MaxLength="250" CssClass="form-control primeiro"></asp:TextBox>
                </div>
            </div>

            <div class="row">
                <div class="col-md-3 col-sm-6 col-xs-12">
                    <label title="valor máximo que pode ser descontado.">Desconto máx.</label>
                    <div class="input-group">
                        <span class="input-group-addon "><i class="fa fa-money"></i></span>
                        <asp:TextBox runat="server" ID="txtDescontoMaximo" CssClass="form-control money-mask" />
                    </div>
                </div>

                <div class="col-md-3 col-sm-6 col-xs-12">
                    <label title="percentual de desconto na folha salarial">Perc. Desconto</label>
                    <div class="input-group">
                        <span class="input-group-addon "><i class="fa fa-percent"></i></span>
                        <asp:TextBox runat="server" ID="txtPercentualDesconto" CssClass="form-control perc-mask" />
                    </div>
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