<%@ Page Title="" Language="C#" MasterPageFile="~/_MLogar.master" AutoEventWireup="true" CodeBehind="Logar.aspx.cs" Inherits="Site.Logar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cConteudo" runat="server">
    <asp:UpdatePanel runat="server" id="upnl01" UpdateMode="Always" RenderMode="Inline">
        <ContentTemplate>
            <div class="page-center">
                <div class="page-center-in">
                    <div class="container-fluid">
                        <asp:Panel CssClass="sign-box" runat="server" ID="pnl1" DefaultButton="btnLogar">
                            <div class="sign-avatar">
                                <img src="img/avatar-sign.png" alt="">
                            </div>
                            <header class="sign-title">Entrar</header>
                            <div class="form-group"><asp:TextBox runat="server" ID="txtLogin" CssClass="form-control primeiro" placeholder="Login"></asp:TextBox></div>
                            <div class="form-group"><asp:TextBox runat="server" ID="txtSenha" TextMode="Password" CssClass="form-control" placeholder="Senha"></asp:TextBox></div>
                            <div class="form-group">
                                <div class="checkbox float-left"><asp:CheckBox Enabled="false" runat="server" ID="cbxContinuarConectado" Text="Continuar conectado" /></div>
                                <div class="float-right reset"><asp:LinkButton runat="server" ID="lnkResetar" PostBackUrl="~/ResetarSenha.aspx">Resetar Senha</asp:LinkButton></div>
                            </div>
                            <asp:Button runat="server" ID="btnLogar" Text="Entrar" OnClick="btnLogar_Click" CssClass="btn btn-primary swal-btn-basic" />
                            <%--<p class="sign-note">© 2016 Todos os direitos reservados. PetRescue - Para controle de animais</p>--%>
                            <p class="sign-note">© 2016 Todos os direitos reservados.</p>
                            <p class="sign-note" style="font-size:12px!important;"><asp:Literal runat="server" ID="ltrPing"></asp:Literal></p>
                            <p class="sign-note"><asp:Literal runat="server" ID="ltrAcessibilidade"></asp:Literal></p>
                        </asp:Panel>
                    </div>
                </div>
            </div><!--.page-center-->
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>