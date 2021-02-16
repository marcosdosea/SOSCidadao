using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Service
{
    public interface ITipoocorrenciaService
    {
        int Inserir(Tipoocorrencia tipoOcorrencia);
        Tipoocorrencia Obter(int idTipoOcorrencia);
        IEnumerable<Tipoocorrencia> ObterTodos();
        TipoocorrenciaDTO ObterDTO(int idTipoOcorrencia);
        IEnumerable<TipoocorrenciaDTO> ObterTodosDTO();
        void Atualizar(Tipoocorrencia tipoOcorrencia);
        void Remover(int idTipoOcorrencia);
    }
}
