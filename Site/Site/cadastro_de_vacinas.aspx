<%@ Page Title="" Language="C#" MasterPageFile="~/_MLogado.master" AutoEventWireup="true" CodeBehind="cadastro_de_vacinas.aspx.cs" Inherits="Site.cadastro_de_vacinas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cHeaderScripts" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cConteudo" runat="server">
    <asp:Panel runat="server" ID="pnl01" DefaultButton="lnkSalvar">
        <div class="box-typical box-typical-padding">
            <h5 class="m-t-lg with-border">Cadastro de Vacinas</h5>
            <div class="row">
                <div class="col-md-2 col-sm-4 col-xs-12">
                    <label class="form-control-label">Código</label>
                    <asp:TextBox readonly disabled runat="server" ID="txtCodigo" CssClass="form-control" Text="AUTOMATICO"></asp:TextBox>
                </div>
                <div class="col-md-4 col-sm-8 col-xs-12">
                    <label class="form-control-label">Espécie</label>
                    <asp:DropDownList runat="server" ID="ddlEspecie" CssClass="form-control primeiro"></asp:DropDownList>
                </div>

                <div class="col-md-2 col-sm-4 col-xs-12">
                    <label class="form-control-label">Qnt. Doses</label>
                    <asp:TextBox runat="server" ID="txtQntDoses" MaxLength="3" CssClass="form-control number"></asp:TextBox>
                </div>
                <div class="col-md-2 col-sm-4 col-xs-12">
                    <label class="form-control-label" title="Diferença de dias entre as doses">Entre doses</label>
                    <asp:TextBox runat="server" ID="txtEntreDoses" MaxLength="4" CssClass="form-control number"></asp:TextBox>
                </div>
                <div class="col-md-2 col-sm-4 col-xs-12">
                    <label class="form-control-label">Dias Validade</label>
                    <asp:TextBox runat="server" ID="txtQntDiasValidade" MaxLength="4" CssClass="form-control number"></asp:TextBox>
                </div>

                

                <div class="col-md-12 col-sm-12 col-xs-12">
                    <label class="form-control-label">Nome</label>
                    <asp:TextBox runat="server" ID="txtNome" MaxLength="250" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="col-md-12 col-sm-12 col-xs-12">
                    <label class="form-control-label">Descrição</label>
                    <asp:TextBox runat="server" ID="txtDescricao" MaxLength="250" Rows="4" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="col-md-12 col-sm-12 col-xs-12">
                    <label class="form-control-label">Precauções/Atenção</label>
                    <asp:TextBox runat="server" ID="txtAtencao" MaxLength="250" Rows="4" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
        
            <br /><div class="clearfix"></div>
            <div class="row">
                <div class="col-md-2 col-sm-6 col-xs-12"><asp:LinkButton OnClick="lnkSalvar_Click" runat="server" CssClass="form-control btn btn-success swal-btn-basic" ID="lnkSalvar"><i class="fa fa-check"></i> Salvar</asp:LinkButton></div>
                <div class="col-md-2 col-sm-6 col-xs-12"><asp:LinkButton OnClick="lnkCancelar_Click" runat="server" CssClass="form-control btn btn-danger-outline swal-btn-basic" ID="lnkCancelar"><i class="fa fa-close"></i> Cancelar</asp:LinkButton></div>
            </div>
        </div>
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cFooterScripts" runat="server">
</asp:Content>