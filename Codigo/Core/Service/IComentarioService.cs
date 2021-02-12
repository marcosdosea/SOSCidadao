using System.Collections.Generic;

namespace Core.Service
{
    public interface IComentarioService
    {
        int Inserir(Comentario comentario);

        Comentario Obter(int id);

        IEnumerable<Comentario> ObterPorOcorrencia(int id);

        IEnumerable<Comentario> ObterTodos();

        int Atualizar(Comentario comentario);

        int Remover(int id);

    }
}
