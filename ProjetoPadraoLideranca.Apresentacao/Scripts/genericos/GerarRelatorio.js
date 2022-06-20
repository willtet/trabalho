//var nomeController = 'GerarRelatorio'; // nome da contrller onde vai ser gerado o relatório
//var nomeAction = 'GerandoRelatorio'; // nome do action onde vai ser gerado o relatório
function GerarRelatorio(nomeRelatorio, tipoFormato) {
    $.ajax({
        url: '/GerarTIpoArquivoRelatorio/GerarRelatorio',
        type: 'POST',
        dataType: 'json',
        data: { nomeRelatorio: nomeRelatorio, tipoFormato: tipoFormato },
        success: function (response) {
            if (response.Url !== '') {
                window.open(response.Url, '_blank');
            } else {
                toastr.error(response.Message, 'Error', { timeOut: 5000, "progressBar": true, "positionClass": "toast-bottom-right", "closeButton": true });
            }
        }
    });
}

// Imprimir - Método padrão para gerar relatórios em PDFs
function ImprimirRelatorioPDF(nomeRelatorio, tipoFormato) {

    runLoadFiltro();
    var url = '/GerarRelatorio/GerandoRelatorio?nomeRelatorio=' + nomeRelatorio + '&tipoFormato=' + tipoFormato;
    window.open(url, '_blank');
    setTimeout(function () {
        fechaLoadFiltro();
    }, 500); // 3 segundos
}

// Gerar Excel - Método Padrão para gerar relatórios em Excel
function ImprimirRelatorioExcel(nomeRelatorio, tipoFormato) {
    runLoadFiltro();
    var url = '/GerarRelatorio/GerandoRelatorio?nomeRelatorio=' + nomeRelatorio + '&tipoFormato=' + tipoFormato;
    window.location.href = url;
    setTimeout(function () {
        fechaLoadFiltro();
    }, 1500); // 3 segundos
}

// Gerar Excel - Método Padrão para gerar relatórios em Excel
function ImprimirRelatorioExcelLento(nomeRelatorio, tipoFormato) {
    runLoadFiltro();
    var url = '/GerarRelatorio/GerandoRelatorio?nomeRelatorio=' + nomeRelatorio + '&tipoFormato=' + tipoFormato;
    window.location.href = url;
    setTimeout(function () {
        fechaLoadFiltro();
    }, 50000); // 3 segundos
}

// Imprimir - Método padrão para gerar relatórios em PDFs
function GerarRelatorioPDF(controller, tipoRelatorio) {
    runLoadFiltro();
    var url = '/' + controller + '/GeraRelatorio?tipoRelatorio=' + tipoRelatorio;
    window.open(url, '_blank');
    setTimeout(function () {
        fechaLoadFiltro();
    }, 1500); // 3 segundos
}

// Gerar Excel - Método Padrão para gerar relatórios em Excel
function GerarRelatorioExcel(controller, tipoRelatorio) {
    runLoadFiltro();
    var url = '/' + controller + '/GeraRelatorio?tipoRelatorio=' + tipoRelatorio;
    window.location.href = url;
    setTimeout(function () {
        fechaLoadFiltro();
    }, 1500); // 3 segundos
}


// Imprimir - Método padrão para gerar relatórios em PDFs
function ImprimirRelatorioPDF(nomeRelatorio, nomeDataSet, tipoFormato, tipoParamentro) {

    runLoadFiltro();
    var url = '/GerarRelatorio/GerandoRelatorio?nomeRelatorio=' + nomeRelatorio + '&nomeDataSet=' + nomeDataSet + '&tipoFormato=' + tipoFormato + '&tipoParamentro=' + tipoParamentro;

    window.open(url, '_blank');
    setTimeout(function () {
        fechaLoadFiltro();
    }, 1500); // 3 segundos
}

// Gerar Excel - Método Padrão para gerar relatórios em Excel
function ImprimirRelatorioExcel(nomeRelatorio, nomeDataSet, tipoFormato, tipoParamentro) {
    runLoadFiltro();
    var url = '/GerarRelatorio/GerandoRelatorio?nomeRelatorio=' + nomeRelatorio + '&nomeDataSet=' + nomeDataSet + '&tipoFormato=' + tipoFormato + '&tipoParamentro=' + tipoParamentro;

    window.location.href = url;
    setTimeout(function () {
        fechaLoadFiltro();
    }, 2500); // 3 segundos
}