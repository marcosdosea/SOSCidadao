using Core;
using Core.DTO;
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

        public int Inserir(Comentario comentario)
        {
            _context.Add(comentario);
            _context.SaveChanges();
            return comentario.IdComentario;
        }

        private IQueryable<Comentario> GetQuery()
        {
            IQueryable<Comentario> tb_comentario = _context.Comentario;
            var query = from comentario in tb_comentario
                        select comentario;
            return query;
        }

        public Comentario Obter(int idComentario)
        {
            var _comentario = _context.Comentario.Find(idComentario);
            return _comentario;
        }

        public IEnumerable<Comentario> ObterTodos()
        {
            return GetQuery();
        }

        public ComentarioDTO ObterDTO(int idComentario)
        {
            var query = from comentario in _context.Comentario
                        where comentario.IdComentario == idComentario

                        select new ComentarioDTO
                        {
                            IdComentario = comentario.IdComentario,
                            DataCadastro = comentario.DataCadastro,
                            Descricao = comentario.Descricao,
                            IdOcorrencia = comentario.IdOcorrencia,
                            NomePessoa = comentario.IidPessoaNavigation.Nome,
                        };

            return query.First();
        }

        public IEnumerable<ComentarioDTO> ObterTodosDTO()
        {
            var query = from comentario in _context.Comentario
                        orderby comentario.IdComentario

                        select new ComentarioDTO
                        {
                            IdComentario = comentario.IdComentario,
                            DataCadastro = comentario.DataCadastro,
                            Descricao = comentario.Descricao,
                            IdOcorrencia = comentario.IdOcorrencia,
                            NomePessoa = comentario.IidPessoaNavigation.Nome,
                        };

            return query.ToList();
        }

        public void Atualizar(Comentario comentario)
        {
            _context.Update(comentario);
            _context.SaveChanges();

        }

        public void Remover(int idComentario)
        {
            var _comentario = _context.Comentario.Find(idComentario);
            _context.Remove(_comentario);
            _context.SaveChanges();
        }

    }
}