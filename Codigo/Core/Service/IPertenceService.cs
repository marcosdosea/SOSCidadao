using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Service
{
    public interface IPertenceService
    {

        int Inserir(Pertence pertence);

        Pertence Obter(int idPertence);

        IEnumerable<Pertence> ObterTodos();

        void Atualizar(Pertence pertence);

        void Remover(int idPertence);
    }
}
