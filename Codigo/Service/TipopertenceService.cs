using Core;
using Core.DTO;
using Core.Service;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class TipopertenceService : ITipopertenceService
    {
        private readonly SosCidadaoContext _context;
        public TipopertenceService(SosCidadaoContext context)
        {
            _context = context;
        }

        public int Inserir(Tipopertence tipoPertence)
        {
            _context.Add(tipoPertence);
            _context.SaveChanges();
            return tipoPertence.IdTipoPertence;
        }

        public Tipopertence Obter(int idTipoPertence)
        {
            var tipopertence = _context.Tipopertence.Find(idTipoPertence);
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
                        where tipopertence.IdTipoPertence == idTipoPertence

                        select new TipopertenceDTO
                        {
                            IdTipoPertence = tipopertence.IdTipoPertence,
                            Nome = tipopertence.Nome,
                            IdOrganizacao = tipopertence.IdOrganizacaoNavigation.IdOrganizacao,
                            NomeOrganizacao = tipopertence.IdOrganizacaoNavigation.NomeFantasia
                        };

            return query.First();
        }

        public IEnumerable<TipopertenceDTO> ObterTodosDTO()
        {
            var query = from tipopertence in _context.Tipopertence
                        orderby tipopertence.Nome

                        select new TipopertenceDTO
                        {
                            IdTipoPertence = tipopertence.IdTipoPertence,
                            Nome = tipopertence.Nome,
                            IdOrganizacao = tipopertence.IdOrganizacaoNavigation.IdOrganizacao,
                            NomeOrganizacao = tipopertence.IdOrganizacaoNavigation.NomeFantasia
                        };

            return query.ToList();
        }

        public void Atualizar(Tipopertence tipoPertence)
        {
            _context.Update(tipoPertence);
            _context.SaveChanges();
        }

        public void Remover(int idTipoPertence)
        {
            var _tipopertence = _context.Tipopertence.Find(idTipoPertence);
            _context.Tipopertence.Remove(_tipopertence);
            _context.SaveChanges();
        }
    }
}
