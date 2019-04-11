<%@ Page Title="" Language="C#" MasterPageFile="~/_MLogado.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Site.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cHeaderScripts" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cConteudo" runat="server">
    <div class="row">
        <div class="col-xl-12">
	        <div class="row">
                <asp:UpdatePanel runat="server" ID="upnlResumos">
                    <ContentTemplate>
	                    <div class="col-sm-3">
	                        <article class="statistic-box red">
	                            <div>
	                                <div class="number"><asp:Literal runat="server" ID="ltrTotalAnimais"></asp:Literal></div>
	                                <div class="caption"><div>Animais</div></div>
	                            </div>
	                        </article>
	                    </div><!--.col-->
	                    <div class="col-sm-3">
	                        <article class="statistic-box purple">
	                            <div>
	                                <div class="number"><asp:Literal runat="server" ID="ltrTotalAnimaisTratamento"></asp:Literal></div>
	                                <div class="caption"><div>Em tratamento</div></div>
	                                <div class="percent" style="top:15px!important;"><p><asp:Literal runat="server" ID="ltrPercAnimaisTratamento"></asp:Literal>%</p></div>
	                            </div>
	                        </article>
	                    </div><!--.col-->
	                    <div class="col-sm-3">
	                        <article class="statistic-box yellow">
	                            <div>
	                                <div class="number"><asp:Literal runat="server" ID="ltrUltimosAnimaisCadastrados"></asp:Literal></div>
	                                <div class="caption"><div>Novos nos útlimos 7 dias</span></div></div>
	                            </div>
	                        </article>
	                    </div><!--.col-->
	                    <div class="col-sm-3">
	                        <article class="statistic-box green">
	                            <div>
	                                <div class="number"><asp:Literal runat="server" ID="ltrMedicamentosDoDia"></asp:Literal></div>
	                                <div class="caption"><div>Medicamentos pendentes</div></div>
	                            </div>
	                        </article>
	                    </div><!--.col-->
                    </ContentTemplate>
                </asp:UpdatePanel>
	        </div><!--.row-->
	    </div><!--.col-->
    </div>

	<div class="row">
        <div class="col-md-3">
            <asp:LinkButton runat="server" ID="lnkImprimirAgenda" OnClick="lnkImprimirAgenda_Click">
                <article class="statistic-box yellow" style="height:50px;">
	                <div><div class="caption"><div><i class="fa fa-print"> </i> Imprimir Medicamentos</div></div></div>
	            </article>
            </asp:LinkButton>
        </div>
        
        <div class="col-md-3">
            <asp:LinkButton runat="server" ID="lnkImprimirListaCompras" OnClick="lnkImprimirListaCompras_Click">
                <article class="statistic-box green" style="height:50px;">
	                <div><div class="caption"><div><i class="fa fa-print"> </i> Imprimir Lista de Compras</div></div></div>
	            </article>
            </asp:LinkButton>
        </div>
    </div>

    <div class="row">
        <div class="col-xl-6 dahsboard-column">
            <asp:UpdatePanel runat="server" ID="upnlMedPendente">
                <ContentTemplate>
                    <asp:Repeater runat="server" ID="rptMedicamentosPendentes">
                        <HeaderTemplate>
	                            <section class="box-typical box-typical-dashboard panel panel-default scrollable">
	                                <header class="box-typical-header panel-heading"><h3 class="panel-title">Medicamentos Pendentes</h3></header>
	                                <div class="box-typical-body panel-body">
	                                    <table class="tbl-typical">
	                                        <tr>
                                                <th align="center"><div></div></th>
	                                            <th><div>Animal</div></th>
                                                <th><div>Medicamento</div></th>
	                                            <th align="center"><div>Dose#</div></th>
                                                <th align="center"><div>Dia</div></th>
	                                        </tr>
                        </HeaderTemplate>
                        <FooterTemplate></table></div><!--.box-typical-body--></section><!--.box-typical-dashboard--></FooterTemplate>
                        <ItemTemplate>
                            <tr>
                                <td><asp:LinkButton Enabled='<%#Eval("Liberado") %>' CommandName="ConfirmarMedicamento" CommandArgument='<%#Eval("Id") %>' OnCommand="lnkConfirmar_Command" runat="server" ID="lnkConfirmar" CssClass='<%#Convert.ToBoolean(Eval("Liberado")) ? "form-control label label-success" : "form-control label" %>'><i style="color:white!important" class="fa fa-check-circle"></i></asp:LinkButton></td>
	                            <td><%#Eval("AnimalMedicado.SNome") %></td>
	                            <td><%#Eval("Medicamento.SNome") %></td>
	                            <td class="color-blue-grey" nowrap align="center"><span class="semibold"><%#Eval("IDose") %></span></td>
                                <td><%#Convert.ToDateTime(Eval("DtmPrevisao").ToString()) < DateTime.Today ? String.Format("<span class='label label-danger'>{0}</span>", Convert.ToDateTime(Eval("DtmPrevisao").ToString()).ToString("dd/MM")) : Convert.ToDateTime(Eval("DtmPrevisao").ToString()).ToString("dd/MM") %></td>
	                        </tr>
                        </ItemTemplate>
                    </asp:Repeater>

                    <section class="box-typical box-typical-dashboard panel panel-default scrollable">
	                    <header class="box-typical-header panel-heading">
	                        <h3 class="panel-title">Lista Contatos</h3>
	                    </header>
	                    <div class="box-typical-body panel-body">
	                        <div class="contact-row-list">
	                            <asp:Repeater runat="server" ID="rptContatos">
                                    <ItemTemplate>
                                        <article class="contact-row">
	                                        <div class="user-card-row">
	                                            <div class="tbl-row">
	                                                <div class="tbl-cell tbl-cell-photo">
	                                                    <a href="#"><img src="img/avatar-1-32.png" alt=""></a>
	                                                </div>
	                                                <div class="tbl-cell">
	                                                    <p class="user-card-row-name"><a href="#"><%#Eval("SNome") %></a></p>
	                                                    <p class="user-card-row-mail"><a href="#"><%#Eval("PrimeiroContato") %></a></p>
	                                                </div>
	                                            </div>
	                                        </div>
	                                    </article>
                                    </ItemTemplate>
	                            </asp:Repeater>
	                        </div>
	                    </div><!--.box-typical-body-->
	                </section><!--.box-typical-dashboard-->
                </ContentTemplate>
            </asp:UpdatePanel>

            
        </div><!--.col-->

	    <div class="col-xl-6 dahsboard-column">
	        <section class="box-typical box-typical-dashboard panel panel-default scrollable">
	            <header class="box-typical-header panel-heading">
	                <h3 class="panel-title">Lista de Compras</h3>
	            </header>
                
                <asp:UpdatePanel runat="server" ID="upnlListaComprasCamposInserir">
                    <ContentTemplate>
                        <div class="row">
                            <asp:HiddenField runat="server" ID="txtPedidoCompraAtivo" />
                            <div class="col-md-6 col-sm-5 col-xs-11" style="margin-left:10px;">
                                <label>Produto</label>
                                <asp:DropDownList runat="server" ID="ddlProduto" CssClass="select2"></asp:DropDownList>
                            </div>

                            <div class="col-md-3 col-sm-4 col-xs-7" style="margin-left:10px;">
                                <label>Qtd</label>
                                <asp:TextBox runat="server" ID="txtProdutoQuantidade" CssClass="form-control numero"></asp:TextBox>
                            </div>
                            <div class="col-md-1 col-sm-2 col-xs-4">
                                <label>&nbsp;</label>
                                <asp:Button runat="server" ID="btnIncluirProduto" OnClick="btnIncluirProduto_Click" Text="+" CssClass="btn btn-success" />
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                

	                    
                <asp:UpdatePanel runat="server" ID="upnlListaCompras">
                    <ContentTemplate>
                        <asp:Repeater runat="server" ID="rptComprar">
                            <HeaderTemplate>
                                <div class="box-typical-body panel-body">
                                    <div class="contact-row-list">
                                        <table class="tbl-typical">
	                                        <tr>
	                                            <th style="width:80px"><div>&nbsp;</div></th>
	                                            <th><div>Produto</div></th>
	                                            <th align="center"><div>Qtd.</div></th>
	                                        </tr>
                            </HeaderTemplate>
                            <FooterTemplate></table></div></div></FooterTemplate>
                            <ItemTemplate>
	                                <tr>
	                                    <%--<td><img width="60px" id="img1" runat="server" src='<%#String.IsNullOrEmpty(Eval("Produto.SPathFotoCapa").ToString()) ? "~/img/avatar-1-32.png" : Eval("Produto.SPathFotoCapa", "~/Arquivos/Produtos/{0}").ToString() %>' alt=""></td>--%>
                                        <td><asp:Image Width="50px" runat="server" ID="img" ImageUrl='<%#String.IsNullOrEmpty(Eval("Produto.SPathFotoCapa").ToString()) ? "~/img/avatar-1-32.png" : Eval("Produto.SPathFotoCapa", "~/Arquivos/Produtos/{0}").ToString() %>' /></td>
	                                    <td><%#Eval("Produto.SNome") %></td>
	                                    <td nowrap align="center"><%#Eval("IQuantidade") %></td>
	                                </tr>
                            </ItemTemplate>
	                    </asp:Repeater>

                        <asp:Panel runat="server" CssClass="box-typical-body panel-body" ID="pnlListaCompra">
                            <table class="tbl-typical">
	                            <tr>
	                                <td align="center">Nenhum produto na lista!</td>
	                            </tr>
	                        </table>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>

                
	        </section><!--.box-typical-dashboard-->
