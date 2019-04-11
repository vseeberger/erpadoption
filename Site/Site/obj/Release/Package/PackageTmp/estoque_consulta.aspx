<%@ Page Title="" Language="C#" MasterPageFile="~/_MLogado.master" AutoEventWireup="true" CodeBehind="estoque_consulta.aspx.cs" Inherits="Site.estoque_consulta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cHeaderScripts" runat="server">
    <link rel="stylesheet" href="css/lib/datatables-net/datatables.min.css">
    <link rel="stylesheet" href="css/separate/vendor/datatables-net.min.css">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cConteudo" runat="server">
    <header class="section-header">
		<div class="tbl">
			<div class="tbl-row">
                <div class="col-md-10 col-sm-8 col-xs-12 tbl-cell">
					<h2>Estoque de Produtos</h2>
				</div>
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
                    <div class="col-md-12 col-sm-12 col-xs-12">
                        <asp:RadioButton runat="server" Text="Ambos" ID="rbtStatusTodos" GroupName="Status" CssClass="radio-inline" />
                        <asp:RadioButton runat="server" Text="Produtos Ativos" Checked="true" ID="rbtStatusAtivo" GroupName="Status" CssClass="radio-inline" />
                        <asp:RadioButton runat="server" Text="Produtos Inativos" ID="rbtStatusInativo" GroupName="Status" CssClass="radio-inline" />
                    </div>
                </div>
            
                <div class="row">
                    <div class="col-md-2 col-sm-4 col-xs-12">
                        <label>Qtd. registros</label>
                        <asp:TextBox runat="server" ID="txtQuantidadeRegistros" Text="100" CssClass="form-control numero"></asp:TextBox>
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
            <asp:UpdatePanel runat="server" ID="upnlResultados" UpdateMode="Always">
                <ContentTemplate>
                    <table class="tabelasdinamicas display table table-striped table-bordered table-responsive" width="100%">
                        <thead>
				            <tr>
					            <th>#</th>
                                <th>Referência</th>
                                <th>Tipo</th>
					            <th width="100%">Nome</th>
					            <th>Estoque</th>
                                <th> </th>
				            </tr>
				        </thead>
                        <tbody>
                            <asp:Repeater runat="server" ID="rptResultado">
                                <ItemTemplate>
                                    <%#Decimal.Parse(Eval("Produto.DEstoqueMinimo").ToString()) <= 0 ? "<tr>" : Decimal.Parse(Eval("Produto.DEstoqueMinimo").ToString()) > Decimal.Parse(Eval("DQuantidade").ToString()) ? "<tr class='danger'>" : "<tr>" %>
                                    
                                        <td><%#Convert.ToInt32(Eval("Produto.Id")).ToString("00000") %></td>
                                        <td><%#Eval("Produto.SReferencia") %></td>
                                        <td><%#Eval("Produto.STipoProduto") %></td>
                                        <td><%#Eval("Produto.SNome") %></td>
                                        <td><%#Eval("DQuantidade") %></td>
                                        <td><asp:LinkButton runat="server" ToolTip="Detalhar movimentação do produto" CommandArgument='<%#Eval("Produto.Id") %>' CommandName="Alterar" ID="lnkAlterar" CssClass="btn"><i class="glyphicon glyphicon-cloud-upload"></i></asp:LinkButton></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                            <asp:Panel runat="server" ID="pnlVazio"><tr><td colspan="6" align="center">Nenhum registro encontrado.</td></tr></asp:Panel>
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