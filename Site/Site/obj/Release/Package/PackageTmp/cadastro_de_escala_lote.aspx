<%@ Page Title="" Language="C#" MasterPageFile="~/_MLogado.master" AutoEventWireup="true" CodeBehind="cadastro_de_escala_lote.aspx.cs" Inherits="Site.cadastro_de_escala_lote" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cHeaderScripts" runat="server">
    <link rel="stylesheet" href="css/separate/vendor/tags_editor.min.css">
    <link rel="stylesheet" href="css/separate/vendor/bootstrap-select/bootstrap-select.min.css">
    <link rel="stylesheet" href="css/separate/vendor/select2.min.css">
    <link rel="stylesheet" href="css/separate/vendor/bootstrap-daterangepicker.min.css">
    <link rel="stylesheet" href="css/lib/clockpicker/bootstrap-clockpicker.min.css">
    <link rel="stylesheet" href="css/separate/vendor/fancybox.min.css">

    <link rel="stylesheet" href="css/separate/vendor/tags_editor.min.css">
    <link rel="stylesheet" href="css/separate/vendor/bootstrap-select/bootstrap-select.min.css">
    <link rel="stylesheet" href="css/separate/vendor/select2.min.css">
    <link rel="stylesheet" href="css/separate/vendor/bootstrap-daterangepicker.min.css">
    <link rel="stylesheet" href="css/lib/clockpicker/bootstrap-clockpicker.min.css">
    <link rel="stylesheet" href="css/separate/vendor/fancybox.min.css">

    <style>
        .fimdesemana { background-color:antiquewhite!important; }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cConteudo" runat="server">
    <asp:Panel runat="server" ID="pnl01" DefaultButton="lnkSalvar">
        <div class="box-typical box-typical-padding">
            <h5 class="m-t-lg with-border">Cadastro de Escala</h5>
            <div class="row">
                <asp:UpdatePanel runat="server" ID="upnl01" UpdateMode="Always" RenderMode="Inline">
                    <ContentTemplate>
                        <div class="col-md-3 col-sm-4 col-xs-12">
                            <label class="form-control-label">Período</label>
                            <asp:TextBox runat="server" ID="txtPeriodo" AutoPostBack="true" OnTextChanged="txtPeriodo_TextChanged" CssClass="form-control primeiro"></asp:TextBox>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        
            <br /><div class="clearfix"></div>
            <div class="row">
                <asp:UpdatePanel runat="server" ID="upnl02">
                    <ContentTemplate>
                        <asp:Repeater runat="server" ID="rpt">
                            <HeaderTemplate>
                                <table class="table-responsive">
                                    <tr>
                                        <th style="padding:0 5px!important;" width="100%">Colaborador</th>
                                        <th nowrap="nowrap" >Dias >&nbsp;</th>
                                        <asp:Repeater runat="server" ID="rptDias" DataSource='<%#LstDiasMes%>'><ItemTemplate><th class='<%#Convert.ToBoolean(Eval("FimDeSemana")) ? "fimdesemana" : "" %>' style="padding:2px;" align="center"><%#Convert.ToInt32(Eval("Dia")).ToString("00") %></th></ItemTemplate></asp:Repeater>
                                    </tr>
                            </HeaderTemplate>

                            <FooterTemplate></table></FooterTemplate>
                            <ItemTemplate>
                                <tr class="table-active">
                                    <td colspan="2" nowrap="nowrap" style="padding:0 5px!important;"><%#Eval("SNome") %></td>
                                    <asp:Repeater runat="server" ID="rptDias" DataSource='<%#RetornaListaDiasMes(long.Parse(Eval("Id").ToString()))%>'>
                                        <ItemTemplate>
                                            <td class='<%#Convert.ToBoolean(Eval("FimDeSemana")) ? "fimdesemana" : "" %>' valign="middle" align="center">
                                                <asp:CheckBox CssClass="checkbox" Checked='<%#Eval("Trabalha") %>' Text=" " runat="server" ID="cbxTrab" />
                                                <asp:TextBox runat="server" style="display:none;" ID="hdfColab" Value='<%#Eval("Colab.Id") %>' />
                                                <asp:HiddenField runat="server" ID="hdfData" Value='<%#Eval("Dtm") %>' />
                                            </td>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tr>
                            </ItemTemplate>
                            <AlternatingItemTemplate>
                                <tr>
                                    <td colspan="2" nowrap="nowrap" style="padding:0 5px!important;"><%#Eval("SNome") %></td>
                                    <asp:Repeater runat="server" ID="rptDias" DataSource='<%#RetornaListaDiasMes(long.Parse(Eval("Id").ToString()))%>'>
                                        <ItemTemplate>
                                            <td class='<%#Convert.ToBoolean(Eval("FimDeSemana")) ? "fimdesemana" : "" %>' valign="middle" align="center">
                                                <asp:CheckBox Checked='<%#Eval("Trabalha") %>' CssClass="checkbox" Text=" " runat="server" ID="cbxTrab" />
                                                <asp:TextBox runat="server" style="display:none;" ID="hdfColab" Value='<%#Eval("Colab.Id") %>' />
                                                <asp:HiddenField runat="server" ID="hdfData" Value='<%#Eval("Dtm") %>' />
                                            </td>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tr>
                            </AlternatingItemTemplate>
                        </asp:Repeater>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

            <button type="button" class="btn btn-inline btn-primary" data-toggle="modal" data-target=".bd-example-modal-sm">Small modal</button>

			<div class="modal fade bd-example-modal-sm" tabindex="-1" role="dialog" aria-labelledby="mySmallModalLabel" aria-hidden="true">
				<div class="modal-dialog modal-sm">
					<div class="modal-content">
						<div class="modal-header"><h4 class="modal-title" id="myModalLabel">Modal title</h4></div>
						<div class="modal-body">
							...
						</div>
					</div>
				</div>
			</div><!--.modal-->

            <br /><div class="clearfix"></div>
            <div class="row">
                <asp:UpdatePanel runat="server" ID="upnlTeste02">
                    <ContentTemplate>
                        <div class="col-md-2 col-sm-6 col-xs-12"><asp:LinkButton OnClientClick="Aguardar();" runat="server" CssClass="form-control btn btn-success swal-btn-basic" ID="lnkSalvar" OnClick="lnkSalvar_Click"><i runat="server" id="ifa" class="fa fa-check"></i> Salvar</asp:LinkButton></div>
                        <div class="col-md-2 col-sm-6 col-xs-12"><asp:LinkButton runat="server" CssClass="form-control btn btn-danger-outline swal-btn-basic" ID="lnkCancelar" OnClick="lnkCancelar_Click"><i class="fa fa-close"></i> Cancelar</asp:LinkButton></div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </asp:Panel>

    <script type="text/javascript" language="javascript">    
        function Aguardar() {

        }
   </script>  
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cFooterScripts" runat="server">
</asp:Content>