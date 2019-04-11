<%@ Page Title="" Language="C#" MasterPageFile="~/_MLogado.master" AutoEventWireup="true" CodeBehind="pesquisa_de_animais.aspx.cs" Inherits="Site.pesquisa_de_animais" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cHeaderScripts" runat="server">
<link rel="stylesheet" href="css/lib/datatables-net/datatables.min.css">
    <link rel="stylesheet" href="css/separate/vendor/datatables-net.min.css">
    <style>
        .inativos { color:red!important; font-weight:bold;}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cConteudo" runat="server">
    <header class="section-header">
		<div class="tbl">
			<div class="tbl-row">
				<div class="col-md-10 col-sm-8 col-xs-12 tbl-cell">
					<h2>Animais</h2>
				</div>
                <div class="col-md-2 col-sm-4 col-xs-12 pull-right"><asp:Button runat="server" ID="btnAdd" CssClass="form-control btn btn-rounded" Text="Inserir" OnClick="btnAdd_Click" /></div>
			</div>
		</div>
	</header>
    
     <section class="card">
		<div class="card-block">
            <asp:Panel runat="server" ID="pnlTop" DefaultButton="lnkCarregar">
                <div class="row">
                    <div class="col-md-12 col-sm-12 col-xs-12">
                        <asp:RadioButton runat="server" Text="Todos" ID="rbtStatusTodos" GroupName="Stats" CssClass="radio-inline" />
                        <asp:RadioButton runat="server" Text="Ativos" Checked="True" ID="rbtStatusAtivos" GroupName="Stats" CssClass="radio-inline" />
                        <asp:RadioButton runat="server" Text="Inativos" ID="rbtStatusInativos" GroupName="Stats" CssClass="radio-inline" />
                    </div>
                    <div class="col-md-12 col-sm-12 col-xs-12">
                        <asp:RadioButton runat="server" Text="Todos" ID="rbtSituacaoTodos" GroupName="Situacao" CssClass="radio-inline" />
                        <asp:RadioButton runat="server" Text="Disponíveis" Checked="True" ID="rbtSituacaoDisponiveis" GroupName="Situacao" CssClass="radio-inline" />
                        <asp:RadioButton runat="server" Text="Adotados" ID="rbtSituacaoAdotados" GroupName="Situacao" CssClass="radio-inline" />
                        <asp:RadioButton runat="server" Text="Indisponíveis" ID="rbtSituacaoIndisponiveis" GroupName="Situacao" CssClass="radio-inline" />
                    </div>
                </div>
            
                <div class="row">
                    <div class="col-md-12 col-sm-12 col-xs-12">
                        <label>Padrinho/Responsável</label>
                        <asp:DropDownList runat="server" ID="ddlPadrinhos"></asp:DropDownList>
                    </div>
                </div>

                <div class="row">
                    <div class="pull-right">
                        <label>&nbsp;</label>
                        <asp:LinkButton runat="server" ID="lnkCarregar" CssClass="btn btn-info" OnClick="lnkCarregar_Click"><i class="fa fa-search"></i> Pesquisar</asp:LinkButton>
                    </div>
                </div>
            </asp:Panel>
        </div>
    </section>

    <section class="card">
		<div class="card-block">
            <table class="tabelasdinamicas display table table-striped table-bordered table-responsive" width="100%">
                <thead>
				    <tr>
					    <th>#</th>
					    <th width="100%">Nome</th>
                        <th>Espécie</th>
                        <th>Raça</th>
                        <th>Porte</th>
                        <th>Situação</th>
					    <th>Cadastro</th>
                        <th> </th>
                        <th> </th>
				    </tr>
				</thead>
                <tbody>
                <asp:Repeater runat="server" ID="rptResultado" OnItemCommand="rptResultado_ItemCommand">
                    <ItemTemplate>
                        <tr>
                            <td <%#!Convert.ToBoolean(Eval("Status").ToString()) ? "class='inativos'" : ""%>><%#Convert.ToInt32(Eval("Id")).ToString("00000") %></td>
                            <td <%#!Convert.ToBoolean(Eval("Status").ToString()) ? "class='inativos'" : ""%>><%#Eval("SNome") %></td>
                            <td <%#!Convert.ToBoolean(Eval("Status").ToString()) ? "class='inativos'" : ""%>><%#Eval("Especie") == null ? "-" : Eval("Especie.SDescricao") %></td>
                            <td <%#!Convert.ToBoolean(Eval("Status").ToString()) ? "class='inativos'" : ""%>><%#Eval("Raca") == null ? "-" : Eval("Raca.SDescricao") %></td>
                            <td <%#!Convert.ToBoolean(Eval("Status").ToString()) ? "class='inativos'" : ""%>><%#Eval("Porte") == null ? "-" : Eval("Porte.SDescricao") %></td>
                            <td <%#!Convert.ToBoolean(Eval("Status").ToString()) ? "class='inativos'" : ""%>><%#Eval("Situacao") == null ? "-" : Eval("Situacao.SDescricao") %></td>
                            <td <%#!Convert.ToBoolean(Eval("Status").ToString()) ? "class='inativos'" : ""%>><%#Convert.ToDateTime(Eval("DtmCadastro")).ToString("dd/MM/yyyy") %></td>
                            <td><asp:LinkButton runat="server" CommandArgument='<%#Eval("Id") %>' CommandName="Alterar" ID="lnkAlterar" CssClass="btn"><i class="glyphicon glyphicon-edit"></i></asp:LinkButton></td>
                            <td><asp:LinkButton runat="server" CommandArgument='<%#Eval("Id") %>' CommandName="Remover" ID="lnkRemover" OnClientClick="return fnConfirmar();" CssClass="btn"><i class="glyphicon glyphicon-remove"></i></asp:LinkButton></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Panel runat="server" ID="pnlVazio"><tr><td colspan="9" align="center">Nenhum registro encontrado.</td></tr></asp:Panel>
                </tbody>
            </table>
        </div>
    </section>
    <script> $('#example, .tabelasdinamicas').DataTable();</script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cFooterScripts" runat="server">
</asp:Content>