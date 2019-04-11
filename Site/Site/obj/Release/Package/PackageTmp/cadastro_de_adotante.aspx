<%@ Page Title="" Language="C#" MasterPageFile="~/_MLogado.master" AutoEventWireup="true" CodeBehind="cadastro_de_adotante.aspx.cs" Inherits="Site.cadastro_de_adotante" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cHeaderScripts" runat="server">
    <link rel="stylesheet" href="css/lib/datatables-net/datatables.min.css">
    <link rel="stylesheet" href="css/separate/vendor/datatables-net.min.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cConteudo" runat="server">
    <asp:Panel runat="server" ID="pnl01" DefaultButton="lnkSalvar">
        <div class="box-typical box-typical-padding">
            <h5 class="m-t-lg with-border">Cadastro de Adotante</h5>
            <div class="row">
                <div class="col-md-2 col-sm-2 col-xs-12">
                    <label class="form-control-label">Código</label>
                    <asp:TextBox readonly disabled runat="server" ID="txtCodigo" CssClass="form-control" Text="AUTOMATICO"></asp:TextBox>
                </div>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <label class="form-control-label">Nome</label>
                    <asp:TextBox runat="server" ID="txtNome" MaxLength="250" CssClass="form-control primeiro"></asp:TextBox>
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
                <div class="col-md-3 col-sm-6 col-xs-12">
                    <label class="form-control-label">RG</label>
                    <asp:TextBox runat="server" ID="txtRG" MaxLength="20" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-3 col-sm-6 col-xs-12">
                    <label class="form-control-label">CPF</label>
                    <asp:TextBox runat="server" ID="txtCPF" CssClass="form-control cpf"></asp:TextBox>
                </div>

                <div class="col-md-4 col-sm-6 col-xs-12">
                    <label class="form-control-label">Profissão</label>
                    <asp:TextBox runat="server" ID="txtProfissao" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-2 col-sm-6 col-xs-12">
                    <label class="form-control-label">Data nasc.</label>
                    <asp:TextBox runat="server" ID="txtDataNascimento" CssClass="form-control date-mask"></asp:TextBox>
                </div>
            </div>

            <div class="row">
                <div class="col-md-3 col-sm-3 col-xs-12">
                    <label class="form-control-label">E-mail</label>
                    <asp:TextBox runat="server" ID="txtEmail" MaxLength="250" CssClass="form-control emails"></asp:TextBox>
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
                            <li class="nav-item"><a class="nav-link" href="#tabs-Adocoes" role="tab" data-toggle="tab"><span class="nav-link-in">Adoções</span></a></li>
                            <li class="nav-item"><a class="nav-link" href="#tabs-Adotar" role="tab" data-toggle="tab"><span class="nav-link-in">Nova Adoção</span></a></li>
                            <li class="nav-item"><asp:Button OnClick="btnNovoEndereco_Click" runat="server" ID="btnNovoEndereco" Text="Novo endereço" CssClass="btn btn-default pull-right" /></li>
                        </ul>
                    </div>
                </div><!--.tabs-section-nav-->

                <div class="tab-content" style="min-height:200px;">
                    <div role="tabpanel" class="tab-pane fade in active" id="tabs-Enderecos">
                        <asp:UpdatePanel runat="server" ID="upnlEndereco">
                            <ContentTemplate>
                                <div class="row">
                                    <div class="col-md-2 col-sm-4 col-xs-12">
                                        <label>Cód</label>
                                        <asp:TextBox runat="server" ID="txtEnderecoCodigo" readonly disabled CssClass="form-control" Text="AUTOMATICO" />
                                    </div>
                                    <div class="col-md-3 col-sm-8 col-xs-12">
                                        <label>CEP</label>
                                        <div class="input-group">
                                            <asp:TextBox Height="100%" runat="server" ID="txtEnderecoCEP" MaxLength="10" CssClass="form-control cep-mask" />
                                            <asp:LinkButton runat="server" ID="lnkCarregaCEP" CssClass="input-group-addon btn btn-info" OnClick="lnkCarregaCEP_Click"><i class="fa fa-refresh"></i></asp:LinkButton>
                                        </div>
                                    </div>
                                    <div class="col-md-7 col-sm-12 col-xs-12">
                                        <label>Endereço</label>
                                        <asp:TextBox runat="server" ID="txtEnderecoLogradouro" MaxLength="250" CssClass="form-control" />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-2 col-sm-4 col-xs-12">
                                        <label>Número</label>
                                        <asp:TextBox runat="server" ID="txtEnderecoNumero" MaxLength="250" CssClass="form-control" />
                                    </div>
                                    <div class="col-md-5 col-sm-8 col-xs-12">
                                        <label>Bairro</label>
                                        <asp:TextBox runat="server" ID="txtEnderecoBairro" MaxLength="250" CssClass="form-control" />
                                    </div>
                                    <div class="col-md-4 col-sm-8 col-xs-12">
                                        <label>Cidade</label>
                                        <asp:TextBox runat="server" ID="txtEnderecoCidade" MaxLength="250" CssClass="form-control" />
                                    </div>
                                    <div class="col-md-1 col-sm-4 col-xs-12">
                                        <label>UF</label>
                                        <asp:TextBox runat="server" ID="txtEnderecoUF" MaxLength="2" CssClass="form-control" />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12 col-sm-12 col-xs-12">
                                        <label>Complemento</label>
                                        <asp:TextBox runat="server" ID="txtEnderecoComplemento" MaxLength="250" CssClass="form-control" />
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>

                    <div role="tabpanel" class="tab-pane fade in" id="tabs-Adocoes">
                        <asp:UpdatePanel runat="server" ID="upnlAnimaisAdotados">
                            <ContentTemplate>
                                <div class="row">
                                    <div class="col-xl-12">
                                        <table class="display table table-bordered tabelasComOrder" cellspacing="0" width="100%">
                                            <thead>
                                                <tr>
                                                    <th nowrap="nowrap">Animal</th>
                                                    <th nowrap="nowrap">Data adoção</th>
                                                    <th>Desitiu?</th>
                                                    <th width="100%">Endereço</th>
                                                    <th width="30px"></th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:Repeater runat="server" ID="rptAnimaisAdotados">
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td nowrap="nowrap"><%#Eval("Animal.SNome") %></td>
                                                            <td><%#Convert.ToDateTime(Eval("DtmAdocao")).ToString("dd/MM/yyyy") %></td>
                                                            <td><%#Eval("DtmDevolucao") == null ? "Não" : Convert.ToDateTime(Eval("DtmDevolucao")).ToString("dd/MM/yyyy") %></td>
                                                            <td><%#Eval("EnderecoOndeFicaOAnimal.SEndereco") %>, <%#Eval("EnderecoOndeFicaOAnimal.SNumero") %> - <%#Eval("EnderecoOndeFicaOAnimal.SBairro") %>, <%#Eval("EnderecoOndeFicaOAnimal.SCidade") %>/<%#Eval("EnderecoOndeFicaOAnimal.SUF") %> - <%#Eval("EnderecoOndeFicaOAnimal.SCEP") %></td>
                                                            <td><asp:LinkButton runat="server" ID="btnRemoverEndereco" CssClass="btn btn-danger" CommandName="Remover" CommandArgument='<%#Eval("Id") %>'><i class="fa fa-remove"> </i></asp:LinkButton></td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>

                    <div role="tabpanel" class="tab-pane fade in" id="tabs-Adotar">
                        <asp:UpdatePanel runat="server" ID="upnlNovaAdocao">
                            <ContentTemplate>
                                <asp:HiddenField runat="server" ID="hdfIDAdocao" />
                                <div class="row">
                                    <div class="col-md-6 col-sm-12">
                                        <label>Animal</label>
                                        <asp:DropDownList runat="server" ID="ddlAdotarAnimais" CssClass="select2"></asp:DropDownList>
                                    </div>
                                    
                                    <div class="col-md-2 col-sm-6 col-xs-12">
                                        <label class="form-control-label">Data adoção</label>
                                        <asp:TextBox runat="server" ID="txtAdotarDataAdocao" CssClass="form-control daterange3"></asp:TextBox>
                                    </div>

                                    <div class="col-md-4 col-sm-6 col-xs-12">
                                        <label>Endereço</label>
                                        <asp:CheckBox runat="server" ID="cbxAdotarEndereco" Text="Mesmo do adotante" CssClass="checkbox" AutoPostBack="true" OnCheckedChanged="cbxAdotarEndereco_CheckedChanged" />
                                    </div>
                                </div>

                                <div class="row">
                                    <asp:HiddenField runat="server" ID="hdfAdotarEnderecoID" />
                                    <div class="col-md-3 col-sm-4 col-xs-12">
                                        <label>CEP</label>
                                        <div class="input-group">
                                            <asp:TextBox Height="100%" runat="server" ID="txtAdotarCEP" MaxLength="10" CssClass="form-control cep-mask" />
                                            <asp:LinkButton runat="server" ID="lnkAdotarCarregarCEP" CssClass="input-group-addon btn btn-info" OnClick="lnkAdotarCarregarCEP_Click"><i class="fa fa-refresh"></i></asp:LinkButton>
                                        </div>
                                    </div>
                                    <div class="col-md-9 col-sm-8 col-xs-12">
                                        <label>Endereço</label>
                                        <asp:TextBox runat="server" ID="txtAdotarEndereco" MaxLength="250" CssClass="form-control" />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-2 col-sm-4 col-xs-12">
                                        <label>Número</label>
                                        <asp:TextBox runat="server" ID="txtAdotarNumero" MaxLength="250" CssClass="form-control" />
                                    </div>
                                    <div class="col-md-5 col-sm-8 col-xs-12">
                                        <label>Bairro</label>
                                        <asp:TextBox runat="server" ID="txtAdotarBairro" MaxLength="250" CssClass="form-control" />
                                    </div>
                                    <div class="col-md-4 col-sm-8 col-xs-8">
                                        <label>Cidade</label>
                                        <asp:TextBox runat="server" ID="txtAdotarCidade" MaxLength="250" CssClass="form-control" />
                                    </div>
                                    <div class="col-md-1 col-sm-4 col-xs-4">
                                        <label>UF</label>
                                        <asp:TextBox runat="server" ID="txtAdotarUF" MaxLength="2" CssClass="form-control" />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <label>Complemento</label>
                                        <asp:TextBox runat="server" ID="txtAdotarComplemento" MaxLength="250" CssClass="form-control" />
                                    </div>
                                </div>
                                
                                <div class="row">
                                    <div class="col-md-2 col-sm-4 col-xs-12"><asp:LinkButton runat="server" CssClass="form-control btn btn-success swal-btn-basic" ID="lnkIncluirAdocao" OnClick="lnkIncluirAdocao_Click"><i class="fa fa-plus-circle"></i> Incluir</asp:LinkButton></div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </section>
            <br /><div class="clearfix"></div>
            <div class="row">
                <div class="col-md-2 col-sm-4 col-xs-12"><asp:LinkButton runat="server" CssClass="form-control btn btn-info swal-btn-basic" ID="lnkNovo" OnClick="lnkNovo_Click"><i class="fa fa-file"></i> Novo</asp:LinkButton></div>
                <div class="col-md-2 col-sm-4 col-xs-12"><asp:LinkButton runat="server" CssClass="form-control btn btn-success swal-btn-basic" ID="lnkSalvar" OnClick="lnkSalvar_Click"><i class="fa fa-check"></i> Salvar</asp:LinkButton></div>
                <div class="col-md-2 col-sm-4 col-xs-12"><asp:LinkButton runat="server" CssClass="form-control btn btn-danger-outline swal-btn-basic" ID="lnkCancelar" OnClick="lnkCancelar_Click"><i class="fa fa-close"></i> Cancelar</asp:LinkButton></div>
            </div>
        </div>
    </asp:Panel>
    <script> $('#example, .tabelasdinamicas').DataTable();</script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cFooterScripts" runat="server">
</asp:Content>