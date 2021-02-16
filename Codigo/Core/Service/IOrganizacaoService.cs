using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Service
{
    public interface IOrganizacaoService
    {
        int Inserir(Organizacao organizacao);
        Organizacao Obter(int idOrganizacao);
        IEnumerable<Organizacao> ObterTodos();
        OrganizacaoDTO ObterDTO(int idOrganizacao);
        IEnumerable<OrganizacaoDTO> ObterTodosDTO();
        void Atualizar(Organizacao organizacao);
        void Remover(int idOrganizacao);
    }
}