<%@ Page Title="" Language="C#" MasterPageFile="~/_MLogado.master" AutoEventWireup="true" CodeBehind="Log.aspx.cs" Inherits="Site.Log" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cHeaderScripts" runat="server">
    <link rel="stylesheet" href="css/separate/vendor/tags_editor.min.css">
    <link rel="stylesheet" href="css/separate/vendor/bootstrap-select/bootstrap-select.min.css">
    <link rel="stylesheet" href="css/separate/vendor/select2.min.css">
    <link rel="stylesheet" href="css/separate/vendor/bootstrap-daterangepicker.min.css">
    <link rel="stylesheet" href="css/lib/clockpicker/bootstrap-clockpicker.min.css">
    <link rel="stylesheet" href="css/separate/vendor/fancybox.min.css">
    <link rel="stylesheet" href="css/lib/datatables-net/datatables.min.css">
    <link rel="stylesheet" href="css/separate/vendor/datatables-net.min.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cConteudo" runat="server">
    <header class="section-header">
		<div class="tbl">
			<div class="tbl-row">
				<div class="col-md-10 col-sm-8 col-xs-12 tbl-cell">
					<h2>Log de Acesso ao sistema</h2>
				</div>
			</div>
		</div>
	</header>
    
    <section class="card">
		<div class="card-block">
            <asp:Panel runat="server" ID="pnlTop" DefaultButton="lnkCarregar">
                <div class="row">
                    <div class="col-md-2 col-sm-4 col-xs-12">
                        <label class="form-control-label"><asp:CheckBox runat="server" ID="cbxPeriodo" CssClass="checkbox" Text="Periodo de:" ToolTip="Utilizar período na pesquisa" /></label>
                        <asp:TextBox runat="server" ID="txtDataInicio" CssClass="form-control daterange3 date-mask"></asp:TextBox>
                    </div>

                    <div class="col-md-2 col-sm-4 col-xs-12">
                        <label class="form-control-label">Até</label>
                        <asp:TextBox runat="server" ID="txtDataFinal" CssClass="form-control daterange3 date-mask"></asp:TextBox>
                    </div>
                </div>
            
                <div class="row">
                    <div class="col-md-2 col-sm-4 col-xs-12">
                        <label>Qtd. registros</label>
                        <asp:TextBox runat="server" ID="txtQuantidadeRegistros" CssClass="form-control numero"></asp:TextBox>
                    </div>
                    <div class="pull-right">
                        <label>&nbsp;</label>
                        <asp:UpdatePanel runat="server" ID="upnl01"><ContentTemplate><asp:LinkButton runat="server" ID="lnkCarregar" OnClick="lnkCarregar_Click" CssClass="btn btn-info"><i class="fa fa-search"></i> Pesquisar</asp:LinkButton></ContentTemplate></asp:UpdatePanel>
                    </div>
                </div>
            </asp:Panel>
        </div>
    </section>

    <section class="card">
		<div class="card-block">
           
            <asp:UpdatePanel runat="server" ID="upnl002">
                <ContentTemplate>
                    <table class="tabelasdinamicas display table table-striped table-bordered" width="100%">
                        <thead>
				            <tr>
                                <th>Usuário</th>
					            <th>Ação</th>
                                <th>Tela</th>
                                <th width="100%">Descrição</th>
                                <th>Data</th>
				            </tr>
				        </thead>
                        <tbody>
                            <asp:Repeater runat="server" ID="rptResultado">
                                <ItemTemplate>
                                    <tr>
                                        <td nowrap="nowrap"><%#Eval("Usuario.SNome") %></td>
                                        <td><%#Eval("Acao.STexto") %></td>
                                        <td><%#Eval("Tela.SNome") %></td>
                                        <td><%#Eval("SDescricao") %></td>
                                        <td nowrap="nowrap"><%#Convert.ToDateTime(Eval("DtmCadastro")).ToString("dd/MM/yyyy HH:mm") %></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                            <asp:Panel runat="server" ID="pnlVazio"><tr><td colspan="7" align="center">Nenhum registro encontrado.</td></tr></asp:Panel>
                        </tbody>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </section>
    <script> $('.tabelasdinamicas').DataTable();</script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cFooterScripts" runat="server">
</asp:Content>