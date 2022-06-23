var $table = $('#tblFuncionario');

$(function () {
    AtualizaListaCadastro();
    ListarFunc();
});



function AtualizaListaCadastro() {

    $.ajax({
        url: '/Cadastro/AtualizaListaCadastro',
        type: 'GET',
        success: function (response) {
            console.log(response)
        }
    });
}


function ListarFunc() {
    $('#tblFuncionario').hide();
    $('#tblFuncionario').bootstrapTable('destroy')

    $.ajax({
        url: '/Cadastro/Consultar',
        type: 'GET',
        success: function (response) {
            if (response.Success) {
                $("#tblFuncionario").bootstrapTable({ data: response.Message });
                $("#tblFuncionario").show();
            } else {
                mensagemToastr(response);
            }
        }
    });
}

function acoes(value, row) {
    var html = '<div class="col-xs-12">';

    html += '<div class="col-xs-4">';
    html += '<a href="javascript:void(0);" class="editar" data-CodFuncionario= "' + row.CodFuncionario + '" data-status= "' + row.Novo + '" data-titulo= "' + row.TituloFormatado + '" data-confirmacao= 0 data-toggle="tooltip" data-placement="top" title="Dados do funcionario"><i class="fa fa-user"></i></a>';
    html += '</div>';

    html += '</div>';
    return html;
}

$('html').on('click', '.editar', function () {
    var codFunc = $(this).data().codfuncionario;

    BootstrapDialog.show({
        title: 'Editar Funcionario',
        message: $('<form id="frmEditar" data-toggle="validator" role="form" class="form-horizontal"></form>').load("/Cadastro/Edicao?codFuncionario=" + codFunc),
        size: BootstrapDialog.SIZE_WIDE,
        onshow: function (dialog) {
            if (status > 4) {
                dialog.getButton('btn-salvar-cliente').disable();
            }
        },
        closable: false,
        buttons: [{
            id: 'btn-salvar-cliente',
            label: 'Salvar',
            cssClass: 'btn-primary',
            action: function (dialogItself) {
                if (SalvarFuncionario()) {
                    ListarFunc();
                    dialogItself.close();
                }

            }
        }, {
            label: 'Cancelar',
            cssClass: 'btn-danger',
            action: function (dialogItself) {
                dialogItself.close();
            }
        }]
    });

});


$("#btnPesquisar").click(function () {
    ConsultarResultadoProjeto()
});

function ConsultarResultadoProjeto() {
    var _data = { nome: "", regime: "", tipo: "" }

    _data.nome = $("#nome").val();
    _data.regime = $("#regime").val();
    _data.tipo = $("#tipo").val();
    debugger

    $("#tblFuncionario").hide();
    $("#tblFuncionario").bootstrapTable('destroy')
    $.ajax({
        url: '/Cadastro/Consultar',
        type: 'GET',
        data: _data,
        success: function (response) {
            if (response.Success) {
                $("#tblFuncionario").bootstrapTable({ data: response.Message });
                $("#tblFuncionario").show();

                $("#nome").val('');
                $("#regime").val('');
                $("#tipo").val('')
            } else {
                mensagemToastr(response);
            }
        }
    });
}
