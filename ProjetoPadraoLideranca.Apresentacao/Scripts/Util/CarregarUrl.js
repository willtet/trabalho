function CarregarUrlBrowser(url, urlAplicacao) {
    
    alert(urlAplicacao);
    var ambiente = '';
    var urlRegx = /(localhost)|(desenv)|(homolog)/g.exec(url);

    if (urlRegx !== null) {
        ambiente = urlRegx.shift(',');
    }

    switch (ambiente) {

        case 'localhost': // localhost
            window.location.href = urlAplicacao;
            break;

        case 'desenv': // desenv
            window.location.href = urlAplicacao;
            break;

        case 'homolog': // homolog
            window.location.href = urlAplicacao;
            break;

        case '': // produção
            window.location.href = urlAplicacao;
            break;

        default:
    }
}