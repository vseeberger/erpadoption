<%@ Page Title="" Language="C#" MasterPageFile="~/_MLogado.master" AutoEventWireup="true" CodeBehind="cadastro_de_escala.aspx.cs" Inherits="Site.cadastro_de_escala" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cHeaderScripts" runat="server">
    <link rel="stylesheet" href="css/separate/pages/calendar.css">
    <link rel="stylesheet" href="css/separate/vendor/bootstrap-datetimepicker.min.css">
    <link rel="stylesheet" href="css/separate/vendor/bootstrap-daterangepicker.min.css">
    <link rel="stylesheet" href="css/lib/clockpicker/bootstrap-clockpicker.min.css">
    <link rel="stylesheet" href="css/separate/vendor/bootstrap-select/bootstrap-select.min.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cConteudo" runat="server">
    <header class="section-header">
		<div class="tbl">
			<div class="tbl-row">
				<div class="col-md-10 col-sm-8 col-xs-12 tbl-cell"><h2>Escalas do Mês</h2></div>
                <div class="col-md-2 col-sm-4 col-xs-12 pull-right"><asp:Button runat="server" ID="btnAdd" CssClass="form-control btn btn-rounded" Text="Inserir em lote" OnClick="btnAdd_Click" /></div>
			</div>
		</div>
	</header>

    <div class="box-typical">
		<div class="calendar-page">
            <div class="calendar-page-content">
				<div class="calendar-page-content-in">
					<div id='calendar'></div>
				</div><!--.calendar-page-content-in-->
			</div><!--.calendar-page-content-->

            <div class="calendar-page-side">
                <section class="calendar-page-side-section">
					<header class="box-typical-header-sm">Escala avulso</header>
                    <asp:UpdatePanel runat="server" ID="upnl01">
                        <ContentTemplate>
                            <div class="calendar-page-side-section-in">
                                <div class="col-md-12">
                                    <label>Código</label>
                                    <asp:TextBox runat="server" readonly Text="AUTOMATICO" ID="txtCodigoEscala" CssClass="form-control"></asp:TextBox>
                                </div>

                                <div class="col-md-12">
                                    <label>Colaborador</label>
                                    <asp:DropDownList runat="server" ID="ddlColaborador" CssClass="form-control select"></asp:DropDownList>
                                </div>

                                <div class="col-md-12">
                                    <label>Dia</label>
                                    <div class='input-group date'>
                                        <asp:TextBox runat="server" ID="txtData" CssClass="form-control daterange3"></asp:TextBox>
								        <span class="input-group-addon">
									        <i class="font-icon font-icon-calend"></i>
								        </span>
							        </div>
                                </div>

                                <div class="col-md-6">
                                    <label>De</label>
                                    <asp:TextBox runat="server" ID="txtHoraDe" CssClass="form-control clockpicker"></asp:TextBox>
                                </div>
                                <div class="col-md-6">
                                    <label>Até</label>
                                    <asp:TextBox runat="server" ID="txtHoraAte" CssClass="form-control clockpicker"></asp:TextBox>
                                </div>

                                <div class="clearfix"></div><br />
                                <div class="col-md-12 col-sm-12 col-xs-12"><asp:LinkButton OnClick="btnSalvar_Click" runat="server" ID="btnSalvar" CssClass="form-control btn btn-success"><i class="fa fa-check"></i> Salvar</asp:LinkButton></div>
                                <div class="clearfix"></div><br />
                                <div class="col-md-12 col-sm-12 col-xs-12"><asp:LinkButton OnClick="btnCancelar_Click" runat="server" ID="btnCancelar" CssClass="form-control btn btn-danger"><i class="fa fa-remove"></i> Cancelar</asp:LinkButton></div>
                                <div class="clearfix"></div><br />
                                <div class="col-md-12 col-sm-12 col-xs-12"><asp:LinkButton OnClick="btnExcluir_Click" runat="server" ID="btnExcluir" CssClass="form-control btn btn-danger"><i class="fa fa-remove"></i> Excluir</asp:LinkButton></div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </section>
		    </div><!--.calendar-page-side-->
		</div><!--.calendar-page-->
	</div><!--.box-typical-->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cFooterScripts" runat="server">
    <script>
    $(document).ready(function () {

        /* ==========================================================================
            Fullcalendar
            ========================================================================== */

        $('#calendar').fullCalendar({
            locale: {
                daysOfWeek: ['D', 'S', 'T', 'Q', 'Q', 'S', 'S'],
                monthNames: ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun', 'Jul', 'Ago', 'Set', 'Out', 'Nov', 'Dez']
            },
            header: {
                left: '',
                center: 'prev, title, next',
                right: 'today agendaDay,agendaTwoDay,agendaWeek,month'
            },
            buttonIcons: {
                prev: 'font-icon font-icon-arrow-left',
                next: 'font-icon font-icon-arrow-right',
                prevYear: 'font-icon font-icon-arrow-left',
                nextYear: 'font-icon font-icon-arrow-right'
            },
            defaultDate: '<%=DateTime.Today.ToString("yyyy-MM-dd")%>',
            editable: false,
            selectable: true,
            eventLimit: true, // allow "more" link when too many events
            events: '/CarregaEventos.ashx',
            viewRender: function (view, element) {
                if (!("ontouchstart" in document.documentElement)) {
                    $('.fc-scroller').jScrollPane({
                        autoReinitialise: true,
                        autoReinitialiseDelay: 100
                    });
                }
                
                $('.fc-popover.click').remove();
            },
            eventClick: function(calEvent, jsEvent, view) {
                
                var eventEl = $(this);

                // Add and remove event border class
                if (!$(this).hasClass('event-clicked')) {
                    $('.fc-event').removeClass('event-clicked');

                    $(this).addClass('event-clicked');
                }

                // Add popover
                $('body').append(
                    '<div class="fc-popover click">' +
                        '<div class="fc-header">' +
                            moment(calEvent.start).format('dddd • D') +
                            '<button type="button" class="cl"><i class="font-icon-close-2"></i></button>' +
                        '</div>' +

                        '<div class="fc-body main-screen">' +
                            '<p>De ' +
                                moment(calEvent.start).format('hh:mma') +
                            ' Até ' +
                                moment(calEvent.end).format('hh:mma') +
                            '</p>' +
                            '<p class="color-blue-grey">' + calEvent.title + '</p>' +
                            '<ul class="actions">' +
                                '<li><a href="?' + calEvent.Id + '">Editar</a></li>' +
                            '</ul>' +
                        '</div>' +
                    '</div>'
                );

                // Datepicker init
                $('.fc-popover.click .datetimepicker').datetimepicker({
                    widgetPositioning: {
                        horizontal: 'right'
                    }
                });

                $('.fc-popover.click .datetimepicker-2').datetimepicker({
                    widgetPositioning: {
                        horizontal: 'right'
                    },
                    format: 'LT',
                    debug: true
                });


                // Position popover
                function posPopover(){
                    $('.fc-popover.click').css({
                        left: eventEl.offset().left + eventEl.outerWidth()/2,
                        top: eventEl.offset().top + eventEl.outerHeight()
                    });
                }

                posPopover();

                $('.fc-scroller, .calendar-page-content, body').scroll(function(){
                    posPopover();
                });

                $(window).resize(function(){
                    posPopover();
                });


                // Remove old popover
                if ($('.fc-popover.click').length > 1) {
                    for (var i = 0; i < ($('.fc-popover.click').length - 1); i++) {
                        $('.fc-popover.click').eq(i).remove();
                    }
                }

                // Close buttons
                $('.fc-popover.click .cl, .fc-popover.click .remove-popover').click(function(){
                    $('.fc-popover.click').remove();
                    $('.fc-event').removeClass('event-clicked');
                });

                // Actions link
                $('.fc-event-action-edit').click(function(e){
                    e.preventDefault();

                    $('.fc-popover.click .main-screen').hide();
                    $('.fc-popover.click .edit-event').show();
                });

                $('.fc-event-action-remove').click(function(e){
                    e.preventDefault();

                    $('.fc-popover.click .main-screen').hide();
                    $('.fc-popover.click .remove-confirm').show();
                });
            }
        });


        /* ==========================================================================
            Side datepicker
            ========================================================================== */

        $('#side-datetimepicker').datetimepicker({
            inline: true,
            format: 'DD/MM/YYYY'
        });

        /* ========================================================================== */

    });


    /* ==========================================================================
        Calendar page grid
        ========================================================================== */

    (function ($, viewport) {
        $(document).ready(function () {

            if (viewport.is('>=lg')) {
                $('.calendar-page-content, .calendar-page-side').matchHeight();
            }

            // Execute code each time window size changes
            $(window).resize(
                viewport.changed(function () {
                    if (viewport.is('<lg')) {
                        $('.calendar-page-content, .calendar-page-side').matchHeight({ remove: true });
                    }
                })
            );
        });
    })(jQuery, ResponsiveBootstrapToolkit);
</script>
</asp:Content>