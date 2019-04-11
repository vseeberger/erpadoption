<%@ Page Title="" Language="C#" MasterPageFile="~/_MLogado.master" AutoEventWireup="true" CodeBehind="configuracoes.aspx.cs" Inherits="Site.configuracoes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cHeaderScripts" runat="server">
    <link rel="stylesheet" href="css/separate/vendor/tags_editor.min.css">
    <link rel="stylesheet" href="css/separate/vendor/bootstrap-select/bootstrap-select.min.css">
    <link rel="stylesheet" href="css/separate/vendor/select2.min.css">
    <link rel="stylesheet" href="css/separate/vendor/bootstrap-daterangepicker.min.css">
    <link rel="stylesheet" href="css/lib/clockpicker/bootstrap-clockpicker.min.css">
    <link rel="stylesheet" href="css/separate/vendor/fancybox.min.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cConteudo" runat="server">
    <%--<asp:ScriptManager runat="server" ID="srcM"></asp:ScriptManager>--%>
    <asp:HiddenField runat="server" ID="hdfID" />

    <div class="box-typical box-typical-padding">
        <h5 class="m-t-lg with-border">Configurações do Sistema</h5>
        <div class="row">
            <div class="col-md-5 col-sm-8 col-xs-12">
                <label class="form-control-label">Valor Diária</label>
                <asp:TextBox runat="server" ID="txtValorDiaria" CssClass="form-control money-mask"></asp:TextBox>
            </div>

            <div class="col-md-2 col-sm-2 col-xs-12">
                <label>Dia pagto.</label>
                <asp:TextBox runat="server" ID="txtDiaPagamento" CssClass="form-control numero"></asp:TextBox>
            </div>
        </div>
        
        <div class="row">
            <div class="col-md-5 col-sm-8 col-xs-12">
                <label class="form-control-label">Qtd. dias contato - Adoção</label>
                <asp:TextBox runat="server" ID="txtQuantDiasParaContato" CssClass="form-control numero"></asp:TextBox>
            </div>

        </div>

        <div class="row">
            <div class="col-xl-12"><label>Criar pastas</label></div>
            <div class="col-md-2 col-sm-4 col-xs-4"><asp:Button runat="server" OnClick="btnPastaProduto_Click" ID="btnPastaProduto" Text="Produto" /></div>
            <div class="col-md-2 col-sm-4 col-xs-4"><asp:Button runat="server" OnClick="btnPastaAnimais_Click" ID="btnPastaAnimais" Text="Animais" /></div>
            <div class="col-md-2 col-sm-4 col-xs-4"><asp:Button runat="server" OnClick="btnPastaExames_Click" ID="btnPastaExames" Text="Exames" /></div>
        </div>

        <br /><div class="clearfix"></div>
        <div class="row">
            <div class="col-md-2 col-sm-6 col-xs-12"><asp:LinkButton OnClick="lnkSalvar_Click" runat="server" CssClass="form-control btn btn-success swal-btn-basic" ID="lnkSalvar"><i class="fa fa-check"></i> Salvar</asp:LinkButton></div>
            <div class="col-md-2 col-sm-6 col-xs-12"><asp:LinkButton OnClick="lnkCancelar_Click" runat="server" CssClass="form-control btn btn-danger-outline swal-btn-basic" ID="lnkCancelar"><i class="fa fa-close"></i> Cancelar</asp:LinkButton></div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cFooterScripts" runat="server">
</asp:Content>