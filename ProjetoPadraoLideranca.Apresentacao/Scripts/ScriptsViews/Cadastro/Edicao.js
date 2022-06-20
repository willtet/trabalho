function ConsultaFunc(codfuncionario) {
    var funcionario = {};
    CodFuncionario = $(".hdnCodFuncionario").val();

    $.ajax({
        url: "/Cadastro/ConsultaUmFuncionario/?codfuncionario=" + CodFuncionario,
        type: 'GET',
        async: false,
        success: function (response) {
            if (response.Success) {
                if (response.Message.length > 0) {
                    funcionario = response.Message[0];
                }

            } else {
                mensagemToastr(response);
            }
        }
    });

    console.log(funcionario)

    if (funcionario != null) {

        $(".modal #nome").val(funcionario.Nome);
        $(".modal #regime").val(funcionario.Regime.trim());
        $(".modal #horario").val(cliente.CargaHoraria);
        $(".modal #salario").val(cliente.Salario);
        $(".modal #vt").val(cliente.vt);
        $(".modal #vr").val(cliente.vr);
        $(".modal #va").val(cliente.va);
        $(".modal #medica").val(cliente.medica);
        $(".modal #odonto").val(cliente.odonto);
        $(".modal #seguro").val(cliente.seguro);
        $(".modal #creche").val(cliente.creche);
        $(".modal #baba").val(cliente.baba);
        if (cliente.Tipo != null) {

            if (cliente.Tipo.toUpperCase() == 'CAPEX') {
                $(".modal #capex").click();
            }

            if (cliente.Tipo.toUpperCase() == 'OPEX') {
                $(".modal #opex").click();
            }
        }
    }
}

$(function () {
    ConsultaFunc(1)
});

