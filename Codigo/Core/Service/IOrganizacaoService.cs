using Core.DTO;
using System.Collections.Generic;

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