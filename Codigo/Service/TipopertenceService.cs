using Core;
using Core.DTO;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public class TipopertenceService : ITipopertenceService
    {
        private readonly SosCidadaoContext _context;
        public TipopertenceService(SosCidadaoContext context)
        {
            _context = context;
        }

        public int Inserir(Tipopertence tipopertence)
        {
            _context.Add(tipopertence);
            _context.SaveChanges();
            return tipopertence.IdTipoPertence;
        }
        public Tipopertence Obter(int idTipopertence)
        {
            var tipopertence = _context.Tipopertence.Find(idTipopertence);
            return tipopertence;
        }
        private IQueryable<Tipopertence> GetQuery()
        {
            IQueryable<Tipopertence> tipopertence = _context.Tipopertence;
            var query = from nome in tipopertence
                        select nome;
            return query;
        }
        public IEnumerable<Tipopertence> ObterTodos()
        {
            return GetQuery();
        }

        public TipopertenceDTO ObterDTO(int idTipoPertence)
        {
            var query = from tipopertence in _context.Tipopertence
                        join organizacao in _context.Organizacao
                        on tipopertence.IdOrganizacao equals organizacao.IdOrganizacao
                        where tipopertence.IdTipoPertence == idTipoPertence

                        select new TipopertenceDTO
                        {
                            IdTipoPertence = tipopertence.IdTipoPertence,
                            Nome = tipopertence.Nome,
                            IdOrganizacao = organizacao.IdOrganizacao,
                            NomeOrganizacao = organizacao.NomeFantasia
                        };

            return query.First();
        }
        public IEnumerable<TipopertenceDTO> ObterTodosDTO()
        {
            var query = from tipopertence in _context.Tipopertence
                        join organizacao in _context.Organizacao
                        on tipopertence.IdOrganizacao equals organizacao.IdOrganizacao
                        orderby tipopertence.Nome

                        select new TipopertenceDTO
                        {
                            IdTipoPertence = tipopertence.IdTipoPertence,
                            Nome = tipopertence.Nome,
                            IdOrganizacao = organizacao.IdOrganizacao,
                            NomeOrganizacao = organizacao.NomeFantasia
                        };

            return query.ToList();
        }
        public void Atualizar(Tipopertence tipopertence)
        {
            _context.Update(tipopertence);
            _context.SaveChanges();
        }

        public void Remover(int idTipopertence)
        {
            var _tipopertence = _context.Tipopertence.Find(idTipopertence);
            _context.Tipopertence.Remove(_tipopertence);
            _context.SaveChanges();
        }
    }
}
