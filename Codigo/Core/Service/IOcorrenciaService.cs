using System.Collections.Generic;
using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Service
{
    public interface IOcorrenciaService
    {
        int Inserir(Ocorrencia ocorrencia);
        Ocorrencia Obter(int idOcorrencia);
        IEnumerable<Ocorrencia> ObterTodos();
        OcorrenciaDTO ObterDTO(int idOcorrencia);
        IEnumerable<OcorrenciaDTO> ObterTodosDTO();
        void Atualizar(Ocorrencia ocorrencia);
        void Remover(int idOcorrencia);
    }
}
