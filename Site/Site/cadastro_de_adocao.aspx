<%@ Page Title="" Language="C#" MasterPageFile="~/_MLogado.master" AutoEventWireup="true" CodeBehind="cadastro_de_adocao.aspx.cs" Inherits="Site.cadastro_de_adocao" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cHeaderScripts" runat="server">
    <link rel="stylesheet" href="css/lib/datatables-net/datatables.min.css">
    <link rel="stylesheet" href="css/separate/vendor/datatables-net.min.css">
    <style>
        .form-control { height:100%!important;}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cConteudo" runat="server">
    <asp:Panel runat="server" ID="pnl01" DefaultButton="lnkSalvar">
        <div class="box-typical box-typical-padding">
            <h5 class="m-t-lg with-border">Cadastro de Adoção</h5>
            <div class="row">
                <div class="col-md-2 col-sm-2 col-xs-12">
                    <label class="form-control-label">Código</label>
                    <asp:TextBox readonly disabled runat="server" ID="txtCodigo" CssClass="form-control" Text="AUTOMATICO"></asp:TextBox>
                </div>
                
                <div class="col-md-10 col-sm-12">
                    <label>Animal</label>
                    <asp:DropDownList runat="server" ID="ddlAnimal" CssClass="select2"></asp:DropDownList>
                </div>
                
                <div class="col-md-12">
                    <label>Adotante</label>
                    <asp:DropDownList runat="server" ID="ddlAdotante" CssClass="select2"></asp:DropDownList>
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

            <asp:UpdatePanel runat="server" ID="upnlEnderecos">
                <ContentTemplate>
                    <div class="row">
                        <asp:HiddenField runat="server" ID="hdfAdotarEnderecoID" />
                        <div class="col-md-3 col-sm-4 col-xs-12">
                            <label>CEP</label>
                            <div class="input-group">
                                <asp:TextBox runat="server" ID="txtAdotarCEP" MaxLength="10" CssClass="form-control cep-mask" />
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
                </ContentTemplate>
            </asp:UpdatePanel>
            <br /><div class="clearfix"></div>
            <div class="row">
                <div class="col-md-2 col-sm-3 col-xs-12"><asp:LinkButton runat="server" CssClass="form-control btn btn-info swal-btn-basic" ID="lnkNovo" OnClick="lnkNovo_Click"><i class="fa fa-file"></i> Novo</asp:LinkButton></div>
                <div class="col-md-2 col-sm-3 col-xs-12"><asp:LinkButton runat="server" CssClass="form-control btn btn-success swal-btn-basic" ID="lnkSalvar" OnClick="lnkSalvar_Click"><i class="fa fa-check"></i> Salvar</asp:LinkButton></div>
                <div class="col-md-2 col-sm-3 col-xs-12"><asp:LinkButton runat="server" CssClass="form-control btn btn-danger-outline swal-btn-basic" ID="lnkCancelar" OnClick="lnkCancelar_Click"><i class="fa fa-close"></i> Cancelar</asp:LinkButton></div>
                <div class="col-md-2 col-sm-3 col-xs-12"><asp:LinkButton runat="server" CssClass="form-control btn btn-default swal-btn-basic" ID="lnkImprimeContrato" OnClick="lnkImprimeContrato_Click"><i class="fa fa-print"></i> Contrato</asp:LinkButton></div>
            </div>
        </div>
    </asp:Panel>
    <script> $('#example, .tabelasdinamicas').DataTable();</script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cFooterScripts" runat="server">
</asp:Content>