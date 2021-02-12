using System.Collections.Generic;

namespace Core.Service
{
    public interface ITipopertenceService
    {
        int Inserir(Tipopertence tipopertence);

        Tipopertence Obter(int idTipopertence);

        IEnumerable<Tipopertence> ObterTodos();

        void Atualizar(Tipopertence tipopertence);

        void Remover(int idTipopertence);
    }
}
