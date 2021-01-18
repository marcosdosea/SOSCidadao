using Core;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public class PessoaService : IPessoaService
    {
        private readonly SosCidadaoContext _context;

        public PessoaService(SosCidadaoContext context)
        {
            _context = context;
        }

        public int Atualizar(Pessoa pessoa)
        {
            _context.Update(pessoa);
            return _context.SaveChanges();

        }

        public int Inserir(Pessoa pessoa)
        {
            _context.Add(pessoa);
            _context.SaveChanges();
            return pessoa.IdPessoa;
        }

        public Pessoa Obter(int id)
        {
            var _pessoa = _context.Pessoa.Find(id);
            return _pessoa;

        }

        public IEnumerable<Pessoa> ObterTodos()
        {
            return GetQuery();
        }

        private IQueryable<Pessoa> GetQuery()
        {
            IQueryable<Pessoa> tb_pessoa = _context.Pessoa;
            var query = from pessoa in tb_pessoa
                        select pessoa;
            return query;

        }

        public int Remover(int id)
        {
            var _pessoa = _context.Pessoa.Find(id);
            _context.Pessoa.Remove(_pessoa);
            return _context.SaveChanges();
        }

        public bool Validar(Pessoa pessoa)
        {
            throw new NotImplementedException();
        }

        public Pessoa Autenticar(Pessoa pessoa)
        {
            var _pessoa = _context.Pessoa.Find(pessoa.Login, pessoa.Senha);
            return _pessoa;

        }
    }
}
