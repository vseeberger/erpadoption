<%@ Page Title="" Language="C#" MasterPageFile="~/_MLogado.master" AutoEventWireup="true" CodeBehind="Executar.aspx.cs" Inherits="Site.Executar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cHeaderScripts" runat="server">
    <link rel="stylesheet" href="css/lib/datatables-net/datatables.min.css">
    <link rel="stylesheet" href="css/separate/vendor/datatables-net.min.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cConteudo" runat="server">
    <div class="box-typical box-typical-padding">
        <h5 class="m-t-lg with-border">Executar Comandos no banco de dados</h5>
        <div class="row">
            <div class="col-md-12 col-sm-12 col-xs-12">
                <asp:TextBox runat="server" ID="txtComando" TextMode="MultiLine" Rows="6" CssClass="form-control primeiro"></asp:TextBox>
            </div>
        </div>

        <br /><div class="clearfix"></div>
        <div class="row">
            <div class="col-md-2 col-sm-6 col-xs-12"><asp:LinkButton runat="server" CssClass="form-control btn btn-danger-outline swal-btn-basic" ID="lnkExecutar" OnClick="lnkExecutar_Click"><i class="fa fa-flash"></i> Executar</asp:LinkButton></div>
        </div>
    </div>

    <div class="box-typical box-typical-padding">
        <asp:GridView runat="server" ID="gdv" AutoGenerateColumns="true" GridLines="None" CssClass="tabelasdinamicas display table table-striped table-bordered table-responsive">
            <EmptyDataTemplate><center><p>Nenhum resultado...</p></center></EmptyDataTemplate>
        </asp:GridView>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cFooterScripts" runat="server">
</asp:Content>