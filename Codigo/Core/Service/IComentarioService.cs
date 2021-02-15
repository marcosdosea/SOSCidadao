using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Service
{
    public interface IComentarioService
    {
        int Inserir(Comentario comentario);
        Comentario Obter(int idComentario);
        IEnumerable<Comentario> ObterTodos();
        ComentarioDTO ObterDTO(int idPertence);
        IEnumerable<ComentarioDTO> ObterTodosDTO();
        void Atualizar(Comentario comentario);
        void Remover(int idComentario);
    }
}