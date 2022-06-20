
function runLoad() {

    $('.sitePautas').waitMe({
        effect: 'ios',
        //text: 'Por favor, aguarde...',
        bg: 'rgba(255,255,255,0.7)',
        color: '#72274F',
        maxSize: '',
        source: '',
        onClose: function () {
        }
    });
}

function fechaModal() {
    $('.sitePautas').waitMe('hide');
}

// Para Modal
function runLoadModal() {

    $('.modal-body').waitMe({
        effect: 'ios',
        //text: 'Por favor, aguarde...',
        bg: 'rgba(255,255,255,0.7)',
        color: '#72274F',
        maxSize: '',
        source: '',
        onClose: function () {
        }
    });
}

// Para Modal
function fechaLoadModal() {
    $('.modal-body').waitMe('hide');
}

// Para filtro
function runLoadFiltro() {

    $('.filtro').waitMe({
        effect: 'ios',
        //text: 'Por favor, aguarde...',
        bg: 'rgba(255,255,255,0.7)',
        color: '#72274F',
        maxSize: '',
        source: '',
        onClose: function () {
        }
    });
}

// Para filtro
function fechaLoadFiltro() {
    $('.filtro').waitMe('hide');
}