<%--	        <section class="box-typical box-typical-dashboard panel panel-default scrollable">
	            <header class="box-typical-header panel-heading">
	                <h3 class="panel-title">Novos </h3>
	            </header>
	            <div class="box-typical-body panel-body">
	                <table class="tbl-typical">
	                    <tr>
	                        <th><div>Status</div></th>
	                        <th><div>Subject</div></th>
	                        <th align="center"><div>Department</div></th>
	                        <th align="center"><div>Date</div></th>
	                    </tr>
	                    <tr>
	                        <td>
	                            <span class="label label-success">Open</span>
	                        </td>
	                        <td>Website down for one week</td>
	                        <td align="center">Support</td>
	                        <td nowrap align="center"><span class="semibold">Today</span> 8:30</td>
	                    </tr>
	                    <tr>
	                        <td>
	                            <span class="label label-success">Open</span>
	                        </td>
	                        <td>Restoring default settings</td>
	                        <td align="center">Support</td>
	                        <td nowrap align="center"><span class="semibold">Today</span> 16:30</td>
	                    </tr>
	                    <tr>
	                        <td>
	                            <span class="label label-warning">Progress</span>
	                        </td>
	                        <td>Loosing control on server</td>
	                        <td align="center">Support</td>
	                        <td nowrap align="center"><span class="semibold">Yesterday</span></td>
	                    </tr>
	                    <tr>
	                        <td>
	                            <span class="label label-danger">Closed</span>
	                        </td>
	                        <td>Authorizations keys</td>
	                        <td align="center">Support</td>
	                        <td nowrap align="center">23th May</td>
	                    </tr>
	                </table>
	            </div><!--.box-typical-body-->
	        </section><!--.box-typical-dashboard-->--%>
	    </div><!--.col-->
	</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cFooterScripts" runat="server">
</asp:Content>