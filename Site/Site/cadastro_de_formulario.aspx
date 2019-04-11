<%@ Page Title="" Language="C#" MasterPageFile="~/_MLogado.master" AutoEventWireup="true" CodeBehind="cadastro_de_formulario.aspx.cs" Inherits="Site.cadastro_de_formulario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cHeaderScripts" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cConteudo" runat="server">
    <asp:Panel runat="server" ID="pnl01" DefaultButton="lnkSalvar">
        <div class="box-typical box-typical-padding">
            <h5 class="m-t-lg with-border">Cadastro de Formulário</h5>
            <div class="row">
                <div class="col-md-2 col-sm-6 col-xs-6">
                    <label class="form-control-label">Código</label>
                    <asp:TextBox readonly disabled runat="server" ID="txtCodigo" CssClass="form-control" Text="AUTOMATICO"></asp:TextBox>
                </div>
                <div class="col-md-2 col-sm-6 col-xs-6">
                    <label class="form-control-label">Agrupador</label>
                    <asp:TextBox runat="server" ID="txtAgrupador" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-6 col-sm-12 col-xs-12">
                    <label class="form-control-label">Nome</label>
                    <asp:TextBox runat="server" ID="txtNome" MaxLength="250" CssClass="form-control primeiro"></asp:TextBox>
                </div>
                    
                <div class="col-md-12 col-sm-12 col-xs-12">
                    <label class="form-control-label">Nome do arquivo</label>
                    <div class="input-group">
                        <span class="input-group-addon btn btn-info"><i class="fa fa-file"></i></span>
                        <asp:TextBox Height="100%" runat="server" ID="txtURL" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-12 col-sm-12 col-xs-12">
                    <label class="form-control-label">Url Curta</label>
                    <div class="input-group">
                        <span class="input-group-addon btn btn-info"><i class="fa fa-file"></i></span>
                        <asp:TextBox Height="100%" runat="server" ID="txtURLCurta" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>

                <div class="col-md-2 col-sm-3 col-xs-6">
                    <label>&nbsp;</label>
                    <asp:CheckBox runat="server" ID="cbxEhMenu" Text="Aparece no menu?" CssClass="checkbox" />
                </div>
                <div class="col-md-2 col-sm-3 col-xs-6">
                    <label title="Sequência - Apenas para exibição do menu">Seq.</label>
                    <asp:TextBox runat="server" ID="txtSequenciaMenu" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-4 col-sm-6 col-xs-12">
                    <label class="form-control-label">Filho do menu</label>
                    <asp:DropDownList runat="server" ID="ddlMenuPai" CssClass="select2"></asp:DropDownList>
                </div>

                <div class="col-md-2 col-sm-6 col-xs-12">
                    <label>Css Menu</label>
                    <asp:TextBox runat="server" ID="txtCssMenu" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-2 col-sm-6 col-xs-12">
                    <label>Css Icone</label>
                    <asp:TextBox runat="server" ID="txtIconeMenu" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            
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