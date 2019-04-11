<%@ Page Title="" Language="C#" MasterPageFile="~/_MLogado.master" AutoEventWireup="true" CodeBehind="estoque_almoxarifado.aspx.cs" Inherits="Site.estoque_almoxarifado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cHeaderScripts" runat="server">
    <link rel="stylesheet" href="css/separate/vendor/tags_editor.min.css">
    <link rel="stylesheet" href="css/separate/vendor/bootstrap-select/bootstrap-select.min.css">
    <link rel="stylesheet" href="css/separate/vendor/select2.min.css">
    <link rel="stylesheet" href="css/separate/vendor/bootstrap-daterangepicker.min.css">
    <link rel="stylesheet" href="css/lib/clockpicker/bootstrap-clockpicker.min.css">
    <link rel="stylesheet" href="css/separate/vendor/fancybox.min.css">
    <link rel="stylesheet" href="css/lib/datatables-net/datatables.min.css">
    <link rel="stylesheet" href="css/separate/vendor/datatables-net.min.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cConteudo" runat="server">
    <%--<asp:ScriptManager runat="server" ID="srcM"></asp:ScriptManager>--%>

    <div class="box-typical box-typical-padding">
        <h5 class="m-t-lg with-border">Almoxarifado</h5>
        <div class="row">
            <div class="col-md-2 col-sm-4 col-xs-12">
                <label>Código</label>
                <div class="input-group">
                    <asp:TextBox runat="server" Height="100%" ID="txtCodigo" readonly disabled Text="AUTOMATICO" CssClass="form-control"></asp:TextBox>
                    <asp:LinkButton runat="server" ID="lnkCarregaCEP" CssClass="input-group-addon btn btn-info"><i class="fa fa-search"></i></asp:LinkButton>
                </div>
            </div>
            
            <div class="col-md-6 col-sm-8 col-xs-12">
                <label class="form-control-label">Colaborador</label>
                <asp:DropDownList runat="server" ID="ddlColaborador" CssClass="select2"></asp:DropDownList>
            </div>

            <div class="col-md-2 col-sm-6 col-xs-12">
                <label>Dt. Emissão</label>
                <asp:TextBox runat="server" ID="txtDataEmissao" CssClass="form-control daterange3"></asp:TextBox>
            </div>

            <div class="col-md-2 col-sm-6 col-xs-12">
                <label>Dt. Movimentação</label>
                <asp:TextBox runat="server" ID="txtDataMovimentacao" CssClass="form-control daterange3"></asp:TextBox>
            </div>

            <div class="col-md-12 col-sm-12 col-xs-12">
                <label>Observação</label>
                <asp:TextBox TextMode="MultiLine" runat="server" ID="txtObservacao" Rows="3" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="clearfix"></div><br />
        <div class="row">
            <asp:UpdatePanel runat="server" ID="upnlFormulario">
                <ContentTemplate>
                    <asp:HiddenField runat="server" ID="hdfMovimentacaoItemID" />
                    <div class="col-md-1 col-sm-3 col-xs-4">
                        <label>Tipo</label>
                        <asp:DropDownList runat="server" ID="ddlMovimentacaoTipo" CssClass="form-control"><asp:ListItem Text="Entrada" Value="1" /><asp:ListItem Text="Saída" Value="2" /></asp:DropDownList>
                    </div>
                    <div class="col-md-3 col-sm-9 col-xs-8">
                        <label class="form-control-label">Produto</label>
                        <asp:DropDownList runat="server" ID="ddlMovimentacaoProduto" CssClass="select2"></asp:DropDownList>
                    </div>
                    <div class="clearfix visible-xs"></div>

                    <div class="col-md-2 col-sm-4 col-xs-12">
                        <label>Valor</label>
                        <asp:TextBox Height="100%" runat="server" ID="txtMovimentacaoValor" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-2 col-sm-4 col-xs-12">
                        <label>Qtd.</label>
                        <div class="form-group">
							<asp:TextBox runat="server" Height="100%" ID="txtMovimentacaoQtd" CssClass="form-control CampoNumeroBotoes"></asp:TextBox>
						</div>
                    </div>
                    <div class="col-md-2 col-sm-4 col-xs-12">
                        <label>Total</label>
                        <asp:TextBox Height="100%" runat="server" readonly disabled ID="txtMovimentacaoTotal" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="clearfix visible-xs"></div>

                    <div class="col-md-1 col-sm-4 col-xs-9">
                        <label>Endereço</label>
                        <div class="input-group">
                            <asp:TextBox Height="100%" runat="server" readonly disabled ID="txtMovimentacaoEndereco" CssClass="form-control visible-xs"></asp:TextBox>
                            <asp:LinkButton runat="server" ID="lnkBuscaEndereco" CssClass="input-group-addon btn btn-default"><i class="fa fa-search"></i></asp:LinkButton>
                        </div>
                    </div>
                    <div class="col-md-1 col-sm-2 col-xs-3">
                        <label>&nbsp;</label>
                        <asp:Button runat="server" ID="btnAddMedicamento" Text="+" CssClass="form-control btn btn-success" OnClick="btnAddMedicamento_Click"/>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div class="clearfix"></div><br />
        <section class="card">
		    <div class="card-block">
                <asp:UpdatePanel runat="server" ID="upnlLista">
                    <ContentTemplate>
                        <table class="tabelasdinamicas display table table-striped table-bordered table-responsive" width="100%">
                            <thead>
				                <tr>
                                    <th>Tipo</th>
                                    <th width="100%">Produto</th>
                                    <th>Valor</th>
                                    <th>Qtd</th>
                                    <th>Total(R$)</th>
                                    <th>Endereço</th>
                                    <th> </th>
				                </tr>
				            </thead>
                            <tbody>
                    
                                <asp:Repeater runat="server" ID="rptAgendamentos">
                                    <ItemTemplate>
                                        <tr>
                                            <td>Tipo</td>
                                            <td width="100%">Produto</td>
                                            <td>Valor</td>
                                            <td>Qtd</td>
                                            <td>Total(R$)</td>
                                            <td>Endereço</td>
                                            <td><asp:LinkButton runat="server" CommandArgument='medicamento' CommandName="Remover" ID="lnkRemover" CssClass="btn"><i class="glyphicon glyphicon-exclamation-sign"></i></asp:LinkButton></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            
                            </tbody>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </section>
    

        <br /><div class="clearfix"></div>
        <div class="row">
            <div class="col-md-3 col-sm-6 col-xs-12"><asp:LinkButton runat="server" CssClass="form-control btn btn-success swal-btn-basic" ID="lnkNovo"><i class="fa fa-check"></i> Novo</asp:LinkButton></div>
            <div class="col-md-3 col-sm-6 col-xs-12"><asp:LinkButton runat="server" CssClass="form-control btn btn-success swal-btn-basic" ID="lnkSalvar"><i class="fa fa-check"></i> Salvar</asp:LinkButton></div>
            <div class="col-md-3 col-sm-6 col-xs-12"><asp:LinkButton runat="server" CssClass="form-control btn btn-success swal-btn-basic" ID="lnkFinalizar"><i class="fa fa-check"></i> Finalizar</asp:LinkButton></div>
            <div class="col-md-2 col-sm-6 col-xs-12"><asp:LinkButton runat="server" CssClass="form-control btn btn-danger-outline swal-btn-basic" ID="lnkCancelar"><i class="fa fa-close"></i> Cancelar</asp:LinkButton></div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cFooterScripts" runat="server">
    <script>
        function fnFechar(botao) { $("#" + botao).click(); }
        function fnSelect() { $(".select2").select2(); }
        function fnAbrir(idBotao) { $("#" + idBotao).click(); }
        $('#example, .tabelasdinamicas').DataTable();
    </script>
</asp:Content>