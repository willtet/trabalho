var $table = $('#tblRelatorio');
var $comboCampanha = $('#comboCampanha');
var $comboStatusPedido = $('#comboStatus');
var $anoPesquisa = $('#anoPesquisa');
var $dataInicio = $('#dtInicioPesquisa');
var $dataFim = $('#dtFimPesquisa');


var $btnPesquisar = $('.btnPesquisar');
var $btnLimpar = $('.btnLimpar');
var $btnImprimir = $("#linkRelatorio");
var $btnExcel = $(".btnExcel");

var nomeRelatorio = 'RelatorioResumoDia';
var nomeDataset = 'dsRelatorioRelatorioResumoDia';

$(function () {

    $('.data').datetimepicker({
        format: 'DD/MM/YYYY'
    }).on('dp.change', function (e) {
        e.preventDefault();
        LimparGrid();
    });

    $('.ano').datetimepicker({
        format: 'YYYY'
    }).on('dp.change', function (e) {
        e.preventDefault();
        LimparGrid();
    });


    LimparGrid();
    //CarregarComboCampanhas($comboCampanha);
    //CarregarComboStatusPedido($comboStatusPedido);

    $('html').on('change', '#comboCampanha', function (e) {
        e.preventDefault();
        LimparGrid();
    });

    $('html').on('change', '#comboStatus', function (e) {
        e.preventDefault();
        LimparGrid();
    });

});


$btnPesquisar.on('click', function () {
    if (ValidaFiltro()) {
        parametros = [];
        parametros = {
            DtInicioProc: $dataInicio.val(),
            DtFimProc: $dataFim.val(),
            AnoProc: $anoPesquisa.val(),
            CodCampanhaProc: $comboCampanha.val(),
            CodStatusProc: $comboStatusPedido.val(),
        }

        CarregarGrid(parametros);
    }
});

$btnLimpar.on('click', function () {
    $comboCampanha.val(1).trigger('change');
    $comboStatusPedido.val(1).trigger('change');
    $('input').val('');
    LimparGrid();
    $dataInicio.focus();
});

$btnImprimir.on('click', function (e) {
    e.preventDefault();

    tipoFormato = [];
    tipoParamentro = [];
    tipoFormato = { Pdf: "Pdf", Excel: "", Word: "" };
    tipoParamentro = { tipoformato: "Pdf" };

    if (ValidaFiltro()) {
        if ($table.bootstrapTable('getData').length > 0) {
            ImprimirRelatorioPDF(nomeRelatorio, nomeDataset, JSON.stringify(tipoFormato), JSON.stringify(tipoParamentro));
        }
    }
});

$btnExcel.on('click', function (e) {
    e.preventDefault();

    tipoFormato = [];
    tipoParamentro = [];
    tipoFormato = { Pdf: "Excel", Excel: "", Word: "" };
    tipoParamentro = { tipoformato: "Excel" };

    if (ValidaFiltro()) {
        if ($table.bootstrapTable('getData').length > 0) {
            ImprimirRelatorioExcel(nomeRelatorio, nomeDataset, JSON.stringify(tipoFormato), JSON.stringify(tipoParamentro));
        }
    }
});


// validando os campos do filtro
function ValidaFiltro() {

    if ($('#dtInicioPesquisa').val() === '' && $('#dtFimPesquisa').val() === '') {
        toastr.error('Necessário o preenchimento dos campos para efetuar a pesquisa!', 'Error', { timeOut: 5000, "progressBar": true, "positionClass": "toast-bottom-right", "closeButton": true });
        return false;
    }
    else if ($('#dtInicioPesquisa').val() === '') {
        toastr.error('Necessário o preenchimento do campo Data Início para efetuar a pesquisa!', 'Error', { timeOut: 5000, "progressBar": true, "positionClass": "toast-bottom-right", "closeButton": true });
        return false;
    }
    else if ($('#dtFimPesquisa').val() === '') {
        toastr.error('Necessário o preenchimento do campo Data Fim para efetuar a pesquisa!', 'Error', { timeOut: 5000, "progressBar": true, "positionClass": "toast-bottom-right", "closeButton": true });
        return false;
    }

    return true;
}

function CarregarGrid(params) {

    runLoadFiltro();
    $.ajax({

        url: '/relVdDia/CarregarGridConsulta',
        type: 'GET',
        dataType: 'json',
        cache: false,
        data: params,
        success: function (result) {
            if (!result.error) {
                $table.bootstrapTable('destroy');
                $table.bootstrapTable({
                    data: result.Message
                });
                $table.show();
                fechaLoadFiltro();
            }
            else {
                mensagemToastr(result);
            }
        }
    });
}

function LimparGrid() {
    $table.bootstrapTable('destroy');
    $table.bootstrapTable();
    $table.show();
}