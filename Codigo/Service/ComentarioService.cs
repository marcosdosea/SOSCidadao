using Core;
using Core.Service;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class ComentarioService : IComentarioService
    {
        private readonly SosCidadaoContext _context;

        public ComentarioService(SosCidadaoContext context)
        {
            _context = context;
        }

        public int Atualizar(Comentario comentario)
        {
            _context.Update(comentario);
            return _context.SaveChanges();
        }

        public int Inserir(Comentario comentario)
        {
            _context.Add(comentario);
            _context.SaveChanges();
            return comentario.IdComentario;
        }

        public Comentario Obter(int id)
        {
            var _comentario = _context.Comentario.Find(id);
            return _comentario;
        }


        public IEnumerable<Comentario> ObterTodos()
        {
            return GetQuery();
        }

        public IEnumerable<Comentario> ObterPorOcorrencia(int id)
        {
            return GetQuery();
        }

        private IQueryable<Comentario> GetQuery()
        {
            IQueryable<Comentario> tb_comentario = _context.Comentario;
            var query = from comentario in tb_comentario
                        select comentario;
            return query;

        }

        public int Remover(int id)
        {
            var _comentario = _context.Comentario.Find(id);
            _context.Remove(_comentario);
            return _context.SaveChanges();

        }

    }
}
