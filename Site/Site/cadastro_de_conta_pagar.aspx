<%@ Page Title="" Language="C#" MasterPageFile="~/_MLogado.master" AutoEventWireup="true" CodeBehind="cadastro_de_conta_pagar.aspx.cs" Inherits="Site.cadastro_de_conta_pagar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cHeaderScripts" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cConteudo" runat="server">
    <asp:Panel runat="server" ID="pnl01" DefaultButton="lnkSalvar">
        <div class="box-typical box-typical-padding">
            <h5 class="m-t-lg with-border">Lançar conta a pagar</h5>
            <asp:HiddenField runat="server" ID="hdfContaPagarID" />
            <asp:HiddenField runat="server" ID="hdfContaPagarDataPagamento" />
            <asp:HiddenField runat="server" ID="hdfPeriodoHerdado" />

            <div class="row">
                <div class="col-md-12 col-sm-12 col-xs-12">
                    <asp:TextBox runat="server" ID="txtContaPagarDescricao" CssClass="form-control" placeholder="Descrição (opcional)"></asp:TextBox>
                </div>

                <div class="col-md-4 col-sm-6 col-xs-12">
                    <label>Núm. Documento</label>
                    <div class="form-group">
						<div class="input-group">
							<div class="input-group-addon"><i class="fa fa-archive"> </i></div>
							<asp:TextBox runat="server" ID="txtContaPagarNumDoc" CssClass="form-control"></asp:TextBox>
						</div>
					</div>
                </div>
                                
                <div class="col-md-3 col-sm-6 col-xs-12">
                    <label>Valor</label>
                    <div class="form-group">
						<div class="input-group">
							<div class="input-group-addon">R$</div>
							<asp:TextBox runat="server" ID="txtContaPagarValor" CssClass="form-control money-mask"></asp:TextBox>
						</div>
					</div>
                </div>
                                
                <div class="col-md-3 col-sm-6 col-xs-12">
                    <label>Data de competência</label>
                    <asp:TextBox runat="server" ID="txtContaPagarCompetencia" CssClass="form-control daterange3"></asp:TextBox>
                </div>
                                
                <div class="col-md-2 col-sm-6 col-xs-12">
                    <label>Vencimento</label>
                    <asp:TextBox runat="server" ID="txtContaPagarDataVencimento" CssClass="form-control daterange3"></asp:TextBox>
                </div>
            </div>

            <div class="row">
                <div class="col-md-3 col-sm-6 col-xs-12">
                    <label class="form-control-label">Já Pagou?</label>
                    <div class="form-group">
					    <div class="btn-group" data-toggle="buttons">
						    <label runat="server" id="lblContaPagarsim"><asp:RadioButton GroupName="rdCPRecebeu" runat="server" ID="rbContaPagarSim" Text="Sim" /></label>
						    <label runat="server" id="lblContaPagarNao"><asp:RadioButton GroupName="rdCPRecebeu" runat="server" ID="rbContaPagarNao" Text="Não" /></label>
					    </div>
				    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-md-12 col-sm-12 col-xs-12">
                    <label>Pago para</label>
                    <asp:TextBox runat="server" MaxLength="250" ID="txtContaPagarRecebidoDe" CssClass="form-control"></asp:TextBox>
                </div>

                <asp:UpdatePanel runat="server" ID="upnlListaPagamento" RenderMode="Block">
                    <ContentTemplate>
                        <div class="col-md-3 col-sm-3 col-xs-12">
                            <label>ou</label>
                            <asp:DropDownList AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlTipoPagamento_SelectedIndexChanged" runat="server" ID="ddlTipoPagamento">
                                <asp:ListItem Value="1">Fornecedor</asp:ListItem>
                                <asp:ListItem Value="4">Clínica</asp:ListItem>
                                <asp:ListItem Value="5">Laboratorio/Fabricante</asp:ListItem>
                                <asp:ListItem Value="2">Colaborador</asp:ListItem>
                                <asp:ListItem Value="3">Responsável</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    
                        <div class="col-md-9 col-sm-9 col-xs-12">
                            <label>&nbsp;</label>
                            <asp:DropDownList runat="server" ID="ddlPagoPara" CssClass="select2"></asp:DropDownList>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

            <div class="row">
                <div class="col-md-3 col-sm-6 col-xs-12">
                    <label>Conta</label>
                    <asp:DropDownList runat="server" ID="ddlContaPagarConta" CssClass="form-control"></asp:DropDownList>
                </div>

                <div class="col-md-3 col-sm-6 col-xs-12">
                    <label>Forma pagamento</label>
                    <asp:DropDownList runat="server" ID="ddlContaPagarFormaPagamento" CssClass="form-control"></asp:DropDownList>
                </div>
                                
                <div class="col-md-3 col-sm-6 col-xs-12">
                    <label>Classificação</label>
                    <asp:DropDownList runat="server" ID="ddlContaPagarClassificacao" CssClass="form-control"></asp:DropDownList>
                </div>

                <div class="col-md-3 col-sm-6 col-xs-12">
                    <label>Centro de custo</label>
                    <asp:DropDownList runat="server" ID="ddlContaPagarCentroDeCustos" CssClass="form-control"></asp:DropDownList>
                </div>
                                
                <div class="col-md-12 col-sm-12 col-xs-12">
                    <label>Outras informações</label>
                    <asp:TextBox runat="server" ID="txtContaPagarOutrasInformacoes" TextMode="MultiLine" Rows="3" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
        
            <br /><div class="clearfix"></div>
            <div class="row">
                <div class="col-md-2 col-sm-6 col-xs-12"><asp:LinkButton runat="server" CssClass="form-control btn btn-success swal-btn-basic" ID="lnkSalvar" OnClick="btnContaPagarSalvar_Click"><i class="fa fa-check"></i> Salvar</asp:LinkButton></div>
                <div class="col-md-2 col-sm-6 col-xs-12"><asp:LinkButton runat="server" CssClass="form-control btn btn-danger-outline swal-btn-basic" ID="lnkCancelar" OnClick="lnkCancelar_Click"><i class="fa fa-close"></i> Cancelar</asp:LinkButton></div>
            </div>
        </div>
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cFooterScripts" runat="server">
</asp:Content>
