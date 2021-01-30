using System;
using System.Collections.Generic;
using System.Text;

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
