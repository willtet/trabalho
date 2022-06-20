
function ModalMensagem(mensagem, title, btnOkClass, type) {
    BootstrapDialog.show({
        type: type,
        title: title,
        btnOKClass: btnOkClass,
        message: mensagem,
        buttons: [{
            id: 'btnFechar',
            label: btnCancel,
            icon: 'fa fa-ban',
            cssClass: 'btn-danger btn-sm',
            action: function (dialogItself) {
                dialogItself.close();
            }
        }]
    });
}

function ModalMensagem2(mensagem, title, btnOkClass, type) {
    BootstrapDialog.show({
        type: type,
        title: title,
        btnOKClass: btnOkClass,
        message: mensagem,
        buttons: [{
            id: 'btnFechar',
            label: btnCancel,
            icon: 'fa fa-ban',
            cssClass: 'btn-danger btn-sm',
            action: function (dialogItself) {
                dialogItself.close();
            }
        }]
    });
}

function ModalMensagemConfirmShow(mensagem, title, btnOkClass, btnCancel, btnOk, type) {

    BootstrapDialog.show({
        type: type,
        title: title,
        btnOKClass: btnOkClass,
        message: mensagem,
        buttons: [
         {
             id: 'btnSalvar',
             icon: 'fa fa-floppy-o',
             label: btnOk,
             cssClass: 'btn-primary btn-sm',
             action: function (dialogItself) {
                 ChamaBaixa();
                 dialogItself.close();
             }
         },
         {
             id: 'btnFechar',
             label: btnCancel,
             icon: 'fa fa-ban',
             cssClass: 'btn-danger btn-sm',
             action: function (dialogItself) {
                 dialogItself.close();
             }
         }]
    });
}

function ModalMensagemObs(mensagem, title, btnOkClass, btnCancel, btnOk, type, numero) {
    console.log(mensagem);
    BootstrapDialog.show({
        type: type,
        title: title,
        btnOKClass: btnOkClass,
        message: function (dialogRef) {
            var $content = $('<div>' + mensagem + ' <textarea rows="3" cols="75" class="txtareaobs"></textarea></div>');
            return $content;
        },
        buttons: [
            {
                id: 'btnSalvar',
                icon: 'fa fa-floppy-o',
                label: btnOk,
                cssClass: 'btn-primary btn-sm',
                action: function (dialogItself) {
                    var mensagemTextArea = $('.txtareaobs').val();
                    ChamaObservacao(mensagemTextArea);
                    dialogItself.close();
                }
            },
            {
            id: 'btnFechar',
            label: btnCancel,
            icon: 'fa fa-ban',
            cssClass: 'btn-danger btn-sm',
            action: function (dialogItself) {
                dialogItself.close();
            }
        }]
    });
}





