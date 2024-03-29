﻿using Core.DTO;
using System.Collections.Generic;

namespace Core.Service
{
    public interface IPertenceService
    {
        int Inserir(Pertence pertence);
        Pertence Obter(int idPertence);
        IEnumerable<Pertence> ObterTodos();
        PertenceDTO ObterDTO(int idPertence);
        IEnumerable<PertenceDTO> ObterTodosDTO();
        void Atualizar(Pertence pertence);
        void Remover(int idPertence);
    }
}
