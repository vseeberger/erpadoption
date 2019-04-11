<%@ Page Title="" Language="C#" MasterPageFile="~/_MLogado.master" AutoEventWireup="true" CodeBehind="Oops.aspx.cs" Inherits="Site.Oops" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cHeaderScripts" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cConteudo" runat="server">
    <div class="jumbotron">
        <div class="container">
            <h1>Oops!</h1>
            <p>Algo ocorreu e não foi possível executar a ação.</p>
            <p>Nossa equipe de suporte já foi notificada e em breve esta dificuldade não irá ocorrer!</p>
            <p><asp:LinkButton role="button" PostBackUrl="~/Dashboard" runat="server" CssClass="btn btn-primary btn-lg" ID="btnVoltar"> Voltar para o início</asp:LinkButton></p>
            <p>&nbsp;</p>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cFooterScripts" runat="server">
</asp:Content>