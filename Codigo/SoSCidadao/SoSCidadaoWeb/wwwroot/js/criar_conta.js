﻿
$(document).ready(function () {


    $('#bt_create').click(function () {
        if ($(this).html().trim() == 'Continuar') {
            $('#box-main').removeClass('col-12');
            $('#box-main').addClass(['col-6', 'd-flex', 'justify-content-center', 'flex-column']);
            $('#data-personal').toggle();
            $('#data-user').removeClass('d-none');
            $('#step').html('Etapa 2');
            $(this).html('Finalizar')
        }
    });
    $('#btn_back').click(function () {
        if ($('#step').html().trim() == 'Etapa 2') {
            $('#box-main').addClass('col-12');
            $('#box-main').removeClass(['col-6', 'd-flex', 'justify-content-center', 'flex-column']);
            $('#data-personal').toggle();
            $('#data-user').addClass('d-none');
            $('#step').html('Etapa 1');
            $('#bt_create').html('Continuar')
        }

    });




});