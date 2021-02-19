using Core.DTO;
using System.Collections.Generic;

namespace Core.Service
{
    public interface ITipoocorrenciaService
    {
        int Inserir(Tipoocorrencia tipoOcorrencia);
        Tipoocorrencia Obter(int idtipoOcorrencia);
        IEnumerable<Tipoocorrencia> ObterTodos();
        TipoocorrenciaDTO ObterDTO(int idtipoOcorrencia);
        IEnumerable<TipoocorrenciaDTO> ObterTodosDTO();
        void Atualizar(Tipoocorrencia tipoOcorrencia);
        void Remover(int idtipoOcorrencia);
    }
}
