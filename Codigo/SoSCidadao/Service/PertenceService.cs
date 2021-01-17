using Core;
using Core.DTO;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public class PertenceService : IPertenceService
    {
        private readonly SosCidadaoContext _context;
        public PertenceService(SosCidadaoContext context)
        {
            _context = context;
        }

        public int Inserir(Pertence pertence)
        {
            _context.Add(pertence);
            _context.SaveChanges();
            return pertence.IdPertence;
        }
        public Pertence Obter(int idPertence)
        {
            var pertence = _context.Pertence.Find(idPertence);
            return pertence;
        }
        private IQueryable<Pertence> GetQuery()
        {
            IQueryable<Pertence> pertence = _context.Pertence;
            var query = from nome in pertence
                        select nome;
            return query;
        }
        public IEnumerable<Pertence> ObterTodos()
        {
            return GetQuery();
        }

        public void Atualizar(Pertence pertence)
        {
            _context.Update(pertence);
            _context.SaveChanges();
        }

        public void Remover(int idPertence)
        {
            var _pertence  = _context.Tipopertence.Find(idPertence);
            _context.Tipopertence.Remove(_pertence);
            _context.SaveChanges();
        }
    }
}
