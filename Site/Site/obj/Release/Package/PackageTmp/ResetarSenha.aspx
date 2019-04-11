<%@ Page Title="" Language="C#" MasterPageFile="~/_MLogar.master" AutoEventWireup="true" CodeBehind="ResetarSenha.aspx.cs" Inherits="Site.ResetarSenha" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cConteudo" runat="server">
    <div class="page-center">
        <div class="page-center-in">
            <div class="container-fluid">
                <asp:Panel runat="server" ID="pnl1" class="sign-box reset-password-box" DefaultButton="btnResetar">
                    <header class="sign-title">Resetar Senha</header>
                    <div class="form-group"><asp:TextBox runat="server" CssClass="form-control" ID="txtLogin" placeholder="Informe o Login de acesso"></asp:TextBox></div>
                    <asp:Button runat="server" ID="btnResetar" Text="Resetar" CssClass="btn btn-rounded" OnClick="btnResetar_Click" />
                    ou <asp:LinkButton runat="server" ID="lnkLogar" PostBackUrl="~/Logar.aspx">Entrar</asp:LinkButton>
                </asp:Panel>
            </div>
        </div>
    </div><!--.page-center-->
</asp:Content>