$(function () {

    $('#search_cep').click(function () {
        $('#msg-cep').text('');
        var cep = $('#cep').val();
        var url = `viacep.com.br/ws/${cep}/json`;

        if (cep == '') {
            $('#msg-cep').html('* Informe o Cep antes de continuar.');
            $('#cep').focus();
            return false;
        }

        $.ajax({
            url: 'https://viacep.com.br/ws/' + cep + '/json',
            dataType: 'json',
            crossDomain: true,
            contentType: 'application/json',
            beforeSend: function () {
                $('#search_cep').addClass("disabled");    
            },
            statusCode: {
                200: function (data) {
                    if (data.erro) {
                        $("#msg-cep").html("* CEP não encontrado."); cleanAddress()
                    }
                    $('#uf').val(data.uf)
                    $('#cidade').val(data.localidade)
                    $('#bairro').val(data.bairro)
                    $('#rua').val(data.logradouro)
                } // Ok
                , 400: function (msg) { $("#msg-cep").html("* Não foi possivel realizar a pesquisa."); cleanAddress() } // Bad Request
                , 404: function (msg) { $("#msg-cep").html("* CEP não encontrado."); cleanAddress() } // Not Found
            },
            error: function () {
                $("#msg-cep").html("* Não foi possivel realizar a pesquisa.");
                cleanAddress()
            }
        });
        $('#search_cep').removeClass("disabled");
    });

    function cleanAddress() {
        $('#uf').val("")
        $('#cidade').val("")
        $('#bairro').val("")
        $('#rua').val("")
    }
});