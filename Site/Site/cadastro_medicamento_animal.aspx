<%@ Page Title="" Language="C#" MasterPageFile="~/_MLogado.master" AutoEventWireup="true" CodeBehind="cadastro_medicamento_animal.aspx.cs" Inherits="Site.cadastro_medicamento_animal" %>
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
        <h5 class="m-t-lg with-border">Agendar Medicamento</h5>
        <div class="row">
            <div class="col-md-2 col-sm-4 col-xs-12">
                <label class="form-control-label">Código</label>
                <asp:TextBox runat="server" ID="txtCodigo" readonly disabled Text="AUTOMATICO" CssClass="form-control"></asp:TextBox>
            </div>
            <asp:UpdatePanel runat="server" ID="upnlFormulario">
                <ContentTemplate>
                    <div class="col-md-10 col-sm-8 col-xs-12">
                        <label class="form-control-label">Animal</label>
                        <asp:DropDownList runat="server" ID="ddlAnimal" CssClass="select2"></asp:DropDownList>
                    </div>

                    <div class="col-md-4 col-sm-4 col-xs-12">
                        <label class="form-control-label">Tratamento?</label>
                        <asp:DropDownList runat="server" ID="ddlTratamento" CssClass="select2"></asp:DropDownList>
                    </div>
                    <div class="col-md-8 col-sm-8 col-xs-12">
                        <label>Observação</label>
                        <asp:TextBox runat="server" MaxLength="250" ID="txtObservacao" CssClass="form-control"></asp:TextBox>
                    </div>

                    <div class="col-md-3 col-sm-12 col-xs-12">
                        <label class="form-control-label">Medicamento</label>
                        <asp:DropDownList runat="server" ID="ddlMedicamento" CssClass="select2"></asp:DropDownList>
                    </div>
                    <div class="col-md-2 col-sm-6 col-xs-12">
                        <label>Dose/Dia</label>
                        <asp:TextBox runat="server" ID="txtDosesPorDia" CssClass="form-control numero"></asp:TextBox>
                    </div>
                    <div class="col-md-2 col-sm-5 col-xs-12">
                        <label>Durante</label>
                        <asp:TextBox placeholder="durante quantos dias" runat="server" ID="txtQuantidadeDeDias" CssClass="form-control numero"></asp:TextBox>
                    </div>
                    <div class="col-md-2 col-sm-5 col-xs-12">
                        <label>Dosagem</label>
                        <asp:TextBox runat="server" ID="txtDosagem" CssClass="form-control"></asp:TextBox>
                    </div>
        
                    <div class="col-md-2 col-sm-6 col-xs-8">
                        <label>Data Início</label>
                        <asp:TextBox runat="server" ID="txtDataInicio" CssClass="form-control daterange3"></asp:TextBox>
                    </div>
                    <div class="col-md-1 col-sm-2 col-xs-4">
                        <label>&nbsp;</label>
                        <asp:Button runat="server" ID="btnAddMedicamento" OnClick="btnAddMedicamento_Click" Text="+" CssClass="form-control btn btn-success" />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div class="clearfix"></div><br />
        <section class="card">
		    <div class="card-block">
                <asp:UpdatePanel runat="server" ID="upnlLista">
                    <ContentTemplate>
                        <table class="tabelasdinamicas display table table-striped table-bordered" width="100%">
                            <thead>
				                <tr>
                                    <th width="100%">Medicamento</th>
                                    <th>Início</th>
                                    <th>Durante</th>
                                    <th>Dose/Dia</th>
                                    <th>Dosagem</th>
                                    <th> </th>
				                </tr>
				            </thead>
                            <tbody>
                    
                                <asp:Repeater runat="server" ID="rptAgendamentos">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%#Eval("Medicamento.SNome") %></td>
                                            <td><%#Convert.ToDateTime(Eval("DtmInicio").ToString()).ToString("dd/MM/yyyy") %></td>
                                            <td align="center"><%#Eval("IQuantidadeDias") %> dia(s)</td>
                                            <td align="center"><%#Eval("ITotalDose") %>x</td>
                                            <td align="center"><%#Eval("SPosologia") %></td>
                                            <td><asp:LinkButton runat="server" CommandArgument='medicamento' CommandName="Remover" ID="lnkRemover" CssClass="btn"><i class="glyphicon glyphicon-remove"></i></asp:LinkButton></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            
                            </tbody>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </section>
    

        <br /><div class="clearfix"></div>
        <div class="row">
            <div class="col-md-2 col-sm-4 col-xs-12"><asp:LinkButton runat="server" OnClick="lnkNovo_Click" CssClass="form-control btn btn-info swal-btn-basic" ID="lnkNovo"><i class="fa fa-file"></i> Novo</asp:LinkButton></div>
            <div class="col-md-3 col-sm-4 col-xs-12"><asp:LinkButton runat="server" OnClick="lnkSalvar_Click" CssClass="form-control btn btn-success swal-btn-basic" ID="lnkSalvar"><i class="fa fa-check"></i> Gerar Agendamento</asp:LinkButton></div>
            <div class="col-md-2 col-sm-4 col-xs-12"><asp:LinkButton runat="server" OnClick="lnkCancelar_Click" CssClass="form-control btn btn-danger-outline swal-btn-basic" ID="lnkCancelar"><i class="fa fa-close"></i> Cancelar</asp:LinkButton></div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cFooterScripts" runat="server">
    <script>
        function fnFechar(botao) { $("#" + botao).click(); }
        function fnSelect() { $(".select2").select2(); }
        function fnAbrir(idBotao) { $("#" + idBotao).click(); }
        $('#example, .tabelasdinamicas').DataTable();
    </script>
</asp:Content>