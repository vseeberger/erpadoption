<%@ Page Title="" Language="C#" MasterPageFile="~/_MLogado.master" AutoEventWireup="true" CodeBehind="403.aspx.cs" Inherits="Site.Erros._403" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cConteudo" runat="server">
    <div class="jumbotron">
        <div class="container">
            <h1>¬¬'</h1>
            <p>Ei, você não tem permissão de acesso à essa página, certo?</p>
            <p>&nbsp;</p><p>&nbsp;</p>
            <%--<p>Você tem certeza que digitou o endereço certo? Mesmo assim já fomos notificados e vamos verificar se temos que ajustar algo em sua conta!</p>--%>
            <p><asp:LinkButton role="button" PostBackUrl="~/Dashboard" runat="server" CssClass="btn btn-primary btn-lg" ID="btnVoltar"> Voltar para o início</asp:LinkButton></p>
            <p>&nbsp;</p>
            <p><small>403 - Acesso negado (Forbidden)</small></p>
        </div>
    </div>
</asp:Content>