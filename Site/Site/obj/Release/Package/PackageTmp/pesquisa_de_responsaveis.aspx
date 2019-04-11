﻿<%@ Page Title="" Language="C#" MasterPageFile="~/_MLogado.master" AutoEventWireup="true" CodeBehind="pesquisa_de_responsaveis.aspx.cs" Inherits="Site.pesquisa_de_responsaveis" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cHeaderScripts" runat="server">
<link rel="stylesheet" href="css/lib/datatables-net/datatables.min.css">
    <link rel="stylesheet" href="css/separate/vendor/datatables-net.min.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cConteudo" runat="server">
    <header class="section-header">
		<div class="tbl">
			<div class="tbl-row">
				<div class="col-md-10 col-sm-8 col-xs-12 tbl-cell">
					<h2>Padrinhos</h2>
					<div class="subtitle">Lista com os padrinhos responsáveis cadastrados.</div>
                    
				</div>
                <div class="col-md-2 col-sm-4 col-xs-12 pull-right"><asp:Button runat="server" ID="btnAdd" CssClass="form-control btn btn-rounded" Text="Inserir" OnClick="btnAdd_Click" /></div>
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
					    <th>Cadastro</th>
                        <th> </th>
                        <th> </th>
				    </tr>
				</thead>
                <tbody>
                <asp:Repeater runat="server" ID="rptResultado" OnItemCommand="rptResultado_ItemCommand">
                    <ItemTemplate>
                        <tr>
                            <td><%#Convert.ToInt32(Eval("Id")).ToString("00000") %></td>
                            <td><%#Eval("SNome") %></td>
                            <td><%#Convert.ToDateTime(Eval("DtmCadastro")).ToString("dd/MM/yyyy") %></td>
                            <td><asp:LinkButton runat="server" CommandArgument='<%#Eval("Id") %>' CommandName="Alterar" ID="lnkAlterar" CssClass="btn"><i class="glyphicon glyphicon-edit"></i></asp:LinkButton></td>
                            <td><asp:LinkButton runat="server" OnClientClick="return fnConfirmar();" CommandArgument='<%#Eval("Id") %>' CommandName="Remover" ID="lnkRemover" CssClass="btn"><i class="glyphicon glyphicon-remove"></i></asp:LinkButton></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Panel runat="server" ID="pnlVazio"><tr><td colspan="7" align="center">Nenhum registro encontrado.</td></tr></asp:Panel>
                </tbody>
            </table>
        </div>
    </section>
    <script> $('#example, .tabelasdinamicas').DataTable();</script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cFooterScripts" runat="server">
</asp:Content>