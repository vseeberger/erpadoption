<%@ Page Title="" Language="C#" MasterPageFile="~/_MLogado.master" AutoEventWireup="true" CodeBehind="cadastro_de_colaborador.aspx.cs" Inherits="Site.cadastro_de_colaborador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cHeaderScripts" runat="server">
    <link rel="stylesheet" href="css/lib/clockpicker/bootstrap-clockpicker.min.css">
    <link rel="stylesheet" href="css/separate/vendor/bootstrap-daterangepicker.min.css">
    <link rel="stylesheet" href="css/lib/clockpicker/bootstrap-clockpicker.min.css">
    <link rel="stylesheet" href="css/separate/vendor/fancybox.min.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cConteudo" runat="server">
    <asp:Panel runat="server" ID="pnl01" DefaultButton="lnkSalvar">
        <div class="box-typical box-typical-padding">
            <h5 class="m-t-lg with-border">Cadastro de Colaborador</h5>
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
                            <li class="nav-item"><a class="nav-link active" href="#tabs-Documentos" role="tab" data-toggle="tab"><span class="nav-link-in">Documentos</span></a></li>
                            <li class="nav-item"><a class="nav-link" href="#tabs-Detalhamentos" role="tab" data-toggle="tab"><span class="nav-link-in">Detalhamentos</span></a></li>
                            <li class="nav-item"><a class="nav-link" href="#tabs-Ferias" role="tab" data-toggle="tab"><span class="nav-link-in">Férias</span></a></li>
                            <li class="nav-item"><a class="nav-link"><span class="nav-link-in">Benefícios/Descontos</span></a></li>
                            <li class="nav-item"><a class="nav-link"><span class="nav-link-in">Exames</span></a></li>
                            <li class="nav-item"><a class="nav-link" href="#tabs-Dependentes" role="tab" data-toggle="tab"><span class="nav-link-in">Dependentes</span></a></li>
                            <li class="nav-item"><a class="nav-link" href="#tabs-Enderecos" role="tab" data-toggle="tab"><span class="nav-link-in">Endereço</span></a></li>
                        </ul>
                    </div>
                </div><!--.tabs-section-nav-->

                <div class="tab-content" style="min-height:200px;">
                    <div role="tabpanel" class="tab-pane fade in active" id="tabs-Documentos">
                        <div class="row">
                            <div class="col-md-2 col-sm-4 col-xs-12">
                                <label class="form-control-label">RG</label>
                                <asp:TextBox runat="server" ID="txtRG" MaxLength="20" CssClass="form-control numero"></asp:TextBox>
                            </div>
                            <div class="col-md-1 col-sm-2 col-xs-12">
                                <label class="form-control-label">Órgão</label>
                                <asp:TextBox runat="server" ID="txtRGOrgao" MaxLength="5" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-1 col-sm-2 col-xs-12">
                                <label class="form-control-label">UF</label>
                                <asp:TextBox runat="server" ID="txtRGUF" MaxLength="2" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-2 col-sm-4 col-xs-12">
                                <label class="form-control-label" title="Data de expedição">Data exp.</label>
                                <asp:TextBox runat="server" ID="txtRGData" MaxLength="10" CssClass="form-control daterange3 date-mask"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-3 col-sm-6 col-xs-12">
                                <label class="form-control-label">CTPS</label>
                                <asp:TextBox runat="server" ID="txtCTPS" MaxLength="30" CssClass="form-control numero"></asp:TextBox>
                            </div>
                            <div class="col-md-2 col-sm-4 col-xs-12">
                                <label class="form-control-label">Série</label>
                                <asp:TextBox runat="server" ID="txtCTPSSerie" MaxLength="10" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-1 col-sm-2 col-xs-12">
                                <label class="form-control-label">UF</label>
                                <asp:TextBox runat="server" ID="txtCTPSUF" MaxLength="2" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="col-md-2 col-sm-6 col-xs-12">
                                <label class="form-control-label">Tít. Eleitor</label>
                                <asp:TextBox runat="server" ID="txtTitEleitor" MaxLength="50" CssClass="form-control numero"></asp:TextBox>
                            </div>
                            <div class="col-md-2 col-sm-4 col-xs-12">
                                <label class="form-control-label">Zona</label>
                                <asp:TextBox runat="server" ID="txtTitEleitorZona" MaxLength="50" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-2 col-sm-2 col-xs-12">
                                <label class="form-control-label">Seção</label>
                                <asp:TextBox runat="server" ID="txtTitEleitorSecao" MaxLength="50" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-3 col-sm-6 col-xs-12">
                                <label class="form-control-label">PIS/PASEP</label>
                                <asp:TextBox runat="server" ID="txtPISPASEP" MaxLength="50" CssClass="form-control numero"></asp:TextBox>
                            </div>

                            <div class="col-md-2 col-sm-2 col-xs-4">
                                <label>Estrangeiro?</label>
                                <asp:CheckBox runat="server" ID="cbxEstrangeiro" Text="&nbsp;" CssClass="checkbox" />
                            </div>
                            <div class="col-md-2 col-sm-4 col-xs-8">
                                <label class="form-control-label">Passaporte</label>
                                <asp:TextBox runat="server" ID="txtPassaporte" MaxLength="50" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div role="tabpanel" class="tab-pane fade in" id="tabs-Detalhamentos">
                        <div class="row">
                            <div class="col-md-6 col-sm-6 col-xs-12">
                                <label class="form-control-label">Nome mãe</label>
                                <asp:TextBox runat="server" ID="txtNomeMae" MaxLength="50" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-6 col-sm-6 col-xs-12">
                                <label class="form-control-label">Nome pai</label>
                                <asp:TextBox runat="server" ID="txtNomePai" MaxLength="50" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-2 col-sm-4 col-xs-8">
                                <label class="form-control-label">Naturalidade</label>
                                <asp:TextBox runat="server" ID="txtNaturalidade" MaxLength="50" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-2 col-sm-4 col-xs-4">
                                <label class="form-control-label" title="Natural de qual estado">UF</label>
                                <asp:TextBox runat="server" ID="txtNaturalidadeUF" MaxLength="2" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-2 col-sm-4 col-xs-12">
                                <label class="form-control-label">Nacionalidade</label>
                                <asp:TextBox runat="server" ID="txtNacionalidade" MaxLength="50" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="col-md-2 col-sm-4 col-xs-12">
                                <label class="form-control-label">Sangue</label>
                                <asp:TextBox runat="server" ID="txtTipoSanguineo" MaxLength="4" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-2 col-sm-4 col-xs-12">
                                <label class="form-control-label">Estado civil</label>
                                <asp:DropDownList runat="server" ID="ddlEstadoCivil" CssClass="form-control">
                                    <asp:ListItem Value="Solteiro(a)" />
                                    <asp:ListItem Value="Casado(a)" />
                                    <asp:ListItem Value="Separado(a)" />
                                    <asp:ListItem Value="Divorciado(a)" />
                                    <asp:ListItem Value="Viúvo(a)" />
                                    <asp:ListItem Value="Outro" />
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-2 col-sm-4 col-xs-12">
                                <label class="form-control-label">Qtd. Filhos</label>
                                <asp:TextBox runat="server" ID="txtQtdFilhos" MaxLength="4" CssClass="form-control numero"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-2 col-sm-2 col-xs-12">
                                <label title="Dia de pagamento">Dia pagto.</label>
                                <asp:TextBox runat="server" ID="txtDiaPagto" CssClass="form-control numero"></asp:TextBox>
                            </div>

                            <div class="col-md-2 col-sm-2 col-xs-12">
                                <br />
                                <asp:CheckBox ToolTip="Marcar caso o NÃO seja colaborador" runat="server" ID="cbxDiarista" Text="Freelance" TextAlign="Right" CssClass="checkbox" />
                                <asp:CheckBox ToolTip="Marcar caso o colaborador receba no dia da diária" runat="server" ID="cbxRecebePagamentoNaDiaria" TextAlign="Right" Text="Recebe dia" CssClass="checkbox" />
                            </div>

                            <div class="col-md-2 col-sm-3 col-xs-12">
                                <label>Entrada (hora)</label>
                                <asp:TextBox runat="server" ID="txtDahoraEntrada" CssClass="form-control clockpicker"></asp:TextBox>
                            </div>

                            <div class="col-md-2 col-sm-3 col-xs-12">
                                <label>Saída (hora)</label>
                                <asp:TextBox runat="server" ID="txtDahoraSaida" CssClass="form-control clockpicker"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-3 col-sm-6 col-xs-12">
                                <label title="Será considerado o salário APENAS quando NÃO for diarista">Salário</label>
                                <div class="input-group">
                                    <span class="input-group-addon "><i class="fa fa-money"></i></span>
                                    <asp:TextBox runat="server" ID="txtSalario" MaxLength="10" CssClass="form-control money-mask" />
                                </div>
                            </div>

                            <div class="col-md-2 col-sm-6 col-xs-12">
                                <label>Data Admissão</label>
                                <asp:TextBox runat="server" ID="txtDataAdmissao" CssClass="form-control date-mask"></asp:TextBox>
                            </div>

                            <div class="col-md-2 col-sm-6 col-xs-12">
                                <label>Data Demissão</label>
                                <asp:TextBox runat="server" ID="txtDataDemissao" CssClass="form-control date-mask"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-12 col-sm-12 col-xs-12">
                                <label>Trabalha nos dias</label><br />
                            </div>
                            <div class="col-md-12 col-sm-12 col-xs-12">
                                <asp:Checkbox CssClass="pull-left checkbox" runat="server" TextAlign="Right" Text="Segunda-feira" id="cbxSegunda" />
                                <asp:Checkbox CssClass="pull-left checkbox" runat="server" TextAlign="Right" Text="Terça-feira" id="cbxTerca" />
                                <asp:Checkbox CssClass="pull-left checkbox" runat="server" TextAlign="Right" Text="Quarta-feira" id="cbxQuarta" />
                                <asp:Checkbox CssClass="pull-left checkbox" runat="server" TextAlign="Right" Text="Quinta-feira" id="cbxQuinta" />
                                <asp:Checkbox CssClass="pull-left checkbox" runat="server" TextAlign="Right" Text="Sexta-feira" id="cbxSexta" />
                                <asp:Checkbox CssClass="pull-left checkbox" runat="server" TextAlign="Right" Text="Sábado" id="cbxSabado" />
                                <asp:Checkbox CssClass="pull-left checkbox" runat="server" TextAlign="Right" Text="Domingo" id="cbxDomingo" />
                            </div>
                        </div>
                    </div>

                    <div class="tab-pane fade in" id="tabs-Ferias">
                        <div class="row">
	                        <asp:UpdatePanel runat="server" ID="upnlFerias">
                                <ContentTemplate>
                                    <div class="col-md-2 col-sm-6 col-xs-12">
                                        <label>Competência: De</label>
                                        <asp:TextBox runat="server" ID="txtFeriasCompetenciaDe" CssClass="form-control date-mask"></asp:TextBox>
                                    </div>
                                    <div class="col-md-2 col-sm-6 col-xs-12">
                                        <label>Até</label>
                                        <asp:TextBox runat="server" ID="txtFeriasCompetenciaAte" CssClass="form-control date-mask"></asp:TextBox>
                                    </div>
                            
                                    <div class="col-md-2 col-sm-6 col-xs-12">
                                        <label>Período: De</label>
                                        <asp:TextBox runat="server" ID="txtFeriasPeriodoDe" CssClass="form-control date-mask"></asp:TextBox>
                                    </div>
                                    <div class="col-md-2 col-sm-6 col-xs-12">
                                        <label>Até</label>
                                        <asp:TextBox runat="server" ID="txtFeriasPeriodoAte" CssClass="form-control date-mask"></asp:TextBox>
                                    </div>

                                    <div class="col-md-3 col-sm-10 col-xs-10">
                                        <label>Observação</label>
                                        <asp:TextBox runat="server" ID="txtFeriasObservacoes" MaxLength="250" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-md-1 col-sm-2 col-xs-2">
                                        <label>&nbsp;</label>
                                        <asp:Button runat="server" ID="btnFeriasAdd" Text="+" OnClick="btnFeriasAdd_Click" CssClass="form-control btn btn-info" />
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <br /><div class="clearfix"></div>
                        <div class="row">
                            <div class="col-md-12 col-sm-12 col-xs-12">
                                <asp:UpdatePanel runat="server" ID="upnlFerias2">
                                    <ContentTemplate>
                                        <table class="display table table-bordered tabelasComOrder" cellspacing="0" width="100%">
                                            <thead>
                                                <tr>
                                                    <th>Competência</th>
                                                    <th>Período</th>
                                                    <th>Dias</th>
                                                    <th>Observação</th>
                                                    <th style="width:40px;"></th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:Panel runat="server" ID="pnlFerias" Visible="false">
                                                    <tr><td colspan="5" align="center">Nenhum registro encontrado!</td></tr>
                                                </asp:Panel>
                                                <asp:Repeater runat="server" ID="rptFerias" OnItemCommand="rptFerias_ItemCommand">
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td align="center"><%#Convert.ToDateTime(Eval("DtmCompetenciaDe")).ToString("dd/MM/yyy") %><br />até<br /><%#Convert.ToDateTime(Eval("DtmCompetenciaAte")).ToString("dd/MM/yyy") %></td>
                                                            <td align="center"><%#Convert.ToDateTime(Eval("DtmPeriodoDe")).ToString("dd/MM/yyy") %><br />até<br /><%#Convert.ToDateTime(Eval("DtmPeriodoAte")).ToString("dd/MM/yyy") %></td>
                                                            <td align="center"><%#ContaDiasFerias(Convert.ToDateTime(Eval("DtmPeriodoDe")), Convert.ToDateTime(Eval("DtmPeriodoAte"))) %></td>
                                                            <td><%#Eval("SObservacoes") %></td>
                                                            <td><asp:Button runat="server" ID="lnbExcluir" Text="x" CommandArgument='<%#Eval("sequencia") %>' CommandName="Apagar" CssClass="form-control btn btn-danger" /></td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </tbody>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>

                    <div class="tab-pane fade in" id="tabs-Beneficios">
                        <div class="row">
	                        <asp:UpdatePanel runat="server" ID="upnlBeneficios01">
                                <ContentTemplate>
                                    <div class="col-md-2 col-sm-6 col-xs-12">
                                        <label>Tipo</label>
                                        <asp:DropDownList runat="server" ID="ddlBeneficioTipo">
                                            <asp:ListItem Value="B" Text="Benefício" />
                                            <asp:ListItem Value="D" Text="Desconto" />
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                        <label>Benefício/Desconto</label>
                                        <asp:DropDownList runat="server" ID="ddlBeneficios" CssClass="select2"></asp:DropDownList>
                                    </div>
                                    <div class="col-md-3 col-sm-10 col-xs-10">
                                        <label>Valor</label>
                                        <asp:TextBox runat="server" ID="txtBeneficioValor" CssClass="form-control money-mask"></asp:TextBox>
                                    </div>
                                    <div class="col-md-1 col-sm-2 col-xs-2">
                                        <label>&nbsp;</label>
                                        <asp:Button runat="server" ID="btnBeneficioAdd" OnClick="btnBeneficioAdd_Click" Text="+" CssClass="form-control btn btn-info" />
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <br /><div class="clearfix"></div>
                        <div class="row">
                            <div class="col-md-12 col-sm-12 col-xs-12">
                                <asp:UpdatePanel runat="server" ID="upnlBeneficios02">
                                    <ContentTemplate>
                                        <table class="display table table-bordered tabelasComOrder" cellspacing="0" width="100%">
                                            <thead>
                                                <tr>
                                                    <th>Beneficio/Desconto</th>
                                                    <th>Descricao</th>
                                                    <th>Valor</th>
                                                    <th style="width:40px;"></th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:Panel runat="server" ID="pnlBeneficios" Visible="false">
                                                    <tr><td colspan="4" align="center">Nenhum registro encontrado!</td></tr>
                                                </asp:Panel>
                                                <asp:Repeater runat="server" ID="rptBeneficios" OnItemCommand="rptBeneficios_ItemCommand">
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td><%#Eval("SNome") %></td>
                                                            <td><%#Convert.ToDateTime(Eval("DtmNascimento")).ToString("dd/MM/yyy") %></td>
                                                            <td><%#Eval("GrauParentesco.SDescricao") %></td>
                                                            <td><asp:Button runat="server" ID="lnbExcluir" Text="x" CommandArgument='<%#Eval("sequencia") %>' CommandName="Apagar" CssClass="form-control btn btn-danger" /></td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </tbody>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>

                    <div class="tab-pane fade in" id="tabs-Exames">

                    </div>

                    <div class="tab-pane fade in" id="tabs-Dependentes">
                        <div class="row">
	                        <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                                <ContentTemplate>
                                    <div class="col-md-5 col-sm-6 col-xs-12">
                                        <label>Nome</label>
                                        <asp:TextBox runat="server" ID="txtDependenteNome" CssClass="form-control" MaxLength="250"></asp:TextBox>
                                    </div>
                                    <div class="col-md-2 col-sm-6 col-xs-12">
                                        <label>Data nasc.</label>
                                        <asp:TextBox runat="server" ID="txtDependenteDataNascimento" CssClass="form-control date-mask"></asp:TextBox>
                                    </div>
                            
                                    <div class="col-md-4 col-sm-8 col-xs-12">
                                        <label>Parentesco</label>
                                        <asp:DropDownList runat="server" ID="ddlDependenteGrauParentesco" CssClass="form-control" />
                                    </div>
                                    <div class="col-md-1 col-sm-2 col-xs-2">
                                        <label>&nbsp;</label>
                                        <asp:Button runat="server" ID="btnDependenteAdd" Text="+" OnClick="btnDependenteAdd_Click" CssClass="form-control btn btn-info" />
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>

                         <br /><div class="clearfix"></div>
                        <div class="row">
                            <div class="col-md-12 col-sm-12 col-xs-12">
                                <asp:UpdatePanel runat="server" ID="UpdatePanel2">
                                    <ContentTemplate>
                                        <table class="display table table-bordered tabelasComOrder" cellspacing="0" width="100%">
                                            <thead>
                                                <tr>
                                                    <th>Nome</th>
                                                    <th>Data nasc.</th>
                                                    <th>Parentesco</th>
                                                    <th style="width:40px;"></th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:Panel runat="server" ID="pnlDependentes" Visible="false">
                                                    <tr><td colspan="4" align="center">Nenhum registro encontrado!</td></tr>
                                                </asp:Panel>
                                                <asp:Repeater runat="server" ID="rptDependentes" OnItemCommand="rptDependentes_ItemCommand">
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td><%#Eval("SNome") %></td>
                                                            <td><%#Convert.ToDateTime(Eval("DtmNascimento")).ToString("dd/MM/yyy") %></td>
                                                            <td><%#Eval("GrauParentesco.SDescricao") %></td>
                                                            <td><asp:Button runat="server" ID="lnbExcluir" Text="x" CommandArgument='<%#Eval("sequencia") %>' CommandName="Apagar" CssClass="form-control btn btn-danger" /></td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </tbody>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>

                    <div role="tabpanel" class="tab-pane fade in" id="tabs-Enderecos">
                        <asp:UpdatePanel runat="server" ID="upnlEndereco">
                            <ContentTemplate>
                                <div class="row">
                                    <div class="col-md-2 col-sm-2 col-xs-12">
                                        <label>Cód</label>
                                        <asp:TextBox runat="server" ID="txtEnderecoCodigo" readonly disabled CssClass="form-control" Text="AUTOMATICO" />
                                    </div>
                                    <div class="col-md-3 col-sm-4 col-xs-12">
                                        <label>CEP</label>
                                        <div class="input-group">
                                            <asp:TextBox runat="server" ID="txtEnderecoCEP" MaxLength="10" CssClass="form-control cep-mask" />
                                            <asp:LinkButton runat="server" ID="lnkCarregaCEP" CssClass="input-group-addon btn btn-info" OnClick="lnkCarregaCEP_Click"><i class="fa fa-refresh"></i></asp:LinkButton>
                                        </div>
                                    </div>
                                    <div class="col-md-5 col-sm-4 col-xs-12">
                                        <label>Endereço</label>
                                        <asp:TextBox runat="server" ID="txtEnderecoLogradouro" MaxLength="250" CssClass="form-control" />
                                    </div>
                                    <div class="col-md-2 col-sm-2 col-xs-12">
                                        <label>Número</label>
                                        <asp:TextBox runat="server" ID="txtEnderecoNumero" MaxLength="250" CssClass="form-control" />
                                    </div>


                                    <div class="col-md-5 col-sm-5 col-xs-12">
                                        <label>Bairro</label>
                                        <asp:TextBox runat="server" ID="txtEnderecoBairro" MaxLength="250" CssClass="form-control" />
                                    </div>
                                    <div class="col-md-5 col-sm-5 col-xs-12">
                                        <label>Cidade</label>
                                        <asp:TextBox runat="server" ID="txtEnderecoCidade" MaxLength="250" CssClass="form-control" />
                                    </div>
                                    <div class="col-md-2 col-sm-2 col-xs-12">
                                        <label>UF</label>
                                        <asp:TextBox runat="server" ID="txtEnderecoUF" MaxLength="2" CssClass="form-control" />
                                    </div>
                                    
                                    <div class="col-md-12 col-sm-12 col-xs-12">
                                        <label>Complemento</label>
                                        <asp:TextBox runat="server" ID="txtEnderecoComplemento" MaxLength="250" CssClass="form-control" />
                                    </div>
                                </div>
                                <div class="clearfix"></div><br />
                                <div class="row">
                                    <div class="col-md-12 col-sm-12 col-xs-12"><asp:UpdatePanel runat="server" ID="upnlNovoEnderecoBotao"><ContentTemplate><asp:Button OnClick="btnNovoEndereco_Click" runat="server" ID="btnNovoEndereco" Text="Novo endereço" CssClass="btn btn-default pull-right" /></ContentTemplate></asp:UpdatePanel></div>
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
