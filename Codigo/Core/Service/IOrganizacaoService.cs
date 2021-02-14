using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Service
{
    public interface IOrganizacaoService
    {
        int Inserir(Organizacao organizacao);
        Organizacao Obter(int idorganizacao);
        IEnumerable<Organizacao> ObterTodos();
        OrganizacaoDTO ObterDTO(int idLocal);
        IEnumerable<OrganizacaoDTO> ObterTodosDTO();
        void Atualizar(Organizacao organizacao);
        void Remover(int idorganizacao);
    }
}