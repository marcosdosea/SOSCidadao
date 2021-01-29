using Core;
using Core.DTO;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    class OrganizacaoService : IOrganizacaoService
    {
        private readonly SosCidadaoContext _context;

        public OrganizacaoService(SosCidadaoContext context)
        {
            _context = context;
        }
      
        public int Inserir(Organizacao organizacao)
        {
            _context.Add(organizacao);
            _context.SaveChanges();
            return organizacao.IdOrganizacao;
        }

        public void Atualizar(Organizacao organizacao)
        {
            _context.Update(organizacao);
            _context.SaveChanges();
        }

        public void Remover(Organizacao IdOrganizacao)
        {
            var _organizacao = _context.Organizacao.Find(IdOrganizacao);
            _context.Organizacao.Remove(_organizacao);
            _context.SaveChanges();
        }

        private IQueryable<Organizacao> GetQuery()
        {
            IQueryable<Organizacao> tb_organizacao = _context.Organizacao;
            var query = from NomeFantasia in tb_organizacao
                        select NomeFantasia;
            return query;
        }

        public Organizacao Obter(int IdOrganizacao)
        {
            var _organizacao= _context.Organizacao.Find(IdOrganizacao);
            return _organizacao;
        }
        
        public IEnumerable<OrganizacaoDTO> ObterPorNomeOrdenadoDescending(string NomeFantasia)
        {
            IQueryable<Organizacao> tb_organizacao = _context.Organizacao;
            var query = from organizacao in tb_organizacao
                        where NomeFantasia.StartsWith(NomeFantasia)
                        orderby organizacao.NomeFantasia descending
                        select new OrganizacaoDTO
                        {
                            NomeFantasia = organizacao.NomeFantasia
                        };
            return query;
        }

        public IEnumerable<Organizacao> ObterTodos()
        {
            return GetQuery();
        }
    }
}
