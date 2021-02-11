using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Service
{
    public interface IOcorrenciaService
    {
        int Inserir(Ocorrencia ocorrencia);

        Ocorrencia Obter(int id);

        IEnumerable<Ocorrencia> ObterTodos();

        int Atualizar(Ocorrencia ocorrencia);

        int Remover(int id);

    }
}

