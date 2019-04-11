<%@ Page Title="" Language="C#" MasterPageFile="~/_MLogado.master" AutoEventWireup="true" CodeBehind="cadastro_de_contato.aspx.cs" Inherits="Site.cadastro_de_contato" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cHeaderScripts" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cConteudo" runat="server">
    <%--<asp:ScriptManager runat="server" ID="src001"></asp:ScriptManager>--%>
    <asp:Panel runat="server" ID="pnl01" DefaultButton="lnkSalvar">
        <div class="box-typical box-typical-padding">
            <h5 class="m-t-lg with-border">Agenda de Contato</h5>
            <div class="row">
                <div class="col-md-2 col-sm-4 col-xs-12">
                    <label class="form-control-label">Código</label>
                    <asp:TextBox readonly disabled runat="server" ID="txtCodigo" CssClass="form-control" Text="AUTOMATICO"></asp:TextBox>
                </div>
                <div class="col-md-10 col-sm-8 col-xs-12">
                    <label class="form-control-label">Nome</label>
                    <asp:TextBox runat="server" ID="txtNome" MaxLength="250" CssClass="form-control primeiro"></asp:TextBox>
                </div>
                <div class="col-md-12">
                    <asp:CheckBox runat="server" ID="cbxPrivado" Text="Contato Privado" />
                </div>
            </div>

            <br /><div class="clearfix"></div>        
            <section id="Tabs" class="tabs-section">
                <div class="tabs-section-nav tabs-section-nav-icons">
                    <div class="tbl">
                        <ul class="nav" role="tablist">
                            <li class="nav-item"><a class="nav-link active" href="#tabs-Enderecos" role="tab" data-toggle="tab"><span class="nav-link-in">Contatos</span></a></li>
                        </ul>
                    </div>
                </div><!--.tabs-section-nav-->

                <div class="tab-content" style="min-height:200px;">
                    <div role="tabpanel" class="tab-pane fade in active" id="tabs-Enderecos">
                        <asp:UpdatePanel runat="server" ID="upnlEndereco">
                            <ContentTemplate>
                                <div class="row">
                                    <div class="col-md-4 col-sm-12 col-xs-12">
                                        <label>Tipo</label>
                                        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlTipoContato" AutoPostBack="true" OnSelectedIndexChanged="ddlTipoContato_SelectedIndexChanged"></asp:DropDownList>
                                    </div>
                                    <div class="col-md-4 col-sm-10 col-xs-12">
                                        <label>Contato</label>
                                        <asp:TextBox runat="server" ID="txtContato" MaxLength="250" />
                                    </div>
                                    <div class="col-md-2 col-sm-2 col-xs-12">
                                        <label>&nbsp;</label>
                                        <asp:LinkButton runat="server" CssClass="form-control btn btn-success" ID="btnInserirContato" OnClick="btnInserirContato_Click"><i class="font-icon font-icon-plus-1"> </i></asp:LinkButton>
                                    </div>
                                </div>
                                <div class="clearfix"></div><br />
                                <div class="row">
                                    <asp:GridView runat="server" ShowHeader="false" ID="gdvContatos" CssClass="table" OnRowCommand="gdvContatos_RowCommand" AutoGenerateColumns="false" GridLines="None">
                                        <Columns>
                                            <asp:TemplateField HeaderText="">
                                                <ItemTemplate>
                                                    <%#Eval("STipoContato") %>
                                                    <asp:HiddenField runat="server" ID="hdfID" Value='<%#Eval("Id") %>' />
                                                    <asp:HiddenField runat="server" ID="hdfContato" Value='<%#Eval("SNome") %>' />
                                                    <asp:HiddenField runat="server" ID="hdfTipoContato" Value='<%#Eval("STipoContato") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="">
                                                <ItemTemplate><%#Eval("SNome") %></ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="" ItemStyle-Width="40px">
                                                <ItemTemplate><asp:LinkButton CommandArgument='<%#Eval("Id") %>' CommandName="Remover" runat="server" ID="btnRem" CssClass="label label-danger"><i class="fa fa-remove"> </i></asp:LinkButton></ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
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