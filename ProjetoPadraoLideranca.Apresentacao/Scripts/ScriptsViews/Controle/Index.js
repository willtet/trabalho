$(function () {
    $("#btnExcel").hide();
    ConsultarProjetos();
});

function ConsultarProjetos() {
    $.ajax({
        url: '/Controle/ConsultarProjetos',
        type: 'GET',
        success: function (response) {
            debugger
            if (response.Success) {
                
                montaSelectList("#Projeto", response.Message, "CodJira", "CodigoJira","Selecione");
            } else {
                mensagemToastr(response);
            }
        }
    });
}

$("#btnPesquisar").click(function () {
    ConsultarResultadoProjeto()
});

function ConsultarResultadoProjeto() {
    var _data = { projeto: "", regime: "", mes: 0, ano: 0 }
    var ma = $("#mesAno input").val().split("/")
    if (ma != '') {
        var mesAno = $("#mesAno input").val().split("/")
    } else {
        var mesAno = '0/0'.split("/")
    }

    _data.projeto = $("#Projeto").find(":selected").text();
    _data.regime = $("#regime").val();
    _data.mes = mesAno[0];
    _data.ano = mesAno[1];
    debugger

    $("#tblResultado").hide();
    $("#btnExcel").hide();
    $("#tblResultado").bootstrapTable('destroy')
    $.ajax({
        url: '/Controle/ConsultarResultadoProjetosJira',
        type: 'POST',
        data: _data,
        success: function (response) {
            if (response.Success) {
                $("#tblResultado").bootstrapTable({ data: response.Message });
                $("#tblResultado").show();
                $("#btnExcel").show();

                $("#regime").val('');
                $("#mesAno input").val('')
            } else {
                mensagemToastr(response);
            }
        }
    });
}

$("#btnExcel").click(function () {
    GerarResultadoExcel()
});



function GerarResultadoExcel() {
    var _data = { projeto: "", regime: "", mes: 0, ano: 0 }
    var ma = $("#mesAno input").val().split("/")
    if (ma != '') {
        var mesAno = $("#mesAno input").val().split("/")
    } else {
        var mesAno = '0/0'.split("/")
    }

    _data.projeto = $("#Projeto").find(":selected").text();
    _data.regime = $("#regime").val();
    _data.mes = mesAno[0];
    _data.ano = mesAno[1];

    openBlank("/Controle/ExcelResultadoProjetosJira?projeto=" + _data.projeto + "&regime=" + _data.regime + "&mes=" + _data.mes + "&ano="+ _data.ano)
}

function openBlank(url) {
    window.open(url, "_blank");
}


