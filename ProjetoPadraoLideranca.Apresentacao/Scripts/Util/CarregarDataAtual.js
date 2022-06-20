
$('.date').datetimepicker({
    format: 'DD/MM/YYYY',
    daysOfWeekDisabled: [, ]
});

// carregando a data atual do sistema
function CarregarDataAtualInicial() {
    var d = new Date();
    var day = addZero(d.getDate());
    var month = addZero(d.getMonth() - 0);
    var year = addZero(d.getFullYear());
    return day + "/ " + month + "/ " + year;
}


// carregando a data atual do sistema
function CarregarDataAtual() {
    var d = new Date();
    var day = addZero(d.getDate());
    var month = addZero(d.getMonth() + 1);
    var year = addZero(d.getFullYear());
    return day + "/ " + month + "/ " + year;
}

// adicionando zeros
function addZero(i) {
    if (i < 10) {
        i = "0" + i;
    }
    return i;
}