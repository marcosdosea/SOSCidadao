using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.Tests
{
	[TestClass()]
	public class TipoocorrenciaServiceTests
	{
		private SosCidadaoContext _context;
		private ITipoocorrenciaService _tipoocorrenciaService;

		[TestInitialize]
		public void Initialize()
		{
			//Arrange
			var builder = new DbContextOptionsBuilder<SosCidadaoContext>();
			builder.UseInMemoryDatabase("SosCidadao");
			var options = builder.Options;

			_context = new SosCidadaoContext(options);
			_context.Database.EnsureDeleted();
			_context.Database.EnsureCreated();
			var tipoOcorrencias = new List<Tipoocorrencia>
				{
					new Tipoocorrencia { IdTipoOcorrencia = 12, Nome = "Assalto", IdOrganizacao =10},
					new Tipoocorrencia { IdTipoOcorrencia = 13, Nome = "Violencia",IdOrganizacao =10},
					new Tipoocorrencia { IdTipoOcorrencia = 14, Nome = "Vandalismo",IdOrganizacao =10},
				};

			_context.AddRange(tipoOcorrencias);
			_context.SaveChanges();

			_tipoocorrenciaService = new TipoocorrenciaService(_context);
		}


		[TestMethod()]
		public void InserirTest()
		{
			// Act
			_tipoocorrenciaService.Inserir(new Tipoocorrencia() { IdTipoOcorrencia = 15, Nome = "Pertubacao", IdOrganizacao = 10 });
			// Assert
			Assert.AreEqual(4, _tipoocorrenciaService.ObterTodos().Count());
			var tipoocorrencia = _tipoocorrenciaService.Obter(4);
			Assert.AreEqual("Violencia", tipoocorrencia.Nome);
			Assert.AreEqual(10, tipoocorrencia.IdOrganizacao);
		}

		[TestMethod()]
		public void EditarTest()
		{
			var tipoocorrencia = _tipoocorrenciaService.Obter(3);
			tipoocorrencia.Nome = "Violencia";
			tipoocorrencia.IdOrganizacao = 10;
			_tipoocorrenciaService.Atualizar(tipoocorrencia);
			tipoocorrencia = _tipoocorrenciaService.Obter(3);
			Assert.AreEqual("Violencia", tipoocorrencia.Nome);
			Assert.AreEqual(10, tipoocorrencia.IdOrganizacao);
		}

		[TestMethod()]
		public void RemoverTest()
		{
			// Act
			_tipoocorrenciaService.Remover(2);
			// Assert
			Assert.AreEqual(2, _tipoocorrenciaService.ObterTodos().Count());
			var tipoocorrencia = _tipoocorrenciaService.Obter(2);
			Assert.AreEqual(null, tipoocorrencia);
		}

		[TestMethod()]
		public void ObterTodosTest()
		{
			// Act
			var listaTipoocorrencia = _tipoocorrenciaService.ObterTodos();
			// Assert
			Assert.IsInstanceOfType(listaTipoocorrencia, typeof(IEnumerable<Tipoocorrencia>));
			Assert.IsNotNull(listaTipoocorrencia);
			Assert.AreEqual(3, listaTipoocorrencia.Count());
			Assert.AreEqual(1, listaTipoocorrencia.First().IdTipoOcorrencia);
			Assert.AreEqual("Violencia", listaTipoocorrencia.First().Nome);
		}



		[TestMethod()]
		public void ObterTest()
		{
			var tipoocorrencia = _tipoocorrenciaService.Obter(1);
			Assert.IsNotNull(tipoocorrencia);
			Assert.AreEqual("Violencia", tipoocorrencia.Nome);
		}



	}
}