<%@ Page Title="" Language="C#" MasterPageFile="~/_MLogado.master" AutoEventWireup="true" CodeBehind="meu_perfil.aspx.cs" Inherits="Site.meu_perfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cHeaderScripts" runat="server">
    <link rel="stylesheet" href="css/separate/vendor/tags_editor.min.css">
    <link rel="stylesheet" href="css/separate/vendor/bootstrap-select/bootstrap-select.min.css">
    <link rel="stylesheet" href="css/separate/vendor/select2.min.css">
    <link rel="stylesheet" href="css/separate/vendor/bootstrap-daterangepicker.min.css">
    <link rel="stylesheet" href="css/lib/clockpicker/bootstrap-clockpicker.min.css">
    <link rel="stylesheet" href="css/separate/vendor/fancybox.min.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cConteudo" runat="server">
    <%--<asp:ScriptManager runat="server" ID="srcM"></asp:ScriptManager>--%>
    
    <asp:Panel runat="server" ID="pnl01" DefaultButton="lnkSalvar">
        <div class="box-typical box-typical-padding">
            <h5 class="m-t-lg with-border">Meu Perfil</h5>
            <div class="row">
                <div class="col-md-2 col-sm-4 col-xs-12">
                    <label class="form-control-label">Código</label>
                    <asp:TextBox readonly disabled runat="server" ID="txtCodigo" CssClass="form-control" Text="AUTOMATICO"></asp:TextBox>
                    <asp:HiddenField runat="server" ID="hdfID" />
                </div>
                <div class="col-md-10 col-sm-8 col-xs-12">
                    <label class="form-control-label">Nome</label>
                    <asp:TextBox runat="server" ID="txtNome" MaxLength="250" CssClass="form-control primeiro"></asp:TextBox>
                </div>


                <div class="col-md-6 col-sm-6 col-xs-12">
                    <label class="form-control-label">Perfil</label>
                    <asp:DropDownList readonly disabled runat="server" ID="ddlPerfil" CssClass="select2"></asp:DropDownList>
                </div>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <label class="form-control-label">Pessoa</label>
                    <asp:DropDownList readonly disabled runat="server" ID="ddlPessoaVincular" CssClass="select2"></asp:DropDownList>
                </div>

            </div>
            <br /><div class="clearfix"></div>                        
            <div class="row">
                <div class="col-md-4 col-sm-4 col-xs-12">
                    <label class="form-control-label">Login</label>
                    <asp:TextBox readonly disabled runat="server" ID="txtLogin" MaxLength="250" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-2 col-sm-4 col-xs-12">
                    <label class="form-control-label">Senha</label>
                    <asp:TextBox runat="server" ID="txtSenha" CssClass="form-control" TextMode="Password"></asp:TextBox>
                    <asp:HiddenField runat="server" ID="hdfSenha" />
                </div>
                <div class="col-md-6 col-sm-4 col-xs-12">
                    <label class="form-control-label">E-mail</label>
                    <asp:TextBox runat="server" ID="txtEmail" MaxLength="250" CssClass="form-control emails"></asp:TextBox>
                </div>
            </div>
            
            <br /><div class="clearfix"></div>
            <asp:UpdatePanel runat="server" ID="upnlEndereco">
                <ContentTemplate>
                    <asp:Panel runat="server" ID="pnlEnderecos">
                    
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
                                </div>
                            </div>
                        </section>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>

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