using Core;
using Core.DTO;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public class TipoocorrenciaService : ITipoocorrenciaService
    {
        private readonly SosCidadaoContext _context;
        public TipoocorrenciaService(SosCidadaoContext context)
        {
            _context = context;
        }

        public int Inserir(Tipoocorrencia tipoOcorrencia)
        {
            _context.Add(tipoOcorrencia);
            _context.SaveChanges();
            return tipoOcorrencia.IdTipoOcorrencia;
        }

        private IQueryable<Tipoocorrencia> GetQuery()
        {
            IQueryable<Tipoocorrencia> tipoocorrencia = _context.Tipoocorrencia;
            var query = from nome in tipoocorrencia
                        select nome;
            return query;
        }

        public Tipoocorrencia Obter(int idTipoOcorrencia)
        {

            var tipoocorrencia = _context.Tipoocorrencia.Find(idTipoOcorrencia);
            return tipoocorrencia;
        }

        public IEnumerable<Tipoocorrencia> ObterTodos()
        {
            return GetQuery();
        }

        public TipoocorrenciaDTO ObterDTO(int idTipoOcorrencia)
        {
            var query = from tipoOcorrencia in _context.Tipoocorrencia
                        where tipoOcorrencia.IdTipoOcorrencia == idTipoOcorrencia

                        select new TipoocorrenciaDTO
                        {
                            IdTipoOcorrencia = tipoOcorrencia.IdTipoOcorrencia,
                            IdOrganizacao = tipoOcorrencia.IdOrganizacao,
                            Nome = tipoOcorrencia.Nome,
                            NomeOrganizacao = tipoOcorrencia.IdOrganizacaoNavigation.NomeFantasia
                        };

            return query.First();
        }

        public IEnumerable<TipoocorrenciaDTO> ObterTodosDTO()
        {
            var query = from tipoOcorrencia in _context.Tipoocorrencia
                        orderby tipoOcorrencia.Nome

                        select new TipoocorrenciaDTO
                        {
                            IdTipoOcorrencia = tipoOcorrencia.IdTipoOcorrencia,
                            IdOrganizacao = tipoOcorrencia.IdOrganizacao,
                            Nome = tipoOcorrencia.Nome,
                            NomeOrganizacao = tipoOcorrencia.IdOrganizacaoNavigation.NomeFantasia
                        };

            return query.ToList();
        }

        public void Atualizar(Tipoocorrencia tipoOcorrencia)
        {
            _context.Update(tipoOcorrencia);
            _context.SaveChanges();
        }

        public void Remover(int idTipoOcorrencia)
        {
            var _tipoocorrencia = _context.Tipoocorrencia.Find(idTipoOcorrencia);
            _context.Tipoocorrencia.Remove(_tipoocorrencia);
            _context.SaveChanges();
        }
    }
}
