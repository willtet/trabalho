var Cartelas =
{
    /**
	 * Função de inicialização do javascript da aplicação
	 */
    init: function () {
        Cartelas.btns();
        Cartelas.masks();
        Cartelas.listeners();
        Cartelas.keypath();
    },

    /**
	 * Funções dos botões
	 */
    btns: function () {
        $('.btn-pesquisa-titulo').click(function () {
            Cartelas.showHideSearch('pesquisa-titulo', 'pesquisa-rodas-fortuna');
            $('#produto').focus();
        });
        $('.btn-pesquisa-rodas-fortuna').click(function () {
            // botão bloqueado para sua ação
            return false;
            //Cartelas.showHideSearch('pesquisa-rodas-fortuna', 'pesquisa-titulo');
            //$('#numero_rodas_fortuna').focus();
        });
        $('.fecha').click(function () {
            $(this).closest('.box-pesquisa').fadeOut('slow');
        });
        $('#btn-alert-remove').click(function () {
            $('.alert').fadeOut('slow');
        });
        $('.btn-imprimir').click(function () {
            window.print();
        });
        $('.btn-login').click(function () {
            $('.box-login').toggle('fold');
        });
    },

    /**
	 * Exibe e esconde pesquisas da aplicação
	 * 
	 * @param show    pesquisa a ser exibida ou oculta
	 * @param hide    a outra pesquisa que será sempre fechada.
	 */
    showHideSearch: function (show, hide) {
        $('#' + show).fadeToggle('slow', 'swing');
        $('#' + hide).hide();
        $('.alert').hide();
        $('#' + show + ' .container form input').each(function () {
            $(this).val('');
        });
        Cartelas.masks();
    },

    /**
	 * Cria máscaras para os campos de pesquisa do título
	 */
    masks: function () {
        $('#produto').setMask({ mask: '99', 'maxLength': 2 });
        $('#serie').setMask({ mask: '9999', 'maxLength': 4 });
        $('#ntitulo').setMask({ mask: '9999999', 'maxLength': 7 });
        $('#dv').setMask({ mask: '9', 'maxLength': 1 }); // 'autoTab':false
    },

    /**
     * monitora ações na página
     * 
     * @returns {undefined}
     */
    listeners: function () {
        $('#produto').on('blur', function () {
            var produto = $("#produto").val();
            if (produto.length > 0) {
                $("#produto").val(Cartelas.ajustaInput(produto, 2));
                Cartelas.exibeDigito();
            }
        });
        $('#serie').on('blur', function () {
            var serie = $("#serie").val();
            if (serie.length > 0) {
                $("#serie").val(Cartelas.ajustaInput(serie, 4));
                Cartelas.exibeDigito();
            }
        });
        $('#ntitulo').on('blur', function () {
            var titulo = $("#ntitulo").val();
            if (titulo.length > 0) {
                $("#ntitulo").val(Cartelas.ajustaInput(titulo, 7));
                Cartelas.exibeDigito();
            }
        });
    },

    /**
     * Controla teclas de atalho
     * F7 => Abre pesquisa (118 ASCII)
     * @returns {undefined}
     */
    keypath: function () {
        $(document).keydown(function (e) {
            if (e.which == 118 || e.keyCode == 118) {
                Cartelas.showHideSearch('pesquisa-titulo', 'pesquisa-rodas-fortuna');
                $('#produto').focus();
            }
        });
    },

    /**
     * Calcula dígito pelo Módulo 11, base 9
     * 
     * @param   {String} cNumero (número do título aglutinado completo)
     * @returns {Number} nResult (dígito verificador)
     */
    calculaDigito: function (cNumero) {
        var nSoma = 0; //int
        var nFatorCalc = 2; //int
        var nResto = 0; //int
        var nLoop = cNumero.length; //int
        var nResult = 0; //int

        if (cNumero == null) {
            nResult = -1;
        }

        while (nLoop >= 1 && nResult > -1) {
            var sub = cNumero.substring((nLoop - 1), nLoop);
            if (sub >= 0 && sub <= 9) {
                nSoma = nSoma + (parseInt(sub) * nFatorCalc);
                if (nFatorCalc === 9) {
                    nFatorCalc = 2;
                } else {
                    nFatorCalc += 1;
                }
            } else {
                nResult = -1;
            }
            nLoop -= 1;
        }

        // Configura o resultado
        if (nResult > -1) {
            nResto = nSoma - (Math.floor(nSoma / 11) * 11);
            if (nResto < 2) {
                nResult = 0;
            } else {
                nResult = 11 - nResto;
            }
        }

        return nResult;
    },

    /**
     * Ajusta com zeros a esquerda o número passado 
     * 
     * @param {type} numero (número a ser ajustado)
     * @param {type} limite (tamanho total do número)
     * 
     * @returns {String}
     */
    ajustaInput: function (numero, limite) {
        var adiciona = limite - numero.length;
        for (var i = 0; i < adiciona; i++) {
            numero = '0' + numero;
        }
        return numero;
    },

    /**
     * Une número do título (produto|série|título) em uma só string
     * 
     * @param {Integer} produto
     * @param {Integer} serie
     * @param {Integer} ntitulo
     * 
     * @returns {String}
     */
    aglutinaNTitulo: function (produto, serie, ntitulo) {
        var novoproduto = "";
        var novoserie = "";
        var novontitulo = "";

        //produto
        novoproduto = Cartelas.ajustaInput(produto, 2);

        //serie
        novoserie = Cartelas.ajustaInput(serie, 4);
        //titulo
        novontitulo = Cartelas.ajustaInput(ntitulo, 7);

        return novoproduto + novoserie + novontitulo;
    },

    /**
     * Verifica qual o dígito verificador de um produto|série|título
     * 
     * @param {Integer} produto
     * @param {Integer} serie
     * @param {Integer} ntitulo
     * 
     * @returns {Number}
     */
    verificaDigito: function (produto, serie, ntitulo) {
        var titulo = null;
        var dv = null;

        titulo = Cartelas.aglutinaNTitulo(produto, serie, ntitulo);
        dv = Cartelas.calculaDigito(titulo);

        return dv;
    },

    exibeDigito: function () {
        var produto = $('#produto').val();
        var serie = $('#serie').val();
        var ntitulo = $('#ntitulo').val();
        var dv = null;

        if (produto == '' || serie == '' || ntitulo == '') {
            return false;
        } else {
            dv = Cartelas.verificaDigito(produto, serie, ntitulo);
        }

        $('#dv').val(dv);
    }
};

$(document).ready(function () {
    Cartelas.init();
});