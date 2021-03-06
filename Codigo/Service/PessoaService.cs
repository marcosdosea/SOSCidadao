﻿using Core;
using Core.DTO;
using Core.Service;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Service
{
    public class PessoaService : IPessoaService
    {
        private readonly SosCidadaoContext _context;

        public PessoaService(SosCidadaoContext context)
        {
            _context = context;
        }

        public int Inserir(Pessoa pessoa)
        {
            _context.Add(pessoa);
            _context.SaveChanges();
            return pessoa.IdPessoa;
        }

        private IQueryable<Pessoa> GetQuery()
        {
            IQueryable<Pessoa> tb_pessoa = _context.Pessoa;
            var query = from pessoa in tb_pessoa
                        select pessoa;
            return query;

        }

        public Pessoa Obter(int idPessoa)
        {
            var _pessoa = _context.Pessoa.Find(idPessoa);
            return _pessoa;

        }

        public IEnumerable<Pessoa> ObterTodos()
        {
            return GetQuery();
        }
        
        public PessoaDTO ObterDTO(int idPessoa)
        {
            var query = from pessoa in _context.Pessoa
                        where pessoa.IdPessoa == idPessoa

                        select new PessoaDTO
                        {
                            IdPessoa = pessoa.IdPessoa,
                            Nome = pessoa.Nome,
                            Sexo = pessoa.Sexo,
                            Cpf = pessoa.Cpf,
                            Telefone = pessoa.Telefone,
                            DataNascimento = pessoa.DataNascimento,
                            Cidade = pessoa.Cidade,
                            TipoPessoa = pessoa.TipoPessoa,
                            StatusPessoa = pessoa.StatusPessoa,
                            DataCadastro = pessoa.DataCadastro,
                            NomeOrganizacao = pessoa.IdOrganizacaoNavigation.NomeFantasia
                        };

            return query.First();
        }
        public IEnumerable<PessoaDTO> ObterTodosDTO()
        {
            var query = from pessoa in _context.Pessoa
                        orderby pessoa.Nome

                        select new PessoaDTO
                        {
                            IdPessoa = pessoa.IdPessoa,
                            Nome = pessoa.Nome,
                            Sexo = pessoa.Sexo,
                            Cpf = pessoa.Cpf,
                            Telefone = pessoa.Telefone,
                            DataNascimento = pessoa.DataNascimento,
                            Cidade = pessoa.Cidade,
                            TipoPessoa = pessoa.TipoPessoa,
                            StatusPessoa = pessoa.StatusPessoa,
                            DataCadastro = pessoa.DataCadastro,
                            NomeOrganizacao = pessoa.IdOrganizacaoNavigation.NomeFantasia
                        };

            return query.ToList();
        }

        public void Atualizar(Pessoa pessoa)
        {
            _context.Update(pessoa);
            _context.SaveChanges();

        }

        public void Remover(int idPessoa)
        {
            var _pessoa = _context.Pessoa.Find(idPessoa);
            _context.Pessoa.Remove(_pessoa);
            _context.SaveChanges();
        }
    }
}