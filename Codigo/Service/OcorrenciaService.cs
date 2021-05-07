using Core;
using Core.DTO;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public class OcorrenciaService : IOcorrenciaService
    {
        private readonly SosCidadaoContext _context;

        public OcorrenciaService(SosCidadaoContext context)
        {
            _context = context;
        }

        public int Editar(Ocorrencia ocorrencia)
        {
            _context.Add(ocorrencia);
            _context.SaveChanges();
            return ocorrencia.IdOcorrencia;
        }

        private IQueryable<Ocorrencia> GetQuery()
        {
            IQueryable<Ocorrencia> tb_ocorrencia = _context.Ocorrencia;
            var query = from ocorrencia in tb_ocorrencia
                        select ocorrencia;
            return query;

        }

        public Ocorrencia Obter(int idOcorrencia)
        {
            var _ocorrencia = _context.Ocorrencia.Find(idOcorrencia);
            return _ocorrencia;

        }

        public IEnumerable<Ocorrencia> ObterTodos()
        {
            return GetQuery();
        }

        public OcorrenciaDTO ObterDTO(int idOcorrencia)
        {
            var query = from ocorrencia in _context.Ocorrencia
                        where ocorrencia.IdOcorrencia == idOcorrencia

                        select new OcorrenciaDTO
                        {
                            IdOcorrencia = ocorrencia.IdOcorrencia,
                            DataCadastro = ocorrencia.DataCadastro,
                            StatusOcorrencia = ocorrencia.StatusOcorrencia,
                            Descricao = ocorrencia.Descricao,
                            Emergencia = ocorrencia.Emergencia,
                            IdLocal = ocorrencia.IdLocal

                        };

            return query.First();
        }
        public IEnumerable<OcorrenciaDTO> ObterTodosDTO()
        {
            var query = from ocorrencia in _context.Ocorrencia
                        orderby ocorrencia.IdOcorrencia

                        select new OcorrenciaDTO
                        {
                            IdOcorrencia = ocorrencia.IdOcorrencia,
                            DataCadastro = ocorrencia.DataCadastro,
                            StatusOcorrencia = ocorrencia.StatusOcorrencia,
                            Descricao = ocorrencia.Descricao,
                            Emergencia = ocorrencia.Emergencia,
                            IdLocal = ocorrencia.IdLocal
                        };

            return query.ToList();
        }

        public void Atualizar(Ocorrencia ocorrencia)
        {
            _context.Update(ocorrencia);
            _context.SaveChanges();

        }

        public void Remover(int idOcorrencia)
        {
            var _ocorrencia = _context.Ocorrencia.Find(idOcorrencia);
            _context.Ocorrencia.Remove(_ocorrencia);
            _context.SaveChanges();
        }
              
    }
}
