using Core;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    class OcorrenciaService : IOcorrenciaService
    {
        private readonly SosCidadaoContext _context;

        public OcorrenciaService(SosCidadaoContext context)
        {
            _context = context;
        }

        public int Inserir(Ocorrencia ocorrencia)
        {
            _context.Add(ocorrencia);
            _context.SaveChanges();
            return ocorrencia.IdOcorrencia;
        }

        public int Atualizar(Ocorrencia ocorrencia)
        {
            _context.Update(ocorrencia);
            return _context.SaveChanges();

        }

        public Ocorrencia Obter(int id)
        {
            var _ocorrencia = _context.Ocorrencia.Find(id);
            return _ocorrencia;
        }

        public int Remover(int id)
        {
            var _ocorrencia = _context.Ocorrencia.Find(id);
            _context.Ocorrencia.Remove(_ocorrencia);
            return _context.SaveChanges();
        }


        private IQueryable<Ocorrencia> GetQuery()
        {
            IQueryable<Ocorrencia> tb_ocorrencia = _context.Ocorrencia;
            var query = from ocorrencia in tb_ocorrencia
                        select ocorrencia;
            return query;

        }

        public IEnumerable<Ocorrencia> ObterTodos()
        {
            return GetQuery();
        }

    }
}
