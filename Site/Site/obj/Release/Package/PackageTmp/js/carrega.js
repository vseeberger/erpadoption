function onAddTag(tag) { alert("Added a tag: " + tag); }
function onRemoveTag(tag) { alert("Removed a tag: " + tag); }
function onChangeTag(input, tag) { alert("Changed a tag: " + tag); }

//$(document).ready(function () {
//    $(":input").inputmask();
//});

//$(document).ready(function () {
//    $(".dataSimples").singleDatePicker();
//});

$.fn.singleDatePicker = function () {
    $(this).on("apply.daterangepicker", function (e, picker) {
        picker.element.val(picker.startDate.format(picker.locale.format));
    });
    return $(this).daterangepicker({
        singleDatePicker: true,
        autoUpdateInput: false,
        locale: {
            format: 'DD/MM/YYYY',
            daysOfWeek: ['D', 'S', 'T', 'Q', 'Q', 'S', 'S'],
            monthNames: ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun', 'Jul', 'Ago', 'Set', 'Out', 'Nov', 'Dez']
        },
    });
};


if ($('.bootstrap-select').size()) {
    // Bootstrap-select
    $('.bootstrap-select').selectpicker({
        style: '',
        width: '100%',
        size: 8
    });
}

if ($('.select2').size()) {
    // Select2
    //$.fn.select2.defaults.set("minimumResultsForSearch", "Infinity");

    $('.select2').not('.manual').select2();

    $(".select2-icon").not('.manual').select2({
        templateSelection: select2Icons,
        templateResult: select2Icons
    });

    $(".select2-arrow").not('.manual').select2({
        theme: "arrow"
    });

    $('.select2-no-search-arrow').select2({
        minimumResultsForSearch: "Infinity",
        theme: "arrow"
    });

    $('.select2-no-search-default').select2({
        minimumResultsForSearch: "Infinity"
    });

    $(".select2-white").not('.manual').select2({
        theme: "white"
    });

    $(".select2-photo").not('.manual').select2({
        templateSelection: select2Photos,
        templateResult: select2Photos
    });
}

function select2Icons(state) {
    if (!state.id) { return state.text; }
    var $state = $(
        '<span class="font-icon ' + state.element.getAttribute('data-icon') + '"></span><span>' + state.text + '</span>'
    );
    return $state;
}

function select2Photos(state) {
    if (!state.id) { return state.text; }
    var $state = $(
        '<span class="user-item"><img src="' + state.element.getAttribute('data-photo') + '"/>' + state.text + '</span>'
    );
    return $state;
}

/* ==========================================================================
    Tooltips
    ========================================================================== */

// Tooltip
$('[data-toggle="tooltip"]').tooltip({
    html: true
});

// Popovers
$('[data-toggle="popover"]').popover({
    trigger: 'focus'
});

/* ==========================================================================
    Full height box
    ========================================================================== */

function boxFullHeight() {
    var sectionHeader = $('.section-header');
    var sectionHeaderHeight = 0;

    if (sectionHeader.size()) {
        sectionHeaderHeight = parseInt(sectionHeader.height()) + parseInt(sectionHeader.css('padding-bottom'));
    }

    $('.box-typical-full-height').css('min-height',
        $(window).height() -
        parseInt($('.page-content').css('padding-top')) -
        parseInt($('.page-content').css('padding-bottom')) -
        sectionHeaderHeight -
        parseInt($('.box-typical-full-height').css('margin-bottom')) - 2
    );
    $('.box-typical-full-height>.tbl, .box-typical-full-height>.box-typical-center').height(parseInt($('.box-typical-full-height').css('min-height')));
}

boxFullHeight();

$(window).resize(function () {
    boxFullHeight();
});

$(function () {
    //$('.clockpicker').clockpicker({
    //    //autoclose: true,
    //    donetext: 'Ok',
    //    //'default': 'now'
    //});
    $('.clockpicker').clockpicker({
        autoclose: true,
        donetext: 'Ok',
        placement: 'left',
        align: 'left',
    });

    $('.daterange3').daterangepicker({
        singleDatePicker: true,
        showDropdowns: true,
        locale: {
            format: 'DD/MM/YYYY',
            daysOfWeek: ['D', 'S', 'T', 'Q', 'Q', 'S', 'S'],
            monthNames: ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun', 'Jul', 'Ago', 'Set', 'Out', 'Nov', 'Dez']
        },
        //"timePicker": true,
        //ranges: {
        //    'Today': [moment(), moment()],
        //    'Yesterday': [moment().subtract(1, 'days'), moment().subtract(1, 'days')],
        //    'Last 7 Days': [moment().subtract(6, 'days'), moment()],
        //    'Last 30 Days': [moment().subtract(29, 'days'), moment()],
        //    'This Month': [moment().startOf('month'), moment().endOf('month')],
        //    'Last Month': [moment().subtract(1, 'month').startOf('month'), moment().subtract(1, 'month').endOf('month')]
        //},
        //"linkedCalendars": false,
        //"autoUpdateInput": false,
        //"alwaysShowCalendars": true,
        //"showWeekNumbers": true,
        //"showDropdowns": true,
        //"showISOWeekNumbers": true
    });

    $('.daterange4').daterangepicker({
        singleDatePicker: true,
        showDropdowns: true,
        locale: {
            format: 'MM/YYYY',
            daysOfWeek: ['D', 'S', 'T', 'Q', 'Q', 'S', 'S'],
            monthNames: ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun', 'Jul', 'Ago', 'Set', 'Out', 'Nov', 'Dez']
        },
    });


    $('.daterange5').daterangepicker({
        timePicker: true,
        singleDatePicker: true,
        timePicker24Hour: true,
        autoApply: true,
        locale: {
            format: 'DD/MM/YYYY HH:mm',
            daysOfWeek: ['D', 'S', 'T', 'Q', 'Q', 'S', 'S'],
            monthNames: ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun', 'Jul', 'Ago', 'Set', 'Out', 'Nov', 'Dez'],
            applyLabel: 'Aplicar',
            cancelLabel: 'Cancelar',
        }
    });

    $(".fancybox").fancybox({
        padding: 0,
        openEffect: 'none',
        closeEffect: 'none'
    });

    $('.tabelasdinamicas').DataTable();

    $('.CampoNumeroBotoes').TouchSpin({
        verticalbuttons: true,
        verticalupclass: 'glyphicon glyphicon-plus',
        verticaldownclass: 'glyphicon glyphicon-minus',
        stepinterval: 50,
        //decimals: 2,
        //maxboostedstep: 10000000
        min: 0,
        max: 1000000,
        step: 0.01,
        decimals: 2,
        boostat: 5,
        maxboostedstep: 10000000,
    });
});

$(function () {
    //var $table = $('.table');
    ////Make a clone of our table
    //var $fixedColumn = $table.clone().insertBefore($table).addClass('fixed-column');

    ////Remove everything except for first column
    //$fixedColumn.find('th:not(:first-child),td:not(:first-child)').remove();

    ////Match the height of the rows to that of the original table's
    //$fixedColumn.find('tr').each(function (i, elem) {
    //    $(this).height($table.find('tr:eq(' + i + ')').height());
    //});
});