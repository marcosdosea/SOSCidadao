using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

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
