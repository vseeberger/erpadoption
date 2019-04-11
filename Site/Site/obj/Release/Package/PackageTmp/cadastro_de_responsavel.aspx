<%@ Page Title="" Language="C#" MasterPageFile="~/_MLogado.master" AutoEventWireup="true" CodeBehind="cadastro_de_responsavel.aspx.cs" Inherits="Site.cadastro_de_responsavel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cHeaderScripts" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cConteudo" runat="server">
<%--    <asp:ScriptManager runat="server" ID="src001"></asp:ScriptManager>--%>
    <asp:Panel runat="server" ID="pnl01" DefaultButton="lnkSalvar">
        <div class="box-typical box-typical-padding">
            <h5 class="m-t-lg with-border">Cadastro de Padrinhos</h5>
            <div class="row">
                <div class="col-md-2 col-sm-4 col-xs-12">
                    <label class="form-control-label">Código</label>
                    <asp:TextBox readonly disabled runat="server" ID="txtCodigo" CssClass="form-control" Text="AUTOMATICO"></asp:TextBox>
                </div>
                <div class="col-md-10 col-sm-8 col-xs-12">
                    <label class="form-control-label">Nome</label>
                    <asp:TextBox runat="server" ID="txtNome" MaxLength="250" CssClass="form-control primeiro"></asp:TextBox>
                </div>
                    

                <div class="col-md-4 col-sm-4 col-xs-12">
                    <label class="form-control-label">RG</label>
                    <asp:TextBox runat="server" ID="txtRG" MaxLength="20" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-4 col-sm-4 col-xs-12">
                    <label class="form-control-label">CPF</label>
                    <asp:TextBox runat="server" ID="txtCPF" CssClass="form-control cpf"></asp:TextBox>
                </div>
                <div class="col-md-4 col-sm-4 col-xs-12">
                    <label class="form-control-label">Data nasc.</label>
                    <asp:TextBox runat="server" ID="txtDataNascimento" CssClass="form-control date-mask"></asp:TextBox>
                </div>

                <div class="col-md-4 col-sm-4 col-xs-12">
                    <label class="form-control-label">Sexo</label>
                    <div class="form-group">
						<div class="btn-group" data-toggle="buttons">
							<label runat="server" id="lblSMasc"><asp:RadioButton GroupName="rdSex" runat="server" ID="rdMasc" Text="Masculino" /></label>
							<label runat="server" id="lblSFemi"><asp:RadioButton GroupName="rdSex" runat="server" ID="rdFem" Text="Feminino" /></label>
						</div>
					</div>
                </div>
            </div>

            <div class="row">
                <div class="col-md-3 col-sm-3 col-xs-12">
                    <label class="form-control-label">E-mail</label>
                    <asp:TextBox runat="server" ID="txtEmail" MaxLength="255" CssClass="form-control emails"></asp:TextBox>
                </div>
                <div class="col-md-3 col-sm-3 col-xs-12">
                    <label class="form-control-label">Telefone</label>
                    <asp:TextBox runat="server" ID="txtTelefone" MaxLength="50" CssClass="form-control fone-mask"></asp:TextBox>
                </div>
                <div class="col-md-3 col-sm-3 col-xs-12">
                    <label class="form-control-label">Celular</label>
                    <asp:TextBox runat="server" ID="txtCelular" MaxLength="50" CssClass="form-control cel-mask"></asp:TextBox>
                </div>
                <div class="col-md-3 col-sm-3 col-xs-12">
                    <label class="form-control-label">Outros contatos</label>
                    <asp:TextBox runat="server" MaxLength="50" ID="txtOutroContato" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <br /><div class="clearfix"></div>        
            <section id="Tabs" class="tabs-section">
                <div class="tabs-section-nav tabs-section-nav-icons">
                    <div class="tbl">
                        <ul class="nav" role="tablist">
                            <li class="nav-item"><a class="nav-link active" href="#tabs-Enderecos" role="tab" data-toggle="tab"><span class="nav-link-in">Endereço</span></a></li>
                            <li class="nav-item"><asp:Button OnClick="btnNovoEndereco_Click" runat="server" ID="btnNovoEndereco" Text="Novo endereço" CssClass="btn btn-default pull-right" /></li>
                        </ul>
                    </div>
                </div><!--.tabs-section-nav-->

                <div class="tab-content" style="min-height:200px;">
                    <div role="tabpanel" class="tab-pane fade in active" id="tabs-Enderecos">
                        <asp:UpdatePanel runat="server" ID="upnlEndereco">
                            <ContentTemplate>
                                <div class="row">
                                    <div class="col-md-2 col-sm-2 col-xs-12">
                                        <label>Cód</label>
                                        <asp:TextBox runat="server" ID="txtEnderecoCodigo" readonly disabled CssClass="form-control" Text="AUTOMATICO" />
                                    </div>
                                    <div class="col-md-8 col-sm-8 col-xs-12">
                                        <label>Endereço</label>
                                        <asp:TextBox runat="server" ID="txtEnderecoLogradouro" MaxLength="250" CssClass="form-control" />
                                    </div>
                                    <div class="col-md-2 col-sm-2 col-xs-12">
                                        <label>Número</label>
                                        <asp:TextBox runat="server" ID="txtEnderecoNumero" MaxLength="250" CssClass="form-control" />
                                    </div>


                                    <div class="col-md-4 col-sm-6 col-xs-12">
                                        <label>Bairro</label>
                                        <asp:TextBox runat="server" ID="txtEnderecoBairro" MaxLength="250" CssClass="form-control" />
                                    </div>
                                    <div class="col-md-4 col-sm-6 col-xs-12">
                                        <label>Cidade</label>
                                        <asp:TextBox runat="server" ID="txtEnderecoCidade" MaxLength="250" CssClass="form-control" />
                                    </div>
                                    <div class="col-md-1 col-sm-6 col-xs-12">
                                        <label>UF</label>
                                        <asp:TextBox runat="server" ID="txtEnderecoUF" MaxLength="2" CssClass="form-control" />
                                    </div>
                                    <div class="col-md-3 col-sm-6 col-xs-12">
                                        <label>CEP</label>
                                        <div class="input-group">
                                            <asp:TextBox runat="server" ID="txtEnderecoCEP" MaxLength="10" CssClass="form-control cep-mask" />
                                            <asp:LinkButton runat="server" ID="lnkCarregaCEP" CssClass="input-group-addon btn btn-info" OnClick="lnkCarregaCEP_Click"><i class="fa fa-refresh"></i></asp:LinkButton>
                                        </div>
                                    </div>

                                    <div class="col-md-12 col-sm-12 col-xs-12">
                                        <label>Complemento</label>
                                        <asp:TextBox runat="server" ID="txtEnderecoComplemento" MaxLength="250" CssClass="form-control" />
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </section>
            <br /><div class="clearfix"></div>
            <div class="row">
                <div class="col-md-2 col-sm-6 col-xs-12"><asp:LinkButton runat="server" CssClass="form-control btn btn-success swal-btn-basic" ID="lnkSalvar" OnClick="lnkSalvar_Click"><i class="fa fa-check"></i> Salvar</asp:LinkButton></div>
                <div class="col-md-2 col-sm-6 col-xs-12"><asp:LinkButton runat="server" CssClass="form-control btn btn-danger-outline swal-btn-basic" ID="lnkCancelar" OnClick="lnkCancelar_Click"><i class="fa fa-close"></i> Cancelar</asp:LinkButton></div>
            </div>
        </div>
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cFooterScripts" runat="server">
</asp:Content>