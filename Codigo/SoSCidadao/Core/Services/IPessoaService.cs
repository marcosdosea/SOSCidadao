using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services
{
    public interface IPessoaService
    {
        int Inserir(Pessoa pessoa);

        Pessoa Obter(Pessoa pessoa);

        int Atualizar(Pessoa pessoa);

        int Remover(Pessoa pessoa);

        bool Validar(Pessoa pessoa);

    }
}
