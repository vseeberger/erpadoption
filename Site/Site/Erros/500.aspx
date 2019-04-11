<%@ Page Title="" Language="C#" MasterPageFile="~/_MLogado.master" AutoEventWireup="true" CodeBehind="500.aspx.cs" Inherits="Site._500" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cConteudo" runat="server">
    <div class="jumbotron">
        <div class="container">
            <h1>:(</h1>
            <p>Estamos com alguma dificuldade em nosso servidor.</p>
            <p>De qualquer forma nossa equipe já foi notificada e vamos resolver isso! Obrigado.</p>
            <p><asp:LinkButton role="button" PostBackUrl="~/Dashboard" runat="server" CssClass="btn btn-primary btn-lg" ID="btnVoltar"> Voltar para o início</asp:LinkButton></p>
            <p>&nbsp;</p>
            <p><small>500 - Erro interno do servidor (Internal Server Error)</small></p>
        </div>
    </div>
</asp:Content>