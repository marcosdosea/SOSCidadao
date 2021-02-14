using System.Collections.Generic;
﻿using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;


namespace Core.Service
{
    public interface IPessoaService
    {
        int Inserir(Pessoa pessoa);
        Pessoa Obter(int idPessoa);
        IEnumerable<Pessoa> ObterTodos();
        PessoaDTO ObterDTO(int idPessoa);
        IEnumerable<PessoaDTO> ObterTodosDTO();
        void Atualizar(Pessoa pessoa);
        void Remover(int idPessoa);
    }
}
