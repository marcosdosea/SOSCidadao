
﻿using System.Collections.Generic;
﻿using Core.DTO;
using System;
using System.Text;


namespace Core.Service
{
    public interface IComentarioService
    {
        int Inserir(Comentario comentario);

        Comentario Obter(int idComentario);

        IEnumerable<Comentario> ObterTodos();

        ComentarioDTO ObterDTO(int idComentario);

        IEnumerable<ComentarioDTO> ObterTodosDTO();

        void Atualizar(Comentario comentario);

        void Remover(int idComentario);
    }
}