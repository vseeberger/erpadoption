<%@ Page Title="" Language="C#" MasterPageFile="~/_MLogado.master" AutoEventWireup="true" CodeBehind="404.aspx.cs" Inherits="Site._404" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cConteudo" runat="server">
    <div class="jumbotron">
        <div class="container">
            <h1>:(</h1>
            <p>A página que você tentou acessar não foi localizada.</p>
            <p>Você tem certeza que digitou o endereço certo? De qualquer forma nossa equipe já foi notificada e vamos resolver isso! Obrigado.</p>
            <p><asp:LinkButton role="button" PostBackUrl="~/Dashboard" runat="server" CssClass="btn btn-primary btn-lg" ID="btnVoltar"> Voltar para o início</asp:LinkButton></p>
            <p>&nbsp;</p>
            <p><small>404 : Página não localizada</small></p>
        </div>
    </div>
</asp:Content>