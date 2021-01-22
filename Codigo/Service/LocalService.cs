using Core;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public class LocalService : ILocalService
    {
        private readonly SosCidadaoContext _context;

        public LocalService(SosCidadaoContext context)
        {
            _context = context;
        }

        public int Atualizar(Local local)
        {
            _context.Update(local);
            return _context.SaveChanges();

        }

        public int Inserir(Local local)
        {
            _context.Add(local);
            _context.SaveChanges();
            return local.IdLocal;
        }

        public Local Obter(int id)
        {
            var _local = _context.Local.Find(id);
            return _local;

        }

        public IEnumerable<Local> ObterTodos()
        {
            return GetQuery();
        }

        private IQueryable<Local> GetQuery()
        {
            IQueryable<Local> tb_local = _context.Local;
            var query = from local in tb_local
                        select local;
            return query;

        }

        public int Remover(int id)
        {
            var _local = _context.Local.Find(id);
            _context.Local.Remove(_local);
            return _context.SaveChanges();
        }
    }
}
