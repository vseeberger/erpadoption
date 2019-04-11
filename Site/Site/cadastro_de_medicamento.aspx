<%@ Page Title="" Language="C#" MasterPageFile="~/_MLogado.master" AutoEventWireup="true" CodeBehind="cadastro_de_medicamento.aspx.cs" Inherits="Site.cadastro_de_medicamento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cHeaderScripts" runat="server">
    <link rel="stylesheet" href="css/separate/vendor/tags_editor.min.css">
    <link rel="stylesheet" href="css/separate/vendor/bootstrap-select/bootstrap-select.min.css">
    <link rel="stylesheet" href="css/separate/vendor/select2.min.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cConteudo" runat="server">
<%--    <asp:ScriptManager runat="server" ID="scrm" />--%>
    <asp:Panel runat="server" ID="pnl01" DefaultButton="lnkSalvar">
        <div class="box-typical box-typical-padding">
            <h5 class="m-t-lg with-border">Cadastro de Produto</h5>
            <div class="row">
                <div class="col-md-2 col-sm-4 col-xs-12">
                    <label class="form-control-label">Código</label>
                    <asp:TextBox  readonly disabled runat="server" ID="txtCodigo" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-4 col-sm-8 col-xs-12">
                    <label class="form-control-label">Grupo</label>
                    <asp:DropDownList runat="server" ID="ddlGrupo" CssClass="form-control select2"></asp:DropDownList>
                </div>
                <div class="col-md-6 col-sm-12 col-xs-12">
                    <label class="form-control-label">Fornecedor</label>
					<asp:DropDownList runat="server" ID="ddlFornecedor" CssClass="form-control select2"></asp:DropDownList>
                </div>
            </div>

            <div class="row">
                <div class="col-md-2 col-sm-4 col-xs-12">
                    <label class="form-control-label">Referência</label>
                    <asp:TextBox runat="server" ID="txtReferencia" CssClass="form-control primeiro"></asp:TextBox>
                </div>
                <div class="col-md-10 col-sm-8 col-xs-12">
                    <label class="form-control-label" title="Nome oficial do produto">Nome</label>
                    <asp:TextBox runat="server" ID="txtNomeDoProduto" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-12 col-sm-12 col-xs-12">
                    <label class="form-control-label" title="Nome comercial do produto">Nome Comercial</label>
                    <asp:TextBox runat="server" ID="txtNomeComercial" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="row">
                <div class="col-md-4 col-sm-12 col-xs-12">
                    <label class="form-control-label">Princípio Ativo</label>
                    <asp:DropDownList runat="server" ID="ddlPrincipioAtivo" CssClass="form-control select2"></asp:DropDownList>
                </div>

                <div class="col-md-6 col-sm-12 col-xs-12">
                    <div class="form-group">
                        <label class="form-control-label" title="Nome comercial do produto">Nome Genérico</label>
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

                

                <div class="col-md-12 col-sm-12 col-xs-12">
                    <label class="form-control-label" title="Nome comercial do produto">Observações</label>
                    <asp:TextBox runat="server" ID="txtObservacoes" Rows="4" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <br /><div class="clearfix"></div>
            <section runat="server" visible="false" id="Tabs" class="tabs-section">
                <div class="tabs-section-nav tabs-section-nav-icons">
                    <div class="tbl">
                        <ul class="nav" role="tablist">
                            <li class="nav-item"><a class="nav-link active" href="#tabs-fornecedores" role="tab" data-toggle="tab"><span class="nav-link-in">Outros Fornecedores</span></a></li>
                        </ul>
                    </div>
                </div><!--.tabs-section-nav-->
                <div class="tab-content" style="min-height:200px;">
                    <div role="tabpanel" class="tab-pane fade in active" id="tabs-fornecedores">
                        <div class="row">
                            <div class="col-md-4 col-sm-4 col-xs-12">
                                <label class="form-control-label">Fornecedor/Fabricante</label>
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
                </div>
            </section>

            <br /><div class="clearfix"></div>
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
                    <h4 class="modal-title" id="myModalLabel">Cadastrar Genéricos</h4>
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
        function fnSelect() { $(".select2").select2();}
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cFooterScripts" runat="server">
</asp:Content>