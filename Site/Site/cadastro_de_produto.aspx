<%@ Page Title="" Language="C#" MasterPageFile="~/_MLogado.master" AutoEventWireup="true" CodeBehind="cadastro_de_produto.aspx.cs" Inherits="Site.cadastro_de_produto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cHeaderScripts" runat="server">
    <link rel="stylesheet" href="css/separate/vendor/tags_editor.min.css">
    <link rel="stylesheet" href="css/separate/vendor/bootstrap-select/bootstrap-select.min.css">
    <link rel="stylesheet" href="css/separate/vendor/select2.min.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cConteudo" runat="server">
    <asp:Panel runat="server" ID="pnl01" DefaultButton="lnkSalvar">
        <div class="box-typical box-typical-padding">
            <h5 class="m-t-lg with-border">Cadastro de Produto</h5>
            <div class="row">
                <div class="col-md-2 col-sm-4 col-xs-12 dahsboard-column">
                    <div class="row">
                        <div class="col-xl-12">
                            <input type="button" class="form-control btn btn-info" value="Carregar foto..." onclick="carregarFoto();" />
                            <asp:HiddenField runat="server" ID="hdfFotoAtual" />
                            <asp:FileUpload CssClass="carregaFoto" runat="server" ID="fupCapa" style="display:none;" />
                        </div>
                        <div class="clearfix"></div><br />
                        <div class="col-xl-12">
                            <asp:Image runat="server" ID="img" ImageUrl="" CssClass="form-control" />
                        </div>
                    </div>
                </div>
            
                <div class="col-md-10 col-sm-8 col-xs-12 dahsboard-column">
                    <div class="row">
                        <div class="col-md-3 col-sm-6 col-xs-12">
                            <label class="form-control-label">Código</label>
                            <asp:TextBox  readonly disabled runat="server" ID="txtCodigo" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-3 col-sm-6 col-xs-12">
                            <label class="form-control-label">Referência</label>
                            <asp:TextBox runat="server" ID="txtReferencia" CssClass="form-control primeiro"></asp:TextBox>
                        </div>
                        <div class="col-md-3 col-sm-12 col-xs-12">
                            <label class="form-control-label">Marca</label>
                            <asp:DropDownList runat="server" ID="ddlMarca" CssClass="form-control select2"></asp:DropDownList>
                        </div>
                        <div class="col-md-12 col-sm-12 col-xs-12">
                            <asp:RadioButtonList runat="server" RepeatDirection="Horizontal" CssClass="radio" ID="rblTipos">
                                <asp:ListItem Value="C" Text="Consumo" Selected="True" />
                                <asp:ListItem Value="M" Text="Mercadoria" />
                                <asp:ListItem Value="S" Text="Serviço" />
                                <asp:ListItem Value="I" Text="Imobilizado" />
                            </asp:RadioButtonList>
                            <asp:CheckBox runat="server" ID="cbxEhMedicamento" CssClass="checkbox" Text="É medicamento? " />
                            <asp:CheckBox runat="server" ID="cbxEhVacina" CssClass="checkbox" Text="É vacina? " />
                        </div>
                    </div>
                
                    <div class="row">
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <label class="form-control-label">Grupo</label>
                            <asp:DropDownList runat="server" ID="ddlGrupo" CssClass="form-control select2"></asp:DropDownList>
                        </div>
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <label class="form-control-label">Fabricante</label>
					        <asp:DropDownList runat="server" ID="ddlFornecedor" CssClass="form-control select2"></asp:DropDownList>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-12 col-sm-12 col-xs-12">
                            <label class="form-control-label" title="Nome oficial do produto">Nome</label>
                            <asp:TextBox runat="server" ID="txtNomeDoProduto" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-12 col-sm-12 col-xs-12">
                            <label class="form-control-label" title="Nome comercial do produto">Nome Comercial</label>
                            <asp:TextBox runat="server" ID="txtNomeComercial" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            

            <br /><div class="clearfix"></div>
            <section id="Tabs" class="tabs-section">
                <div class="tabs-section-nav tabs-section-nav-icons">
                    <div class="tbl">
                        <ul class="nav" role="tablist">
                            <li class="nav-item"><a class="nav-link active" href="#tabs-Detalhes" role="tab" data-toggle="tab"><span class="nav-link-in">Detalhes</span></a></li>
                            <li class="nav-item"><a class="nav-link" href="#tabs-fornecedores" role="tab" data-toggle="tab"><span class="nav-link-in">+ Fabricantes</span></a></li>
                            <li class="nav-item"><a class="nav-link" href="#tabs-Medicamento" role="tab" data-toggle="tab"><span class="nav-link-in">Medicamento</span></a></li>
                            <li class="nav-item"><a class="nav-link" href="#tabs-Vacina" role="tab" data-toggle="tab"><span class="nav-link-in">Vacina</span></a></li>
                            <%--<li class="nav-item"><a class="nav-link" href="#tabs-Barras" role="tab" data-toggle="tab"><span class="nav-link-in">Cód. Barras</span></a></li>--%>
                        </ul>
                    </div>
                </div><!--.tabs-section-nav-->
                <div class="tab-content" style="min-height:300px;">
                    <div role="tabpanel" class="tab-pane fade in active" id="tabs-Detalhes">
                        <div class="row">
                            <div class="col-md-2 col-sm-4 col-xs-4"><asp:CheckBox Text="Tem Lote" runat="server" ID="cbxTrabalhaComLote" CssClass="checkbox" /></div>
                            <div class="col-md-2 col-sm-4 col-xs-4"><asp:CheckBox Text="Tem Grade" runat="server" ID="cbxPossuiGrade" CssClass="checkbox" /></div>
                            <div class="col-md-2 col-sm-4 col-xs-4"><asp:CheckBox Text="É Importado" runat="server" ID="cbxImportado" CssClass="checkbox" /></div>
                        </div>

                        <div class="row">
                            <div class="col-md-4 col-sm-4 col-xs-12">
                                <label>Peso bruto</label>
                                <asp:TextBox runat="server" ID="txtPesoBruto" CssClass="form-control peso-mask"></asp:TextBox>
                            </div>

                            <div class="col-md-4 col-sm-4 col-xs-12">
                                <label>Peso liq.</label>
                                <asp:TextBox runat="server" ID="txtPesoLiquido" CssClass="form-control peso-mask"></asp:TextBox>
                            </div>

                            <div class="col-md-4 col-sm-4 col-xs-12">
                                <label>Qtd. caixa</label>
                                <asp:TextBox runat="server" ID="txtQtdCaixa" CssClass="form-control numero"></asp:TextBox>
                            </div>
                        </div>
                        
                        <div class="row">
                            <div class="col-md-4 col-sm-4 col-xs-12">
                                <label>Estoque min.</label>
                                <asp:TextBox runat="server" ID="txtEstoqueMinimo" CssClass="form-control numero"></asp:TextBox>
                            </div>

                            <div class="col-md-4 col-sm-4 col-xs-12">
                                <label>Estoque max.</label>
                                <asp:TextBox runat="server" ID="txtEstoqueMaximo" CssClass="form-control numero"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-12 col-sm-12 col-xs-12">
                                <label class="form-control-label" title="Nome comercial do produto">Observações</label>
                                <asp:TextBox runat="server" ID="txtObservacoes" Rows="3" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div role="tabpanel" class="tab-pane fade in" id="tabs-fornecedores">
                        <div class="row">
                            <div class="col-md-4 col-sm-4 col-xs-12">
                                <label class="form-control-label">Fabricante</label>
					            <asp:DropDownList runat="server" ID="txtFornecedorOutros" CssClass="select2"></asp:DropDownList>
                            </div>
                            <div class="col-md-2 col-sm-2 col-xs-12">
                                <label class="form-control-label">Referência</label>
                                <asp:TextBox runat="server" ID="txtFornecedorReferencia" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-4 col-sm-4 col-xs-12">
                                <label class="form-control-label">Descrição</label>
                                <asp:TextBox runat="server" ID="txtFornecedorDescricao" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-2 col-sm-2 col-xs-12">
                                <label class="form-control-label">&nbsp;</label>
                                <asp:LinkButton runat="server" CssClass="form-control btn btn-info swal-btn-basic" ID="lnkMaisFornecedor"><i class="fa fa-plus"></i></asp:LinkButton>
                            </div>
                        </div>
                    </div>

                    <div role="tabpanel" class="tab-pane fade in" id="tabs-Medicamento">
                        <div class="row">
                            <div class="col-md-6 col-sm-12 col-xs-12">
                                <label class="form-control-label">Princípio Ativo</label>
                                <asp:DropDownList runat="server" ID="ddlPrincipioAtivo" CssClass="form-control select2"></asp:DropDownList>
                            </div>

                            <div class="col-md-6 col-sm-12 col-xs-12">
                                <div class="form-group">
                                    <label class="form-control-label" title="Nome comercial do produto">Genérico</label>
                                    <div class="input-group">
                                        <asp:UpdatePanel runat="server" ID="upnlGenericos" RenderMode="Inline" UpdateMode="Always">
                                            <ContentTemplate>
							                    <asp:DropDownList runat="server" ID="ddlGenerico" CssClass="select2"></asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <div class="input-group-addon btn btn-info" data-toggle="modal" data-target="#MGenericos" data-backdrop="static" data-keyboard="false"><i class="fa fa-plus-circle"></i></div>
                                    </div>
					            </div>
                            </div>

                        </div>
                    </div>

                    <div role="tabpanel" class="tab-pane fade in" id="tabs-Vacina">
                        <div class="row">
                            <div class="col-md-4 col-sm-8 col-xs-12">
                                <label class="form-control-label">Espécie</label>
                                <asp:DropDownList runat="server" ID="ddlEspecie" CssClass="form-control"></asp:DropDownList>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-2 col-sm-4 col-xs-12">
                                <label class="form-control-label">Qnt. Doses</label>
                                <asp:TextBox runat="server" ID="txtQntDoses" MaxLength="3" CssClass="form-control number"></asp:TextBox>
                            </div>
                            <div class="col-md-2 col-sm-4 col-xs-12">
                                <label class="form-control-label" title="Diferença de dias entre as doses">Entre doses</label>
                                <asp:TextBox runat="server" ID="txtEntreDoses" MaxLength="4" CssClass="form-control number"></asp:TextBox>
                            </div>
                            <div class="col-md-2 col-sm-4 col-xs-12">
                                <label class="form-control-label">Dias Validade</label>
                                <asp:TextBox runat="server" ID="txtQntDiasValidade" MaxLength="4" CssClass="form-control number"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div role="tabpanel" class="tab-pane fade in" id="tabs-Barras">
                        <div class="row">
                            <%--<div class="col-xl-8 dahsboard-column">
                                <section class="box-typical box-typical-dashboard panel panel-default scrollable">
	                                <header class="box-typical-header panel-heading"><h3 class="panel-title panel">Código de barras</h3></header>
	                                <div class="box-typical-body panel-body">
                                        - TIPO [EAN 13]
                                        - GERAR [BOTÃO GERAR]
                                        - BARRA [texto do codigo de barras]
                                        - QUANTIDADE
                                        - UNIDADE
                                        - CÓDIGO SERVE PARA [ ] COMPRA    [ ] VENDA
                                        <div class="col-xl-1">
                                            <label>Tipo</label>
                                            <asp:DropDownList runat="server" ID="ddlBarrasTipo" CssClass="form-control"><asp:ListItem Value="EAN13" /></asp:DropDownList>
                                        </div>
                                        <div class="col-xl-1">
                                            <label title="FATOR DE CONVERSÃO"></label>
                                            <asp:TextBox runat="server" ID="TextBox1" MaxLength="3" CssClass="form-control number"></asp:TextBox>
                                        </div>
                                        <div class="col-xl-1">
                                            <label title="OPERAÇÃO (MULTIPLICAÇÃO ou DIVISÃO)"></label>
                                            <asp:DropDownList runat="server" ID="DropDownList2" CssClass="form-control"><asp:ListItem Value=" " Text="selecione" /><asp:ListItem Value="*" /><asp:ListItem Value="/" /></asp:DropDownList>
                                        </div>
                                        <div class="col-xl-1">
                                            <label title="UNIDADE DE CONTROLE (UNIDADE QUE SERÁ CONTROLADA - UNIDADE DE DESTINO --> {{{{(QUANTIDADE UN.COMPRA) [OPERAÇÃO] (FATOR) = (QUANTIDADE UN. CONTROLE)}}}})"></label>
                                            <asp:DropDownList runat="server" ID="DropDownList3" CssClass="form-control"></asp:DropDownList>
                                        </div>
                                        <div class="col-xl-1">
                                            <label title="">&nbsp;</label>
                                            <asp:Button runat="server" ID="Button1" Text="+" CssClass="btn btn-success" />
                                        </div>
                                    </div>
                                </section>
                            </div>

                            <div class="col-xl-4 dahsboard-column">
                                <section class="box-typical box-typical-dashboard panel panel-default scrollable">
	                                <header class="box-typical-header panel-heading"><h3 class="panel-title"><asp:CheckBox runat="server" ID="cbxTemConversao" Text="Tem Conversão" CssClass="checkbox" /></h3></header>
	                                <div class="box-typical-body panel-body">
                                        <div class="col-xl-1">
                                            <label title="UNIDADE DE COMPRA">De UN</label>
                                            <asp:DropDownList runat="server" ID="ddlConversaoUNOrigem" CssClass="form-control"></asp:DropDownList>
                                        </div>
                                        <div class="col-xl-1">
                                            <label title="FATOR DE CONVERSÃO">Fator</label>
                                            <asp:TextBox runat="server" ID="txtConversaoFator" MaxLength="3" CssClass="form-control number"></asp:TextBox>
                                        </div>
                                        <div class="col-xl-1">
                                            <label title="OPERAÇÃO (MULTIPLICAÇÃO ou DIVISÃO)">Oper</label>
                                            <asp:DropDownList runat="server" ID="ddlConversaoOperacao" CssClass="form-control"><asp:ListItem Value=" " Text="selecione" /><asp:ListItem Value="*" /><asp:ListItem Value="/" /></asp:DropDownList>
                                        </div>
                                        <div class="col-xl-1">
                                            <label title="UNIDADE DE CONTROLE (UNIDADE QUE SERÁ CONTROLADA - UNIDADE DE DESTINO --> {{{{(QUANTIDADE UN.COMPRA) [OPERAÇÃO] (FATOR) = (QUANTIDADE UN. CONTROLE)}}}})">Para UN</label>
                                            <asp:DropDownList runat="server" ID="ddlConversaoUNDestino" CssClass="form-control"></asp:DropDownList>
                                        </div>
                                        <div class="col-xl-1">
                                            <label title="">&nbsp;</label>
                                            <asp:Button runat="server" ID="btnIncluirConversao" Text="+" CssClass="btn btn-success" />
                                        </div>
                                    </div>
                                </section>
                            </div>--%>
                        </div>
                    </div>
                </div>
            </section>

           
            <div class="row">
                <div class="col-md-2 col-sm-6 col-xs-12"><asp:LinkButton OnClick="lnkSalvar_Click" runat="server" CssClass="form-control btn btn-success swal-btn-basic" ID="lnkSalvar"><i class="fa fa-check"></i> Salvar</asp:LinkButton></div>
                <div class="col-md-2 col-sm-6 col-xs-12"><asp:LinkButton OnClick="lnkCancelar_Click" runat="server" CssClass="form-control btn btn-danger-outline swal-btn-basic" ID="lnkCancelar"><i class="fa fa-close"></i> Cancelar</asp:LinkButton></div>
            </div>
        </div>
    </asp:Panel>

    <div id="MGenericos" class="modal fade bd-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="modal-close" data-dismiss="modal" aria-label="Close"><i class="font-icon-close-2"></i></button>
                    <h4 class="modal-title" id="myModalLabel">Cadastrar Genérico</h4>
                </div>
                <asp:UpdatePanel runat="server" ID="upnlCadGenerico">
                    <ContentTemplate>
                        <div class="modal-body">
                            <div class="row">
                                <div class="col-md-2 col-sm-4 col-xs-12">
                                    <label>Cód</label>
                                    <asp:TextBox readonly disabled CssClass="form-control" runat="server" ID="txtGenericoCodigo"></asp:TextBox>
                                </div>
                        
                                <div class="col-md-10 col-sm-8 col-xs-12">
                                    <label>Descrição</label>
                                    <asp:TextBox CssClass="form-control" runat="server" ID="txtGenericoDescricao"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button id="btnfecharmodal01" class="invisible" type="button" data-dismiss="modal" aria-label="Close"><i class="font-icon-close-2"></i></button>            
                            <asp:Button runat="server" OnClick="btnCancelarGenerico_Click" ID="btnCancelarGenerico" Text="Cancelar" CssClass="btn btn-rounded btn-danger" />
                            <asp:Button runat="server" OnClick="btnSalvarGenerico_Click" ID="btnSalvarGenerico" Text="Salvar" CssClass="btn btn-rounded btn-primary" />
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                
            </div>
        </div>
    </div>
    <script>
        function fnFechar() { $("#btnfecharmodal01").click(); }
        function fnSelect() { $(".select2").select2(); }
        function carregarFoto() {
            $(".carregaFoto").click();
        }
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cFooterScripts" runat="server">
</asp:Content>