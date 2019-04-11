<%@ Page Title="" Language="C#" MasterPageFile="~/_MLogado.master" AutoEventWireup="true" CodeBehind="pesquisa_de_usuarios.aspx.cs" Inherits="Site.pesquisa_de_usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cHeaderScripts" runat="server">
<link rel="stylesheet" href="css/lib/datatables-net/datatables.min.css">
    <link rel="stylesheet" href="css/separate/vendor/datatables-net.min.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cConteudo" runat="server">
    <header class="section-header">
		<div class="tbl">
			<div class="tbl-row">
				<div class="col-md-10 col-sm-8 col-xs-12 tbl-cell">
					<h2>Usuários</h2>
				</div>
                <div class="col-md-2 col-sm-4 col-xs-12 pull-right"><asp:Button runat="server" ID="btnAdd" OnClick="btnAdd_Click" CssClass="form-control btn btn-rounded" Text="Inserir" /></div>
			</div>
		</div>
	</header>
    <section class="card">
		<div class="card-block">
            <table class="tabelasdinamicas display table table-striped table-bordered table-responsive" width="100%">
                <thead>
				    <tr>
					    <th>#</th>
					    <th width="100%">Nome</th>
                        <th>Login</th>
					    <th>Cadastro</th>
                        <th> </th>
                        <th> </th>
				    </tr>
				</thead>
                <tbody>
                <asp:Repeater runat="server" ID="rptResultado" OnItemCommand="rptResultado_ItemCommand">
                    <ItemTemplate>
                        <tr>
                            <td nowrap><%#Eval("SId") %></td>
                            <td><%#Eval("SNome") %></td>
                            <td nowrap><%#Eval("SLogin") %></td>
                            <td><%#Convert.ToDateTime(Eval("DtmCadastro")).ToString("dd/MM/yyyy") %></td>
                            <td><asp:LinkButton runat="server" CommandArgument='<%#Eval("Id") %>' CommandName="Alterar" ID="lnkAlterar" CssClass="btn"><i class="glyphicon glyphicon-edit"></i></asp:LinkButton></td>
                            <td><asp:LinkButton runat="server" OnClientClick="return fnConfirmar();" CommandArgument='<%#Eval("Id") %>' CommandName="Remover" ID="lnkRemover" CssClass="btn"><i class="glyphicon glyphicon-remove"></i></asp:LinkButton></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Panel runat="server" ID="pnlVazio"><tr><td colspan="6" align="center">Nenhum registro encontrado.</td></tr></asp:Panel>
                </tbody>
            </table>
        </div>
    </section>
    <script> $('#example, .tabelasdinamicas').DataTable();</script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cFooterScripts" runat="server">
</asp:Content>