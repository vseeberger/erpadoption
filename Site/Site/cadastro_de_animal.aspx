<%@ Page Title="" Language="C#" MasterPageFile="~/_MLogado.master" AutoEventWireup="true" CodeBehind="cadastro_de_animal.aspx.cs" Inherits="Site.cadastro_de_animal" %>
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
        <h5 class="m-t-lg with-border">Cadastro de Animais</h5>
        <div class="row">
            <div class="col-md-2 col-sm-4 col-xs-12">
                <label class="form-control-label">Código</label>
                <asp:TextBox runat="server" ID="txtCodigo" readonly disabled Text="AUTOMATICO" CssClass="form-control"></asp:TextBox>
            </div>
                    
            <div class="col-md-5 col-sm-8 col-xs-12">
                <label class="form-control-label">Nome</label>
                <asp:TextBox runat="server" ID="txtNome" CssClass="form-control"></asp:TextBox>
            </div>
                    
            <div class="col-md-2 col-sm-4 col-xs-12">
                <label class="form-control-label">Espécie</label>
                <asp:DropDownList runat="server" ID="ddlEspecie" CssClass="bootstrap-select"></asp:DropDownList>
            </div>
                    
            <div class="col-md-3 col-sm-8 col-xs-12">
                <label class="form-control-label">Raça</label>
                <asp:DropDownList runat="server" ID="ddlRaca" CssClass="bootstrap-select"></asp:DropDownList>
            </div>
        </div>
        <div class="row">    
            <div class="col-md-3 col-sm-12 col-xs-12">
                <label class="form-control-label">Sexo</label>
                <div class="form-group">
					<div class="btn-group" data-toggle="buttons">
						<label runat="server" id="lblSMasc"><asp:RadioButton GroupName="rdSex" runat="server" ID="rdMasc" Text="Macho" /></label>
						<label runat="server" id="lblSFemi"><asp:RadioButton GroupName="rdSex" runat="server" ID="rdFem" Text="Fêmea" /></label>
					</div>
				</div>
            </div>
            <div class="col-md-9 col-sm-12 col-xs-12">
                <label class="form-control-label">Padrinho</label>
                <asp:DropDownList runat="server" ID="ddlResponsavel" CssClass="bootstrap-select"></asp:DropDownList>
            </div>
        </div>
        <div class="form-group row">
            <label for="exampleSelect" class="col-md-2 col-sm-4 col-xs-12 form-control-label">Observações</label>
            <div class="col-md-10 col-sm-8 col-xs-12">
                <asp:TextBox runat="server" ID="txtObservacoes" Rows="4" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
            
        <br />
        <section class="tabs-section">
            <div class="tabs-section-nav tabs-section-nav-icons">
                <div class="tbl">
                    <ul class="nav" role="tablist">
                        <li class="nav-item"><a class="nav-link active" href="#tabs-informacao" role="tab" data-toggle="tab"><span class="nav-link-in">Informações</span></a></li>
                        <li class="nav-item"><a runat="server" id="aAnamnese" class="nav-link" href="#tabs-anamnese" role="tab" data-toggle="tab"><span class="nav-link-in">Anamneses</span></a></li>
                        <li class="nav-item"><a runat="server" id="aVacinas" class="nav-link" href="#tabs-vacina" role="tab" data-toggle="tab"><span class="nav-link-in">Vacinas</span></a></li>
                        <li class="nav-item"><a runat="server" id="aExames" class="nav-link" href="#tabs-exame" role="tab" data-toggle="tab"><span class="nav-link-in">Exames</span></a></li>
                        <li class="nav-item"><a runat="server" id="aFotos" class="nav-link" href="#tabs-fotos" role="tab" data-toggle="tab"><span class="nav-link-in">Fotos</span></a></li>
                    </ul>
                </div>
            </div><!--.tabs-section-nav-->
            <div class="tab-content" style="min-height:200px;">
                <div role="tabpanel" class="tab-pane fade in active" id="tabs-informacao">
                    <div class="row">
                        <div class="col-md-2 col-sm-4 col-xs-12">
                            <label class="form-control-label">Nº chip</label>
                            <asp:TextBox runat="server" ID="txtNumeroChip" placeholder="se existir" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-2 col-sm-4 col-xs-12">
                            <label class="form-control-label">Cor</label>
                            <asp:TextBox runat="server" ID="txtCorDoAnimal" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-2 col-sm-4 col-xs-12">
                            <label class="form-control-label">Chegou</label>
                            <asp:TextBox runat="server" ID="txtDataChegou" CssClass="form-control date-mask"></asp:TextBox>
                        </div>
                        <div class="col-md-2 col-sm-4 col-xs-12">
                            <label class="form-control-label">Resgate</label>
                            <asp:TextBox runat="server" ID="txtDataResgate" CssClass="form-control date-mask"></asp:TextBox>
                        </div>
                        <div class="col-md-2 col-sm-4 col-xs-12">
                            <label class="form-control-label">Nasc.</label>
                            <asp:TextBox runat="server" ID="txtDataNascimento" CssClass="form-control daterange3"></asp:TextBox>
                        </div>
                        <div class="col-md-2 col-sm-4 col-xs-12">
                            <label>Porte</label>
                            <asp:DropDownList runat="server" ID="ddlPorte" CssClass="form-control"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="row">
                            
                        <div class="col-md-3 col-sm-4 col-xs-12">
                            <label class="form-control-label">Situação</label>
                            <asp:DropDownList runat="server" ID="ddlSituacao" readonly disabled CssClass="form-control"></asp:DropDownList>
                        </div>
                        <div class="col-md-4 col-sm-4 col-xs-12">
                            <label class="form-control-label">Castrado</label>
                            <asp:CheckBox runat="server" ID="cbxCastrado" CssClass="form-control flat" />
                        </div>
                        <div class="col-md-2 col-sm-4 col-xs-12">
                            <label class="form-control-label">Status</label>
                            <asp:DropDownList runat="server" ID="ddlStatus" CssClass="form-control"><asp:ListItem Value="1" Text="Ativo" /><asp:ListItem Value="0" Text="Inativo" /></asp:DropDownList>
                        </div>
                            
                    </div>
                    <div class="row" style="display:none;">
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <label>Pai</label>
                            <select class="form-control">
                                <option>Desconhecido</option>
                                <option>Nome de animais machos do sistema</option>
                            </select>
                        </div>
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <label>Mãe</label>
                            <select class="form-control">
                                <option>Desconhecido</option>
                                <option>Nome de animais fêmeas do sistema</option>
                            </select>
                        </div>
                    </div>
                </div>
                <div role="tabpanel" class="tab-pane fade" id="tabs-anamnese">
                    <div class="row">
                        <div class="col-md-12 col-sm-12 col-xs-12">
                            <asp:UpdatePanel runat="server" ID="upnlBotaoAnamnese">
                                <ContentTemplate><asp:Button runat="server" ID="btnInserirAnamnese" OnClick="btnInserirAnamnese_Click" Text="Inserir Anamnese" CssClass="btn btn-inline" /></ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-12 col-sm-12 col-xs-12">
                            <asp:UpdatePanel runat="server" ID="upnlAnamneses">
                                <ContentTemplate>
                                    <table class="display table table-bordered tabelasComOrder table-responsive" cellspacing="0" width="100%">
                                        <thead>
                                            <tr>
                                                <th width="100%">Descrição</th>
                                                <th>Data</th>
                                                <th>Peso</th>
                                                <th>Veterinário</th>
                                                <th></th>
                                                <th></th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Panel runat="server" ID="pnlAnamnesevazia" Visible="false">
                                                <tr><td colspan="5" align="center">Nenhum registro encontrado!</td></tr>
                                            </asp:Panel>
                                            <asp:Repeater runat="server" ID="rptAnamneses" OnItemCommand="rptAnamneses_ItemCommand">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td><%#Eval("SDescricao") %></td>
                                                        <td><%#Convert.ToDateTime(Eval("DtmRealizacao")).ToString("dd/MM/yyyy") %></td>
                                                        <td><%#Eval("DPeso") %></td>
                                                        <td><%#Eval("Veterinario.SNome") %></td>
                                                        <td><asp:LinkButton runat="server" ID="lnbVisualizar" CommandName="Visualizar" CommandArgument='<%#Eval("Id") %>' CssClass="btn"><i class="glyphicon glyphicon-zoom-in"> </i></asp:LinkButton></td>
                                                        <td><asp:LinkButton runat="server" ID="lnbExcluir" CommandName="Apagar" CommandArgument='<%#Eval("Id") %>' CssClass="btn"><i class="glyphicon glyphicon-remove"> </i></asp:LinkButton></td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                    
                                            <img id="botaoAbreAnamnese" data-target="#MAnamnese" data-toggle="modal" data-backdrop="static" data-keyboard="false" style="display:none;" />
                                        </tbody>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
                <div role="tabpanel" class="tab-pane fade" id="tabs-vacina">
                    <div class="row">
                        <div class="col-md-12 col-sm-12 col-xs-12">
                            <button id="botaoAbreVacina" type="button" class="btn btn-inline" data-toggle="modal" data-target="#MVacinas" data-backdrop="static" data-keyboard="false" style="display:none;"></button>
                            <asp:UpdatePanel runat="server" ID="upnlBotaoVacina">
                                <ContentTemplate><asp:Button runat="server" ID="btnInserirVacina" OnClick="btnInserirVacina_Click" Text="Inserir Vacina" CssClass="btn btn-inline" /></ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-12 col-sm-12 col-xs-12">
                            <asp:UpdatePanel runat="server" ID="upnlVacinas">
                                <ContentTemplate>
                                    <table class="display table table-bordered tabelasComOrder table-responsive" cellspacing="0" width="100%">
                                        <thead>
                                            <tr>
                                                <th width="100%">Vacina</th>
                                                <th nowrap="nowrap">Dt. Agendada</th>
                                                <th nowrap="nowrap">Dt. Aplicada</th>
                                                <th nowrap="nowrap">Dose</th>
                                                <th nowrap="nowrap">Aplic?</th>
                                                <th></th>
                                                <th></th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater runat="server" ID="rptVacinas" OnItemCommand="rptVacinas_ItemCommand">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td><%#Eval("Vacina.SNome") %></td>
                                                        <td><%#Convert.ToDateTime(Eval("DtmAgendamento")) == new DateTime() ? "-" : Convert.ToDateTime(Eval("DtmAgendamento")).ToString("dd/MM/yyyy") %></td>
                                                        <td><%#Convert.ToDateTime(Eval("DtmAplicacao")) == new DateTime() ? "-" : Convert.ToDateTime(Eval("DtmAplicacao")).ToString("dd/MM/yyyy") %></td>
                                                        <td><%#Eval("IDoseAplicada") + "/" + Eval("ITotalDoses") %></td>
                                                        <td><%#Convert.ToBoolean(Eval("Aplicado")) ? "Sim" : "Não" %></td>
                                                        <td><asp:LinkButton runat="server" ID="lnbVisualizar" CommandName="Visualizar" CommandArgument='<%#Eval("Id") %>' CssClass="btn"><i class="glyphicon glyphicon-zoom-in"> </i></asp:LinkButton></td>
                                                        <td><asp:LinkButton runat="server" ID="lnbExcluir" CommandName="Apagar" CommandArgument='<%#Eval("Id") %>' CssClass="btn"><i class="glyphicon glyphicon-remove"> </i></asp:LinkButton></td>
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
                <div role="tabpanel" class="tab-pane fade" id="tabs-exame">
                    <div class="row">
                        <div class="col-md-12 col-sm-12 col-xs-12">
                            <button id="botaoAbreExame" type="button" class="btn btn-inline" data-toggle="modal" data-target="#MExames" data-backdrop="static" data-keyboard="false" style="display:none;">Inserir Exame</button>
                            <asp:UpdatePanel runat="server" ID="upnlBotaoExame">
                                <ContentTemplate><asp:Button runat="server" ID="btnInserirExame" OnClick="btnInserirExame_Click" Text="Inserir Exame" CssClass="btn btn-inline" /></ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-12 col-sm-12 col-xs-12">
                            <asp:UpdatePanel runat="server" ID="upnlExames">
                                <ContentTemplate>
                                    <table class="display table table-bordered tabelasComOrder" cellspacing="0" width="100%">
                                        <thead>
                                            <tr>
                                                <th nowrap="nowrap">Agendamento</th>
                                                <th nowrap="nowrap">Realização</th>
                                                <th width="100%" nowrap="nowrap">Descrição</th>
                                                <th nowrap="nowrap">Tipo</th>
                                                <th nowrap="nowrap">Laboratório</th>
                                                <th></th>
                                                <th></th>
                                                <th></th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater runat="server" ID="rptExames" OnItemCommand="rptExames_ItemCommand">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td><%#Convert.ToDateTime(Eval("DtmAgendamento")) == new DateTime() ? "-" : Convert.ToDateTime(Eval("DtmAgendamento")).ToString("dd/MM/yyyy") %></td>
                                                        <td><%#Convert.ToDateTime(Eval("DtmRealizacao")) == new DateTime() ? "-" : Convert.ToDateTime(Eval("DtmRealizacao")).ToString("dd/MM/yyyy") %></td>
                                                        <td><%#Eval("SDescricao") %></td>
                                                        <td><%#Eval("Tipo") == null ? "-" : Eval("Tipo.SDescricao") %></td>
                                                        <td><%#Eval("Laboratorio") == null ? "-" : Eval("Laboratorio.SNomeFantasia") %></td>
                                                        <td><%#!String.IsNullOrEmpty(Eval("SPathAnexo").ToString()) ? "<a href='" + Eval("SPathAnexo") + "' class='btn'><i class='fa fa-download'> </i></a>" : "" %></td>
                                                        <td><asp:LinkButton runat="server" ID="lnbVisualizar" CommandName="Visualizar" CommandArgument='<%#Eval("Id") %>' CssClass="btn"><i class="glyphicon glyphicon-zoom-in"> </i></asp:LinkButton></td>
                                                        <td><asp:LinkButton runat="server" ID="lnbExcluir" CommandName="Apagar" CommandArgument='<%#Eval("Id") %>' CssClass="btn"><i class="glyphicon glyphicon-remove"> </i></asp:LinkButton></td>
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
                <div role="tabpanel" class="tab-pane fade" id="tabs-fotos">
                    <asp:UpdatePanel runat="server" ID="upnlFotos" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="row">
                                <div class="col-md-10 col-sm-10 col-xs-12">
                                    <label class="form-control-label">Foto</label>
                                    <asp:FileUpload runat="server" ID="FileUpload1" CssClass="form-control FileUpload1" />
                                </div>
                                <div class="col-md-2 col-sm-4 col-xs-12">
                                    <label>&nbsp;</label>
                                    <asp:LinkButton runat="server" OnClick="lnkInserirFoto_Click" ID="lnkInserirFoto" CssClass="form-control btn btn-success enviaArquivo"><i class="fa fa-plus-circle"> </i></asp:LinkButton>
                                </div>
                            </div>
                            <div class="clearfix"> </div><br />
                            <div class="row">
                                <asp:Repeater runat="server" ID="rptFotos" OnItemCommand="rptFotos_ItemCommand">
                                    <ItemTemplate>
                                        <div class="col col-md-2 col-sm-4 col-xs-6" style="margin-bottom:10px;">
                                            <asp:LinkButton style="position:absolute; top:0; right:0;" CssClass="btn btn-danger" runat="server" ID="lnkRemover" CommandName="Remover" CommandArgument='<%#Eval("Id") %>'><i class="fa fa-remove"> </i></asp:LinkButton>
                                            <a class="fancybox" rel='<%#Eval("Id", "g{0}") %>' href="<%#String.Format("Arquivos/Fotos/{0}{1}",Eval("SNome_novo_arquivo"),Eval("SExtensao")) %>"><img class="form-control" src="<%#String.Format("Arquivos/Fotos/{0}{1}",Eval("SNome_novo_arquivo"),Eval("SExtensao")) %>" alt=""></a>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:PostBackTrigger ControlID="lnkInserirFoto" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div><!--.tab-content-->
        </section><!--.tabs-section-->

        <br /><div class="clearfix"></div>
        <div class="row">
            <div class="col-md-2 col-sm-4 col-xs-12"><asp:LinkButton runat="server" CssClass="form-control btn btn-info swal-btn-basic" ID="lnkNovo" OnClick="lnkNovo_Click"><i class="fa fa-file"></i> Novo</asp:LinkButton></div>
            <div class="col-md-2 col-sm-4 col-xs-12"><asp:LinkButton runat="server" CssClass="form-control btn btn-success swal-btn-basic" ID="lnkSalvar" OnClick="lnkSalvar_Click"><i class="fa fa-check"></i> Salvar</asp:LinkButton></div>
            <div class="col-md-2 col-sm-4 col-xs-12"><asp:LinkButton runat="server" CssClass="form-control btn btn-danger-outline swal-btn-basic" ID="lnkCancelar" OnClick="lnkCancelar_Click"><i class="fa fa-close"></i> Cancelar</asp:LinkButton></div>
        </div>
    </div>

    <div id="MAnamnese" class="modal fade bd-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <asp:Panel runat="server" ID="pnlAnamnese" DefaultButton="btnAnamneseSalvar" CssClass="modal-content">
                <div class="modal-header">
                    <button id="fechaAnamnese" type="button" class="modal-close" data-dismiss="modal" aria-label="Close"><i class="font-icon-close-2"></i></button>
                    <h4 class="modal-title">Anamnese</h4>
                </div>
                <asp:UpdatePanel runat="server" ID="upnlMAnamnese">
                    <ContentTemplate>
                        <div class="modal-body">
                            <asp:Panel runat="server" Visible="false" ID="pnlAnamneseErro"><asp:Literal runat="server" ID="ltrAnamnese"></asp:Literal></asp:Panel>
                            <div class="row">
                                <div class="col-md-2 col-sm-4 col-xs-12">
                                    <label>Cód</label>
                                    <asp:TextBox runat="server" ID="txtAnamneseCodigo" readonly disabled CssClass="form-control" Text="AUTOMATICO"></asp:TextBox>
                                </div>
                                <div class="col-md-2 col-sm-8 col-xs-12">
                                    <label>Data</label>
                                    <asp:TextBox runat="server" ID="txtAnamneseData" CssClass="form-control date-mask"></asp:TextBox>
                                </div>
                                <div class="col-md-8 col-sm-12 col-xs-12">
                                    <label>Peso</label>
                                    <asp:TextBox runat="server" ID="txtAnamnesePeso" CssClass="form-control peso-mask"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row" style="padding-top:5px;">
                                <label class="col-md-2 form-label">Descrição</label>
                                <div class="col-md-10"><asp:TextBox runat="server" MaxLength="250" ID="txtAnamneseDescricao" CssClass="form-control"></asp:TextBox></div>
                            </div>
                            <div class="row" style="padding-top:5px;">
                                <label class="col-md-2 form-label">Veterinário</label>
                                <div class="col-md-10"><asp:DropDownList runat="server" ID="ddlAnamneseVeterinario" CssClass="form-control"></asp:DropDownList></div>
                            </div>

                            <div class="row">
                                <div class="col-md-12 col-sm-12 col-xs-12">
                                    <label>Anamnese</label>
                                    <asp:TextBox runat="server" ID="txtAnamnese" Rows="4" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-rounded btn-danger" data-dismiss="modal">Fechar</button>
                            <asp:Button runat="server" ID="btnAnamneseSalvar" Text="Salvar" CssClass="btn btn-rounded btn-primary" OnClick="btnAnamneseSalvar_Click" />
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
        </div>
    </div>

    <div id="MVacinas" class="modal fade bd-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <asp:Panel runat="server" ID="pnlVacina" DefaultButton="btnVacinaSalvar" CssClass="modal-content">
                <div class="modal-header">
                    <button id="fechaVacina" type="button" class="modal-close" data-dismiss="modal" aria-label="Close"><i class="font-icon-close-2"></i></button>
                    <h4 class="modal-title">Vacina</h4>
                </div>
                
                <asp:UpdatePanel runat="server" ID="upnlMvacina">
                    <ContentTemplate>
                        <div class="modal-body">
                            <div class="row">
                                <div class="col-md-3 col-sm-3 col-xs-12">
                                    <label>Cód</label>
                                    <asp:TextBox runat="server" ID="txtVacinaCodigo" readonly disabled CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-md-4 col-sm-5 col-xs-12">
                                    <label>Data Agendamento</label>
                                    <asp:TextBox runat="server" ID="txtVacinaDataAgendada" CssClass="form-control date-mask"></asp:TextBox>
                                </div>
                                <div class="col-md-4 col-sm-4 col-xs-12">
                                    <label>Data Aplicação</label>
                                    <asp:TextBox runat="server" ID="txtVacinaDataAplicacao" CssClass="form-control date-mask"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6 col-sm-12 col-xs-12">
                                    <label>Vacina</label>
                                    <asp:DropDownList runat="server" ID="ddlVacinas" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlVacinas_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                                <div class="col-md-2 col-sm-12 col-xs-12">
                                    <label>Nº Dose</label>
                                    <asp:TextBox runat="server" ID="txtVacinaDose" CssClass="form-control numero"></asp:TextBox>
                                </div>
                                <div class="col-md-2 col-sm-12 col-xs-12">
                                    <label>Total</label>
                                    <asp:TextBox runat="server" ID="txtVacinaTotalDeDoses" CssClass="form-control numero"></asp:TextBox>
                                </div>
                        
                                <div class="col-md-2 col-sm-12 col-xs-12">
                                    <label title="Vacina foi aplicada?">Aplic</label><br />
                                    <asp:CheckBox runat="server" ID="cbxVacinaAplicada" AutoPostBack="true" OnCheckedChanged="cbxVacinaAplicada_CheckedChanged" />
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-rounded btn-danger" data-dismiss="modal">Fechar</button>
                            <asp:Button runat="server" ID="btnVacinaSalvar" Text="Salvar" CssClass="btn btn-rounded btn-success" OnClick="btnVacinaSalvar_Click" />
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
        </div>
    </div>

    <div id="MExames" class="modal fade bd-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="modal-close" data-dismiss="modal" aria-label="Close"><i class="font-icon-close-2"></i></button>
                    <h4 class="modal-title">Exame</h4>
                </div>
                <asp:UpdatePanel runat="server" ID="upnlMExames" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="modal-body">
                            <div class="row">
                                <div class="col-md-2 col-sm-4 col-xs-12">
                                    <label>Cód</label>
                                    <asp:TextBox runat="server" readonly disabled ID="txtExameCodigo" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-md-2 col-sm-4 col-xs-12">
                                    <label>Tipo</label>
                                    <asp:DropDownList runat="server" ID="ddlExameTipo" CssClass="form-control"></asp:DropDownList>
                                </div>
                                <div class="col-md-2 col-sm-8 col-xs-12">
                                    <label>Agendamento</label>
                                    <asp:TextBox runat="server" ID="txtExameDataAgendada" CssClass="form-control daterange3"></asp:TextBox>
                                </div>
                                <div class="col-md-2 col-sm-8 col-xs-12">
                                    <label>Realização</label>
                                    <asp:TextBox runat="server" ID="txtExameDataRealizada" CssClass="form-control date-mask"></asp:TextBox>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-4 col-sm-12 col-xs-12">
                                    <label>Laboratório</label>
                                    <asp:DropDownList runat="server" ID="ddlExameLaboratorios" CssClass="select2"></asp:DropDownList>
                                </div>
                                <div class="col-md-8 col-sm-12 col-xs-12">
                                    <label>Descrição</label>
                                    <asp:TextBox runat="server" ID="txtExameDescricao" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>

                            <div class="row" style="padding-top:5px;">
                                <div class="col-md-12 col-sm-12 col-xs-12">
                                    <label>Técnico que assinou o exame</label>
                                    <asp:TextBox runat="server" ID="txtExameTecnicoAssinou" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>

                            <div class="row" style="padding-top:5px;">
                                <div class="col-md-12 col-sm-12 col-xs-12">
                                    <label>Veterinário</label>
                                    <asp:DropDownList runat="server" ID="ddlExameVeterinario" CssClass="select2"></asp:DropDownList>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-12 col-sm-12 col-xs-12">
                                    <label>Corpo do exame (ou anexar)</label>
                                    <asp:TextBox runat="server" ID="txtExameCorpo" Rows="6" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>

                            <div class="row">
                                <asp:HiddenField runat="server" ID="hdfExaneAnexo" />
                                <div class="col-md-12 col-sm-12 col-xs-12">
                                    <label>Anexar <asp:Literal runat="server" ID="ltrExameAnexo"></asp:Literal></label>
                                    <asp:FileUpload runat="server" ID="fupExameAnexo" CssClass="form-control" />
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-rounded btn-danger" data-dismiss="modal">Fechar</button>
                            <asp:Button runat="server" ID="btnExameSalvar" Text="Salvar" CssClass="btn btn-rounded btn-primary" OnClick="btnExameSalvar_Click" />
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnExameSalvar" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <script> $('#example, .tabelasdinamicas').DataTable();</script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cFooterScripts" runat="server">
    <script>
        function fnFechar(botao) { $("#" + botao).click(); }
        function fnSelect() { $(".select2").select2(); }
        function fnAbrir(idBotao) { $("#" + idBotao).click(); }
    </script>
</asp:Content>