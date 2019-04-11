<%@ Page Title="" Language="C#" MasterPageFile="~/_MPrincipal.Master" AutoEventWireup="true" CodeBehind="Instalador.aspx.cs" Inherits="Site.Instalador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cHeadScripts" runat="server">
    <link rel="stylesheet" href="css/separate/pages/login.min.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cBody" runat="server">
    <body>
        <form id="form2" runat="server">
            <div class="page-center">
                <div class="page-center-in">
                    <div class="container-fluid">
                        <%--<asp:ScriptManager runat="server" ID="srcGeral"></asp:ScriptManager>--%>

                        <h1 class="text-center">PROCESSO DE INSTALAÇÃO DO SISTEMA</h1>

                        <div class="row">
                            <div class="col-md-6 offset-md-3">
                                <asp:Button runat="server" Height="80px" Width="100%" ID="btnIniciar" Text="Iniciar" CssClass="btn jumbotron-fluid" />
                            </div>
                        </div>

                        <hr class="jumbotron-hr" />

                        <div class="row">
                            <div class="col-xl-6 offset-xl-5">
                                <asp:UpdatePanel runat="server" ID="upnlMedPendente">
                                    <ContentTemplate>
                                        <asp:Repeater runat="server" ID="rptAndamento">
                                            <HeaderTemplate>
	                                                <section class="box-typical box-typical-dashboard panel panel-default scrollable">
	                                                    <header class="box-typical-header panel-heading"><h3 class="panel-title panel">ANDAMENTO</h3></header>
	                                                    <div class="box-typical-body panel-body">
	                                                        <table class="tbl-typical">
                                            </HeaderTemplate>
                                            <FooterTemplate>
                                                            </table>
	                                                    </div><!--.box-typical-body-->
	                                                </section><!--.box-typical-dashboard-->
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <tr>
                                                    <td><%#Eval("DataHora") %></td>
	                                                <td><%#Eval("Andamento") %></td>
	                                            </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <script>
                function AlertaErro(texto) {
                    swal({
                        html: true,
                        title: "",
                        text: texto,
                        type: "error",
                        showCancelButton: false,
                        closeOnConfirm: true,
                    });
                }
                function AlertaSucesso(texto) {
                    swal({
                        html: true,
                        title: "",
                        text: texto,
                        type: "success",
                        showCancelButton: false,
                        closeOnConfirm: true,
                    });
                }
                function AlertaAtencao(texto) {
                    swal({
                        html: true,
                        title: "",
                        text: texto,
                        type: "warning",
                        showCancelButton: false,
                        closeOnConfirm: true,
                    });
                }
                function Alerta(texto) {
                    swal({
                        html: true,
                        title: "",
                        text: texto,
                        type: "info",
                        showCancelButton: false,
                        closeOnConfirm: true,
                    });
                }
            </script>
        </form>
    </body>
</asp:Content>