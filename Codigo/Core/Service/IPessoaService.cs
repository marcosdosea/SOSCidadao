using System.Collections.Generic;

namespace Core.Service
{
    public interface IPessoaService
    {

        int Inserir(Pessoa pessoa);

        Pessoa Obter(int id);

        IEnumerable<Pessoa> ObterTodos();

        int Atualizar(Pessoa pessoa);

        int Remover(int id);

        bool Validar(Pessoa pessoa);
    }
}
