
﻿using System.Collections.Generic;
﻿using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;


namespace Core.Service
{
    public interface IComentarioService
    {
        int Inserir(Comentario comentario);


        IEnumerable<Comentario> ObterPorOcorrencia(int id);

        Comentario Obter(int idComentario);

        IEnumerable<Comentario> ObterTodos();

        ComentarioDTO ObterDTO(int idPertence);

        IEnumerable<ComentarioDTO> ObterTodosDTO();

        void Atualizar(Comentario comentario);

        void Remover(int idComentario);
    }
}