



$(document).ready(function () {

    $('.input-group .date').datepicker({
        //format: 'DD/MM/YYYY'
        language: 'pt-BR',
        autoclose: true,

    });


    /** "ouve" clique no botão de abrir/fechar conteúdo do box */
    $('.toggle-filter').on('click', function () {
        var box = $(this).closest('.box');
        toggleFilter(box);
    });
});

/** Fecha/Abre conteúdo do box */
function toggleFilter(box) {
    $(box).find('.content-box').slideToggle();
    $(box).find('.toggle-filter').toggleClass('close-content-box');
}


/** Formata Valor em tabela bootstrap **/
function formataDecimalQtd(value, row) {
    if (value == null) {
        return "";
    }
    var tmp = parseFloat(value + '');
    if (isNaN(tmp)) {
        return '';
    }
    tmp = tmp + "";
    //tmp = tmp.replace(/\D/g, "");
    if (tmp.length > 3) {
        tmp = tmp.replace(/([0-9]{3})$/g, ".$1");
    }
    if (tmp.length > 6)
        tmp = tmp.replace(/([0-9]{3}),([0-9]{3}$)/g, ".$1.$2");
    return tmp;
}

function formataQtd(value) {
    if (value == null) {
        return "";
    }
    var tmp = parseFloat(value + '');
    if (isNaN(tmp)) {
        return '';
    }
    tmp = tmp + "";
    //tmp = tmp.replace(/\D/g, "");
    if (tmp.length > 3) {
        tmp = tmp.replace(/([0-9]{3})$/g, ".$1");
    }
    if (tmp.length > 6)
        tmp = tmp.replace(/([0-9]{3}),([0-9]{3}$)/g, ".$1.$2");
    return tmp;
}


function formataData(value, row) {
    //alert(value);

    //alert(value);

    if (value != null) {

        var d = value;
        d = d.toString().replace("/Date(", "").replace(")/", "");
        d = new Date(parseInt(d));
        var strData = "";
        if (d.getDate() < 10) {
            strData = "0" + d.getDate() + '/';
        } else {
            strData = d.getDate() + '/';
        }
        if (d.getMonth() < 10) {
            strData += '0' + (d.getMonth() + 1);
        } else {
            strData += (d.getMonth() + 1);
        }
        return strData + '/' + d.getFullYear();
    }
    else
        return '';

}


function formataDecimal(value, row) {
    var tmp = parseFloat(value + '');
    //tmp = tmp.replace(/\D/g, "");
    if (tmp.length > 3) {
        tmp = tmp.replace(/([0-9]{3})$/g, ".$1");
    }
    if (tmp.length > 6)
        tmp = tmp.replace(/([0-9]{3}),([0-9]{3}$)/g, ".$1.$2");

    return tmp;
}

$("#toggle_sidemenu_l").mouseup(function () {
    setTimeout(function () {
        $("#tblRelatorio").bootstrapTable('resetWidth');
    }, 300);
});


function percentualComVirgula(value) {
    value = value.toString();
    var str = value.replace(".", ",");
    return str;
}



