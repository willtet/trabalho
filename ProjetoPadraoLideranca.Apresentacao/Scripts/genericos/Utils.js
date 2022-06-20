function montaSelectList(idSelectList, arrayObjetos, propriedadeId, propriedadeTexto, textoPadrao) {

    if (textoPadrao == "" || textoPadrao == undefined) {
        textoPadrao = "Selecione";
    }
    $(idSelectList).empty();
    var options = '';
    for (var i = 0; i < arrayObjetos.length; i++) {
        options += '<option value="' + arrayObjetos[i][propriedadeId] + '">' + arrayObjetos[i][propriedadeTexto] + '</option>';
    }


    if (arrayObjetos.length > 0) {
        if (arrayObjetos.length > 1) {
            $(idSelectList).append('<option value="">' + textoPadrao + '</option>');
        }
        $(idSelectList).append(options);
    } else {
        $(idSelectList).append('<option value="">Sem Dados</option>');
    }
}

function mensagemToastr(contexto) {
    toastr.options = {
        "closeButton": true,
        "debug": false,
        "newestOnTop": false,
        "progressBar": false,
        "positionClass": "toast-top-full-width",
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "300",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    }

    var resposta = {};

    if (contexto.Message != undefined) {
        if (contexto.Message.length >= 1) {
            resposta = contexto.Message[0];
        } else {
            resposta = contexto.Message;
        }
    } else {
        resposta = contexto;
    }


    if (resposta.Codigo == undefined) {
        toastr["error"]("Ocorreu um erro", "Erro");
        return;
    }

    if (resposta.Codigo == 0) {
        toastr["success"](resposta.Descricao, "Sucesso");
        return;
    }

    if (resposta.Codigo > 0) {
        toastr["warning"](resposta.Descricao, "Atenção");
        return;
    }

    if (resposta.Codigo < 0) {
        toastr["error"](resposta.Descricao, "Erro");
        return;
    }
}

$('html').on('keydown', '.sonumeros', function (e) {
    // Allow: backspace, delete, tab, escape, enter and .
    if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
        // Allow: Ctrl/cmd+A
        (e.keyCode == 65 && (e.ctrlKey === true || e.metaKey === true)) ||
        // Allow: Ctrl/cmd+C
        (e.keyCode == 67 && (e.ctrlKey === true || e.metaKey === true)) ||
        // Allow: Ctrl/cmd+C
        (e.keyCode == 86 && (e.ctrlKey === true || e.metaKey === true)) ||
        // Allow: Ctrl/cmd+X
        (e.keyCode == 88 && (e.ctrlKey === true || e.metaKey === true)) ||
        // Allow: home, end, left, right
        (e.keyCode >= 35 && e.keyCode <= 39)) {
        // let it happen, don't do anything
        return;
    }
    // Ensure that it is a number and stop the keypress
    if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
        e.preventDefault();
    }
});

Date.prototype.addDays = function (days) {
    this.setDate(this.getDate() + parseInt(days));
    return this;
}

Date.prototype.DataBR = function (days) {
    var retorno = "";

    if (this.getDate() < 10) {
        retorno = "0" + this.getDate() + "/";
    } else {
        retorno = this.getDate() + "/";
    }

    if ((this.getMonth() + 1) < 10) {
        retorno += "0" + (this.getMonth() + 1) + "/";
    } else {
        retorno += (this.getMonth() + 1) + "/";
    }

    retorno += this.getFullYear();
    return retorno;
}

 $(document).ajaxStart(function () {
    runLoadFiltro();
});

$(document).ajaxStop(function () {
    fechaLoadFiltro();
});

function datesSorter(a, b) {
    var data1 = a.split('/');
    var data2 = b.split('/');

    if (data1.length > 0) {
        var novaData1 = new Date(parseInt(data1[2]), parseInt(data1[1]) - 1, parseInt(data1[0]));
    }

    if (data2.length > 0) {
        var novaData2 = new Date(parseInt(data2[2]), parseInt(data2[1]) - 1, parseInt(data2[0]));
    }

    if (novaData1 < novaData2) {
        return 1
    };

    if (novaData1 > novaData2) {
        return -1
    };

    return 0;
}