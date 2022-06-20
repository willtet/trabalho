
function CarregarComboCampanhas(nomeComboCampanha) {
    $.ajax({
        url: '/MetodosPadrao/CarregarCampanhasCombo',
        async: false,
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            $(nomeComboCampanha).empty();
            $.each(data, function (i, e) {
                $(nomeComboCampanha).append($('<option></option>').val(e.idCampanha).text(e.NomeComercial));
            });
        }
    });
}

function CarregarComboStatusPedido(nomeComboStatusPedido) {
    $.ajax({
        url: '/MetodosPadrao/CarregarStatusPedidoCombo',
        async: false,
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            $(nomeComboStatusPedido).empty();
            $.each(data, function (i, e) {
                $(nomeComboStatusPedido).append($('<option></option>').val(e.idStatus).text(e.NomeStatus));
            });
        }
    });
}

function CarregarComboGateway(nomeComboGateway) {
    $.ajax({
        url: '/MetodosPadrao/CarregarGatewayCombo',
        async: false,
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            $(nomeComboGateway).empty();
            $.each(data, function (i, e) {
                $(nomeComboGateway).append($('<option></option>').val(e.idGateway).text(e.NomeGateway));
            });
        }
    });
}