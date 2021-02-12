using Core.DTO;
using System.Collections.Generic;

namespace Core.Service
{
    public interface ITipoocorrenciaService
    {
        int Inserir(Tipoocorrencia tipoocorrencia);

        Tipoocorrencia Obter(int tipoocorrencia);

        IEnumerable<Tipoocorrencia> ObterTodos();

        void Atualizar(Tipoocorrencia tipoocorrencia);

        void Remover(int idTipoocorrencia);

        IEnumerable<TipoocorrenciaDTO> ObterTodosComNomeOrganizacao();


    }
}
