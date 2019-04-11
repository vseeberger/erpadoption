<%@ Page Title="" Language="C#" MasterPageFile="~/_MLogado.master" AutoEventWireup="true" CodeBehind="pesquisa_de_adocoes.aspx.cs" Inherits="Site.pesquisa_de_adocoes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cHeaderScripts" runat="server">
    <link rel="stylesheet" href="css/lib/datatables-net/datatables.min.css">
    <link rel="stylesheet" href="css/separate/vendor/datatables-net.min.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cConteudo" runat="server">
    <header class="section-header">
		<div class="tbl">
			<div class="tbl-row">
                <div class="col-md-10 col-sm-8 col-xs-12 tbl-cell">
					<h2>Adoções</h2>
					<div class="subtitle">Lista com os animais adotados</div>
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
                        <asp:RadioButton runat="server" Text="Todos" Checked="True" ID="rbtTodos" GroupName="Tipos2" CssClass="radio-inline" />
                        <asp:RadioButton runat="server" Text="Disponível" ID="rbtDisponivel" GroupName="Tipos2" CssClass="radio-inline" />
                        <asp:RadioButton runat="server" Text="Em adoção" ID="rbtEmAdocao" GroupName="Tipos2" CssClass="radio-inline" />
                        <asp:RadioButton runat="server" Text="Adotado" ID="rbtAdotado" GroupName="Tipos2" CssClass="radio-inline" />
                        <asp:RadioButton runat="server" Text="Indisponível" ID="rbtIndisponivel" GroupName="Tipos2" CssClass="radio-inline" />
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
                                <th>Animal</th>
                                <th width="100%">Adotante</th>
					            <th>Adotado</th>
                                <th> </th>
                                <th> </th>
                                <th> </th>
				            </tr>
				        </thead>
                        <tbody>
                
                            <asp:Repeater runat="server" ID="rptResultado" OnItemCommand="rptResultado_ItemCommand">
                                <ItemTemplate>
                                    <tr>
                                        <td nowrap="nowrap"><%#Eval("Animal.SNome") %></td>
                                        <td><%#Eval("Adotante.SNome") %></td>
                                        <td><%#Convert.ToDateTime(Eval("DtmAdocao")).ToString("dd/MM/yyyy") %></td>
                                        <td><%#Eval("DtmDevolucao") == null ? "" : "<span style='color:red!important'>Desistiu</span>" %></td>
                                        <td><asp:LinkButton runat="server" CommandArgument='<%#Eval("Id") %>' CommandName="Alterar" ID="lnkAlterar" CssClass="btn"><i class="glyphicon glyphicon-edit"></i></asp:LinkButton></td>
                                        <td><asp:LinkButton runat="server" OnClientClick="return fnConfirmar();" CommandArgument='<%#String.Format("{0},{1}", Eval("Id"), Eval("Animal.Id")) %>' CommandName="Remover" ID="lnkRemover" CssClass="btn"><i class="glyphicon glyphicon-remove"></i></asp:LinkButton></td>
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