
function TratarDataJson(value) {
    if (value === undefined || value === null) {
        return "-";
    } else {
        var date = new Date(parseInt(value.substr(6)));
        return ("0" + date.getDate()).slice(-2) + "/" + ("0" + (date.getMonth() + 1)).slice(-2) + "/" + date.getFullYear();
    }
}

function TratarDataJsonTipoString(value) {
    
    if (value !== '' && value !== null) {
        var dateMapa = moment(value, "DD-MM-YYYY");
        var date2 = new Date(moment(value, 'DD/MM/YYYY'));
        console.log(date2);
        return dateMapa._i;
    } else {
        return null;
    }

    
}

function TratarDataJsonMapa(value) {
    var dateMapa = moment(value, "DD-MM-YYYY");
    return dateMapa._i;
}

function TratarDataJsonMinute(value) {

    if (value === undefined || value === null) {
        return "-";
    } else {
        var date = new Date(parseInt(value.substr(6)));
        return ("0" + date.getDate()).slice(-2) + "/" + ("0" + (date.getMonth() + 1)).slice(-2) + "/" + date.getFullYear() + " " + addZero(date.getHours()) + ":" + addZero(date.getMinutes());
    }
}

function addZero(i) {
    if (i < 10) {
        i = "0" + i;
    }
    return i;
}