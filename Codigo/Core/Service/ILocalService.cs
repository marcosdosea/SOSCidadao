
using System.Collections.Generic;
﻿using Core.DTO;
using System;
using System.Text;

namespace Core.Service
{
    public interface ILocalService
    {
        int Inserir(Local local);
        Local Obter(int idLocal);
        IEnumerable<Local> ObterTodos();
        LocalDTO ObterDTO(int idLocal);
        IEnumerable<LocalDTO> ObterTodosDTO();
        void Atualizar(Local local);
        void Remover(int idLocal);
    }
}