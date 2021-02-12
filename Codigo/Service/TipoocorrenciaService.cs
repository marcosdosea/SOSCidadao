using Core;
using Core.DTO;
using Core.Service;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class TipoocorrenciaService : ITipoocorrenciaService
    {
        private readonly SosCidadaoContext _context;
        public TipoocorrenciaService(SosCidadaoContext context)
        {
            _context = context;
        }

        public int Inserir(Tipoocorrencia tipoocorrencia)
        {
            _context.Add(tipoocorrencia);
            _context.SaveChanges();
            return tipoocorrencia.IdTipoOcorrencia;
        }

        public Tipoocorrencia Obter(int idTipoocorrencia)
        {

            var tipoocorrencia = _context.Tipoocorrencia.Find(idTipoocorrencia);
            return tipoocorrencia;
        }

        private IQueryable<Tipoocorrencia> GetQuery()
        {
            IQueryable<Tipoocorrencia> tipoocorrencia = _context.Tipoocorrencia;
            var query = from nome in tipoocorrencia
                        select nome;
            return query;
        }

        public IEnumerable<Tipoocorrencia> ObterTodos()
        {
            return GetQuery();
        }
        public void Atualizar(Tipoocorrencia tipoocorrencia)
        {
            _context.Update(tipoocorrencia);
            _context.SaveChanges();
        }

        public void Remover(int idTipoocorrencia)
        {
            var _tipoocorrencia = _context.Tipoocorrencia.Find(idTipoocorrencia);
            _context.Tipoocorrencia.Remove(_tipoocorrencia);
            _context.SaveChanges();
        }


        /// <summary>
        /// Obtém lista de todas os Tipo Ocorrências Com as Organizações
        /// </summary>
        public IEnumerable<TipoocorrenciaDTO> ObterTodosComNomeOrganizacao()
        {
            var query = from tipo_ocorrencia in _context.Tipoocorrencia
                        join organizacao in _context.Organizacao
                        on tipo_ocorrencia.IdOrganizacao equals organizacao.IdOrganizacao
                        orderby tipo_ocorrencia.Nome
                        select new TipoocorrenciaDTO
                        {
                            IdTipoOcorrencia = tipo_ocorrencia.IdTipoOcorrencia,
                            Nome = tipo_ocorrencia.Nome,
                            IdOrganizacao = organizacao.IdOrganizacao,
                            NomeFantasiaOrganizacao = organizacao.NomeFantasia,
                        };

            return query.ToList();

        }
    }
}
