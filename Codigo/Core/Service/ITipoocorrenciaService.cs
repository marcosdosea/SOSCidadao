using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Service
{
    public interface ITipoocorrenciaService
    {
        int Inserir(Tipoocorrencia tipoocorrencia);

        Tipoocorrencia Obter(int tipoocorrencia);

        IEnumerable<Tipoocorrencia> ObterTodos();

        void Atualizar(Tipoocorrencia tipoocorrencia);

        void Remover(int idTipoocorrencia);

        IEnumerable<TipoocorrenciaDTO> TipoOcorrenciaOrganizacao();
    }
}
