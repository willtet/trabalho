
function GerandoTipoRelatorioBase(url, jsonResul, nomeRelatorio, tipoFormato) {

    debugger;
    
    runLoadFiltro();

    $.ajax({
        url: url,
        type: 'POST',
        dataType: 'json',
        async: false, //_async,
        data: { listaRelatorio: jsonResul },
        success: function (response) {
            if (response.Success) {
                if (response.Codigo === 0) {

                    switch (tipoFormato) {

                        case 'PDF':
                            ImprimirRelatorioPDF(nomeRelatorio, tipoFormato);
                            break;

                        case 'Imprimir':
                            ImprimirRelatorioPDF(nomeRelatorio, tipoFormato);
                            break;

                        case 'Excel':
                            ImprimirRelatorioPDF(nomeRelatorio, tipoFormato);
                            break;
                    }
                    fechaLoadFiltro();
                } else {
                    toastr.warning(response.Message, 'Atenção!', { timeOut: 5000, "progressBar": true, "positionClass": "toast-bottom-right", "closeButton": true });
                    fechaLoadFiltro();
                }
            } else {
                toastr.error(response.Message, 'Error!', { timeOut: 5000, "progressBar": true, "positionClass": "toast-bottom-right", "closeButton": true });
                fechaLoadFiltro();
            }
        },
        error: function (response) {
            fechaLoadFiltro();
        }
    });
}