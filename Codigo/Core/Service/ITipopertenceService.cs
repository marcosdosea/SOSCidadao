﻿using Core.DTO;
using System.Collections.Generic;

namespace Core.Service
{
    public interface ITipopertenceService
    {

        int Inserir(Tipopertence tipoPertence);

        Tipopertence Obter(int idTipoPertence);

        IEnumerable<Tipopertence> ObterTodos();

        TipopertenceDTO ObterDTO(int idTipoPertence);

        IEnumerable<TipopertenceDTO> ObterTodosDTO();

        void Atualizar(Tipopertence tipoPertence);

        void Remover(int idTipoPertence);

    }
}
