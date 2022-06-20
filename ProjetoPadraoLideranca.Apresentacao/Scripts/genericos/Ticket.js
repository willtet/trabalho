
var ModalTicket = {   

    /* Função para a inicialização do javascript da aplicação */
    init: function() {
        ModalTicket.keypath();
        ModalTicket.keypTicketHome();
    },
    
    keypath: function(e) {
        $(document).keydown(function(e) {
            if (e.which == 118 || e.keyCode == 118) { // F7
                
                $('#myModal').modal({
                    keyboard: true
                }, 'show');

                NovoTicketHome();

                return false;
            }
        });
    },
    
    keypTicketHome: function (e) {
        $(document).keydown(function (e) {
            if (e.which == 119 || e.keyCode == 119) { //F8

                $('#myModalTicketHome').modal({
                    keyboard: true
                }, 'show');

                SelcionarTicketHome();

                return false;
            }
        });
    }
    
};


$(document).ready(function() {
    ModalTicket.init();
});

function NovoTicketHome(parametrosFiltro) {

    $.ajax({
        url: '/Ticket/Create',
        type: 'GET',
        data: parametrosFiltro,
        success: function (response) {
            if (response.success) {
                $('#myModal').attr('tabindex');
                $('#myModal').modal('hide');
                location.reload();
            } else {
                $('#myModal').removeAttr('tabindex');
                $('#myModalContent').html(response);
            }
        },
        error: function (response) { }
    });

    return false;
}


function SelcionarTicketHome() {

    $.ajax({
        url: '/Home/TicketHome',
        type: 'GET',
        success: function (response) {
            if (response.success) {
                $('#myModalTicketHome').attr('tabindex');
                $('#myModalTicketHome').modal('hide');
                location.reload();
            } else {
                $('#myModalTicketHome').removeAttr('tabindex');
                $('#myModalContentTicketHome').html(response);
            }
        },
        error: function (response) { }
    });

    return false;
}

