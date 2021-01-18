
$(document).ready(function () {
    $('#bt_create').click(function () {
        if ($(this).html().trim() == 'Continuar') {
            $('#box-main').removeClass('col-12');
            $('#box-main').addClass(['col-6', 'd-flex', 'justify-content-center', 'flex-column']);

            $('#data-personal').toggle();
            $('#data-user').removeClass('d-none');

            $('#step').html('Etapa 2');
            $(this).html('Finalizar')
        } else if ($(this).html().trim() == 'Finalizar') {
            $('#form-create').submit();
        }
    });
    $('#btn_back').click(function (e) {
        if ($('#step').html().trim() == 'Etapa 2') {
            e.preventDefault()
            $('#box-main').addClass('col-12');
            $('#box-main').removeClass(['col-6', 'd-flex', 'justify-content-center', 'flex-column']);

            $('#data-personal').toggle();
            $('#data-user').addClass('d-none');

            $('#step').html('Etapa 1');
            $('#bt_create').html('Continuar');               
                
            $(this).removeAttr('asp-controller');
            $(this).removeAttr('asp-action');
        }

    });




});