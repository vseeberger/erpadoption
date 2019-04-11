<%@ Page Title="" Language="C#" MasterPageFile="~/_MLogado.master" AutoEventWireup="true" CodeBehind="cadastro_de_conta_receber.aspx.cs" Inherits="Site.cadastro_de_conta_receber" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cHeaderScripts" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cConteudo" runat="server">
    <asp:Panel runat="server" ID="pnl01" DefaultButton="lnkSalvar">
        <div class="box-typical box-typical-padding">
            <h5 class="m-t-lg with-border">Lançar conta a receber</h5>
            <asp:HiddenField runat="server" ID="hdfPeriodoHerdado" />
            <asp:HiddenField runat="server" ID="hdfContaReceberID" />
            <asp:HiddenField runat="server" ID="hdfContaReceberDataPagamento" />

            <div class="row">
                <div class="col-md-12 col-sm-12 col-xs-12">
                    <asp:TextBox runat="server" ID="txtContaReceberDescricao" CssClass="form-control" placeholder="Descrição (opcional)"></asp:TextBox>
                </div>

                <div class="col-md-4 col-sm-6 col-xs-12">
                    <label>Núm. Documento</label>
                    <div class="form-group">
				        <div class="input-group">
					        <div class="input-group-addon"><i class="fa fa-archive"> </i></div>
					        <asp:TextBox runat="server" ID="txtContaReceberNumDoc" CssClass="form-control"></asp:TextBox>
				        </div>
			        </div>
                </div>
                <div class="col-md-2 col-sm-6 col-xs-12">
                    <label>Vencimento</label>
                    <asp:TextBox runat="server" ID="txtContaReceberDataPrevisao" CssClass="form-control daterange3"></asp:TextBox>
                </div>

                <div class="col-md-3 col-sm-6 col-xs-12">
                    <label>Valor</label>
                    <div class="form-group">
				        <div class="input-group">
					        <div class="input-group-addon">R$</div>
					        <asp:TextBox runat="server" ID="txtContaReceberValor" CssClass="form-control money-mask"></asp:TextBox>
				        </div>
			        </div>
                </div>

                <div class="col-md-3 col-sm-6 col-xs-12">
                    <label class="form-control-label">Já Recebeu?</label>
                    <div class="form-group">
				        <div class="btn-group" data-toggle="buttons">
					        <label runat="server" id="lblSim"><asp:RadioButton GroupName="rdRecebeu" runat="server" ID="rdSim" Text="Sim" /></label>
					        <label runat="server" id="lblNao"><asp:RadioButton GroupName="rdRecebeu" runat="server" ID="rdNao" Text="Não" /></label>
				        </div>
			        </div>
                </div>

                <div class="col-md-12 col-sm-12 col-xs-12">
                    <label>Recebido de</label>
                    <asp:TextBox runat="server" ID="txtContaReceberRecebidoDe" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="row">
                <div class="col-md-3 col-sm-6 col-xs-12">
                    <label>Conta</label>
                    <asp:DropDownList runat="server" ID="ddlContaReceberContaBancaria" CssClass="form-control select"></asp:DropDownList>
                </div>

                <div class="col-md-3 col-sm-6 col-xs-12">
                    <label>Data de competência</label>
                    <asp:TextBox runat="server" ID="txtContaReceberCompetencia" CssClass="form-control daterange3"></asp:TextBox>
                </div>
                                
                <div class="col-md-3 col-sm-6 col-xs-12">
                    <label>Forma pagamento</label>
                    <asp:DropDownList runat="server" ID="ddlContaReceberFormaPagamento" CssClass="form-control select"></asp:DropDownList>
                </div>
                <div class="col-md-3 col-sm-6 col-xs-12">
                    <label>Classificação</label>
                    <asp:DropDownList runat="server" ID="ddlContaReceberOrigem" CssClass="form-control select"></asp:DropDownList>
                </div>
                <div class="col-md-12 col-sm-12 col-xs-12">
                    <label>Outras informações</label>
                    <asp:TextBox runat="server" ID="txtContaReceberDetalhes" TextMode="MultiLine" Rows="3" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <br /><div class="clearfix"></div>
            <div class="row">
                <div class="col-md-2 col-sm-6 col-xs-12"><asp:LinkButton runat="server" CssClass="form-control btn btn-success swal-btn-basic" ID="lnkSalvar" OnClick="btnContaReceberSalvar_Click"><i class="fa fa-check"></i> Salvar</asp:LinkButton></div>
                <div class="col-md-2 col-sm-6 col-xs-12"><asp:LinkButton runat="server" CssClass="form-control btn btn-danger-outline swal-btn-basic" ID="lnkCancelar" OnClick="lnkCancelar_Click"><i class="fa fa-close"></i> Cancelar</asp:LinkButton></div>
            </div>
        </div>
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cFooterScripts" runat="server">
</asp:Content>