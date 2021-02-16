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

        private IQueryable<Pertence> GetQuery()
        {
            IQueryable<Pertence> pertence = _context.Pertence;
            var query = from nome in pertence
                        select nome;
            return query;
        }

        public Pertence Obter(int idPertence)
        {
            var pertence = _context.Pertence.Find(idPertence);
            return pertence;
        }

        public IEnumerable<Pertence> ObterTodos()
        {
            return GetQuery();
        }

        public PertenceDTO ObterDTO(int idPertence)
        {
            var query = from pertence in _context.Pertence
                        where pertence.IdPertence == idPertence

                        select new PertenceDTO
                        {
                            IdPertence = pertence.IdPertence,
                            Nome = pertence.Nome,
                            Descricao = pertence.Descricao,
                            StatusPertence = pertence.StatusPertence,
                            IdOcorrencia =  pertence.IdOcorrencia,
                            IdTipoPertence = pertence.IdTipoPertenceNavigation.IdTipoPertence,
                            NomePertence = pertence.IdTipoPertenceNavigation.Nome
                        };

            return query.First();
        }

        public IEnumerable<PertenceDTO> ObterTodosDTO()
        {
            var query = from pertence in _context.Pertence
                        orderby pertence.Nome

                        select new PertenceDTO
                        {
                            IdPertence = pertence.IdPertence,
                            Nome = pertence.Nome,
                            Descricao = pertence.Descricao,
                            StatusPertence = pertence.StatusPertence,
                            IdOcorrencia = pertence.IdOcorrencia,
                            IdTipoPertence = pertence.IdTipoPertenceNavigation.IdTipoPertence,
                            NomePertence = pertence.IdTipoPertenceNavigation.Nome
                        };

            return query.ToList();
        }

        public void Atualizar(Pertence pertence)
        {
            _context.Update(pertence);
            _context.SaveChanges();
        }

        public void Remover(int idPertence)
        {
            var _pertence  = _context.Pertence.Find(idPertence);
            _context.Pertence.Remove(_pertence);
            _context.SaveChanges();
        }
    }
}
