﻿using Core;
using Core.DTO;
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
        public int Inserir(Local local)
        {
            _context.Add(local);
            _context.SaveChanges();
            return local.IdLocal;
        }
        private IQueryable<Local> GetQuery()
        {
            IQueryable<Local> tb_local = _context.Local;
            var query = from local in tb_local
                        select local;
            return query;
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
        public LocalDTO ObterDTO(int idLocal)
        {
            var query = from local in _context.Local
                        join organizacao in _context.Organizacao
                        on local.IdOrganizacao equals organizacao.IdOrganizacao
                        where local.IdLocal == idLocal

                        select new LocalDTO
                        {
                            IdLocal = local.IdLocal,
                            Nome = local.Nome,
                            Latitude = local.Latitude,
                            Longitude = local.Longitude,
                            Cep = local.Cep,
                            Rua = local.Rua,
                            Bairro = local.Bairro,
                            Cidade = local.Cidade,
                            Uf = local.Uf,
                            NumeroEndereco = local.NumeroEndereco,
                            NomeOrganizacao = organizacao.NomeFantasia,
                        };

            return query.First();
        }
        public IEnumerable<LocalDTO> ObterTodosDTO()
        {
            var query = from local in _context.Local
                        join organizacao in _context.Organizacao
                        on local.IdOrganizacao equals organizacao.IdOrganizacao
                        orderby local.Nome

                        select new LocalDTO
                        {
                            IdLocal = local.IdLocal,
                            Nome = local.Nome,
                            Latitude = local.Latitude,
                            Longitude = local.Longitude,
                            Cep = local.Cep,
                            Rua = local.Rua,
                            Bairro = local.Bairro,
                            Cidade = local.Cidade,
                            Uf = local.Uf,
                            NumeroEndereco = local.NumeroEndereco,
                            NomeOrganizacao = organizacao.NomeFantasia,
                        };

            return query.ToList();
        }
        public void Atualizar(Local local)
        {
            _context.Update(local);
            _context.SaveChanges();
        }
        public void Remover(int id)
        {
            var _local = _context.Local.Find(id);
            _context.Local.Remove(_local);
            _context.SaveChanges();
        }
    }
}