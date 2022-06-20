
function FormataNumerico(value) {
    return accounting.formatNumber(value);
}

function formataMoeda(value) {
    return new numeral(value).format('0,0.00');
}

//function formataMoeda2(value) {
//    return new numeral(value).format('0.0,00');
//}

function formataMoeda3(value) {
    return new numeral(value).format('0,0.000');
}

function formataMoeda4(value) {
    return new numeral(value).format('0,0.0000');
}

function formataMoeda5(value) {
    return new numeral(value).format('0,0.00000');
}

function formataMoeda6(value) {
    return new numeral(value).format('0,0.000000');
}

function formataMoeda7(value) {
    return new numeral(value).format('0,0.0000000');
}

function formataMoeda8(value) {
    return new numeral(value).format('0,0.00000000');
}

function formataMoeda9(value) {
    return new numeral(value).format('0,0.000000000');
}

function formataMoeda10(value) {
    return new numeral(value).format('0,0.0000000000');
}


function converteMoedaFloat(value) {
    var  num = numeral(value).format('0,0.00');
    var valor = num;

    if (valor === "") {
        valor = 0;
    } else {
        valor = valor.replace(",", ".");
        valor = valor.replace(".", ",");
        
        //valor = parseFloat(valor);
    }
    return valor;

}

function currencyFormat(num) {
    return num.toFixed(2).replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1.")

    //num.toFixed(2).replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1.")
}

//function valorPontoeVirgula(value) {
//    var tmp = parseFloat(value + '');

//    tmp = tmp.value.replace(/[.]/g, ",").replace(/\d(?=(?:\d{3})+(?:\D|$))/g, "$&.");

//    return tmp;

////maskMoney({
////prefix: "",
////    decimal: ",",
////thousands: "."
////        )};
//}

