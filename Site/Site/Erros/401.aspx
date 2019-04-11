<%@ Page Title="" Language="C#" MasterPageFile="~/_MLogado.master" AutoEventWireup="true" CodeBehind="401.aspx.cs" Inherits="Site.Erros._401" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cConteudo" runat="server">
    <div class="jumbotron">
        <div class="container">
            <h1>^^!</h1>
            <p>Você precisa de permissão para continuar.</p>
            <p>Você tem certeza que digitou o endereço certo? De qualquer forma nossa equipe já foi notificada e vamos resolver isso! Obrigado.</p>
            <p><asp:LinkButton role="button" PostBackUrl="~/Dashboard" runat="server" CssClass="btn btn-primary btn-lg" ID="btnVoltar"> Voltar para o início</asp:LinkButton></p>
            <p>&nbsp;</p>
            <p><small>401 - Autorização necessária (Authorization Required)</small></p>
        </div>
    </div>
</asp:Content>