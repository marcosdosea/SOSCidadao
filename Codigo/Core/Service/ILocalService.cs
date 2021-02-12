using System.Collections.Generic;

namespace Core.Service
{
    public interface ILocalService
    {
        int Inserir(Local local);

        Local Obter(int id);

        IEnumerable<Local> ObterTodos();

        int Atualizar(Local local);

        int Remover(int id);
    }
}
