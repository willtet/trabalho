$(function () {
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
    var _data = { projeto: "" }

    _data.projeto = $("#Projeto").find(":selected").text();
    debugger

    $("#tblResultado").hide();
    $("#tblResultado").bootstrapTable('destroy')
    $.ajax({
        url: '/Controle/ConsultarResultadoProjetosJira',
        type: 'POST',
        data: _data,
        success: function (response) {
            if (response.Success) {
                $("#tblResultado").bootstrapTable({ data: response.Message });
                $("#tblResultado").show();
            } else {
                mensagemToastr(response);
            }
        }
    });
}


