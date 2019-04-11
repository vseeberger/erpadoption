<%@ Page Title="" Language="C#" MasterPageFile="~/_MLogado.master" AutoEventWireup="true" CodeBehind="pesquisa_de_movimentacoes.aspx.cs" Inherits="Site.pesquisa_de_movimentacoes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cHeaderScripts" runat="server">
    <link rel="stylesheet" href="css/separate/vendor/tags_editor.min.css">
    <link rel="stylesheet" href="css/separate/vendor/bootstrap-select/bootstrap-select.min.css">
    <link rel="stylesheet" href="css/separate/vendor/select2.min.css">
    <link rel="stylesheet" href="css/separate/vendor/bootstrap-daterangepicker.min.css">
    <link rel="stylesheet" href="css/lib/clockpicker/bootstrap-clockpicker.min.css">
    <link rel="stylesheet" href="css/separate/vendor/fancybox.min.css">
    <link rel="stylesheet" href="css/separate/pages/tasks.min.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cConteudo" runat="server">
    <style>
        .task-card-title { font-size:12px !important; }
        .task-card-title2 { font-size:11px !important; text-transform:uppercase; font-weight:bold; }
        h1, h2, h3, h4, h5, h6 { padding:10px 0 0 10px; margin:0; }
        .subtitle { padding:0; padding-left:10px; font-size:14px; color:gray; margin:0;}
    </style>
    
    <img id="botaoAbreRecebimento" data-target="#MContasReceber" data-toggle="modal" data-backdrop="static" data-keyboard="false" style="display:none;" />
    <header class="section-header">
		<div class="tbl">
			<div class="tbl-row">
				<div class="col-md-12 col-sm-12 col-xs-12 tbl-cell">
					<h2>Contas a Pagar e Receber</h2>
					<div class="subtitle">Movimentações financeiras</div>
                    <div class="subtitle">
                        <asp:UpdatePanel runat="server" ID="upnlPeriodo">
                            <ContentTemplate>
                                <div class="col-md-2 col-sm-4 col-sm-12">
                                    <label>Período</label>
                                    <div class="form-group">
							            <div class="input-group">
								            <asp:TextBox runat="server" ID="txtPeriodoBusca" CssClass="form-control daterange4"></asp:TextBox>
                                            <asp:LinkButton OnClick="txtPeriodoBusca_TextChanged" runat="server" ID="lnkAtualizarLista" CssClass="input-group-addon"><i class="fa fa-archive"> </i></asp:LinkButton>
							            </div>
						            </div>
                                </div>

                                <div class="col-md-4 col-sm-4 col-xs-12">
                                    <label>&nbsp;</label>
                                    <asp:Button runat="server" ID="btnContaARecebear" OnClick="btnContaAReceber_Click" Text="+ Lançar recebimento" CssClass="form-control btn btn-inline" />
                                </div>

                                <div class="col-md-4 col-sm-4 col-xs-12">
                                    <label>&nbsp;</label>
                                    <asp:Button runat="server" ID="btnLancarDespesa" OnClick="btnLancarDespesa_Click" Text="+ Lançar pagamento" CssClass="form-control btn btn-inline btn-danger" />
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
				</div>
			</div>
		</div>
	</header>

    <div class="box-typical box-typical-padding">
        <section id="Tabs" class="tabs-section">
            <div class="tabs-section-nav tabs-section-nav-icons">
                <div class="tbl">
                    <ul class="nav" role="tablist">
                        <li class="nav-item"><a class="nav-link active" href="#tabs-Recebimentos" role="tab" data-toggle="tab"><span style="border-color:green!important;" class="nav-link-in">Recebimentos <asp:UpdatePanel runat="server" ID="upnlCountReceita" RenderMode="Inline"><ContentTemplate><asp:Literal runat="server" ID="ltrQntRecebimentos" /></ContentTemplate></asp:UpdatePanel></span></a></li>
                        <li class="nav-item"><a class="nav-link" href="#tabs-Fixas" role="tab" data-toggle="tab"><span style="border-color:red!important;" class="nav-link-in">Despesas fixas <asp:UpdatePanel runat="server" ID="upnlCountDespesaFixa" RenderMode="Inline"><ContentTemplate><asp:Literal runat="server" ID="ltrQtdDespesaFixa" /></ContentTemplate></asp:UpdatePanel></span></a></li>
                        <li class="nav-item"><a class="nav-link" href="#tabs-Variaveis" role="tab" data-toggle="tab"><span style="border-color:red!important;" class="nav-link-in">Despesas variáveis <asp:UpdatePanel runat="server" ID="upnlCountDespesaVariavel" RenderMode="Inline"><ContentTemplate><asp:Literal runat="server" ID="ltrQtdDespesaVariavel" /></ContentTemplate></asp:UpdatePanel></span></a></li>
                        <li class="nav-item"><a class="nav-link" href="#tabs-Pessoas" role="tab" data-toggle="tab"><span style="border-color:red!important;" class="nav-link-in">Outras <asp:UpdatePanel runat="server" ID="upnlCountDespesa" RenderMode="Inline"><ContentTemplate><asp:Literal runat="server" ID="ltrQtdDespesas" /></ContentTemplate></asp:UpdatePanel></span></a></li>
                    </ul>
                </div>
            </div><!--.tabs-section-nav-->

            

            <div class="row">
                <div class="tab-content col-md-9 col-sm-9 col-xs-12" style="min-height:200px;">
                    <div role="tabpanel" class="tab-pane fade in active" id="tabs-Recebimentos">
                        <asp:UpdatePanel runat="server" ID="upnlEndereco">
                            <ContentTemplate>
                                <h3>Esta é a sua tabela de receitas</h3>
                                <div class="subtitle"><i>Receita é toda entrada de dinheiro da empresa. Ex.: contratos, mensalidades, rendimentos, comissões ou vendas.</i></div>
                                					
                                <asp:GridView OnRowCommand="_RowCommand" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" runat="server" ID="gdvReceitas" GridLines="None" CssClass="table">
                                    <Columns>
                                        <asp:TemplateField HeaderText=" ">
                                            <ItemTemplate>
                                                <%#Convert.ToDateTime(Eval("DtmPagamentoRecebimento")) == new DateTime() ? "<i title='O pagamento NÃO foi realizado' class='fa fa-question-circle red'> </i>" : (Convert.ToDateTime(Eval("DtmPagamentoRecebimento")).ToString("MM/yyyy") == Convert.ToDateTime(Eval("DtmPrevisao")).ToString("MM/yyyy") ? "<i title='O pagamento foi realizado' class='fa fa-check'> </i>": "<i title='O pagamento foi realizado fora do prazo' class='fa fa-exclamation-triangle red'> </i>") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Núm. Doc.">
                                            <ItemTemplate><%#Eval("SNumeroDocumento") %></ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Referência">
                                            <ItemTemplate><%#Eval("SDescricaoReferencia") %></ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="De quem">
                                            <ItemTemplate><%#Eval("SNomeDeQuemPagou") %></ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Data pagto.">
                                            <ItemTemplate><%#Convert.ToDateTime(Eval("DtmPagamentoRecebimento")).ToString("dd/MM/yyyy") %></ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Competência">
                                            <ItemTemplate><%#Convert.ToDateTime(Eval("DtmCompetencia")).ToString("MM/yyyy") %></ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Valor">
                                            <ItemTemplate>R$ <%#Convert.ToDecimal(Eval("DValor")).ToString("#,0.00") %></ItemTemplate>
                                        </asp:TemplateField>
                                    
                                        <asp:TemplateField>
                                            <ItemTemplate><asp:LinkButton runat="server" CommandArgument='<%#Eval("Id") %>' CommandName="AlterarEntrada" ID="lnkAlterar" CssClass="btn btn-sm"><i class="glyphicon glyphicon-edit"></i></asp:LinkButton></ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate><asp:LinkButton runat="server" CommandArgument='<%#Eval("Id") %>' CommandName="RemoverConta" ID="lnkRemover" CssClass="btn btn-danger btn-sm"><i class="glyphicon glyphicon-remove"></i></asp:LinkButton></ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>

                                    <EmptyDataTemplate>
                                        <center>NENHUMA RECEITA CADASTRADA</center>
                                    </EmptyDataTemplate>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>

                    <div role="tabpanel" class="tab-pane fade in" id="tabs-Fixas">
                        <asp:UpdatePanel runat="server" ID="UpdatePanel2">
                            <ContentTemplate>
                                <h3>Esta é a sua tabela de despesas fixas</h3>
                                <div class="subtitle"><i>Despesas fixas são gastos relativos ao funcionamento da empresa, que não variam conforme a quantidade de vendas. Ex.: conta de água, energia, telefone etc.</i></div>
                                <asp:GridView OnRowCommand="_RowCommand" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" runat="server" ID="gdvDespesaFixa" GridLines="None" CssClass="table">
                                    <Columns>
                                        <asp:TemplateField HeaderText=" ">
                                            <ItemTemplate>
                                                <%#Convert.ToDateTime(Eval("DtmPagamentoRecebimento")) == new DateTime() ? "<i title='O pagamento NÃO foi realizado' class='fa fa-question-circle red'> </i>" : (Convert.ToDateTime(Eval("DtmPagamentoRecebimento")).ToString("MM/yyyy") == Convert.ToDateTime(Eval("DtmPrevisao")).ToString("MM/yyyy") ? "<i title='O pagamento foi realizado' class='fa fa-check'> </i>": "<i title='O pagamento foi realizado fora do prazo' class='fa fa-exclamation-triangle red'> </i>") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Núm. Doc.">
                                            <ItemTemplate><%#Eval("SNumeroDocumento") %></ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Referência">
                                            <ItemTemplate><%#Eval("SDescricaoReferencia") %></ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="De quem">
                                            <ItemTemplate><%#Eval("SNomeDeQuemPagou") %></ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Data pagto.">
                                            <ItemTemplate><%#Convert.ToDateTime(Eval("DtmPagamentoRecebimento")).ToString("dd/MM/yyyy") %></ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Competência">
                                            <ItemTemplate><%#Convert.ToDateTime(Eval("DtmCompetencia")).ToString("MM/yyyy") %></ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Valor">
                                            <ItemTemplate>R$ <%#Convert.ToDecimal(Eval("DValor")).ToString("#,0.00") %></ItemTemplate>
                                        </asp:TemplateField>
                                    
                                        <asp:TemplateField>
                                            <ItemTemplate><asp:LinkButton runat="server" CommandArgument='<%#Eval("Id") %>' CommandName="AlterarSaida" ID="lnkAlterar" CssClass="btn btn-sm"><i class="glyphicon glyphicon-edit"></i></asp:LinkButton></ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate><asp:LinkButton runat="server" CommandArgument='<%#Eval("Id") %>' CommandName="RemoverConta" ID="lnkRemover" CssClass="btn btn-danger btn-sm"><i class="glyphicon glyphicon-remove"></i></asp:LinkButton></ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>

                                    <EmptyDataTemplate>
                                        <center>NENHUMA DESPESA FIXA CADASTRADA</center>
                                    </EmptyDataTemplate>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>

                    <div role="tabpanel" class="tab-pane fade in" id="tabs-Variaveis">
                        <asp:UpdatePanel runat="server" ID="UpdatePanel3">
                            <ContentTemplate>
                                <h3>Esta é a sua tabela de despesas variáveis</h3>
                                <div class="subtitle"><i>Despesas variáveis são gastos relacionados com a produção, venda ou manutenção dos produtos e equipamentos. Ex.: publicidade, comissões, combustível etc.</i></div>
                                <asp:GridView OnRowCommand="_RowCommand" ShowHeaderWhenEmpty="true" AutoGenerateColumns="false" runat="server" ID="gdvDespesaVariavel" GridLines="None" CssClass="table">
                                    <Columns>
                                        <asp:TemplateField HeaderText=" ">
                                            <ItemTemplate>
                                                <%#Convert.ToDateTime(Eval("DtmPagamentoRecebimento")) == new DateTime() ? "<i title='O pagamento NÃO foi realizado' class='fa fa-question-circle red'> </i>" : (Convert.ToDateTime(Eval("DtmPagamentoRecebimento")).ToString("MM/yyyy") == Convert.ToDateTime(Eval("DtmPrevisao")).ToString("MM/yyyy") ? "<i title='O pagamento foi realizado' class='fa fa-check'> </i>": "<i title='O pagamento foi realizado fora do prazo' class='fa fa-exclamation-triangle red'> </i>") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Núm. Doc.">
                                            <ItemTemplate><%#Eval("SNumeroDocumento") %></ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Referência">
                                            <ItemTemplate><%#Eval("SDescricaoReferencia") %></ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="De quem">
                                            <ItemTemplate><%#Eval("SNomeDeQuemPagou") %></ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Data pagto.">
                                            <ItemTemplate><%#Convert.ToDateTime(Eval("DtmPagamentoRecebimento")).ToString("dd/MM/yyyy") %></ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Competência">
                                            <ItemTemplate><%#Convert.ToDateTime(Eval("DtmCompetencia")).ToString("MM/yyyy") %></ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Valor">
                                            <ItemTemplate>R$ <%#Convert.ToDecimal(Eval("DValor")).ToString("#,0.00") %></ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField>
                                            <ItemTemplate><asp:LinkButton runat="server" CommandArgument='<%#Eval("Id") %>' CommandName="AlterarSaida" ID="lnkAlterar" CssClass="btn btn-sm"><i class="glyphicon glyphicon-edit"></i></asp:LinkButton></ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate><asp:LinkButton runat="server" CommandArgument='<%#Eval("Id") %>' CommandName="RemoverConta" ID="lnkRemover" CssClass="btn btn-danger btn-sm"><i class="glyphicon glyphicon-remove"></i></asp:LinkButton></ItemTemplate>
                                        </asp:TemplateField>
                                        
                                    </Columns>
                                    <EmptyDataTemplate>
                                        <center>NENHUMA DESPESA FIXA CADASTRADA</center>
                                    </EmptyDataTemplate>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>

                    <div role="tabpanel" class="tab-pane fade in" id="tabs-Pessoas">
                        <asp:UpdatePanel runat="server" ID="UpdatePanel4">
                            <ContentTemplate>
                                <h3>Esta é a sua tabela com as outras despesas</h3>
                                <div class="subtitle"><i>Enquadram-se nesta tela, as despesas relacionadas a impostos, às pessoas e todas as outras que não são fixas ou variáveis. Despesas com PESSOAL por exemplo, compreendem a folha de pagamento. Ex.: salários, adiantamento, pro-labore, FGTS etc.</i></div>
                                <asp:GridView OnRowCommand="_RowCommand" ShowHeaderWhenEmpty="true" AutoGenerateColumns="false" runat="server" ID="gdvDespesaComPessoal" GridLines="None" CssClass="table">
                                    <Columns>
                                        <asp:TemplateField HeaderText=" ">
                                            <ItemTemplate>
                                                <%#Convert.ToDateTime(Eval("DtmPagamentoRecebimento")) == new DateTime() ? "<i title='O pagamento NÃO foi realizado' class='fa fa-question-circle red'> </i>" : (Convert.ToDateTime(Eval("DtmPagamentoRecebimento")).ToString("MM/yyyy") == Convert.ToDateTime(Eval("DtmPrevisao")).ToString("MM/yyyy") ? "<i title='O pagamento foi realizado' class='fa fa-check'> </i>": "<i title='O pagamento foi realizado fora do prazo' class='fa fa-exclamation-triangle red'> </i>") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Núm. Doc.">
                                            <ItemTemplate><%#Eval("SNumeroDocumento") %></ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Referência">
                                            <ItemTemplate><%#Eval("SDescricaoReferencia") %></ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Para quem">
                                            <ItemTemplate><%#Eval("SNomeDeQuemPagou") %></ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Data pagto.">
                                            <ItemTemplate><%#Convert.ToDateTime(Eval("DtmPagamentoRecebimento")) != new DateTime() ? Convert.ToDateTime(Eval("DtmPagamentoRecebimento")).ToString("dd/MM/yyyy") : "-" %></ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Competência">
                                            <ItemTemplate><%#Convert.ToDateTime(Eval("DtmCompetencia")).ToString("MM/yyyy") %></ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Valor">
                                            <ItemTemplate>R$ <%#Convert.ToDecimal(Eval("DValor")).ToString("#,0.00") %></ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField>
                                            <ItemTemplate><asp:LinkButton runat="server" CommandArgument='<%#Eval("Id") %>' CommandName="AlterarSaida" ID="lnkAlterar" CssClass="btn btn-sm"><i class="glyphicon glyphicon-edit"></i></asp:LinkButton></ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate><asp:LinkButton runat="server" CommandArgument='<%#Eval("Id") %>' CommandName="RemoverConta" ID="lnkRemover" CssClass="btn btn-danger btn-sm"><i class="glyphicon glyphicon-remove"></i></asp:LinkButton></ItemTemplate>
                                        </asp:TemplateField>
                                        
                                    </Columns>
                                    <EmptyDataTemplate>
                                        <center>NENHUMA DESPESA FIXA CADASTRADA</center>
                                    </EmptyDataTemplate>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>

                <div style="border-left: 1px solid #ededed; min-height:200px; " class="col-md-3 col-sm-3 col-xs-12">
                    <div class="tasks-grid">
                        <br /><div class="clearfix"></div>

                        <div class="tasks-grid-col grey-blue">
                            <section class="box-typical task-card task">
							    <div class="task-card-in">
								    <div class="task-card-title">TOTAL PREVISTO É:</div>
								    <div class="progress-compact-style">
                                        <asp:UpdatePanel runat="server" RenderMode="Inline" ID="upnlMesAtual"><ContentTemplate><p><span class="unit">R$</span><b><span class="number"><asp:Literal runat="server" ID="ltrMesAtual"></asp:Literal></span></b></p></ContentTemplate></asp:UpdatePanel>
								    </div>
							    </div>
						    </section><!--.task-card-->
                        </div>

				        <div class="tasks-grid-col green">
                            <section class="box-typical task-card task">
							    <div class="task-card-in">
								    <div class="task-card-title">REALIZADO NO MÊS ANTERIOR:</div>
								    <div class="progress-compact-style">
                                        <asp:UpdatePanel runat="server" RenderMode="Inline" ID="upnlTotalAnterior"><ContentTemplate><p><span class="unit">R$</span><b><span class="number"><asp:Literal runat="server" ID="ltrMesAnterior"></asp:Literal></span></b></p></ContentTemplate></asp:UpdatePanel>
								    </div>
							    </div>
						    </section><!--.task-card-->
                        </div>

                        <asp:UpdatePanel runat="server" ID="upnlPeriodoMes"><ContentTemplate><h5 class="m-t-lg with-border"><asp:Literal runat="server" ID="ltrPeriodoMesAtual"></asp:Literal></h5></ContentTemplate></asp:UpdatePanel>
                        <div class="tasks-grid-col green">
                            <section class="box-typical task-card task">
							    <div class="task-card-in">
								    <div class="task-card-title task-card-title2">RECEBIMENTOS</div>
								    <asp:UpdatePanel runat="server" ID="UpdatePanel6" RenderMode="Inline"><ContentTemplate><div class="progress-compact-style progress-compact-style2"><p><span title="Realizado" style="color:green;">R$ <b><asp:Literal runat="server" ID="ltrRecebimentoRealizado"></asp:Literal></b></span> / <span title="Previsto" style="color:gray">R$ <b><asp:Literal runat="server" ID="ltrRecebimentoPrevisto"></asp:Literal></b></span></p></div></ContentTemplate></asp:UpdatePanel>
							    </div>
						    </section><!--.task-card-->
                        </div>

                        <div class="tasks-grid-col red">
                            <section class="box-typical task-card task">
							    <div class="task-card-in">
								    <div class="task-card-title task-card-title2">DESPESAS TOTAIS</div>
								    <div class="progress-compact-style progress-compact-style2"><p><asp:UpdatePanel runat="server" ID="upnlTotalSaidas" RenderMode="Inline"><ContentTemplate><span title="Realizado" style="color:dodgerblue;">R$ <b><asp:Literal runat="server" ID="ltrSaidasRealizado"></asp:Literal></b></span> / <span title="Previsto" style="color:gray">R$ <b><asp:Literal runat="server" ID="ltrSaidasPrevisto"></asp:Literal></b></span></ContentTemplate></asp:UpdatePanel></p></div>
							    </div>
						        
                                <asp:UpdatePanel runat="server" ID="ltrSomatoriaDespesas">
                                    <ContentTemplate>
                                        <div class="task-card-in">
								            <div class="task-card-title task-card-title2">DESPESAS FIXAS</div>
								            <div class="progress-compact-style progress-compact-style2"><p><span title="Realizado" style="color:dodgerblue;">R$ <b><asp:Literal runat="server" ID="ltrTotalDespesaFixaRealizado" /></b></span> / <span title="Previsto" style="color:gray">R$ <b><asp:Literal runat="server" ID="ltrTotalDespesaFixaPrevisto" /></b></span></p></div>
							            </div>
						        
							            <div class="task-card-in">
								            <div class="task-card-title task-card-title2">DESPESAS VARIÁVEIS</div>
								            <div class="progress-compact-style progress-compact-style2"><p><span title="Realizado" style="color:dodgerblue;">R$ <b><asp:Literal runat="server" ID="ltrTotalDespesaVariavelRealizado" /></b></span> / <span title="Previsto" style="color:gray">R$ <b><asp:Literal runat="server" ID="ltrTotalDespesaVariavelPrevisto" /></b></span></p></div>
							            </div>
							    
                                        <div class="task-card-in">
								            <div class="task-card-title task-card-title2">PESSOAS</div>
								            <div class="progress-compact-style progress-compact-style2"><p><span title="Realizado" style="color:dodgerblue;">R$ <b><asp:Literal runat="server" ID="ltrTotalDespesaPessoalRealizado" /></b></span> / <span title="Previsto" style="color:gray">R$ <b><asp:Literal runat="server" ID="ltrTotalDespesaPessoalPrevisto" /></b></span></p></div>
							            </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
						    </section><!--.task-card-->
                        </div>
                    </div>
                        
                </div>
            </div>
        </section>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cFooterScripts" runat="server">
    <script>
        function fnFechar(botao) { $("#" + botao).click(); }
        //function fnSelect() { $(".select2").select2(); }
        function fnAbrir(idBotao) { $("#" + idBotao).click(); }
    </script>
</asp:Content>