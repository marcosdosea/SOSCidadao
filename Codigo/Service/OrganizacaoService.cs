﻿using Core;
using Core.DTO;
using Core.Service;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class OrganizacaoService : IOrganizacaoService
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

        private IQueryable<Organizacao> GetQuery()
        {
            IQueryable<Organizacao> tb_organizacao = _context.Organizacao;
            var query = from NomeFantasia in tb_organizacao
                        select NomeFantasia;
            return query;
        }

        public Organizacao Obter(int IdOrganizacao)
        {
            var _organizacao = _context.Organizacao.Find(IdOrganizacao);
            return _organizacao;
        }

        public IEnumerable<Organizacao> ObterTodos()
        {
            return GetQuery();
        }

        public OrganizacaoDTO ObterDTO(int idOrganizacao)
        {
            var query = from organizacao in _context.Organizacao
                        where organizacao.IdOrganizacao == idOrganizacao && organizacao.IdOrganizacao > 1

                        select new OrganizacaoDTO
                        {
                            IdOrganizacao = organizacao.IdOrganizacao,
                            Cnpj = organizacao.Cnpj,
                            NomeRazao = organizacao.NomeRazao,
                            NomeFantasia = organizacao.NomeFantasia,
                            Cep = organizacao.Cep,
                            Rua = organizacao.Rua,
                            Bairro = organizacao.Bairro,
                            Cidade = organizacao.Cidade,
                            Uf = organizacao.Uf,
                            NumeroEndereco = organizacao.NumeroEndereco,
                            DataRegistro = organizacao.DataRegistro,
                            NomePessoa = organizacao.IdPessoaNavigation.Nome,
                        };

            return query.First();
        }

        public IEnumerable<OrganizacaoDTO> ObterTodosDTO()
        {
            var query = from organizacao in _context.Organizacao
                        where organizacao.IdOrganizacao > 1
                        orderby organizacao.NomeFantasia

                        select new OrganizacaoDTO
                        {
                            IdOrganizacao = organizacao.IdOrganizacao,
                            Cnpj = organizacao.Cnpj,
                            NomeRazao = organizacao.NomeRazao,
                            NomeFantasia = organizacao.NomeFantasia,
                            Cep = organizacao.Cep,
                            Rua = organizacao.Rua,
                            Bairro = organizacao.Bairro,
                            Cidade = organizacao.Cidade,
                            Uf = organizacao.Uf,
                            NumeroEndereco = organizacao.NumeroEndereco,
                            DataRegistro = organizacao.DataRegistro,
                            NomePessoa = organizacao.IdPessoaNavigation.Nome,
                        };

            return query.ToList();
        }

        public void Atualizar(Organizacao organizacao)
        {
            _context.Update(organizacao);
            _context.SaveChanges();
        }

        public void Remover(int IdOrganizacao)
        {
            var _organizacao = _context.Organizacao.Find(IdOrganizacao);
            _context.Organizacao.Remove(_organizacao);
            _context.SaveChanges();
        }
    }
}