<%@ Page Title="" Language="C#" MasterPageFile="~/_MLogado.master" AutoEventWireup="true" CodeBehind="pesquisa_de_produtos.aspx.cs" Inherits="Site.pesquisa_de_produtos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cHeaderScripts" runat="server">
    <link rel="stylesheet" href="css/lib/datatables-net/datatables.min.css">
    <link rel="stylesheet" href="css/separate/vendor/datatables-net.min.css">
    <%--<style>
        .table-responsive>.fixed-column {
            position: absolute;
            display: inline-block;
            width: auto;
            border-right: 1px solid #ddd;
        }
    </style>--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cConteudo" runat="server">
    <header class="section-header">
		<div class="tbl">
			<div class="tbl-row">
                <div class="col-md-10 col-sm-8 col-xs-12 tbl-cell">
					<h2>Produtos</h2>
					<div class="subtitle">Lista com os produtos / medicamentos / vacinas cadastrados</div>
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
                        <asp:RadioButton runat="server" Text="Todos" Checked="True" ID="rbtTiposTodos" GroupName="Tipos" CssClass="radio-inline" />
                        <asp:RadioButton runat="server" Text="Consumo" ID="rbtTiposConsumo" GroupName="Tipos" CssClass="radio-inline" />
                        <asp:RadioButton runat="server" Text="Mercadoria" ID="rbtTiposMercadoria" GroupName="Tipos" CssClass="radio-inline" />
                        <asp:RadioButton runat="server" Text="Serviço" ID="rbtTiposServico" GroupName="Tipos" CssClass="radio-inline" />
                        <asp:RadioButton runat="server" Text="Imobilizado" ID="rbtTiposImobilizado" GroupName="Tipos" CssClass="radio-inline" />
                    </div>
                    <div class="col-md-12 col-sm-12 col-xs-12">
                        <asp:RadioButton runat="server" Text="Tudo" Checked="True" ID="rbtTipos2Tudo" GroupName="Tipos2" CssClass="radio-inline" />
                        <asp:RadioButton runat="server" Text="É Medicamento" ID="rbtTipos2Medicamento" GroupName="Tipos2" CssClass="radio-inline" />
                        <asp:RadioButton runat="server" Text="É Vacina" ID="rbtTipos2Vacina" GroupName="Tipos2" CssClass="radio-inline" />
                        <asp:RadioButton runat="server" Text="NÃO é Vacina" ID="rbtTipos2NaoVacina" GroupName="Tipos2" CssClass="radio-inline" />
                        <asp:RadioButton runat="server" Text="NÃO é Medicamento" ID="rbtTipos2NaoMedicamento" GroupName="Tipos2" CssClass="radio-inline" />
                    </div>
                </div>
            
                <div class="row">
                    <div class="col-md-2 col-sm-4 col-xs-12">
                        <label>Qtd. registros</label>
                        <asp:TextBox runat="server" ID="txtQuantidadeRegistros" Text="100" CssClass="form-control numero"></asp:TextBox>
                    </div>
                    <div class="pull-right">
                        <label>&nbsp;</label>
                        <asp:UpdatePanel runat="server" ID="upnl01"><ContentTemplate><asp:LinkButton runat="server" ID="lnkCarregar" CssClass="btn btn-info" OnClick="lnkCarregar_Click"><i class="fa fa-search"></i> Pesquisar</asp:LinkButton></ContentTemplate></asp:UpdatePanel>
                    </div>
                </div>
            </asp:Panel>
        </div>
    </section>

    <section class="card">
		<div class="card-block">
            <asp:UpdatePanel runat="server" ID="upnlResultados" UpdateMode="Always">
                <ContentTemplate>
                    <table class="tabelasdinamicas display table table-striped table-bordered table-responsive" width="100%">
                        <thead>
				            <tr>
					            <th>#</th>
                                <th>Referência</th>
                                <th>Tipo</th>
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
                                        <td><%#Eval("SReferencia") %></td>
                                        <td><%#Eval("STipoProduto") %></td>
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
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </section>
    <script> $('#example, .tabelasdinamicas').DataTable();</script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cFooterScripts" runat="server">
</asp:Content>