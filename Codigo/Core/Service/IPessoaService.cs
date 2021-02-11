using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Service
{
    public interface IPessoaService
    {

        int Inserir(Pessoa pessoa);
        Pessoa Obter(int id);
        IEnumerable<PessoaDTO> ObterTodosDTO();
        PessoaDTO ObterDTO(int idPertence);
        IEnumerable<Pessoa> ObterTodos();
        int Atualizar(Pessoa pessoa);
        int Remover(int id);
        bool Validar(Pessoa pessoa);
    }
}
