<%@ Page Title="" Language="C#" MasterPageFile="~/_MLogado.master" AutoEventWireup="true" CodeBehind="400.aspx.cs" Inherits="Site.Erros._400" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cConteudo" runat="server">
    <div class="jumbotron">
        <div class="container">
            <h1>Ahh</h1>
            <p>Algo ocorreu e não foi possível completar sua solicitação.</p>
            <p>Nossa equipe já foi notificada e vamos resolver isso! Obrigado.</p>
            <p><asp:LinkButton role="button" PostBackUrl="~/Dashboard" runat="server" CssClass="btn btn-primary btn-lg" ID="btnVoltar"> Voltar para o início</asp:LinkButton></p>
            <p>&nbsp;</p>
            <p><small> 400 - Solicitação com erro (Bad Request)</small></p>
        </div>
    </div>
</asp:Content>